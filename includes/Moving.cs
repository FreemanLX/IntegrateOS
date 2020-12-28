using System;
using System.Windows.Forms;

namespace IntegrateOS
{

    public static class OnClose
    {
        public static void Form(Form form, System.Windows.Forms.FormClosingEventArgs e)
        {
            var dialog = MetroFramework.MetroMessageBox.Show(form, "Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, IntegrateOS.IntegrateOS_var.color_t);
            if (dialog == DialogResult.Yes) Environment.Exit(0);
            else e.Cancel = true;
        }

    }

    public static class Saving
    {
        public static void Data()
        {
            string[] complete = new string[3];
            complete[0] = IntegrateOS_var.dark.ToString();
            complete[1] = IntegrateOS_var.color_t.ToString();
            complete[2] = IntegrateOS_var.program_mode.ToString();
            if (System.IO.File.Exists("Settings\\user.dat")) System.IO.File.WriteAllLines("Settings\\user.dat", complete);
            else
            {
                if (!System.IO.Directory.Exists("Settings")) System.IO.Directory.CreateDirectory("Settings");
                using (System.IO.StreamWriter sw = System.IO.File.CreateText("Settings\\user.dat"))
                {
                    sw.WriteLine(complete[0]);
                    sw.WriteLine(complete[1]);
                    sw.WriteLine(complete[2]);
                }
            }
        }

    }

    public static class MessageBox
    {
        public static DialogResult Show(string data, string title = "Error", MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK, MessageBoxIcon messageBoxIcon = MessageBoxIcon.None)
        {
            System.Windows.Forms.Form text = new System.Windows.Forms.Form();
            return Message.Show(text, data, title, messageBoxButtons, messageBoxIcon);
        }
    }

    public static class Message
    {

        public static DialogResult Show(System.Windows.Forms.Form who, string data, string title, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            return MetroFramework.MetroMessageBox.Show(who, data, title, messageBoxButtons, messageBoxIcon, IntegrateOS_var.color_t);
        }
    }

    public static class Moving
    {
        /// <summary>
        /// Change the form to another form in the safe way
        /// </summary>
        /// <param name="form1">From form1</param>
        /// <param name="form2">To form2</param> 
       
        public static void Form(System.Windows.Forms.Form form1, System.Windows.Forms.Form form2)
        {
            form1.Hide();
            form2.ShowDialog();
            form1.Dispose();
        }
    }
}
