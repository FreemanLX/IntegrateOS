using System;
using System.IO;
using System.Windows.Forms;
using DiscUtils;
using DiscUtils.Udf;
using System.Collections.Generic;
using System.Linq;

namespace IntegrateOS
{

    public partial class Extract_iso : MetroFramework.Forms.MetroForm
    {
        public Extract_iso(System.Drawing.Point punct)
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
                        Progress_Bar.Increment(1 / test.Length);
                        Progress_Number.Text = Progress_Bar.Value.ToString() + " %";
                        Progress_Number.Refresh();
                        FileStr.CopyTo(Fs, 8 * 1024); 
                    }
                }
            }
        }
        static void AppendDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
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


        private void ExtractISO_Load(object sender, EventArgs e)
        {
            StyleManager = Themes.Generate(IntegrateOS_var.color, IntegrateOS_var.theme);
            Progress_Message.Theme = Progress_Number.Theme = Waiting_message_label.Theme = Progress_Bar.Theme = IntegrateOS_var.theme;
            Progress_Bar.Style = IntegrateOS_var.color;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Progress_Bar.Minimum = 0;
            Progress_Bar.Maximum = 100;
            Progress_Bar.Enabled = true;
            Progress_Timer.Enabled = true;
            string extractTo = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(extractTo);
            if (Progress_Bar.Value == 0)
            {
                string s = IntegrateOS.Temporary_I.locatie;
                ExtractISO(s, extractTo);
                Progress_Bar.Value = 100;
                Progress_Number.Text = Progress_Bar.Value.ToString() + " %";
                Progress_Number.Refresh();
                Progress_Timer.Stop();       
            }
            if (Progress_Bar.Value == 100) {

                var extensions = new List<string> { ".swm", ".wim", ".esd" };
                string[] files = Directory.GetFiles(extractTo, "*.*", SearchOption.AllDirectories)
                    .Where(f => extensions.IndexOf(Path.GetExtension(f)) >= 0).ToArray();
                if (files.Length == 0)
                {
                    MessageBox.Show("It isn't an official Windows iso!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Progress_Timer.Enabled = false;
                    Progress_Timer.Stop();
                    Moving.Form(this, new Select_installation(Location));
                }
                else
                {
                    Moving.Form(this, new Select_Image_File(files, Location));
                }
                
            }
        }
    }
}
