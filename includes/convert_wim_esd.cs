using System;
using System.Windows.Forms;
using ManagedWimLib;


namespace IntegrateOS
{
    public partial class convert_wim_esd : MetroFramework.Forms.MetroForm
    {

        string convert_final, to_convert_final;
        public convert_wim_esd(int convert = 1)
        {
            InitializeComponent();

        }
        System.Threading.Thread x;
        int convert_l;
        public convert_wim_esd(string convert, string to_convert, int convert_t = 0)
        {
            InitializeComponent();
            if (convert_t == 1)
            {
                label4.Visible = true;
                progressBar1.Visible = true;
                button4.Visible = false;
                button5.Visible = false;
                metroButton1.Enabled = false;
                button1.Enabled = false;
                comboBox3.Enabled = false;
                txtPath.Text = tools_location.location1;
                metroTextBox1.Text = tools_location.location2;
                x = new System.Threading.Thread(() =>
               {
                   Export_image(tools_location.location1, tools_location.location2, Int32.Parse(tools_location.index), tools_location.conversion_code);
               })
                {
                    IsBackground = true
                };
                
                
            }
            convert_l = convert_t;
            this.Text = "Convert " + convert + " - " + to_convert;
            this.label6.Text = convert;
            convert_final = convert;
            to_convert_final = to_convert;
            label6.Refresh();
            this.label1.Text = to_convert;
            label1.Refresh();
            IntegrateOS.tools_location.type = convert;
            IntegrateOS.tools_location.conversion_type = to_convert;
        }

        private void convert_wim_esd_Load(object sender, EventArgs e)
        {
            
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.user_settings.color1, IntegrateOS.user_settings.theme);
            txtPath.Theme = IntegrateOS.user_settings.theme;
            metroTextBox1.Theme = IntegrateOS.user_settings.theme;
            if(user_settings.dark == 0)
            {
                label1.ForeColor = System.Drawing.Color.Black;
                label4.ForeColor = System.Drawing.Color.Black;
                label6.ForeColor = System.Drawing.Color.Black;
                comboBox3.BackColor = System.Drawing.Color.White;
                comboBox3.ForeColor = System.Drawing.Color.Black;
                label2.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                label1.ForeColor = System.Drawing.Color.White;
                label4.ForeColor = System.Drawing.Color.White;
                label6.ForeColor = System.Drawing.Color.White;
                comboBox3.BackColor = System.Drawing.Color.Black;
                comboBox3.ForeColor = System.Drawing.Color.White;
                label2.ForeColor = System.Drawing.Color.White;
            }
            if (Environment.ProcessorCount <= 2)
            {
                label3.Visible = true;
                label3.Refresh();
            }
            else
            {
                float lbl_Avilable_Memory = (new Microsoft.VisualBasic.Devices.ComputerInfo().AvailablePhysicalMemory / 1048576);
                if (lbl_Avilable_Memory <= 2048)
                {
                    label3.Visible = true;
                    label3.Refresh();
                    this.comboBox3.Items.Remove("Recovery");
                    this.comboBox3.Items.Remove("Max");
                }
                else
                {
                    if (lbl_Avilable_Memory <= 4096)
                    {
                        label3.Text = "Warning: Your free ram has less space than 4GB.";
                        label3.Visible = true;
                        label3.Refresh();
                        this.comboBox3.Items.Remove("Recovery");
                    }
                }
                if(convert_l == 1)
                {
                    progressBar1.Value = 30;
                    x.Start();
                    while (x.IsAlive) { Application.DoEvents(); }
                    progressBar1.Value = 100;
                    
                }
                if(progressBar1.Value == 100)
                {
                    System.Threading.Thread.Sleep(1000);
                    MessageBox.Show("The conversion is complete", "Converted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        var x = new tools();
                        x.Show();
                        this.Close();
                    }
                    catch
                    {

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

        Wim y;
        private void Export_image(string loc1, string loc2, int index, int compression)
        {
            Wim.GlobalInit("libwim-15.dll");
            Wim x = Wim.OpenWim(loc1, 0);
            switch (compression)
            {
                case 0:
                    y = Wim.CreateNewWim(CompressionType.NONE);
                    break;
                case 1:
                    y = Wim.CreateNewWim(CompressionType.XPRESS);
                    break;
                case 2:
                    y = Wim.CreateNewWim(CompressionType.LZMS);
                    break;
                case 3:
                    y = Wim.CreateNewWim(CompressionType.LZX);
                    break;
                default:
                    y = Wim.CreateNewWim(CompressionType.NONE);
                    break;
            }
            x.ExportImage(index, y, null, null, ExportFlags.DEFAULT);
            y.Write(loc2, Wim.AllImages, WriteFlags.DEFAULT, Wim.DefaultThreads);
            
        }


        private void button5_Click(object sender, EventArgs e)
        {  

            if (txtPath.Text != "Click browse to select" && metroTextBox1.Text != "Click save to save the following file")
            {
                if (txtPath.Text.Length > 1 && metroTextBox1.Text.Length > 1)
                {
                    tools_location.location1 = txtPath.Text;
                    tools_location.location2 = metroTextBox1.Text;
                    tools_location.conversion_code = this.comboBox3.SelectedIndex;
                    var x = new WindowsFormsApplication2.Form12(1);
                    this.Hide();
                    x.Show(); 
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

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
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
