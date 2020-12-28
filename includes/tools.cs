using System;
using System.Windows.Forms;
using MetroFramework;

namespace IntegrateOS
{
    public partial class Basic_tools : MetroFramework.Forms.MetroForm
    {
        int os_t;
        public Basic_tools(System.Drawing.Point punct, int os = 0)
        {
            this.Location = punct;
            InitializeComponent();
            switch (os)
            {
                case 0:
                    this.Text = "Basic tools - Windows";
                    break;
                case 1:
                    this.Text = "Basic tools - Linux";
                    break;
                case 2:
                    this.Text = "Basic tools - Android";
                    break;
                case 3:
                    this.Text = "Basic tools - Windows Phone";
                    break;
                default:
                    break;
            }
            os_t = os;
        }

        public void Wcommandmode_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Command_Prompt(Location));
        }

        private void Tools_Load(object sender, EventArgs e)
        {
            Wcommandmode.StyleManager = Wadvmode.StyleManager = StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            metroButton2.BackgroundImage = IntegrateOS_var.theme == MetroThemeStyle.Light ? Resources.white_left_arrow : Resources.black_left_arrow;
            metroButton2.BackgroundImageLayout = ImageLayout.Center;
            metroButton2.Refresh();
            Convert_Windows_Installation.Style = Mount_Windows.Style = IntegrateOS_var.color;
        }


        private void Convert_Windows_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new IntegrateOS.Select_installation(Location, 2));
        }

        private void Mount_Windows_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new IntegrateOS.Select_installation(Location, 1));
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Select_tools_type(Location, os_t));
        }

        private void Wadvmode_Click_1(object sender, EventArgs e)
        {
            DialogResult waudit_go = MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to see the Advanced options of Windows ?", "Booting to the Advanced options of Windows", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, IntegrateOS.IntegrateOS_var.color_t);
            if (waudit_go == DialogResult.Yes)
            {
                CMD_Process_Class.Process_CMD("shutdown.exe -r -o -t 0", "cmd.exe");
            }
        }

    }
}
