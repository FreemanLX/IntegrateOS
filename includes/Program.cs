using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace IntegrateOS
{

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists("Settings\\user.xml"))
            {
                using(Read_settings_XML read_Settings_XML = new Read_settings_XML("Settings\\user.xml"))
                {
                    read_Settings_XML.Read();
                }
            }
            Data.list_of_history_codes = new List<string> { "menu" };
            int x = Screen.PrimaryScreen.Bounds.Width - 800;
            int y = Screen.PrimaryScreen.Bounds.Height - 600;
            Application.Run(new PrincipalForm(new Point(x / 2, y / 2)));
        }
    }
}
