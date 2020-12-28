using System;
using System.Windows.Forms;

namespace IntegrateOS
{

    public partial class Mount_Windows : MetroFramework.Forms.MetroForm
    {
        int index1;
        public Mount_Windows(System.Drawing.Point punct, int index)
        {
            InitializeComponent();
            Location = punct;
            this.Text = "Mount program. Status: Alpha";
            index1 = index;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
        }

        private void Mount_Windows_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            metroTextBox2.Text = Tools_location.Mount.path_to_mount;
            metroLabel1.Theme = metroLabel2.Theme = metroTextBox1.Theme = metroTextBox2.Theme = IntegrateOS.IntegrateOS_var.theme;
        }
        bool mounted = false;

        private void Browse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Tools_location.Mount.path_to_be_mounted = fbd.SelectedPath;
                    metroTextBox1.Text = fbd.SelectedPath;
                }
                fbd.Dispose();
            }
        }

        int pass;
        private async void Mount_Click(object sender, EventArgs e)
        {
            pass = 0;
            if (mounted == false && pass == 0)
            {
                this.Text = "Preparing to mount. Please Wait";
                metroButton1.Visible = metroButton4.Visible = false;
                bool s = await IntegrateOS.DISMAPI.DismMountImage(Tools_location.Mount.path_to_mount, Tools_location.Mount.path_to_be_mounted, (uint)index1, true);
                if (s == false)
                {
                    var dialog = MetroFramework.MetroMessageBox.Show(this, "Error mounting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, IntegrateOS.IntegrateOS_var.color_t);
                    metroButton1.Visible = metroButton4.Visible = true;
                }
                else
                {
                    this.Text = "Mounted!";
                    metroButton4.Visible = true;
                    metroButton4.Text = "Unmount";
                    metroButton4.Refresh();
                    mounted = true;
                    pass = 1;
                }
            
        }
            if (mounted == true && pass == 0)
            {
                this.Text = "Unmounting..." + "  Status: Alpha";
                bool t = await IntegrateOS.DISMAPI.DismUnmountImage(Tools_location.Mount.path_to_be_mounted, false);
                if (t == false)
                {
                    var dialog = MetroFramework.MetroMessageBox.Show(this, "Error unmounting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, IntegrateOS.IntegrateOS_var.color_t);
                }
                else
                {
                    metroButton4.Visible = false;
                    System.Threading.Thread.Sleep(500);
                    this.Text = "Unmounted. Status: Alpha";
                    metroButton4.Enabled = true;
                    metroButton4.Text = "Mount";
                    metroButton4.Refresh();
                    metroButton4.Visible = true;
                    metroButton1.Visible = true;
                    mounted = true;
                    pass = 1;
                }
}
        }

        private void Select_installation_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new IntegrateOS.Select_installation(Location, 1));
        }

        private void Tools_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Basic_tools(this.Location));
        }

    }
}
