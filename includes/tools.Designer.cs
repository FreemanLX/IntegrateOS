using System;
using System.Windows.Forms;

namespace IntegrateOS
{
    partial class Basic_tools
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
            this.Convert_Windows_Installation = new MetroFramework.Controls.MetroTile();
            this.Mount_Windows = new MetroFramework.Controls.MetroTile();
            this.Wadvmode = new MetroFramework.Controls.MetroTile();
            this.Wcommandmode = new MetroFramework.Controls.MetroTile();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // Convert_Windows_Installation
            // 
            this.Convert_Windows_Installation.ActiveControl = null;
            this.Convert_Windows_Installation.Location = new System.Drawing.Point(43, 150);
            this.Convert_Windows_Installation.Name = "metroTile1";
            this.Convert_Windows_Installation.Size = new System.Drawing.Size(194, 136);
            this.Convert_Windows_Installation.TabIndex = 13;
            this.Convert_Windows_Installation.Text = "Convert Windows Setup Files";
            this.Convert_Windows_Installation.UseSelectable = true;
            this.Convert_Windows_Installation.Click += new System.EventHandler(this.Convert_Windows_Click);
            // 
            // Mount_Windows
            // 
            this.Mount_Windows.ActiveControl = null;
            this.Mount_Windows.Location = new System.Drawing.Point(243, 150);
            this.Mount_Windows.Name = "metroTile4";
            this.Mount_Windows.Size = new System.Drawing.Size(194, 136);
            this.Mount_Windows.TabIndex = 16;
            this.Mount_Windows.Text = "Mount Windows";
            this.Mount_Windows.UseSelectable = true;
            this.Mount_Windows.Click += new System.EventHandler(this.Mount_Windows_Click);
            // 
            // Wadvmode
            // 
            this.Wadvmode.ActiveControl = null;
            this.Wadvmode.Location = new System.Drawing.Point(443, 150);
            this.Wadvmode.Name = "Compress";
            this.Wadvmode.Size = new System.Drawing.Size(194, 136);
            this.Wadvmode.TabIndex = 17;
            this.Wadvmode.Text = "Boot to Windows advanced mode";
            this.Wadvmode.UseSelectable = true;
            this.Wadvmode.Click += new System.EventHandler(this.Wadvmode_Click_1);
            // 
            // Wcommandmode
            // 
            this.Wcommandmode.ActiveControl = null;
            this.Wcommandmode.Location = new System.Drawing.Point(43, 293);
            this.Wcommandmode.Name = "Compress";
            this.Wcommandmode.Size = new System.Drawing.Size(194, 136);
            this.Wcommandmode.TabIndex = 17;
            this.Wcommandmode.Text = "IntegrateOS Command Mode";
            this.Wcommandmode.UseSelectable = true;
            this.Wcommandmode.Click += new System.EventHandler(this.Wcommandmode_Click);
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
            // Basic_tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.Mount_Windows);
            this.Controls.Add(this.Convert_Windows_Installation);
            this.Controls.Add(this.Wadvmode);
            this.Controls.Add(this.Wcommandmode);
            this.MaximizeBox = false;
            this.Name = "Basic_tools";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "IntegrateOS Tools";
            this.Load += new System.EventHandler(this.Tools_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTile Convert_Windows_Installation;
        private MetroFramework.Controls.MetroTile Mount_Windows;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroTile Wadvmode;
        private MetroFramework.Controls.MetroTile Wcommandmode;
    }
}