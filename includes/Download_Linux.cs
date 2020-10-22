using System;
using System.Net;
using System.Windows.Forms;
using MetroFramework;



namespace IntegrateOS
{
    public partial class Download_Linux : MetroFramework.Forms.MetroForm
    {
        void download(string link, string type)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                        wc.DownloadFileAsync(
                        new System.Uri(link),
                        "Packages\\" + type + ".iso"
                );
                    
            }
            }
        
        bool file_exist_message(string file)
        {
            if (System.IO.File.Exists(file))
            {
                DialogResult result = MetroMessageBox.Show(this, "Do you want to overwrite the file: " + file + "?", "Overwrite " + file, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    return true;
                }
                
                return false;
            }
            return true;
        }
        public Download_Linux()
        {
            InitializeComponent();
        }


        public Download_Linux(string s, int version)
        {
            InitializeComponent();
            label2.Text = s + " " + version.ToString() + " BITS";
            label2.Update();
            if (version == 64)
            {
                if (s == "Ubuntu")
                {
                    if(file_exist_message("Ubuntu64") == true)
                    download("https://mirrors.chroot.ro/ubuntu-releases/20.04/ubuntu-20.04-desktop-amd64.iso", "Ubuntu64");
                }
                if (s == "CentOS")
                {
                    if (file_exist_message("CentOS32_64") == true)
                        download("http://mirrors.primetelecom.ro/centos/8.1.1911/isos/x86_64/CentOS-8.1.1911-x86_64-dvd1.iso", "CentOS32_64");
                }
                if (s == "Debian")
                {
                    if (file_exist_message("Debian64") == true)
                        download("https://saimei.ftp.acc.umu.se/debian-cd/current/amd64/iso-cd/debian-10.4.0-amd64-netinst.iso", "Debian64");
                }
                if (s == "Fedora")
                {
                    if (file_exist_message("Fedora64") == true)
                        download("http://mirrors.chroot.ro/fedora/linux/releases/32/Workstation/aarch64/images/Fedora-Workstation-32-1.6.aarch64.raw.xz", "Fedora64");
                }
                if (s == "Xubuntu")
                {
                    if (file_exist_message("Xubuntu64") == true)
                        download("http://mirror.us.leaseweb.net/ubuntu-cdimage/xubuntu/releases/20.04/release/xubuntu-20.04-desktop-amd64.iso", "Xubuntu64");
                }
                if (s == "Lubuntu")
                {
                    if (file_exist_message("Lubuntu64") == true)
                        download("http://cdimage.ubuntu.com/lubuntu/releases/18.04/release/lubuntu-18.04-alternate-amd64.iso", "Lubuntu64");
                    
                }
                if (s == "Linux Mint")
                {
                    if (file_exist_message("Linux_Mint64") == true)
                        download("http://mirrors.evowise.com/linuxmint/stable/19.3/linuxmint-19.3-cinnamon-64bit.iso", "Linux_Mint64");

                }
                if(s == "OpenBSD")
                {
                    if (file_exist_message("OpenBSD") == true)
                        download("https://cdn.openbsd.org/pub/OpenBSD/6.7/amd64/install67.iso", "OpenBSD64");
                }
            }
            if (version == 32)
            {
                if (s == "Ubuntu")
                {
                    if (file_exist_message("Ubuntu32") == true)
                        download("https://releases.ubuntu.com/16.04/ubuntu-16.04.6-desktop-i386.iso", "Ubuntu32");
                }
                if (s == "CentOS")
                {
                    if (file_exist_message("CentOS32_64") == true)
                        download("http://mirrors.primetelecom.ro/centos/8.1.1911/isos/x86_64/CentOS-8.1.1911-x86_64-dvd1.iso", "CentOS32_64");
                }
                if (s == "Debian")
                {
                    if (file_exist_message("Debian32") == true)
                        download("https://gensho.ftp.acc.umu.se/debian-cd/current/i386/iso-cd/debian-10.4.0-i386-netinst.iso", "Debian32");
                }
                if (s == "Fedora")
                {
                    if (file_exist_message("Fedora32") == true)
                        download("http://mirrors.chroot.ro/fedora/linux/releases/32/Workstation/x86_64/iso/Fedora-Workstation-Live-x86_64-32-1.6.iso", "Fedora32");
                }
                if (s == "Xubuntu")
                {
                    if (file_exist_message("Xubuntu32") == true)
                        download("http://mirror.us.leaseweb.net/ubuntu-cdimage/xubuntu/releases/18.04/release/xubuntu-18.04-desktop-i386.iso", "Xubuntu32");
                }
                if (s == "Lubuntu")
                {
                    if (file_exist_message("Lubuntu32") == true)
                        download("http://cdimage.ubuntu.com/lubuntu/releases/18.04/release/lubuntu-18.04-alternate-i386.iso", "Lubuntu32");
                }
                if (s == "Linux Mint")
                {
                    if (file_exist_message("Linux_Mint32") == true)
                        download("http://mirrors.evowise.com/linuxmint/stable/19.3/linuxmint-19.3-cinnamon-32bit.iso", "Linux_Mint32");
                }
                if (s == "OpenBSD")
                {
                    if (file_exist_message("OpenBSD32") == true)
                        download("https://cdn.openbsd.org/pub/OpenBSD/6.7/i386/install67.iso", "OpenBSD32");
                }
            }

        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            int MB = 1024 * 1024;
            label4.Text = e.BytesReceived / MB + "MB of " + e.TotalBytesToReceive / MB + " MB";
            label4.Refresh();
            metroProgressBar1.Value = e.ProgressPercentage;
            if (metroProgressBar1.Value == 100)
            {
                var x = new WindowsFormsApplication2.Form11(1);
                x.Show();
                this.Hide();
            }
        }


        private void Download_Linux_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.generate(IntegrateOS.user_settings.color1, IntegrateOS.user_settings.theme);
            metroProgressBar1.Theme = IntegrateOS.user_settings.theme;
            metroProgressBar1.Style = IntegrateOS.user_settings.color1;
            if (IntegrateOS.user_settings.dark == 0)
            {
                this.label1.ForeColor = System.Drawing.Color.Black;
                this.label2.ForeColor = System.Drawing.Color.Black;
                this.label3.ForeColor = System.Drawing.Color.Black;
                this.label4.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.label1.ForeColor = System.Drawing.Color.White;
                this.label2.ForeColor = System.Drawing.Color.White;
                this.label3.ForeColor = System.Drawing.Color.White;
                this.label4.ForeColor = System.Drawing.Color.White;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
