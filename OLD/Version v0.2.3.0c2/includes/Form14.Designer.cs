namespace WindowsFormsApplication2
{
    partial class Form14
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form14));
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.button3 = new MetroFramework.Controls.MetroButton();
            this.button2 = new MetroFramework.Controls.MetroButton();
            this.txtPath = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(620, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Browse";
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(34, 190);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 26);
            this.button3.TabIndex = 9;
            this.button3.Text = "Back";
            this.button3.UseSelectable = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(634, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 26);
            this.button2.TabIndex = 10;
            this.button2.Text = "Next";
            this.button2.UseSelectable = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // txtPath
            // 
            // 
            // 
            // 
            this.txtPath.CustomButton.Image = null;
            this.txtPath.CustomButton.Location = new System.Drawing.Point(538, 1);
            this.txtPath.CustomButton.Name = "";
            this.txtPath.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.txtPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPath.CustomButton.TabIndex = 1;
            this.txtPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPath.CustomButton.UseSelectable = true;
            this.txtPath.CustomButton.Visible = false;
            this.txtPath.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtPath.Lines = new string[] {
        "Click browse to select"};
            this.txtPath.Location = new System.Drawing.Point(34, 109);
            this.txtPath.MaxLength = 32767;
            this.txtPath.Name = "txtPath";
            this.txtPath.PasswordChar = '\0';
            this.txtPath.ReadOnly = true;
            this.txtPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPath.SelectedText = "";
            this.txtPath.SelectionLength = 0;
            this.txtPath.SelectionStart = 0;
            this.txtPath.ShortcutsEnabled = true;
            this.txtPath.Size = new System.Drawing.Size(570, 33);
            this.txtPath.TabIndex = 12;
            this.txtPath.Text = "Click browse to select";
            this.txtPath.UseSelectable = true;
            this.txtPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPath.SizeChanged += new System.EventHandler(this.txtPath_SizeChanged);
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            this.txtPath.Click += new System.EventHandler(this.txtPath_Click);
            // 
            // Form14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(786, 237);
            this.ControlBox = false;
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Form14";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Select %type%";
            this.Load += new System.EventHandler(this.Form14_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroButton button3;
        private MetroFramework.Controls.MetroButton button2;
        private MetroFramework.Controls.MetroTextBox txtPath;
    }
}