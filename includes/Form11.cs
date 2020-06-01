using System;
using System.Windows.Forms;
using System.IO;
using WindowsSetup;
using System.Threading;
using System.Management;

namespace WindowsFormsApplication2
{
    public partial class Form11 : MetroFramework.Forms.MetroForm
    {

        public Form11()
        {
            InitializeComponent();
            string[] drivers = new string[10];
            DriveInfo[] driverslist = DriveInfo.GetDrives();
            foreach (DriveInfo d in driverslist)
            {
                int i = 0;
                if (d.DriveType == 0){}
                else
                {
                    if (d.DriveType == DriveType.CDRom || d.DriveType == DriveType.Network) { }
                    else
                    {
                        long gamma = d.TotalSize;
                        double e = WindowsSetup.Variabile.space_gb_ver;
                        if (gamma < e) { }
                        else
                        {
                            e = e + 0.5;
                            metroLabel2.Text = e.ToString() + " MB";
                            metroLabel2.Refresh();
                            if (d.DriveFormat == "NTFS")
                            {
                                drivers[i] = d.Name; i++;
                                drivers[i] = d.DriveFormat.ToString();
                                i++;
                                if (d.IsReady == true)
                                {
                                    
                                        string TotalSize =(d.TotalSize / (1024 * 1024 * 1024)).ToString() + " GB";
                                        drivers[i]  = TotalSize;
                                        i++;
                                        string AvailabeFree = (d.AvailableFreeSpace / (1024 * 1024 * 1024)).ToString() + " GB";
                                        drivers[i]  = AvailabeFree; 
                                        i++;                                    
                                }
                            }
                            
                        }

                    }
                    dataGridView1.Rows.Add(drivers);

                }
                
            }
        }



        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            g.Clear();
            Environment.Exit(0);
        }

        

        
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
                if (File.Exists(k) || File.Exists(k1) || drive_letter == "C:")
                {
                    if (ga == "C:")
                    {
                        MessageBox.Show("It's a system disk");
                    }
                    MessageBox.Show("I can't format your disk, it contains system files such as pagefile.sys. Code error 5!");
                }
                else
                {
                    WindowsSetup.Variabile.format = ga + "\\";
                    var result = MessageBox.Show("You really want to install Windows?", "Install Windows", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        IntegrateOS.set_partition temp_form = new IntegrateOS.set_partition(ga);
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

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var form3 = new Form5();
            this.Hide();
            form3.Show();    
        }

        private void metroLabel2_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
