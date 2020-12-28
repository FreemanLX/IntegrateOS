using System;
using System.Drawing;

namespace IntegrateOS
{
    public partial class Not_Ready : MetroFramework.Forms.MetroForm
    {
        public Not_Ready(Point punct)
        {
            InitializeComponent();
            Location = punct;
        }

        private void Not_Ready_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new Menu("IntegrateOS Full Version: v0.2.8.5_betaC1", Location));
        }
    }
}
