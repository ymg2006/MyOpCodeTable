using Microsoft.Win32;
using System;
using System.Windows.Forms;
using MyOpCodeTable.Shared;

namespace MyOpCodeTable
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(isWindowsDarkTheme()));
        }

        static bool isWindowsDarkTheme()
        {
            int res = -1;
            try
            {
                res = (int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", -1);
            }
            catch { }
            return res == 0;
        }
    }
}