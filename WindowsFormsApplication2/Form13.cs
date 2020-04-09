using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class Form13 : MetroFramework.Forms.MetroForm
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
           
        }

        private void cmd(string s, int e = 1)
         {
            
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(s);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            if (e == 1)
            {
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            }
        }

        private void Conquer(string loading)
        {
            string dism = "dism /export-image /SourceImageFile:" + loading + " /SourceIndex:" + WindowsSetup.Variabile.fix + " /DestinationImageFile:" + WindowsSetup.Variabile.format + "\\install.wim " + "/Compress:none / CheckIntegrity";
            cmd(dism);

        }
        long min(long a, long b)
        {
            if (a < b) return a;
            return b;
            
        }
        public static int CountLines(string filename)
        {
            int result = 0;

            using (var input = File.OpenText(filename))
            {
                while (input.ReadLine() != null)
                {
                    ++result;
                }
            }

            return result;
        }

            private void Imagex(string loading)
            {
            int load_temp_c = 0;
            string imagex = "dism /Apply-Image /ImageFile:" + loading + " /index:" + WindowsSetup.Variabile.fix + " /ApplyDir:" + WindowsSetup.Variabile.format + "\\ > temp.txt";
            Process cmd1 = new Process();
            cmd1.StartInfo.FileName = "cmd.exe";
            cmd1.StartInfo.RedirectStandardInput = true;
            cmd1.StartInfo.RedirectStandardOutput = true;
            cmd1.StartInfo.CreateNoWindow = true;
            cmd1.StartInfo.UseShellExecute = false;
            cmd1.Start();
            cmd1.StandardInput.WriteLine(imagex);
            cmd1.StandardInput.Flush();
            int e = 0;
            label9.Text = String.Format("(0 %)");
            int fu = 1;
            int f = 6;
            string temp = "";
            string co = fu.ToString();
            string complete = "Temp\\temp" + co + ".txt";
            Thread.Sleep(3000);
            label9.Text = string.Format("({0} %)", e);
            while (e < 95)
            {
                if (File.Exists("temp.txt"))
                {
                   
                    string[] load_all;
                    if (e == 0)
                        load_all = File.ReadAllLines("TEMP\\temp0.txt");
                    else
                    {
                        File.Copy("temp.txt", complete, true);
                        load_all = File.ReadAllLines(complete);
                    }

                    string complete_load = "";
                    if (load_all.Length != 0)
                    {
                        int gaa;
                        if (e == 0)
                        {
                            gaa = 6;

                        }
                        else
                            gaa = CountLines(complete) - 1;


                        int k;
                        for (k = 0; k <= gaa; k++)
                        {
                            if (load_all[gaa][0] == '[' && load_all[gaa] != " ")
                            {
                                complete_load = load_all[gaa];
                                break;
                            }
                        }
                        string load = complete_load;
                        if (load != null && load!="")
                        {
                            int kx = 0;
                            for (int i = 0; i < load.Length; i++)
                                if (load[i] <= '9' && load[i] >= '0')
                                {
                                    kx = kx + load[i] - '0';
                                    kx *= 10;
                                }
                            kx /= 100;
                            e = kx;
                            label9.Text = string.Format("({0} %)", kx);
                            label9.Refresh();
                            if (load_temp_c != e / 4)
                            {
                                if (e == 94)
                                    progressBar1.Value = 40;
                                else
                                {
                                    progressBar1.Value = 15 + e / 4;
                                    load_temp_c = e / 4;
                                }
                            }
                            label7.Text = progressBar1.Value.ToString() + " %";
                            label7.Refresh();
                            fu++;
                            f += 2;
                            co = fu.ToString();
                            complete = "Temp\\temp" + co + ".txt";
                            Thread.Sleep(5000);
                            temp = load;
                        }
                    }
                }
            }
            label9.Text = "(100 %)";
            label9.Refresh();
            Thread.Sleep(1000);

        }

        private void Bcdboot()
        {
            string bcdboot;
            bcdboot = "bcdboot " + WindowsSetup.Variabile.format + "\\Windows /s " + WindowsSetup.Variabile.format + "\\" + " /f all";
            cmd(bcdboot);

        }
        private void Bootsect()
        {
            string bootsect = "bootsect /NT60 " + WindowsSetup.Variabile.format + " /force";
            cmd(bootsect);
        }

        private void Bcdedit()
        {
            string firstbcdedit;
            firstbcdedit = "bcdedit /copy {current} /d \"Windows\" > edit.dll";
            cmd(firstbcdedit);
            string lines = File.ReadAllText(@"edit.dll");
            string[] s1 = lines.Split('{');
            string ep = "bcdedit.exe /set " + s1[1] + "device partiion=" + WindowsSetup.Variabile.format;
            cmd(ep);
            string ep1 = "bcdedit.exe /set " + s1[1] + " path \\Windows\\system32\\winload.exe";
            cmd(ep1);
            string ep2 = "bcdedit.exe /set " + s1[1] + " systemroot \\Windows";
            cmd(ep2);
        }

        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            g.Clear();
            Environment.Exit(0);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            label7.Enabled = true;
            label7.Visible = true;
            string ss = WindowsSetup.Variabile.locatie;
            label7.Text = string.Format("{0} %", progressBar1.Value);
            label7.Refresh();
            if (WindowsSetup.Variabile.var == "wim")
            {
                int epsilon = 0;
                
                if (progressBar1.Value == 0)
                {
                    while (epsilon <= 100)
                    {
                        label8.Text = "(" + epsilon.ToString() + "  %)";
                        label8.Refresh();
                        epsilon++;
                        Thread.Sleep(300);
                        if (epsilon % 10 == 0 && epsilon != 0)
                        {
                            progressBar1.Increment(1);
                            label7.Text = progressBar1.Value.ToString() + " %";
                            label7.Refresh();
                        }
                    }
                    Thread.Sleep(1000);
                    label4.Visible = false;
                    label8.Visible = false;
                    while (progressBar1.Value < 15)
                    {
                        progressBar1.Increment(1);
                        label7.Text = progressBar1.Value.ToString() + " %";
                        label7.Refresh();
                        Thread.Sleep(500);
                    }
                    Imagex(ss);
                    progressBar1.Value = 40;
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                    label9.Text = "";
                    label12.Visible = true;
                }
                if (progressBar1.Value == 40)
                {
                    label1.Font = new Font("Arial", 14, FontStyle.Regular);
                    label5.Font = new Font("Arial", 14, FontStyle.Bold);
                    Bootsect();
                    Thread.Sleep(5000);
                    label13.Visible = true;
                    progressBar1.Value += 10;
                    label7.Text = progressBar1.Value.ToString() +  "%";
                    label7.Refresh();
                }
                if (progressBar1.Value == 50)
                {
                    progressBar1.Value += 10;
                    Bcdboot();
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                }
                if (progressBar1.Value == 60)
                {
                    progressBar1.Value += 20;
                    label5.Font = new Font("Arial", 14, FontStyle.Regular);
                    label6.Font = new Font("Arial", 14, FontStyle.Bold);
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                    Thread.Sleep(5000);
                }
                if (progressBar1.Value == 80)
                {
                    progressBar1.Value += 20;
                    Bcdedit();
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                    Thread.Sleep(5000);
                }
                if (progressBar1. Value == 100)
                {
                    timer1.Enabled = false;
                    progressBar1.Enabled = false;
                    var formga = new Form19();
                    this.Hide();
                    formga.Show();
                }
            }
            if (WindowsSetup.Variabile.var == "esd")
            {
                if (progressBar1.Value == 0)
                {
                    Conquer(ss);
                    progressBar1.Value += 20;
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                }

                if (progressBar1.Value == 20)
                {
                    string gamma = WindowsSetup.Variabile.format + "\\install.wim";
                    Imagex(gamma);
                    progressBar1.Value += 30;
                    label1.Font = new Font("Arial", 14, FontStyle.Regular);
                    label5.Font = new Font("Arial", 14, FontStyle.Bold);
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                }

                if (progressBar1.Value == 50)
                {
                    Bootsect();
                    progressBar1.Value += 20;
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                    Thread.Sleep(5000);
                }

                if (progressBar1.Value == 70)
                {
                    Bcdboot();
                    progressBar1.Value += 20;
                    label5.Font = new Font("Arial", 14, FontStyle.Regular);
                    label6.Font = new Font("Arial", 14, FontStyle.Bold);
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                    Thread.Sleep(5000);
                }
                if (progressBar1.Value == 90)
                {
                    Bcdedit();
                    progressBar1.Value += 10;
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                    Thread.Sleep(5000);
                }
                if(progressBar1.Value == 100)
                {
                    timer1.Enabled = false;
                    progressBar1.Enabled = false;
                    var formga = new Form19();
                    this.Hide();
                    formga.Show();
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
