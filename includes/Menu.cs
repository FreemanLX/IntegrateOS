using System;
using System.Windows.Forms;
using System.Security.Principal;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace IntegrateOS
{


    public partial class Menu : MetroFramework.Forms.MetroForm
    {



        public Menu(string s, System.Drawing.Point punct)
        {
            InitializeComponent();
            Icon test = Icon.FromHandle(Resources.IntegrateOS_Logo.GetHicon());
            Icon = test;
            IntegrateOS.Temporary_I.version = this.Text = s;
            this.Location = punct;
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
            if(IntegrateOS_var.program_mode == 2)
            {
                Tools.Visible = false;
                Settings.Location = new System.Drawing.Point(223, 110);
            }
            else
            {
                Tools.Visible = true;
                Settings.Location = new System.Drawing.Point(423, 110);
            }
            if(!this.IsElevated)
            {
                var exeName = Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName)
                {
                    Verb = "runas",
                    Arguments = "restart"
                };
                Process.Start(startInfo);
                Application.Exit();
            }
            this.StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            Setup.Style = Tools.Style = Settings.Style = IntegrateOS.IntegrateOS_var.color;
        }

        private void Selection_OS_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Selection_os(Location));
        }

        private void Tools_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Selection_os(Location, 1));
        }

        private void Settings_Click_1(object sender, EventArgs e)
        {
            Moving.Form(this, new Settings_Menu(Location));
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            var eps = MetroFramework.MetroMessageBox.Show(this, "Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, IntegrateOS_var.color_t);
            if(eps == DialogResult.Yes) Environment.Exit(0);
        }
    }
}
