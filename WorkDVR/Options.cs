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
                captureFrameEveryTextBox.Text = Properties.Settings.Default.CaptureFrameInterval.ToString();
                storeFolderTextBox.Text = Properties.Settings.Default.FramesStoreFolder;
                keepMbRecodingsTextBox.Text = Properties.Settings.Default.KeepMBRecodings.ToString();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CaptureFrameInterval = int.Parse(captureFrameEveryTextBox.Text);
            Properties.Settings.Default.FramesStoreFolder = storeFolderTextBox.Text;
            Properties.Settings.Default.KeepMBRecodings = int.Parse(keepMbRecodingsTextBox.Text);
            
            Properties.Settings.Default.Save();

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
