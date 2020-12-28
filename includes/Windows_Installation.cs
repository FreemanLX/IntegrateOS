using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using MetroFramework;
using System.Runtime.InteropServices;

namespace IntegrateOS
{
    public partial class Windows_Installation : MetroFramework.Forms.MetroForm
    {
        public Windows_Installation(System.Drawing.Point punct){
            InitializeComponent();
            Location = punct;
        }

        private void Form13_Load(object sender, EventArgs e){
            StyleManager = Themes.Generate(IntegrateOS_var.color, IntegrateOS_var.theme);
            Extracting_windows_label.ForeColor = Installing_Boot_Label.ForeColor = Percentage_Label.ForeColor = Progress_Label.ForeColor = IntegrateOS_var.dark == 0 ? Color.Black : Color.White;
            Progress_Bar.Theme = IntegrateOS_var.theme;
            Progress_Bar.Style = IntegrateOS_var.color;
        }

        private const string DllFilePath = @"IntegrateOS Core.dll";
        [DllImport(DllFilePath, SetLastError = true, EntryPoint = "complete", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int Complete(System.Text.StringBuilder format, System.Text.StringBuilder nickname, int uefi);

        private void Complete()
        {
            var format = new System.Text.StringBuilder(Temporary_I.format);
            var temp = new System.Text.StringBuilder("IntegrateOS");
            if(Complete(format, temp, -1) == 0)
            {
                if(MessageBox.Show("The installation failed. Error code: 0x10. Please retry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Environment.Exit(10);
                }
            }
        }

        

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Progress_Bar.Minimum = 0;
            Progress_Bar.Maximum = 100;
            string ss = IntegrateOS.Temporary_I.locatie;
            Percentage_Label.Text = string.Format("{0} %", Progress_Bar.Value);
            Percentage_Label.Refresh();
                         
                if (Progress_Bar.Value == 0)
                {
                    Progress_Bar.Value = Progress_Bar.Value + 20;
                    ManagedWimLib.Wim.GlobalInit("libwim-15.dll");
                    Thread t1 = new Thread(() =>{

                    ManagedWimLib.Wim x = ManagedWimLib.Wim.OpenWim(IntegrateOS.Temporary_I.locatie, 0);
                    x.ExtractImage(Int32.Parse(IntegrateOS.Temporary_I.fix), IntegrateOS.Temporary_I.format + "\\", ManagedWimLib.ExtractFlags.ALL_CASE_CONFLICTS);

                    }){ IsBackground = true };
                    t1.Start();
                    while (t1.IsAlive) { Application.DoEvents();}
                    Progress_Bar.Value = 60;
                    Percentage_Label.Text = Progress_Bar.Value.ToString() + " %";
                    Percentage_Label.Refresh();
                    Done_1.Visible = true;
                }
                if (Progress_Bar.Value == 60)
                {
                    Extracting_windows_label.Font = new Font("Segoe UI Semilight", 14, FontStyle.Regular);
                    Installing_Boot_Label.Font = new Font("Segoe UI Semibold", 14, FontStyle.Italic);
                    Extracting_windows_label.Refresh(); Installing_Boot_Label.Refresh();
                    string[] epsilon = IntegrateOS.Temporary_I.format.Split('\\');
                    IntegrateOS.Temporary_I.format = epsilon[0];
                    Thread bootsect = new Thread(() =>{Complete();}) {IsBackground = true};
                    bootsect.Start();
                    bootsect.Join();
                    Done_2.Visible = true;
                    Progress_Bar.Value = 100;
                    Percentage_Label.Text = Progress_Bar.Value.ToString() +  "%";
                    Percentage_Label.Refresh();
                }

                if (Progress_Bar. Value == 100)
                {
                    Timer_Installation.Enabled = false;
                    Progress_Bar.Enabled = false;
                    var result = MetroMessageBox.Show(this, "Do you want to restart the Windows to complete the installation?", "Succes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, IntegrateOS.IntegrateOS_var.color_t);
                    if (result == DialogResult.Yes) IntegrateOS.CMD_Process_Class.Process_CMD("shutdown -r -t 0", "cmd.exe");
                    else Environment.Exit(0);
                }
            

        }

    }
}