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
    public partial class Select_Image_File : MetroFramework.Forms.MetroForm
    {
        public Select_Image_File(string[] data, System.Drawing.Point punct)
        {
            InitializeComponent();
            Location = punct;
            foreach (string pointer in data)
            {
                checkedListBox1.Items.Add(pointer);
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                var dialog = MetroFramework.MetroMessageBox.Show(this, "Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, IntegrateOS.IntegrateOS_var.color_t);
                if (dialog == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                if (dialog == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            catch { }
        }

        private void Select_Image_File_Load(object sender, EventArgs e)
        {
            this.Theme = IntegrateOS_var.theme;
            this.Style = IntegrateOS.IntegrateOS_var.color1;

            if(IntegrateOS_var.dark == 1)
            {
                checkedListBox1.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Dark);
                checkedListBox1.ForeColor = System.Drawing.Color.White;
            }
            else 
            {
                checkedListBox1.BackColor = MetroFramework.Drawing.MetroPaint.BackColor.Form(MetroFramework.MetroThemeStyle.Light);
                checkedListBox1.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = new WindowsFormsApplication2.Form5(Location);
            x.Show();
            this.Hide();
        }

        private void checkedListBox1_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);

            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowsSetup.Variabile.locatie = checkedListBox1.Items[checkedListBox1.SelectedIndex].ToString();
            var x = new WindowsFormsApplication2.Form12(Location);
            x.Show();
            this.Hide();
            
        }
    }
}
