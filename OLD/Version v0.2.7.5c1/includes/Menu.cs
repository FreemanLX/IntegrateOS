using System;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class Menu : MetroFramework.Forms.MetroForm
    {
        public Menu(string s)
        {
            InitializeComponent();
            this.Text = s;
           
           
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            var x = new selection_os();
            this.Hide();
            x.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            var x = new tools();
            this.Hide();
            x.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            ////Settings
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroTile3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var x = new selection_os();
            this.Hide();
            x.Show();
        }
    }
}
