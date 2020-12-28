using System;
using System.Drawing;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class Licenses : MetroFramework.Forms.MetroForm
    {
        public Licenses(Point point)
        {
            InitializeComponent();
            Location = point;
        }

        private void Integrate_License_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new license(Location, "ios", metroLabel6.Text));
        }

        private void MetroFramework_License_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new license(Location, "metro", metroLabel8.Text));
        }

        private void DiscUtils_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new license(Location, "disc", metroLabel9.Text));
        }

        private void Microsoft_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new license(Location, "microsoft", metroLabel10.Text));
        }

        private void Linux_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new license(Location, "linux", metroLabel11.Text));
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Settings_Menu(Location));
        }

        private void Licenses_Load(object sender, EventArgs e)
        {
            metroLabel6.StyleManager = metroLabel8.StyleManager = metroLabel10.StyleManager 
             = metroLabel11.StyleManager = metroLabel9.StyleManager = this.StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            metroButton2.BackgroundImage = IntegrateOS_var.theme == MetroFramework.MetroThemeStyle.Light ? Resources.white_left_arrow : Resources.black_left_arrow;
            metroButton2.BackgroundImageLayout = ImageLayout.Center;
        }
    }
}
