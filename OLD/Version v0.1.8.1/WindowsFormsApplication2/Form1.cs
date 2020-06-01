using System;
using System.Windows.Forms;
using System.Security.Principal;
using System.IO;

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


        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

           


            
            if (File.Exists("Packages\\imagex.exe") && File.Exists("Packages\\bcdboot.exe") && File.Exists("Packages\\bootsect.exe") && File.Exists("Packages\\bcdedit.exe") && File.Exists("Packages\\dism.exe"))
            {


            }
            else {

                MessageBox.Show("You don't have Microsoft AIK tools");
                this.Close();

            }
            this.Hide();
            var form2 = new Form2();
            form2.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var x = new Form1();
            x.Movable = false;
 



            if (this.IsElevated)
            {
                button1.Enabled = true;
                label1.Visible = false;
            }
            else {

                button1.Enabled = false;
                label1.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
