using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;



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
        public Download_Linux(string s, int version)
        {
            InitializeComponent();
            label2.Text = s + " " + version.ToString() + " BITS";
            label2.Update();
            if (version == 64)
            {
                if (s == "Ubuntu")
                {
                    download("https://mirrors.chroot.ro/ubuntu-releases/20.04/ubuntu-20.04-desktop-amd64.iso", "Ubuntu64");
                }
                if (s == "CentOS")
                {
                    download("http://mirrors.primetelecom.ro/centos/8.1.1911/isos/x86_64/CentOS-8.1.1911-x86_64-dvd1.iso", "CentOS32_64");
                }
                if (s == "Debian")
                {
                    download("https://saimei.ftp.acc.umu.se/debian-cd/current/amd64/iso-cd/debian-10.4.0-amd64-netinst.iso", "Debian64");
                }
                if (s == "Fedora")
                {
                    download("http://mirrors.chroot.ro/fedora/linux/releases/32/Workstation/aarch64/images/Fedora-Workstation-32-1.6.aarch64.raw.xz", "Fedora64");
                }
                if (s == "Xubuntu")
                {
                    download("http://mirror.us.leaseweb.net/ubuntu-cdimage/xubuntu/releases/20.04/release/xubuntu-20.04-desktop-amd64.iso", "Xubuntu64");
                }
                if (s == "Lubuntu")
                {
                    download("http://cdimage.ubuntu.com/lubuntu/releases/18.04/release/lubuntu-18.04-alternate-amd64.iso", "Lubuntu64");
                    
                }
                if (s == "Linux Mint")
                {
                    download("http://mirrors.evowise.com/linuxmint/stable/19.3/linuxmint-19.3-cinnamon-64bit.iso", "Linux_Mint64");

                }
                if(s == "OpenBSD")
                {
                    download("https://cdn.openbsd.org/pub/OpenBSD/6.7/amd64/install67.iso", "OpenBSD64");
                }
            }
            if (version == 32)
            {
                if (s == "Ubuntu")
                {
                    download("https://releases.ubuntu.com/16.04/ubuntu-16.04.6-desktop-i386.iso", "Ubuntu32");
                }
                if (s == "CentOS")
                {
                    download("http://mirrors.primetelecom.ro/centos/8.1.1911/isos/x86_64/CentOS-8.1.1911-x86_64-dvd1.iso", "CentOS32_64");
                }
                if (s == "Debian")
                {
                    download("https://gensho.ftp.acc.umu.se/debian-cd/current/i386/iso-cd/debian-10.4.0-i386-netinst.iso", "Debian32");
                }
                if (s == "Fedora")
                {
                    download("http://mirrors.chroot.ro/fedora/linux/releases/32/Workstation/x86_64/iso/Fedora-Workstation-Live-x86_64-32-1.6.iso", "Fedora32");
                }
                if (s == "Xubuntu")
                {
                    download("http://mirror.us.leaseweb.net/ubuntu-cdimage/xubuntu/releases/18.04/release/xubuntu-18.04-desktop-i386.iso", "Xubuntu32");
                }
                if (s == "Lubuntu")
                {
                    download("http://cdimage.ubuntu.com/lubuntu/releases/18.04/release/lubuntu-18.04-alternate-i386.iso", "Lubuntu32");
                }
                if (s == "Linux Mint")
                {
                    download("http://mirrors.evowise.com/linuxmint/stable/19.3/linuxmint-19.3-cinnamon-32bit.iso", "Linux_Mint32");
                }
                if (s == "OpenBSD")
                {
                    download("https://cdn.openbsd.org/pub/OpenBSD/6.7/i386/install67.iso", "OpenBSD32");
                }
            }

            if(metroProgressBar1.Value == 100)
            {
                var x = new WindowsFormsApplication2.Form11(1);
                x.Show();
                this.Hide();
            }

        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            label4.Text = e.ProgressPercentage.ToString() + " %";
            label4.Refresh();
            metroProgressBar1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 100)
            {
                var x = new WindowsFormsApplication2.Form11(1);
                x.Show();
                this.Hide();
            }
        }


        private void Download_Linux_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
