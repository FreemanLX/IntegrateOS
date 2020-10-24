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
            
            pictureBox3.BackColor = Generate_Colors.Generate(IntegrateOS_var.color_t);
            if(!this.IsElevated)
            {
                var exeName = Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                startInfo.Arguments = "restart";
                Process.Start(startInfo);
                Application.Exit();
            }
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.IntegrateOS_var.color1, IntegrateOS.IntegrateOS_var.theme);
            metroTile1.Style = IntegrateOS.IntegrateOS_var.color1;
            metroTile2.Style = IntegrateOS.IntegrateOS_var.color1;
            metroTile3.Style = IntegrateOS.IntegrateOS_var.color1;
            if (IntegrateOS_var.dark == 0)
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
            var eps = MetroFramework.MetroMessageBox.Show(this, "Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, IntegrateOS_var.color_t);
            if(eps == DialogResult.Yes)
              Environment.Exit(0);

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            var x = new tools();
            this.Hide();
            x.Show();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            var x = new selection_os();
            x.Show();
            this.Hide();
        }
    }
}
