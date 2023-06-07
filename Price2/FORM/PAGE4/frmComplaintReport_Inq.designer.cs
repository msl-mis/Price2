namespace Price2
{
    partial class frmComplaintReport_Inq
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label18 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblVendor = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工單號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工單客訴額NTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工廠累計賠償額NTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工廠累計賠償額RMB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工單新建日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客訴日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.備註 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.label18);
            this.groupBox.Controls.Add(this.btnPrint);
            this.groupBox.Controls.Add(this.lblVendor);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 10F);
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox.Size = new System.Drawing.Size(600, 360);
            this.groupBox.TabIndex = 12;
            this.groupBox.TabStop = false;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.客戶,
            this.工單號,
            this.工單客訴額NTD,
            this.工廠累計賠償額NTD,
            this.工廠累計賠償額RMB,
            this.工單新建日期,
            this.客訴日期,
            this.備註});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(11, 19);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("新細明體", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 21;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(582, 298);
            this.dgvData.TabIndex = 233;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(9, 326);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(268, 25);
            this.label18.TabIndex = 232;
            this.label18.Text = "注:工廠賠償金額=工單加總客訴額*20%";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrint.Location = new System.Drawing.Point(455, 324);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(50, 26);
            this.btnPrint.TabIndex = 231;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblVendor
            // 
            this.lblVendor.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblVendor.ForeColor = System.Drawing.Color.Red;
            this.lblVendor.Location = new System.Drawing.Point(812, 19);
            this.lblVendor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(68, 25);
            this.lblVendor.TabIndex = 128;
            this.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(526, 324);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 26);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // 客戶
            // 
            this.客戶.DataPropertyName = "客戶";
            this.客戶.HeaderText = "客戶";
            this.客戶.MinimumWidth = 6;
            this.客戶.Name = "客戶";
            this.客戶.ReadOnly = true;
            this.客戶.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 工單號
            // 
            this.工單號.DataPropertyName = "工單號";
            this.工單號.HeaderText = "工單號";
            this.工單號.MinimumWidth = 6;
            this.工單號.Name = "工單號";
            this.工單號.ReadOnly = true;
            this.工單號.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 工單客訴額NTD
            // 
            this.工單客訴額NTD.DataPropertyName = "工單客訴額(NTD)";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.工單客訴額NTD.DefaultCellStyle = dataGridViewCellStyle2;
            this.工單客訴額NTD.HeaderText = "工單客訴額(NTD)";
            this.工單客訴額NTD.MinimumWidth = 6;
            this.工單客訴額NTD.Name = "工單客訴額NTD";
            this.工單客訴額NTD.ReadOnly = true;
            this.工單客訴額NTD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 工廠累計賠償額NTD
            // 
            this.工廠累計賠償額NTD.DataPropertyName = "工廠累計賠償額(NTD)";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.工廠累計賠償額NTD.DefaultCellStyle = dataGridViewCellStyle3;
            this.工廠累計賠償額NTD.HeaderText = "工廠累計賠償額(NTD)";
            this.工廠累計賠償額NTD.MinimumWidth = 6;
            this.工廠累計賠償額NTD.Name = "工廠累計賠償額NTD";
            this.工廠累計賠償額NTD.ReadOnly = true;
            this.工廠累計賠償額NTD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 工廠累計賠償額RMB
            // 
            this.工廠累計賠償額RMB.DataPropertyName = "工廠累計賠償額(RMB)";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.工廠累計賠償額RMB.DefaultCellStyle = dataGridViewCellStyle4;
            this.工廠累計賠償額RMB.HeaderText = "工廠累計賠償額(RMB)";
            this.工廠累計賠償額RMB.MinimumWidth = 6;
            this.工廠累計賠償額RMB.Name = "工廠累計賠償額RMB";
            this.工廠累計賠償額RMB.ReadOnly = true;
            this.工廠累計賠償額RMB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 工單新建日期
            // 
            this.工單新建日期.DataPropertyName = "工單新建日期";
            this.工單新建日期.HeaderText = "工單新建日期";
            this.工單新建日期.MinimumWidth = 6;
            this.工單新建日期.Name = "工單新建日期";
            this.工單新建日期.ReadOnly = true;
            this.工單新建日期.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 客訴日期
            // 
            this.客訴日期.DataPropertyName = "客訴日期";
            this.客訴日期.HeaderText = "客訴日期";
            this.客訴日期.MinimumWidth = 6;
            this.客訴日期.Name = "客訴日期";
            this.客訴日期.ReadOnly = true;
            this.客訴日期.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 備註
            // 
            this.備註.DataPropertyName = "備註";
            this.備註.HeaderText = "備註";
            this.備註.MinimumWidth = 6;
            this.備註.Name = "備註";
            this.備註.ReadOnly = true;
            this.備註.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmComplaintReport_Inq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmComplaintReport_Inq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工廠累計賠償額明細";
            this.Load += new System.EventHandler(this.frmComplaintReport_Inq_Load);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工單號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工單客訴額NTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工廠累計賠償額NTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工廠累計賠償額RMB;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工單新建日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客訴日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備註;
    }
}