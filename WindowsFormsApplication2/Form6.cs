using System;
using System.Windows.Forms;
using System.Diagnostics;
using SevenZip.Compression.LZMA;
using System.IO;

namespace WindowsSetup
{
    
    public partial class Form6 : MetroFramework.Forms.MetroForm
    {
        public Form6()
        {
            InitializeComponent();
        }
        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        internal static string alg;




        private void Form6_Load(object sender, EventArgs e)
        {
            g.Clear();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.iso|*.iso";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                metroTextBox1.Text = ofd.FileName;
                WindowsSetup.Variabile.locatie = metroTextBox1.Text;
                alg = ofd.FileName;
                string temp = metroTextBox1.Text;
                string[] temp_b = temp.Split('\\');
                string co = temp_b[0];
                metroButton2.Visible = true;
                MessageBox.Show("Your ISO file has been chosen successfully!");
            }
            else
            {
                metroButton2.Visible = false;
            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox1.Text.Length > 0)
            {
                metroButton2.Visible = true;
            }
            if (metroTextBox1.Text.Length == 0)
            {
                metroButton2.Visible = false;
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var form = new WindowsFormsApplication2.Form5();
            this.Hide();
            form.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string temp = metroTextBox1.Text;
            string[] temp_b = temp.Split('\\');
            string co = temp_b[0];
            File.Move(WindowsSetup.Variabile.locatie, co + "\\Windows.iso");
            WindowsSetup.Variabile.locatie = co + "\\Windows.iso";
            var x = new Form7();
            this.Hide();
            x.Show();
            
        }
    }
}
