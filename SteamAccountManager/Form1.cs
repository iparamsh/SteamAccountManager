using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SteamAccountManager
{
    public partial class Form1 : Form
    {

        Encryption encryption = new Encryption();
        private byte[] key; 

        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(
        string PathName,
        StringBuilder VolumeNameBuffer,
        UInt32 VolumeNameSize,
        ref UInt32 VolumeSerialNumber,
        ref UInt32 MaximumComponentLength,
        ref UInt32 FileSystemFlags,
        StringBuilder FileSystemNameBuffer,
        UInt32 FileSystemNameSize);

        public string filePath = @"C:/someData.txt"; // you can change path here
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initializeKey();
            steamProcessKiller();
            if (!File.Exists(filePath))
            {
                var myFile = File.CreateText(filePath);
                myFile.Close();
            }
            parseComboBox();
        }

        private void initializeKey()
        {
            string hash = encryption.ComputeSHA256Hash(getDriveSerialNumber());
            hash = hash.Substring(0, Math.Min(hash.Length, 24));
            this.key = Convert.FromBase64String(hash);
            this.key = encryption.stripKey(this.key);
        }

        private void parseComboBox()
        {
            comboBox1.Items.Clear();
            List<string> data = new List<string>();

            data = File.ReadAllLines(filePath).ToList();

            for (int ctr = 0; ctr < data.Count(); ctr++)
            {
                comboBox1.Items.Add(data[ctr].Substring(0, data[ctr].IndexOf(',')));
            }
        }

        private void steamProcessKiller()
        {
            foreach (var currentProcess in Process.GetProcessesByName("steam"))
            {
                currentProcess.Kill();
            }
        }

        private void addAccountToList_button_Click(object sender, EventArgs e)
        {
            List<string> data = new List<string>();

            data = File.ReadAllLines(filePath).ToList();
            string username = Convert.ToBase64String(encryption.Encrypt(username_textBox.Text, this.key));
            string password = Convert.ToBase64String(encryption.Encrypt(password_textBox.Text, this.key));

            data.Add(accName_textBox.Text + "," + username + ":" + password);

            File.WriteAllLines(filePath, data);

            MessageBox.Show("Account added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            parseComboBox();
        }

        private string getDriveSerialNumber()
        {
            DriveInfo[] drives = DriveInfo.GetDrives(); 

            uint serial_number = 0;
            uint max_component_length = 0;
            StringBuilder sb_volume_name = new StringBuilder(256);
            UInt32 file_system_flags = new UInt32();
            StringBuilder sb_file_system_name = new StringBuilder(256);

            if (GetVolumeInformation(drives[0].Name, sb_volume_name,
                (UInt32)sb_volume_name.Capacity, ref serial_number,
                ref max_component_length, ref file_system_flags,
                sb_file_system_name,
                (UInt32)sb_file_system_name.Capacity) == 0)
            {
                MessageBox.Show("Error getting volume information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //MessageBox.Show(serial_number.ToString());
                return serial_number.ToString();
            }

            return "";
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem.ToString();

            string usernameToLogin = getAccountDataByName(comboBox1.SelectedItem.ToString(), "username");
            string passwordToLogin = getAccountDataByName(comboBox1.SelectedItem.ToString(), "password");

            usernameToLogin = encryption.Decrypt(Convert.FromBase64String(usernameToLogin), this.key);
            passwordToLogin = encryption.Decrypt(Convert.FromBase64String(passwordToLogin), this.key);

            if (usernameToLogin != "" && passwordToLogin != "")
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();

                processStartInfo.FileName = (String)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Valve\Steam", "SteamExe", "null");
                processStartInfo.Arguments = " -login " + usernameToLogin + " " + passwordToLogin;

                Process.Start(processStartInfo);
            }
            else
            {
                MessageBox.Show("Error: can't get username or password");
            }

            Application.Exit();
        }
         
        private string getAccountDataByName(string nameOfAccount, string dataToGet)
        {
            List<string> accData = new List<string>();

            accData = File.ReadAllLines(filePath).ToList();

            for (int ctr = 0; ctr < accData.Count(); ctr++)
            {
                if (accData[ctr].Substring(0, accData[ctr].IndexOf(',')) == nameOfAccount)
                {
                    if (dataToGet == "username")
                    {
                        return accData[ctr].Substring(accData[ctr].IndexOf(',') + 1, accData[ctr].IndexOf(':') - accData[ctr].IndexOf(',') - 1);
                    }
                    else
                    {
                        return accData[ctr].Substring(accData[ctr].IndexOf(':') + 1, accData[ctr].Length - accData[ctr].IndexOf(':') - 1);
                    }
                }
            }

            return "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/IlliaParamosh/SteamAccountManager");
        }
    }
}
