using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkDVR
{
    public partial class License : Form
    {
        public License()
        {
            InitializeComponent();
        }

        private void License_Load(object sender, EventArgs e)
        {
            // not resizable form
            this.MinimumSize = new Size(Size.Width, Size.Height);
            this.MaximumSize = new Size(Size.Width, Size.Height);

            buyLicenseLinkLabel.Text = Properties.Settings.Default.LicenseUrl;
            registerButton.Enabled = false;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (LicenseManager.EnterLicenseKey(enterLicKeyTextBox.Text))
            {
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buyLicenseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(buyLicenseLinkLabel.Text);
        }

        private void enterLicKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            registerButton.Enabled = enterLicKeyTextBox.Text.Length != 0;
        }
    }
}
