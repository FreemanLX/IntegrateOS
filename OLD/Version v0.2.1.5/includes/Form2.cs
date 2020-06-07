using System;
using System.Windows.Forms;



namespace WindowsFormsApplication2
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }
        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        protected override void OnFormClosing(FormClosingEventArgs e){ g.Clear(); Environment.Exit(0); }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true){ button1.Enabled = true; button2.Enabled = false; }
            if (checkBox1.Checked == false){ button1.Enabled = false; button2.Enabled = true; }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {this.Hide(); var form3 = new IntegrateOS.selection_os(); form3.Show();}
        private void Form2_Load(object sender, EventArgs e){}
        private void button2_Click(object sender, EventArgs e){this.Close();}

        private void metroLabel2_Click(object sender, EventArgs e)
        {
            var form25 = new WindowsSetup.Form25();
            form25.Show();
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {
            var form25 = new WindowsSetup.Form3();
            form25.Show();
        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {
            var form = new IntegrateOS.MetroFramework_licence();
            form.ShowDialog();
        }
    }

   
}
