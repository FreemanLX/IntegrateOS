using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form14 : MetroFramework.Forms.MetroForm
    {
        string which_t;
        public Form14(string which)
        {
            InitializeComponent();
            this.Text = "Select " + which;
            which_t = which;
        }
        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            
            g.Clear();
            Environment.Exit(0);
        }




        

        private void Form14_Load(object sender, EventArgs e)
        {

        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (which_t == "WIM")
            {
                WindowsSetup.Variabile.var = "wim";

                var form15 = new Form12();
                this.Hide();
                form15.Show();
            }
            if (which_t == "ESD")
            {
                WindowsSetup.Variabile.var = "esd";

                var form15 = new Form12();
                this.Hide();
                form15.Show();
            }
            if (which_t == "ISO")
            {
                var form15 = new WindowsSetup.Form7();
                this.Hide();
                form15.Show();
            }
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
            if (which_t == "WIM") ofd.Filter = "*.wim|*.wim";
            if (which_t == "ISO") ofd.Filter = "*.iso|*.iso";
            if (which_t == "ESD") ofd.Filter = "*.esd|*.esd";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofd.FileName;
                WindowsSetup.Variabile.locatie = txtPath.Text;
            }
        }

        private void txtPath_Click(object sender, EventArgs e)
        {

        }

        private void txtPath_SizeChanged(object sender, EventArgs e)
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
#pragma warning disable IDE1006 // Naming Styles
        private void txtPath_TextChanged(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
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
    }
}
