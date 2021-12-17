using System.Windows.Forms;
using MetroFramework.Controls;

namespace IntegrateOS
{
    partial class Select_Partition
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            MetroFramework.MetroThemeStyle metroThemeStyle2 = new MetroFramework.MetroThemeStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new MetroFramework.Controls.MetroButton();
            this.Partition_list = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Partition_list)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Location = new System.Drawing.Point(29, 70);
            this.button2.Name = "Back";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 25;
            this.button2.Theme = metroThemeStyle1;
            this.button2.UseCustomForeColor = false;
            this.button2.UseSelectable = true;
            this.button2.UseStyleColors = false;
            this.button2.Click += new System.EventHandler(this.Back_Click);
            // 
            // Partition_list
            // 
            this.Partition_list.AllowUserToAddRows = false;
            this.Partition_list.AllowUserToDeleteRows = false;
            this.Partition_list.AllowUserToResizeColumns = false;
            this.Partition_list.AllowUserToResizeRows = false;
            this.Partition_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Partition_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Partition_list.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Partition_list.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Partition_list.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Partition_list.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Partition_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Partition_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column3,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Partition_list.DefaultCellStyle = dataGridViewCellStyle2;
            this.Partition_list.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Partition_list.EnableHeadersVisualStyles = false;
            this.Partition_list.Location = new System.Drawing.Point(27, 161);
            this.Partition_list.MultiSelect = false;
            this.Partition_list.Name = "Partition_list";
            this.Partition_list.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Partition_list.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Partition_list.RowHeadersVisible = false;
            this.Partition_list.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Partition_list.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Partition_list.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Partition_list.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Partition_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Partition_list.ShowCellErrors = false;
            this.Partition_list.ShowCellToolTips = false;
            this.Partition_list.ShowEditingIcon = false;
            this.Partition_list.ShowRowErrors = false;
            this.Partition_list.Size = new System.Drawing.Size(750, 246);
            this.Partition_list.TabIndex = 15;
            this.Partition_list.TabStop = false;
            this.Partition_list.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PartitionList_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 50F;
            this.Column1.HeaderText = "Partition";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Partition Type";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Total Space";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Free Space";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // metroButton1
            // 
            this.metroButton1.FlatAppearance.BorderSize = 0;
            this.metroButton1.Location = new System.Drawing.Point(89, 70);
            this.metroButton1.Name = "Back";
            this.metroButton1.Size = new System.Drawing.Size(50, 50);
            this.metroButton1.TabIndex = 25;
            this.metroButton1.Theme = metroThemeStyle2;
            this.metroButton1.UseCustomForeColor = false;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = false;
            this.metroButton1.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(0, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(800, 2);
            this.label2.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(0, 539);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(800, 2);
            this.label3.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 21);
            this.label4.TabIndex = 39;
            this.label4.Text = "Format partition";
            this.label4.Click += new System.EventHandler(this.Format_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(23, 492);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(566, 21);
            this.label6.TabIndex = 41;
            this.label6.Text = "Warning: All the partitions listed here, can be installed with the selected Windo" +
    "ws";
            // 
            // Select_Partition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.Partition_list);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Select_Partition";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Select an available partition to install";
            this.Load += new System.EventHandler(this.Select_Partition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Partition_list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton button2;
        private System.Windows.Forms.DataGridView Partition_list;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
    }
}