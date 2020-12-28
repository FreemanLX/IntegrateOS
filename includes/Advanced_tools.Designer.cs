namespace IntegrateOS
{
    partial class Advanced_tools
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
            this.Edit_Windows = new MetroFramework.Controls.MetroTile();
            this.Sysprep = new MetroFramework.Controls.MetroTile();
            this.Compress = new MetroFramework.Controls.MetroTile();
            this.WindowsPE = new MetroFramework.Controls.MetroTile();
            this.Waudit = new MetroFramework.Controls.MetroTile();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // Edit_Windows
            // 
            this.Edit_Windows.ActiveControl = null;
            this.Edit_Windows.Location = new System.Drawing.Point(43, 150);
            this.Edit_Windows.Name = "metroTile5";
            this.Edit_Windows.Size = new System.Drawing.Size(194, 136);
            this.Edit_Windows.TabIndex = 17;
            this.Edit_Windows.Text = "Edit Windows";
            this.Edit_Windows.UseSelectable = true;
            this.Edit_Windows.Click += new System.EventHandler(this.Edit_Windows_Click);
            // 
            // Sysprep
            // 
            this.Sysprep.ActiveControl = null;
            this.Sysprep.Location = new System.Drawing.Point(243, 150);
            this.Sysprep.Name = "Sysprep";
            this.Sysprep.Size = new System.Drawing.Size(194, 136);
            this.Sysprep.TabIndex = 17;
            this.Sysprep.Text = "Uninstall all Windows drivers";
            this.Sysprep.UseSelectable = true;
            this.Sysprep.Click += new System.EventHandler(this.Sysprep_Click);
            // 
            // Compress
            // 
            this.Compress.ActiveControl = null;
            this.Compress.Location = new System.Drawing.Point(443, 150);
            this.Compress.Name = "Compress";
            this.Compress.Size = new System.Drawing.Size(194, 136);
            this.Compress.TabIndex = 17;
            this.Compress.Text = "Capture a Windows image";
            this.Compress.UseSelectable = true;
            this.Compress.Click += new System.EventHandler(this.Compress_Click);
            // 
            // WindowsPE
            // 
            this.WindowsPE.ActiveControl = null;
            this.WindowsPE.Location = new System.Drawing.Point(43, 293);
            this.WindowsPE.Name = "Compress";
            this.WindowsPE.Size = new System.Drawing.Size(194, 136);
            this.WindowsPE.TabIndex = 17;
            this.WindowsPE.Text = "Create and customize Windows PE";
            this.WindowsPE.UseSelectable = true;
            this.WindowsPE.Click += new System.EventHandler(this.Windows_PE_Click);
            // 
            // Waudit
            // 
            this.Waudit.ActiveControl = null;
            this.Waudit.Location = new System.Drawing.Point(243, 293);
            this.Waudit.Name = "Compress";
            this.Waudit.Size = new System.Drawing.Size(194, 136);
            this.Waudit.TabIndex = 17;
            this.Waudit.Text = "Boot to audit mode (advanced only)";
            this.Waudit.UseSelectable = true;
            this.Waudit.Click += new System.EventHandler(this.Waudit_Click);
            // 
            // Back
            // 
            this.metroButton2.FlatAppearance.BorderSize = 0;
            this.metroButton2.Location = new System.Drawing.Point(29, 70);
            this.metroButton2.Name = "Back";
            this.metroButton2.Size = new System.Drawing.Size(50, 50);
            this.metroButton2.TabIndex = 25;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.Back_Click);
            // 
            // Advanced_tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackLocation = MetroFramework.Forms.BackLocation.TopLeft;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.Edit_Windows);
            this.Controls.Add(this.Sysprep);
            this.Controls.Add(this.Compress);
            this.Controls.Add(this.WindowsPE);
            this.Controls.Add(this.Waudit);
            this.MaximizeBox = false;
            this.Name = "Advanced_tools";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "IntegrateOS Tools";
            this.Load += new System.EventHandler(this.Advanced_tools_Load);
            this.ResumeLayout(false);

        }
        private MetroFramework.Controls.MetroTile Edit_Windows;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroTile Sysprep;
        private MetroFramework.Controls.MetroTile Compress;
        private MetroFramework.Controls.MetroTile WindowsPE;
        private MetroFramework.Controls.MetroTile Waudit;
        #endregion
    }
}