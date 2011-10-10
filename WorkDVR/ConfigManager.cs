using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace WorkDVR
{
    public class ConfigManager
    {
        // configuration properties names
        public const string captureFrameIntervalProperty = "CaptureFrameInterval";
        public const string framesStoreFolderProperty = "FramesStoreFolder";
        public const string keepMbRecodingsProperty = "KeepMbRecodings";

        // properties default values
        private const int defaultCaptureFrameInterval = 5; // in seconds
        private const int defaultKeepMbRecodings = 100;
        private const string applicationSubFolder = @"WorkDVR\";
        private const string capturesSubFolder = "ScreenCaptures";
        private const string exeFileName = "WorkDVR.exe";
        
        private static string applicationFolder;
        private static System.Configuration.Configuration config;

        private static Dictionary<string, object> defaultValues = new Dictionary<string, object>();

        static ConfigManager()
        {
            string localApplicationData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            applicationFolder = Path.Combine(localApplicationData, applicationSubFolder);

            if (!Directory.Exists(applicationFolder))
            {
                Directory.CreateDirectory(applicationFolder);
            }

            string configFilePath = Path.Combine(applicationFolder, exeFileName);
            File.Create(configFilePath); // temporary solution
            config = ConfigurationManager.OpenExeConfiguration(configFilePath);

            defaultValues.Add(captureFrameIntervalProperty, defaultCaptureFrameInterval);
            defaultValues.Add(framesStoreFolderProperty, Path.Combine(applicationFolder, capturesSubFolder));
            defaultValues.Add(keepMbRecodingsProperty, defaultKeepMbRecodings);
        }

        public static string GetProperty(string name)
        {
            return (config.AppSettings.Settings[name] != null) ? config.AppSettings.Settings[name].Value : defaultValues[name].ToString();
        }

        public static int GetIntProperty(string name)
        {
            return (config.AppSettings.Settings[name] != null) ? int.Parse(config.AppSettings.Settings[name].Value) : (int)defaultValues[name];
        }

        public static void SetProperty(string name, string value)
        {
            if (config.AppSettings.Settings[name] != null)
            {
                config.AppSettings.Settings.Remove(name);
            }
            config.AppSettings.Settings.Add(name, value);
        }

        public static void Save()
        {
            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}