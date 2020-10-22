using System;

namespace WindowsFormsApplication2
{
    public partial class Form16 : MetroFramework.Forms.MetroForm
    {
        public Form16()
        {
            InitializeComponent();
        }

        

        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            
            g.Clear();
            Environment.Exit(1);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
