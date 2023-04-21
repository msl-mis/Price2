namespace Price2
{
    partial class frmBOMPrice_Find_Quotation
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
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioDeal = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioDealYet = new System.Windows.Forms.RadioButton();
            this.chkNewDate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewDate_E = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewDate_S = new System.Windows.Forms.TextBox();
            this.chkCustomer = new System.Windows.Forms.CheckBox();
            this.chkDealDate = new System.Windows.Forms.CheckBox();
            this.lblCZF = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDealDate_E = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDealDate_S = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnInq = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.線路 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.線長 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.報價新建日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最後成交日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.成交總數量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.最後成交利潤 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.即時利潤 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.新建用戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.txtCustomer);
            this.groupBox.Controls.Add(this.btnDelete);
            this.groupBox.Controls.Add(this.lblCount);
            this.groupBox.Controls.Add(this.tableLayoutPanel1);
            this.groupBox.Controls.Add(this.chkNewDate);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.txtNewDate_E);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.txtNewDate_S);
            this.groupBox.Controls.Add(this.chkCustomer);
            this.groupBox.Controls.Add(this.chkDealDate);
            this.groupBox.Controls.Add(this.lblCZF);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.txtDealDate_E);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.txtDealDate_S);
            this.groupBox.Controls.Add(this.btnPrint);
            this.groupBox.Controls.Add(this.btnExport);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox.Size = new System.Drawing.Size(800, 470);
            this.groupBox.TabIndex = 6;
            this.groupBox.TabStop = false;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomer.Location = new System.Drawing.Point(591, 418);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(103, 27);
            this.txtCustomer.TabIndex = 70;
            this.txtCustomer.Text = "(ALL)";
            this.txtCustomer.Enter += new System.EventHandler(this.txtCustomer_Enter_1);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(486, 341);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 34);
            this.btnDelete.TabIndex = 69;
            this.btnDelete.Text = "資料刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCount.ForeColor = System.Drawing.Color.Blue;
            this.lblCount.Location = new System.Drawing.Point(747, 340);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(42, 27);
            this.lblCount.TabIndex = 68;
            this.lblCount.Text = "0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.radioDeal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioDealYet, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(207, 340);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(248, 34);
            this.tableLayoutPanel1.TabIndex = 67;
            // 
            // radioDeal
            // 
            this.radioDeal.AutoSize = true;
            this.radioDeal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioDeal.ForeColor = System.Drawing.Color.Red;
            this.radioDeal.Location = new System.Drawing.Point(87, 5);
            this.radioDeal.Name = "radioDeal";
            this.radioDeal.Size = new System.Drawing.Size(74, 24);
            this.radioDeal.TabIndex = 2;
            this.radioDeal.Text = "成交";
            this.radioDeal.UseVisualStyleBackColor = true;
            this.radioDeal.Click += new System.EventHandler(this.radioDeal_Click);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioAll.ForeColor = System.Drawing.Color.Red;
            this.radioAll.Location = new System.Drawing.Point(5, 5);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(74, 24);
            this.radioAll.TabIndex = 1;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "全部";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.Click += new System.EventHandler(this.radioAll_Click);
            // 
            // radioDealYet
            // 
            this.radioDealYet.AutoSize = true;
            this.radioDealYet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioDealYet.ForeColor = System.Drawing.Color.Red;
            this.radioDealYet.Location = new System.Drawing.Point(169, 5);
            this.radioDealYet.Name = "radioDealYet";
            this.radioDealYet.Size = new System.Drawing.Size(74, 24);
            this.radioDealYet.TabIndex = 0;
            this.radioDealYet.Text = "未成交";
            this.radioDealYet.UseVisualStyleBackColor = true;
            this.radioDealYet.Click += new System.EventHandler(this.radioDealYet_Click);
            // 
            // chkNewDate
            // 
            this.chkNewDate.AutoSize = true;
            this.chkNewDate.BackColor = System.Drawing.Color.Transparent;
            this.chkNewDate.Checked = true;
            this.chkNewDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewDate.ForeColor = System.Drawing.Color.Blue;
            this.chkNewDate.Location = new System.Drawing.Point(397, 391);
            this.chkNewDate.Name = "chkNewDate";
            this.chkNewDate.Size = new System.Drawing.Size(58, 20);
            this.chkNewDate.TabIndex = 66;
            this.chkNewDate.Text = "全部";
            this.chkNewDate.UseVisualStyleBackColor = false;
            this.chkNewDate.CheckedChanged += new System.EventHandler(this.chkNewDate_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(258, 388);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 27);
            this.label4.TabIndex = 65;
            this.label4.Text = "至";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewDate_E
            // 
            this.txtNewDate_E.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtNewDate_E.Location = new System.Drawing.Point(289, 388);
            this.txtNewDate_E.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNewDate_E.Name = "txtNewDate_E";
            this.txtNewDate_E.Size = new System.Drawing.Size(103, 27);
            this.txtNewDate_E.TabIndex = 64;
            this.txtNewDate_E.Text = "(ALL)";
            this.txtNewDate_E.Enter += new System.EventHandler(this.txtNewDate_E_Enter);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(26, 388);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 27);
            this.label5.TabIndex = 63;
            this.label5.Text = "新建日期：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewDate_S
            // 
            this.txtNewDate_S.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtNewDate_S.Location = new System.Drawing.Point(154, 388);
            this.txtNewDate_S.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNewDate_S.Name = "txtNewDate_S";
            this.txtNewDate_S.Size = new System.Drawing.Size(103, 27);
            this.txtNewDate_S.TabIndex = 62;
            this.txtNewDate_S.Text = "(ALL)";
            this.txtNewDate_S.Enter += new System.EventHandler(this.txtNewDate_S_Enter);
            // 
            // chkCustomer
            // 
            this.chkCustomer.AutoSize = true;
            this.chkCustomer.BackColor = System.Drawing.Color.Transparent;
            this.chkCustomer.Checked = true;
            this.chkCustomer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCustomer.ForeColor = System.Drawing.Color.Blue;
            this.chkCustomer.Location = new System.Drawing.Point(699, 422);
            this.chkCustomer.Name = "chkCustomer";
            this.chkCustomer.Size = new System.Drawing.Size(58, 20);
            this.chkCustomer.TabIndex = 61;
            this.chkCustomer.Text = "全部";
            this.chkCustomer.UseVisualStyleBackColor = false;
            this.chkCustomer.CheckedChanged += new System.EventHandler(this.chkCustomer_CheckedChanged);
            // 
            // chkDealDate
            // 
            this.chkDealDate.AutoSize = true;
            this.chkDealDate.BackColor = System.Drawing.Color.Transparent;
            this.chkDealDate.Checked = true;
            this.chkDealDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDealDate.ForeColor = System.Drawing.Color.Blue;
            this.chkDealDate.Location = new System.Drawing.Point(397, 422);
            this.chkDealDate.Name = "chkDealDate";
            this.chkDealDate.Size = new System.Drawing.Size(58, 20);
            this.chkDealDate.TabIndex = 60;
            this.chkDealDate.Text = "全部";
            this.chkDealDate.UseVisualStyleBackColor = false;
            this.chkDealDate.CheckedChanged += new System.EventHandler(this.chkDealDate_CheckedChanged);
            // 
            // lblCZF
            // 
            this.lblCZF.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCZF.ForeColor = System.Drawing.Color.Red;
            this.lblCZF.Location = new System.Drawing.Point(35, 344);
            this.lblCZF.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCZF.Name = "lblCZF";
            this.lblCZF.Size = new System.Drawing.Size(141, 27);
            this.lblCZF.TabIndex = 59;
            this.lblCZF.Text = "按空格顯示參照法";
            this.lblCZF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(258, 419);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 27);
            this.label3.TabIndex = 58;
            this.label3.Text = "至";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDealDate_E
            // 
            this.txtDealDate_E.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDealDate_E.Location = new System.Drawing.Point(289, 419);
            this.txtDealDate_E.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDealDate_E.Name = "txtDealDate_E";
            this.txtDealDate_E.Size = new System.Drawing.Size(103, 27);
            this.txtDealDate_E.TabIndex = 57;
            this.txtDealDate_E.Text = "(ALL)";
            this.txtDealDate_E.Enter += new System.EventHandler(this.txtDealDate_E_Enter);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(26, 418);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 27);
            this.label1.TabIndex = 56;
            this.label1.Text = "訂單成交日期：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDealDate_S
            // 
            this.txtDealDate_S.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDealDate_S.Location = new System.Drawing.Point(154, 419);
            this.txtDealDate_S.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDealDate_S.Name = "txtDealDate_S";
            this.txtDealDate_S.Size = new System.Drawing.Size(103, 27);
            this.txtDealDate_S.TabIndex = 55;
            this.txtDealDate_S.Text = "(ALL)";
            this.txtDealDate_S.Enter += new System.EventHandler(this.txtDealDate_S_Enter);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Location = new System.Drawing.Point(590, 341);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(63, 34);
            this.btnPrint.TabIndex = 54;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExport.Location = new System.Drawing.Point(657, 378);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(63, 34);
            this.btnExport.TabIndex = 52;
            this.btnExport.Text = "導出";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInq.Location = new System.Drawing.Point(590, 378);
            this.btnInq.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(63, 34);
            this.btnInq.TabIndex = 51;
            this.btnInq.Text = "搜尋";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
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
            this.客號,
            this.線路,
            this.線長,
            this.報價新建日期,
            this.最後成交日期,
            this.成交總數量,
            this.最後成交利潤,
            this.即時利潤,
            this.用戶,
            this.新建用戶});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(11, 24);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(778, 303);
            this.dgvData.TabIndex = 50;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvData_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(510, 418);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 27);
            this.label2.TabIndex = 36;
            this.label2.Text = "客戶：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(657, 341);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 34);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // 客戶
            // 
            this.客戶.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.客戶.DataPropertyName = "客戶";
            this.客戶.FillWeight = 80F;
            this.客戶.HeaderText = "客戶";
            this.客戶.MinimumWidth = 80;
            this.客戶.Name = "客戶";
            this.客戶.ReadOnly = true;
            this.客戶.Width = 80;
            // 
            // 客號
            // 
            this.客號.DataPropertyName = "客號";
            this.客號.FillWeight = 238.65F;
            this.客號.HeaderText = "客號";
            this.客號.MinimumWidth = 6;
            this.客號.Name = "客號";
            this.客號.ReadOnly = true;
            this.客號.Width = 168;
            // 
            // 線路
            // 
            this.線路.DataPropertyName = "線路";
            this.線路.FillWeight = 80F;
            this.線路.HeaderText = "線路";
            this.線路.MinimumWidth = 52;
            this.線路.Name = "線路";
            this.線路.ReadOnly = true;
            this.線路.Width = 80;
            // 
            // 線長
            // 
            this.線長.DataPropertyName = "線長";
            this.線長.FillWeight = 80F;
            this.線長.HeaderText = "線長";
            this.線長.MinimumWidth = 6;
            this.線長.Name = "線長";
            this.線長.ReadOnly = true;
            this.線長.Width = 80;
            // 
            // 報價新建日期
            // 
            this.報價新建日期.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.報價新建日期.DataPropertyName = "報價新建日期";
            this.報價新建日期.FillWeight = 200F;
            this.報價新建日期.HeaderText = "報價新建日期";
            this.報價新建日期.MinimumWidth = 150;
            this.報價新建日期.Name = "報價新建日期";
            this.報價新建日期.ReadOnly = true;
            this.報價新建日期.Width = 150;
            // 
            // 最後成交日期
            // 
            this.最後成交日期.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.最後成交日期.DataPropertyName = "最後成交日期";
            this.最後成交日期.FillWeight = 200F;
            this.最後成交日期.HeaderText = "最後成交日期";
            this.最後成交日期.MinimumWidth = 150;
            this.最後成交日期.Name = "最後成交日期";
            this.最後成交日期.ReadOnly = true;
            this.最後成交日期.Width = 150;
            // 
            // 成交總數量
            // 
            this.成交總數量.DataPropertyName = "成交總數量";
            this.成交總數量.FillWeight = 200F;
            this.成交總數量.HeaderText = "成交總數量";
            this.成交總數量.MinimumWidth = 50;
            this.成交總數量.Name = "成交總數量";
            this.成交總數量.ReadOnly = true;
            this.成交總數量.Width = 150;
            // 
            // 最後成交利潤
            // 
            this.最後成交利潤.DataPropertyName = "最後成交利潤";
            this.最後成交利潤.FillWeight = 200F;
            this.最後成交利潤.HeaderText = "最後成交利潤";
            this.最後成交利潤.MinimumWidth = 50;
            this.最後成交利潤.Name = "最後成交利潤";
            this.最後成交利潤.ReadOnly = true;
            this.最後成交利潤.Width = 150;
            // 
            // 即時利潤
            // 
            this.即時利潤.DataPropertyName = "即時利潤";
            this.即時利潤.HeaderText = "即時利潤";
            this.即時利潤.MinimumWidth = 6;
            this.即時利潤.Name = "即時利潤";
            this.即時利潤.ReadOnly = true;
            // 
            // 用戶
            // 
            this.用戶.DataPropertyName = "用戶";
            this.用戶.FillWeight = 80F;
            this.用戶.HeaderText = "用戶";
            this.用戶.MinimumWidth = 8;
            this.用戶.Name = "用戶";
            this.用戶.ReadOnly = true;
            this.用戶.Width = 80;
            // 
            // 新建用戶
            // 
            this.新建用戶.DataPropertyName = "新建用戶";
            this.新建用戶.HeaderText = "新建用戶";
            this.新建用戶.MinimumWidth = 8;
            this.新建用戶.Name = "新建用戶";
            this.新建用戶.ReadOnly = true;
            // 
            // frmBOMPrice_Find_Quotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Name = "frmBOMPrice_Find_Quotation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "尋找物料用在哪些線路中";
            this.Load += new System.EventHandler(this.frmBOMPrice_Find_Quotation_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label lblCZF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDealDate_E;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDealDate_S;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioDeal;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioDealYet;
        private System.Windows.Forms.CheckBox chkNewDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewDate_E;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNewDate_S;
        private System.Windows.Forms.CheckBox chkCustomer;
        private System.Windows.Forms.CheckBox chkDealDate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 線路;
        private System.Windows.Forms.DataGridViewTextBoxColumn 線長;
        private System.Windows.Forms.DataGridViewTextBoxColumn 報價新建日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最後成交日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 成交總數量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 最後成交利潤;
        private System.Windows.Forms.DataGridViewTextBoxColumn 即時利潤;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用戶;
        private System.Windows.Forms.DataGridViewTextBoxColumn 新建用戶;
    }
}