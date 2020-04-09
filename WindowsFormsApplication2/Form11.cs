using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    public partial class Form11 : MetroFramework.Forms.MetroForm
    {
        public Form11()
        {
            InitializeComponent();
            DriveInfo[] driverslist = DriveInfo.GetDrives();
            foreach (DriveInfo d in driverslist)
            {
                using (StreamWriter objWriter = new StreamWriter("hdd.dll"))
                {

                    if (d.DriveType == 0)
                    {


                    }
                    else
                    {
                        if (d.DriveType == DriveType.CDRom || d.DriveType == DriveType.Network)
                        {

                        }
                        else
                        {
                            long gamma = d.TotalSize;
                            double e = WindowsSetup.Variabile.space_gb_ver;
                            if (gamma < e)
                            {


                            }
                            else
                            {
                                e = e + 0.5;
                                metroLabel2.Text = e.ToString() + " GB";
                                metroLabel2.Refresh();
                                if (d.DriveFormat == "NTFS")
                                { 
                                    objWriter.Write(d.Name);
                                    objWriter.Write("          {0}", d.DriveFormat);
                                    if (d.IsReady == true)
                                    {
                                        if (d.TotalSize / (1024 * 1024 * 1024) < 10)
                                        {
                                            objWriter.Write("                    {0} GB", d.TotalSize / (1024 * 1024 * 1024));
                                            objWriter.Write("                        {0} GB", d.AvailableFreeSpace / (1024 * 1024 * 1024));
                                        }
                                        else
                                        {
                                            objWriter.Write("                   {0} GB", d.TotalSize / (1024 * 1024 * 1024));
                                            if (d.AvailableFreeSpace / (1024 * 1024 * 1024) < 10)
                                                objWriter.Write("                        {0} GB", d.AvailableFreeSpace / (1024 * 1024 * 1024));
                                            else
                                                objWriter.Write("                        {0} GB", d.AvailableFreeSpace / (1024 * 1024 * 1024));
                                        }
                                    }
                                }
                            }
                        }

                    }
                          


                }
                string[] lines = File.ReadAllLines(@"hdd.dll");
                listBox1.Items.AddRange(lines);
            }
        }

 


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (File.Exists(@"1.txt"))
            {
                File.Delete(@"1.txt");
            }
            if (File.Exists(@"2.txt"))
            {
                File.Delete(@"2.txt");
            }
            if (File.Exists(@"disk.txt"))
            {
                File.Delete(@"disk.txt");
            }
            if (File.Exists(@"done.dll"))
            {
                File.Delete(@"done.dll");
            }
            File.Delete("drive.txt");
            File.Delete("edit.dll");
            File.Delete("error.dll");
            File.Delete("fix.txt");
            File.Delete("format1.txt");
            File.Delete("hdd.dll");
            if (File.Exists("hdd1.dll"))
            {
                File.Delete("hdd1.dll");
            }
            File.Delete("location.txt");
            File.Delete("temp.dll");
            File.Delete("upv.dll");
            File.Delete("verify.dll");
            File.Delete("wimdone.dll");
            File.Delete("work.dll");
            File.Delete("index.dll");
            File.Delete("indice.dll");
            File.Delete("fedition.txt");
            File.Delete("edition.txt");
            File.Delete("index.dll");
            File.Delete("indice.dll");
            File.Delete("fedition.txt");
            File.Delete("edition.txt");
            Environment.Exit(0);

        }


      
        private void button1_Click_1(object sender, EventArgs e)
        {
            char al=' ', f=' ';
            foreach (string ap in listBox1.CheckedItems)
            {
                al = ap[0];
                f = ap[1];
            }
            string al_s = al.ToString();
            string f_s = f.ToString();
            string com = al_s + f_s;
            string t = "\\pagefile.sys";
            string ga = com;
            string k = ga + t;
            string t1 = "\\hiberfile.sys";
                string k1 = ga + t1;
                if (File.Exists(k) || File.Exists(k1) || com == "C:")
                {
                    if (com == "C:")
                    {
                        MessageBox.Show("It's a system disk");
                    }
                    MessageBox.Show("I can't format your disk, it contains system files such as pagefile.sys. Code error 5!");
                }
                else
                {

                    string s = ga;
                    string s3 = "Format ";
                    string s2 = s3 + s;
                    string s4 = " /Y /FS:NTFS /V:Windows /Q";
                 string strCmdText = s2+s4;
                 WindowsSetup.Variabile.format = ga + "\\";

                    

                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine(strCmdText);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                var result = MessageBox.Show("You really want to install Windows?", "Install Windows", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var form2 = new Form13();
                    this.Hide();
                    form2.Show();
                }
                }
            
            


        }
        

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            if (WindowsSetup.Variabile.var == "wim")
            {var form3 = new Form14();
                this.Hide();
                form3.Show();
            }
            else {
               var form3 = new Form8();
                this.Hide();
                form3.Show();
            }
            
            
            using (StreamWriter objWriter = new StreamWriter("hdd.dll"))
            {
                objWriter.WriteLine("");
            }
            
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
