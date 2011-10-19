using System;
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

        public static bool ProgramRegistered()
        {
            return getLicRegValue().Equals(licenseKey); ;
        }

        public static bool TrialPeriod()
        {
            try
            {
                DateTime instTime = DateTime.Parse(getLicRegValue());
                DateTime checkTime = DateTime.UtcNow.AddDays(trialPeriod);
                return instTime.CompareTo(checkTime) > 0;
            }
            catch
            {
                return false;
            }
        }

        public static bool EnterLicenseKey(string key)
        {
            RegistryKey reg = Registry.LocalMachine.CreateSubKey(productRegkey);
            reg.SetValue(instLicenseRegKey, key);

            return ProgramRegistered();
        }

        private static string getLicRegValue()
        {
            object reg = Registry.LocalMachine.OpenSubKey(productRegkey).GetValue(instLicenseRegKey, string.Empty);
            return reg.ToString();
        }
    }
}
