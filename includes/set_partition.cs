using System;

namespace IntegrateOS
{
    public partial class Set_partition : MetroFramework.Forms.MetroForm
    {
        public Set_partition(System.Drawing.Point punct, string partition, string type = "NTFS")
        {  
            InitializeComponent();
            Location = punct;
            comboBox3.Text = type;
            comboBox1.Text = partition;
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

        private void Set_partition_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            if (IntegrateOS_var.dark == 0)
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

        private void metroButton3_Click(object sender, EventArgs e)
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

            Moving.Form(this, new Format(Location, com1, textBox1.Text, t, com3, quick_format));
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new IntegrateOS.Select_Partition(Location));
        }
    }
}
