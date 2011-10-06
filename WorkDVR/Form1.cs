using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Timers;
using System.IO;
using System.Reflection;
using System.Drawing.Imaging;

namespace WorkDVR
{
    public partial class Form1 : Form
    {
        private Options options;
        private static System.Timers.Timer replayTimer;
        private ScreenShotManager ssm;

        private bool canShutdownWindow = false;
        private bool recording = true;

        public Form1()
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

        private void setImage()
        {
            String imageFileName = "C:\\workdvr\\" + ssm.CurrentFrameName + ".png";
            if (File.Exists(imageFileName))
            {
                Image image = Image.FromFile(imageFileName);
                pictureBox1.Image = image.GetThumbnailImage(pictureBox1.Width, pictureBox1.Height, null, IntPtr.Zero);

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

        private void Form1_Load(object sender, EventArgs e)
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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

    class ScreenShotManager
    {
        private ArrayList frames;
        private int currentFrame = 0;
        private System.Timers.Timer screenCapTimer;

        public void stopRecording()
        {
            screenCapTimer.Enabled = false;
        }

        public void startRecording()
        {
            screenCapTimer.Enabled = true;
        }

        public void forwardOneFrame()
        {
            if (currentFrame < frames.Count - 1)
            {
                currentFrame++;
            }
        }

        public void backOneFrame()
        {
            if (currentFrame > 0)
            {
                currentFrame--;
            }
        }

        // Property to set current frame by total progress
        public float Progress
        {
            get
            {
                return (float) currentFrame / (float) frames.Count;
            }
            set
            {
                if ((value >= 0.0) && (value <= 100.0))
                {
                    currentFrame = (int)((frames.Count-1) * (value / 100.0));
                    if (currentFrame < 0)
                    {
                        currentFrame = 0;
                    }
                }
            }
        }

        public int CurrentFrameName    // the Name property
        {
            get
            {
                return (int) frames[currentFrame];
            }
        }

        public ScreenShotManager()
        {
            frames = new ArrayList();

            setupLocalDirectories();

            loadExistingFrames();

            // Create a screen capture timer with the configured timeout
            screenCapTimer = new System.Timers.Timer(5000);
            screenCapTimer.Elapsed += new ElapsedEventHandler(PeriodicImageCapture);
            startRecording();
        }

        private void setupLocalDirectories()
        {
            if (!Directory.Exists(@"C:\\workdvr\\"))
            {
                Directory.CreateDirectory(@"C:\\workdvr\\");
            }
        }

        public static void CaptureImage(Point SourcePoint, Point DestinationPoint,
            Rectangle SelectionRectangle, string FilePath)
        {
            using (Bitmap bitmap = new Bitmap(SelectionRectangle.Width,
                SelectionRectangle.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(SourcePoint, DestinationPoint,
                        SelectionRectangle.Size);
                }
                bitmap.Save(FilePath, ImageFormat.Png);
            }
        }

        private void loadExistingFrames()
        {
            string[] filePaths = Directory.GetFiles(@"C:\\workdvr\\", "*.png");
            foreach (string file in filePaths)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(file);
                int frameToAdd = 0;
                if (int.TryParse(fileNameWithoutExt, out frameToAdd))
                {
                    frames.Add(frameToAdd);
                }
            }
        }

        //TODO
        private void deleteFilesUntilUnderLimit()
        {
            //Iterate through frames, and delete until we are within the storage limit
            foreach (int i in frames)
            {

            }
        }

        //Callback function for image capturing
        public void PeriodicImageCapture(object source, ElapsedEventArgs e)
        {
            //Calculate UNIX epoch time to make the file name
            TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            int frameTime = (int)t.TotalSeconds;
            frames.Add(frameTime);
            Rectangle bounds = Screen.GetBounds(Screen.GetBounds(Point.Empty));
            ScreenShotManager.CaptureImage(Point.Empty, Point.Empty, bounds, "C:\\workdvr\\" + frameTime + ".png");
        }

        

    }
}