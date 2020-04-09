using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form8 : MetroFramework.Forms.MetroForm
    {
       
        public Form8()
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
        }

       

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        
        private void metroButton3_Click(object sender, EventArgs e)
        {
            WindowsSetup.Variabile.var = "esd";
            var form15 = new Form12();
            this.Hide();
            form15.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.esd|*.esd";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = ofd.FileName;
                    WindowsSetup.Variabile.locatie = txtPath.Text;
                    MessageBox.Show("Your WIM file has been chosen successfully!");
                }
            }

            if(WindowsSetup.Variabile.locatie.Length > 0)
            {
                metroButton3.Visible = true;
            }

            if (WindowsSetup.Variabile.locatie.Length == 1)
            {
                metroButton3.Visible = false;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var form5 = new Form5();
            this.Hide();
            form5.Show();
        }
    }
}