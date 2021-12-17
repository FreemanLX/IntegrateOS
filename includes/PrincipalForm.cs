using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Security.Principal;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using IntegrateOS.Account.Settings.Themes;

namespace IntegrateOS
{
    public partial class PrincipalForm : MetroForm
    {

        public Thread check_login_user;

        public PrincipalForm(Point point)
        {
            Location = point;
            InitializeComponent();
        }


        public string[] Get_type(string code)
        {
            switch (code)
            {
                case "menu": return new string[] { "IntegrateOS Setup", "IntegrateOS Tools", "Settings" };
                case "selectos": return new string[] { "Windows", "Windows Phone", "Android", "Linux" };
                case "selectostools": return new string[] { "Windows", "Windows Phone", "Android" };
                case "selecttools": return new string[] { "Advanced tools", "Basic tools" };
                case "wbasictools": return new string[] { "Convert Windows Setup Files", "Mount Windows", "Boot to Advanced boot options" };
                case "wadvancedtools": return new string[] { "Customize Windows", "Uninstall all Windows drivers", "Capture a Windows image", "Create and Customize Windows PE", "Boot to audit mode" };
                case "aadvancedtools": return new string[] { "Reboot into Recovery mode (USB)", "Reboot into Download mode (USB)", "Reboot into bootloader (USB)", "Create a backup", "Restore a backup", "Open ADB Shell command" };
                case "abasictools": return new string[] { "Reset the data (USB)", "Install an application (USB)" };
                case "wpbasictools": return new string[] { "Reset the data (USB)", "Install an application (USB)" };
                case "wpadvancedtools": return new string[] { "Boot to download mode (USB)", "Boot to recovery mode (USB)", "Get access to full partition data (USB)", "Flash a vhd file", "Make a backup", "Restore a backup" };
                case "settings": return new string[] { "Themes", "About" };
                default:
                    return null;
            }
        }

        public MetroTile SetMetroTile(string name) => new MetroTile {StyleManager = Themes.Generate,  ActiveControl = null, Text = name, Size = new Size(194, 136), TabIndex = 0, UseSelectable = true };

        void Set_metroTiles(string code)
        {
            if(code != "menu") metroButton2.Visible = true;
            string[] titles = Get_type(code);
            for(int i = 0; i < titles.Length; i++)
            {
                MetroTile tile = SetMetroTile(titles[i]);
                tile.Click += new EventHandler(DoubleClickEvent);
                LayoutPanel.Controls.Add(tile);
            }
        }

        private void MetroButton2_Click(object sender, EventArgs e) => Go_before();

        string os_type;

