using System;

namespace IntegrateOS
{
    partial class Settings_Menu
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
            this.Themes = new MetroFramework.Controls.MetroTile();
            this.Licenses = new MetroFramework.Controls.MetroTile();
            this.About = new MetroFramework.Controls.MetroTile();
            this.Advanced = new MetroFramework.Controls.MetroTile();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // Themes
            // 
            this.Themes.ActiveControl = null;
            this.Themes.Location = new System.Drawing.Point(43, 150);
            this.Themes.Name = "Themes";
            this.Themes.Size = new System.Drawing.Size(194, 136);
            this.Themes.TabIndex = 13;
            this.Themes.Text = "Themes";
            this.Themes.UseSelectable = true;
            this.Themes.Click += new System.EventHandler(this.Themes_Click);
            // 
            // Licenses
            // 
            this.Licenses.ActiveControl = null;
            this.Licenses.Location = new System.Drawing.Point(443, 150);
            this.Licenses.Name = "Licenses";
            this.Licenses.Size = new System.Drawing.Size(194, 136);
            this.Licenses.TabIndex = 13;
            this.Licenses.Text = "Licenses";
            this.Licenses.UseSelectable = true;
            this.Licenses.Click += new System.EventHandler(this.Licenses_Click);
            // 
            // About
            // 
            this.About.ActiveControl = null;
            this.About.Location = new System.Drawing.Point(43, 291);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(194, 136);
            this.About.TabIndex = 13;
            this.About.Text = "About";
            this.About.UseSelectable = true;
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // Advanced
            // 
            this.Advanced.ActiveControl = null;
            this.Advanced.Location = new System.Drawing.Point(243, 150);
            this.Advanced.Name = "Advanced";
            this.Advanced.Size = new System.Drawing.Size(194, 136);
            this.Advanced.TabIndex = 13;
            this.Advanced.Text = "Advanced";
            this.Advanced.UseSelectable = true;
            this.Advanced.Click += new System.EventHandler(this.Advanced_Click);
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
            // Settings_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.Themes);
            this.Controls.Add(this.About);
            this.Controls.Add(this.Licenses);
            this.Controls.Add(this.Advanced);
            this.Controls.Add(this.metroButton2);
            this.MaximizeBox = false;
            this.Name = "Settings_Menu";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile Themes;
        private MetroFramework.Controls.MetroTile Licenses;
        private MetroFramework.Controls.MetroTile Advanced;
        private MetroFramework.Controls.MetroTile About;
        private MetroFramework.Controls.MetroButton metroButton2;

    }
}