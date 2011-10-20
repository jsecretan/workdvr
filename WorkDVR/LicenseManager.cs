using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace WorkDVR
{
    // Manager of Product License
    class LicenseManager
    {
        // Product License Key
        private static string licenseKey = "123";

        // Product Registry Key
        private static string productRegkey = @"Software\Microsoft\Windows\CurrentVersion\App Paths\WorkDVR.exe";

        // Product Version, is used for registry key value
        private static string instLicenseRegKey = "1.0";

        // trial period, days
        private static int trialPeriod = 30;

        // datatime format to parse registry value: datetime of the product installation
        private const string dateTimeFormat = "dd.MM.yyyy HH:mm:ss";

        // is product already buyed
        // the License key is stored into Current User registry part
        public static bool ProgramRegistered()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(productRegkey);
            object regValue = (regKey != null) ? regKey.GetValue(instLicenseRegKey, string.Empty) : string.Empty;
            return regValue.Equals(licenseKey);
        }

        // is trial product's period
        public static bool TrialPeriod()
        {
            // installer saves datetime info into Local Machine registry part
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(productRegkey);
            object reg = (regKey != null) ? regKey.GetValue(instLicenseRegKey, string.Empty) : string.Empty;

            if (((string)reg).Length == 0)
            {
                // key was removed, no information about installation datetime
                return false;
            }

            try
            {
                // check trial period
                DateTime instTime = DateTime.ParseExact(reg.ToString(), dateTimeFormat, null);
                DateTime checkTime = DateTime.UtcNow.AddDays(-trialPeriod);
                return instTime.CompareTo(checkTime) > 0;
            }
            catch
            {
                // key was corrupted by somebody
                return false;
            }
        }

        // enter buyed License Key
        // the License key is stored into Current User registry part
        public static bool EnterLicenseKey(string key)
        {
            if (key.Equals(licenseKey))
            {
                RegistryKey reg = Registry.CurrentUser.CreateSubKey(productRegkey);
                reg.SetValue(instLicenseRegKey, key);
                return true;
            }
            return false;
        }
    }
}
