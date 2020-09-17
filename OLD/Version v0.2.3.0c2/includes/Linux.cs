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

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
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
