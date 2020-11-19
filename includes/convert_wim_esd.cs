using System;
using System.Windows.Forms;
using ManagedWimLib;


namespace IntegrateOS
{
    public partial class convert_wim_esd : MetroFramework.Forms.MetroForm
    {

        string convert_final, to_convert_final;
        public convert_wim_esd(System.Drawing.Point punct, int convert = 1)
        {
            InitializeComponent();
            this.Location = punct;
        }
        System.Threading.Thread x;
        int convert_l;
        public convert_wim_esd(string convert, string to_convert, System.Drawing.Point punct, int convert_t = 0)
        {
            InitializeComponent();
            label4.Hide();
            this.Location = punct;
            if (convert_t == 1)
            {
                Activate();
                label4.Show();
                button4.Visible = false;
                button5.Visible = false;
                button1.Enabled = false;
                button2.Enabled = false;
                metroComboBox1.Enabled = false;
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
            this.label6.Text = "Select " + convert;
            convert_final = convert;
            to_convert_final = to_convert;
            label6.Refresh();
            this.label1.Text = "Convert to " + to_convert;
            label1.Refresh();
            IntegrateOS.tools_location.type = convert;
            IntegrateOS.tools_location.conversion_type = to_convert;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                var dialog = MetroFramework.MetroMessageBox.Show(this, "Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, IntegrateOS.IntegrateOS_var.color_t);
                if (dialog == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            catch { }
        }

        private void convert_wim_esd_Load(object sender, EventArgs e)
        {
           
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.IntegrateOS_var.color1, IntegrateOS.IntegrateOS_var.theme);
            txtPath.Theme = IntegrateOS.IntegrateOS_var.theme;
            metroTextBox1.Theme = IntegrateOS.IntegrateOS_var.theme;
            metroComboBox1.Theme = IntegrateOS.IntegrateOS_var.theme;
            metroComboBox1.Style = IntegrateOS_var.color1;
            if(IntegrateOS_var.dark == 0)
            {
                label1.ForeColor = System.Drawing.Color.Black;
                label6.ForeColor = System.Drawing.Color.Black;
                label2.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                label1.ForeColor = System.Drawing.Color.White;
                label6.ForeColor = System.Drawing.Color.White;
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
                    this.metroComboBox1.Items.Remove("Recovery");
                    this.metroComboBox1.Items.Remove("Max");
                }
                else
                {
                    if (lbl_Avilable_Memory <= 4096)
                    {
                        label3.Text = "Warning: Your free ram has less space than 4GB.";
                        label3.Visible = true;
                        label3.Refresh();
                        this.metroComboBox1.Items.Remove("Recovery");
                    }
                }
                if(convert_l == 1)
                {
                    Activate();
                    this.Shown += new System.EventHandler(this.xShown);
                }
                    
                
            }
        }

        private void xShown(object sender, EventArgs e)
        {
            x.Start();
            while (x.IsAlive) { Application.DoEvents(); }
            if(x.IsAlive == false)
            {
               var dialog = MetroFramework.MetroMessageBox.Show(this, "Conversion completed!", "Conversion complete", MessageBoxButtons.OK, MessageBoxIcon.Information, IntegrateOS_var.color_t);
               if(dialog == DialogResult.OK)
                {
                    var x = new tools(Location);
                    this.Hide();
                    x.Show();
                }
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
                    tools_location.conversion_code = this.metroComboBox1.SelectedIndex;
                    var x = new WindowsFormsApplication2.Form12(Location, 1);
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
            var x = new tools(this.Location);
            this.Hide();
            x.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            if (to_convert_final == "WIM") ofd.Filter = "*.wim|*.wim";
            if (to_convert_final == "ESD") ofd.Filter = "*.esd|*.esd";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                metroTextBox1.Text = ofd.FileName;
            }
        }

        private void convert_wim_esd_LocationChanged(object sender, EventArgs e)
        {
            IntegrateOS.Generate_location.data_l = this.Location;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
