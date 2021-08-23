using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using static IntegrateOS.Algorithms.Dism_Methods;

namespace IntegrateOS
{
    public partial class Select_installation : MetroFramework.Forms.MetroForm
    {
        int j;
        bool folder = false;
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
                    Folder.Visible = false;
                    break;
                case 4:
                    Text = "Select the file type - Basic";
                    break;
                case 5:
                    Text = "Select the type to compress";
                    break;
                case 6:
                    Text = "Select a folder to capture";
                    break;
            }
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            Back.BackgroundImage = Themes.Icon_Style;
            if(j == 6)
            {
                WIM.Visible = false;
                Folder.Location = WIM.Location;
            }
            Back.BackgroundImageLayout = ImageLayout.Center;
            Back.BackColor = Themes.GenerateTheme(Themes.MetroTheme);
            Back.ForeColor = Themes.GenerateTheme(!Themes.MetroTheme);
            switch (j)
            {
                case 3:
                    Folder.Visible = false;
                    Conversion_text.Visible = Conversion_Code.Visible = true;
                    Conversion_Code.Theme = Themes.MetroTheme;
                    Conversion_Code.Style = Themes.MetroColor;
                    break;
            }
            Conversion_text.ForeColor = Themes.GenerateTheme(!Themes.MetroTheme);

            StyleManager = Themes.Generate;
            WIM.Style = Folder.Style = Themes.MetroColor;
            Path.ForeColor = Themes.GenerateTheme(!Themes.MetroTheme);
        }


        private void WIM_Click(object sender, EventArgs e)
        {
            folder = false;
            button3.Visible = true;
            Path.Visible = true;
            button3.Text = j == 3 ? "Save file" : "Browse file";
            Path.Text = j == 3 ? "Save Windows Image" : "Browse Windows Image";
        }



        private void Folder_Click(object sender, EventArgs e)
        {
            Path.Visible = button3.Visible = true;
            Path.Text = "Browse Windows Image";
            button3.Text = "Browse a folder";
            folder = true;
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            bool cancel = true;
            string hidden_path = "";
            if (j != 3)
            {
                if (!folder)
                {
                    OpenFileDialog ofd = new OpenFileDialog
                    {
                        Filter = "(WIM File)|*.wim|(ESD File)|*.esd|(SWM File)|*.swm|(VHD File)|*.vhd|(VHDX File)|*.vhdx"
                    };
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        hidden_path = InstallationData.location = System.IO.Path.GetFullPath(ofd.FileName);
                        cancel = false;
                    }
                }
                else
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            hidden_path = fbd.SelectedPath;
                            cancel = false;
                        }
                    }
                }
            }
            else
            {
                using (var fbd = new SaveFileDialog())
                {

                    fbd.Filter = " *.wim|*.wim|*.esd|*.esd|*.swm|*.swm";
                    fbd.FilterIndex = 2;
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        hidden_path = fbd.FileName;
                        cancel = false;
                    }
                }

            }
            if (cancel == false)
            {
                switch (j)
                {
                    case 0:
                        if (folder) Search_folder(hidden_path);                  
                        else Moving.Form(this, new Select_Windows_Edition(Location));
                        break;


                    case 1:
                        ToolsData.Mount.path_to_mount = hidden_path;
                        if (folder) Search_folder(hidden_path, 1);
                        else Moving.Form(this, new Select_Windows_Edition(Location, 1));
                        break;

                    case 2:

                        ToolsData.Conversion.convert_path_type = System.IO.Path.GetExtension(hidden_path);
                        ToolsData.Conversion.convert_path = hidden_path;
                        if (folder) Search_folder(hidden_path, 2);
                        else Moving.Form(this, new Select_Windows_Edition(Location, 2));
                        break;


                    case 3:
                        ToolsData.Conversion.to_convert_path = hidden_path;
                        ToolsData.Conversion.to_convert_part_type = System.IO.Path.GetExtension(hidden_path);
                        ToolsData.Conversion.conversion_code = Conversion_Code.SelectedIndex;
                        new Async_Processing(new Thread(() => Conversion()), "Converting").ShowDialog();
                        
                        break;
                        

                }
            }
        }


        private void Search_folder(string hidden_path, int type = 0)
        {
            var extensions = new List<string> { ".swm", ".wim", ".esd", ".vhd", ".vhdx" };
            new Async_Processing(new Thread(() =>
            {
                Algorithms.WimFileSearch fileSearch = new Algorithms.WimFileSearch();
                IntegrateOS_Data.files = fileSearch.SearchingByExtension(hidden_path, extensions);
            }), "Looking for available Windows images").ShowDialog();
            if (IntegrateOS_Data.files.Count == 0) MessageBox.Show("Not founded available windows images!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else Moving.Form(this, new Select_Image_File(IntegrateOS_Data.files, Location, type));
        }

        public bool Type_test(string type) => ToolsData.Conversion.convert_path_type == type;

        public bool To_type_test(string type) => ToolsData.Conversion.to_convert_part_type == type;

        private void Conversion()
        {
            try
            {
                if (Type_test(".wim") && To_type_test(".esd") == true || Type_test(".esd") && To_type_test(".wim") == true ||
                    Type_test(".wim") && To_type_test(".wim") == true || Type_test(".esd") && To_type_test(".esd") == true)
                    ConvertImage(ToolsData.Conversion.convert_path, ToolsData.Conversion.to_convert_path, ToolsData.Conversion.index, (NativeStructures.WimCompressionType)ToolsData.Conversion.conversion_code);
                if (Type_test(".wim") && To_type_test(".swm") == true)
                {
                    Split(ToolsData.Conversion.convert_path, ToolsData.Conversion.to_convert_path, 100);
                }
            }
            catch (Win32Exception exception)
            {
                Invoke(new Action(() =>
                MessageBox.Show(exception.Message)));
            }
            

        }

        private void Back_Click(object sender, EventArgs e)
        {
            switch (j)
            {
                case 0:
                    Moving.Form(this, new Default_form(Location)); break;

                case 3:
                    Moving.Form(this, new Select_installation(Location, 2)); break;

                case 4:
                    Moving.Form(this, new Default_form(Location)); break;

                default:
                    Moving.Form(this, new Default_form(Location));
                    break;
            }
        }
    }
}
