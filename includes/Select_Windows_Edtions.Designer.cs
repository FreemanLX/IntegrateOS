namespace IntegrateOS
{
    partial class Select_Windows_Edition
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
            MetroFramework.MetroThemeStyle metroThemeStyle1 = new MetroFramework.MetroThemeStyle();
            MetroFramework.MetroThemeStyle metroThemeStyle2 = new MetroFramework.MetroThemeStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Back = new MetroFramework.Controls.MetroButton();
            this.Refresh = new MetroFramework.Controls.MetroButton();
            this.Windows_Editions_List = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Compression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Windows_Editions_List)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 333);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(10, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Visible = false;
            // 
            // Back
            // 
            this.Back.FlatAppearance.BorderSize = 0;
            this.Back.Location = new System.Drawing.Point(29, 70);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(50, 50);
            this.Back.TabIndex = 25;
            this.Back.Theme = metroThemeStyle1;
            this.Back.UseCustomForeColor = false;
            this.Back.UseSelectable = true;
            this.Back.UseStyleColors = false;
            this.Back.Click += new System.EventHandler(this.Moving_Selection_OS_Click);
            // 
            // Refresh
            // 
            this.Refresh.FlatAppearance.BorderSize = 0;
            this.Refresh.Location = new System.Drawing.Point(89, 70);
            this.Refresh.Name = "Back";
            this.Refresh.Size = new System.Drawing.Size(50, 50);
            this.Refresh.TabIndex = 25;
            this.Refresh.Theme = metroThemeStyle2;
            this.Refresh.UseCustomForeColor = false;
            this.Refresh.UseSelectable = true;
            this.Refresh.UseStyleColors = false;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Windows_Editions_List
            // 
            this.Windows_Editions_List.AllowUserToAddRows = false;
            this.Windows_Editions_List.AllowUserToDeleteRows = false;
            this.Windows_Editions_List.AllowUserToResizeColumns = false;
            this.Windows_Editions_List.AllowUserToResizeRows = false;
            this.Windows_Editions_List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Windows_Editions_List.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Windows_Editions_List.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Windows_Editions_List.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Windows_Editions_List.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Windows_Editions_List.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Windows_Editions_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Windows_Editions_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Compression});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Windows_Editions_List.DefaultCellStyle = dataGridViewCellStyle2;
            this.Windows_Editions_List.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Windows_Editions_List.EnableHeadersVisualStyles = false;
            this.Windows_Editions_List.Location = new System.Drawing.Point(23, 154);
            this.Windows_Editions_List.MultiSelect = false;
            this.Windows_Editions_List.Name = "Windows_Editions_List";
            this.Windows_Editions_List.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Windows_Editions_List.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Windows_Editions_List.RowHeadersVisible = false;
            this.Windows_Editions_List.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Windows_Editions_List.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Windows_Editions_List.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Windows_Editions_List.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Windows_Editions_List.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Windows_Editions_List.ShowCellErrors = false;
            this.Windows_Editions_List.ShowCellToolTips = false;
            this.Windows_Editions_List.ShowEditingIcon = false;
            this.Windows_Editions_List.ShowRowErrors = false;
            this.Windows_Editions_List.Size = new System.Drawing.Size(754, 362);
            this.Windows_Editions_List.TabIndex = 16;
            this.Windows_Editions_List.TabStop = false;
            this.Windows_Editions_List.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Windows_Editions_List_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Windows";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 50F;
            this.Column3.HeaderText = "File size";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Compression
            // 
            this.Compression.FillWeight = 50F;
            this.Compression.HeaderText = "Description";
            this.Compression.Name = "Compression";
            this.Compression.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(0, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 2);
            this.label1.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(0, 539);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(800, 2);
            this.label2.TabIndex = 36;
            // 
            // Select_Windows_Edition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Windows_Editions_List);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Select_Windows_Edition";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Select Windows Editions";
            this.Load += new System.EventHandler(this.Form12_Load);
            this.Shown += new System.EventHandler(this.Select_Windows_Edition_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Windows_Editions_List)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private MetroFramework.Controls.MetroButton Back;
        private new MetroFramework.Controls.MetroButton Refresh;
        private System.Windows.Forms.DataGridView Windows_Editions_List;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Compression;
    }
}