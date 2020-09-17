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
    public partial class DiskUtils_License : MetroFramework.Forms.MetroForm
    {
        public DiskUtils_License()
        {
            InitializeComponent();
        }

        private void DiskUtils_License_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = new WindowsFormsApplication2.Form2();
            x.Show();
            this.Hide();
        }
    }
}
