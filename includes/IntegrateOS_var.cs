using MetroFramework;
using MetroFramework.Components;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace IntegrateOS
{
    public static class Generate_location
    {

        public static Point default_location()
        {
            Rectangle screenRect = Screen.GetBounds(Screen.PrimaryScreen.Bounds);
            Size ClientSize = new Size((int)(screenRect.Width / 2), (int)(screenRect.Height / 2));
            Point Location = new Point(screenRect.Width / 2 - ClientSize.Width / 2, screenRect.Height / 2 - ClientSize.Height / 2);
            return Location;
        }

        static Point data_l = default_location();
        public static Point Generate(int x, int y)
        {
            return new Point(x, y);
        }
    

    }

    public static class Generate_Colors
    {
        public static System.Drawing.Color Generate(int color)
        {
            switch (color)
            {
                case 1:
                    return MetroColors.Blue;
                case 2:
                    return MetroColors.Brown;
                case 3:
                    return MetroColors.Green;
                case 4:
                    return MetroColors.Lime;
                case 5:
                    return MetroColors.Magenta;
                case 6:
                    return MetroColors.Orange;
                case 7:
                    return MetroColors.Pink;
                case 8:
                    return MetroColors.Purple;
                case 9:
                    return MetroColors.Red;
                case 10:
                    return MetroColors.Teal;
                case 11:
                    return MetroColors.Yellow;
                default:
                    return MetroColors.Blue;
            }
        }

        public static MetroColorStyle Generate_Metro(int color)
        {
            switch (color)
            {
                case 1:
                    return MetroColorStyle.Blue;
                case 2:
                    return MetroColorStyle.Brown;
                case 3:
                    return MetroColorStyle.Green;
                case 4:
                    return MetroColorStyle.Lime;
                case 5:
                    return MetroColorStyle.Magenta;
                case 6:
                    return MetroColorStyle.Orange;
                case 7:
                    return MetroColorStyle.Pink;
                case 8:
                    return MetroColorStyle.Purple;
                case 9:
                    return MetroColorStyle.Red;
                case 10:
                    return MetroColorStyle.Teal;
                case 11:
                    return MetroColorStyle.Yellow;
                default:
                    return MetroColorStyle.Blue;
            }
        }


        public static string Generate_String(int color)
        {
            switch (color)
            {
                case 1:
                    return "Blue";
                case 2:
                    return "Brown";
                case 3:
                    return "Green";
                case 4:
                    return "Lime";
                case 5:
                    return "Magenta";
                case 6:
                    return "Orange";
                case 7:
                    return "Pink";
                case 8:
                    return "Purple";
                case 9:
                    return "Red";
                case 10:
                    return "Teal";
                case 11:
                    return "Yellow";
                default:
                    return "Blue";
            }
        }

        public static MetroThemeStyle Generate_MetroTheme(int color)
        {
            switch (color)
            {
                case 1:
                    return MetroThemeStyle.Light;
                case 2:
                    return MetroThemeStyle.Dark;
                default:
                    return MetroThemeStyle.Default;
            }
        }


    }

  

    public class CMD_Process_Class
    {

        internal static int Process_CMD(string dism, int e = 0)
        {
            try
            {
                Process Cmd = new Process();
                Cmd.StartInfo.FileName = "cmd.exe";
                Cmd.StartInfo.RedirectStandardInput = true;
                Cmd.StartInfo.RedirectStandardError = true;
                Cmd.StartInfo.CreateNoWindow = true;
                Cmd.StartInfo.UseShellExecute = false;

                try
                {
                    Cmd.Start();
                    Cmd.StandardInput.WriteLine(dism);
                    Cmd.StandardInput.Flush();
                    Cmd.StandardInput.Close();
                    Cmd.WaitForExit();
                    return 0;
                }
                catch
                {
                    return 1;
                }
            }
            catch
            {
                return 1;
            }
        }
    }
    class IntegrateOS_var
    {
        public static int beta = 1;
        public static int trial = 0;
        public static int dark;
        public static string color = "Blue";
        public static int color_t = 1;
        public static MetroFramework.MetroColorStyle color1;
        public static MetroFramework.MetroThemeStyle theme;
    }
    class tools_location
    {
        public static string location1;
        public static string location2;
        public static string index;
        public static string type; ///for converting and mount
        public static string conversion_type;
        public static int conversion_code;
    }

    public static class Themes
    {
        public static MetroStyleManager generate(MetroColorStyle mcs, MetroThemeStyle mts)
        {
            MetroStyleManager e = new MetroStyleManager();
            e.Theme = mts;
            e.Style = mcs;
            return e;
        }
    }


}

namespace WindowsSetup
{
    class Variabile
    {
        public static string var;
        public static string format;
        public static string fix;
        public static string locatie;
        public static int space_gb_ver = 0;
        public static string version;
    }
}
