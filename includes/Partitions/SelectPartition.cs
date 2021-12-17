using System;
using System.Windows.Forms;
using System.IO;
using MetroFramework;
using MetroFramework.Drawing;
using System.Drawing;
using IntegrateOS.Setup.Windows;

namespace IntegrateOS
{
    public partial class Select_Partition : MetroFramework.Forms.MetroForm
    {
        int linux_temp = 0;
        public Select_Partition(Point punct, int linux = 0)
        {
            InitializeComponent();
            linux_temp = linux;
            Location = punct;
            Partitions();
        }

        bool Verify_drive_avaibility(DriveInfo driver) => !(driver.DriveType == 0 || driver.DriveType == DriveType.CDRom || driver.DriveType == DriveType.Network);

        void Partitions()
        {
            foreach (DriveInfo driver in DriveInfo.GetDrives())
            {
                if (Verify_drive_avaibility(driver) && driver.IsReady == true && driver.AvailableFreeSpace / Math.Pow(1024, 2) > InstallationData.size_in_mb + 100)
                {
                    Partition_list.Rows.Add(new string[] { driver.Name, driver.DriveFormat, Math.Round(driver.TotalSize / Math.Pow(1024, 3), 2).ToString() + " GB",
                        Math.Round(driver.AvailableFreeSpace / Math.Pow(1024, 3), 2).ToString() + " GB" });
                }
            }
        }
        
        private void Select_Partition_Load(object sender, EventArgs e)
        {
            StyleManager = Themes.Generate;
            Partition_list.DefaultCellStyle.SelectionBackColor = GenerateColors.Generate((int)Themes.MetroColor);
            metroButton1.BackgroundImageLayout = button2.BackgroundImageLayout = ImageLayout.Center;
            label4.ForeColor = Themes.GenerateTheme(!Themes.MetroTheme);
            button2.BackgroundImage = Themes.Icon_Style;
            if (Themes.MetroTheme == 0 || (int)Themes.MetroTheme == 1)
            {
                metroButton1.BackgroundImage = Resources.refresh_48_lightmode;
                Partition_list.ForeColor = Color.Black;
                Partition_list.BackColor = Color.White;
                Partition_list.BackgroundColor = Color.White;
                Partition_list.DefaultCellStyle.ForeColor = Color.Black;
                Partition_list.DefaultCellStyle.BackColor = Color.White;
                Partition_list.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                Partition_list.ColumnHeadersDefaultCellStyle.BackColor = MetroPaint.BackColor.Form(MetroThemeStyle.Light);
            }
            else
            {
                metroButton1.BackgroundImage = Resources.refresh_48_darkmode;
                Partition_list.ForeColor = Color.White;
                Partition_list.BackColor = MetroPaint.BackColor.Form(MetroThemeStyle.Dark);
                Partition_list.BackgroundColor = MetroPaint.BackColor.Form(MetroThemeStyle.Dark);
                Partition_list.DefaultCellStyle.ForeColor = Color.White;
                Partition_list.DefaultCellStyle.BackColor = MetroPaint.BackColor.Form(MetroThemeStyle.Dark);
                Partition_list.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Partition_list.ColumnHeadersDefaultCellStyle.BackColor = MetroPaint.BackColor.Form(MetroThemeStyle.Dark);
            }
        }

        /// <summary>
        /// It moves back from this form to the form which the activity started
        /// </summary>
        /// <param name="sender">The button sender</param>
        /// <param name="e">The button arguments</param>
        private void Back_Click(object sender, EventArgs e) => Moving.Form(this, new SelectInstallationMode(Location));
        
        private void RefreshData()
        {
            Partition_list.Rows.Clear(); ///clears the table
            Partition_list.Refresh();  ///refreshing the table
            Partitions(); ///recalling to search the partitions
        }

        private void Refresh_Click(object sender, EventArgs e) => RefreshData();

        private void PartitionList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string drive_letter = Partition_list[0, Partition_list.CurrentCell.RowIndex].Value.ToString();
            if(drive_letter != Path.GetPathRoot(Environment.SystemDirectory))
            {
                ///instalable even if you have the pagefile / hiberfile or whatever
                InstallationData.partition = drive_letter;
                Moving.Form(this, new Installation(Location));
            }
        }

        private void Format_Click(object sender, EventArgs e)
        {
            string drive_letter = Partition_list[0, Partition_list.CurrentCell.RowIndex].Value.ToString(); 
            new Set_partition(Location, new string(new char[] { drive_letter[0], drive_letter[1] })).ShowDialog();
            RefreshData();
        }
    }
}
