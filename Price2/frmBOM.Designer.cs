namespace Price2
{
    partial class frmBOM
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
            this.btnTrackChanges = new System.Windows.Forms.Button();
            this.txtTbprice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVendorid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPurprice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModify_L3 = new System.Windows.Forms.Button();
            this.btnModify_L2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLevel3 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLevel2 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboLevel1 = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnModify_L1 = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.ap3_part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ap3_purprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ap3_vendorid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ap3_currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ap3_tbprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ap3_adddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblHighlight = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.btnTrackChanges);
            this.groupBox.Controls.Add(this.txtTbprice);
            this.groupBox.Controls.Add(this.label7);
            this.groupBox.Controls.Add(this.txtCurrency);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.txtVendorid);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.txtPurprice);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.txtID);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.btnModify_L3);
            this.groupBox.Controls.Add(this.btnModify_L2);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.cboLevel3);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.cboLevel2);
            this.groupBox.Controls.Add(this.label10);
            this.groupBox.Controls.Add(this.cboLevel1);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.btnPrint);
            this.groupBox.Controls.Add(this.btnModify_L1);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.btnDelete);
            this.groupBox.Controls.Add(this.btnAdd);
            this.groupBox.Controls.Add(this.lblHighlight);
            this.groupBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(939, 560);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            // 
            // btnTrackChanges
            // 
            this.btnTrackChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTrackChanges.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTrackChanges.Location = new System.Drawing.Point(837, 79);
            this.btnTrackChanges.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTrackChanges.Name = "btnTrackChanges";
            this.btnTrackChanges.Size = new System.Drawing.Size(84, 42);
            this.btnTrackChanges.TabIndex = 86;
            this.btnTrackChanges.Text = "修改紀錄";
            this.btnTrackChanges.UseVisualStyleBackColor = false;
            this.btnTrackChanges.Click += new System.EventHandler(this.btnTrackChanges_Click);
            // 
            // txtTbprice
            // 
            this.txtTbprice.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtTbprice.Location = new System.Drawing.Point(585, 499);
            this.txtTbprice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTbprice.Name = "txtTbprice";
            this.txtTbprice.ReadOnly = true;
            this.txtTbprice.Size = new System.Drawing.Size(125, 31);
            this.txtTbprice.TabIndex = 85;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(585, 463);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 34);
            this.label7.TabIndex = 84;
            this.label7.Text = "台幣單價";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCurrency
            // 
            this.txtCurrency.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCurrency.Location = new System.Drawing.Point(493, 499);
            this.txtCurrency.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.ReadOnly = true;
            this.txtCurrency.Size = new System.Drawing.Size(86, 31);
            this.txtCurrency.TabIndex = 83;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(493, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 34);
            this.label6.TabIndex = 82;
            this.label6.Text = "幣種";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtVendorid
            // 
            this.txtVendorid.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVendorid.Location = new System.Drawing.Point(401, 499);
            this.txtVendorid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVendorid.Name = "txtVendorid";
            this.txtVendorid.ReadOnly = true;
            this.txtVendorid.Size = new System.Drawing.Size(86, 31);
            this.txtVendorid.TabIndex = 81;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(401, 463);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 34);
            this.label5.TabIndex = 80;
            this.label5.Text = "廠商";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPurprice
            // 
            this.txtPurprice.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPurprice.Location = new System.Drawing.Point(309, 499);
            this.txtPurprice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPurprice.Name = "txtPurprice";
            this.txtPurprice.ReadOnly = true;
            this.txtPurprice.Size = new System.Drawing.Size(86, 31);
            this.txtPurprice.TabIndex = 79;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(309, 463);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 34);
            this.label4.TabIndex = 78;
            this.label4.Text = "單價";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtID.Location = new System.Drawing.Point(21, 499);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(282, 31);
            this.txtID.TabIndex = 77;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 34);
            this.label3.TabIndex = 76;
            this.label3.Text = "第四層名稱";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnModify_L3
            // 
            this.btnModify_L3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnModify_L3.Location = new System.Drawing.Point(597, 163);
            this.btnModify_L3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModify_L3.Name = "btnModify_L3";
            this.btnModify_L3.Size = new System.Drawing.Size(133, 33);
            this.btnModify_L3.TabIndex = 75;
            this.btnModify_L3.Text = "第三層修改";
            this.btnModify_L3.UseVisualStyleBackColor = false;
            this.btnModify_L3.Click += new System.EventHandler(this.btnModify_L3_Click);
            // 
            // btnModify_L2
            // 
            this.btnModify_L2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnModify_L2.Location = new System.Drawing.Point(597, 103);
            this.btnModify_L2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModify_L2.Name = "btnModify_L2";
            this.btnModify_L2.Size = new System.Drawing.Size(133, 33);
            this.btnModify_L2.TabIndex = 74;
            this.btnModify_L2.Text = "第二層修改";
            this.btnModify_L2.UseVisualStyleBackColor = false;
            this.btnModify_L2.Click += new System.EventHandler(this.btnModify_L2_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 34);
            this.label2.TabIndex = 73;
            this.label2.Text = "第三層名稱：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboLevel3
            // 
            this.cboLevel3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLevel3.FormattingEnabled = true;
            this.cboLevel3.Location = new System.Drawing.Point(177, 167);
            this.cboLevel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboLevel3.Name = "cboLevel3";
            this.cboLevel3.Size = new System.Drawing.Size(367, 28);
            this.cboLevel3.TabIndex = 72;
            this.cboLevel3.TextChanged += new System.EventHandler(this.cboLevel3_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 34);
            this.label1.TabIndex = 71;
            this.label1.Text = "第二層名稱：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboLevel2
            // 
            this.cboLevel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLevel2.FormattingEnabled = true;
            this.cboLevel2.Location = new System.Drawing.Point(177, 107);
            this.cboLevel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboLevel2.Name = "cboLevel2";
            this.cboLevel2.Size = new System.Drawing.Size(367, 28);
            this.cboLevel2.TabIndex = 70;
            this.cboLevel2.TextChanged += new System.EventHandler(this.cboLevel2_TextChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(17, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 34);
            this.label10.TabIndex = 69;
            this.label10.Text = "第一層名稱：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboLevel1
            // 
            this.cboLevel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLevel1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboLevel1.FormattingEnabled = true;
            this.cboLevel1.Location = new System.Drawing.Point(177, 46);
            this.cboLevel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboLevel1.Name = "cboLevel1";
            this.cboLevel1.Size = new System.Drawing.Size(367, 28);
            this.cboLevel1.TabIndex = 68;
            this.cboLevel1.TextChanged += new System.EventHandler(this.cboLevel1_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(837, 488);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 42);
            this.btnClose.TabIndex = 56;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPrint.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrint.Location = new System.Drawing.Point(837, 134);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 42);
            this.btnPrint.TabIndex = 54;
            this.btnPrint.Text = "列印BOM";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnModify_L1
            // 
            this.btnModify_L1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnModify_L1.Location = new System.Drawing.Point(597, 42);
            this.btnModify_L1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModify_L1.Name = "btnModify_L1";
            this.btnModify_L1.Size = new System.Drawing.Size(133, 33);
            this.btnModify_L1.TabIndex = 53;
            this.btnModify_L1.Text = "第一層修改";
            this.btnModify_L1.UseVisualStyleBackColor = false;
            this.btnModify_L1.Click += new System.EventHandler(this.btnModify_L1_Click);
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
            this.ap3_part,
            this.ap3_purprice,
            this.ap3_vendorid,
            this.ap3_currency,
            this.ap3_tbprice,
            this.ap3_adddate});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(21, 227);
            this.dgvData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(803, 220);
            this.dgvData.TabIndex = 50;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvData_KeyDown);
            // 
            // ap3_part
            // 
            this.ap3_part.DataPropertyName = "ap3_part";
            this.ap3_part.HeaderText = "第四層名稱";
            this.ap3_part.MinimumWidth = 6;
            this.ap3_part.Name = "ap3_part";
            this.ap3_part.ReadOnly = true;
            this.ap3_part.Width = 300;
            // 
            // ap3_purprice
            // 
            this.ap3_purprice.DataPropertyName = "ap3_purprice";
            this.ap3_purprice.HeaderText = "單價";
            this.ap3_purprice.MinimumWidth = 6;
            this.ap3_purprice.Name = "ap3_purprice";
            this.ap3_purprice.ReadOnly = true;
            this.ap3_purprice.Width = 90;
            // 
            // ap3_vendorid
            // 
            this.ap3_vendorid.DataPropertyName = "ap3_vendorid";
            this.ap3_vendorid.HeaderText = "廠商";
            this.ap3_vendorid.MinimumWidth = 6;
            this.ap3_vendorid.Name = "ap3_vendorid";
            this.ap3_vendorid.ReadOnly = true;
            this.ap3_vendorid.Width = 90;
            // 
            // ap3_currency
            // 
            this.ap3_currency.DataPropertyName = "ap3_currency";
            this.ap3_currency.HeaderText = "幣種";
            this.ap3_currency.MinimumWidth = 6;
            this.ap3_currency.Name = "ap3_currency";
            this.ap3_currency.ReadOnly = true;
            this.ap3_currency.Width = 90;
            // 
            // ap3_tbprice
            // 
            this.ap3_tbprice.DataPropertyName = "ap3_tbprice";
            this.ap3_tbprice.HeaderText = "台幣單價";
            this.ap3_tbprice.MinimumWidth = 6;
            this.ap3_tbprice.Name = "ap3_tbprice";
            this.ap3_tbprice.ReadOnly = true;
            this.ap3_tbprice.Width = 125;
            // 
            // ap3_adddate
            // 
            this.ap3_adddate.DataPropertyName = "ap3_adddate";
            this.ap3_adddate.HeaderText = "最後日期";
            this.ap3_adddate.MinimumWidth = 6;
            this.ap3_adddate.Name = "ap3_adddate";
            this.ap3_adddate.ReadOnly = true;
            this.ap3_adddate.Width = 180;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDelete.Location = new System.Drawing.Point(837, 293);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 42);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAdd.Location = new System.Drawing.Point(837, 227);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 42);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblHighlight
            // 
            this.lblHighlight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblHighlight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHighlight.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblHighlight.ForeColor = System.Drawing.Color.Red;
            this.lblHighlight.Location = new System.Drawing.Point(837, 30);
            this.lblHighlight.Name = "lblHighlight";
            this.lblHighlight.Size = new System.Drawing.Size(84, 34);
            this.lblHighlight.TabIndex = 35;
            this.lblHighlight.Text = "唯讀";
            this.lblHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 558);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmBOM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BOM產品結構建立";
            this.Activated += new System.EventHandler(this.frmBOM_Activated);
            this.Load += new System.EventHandler(this.frmBOM_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblHighlight;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnModify_L1;
        private System.Windows.Forms.Button btnModify_L3;
        private System.Windows.Forms.Button btnModify_L2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLevel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLevel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboLevel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTbprice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVendorid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPurprice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ap3_part;
        private System.Windows.Forms.DataGridViewTextBoxColumn ap3_purprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ap3_vendorid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ap3_currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn ap3_tbprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ap3_adddate;
        private System.Windows.Forms.Button btnTrackChanges;
    }
}