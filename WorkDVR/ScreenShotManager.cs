using System.Drawing;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;

namespace WorkDVR
{

    class ScreenShotManager
    {
        private ArrayList frames;
        private int currentFrame = 0;

        public void forwardOneFrame()
        {
            if (currentFrame < frames.Count - 1)
            {
                currentFrame++;
            }
        }

        public int getFramesCount()
        {
            return frames.Count;
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
                return (float)currentFrame / (float)(frames.Count - 1);
            }
            set
            {
                currentFrame = (int)(((float)frames.Count - 1.0) * value);
                if (currentFrame < 0)
                {
                    currentFrame = 0;
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

            loadExistingFrames();
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
    }
}
