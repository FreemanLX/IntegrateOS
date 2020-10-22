using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class Linux : MetroFramework.Forms.MetroForm
    {
        public Linux()
        {
            InitializeComponent();
        }

        private void Linux_Load(object sender, EventArgs e)
        {
            metroComboBox1.Text = "Select an architecture";
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.user_settings.color1, IntegrateOS.user_settings.theme);
            metroComboBox1.Theme = IntegrateOS.user_settings.theme;
            metroComboBox1.Style = IntegrateOS.user_settings.color1;
            if (user_settings.dark == 1) {
                checkedListBox1.BackColor = System.Drawing.Color.Black;
                checkedListBox1.ForeColor = System.Drawing.Color.White;
             }
            else
            {
                checkedListBox1.BackColor = System.Drawing.Color.White;
                checkedListBox1.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string which = checkedListBox1.SelectedItem.ToString();
            Download_Linux x;
            if (this.metroComboBox1.GetItemText(this.metroComboBox1.SelectedItem) == "64 BITS")
            {
                x = new Download_Linux(which, 64);
            }
            else
            {
                x = new Download_Linux(which, 32);
            }
            x.Show();
            this.Hide();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var menu = new Select_Linux();
            menu.Show();
            this.Hide();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var menu = new Select_Linux();
            menu.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string which = checkedListBox1.SelectedItem.ToString();
            Download_Linux x;
            if (this.metroComboBox1.GetItemText(this.metroComboBox1.SelectedItem) == "64 BITS")
            {
                x = new Download_Linux(which, 64);
            }
            else
            {
                x = new Download_Linux(which, 32);
            }
            x.Show();
            this.Hide();
        }
    }
}
