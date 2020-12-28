namespace IntegrateOS
{
    partial class Windows_Installation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Windows_Installation));
            this.Extracting_windows_label = new System.Windows.Forms.Label();
            this.Installing_Boot_Label = new System.Windows.Forms.Label();
            this.Timer_Installation = new System.Windows.Forms.Timer(this.components);
            this.Progress_Bar = new MetroFramework.Controls.MetroProgressBar();
            this.Percentage_Label = new System.Windows.Forms.Label();
            this.Progress_Label = new System.Windows.Forms.Label();
            this.Done_1 = new System.Windows.Forms.Label();
            this.Done_2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Extracting_windows_label
            // 
            this.Extracting_windows_label.AutoSize = true;
            this.Extracting_windows_label.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Extracting_windows_label.Location = new System.Drawing.Point(23, 118);
            this.Extracting_windows_label.Name = "Extracting_windows_label";
            this.Extracting_windows_label.Size = new System.Drawing.Size(298, 25);
            this.Extracting_windows_label.TabIndex = 11;
            this.Extracting_windows_label.Text = "Stage 1: Extracting Windows Files";
            // 
            // Installing_Boot_Label
            // 
            this.Installing_Boot_Label.AutoSize = true;
            this.Installing_Boot_Label.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Installing_Boot_Label.Location = new System.Drawing.Point(23, 174);
            this.Installing_Boot_Label.Name = "Installing_Boot_Label";
            this.Installing_Boot_Label.Size = new System.Drawing.Size(457, 25);
            this.Installing_Boot_Label.TabIndex = 12;
            this.Installing_Boot_Label.Text = "Stage 2: Installing Windows Boot Files and Finishing Up";
            // 
            // Timer_Installation
            // 
            this.Timer_Installation.Enabled = true;
            this.Timer_Installation.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Progress_Bar
            // 
            this.Progress_Bar.Location = new System.Drawing.Point(23, 473);
            this.Progress_Bar.Name = "progressBar1";
            this.Progress_Bar.Size = new System.Drawing.Size(741, 34);
            this.Progress_Bar.Step = 1;
            this.Progress_Bar.TabIndex = 14;
            // 
            // Percentage_Label
            // 
            this.Percentage_Label.AutoSize = true;
            this.Percentage_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Percentage_Label.Location = new System.Drawing.Point(157, 441);
            this.Percentage_Label.Name = "Percentage_Label";
            this.Percentage_Label.Size = new System.Drawing.Size(34, 24);
            this.Percentage_Label.TabIndex = 17;
            this.Percentage_Label.Text = "0 %";
            this.Percentage_Label.UseCompatibleTextRendering = true;
            // 
            // Progress_Label
            // 
            this.Progress_Label.AutoSize = true;
            this.Progress_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Progress_Label.Location = new System.Drawing.Point(23, 441);
            this.Progress_Label.Name = "Progress_Label";
            this.Progress_Label.Size = new System.Drawing.Size(128, 20);
            this.Progress_Label.TabIndex = 20;
            this.Progress_Label.Text = "Overall Progress:";
            // 
            // Done_1
            // 
            this.Done_1.AutoSize = true;
            this.Done_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Done_1.ForeColor = System.Drawing.Color.YellowGreen;
            this.Done_1.Location = new System.Drawing.Point(708, 119);
            this.Done_1.Name = "Done_1";
            this.Done_1.Size = new System.Drawing.Size(56, 24);
            this.Done_1.TabIndex = 22;
            this.Done_1.Text = "Done";
            this.Done_1.Visible = false;
            // 
            // Done_2
            // 
            this.Done_2.AutoSize = true;
            this.Done_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Done_2.ForeColor = System.Drawing.Color.YellowGreen;
            this.Done_2.Location = new System.Drawing.Point(708, 174);
            this.Done_2.Name = "Done_2";
            this.Done_2.Size = new System.Drawing.Size(56, 24);
            this.Done_2.TabIndex = 23;
            this.Done_2.Text = "Done";
            this.Done_2.Visible = false;
            // 
            // Windows_Installation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.Done_2);
            this.Controls.Add(this.Done_1);
            this.Controls.Add(this.Progress_Label);
            this.Controls.Add(this.Percentage_Label);
            this.Controls.Add(this.Progress_Bar);
            this.Controls.Add(this.Installing_Boot_Label);
            this.Controls.Add(this.Extracting_windows_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Windows_Installation";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Installing Windows";
            this.Load += new System.EventHandler(this.Form13_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Extracting_windows_label;
        private System.Windows.Forms.Label Installing_Boot_Label;
        private System.Windows.Forms.Timer Timer_Installation;
        private System.Windows.Forms.Label Progress_Label;
        private System.Windows.Forms.Label Done_1;
        private System.Windows.Forms.Label Done_2;
        public System.Windows.Forms.Label Percentage_Label;
        private MetroFramework.Controls.MetroProgressBar Progress_Bar;
    }
}