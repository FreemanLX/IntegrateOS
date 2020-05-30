using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsSetup
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        
        private void Form4_Load(object sender, EventArgs e)
        {
            
         }




        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
