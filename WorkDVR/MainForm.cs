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
        private ScreenShotManager screenShotManager;
        private CaptureManager captureManager;

        private bool canShutdownWindow = false;
        private bool recording = true;
        private const int baseInterval = 1000;
        private int timeParam = 0;

        public MainForm()
        {
            InitializeComponent();

            replayTimer = new System.Timers.Timer(baseInterval);
            replayTimer.Elapsed += new ElapsedEventHandler(ReplayFrames);
            replayTimer.Enabled = false;

            options = new Options();
            captureManager = new CaptureManager();
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                screenShotManager = new ScreenShotManager();
                //trackBar.Maximum = (screenShotManager.getFramesCount() >= 100) ? 100 : screenShotManager.getFramesCount();
                trackBar.Maximum = screenShotManager.getFramesCount() - 1;
            }
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
            String imageFileName = Path.Combine(ConfigManager.GetProperty(ConfigManager.framesStoreFolderProperty), screenShotManager.CurrentFrameName + ".png");
            if (File.Exists(imageFileName))
            {
                Image image = Image.FromFile(imageFileName);
                //showImagePictureBox.Image = image.GetThumbnailImage(showImagePictureBox.Width, showImagePictureBox.Height, null, IntPtr.Zero);
                showImagePictureBox.Image = image;
                
                DateTime frameDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                SetControlPropertyThreadSafe(frameTimeLabel, "Text", "Displaying frame from: " + frameDateTime.AddSeconds(double.Parse(screenShotManager.CurrentFrameName.ToString())));
            }
        }

        private void rewindButton_Click(object sender, EventArgs e)
        {
            if (!replayTimer.Enabled)
            {
                replayTimer.Enabled = true;
                pauseButton.Visible = true;
                playButton.Visible = false;
            }

            timeParam--;
            replayTimer.Interval = (double)baseInterval / Math.Pow(2, Math.Abs(timeParam));

            //stopPlayback();
            //screenShotManager.Progress = 0.0f;
            //setImage();
            //trackBar.Value = trackBar.Minimum;
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            if (!replayTimer.Enabled)
            {
                replayTimer.Enabled = true;
                pauseButton.Visible = true;
                playButton.Visible = false;
            }

            timeParam++;
            replayTimer.Interval = (double)baseInterval / Math.Pow(2, Math.Abs(timeParam));


            //stopPlayback();
            //screenShotManager.Progress = 100.0f;
            //setImage();
            //trackBar.Value = trackBar.Maximum;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            replayTimer.Enabled = true;
            pauseButton.Visible = true;
            playButton.Visible = false;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            timeParam = 0;
            replayTimer.Interval = baseInterval;

            replayTimer.Enabled = false;
            playButton.Visible = true;
            pauseButton.Visible = false;
        }

        //Callback function for image replay
        private void ReplayFrames(object source, ElapsedEventArgs e)
        {
            if (timeParam >= 0)
            {
                screenShotManager.forwardOneFrame();
            }
            else
            {
                screenShotManager.backOneFrame();
            }
            setImage();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Change proportion of the view window to match the screen
            //System.Drawing.Drawing2D.GraphicsPath Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            //Button_Path.AddEllipse(0, 0, this.button1.Width, this.button1.Height);
            //Region Button_Region = new Region(Button_Path);
            //this.button1.Region = Button_Region;

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

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            screenShotManager.Progress = (float)trackBar.Value / (float)trackBar.Maximum;
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
                captureManager.startRecording();
            }
            else
            {
                recordingMenuItem.Text = "Start Recording";
                captureManager.stopRecording();
            }
        }

        private void showImagePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (replayTimer.Enabled)
            {
                trackBar.Value = (int)(screenShotManager.Progress * (float)trackBar.Maximum + 0.5);
            }
        }
    }
}