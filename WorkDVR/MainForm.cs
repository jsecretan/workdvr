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
        private StoreFolderManager storeFolderManager;

        private bool canShutdownWindow = false;
        private bool keepRecordingState;

        // interval for images show
        private int baseInterval;

        // 0 - normal speed, forward direction
        // < 0 - rewind, back direction
        // > 0 - forward direction
        // ABS(timeParam) - speed value
        private int timeParam = 0;

        public MainForm()
        {
            InitializeComponent();
            
            setupLocalDirectories();
            baseInterval = Properties.Settings.Default.PlaybackInterval;

            replayTimer = new System.Timers.Timer(baseInterval);
            replayTimer.Elapsed += new ElapsedEventHandler(ReplayFrames);
            replayTimer.Enabled = false;

            options = new Options(this);
            captureManager = new CaptureManager();
            storeFolderManager = new StoreFolderManager();

            // default to recording state when started
            SwitchRecording();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // resize main form for the current screen ratio
            // default ratio is 16:9
            int newImageWidth = (int)((float)showImagePictureBox.Height / (float)Screen.PrimaryScreen.Bounds.Height 
                * (float)Screen.PrimaryScreen.Bounds.Width);

            this.Width = this.Width - showImagePictureBox.Width + newImageWidth;
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            stopPlayback();
            trackBar.Value = trackBar.Minimum;

            // form is opened
            if (this.Visible)
            {
                // check license info
                if (!LicenseManager.ProgramRegistered() && !LicenseManager.TrialPeriod())
                {
                    License licForm = new License();
                    licForm.ShowDialog();
                }

                // stop capturing on show main form
                keepRecordingStateAndStop();

                // stop removal of old files to conform to a storage quota
                storeFolderManager.stopWatching();

                // initialize screen shots show
                screenShotManager = new ScreenShotManager();
                trackBar.Maximum = Properties.Settings.Default.PlaybackBarNotches;

                if (screenShotManager.getFramesCount() > 0)
                {
                    EnabledControls(true);
                    setImage();
                }
                else
                {
                    EnabledControls(false);
                    showImagePictureBox.Image = showImagePictureBox.BackgroundImage;
                }
            }
            else
            {
                // start removal of old files to conform to a storage quota
                storeFolderManager.startWatching();

                restoreRecordingState();
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
            String imageFileName = Path.Combine(Properties.Settings.Default.FramesStoreFolder, screenShotManager.CurrentFrameName + ScreenShotManager.ScreenShotFileExt);
            if (File.Exists(imageFileName))
            {
                FileStream fileStream = new FileStream(imageFileName, FileMode.Open, FileAccess.Read);
                
                Image image = Image.FromStream(fileStream);
                showImagePictureBox.Image = image;
                
                fileStream.Close();

                DateTime frameUtcDateTime = 
                    new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(double.Parse(screenShotManager.CurrentFrameName.ToString()));
                DateTime frameDateTime = TimeZone.CurrentTimeZone.ToLocalTime(frameUtcDateTime);
                
                SetControlPropertyThreadSafe(frameTimeLabel, "Text", "Displaying frame from: " + frameDateTime);
            }
        }

        private void rewindButton_Click(object sender, EventArgs e)
        {
            timeParam--;
            replayTimer.Interval = (double)baseInterval / Math.Pow(2, Math.Abs(timeParam));
            refreshSpeedLable();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            timeParam++;
            replayTimer.Interval = (double)baseInterval / Math.Pow(2, Math.Abs(timeParam));
            refreshSpeedLable();
        }

        private void refreshSpeedLable()
        {
            speedLabel.Text = string.Format("Speed: {0}",
                (timeParam == 0) ? "Normal" : (Math.Pow(2, Math.Abs(timeParam)).ToString() + "X"));
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            startPlayback();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            replayTimer.Interval = baseInterval;
            stopPlayback();
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

        private void optionsMenuItem_Click(object sender, EventArgs e)
        {
            options.Show();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            options.Dispose();
            canShutdownWindow = true;
            Application.Exit();
        }

        private void showPlaybackMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.BringToFront();
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            screenShotManager.Progress = (float)trackBar.Value / (float)trackBar.Maximum;
            setImage();
        }

        private void startPlayback()
        {
            // start play with normal speed
            timeParam = 0;
            replayTimer.Interval = baseInterval;
            refreshSpeedLable();

            replayTimer.Enabled = true;

            pauseButton.Visible = true;
            forwardButton.Visible = true;
            rewindButton.Visible = true;
            pauseLabel.Visible = true;
            fastForwardLabel.Visible = true;
            rewindLabel.Visible = true;
            speedLabel.Visible = true;

            playButton.Visible = false;
            nextButton.Visible = false;
            prevButton.Visible = false;
            playLabel.Visible = false;
            backFrameLabel.Visible = false;
            forwardFrameLabel.Visible = false;
        }

        private void stopPlayback()
        {
            replayTimer.Enabled = false;
            
            playButton.Visible = true;
            nextButton.Visible = true;
            prevButton.Visible = true;
            playLabel.Visible = true;
            backFrameLabel.Visible = true;
            forwardFrameLabel.Visible = true;
            
            pauseButton.Visible = false;
            forwardButton.Visible = false;
            rewindButton.Visible = false;
            pauseLabel.Visible = false;
            fastForwardLabel.Visible = false;
            rewindLabel.Visible = false;
            speedLabel.Visible = false;
        }

        private void EnabledControls(bool enable)
        {
            playButton.Enabled = enable;
            pauseButton.Enabled = enable;
            nextButton.Enabled = enable;
            prevButton.Enabled = enable;
            forwardButton.Enabled = enable;
            rewindButton.Enabled = enable;
            trackBar.Enabled = enable;
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

        private void recordingMenuItem_Click(object sender, EventArgs e)
        {
            if (!LicenseManager.ProgramRegistered() && !LicenseManager.TrialPeriod())
            {
                License licForm = new License();
                licForm.ShowDialog();
            }
            else
            {
                SwitchRecording();
            }
        }

        private void SwitchRecording()
        {
            if (!captureManager.isRecording() && (LicenseManager.ProgramRegistered() || LicenseManager.TrialPeriod()))
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
                refreshTrackBar();
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            screenShotManager.forwardOneFrame();
            setImage();
            refreshTrackBar();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            screenShotManager.backOneFrame();
            setImage();
            refreshTrackBar();
        }

        private void refreshTrackBar()
        {
            trackBar.Value = (int)(screenShotManager.Progress * (float)trackBar.Maximum + 0.5);
            if (screenShotManager.Progress == 0 || screenShotManager.Progress == 1)
            {
                stopPlayback();
            }
        }

        // create folders on the first call
        private static void setupLocalDirectories()
        {
            if (Properties.Settings.Default.FramesStoreFolder.Length == 0)
            {
                string localApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                Properties.Settings.Default.FramesStoreFolder = Path.Combine(localApplicationData, Properties.Settings.Default.ScreenCapturesFolder);
                Properties.Settings.Default.Save();
            }

            if (!Directory.Exists(Properties.Settings.Default.FramesStoreFolder))
            {
                Directory.CreateDirectory(Properties.Settings.Default.FramesStoreFolder);
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        // one left click on the tray icon brings up the context menu
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            mi.Invoke(notifyIcon, null);
        }

        // keep recording state to restore on close
        public void keepRecordingStateAndStop()
        {
            keepRecordingState = captureManager.isRecording();

            if (keepRecordingState)
            {
                SwitchRecording();
            }
        }

        public void restoreRecordingState()
        {
            if (keepRecordingState)
            {
                SwitchRecording();
            }
        }
    }
}