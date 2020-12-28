using System;

namespace IntegrateOS
{
    public partial class Advanced_Settings : MetroFramework.Forms.MetroForm
    {
        public Advanced_Settings(System.Drawing.Point point)
        {
            Location = point;
            InitializeComponent();
        }

        private void Advanced_Settings_Load(object sender, EventArgs e)
        {
            switch (IntegrateOS_var.program_mode)
            {
                case 1: Advanced_radio.Checked = true; break;
                case 2: Basic_radio.Checked = true; break;
                case 3: Beta_radio.Checked = true; break;
            }
            this.StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            metroPanel1.StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            if (IntegrateOS_var.theme == MetroFramework.MetroThemeStyle.Light)
            {
                metroButton2.BackgroundImage = Resources.white_left_arrow;
                Beta_radio.ForeColor = Basic_radio.ForeColor = Advanced_radio.ForeColor = System.Drawing.Color.Black;
                label5.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                metroButton2.BackgroundImage = Resources.black_left_arrow;
                Beta_radio.ForeColor = Basic_radio.ForeColor = Advanced_radio.ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
                label5.ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
            }
            metroButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        }

        private void Beta_CheckedChanged(object sender, EventArgs e) => IntegrateOS_var.program_mode = 3;
        private void Advanced_CheckedChanged(object sender, EventArgs e) => IntegrateOS_var.program_mode = 1;
        private void Basic_CheckedChanged(object sender, EventArgs e) => IntegrateOS_var.program_mode = 2;
        private void Back_Click(object sender, EventArgs e) => Moving.Form(this, new Settings_Menu(Location));
        private void Advanced_Settings_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) => Saving.Data();
    }
}
