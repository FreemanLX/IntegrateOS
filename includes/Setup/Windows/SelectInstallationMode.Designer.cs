namespace IntegrateOS
{
    partial class SelectInstallationMode
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
            MetroFramework.MetroThemeStyle metroThemeStyle1 = new MetroFramework.MetroThemeStyle();
            MetroFramework.MetroThemeStyle metroThemeStyle2 = new MetroFramework.MetroThemeStyle();
            MetroFramework.MetroThemeStyle metroThemeStyle3 = new MetroFramework.MetroThemeStyle();
            this.Folder = new MetroFramework.Controls.MetroTile();
            this.button3 = new System.Windows.Forms.Button();
            this.Conversion_Code = new MetroFramework.Controls.MetroComboBox();
            this.Conversion_text = new System.Windows.Forms.Label();
            this.WIM = new MetroFramework.Controls.MetroTile();
            this.Back = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Path = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Folder
            // 
            this.Folder.ActiveControl = null;
            this.Folder.Location = new System.Drawing.Point(239, 168);
            this.Folder.Name = "metroTile5";
            this.Folder.Size = new System.Drawing.Size(194, 136);
            this.Folder.TabIndex = 24;
            this.Folder.Text = "Folder";
            this.Folder.Theme = metroThemeStyle1;
            this.Folder.UseSelectable = true;
            this.Folder.Click += new System.EventHandler(this.Folder_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(342, 422);
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
            this.Conversion_Code.Location = new System.Drawing.Point(522, 204);
            this.Conversion_Code.Name = "Conversion_Code";
            this.Conversion_Code.PromptText = "None";
            this.Conversion_Code.Size = new System.Drawing.Size(121, 29);
            this.Conversion_Code.TabIndex = 30;
            this.Conversion_Code.Theme = metroThemeStyle2;
            this.Conversion_Code.UseSelectable = true;
            this.Conversion_Code.Visible = false;
            // 
            // Conversion_text
            // 
            this.Conversion_text.AutoSize = true;
            this.Conversion_text.Font = new System.Drawing.Font("Segoe UI Semilight", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Conversion_text.Location = new System.Drawing.Point(518, 167);
            this.Conversion_text.Name = "Conversion_text";
            this.Conversion_text.Size = new System.Drawing.Size(130, 23);
            this.Conversion_text.TabIndex = 31;
            this.Conversion_text.Text = "Conversion type";
            this.Conversion_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Conversion_text.Visible = false;
            // 
            // WIM
            // 
            this.WIM.ActiveControl = null;
            this.WIM.Location = new System.Drawing.Point(39, 168);
            this.WIM.Name = "metroTile1";
            this.WIM.Size = new System.Drawing.Size(194, 136);
            this.WIM.TabIndex = 20;
            this.WIM.Text = "File";
            this.WIM.Theme = metroThemeStyle3;
            this.WIM.UseSelectable = true;
            this.WIM.UseTileImage = true;
            this.WIM.Click += new System.EventHandler(this.WIM_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.White;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Back.ForeColor = System.Drawing.Color.Black;
            this.Back.Location = new System.Drawing.Point(29, 70);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(50, 50);
            this.Back.TabIndex = 35;
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(0, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(800, 2);
            this.label2.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(0, 539);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(800, 2);
            this.label3.TabIndex = 38;
            // 
            // Path
            // 
            this.Path.AutoSize = true;
            this.Path.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Path.Location = new System.Drawing.Point(303, 360);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(207, 25);
            this.Path.TabIndex = 39;
            this.Path.Text = "Browse Windows Image";
            this.Path.Visible = false;
            // 
            // Select_installation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Conversion_text);
            this.Controls.Add(this.Conversion_Code);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Folder);
            this.Controls.Add(this.WIM);
            this.MaximizeBox = false;
            this.Name = "Select_installation";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Select Windows Image Files";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile Folder;
        private System.Windows.Forms.Button button3;
        private MetroFramework.Controls.MetroComboBox Conversion_Code;
        private System.Windows.Forms.Label Conversion_text;
        private MetroFramework.Controls.MetroTile WIM;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Path;
    }
}