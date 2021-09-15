using System;
using System.Windows.Forms;

namespace AudioPlayer
{
    static class Program
    {
        public static FormUI FormUI
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormUI());
        }
    }
}
