using System;
using System.Windows.Forms;
using ManagedWimLib;


namespace IntegrateOS
{
    public partial class Convert_windows_type : MetroFramework.Forms.MetroForm
    {

        System.Threading.Thread x;
        public Convert_windows_type(System.Drawing.Point punct)
        {
            InitializeComponent();
            Location = punct;
            Activate();
            label4.Show();
            txtPath.Text = Tools_location.Conversion.convert_path;
            metroTextBox1.Text = Tools_location.Conversion.to_convert_path;
            x = new System.Threading.Thread(() => { Export_image(Tools_location.Conversion.convert_path, Tools_location.Conversion.to_convert_path, Tools_location.Conversion.index, Tools_location.Conversion.conversion_code); })
            { IsBackground = true };
        }

        private void Convert_Load(object sender, EventArgs e)
        {
            this.StyleManager = IntegrateOS.Themes.Generate(IntegrateOS.IntegrateOS_var.color, IntegrateOS.IntegrateOS_var.theme);
            txtPath.Theme = metroTextBox1.Theme = IntegrateOS.IntegrateOS_var.theme;
            label1.ForeColor = label6.ForeColor = IntegrateOS_var.dark == 0 ? (System.Drawing.Color.Black) : (System.Drawing.Color.White);
            Activate();
            this.Shown += new System.EventHandler(this.XShown); 
        }

        private void XShown(object sender, EventArgs e)
        {
            x.Start();
            while (x.IsAlive) { Application.DoEvents(); }
            if(x.IsAlive == false)
            {
               var dialog = MetroFramework.MetroMessageBox.Show(this, "Conversion completed!", "Conversion complete", MessageBoxButtons.OK, MessageBoxIcon.Information, IntegrateOS_var.color_t);
               if(dialog == DialogResult.OK) Moving.Form(this, new Basic_tools(Location));
            }

        }

        Wim y;
        private void Export_image(string loc1, string loc2, int index, int compression)
        {
            if(Tools_location.Conversion.convert_path_type == "Folder")
            {

            }
            if (Tools_location.Conversion.convert_path_type == "ISO")
            {

            }
            else
            {
                Wim.GlobalInit("libwim-15.dll");
                Wim x = Wim.OpenWim(loc1, 0);
                if(Tools_location.Conversion.to_convert_part_type == "SWM")
                {
                    ulong partSize = (ulong)(Tools_location.Conversion.swm_partition_type * 1024);
                    x.Split(Tools_location.Conversion.to_convert_path, partSize, WriteFlags.DEFAULT);
                }
                switch (compression)
                {
                    case 0:
                        y = Wim.CreateNewWim(CompressionType.NONE);
                        break;
                    case 1:
                        y = Wim.CreateNewWim(CompressionType.XPRESS);
                        break;
                    case 2:
                        y = Wim.CreateNewWim(CompressionType.LZMS);
                        break;
                    case 3:
                        y = Wim.CreateNewWim(CompressionType.LZX);
                        break;
                    default:
                        y = Wim.CreateNewWim(CompressionType.NONE);
                        break;
                }
                x.ExportImage(index, y, null, null, ExportFlags.DEFAULT);
                y.Write(loc2, Wim.AllImages, WriteFlags.DEFAULT, Wim.DefaultThreads);
            }
        }

    }
}
