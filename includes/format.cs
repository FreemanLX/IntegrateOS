using System;
using System.Threading;
using System.Management;


namespace IntegrateOS
{
    public partial class Format : MetroFramework.Forms.MetroForm
    {
        public Select_Partition test;
        public static bool FormatDrive(string driveLetter="", string label = "", string fileSystem = "NTFS", bool quickFormat = true, int clusterSize = 8192, bool enableCompression = false)
        {
            if (driveLetter.Length != 2 || driveLetter[1] != ':' || !char.IsLetter(driveLetter[0])) return false;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"select * from Win32_Volume WHERE DriveLetter = '" + driveLetter + "'");
            foreach (ManagementObject vi in searcher.Get())
            {
                vi.InvokeMethod("Format", new object[]{ fileSystem, quickFormat, clusterSize, label, enableCompression });
            }

            return true;

        }
        int format_type_cluster;
        string format_type_fileSystem, partition_name_type, format_t;
        bool format_type_quickformat;

        System.Drawing.Point punct;
        public Format(System.Drawing.Point locatie, string s, string partition_name, int clusterSize, string fileSystem, bool quickFormat)
        {
            InitializeComponent();
            format_type_cluster = clusterSize;
            format_type_fileSystem = fileSystem;
            format_type_quickformat = quickFormat;
            partition_name_type = partition_name;
            format_t = s;
            punct = locatie;
        }

        Thread temp;
        private void Format_Load(object sender, EventArgs e)
        { 
            this.StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            Message_Label.Theme = IntegrateOS.IntegrateOS_var.theme;
            temp = new Thread(() =>
                        {
                            if (FormatDrive(format_t, partition_name_type, format_type_fileSystem, format_type_quickformat, format_type_cluster) == true)
                            {
                                Invoke(new Action(() =>
                                {
                                    temp.Abort();
                                    Moving.Form(this, new Windows_Installation(punct));
                                }));
                            }
                            else Invoke(new Action(() => {temp.Abort();}));
                        })
            {IsBackground = true};
            temp.Start();
        }

    }
}
