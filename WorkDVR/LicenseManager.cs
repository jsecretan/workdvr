﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace WorkDVR
{
    class LicenseManager
    {
        private static string licenseKey = "123";

        private static string productRegkey = @"Software\Microsoft\Windows\CurrentVersion\App Paths\WorkDVR.exe";
        private static string instLicenseRegKey = "1.0";
        private static int trialPeriod = 30;
        private const string dateTimeFormat = "dd.MM.yyyy HH:mm:ss";

        public static bool ProgramRegistered()
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(productRegkey);
            object regValue = (regKey != null) ? regKey.GetValue(instLicenseRegKey, string.Empty) : string.Empty;
            return regValue.Equals(licenseKey); ;
        }

        public static bool TrialPeriod()
        {
            RegistryKey regKey = Registry.LocalMachine.OpenSubKey(productRegkey);
            object reg = (regKey != null) ? regKey.GetValue(instLicenseRegKey, string.Empty) : string.Empty;

            if (((string)reg).Length == 0)
            {
                return false;
            }

            try
            {
                DateTime instTime = DateTime.ParseExact(reg.ToString(), dateTimeFormat, null);
                DateTime checkTime = DateTime.UtcNow.AddDays(-trialPeriod);
                return instTime.CompareTo(checkTime) > 0;
            }
            catch
            {
                // ignore incorrect value from registry
                return false;
            }
        }

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
