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

       

        private void Microsoft_Click(object sender, EventArgs e)
        {
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Default_form(Location));
        }

        private void Licenses_Load(object sender, EventArgs e)
        {
            metroLabel10.StyleManager = this.StyleManager = Themes.Generate;
            metroButton2.BackgroundImage = Themes.Icon_Style;
            metroButton2.BackgroundImageLayout = ImageLayout.Center;
        }
    }
}
