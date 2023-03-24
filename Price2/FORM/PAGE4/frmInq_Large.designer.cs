namespace Price2
{
    partial class frmInq_Large
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkDeal_Yet = new System.Windows.Forms.CheckBox();
            this.chkPlus = new System.Windows.Forms.CheckBox();
            this.chkMinus = new System.Windows.Forms.CheckBox();
            this.chkDeal = new System.Windows.Forms.CheckBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtCZF = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInq = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.數量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.差別報價 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.利潤 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.舊利潤 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.單價日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.儲存日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.lblVendor);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.txtVendor);
            this.groupBox.Controls.Add(this.tableLayoutPanel2);
            this.groupBox.Controls.Add(this.lblCount);
            this.groupBox.Controls.Add(this.txtCZF);
            this.groupBox.Controls.Add(this.label18);
            this.groupBox.Controls.Add(this.txtLength);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.txtCustomer);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.btnPrint);
            this.groupBox.Controls.Add(this.txtCustomerID);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 10F);
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(1181, 653);
            this.groupBox.TabIndex = 8;
            this.groupBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(900, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 31);
            this.label2.TabIndex = 126;
            this.label2.Text = "廠號：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVendor
            // 
            this.txtVendor.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVendor.Location = new System.Drawing.Point(996, 24);
            this.txtVendor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.Size = new System.Drawing.Size(80, 29);
            this.txtVendor.TabIndex = 127;
            this.txtVendor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVendor_KeyDown);
            this.txtVendor.Leave += new System.EventHandler(this.txtVendor_Leave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.chkDeal_Yet, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkPlus, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkMinus, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkDeal, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(44, 71);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(731, 33);
            this.tableLayoutPanel2.TabIndex = 125;
            // 
            // chkDeal_Yet
            // 
            this.chkDeal_Yet.AutoSize = true;
            this.chkDeal_Yet.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkDeal_Yet.ForeColor = System.Drawing.Color.Red;
            this.chkDeal_Yet.Location = new System.Drawing.Point(552, 5);
            this.chkDeal_Yet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkDeal_Yet.Name = "chkDeal_Yet";
            this.chkDeal_Yet.Size = new System.Drawing.Size(84, 22);
            this.chkDeal_Yet.TabIndex = 143;
            this.chkDeal_Yet.Text = "未成交";
            this.chkDeal_Yet.UseVisualStyleBackColor = true;
            this.chkDeal_Yet.CheckedChanged += new System.EventHandler(this.chkDeal_Yet_CheckedChanged);
            // 
            // chkPlus
            // 
            this.chkPlus.AutoSize = true;
            this.chkPlus.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkPlus.ForeColor = System.Drawing.Color.Red;
            this.chkPlus.Location = new System.Drawing.Point(6, 5);
            this.chkPlus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkPlus.Name = "chkPlus";
            this.chkPlus.Size = new System.Drawing.Size(166, 22);
            this.chkPlus.TabIndex = 3;
            this.chkPlus.Text = "量大單價>一般價";
            this.chkPlus.UseVisualStyleBackColor = true;
            // 
            // chkMinus
            // 
            this.chkMinus.AutoSize = true;
            this.chkMinus.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkMinus.ForeColor = System.Drawing.Color.Red;
            this.chkMinus.Location = new System.Drawing.Point(188, 5);
            this.chkMinus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkMinus.Name = "chkMinus";
            this.chkMinus.Size = new System.Drawing.Size(156, 22);
            this.chkMinus.TabIndex = 140;
            this.chkMinus.Text = "量大利潤是負數";
            this.chkMinus.UseVisualStyleBackColor = true;
            // 
            // chkDeal
            // 
            this.chkDeal.AutoSize = true;
            this.chkDeal.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkDeal.ForeColor = System.Drawing.Color.Red;
            this.chkDeal.Location = new System.Drawing.Point(370, 5);
            this.chkDeal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkDeal.Name = "chkDeal";
            this.chkDeal.Size = new System.Drawing.Size(84, 22);
            this.chkDeal.TabIndex = 141;
            this.chkDeal.Text = "已成交";
            this.chkDeal.UseVisualStyleBackColor = true;
            this.chkDeal.CheckedChanged += new System.EventHandler(this.chkDeal_CheckedChanged);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblCount.Location = new System.Drawing.Point(38, 122);
            this.lblCount.Name = "lblCount";
            this.lblCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCount.Size = new System.Drawing.Size(200, 31);
            this.lblCount.TabIndex = 123;
            this.lblCount.Text = "資料筆數：0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCZF
            // 
            this.txtCZF.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCZF.Location = new System.Drawing.Point(552, 24);
            this.txtCZF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCZF.Name = "txtCZF";
            this.txtCZF.Size = new System.Drawing.Size(160, 29);
            this.txtCZF.TabIndex = 122;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(718, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 31);
            this.label18.TabIndex = 120;
            this.label18.Text = "線長：";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLength
            // 
            this.txtLength.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLength.Location = new System.Drawing.Point(814, 24);
            this.txtLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(80, 29);
            this.txtLength.TabIndex = 121;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(1021, 71);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 28);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomer.Location = new System.Drawing.Point(108, 24);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(80, 29);
            this.txtCustomer.TabIndex = 112;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(194, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 31);
            this.label5.TabIndex = 110;
            this.label5.Text = "客號：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInq.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInq.Location = new System.Drawing.Point(875, 71);
            this.btnInq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(67, 28);
            this.btnInq.TabIndex = 93;
            this.btnInq.Text = "搜尋";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(12, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 31);
            this.label6.TabIndex = 113;
            this.label6.Text = "客戶：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrint.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrint.Location = new System.Drawing.Point(948, 71);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(67, 28);
            this.btnPrint.TabIndex = 92;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomerID.Location = new System.Drawing.Point(290, 24);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(160, 29);
            this.txtCustomerID.TabIndex = 111;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("新細明體", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.客戶,
            this.客號,
            this.數量,
            this.差別報價,
            this.利潤,
            this.舊利潤,
            this.單價日期,
            this.儲存日期});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(41, 155);
            this.dgvData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("新細明體", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 21;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1050, 420);
            this.dgvData.TabIndex = 80;
            // 
            // 客戶
            // 
            this.客戶.DataPropertyName = "客戶";
            this.客戶.FillWeight = 693.0073F;
            this.客戶.HeaderText = "客戶";
            this.客戶.MinimumWidth = 6;
            this.客戶.Name = "客戶";
            this.客戶.ReadOnly = true;
            this.客戶.Width = 125;
            // 
            // 客號
            // 
            this.客號.DataPropertyName = "客號";
            this.客號.FillWeight = 89.24592F;
            this.客號.HeaderText = "客號";
            this.客號.MinimumWidth = 6;
            this.客號.Name = "客號";
            this.客號.ReadOnly = true;
            this.客號.Width = 200;
            // 
            // 數量
            // 
            this.數量.DataPropertyName = "數量";
            this.數量.HeaderText = "數量(>=)";
            this.數量.MinimumWidth = 8;
            this.數量.Name = "數量";
            this.數量.ReadOnly = true;
            this.數量.Width = 125;
            // 
            // 差別報價
            // 
            this.差別報價.DataPropertyName = "差別報價";
            this.差別報價.HeaderText = "差別報價";
            this.差別報價.MinimumWidth = 6;
            this.差別報價.Name = "差別報價";
            this.差別報價.ReadOnly = true;
            this.差別報價.Width = 125;
            // 
            // 利潤
            // 
            this.利潤.DataPropertyName = "利潤";
            this.利潤.FillWeight = 0.09294103F;
            this.利潤.HeaderText = "利潤%";
            this.利潤.MinimumWidth = 6;
            this.利潤.Name = "利潤";
            this.利潤.ReadOnly = true;
            this.利潤.Width = 125;
            // 
            // 舊利潤
            // 
            this.舊利潤.DataPropertyName = "舊利潤";
            this.舊利潤.FillWeight = 12.46668F;
            this.舊利潤.HeaderText = "舊利潤%";
            this.舊利潤.MinimumWidth = 6;
            this.舊利潤.Name = "舊利潤";
            this.舊利潤.ReadOnly = true;
            this.舊利潤.Width = 125;
            // 
            // 單價日期
            // 
            this.單價日期.DataPropertyName = "單價日期";
            this.單價日期.FillWeight = 95.18718F;
            this.單價日期.HeaderText = "單價日期";
            this.單價日期.MinimumWidth = 6;
            this.單價日期.Name = "單價日期";
            this.單價日期.ReadOnly = true;
            this.單價日期.Width = 150;
            // 
            // 儲存日期
            // 
            this.儲存日期.DataPropertyName = "儲存日期";
            this.儲存日期.HeaderText = "量大最後儲存日期";
            this.儲存日期.MinimumWidth = 6;
            this.儲存日期.Name = "儲存日期";
            this.儲存日期.ReadOnly = true;
            this.儲存日期.Width = 200;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(456, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 31);
            this.label4.TabIndex = 107;
            this.label4.Text = "參照法：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVendor
            // 
            this.lblVendor.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblVendor.ForeColor = System.Drawing.Color.Red;
            this.lblVendor.Location = new System.Drawing.Point(1082, 24);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(90, 31);
            this.lblVendor.TabIndex = 128;
            this.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmInq_Large
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 653);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Name = "frmInq_Large";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "量大資料查詢";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVendor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chkMinus;
        private System.Windows.Forms.CheckBox chkPlus;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtCZF;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkDeal_Yet;
        private System.Windows.Forms.CheckBox chkDeal;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 數量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 差別報價;
        private System.Windows.Forms.DataGridViewTextBoxColumn 利潤;
        private System.Windows.Forms.DataGridViewTextBoxColumn 舊利潤;
        private System.Windows.Forms.DataGridViewTextBoxColumn 單價日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 儲存日期;
        private System.Windows.Forms.Label lblVendor;
    }
}