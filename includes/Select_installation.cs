using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace IntegrateOS
{

    public partial class Select_installation : MetroFramework.Forms.MetroForm
    {
        int j;
        public Select_installation(System.Drawing.Point punct, int i = 0)
        {
            j = i;
            InitializeComponent();
            Location = punct;
            switch (i)
            {
                case 1:
                    Text = "Mount Windows - Select the file type for mounting"; break;
                case 2:
                    Text = "Convert Windows - Select the file type"; break;
                case 3:
                    Text = "Convert Windows - Select the file type to convert";
                    DVD.Visible = Folder.Visible = false;
                    break;
                case 4:
                    Text = "Select the file type - Basic";
                    break;
                case 5:
                    Text = "Select the type to compress";
                    break;
            }
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            if(IntegrateOS_var.program_mode == 2 || j == 4)
            {
                WIM.Visible = ESD.Visible = SWM.Visible = false;
                DVD.Location = new System.Drawing.Point(39, 75);
                Folder.Location = new System.Drawing.Point(239, 75);
            }
            else
            {
                WIM.Visible = ESD.Visible = SWM.Visible = true;
                DVD.Location = new System.Drawing.Point(39, 217);
                Folder.Location = new System.Drawing.Point(239, 217);
            }

            switch (j)
            {
                case 3:
                    DVD.Visible = Folder.Visible = false;
                    Conversion_text.Visible = Conversion_Code.Visible = true;
                    Conversion_Code.Theme = IntegrateOS.IntegrateOS_var.theme;
                    Conversion_Code.Style = IntegrateOS_var.color;
                    break;

                case 1:
                    SWM.Visible = false;
                    Folder.Location = SWM.Location;
                    break;

                case 5:
                    Folder.Location = WIM.Location;
                    WIM.Visible = DVD.Visible = false;
                    ESD.Text = "VHD";
                    SWM.Text = "Partition";
                    break;

            }

            if (IntegrateOS_var.dark == 0)
            {
                textBox1.ForeColor = System.Drawing.Color.Black;
                label1.ForeColor = System.Drawing.Color.Black;
                textBox1.BackColor = System.Drawing.Color.White;
                Conversion_text.ForeColor = System.Drawing.Color.Black;
            }
            else {
                textBox1.ForeColor = System.Drawing.Color.White;
                textBox1.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                label1.ForeColor = System.Drawing.Color.White;
                Conversion_text.ForeColor = System.Drawing.Color.White;
             }
                this.StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            WIM.Style = ESD.Style = SWM.Style = DVD.Style = Folder.Style = IntegrateOS_var.color;

        }
        string which_t;

        private void Path_SizeChanged(object sender, EventArgs e)
        {
            button4.Visible = Path.Text.Length > 0 ? true : false;
        }

        private void Path_TextChanged(object sender, EventArgs e) => button4.Visible = Path.Text.Length > 0 ? true : false;

        string Enable_downside(string text)
        {
            Path.Visible = button3.Visible = true;
            button3.Text = j == 3 ? "Save " + text : "Browse " + text;
            return text;
        }

        private void DVD_Click(object sender, EventArgs e)
        {
            which_t = Enable_downside(DVD.Text);
            Path.Text = "Click browse to select ISO file";
        }

        private void WIM_Click(object sender, EventArgs e)
        {
            which_t = Enable_downside(WIM.Text);
            Path.Text = j == 3 ? "" : "Click browse to select a " + which_t + " file";
            if (j == 3)
            {
                label1.Visible = false;
                textBox1.Visible = false;
            }
        }

        private void ESD_Click(object sender, EventArgs e)
        {
            which_t = Enable_downside(ESD.Text);
            Path.Text = j == 3 ? "" : "Click browse to select a " + which_t + " file";
            if (j == 3)
            {
                label1.Visible = false;
                textBox1.Visible = false;
            }
        }

        private void SWM_Click(object sender, EventArgs e)
        {
            if (j == 5)
            {

            }
            else
            {
                which_t = Enable_downside(SWM.Text);
                Path.Text = j == 3 ? "" : "Click browse to select a " + which_t + " file";
                if (j == 3)
                {
                    label1.Visible = true;
                    textBox1.Visible = true;
                }
            }
        }

        private void Folder_Click(object sender, EventArgs e)
        {
            which_t = Enable_downside(Folder.Text);
            Path.Text = "Click browse to select a folder";
        }

        private void Back_Click(object sender, EventArgs e)
        {
            switch (j)
            {
                case 0:
                    Moving.Form(this, new Selection_os(Location)); break;

                case 3:
                    Moving.Form(this, new Select_installation(Location, 2)); break;

                case 4:
                    Moving.Form(this, new Selection_os(Location)); break;

                default:
                    Moving.Form(this, new Basic_tools(Location));
                    break;
            }
        }
        

        private void Browse_Click(object sender, EventArgs e)
        {
            if (j != 3)
            {
                if (which_t != "Folder")
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    switch (which_t)
                    {
                        case "WIM": ofd.Filter = "*.wim|*.wim"; break;
                        case "DVD": ofd.Filter = "*.iso|*.iso"; break;
                        case "ESD": ofd.Filter = "*.esd|*.esd"; break;
                        case "SWM": ofd.Filter = "*.swm|*.swm"; break;
                    }
                    if (ofd.ShowDialog() == DialogResult.OK) IntegrateOS.Temporary_I.locatie = Path.Text = ofd.FileName;
                }
                else
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath)) Path.Text = fbd.SelectedPath;
                    }
                }
            }
            else
            {
                using (var fbd = new SaveFileDialog())
                {
                    switch (which_t)
                    {
                        case "WIM": fbd.Filter = "*.wim|*.wim"; break;
                        case "ESD": fbd.Filter = "*.esd|*.esd"; break;
                        case "SWM": fbd.Filter = "*.swm|*.swm"; break;
                    }
                    fbd.FilterIndex = 2;
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        Path.Text = fbd.FileName;
                    }
                }

            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            switch(j)
            {
                case 0: 
                    switch (which_t)
                    {
                        case "Folder":
                                var extensions = new List<string> { ".swm", ".wim", ".esd" };
                                string[] files = Directory.GetFiles(Path.Text, "*.*", SearchOption.AllDirectories).Where(f => extensions.IndexOf(System.IO.Path.GetExtension(f)) >= 0).ToArray();
                                if (files.Length == 0) MessageBox.Show("It isn't an official Windows iso!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else IntegrateOS.Moving.Form(this, new IntegrateOS.Select_Image_File(files, Location));
                                break;

                        case "DVD":
                               IntegrateOS.Moving.Form(this, new IntegrateOS.Extract_iso(Location)); break;

                        default:
                                IntegrateOS.Temporary_I.var = which_t.ToLower();
                                IntegrateOS.Moving.Form(this, new Select_Windows_Edition(Location));
                                break;
                    }

                    break;

                case 1:
                    IntegrateOS.Tools_location.Mount.path_to_mount = which_t;
                    Moving.Form(this, new Select_Windows_Edition(Location, 2));
                    break;

                case 2:
                    Tools_location.Conversion.convert_path_type = which_t;
                    Tools_location.Conversion.convert_path = Path.Text;
                    Moving.Form(this, new Select_Windows_Edition(Location, 1));
                    break;


                case 3:
                    IntegrateOS.Tools_location.Conversion.to_convert_path = Path.Text;
                    IntegrateOS.Tools_location.Conversion.to_convert_part_type = which_t;
                    IntegrateOS.Tools_location.Conversion.conversion_code = Conversion_Code.SelectedIndex;
                    if (textBox1 != null && which_t == "SWM")
                    {
                        IntegrateOS.Tools_location.Conversion.swm_partition_type = float.Parse(textBox1.Text);
                    }
                    Moving.Form(this, new Convert_windows_type(Location));

                    break;

            }
           
 
        }

    }
}
