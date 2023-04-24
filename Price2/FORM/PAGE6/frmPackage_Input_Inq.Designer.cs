namespace Price2
{
    partial class frmPackage_Input_Inq
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInq = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.產品號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.材積 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.箱量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.淨重 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.毛重 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.線路 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.儲存日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Controls.Add(this.lblCount);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.txtCustomer);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.btnPrint);
            this.groupBox.Controls.Add(this.txtCustomerID);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 10F);
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(1124, 521);
            this.groupBox.TabIndex = 9;
            this.groupBox.TabStop = false;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCount.ForeColor = System.Drawing.Color.Blue;
            this.lblCount.Location = new System.Drawing.Point(909, 78);
            this.lblCount.Name = "lblCount";
            this.lblCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCount.Size = new System.Drawing.Size(149, 31);
            this.lblCount.TabIndex = 123;
            this.lblCount.Text = "資料筆數：0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(875, 28);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 32);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomer.Location = new System.Drawing.Point(536, 28);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(81, 31);
            this.txtCustomer.TabIndex = 112;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(37, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 31);
            this.label5.TabIndex = 110;
            this.label5.Text = "產品號：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInq.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInq.Location = new System.Drawing.Point(656, 26);
            this.btnInq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(67, 32);
            this.btnInq.TabIndex = 93;
            this.btnInq.Text = "搜尋";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(440, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 31);
            this.label6.TabIndex = 113;
            this.label6.Text = "客戶：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrint.Location = new System.Drawing.Point(802, 28);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(67, 32);
            this.btnPrint.TabIndex = 92;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomerID.Location = new System.Drawing.Point(133, 28);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(300, 31);
            this.txtCustomerID.TabIndex = 111;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.產品號,
            this.材積,
            this.箱量,
            this.淨重,
            this.毛重,
            this.客戶,
            this.線路,
            this.用戶,
            this.儲存日期});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(41, 111);
            this.dgvData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 21;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1051, 376);
            this.dgvData.TabIndex = 80;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // 產品號
            // 
            this.產品號.DataPropertyName = "產品號";
            this.產品號.FillWeight = 200F;
            this.產品號.HeaderText = "產品號";
            this.產品號.MinimumWidth = 200;
            this.產品號.Name = "產品號";
            this.產品號.ReadOnly = true;
            this.產品號.Width = 200;
            // 
            // 材積
            // 
            this.材積.DataPropertyName = "材積";
            this.材積.HeaderText = "材積";
            this.材積.MinimumWidth = 100;
            this.材積.Name = "材積";
            this.材積.ReadOnly = true;
            this.材積.Width = 125;
            // 
            // 箱量
            // 
            this.箱量.DataPropertyName = "箱量";
            this.箱量.HeaderText = "箱量";
            this.箱量.MinimumWidth = 100;
            this.箱量.Name = "箱量";
            this.箱量.ReadOnly = true;
            this.箱量.Width = 125;
            // 
            // 淨重
            // 
            this.淨重.DataPropertyName = "淨重";
            this.淨重.HeaderText = "淨重";
            this.淨重.MinimumWidth = 100;
            this.淨重.Name = "淨重";
            this.淨重.ReadOnly = true;
            this.淨重.Width = 125;
            // 
            // 毛重
            // 
            this.毛重.DataPropertyName = "毛重";
            this.毛重.HeaderText = "毛重";
            this.毛重.MinimumWidth = 100;
            this.毛重.Name = "毛重";
            this.毛重.ReadOnly = true;
            this.毛重.Width = 125;
            // 
            // 客戶
            // 
            this.客戶.DataPropertyName = "客戶";
            this.客戶.FillWeight = 125F;
            this.客戶.HeaderText = "客戶";
            this.客戶.MinimumWidth = 125;
            this.客戶.Name = "客戶";
            this.客戶.ReadOnly = true;
            this.客戶.Width = 125;
            // 
            // 線路
            // 
            this.線路.DataPropertyName = "線路";
            this.線路.FillWeight = 125F;
            this.線路.HeaderText = "線路";
            this.線路.MinimumWidth = 125;
            this.線路.Name = "線路";
            this.線路.ReadOnly = true;
            this.線路.Width = 125;
            // 
            // 用戶
            // 
            this.用戶.DataPropertyName = "用戶";
            this.用戶.FillWeight = 125F;
            this.用戶.HeaderText = "用戶";
            this.用戶.MinimumWidth = 125;
            this.用戶.Name = "用戶";
            this.用戶.ReadOnly = true;
            this.用戶.Width = 125;
            // 
            // 儲存日期
            // 
            this.儲存日期.DataPropertyName = "儲存日期";
            this.儲存日期.FillWeight = 150F;
            this.儲存日期.HeaderText = "最後儲存日期";
            this.儲存日期.MinimumWidth = 150;
            this.儲存日期.Name = "儲存日期";
            this.儲存日期.ReadOnly = true;
            this.儲存日期.Width = 150;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(729, 27);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(67, 32);
            this.btnClear.TabIndex = 124;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmPackage_Input_Inq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 521);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPackage_Input_Inq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "產品號查詢";
            this.Load += new System.EventHandler(this.frmPackage_Input_Inq_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn 產品號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 材積;
        private System.Windows.Forms.DataGridViewTextBoxColumn 箱量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 淨重;
        private System.Windows.Forms.DataGridViewTextBoxColumn 毛重;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶;
        private System.Windows.Forms.DataGridViewTextBoxColumn 線路;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用戶;
        private System.Windows.Forms.DataGridViewTextBoxColumn 儲存日期;
        private System.Windows.Forms.Button btnClear;
    }
}