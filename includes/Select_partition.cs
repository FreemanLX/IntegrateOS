using System;
using System.Windows.Forms;
using System.IO;


namespace IntegrateOS
{
    public partial class Select_Partition : MetroFramework.Forms.MetroForm
    {
        int linux_temp = 0;
        public Select_Partition(System.Drawing.Point punct, int linux = 0)
        { 
            InitializeComponent();
            linux_temp = linux;
            Location = punct;
            Partitions(linux);
        }

        void Partitions(int linux)
        {
            string[] drivers = new string[10];
            DriveInfo[] driverslist = DriveInfo.GetDrives();
            foreach (DriveInfo d in driverslist)
            {
                int i = 0;
                if (d.DriveType == 0 || d.DriveType == DriveType.CDRom || d.DriveType == DriveType.Network) { }
                else
                {
                        long gamma = d.TotalSize;
                        bool cond1 = linux == 1 ? gamma < 10000000000 : gamma < 2000000000;
                        if (cond1) { }
                        else
                        {
                            bool cond = linux == 1 ? (d.DriveFormat == "NTFS") || (d.DriveFormat == "FAT32") || (d.DriveFormat == "EXFAT") : (d.DriveFormat == "NTFS");
                            if (cond)
                            {
                                drivers[i] = d.Name; i++;
                                drivers[i] = d.DriveFormat.ToString(); i++;
                                if (d.IsReady == true)
                                {
                                    drivers[i] = (d.TotalSize / (1024 * 1024 * 1024)).ToString() + " GB"; i++;
                                    drivers[i] = (d.AvailableFreeSpace / (1024 * 1024 * 1024)).ToString() + " GB"; i++;
                                    dataGridView1.Rows.Add(drivers);
                                }
                                
                            }

                        }

                }

            }
        }

        
        private void Next_Click_1(object sender, EventArgs e)
        {
            string drive_letter = "";
            try
            {
                drive_letter = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            }
            catch { }
            char[] s = new char[2];
            s[0] = drive_letter[0];
            s[1] = drive_letter[1];
            string ga = new string(s);
            if (drive_letter != "")
            {
                if (File.Exists(new string(s) + "\\hiberfile.sys") || File.Exists(new string(s) + "\\pagefile.sys"))
                {
                    MetroFramework.MetroMessageBox.Show(this, "I can't Format your disk, it contains system files such as pagefile.sys", "Error formating", MessageBoxButtons.OK, MessageBoxIcon.Error, IntegrateOS_var.color_t);
                }
                else
                {
                    Temporary_I.format = ga + "\\";
                    if (linux_temp == 1) IntegrateOS.Moving.Form(this, new IntegrateOS.Set_partition(Location, ga, "EXT4"));
                    else IntegrateOS.Moving.Form(this, new IntegrateOS.Set_partition(Location, ga));
                }
            }
            else
            {
                MessageBox.Show("You didn't selected any option!", "Error 003", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        

        private void Form11_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            dataGridView1.DefaultCellStyle.SelectionBackColor = IntegrateOS.Generate_Colors.Generate(IntegrateOS.IntegrateOS_var.color_t);
            metroButton1.BackgroundImageLayout = button2.BackgroundImageLayout = ImageLayout.Center;
            if (IntegrateOS.IntegrateOS_var.dark == 0)
            {
                button2.BackgroundImage = IntegrateOS.Resources.white_left_arrow;
                metroButton1.BackgroundImage = IntegrateOS.Resources.refresh_48_lightmode;
                dataGridView1.ForeColor = System.Drawing.Color.Black;
                dataGridView1.BackColor = System.Drawing.Color.White;
                dataGridView1.BackgroundColor = System.Drawing.Color.White;
                dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Light);
            }
            else
            {
                button2.BackgroundImage = IntegrateOS.Resources.black_left_arrow;
                metroButton1.BackgroundImage = IntegrateOS.Resources.refresh_48_darkmode;
                dataGridView1.ForeColor = System.Drawing.Color.White;
                dataGridView1.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                dataGridView1.BackgroundColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dataGridView1.DefaultCellStyle.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            IntegrateOS.Moving.Form(this, new Select_installation(Location));
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            Partitions(linux_temp);
        }

    }
}
