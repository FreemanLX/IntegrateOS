using System;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class Selection_os : MetroFramework.Forms.MetroForm
    {
        int tools_t = 0;
        public Selection_os(System.Drawing.Point punct, int tools = 0)
        {
            this.Location = punct;
            InitializeComponent();
            if(tools == 1) Text = "Select OS for tools";
            tools_t = tools;
        }


        private void Selection_os_Load(object sender, EventArgs e)
        {
            if(IntegrateOS_var.program_mode == 1 || IntegrateOS_var.program_mode == 2)
            {
                Windows_Phone.Visible = Android.Visible = false;
                Linux.Location = new System.Drawing.Point(243, 150);
            }
            else
            {
                Windows_Phone.Visible = Android.Visible = true;
                Linux.Location = new System.Drawing.Point(443, 150);
            }
            this.StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            Back.BackgroundImage = IntegrateOS_var.theme == MetroFramework.MetroThemeStyle.Light ? Resources.white_left_arrow : Resources.black_left_arrow;
            Back.BackgroundImageLayout = ImageLayout.Center;
            Back.Refresh();
            Windows.Style = Linux.Style = Android.Style = Windows_Phone.Style = IntegrateOS.IntegrateOS_var.color;
        }


        private void Windows_Installaton_Click(object sender, EventArgs e)
        {
            if(tools_t == 0)
            Moving.Form(this, new IntegrateOS.Select_installation(Location));
            else
            {
                Moving.Form(this, new IntegrateOS.Select_tools_type(Location));
            }
        }

        private void Linux_Installation_Click(object sender, EventArgs e)
        {
            if(tools_t == 0)
                Moving.Form(this, new IntegrateOS.Select_installation(Location, 4));
            else
                Moving.Form(this, new IntegrateOS.Select_tools_type(Location, 1));
            
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Menu(IntegrateOS.Temporary_I.version, this.Location));
        }
    }
}
