using System;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form14 : MetroFramework.Forms.MetroForm
    {
        string which_t;
        int j = 0;
        public Form14(string which, int i = 0)
        {
            InitializeComponent();
            this.Text = "Select " + which;
            which_t = which;
            j = i;
        }
        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            
            g.Clear();
            Environment.Exit(0);
        }




        

        private void Form14_Load(object sender, EventArgs e)
        {

        }

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var form5 = new Form5();
            this.Hide();
            form5.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void txtPath_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Asta reprezinta o functie ce verifica daca textbox ul a fost modificat, daca a fost modificat si e > 0, automat ca fisierul e citit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (j == 0)
            {
                var form5 = new Form5();
                this.Hide();
                form5.Show();
            }
            else
            {
                var form5 = new IntegrateOS.tools();
                this.Hide();
                form5.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ///Aici ne ducem in functie de extensie, cum ar fi Wim, Swm etc si il ducem la o clasa anume.
            if (j == 0)
            {
                ///mai bine scriu decat sa vorbesc, ca nu ma intelegeti.
                if (which_t == "WIM") ///aici ne mutam la clasa pentru WIM fiindca aveam extensia WIM
                {
                    WindowsSetup.Variabile.var = "wim";

                    var form15 = new Form12();
                    this.Hide();
                    form15.Show();
                }
                if (which_t == "ESD") ///aici pentru esd and so on ...
                {
                    WindowsSetup.Variabile.var = "esd";

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
                if(which_t == "SWM")
                { ///fiindca SWM functioneaza ca si concept ca la WIM, putem edita / sterge modifica exact ca la WIM 
                  ///deci vom folosi aceeasi clasa ca si WIM
                    var form15 = new Form12(); ///Formul 12 afiseaza editiile de Windows, pe care vi le am explicat cat am putut mai inainte
                    this.Hide();
                    ///form15.Show(); 

                    ////evident inainte sa mergem la Form12, trebuie sa salvam ca suntem in extensia SWM deci 
                    ///
                    WindowsSetup.Variabile.var = "SWM"; ///Acesta salveaza in global ca suntem in SWM ca prelucrare
                                                        ///Iar apoi 
                                                        ///
                    form15.Show(); ///Am terminat pana aici, ne ducem la Form12
                }
            }
            else
            { 
                 if(which_t == "WIM")
                {
                    IntegrateOS.tools_location.type = "WIM";
                }
                 if(which_t == "ESD")
                {
                    IntegrateOS.tools_location.type = "ESD";
                }
                IntegrateOS.tools_location.location1 = txtPath.Text;
                var form15 = new Form12(2);
                this.Hide();
                form15.Show();
            }
        }
    }
}
