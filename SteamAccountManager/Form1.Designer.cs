
namespace SteamAccountManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.accName_textBox = new System.Windows.Forms.TextBox();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.addAccountToList_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.login_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.OldLace;
            this.label1.Location = new System.Drawing.Point(53, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Powered by Chadz group (click to join discord)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // accName_textBox
            // 
            this.accName_textBox.Location = new System.Drawing.Point(12, 12);
            this.accName_textBox.Name = "accName_textBox";
            this.accName_textBox.Size = new System.Drawing.Size(137, 22);
            this.accName_textBox.TabIndex = 1;
            this.accName_textBox.Text = "Name of the account";
            // 
            // username_textBox
            // 
            this.username_textBox.Location = new System.Drawing.Point(12, 56);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(137, 22);
            this.username_textBox.TabIndex = 2;
            this.username_textBox.Text = "username";
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(12, 100);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(137, 22);
            this.password_textBox.TabIndex = 3;
            this.password_textBox.Text = "Password";
            // 
            // addAccountToList_button
            // 
            this.addAccountToList_button.Location = new System.Drawing.Point(12, 140);
            this.addAccountToList_button.Name = "addAccountToList_button";
            this.addAccountToList_button.Size = new System.Drawing.Size(136, 23);
            this.addAccountToList_button.TabIndex = 4;
            this.addAccountToList_button.Text = "Add account";
            this.addAccountToList_button.UseVisualStyleBackColor = true;
            this.addAccountToList_button.Click += new System.EventHandler(this.addAccountToList_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 34);
            this.label2.TabIndex = 5;
            this.label2.Text = "if you think that this is a scam or something, here is an\r\n open source";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(173, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(217, 24);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "Here is names of the accounts";
            // 
            // login_button
            // 
            this.login_button.Font = new System.Drawing.Font("NSimSun", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_button.Location = new System.Drawing.Point(173, 43);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(217, 79);
            this.login_button.TabIndex = 7;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(402, 324);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addAccountToList_button);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.username_textBox);
            this.Controls.Add(this.accName_textBox);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "steam account manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox accName_textBox;
        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Button addAccountToList_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button login_button;
    }
}

