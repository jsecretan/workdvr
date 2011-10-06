using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WorkDVR
{
    static class Program
    {

        private static Form1 playbackWindow;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            playbackWindow = new Form1();

            Application.Run();
        }

        
    }

}
