using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using System.Reflection;

namespace WorkDVR
{
    public partial class MainForm : Form
    {
        private Options options;
        private static System.Timers.Timer replayTimer;
        private ScreenShotManager ssm;

        private bool canShutdownWindow = false;
        private bool recording = true;

        public MainForm()
        {
            InitializeComponent();

            replayTimer = new System.Timers.Timer(1000);
            replayTimer.Elapsed += new ElapsedEventHandler(ReplayFrames);
            replayTimer.Enabled = false;

            options = new Options();

            ssm = new ScreenShotManager();
        }

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }

        // set image to show on form
        private void setImage()
        {
            String imageFileName = Path.Combine(ConfigManager.GetProperty(ConfigManager.framesStoreFolderProperty), ssm.CurrentFrameName + ".png");
            if (File.Exists(imageFileName))
            {
                Image image = Image.FromFile(imageFileName);
                showImagePictureBox.Image = image.GetThumbnailImage(showImagePictureBox.Width, showImagePictureBox.Height, null, IntPtr.Zero);

                DateTime frameDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                SetControlPropertyThreadSafe(frameTimeLabel, "Text", "Displaying frame from: " + frameDateTime.AddSeconds(double.Parse(ssm.CurrentFrameName.ToString())));

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopPlayback();
            ssm.Progress = 0.0f;
            setImage();
            trackBar1.Value = trackBar1.Minimum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            replayTimer.Enabled = !replayTimer.Enabled;
        }

        //Callback function for image replay
        private void ReplayFrames(object source, ElapsedEventArgs e)
        {
            ssm.forwardOneFrame();
            setImage();
            trackBar1.Value = (int) ((ssm.Progress / 100.0f) * trackBar1.Maximum);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stopPlayback();
            ssm.Progress = 100.0f;
            setImage();
            trackBar1.Value = trackBar1.Maximum;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Change proportion of the view window to match the screen

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            options.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            canShutdownWindow = true;
            Application.Exit();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ssm.Progress = trackBar1.Value;
            setImage();
        }

        private void startPlayback()
        {
            replayTimer.Enabled = true;
        }

        private void stopPlayback()
        {
            replayTimer.Enabled = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopPlayback();

            if (!canShutdownWindow)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            recording = !recording;
            if (recording)
            {
                recordingMenuItem.Text = "Stop Recording";
                ssm.startRecording();
            }
            else
            {
                recordingMenuItem.Text = "Start Recording";
                ssm.stopRecording();
            }
        }
    }
}