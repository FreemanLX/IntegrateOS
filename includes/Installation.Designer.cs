namespace IntegrateOS
{
    partial class Installation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installation));
            this.Extracting_windows_label = new System.Windows.Forms.Label();
            this.Installing_Boot_Label = new System.Windows.Forms.Label();
            this.Done_1 = new System.Windows.Forms.Label();
            this.Done_2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Extracting_windows_label
            // 
            this.Extracting_windows_label.AutoSize = true;
            this.Extracting_windows_label.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Extracting_windows_label.Location = new System.Drawing.Point(23, 212);
            this.Extracting_windows_label.Name = "Extracting_windows_label";
            this.Extracting_windows_label.Size = new System.Drawing.Size(278, 25);
            this.Extracting_windows_label.TabIndex = 11;
            this.Extracting_windows_label.Text = "Stage 1: Extracting Windows Files";
            // 
            // Installing_Boot_Label
            // 
            this.Installing_Boot_Label.AutoSize = true;
            this.Installing_Boot_Label.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Installing_Boot_Label.Location = new System.Drawing.Point(23, 267);
            this.Installing_Boot_Label.Name = "Installing_Boot_Label";
            this.Installing_Boot_Label.Size = new System.Drawing.Size(457, 25);
            this.Installing_Boot_Label.TabIndex = 12;
            this.Installing_Boot_Label.Text = "Stage 2: Installing Windows Boot Files and Finishing Up";
            // 
            // Done_1
            // 
            this.Done_1.AutoSize = true;
            this.Done_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Done_1.ForeColor = System.Drawing.Color.YellowGreen;
            this.Done_1.Location = new System.Drawing.Point(708, 213);
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
            this.Done_2.Location = new System.Drawing.Point(708, 268);
            this.Done_2.Name = "Done_2";
            this.Done_2.Size = new System.Drawing.Size(56, 24);
            this.Done_2.TabIndex = 23;
            this.Done_2.Text = "Done";
            this.Done_2.Visible = false;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(0, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 2);
            this.label1.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(0, 539);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(800, 2);
            this.label2.TabIndex = 35;
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            //this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Installation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Done_2);
            this.Controls.Add(this.Done_1);
            this.Controls.Add(this.Installing_Boot_Label);
            this.Controls.Add(this.Extracting_windows_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Installation";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Installing Windows";
            this.Load += new System.EventHandler(this.Installation_Load);
            this.Shown += new System.EventHandler(this.Installation_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Extracting_windows_label;
        private System.Windows.Forms.Label Installing_Boot_Label;
        private System.Windows.Forms.Label Done_1;
        private System.Windows.Forms.Label Done_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer Timer;
    }
}