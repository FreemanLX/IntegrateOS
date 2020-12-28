using System;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class tools : MetroFramework.Forms.MetroForm
    {
        public tools(System.Drawing.Point punct)
        {
            this.Location = punct;
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                var dialog = MetroFramework.MetroMessageBox.Show(this, "Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, IntegrateOS.IntegrateOS_var.color_t);
                if (dialog == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            catch { }
        }

        private void tools_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.IntegrateOS_var.color1, IntegrateOS.IntegrateOS_var.theme);
            metroTile1.Style = IntegrateOS.IntegrateOS_var.color1;
            metroTile2.Style = IntegrateOS.IntegrateOS_var.color1;
            metroTile4.Style = IntegrateOS.IntegrateOS_var.color1;
            metroTile5.Style = IntegrateOS.IntegrateOS_var.color1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var x = new IntegrateOS.Menu(WindowsSetup.Variabile.version, this.Location);
            x.Show();
        }


        private void metroTile1_Click(object sender, EventArgs e)
        {
            var x = new convert_wim_esd("WIM", "ESD", Location);
            this.Hide();
            x.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            var x = new convert_wim_esd("ESD", "WIM", Location);
            this.Hide();
            x.Show();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            var x = new WindowsFormsApplication2.Form5(Location, 1);
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
            var x = new IntegrateOS.Menu(WindowsSetup.Variabile.version, this.Location);
            x.Show();
        }
    }
}
