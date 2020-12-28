namespace IntegrateOS
{
    partial class Extract_iso
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
            this.components = new System.ComponentModel.Container();
            this.Progress_Bar = new MetroFramework.Controls.MetroProgressBar();
            this.Progress_Timer = new System.Windows.Forms.Timer(this.components);
            this.Progress_Message = new MetroFramework.Controls.MetroLabel();
            this.Progress_Number = new MetroFramework.Controls.MetroLabel();
            this.Waiting_message_label = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // Progress_Bar
            // 
            this.Progress_Bar.Location = new System.Drawing.Point(17, 143);
            this.Progress_Bar.Name = "metroProgressBar1";
            this.Progress_Bar.Size = new System.Drawing.Size(747, 33);
            this.Progress_Bar.TabIndex = 0;
            // 
            // Progress_Timer
            // 
            this.Progress_Timer.Enabled = true;
            this.Progress_Timer.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Progress_Message
            // 
            this.Progress_Message.AutoSize = true;
            this.Progress_Message.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.Progress_Message.Location = new System.Drawing.Point(17, 102);
            this.Progress_Message.Name = "Progress_Message";
            this.Progress_Message.Size = new System.Drawing.Size(81, 25);
            this.Progress_Message.TabIndex = 1;
            this.Progress_Message.Text = "Progress:";
            // 
            // Progress_Number
            // 
            this.Progress_Number.AutoSize = true;
            this.Progress_Number.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.Progress_Number.Location = new System.Drawing.Point(104, 102);
            this.Progress_Number.Name = "Progress_Number";
            this.Progress_Number.Size = new System.Drawing.Size(40, 25);
            this.Progress_Number.TabIndex = 2;
            this.Progress_Number.Text = "0 %";
            // 
            // Waiting_message_label
            // 
            this.Waiting_message_label.AutoSize = true;
            this.Waiting_message_label.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.Waiting_message_label.Location = new System.Drawing.Point(17, 203);
            this.Waiting_message_label.Name = "metroLabel4";
            this.Waiting_message_label.Size = new System.Drawing.Size(272, 25);
            this.Waiting_message_label.TabIndex = 6;
            this.Waiting_message_label.Text = "It takes a while. Please be patient...";
            // 
            // Extract_iso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.Waiting_message_label);
            this.Controls.Add(this.Progress_Number);
            this.Controls.Add(this.Progress_Message);
            this.Controls.Add(this.Progress_Bar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Extract_iso";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Extracting ISO files";
            this.Load += new System.EventHandler(this.ExtractISO_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar Progress_Bar;
        private MetroFramework.Controls.MetroLabel Progress_Message;
        private MetroFramework.Controls.MetroLabel Progress_Number;
        public System.Windows.Forms.Timer Progress_Timer;
        private MetroFramework.Controls.MetroLabel Waiting_message_label;
    }
}