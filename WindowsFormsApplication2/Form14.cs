using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form14 : MetroFramework.Forms.MetroForm
    {
        public Form14()
        {
            InitializeComponent();
        }
        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            
            g.Clear();
            Environment.Exit(0);
        }



        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            if (txtPath.Text.Length > 0)
            {
                button2.Visible = true;
            }
            if (txtPath.Text.Length == 0)
            {
                button2.Visible = false;
            }
        }

        

        private void Form14_Load(object sender, EventArgs e)
        {

        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            var form8 = new Form8();
            WindowsSetup.Variabile.var = "wim";

            var form15 = new Form12();
            this.Hide();
            form15.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var form5 = new Form5();
            this.Hide();
            form5.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.wim|*.wim";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofd.FileName;
                WindowsSetup.Variabile.locatie = txtPath.Text;
                MessageBox.Show("Your WIM file has been chosen successfully!");
            }
        }
    }
}
