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
    public partial class Command_Prompt : MetroFramework.Forms.MetroForm
    {
        public Command_Prompt(System.Drawing.Point local)
        {
            Location = local;
            InitializeComponent();
        }

        private void Command_Promp_Load(object sender, EventArgs e)
        {
            StyleManager = Themes.Generate(IntegrateOS_var.color, IntegrateOS_var.theme);
            textBox1.BackColor = IntegrateOS_var.dark == 0 ? Color.White : Color.Black;
            label1.ForeColor = textBox1.ForeColor  = IntegrateOS_var.dark == 0 ? Color.Black : Color.White;
        }


        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string s = textBox1.Text;
                textBox1.Clear();
                richTextBox1.AppendText("IntegrateOS@Beta> " + s + "\n");
                switch (s)
                {
                    case "help":
                        richTextBox1.AppendText("\nThe commands are:\n");
                        richTextBox1.AppendText("\nhelp - you see the available commands");
                        richTextBox1.AppendText("\nexit - you will leave the form\n");
                        break;

                    case "exit":
                        Moving.Form(this, new Basic_tools(Location));
                        break;

                    case "clear":
                        richTextBox1.Clear();
                        break;

                    default:
                        List<string> list = new List<string>();

                        System.Threading.Thread t = new System.Threading.Thread(() =>
                        {
                            CMD_Process_Class x = new CMD_Process_Class();
                            x.Process_CMD(s);
                            list = x.Get();
                            x.Dispose();
                        });
                        t.Start();
                        while (t.IsAlive == true)
                        {

                        }
                        for(int i = 0; i<list.Count; i++)
                        {
                            richTextBox1.AppendText(list[i]);
                        }
                        break;

                }
            }
        }

    }
}
