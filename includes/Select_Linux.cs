using System;
using System.Windows.Forms;
using IntegrateOS;
using System.IO;

namespace IntegrateOS
{
    public partial class Select_Linux : MetroFramework.Forms.MetroForm
    {
        public Select_Linux()
        {
            InitializeComponent();
        }

        private void txtPath_SizeChanged(object sender, EventArgs e)
        {
            if (txtPath.Text.Length > 0)   ///aici verificam lungimea textului din textbox 
            {
                button1.Visible = true;
            }
            if (txtPath.Text.Length == 0) ///aici fixam problema ca daca stergi ceva din textbox sa nu mai apara butonul
            {
                button1.Visible = false;
            }
        }
#pragma warning disable IDE1006 // Naming Styles
        private void txtPath_TextChanged(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            if (txtPath.Text.Length > 0)
            {
                button1.Visible = true;
            }
            if (txtPath.Text.Length == 0)
            {
                button1.Visible = false;
            }
        }

        private void Select_Linux_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.user_settings.color1, IntegrateOS.user_settings.theme);
            metroTile1.Style = IntegrateOS.user_settings.color1;
            metroTile2.Style = IntegrateOS.user_settings.color1;
            metroTile3.Style = IntegrateOS.user_settings.color1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var t = new IntegrateOS.selection_os();
            t.Show();
            this.Hide();
        }
        string which_t;
        private void metroTile1_Click(object sender, EventArgs e)
        {
            txtPath.Visible = true;
            button3.Visible = true;
            which_t = metroTile1.Text;
            button3.Text = "Browse " + which_t;
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            txtPath.Visible = true;
            button3.Visible = true;
            which_t = metroTile2.Text;
            button3.Text = "Browse " + which_t;
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            var x = new Linux();
            x.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (which_t != "Folder")
            {
                OpenFileDialog ofd = new OpenFileDialog();
            if (which_t == "ISO") ofd.Filter = "*.iso|*.iso";
            if (ofd.ShowDialog() == DialogResult.OK) ////ofd este un obiect de tip OfenFileDialog, si ShowDialog() verifica daca fisierul 
                                                     ///respectiv a fost citit sau nu (cu 1 sau cu 0)
            {
                ///DialogResult.OK e un define, si e atribuit cu 1
                txtPath.Text = ofd.FileName; ////Aici il ducem la textbox (il afisam)
                WindowsSetup.Variabile.locatie = txtPath.Text; ///aici luam locatia si l procesam
            }
        }
            else
            {
                string path;
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        path = fbd.SelectedPath;
                        WindowsSetup.Variabile.locatie = path;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (which_t == "ISO")
            {
                var form15 = new WindowsSetup.Form7();
                this.Hide();
                form15.Show();
            }
        }
    }
}
