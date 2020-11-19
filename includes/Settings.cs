using System;
using MetroFramework;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class Settings : MetroFramework.Forms.MetroForm
    {
        public Settings(System.Drawing.Point punct)
        {
            InitializeComponent();
            this.Location = punct;
            ///metroStyleManager1 = Themes.generate(user_settings.color1, user_settings.theme);
            if (IntegrateOS_var.dark == 0)
            {
                temp = false;
            }
            else temp = true;
           
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                var dialog = MetroFramework.MetroMessageBox.Show(this, "Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, IntegrateOS.IntegrateOS_var.color_t);
                if (dialog == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                if(dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            catch { }
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
            metroComboBox1.Text = IntegrateOS_var.color;
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
            IntegrateOS_var.theme = metroStyleManager1.Theme;
            IntegrateOS_var.dark = 1;
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.ForeColor = System.Drawing.Color.Black;
            comboBox3.BackColor = System.Drawing.Color.White;
            temp = false;
            metroStyleManager1.Theme = MetroThemeStyle.Light;
            IntegrateOS_var.theme = metroStyleManager1.Theme;
            IntegrateOS_var.dark = 0;
        }

        private void metroLabel6_Click(object sender, EventArgs e)
        {
            var x = new license(Location, "ios", metroLabel6.Text);
            x.Show();
            this.Hide();
        }

        private void metroLabel8_Click(object sender, EventArgs e)
        {
            var x = new license(Location, "metro", metroLabel8.Text);
            x.Show();
            this.Hide();
        }

        private void metroLabel9_Click(object sender, EventArgs e)
        {
            var x = new license(Location, "disc", metroLabel9.Text);
            x.Show();
            this.Hide();
        }

        private void metroLabel10_Click(object sender, EventArgs e)
        {
            var x = new license(Location, "microsoft", metroLabel10.Text);
            x.Show();
            this.Hide();
        }

        private void metroLabel11_Click(object sender, EventArgs e)
        {
            var x = new license(Location, "linux", metroLabel11.Text);
            x.Show();
            this.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            string[] complete = new string[2];
            complete[0] = IntegrateOS_var.dark.ToString();
            complete[1] = IntegrateOS_var.color_t.ToString();
                if (System.IO.File.Exists("Settings\\user.dat"))
                {
                    System.IO.File.WriteAllLines("Settings\\user.dat", complete);
                }
                else
                {
                    if (!System.IO.Directory.Exists("Settings"))
                    {
                        System.IO.Directory.CreateDirectory("Settings");
                    }
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText("Settings\\user.dat"))
                    {
                        sw.WriteLine(complete[0]);
                        sw.WriteLine(complete[1]);
                    }
                }
            
         
            x = new Menu(WindowsSetup.Variabile.version, this.Location);
            x.Show();
            this.Hide();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IntegrateOS_var.color = this.comboBox3.GetItemText(this.metroComboBox1.SelectedItem);
            if (IntegrateOS_var.color == "Blue")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Blue;
            }
            if (IntegrateOS_var.color == "Green")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Green;
            }
            if (IntegrateOS_var.color == "Lime")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime;
            }
            if (IntegrateOS_var.color == "Teal")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Teal;
            }
            if (IntegrateOS_var.color == "Orange")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Orange;
            }
            if (IntegrateOS_var.color == "Brown")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Brown;
            }
            if (IntegrateOS_var.color == "Pink")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Pink;
            }
            if (IntegrateOS_var.color == "Magenta")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Magenta;
            }
            if (IntegrateOS_var.color == "Purple")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Purple;
            }
            if (IntegrateOS_var.color == "Red")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
            }
            if (IntegrateOS_var.color == "Yellow")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Yellow;
            }
            IntegrateOS_var.color_t = metroComboBox1.SelectedIndex + 1;
            IntegrateOS_var.color1 = metroStyleManager1.Style;
        }
    }
}
