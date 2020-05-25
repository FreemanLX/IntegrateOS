using System;
using System.IO;
using System.Windows.Forms;
using DiscUtils;
using System.Diagnostics;
using DiscUtils.Udf;


namespace WindowsSetup
{

    

    public partial class Form7 : MetroFramework.Forms.MetroForm
    {
        public Form7()
        {
            InitializeComponent();
        }

        void ExtractISO(string ISOName, string ExtractionPath)
        {
            using (FileStream ISOStream = File.Open(ISOName, FileMode.Open))
            {
                UdfReader Reader = new UdfReader(ISOStream);
                ExtractDirectory(Reader.Root, ExtractionPath + "\\", "");
                Reader.Dispose();
            }
        }
        void ExtractDirectory(DiscDirectoryInfo Dinfo, string RootPath, string PathinISO)
        {
            if (!string.IsNullOrWhiteSpace(PathinISO))
            {
                PathinISO += "\\" + Dinfo.Name;
            }
            RootPath += "\\" + Dinfo.Name;
            AppendDirectory(RootPath);
            foreach (DiscDirectoryInfo dinfo in Dinfo.GetDirectories())
            {
                ExtractDirectory(dinfo, RootPath, PathinISO);
            }
            foreach (DiscFileInfo finfo in Dinfo.GetFiles())
            {
                
                using (Stream FileStr = finfo.OpenRead())
                {
                    using (FileStream Fs = File.Create(RootPath + "\\" + finfo.Name)) // Here you can Set the BufferSize Also e.g. File.Create(RootPath + "\\" + finfo.Name, 4 * 1024)
                    {
                        metroProgressBar1.Increment(1);
                        metroLabel2.Text = metroProgressBar1.Value.ToString() + " %";
                        metroLabel2.Refresh();
                        metroTextBox1.Text = finfo.Name.ToString();
                        metroTextBox1.Refresh();
                        FileStr.CopyTo(Fs, 8 * 1024); // Buffer Size is 4 * 1024 but you can modify it in your code as per your need
                    }
                }
            }
        }
        static void AppendDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (DirectoryNotFoundException)
            {
                AppendDirectory(Path.GetDirectoryName(path));
            }
            catch (PathTooLongException)
            {
                AppendDirectory(Path.GetDirectoryName(path));
            }
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

        private void Form7_Load(object sender, EventArgs e)
        {

        }
        string esd, wim;
        private void timer1_Tick(object sender, EventArgs e)
        {
            metroProgressBar1.Minimum = 0;
            metroProgressBar1.Maximum = 100;
            metroProgressBar1.Enabled = true;
            timer1.Enabled = true;
            if (!Directory.Exists("Windows_TEMP"))
                Directory.CreateDirectory("Windows_TEMP");
            else
            {
                Directory.Delete("Windows_TEMP", true);
                Directory.CreateDirectory("Windows_TEMP");
            }

            string extractTo = "Windows_TEMP\\";
            if (metroProgressBar1.Value == 0)
            {
                string s = WindowsSetup.Variabile.locatie;
                ExtractISO(s, extractTo);
                metroProgressBar1.Value = 100;
                metroLabel2.Text = metroProgressBar1.Value.ToString() + " %";
                metroLabel2.Refresh();
                timer1.Stop();
                

                string te = Form6.alg;
                cmd("rename " + WindowsSetup.Variabile.locatie + " " + te);

                 esd = "Windows_TEMP\\sources\\install.esd";
                 wim = "Windows_TEMP\\sources\\install.wim";
               
            }
            if (metroProgressBar1.Value == 100) { 

                if (!File.Exists(esd))
                {
                    if (!File.Exists(wim))
                    {
                        MessageBox.Show("It isn't an official Windows iso!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        var form = new Form6();
                        timer1.Enabled = false;
                        timer1.Stop();
                        this.Hide();
                        form.Show();
                    }
                    else
                    {

                        WindowsSetup.Variabile.locatie = wim;
                        WindowsSetup.Variabile.var = "wim";
                        
                        var y = new WindowsFormsApplication2.Form12();
                        this.Hide();
                        y.Show();
                    }
                }
                else
                {

                    WindowsSetup.Variabile.locatie = esd;
                    WindowsSetup.Variabile.var = "esd";
                    var y = new WindowsFormsApplication2.Form12();
                    this.Hide();
                    y.Show();
                }
                
            }
        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
