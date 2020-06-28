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
    public partial class Bcdedit_name : MetroFramework.Forms.MetroForm
    {
        public Bcdedit_name()
        {
            InitializeComponent();
        }

        private void Bcdedit_name_Load(object sender, EventArgs e)
        {

        }

        string full;

        public string get()
        {
            return full;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length < 1)
            {
                full = "Windows";
            }
            else
            {
                full = textBox1.Text;
            }
            this.Close();

        }
    }
}
