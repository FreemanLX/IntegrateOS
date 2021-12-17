using System;
using System.Windows.Forms;
using MetroFramework;

namespace IntegrateOS.Account.Settings.Themes
{
    public partial class Settings : MetroFramework.Forms.MetroForm
    {
        public Settings(System.Drawing.Point punct)
        {
            InitializeComponent();
            Location = punct;
            temp = Data.Dark;
        }
        bool temp;

        private void Settings_Load(object sender, EventArgs e)
        {
            Back.BackgroundImage = IntegrateOS.Themes.Icon_Style;
            Back.Refresh();
            
            for (int i = 0; i<12; i++) Colors.Items.Add(MetroDefaults.Convert_to_String(i));
            StyleManager = Form_StyleManager;
            Colors.Text = Colors.GetItemText(MetroDefaults.Convert_to_String((int)IntegrateOS.Themes.MetroColor - 1));
            Dark.Checked = temp;  White.Checked = !temp;
        }

        private void Dark_CheckedChanged(object sender, EventArgs e)
        {
            IntegrateOS.Themes.MetroTheme = Form_StyleManager.Theme = MetroThemeStyle.Dark;
            Back.BackgroundImage = Resources.black_left_arrow;
        }

        private void White_CheckedChanged(object sender, EventArgs e)
        {
            IntegrateOS.Themes.MetroTheme = Form_StyleManager.Theme = MetroThemeStyle.Light;
            Back.BackgroundImage = Resources.white_left_arrow;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Saving.XML();
            Moving.Form(this, new PrincipalForm(Location));
        }

        private void MetroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form_StyleManager.Style = (MetroColorStyle) (Colors.SelectedIndex + 1);
            IntegrateOS.Themes.MetroColor = Form_StyleManager.Style;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Saving.XML();
            base.OnFormClosing(e);
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e) { } 

    }
}
