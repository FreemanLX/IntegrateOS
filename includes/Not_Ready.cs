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

        private void Button1_Click(object sender, EventArgs e) => Moving.Form(this, new Default_form(Location));
    }
}
