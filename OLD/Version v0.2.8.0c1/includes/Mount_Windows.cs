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
        public Mount_Windows(System.Drawing.Point punct, int index)
        {
            InitializeComponent();
            Location = punct;
            this.Text = "Mount " + tools_location.type + " Status: Alpha";
            index1 = index;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
        }

        private void Mount_Windows_Load(object sender, EventArgs e)
        {
            this.Location = IntegrateOS.Generate_location.data_l;
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





        int pass;

        private async void metroButton4_Click(object sender, EventArgs e)
        {
            pass = 0;
            if (mounted == false && pass == 0)
            {
                this.Text = "Preparing to mount. Please Wait";
                metroButton1.Visible = false;
                metroButton4.Visible = false;
                this.Text = "Mount the " + tools_location.type + ". Please Wait";
                bool s = await IntegrateOS.DISMAPI.DismMountImage(tools_location.location1, tools_location.location2, (uint)index1, true);
                if (s == false)
                {
                    var dialog = MetroFramework.MetroMessageBox.Show(this, "Error mounting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, IntegrateOS.IntegrateOS_var.color_t);
                    metroButton1.Visible = true;
                    metroButton4.Visible = true;
                }
                else
                {
                    this.Text = "Mounted the selected " + tools_location.type;
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
                bool t = await IntegrateOS.DISMAPI.DismUnmountImage(tools_location.location2, false);
                if (t == false)
                {
                    var dialog = MetroFramework.MetroMessageBox.Show(this, "Error unmounting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, IntegrateOS.IntegrateOS_var.color_t);
    }
                else
                {
                    metroButton4.Visible = false;
                    System.Threading.Thread.Sleep(500);


                    this.Text = "Unmounted the selected " + tools_location.type + " Status: Alpha";
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

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var x = new WindowsFormsApplication2.Form5(Location, 1);
            x.Show();
            this.Hide();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            var x = new tools(this.Location);
            this.Hide();
            x.Show();
        }

        private void Mount_Windows_LocationChanged(object sender, EventArgs e)
        {
            IntegrateOS.Generate_location.data_l = this.Location;
        }


        protected override async void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                var dialog = MetroFramework.MetroMessageBox.Show(this, "Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, IntegrateOS.IntegrateOS_var.color_t);
                if (dialog == DialogResult.Yes)
                {
                    if(mounted == true)
                    {
                        bool t = await IntegrateOS.DISMAPI.DismUnmountImage(tools_location.location2, false);
                    }
                    Environment.Exit(0);
                }
                if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            catch { }
        }

    }
}
