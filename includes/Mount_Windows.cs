using System;
using System.Threading;
using System.Windows.Forms;
using static IntegrateOS.Algorithms.Dism_Methods;


namespace IntegrateOS
{

    public partial class Mount_Windows : MetroFramework.Forms.MetroForm
    {
        int index1;
        public Mount_Windows(System.Drawing.Point punct, int index)
        {
            InitializeComponent();
            Location = punct;
            index1 = index;
        }


        public void SetTheme()
        {
            foreach (Control control in this.Controls)
            {
                if ((control is Label) || (control is CheckBox))
                {
                    control.ForeColor = Themes.GenerateTheme(!Themes.MetroTheme);
                }
                
            }
        }

        private void Mount_Windows_Load(object sender, EventArgs e)
        {
            StyleManager = Themes.Generate;
            SetTheme();
            Back.BackColor = Themes.GenerateTheme(Themes.MetroTheme);
            Back.ForeColor = Themes.GenerateTheme(!Themes.MetroTheme);
            Back.BackgroundImage = Themes.Icon_Style;
            Back.BackgroundImageLayout = ImageLayout.Center;
        }

        bool mounted = false;
        int pass;
        private void Select_folder_path_to_mount(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    ToolsData.Mount.path_to_be_mounted = fbd.SelectedPath;
                    label2.Text = "Mount directory: " + fbd.SelectedPath;
                }
            }
        }

        private void Reselecting_image_path_Click(object sender, EventArgs e) => Moving.Form(this, new Select_installation(Location, 1));


        public bool Mount()
        {
            if (!DismMountImage(ToolsData.Mount.path_to_mount, ToolsData.Mount.path_to_be_mounted, (uint)index1, checkBox1.Checked))
            {
                Invoke(new Action(() =>
                MetroFramework.MetroMessageBox.Show(this, "Error mounting.",
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error, (int)Themes.MetroColor)));
                return false;
            }
            return true;
        }

        public bool Unmount()
        {
            if (DismUnmountImage(ToolsData.Mount.path_to_be_mounted, checkBox1.Checked) == false)
            {
                Invoke(new Action(() =>
                MetroFramework.MetroMessageBox.Show(this, "Error unmounting.",
                "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error, (int)Themes.MetroColor)));
                return false;
            }
            return true;
        }

        private void MountUnmount_Click(object sender, EventArgs e)
        {
            pass = 0;
            if (mounted == false && pass == 0)
            {
                Thread mount_thread = new Thread(() =>
                {
                    if (Mount())
                    {
                        mounted = true;
                        Invoke(new Action(() =>
                        {
                            label8.Text = "Unmount image file";
                            Text = "Mount Windows Image File. Status: Mounted";
                        }));
                        pass = 1;

                    }
                });
                new Async_Processing(mount_thread, "Mounting selected Windows Image File").ShowDialog();
            }
            if (mounted == true && pass == 0)
            {
                    Thread unmount_thread = new Thread(() =>
                    {
                        if (Unmount())
                        {
                            mounted = false;
                            pass = 1;
                            Invoke(new Action(() => {
                                label8.Text = "Mount image file";
                                Text = "Mount Windows Image File. Status: Unmounted";
                            }));
                        }
                    });
            
                new Async_Processing(unmount_thread, "Unmounting selected Windows Image File").ShowDialog();
            }
        }

        private void BrowseFolder_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ToolsData.Mount.path_to_mount, "Selected path");
        }

        private void Back_Click(object sender, EventArgs e) => Moving.Form(this, new Default_form(Location));
    }
}
