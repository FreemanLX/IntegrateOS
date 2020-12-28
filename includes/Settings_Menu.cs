using System;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class Settings_Menu : MetroFramework.Forms.MetroForm
    {
        public Settings_Menu(System.Drawing.Point punct)
        {
            Location = punct;
            InitializeComponent();
        }

        private void Settings_Menu_Load(object sender, EventArgs e)
        {
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            Advanced.StyleManager = Themes.StyleManager = Licenses.StyleManager = About.StyleManager = this.StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            metroButton2.BackgroundImage = IntegrateOS_var.theme == MetroFramework.MetroThemeStyle.Light ? Resources.white_left_arrow : Resources.black_left_arrow;
            metroButton2.BackgroundImageLayout = ImageLayout.Center;
        }

        private void Themes_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Settings(Location));
        }

        private void Licenses_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Licenses(Location));
        }

        private void About_Click(object sender, EventArgs e)
        {

        }

        private void Advanced_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Advanced_Settings(Location));
        }

        private void Back_Click(object sender, EventArgs e)
        {
            string[] complete = new string[3];
            complete[0] = IntegrateOS_var.dark.ToString();
            complete[1] = IntegrateOS_var.color_t.ToString();
            complete[2] = IntegrateOS_var.program_mode.ToString();
            if (System.IO.File.Exists("Settings\\user.dat")) System.IO.File.WriteAllLines("Settings\\user.dat", complete);
            else
            {
                if (!System.IO.Directory.Exists("Settings")) System.IO.Directory.CreateDirectory("Settings");
                using (System.IO.StreamWriter sw = System.IO.File.CreateText("Settings\\user.dat"))
                {
                    sw.WriteLine(complete[0]);
                    sw.WriteLine(complete[1]);
                    sw.WriteLine(complete[2]);
                }
            }
            Moving.Form(this, new Menu(Temporary_I.version, Location));
        }
    }
}
