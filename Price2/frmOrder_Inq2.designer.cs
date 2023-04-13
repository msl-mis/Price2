namespace Price2
{
    partial class frmOrder_Inq2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDate_E = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate_S = new System.Windows.Forms.TextBox();
            this.btnInq = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.訂單編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.一般訂單 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.外購訂單 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.電源訂單 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.光纖訂單 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.晶元訂單 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.成朋訂單 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.訂單日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.txtOrderID);
            this.groupBox.Controls.Add(this.lblCount);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.txtDate_E);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.txtDate_S);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.txtCustomer);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(1195, 602);
            this.groupBox.TabIndex = 8;
            this.groupBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(19, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 32);
            this.label4.TabIndex = 61;
            this.label4.Text = "訂單編號：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOrderID
            // 
            this.txtOrderID.BackColor = System.Drawing.Color.White;
            this.txtOrderID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtOrderID.Location = new System.Drawing.Point(152, 28);
            this.txtOrderID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(316, 31);
            this.txtOrderID.TabIndex = 60;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCount.ForeColor = System.Drawing.Color.Blue;
            this.lblCount.Location = new System.Drawing.Point(1052, 544);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(115, 32);
            this.lblCount.TabIndex = 59;
            this.lblCount.Text = "共：";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(291, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 32);
            this.label3.TabIndex = 58;
            this.label3.Text = "至";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate_E
            // 
            this.txtDate_E.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDate_E.Location = new System.Drawing.Point(332, 72);
            this.txtDate_E.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDate_E.Name = "txtDate_E";
            this.txtDate_E.Size = new System.Drawing.Size(136, 31);
            this.txtDate_E.TabIndex = 57;
            this.txtDate_E.Click += new System.EventHandler(this.txtDate_E_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(13, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 32);
            this.label1.TabIndex = 56;
            this.label1.Text = "新建日期：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate_S
            // 
            this.txtDate_S.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDate_S.Location = new System.Drawing.Point(152, 72);
            this.txtDate_S.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDate_S.Name = "txtDate_S";
            this.txtDate_S.Size = new System.Drawing.Size(136, 31);
            this.txtDate_S.TabIndex = 55;
            this.txtDate_S.Click += new System.EventHandler(this.txtDate_S_Click);
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInq.Location = new System.Drawing.Point(703, 28);
            this.btnInq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(84, 36);
            this.btnInq.TabIndex = 54;
            this.btnInq.Text = "查詢";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Location = new System.Drawing.Point(804, 28);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 36);
            this.btnClear.TabIndex = 52;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
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
            this.dgvData.Location = new System.Drawing.Point(39, 122);
            this.dgvData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1128, 420);
            this.dgvData.TabIndex = 50;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.一般訂單.DefaultCellStyle = dataGridViewCellStyle9;
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            this.外購訂單.DefaultCellStyle = dataGridViewCellStyle10;
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            this.電源訂單.DefaultCellStyle = dataGridViewCellStyle11;
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
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            this.光纖訂單.DefaultCellStyle = dataGridViewCellStyle12;
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
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N0";
            this.晶元訂單.DefaultCellStyle = dataGridViewCellStyle13;
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
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N0";
            this.成朋訂單.DefaultCellStyle = dataGridViewCellStyle14;
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
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(475, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 32);
            this.label2.TabIndex = 36;
            this.label2.Text = "客戶：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.White;
            this.txtCustomer.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomer.Location = new System.Drawing.Point(572, 28);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(101, 31);
            this.txtCustomer.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(804, 72);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 36);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmOrder_Inq2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 602);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmOrder_Inq2";
            this.Text = "訂單查詢";
            this.Load += new System.EventHandler(this.frmOrder_Inq_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDate_E;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDate_S;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Button btnClear;
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