using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkDVR
{
    class LicenseManager
    {
        public static bool programRegistered()
        {
            return true;
        }

        public static bool trialPeriod()
        {
            return true;
        }

        public static bool enterLicenseKey(string key)
        {
            return programRegistered();
        }

    }
}
