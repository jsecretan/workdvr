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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            // not resizable form
            this.MinimumSize = new Size(Size.Width, Size.Height);
            this.MaximumSize = new Size(Size.Width, Size.Height);
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
                captureFrameEveryTextBox.Text = ConfigManager.GetProperty(ConfigManager.captureFrameIntervalProperty);
                storeFolderTextBox.Text = ConfigManager.GetProperty(ConfigManager.framesStoreFolderProperty);
                keepMbRecodingsTextBox.Text = ConfigManager.GetProperty(ConfigManager.keepMBRecodingsProperty);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ConfigManager.SetProperty(ConfigManager.captureFrameIntervalProperty, captureFrameEveryTextBox.Text);
            ConfigManager.SetProperty(ConfigManager.framesStoreFolderProperty, storeFolderTextBox.Text);
            ConfigManager.SetProperty(ConfigManager.keepMBRecodingsProperty, keepMbRecodingsTextBox.Text);
            ConfigManager.Save();

            this.Hide();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void deleteStoredButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm delete", "Delete stored recordings?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                StoreFolderManager.DeleteAllRecords();
            }
        }
    }
}
