﻿namespace Price2
{
    partial class frmSafetyFees_Report
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblA3 = new System.Windows.Forms.Label();
            this.lblA2 = new System.Windows.Forms.Label();
            this.lblA1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvFees = new System.Windows.Forms.DataGridView();
            this.規格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.電源線材 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.電源插頭 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.一般線材 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInq = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPurprice = new System.Windows.Forms.TextBox();
            this.cboMaterial = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvCount = new System.Windows.Forms.DataGridView();
            this.年份 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.安規費用 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.安規數量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label22 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFees)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.groupBox3);
            this.groupBox.Controls.Add(this.groupBox2);
            this.groupBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 10F);
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(1044, 378);
            this.groupBox.TabIndex = 9;
            this.groupBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox3.Controls.Add(this.lblA3);
            this.groupBox3.Controls.Add(this.lblA2);
            this.groupBox3.Controls.Add(this.lblA1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtpDate);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnInq);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(6, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(548, 354);
            this.groupBox3.TabIndex = 130;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "安規費用彙整表";
            // 
            // lblA3
            // 
            this.lblA3.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblA3.ForeColor = System.Drawing.Color.Blue;
            this.lblA3.Location = new System.Drawing.Point(400, 264);
            this.lblA3.Name = "lblA3";
            this.lblA3.Size = new System.Drawing.Size(109, 31);
            this.lblA3.TabIndex = 176;
            this.lblA3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblA2
            // 
            this.lblA2.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblA2.ForeColor = System.Drawing.Color.Blue;
            this.lblA2.Location = new System.Drawing.Point(275, 264);
            this.lblA2.Name = "lblA2";
            this.lblA2.Size = new System.Drawing.Size(109, 31);
            this.lblA2.TabIndex = 175;
            this.lblA2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblA1
            // 
            this.lblA1.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblA1.ForeColor = System.Drawing.Color.Blue;
            this.lblA1.Location = new System.Drawing.Point(150, 264);
            this.lblA1.Name = "lblA1";
            this.lblA1.Size = new System.Drawing.Size(109, 31);
            this.lblA1.TabIndex = 174;
            this.lblA1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(13, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 31);
            this.label1.TabIndex = 173;
            this.label1.Text = "總和";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(121, 30);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShowUpDown = true;
            this.dtpDate.Size = new System.Drawing.Size(110, 29);
            this.dtpDate.TabIndex = 166;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.dgvFees);
            this.panel3.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel3.Location = new System.Drawing.Point(16, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(495, 181);
            this.panel3.TabIndex = 163;
            // 
            // dgvFees
            // 
            this.dgvFees.AllowUserToAddRows = false;
            this.dgvFees.AllowUserToDeleteRows = false;
            this.dgvFees.AllowUserToOrderColumns = true;
            this.dgvFees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFees.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.規格,
            this.電源線材,
            this.電源插頭,
            this.一般線材});
            this.dgvFees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFees.EnableHeadersVisualStyles = false;
            this.dgvFees.Location = new System.Drawing.Point(0, 0);
            this.dgvFees.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFees.Name = "dgvFees";
            this.dgvFees.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFees.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFees.RowHeadersVisible = false;
            this.dgvFees.RowHeadersWidth = 25;
            this.dgvFees.RowTemplate.Height = 21;
            this.dgvFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFees.Size = new System.Drawing.Size(495, 181);
            this.dgvFees.TabIndex = 164;
            // 
            // 規格
            // 
            this.規格.DataPropertyName = "規格";
            this.規格.FillWeight = 115F;
            this.規格.HeaderText = "規格";
            this.規格.MinimumWidth = 115;
            this.規格.Name = "規格";
            this.規格.ReadOnly = true;
            // 
            // 電源線材
            // 
            this.電源線材.DataPropertyName = "電源線材";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.電源線材.DefaultCellStyle = dataGridViewCellStyle2;
            this.電源線材.FillWeight = 125F;
            this.電源線材.HeaderText = "電源線材";
            this.電源線材.MinimumWidth = 125;
            this.電源線材.Name = "電源線材";
            this.電源線材.ReadOnly = true;
            // 
            // 電源插頭
            // 
            this.電源插頭.DataPropertyName = "電源插頭";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.電源插頭.DefaultCellStyle = dataGridViewCellStyle3;
            this.電源插頭.FillWeight = 125F;
            this.電源插頭.HeaderText = "電源插頭";
            this.電源插頭.MinimumWidth = 125;
            this.電源插頭.Name = "電源插頭";
            this.電源插頭.ReadOnly = true;
            // 
            // 一般線材
            // 
            this.一般線材.DataPropertyName = "一般線材";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.一般線材.DefaultCellStyle = dataGridViewCellStyle4;
            this.一般線材.FillWeight = 125F;
            this.一般線材.HeaderText = "一般線材";
            this.一般線材.MinimumWidth = 125;
            this.一般線材.Name = "一般線材";
            this.一般線材.ReadOnly = true;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClear.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(357, 32);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(67, 28);
            this.btnClear.TabIndex = 159;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInq.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInq.Location = new System.Drawing.Point(268, 32);
            this.btnInq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(67, 28);
            this.btnInq.TabIndex = 162;
            this.btnInq.Text = "查詢";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label25.Location = new System.Drawing.Point(6, 30);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(109, 31);
            this.label25.TabIndex = 161;
            this.label25.Text = "查詢年份";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox2.Controls.Add(this.txtPurprice);
            this.groupBox2.Controls.Add(this.cboMaterial);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(560, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 354);
            this.groupBox2.TabIndex = 129;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "安規費用分攤計算";
            // 
            // txtPurprice
            // 
            this.txtPurprice.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPurprice.Location = new System.Drawing.Point(121, 253);
            this.txtPurprice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPurprice.Name = "txtPurprice";
            this.txtPurprice.Size = new System.Drawing.Size(110, 29);
            this.txtPurprice.TabIndex = 180;
            this.txtPurprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboMaterial
            // 
            this.cboMaterial.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboMaterial.FormattingEnabled = true;
            this.cboMaterial.Items.AddRange(new object[] {
            "年費/一般安規線材/M",
            "年費/電源插頭/頭",
            "年費/電源線材/M"});
            this.cboMaterial.Location = new System.Drawing.Point(122, 35);
            this.cboMaterial.Name = "cboMaterial";
            this.cboMaterial.Size = new System.Drawing.Size(254, 26);
            this.cboMaterial.TabIndex = 179;
            this.cboMaterial.TextChanged += new System.EventHandler(this.cboMaterial_TextChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(6, 285);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(412, 66);
            this.label13.TabIndex = 178;
            this.label13.Text = "注意：\r\n按下 [ 儲存 ] , 系統將回寫火車頭材料單價！";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(405, 254);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 28);
            this.btnClose.TabIndex = 177;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvCount);
            this.panel4.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel4.Location = new System.Drawing.Point(30, 70);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(431, 181);
            this.panel4.TabIndex = 174;
            // 
            // dgvCount
            // 
            this.dgvCount.AllowUserToAddRows = false;
            this.dgvCount.AllowUserToDeleteRows = false;
            this.dgvCount.AllowUserToOrderColumns = true;
            this.dgvCount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCount.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCount.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.年份,
            this.安規費用,
            this.安規數量});
            this.dgvCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCount.EnableHeadersVisualStyles = false;
            this.dgvCount.Location = new System.Drawing.Point(0, 0);
            this.dgvCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCount.Name = "dgvCount";
            this.dgvCount.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCount.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCount.RowHeadersVisible = false;
            this.dgvCount.RowHeadersWidth = 25;
            this.dgvCount.RowTemplate.Height = 21;
            this.dgvCount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCount.Size = new System.Drawing.Size(431, 181);
            this.dgvCount.TabIndex = 159;
            // 
            // 年份
            // 
            this.年份.DataPropertyName = "年份";
            this.年份.FillWeight = 130F;
            this.年份.HeaderText = "年份";
            this.年份.MinimumWidth = 130;
            this.年份.Name = "年份";
            this.年份.ReadOnly = true;
            // 
            // 安規費用
            // 
            this.安規費用.DataPropertyName = "安規費用";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.安規費用.DefaultCellStyle = dataGridViewCellStyle7;
            this.安規費用.FillWeight = 150F;
            this.安規費用.HeaderText = "安規費用";
            this.安規費用.MinimumWidth = 150;
            this.安規費用.Name = "安規費用";
            this.安規費用.ReadOnly = true;
            // 
            // 安規數量
            // 
            this.安規數量.DataPropertyName = "安規數量";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.安規數量.DefaultCellStyle = dataGridViewCellStyle8;
            this.安規數量.FillWeight = 150F;
            this.安規數量.HeaderText = "安規數量";
            this.安規數量.MinimumWidth = 150;
            this.安規數量.Name = "安規數量";
            this.安規數量.ReadOnly = true;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(6, 254);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(109, 31);
            this.label22.TabIndex = 172;
            this.label22.Text = "單價";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Red;
            this.btnSave.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Location = new System.Drawing.Point(309, 254);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 28);
            this.btnSave.TabIndex = 170;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(6, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(110, 31);
            this.label21.TabIndex = 169;
            this.label21.Text = "材料名";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmSafetyFees_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 378);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Name = "frmSafetyFees_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "安龜費用分攤統計表";
            this.Activated += new System.EventHandler(this.frmSafetyFees_Report_Activated);
            this.Load += new System.EventHandler(this.frmSafetyFees_Report_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFees)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvFees;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvCount;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboMaterial;
        private System.Windows.Forms.Label lblA3;
        private System.Windows.Forms.Label lblA2;
        private System.Windows.Forms.Label lblA1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPurprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn 規格;
        private System.Windows.Forms.DataGridViewTextBoxColumn 電源線材;
        private System.Windows.Forms.DataGridViewTextBoxColumn 電源插頭;
        private System.Windows.Forms.DataGridViewTextBoxColumn 一般線材;
        private System.Windows.Forms.DataGridViewTextBoxColumn 年份;
        private System.Windows.Forms.DataGridViewTextBoxColumn 安規費用;
        private System.Windows.Forms.DataGridViewTextBoxColumn 安規數量;
    }
}