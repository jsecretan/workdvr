﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using System.Collections.Generic;

namespace WorkDVR
{
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

        public void stopWatching()
        {
            checkFolderTimer.Enabled = false;
        }

        public void startWatching()
        {
            checkFolderTimer.Enabled = true;
        }

        //Callback function for check store folder
        public void DeleteFilesUntilUnderLimit(object source, ElapsedEventArgs e)
        {
            long folderSize = 0;

            SortedDictionary<string, long> filesDic = new SortedDictionary<string, long>();

            string[] files = Directory.GetFiles(ConfigManager.GetProperty(ConfigManager.framesStoreFolderProperty), "*" + ScreenShotManager.ScreenShotFileExt);

            // get files for store folder folder
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                filesDic.Add(fileInfo.FullName, fileInfo.Length);
                folderSize += fileInfo.Length;
            }

            // from MBs to bytes
            long folderMaxSize = ConfigManager.GetIntProperty(ConfigManager.keepMBRecodingsProperty) * 1024 * 1024;

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

        internal static void DeleteAllRecords()
        {
            string[] files = Directory.GetFiles(ConfigManager.GetProperty(ConfigManager.framesStoreFolderProperty), "*" + ScreenShotManager.ScreenShotFileExt);

            foreach (string file in files)
            {
                File.Delete(file);
            }
        }
    }
}
