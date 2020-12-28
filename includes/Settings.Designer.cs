namespace IntegrateOS
{
    partial class Settings
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.Dark = new MetroFramework.Controls.MetroRadioButton();
            this.White = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.Form_StyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.Back = new MetroFramework.Controls.MetroButton();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Form_StyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(45, 130);
            this.metroLabel1.Name = "Progress_Message";
            this.metroLabel1.Size = new System.Drawing.Size(71, 25);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Themes";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(73, 163);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(53, 25);
            this.metroLabel4.TabIndex = 14;
            this.metroLabel4.Text = "Color";
            // 
            // Dark
            // 
            this.Dark.AutoSize = true;
            this.Dark.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.Dark.Location = new System.Drawing.Point(432, 200);
            this.Dark.Name = "Dark";
            this.Dark.Size = new System.Drawing.Size(117, 25);
            this.Dark.TabIndex = 22;
            this.Dark.Text = "Dark Mode";
            this.Dark.UseSelectable = true;
            this.Dark.CheckedChanged += new System.EventHandler(this.Dark_CheckedChanged);
            // 
            // White
            // 
            this.White.AutoSize = true;
            this.White.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.White.Location = new System.Drawing.Point(637, 200);
            this.White.Name = "White";
            this.White.Size = new System.Drawing.Size(119, 25);
            this.White.TabIndex = 23;
            this.White.Text = "Light Mode";
            this.White.UseSelectable = true;
            this.White.CheckedChanged += new System.EventHandler(this.White_CheckedChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(73, 200);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(338, 25);
            this.metroLabel3.TabIndex = 24;
            this.metroLabel3.Text = "Choose the default theme for IntegrateOS: ";
            // 
            // Form_StyleManager
            // 
            this.Form_StyleManager.Owner = this;
            // 
            // Back
            // 
            this.Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Location = new System.Drawing.Point(29, 70);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(50, 50);
            this.Back.TabIndex = 31;
            this.Back.UseSelectable = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(144, 163);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.PromptText = "Blue";
            this.metroComboBox1.Size = new System.Drawing.Size(121, 29);
            this.metroComboBox1.TabIndex = 32;
            this.metroComboBox1.UseSelectable = true;
            this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel12.Location = new System.Drawing.Point(47, 236);
            this.metroLabel12.Name = "Progress_Number";
            this.metroLabel12.Size = new System.Drawing.Size(58, 25);
            this.metroLabel12.TabIndex = 11;
            this.metroLabel12.Text = "About";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.White);
            this.Controls.Add(this.Dark);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Themes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Form_StyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroRadioButton Dark;
        private MetroFramework.Controls.MetroRadioButton White;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Components.MetroStyleManager Form_StyleManager;
        private MetroFramework.Controls.MetroButton Back;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroLabel metroLabel12;
    }
}