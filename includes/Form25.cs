using System;

namespace WindowsSetup
{
    public partial class Form25 : MetroFramework.Forms.MetroForm
    {
        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        public Form25()
        {
            
            g.Clear();
            InitializeComponent();
        }

        private void Form25_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var x = new WindowsFormsApplication2.Form2();
            x.Show();
            this.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
