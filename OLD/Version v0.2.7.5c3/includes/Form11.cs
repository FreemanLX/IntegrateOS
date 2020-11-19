using System;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication2
{
    public partial class Form11 : MetroFramework.Forms.MetroForm
    {
        int linux_temp = 0;

        public Form11(int linux = 0)
        { 
            InitializeComponent();
            linux_temp = linux;
            partitions(linux);
        }

        void partitions(int linux)
        {
            string[] drivers = new string[10];
            DriveInfo[] driverslist = DriveInfo.GetDrives();
            foreach (DriveInfo d in driverslist)
            {
                int i = 0;
                if (d.DriveType == 0) { }
                else
                {
                    if (d.DriveType == DriveType.CDRom || d.DriveType == DriveType.Network) { }
                    else
                    {
                        long gamma = d.TotalSize;
                        bool cond1;
                        if (linux == 1)
                            cond1 = gamma < 10000000000;
                        else cond1 = gamma < 2000000000;

                        if (cond1) { }
                        else
                        {

                            bool cond;
                            if (linux == 1)
                                cond = (d.DriveFormat == "NTFS") || (d.DriveFormat == "FAT32") || (d.DriveFormat == "EXFAT");
                            else
                                cond = (d.DriveFormat == "NTFS");
                            if (cond)
                            {
                                drivers[i] = d.Name; i++;
                                drivers[i] = d.DriveFormat.ToString();
                                i++;
                                if (d.IsReady == true)
                                {

                                    string TotalSize = (d.TotalSize / (1024 * 1024 * 1024)).ToString() + " GB";
                                    drivers[i] = TotalSize;
                                    i++;
                                    string AvailabeFree = (d.AvailableFreeSpace / (1024 * 1024 * 1024)).ToString() + " GB";
                                    drivers[i] = AvailabeFree;
                                    i++;
                                }
                                dataGridView1.Rows.Add(drivers);
                            }

                        }

                    }


                }

            }
        }

        WindowsSetup.Variabile g = new WindowsSetup.Variabile();

        

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            string drive_letter = "";
            try
            {
                drive_letter = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            }
            catch { }
            string t = "\\pagefile.sys";
            char[] s = new char[2];
            s[0] = drive_letter[0];
            s[1] = drive_letter[1];
            string ga = new string(s);
            string k = ga + t;
            string t1 = "\\hiberfile.sys";
            if (drive_letter != "")
            {
                string k1 = ga + t1;
                if (File.Exists(k) || File.Exists(k1))
                {
                    MetroFramework.MetroMessageBox.Show(this, "I can't format your disk, it contains system files such as pagefile.sys", "Error formating", MessageBoxButtons.OK, MessageBoxIcon.Error, IntegrateOS.IntegrateOS_var.color_t);
                }
                else
                {
                    WindowsSetup.Variabile.format = ga + "\\";
                    var result = MessageBox.Show("You really want to install Windows?", "Install Windows", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        IntegrateOS.set_partition temp_form;
                        if (linux_temp == 1) temp_form = new IntegrateOS.set_partition(ga, "EXT4");
                        else temp_form = new IntegrateOS.set_partition(ga);
                        temp_form.Show();
                        this.Hide();
                    }

                }


            }
            else
            {
                MessageBox.Show("You didn't selected any option!", "Error 003", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        

        private void Form11_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.IntegrateOS_var.color1, IntegrateOS.IntegrateOS_var.theme);

            dataGridView1.DefaultCellStyle.SelectionBackColor = IntegrateOS.Generate_Colors.Generate(IntegrateOS.IntegrateOS_var.color_t);

            if (IntegrateOS.IntegrateOS_var.dark == 0)
            {
                
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
                dataGridView1.ForeColor = System.Drawing.Color.White;
                dataGridView1.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                dataGridView1.BackgroundColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dataGridView1.DefaultCellStyle.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new Form5();
            form3.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void metroButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            partitions(linux_temp);
        }
    }
}
