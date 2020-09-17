using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IntegrateOS;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;


namespace IntegrateOS
{
    public partial class convert_wim_esd : MetroFramework.Forms.MetroForm
    {

        string convert_final, to_convert_final;
        public convert_wim_esd(string convert, string to_convert)
        {
            InitializeComponent();
            this.Text = "Convert " + convert + " - " + to_convert;
            this.label6.Text = convert;
            convert_final = convert;
            to_convert_final = to_convert;
            label6.Refresh();
            this.label1.Text = to_convert;
            label1.Refresh();
            IntegrateOS.tools_location.type = convert;
        }

        private void convert_wim_esd_Load(object sender, EventArgs e)
        {

            if (Environment.ProcessorCount <= 2)
            {
                label3.Visible = true;
                label3.Refresh();
            }
            else
            {
                float lbl_Avilable_Memory = (new Microsoft.VisualBasic.Devices.ComputerInfo().AvailablePhysicalMemory / 1048576);
                if (lbl_Avilable_Memory < 2048)
                {
                    label3.Visible = true;
                    label3.Refresh();
                    this.comboBox3.Items.Remove("Recovery");
                    this.comboBox3.Items.Remove("Max");
                }
                else
                {
                    if (lbl_Avilable_Memory < 4096)
                    {
                        label3.Text = "Do not use the recovery option, your free ram has less than 4GB RAM.";
                        label3.Visible = true;
                        label3.Refresh();
                        this.comboBox3.Items.Remove("Recovery");
                    }
                }
            }
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            if (to_convert_final == "WIM") ofd.Filter = "*.wim|*.wim";
            if (to_convert_final == "ESD") ofd.Filter = "*.esd|*.esd";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                metroTextBox1.Text = ofd.FileName;
            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtPath_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtPath.Text != "Click browse to select" && metroTextBox1.Text != "Click save to save the following file")
            {
                if (txtPath.Text.Length > 1 && metroTextBox1.Text.Length > 1)
                {
                    tools_location.location1 = txtPath.Text;
                    tools_location.location2 = metroTextBox1.Text;
                    var x = new WindowsFormsApplication2.Form12(1);
                    this.Hide();
                    x.Show();
                    tools_location.conversion_type = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);
                }
                else
                {
                    MessageBox.Show("You didn't selected the path!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                MessageBox.Show("You didn't selected the path!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var x = new tools();
            this.Hide();
            x.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (convert_final == "WIM") ofd.Filter = "*.wim|*.wim";
            if (convert_final == "ESD") ofd.Filter = "*.esd|*.esd";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofd.FileName;
            }
        }
    }
}
