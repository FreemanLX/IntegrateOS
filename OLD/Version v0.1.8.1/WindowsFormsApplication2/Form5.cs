using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication2
{

   
    public partial class Form5 : MetroFramework.Forms.MetroForm
    {
        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        public Form5()
        {
            
            g.Clear();
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
           
            Environment.Exit(0);

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            var cx = new Form8();
            cx.Movable = false;
            var gx = new Form14();
            gx.Movable = false;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var form = new Form14();
            this.Hide();
            form.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new Form2();
            this.Hide();
            form.Show();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = new WindowsSetup.Form9();
            this.Hide();
            x.Show();
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {
           

        }

        

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            var form = new Form14();
            this.Hide();
            form.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            this.Hide();
            form.Show();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            var form1 = new Form8();
            this.Hide();
            form1.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var form = new WindowsSetup.Form6();
            this.Hide();
            form.Show();
        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
