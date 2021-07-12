using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccountManager
{
    public partial class Form1 : Form
    {
        public string filePath = @"C:/someData.txt"; // you can change path here
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            steamProcessKiller();
            if (!File.Exists(filePath))
            {
                var myFile = File.CreateText(filePath);
                myFile.Close();
            }
            parseComboBox();
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

            data.Add(accName_textBox.Text + "," + username_textBox.Text + "/" + password_textBox.Text);

            File.WriteAllLines(filePath, data);

            parseComboBox();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/C8sMqTRkDM");
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem.ToString();

            string usernameToLogin = getAccountDataByName(comboBox1.SelectedItem.ToString(), "username");
            string passwordToLogin = getAccountDataByName(comboBox1.SelectedItem.ToString(), "password");

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
                        return accData[ctr].Substring(accData[ctr].IndexOf(',') + 1, accData[ctr].IndexOf('/') - accData[ctr].IndexOf(',') - 1);
                    }
                    else
                    {
                        return accData[ctr].Substring(accData[ctr].IndexOf('/') + 1, accData[ctr].Length - accData[ctr].IndexOf('/') - 1);
                    }
                }
            }

            return "";
        }
    }
}
