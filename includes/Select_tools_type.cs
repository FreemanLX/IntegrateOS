using System;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class Select_tools_type : MetroFramework.Forms.MetroForm
    {

        int os_t;
        public Select_tools_type(System.Drawing.Point point, int os = 0)
        {
            Location = point;
            os_t = os;
            InitializeComponent();
            this.Text = os == 1 ? "Select the type of tools for Linux Operating System" : "Select the type of tools for Windows Operating System";
        }

        private void Select_tools_type_Load(object sender, EventArgs e)
        {
            Advanced.StyleManager = Basic.StyleManager = StyleManager = Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            this.Back.BackgroundImage = IntegrateOS_var.theme == MetroFramework.MetroThemeStyle.Light ? Resources.white_left_arrow : Resources.black_left_arrow;
            this.Back.BackgroundImageLayout = ImageLayout.Center;
            this.Back.Refresh();
        }

        private void Advanced_Click(object sender, EventArgs e)
        {
            if (os_t == 0)
               Moving.Form(this, new Advanced_tools(Location, os_t));
        }

        private void Basic_Click(object sender, EventArgs e)
        {
            if(os_t == 0)
              Moving.Form(this, new Basic_tools(Location, os_t));
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Selection_os(Location, 1));
        }
    }
}
