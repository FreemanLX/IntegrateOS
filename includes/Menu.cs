using System;
using System.Windows.Forms;
using System.Security.Principal;
using System.IO;
using System.Diagnostics;

namespace IntegrateOS
{
    public partial class Menu : MetroFramework.Forms.MetroForm
    {
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(string s)
        {
            InitializeComponent();
            this.Text = s;
            WindowsSetup.Variabile.version = s;

        }

        public bool IsElevated
        {
            get
            {
                return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

            if(!this.IsElevated)
            {
                var exeName = Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                startInfo.Arguments = "restart";
                Process.Start(startInfo);
                Application.Exit();
            }
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.user_settings.color1, IntegrateOS.user_settings.theme);
            metroTile1.Style = IntegrateOS.user_settings.color1;
            metroTile2.Style = IntegrateOS.user_settings.color1;
            metroTile3.Style = IntegrateOS.user_settings.color1;
            if (user_settings.dark == 0)
            {
                label1.ForeColor = System.Drawing.Color.Black;
                label2.ForeColor = System.Drawing.Color.Black;
                label5.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                label1.ForeColor = System.Drawing.Color.White;
                label2.ForeColor = System.Drawing.Color.White;
                label5.ForeColor = System.Drawing.Color.White;
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            var x = new selection_os();
            this.Hide();
            x.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            var x = new tools();
            this.Hide();
            x.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            ////Settings
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroTile3_Click_1(object sender, EventArgs e)
        {
            var x = new Settings();
            x.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var x = new Settings();
            x.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var x = new selection_os();
            this.Hide();
            x.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
