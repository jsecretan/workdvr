using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Timers;
using System.IO;
using System.Drawing.Imaging;

namespace WorkDVR
{

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
                return (float)currentFrame / (float)frames.Count;
            }
            set
            {
                if ((value >= 0.0) && (value <= 100.0))
                {
                    currentFrame = (int)((frames.Count - 1) * (value / 100.0));
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
                return (int)frames[currentFrame];
            }
        }

        public ScreenShotManager()
        {
            frames = new ArrayList();

            setupLocalDirectories();

            loadExistingFrames();

            // Create a screen capture timer with the configured timeout
            screenCapTimer = new System.Timers.Timer(ConfigManager.GetIntProperty(ConfigManager.captureFrameIntervalProperty));
            screenCapTimer.Elapsed += new ElapsedEventHandler(PeriodicImageCapture);
            startRecording();
        }
        
        private void setupLocalDirectories()
        {
            if (!Directory.Exists(ConfigManager.GetProperty(ConfigManager.framesStoreFolderProperty)))
            {
                Directory.CreateDirectory(ConfigManager.GetProperty(ConfigManager.framesStoreFolderProperty));
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
            string[] filePaths = Directory.GetFiles(ConfigManager.GetProperty(ConfigManager.framesStoreFolderProperty), "*.png");
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
            ScreenShotManager.CaptureImage(Point.Empty, Point.Empty, bounds, Path.Combine(ConfigManager.GetProperty(ConfigManager.framesStoreFolderProperty), frameTime + ".png"));
        }



    }
}
