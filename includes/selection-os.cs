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

        private void selection_os_Load(object sender, EventArgs e)
        {
            ///
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var x = new IntegrateOS.Menu(WindowsSetup.Variabile.version);
            x.Show();
            this.Close();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            var t = new WindowsFormsApplication2.Form5();
            t.Show();
            this.Hide();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            var x = new Linux();
            x.Show();
            this.Hide();
        }
    }
}
