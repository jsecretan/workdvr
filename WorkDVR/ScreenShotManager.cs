using System.Drawing;
using System.Collections;
using System.IO;

namespace WorkDVR
{
    // managing of captured screen shots
    class ScreenShotManager
    {
        // image file extension
        public const string ScreenShotFileExt = ".png";

        private ArrayList frames;
        private int currentFrame = 0;

        public ScreenShotManager()
        {
            frames = new ArrayList();

            loadExistingFrames();
        }

        // forward on one frame in the screen shots array
        public void forwardOneFrame()
        {
            if (currentFrame < frames.Count - 1)
            {
                currentFrame++;
            }
        }

        // screen shots count in the array
        public int getFramesCount()
        {
            return frames.Count;
        }

        // back on one frame in the screen shots array
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

        // the Name property
        public int CurrentFrameName
        {
            get
            {
                return (int)frames[currentFrame];
            }
        }

        // fill screen shots array from frames store folder
        private void loadExistingFrames()
        {
            string[] filePaths = Directory.GetFiles(Properties.Settings.Default.FramesStoreFolder, "*" + ScreenShotManager.ScreenShotFileExt);

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
