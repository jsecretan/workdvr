using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using System.Drawing.Imaging;

namespace WorkDVR
{
    // Periodically capturing a screen to a file
    class CaptureManager
    {
        private System.Timers.Timer screenCapTimer;

        public CaptureManager()
        {
            // Create a screen capture timer with the configured timeout
            screenCapTimer = new System.Timers.Timer(Properties.Settings.Default.CaptureFrameInterval * 1000);
            screenCapTimer.Elapsed += new ElapsedEventHandler(PeriodicImageCapture);
        }

        // is capturing on
        public bool isRecording()
        {
            return screenCapTimer.Enabled;
        }

        // stop capturing
        public void stopRecording()
        {
            screenCapTimer.Enabled = false;
        }

        // start capturing
        public void startRecording()
        {
            screenCapTimer.Interval = Properties.Settings.Default.CaptureFrameInterval * 1000;
            screenCapTimer.Enabled = true;
        }

        // Callback function for image capturing
        public void PeriodicImageCapture(object source, ElapsedEventArgs e)
        {
            //Calculate UTC time to make the file name
            int frameTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            Rectangle bounds = Screen.GetBounds(Screen.GetBounds(Point.Empty));

            CaptureImage(Point.Empty, Point.Empty, bounds, 
                Path.Combine(Properties.Settings.Default.FramesStoreFolder, frameTime + ScreenShotManager.ScreenShotFileExt));
        }

        // capture image from a screen
        private void CaptureImage(Point SourcePoint, Point DestinationPoint,
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
    }
}
