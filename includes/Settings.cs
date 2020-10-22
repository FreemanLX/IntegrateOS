using System;
using MetroFramework;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class Settings : MetroFramework.Forms.MetroForm
    {
        public Settings()
        {
            InitializeComponent();
            ///metroStyleManager1 = Themes.generate(user_settings.color1, user_settings.theme);
            if (user_settings.dark == 0)
            {
                temp = false;
            }
            else temp = true;
           
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.StyleManager = metroStyleManager1;
            foreach (string s in comboBox3.Items)
            {
                metroComboBox1.Items.Add(s);
            }
            
            if (temp == false)
            {
                metroRadioButton2.Checked = true;
                metroRadioButton1.Checked = false;
            }
            else
            {
                metroRadioButton2.Checked = false;
                metroRadioButton1.Checked = true;
            }
            comboBox3.Text = user_settings.color;
        }

        private void metroLabel7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        Menu x;
        bool temp;
        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            temp = true;
            metroStyleManager1.Theme = MetroThemeStyle.Dark;
            comboBox3.ForeColor = System.Drawing.Color.White;
            comboBox3.BackColor = System.Drawing.Color.Black;
            user_settings.theme = metroStyleManager1.Theme;
            user_settings.dark = 1;
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.ForeColor = System.Drawing.Color.Black;
            comboBox3.BackColor = System.Drawing.Color.White;
            temp = false;
            metroStyleManager1.Theme = MetroThemeStyle.Light;
            user_settings.theme = metroStyleManager1.Theme;
            user_settings.dark = 0;
        }

        private void metroLabel6_Click(object sender, EventArgs e)
        {
            var x = new license("ios", metroLabel6.Text);
            x.Show();
            this.Hide();
        }

        private void metroLabel8_Click(object sender, EventArgs e)
        {
            var x = new license("metro", metroLabel8.Text);
            x.Show();
            this.Hide();
        }

        private void metroLabel9_Click(object sender, EventArgs e)
        {
            var x = new license("disc", metroLabel9.Text);
            x.Show();
            this.Hide();
        }

        private void metroLabel10_Click(object sender, EventArgs e)
        {
            var x = new license("microsoft", metroLabel10.Text);
            x.Show();
            this.Hide();
        }

        private void metroLabel11_Click(object sender, EventArgs e)
        {
            var x = new license("linux", metroLabel11.Text);
            x.Show();
            this.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            x = new Menu(WindowsSetup.Variabile.version);
            x.Show();
            this.Hide();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            user_settings.color = this.comboBox3.GetItemText(this.metroComboBox1.SelectedItem);
            if (user_settings.color == "Blue")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Blue;
            }
            if (user_settings.color == "Green")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Green;
            }
            if (user_settings.color == "Lime")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime;
            }
            if (user_settings.color == "Teal")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Teal;
            }
            if (user_settings.color == "Orange")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Orange;
            }
            if (user_settings.color == "Brown")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Brown;
            }
            if (user_settings.color == "Pink")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Pink;
            }
            if (user_settings.color == "Magenta")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Magenta;
            }
            if (user_settings.color == "Purple")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Purple;
            }
            if (user_settings.color == "Red")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
            }
            if (user_settings.color == "Yellow")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Yellow;
            }

            user_settings.color1 = metroStyleManager1.Style;
        }
    }
}
