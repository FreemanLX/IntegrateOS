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
        private void Form13_Load(object sender, EventArgs e){///asta e formul pe care vrem sa l extractam si sa l instalam
        }
        Thread t2;

        Thread ExtractSWM_1;
        private void ExtractSWM ()
        {
            ///asta e comanda ne vom folosi de ea: dism /apply-image /ImageFile:C:\install.swm /SWMFile:install*.swm   /Index:1 /ApplyDir:E:\ /checkintegrity
            ///si avem asa
            ///

            string dism = "dism /apply image /ImageFile:" + "\"" + WindowsSetup.Variabile.locatie + "\"" + " /SWMFile:"; ///problema devine mai grea ca trebuie sa avem * la final, dar e in regula se rezolva.
            string[] get_name = WindowsSetup.Variabile.locatie.Split('.');
            ///functia da split cand vede primul . deci daca avem C:\Windows\Nume.swm atunci get_name[0] e C:\Windows\Nume
            ///si get_name[1] e .swm
            ///Vom folosi get_name[0] ca de el avem nevoie.
            ///
            ///deci vom unii si finaliza comanda
            /// 

            ///evident noi nu vrem ca programul sa se blocheze cand apelam un proces deci folosim un thread
            dism = dism + "\"" + get_name + "*.swm\"" + " /Index: " + WindowsSetup.Variabile.fix + " /ApplyDir:" + WindowsSetup.Variabile.format + "\\ /checkintegrity";
            MessageBox.Show(dism); ///for tests purposes
            ExtractSWM_1 = new Thread(
                () =>
            {
                CMD_Process_Class.Process_CMD(dism);
                ///Am integrat procesul in thread vrem sa invokam ca grafica sa nu aibe probleme
                Invoke(new Action(() =>
                {
                    ExtractSWM_1.Abort();
                }));
                
            });
            ///Si in final apelam threadul
            ///Inainte de asta vrem ca threadu sa fie in Background deci

            ExtractSWM_1.IsBackground = true;
            while (ExtractSWM_1.IsAlive)
            {
                Thread.Sleep(500); ///blocam acest form pentru extractare ...
                Application.DoEvents(); ///Lasam formul sa respire cat timp functioneaza threadul
            }

            ///am codat cum sa extractezi un SWM
        }
        private void Conquer(string loading)
        {////Functia asta extracteaza un fisier WIM fiindca lucram cu SWM vom folosi pentru SWM si cred ca daca fac o functie ajunge 
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

            ///creem aici o obtiune pt swm
            ///
            
            if (WindowsSetup.Variabile.var == "wim" || WindowsSetup.Variabile.var == "swm")
            {                
                if (progressBar1.Value == 0)
                {
                    progressBar1.Value = progressBar1.Value + 20;
                    label4.Visible = false;
                    label8.Visible = false;
                    if (WindowsSetup.Variabile.var == "wim")
                        Imagex(ss);
                    else
                    {
                        if (WindowsSetup.Variabile.var == "swm")
                            ExtractSWM();
                    }
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

                ///Am terminat I guess
                ///hai cu eroriile
                ///Uite c o mers
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
