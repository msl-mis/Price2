namespace Price2
{
    partial class frmWorking_Adjust
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbH = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtH = new System.Windows.Forms.TextBox();
            this.gbM = new System.Windows.Forms.GroupBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.txtM = new System.Windows.Forms.TextBox();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdjust = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioDeal_Yet = new System.Windows.Forms.RadioButton();
            this.radioDeal = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInq = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.線路 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.加工分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.不良率 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.線長 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.參照法 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox.SuspendLayout();
            this.gbH.SuspendLayout();
            this.gbM.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.gbH);
            this.groupBox.Controls.Add(this.gbM);
            this.groupBox.Controls.Add(this.cboItem);
            this.groupBox.Controls.Add(this.label7);
            this.groupBox.Controls.Add(this.btnSave);
            this.groupBox.Controls.Add(this.btnAdjust);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.txtCustomer);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.txtCustomerID);
            this.groupBox.Controls.Add(this.lblCount);
            this.groupBox.Controls.Add(this.tableLayoutPanel1);
            this.groupBox.Controls.Add(this.btnPrint);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Controls.Add(this.txtLine);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 10F);
            this.groupBox.ForeColor = System.Drawing.Color.Black;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox.Size = new System.Drawing.Size(736, 510);
            this.groupBox.TabIndex = 9;
            this.groupBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(169, 435);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 62);
            this.label4.TabIndex = 184;
            this.label4.Text = "線長<=3M    報價工時*1;\r\n線長<=5M    報價工時*1.15;  \r\n線長<=10M  報價工時*1.25;  \r\n線長>10M    報價工時*" +
    "1.35";
            // 
            // gbH
            // 
            this.gbH.Controls.Add(this.label6);
            this.gbH.Controls.Add(this.txtH);
            this.gbH.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbH.ForeColor = System.Drawing.Color.Blue;
            this.gbH.Location = new System.Drawing.Point(246, 104);
            this.gbH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbH.Name = "gbH";
            this.gbH.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbH.Size = new System.Drawing.Size(175, 48);
            this.gbH.TabIndex = 183;
            this.gbH.TabStop = false;
            this.gbH.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(4, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 25);
            this.label6.TabIndex = 183;
            this.label6.Text = "基礎總工時：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtH
            // 
            this.txtH.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtH.Location = new System.Drawing.Point(108, 18);
            this.txtH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtH.Name = "txtH";
            this.txtH.Size = new System.Drawing.Size(56, 25);
            this.txtH.TabIndex = 182;
            // 
            // gbM
            // 
            this.gbM.Controls.Add(this.lblItem);
            this.gbM.Controls.Add(this.txtM);
            this.gbM.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbM.ForeColor = System.Drawing.Color.Blue;
            this.gbM.Location = new System.Drawing.Point(29, 104);
            this.gbM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbM.Name = "gbM";
            this.gbM.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbM.Size = new System.Drawing.Size(213, 48);
            this.gbM.TabIndex = 182;
            this.gbM.TabStop = false;
            this.gbM.Text = "線長區間：";
            this.gbM.Visible = false;
            // 
            // lblItem
            // 
            this.lblItem.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblItem.ForeColor = System.Drawing.Color.Blue;
            this.lblItem.Location = new System.Drawing.Point(4, 19);
            this.lblItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(135, 25);
            this.lblItem.TabIndex = 183;
            this.lblItem.Text = "調整為：";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtM
            // 
            this.txtM.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtM.Location = new System.Drawing.Point(143, 18);
            this.txtM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtM.Name = "txtM";
            this.txtM.Size = new System.Drawing.Size(64, 25);
            this.txtM.TabIndex = 182;
            // 
            // cboItem
            // 
            this.cboItem.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Items.AddRange(new object[] {
            "加工/分",
            "不良率"});
            this.cboItem.Location = new System.Drawing.Point(383, 20);
            this.cboItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(112, 23);
            this.cboItem.TabIndex = 180;
            this.cboItem.Text = "加工/分";
            this.cboItem.TextChanged += new System.EventHandler(this.cboItem_TextChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(30, 435);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 62);
            this.label7.TabIndex = 136;
            this.label7.Text = "調整報價工時的公式:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Location = new System.Drawing.Point(512, 47);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 26);
            this.btnSave.TabIndex = 135;
            this.btnSave.Text = "調整更新";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdjust
            // 
            this.btnAdjust.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdjust.Enabled = false;
            this.btnAdjust.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdjust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjust.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAdjust.Location = new System.Drawing.Point(512, 20);
            this.btnAdjust.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdjust.Name = "btnAdjust";
            this.btnAdjust.Size = new System.Drawing.Size(79, 26);
            this.btnAdjust.TabIndex = 134;
            this.btnAdjust.Text = "調整規範";
            this.btnAdjust.UseVisualStyleBackColor = false;
            this.btnAdjust.Click += new System.EventHandler(this.btnAdjust_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(289, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 25);
            this.label2.TabIndex = 128;
            this.label2.Text = "客戶：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomer.Location = new System.Drawing.Point(383, 45);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(112, 25);
            this.txtCustomer.TabIndex = 129;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(289, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 25);
            this.label3.TabIndex = 126;
            this.label3.Text = "調整參數：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(4, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 124;
            this.label1.Text = "客號：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomerID.Location = new System.Drawing.Point(99, 45);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(186, 25);
            this.txtCustomerID.TabIndex = 125;
            this.txtCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyDown);
            this.txtCustomerID.Leave += new System.EventHandler(this.txtCustomerID_Leave);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCount.ForeColor = System.Drawing.Color.Blue;
            this.lblCount.Location = new System.Drawing.Point(557, 121);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCount.Size = new System.Drawing.Size(150, 25);
            this.lblCount.TabIndex = 123;
            this.lblCount.Text = "資料筆數：0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.radioDeal_Yet, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioDeal, 1, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(31, 74);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(231, 26);
            this.tableLayoutPanel1.TabIndex = 68;
            // 
            // radioDeal_Yet
            // 
            this.radioDeal_Yet.AutoSize = true;
            this.radioDeal_Yet.Location = new System.Drawing.Point(156, 4);
            this.radioDeal_Yet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioDeal_Yet.Name = "radioDeal_Yet";
            this.radioDeal_Yet.Size = new System.Drawing.Size(70, 18);
            this.radioDeal_Yet.TabIndex = 136;
            this.radioDeal_Yet.Text = "未成交";
            this.radioDeal_Yet.UseVisualStyleBackColor = true;
            // 
            // radioDeal
            // 
            this.radioDeal.AutoSize = true;
            this.radioDeal.Location = new System.Drawing.Point(80, 4);
            this.radioDeal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioDeal.Name = "radioDeal";
            this.radioDeal.Size = new System.Drawing.Size(70, 18);
            this.radioDeal.TabIndex = 135;
            this.radioDeal.Text = "已成交";
            this.radioDeal.UseVisualStyleBackColor = true;
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Location = new System.Drawing.Point(4, 4);
            this.radioAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(55, 18);
            this.radioAll.TabIndex = 134;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "全部";
            this.radioAll.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrint.Location = new System.Drawing.Point(667, 15);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(51, 29);
            this.btnPrint.TabIndex = 100;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(667, 46);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(51, 29);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(4, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 25);
            this.label5.TabIndex = 110;
            this.label5.Text = "線路：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInq.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInq.Location = new System.Drawing.Point(612, 15);
            this.btnInq.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(51, 29);
            this.btnInq.TabIndex = 93;
            this.btnInq.Text = "查詢";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(612, 46);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(51, 29);
            this.btnClear.TabIndex = 92;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtLine
            // 
            this.txtLine.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLine.Location = new System.Drawing.Point(99, 18);
            this.txtLine.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(186, 25);
            this.txtLine.TabIndex = 111;
            this.txtLine.TextChanged += new System.EventHandler(this.txtLine_TextChanged);
            this.txtLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLine_KeyDown);
            this.txtLine.Leave += new System.EventHandler(this.txtLine_Leave);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.線路,
            this.加工分,
            this.不良率,
            this.客戶,
            this.客號,
            this.線長,
            this.參照法});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(31, 156);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("新細明體", 10F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 21;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(676, 271);
            this.dgvData.TabIndex = 80;
            // 
            // 線路
            // 
            this.線路.DataPropertyName = "線路";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.線路.DefaultCellStyle = dataGridViewCellStyle9;
            this.線路.HeaderText = "線路";
            this.線路.MinimumWidth = 6;
            this.線路.Name = "線路";
            this.線路.ReadOnly = true;
            this.線路.Width = 125;
            // 
            // 加工分
            // 
            this.加工分.DataPropertyName = "加工分";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.加工分.DefaultCellStyle = dataGridViewCellStyle10;
            this.加工分.HeaderText = "加工分";
            this.加工分.MinimumWidth = 6;
            this.加工分.Name = "加工分";
            this.加工分.ReadOnly = true;
            this.加工分.Width = 125;
            // 
            // 不良率
            // 
            this.不良率.DataPropertyName = "不良率";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.不良率.DefaultCellStyle = dataGridViewCellStyle11;
            this.不良率.HeaderText = "不良率";
            this.不良率.MinimumWidth = 6;
            this.不良率.Name = "不良率";
            this.不良率.ReadOnly = true;
            this.不良率.Width = 125;
            // 
            // 客戶
            // 
            this.客戶.DataPropertyName = "客戶";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.客戶.DefaultCellStyle = dataGridViewCellStyle12;
            this.客戶.HeaderText = "客戶";
            this.客戶.MinimumWidth = 6;
            this.客戶.Name = "客戶";
            this.客戶.ReadOnly = true;
            this.客戶.Width = 125;
            // 
            // 客號
            // 
            this.客號.DataPropertyName = "客號";
            this.客號.FillWeight = 200F;
            this.客號.HeaderText = "客號";
            this.客號.MinimumWidth = 6;
            this.客號.Name = "客號";
            this.客號.ReadOnly = true;
            this.客號.Width = 200;
            // 
            // 線長
            // 
            this.線長.DataPropertyName = "線長";
            this.線長.HeaderText = "線長";
            this.線長.MinimumWidth = 6;
            this.線長.Name = "線長";
            this.線長.ReadOnly = true;
            this.線長.Width = 125;
            // 
            // 參照法
            // 
            this.參照法.DataPropertyName = "參照法";
            this.參照法.FillWeight = 0.09294103F;
            this.參照法.HeaderText = "參照法";
            this.參照法.MinimumWidth = 6;
            this.參照法.Name = "參照法";
            this.參照法.ReadOnly = true;
            this.參照法.Width = 400;
            // 
            // frmWorking_Adjust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 510);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmWorking_Adjust";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "調整報價加工分/不良率";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.gbH.ResumeLayout(false);
            this.gbH.PerformLayout();
            this.gbM.ResumeLayout(false);
            this.gbM.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdjust;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.RadioButton radioDeal_Yet;
        private System.Windows.Forms.RadioButton radioDeal;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.GroupBox gbH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtH;
        private System.Windows.Forms.GroupBox gbM;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.TextBox txtM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn 線路;
        private System.Windows.Forms.DataGridViewTextBoxColumn 加工分;
        private System.Windows.Forms.DataGridViewTextBoxColumn 不良率;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 線長;
        private System.Windows.Forms.DataGridViewTextBoxColumn 參照法;
    }
}