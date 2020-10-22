using System;

namespace IntegrateOS
{
    public partial class Bcdedit_name : MetroFramework.Forms.MetroForm
    {
        public Bcdedit_name()
        {
            InitializeComponent();
        }

        private void Bcdedit_name_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.user_settings.color1, IntegrateOS.user_settings.theme);
        }

        string full;

        public string get()
        {
            return full;
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
            {
                full = "Windows";
            }
            else
            {
                full = textBox1.Text;
            }
            this.Close();
        }
    }
}
