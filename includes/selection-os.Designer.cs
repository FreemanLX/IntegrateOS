namespace IntegrateOS
{
    partial class Selection_os
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
            this.Windows = new MetroFramework.Controls.MetroTile();
            this.Linux = new MetroFramework.Controls.MetroTile();
            this.Android = new MetroFramework.Controls.MetroTile();
            this.Windows_Phone = new MetroFramework.Controls.MetroTile();
            this.Back = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // Windows
            // 
            this.Windows.ActiveControl = null;
            this.Windows.Location = new System.Drawing.Point(43, 150);
            this.Windows.Name = "metroTile1";
            this.Windows.Size = new System.Drawing.Size(194, 136);
            this.Windows.TabIndex = 15;
            this.Windows.Text = "Windows";
            this.Windows.UseSelectable = true;
            this.Windows.Click += new System.EventHandler(this.Windows_Installaton_Click);
            // 
            // Linux
            // 
            this.Linux.ActiveControl = null;
            this.Linux.Location = new System.Drawing.Point(443, 150);
            this.Linux.Name = "metroTile2";
            this.Linux.Size = new System.Drawing.Size(194, 136);
            this.Linux.TabIndex = 16;
            this.Linux.Text = "Linux";
            this.Linux.UseSelectable = true;
            this.Linux.Click += new System.EventHandler(this.Linux_Installation_Click);
            // 
            // Android
            // 
            this.Android.ActiveControl = null;
            this.Android.Location = new System.Drawing.Point(43, 293);
            this.Android.Name = "metroTile3";
            this.Android.Size = new System.Drawing.Size(194, 136);
            this.Android.TabIndex = 17;
            this.Android.Text = "Android";
            this.Android.UseSelectable = true;
            // 
            // Windows_Phone
            // 
            this.Windows_Phone.ActiveControl = null;
            this.Windows_Phone.Location = new System.Drawing.Point(243, 150);
            this.Windows_Phone.Name = "metroTile5";
            this.Windows_Phone.Size = new System.Drawing.Size(194, 136);
            this.Windows_Phone.TabIndex = 19;
            this.Windows_Phone.Text = "Windows Phone (Advanced Users Only)";
            this.Windows_Phone.UseSelectable = true;
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(29, 70);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(50, 50);
            this.Back.TabIndex = 23;
            this.Back.UseSelectable = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Selection_os
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Windows_Phone);
            this.Controls.Add(this.Android);
            this.Controls.Add(this.Linux);
            this.Controls.Add(this.Windows);
            this.MaximizeBox = false;
            this.Name = "Selection_os";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Select OS to Install";
            this.Load += new System.EventHandler(this.Selection_os_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTile Windows;
        private MetroFramework.Controls.MetroTile Linux;
        private MetroFramework.Controls.MetroTile Android;
        private MetroFramework.Controls.MetroTile Windows_Phone;
        private MetroFramework.Controls.MetroButton Back;
    }
}