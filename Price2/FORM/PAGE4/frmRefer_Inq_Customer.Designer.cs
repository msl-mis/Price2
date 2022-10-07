namespace Price2
{
    partial class frmRefer_Inq_Customer
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
            this.lblCount = new System.Windows.Forms.Label();
            this.chkOutsourcing = new System.Windows.Forms.CheckBox();
            this.chkDeal = new System.Windows.Forms.CheckBox();
            this.chkNoQuote = new System.Windows.Forms.CheckBox();
            this.txtDate_E = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDate_S = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.客號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.參照法 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.線路 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInq = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.lblCount);
            this.groupBox.Controls.Add(this.chkOutsourcing);
            this.groupBox.Controls.Add(this.chkDeal);
            this.groupBox.Controls.Add(this.chkNoQuote);
            this.groupBox.Controls.Add(this.txtDate_E);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.txtDate_S);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.txtLine);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.txtName);
            this.groupBox.Controls.Add(this.btnDelete);
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.btnExport);
            this.groupBox.Controls.Add(this.txtID);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(1910, 933);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Location = new System.Drawing.Point(862, 79);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(187, 31);
            this.lblCount.TabIndex = 63;
            this.lblCount.Text = "0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkOutsourcing
            // 
            this.chkOutsourcing.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOutsourcing.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkOutsourcing.ForeColor = System.Drawing.Color.Blue;
            this.chkOutsourcing.Location = new System.Drawing.Point(600, 79);
            this.chkOutsourcing.Name = "chkOutsourcing";
            this.chkOutsourcing.Size = new System.Drawing.Size(92, 31);
            this.chkOutsourcing.TabIndex = 62;
            this.chkOutsourcing.Text = "外購";
            this.chkOutsourcing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOutsourcing.UseVisualStyleBackColor = true;
            // 
            // chkDeal
            // 
            this.chkDeal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDeal.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkDeal.ForeColor = System.Drawing.Color.Blue;
            this.chkDeal.Location = new System.Drawing.Point(502, 79);
            this.chkDeal.Name = "chkDeal";
            this.chkDeal.Size = new System.Drawing.Size(92, 31);
            this.chkDeal.TabIndex = 61;
            this.chkDeal.Text = "成交";
            this.chkDeal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDeal.UseVisualStyleBackColor = true;
            // 
            // chkNoQuote
            // 
            this.chkNoQuote.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoQuote.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkNoQuote.ForeColor = System.Drawing.Color.Blue;
            this.chkNoQuote.Location = new System.Drawing.Point(698, 79);
            this.chkNoQuote.Name = "chkNoQuote";
            this.chkNoQuote.Size = new System.Drawing.Size(92, 31);
            this.chkNoQuote.TabIndex = 60;
            this.chkNoQuote.Text = "無報價";
            this.chkNoQuote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoQuote.UseVisualStyleBackColor = true;
            // 
            // txtDate_E
            // 
            this.txtDate_E.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDate_E.Location = new System.Drawing.Point(357, 79);
            this.txtDate_E.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDate_E.Name = "txtDate_E";
            this.txtDate_E.Size = new System.Drawing.Size(101, 31);
            this.txtDate_E.TabIndex = 59;
            this.txtDate_E.Click += new System.EventHandler(this.txtDate_E_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 31);
            this.label4.TabIndex = 58;
            this.label4.Text = "參照法儲存日期：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate_S
            // 
            this.txtDate_S.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDate_S.Location = new System.Drawing.Point(199, 79);
            this.txtDate_S.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDate_S.Name = "txtDate_S";
            this.txtDate_S.Size = new System.Drawing.Size(101, 31);
            this.txtDate_S.TabIndex = 57;
            this.txtDate_S.Click += new System.EventHandler(this.txtDate_S_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(306, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 31);
            this.label5.TabIndex = 56;
            this.label5.Text = "至";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLine
            // 
            this.txtLine.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLine.Location = new System.Drawing.Point(640, 31);
            this.txtLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(91, 31);
            this.txtLine.TabIndex = 55;
            this.txtLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLine_KeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(382, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 31);
            this.label3.TabIndex = 54;
            this.label3.Text = "客戶：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtName.Location = new System.Drawing.Point(461, 31);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(91, 31);
            this.txtName.TabIndex = 53;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDelete.Location = new System.Drawing.Point(949, 27);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 42);
            this.btnDelete.TabIndex = 52;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.Location = new System.Drawing.Point(859, 27);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 42);
            this.btnClear.TabIndex = 51;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.客號,
            this.參照法,
            this.線路,
            this.客戶});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(30, 133);
            this.dgvData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1846, 769);
            this.dgvData.TabIndex = 50;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // 客號
            // 
            this.客號.DataPropertyName = "客號";
            this.客號.HeaderText = "客號";
            this.客號.MinimumWidth = 6;
            this.客號.Name = "客號";
            this.客號.ReadOnly = true;
            this.客號.Width = 150;
            // 
            // 參照法
            // 
            this.參照法.DataPropertyName = "參照法";
            this.參照法.HeaderText = "參照法";
            this.參照法.MinimumWidth = 6;
            this.參照法.Name = "參照法";
            this.參照法.ReadOnly = true;
            this.參照法.Width = 1400;
            // 
            // 線路
            // 
            this.線路.DataPropertyName = "線路";
            this.線路.HeaderText = "線路";
            this.線路.MinimumWidth = 6;
            this.線路.Name = "線路";
            this.線路.ReadOnly = true;
            this.線路.Width = 150;
            // 
            // 客戶
            // 
            this.客戶.DataPropertyName = "客戶";
            this.客戶.HeaderText = "客戶";
            this.客戶.MinimumWidth = 6;
            this.客戶.Name = "客戶";
            this.客戶.ReadOnly = true;
            this.客戶.Width = 150;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 31);
            this.label2.TabIndex = 36;
            this.label2.Text = "客號：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExport.Location = new System.Drawing.Point(1039, 27);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(84, 42);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "匯出";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtID.Location = new System.Drawing.Point(95, 31);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(281, 31);
            this.txtID.TabIndex = 3;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(1129, 27);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 42);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInq.Location = new System.Drawing.Point(769, 27);
            this.btnInq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(84, 42);
            this.btnInq.TabIndex = 14;
            this.btnInq.Text = "搜尋";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(558, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 31);
            this.label1.TabIndex = 35;
            this.label1.Text = "線路：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmRefer_Inq_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1910, 933);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Name = "frmRefer_Inq_Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "選擇訂單的產品編號";
            this.Activated += new System.EventHandler(this.frmRefer_Inq_Customer_Activated);
            this.Load += new System.EventHandler(this.frmRefer_Inq_Customer_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkOutsourcing;
        private System.Windows.Forms.CheckBox chkDeal;
        private System.Windows.Forms.CheckBox chkNoQuote;
        private System.Windows.Forms.TextBox txtDate_E;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDate_S;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 參照法;
        private System.Windows.Forms.DataGridViewTextBoxColumn 線路;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶;
    }
}