using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.IO;

namespace WorkDVR
{
    class CaptureManager
    {
        private System.Timers.Timer screenCapTimer;

        public CaptureManager()
        {
            // Create a screen capture timer with the configured timeout
            screenCapTimer = new System.Timers.Timer(ConfigManager.GetIntProperty(ConfigManager.captureFrameIntervalProperty) * 1000);
            screenCapTimer.Elapsed += new ElapsedEventHandler(PeriodicImageCapture);
        }

        public bool isRecording()
        {
            return screenCapTimer.Enabled;
        }

        public void stopRecording()
        {
            screenCapTimer.Enabled = false;
        }

        public void startRecording()
        {
            screenCapTimer.Interval = ConfigManager.GetIntProperty(ConfigManager.captureFrameIntervalProperty) * 1000;
            screenCapTimer.Enabled = true;
        }

        //Callback function for image capturing
        public void PeriodicImageCapture(object source, ElapsedEventArgs e)
        {
            //Calculate UNIX epoch time to make the file name
            TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
            int frameTime = (int)t.TotalSeconds;
  //          frames.Add(frameTime);
            Rectangle bounds = Screen.GetBounds(Screen.GetBounds(Point.Empty));
            ScreenShotManager.CaptureImage(Point.Empty, Point.Empty, bounds, Path.Combine(ConfigManager.GetProperty(ConfigManager.framesStoreFolderProperty), frameTime + ScreenShotManager.ScreenShotFileExt));
        }
    }
}
