namespace Price2
{
    partial class frmBOMPrice_Order
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
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.訂單編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.報價單號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.線路 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.數量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客訴 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.新建日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出貨日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.報價 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.換算價 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.匯率 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.利潤 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInq = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblSum = new System.Windows.Forms.Label();
            this.chkCustomer = new System.Windows.Forms.CheckBox();
            this.txtNewDate_S = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewDate_E = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkNewDate = new System.Windows.Forms.CheckBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkLine = new System.Windows.Forms.CheckBox();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkID = new System.Windows.Forms.CheckBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(1068, 525);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 51);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(494, 525);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 40);
            this.label2.TabIndex = 36;
            this.label2.Text = "客戶：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.客戶,
            this.訂單編號,
            this.PO,
            this.報價單號,
            this.客號,
            this.線路,
            this.數量,
            this.客訴,
            this.新建日期,
            this.出貨日期,
            this.報價,
            this.換算價,
            this.匯率,
            this.利潤});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(16, 36);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1398, 454);
            this.dgvData.TabIndex = 50;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // 客戶
            // 
            this.客戶.DataPropertyName = "客戶";
            this.客戶.HeaderText = "客戶";
            this.客戶.MinimumWidth = 6;
            this.客戶.Name = "客戶";
            this.客戶.ReadOnly = true;
            this.客戶.Width = 70;
            // 
            // 訂單編號
            // 
            this.訂單編號.DataPropertyName = "訂單編號";
            this.訂單編號.HeaderText = "訂單編號";
            this.訂單編號.MinimumWidth = 8;
            this.訂單編號.Name = "訂單編號";
            this.訂單編號.ReadOnly = true;
            this.訂單編號.Width = 150;
            // 
            // PO
            // 
            this.PO.DataPropertyName = "PO";
            this.PO.HeaderText = "P/O";
            this.PO.MinimumWidth = 8;
            this.PO.Name = "PO";
            this.PO.ReadOnly = true;
            this.PO.Width = 150;
            // 
            // 報價單號
            // 
            this.報價單號.DataPropertyName = "報價單號";
            this.報價單號.HeaderText = "報價單號";
            this.報價單號.MinimumWidth = 8;
            this.報價單號.Name = "報價單號";
            this.報價單號.ReadOnly = true;
            this.報價單號.Width = 150;
            // 
            // 客號
            // 
            this.客號.DataPropertyName = "客號";
            this.客號.HeaderText = "客號";
            this.客號.MinimumWidth = 6;
            this.客號.Name = "客號";
            this.客號.ReadOnly = true;
            this.客號.Width = 180;
            // 
            // 線路
            // 
            this.線路.DataPropertyName = "線路";
            this.線路.HeaderText = "線路";
            this.線路.MinimumWidth = 6;
            this.線路.Name = "線路";
            this.線路.ReadOnly = true;
            this.線路.Width = 70;
            // 
            // 數量
            // 
            this.數量.DataPropertyName = "數量";
            this.數量.HeaderText = "數量";
            this.數量.MinimumWidth = 6;
            this.數量.Name = "數量";
            this.數量.ReadOnly = true;
            this.數量.Width = 70;
            // 
            // 客訴
            // 
            this.客訴.DataPropertyName = "客訴";
            this.客訴.HeaderText = "客訴";
            this.客訴.MinimumWidth = 8;
            this.客訴.Name = "客訴";
            this.客訴.ReadOnly = true;
            this.客訴.Width = 150;
            // 
            // 新建日期
            // 
            this.新建日期.DataPropertyName = "新建日期";
            this.新建日期.HeaderText = "新建日期";
            this.新建日期.MinimumWidth = 6;
            this.新建日期.Name = "新建日期";
            this.新建日期.ReadOnly = true;
            this.新建日期.Width = 130;
            // 
            // 出貨日期
            // 
            this.出貨日期.DataPropertyName = "出貨日期";
            this.出貨日期.HeaderText = "出貨日期";
            this.出貨日期.MinimumWidth = 6;
            this.出貨日期.Name = "出貨日期";
            this.出貨日期.ReadOnly = true;
            this.出貨日期.Width = 130;
            // 
            // 報價
            // 
            this.報價.DataPropertyName = "報價";
            this.報價.HeaderText = "報價";
            this.報價.MinimumWidth = 6;
            this.報價.Name = "報價";
            this.報價.ReadOnly = true;
            this.報價.Width = 150;
            // 
            // 換算價
            // 
            this.換算價.DataPropertyName = "換算價";
            this.換算價.HeaderText = "換算價";
            this.換算價.MinimumWidth = 6;
            this.換算價.Name = "換算價";
            this.換算價.ReadOnly = true;
            this.換算價.Width = 150;
            // 
            // 匯率
            // 
            this.匯率.DataPropertyName = "匯率";
            this.匯率.HeaderText = "匯率";
            this.匯率.MinimumWidth = 8;
            this.匯率.Name = "匯率";
            this.匯率.ReadOnly = true;
            this.匯率.Width = 150;
            // 
            // 利潤
            // 
            this.利潤.DataPropertyName = "利潤";
            this.利潤.HeaderText = "利潤%";
            this.利潤.MinimumWidth = 6;
            this.利潤.Name = "利潤";
            this.利潤.ReadOnly = true;
            this.利潤.Width = 150;
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInq.Location = new System.Drawing.Point(968, 525);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(94, 51);
            this.btnInq.TabIndex = 51;
            this.btnInq.Text = "搜尋";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.Location = new System.Drawing.Point(867, 525);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 51);
            this.btnClear.TabIndex = 54;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblSum
            // 
            this.lblSum.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSum.ForeColor = System.Drawing.Color.Red;
            this.lblSum.Location = new System.Drawing.Point(1198, 576);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(207, 40);
            this.lblSum.TabIndex = 59;
            this.lblSum.Text = "總數量：";
            this.lblSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkCustomer
            // 
            this.chkCustomer.AutoSize = true;
            this.chkCustomer.BackColor = System.Drawing.Color.Transparent;
            this.chkCustomer.Checked = true;
            this.chkCustomer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCustomer.ForeColor = System.Drawing.Color.Blue;
            this.chkCustomer.Location = new System.Drawing.Point(690, 531);
            this.chkCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCustomer.Name = "chkCustomer";
            this.chkCustomer.Size = new System.Drawing.Size(84, 28);
            this.chkCustomer.TabIndex = 61;
            this.chkCustomer.Text = "全部";
            this.chkCustomer.UseVisualStyleBackColor = false;
            this.chkCustomer.CheckedChanged += new System.EventHandler(this.chkCustomer_CheckedChanged);
            // 
            // txtNewDate_S
            // 
            this.txtNewDate_S.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtNewDate_S.Location = new System.Drawing.Point(162, 620);
            this.txtNewDate_S.Name = "txtNewDate_S";
            this.txtNewDate_S.Size = new System.Drawing.Size(152, 36);
            this.txtNewDate_S.TabIndex = 62;
            this.txtNewDate_S.Text = "(ALL)";
            this.txtNewDate_S.Enter += new System.EventHandler(this.txtNewDate_S_Enter);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(6, 620);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 40);
            this.label5.TabIndex = 63;
            this.label5.Text = "新建日期：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewDate_E
            // 
            this.txtNewDate_E.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtNewDate_E.Location = new System.Drawing.Point(364, 620);
            this.txtNewDate_E.Name = "txtNewDate_E";
            this.txtNewDate_E.Size = new System.Drawing.Size(152, 36);
            this.txtNewDate_E.TabIndex = 64;
            this.txtNewDate_E.Text = "(ALL)";
            this.txtNewDate_E.Enter += new System.EventHandler(this.txtNewDate_E_Enter);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(318, 618);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 40);
            this.label4.TabIndex = 65;
            this.label4.Text = "至";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkNewDate
            // 
            this.chkNewDate.AutoSize = true;
            this.chkNewDate.BackColor = System.Drawing.Color.Transparent;
            this.chkNewDate.Checked = true;
            this.chkNewDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewDate.ForeColor = System.Drawing.Color.Blue;
            this.chkNewDate.Location = new System.Drawing.Point(526, 624);
            this.chkNewDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkNewDate.Name = "chkNewDate";
            this.chkNewDate.Size = new System.Drawing.Size(84, 28);
            this.chkNewDate.TabIndex = 66;
            this.chkNewDate.Text = "全部";
            this.chkNewDate.UseVisualStyleBackColor = false;
            this.chkNewDate.CheckedChanged += new System.EventHandler(this.chkNewDate_CheckedChanged);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Location = new System.Drawing.Point(1194, 525);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(212, 40);
            this.lblCount.TabIndex = 68;
            this.lblCount.Text = "筆數：";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomer.Location = new System.Drawing.Point(590, 525);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(91, 36);
            this.txtCustomer.TabIndex = 70;
            this.txtCustomer.Text = "(ALL)";
            this.txtCustomer.Enter += new System.EventHandler(this.txtCustomer_Enter);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(40, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 40);
            this.label1.TabIndex = 71;
            this.label1.Text = "線路：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChkLine
            // 
            this.ChkLine.AutoSize = true;
            this.ChkLine.BackColor = System.Drawing.Color.Transparent;
            this.ChkLine.Checked = true;
            this.ChkLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkLine.ForeColor = System.Drawing.Color.Blue;
            this.ChkLine.Location = new System.Drawing.Point(357, 531);
            this.ChkLine.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChkLine.Name = "ChkLine";
            this.ChkLine.Size = new System.Drawing.Size(84, 28);
            this.ChkLine.TabIndex = 72;
            this.ChkLine.Text = "全部";
            this.ChkLine.UseVisualStyleBackColor = false;
            this.ChkLine.CheckedChanged += new System.EventHandler(this.ChkLine_CheckedChanged);
            // 
            // txtLine
            // 
            this.txtLine.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLine.Location = new System.Drawing.Point(162, 525);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(186, 36);
            this.txtLine.TabIndex = 73;
            this.txtLine.Text = "(ALL)";
            this.txtLine.Enter += new System.EventHandler(this.txtLine_Enter);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(40, 572);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 40);
            this.label3.TabIndex = 74;
            this.label3.Text = "客號：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChkID
            // 
            this.ChkID.AutoSize = true;
            this.ChkID.BackColor = System.Drawing.Color.Transparent;
            this.ChkID.Checked = true;
            this.ChkID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkID.ForeColor = System.Drawing.Color.Blue;
            this.ChkID.Location = new System.Drawing.Point(357, 578);
            this.ChkID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChkID.Name = "ChkID";
            this.ChkID.Size = new System.Drawing.Size(84, 28);
            this.ChkID.TabIndex = 75;
            this.ChkID.Text = "全部";
            this.ChkID.UseVisualStyleBackColor = false;
            this.ChkID.CheckedChanged += new System.EventHandler(this.ChkID_CheckedChanged);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtID.Location = new System.Drawing.Point(162, 572);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(186, 36);
            this.txtID.TabIndex = 76;
            this.txtID.Text = "(ALL)";
            this.txtID.Enter += new System.EventHandler(this.txtID_Enter);
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.txtID);
            this.groupBox.Controls.Add(this.ChkID);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.txtLine);
            this.groupBox.Controls.Add(this.ChkLine);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.txtCustomer);
            this.groupBox.Controls.Add(this.lblCount);
            this.groupBox.Controls.Add(this.chkNewDate);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.txtNewDate_E);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.txtNewDate_S);
            this.groupBox.Controls.Add(this.chkCustomer);
            this.groupBox.Controls.Add(this.lblSum);
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(1438, 705);
            this.groupBox.TabIndex = 7;
            this.groupBox.TabStop = false;
            // 
            // frmBOMPrice_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1438, 705);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmBOMPrice_Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查詢訂單資料";
            this.Load += new System.EventHandler(this.frmBOMPrice_Order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶;
        private System.Windows.Forms.DataGridViewTextBoxColumn 訂單編號;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO;
        private System.Windows.Forms.DataGridViewTextBoxColumn 報價單號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 線路;
        private System.Windows.Forms.DataGridViewTextBoxColumn 數量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客訴;
        private System.Windows.Forms.DataGridViewTextBoxColumn 新建日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出貨日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 報價;
        private System.Windows.Forms.DataGridViewTextBoxColumn 換算價;
        private System.Windows.Forms.DataGridViewTextBoxColumn 匯率;
        private System.Windows.Forms.DataGridViewTextBoxColumn 利潤;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.CheckBox chkCustomer;
        private System.Windows.Forms.TextBox txtNewDate_S;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNewDate_E;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkNewDate;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ChkLine;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ChkID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.GroupBox groupBox;
    }
}