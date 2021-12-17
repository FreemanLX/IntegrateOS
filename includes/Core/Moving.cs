using System.Windows.Forms;

namespace IntegrateOS
{
    public static class MessageBox
    {
        public static DialogResult Show(string data, string title = "Error", MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK, MessageBoxIcon messageBoxIcon = MessageBoxIcon.None)
        {
            Form text = new Form();
            text.Size = new System.Drawing.Size(data.Length * 10, text.Height); 
            text.Location = new System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Width - text.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - text.Height) / 2);

            return Show(text, data, title, messageBoxButtons, messageBoxIcon);
        }
        public static DialogResult Show(Form who, 
            string data, 
            string title, 
            MessageBoxButtons messageBoxButtons, 
            MessageBoxIcon messageBoxIcon) => MetroFramework.MetroMessageBox.Show(who, 
                data, title, messageBoxButtons, 
                messageBoxIcon, (int)Themes.MetroColor);
    }

    public static class Moving
    {
        /// <summary>
        /// Change the form to another form in a safer way
        /// </summary>
        /// <param name="oldform">From old form</param>
        /// <param name="newform">To new form</param>        
        public static void Form(Form oldform, Form newform)
        {
            oldform.Hide();
            newform.ShowDialog();
            oldform.Dispose();
        }
    }
}
