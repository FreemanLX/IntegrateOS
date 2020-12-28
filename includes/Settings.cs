using System;
using MetroFramework;

namespace IntegrateOS
{
    public partial class Settings : MetroFramework.Forms.MetroForm
    {
        public Settings(System.Drawing.Point punct)
        {
            InitializeComponent();
            this.Location = punct;
            temp = IntegrateOS_var.dark == 0 ? false : true;
        }
        bool temp;

        private void Settings_Load(object sender, EventArgs e)
        {
            Back.BackgroundImage = IntegrateOS_var.theme == MetroThemeStyle.Light ? Resources.white_left_arrow : Resources.black_left_arrow;
            Back.Refresh();
            metroComboBox1.Items.AddRange(new object[] {"Blue", "Brown", "Green", "Lime", "Magenta", "Orange", "Pink", "Purple", "Red", "Teal", "Yellow"});

            StyleManager = Form_StyleManager;
            Dark.Checked = temp;
            White.Checked = !temp;
            metroComboBox1.Text = IntegrateOS_var.color_string;
        }

        private void Dark_CheckedChanged(object sender, EventArgs e)
        {
            IntegrateOS_var.theme = Form_StyleManager.Theme = MetroThemeStyle.Dark;
            IntegrateOS_var.dark = 1;
            Back.BackgroundImage = Resources.black_left_arrow;
        }

        private void White_CheckedChanged(object sender, EventArgs e)
        {
            IntegrateOS_var.theme = Form_StyleManager.Theme = MetroThemeStyle.Light;
            IntegrateOS_var.dark = 0;
            Back.BackgroundImage = Resources.white_left_arrow;
        }

        private void Back_Click(object sender, EventArgs e) => Moving.Form(this, new Settings_Menu(Location));

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IntegrateOS_var.color_string = this.metroComboBox1.GetItemText(this.metroComboBox1.SelectedItem);
            switch (IntegrateOS_var.color_string)
            {
                case "Blue": Form_StyleManager.Style = MetroColorStyle.Blue; break;
                case "Green": Form_StyleManager.Style = MetroColorStyle.Green; break;
                case "Lime": Form_StyleManager.Style = MetroColorStyle.Lime; break;
                case "Teal": Form_StyleManager.Style = MetroColorStyle.Teal; break;
                case "Orange": Form_StyleManager.Style = MetroColorStyle.Orange; break;
                case "Brown": Form_StyleManager.Style = MetroColorStyle.Brown; break;
                case "Pink": Form_StyleManager.Style = MetroColorStyle.Pink; break;
                case "Magenta": Form_StyleManager.Style = MetroColorStyle.Magenta; break;
                case "Purple": Form_StyleManager.Style = MetroColorStyle.Purple; break;
                case "Red": Form_StyleManager.Style = MetroColorStyle.Red; break;
                case "Yellow": Form_StyleManager.Style = MetroColorStyle.Yellow; break;
            }
            IntegrateOS_var.color_t = metroComboBox1.SelectedIndex + 1;
            IntegrateOS_var.color = Form_StyleManager.Style;
        }

        private void Settings_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) => Saving.Data();

    }
}
