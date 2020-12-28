using System;
using MetroFramework.Forms;
using System.IO;

namespace IntegrateOS
{
    public partial class license : MetroForm
    {
        string which;
        public license(System.Drawing.Point pct, string name, string filename)
        {
            InitializeComponent();
            this.Text = filename;
            Location = pct;
            which = name;
        }
        string[] s;
        private void License_Load(object sender, EventArgs e)
        {
            this.StyleManager = Themes.Generate(IntegrateOS_var.color, IntegrateOS_var.theme);
            switch (which)
            {
                case "metro": s = File.ReadAllLines("Licenses\\metroframework.txt");  break;
                case "microsoft": s = File.ReadAllLines("Licenses\\microsoftadk.txt"); break;
                case "linux": s = File.ReadAllLines("Licenses\\linux.txt"); break;
                case "ios": s = File.ReadAllLines("Licenses\\IntegrateOS.txt"); break;
                case "disc": s = File.ReadAllLines("Licenses\\discutils.txt"); break;
            }
            richTextBox1.Lines = s;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Licenses(this.Location));
        }
    }
}
