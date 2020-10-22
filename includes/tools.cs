using System;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class tools : MetroFramework.Forms.MetroForm
    {
        public tools()
        {
            InitializeComponent();
        }

        private void tools_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.user_settings.color1, IntegrateOS.user_settings.theme);
            metroTile1.Style = IntegrateOS.user_settings.color1;
            metroTile2.Style = IntegrateOS.user_settings.color1;
            metroTile4.Style = IntegrateOS.user_settings.color1;
            metroTile5.Style = IntegrateOS.user_settings.color1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var x = new IntegrateOS.Menu(WindowsSetup.Variabile.version);
            x.Show();
        }


        private void metroTile1_Click(object sender, EventArgs e)
        {
            var x = new convert_wim_esd("WIM", "ESD");
            this.Hide();
            x.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            var x = new convert_wim_esd("ESD", "WIM");
            this.Hide();
            x.Show();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            var x = new WindowsFormsApplication2.Form5(1);
            this.Hide();
            x.Show();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            ///Edit Windows
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var x = new IntegrateOS.Menu(WindowsSetup.Variabile.version);
            x.Show();
        }
    }
}
