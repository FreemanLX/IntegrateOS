using System;
using System.Windows.Forms;
using IntegrateOS.Tools.Windows;

namespace IntegrateOS.Setup.Windows
{
    public partial class Select_Image_File : MetroFramework.Forms.MetroForm
    {
        int type;
        public Select_Image_File(System.Collections.Generic.List<string> data, System.Drawing.Point punct, int type = 0)
        {
            InitializeComponent();
            Location = punct;
            foreach(string subdata in data)
            {
                Windows_Editions_List.Rows.Add(subdata, "Yes", "None");
            }
            this.type = type;
        }

        private void Select_Image_File_Load(object sender, EventArgs e)
        {
            button1.BackColor = Themes.GenerateTheme(Themes.MetroTheme);
            button1.ForeColor = Themes.GenerateTheme(!Themes.MetroTheme);
            button1.BackgroundImage = Themes.Icon_Style;
            button1.BackgroundImageLayout = ImageLayout.Center;
            Theme = Themes.MetroTheme;
            Style = Themes.MetroColor;
            Windows_Editions_List.DefaultCellStyle.SelectionBackColor = GenerateColors.Generate((int)Themes.MetroColor);
            if ((int)Themes.MetroTheme == 0 || (int)Themes.MetroTheme == 1)
            {
                Windows_Editions_List.ForeColor = System.Drawing.Color.Black;
                Windows_Editions_List.BackColor = System.Drawing.Color.White;
                Windows_Editions_List.BackgroundColor = System.Drawing.Color.White;
                Windows_Editions_List.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                Windows_Editions_List.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                Windows_Editions_List.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                Windows_Editions_List.ColumnHeadersDefaultCellStyle.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Light);
            }
            else
            {
                Windows_Editions_List.ForeColor = System.Drawing.Color.White;
                Windows_Editions_List.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                Windows_Editions_List.BackgroundColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                Windows_Editions_List.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                Windows_Editions_List.DefaultCellStyle.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                Windows_Editions_List.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                Windows_Editions_List.ColumnHeadersDefaultCellStyle.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
            }

        }

        private void Button1_Click(object sender, EventArgs e) => Moving.Form(this, new IntegrateOS.SelectInstallationMode(Location));

        private void Go_to_next()
        {
            DataGridViewRow row = Windows_Editions_List.SelectedRows[0];
            switch (type)
            {
                default: InstallationData.location = row.Cells[0].Value.ToString(); break;
                case 1: ToolsData.Mount.path_to_mount = row.Cells[0].Value.ToString(); break;
                case 2:
                    ToolsData.Conversion.convert_path_type = System.IO.Path.GetExtension(row.Cells[0].Value.ToString());
                    ToolsData.Conversion.convert_path = row.Cells[0].Value.ToString();
                    break;
            }
            Moving.Form(this, new Select_Windows_Edition(Location, type));
        }

        private void Windows_Editions_List_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if(e.Button == MouseButtons.Left)
                 Go_to_next();
        }
    }
}
