using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;

namespace IntegrateOS
{
    public partial class license : MetroForm
    {
        string which;
        public license(string name, string filename)
        {
            InitializeComponent();
            this.Text = filename;
            which = name;
        }
        string[] s;
        private void license_Load(object sender, EventArgs e)
        {
            this.StyleManager = Themes.generate(IntegrateOS_var.color1, IntegrateOS_var.theme);
            if (which == "metro")
            {
                s = File.ReadAllLines("Licenses\\metroframework.txt");
            }
            if(which == "microsoft")
            {
                s = File.ReadAllLines("Licenses\\microsoftadk.txt");
            }
            if (which == "linux")
            {
                s = File.ReadAllLines("Licenses\\linux.txt");
            }
            if (which == "ios")
            {
                s = File.ReadAllLines("Licenses\\IntegrateOS.txt");
            }
            if (which == "disc")
            {
                s = File.ReadAllLines("Licenses\\discutils.txt");
            }


            richTextBox1.Lines = s;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var x = new Settings();
            x.Show();
            this.Hide();
        }
    }
}
