using System;
using System.Windows.Forms;
using System.Security.Principal;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        WindowsSetup.Variabile g = new WindowsSetup.Variabile(); 
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            g.Clear();
            Environment.Exit(0);
        }
        public bool IsElevated
        {
            get
            {
                return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (File.Exists("Packages\\imagex.exe") && File.Exists("Packages\\bcdboot.exe") && File.Exists("Packages\\bootsect.exe") && File.Exists("Packages\\bcdedit.exe") && File.Exists("Packages\\dism.exe"))
            {
                this.Hide();
                var form2 = new IntegrateOS.Menu(metroLabel1.Text);
                form2.Show();
                WindowsSetup.Variabile.version = metroLabel1.Text;
            }
            else {
                MessageBox.Show("You don't have Microsoft AIK tools");
                this.Close();
            }               
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var x = new Form1();
            x.Movable = false;
            if (!this.IsElevated)
            {
                var exeName = Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                startInfo.Arguments = "restart";
                Process.Start(startInfo);
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ///
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ///
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (File.Exists("Packages\\imagex.exe") && File.Exists("Packages\\bcdboot.exe") && File.Exists("Packages\\bootsect.exe") && File.Exists("Packages\\bcdedit.exe") && File.Exists("Packages\\dism.exe"))
            {
                this.Hide();
                var form2 = new IntegrateOS.Menu(metroLabel3.Text);
                form2.Show();
                WindowsSetup.Variabile.version = metroLabel3.Text;
            }
            else
            {
                MessageBox.Show("You don't have Microsoft AIK tools");
                this.Close();
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("Packages\\imagex.exe") && File.Exists("Packages\\bcdboot.exe") && File.Exists("Packages\\bootsect.exe") && File.Exists("Packages\\bcdedit.exe") && File.Exists("Packages\\dism.exe"))
            {
                this.Hide();
                var form2 = new IntegrateOS.Menu(metroLabel1.Text);
                form2.Show();
                WindowsSetup.Variabile.version = metroLabel1.Text;
            }
            else
            {
                MessageBox.Show("You don't have Microsoft AIK tools");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("Packages\\imagex.exe") && File.Exists("Packages\\bcdboot.exe") && File.Exists("Packages\\bootsect.exe") && File.Exists("Packages\\bcdedit.exe") && File.Exists("Packages\\dism.exe"))
            {
                this.Hide();
                var form2 = new IntegrateOS.Menu(metroLabel3.Text);
                form2.Show();
                WindowsSetup.Variabile.version = metroLabel3.Text;
            }
            else
            {
                MessageBox.Show("You don't have Microsoft AIK tools");
                this.Close();
            }
        }
    }
}
