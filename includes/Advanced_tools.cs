using System;
using System.Windows.Forms;
using MetroFramework;

namespace IntegrateOS
{
    public partial class Advanced_tools : MetroFramework.Forms.MetroForm
    {
        int os = 0;
        public Advanced_tools(System.Drawing.Point point, int os_t = 0)
        {
            Location = point;
            InitializeComponent();
            switch (os_t)
            {
                case 0:
                    this.Text = "Advanced tools - Windows";
                    break;
                case 1:
                    this.Text = "Advanced tools - Linux";
                    break;
                case 2:
                    this.Text = "Advanced tools - Android";
                    break;
                case 3:
                    this.Text = "Advanced tools - Windows Phone";
                    break;
                default:
                    break;
            }
            os = os_t;
        }

        private void Advanced_tools_Load(object sender, EventArgs e)
        {
            if (IntegrateOS_var.program_mode == 2) Edit_Windows.Visible = false;
            Waudit.StyleManager = WindowsPE.StyleManager = Sysprep.StyleManager = Compress.StyleManager = StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            metroButton2.BackgroundImage = IntegrateOS_var.theme == MetroThemeStyle.Light ? Resources.white_left_arrow : Resources.black_left_arrow;
            metroButton2.BackgroundImageLayout = ImageLayout.Center;
            metroButton2.Refresh();
            Edit_Windows.Style = IntegrateOS.IntegrateOS_var.color;
        }

        private void Edit_Windows_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Not_Ready(Location));
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Select_tools_type(Location, os));
        }

        private void Waudit_Click(object sender, EventArgs e)
        {
            DialogResult waudit_go = MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to boot to audit?\nBy booting to audit, you have risk of loosing your data!", "Booting to the Audit mode", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, IntegrateOS.IntegrateOS_var.color_t);
            if (waudit_go == DialogResult.Yes)
            {
                CMD_Process_Class x = new CMD_Process_Class();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.System);

                string final = "start " + path + "\\sysprep\\sysprep.exe /audit /reboot";
                x.Process_CMD(final);
            }
        }

        private void Sysprep_Click(object sender, EventArgs e)
        {
            DialogResult waudit_go = MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to unistall driveres?\nYou have a very high risk of loosing your data!", "Booting to the Audit mode", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, IntegrateOS.IntegrateOS_var.color_t);
            if (waudit_go == DialogResult.Yes)
            {
                CMD_Process_Class x = new CMD_Process_Class();
                string path = Environment.GetFolderPath(Environment.SpecialFolder.System);

                string final = "start " + path + "\\sysprep\\sysprep.exe /generalize /shutdown";
                x.Process_CMD(final);
            }
        }

        private void Windows_PE_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Not_Ready(Location));

        }

        private void Compress_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Not_Ready(Location)); ///Code 5
        }
    }
}
