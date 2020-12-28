namespace IntegrateOS
{
    partial class Format
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
            this.Message_Label = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // Message_Label
            // 
            this.Message_Label.AutoSize = true;
            this.Message_Label.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.Message_Label.Location = new System.Drawing.Point(63, 60);
            this.Message_Label.Name = "Progress_Message";
            this.Message_Label.Size = new System.Drawing.Size(327, 25);
            this.Message_Label.TabIndex = 0;
            this.Message_Label.Text = "Formatting the selected drive, please wait.";
            // 
            // Format
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(460, 145);
            this.ControlBox = false;
            this.Controls.Add(this.Message_Label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Format";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Format_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel Message_Label;
    }
}