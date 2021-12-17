using System;
using System.Threading;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class LoadingResponse : MetroFramework.Forms.MetroForm
    {
        Thread async_thread;
        public LoadingResponse(Thread async_thread, string title)
        {
            InitializeComponent();
            this.async_thread = async_thread;
            Text = title;
            BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.Fixed3D;
        }

        private void Async_Processing_Load(object sender, EventArgs e)
        {
            Theme = Themes.MetroTheme;
            Style = Themes.MetroColor;
        }

        /// <summary>
        /// Thread echivalat cu async (promisiune)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Async_Processing_Shown(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.ForeColor = GenerateColors.Generate((int) Themes.MetroColor);
            progressBar1.Refresh();
            progressBar1.MarqueeAnimationSpeed = 30;
            try
            {
                if (async_thread == null) throw new Exception();
                async_thread.Start();
                async_thread.IsBackground = true;
                while (async_thread.IsAlive)
                {
                    Application.DoEvents();
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show("Unable to run the selected process. Message: " + exception.Message + ". Code:" + exception.HResult.ToString());
            }
            finally
            {
                Close();
            }
        }
    }
}
