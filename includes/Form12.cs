using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace WindowsFormsApplication2
{
    public partial class Form12 : MetroFramework.Forms.MetroForm
    {
        int j = 0;
        public Form12(int i = 0) ///1 - convert, 0 - installation
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
        [DllImport(DllFilePath, SetLastError = true, EntryPoint = "windowsinfo", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Windowsinfo(System.Text.StringBuilder path);
        public static string[] Test(string path)
        {
            string s = "";
                System.Text.StringBuilder text = new System.Text.StringBuilder(path);
                s = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(Windowsinfo(text));
            string[] lines = s.Split(';');
            string[] lines3 = new string[lines.Length - 1];
            for (int i = 0; i < lines.Length - 1; i++)
            {
                lines3[i] = lines[i];
            }
            return lines3;

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

        string[] pointers;
        private void Form12_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.user_settings.color1, IntegrateOS.user_settings.theme);
            if (IntegrateOS.user_settings.dark == 0)
            {
                checkedListBox1.ForeColor = System.Drawing.Color.Black;
                checkedListBox1.BackColor = System.Drawing.Color.White;
            }
            else
            {
                checkedListBox1.ForeColor = System.Drawing.Color.White;
                checkedListBox1.BackColor = System.Drawing.Color.Black;
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            int ok = 0;
          for (int index =0; index < checkedListBox1.Items.Count; ++index)
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
                    var x = new IntegrateOS.Mount_Windows(Int32.Parse(checkedListBox1.SelectedIndex + 1.ToString()));
                    x.Show();
                    this.Hide();
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "You must check an option to select an Edition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
