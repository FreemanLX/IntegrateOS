using System;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class Form19 : MetroFramework.Forms.MetroForm
    {
        public Form19()
        {
            InitializeComponent();
        }

        
        private void Form19_Load(object sender, EventArgs e)
        {

        }
        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        private void metroButton1_Click(object sender, EventArgs e)
        {
           
            g.Clear();
            Environment.Exit(1);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string s = "shutdowns -r -t 0";
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
            cmd.WaitForExit();
        }
    }
}
