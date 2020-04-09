using System;
using System.Windows.Forms;
using System.IO;

namespace WindowsSetup
{
    public partial class Form9 : MetroFramework.Forms.MetroForm
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
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
                    if (!File.Exists(wim))
                    {
                        if(!File.Exists(esd))
                        {

                            MessageBox.Show("It isn't an official Windows iso!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            var form = new WindowsFormsApplication2.Form5();
                            this.Hide();
                            form.Show();
                        }
                        else
                        {
                            WindowsSetup.Variabile.locatie = esd;
                            WindowsSetup.Variabile.var = "esd";
                            var y = new WindowsFormsApplication2.Form12();
                            this.Hide();
                            y.Show();

                        }

                    }
                    else
                    {
                        WindowsSetup.Variabile.locatie = wim;
                        WindowsSetup.Variabile.var = "wim";

                        var y = new WindowsFormsApplication2.Form12();
                        this.Hide();
                        y.Show();

                    }
                }
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var z = new WindowsFormsApplication2.Form5();
            this.Hide();
            z.Show();
        }
    }
}
