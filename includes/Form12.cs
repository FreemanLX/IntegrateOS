using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using DiscUtils.Wim;
using WindowsSetup;

namespace WindowsFormsApplication2
{
    public partial class Form12 : MetroFramework.Forms.MetroForm
    {
        int j = 0;
        public Form12(int i = 0) ///1 - convert, 0 - installation
        {
            j = i;
            InitializeComponent();
        }

        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            g.Clear();
            try
            {
                System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(@"Packages\Temp\");
                foreach (System.IO.FileInfo file in directory.GetFiles())
                    file.Delete();
                foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories())
                    subDirectory.Delete(true);
            }
            catch { }
            Environment.Exit(0);
        }

        int Count_size(string alpha)
        {
            int ep = alpha.Length;
            return ep;

        }
        
        int converter(int max)
        {
            int ep = max / 1024;
            ep /= 1024;
            ep /= 1024;
            return ep;
        }

        private void Form12_Load(object sender, EventArgs e)
        {////Aici putem vedea editiile de Windows
            ///Fiindca exista si WIM / ESD / SWM care are mai multe versiuni de Windows
            ///Fiecare are o licenta a lui si fiecare editie are fisiere de windows diferite
            ///Select an Windows Edition
            ///Windows 8 
            ///Windows 8 Pro
            ///Windows 8 Enterprise 
            try
            {
                using (FileStream wimstream = new FileStream(WindowsSetup.Variabile.locatie, FileMode.Open, FileAccess.Read))
                {

                    WimFile x = new WimFile(wimstream);
                    
                }
            }
            catch
            {

            }
            ///Aici ne jucam cu comanda pe care il apelam folosind un proces, ca sa ne afiseze editiile.
            string install;

            ///WindowsSetup.Variabile.locatie reprezinta locatia acelui fisier citit.
            ///WindowsSetup.Variabile.var reprezinta extensia acelui fisier citit.
            ///

            ///Fiindca lucram cu SWM, trebuie sa folosim o alta comanda deci e putin mai greu.
            if (WindowsSetup.Variabile.var == "SWM") ///daca fisierul citit are extensia *.SWM atunci folosim comanda 
            {
                ///acum hai sa cautam pe Google comanda =)))
                install = "Get-WindowsImage -Imagepath \"" + WindowsSetup.Variabile.locatie + "\" | Select-Object ImageName > Packages\\fix.txt ";
            }                  ///doar pentru *.SWM                   ///
            else
            {
                if (j == 0)
                    install = "Get-WindowsImage -Imagepath \"" + WindowsSetup.Variabile.locatie + "\" | Select-Object ImageName > Packages\\fix.txt ";
                else
                    install = "Get-WindowsImage -Imagepath \"" + IntegrateOS.tools_location.location1 + "\" | Select-Object ImageName > Packages\\fix.txt ";
                ///asta e procesul pe care il apelam:
                CMD_Process_Class.Process_Powershell(install);
            }

            ///aici citim fisierul afisat, ce afiseaza Editia unui Windows...
            string[] lines = File.ReadAllLines("Packages\\fix.txt");
            var lineCount = File.ReadAllLines("Packages\\fix.txt").Length;
            for(int i = 3; i<lineCount; i++)
            {
                if(lines[i].Length > 1) checkedListBox1.Items.Add(lines[i]);
            }
      
            
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            ///Aici e in functie daca vin de la tool uri sau vreau sa instalez.
            ///Noi suntem la instalare, deci avem j = 0
            //MessageBox.Show(WindowsSetup.Variabile.fix);
            if (j == 0)
            {
                ///Ne ducem la form11
                WindowsSetup.Variabile.fix = (checkedListBox1.SelectedIndex + 1).ToString();
                var form = new Form11();
                this.Hide();
                form.Show();
            }
            if(j == 1)
            {
                IntegrateOS.tools_location.index = (checkedListBox1.SelectedIndex + 1).ToString();
                var test = new IntegrateOS.loading_converting_final(IntegrateOS.tools_location.type);
                this.Hide();
                test.Show();
            }
            if(j == 2)
            {
                var x = new IntegrateOS.Mount_Windows(Int32.Parse(checkedListBox1.SelectedIndex + 1.ToString()));
                x.Show();
                this.Hide();
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            string install;
            if(j == 0)
                install = "Get-WindowsImage -Imagepath \"" + WindowsSetup.Variabile.locatie + "\" | Select-Object ImageName > Packages\\fix.txt ";
            else
                install = "Get-WindowsImage -Imagepath \"" + IntegrateOS.tools_location.location1 + "\" | Select-Object ImageName > Packages\\fix.txt ";
            CMD_Process_Class.Process_Powershell(install);
            string[] lines = File.ReadAllLines("Packages\\fix.txt");
            var lineCount = File.ReadAllLines("Packages\\fix.txt").Length;
            for (int i = 3; i < lineCount; i++)
            {
                if (lines[i].Length > 1) checkedListBox1.Items.Add(lines[i]);
            }

        }
    }
}
