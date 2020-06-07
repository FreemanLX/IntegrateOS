using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using WindowsSetup;
using System.Diagnostics;



namespace WindowsFormsApplication2
{
    public partial class Form13 : MetroFramework.Forms.MetroForm
    {
        public Form13(){InitializeComponent();}
        private void Form13_Load(object sender, EventArgs e){}
        Thread t2;
        private void Conquer(string loading)
        {
            string dism = "Packages\\dism /export-image /SourceImageFile:" + "\"" + loading + "\"" + " /SourceIndex:" + WindowsSetup.Variabile.fix + " /DestinationImageFile:" + WindowsSetup.Variabile.format + "\\install.wim " + "/Compress:none /CheckIntegrity";
            t2 = new Thread(
             () =>
             {
                 CMD_Process_Class.Process_CMD(dism, 1);
                 Invoke(new Action(()=>{
                     t2.Abort();
             }));
                 
             }
                );
            t2.IsBackground = true;
            while(t2.IsAlive)
            {
                Thread.Sleep(500);
            }
            t2.Start();
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

        
        string temp;
        private void Bcdedit(int e = 0)
        {
            string firstbcdedit;
            try
            {

                    using (IntegrateOS.Bcdedit_name name = new IntegrateOS.Bcdedit_name())
                    {
                        name.ShowDialog();
                        temp = name.get();
                    }
                
             
            }
            catch { }
            firstbcdedit = "Packages\\bcdedit /copy {current} /d \"" + temp + "\" > Packages\\edit.dll";
            CMD_Process_Class.Process_CMD(firstbcdedit);
            string lines = File.ReadAllText(@"Packages\\edit.dll");
            string[] s1 = lines.Split('{');
            string[] test = WindowsSetup.Variabile.format.Split('\\');
            string[] s2 = s1[1].Split('.');
            string ep = "Packages\\bcdedit.exe /set " + '{' + s2[0] + " device partition=" + test[0];
            string ep2 = "Packages\\bcdedit.exe /set " + '{' + s2[0] + " osdevice partition=" + test[0];
            MessageBox.Show(ep);

            CMD_Process_Class.Process_CMD(ep);
            CMD_Process_Class.Process_CMD(ep2);
            if (File.Exists("Packages\\test.txt"))
            {
                File.Delete("Packages\\test.txt");
            }
            string verify_type = "powershell $(Get-ComputerInfo).BiosFirmwareType > Packages\\test.txt";
            CMD_Process_Class.Process_CMD(verify_type, 1);
            string[] line = File.ReadAllLines(@"Packages\\test.txt");
            string ep1 = "";
            if(line[0] == "Uefi")
            {
                ep1 = "Packages\\bcdedit.exe /set " + '{' + s2[0] + " path \\Windows\\system32\\winload.efi";
            }
            else
            {
                ep1 = "Packages\\bcdedit.exe /set " + '{' + s2[0] + " path \\Windows\\system32\\winload.exe";
            }

            CMD_Process_Class.Process_CMD(ep1);
            string ep3 = "Packages\\bcdedit.exe /set " + '{' + s2[0] + " systemroot \\Windows";
            CMD_Process_Class.Process_CMD(ep3);
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
                    progressBar1.Value = 60;
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                    label12.Visible = true;
                }
                if (progressBar1.Value == 60)
                {
                    label1.Font = new Font("Segoe UI Semilight", 14, FontStyle.Regular);
                    label5.Font = new Font("Segoe UI Semibold", 14, FontStyle.Italic);
                    label1.Refresh();
                    label5.Refresh();
                    Bootsect();
                    Thread.Sleep(5000);
                    label13.Visible = true;
                    progressBar1.Value += 10;
                    label7.Text = progressBar1.Value.ToString() +  "%";
                    label7.Refresh();
                }
                if (progressBar1.Value == 70)
                {
                    progressBar1.Value += 5;
                    Bcdboot();
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                }
                if (progressBar1.Value == 75)
                {
                    label5.Font = new Font("Segoe UI Semilight", 14, FontStyle.Regular);
                    label6.Font = new Font("Segoe UI Semibold", 14, FontStyle.Italic);
                    label5.Refresh();
                    label6.Refresh();
                    progressBar1.Value += 25;
                    Thread t = new Thread(() =>
                    {
                        Bcdedit();
                    });
                    t.Start();
                    t.Join();
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
                    label1.Font = new Font("Segoe UI Semilight", 14, FontStyle.Regular);
                    label5.Font = new Font("Segoe UI Semibold", 14, FontStyle.Italic);
                    label5.Refresh();
                    label1.Refresh();
                    progressBar1.Value += 30;
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
                    label5.Font = new Font("Segoe UI Semilight", 14, FontStyle.Regular);
                    label6.Font = new Font("Segoe UI Semibold", 14, FontStyle.Italic);
                    label5.Refresh();
                    label6.Refresh();
                    Bcdboot();
                    progressBar1.Value += 20;
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                    Thread.Sleep(5000);
                }
                if (progressBar1.Value == 90)
                {
                    Thread t = new Thread(() =>
                    {
                        Bcdedit();
                    });
                    t.Start();
                    t.Join();
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
