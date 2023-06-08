namespace Price2
{
    partial class frmBOM_TrackChanges
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.radYear = new System.Windows.Forms.RadioButton();
            this.radMonth = new System.Windows.Forms.RadioButton();
            this.radWeek = new System.Windows.Forms.RadioButton();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.b_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b_before = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b_after = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.radAll);
            this.groupBox.Controls.Add(this.radYear);
            this.groupBox.Controls.Add(this.radMonth);
            this.groupBox.Controls.Add(this.radWeek);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox.Size = new System.Drawing.Size(802, 413);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(241, 24);
            this.radAll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(55, 19);
            this.radAll.TabIndex = 54;
            this.radAll.Text = "全部";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.CheckedChanged += new System.EventHandler(this.radAll_CheckedChanged);
            // 
            // radYear
            // 
            this.radYear.AutoSize = true;
            this.radYear.Location = new System.Drawing.Point(167, 24);
            this.radYear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radYear.Name = "radYear";
            this.radYear.Size = new System.Drawing.Size(55, 19);
            this.radYear.TabIndex = 53;
            this.radYear.Text = "半年";
            this.radYear.UseVisualStyleBackColor = true;
            this.radYear.CheckedChanged += new System.EventHandler(this.radYear_CheckedChanged);
            // 
            // radMonth
            // 
            this.radMonth.AutoSize = true;
            this.radMonth.Location = new System.Drawing.Point(91, 24);
            this.radMonth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radMonth.Name = "radMonth";
            this.radMonth.Size = new System.Drawing.Size(55, 19);
            this.radMonth.TabIndex = 52;
            this.radMonth.Text = "一月";
            this.radMonth.UseVisualStyleBackColor = true;
            this.radMonth.CheckedChanged += new System.EventHandler(this.radMonth_CheckedChanged);
            // 
            // radWeek
            // 
            this.radWeek.AutoSize = true;
            this.radWeek.Checked = true;
            this.radWeek.Location = new System.Drawing.Point(17, 24);
            this.radWeek.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radWeek.Name = "radWeek";
            this.radWeek.Size = new System.Drawing.Size(55, 19);
            this.radWeek.TabIndex = 51;
            this.radWeek.TabStop = true;
            this.radWeek.Text = "一週";
            this.radWeek.UseVisualStyleBackColor = true;
            this.radWeek.CheckedChanged += new System.EventHandler(this.radWeek_CheckedChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.b_date,
            this.b_username,
            this.b_before,
            this.b_after});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(17, 61);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(774, 333);
            this.dgvData.TabIndex = 50;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(346, 20);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 33);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // b_date
            // 
            this.b_date.DataPropertyName = "b_date";
            this.b_date.FillWeight = 150F;
            this.b_date.HeaderText = "修改日期";
            this.b_date.MinimumWidth = 100;
            this.b_date.Name = "b_date";
            this.b_date.ReadOnly = true;
            // 
            // b_username
            // 
            this.b_username.DataPropertyName = "b_username";
            this.b_username.FillWeight = 150F;
            this.b_username.HeaderText = "修改人員";
            this.b_username.MinimumWidth = 100;
            this.b_username.Name = "b_username";
            this.b_username.ReadOnly = true;
            // 
            // b_before
            // 
            this.b_before.DataPropertyName = "b_before";
            this.b_before.FillWeight = 300F;
            this.b_before.HeaderText = "變動前";
            this.b_before.MinimumWidth = 100;
            this.b_before.Name = "b_before";
            this.b_before.ReadOnly = true;
            // 
            // b_after
            // 
            this.b_after.DataPropertyName = "b_after";
            this.b_after.FillWeight = 500F;
            this.b_after.HeaderText = "變動後";
            this.b_after.MinimumWidth = 200;
            this.b_after.Name = "b_after";
            this.b_after.ReadOnly = true;
            // 
            // frmBOM_TrackChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 413);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmBOM_TrackChanges";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BOM產品建立修改紀錄";
            this.Activated += new System.EventHandler(this.frmBOM_TrackChanges_Activated);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.RadioButton radYear;
        private System.Windows.Forms.RadioButton radMonth;
        private System.Windows.Forms.RadioButton radWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn b_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn b_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn b_before;
        private System.Windows.Forms.DataGridViewTextBoxColumn b_after;
    }
}