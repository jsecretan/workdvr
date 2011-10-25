using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32; 
using System.IO;

namespace WorkDVR
{
    public partial class Options : Form
    {
        private const int heightWoLicenseBlock = 385;
        private const string autoRunRegKey = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            // not resizable form
            this.MinimumSize = new Size(Size.Width, Size.Height);
            this.MaximumSize = new Size(Size.Width, Size.Height);

            // remove License block if product is already buyed
            if (LicenseManager.ProgramRegistered())
            {
                removeLicenseBlock();
            }
            else
            {
                // link to buy a license
                buyLicenseLinkLabel.Text = Properties.Settings.Default.LicenseUrl;
                registerButton.Enabled = false;
            }
        }

        private void storeFolderButton_Click(object sender, EventArgs e)
        {
            if (storeFolderDialog.ShowDialog() == DialogResult.OK)
            {
                storeFolderTextBox.Text = storeFolderDialog.SelectedPath;
            }
        }

        private void Options_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                captureFrameEveryTextBox.Text = Properties.Settings.Default.CaptureFrameInterval.ToString();
                storeFolderTextBox.Text = Properties.Settings.Default.FramesStoreFolder;
                keepMbRecodingsTextBox.Text = Properties.Settings.Default.KeepMBRecodings.ToString();
                deleteStoredButton.Enabled = false;

                // reed run on startup checkbox from registry
                RegistryKey regKeyAutorun = Registry.CurrentUser.OpenSubKey(autoRunRegKey);
                string path = System.Windows.Forms.Application.ExecutablePath;
                string fileName = Path.GetFileName(path);
                runOnStartupCheckBox.Checked = regKeyAutorun.GetValue(fileName) != null;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CaptureFrameInterval = int.Parse(captureFrameEveryTextBox.Text);
            Properties.Settings.Default.FramesStoreFolder = storeFolderTextBox.Text;
            Properties.Settings.Default.KeepMBRecodings = int.Parse(keepMbRecodingsTextBox.Text);
            
            Properties.Settings.Default.Save();

            // set registry key from run on startup checkbox
            RegistryKey regKeyAutorun = Registry.CurrentUser.CreateSubKey(autoRunRegKey);
            string path = System.Windows.Forms.Application.ExecutablePath;
            string fileName = Path.GetFileName(path);

            if (runOnStartupCheckBox.Checked)
            {
                regKeyAutorun.SetValue(fileName, path);
            }
            else
            {
                regKeyAutorun.DeleteValue(fileName);
            }

            this.Hide();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void deleteStoredButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm delete", "Delete stored recordings?", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            // delete old images preparation
            DateTime checkPoint = DateTime.UtcNow;

            switch (deleteOptionsComboBox.SelectedIndex)
            {
                case 0: // the past hour
                    checkPoint = DateTime.UtcNow.AddHours(-1);
                    break;
                case 1: // the last 24 hours
                    checkPoint = DateTime.UtcNow.AddHours(-24);
                    break;
                case 2: // the last week
                    checkPoint = DateTime.UtcNow.AddDays(-7);
                    break;
                case 3: // everything
                    checkPoint = DateTime.MinValue;
                    break;
                default:
                    return;
            };

            // delete all images
            if (checkPoint.Equals(DateTime.MinValue))
            {
                StoreFolderManager.DeleteAllRecords();
                return;
            }

            // delete images according to selected parameter
            StoreFolderManager.DeleteRecords(checkPoint);
        }

        private void deleteOptionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteStoredButton.Enabled = (deleteOptionsComboBox.SelectedIndex >= 0);
        }

        private void enterLicKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            registerButton.Enabled = enterLicKeyTextBox.Text.Length != 0;
        }

        // remove License block if product is already buyed
        private void removeLicenseBlock()
        {
            licenseGroupBox.Visible = false;
            this.MinimumSize = new Size(Size.Width, heightWoLicenseBlock);
            this.MaximumSize = new Size(Size.Width, heightWoLicenseBlock);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (LicenseManager.EnterLicenseKey(enterLicKeyTextBox.Text))
            {
                removeLicenseBlock();
            }
        }

        // open link in the default web browser
        private void buyLicenseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(buyLicenseLinkLabel.Text);
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

    }
}
