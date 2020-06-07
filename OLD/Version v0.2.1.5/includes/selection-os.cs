using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class selection_os : MetroFramework.Forms.MetroForm
    {
        public selection_os()
        {
            InitializeComponent();
        }

        private void selection_os_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var t = new WindowsFormsApplication2.Form5();
            t.Show();
            this.Hide();
        }
    }
}
