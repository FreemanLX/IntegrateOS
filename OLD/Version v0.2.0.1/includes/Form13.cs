using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using WindowsSetup;


namespace WindowsFormsApplication2
{
    public partial class Form13 : MetroFramework.Forms.MetroForm
    {
        public Form13(){InitializeComponent();}
        private void Form13_Load(object sender, EventArgs e){}
        private void Conquer(string loading)
        {
            string dism = "Packages\\dism /export-image /SourceImageFile:" + "\"" + loading + "\"" + " /SourceIndex:" + WindowsSetup.Variabile.fix + " /DestinationImageFile:" + WindowsSetup.Variabile.format + "\\install.wim " + "/Compress:none / CheckIntegrity";
            CMD_Process_Class.Process_CMD(dism);
        }

         private void Imagex(string loading)
         {
            Thread t1 = new Thread(
                ()=>
                {
                    string imagex = "Packages\\dism /Apply-Image /ImageFile:" + "\"" + loading + "\"" + " /index:" + WindowsSetup.Variabile.fix + " /ApplyDir:" + WindowsSetup.Variabile.format + "\\ > Packages\\temp.txt";
                    CMD_Process_Class.Process_CMD(imagex, 1);
                    Invoke(new Action(() =>
                    {
                       
                    }));
                }
            )
            { IsBackground = true};
            t1.Start();
            while (t1.IsAlive)
            {
                Thread.Sleep(500);
                Application.DoEvents();
            }


        }

        private void Bcdboot()
        {
            string bcdboot;
            bcdboot = "Packages\\bcdboot " + WindowsSetup.Variabile.format + "\\Windows /s " + WindowsSetup.Variabile.format + "\\" + " /f all";
            CMD_Process_Class.Process_CMD(bcdboot);

        }
        private void Bootsect()
        {
            string bootsect = "Packages\\bootsect /NT60 " + WindowsSetup.Variabile.format + " /force";
            CMD_Process_Class.Process_CMD(bootsect);
        }

        private void Bcdedit()
        {
            string firstbcdedit;
            firstbcdedit = "Packages\\bcdedit /copy {current} /d \"Windows\" > edit.dll";
            CMD_Process_Class.Process_CMD(firstbcdedit);
            string lines = File.ReadAllText(@"edit.dll");
            string[] s1 = lines.Split('{');
            string ep = "Packages\\bcdedit.exe /set " + s1[1] + "device partition=" + WindowsSetup.Variabile.format;
            CMD_Process_Class.Process_CMD(ep);
            string ep1 = "Packages\\bcdedit.exe /set " + s1[1] + " path \\Windows\\system32\\winload.exe";
            CMD_Process_Class.Process_CMD(ep1);
            string ep2 = "Packages\\bcdedit.exe /set " + s1[1] + " systemroot \\Windows";
            CMD_Process_Class.Process_CMD(ep2);
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
                if (progressBar1.Value == 0)
                {
                    progressBar1.Value = 20;
                    label4.Visible = false;
                    label8.Visible = false;
                    Imagex(ss);
                    progressBar1.Value = 70;
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                    label12.Visible = true;
                }
                if (progressBar1.Value == 70)
                {
                    label1.Font = new Font("Segoe UI Semilight", 14, FontStyle.Regular);
                    label5.Font = new Font("Segoe UI Semibold", 14, FontStyle.Italic);
                    Bootsect();
                    Thread.Sleep(5000);
                    label13.Visible = true;
                    progressBar1.Value += 10;
                    label7.Text = progressBar1.Value.ToString() +  "%";
                    label7.Refresh();
                }
                if (progressBar1.Value == 80)
                {
                    progressBar1.Value += 5;
                    Bcdboot();
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                }
                if (progressBar1.Value == 85)
                {
                    progressBar1.Value += 15;
                    label5.Font = new Font("Segoe UI Semilight", 14, FontStyle.Regular);
                    label6.Font = new Font("Segoe UI Semibold", 14, FontStyle.Italic);
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                    Thread.Sleep(5000);
                    Bcdedit();
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
                    label1.Font = new Font("Segoe UI Semilight", 14, FontStyle.Regular);
                    label5.Font = new Font("Segoe UI Semibold", 14, FontStyle.Italic);
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
                    label5.Font = new Font("Segoe UI Semilight", 14, FontStyle.Regular);
                    label6.Font = new Font("Segoe UI Semibold", 14, FontStyle.Italic);
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
