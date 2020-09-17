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
            this.txtPath = new MetroFramework.Controls.MetroTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(634, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Browse";
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtPath
            // 
            // 
            // 
            // 
            this.txtPath.CustomButton.Image = null;
            this.txtPath.CustomButton.Location = new System.Drawing.Point(561, 1);
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
            this.txtPath.Location = new System.Drawing.Point(23, 139);
            this.txtPath.MaxLength = 32767;
            this.txtPath.Name = "txtPath";
            this.txtPath.PasswordChar = '\0';
            this.txtPath.ReadOnly = true;
            this.txtPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPath.SelectedText = "";
            this.txtPath.SelectionLength = 0;
            this.txtPath.SelectionStart = 0;
            this.txtPath.ShortcutsEnabled = true;
            this.txtPath.Size = new System.Drawing.Size(593, 33);
            this.txtPath.TabIndex = 12;
            this.txtPath.Text = "Click browse to select";
            this.txtPath.UseSelectable = true;
            this.txtPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPath.SizeChanged += new System.EventHandler(this.txtPath_SizeChanged);
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            this.txtPath.Click += new System.EventHandler(this.txtPath_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(657, 546);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 40);
            this.button4.TabIndex = 13;
            this.button4.Text = "Next";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(23, 546);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 40);
            this.button5.TabIndex = 14;
            this.button5.Text = "Back";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtPath);
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
        private MetroFramework.Controls.MetroTextBox txtPath;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}