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
    public partial class set_partition : MetroFramework.Forms.MetroForm
    {
        public set_partition(string partition, string type = "NTFS")
        {
            InitializeComponent();
            comboBox3.Text = type;
            comboBox1.Text = partition;
            comboBox2.Items.Add("Fast");
            comboBox2.Items.Add("Normal");
            comboBox4.Items.Add("4 KB");
            comboBox4.Items.Add("8 KB");
            comboBox4.Items.Add("16 KB");
            comboBox4.Items.Add("32 KB");
            comboBox4.Items.Add("64 KB");
        }


        private void set_partition_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool quick_format = false;
            string com2 = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            string com3 = this.comboBox3.Text;
            if (com2 == "Fast") quick_format = true;
            string com4 = this.comboBox4.GetItemText(this.comboBox4.SelectedItem);
            string com1 = this.comboBox1.Text;
            int t = 4096;
            if (com4 == "8 KB") t = 8192;
            if (com4 == "16 KB") t = 16384;
            if (com4 == "32 KB") t = 32768;
            if (com4 == "64 KB") t = 65536;
            if (textBox1.Text.Length < 0) textBox1.Text = "Local Disk";
            var temp = new format(com1, textBox1.Text, t, com3, quick_format);
            temp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var temp = new WindowsFormsApplication2.Form11();
            temp.Show();
            this.Hide();
        }
    }
}
