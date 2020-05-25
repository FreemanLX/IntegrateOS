using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using DiscUtils.Wim;
using WindowsSetup;

namespace WindowsFormsApplication2
{
    public partial class Form12 : MetroFramework.Forms.MetroForm
    {
        public Form12()
        {
            InitializeComponent();
        }

        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            g.Clear();
            try
            {
                System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(@"Packages\Temp\");
                foreach (System.IO.FileInfo file in directory.GetFiles())
                    file.Delete();
                foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories())
                    subDirectory.Delete(true);
            }
            catch { }
            Environment.Exit(0);
        }

        int Count_size(string alpha)
        {
            int ep = alpha.Length;
            return ep;

        }
        
        int converter(int max)
        {
            int ep = max / 1024;
            ep /= 1024;
            ep /= 1024;
            return ep;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            try
            {
                using (FileStream wimstream = new FileStream(WindowsSetup.Variabile.locatie, FileMode.Open, FileAccess.Read))
                {

                    WimFile x = new WimFile(wimstream);
                    
                }
            }
            catch
            {

            }
            string dism = "dism /Get-WimInfo /WimFile:";
            string install = "\"" + WindowsSetup.Variabile.locatie + "\" > Packages\\fix.txt";
            string installing = dism + install;
            CMD_Process_Class.Process_CMD(installing);
            string[] lines = File.ReadAllLines("Packages\\fix.txt");
            var lineCount = File.ReadAllLines("Packages\\fix.txt").Length;
            int i = 7, j = 1;
            for (i = 7; i < lineCount; i += 5)
            {
                string ep = lines[i];
                string[] lines3 = ep.Split(':');
                string gamma = lines[i + 2];
                string lines2 = "Index " + j.ToString() + ":" + lines3[1] + " ";
                string[] lines1 = new String[] { lines2 };
                string[] gamma_space = gamma.Split(':');
                string comp = gamma_space[1];
                lines2 += comp;
                string[] comp_sp = comp.Split(',');
                int space_nu = Int32.Parse(comp_sp[0]);
                WindowsSetup.Variabile.space_gb_ver = space_nu;
                checkedListBox1.Items.AddRange(lines1);
                if (i > lineCount)
                {
                    break;
                }
                j++;
            }
      
            
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            string s = "";
            foreach (string lambda in checkedListBox1.Items)
            {
                s = lambda;
            }
            string[] tmp = s.Split(' ');
            string number = tmp[1];
            string[] number1 = number.Split(':');
            string number2 = number1[0];
            WindowsSetup.Variabile.fix = number2;
            var form = new Form11();
            this.Hide();
            form.Show();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string dism = "dism /Get-WimInfo /WimFile:";
            string install = "\"" + WindowsSetup.Variabile.locatie + "\" > Packages\\fix.txt";
            string installing = dism + install;
            CMD_Process_Class.Process_CMD(installing);
            while (!File.Exists("Packages\\fix.txt"))
                Thread.Sleep(2000);
            string[] lines = File.ReadAllLines("Packages\\fix.txt");
            var lineCount = File.ReadAllLines("Packages\\fix.txt").Length;

            int i = 7, j = 1;
            for (i = 7; i < lineCount; i += 5)
            {
                string ep = lines[i];
                string[] lines3 = ep.Split(':');
                string gamma = lines[i + 2];
                string lines2 = "Index " + j.ToString() + ":" + lines3[1] + " ";
                string[] lines1 = new String[] { lines2 };
                string[] gamma_space = gamma.Split(':');
                string comp = gamma_space[1];
                lines2 += comp;
                string[] comp_sp = comp.Split(',');
                int space_nu = Int32.Parse(comp_sp[0]);
                WindowsSetup.Variabile.space_gb_ver = space_nu;
                checkedListBox1.Items.AddRange(lines1);
                if (i > lineCount)
                {
                    break;
                }
                j++;
            }
        }
    }
}
