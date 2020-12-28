using System.Windows.Forms;
namespace IntegrateOS
{
    partial class Select_tools_type
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
            this.SuspendLayout();

            this.Advanced = new MetroFramework.Controls.MetroTile();
            this.Basic = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // Advanced
            // 
            this.Advanced.ActiveControl = null;
            this.Advanced.Location = new System.Drawing.Point(43, 150);
            this.Advanced.Name = "metroTile1";
            this.Advanced.Size = new System.Drawing.Size(194, 136);
            this.Advanced.TabIndex = 15;
            this.Advanced.Text = "Advanced tools";
            this.Advanced.UseSelectable = true;
            this.Advanced.Click += new System.EventHandler(this.Advanced_Click);
            // 
            // Basic
            // 
            this.Basic.ActiveControl = null;
            this.Basic.Location = new System.Drawing.Point(243, 150);
            this.Basic.Name = "metroTile2";
            this.Basic.Size = new System.Drawing.Size(194, 136);
            this.Basic.TabIndex = 16;
            this.Basic.Text = "Basic tools";
            this.Basic.UseSelectable = true;
            this.Basic.Click += new System.EventHandler(this.Basic_Click);
            //
            //Back
            //
            this.Back = new MetroFramework.Controls.MetroButton();
            this.Back.Location = new System.Drawing.Point(29, 70);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(50, 50);
            this.Back.TabIndex = 23;
            this.Back.UseSelectable = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            
            // 
            // Select_tools_type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.MaximizeBox = false;
            this.Name = "Select_tools_type";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Select the type of tools";
            this.Load += new System.EventHandler(this.Select_tools_type_Load);
            this.Controls.Add(Basic);
            this.Controls.Add(Advanced);
            this.Controls.Add(Back);
            this.ResumeLayout(false);

        }
        private MetroFramework.Controls.MetroTile Advanced;
        private MetroFramework.Controls.MetroTile Basic;
        private MetroFramework.Controls.MetroButton Back;
        #endregion
    }
}