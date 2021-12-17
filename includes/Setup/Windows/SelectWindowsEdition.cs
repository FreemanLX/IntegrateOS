using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using static IntegrateOS.Algorithms.Dism_Methods;
using IntegrateOS.Tools.Windows;

namespace IntegrateOS.Setup.Windows
{
    public partial class Select_Windows_Edition : MetroFramework.Forms.MetroForm
    {
        int j = 0;
        public Select_Windows_Edition(System.Drawing.Point punct, int i = 0)
        {
            j = i;
            InitializeComponent();
            Location = punct;
        }
        List<double> sizes;
        public bool Getting_WindowsInfo(string path)
        {
            sizes = new List<double>();
            bool ok = false;
            try
            {
                GetImageInfo getImageInfo = new GetImageInfo(path);
                if (getImageInfo.Get(out List<DismImageInfo> dismImageInfos) == true)
                { 
                    foreach (DismImageInfo dismImageInfo in dismImageInfos)
                    {
                        string name = dismImageInfo.ImageName;
                        if (string.IsNullOrEmpty(name)) name = "Windows (Unknown)";
                        sizes.Add(dismImageInfo.ImageSize);
                        Windows_Editions_List.Rows.Add(name, dismImageInfo.ImageSize.ToString() + " MB",
                             dismImageInfo.ImageDescription);
                    }
                    ok = true;
                }
            }
            catch
            {
                MessageBox.Show("Error loading the selected file: " + path);
            }
            return ok;
        }

        public void Getting_the_windows_infos()
        {
            Thread.Sleep(500);
            if (Getting_WindowsInfo(get_path) == false) Moving.Form(this, new PrincipalForm(Location));
        }

        string get_path = "";
        private void Form12_Load(object sender, EventArgs e)
        {
            switch (j)
            {
                case 0:  get_path = InstallationData.location; break;
                case 1:  get_path = ToolsData.Mount.path_to_mount; break;
                case 2:  get_path = ToolsData.Conversion.convert_path;  break;
                default: break;
            }

            
            StyleManager = Themes.Generate;
            Windows_Editions_List.DefaultCellStyle.SelectionBackColor = GenerateColors.Generate((int)Themes.MetroColor);
            Back.BackgroundImage = Themes.Icon_Style;
            if ((int)Themes.MetroTheme == 0 || (int)Themes.MetroTheme == 1)
            {
                Refresh.BackgroundImage = Resources.refresh_48_lightmode;
                
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
                Refresh.BackgroundImage = Resources.refresh_48_darkmode;
                Windows_Editions_List.ForeColor = System.Drawing.Color.White;
                Windows_Editions_List.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                Windows_Editions_List.BackgroundColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                Windows_Editions_List.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                Windows_Editions_List.DefaultCellStyle.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                Windows_Editions_List.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                Windows_Editions_List.ColumnHeadersDefaultCellStyle.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
            }
            Back.BackgroundImageLayout = Refresh.BackgroundImageLayout = ImageLayout.Center;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Windows_Editions_List.Rows.Clear();
            new LoadingResponse(new Thread(() => Getting_the_windows_infos()), "Retrive windows editions").ShowDialog();
        }

        private void Moving_Selection_OS_Click(object sender, EventArgs e) => Moving.Form(this, new PrincipalForm(Location));

        private void Select_Windows_Edition_Shown(object sender, EventArgs e) => new LoadingResponse(new Thread(() => Getting_the_windows_infos()), "Retrive windows editions").ShowDialog();

        private void Windows_Editions_List_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (j)
            {
                case 0:
                    InstallationData.index = (Windows_Editions_List.CurrentCell.RowIndex + 1);
                    InstallationData.size_in_mb = sizes[InstallationData.index - 1];
                    Moving.Form(this, new Select_Partition(Location));
                    break;
                case 2:
                    ToolsData.Conversion.index = (Windows_Editions_List.CurrentCell.RowIndex + 1);
                    Moving.Form(this, new SelectInstallationMode(Location, 3));
                    break;
                case 1:
                    Moving.Form(this, new MountImageFile(Location, Windows_Editions_List.CurrentCell.RowIndex + 1));
                    break;
            }
        }
    }
}
