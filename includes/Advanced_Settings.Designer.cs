namespace IntegrateOS
{
    partial class Advanced_Settings
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.Beta_radio = new System.Windows.Forms.RadioButton();
            this.Advanced_radio = new System.Windows.Forms.RadioButton();
            this.Basic_radio = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.Beta_radio);
            this.metroPanel1.Controls.Add(this.Advanced_radio);
            this.metroPanel1.Controls.Add(this.Basic_radio);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(103, 190);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(465, 100);
            this.metroPanel1.TabIndex = 39;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // Beta_radio
            // 
            this.Beta_radio.AutoSize = true;
            this.Beta_radio.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Beta_radio.Location = new System.Drawing.Point(3, 69);
            this.Beta_radio.Name = "Beta_radio";
            this.Beta_radio.Size = new System.Drawing.Size(454, 27);
            this.Beta_radio.TabIndex = 38;
            this.Beta_radio.TabStop = true;
            this.Beta_radio.Text = "Enable beta mode (Automatically enables advanced mode)";
            this.Beta_radio.UseVisualStyleBackColor = true;
            this.Beta_radio.CheckedChanged += new System.EventHandler(this.Beta_CheckedChanged);
            // 
            // Advanced_radio
            // 
            this.Advanced_radio.AutoSize = true;
            this.Advanced_radio.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Advanced_radio.Location = new System.Drawing.Point(3, 36);
            this.Advanced_radio.Name = "Advanced_radio";
            this.Advanced_radio.Size = new System.Drawing.Size(199, 27);
            this.Advanced_radio.TabIndex = 36;
            this.Advanced_radio.TabStop = true;
            this.Advanced_radio.Text = "Enable advanced mode";
            this.Advanced_radio.UseVisualStyleBackColor = true;
            this.Advanced_radio.CheckedChanged += new System.EventHandler(this.Advanced_CheckedChanged);
            // 
            // Basic_radio
            // 
            this.Basic_radio.AutoSize = true;
            this.Basic_radio.Font = new System.Drawing.Font("Segoe UI Light", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Basic_radio.Location = new System.Drawing.Point(3, 3);
            this.Basic_radio.Name = "Basic_radio";
            this.Basic_radio.Size = new System.Drawing.Size(165, 27);
            this.Basic_radio.TabIndex = 37;
            this.Basic_radio.TabStop = true;
            this.Basic_radio.Text = "Enable basic mode";
            this.Basic_radio.UseVisualStyleBackColor = true;
            this.Basic_radio.CheckedChanged += new System.EventHandler(this.Basic_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.label5.Location = new System.Drawing.Point(48, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 25);
            this.label5.TabIndex = 40;
            this.label5.Text = "Select the program mode";
            // 
            // Back
            // 
            this.metroButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.metroButton2.Location = new System.Drawing.Point(29, 70);
            this.metroButton2.Name = "Back";
            this.metroButton2.Size = new System.Drawing.Size(50, 50);
            this.metroButton2.TabIndex = 31;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.Back_Click);
            // 
            // Advanced_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroButton2);
            this.Name = "Advanced_Settings";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Advanced Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Advanced_Settings_FormClosing);
            this.Load += new System.EventHandler(this.Advanced_Settings_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.RadioButton Beta_radio;
        private System.Windows.Forms.RadioButton Advanced_radio;
        private System.Windows.Forms.RadioButton Basic_radio;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroButton metroButton2;
    }
}