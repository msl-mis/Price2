namespace Price2
{
    partial class frmQuotation
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lblSaveDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnQuotation_Inq = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNote = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnInq = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.產品編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.價格 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.odi_customerid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.odi_line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtQuotationID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtQuotationDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.lblSaveDate);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.lblUser);
            this.groupBox.Controls.Add(this.btnQuotation_Inq);
            this.groupBox.Controls.Add(this.panel2);
            this.groupBox.Controls.Add(this.panel1);
            this.groupBox.Controls.Add(this.txtQuotationID);
            this.groupBox.Controls.Add(this.label12);
            this.groupBox.Controls.Add(this.txtSign);
            this.groupBox.Controls.Add(this.label8);
            this.groupBox.Controls.Add(this.label13);
            this.groupBox.Controls.Add(this.txtQuotationDate);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.txtCustomer);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox.Size = new System.Drawing.Size(1559, 781);
            this.groupBox.TabIndex = 10;
            this.groupBox.TabStop = false;
            // 
            // lblSaveDate
            // 
            this.lblSaveDate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSaveDate.Location = new System.Drawing.Point(858, 55);
            this.lblSaveDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSaveDate.Name = "lblSaveDate";
            this.lblSaveDate.Size = new System.Drawing.Size(180, 27);
            this.lblSaveDate.TabIndex = 167;
            this.lblSaveDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(734, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 27);
            this.label4.TabIndex = 166;
            this.label4.Text = "最後儲存日期：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUser.Location = new System.Drawing.Point(609, 55);
            this.lblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(120, 27);
            this.lblUser.TabIndex = 165;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnQuotation_Inq
            // 
            this.btnQuotation_Inq.BackColor = System.Drawing.Color.Lime;
            this.btnQuotation_Inq.Location = new System.Drawing.Point(283, 54);
            this.btnQuotation_Inq.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuotation_Inq.Name = "btnQuotation_Inq";
            this.btnQuotation_Inq.Size = new System.Drawing.Size(32, 29);
            this.btnQuotation_Inq.TabIndex = 164;
            this.btnQuotation_Inq.Text = "...";
            this.btnQuotation_Inq.UseVisualStyleBackColor = false;
            this.btnQuotation_Inq.Click += new System.EventHandler(this.btnQuotation_Inq_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSelect);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.dgvData);
            this.panel2.Location = new System.Drawing.Point(434, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 630);
            this.panel2.TabIndex = 163;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSelect.Location = new System.Drawing.Point(28, 235);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(92, 34);
            this.btnSelect.TabIndex = 157;
            this.btnSelect.Text = "選取";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.btnNote, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCopy, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInq, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClear, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrint, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 560);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 60);
            this.tableLayoutPanel1.TabIndex = 163;
            // 
            // btnNote
            // 
            this.btnNote.BackColor = System.Drawing.Color.White;
            this.btnNote.Location = new System.Drawing.Point(422, 2);
            this.btnNote.Margin = new System.Windows.Forms.Padding(2);
            this.btnNote.Name = "btnNote";
            this.btnNote.Size = new System.Drawing.Size(56, 56);
            this.btnNote.TabIndex = 162;
            this.btnNote.Text = "選取備註";
            this.btnNote.UseVisualStyleBackColor = false;
            this.btnNote.Click += new System.EventHandler(this.btnNote_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCopy.Location = new System.Drawing.Point(362, 2);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(56, 56);
            this.btnCopy.TabIndex = 156;
            this.btnCopy.Text = "複製";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnInq.Location = new System.Drawing.Point(302, 2);
            this.btnInq.Margin = new System.Windows.Forms.Padding(2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(56, 56);
            this.btnInq.TabIndex = 157;
            this.btnInq.Text = "查詢";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.Location = new System.Drawing.Point(242, 2);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 56);
            this.btnDelete.TabIndex = 158;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.Location = new System.Drawing.Point(62, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 56);
            this.btnSave.TabIndex = 160;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.Location = new System.Drawing.Point(122, 2);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(56, 56);
            this.btnClear.TabIndex = 87;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(482, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 56);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnPrint.Location = new System.Drawing.Point(182, 2);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(56, 56);
            this.btnPrint.TabIndex = 54;
            this.btnPrint.Text = "預覽列印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 25;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.產品編號,
            this.價格});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(145, 10);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 21;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(405, 520);
            this.dgvData.TabIndex = 162;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // 產品編號
            // 
            this.產品編號.DataPropertyName = "產品編號";
            this.產品編號.HeaderText = "產品編號";
            this.產品編號.MinimumWidth = 6;
            this.產品編號.Name = "產品編號";
            this.產品編號.Width = 250;
            // 
            // 價格
            // 
            this.價格.DataPropertyName = "價格";
            this.價格.HeaderText = "價格";
            this.價格.MinimumWidth = 6;
            this.價格.Name = "價格";
            this.價格.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvProduct);
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Location = new System.Drawing.Point(26, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 630);
            this.panel1.TabIndex = 162;
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.AllowUserToOrderColumns = true;
            this.dgvProduct.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProduct.ColumnHeadersHeight = 25;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.odi_customerid,
            this.odi_line});
            this.dgvProduct.EnableHeadersVisualStyles = false;
            this.dgvProduct.Location = new System.Drawing.Point(1, 10);
            this.dgvProduct.Margin = new System.Windows.Forms.Padding(2);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.RowHeadersVisible = false;
            this.dgvProduct.RowHeadersWidth = 51;
            this.dgvProduct.RowTemplate.Height = 21;
            this.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduct.Size = new System.Drawing.Size(404, 520);
            this.dgvProduct.TabIndex = 156;
            this.dgvProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellDoubleClick);
            // 
            // odi_customerid
            // 
            this.odi_customerid.DataPropertyName = "odi_customerid";
            this.odi_customerid.HeaderText = "產品編號";
            this.odi_customerid.MinimumWidth = 6;
            this.odi_customerid.Name = "odi_customerid";
            this.odi_customerid.ReadOnly = true;
            this.odi_customerid.Width = 250;
            // 
            // odi_line
            // 
            this.odi_line.DataPropertyName = "odi_line";
            this.odi_line.HeaderText = "線路";
            this.odi_line.Name = "odi_line";
            this.odi_line.ReadOnly = true;
            this.odi_line.Width = 150;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Location = new System.Drawing.Point(353, 559);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(50, 27);
            this.lblCount.TabIndex = 155;
            this.lblCount.Text = "0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuotationID
            // 
            this.txtQuotationID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQuotationID.Location = new System.Drawing.Point(137, 54);
            this.txtQuotationID.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuotationID.Name = "txtQuotationID";
            this.txtQuotationID.Size = new System.Drawing.Size(125, 27);
            this.txtQuotationID.TabIndex = 152;
            this.txtQuotationID.Text = "Q";
            this.txtQuotationID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuotationID_KeyDown);
            this.txtQuotationID.Leave += new System.EventHandler(this.txtQuotationID_Leave);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(20, 54);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 27);
            this.label12.TabIndex = 150;
            this.label12.Text = "報價單號：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSign
            // 
            this.txtSign.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSign.Location = new System.Drawing.Point(858, 22);
            this.txtSign.Margin = new System.Windows.Forms.Padding(2);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(125, 27);
            this.txtSign.TabIndex = 147;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(485, 54);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 27);
            this.label8.TabIndex = 145;
            this.label8.Text = "最後儲存用戶：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(778, 22);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 27);
            this.label13.TabIndex = 136;
            this.label13.Text = "Sign：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuotationDate
            // 
            this.txtQuotationDate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQuotationDate.Location = new System.Drawing.Point(480, 22);
            this.txtQuotationDate.Margin = new System.Windows.Forms.Padding(2);
            this.txtQuotationDate.Name = "txtQuotationDate";
            this.txtQuotationDate.Size = new System.Drawing.Size(125, 27);
            this.txtQuotationDate.TabIndex = 82;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(368, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 27);
            this.label6.TabIndex = 80;
            this.label6.Text = "報價日期：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomer.Location = new System.Drawing.Point(137, 22);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(125, 27);
            this.txtCustomer.TabIndex = 70;
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            this.txtCustomer.Leave += new System.EventHandler(this.txtCustomer_Leave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(23, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 27);
            this.label2.TabIndex = 36;
            this.label2.Text = "客戶：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1559, 781);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Name = "frmQuotation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客戶報價單";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnQuotation_Inq;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnNote;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtQuotationID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSign;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtQuotationDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 產品編號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 價格;
        private System.Windows.Forms.Label lblSaveDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn odi_customerid;
        private System.Windows.Forms.DataGridViewTextBoxColumn odi_line;
    }
}