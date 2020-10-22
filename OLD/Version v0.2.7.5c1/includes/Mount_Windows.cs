using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Dism;

namespace IntegrateOS
{
    public partial class Mount_Windows : MetroFramework.Forms.MetroForm
    {
        int index1;
        public Mount_Windows(int index)
        {
            InitializeComponent();
            if (tools_location.type == "WIM")
            {
                this.Text = "Mounting WIM...";
            }
            else
            {
                this.Text = "Mounting ESD...";
            }
            index1 = index;

        }

        private void Mount_Windows_Load(object sender, EventArgs e)
        {
            
        }
        bool mounted = false;
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (mounted == false)
            {
                
                metroButton1.Enabled = false;
                //DismApi.MountImage(tools_location.location1, tools_location.location2, index1);
                try
                {
                   DismApi.Initialize(DismLogLevel.LogErrors);
                   DismApi.MountImage(tools_location.location1, tools_location.location2, index1);
                    this.Text = "Windows is mounted";
                    metroButton1.Enabled = true;
                    metroButton1.Text = "Dismount";
                    metroButton1.Refresh();
                    mounted = true;
                    DismApi.Shutdown();

                }
                catch
                {
                    MessageBox.Show("The following wim file is not successfully mounted!","Error");
                }
            }
            if (mounted == true)
            {
                metroButton1.Enabled = false;
                DismApi.Initialize(DismLogLevel.LogErrors);
                DismApi.UnmountImage(tools_location.location2, true);
                this.Text = "Windows is dismounted and saved!";
                metroButton1.Enabled = true;
                metroButton1.Text = "Mount";
                metroButton1.Refresh();
                mounted = false;
                DismApi.Shutdown();
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tools_location.location2 = fbd.SelectedPath;
                    metroTextBox1.Text = fbd.SelectedPath;
                }
            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
