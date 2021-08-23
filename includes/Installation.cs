using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static IntegrateOS.Algorithms.Dism_Methods;
using static IntegrateOS.Algorithms;

namespace IntegrateOS
{
    public partial class Installation : MetroFramework.Forms.MetroForm
    {
        public Installation(Point Location){
            InitializeComponent();
            this.Location = Location;
        }

        private void Installation_Load(object sender, EventArgs e){
            StyleManager = Themes.Generate;
            Extracting_windows_label.ForeColor = Installing_Boot_Label.ForeColor = (int)Themes.MetroTheme == 0 || (int)Themes.MetroTheme == 1 ? Color.Black : Color.White;
        }


        private void Installing_Windows_Boot_Files()
        {
            try
            {
                    Generate_Process.Static_BackgroundWorker_Process("Packages\\bcdboot " + InstallationData.partition + "\\Windows /s " + InstallationData.partition + "\\" + " /f all", "cmd.exe");
                    Generate_Process.Static_BackgroundWorker_Process("Packages\\bcdedit /copy {current} /d \"IntegrateOS\" > Packages\\bootsector_id.txt", "cmd.exe");
                    string bootsector_id = (File.ReadAllText(@"Packages\bootsector_id.txt").Split('{')[1].Split('.')[0].Split('}'))[0];
                    string partition = InstallationData.partition.Split('\\')[0];
                   Generate_Process.Static_BackgroundWorker_Process("Packages\\bcdedit.exe / set { " + bootsector_id + "} device partition=" + partition + " ", "cmd.exe");
                   Generate_Process.Static_BackgroundWorker_Process("Packages\\bcdedit.exe / set { " + bootsector_id + "} osdevice partition=" + partition + " ", "cmd.exe");
            }
            catch (System.ComponentModel.Win32Exception exception)
            {
                if (MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Environment.Exit(10);
                }
            }
            catch(Exception exception)
            {
                if (MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error) == DialogResult.OK)
                {
                    Environment.Exit(10);
                }

            }
            finally
            {

            }
        }

        private void Installation_Shown(object sender, EventArgs e)
        {
            Extracting_windows_label.Font = new Font("Segoe UI Semibold", 14, FontStyle.Italic);
            if (File.Exists(InstallationData.location))
            {
                if (Path.GetExtension(InstallationData.location) == ".esd")
                {
                    string convert_to_path = InstallationData.partition + "\\install.wim";
                    new BackgroundThread(new Thread(() => ConvertImage(InstallationData.location, convert_to_path, InstallationData.index))).Start();
                    new BackgroundThread(new Thread(() => Apply_image(convert_to_path, InstallationData.partition + "\\", InstallationData.index))).Start();
                }
                else new BackgroundThread(new Thread(() => Apply_image(InstallationData.location, InstallationData.partition + "\\", InstallationData.index))).Start();
            }
            Done_1.Visible = true;


            Extracting_windows_label.Font = new Font("Segoe UI Semilight", 14, FontStyle.Regular);
            Installing_Boot_Label.Font = new Font("Segoe UI Semibold", 14, FontStyle.Italic);
            Extracting_windows_label.Refresh(); Installing_Boot_Label.Refresh();
            InstallationData.partition = InstallationData.partition.Split('\\')[0];
            
            Installing_Windows_Boot_Files();
            Done_2.Visible = true;
            bool check = MessageBox.Show("Do you want to restart the Windows to complete the installation?", "Succes",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) ==
                   DialogResult.Yes;
            if (check == true)
            {
                Generate_Process.Static_BackgroundWorker_Process("shutdown -r -t 0", "cmd.exe");
            }
            else Environment.Exit(0);
        }
    }
}