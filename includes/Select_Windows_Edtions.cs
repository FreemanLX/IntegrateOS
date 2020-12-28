using System;
using System.Windows.Forms;

namespace IntegrateOS
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

        public bool Getting_WindowsInfo(string path)
        {
                ManagedWimLib.Wim.GlobalInit("libwim-15.dll");
                try
                {
                    ManagedWimLib.Wim wim = ManagedWimLib.Wim.OpenWim(path, ManagedWimLib.OpenFlags.DEFAULT);
                    ManagedWimLib.WimInfo info = wim.GetWimInfo();
                    string[] index = new string[info.ImageCount];
                    ManagedWimLib.CompressionType compression = info.CompressionType;
                    
                    for (int i = 0; i < info.ImageCount; i++)
                    {
                        switch(info.CompressionType)
                        {
                            case ManagedWimLib.CompressionType.LZMS:
                                   Windows_Editions_List.Rows.Add(wim.GetImageDescription(i + 1), (info.TotalBytes / (1024 * 1024)).ToString() + " MB", "LZMS");
                                break;
                            case ManagedWimLib.CompressionType.LZX:
                                Windows_Editions_List.Rows.Add(wim.GetImageDescription(i + 1), (info.TotalBytes / (1024 * 1024)).ToString() + " MB", "LZX");
                                break;
                            case ManagedWimLib.CompressionType.NONE:
                                Windows_Editions_List.Rows.Add(wim.GetImageDescription(i + 1), (info.TotalBytes / (1024 * 1024)).ToString() + " MB", "NONE");
                                break;
                            case ManagedWimLib.CompressionType.XPRESS:
                                Windows_Editions_List.Rows.Add(wim.GetImageDescription(i + 1), (info.TotalBytes / (1024 * 1024)).ToString() + " MB", "XPRESS");
                                break;
                        }

                    }
                    ManagedWimLib.Wim.GlobalCleanup();
                    return true;
                }
                catch
                {
                    MessageBox.Show("Error loading the selected file: " + path);
                    ManagedWimLib.Wim.GlobalCleanup();
                    return false;
                }
        }



        string get_path = "";
        private void Form12_Load(object sender, EventArgs e)
        {
            switch (j)
            {
                case 0:  get_path = IntegrateOS.Temporary_I.locatie; break;
                case 1:  get_path = Tools_location.Conversion.convert_path; break;
                case 2:  get_path = Tools_location.Mount.path_to_mount;  break;
                default: break;
            }
            bool pointers = Getting_WindowsInfo(get_path);
            if (pointers == false)
            {
                if (j == 0)
                    IntegrateOS.Moving.Form(this, new IntegrateOS.Selection_os(Location));
                
                else                
                    IntegrateOS.Moving.Form(this, new IntegrateOS.Basic_tools(Location));
                
            }
            
            this.StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            Windows_Editions_List.DefaultCellStyle.SelectionBackColor = IntegrateOS.Generate_Colors.Generate(IntegrateOS.IntegrateOS_var.color_t);
            if (IntegrateOS.IntegrateOS_var.dark == 0)
            {
                Back.BackgroundImage = IntegrateOS.Resources.white_left_arrow;
                Refresh.BackgroundImage = IntegrateOS.Resources.refresh_48_lightmode;
                
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
                Back.BackgroundImage = IntegrateOS.Resources.black_left_arrow;
                Refresh.BackgroundImage = IntegrateOS.Resources.refresh_48_darkmode;
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


        private void Next_Click(object sender, EventArgs e)
        {
            
                switch (j)
                {
                    case 0:
                            IntegrateOS.Temporary_I.fix = (Windows_Editions_List.CurrentCell.RowIndex + 1).ToString();
                            IntegrateOS.Moving.Form(this, new Select_Partition(Location));
                            break;
                    case 1:
                            IntegrateOS.Tools_location.Conversion.index = (Windows_Editions_List.CurrentCell.RowIndex + 1);
                            IntegrateOS.Moving.Form(this, new Select_installation(Location, 3));
                            break;
                    case 2:
                            IntegrateOS.Moving.Form(this, new IntegrateOS.Mount_Windows(Location, Windows_Editions_List.CurrentCell.RowIndex + 1));
                            break;
                }

        }



        private void Refresh_Click(object sender, EventArgs e)
        {
            Windows_Editions_List.Rows.Clear();
            bool pointers = Getting_WindowsInfo(get_path);
        }

        private void Moving_Selection_OS_Click(object sender, EventArgs e)
        {
            if (j == 0)
            {
                IntegrateOS.Moving.Form(this, new IntegrateOS.Selection_os(this.Location));
            }

            else {
                IntegrateOS.Moving.Form(this, new IntegrateOS.Basic_tools(this.Location));
            }
       }
    }
}
