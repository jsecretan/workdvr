﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using System.Collections.Generic;

namespace WorkDVR
{
    // manager of the store folder
    // is used for storring of captured images
    class StoreFolderManager
    {
        private System.Timers.Timer checkFolderTimer;
        private int checkInterval = 60 * 1000; // start DeleteFilesUntilUnderLimit each 60 sec

        public StoreFolderManager()
        {
            checkFolderTimer = new System.Timers.Timer(checkInterval);
            checkFolderTimer.Elapsed += new ElapsedEventHandler(DeleteFilesUntilUnderLimit);

            startWatching();        
        }

        // stop watching of the folder
        public void stopWatching()
        {
            checkFolderTimer.Enabled = false;
        }

        // stop watching of the folder
        public void startWatching()
        {
            checkFolderTimer.Enabled = true;
        }

        // Callback function for check store folder
        // removal of old files to conform to a storage quota
        public void DeleteFilesUntilUnderLimit(object source, ElapsedEventArgs e)
        {
            long folderSize = 0;

            // using to sort files by creation datetime
            SortedDictionary<string, long> filesDic = new SortedDictionary<string, long>();

            string[] files = Directory.GetFiles(Properties.Settings.Default.FramesStoreFolder, "*" + ScreenShotManager.ScreenShotFileExt);

            // get files for store folder folder
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                filesDic.Add(fileInfo.FullName, fileInfo.Length);
                folderSize += fileInfo.Length;
            }

            // from MBs to bytes
            long folderMaxSize = Properties.Settings.Default.KeepMBRecodings * 1024 * 1024;

            foreach (string file in filesDic.Keys)
            {
                if (folderSize <= folderMaxSize)
                {
                    break;
                }
                File.Delete(file);
                folderSize -= filesDic[file];
            }
        }

        // delete all images
        internal static void DeleteAllRecords()
        {
            string[] files = Directory.GetFiles(Properties.Settings.Default.FramesStoreFolder, "*" + ScreenShotManager.ScreenShotFileExt);

            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        // delete images according to checkPoint parameter
        internal static void DeleteRecords(DateTime checkPoint)
        {
            string[] files = Directory.GetFiles(Properties.Settings.Default.FramesStoreFolder, "*" + ScreenShotManager.ScreenShotFileExt);
            int checkPointFrameTime = (int)(checkPoint - new DateTime(1970, 1, 1)).TotalSeconds;

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                int fileTime = int.Parse(Path.GetFileNameWithoutExtension(fileInfo.Name));
                if (fileTime >= checkPointFrameTime)
                {
                    File.Delete(file);
                }
            }
        }
    }
}
