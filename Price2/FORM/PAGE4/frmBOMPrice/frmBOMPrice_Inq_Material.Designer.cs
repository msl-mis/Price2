namespace Price2
{
    partial class frmBOMPrice_Inq_Material
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
            this.chkFullInq = new System.Windows.Forms.CheckBox();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.chkVendor = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtPart = new System.Windows.Forms.TextBox();
            this.chkPart = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.chkID = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.chkLine = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkFiber = new System.Windows.Forms.CheckBox();
            this.chkUse_Yet = new System.Windows.Forms.CheckBox();
            this.chkNewDate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewDate_E = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewDate_S = new System.Windows.Forms.TextBox();
            this.chkQuoteDate = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuoteDate_E = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuoteDate_S = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnInq = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.材料名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.新建日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.材料價 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.變動日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.單位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.成本模式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.新建用戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.chkFullInq);
            this.groupBox.Controls.Add(this.cboUnit);
            this.groupBox.Controls.Add(this.label10);
            this.groupBox.Controls.Add(this.txtVendor);
            this.groupBox.Controls.Add(this.chkVendor);
            this.groupBox.Controls.Add(this.label9);
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Controls.Add(this.btnDelete);
            this.groupBox.Controls.Add(this.txtPart);
            this.groupBox.Controls.Add(this.chkPart);
            this.groupBox.Controls.Add(this.label8);
            this.groupBox.Controls.Add(this.txtID);
            this.groupBox.Controls.Add(this.chkID);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.txtLine);
            this.groupBox.Controls.Add(this.chkLine);
            this.groupBox.Controls.Add(this.label7);
            this.groupBox.Controls.Add(this.btnDeleteAll);
            this.groupBox.Controls.Add(this.lblCount);
            this.groupBox.Controls.Add(this.tableLayoutPanel1);
            this.groupBox.Controls.Add(this.chkNewDate);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.txtNewDate_E);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.txtNewDate_S);
            this.groupBox.Controls.Add(this.chkQuoteDate);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.txtQuoteDate_E);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.txtQuoteDate_S);
            this.groupBox.Controls.Add(this.btnPrint);
            this.groupBox.Controls.Add(this.btnExport);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox.Size = new System.Drawing.Size(950, 484);
            this.groupBox.TabIndex = 8;
            this.groupBox.TabStop = false;
            // 
            // chkFullInq
            // 
            this.chkFullInq.AutoSize = true;
            this.chkFullInq.BackColor = System.Drawing.Color.Transparent;
            this.chkFullInq.ForeColor = System.Drawing.Color.Blue;
            this.chkFullInq.Location = new System.Drawing.Point(322, 399);
            this.chkFullInq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkFullInq.Name = "chkFullInq";
            this.chkFullInq.Size = new System.Drawing.Size(86, 19);
            this.chkFullInq.TabIndex = 138;
            this.chkFullInq.Text = "完整搜尋";
            this.chkFullInq.UseVisualStyleBackColor = false;
            this.chkFullInq.CheckedChanged += new System.EventHandler(this.chkFullInq_CheckedChanged);
            // 
            // cboUnit
            // 
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.ItemHeight = 15;
            this.cboUnit.Items.AddRange(new object[] {
            "(ALL)",
            "Meter",
            "Feet",
            "KG",
            "G",
            "MM",
            "CM",
            "PC",
            "SET"});
            this.cboUnit.Location = new System.Drawing.Point(402, 332);
            this.cboUnit.Margin = new System.Windows.Forms.Padding(2);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(94, 23);
            this.cboUnit.TabIndex = 130;
            this.cboUnit.Text = "(ALL)";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(322, 331);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 26);
            this.label10.TabIndex = 92;
            this.label10.Text = "單位：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVendor
            // 
            this.txtVendor.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVendor.Location = new System.Drawing.Point(591, 331);
            this.txtVendor.Margin = new System.Windows.Forms.Padding(2);
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.Size = new System.Drawing.Size(83, 27);
            this.txtVendor.TabIndex = 91;
            this.txtVendor.Text = "(ALL)";
            // 
            // chkVendor
            // 
            this.chkVendor.AutoSize = true;
            this.chkVendor.BackColor = System.Drawing.Color.Transparent;
            this.chkVendor.Checked = true;
            this.chkVendor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVendor.ForeColor = System.Drawing.Color.Blue;
            this.chkVendor.Location = new System.Drawing.Point(680, 334);
            this.chkVendor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkVendor.Name = "chkVendor";
            this.chkVendor.Size = new System.Drawing.Size(56, 19);
            this.chkVendor.TabIndex = 90;
            this.chkVendor.Text = "全部";
            this.chkVendor.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(511, 331);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 26);
            this.label9.TabIndex = 89;
            this.label9.Text = "廠商：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Location = new System.Drawing.Point(223, 437);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(63, 34);
            this.btnClear.TabIndex = 87;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(427, 437);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 34);
            this.btnDelete.TabIndex = 86;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtPart
            // 
            this.txtPart.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPart.Location = new System.Drawing.Point(129, 396);
            this.txtPart.Margin = new System.Windows.Forms.Padding(2);
            this.txtPart.Name = "txtPart";
            this.txtPart.Size = new System.Drawing.Size(126, 27);
            this.txtPart.TabIndex = 85;
            this.txtPart.Text = "(ALL)";
            this.txtPart.Enter += new System.EventHandler(this.txtPart_Enter);
            // 
            // chkPart
            // 
            this.chkPart.AutoSize = true;
            this.chkPart.BackColor = System.Drawing.Color.Transparent;
            this.chkPart.Checked = true;
            this.chkPart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPart.ForeColor = System.Drawing.Color.Blue;
            this.chkPart.Location = new System.Drawing.Point(259, 399);
            this.chkPart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkPart.Name = "chkPart";
            this.chkPart.Size = new System.Drawing.Size(56, 19);
            this.chkPart.TabIndex = 84;
            this.chkPart.Text = "全部";
            this.chkPart.UseVisualStyleBackColor = false;
            this.chkPart.CheckedChanged += new System.EventHandler(this.chkPart_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(4, 396);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 26);
            this.label8.TabIndex = 83;
            this.label8.Text = "BOM材料名：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtID.Location = new System.Drawing.Point(129, 363);
            this.txtID.Margin = new System.Windows.Forms.Padding(2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(126, 27);
            this.txtID.TabIndex = 82;
            this.txtID.Text = "(ALL)";
            this.txtID.Enter += new System.EventHandler(this.txtID_Enter);
            // 
            // chkID
            // 
            this.chkID.AutoSize = true;
            this.chkID.BackColor = System.Drawing.Color.Transparent;
            this.chkID.Checked = true;
            this.chkID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkID.ForeColor = System.Drawing.Color.Blue;
            this.chkID.Location = new System.Drawing.Point(259, 366);
            this.chkID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkID.Name = "chkID";
            this.chkID.Size = new System.Drawing.Size(56, 19);
            this.chkID.TabIndex = 81;
            this.chkID.Text = "全部";
            this.chkID.UseVisualStyleBackColor = false;
            this.chkID.CheckedChanged += new System.EventHandler(this.chkID_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(48, 363);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 26);
            this.label6.TabIndex = 80;
            this.label6.Text = "材料名：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLine
            // 
            this.txtLine.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLine.Location = new System.Drawing.Point(129, 331);
            this.txtLine.Margin = new System.Windows.Forms.Padding(2);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(126, 27);
            this.txtLine.TabIndex = 79;
            this.txtLine.Text = "(ALL)";
            this.txtLine.Enter += new System.EventHandler(this.txtLine_Enter);
            // 
            // chkLine
            // 
            this.chkLine.AutoSize = true;
            this.chkLine.BackColor = System.Drawing.Color.Transparent;
            this.chkLine.Checked = true;
            this.chkLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLine.ForeColor = System.Drawing.Color.Blue;
            this.chkLine.Location = new System.Drawing.Point(259, 334);
            this.chkLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkLine.Name = "chkLine";
            this.chkLine.Size = new System.Drawing.Size(56, 19);
            this.chkLine.TabIndex = 78;
            this.chkLine.Text = "全部";
            this.chkLine.UseVisualStyleBackColor = false;
            this.chkLine.CheckedChanged += new System.EventHandler(this.chkLine_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(48, 331);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 26);
            this.label7.TabIndex = 77;
            this.label7.Text = "品號：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnDeleteAll.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAll.Location = new System.Drawing.Point(495, 437);
            this.btnDeleteAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(130, 34);
            this.btnDeleteAll.TabIndex = 69;
            this.btnDeleteAll.Text = "全部刪除";
            this.btnDeleteAll.UseVisualStyleBackColor = false;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Location = new System.Drawing.Point(908, 330);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(42, 26);
            this.lblCount.TabIndex = 68;
            this.lblCount.Text = "0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.chkFiber, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkUse_Yet, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(341, 364);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(140, 26);
            this.tableLayoutPanel1.TabIndex = 67;
            // 
            // chkFiber
            // 
            this.chkFiber.AutoSize = true;
            this.chkFiber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFiber.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkFiber.ForeColor = System.Drawing.Color.Red;
            this.chkFiber.Location = new System.Drawing.Point(74, 4);
            this.chkFiber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkFiber.Name = "chkFiber";
            this.chkFiber.Size = new System.Drawing.Size(61, 18);
            this.chkFiber.TabIndex = 140;
            this.chkFiber.Text = "光纖";
            this.chkFiber.UseVisualStyleBackColor = true;
            // 
            // chkUse_Yet
            // 
            this.chkUse_Yet.AutoSize = true;
            this.chkUse_Yet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUse_Yet.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkUse_Yet.ForeColor = System.Drawing.Color.Red;
            this.chkUse_Yet.Location = new System.Drawing.Point(5, 4);
            this.chkUse_Yet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkUse_Yet.Name = "chkUse_Yet";
            this.chkUse_Yet.Size = new System.Drawing.Size(61, 18);
            this.chkUse_Yet.TabIndex = 3;
            this.chkUse_Yet.Text = "未使用";
            this.chkUse_Yet.UseVisualStyleBackColor = true;
            // 
            // chkNewDate
            // 
            this.chkNewDate.AutoSize = true;
            this.chkNewDate.BackColor = System.Drawing.Color.Transparent;
            this.chkNewDate.Checked = true;
            this.chkNewDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNewDate.ForeColor = System.Drawing.Color.Blue;
            this.chkNewDate.Location = new System.Drawing.Point(816, 366);
            this.chkNewDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkNewDate.Name = "chkNewDate";
            this.chkNewDate.Size = new System.Drawing.Size(56, 19);
            this.chkNewDate.TabIndex = 66;
            this.chkNewDate.Text = "全部";
            this.chkNewDate.UseVisualStyleBackColor = false;
            this.chkNewDate.CheckedChanged += new System.EventHandler(this.chkNewDate_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(677, 363);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 26);
            this.label4.TabIndex = 65;
            this.label4.Text = "至";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewDate_E
            // 
            this.txtNewDate_E.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtNewDate_E.Location = new System.Drawing.Point(708, 363);
            this.txtNewDate_E.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewDate_E.Name = "txtNewDate_E";
            this.txtNewDate_E.Size = new System.Drawing.Size(103, 27);
            this.txtNewDate_E.TabIndex = 64;
            this.txtNewDate_E.Text = "(ALL)";
            this.txtNewDate_E.Enter += new System.EventHandler(this.txtNewDate_E_Enter);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(446, 363);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 26);
            this.label5.TabIndex = 63;
            this.label5.Text = "新建日期：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewDate_S
            // 
            this.txtNewDate_S.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtNewDate_S.Location = new System.Drawing.Point(573, 363);
            this.txtNewDate_S.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewDate_S.Name = "txtNewDate_S";
            this.txtNewDate_S.Size = new System.Drawing.Size(103, 27);
            this.txtNewDate_S.TabIndex = 62;
            this.txtNewDate_S.Text = "(ALL)";
            this.txtNewDate_S.Enter += new System.EventHandler(this.txtNewDate_S_Enter);
            // 
            // chkQuoteDate
            // 
            this.chkQuoteDate.AutoSize = true;
            this.chkQuoteDate.BackColor = System.Drawing.Color.Transparent;
            this.chkQuoteDate.Checked = true;
            this.chkQuoteDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkQuoteDate.ForeColor = System.Drawing.Color.Blue;
            this.chkQuoteDate.Location = new System.Drawing.Point(816, 399);
            this.chkQuoteDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkQuoteDate.Name = "chkQuoteDate";
            this.chkQuoteDate.Size = new System.Drawing.Size(56, 19);
            this.chkQuoteDate.TabIndex = 60;
            this.chkQuoteDate.Text = "全部";
            this.chkQuoteDate.UseVisualStyleBackColor = false;
            this.chkQuoteDate.CheckedChanged += new System.EventHandler(this.chkQuoteDate_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(677, 396);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 26);
            this.label3.TabIndex = 58;
            this.label3.Text = "至";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuoteDate_E
            // 
            this.txtQuoteDate_E.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQuoteDate_E.Location = new System.Drawing.Point(708, 396);
            this.txtQuoteDate_E.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuoteDate_E.Name = "txtQuoteDate_E";
            this.txtQuoteDate_E.Size = new System.Drawing.Size(103, 27);
            this.txtQuoteDate_E.TabIndex = 57;
            this.txtQuoteDate_E.Text = "(ALL)";
            this.txtQuoteDate_E.Enter += new System.EventHandler(this.txtQuoteDate_E_Enter);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(446, 396);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 26);
            this.label1.TabIndex = 56;
            this.label1.Text = "變動日期：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuoteDate_S
            // 
            this.txtQuoteDate_S.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQuoteDate_S.Location = new System.Drawing.Point(573, 396);
            this.txtQuoteDate_S.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuoteDate_S.Name = "txtQuoteDate_S";
            this.txtQuoteDate_S.Size = new System.Drawing.Size(103, 27);
            this.txtQuoteDate_S.TabIndex = 55;
            this.txtQuoteDate_S.Text = "(ALL)";
            this.txtQuoteDate_S.TextChanged += new System.EventHandler(this.txtQuoteDate_S_TextChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Location = new System.Drawing.Point(359, 437);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnExport.Location = new System.Drawing.Point(291, 437);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnInq.Location = new System.Drawing.Point(155, 437);
            this.btnInq.Margin = new System.Windows.Forms.Padding(2);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.材料名,
            this.品號,
            this.新建日期,
            this.材料價,
            this.變動日期,
            this.單位,
            this.成本模式,
            this.新建用戶});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(10, 24);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(926, 302);
            this.dgvData.TabIndex = 50;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // 材料名
            // 
            this.材料名.DataPropertyName = "材料名";
            this.材料名.HeaderText = "材料名";
            this.材料名.MinimumWidth = 6;
            this.材料名.Name = "材料名";
            this.材料名.ReadOnly = true;
            this.材料名.Width = 180;
            // 
            // 品號
            // 
            this.品號.DataPropertyName = "品號";
            this.品號.HeaderText = "品號";
            this.品號.MinimumWidth = 6;
            this.品號.Name = "品號";
            this.品號.ReadOnly = true;
            this.品號.Width = 130;
            // 
            // 新建日期
            // 
            this.新建日期.DataPropertyName = "新建日期";
            this.新建日期.HeaderText = "新建日期";
            this.新建日期.MinimumWidth = 6;
            this.新建日期.Name = "新建日期";
            this.新建日期.ReadOnly = true;
            this.新建日期.Width = 110;
            // 
            // 材料價
            // 
            this.材料價.DataPropertyName = "材料價";
            this.材料價.HeaderText = "材料價";
            this.材料價.MinimumWidth = 8;
            this.材料價.Name = "材料價";
            this.材料價.ReadOnly = true;
            this.材料價.Width = 150;
            // 
            // 變動日期
            // 
            this.變動日期.DataPropertyName = "變動日期";
            this.變動日期.HeaderText = "變動日期";
            this.變動日期.MinimumWidth = 6;
            this.變動日期.Name = "變動日期";
            this.變動日期.ReadOnly = true;
            this.變動日期.Width = 110;
            // 
            // 單位
            // 
            this.單位.DataPropertyName = "單位";
            this.單位.HeaderText = "單位";
            this.單位.MinimumWidth = 6;
            this.單位.Name = "單位";
            this.單位.ReadOnly = true;
            this.單位.Width = 70;
            // 
            // 成本模式
            // 
            this.成本模式.DataPropertyName = "成本模式";
            this.成本模式.HeaderText = "成本模式";
            this.成本模式.MinimumWidth = 8;
            this.成本模式.Name = "成本模式";
            this.成本模式.ReadOnly = true;
            this.成本模式.Width = 150;
            // 
            // 新建用戶
            // 
            this.新建用戶.DataPropertyName = "新建用戶";
            this.新建用戶.HeaderText = "新建用戶";
            this.新建用戶.MinimumWidth = 8;
            this.新建用戶.Name = "新建用戶";
            this.新建用戶.ReadOnly = true;
            this.新建用戶.Width = 150;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(630, 437);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 34);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmBOMPrice_Inq_Material
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(950, 484);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmBOMPrice_Inq_Material";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查詢材料單";
            this.Load += new System.EventHandler(this.frmBOMPrice_Inq_Material_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.CheckBox chkFullInq;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVendor;
        private System.Windows.Forms.CheckBox chkVendor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtPart;
        private System.Windows.Forms.CheckBox chkPart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.CheckBox chkID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.CheckBox chkLine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkNewDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNewDate_E;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNewDate_S;
        private System.Windows.Forms.CheckBox chkQuoteDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuoteDate_E;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuoteDate_S;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkFiber;
        private System.Windows.Forms.CheckBox chkUse_Yet;
        private System.Windows.Forms.DataGridViewTextBoxColumn 材料名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 新建日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 材料價;
        private System.Windows.Forms.DataGridViewTextBoxColumn 變動日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 單位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 成本模式;
        private System.Windows.Forms.DataGridViewTextBoxColumn 新建用戶;
    }
}