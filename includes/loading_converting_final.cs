using System;
using System.IO;
using System.Windows.Forms;
using WindowsSetup;
using System.Threading;
using System.Linq;

namespace IntegrateOS
{
    public partial class loading_converting_final : MetroFramework.Forms.MetroForm
    {

        private float GetTotalFreeSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                   return (float) (drive.TotalFreeSpace / (1024*1024*1024)); ///gb   
            }
            return -1;
        }


        private void convert_t(string convert_t, string to_convert_t)
        {


        }

        string type;
        public loading_converting_final(string type1)
        {
            type = type1;
            try
            {
                InitializeComponent();
                this.Show();
            }
            catch { }
        }

        private void loading_converting_final_Load(object sender, EventArgs ep)
        {
            try
            {
                this.Show();
                Thread t2 = new Thread(
                () =>
                 {
                     string convert = IntegrateOS.tools_location.location1;
                     string convert_to = IntegrateOS.tools_location.location2;
                     if (File.Exists(convert))
                     {
                         string[] split_t = convert_to.Split(':');
                         string e = split_t[0] + ":\\";
                         float size = new float();
                         size = (float)(new System.IO.FileInfo(convert).Length / (1024 * 1024 * 1024));
                         double calculate_size = 0;
                         int c_ok = 2;
                         if (type == "ESD")
                         {
                             calculate_size = GetTotalFreeSpace(e) + 0.5 * GetTotalFreeSpace(e) + 1; ///3 GB ESD =  4.5 WIM
                             c_ok = 1;
                         }
                         if (type == "WIM")
                         {
                             calculate_size = GetTotalFreeSpace(e);
                             c_ok = 0;
                         }
                         if (c_ok == 0 || c_ok == 1)
                         {
                             if (size > calculate_size)
                             {
                                 MessageBox.Show("You have less space in partition than the file that you want to convert. You need only " + ((double)(calculate_size - size)).ToString() + "GB");
                                 var x = new tools();
                                 this.Hide();
                                 x.Show();
                                 this.Close();
                             }
                             else
                             {
                                 Thread.Sleep(5000);
                                 label2.Text = "30 %";
                                 label2.Refresh();
                                 progressBar1.Value = 30;
                                 string final_convert = "Packages\\dism /export-image /SourceImageFile:" + "\"" + convert + "\"" + " /SourceIndex:" + IntegrateOS.tools_location.index + " /DestinationImageFile:" + "\"" + convert_to + "\"" + " /Compress:" + IntegrateOS.tools_location.conversion_type +  " /CheckIntegrity";
                                 ///MessageBox.Show(final_convert);
                                 int code = CMD_Process_Class.Process_CMD(final_convert, 1);
                                 if (code == 0)
                                 {

                                     progressBar1.Value = 100;
                                     MessageBox.Show("The conversion is complete!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                     var x = new tools();
                                     x.Show();
                                     this.Close();
                                 }
                                 else
                                 {
                                     MessageBox.Show("The conversion failed! Error code " + code.ToString() + "x0", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                     var x = new tools();
                                     x.Show();
                                     this.Close();
                                 }
                             }
                         }
                         else
                         {
                             MessageBox.Show("Error: 2! Contact Support for solving this problem", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             var x = new tools();
                             this.Hide();
                             x.Show();
                             this.Close();
                         }

                     }
                     else
                     {

                         MessageBox.Show("The selected file doesn't exist");
                     }
                 }
                )
                {
                    IsBackground = true
                };
                t2.Start();
            }
            catch { }
        }
    }
}
