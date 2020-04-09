using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (File.Exists(@"1.txt"))
            {
                File.Delete(@"1.txt");
            }
            if (File.Exists(@"2.txt"))
            {
                File.Delete(@"2.txt");
            }
            if (File.Exists(@"disk.txt"))
            {
                File.Delete(@"disk.txt");
            }
            if (File.Exists(@"done.dll"))
            {
                File.Delete(@"done.dll");
            }
            File.Delete("drive.txt");
            File.Delete("edit.dll");
            File.Delete("error.dll");
            File.Delete("fix.txt");
            File.Delete("format1.txt");
            File.Delete("hdd.dll");
            if (File.Exists("hdd1.dll"))
            {
                File.Delete("hdd1.dll");
            }
            File.Delete("location.txt");
            File.Delete("temp.dll");
            File.Delete("upv.dll");
            File.Delete("verify.dll");
            File.Delete("wimdone.dll");
            File.Delete("work.dll");
            File.Delete("index.dll");
            File.Delete("indice.dll");
            File.Delete("fedition.txt");
            File.Delete("edition.txt");
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

           


            
            if (File.Exists("imagex.exe") && File.Exists("bcdboot.exe") && File.Exists("bootsect.exe") && File.Exists("bcdedit.exe"))
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
