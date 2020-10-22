using System;
using System.Windows.Forms;
using IntegrateOS;
using System.IO;

namespace WindowsFormsApplication2
{

   
    public partial class Form5 : MetroFramework.Forms.MetroForm
    {
        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        int j;
        public Form5(int i = 0)
        {
            j = i;
            g.Clear();
            InitializeComponent();
            if(i == 1)
            {
                this.Text = "Mount Windows - Select the file type for mounting";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {Environment.Exit(0);}

        private void Form5_Load(object sender, EventArgs e) {
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.user_settings.color1, IntegrateOS.user_settings.theme);
            metroTile1.Style = IntegrateOS.user_settings.color1;
            metroTile2.Style = IntegrateOS.user_settings.color1;
            metroTile3.Style = IntegrateOS.user_settings.color1;
            metroTile4.Style = IntegrateOS.user_settings.color1;
            metroTile5.Style = IntegrateOS.user_settings.color1;
            if (IntegrateOS.user_settings.dark == 0)
            {
                this.components.SetTheme(this, IntegrateOS.user_settings.theme);
            }
            else
            {

                this.components.SetTheme(this, IntegrateOS.user_settings.theme);
            }

        }
        string which_t;

        private void txtPath_SizeChanged(object sender, EventArgs e)
        {
            if (txtPath.Text.Length > 0)   ///aici verificam lungimea textului din textbox 
            {
                button4.Visible = true;
            }
            if (txtPath.Text.Length == 0) ///aici fixam problema ca daca stergi ceva din textbox sa nu mai apara butonul
            {
                button4.Visible = false;
            }
        }
#pragma warning disable IDE1006 // Naming Styles
        private void txtPath_TextChanged(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            if (txtPath.Text.Length > 0)
            {
                button4.Visible = true;
            }
            if (txtPath.Text.Length == 0)
            {
                button4.Visible = false;
            }
        }
        private void metroTile4_Click(object sender, EventArgs e)
        {
            txtPath.Visible = true;
            button3.Visible = true;
            which_t = metroTile4.Text;
            button3.Text = "Browse " + which_t;
        }

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
            txtPath.Visible = true;
            button3.Visible = true;
            which_t = metroTile3.Text;
            button3.Text = "Browse " + which_t;
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            txtPath.Visible = true;
            button3.Visible = true;
            which_t = metroTile5.Text;
            button3.Text = "Browse " + which_t;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (j == 0)
            {
                var t = new IntegrateOS.selection_os();
                t.Show();
                this.Hide();
            }
            else
            {
                var t = new IntegrateOS.tools();
                t.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (which_t != "Folder")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (which_t == "WIM") ofd.Filter = "*.wim|*.wim";
                if (which_t == "ISO") ofd.Filter = "*.iso|*.iso";
                if (which_t == "ESD") ofd.Filter = "*.esd|*.esd";
                if (which_t == "SWM") ofd.Filter = "*.swm|*.swm";
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
                        string wim = path + "\\Sources\\install.wim";
                        string esd = path + "\\Sources\\install.esd";
                        string swm = path + "\\Sources\\install.swm";
                        if (!File.Exists(swm))
                        {
                            if (!File.Exists(wim))
                            {
                                if (!File.Exists(esd))
                                {
                                    MessageBox.Show("It isn't an official Windows iso!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    WindowsSetup.Variabile.locatie = esd;
                                    txtPath.Text = esd;
                                    WindowsSetup.Variabile.var = "esd";
                                }

                            }
                            else
                            {
                                WindowsSetup.Variabile.locatie = wim;
                                txtPath.Text = wim;
                                WindowsSetup.Variabile.var = "wim";
                            }
                        }
                        else
                        {
                            WindowsSetup.Variabile.locatie = swm;
                            txtPath.Text = swm;
                            WindowsSetup.Variabile.var = "swm";
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (j == 0)
            {
                if (which_t != "ISO")
                {
                    if (which_t == "WIM") WindowsSetup.Variabile.var = "wim";
                    if (which_t == "ESD") WindowsSetup.Variabile.var = "esd";
                    if (which_t == "SWM") WindowsSetup.Variabile.var = "swm";
                    var form15 = new Form12();
                    this.Hide();
                    form15.Show();
                }
                if (which_t == "ISO")
                {
                    var form15 = new WindowsSetup.Form7();
                    this.Hide();
                    form15.Show();
                }
            }
            else
            {
                IntegrateOS.tools_location.type = which_t;
                IntegrateOS.tools_location.location1 = txtPath.Text;
                var form15 = new Form12(2);
                this.Hide();
                form15.Show();
            }
        }

        private void txtPath_Click(object sender, EventArgs e)
        {

        }
    }
}
