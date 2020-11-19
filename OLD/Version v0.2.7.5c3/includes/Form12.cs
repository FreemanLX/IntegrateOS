using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;


namespace WindowsFormsApplication2
{
    public partial class Form12 : MetroFramework.Forms.MetroForm
    {
        int j = 0;
        public Form12(int i = 0) 
        {
            j = i;
            InitializeComponent();
            if (i == 1)
                pointers = Test(IntegrateOS.tools_location.location1);
            else
                pointers = Test(WindowsSetup.Variabile.locatie);
            foreach (string pointer in pointers)
            {
                checkedListBox1.Items.Add(pointer);
            }
        }


        private const string DllFilePath = @"IntegrateOS Base.dll";

       
        [DllImport(DllFilePath, SetLastError = true, EntryPoint = "windowsinfo", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern IntPtr  Windowsinfo(System.Text.StringBuilder path);
        public static string[] Test(string path)
        {
            string s = "";
                System.Text.StringBuilder text = new System.Text.StringBuilder(path);
            s = Marshal.PtrToStringUni(Windowsinfo(text));
            string[] lines = s.Split(';');
            string[] lines3 = new string[lines.Length - 1];
            for (int i = 0; i < lines.Length - 1; i++) lines3[i] = lines[i];
            
            return lines3;

        }

        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                var dialog = MetroFramework.MetroMessageBox.Show(this, "Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, IntegrateOS.IntegrateOS_var.color_t);
                if(dialog == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch { }
        }




        string[] pointers;
        private void Form12_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.IntegrateOS_var.color1, IntegrateOS.IntegrateOS_var.theme);
            if (IntegrateOS.IntegrateOS_var.dark == 0)
            {
                checkedListBox1.ForeColor = System.Drawing.Color.Black;
                checkedListBox1.BackColor = System.Drawing.Color.White;
                
            }
            else
            {
                checkedListBox1.ForeColor = System.Drawing.Color.White;
                checkedListBox1.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
            }
            
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            int ok = 0;
          for (int index = 0; index < checkedListBox1.Items.Count; ++index)
            if (checkedListBox1.GetItemChecked(index) == true)
            {
                    ok = 1;
                    break;
            }
            if (ok == 1)
            {
                if (j == 0)
                {
                    ///Ne ducem la form11
                    WindowsSetup.Variabile.fix = (checkedListBox1.SelectedIndex + 1).ToString();
                    var form = new Form11();
                    this.Hide();
                    form.Show();
                }
                if (j == 1)
                {
                    IntegrateOS.tools_location.index = (checkedListBox1.SelectedIndex + 1).ToString();
                    this.Hide();
                    var x = new IntegrateOS.convert_wim_esd(IntegrateOS.tools_location.type, IntegrateOS.tools_location.conversion_type, 1);
                    x.Show();
                }
                if (j == 2)
                {
                    MessageBox.Show((checkedListBox1.SelectedIndex + 1).ToString());
                    var x = new IntegrateOS.Mount_Windows(checkedListBox1.SelectedIndex + 1);
                    x.Show();
                    this.Hide();
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "You must check an option to select an Edition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, IntegrateOS.IntegrateOS_var.color_t);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);

            metroButton1.Visible = true;
        }



        private void metroButton2_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            string[] pointers1 = Test(WindowsSetup.Variabile.locatie);

            foreach (string pointer in pointers1)
            {
                checkedListBox1.Items.Add(pointer);
            }

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var x = new IntegrateOS.selection_os();
            x.Show();
            this.Hide();
        }
    }
}
