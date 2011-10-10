using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WorkDVR
{
    static class Program
    {

        private static MainForm playbackWindow;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            playbackWindow = new MainForm();

            Application.Run();
        }

        
    }

}
