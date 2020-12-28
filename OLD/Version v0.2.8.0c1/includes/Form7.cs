using System;
using System.IO;
using System.Windows.Forms;
using DiscUtils;
using DiscUtils.Udf;
using System.Collections.Generic;
using System.Linq;

namespace WindowsSetup
{

    

    public partial class Form7 : MetroFramework.Forms.MetroForm
    {
        public Form7(System.Drawing.Point punct)
        {
            InitializeComponent();
            Location = punct;
        }

        private void ExtractISO(string ISOName, string ExtractionPath)
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
            var test = Dinfo.GetFiles();
            foreach (DiscFileInfo finfo in test)
            {
                
                using (Stream FileStr = finfo.OpenRead())
                {
                    using (FileStream Fs = File.Create(RootPath + "\\" + finfo.Name)) 
                    {
                        metroProgressBar1.Increment(1 / test.Length);
                        metroLabel2.Text = metroProgressBar1.Value.ToString() + " %";
                        metroLabel2.Refresh();
                        FileStr.CopyTo(Fs, 8 * 1024); 
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                var dialog = MetroFramework.MetroMessageBox.Show(this, "Do you want to abort extracting ISO?", "Abort", MessageBoxButtons.YesNo, MessageBoxIcon.Question, IntegrateOS.IntegrateOS_var.color_t);
                if (dialog == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            catch { }
        }



        private void Form7_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.IntegrateOS_var.color1, IntegrateOS.IntegrateOS_var.theme);
            this.Location = IntegrateOS.Generate_location.data_l;
            metroLabel1.Theme = IntegrateOS.IntegrateOS_var.theme;
                metroLabel2.Theme = IntegrateOS.IntegrateOS_var.theme;
                metroLabel4.Theme = IntegrateOS.IntegrateOS_var.theme;
                metroProgressBar1.Theme = IntegrateOS.IntegrateOS_var.theme;
            metroProgressBar1.Style = IntegrateOS.IntegrateOS_var.color1;
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void Form7_LocationChanged(object sender, EventArgs e)
        {
            IntegrateOS.Generate_location.data_l = this.Location;
        }

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
       

                  
               
            }
            if (metroProgressBar1.Value == 100) {

                var extensions = new List<string> { ".swm", ".wim", ".esd" };
                string[] files = Directory.GetFiles(extractTo, "*.*", SearchOption.AllDirectories)
                    .Where(f => extensions.IndexOf(Path.GetExtension(f)) >= 0).ToArray();
                if (files.Length == 0)
                {
                    MessageBox.Show("It isn't an official Windows iso!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var form = new WindowsFormsApplication2.Form5(Location);
                    timer1.Enabled = false;
                    timer1.Stop();
                    this.Hide();
                    form.Show();

                }
                else
                {
                    var x = new IntegrateOS.Select_Image_File(files, Location);
                    x.Show();
                    this.Hide();
                }
                
            }
        }
    }
}
