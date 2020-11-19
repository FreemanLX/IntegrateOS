using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using MetroFramework;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication2
{
    public partial class Form13 : MetroFramework.Forms.MetroForm
    {
        public Form13(){InitializeComponent();}


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                var dialog = MetroFramework.MetroMessageBox.Show(this, "Do you want to abort the Installation?", "Abort", MessageBoxButtons.YesNo, MessageBoxIcon.Question, IntegrateOS.IntegrateOS_var.color_t);
                if (dialog == DialogResult.Yes)
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

        private void Form13_Load(object sender, EventArgs e){
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.IntegrateOS_var.color1, IntegrateOS.IntegrateOS_var.theme);
            if(IntegrateOS.IntegrateOS_var.dark == 0)
            {
                label1.ForeColor = System.Drawing.Color.Black;
                label5.ForeColor = System.Drawing.Color.Black;
                label7.ForeColor = System.Drawing.Color.Black;
                label10.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                label1.ForeColor = System.Drawing.Color.White;
                label5.ForeColor = System.Drawing.Color.White;
                label7.ForeColor = System.Drawing.Color.White;
                label10.ForeColor = System.Drawing.Color.White;
            }
            progressBar1.Theme = IntegrateOS.IntegrateOS_var.theme;
            progressBar1.Style = IntegrateOS.IntegrateOS_var.color1;
        }

        private const string DllFilePath = @"IntegrateOS Base.dll";
        [DllImport(DllFilePath, SetLastError = true, EntryPoint = "complete", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int complete(System.Text.StringBuilder format, System.Text.StringBuilder nickname, int uefi);



        string temp;




        private void before_complete()
        {
            try
            {
                string[] epsilon = WindowsSetup.Variabile.format.Split('\\');
                WindowsSetup.Variabile.format = epsilon[0];
                    using (IntegrateOS.Bcdedit_name name = new IntegrateOS.Bcdedit_name())
                    {
                        name.ShowDialog();
                        name.BringToFront();                        
                        temp = name.get();
                        if (temp == "") temp = "IntegrateOS";
                    }
            }
            catch { }
        }
        private void Complete()
        {
            temp = "IntegrateOS";
            var format = new System.Text.StringBuilder(WindowsSetup.Variabile.format);
            var temp1 = new System.Text.StringBuilder(temp);
            if(complete(format, temp1, -1) == 0)
            {
             var eps = MessageBox.Show("The installation failed. Error code: 0x10. Please retry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(eps == DialogResult.OK)
                {
                    Environment.Exit(10);
                }
            }
        }

        WindowsSetup.Variabile g = new WindowsSetup.Variabile();
        

        private void timer1_Tick(object sender, EventArgs e)
        {

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            label7.Enabled = true;
            label7.Visible = true;
            string ss = WindowsSetup.Variabile.locatie;
            label7.Text = string.Format("{0} %", progressBar1.Value);
            label7.Refresh();
                         
                if (progressBar1.Value == 0)
                {
                    progressBar1.Value = progressBar1.Value + 20;
                    ManagedWimLib.Wim.GlobalInit("libwim-15.dll");
                    Thread t1 = new Thread(() =>{
                    ManagedWimLib.Wim x = ManagedWimLib.Wim.OpenWim(WindowsSetup.Variabile.locatie, 0);
                    x.ExtractImage(Int32.Parse(WindowsSetup.Variabile.fix), WindowsSetup.Variabile.format + "\\", ManagedWimLib.ExtractFlags.ALL_CASE_CONFLICTS);
                    }){ IsBackground = true };
                    t1.Start();
                    while (t1.IsAlive) { Application.DoEvents();}
                    progressBar1.Value = 60;
                    label7.Text = progressBar1.Value.ToString() + " %";
                    label7.Refresh();
                    label12.Visible = true;
                }
                if (progressBar1.Value == 60)
                {
                    label1.Font = new Font("Segoe UI Semilight", 14, FontStyle.Regular);
                    label5.Font = new Font("Segoe UI Semibold", 14, FontStyle.Italic);
                    label1.Refresh(); label5.Refresh();
                    string[] epsilon = WindowsSetup.Variabile.format.Split('\\');
                    WindowsSetup.Variabile.format = epsilon[0];
                    Thread bootsect = new Thread(() =>{Complete();}) {IsBackground = true};
                    bootsect.Start();
                    bootsect.Join();
                    label13.Visible = true;
                    progressBar1.Value = 100;
                    label7.Text = progressBar1.Value.ToString() +  "%";
                    label7.Refresh();
                }

                if (progressBar1. Value == 100)
                {
                    timer1.Enabled = false;
                    progressBar1.Enabled = false;
                    var result = MetroMessageBox.Show(this, "Do you want to restart the Windows to complete the installation?", "Succes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, IntegrateOS.IntegrateOS_var.color_t);
                    if (result == DialogResult.Yes)
                    {
                        IntegrateOS.CMD_Process_Class.Process_CMD("shutdown -r -t 0");
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                
                }
            

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
