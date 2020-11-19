using System;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class selection_os : MetroFramework.Forms.MetroForm
    {
        public selection_os()
        {
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

        private void selection_os_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.IntegrateOS_var.color1, IntegrateOS.IntegrateOS_var.theme);
            metroTile1.Style = IntegrateOS.IntegrateOS_var.color1;
            metroTile2.Style = IntegrateOS.IntegrateOS_var.color1;
            metroTile3.Style = IntegrateOS.IntegrateOS_var.color1;
            metroTile5.Style = IntegrateOS.IntegrateOS_var.color1;
            if (IntegrateOS_var.dark == 0)
            {
                label1.ForeColor = System.Drawing.Color.Black;
                label5.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                label1.ForeColor = System.Drawing.Color.White;
                label5.ForeColor = System.Drawing.Color.White;
            }
        }


        private void metroTile1_Click(object sender, EventArgs e)
        {
            var t = new WindowsFormsApplication2.Form5();
            t.Show();
            this.Hide();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            var x = new Select_Linux();
            x.Show();
            this.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var x = new IntegrateOS.Menu(WindowsSetup.Variabile.version);
            x.Show();
            this.Hide();
        }
    }
}
