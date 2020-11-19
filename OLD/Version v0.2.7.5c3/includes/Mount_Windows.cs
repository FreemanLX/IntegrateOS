using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace IntegrateOS
{
    public partial class Mount_Windows : MetroFramework.Forms.MetroForm
    {
        int index1;
        public Mount_Windows()
        {
            InitializeComponent();
        }
        public Mount_Windows(int index)
        {
            InitializeComponent();
            if (tools_location.type == "WIM")
            {
                this.Text = "Mount WIM";
            }
            else
            {
                this.Text = "Mount ESD";
            }
            index1 = index;

        }

        private void Mount_Windows_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.IntegrateOS_var.color1, IntegrateOS.IntegrateOS_var.theme);
            metroTextBox2.Text = tools_location.location1;
            metroLabel1.Theme = IntegrateOS.IntegrateOS_var.theme;
            metroLabel2.Theme = IntegrateOS.IntegrateOS_var.theme;
            metroTextBox1.Theme = IntegrateOS.IntegrateOS_var.theme;
            metroTextBox2.Theme = IntegrateOS.IntegrateOS_var.theme;
        }
        bool mounted = false;

        private void metroButton2_Click(object sender, EventArgs e)
        {
            
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tools_location.location2 = fbd.SelectedPath;
                    metroTextBox1.Text = fbd.SelectedPath;
                }
                fbd.Dispose();
            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private const string DllFilePath = @"IntegrateOS Base.dll";
        [DllImport(DllFilePath, SetLastError = true, EntryPoint = "mount_windows", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern int mount_windows(string loc1, string loc2, int index);


        [DllImport(DllFilePath, SetLastError = true, EntryPoint = "unmount_image", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern int unmount_image(string loc2, int commint_change);

        private bool unmount(string loc2, int commit_image)
        {
            try
            {
                int e = unmount_image(loc2, commit_image);
                if (e == -1)
                    return false;
                if (e == 2)
                {
                    MessageBox.Show("Unable to unmount error: 0x1");
                    return false;
                }
                return true;
            }
            catch
            {

                int rc = Marshal.GetLastWin32Error();
                MessageBox.Show("Unable to unmount error: " + rc.ToString());
                return false;
            }
        }

        private bool mount(string loc1, string loc2, int index)
        {
            MessageBox.Show(index.ToString());
            int e = mount_windows(loc1, loc2, index);

            try
            {
                if (e == 1)
                {
                    MessageBox.Show("Unable to mount error: 0x1");
                    return false;
                }
                return true;
            }
            catch
            {
                int rc = Marshal.GetLastWin32Error();
                MessageBox.Show("Unable to mount error: " + rc.ToString());
                return false;
            }

        }
        int pass;

        private void metroButton4_Click(object sender, EventArgs e)
        {
            pass = 0;
            if (mounted == false && pass == 0)
            {
                this.Text = "Mounting...";
                bool s = mount(tools_location.location1, tools_location.location2, index1);
                if (s == false)
                {

                }
                else
                {
                    metroButton4.Enabled = false;
                    this.Text = "Windows is mounted";
                    metroButton4.Enabled = true;
                    metroButton4.Text = "Dismount";
                    metroButton4.Refresh();
                    mounted = true;
                    pass = 1;
                }
            }
            if (mounted == true && pass == 0)
            {
                this.Text = "Unmounting...";
                bool t = unmount(tools_location.location2, 0);
                if (t == false)
                {


                }
                else
                {
                    metroButton4.Enabled = false;
                    this.Text = "Windows is dismounted";
                    metroButton4.Enabled = true;
                    metroButton4.Text = "Mount";
                    metroButton4.Refresh();
                    mounted = true;
                    pass = 1;
                }
            }
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var x = new WindowsFormsApplication2.Form5(1);
            x.Show();
            this.Hide();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var x = new tools();
            this.Hide();
            x.Show();
        }
    }
}
