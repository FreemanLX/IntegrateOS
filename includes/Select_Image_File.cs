using System;
using System.Windows.Forms;

namespace IntegrateOS
{
    public partial class Select_Image_File : MetroFramework.Forms.MetroForm
    {
        public Select_Image_File(string[] data, System.Drawing.Point punct)
        {
            InitializeComponent();
            Location = punct;
            foreach (string pointer in data) checkedListBox1.Items.Add(pointer);
        }

        private void Select_Image_File_Load(object sender, EventArgs e)
        {
            this.Theme = IntegrateOS_var.theme;
            this.Style = IntegrateOS.IntegrateOS_var.color;

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

        private void button1_Click(object sender, EventArgs e)
        {
            Moving.Form(this, new IntegrateOS.Select_installation(Location));
        }

        private void checkedListBox1_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);

            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IntegrateOS.Temporary_I.locatie = checkedListBox1.Items[checkedListBox1.SelectedIndex].ToString();
            Moving.Form(this, new IntegrateOS.Select_Windows_Edition(Location));
        }
    }
}
