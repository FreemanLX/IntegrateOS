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
            
            string install = "Get-WindowsImage -Imagepath \"" + WindowsSetup.Variabile.locatie + "\" | Select-Object ImageName > Packages\\fix.txt ";
            CMD_Process_Class.Process_Powershell(install);
            string[] lines = File.ReadAllLines("Packages\\fix.txt");
            var lineCount = File.ReadAllLines("Packages\\fix.txt").Length;
            for(int i = 3; i<lineCount; i++)
            {
                if(lines[i].Length > 1) checkedListBox1.Items.Add(lines[i]);
            }
      
            
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {

            WindowsSetup.Variabile.fix = (checkedListBox1.SelectedIndex + 1).ToString();
            MessageBox.Show(WindowsSetup.Variabile.fix);
            var form = new Form11();
            this.Hide();
            form.Show();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            string install = "Get-WindowsImage -Imagepath \"" + WindowsSetup.Variabile.locatie + "\" | Select-Object ImageName > Packages\\fix.txt ";
            CMD_Process_Class.Process_Powershell(install);
            string[] lines = File.ReadAllLines("Packages\\fix.txt");
            var lineCount = File.ReadAllLines("Packages\\fix.txt").Length;
            for (int i = 3; i < lineCount; i++)
            {
                if (lines[i].Length > 1) checkedListBox1.Items.Add(lines[i]);
            }

        }
    }
}
