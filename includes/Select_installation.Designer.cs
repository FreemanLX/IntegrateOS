namespace IntegrateOS
{
    partial class Select_installation
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
            this.Folder = new MetroFramework.Controls.MetroTile();
            this.DVD = new MetroFramework.Controls.MetroTile();
            this.SWM = new MetroFramework.Controls.MetroTile();
            this.ESD = new MetroFramework.Controls.MetroTile();
            this.WIM = new MetroFramework.Controls.MetroTile();
            this.Path = new MetroFramework.Controls.MetroTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Conversion_Code = new MetroFramework.Controls.MetroComboBox();
            this.Conversion_text = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Folder
            // 
            this.Folder.ActiveControl = null;
            this.Folder.Location = new System.Drawing.Point(239, 217);
            this.Folder.Name = "metroTile5";
            this.Folder.Size = new System.Drawing.Size(194, 136);
            this.Folder.TabIndex = 24;
            this.Folder.Text = "Folder";
            this.Folder.UseSelectable = true;
            this.Folder.Click += new System.EventHandler(this.Folder_Click);
            // 
            // DVD
            // 
            this.DVD.ActiveControl = null;
            this.DVD.Location = new System.Drawing.Point(39, 217);
            this.DVD.Name = "metroTile4";
            this.DVD.Size = new System.Drawing.Size(194, 136);
            this.DVD.TabIndex = 23;
            this.DVD.Text = "DVD";
            this.DVD.UseSelectable = true;
            this.DVD.Click += new System.EventHandler(this.DVD_Click);
            // 
            // SWM
            // 
            this.SWM.ActiveControl = null;
            this.SWM.Location = new System.Drawing.Point(439, 75);
            this.SWM.Name = "metroTile3";
            this.SWM.Size = new System.Drawing.Size(194, 136);
            this.SWM.TabIndex = 22;
            this.SWM.Text = "SWM";
            this.SWM.UseSelectable = true;
            this.SWM.Click += new System.EventHandler(this.SWM_Click);
            // 
            // ESD
            // 
            this.ESD.ActiveControl = null;
            this.ESD.Location = new System.Drawing.Point(239, 75);
            this.ESD.Name = "metroTile2";
            this.ESD.Size = new System.Drawing.Size(194, 136);
            this.ESD.TabIndex = 21;
            this.ESD.Text = "ESD";
            this.ESD.UseSelectable = true;
            this.ESD.Click += new System.EventHandler(this.ESD_Click);
            // 
            // WIM
            // 
            this.WIM.ActiveControl = null;
            this.WIM.Location = new System.Drawing.Point(39, 75);
            this.WIM.Name = "metroTile1";
            this.WIM.Size = new System.Drawing.Size(194, 136);
            this.WIM.TabIndex = 20;
            this.WIM.Text = "WIM";
            this.WIM.UseSelectable = true;
            this.WIM.UseTileImage = true;
            this.WIM.Click += new System.EventHandler(this.WIM_Click);
            // 
            // Path
            // 
            this.Path.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.Path.CustomButton.Image = null;
            this.Path.CustomButton.Location = new System.Drawing.Point(561, 1);
            this.Path.CustomButton.Name = "";
            this.Path.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.Path.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Path.CustomButton.TabIndex = 1;
            this.Path.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Path.CustomButton.UseSelectable = true;
            this.Path.CustomButton.Visible = false;
            this.Path.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.Path.Lines = new string[] {
        "Click browse to select"};
            this.Path.Location = new System.Drawing.Point(39, 437);
            this.Path.MaxLength = 32767;
            this.Path.Name = "txtPath";
            this.Path.PasswordChar = '\0';
            this.Path.ReadOnly = true;
            this.Path.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Path.SelectedText = "";
            this.Path.SelectionLength = 0;
            this.Path.SelectionStart = 0;
            this.Path.ShortcutsEnabled = true;
            this.Path.Size = new System.Drawing.Size(593, 33);
            this.Path.TabIndex = 25;
            this.Path.Text = "Click browse to select";
            this.Path.UseSelectable = true;
            this.Path.Visible = false;
            this.Path.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Path.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Path.SizeChanged += new System.EventHandler(this.Path_SizeChanged);
            this.Path.TextChanged += new System.EventHandler(this.Path_TextChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(651, 540);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 40);
            this.button4.TabIndex = 27;
            this.button4.Text = "Next";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.Next_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(29, 540);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 40);
            this.button2.TabIndex = 28;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Back_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(651, 437);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 33);
            this.button3.TabIndex = 29;
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.Browse_Click);
            // 
            // Conversion_Code
            // 
            this.Conversion_Code.FormattingEnabled = true;
            this.Conversion_Code.ItemHeight = 23;
            this.Conversion_Code.Items.AddRange(new object[] {
            "None",
            "Fast",
            "Max",
            "Recovery"});
            this.Conversion_Code.Location = new System.Drawing.Point(39, 288);
            this.Conversion_Code.Name = "Conversion_Code";
            this.Conversion_Code.PromptText = "None";
            this.Conversion_Code.Size = new System.Drawing.Size(121, 29);
            this.Conversion_Code.TabIndex = 30;
            this.Conversion_Code.UseSelectable = true;
            this.Conversion_Code.Visible = false;
            // 
            // Conversion_text
            // 
            this.Conversion_text.AutoSize = true;
            this.Conversion_text.Font = new System.Drawing.Font("Segoe UI Semilight", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Conversion_text.Location = new System.Drawing.Point(35, 250);
            this.Conversion_text.Name = "Conversion_text";
            this.Conversion_text.Size = new System.Drawing.Size(130, 23);
            this.Conversion_text.TabIndex = 31;
            this.Conversion_text.Text = "Conversion type";
            this.Conversion_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Conversion_text.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(255, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 23);
            this.label1.TabIndex = 32;
            this.label1.Text = "SWM Partition (MB)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(251, 288);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(166, 29);
            this.textBox1.TabIndex = 33;
            this.textBox1.Visible = false;
            // 
            // Select_installation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Conversion_text);
            this.Controls.Add(this.Conversion_Code);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.Folder);
            this.Controls.Add(this.DVD);
            this.Controls.Add(this.SWM);
            this.Controls.Add(this.ESD);
            this.Controls.Add(this.WIM);
            this.MaximizeBox = false;
            this.Name = "Select_installation";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Select the file type - Windows";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile WIM;
        private MetroFramework.Controls.MetroTile ESD;
        private MetroFramework.Controls.MetroTile SWM;
        private MetroFramework.Controls.MetroTile DVD;
        private MetroFramework.Controls.MetroTile Folder;
        private MetroFramework.Controls.MetroTextBox Path;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private MetroFramework.Controls.MetroComboBox Conversion_Code;
        private System.Windows.Forms.Label Conversion_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}