        private void DoubleClickEvent(object sender, EventArgs e)
        {
            MetroTile tile_sender = (MetroTile)sender;
            switch (Data.list_of_history_codes.Last())
            {
                case "menu":
                    {
                        switch (tile_sender.Text)
                        {
                            case "IntegrateOS Setup": { Change("selectos"); metroButton2.Visible = true; break; }
                            case "IntegrateOS Tools": { Change("selectostools"); metroButton2.Visible = true; break; }
                            case "Settings": { Change("settings"); metroButton2.Visible = true; break; }
                        }
                        break;
                    }

                case "selectostools":
                    {
                        os_type = tile_sender.Text;
                        Change("selecttools");
                        break;
                    }
                case "selectos":
                    if(tile_sender.Text == "Windows") Moving.Form(this, new IntegrateOS.SelectInstallationMode(Location));
                    break;

                case "selecttools":
                    {
                        if (tile_sender.Text == "Advanced tools")
                            switch (os_type)
                            {
                                case "Windows": { Change("wadvancedtools"); break; }
                                case "Windows Phone": { Change("wpadvancedtools"); break; }
                                case "Android": { Change("aadvancedtools"); break; }
                            }
                        else
                            switch (os_type)
                            {
                                case "Windows": { Change("wbasictools"); break; }
                                case "Windows Phone": { Change("wpbasictools"); break; }
                                case "Android": { Change("abasictools"); break; }
                            }
                        break;
                    }

                case "wbasictools":
                    switch (tile_sender.Text)
                    {
                        case "Convert Windows Setup Files":
                            Moving.Form(this, new IntegrateOS.SelectInstallationMode(Location, 2));
                            break;
                        case "Mount Windows":
                            Moving.Form(this, new IntegrateOS.SelectInstallationMode(Location, 1));
                            break;
                        case "Boot to Advanced boot options":
                            if (MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to see the Advanced options of Windows ?", 
                                "Booting to the Advanced options of Windows", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                                (int)Themes.MetroColor) == DialogResult.Yes)
                                GenerateProcess.Static_BackgroundWorker_Process("shutdown.exe -r -o -t 0", "cmd.exe");               
                            break;
                    }
                    break;

                case "wadvancedtools":
                    switch (tile_sender.Text)
                    {
                        case "Customize Windows": break;
                        case "Uninstall all Windows drivers":
                            DialogResult wsysprep = MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to unistall driveres?\nYou have a very high risk of loosing your data!", "Booting to the Audit mode", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, (int)Themes.MetroColor);
                            if (wsysprep == DialogResult.Yes)
                            {
                                GenerateProcess x = new GenerateProcess();
                                string path = Environment.GetFolderPath(Environment.SpecialFolder.System);

                                string final = "start " + path + "\\sysprep\\sysprep.exe /generalize /shutdown";
                                x.BackgroundWorker_Process(final);
                            }
                            break;
                        case "Capture a Windows image": break;
                        case "Create and Customize Windows PE": break;
                        case "Boot to audit mode":
                            DialogResult waudit_go = MetroFramework.MetroMessageBox.Show(this, "Are you sure you want to boot to audit?\nBy booting to audit, you have risk of loosing your data!", "Booting to the Audit mode", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, (int)Themes.MetroColor);
                            if (waudit_go == DialogResult.Yes)
                            {
                                GenerateProcess x = new GenerateProcess();
                                string path = Environment.GetFolderPath(Environment.SpecialFolder.System);

                                string final = "start " + path + "\\sysprep\\sysprep.exe /audit /reboot";
                                x.BackgroundWorker_Process(final);
                            }
                            break;
                    }
                    break;

                case "aadvancedtools":
                    switch (tile_sender.Text)
                    {
                        case "Reboot into Recovery mode (USB)":
                            break;
                        case "Reboot into Download mode (USB)":
                            break;
                        case "Reboot into bootloader (USB)":
                            break;
                        case "Create a backup":
                            break;
                        case "Restore a backup":
                            break;
                        case "Open ADB Shell command":
                            break;

                    }
                    break;

                case "abasictools":
                case "wpbasictools":
                    switch (tile_sender.Text)
                    {
                        case "Reset the data(USB)": break;
                        case "Install an application (USB)": break;
                    }
                    break;

            

                case "wpadvancedtools":
                    switch (tile_sender.Text)
                    {
                        case "Boot to download mode (USB)":
                            break;
                        case "Boot to recovery mode (USB)":
                            break;
                        case "Get access to full partition data (USB)":
                            break;
                        case "Flash a ffu file":
                            break;
                        case "Make a backup":
                            break;
                        case "Restore the backup":
                            break;
                    }
                    break;

                case "settings":
                    switch (tile_sender.Text)
                    {
                        case "Themes":
                            Moving.Form(this, new Settings(Location));
                            break;

                        case "About":
                            Moving.Form(this, new Licenses(Location));
                            break;
                    }
                    break;
            }
        }

        
        public void Check_if_logged()
        {

            while (true)
            {
                if (Data.user != null)
                {

                    Invoke(new Action(() => { 
                        label4.Text = Data.user.Email;
                        label3.Text = "Sign out";
                        label4.Visible = true;
                    }));
                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        label3.Text = "Login";
                        label4.Visible = false;
                    }));
                }
                Thread.Sleep(100); ///for processor
            }
        }

        private void Go_before()
        {
            LayoutPanel.Controls.Clear();
            LayoutPanel.Refresh();
            Data.list_of_history_codes.Remove(Data.list_of_history_codes.Last());
            if(Data.list_of_history_codes.Last() == "menu") metroButton2.Visible = false;
            Set_metroTiles(Data.list_of_history_codes.Last());
        }

        private void Change(string code)
        {
            LayoutPanel.Controls.Clear();
            LayoutPanel.Refresh();
            Data.list_of_history_codes.Add(code);
            Set_metroTiles(code);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                check_login_user.Abort();
            }
            catch { }
            base.OnClosing(e);
        }

        private void Default_form_Load(object sender, EventArgs e)
        {
            Text = "IntegrateOS 0.3.0.0_alpha";
            if (!IsElevated)
            {
                Process.Start(new ProcessStartInfo(Process.GetCurrentProcess().MainModule.FileName) { Verb = "runas", Arguments = "restart" });
                Application.Exit();
            }
            if (GetOSInfo() == 0 && Data.verify_windows_boolean == 1)
            {
                MessageBox.Show(this, "You're running an old version of Windows. Some functions will be disabled!", "IntegrateOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Data.verify_windows_boolean = 0;
            }
            check_login_user = new Thread(() => Check_if_logged());
            check_login_user.Start();
            StyleManager = Themes.Generate;
            label4.ForeColor = label3.ForeColor = (Themes.MetroTheme == MetroFramework.MetroThemeStyle.Dark) ? Color.White : Color.Black;
            metroButton2.BackgroundImage = Themes.Icon_Style;
            metroButton2.BackgroundImageLayout = ImageLayout.Center;
            metroButton2.Visible = false;
            Set_metroTiles(Data.list_of_history_codes.Last());
        }

        public bool IsElevated => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

        static int GetOSInfo()
        {
            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;
            if (os.Platform == PlatformID.Win32Windows && (vs.Minor == 0 || vs.Minor == 10 || vs.Minor == 90)) return 0;
            if (os.Platform == PlatformID.Win32NT)
            {
                if (vs.Major >= 3 && vs.Major <= 5 || (vs.Major == 6 && (vs.Minor == 1 || vs.Minor == 0))) return 0;
                return 1;
            }
            return -1;
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            if (label4.Visible == false)
            {
                new Login().ShowDialog();
            }
            else
            {
                if(MessageBox.Show("Do you really want to sign out? ", "Sign out", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Data.user = null;
                }
            }
        }
    }
}
