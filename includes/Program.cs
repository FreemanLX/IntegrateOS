using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace IntegrateOS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists("Settings\\user.dat"))
            {
                string[] s = File.ReadAllLines("Settings\\user.dat");
                IntegrateOS_var.dark = int.Parse(s[0]);
                IntegrateOS_var.color_t = int.Parse(s[1]);
                IntegrateOS_var.theme = Generate_Colors.Generate_MetroTheme(int.Parse(s[0]) + 1);
                IntegrateOS_var.color = Generate_Colors.Generate_Metro(int.Parse(s[1]));
                IntegrateOS_var.color_string = Generate_Colors.Generate_String(int.Parse(s[1]));
                IntegrateOS_var.program_mode = int.Parse(s[2]);
            }
            else IntegrateOS_var.dark = 0;
            int x = Screen.PrimaryScreen.Bounds.Width - 800;
            int y = Screen.PrimaryScreen.Bounds.Height - 600;
            Application.Run(new Menu("IntegrateOS Full Version: v0.2.8.5_betaC1", new Point(x / 2, y / 2)));
            
        }
    }
}
