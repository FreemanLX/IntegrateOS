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
        public set_partition()
        {
            InitializeComponent();
        }
        public set_partition(string partition, string type = "NTFS")
        {  ///Aici vedem ce tipuri de clustere trebuie selectat (4 KB etc...)
            InitializeComponent();
            comboBox3.Text = type;
            comboBox1.Text = partition;

            ///Si cum sa fie formatat, fast sau normal cum face rufus
            comboBox2.Items.Add("Fast");
            comboBox2.Items.Add("Normal");
            if (type == "EXT4")
            {
                comboBox4.Items.Add("4 KB");
            }
            else
            {
                comboBox4.Items.Add("4 KB");
                comboBox4.Items.Add("8 KB");
                comboBox4.Items.Add("16 KB");
                comboBox4.Items.Add("32 KB");
                comboBox4.Items.Add("64 KB");
            }
        }


        private void set_partition_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.user_settings.color1, IntegrateOS.user_settings.theme);
            if (user_settings.dark == 0)
            {
                label1.ForeColor = System.Drawing.Color.Black;
                label2.ForeColor = System.Drawing.Color.Black;
                label3.ForeColor = System.Drawing.Color.Black;
                label4.ForeColor = System.Drawing.Color.Black;
                label5.ForeColor = System.Drawing.Color.Black;
                comboBox1.BackColor = System.Drawing.Color.White;
                comboBox2.BackColor = System.Drawing.Color.White;
                comboBox3.BackColor = System.Drawing.Color.White;
                comboBox4.BackColor = System.Drawing.Color.White;
                textBox1.BackColor = System.Drawing.Color.White;


                comboBox1.ForeColor = System.Drawing.Color.Black;
                comboBox2.ForeColor = System.Drawing.Color.Black;
                comboBox3.ForeColor = System.Drawing.Color.Black;
                comboBox4.ForeColor = System.Drawing.Color.Black;
                textBox1.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                comboBox1.BackColor = System.Drawing.Color.Black;
                comboBox2.BackColor = System.Drawing.Color.Black;
                comboBox3.BackColor = System.Drawing.Color.Black;
                comboBox4.BackColor = System.Drawing.Color.Black;
                textBox1.BackColor = System.Drawing.Color.Black;

                comboBox1.ForeColor = System.Drawing.Color.White;
                comboBox2.ForeColor = System.Drawing.Color.White;
                comboBox3.ForeColor = System.Drawing.Color.White;
                comboBox4.ForeColor = System.Drawing.Color.White;
                textBox1.ForeColor = System.Drawing.Color.White;

                label1.ForeColor = System.Drawing.Color.White;
                label2.ForeColor = System.Drawing.Color.White;
                label3.ForeColor = System.Drawing.Color.White;
                label4.ForeColor = System.Drawing.Color.White;
                label5.ForeColor = System.Drawing.Color.White;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void metroButton3_Click(object sender, EventArgs e)
        {
            bool quick_format = false;
            string com2 = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            string com3 = this.comboBox3.Text;
            if (com2 == "Fast") quick_format = true;
            string com4 = this.comboBox4.GetItemText(this.comboBox4.SelectedItem);
            string com1 = this.comboBox1.Text;
            int t = 4096;
            if (com4 == "8 KB") t = 8192;    ///aici luam clusterele si le convertim in Bytes, deci 8KB = 8192 B
            if (com4 == "16 KB") t = 16384;
            if (com4 == "32 KB") t = 32768;
            if (com4 == "64 KB") t = 65536;
            if (textBox1.Text.Length < 0) textBox1.Text = "Local Disk";

            ///Evident aici este un alt form care imi formateaza o partitie. 
            var temp = new format(com1, textBox1.Text, t, com3, quick_format);
            temp.Show();
            this.Hide();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            var temp = new WindowsFormsApplication2.Form11();
            temp.Show();
            this.Hide();
        }
    }
}
