using System;
using System.Threading;
using System.Management;
using WindowsFormsApplication2;


namespace IntegrateOS
{
    public partial class format : MetroFramework.Forms.MetroForm
    {
        public WindowsFormsApplication2.Form11 test;
        public static bool FormatDrive(string driveLetter, string label = "", string fileSystem = "NTFS", bool quickFormat = true,
                int clusterSize = 8192, bool enableCompression = false)
        {
            if (driveLetter.Length != 2 || driveLetter[1] != ':' || !char.IsLetter(driveLetter[0]))
                return false;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"select * from Win32_Volume WHERE DriveLetter = '" + driveLetter + "'");
            foreach (ManagementObject vi in searcher.Get())
            {
                vi.InvokeMethod("Format", new object[]
              { fileSystem, quickFormat,clusterSize, label, enableCompression });
            }

            return true;

        }
        public format(string s, Form11 t)
        {
            test = t;
            InitializeComponent();
            metroLabel2.Text = s;
            metroLabel2.Refresh();
        }

        Thread temp;
        public bool maximum;
        public bool Get()
        {
            return maximum;
        }
        private void format_Load(object sender, EventArgs e)
        {
            temp = new Thread(
                        () =>
                        {
                            if (FormatDrive(metroLabel2.Text, "Windows") == true)
                            {
                                Invoke(new Action(() =>
                                {
                                    maximum = true;
                                    var form2 = new Form13();
                                    this.Hide();
                                    form2.Show();
                                    temp.Abort();
                                }));
                            }
                            else
                            {

                                Invoke(new Action(() =>
                                {
                                    temp.Abort();
                                }));
                            }

                        })
            {
                IsBackground = true
            };
            temp.Start();
            if(maximum == true)
            {
                this.Close();
                test.Hide();
            }
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
