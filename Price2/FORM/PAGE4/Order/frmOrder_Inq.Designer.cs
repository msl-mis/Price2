namespace Price2
{
    partial class frmOrder_Inq
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDate_E = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate_S = new System.Windows.Forms.TextBox();
            this.btnInq = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.訂單編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.一般訂單 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.外購訂單 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.電源訂單 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.光纖訂單 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.晶元訂單 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.成朋訂單 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.訂單日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.btnDeleteAll);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.txtOrderID);
            this.groupBox.Controls.Add(this.lblCount);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.txtDate_E);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.txtDate_S);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Controls.Add(this.btnDelete);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.txtCustomer);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox.Size = new System.Drawing.Size(896, 482);
            this.groupBox.TabIndex = 8;
            this.groupBox.TabStop = false;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDeleteAll.Location = new System.Drawing.Point(670, 22);
            this.btnDeleteAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(96, 29);
            this.btnDeleteAll.TabIndex = 62;
            this.btnDeleteAll.Text = "全部刪除";
            this.btnDeleteAll.UseVisualStyleBackColor = false;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(14, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 26);
            this.label4.TabIndex = 61;
            this.label4.Text = "訂單編號：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOrderID
            // 
            this.txtOrderID.BackColor = System.Drawing.Color.White;
            this.txtOrderID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtOrderID.Location = new System.Drawing.Point(114, 22);
            this.txtOrderID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(238, 27);
            this.txtOrderID.TabIndex = 60;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCount.ForeColor = System.Drawing.Color.Blue;
            this.lblCount.Location = new System.Drawing.Point(789, 435);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(86, 26);
            this.lblCount.TabIndex = 59;
            this.lblCount.Text = "共：";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(218, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 26);
            this.label3.TabIndex = 58;
            this.label3.Text = "至";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate_E
            // 
            this.txtDate_E.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDate_E.Location = new System.Drawing.Point(249, 58);
            this.txtDate_E.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDate_E.Name = "txtDate_E";
            this.txtDate_E.Size = new System.Drawing.Size(103, 27);
            this.txtDate_E.TabIndex = 57;
            this.txtDate_E.Click += new System.EventHandler(this.txtDate_E_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(10, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 26);
            this.label1.TabIndex = 56;
            this.label1.Text = "新建日期：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate_S
            // 
            this.txtDate_S.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDate_S.Location = new System.Drawing.Point(114, 58);
            this.txtDate_S.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDate_S.Name = "txtDate_S";
            this.txtDate_S.Size = new System.Drawing.Size(103, 27);
            this.txtDate_S.TabIndex = 55;
            this.txtDate_S.Click += new System.EventHandler(this.txtDate_S_Click);
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInq.Location = new System.Drawing.Point(527, 22);
            this.btnInq.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(63, 29);
            this.btnInq.TabIndex = 54;
            this.btnInq.Text = "查詢";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Location = new System.Drawing.Point(603, 22);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(63, 29);
            this.btnClear.TabIndex = 52;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(527, 60);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 29);
            this.btnDelete.TabIndex = 51;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.客戶,
            this.訂單編號,
            this.一般訂單,
            this.外購訂單,
            this.電源訂單,
            this.光纖訂單,
            this.晶元訂單,
            this.成朋訂單,
            this.訂單日期});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(29, 98);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(846, 336);
            this.dgvData.TabIndex = 50;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(356, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 26);
            this.label2.TabIndex = 36;
            this.label2.Text = "客戶：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.White;
            this.txtCustomer.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomer.Location = new System.Drawing.Point(429, 22);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(77, 27);
            this.txtCustomer.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(603, 58);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 29);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // 客戶
            // 
            this.客戶.DataPropertyName = "客戶";
            this.客戶.FillWeight = 55.3934F;
            this.客戶.HeaderText = "客戶";
            this.客戶.MinimumWidth = 6;
            this.客戶.Name = "客戶";
            this.客戶.ReadOnly = true;
            // 
            // 訂單編號
            // 
            this.訂單編號.DataPropertyName = "訂單編號";
            this.訂單編號.HeaderText = "訂單編號";
            this.訂單編號.MinimumWidth = 100;
            this.訂單編號.Name = "訂單編號";
            this.訂單編號.ReadOnly = true;
            // 
            // 一般訂單
            // 
            this.一般訂單.DataPropertyName = "一般訂單";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.一般訂單.DefaultCellStyle = dataGridViewCellStyle2;
            this.一般訂單.FillWeight = 55.3934F;
            this.一般訂單.HeaderText = "一般訂單";
            this.一般訂單.MinimumWidth = 6;
            this.一般訂單.Name = "一般訂單";
            this.一般訂單.ReadOnly = true;
            this.一般訂單.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 外購訂單
            // 
            this.外購訂單.DataPropertyName = "外購訂單";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.外購訂單.DefaultCellStyle = dataGridViewCellStyle3;
            this.外購訂單.FillWeight = 55.3934F;
            this.外購訂單.HeaderText = "外購訂單";
            this.外購訂單.MinimumWidth = 6;
            this.外購訂單.Name = "外購訂單";
            this.外購訂單.ReadOnly = true;
            this.外購訂單.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 電源訂單
            // 
            this.電源訂單.DataPropertyName = "電源訂單";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.電源訂單.DefaultCellStyle = dataGridViewCellStyle4;
            this.電源訂單.FillWeight = 55.3934F;
            this.電源訂單.HeaderText = "電源訂單";
            this.電源訂單.MinimumWidth = 6;
            this.電源訂單.Name = "電源訂單";
            this.電源訂單.ReadOnly = true;
            this.電源訂單.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 光纖訂單
            // 
            this.光纖訂單.DataPropertyName = "光纖訂單";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.光纖訂單.DefaultCellStyle = dataGridViewCellStyle5;
            this.光纖訂單.FillWeight = 55.3934F;
            this.光纖訂單.HeaderText = "光纖訂單";
            this.光纖訂單.MinimumWidth = 6;
            this.光纖訂單.Name = "光纖訂單";
            this.光纖訂單.ReadOnly = true;
            this.光纖訂單.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 晶元訂單
            // 
            this.晶元訂單.DataPropertyName = "晶元訂單";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.晶元訂單.DefaultCellStyle = dataGridViewCellStyle6;
            this.晶元訂單.FillWeight = 55.3934F;
            this.晶元訂單.HeaderText = "晶元訂單";
            this.晶元訂單.MinimumWidth = 6;
            this.晶元訂單.Name = "晶元訂單";
            this.晶元訂單.ReadOnly = true;
            this.晶元訂單.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 成朋訂單
            // 
            this.成朋訂單.DataPropertyName = "成朋訂單";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.成朋訂單.DefaultCellStyle = dataGridViewCellStyle7;
            this.成朋訂單.FillWeight = 55.3934F;
            this.成朋訂單.HeaderText = "成朋訂單";
            this.成朋訂單.MinimumWidth = 6;
            this.成朋訂單.Name = "成朋訂單";
            this.成朋訂單.ReadOnly = true;
            this.成朋訂單.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 訂單日期
            // 
            this.訂單日期.DataPropertyName = "訂單日期";
            this.訂單日期.FillWeight = 55.3934F;
            this.訂單日期.HeaderText = "訂單日期";
            this.訂單日期.MinimumWidth = 6;
            this.訂單日期.Name = "訂單日期";
            this.訂單日期.ReadOnly = true;
            this.訂單日期.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmOrder_Inq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 482);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmOrder_Inq";
            this.Text = "訂單查詢";
            this.Load += new System.EventHandler(this.frmOrder_Inq_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDate_E;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDate_S;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶;
        private System.Windows.Forms.DataGridViewTextBoxColumn 訂單編號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 一般訂單;
        private System.Windows.Forms.DataGridViewTextBoxColumn 外購訂單;
        private System.Windows.Forms.DataGridViewTextBoxColumn 電源訂單;
        private System.Windows.Forms.DataGridViewTextBoxColumn 光纖訂單;
        private System.Windows.Forms.DataGridViewTextBoxColumn 晶元訂單;
        private System.Windows.Forms.DataGridViewTextBoxColumn 成朋訂單;
        private System.Windows.Forms.DataGridViewTextBoxColumn 訂單日期;
    }
}