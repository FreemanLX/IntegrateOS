namespace IntegrateOS
{
    partial class Menu
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
            this.Setup = new MetroFramework.Controls.MetroTile();
            this.Tools = new MetroFramework.Controls.MetroTile();
            this.Settings = new MetroFramework.Controls.MetroTile();
            this.Exit = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // Setup
            // 
            this.Setup.ActiveControl = null;
            this.Setup.DisplayFocusBorder = false;
            this.Setup.Location = new System.Drawing.Point(23, 110);
            this.Setup.Name = "metroTile1";
            this.Setup.PaintTileCount = false;
            this.Setup.Size = new System.Drawing.Size(194, 136);
            this.Setup.TabIndex = 11;
            this.Setup.Text = "IntegrateOS Setup";
            this.Setup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Setup.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Setup.UseSelectable = true;
            this.Setup.UseStyleColors = true;
            this.Setup.UseTileImage = true;
            this.Setup.UseVisualStyleBackColor = false;
            this.Setup.Click += new System.EventHandler(this.Selection_OS_Click);
            // 
            // Tools
            // 
            this.Tools.ActiveControl = null;
            this.Tools.Location = new System.Drawing.Point(223, 110);
            this.Tools.Name = "metroTile2";
            this.Tools.Size = new System.Drawing.Size(194, 136);
            this.Tools.TabIndex = 12;
            this.Tools.Text = "IntegrateOS Tools";
            this.Tools.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Tools.UseSelectable = true;
            this.Tools.Click += new System.EventHandler(this.Tools_Click);
            // 
            // Settings
            // 
            this.Settings.ActiveControl = null;
            this.Settings.Location = new System.Drawing.Point(423, 110);
            this.Settings.Name = "metroTile3";
            this.Settings.Size = new System.Drawing.Size(194, 136);
            this.Settings.TabIndex = 13;
            this.Settings.Text = "Settings";
            this.Settings.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Settings.UseSelectable = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click_1);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(342, 537);
            this.Exit.Name = "Back";
            this.Exit.Size = new System.Drawing.Size(120, 40);
            this.Exit.TabIndex = 24;
            this.Exit.Text = "Exit";
            this.Exit.UseSelectable = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.Tools);
            this.Controls.Add(this.Setup);
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "IntegrateOS Menu (Full Version)";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTile Setup;
        private MetroFramework.Controls.MetroTile Tools;
        private MetroFramework.Controls.MetroTile Settings;
        private MetroFramework.Controls.MetroButton Exit;
    }
}