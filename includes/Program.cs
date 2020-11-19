using System;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication2
{
    static class Variabile
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists("Settings\\user.dat"))
            {
                string[] s = File.ReadAllLines("Settings\\user.dat");
                IntegrateOS.IntegrateOS_var.dark = Int32.Parse(s[0]);
                IntegrateOS.IntegrateOS_var.color_t = Int32.Parse(s[1]);
                IntegrateOS.IntegrateOS_var.theme = IntegrateOS.Generate_Colors.Generate_MetroTheme(Int32.Parse(s[0]) + 1);
                IntegrateOS.IntegrateOS_var.color1 = IntegrateOS.Generate_Colors.Generate_Metro(Int32.Parse(s[1]));
                IntegrateOS.IntegrateOS_var.color = IntegrateOS.Generate_Colors.Generate_String(Int32.Parse(s[1]));
            }
            Application.Run(new IntegrateOS.Menu("IntegrateOS Full Version: v0.2.8.0_betaC1", IntegrateOS.Generate_location.default_location()));
            
        }
    }
}
