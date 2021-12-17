using System;
using System.Management;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class Set_partition : MetroFramework.Forms.MetroForm
    {
        public Set_partition(System.Drawing.Point punct, string partition, string type = "NTFS")
        {  
            InitializeComponent();
            Movable = true;
            Location = punct;
            comboBox3.Text = type;
            comboBox1.Text = partition;
          
            comboBox2.Items.Add("Fast");
            comboBox2.Items.Add("Normal");
            comboBox4.Items.Add("4 KB");
            comboBox4.Items.Add("8 KB");
            comboBox4.Items.Add("16 KB");
            comboBox4.Items.Add("32 KB");
            comboBox4.Items.Add("64 KB");
        }


        private void Set_background_foreground<T>(T type, System.Drawing.Color backcolor, System.Drawing.Color forecolor) where T : Control
        {
            type.BackColor = backcolor;
            type.ForeColor = forecolor;
        }

        private void Set_partition_Load(object sender, EventArgs e)
        {
            StyleManager = Themes.Generate;
            foreach (Control control in this.Controls)
            {
                Set_background_foreground(control, Themes.GenerateTheme(Themes.MetroTheme), Themes.GenerateTheme(!Themes.MetroTheme));
            }
        }

        public static bool FormatDrive(string driveLetter = "", string label = "", string fileSystem = "NTFS", bool quickFormat = true, int clusterSize = 8192, bool enableCompression = false)
        {
            if (driveLetter.Length != 2 || driveLetter[1] != ':' || !char.IsLetter(driveLetter[0])) return false;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"select * from Win32_Volume WHERE DriveLetter = '" + driveLetter + "'");
            foreach (ManagementObject vi in searcher.Get())
            {
                vi.InvokeMethod("Format", new object[] { fileSystem, quickFormat, clusterSize, label, enableCompression });
            }

            return true;

        }

        private void Next_Click(object sender, EventArgs e)
        {
            bool quick_format = false;
            if (comboBox2.GetItemText(comboBox2.SelectedItem) == "Fast") quick_format = true;
            int t = 0;
            switch (comboBox4.GetItemText(comboBox4.SelectedItem))
            {
                case "8 KB":  t = 8192; break;
                case "16 KB": t = 16384; break;
                case "32 KB": t = 32768; break;
                case "64 KB": t = 65536; break;
                default: t = 4096; break;
            }
            if (textBox1.Text.Length < 0) textBox1.Text = "Local Disk";
            new LoadingResponse(new System.Threading.Thread(() => FormatDrive(comboBox1.Text, textBox1.Text, comboBox3.Text, quick_format, t)), "Formating the selected partition").ShowDialog();
            Close();
        }
    }
}
