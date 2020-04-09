using System;

namespace WindowsFormsApplication2
{
    public partial class Form19 : MetroFramework.Forms.MetroForm
    {
        public Form19()
        {
            InitializeComponent();
        }

        
        private void Form19_Load(object sender, EventArgs e)
        {

        }
        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        private void metroButton1_Click(object sender, EventArgs e)
        {
           
            g.Clear();
            Environment.Exit(1);
        }
    }
}
