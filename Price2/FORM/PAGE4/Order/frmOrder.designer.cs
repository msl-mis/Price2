namespace Price2
{
    partial class frmOrder
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInq_Order = new System.Windows.Forms.Button();
            this.btnPI_In = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPI_Cost = new System.Windows.Forms.Button();
            this.btnInq_Complaint = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnNote = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.chkDeal_Yet = new System.Windows.Forms.CheckBox();
            this.chkReplenish = new System.Windows.Forms.CheckBox();
            this.btnInq_Order_Modify = new System.Windows.Forms.Button();
            this.btnComplaint = new System.Windows.Forms.Button();
            this.btnOtherPay = new System.Windows.Forms.Button();
            this.radioWorkOrder_Full = new System.Windows.Forms.RadioButton();
            this.radioWorkOrder = new System.Windows.Forms.RadioButton();
            this.radioPI = new System.Windows.Forms.RadioButton();
            this.chkOther = new System.Windows.Forms.CheckBox();
            this.txtQuotationID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboShippingMark = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeliveryDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSaveDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnOrder_Inq = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.產品編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.數量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.業務 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.na6_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.na6_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.na6_qtycal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.na6_yftype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.odi_customerid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.odi_line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.panel3);
            this.groupBox.Controls.Add(this.btnSign);
            this.groupBox.Controls.Add(this.chkDeal_Yet);
            this.groupBox.Controls.Add(this.chkReplenish);
            this.groupBox.Controls.Add(this.btnInq_Order_Modify);
            this.groupBox.Controls.Add(this.btnComplaint);
            this.groupBox.Controls.Add(this.btnOtherPay);
            this.groupBox.Controls.Add(this.radioWorkOrder_Full);
            this.groupBox.Controls.Add(this.radioWorkOrder);
            this.groupBox.Controls.Add(this.radioPI);
            this.groupBox.Controls.Add(this.chkOther);
            this.groupBox.Controls.Add(this.txtQuotationID);
            this.groupBox.Controls.Add(this.label9);
            this.groupBox.Controls.Add(this.txtPO);
            this.groupBox.Controls.Add(this.label7);
            this.groupBox.Controls.Add(this.cboShippingMark);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.txtDeliveryDate);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.txtNewDate);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.lblSaveDate);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.lblUser);
            this.groupBox.Controls.Add(this.btnOrder_Inq);
            this.groupBox.Controls.Add(this.panel2);
            this.groupBox.Controls.Add(this.panel1);
            this.groupBox.Controls.Add(this.txtOrderID);
            this.groupBox.Controls.Add(this.label12);
            this.groupBox.Controls.Add(this.txtSign);
            this.groupBox.Controls.Add(this.label8);
            this.groupBox.Controls.Add(this.label13);
            this.groupBox.Controls.Add(this.txtOrderDate);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.txtCustomer);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(1445, 664);
            this.groupBox.TabIndex = 11;
            this.groupBox.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnInq_Order);
            this.panel3.Controls.Add(this.btnPI_In);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.btnPI_Cost);
            this.panel3.Controls.Add(this.btnInq_Complaint);
            this.panel3.Controls.Add(this.btnCopy);
            this.panel3.Controls.Add(this.btnPrint);
            this.panel3.Controls.Add(this.btnNote);
            this.panel3.Location = new System.Drawing.Point(34, 589);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(700, 60);
            this.panel3.TabIndex = 189;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(614, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 54);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.Location = new System.Drawing.Point(14, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 54);
            this.btnSave.TabIndex = 164;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.Location = new System.Drawing.Point(554, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(54, 54);
            this.btnDelete.TabIndex = 162;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInq_Order
            // 
            this.btnInq_Order.BackColor = System.Drawing.Color.Lime;
            this.btnInq_Order.Location = new System.Drawing.Point(74, 0);
            this.btnInq_Order.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInq_Order.Name = "btnInq_Order";
            this.btnInq_Order.Size = new System.Drawing.Size(54, 54);
            this.btnInq_Order.TabIndex = 163;
            this.btnInq_Order.Text = "訂單查詢";
            this.btnInq_Order.UseVisualStyleBackColor = false;
            this.btnInq_Order.Click += new System.EventHandler(this.btnInq_Order_Click);
            // 
            // btnPI_In
            // 
            this.btnPI_In.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnPI_In.Location = new System.Drawing.Point(314, 0);
            this.btnPI_In.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPI_In.Name = "btnPI_In";
            this.btnPI_In.Size = new System.Drawing.Size(54, 54);
            this.btnPI_In.TabIndex = 54;
            this.btnPI_In.Text = "國內部PI";
            this.btnPI_In.UseVisualStyleBackColor = false;
            this.btnPI_In.Click += new System.EventHandler(this.btnPI_In_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.Location = new System.Drawing.Point(494, 0);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(54, 54);
            this.btnClear.TabIndex = 156;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPI_Cost
            // 
            this.btnPI_Cost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnPI_Cost.Location = new System.Drawing.Point(374, 0);
            this.btnPI_Cost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPI_Cost.Name = "btnPI_Cost";
            this.btnPI_Cost.Size = new System.Drawing.Size(54, 54);
            this.btnPI_Cost.TabIndex = 158;
            this.btnPI_Cost.Text = "成本PI";
            this.btnPI_Cost.UseVisualStyleBackColor = false;
            this.btnPI_Cost.Click += new System.EventHandler(this.btnPI_Cost_Click);
            // 
            // btnInq_Complaint
            // 
            this.btnInq_Complaint.BackColor = System.Drawing.Color.Lime;
            this.btnInq_Complaint.Location = new System.Drawing.Point(254, 0);
            this.btnInq_Complaint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInq_Complaint.Name = "btnInq_Complaint";
            this.btnInq_Complaint.Size = new System.Drawing.Size(54, 54);
            this.btnInq_Complaint.TabIndex = 167;
            this.btnInq_Complaint.Text = "客訴查詢";
            this.btnInq_Complaint.UseVisualStyleBackColor = false;
            this.btnInq_Complaint.Click += new System.EventHandler(this.btnInq_Complaint_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCopy.Location = new System.Drawing.Point(194, 0);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(54, 54);
            this.btnCopy.TabIndex = 166;
            this.btnCopy.Text = "複製";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnPrint.Location = new System.Drawing.Point(134, 0);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(54, 54);
            this.btnPrint.TabIndex = 165;
            this.btnPrint.Text = "預覽列印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnNote
            // 
            this.btnNote.BackColor = System.Drawing.Color.White;
            this.btnNote.Location = new System.Drawing.Point(434, 0);
            this.btnNote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNote.Name = "btnNote";
            this.btnNote.Size = new System.Drawing.Size(54, 54);
            this.btnNote.TabIndex = 157;
            this.btnNote.Text = "選取備註";
            this.btnNote.UseVisualStyleBackColor = false;
            this.btnNote.Click += new System.EventHandler(this.btnNote_Click);
            // 
            // btnSign
            // 
            this.btnSign.AutoEllipsis = true;
            this.btnSign.BackColor = System.Drawing.Color.Lime;
            this.btnSign.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSign.Location = new System.Drawing.Point(1336, 68);
            this.btnSign.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(43, 38);
            this.btnSign.TabIndex = 188;
            this.btnSign.Text = "填入";
            this.btnSign.UseVisualStyleBackColor = false;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // chkDeal_Yet
            // 
            this.chkDeal_Yet.AutoSize = true;
            this.chkDeal_Yet.ForeColor = System.Drawing.Color.Magenta;
            this.chkDeal_Yet.Location = new System.Drawing.Point(579, 545);
            this.chkDeal_Yet.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.chkDeal_Yet.Name = "chkDeal_Yet";
            this.chkDeal_Yet.Size = new System.Drawing.Size(81, 21);
            this.chkDeal_Yet.TabIndex = 187;
            this.chkDeal_Yet.Text = "未成交";
            this.chkDeal_Yet.UseVisualStyleBackColor = true;
            this.chkDeal_Yet.CheckedChanged += new System.EventHandler(this.chkDeal_Yet_CheckedChanged);
            // 
            // chkReplenish
            // 
            this.chkReplenish.AutoSize = true;
            this.chkReplenish.ForeColor = System.Drawing.Color.Magenta;
            this.chkReplenish.Location = new System.Drawing.Point(1116, 545);
            this.chkReplenish.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.chkReplenish.Name = "chkReplenish";
            this.chkReplenish.Size = new System.Drawing.Size(64, 21);
            this.chkReplenish.TabIndex = 186;
            this.chkReplenish.Text = "補貨";
            this.chkReplenish.UseVisualStyleBackColor = true;
            // 
            // btnInq_Order_Modify
            // 
            this.btnInq_Order_Modify.AutoEllipsis = true;
            this.btnInq_Order_Modify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnInq_Order_Modify.Font = new System.Drawing.Font("新細明體", 10.2F);
            this.btnInq_Order_Modify.Location = new System.Drawing.Point(961, 542);
            this.btnInq_Order_Modify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInq_Order_Modify.Name = "btnInq_Order_Modify";
            this.btnInq_Order_Modify.Size = new System.Drawing.Size(123, 42);
            this.btnInq_Order_Modify.TabIndex = 185;
            this.btnInq_Order_Modify.Text = "工單修改紀錄";
            this.btnInq_Order_Modify.UseVisualStyleBackColor = false;
            this.btnInq_Order_Modify.Click += new System.EventHandler(this.btnInq_Order_Modify_Click);
            // 
            // btnComplaint
            // 
            this.btnComplaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnComplaint.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnComplaint.Location = new System.Drawing.Point(833, 542);
            this.btnComplaint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnComplaint.Name = "btnComplaint";
            this.btnComplaint.Size = new System.Drawing.Size(123, 42);
            this.btnComplaint.TabIndex = 184;
            this.btnComplaint.Text = "客訴";
            this.btnComplaint.UseVisualStyleBackColor = false;
            this.btnComplaint.Click += new System.EventHandler(this.btnComplaint_Click);
            // 
            // btnOtherPay
            // 
            this.btnOtherPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOtherPay.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOtherPay.Location = new System.Drawing.Point(705, 542);
            this.btnOtherPay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOtherPay.Name = "btnOtherPay";
            this.btnOtherPay.Size = new System.Drawing.Size(123, 42);
            this.btnOtherPay.TabIndex = 183;
            this.btnOtherPay.Text = "國外其他費用";
            this.btnOtherPay.UseVisualStyleBackColor = false;
            this.btnOtherPay.Click += new System.EventHandler(this.btnOtherPay_Click);
            // 
            // radioWorkOrder_Full
            // 
            this.radioWorkOrder_Full.Location = new System.Drawing.Point(331, 545);
            this.radioWorkOrder_Full.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.radioWorkOrder_Full.Name = "radioWorkOrder_Full";
            this.radioWorkOrder_Full.Size = new System.Drawing.Size(140, 28);
            this.radioWorkOrder_Full.TabIndex = 182;
            this.radioWorkOrder_Full.Text = "工單(完整)";
            this.radioWorkOrder_Full.UseVisualStyleBackColor = true;
            // 
            // radioWorkOrder
            // 
            this.radioWorkOrder.Location = new System.Drawing.Point(183, 545);
            this.radioWorkOrder.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.radioWorkOrder.Name = "radioWorkOrder";
            this.radioWorkOrder.Size = new System.Drawing.Size(140, 28);
            this.radioWorkOrder.TabIndex = 181;
            this.radioWorkOrder.Text = "工單";
            this.radioWorkOrder.UseVisualStyleBackColor = true;
            // 
            // radioPI
            // 
            this.radioPI.Checked = true;
            this.radioPI.Location = new System.Drawing.Point(35, 545);
            this.radioPI.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.radioPI.Name = "radioPI";
            this.radioPI.Size = new System.Drawing.Size(140, 28);
            this.radioPI.TabIndex = 180;
            this.radioPI.TabStop = true;
            this.radioPI.Text = "PI";
            this.radioPI.UseVisualStyleBackColor = true;
            // 
            // chkOther
            // 
            this.chkOther.AutoSize = true;
            this.chkOther.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkOther.ForeColor = System.Drawing.Color.Magenta;
            this.chkOther.Location = new System.Drawing.Point(1085, 105);
            this.chkOther.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.chkOther.Name = "chkOther";
            this.chkOther.Size = new System.Drawing.Size(132, 21);
            this.chkOther.TabIndex = 179;
            this.chkOther.Text = "其他工單費用";
            this.chkOther.UseVisualStyleBackColor = true;
            // 
            // txtQuotationID
            // 
            this.txtQuotationID.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQuotationID.Location = new System.Drawing.Point(828, 105);
            this.txtQuotationID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuotationID.Name = "txtQuotationID";
            this.txtQuotationID.Size = new System.Drawing.Size(167, 28);
            this.txtQuotationID.TabIndex = 178;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(676, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 28);
            this.label9.TabIndex = 177;
            this.label9.Text = "報價單號：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPO
            // 
            this.txtPO.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPO.Location = new System.Drawing.Point(828, 68);
            this.txtPO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(167, 28);
            this.txtPO.TabIndex = 176;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(676, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 28);
            this.label7.TabIndex = 175;
            this.label7.Text = "P/O：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboShippingMark
            // 
            this.cboShippingMark.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboShippingMark.FormattingEnabled = true;
            this.cboShippingMark.ItemHeight = 17;
            this.cboShippingMark.Location = new System.Drawing.Point(505, 28);
            this.cboShippingMark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboShippingMark.Name = "cboShippingMark";
            this.cboShippingMark.Size = new System.Drawing.Size(167, 25);
            this.cboShippingMark.TabIndex = 174;
            this.cboShippingMark.Leave += new System.EventHandler(this.cboShippingMark_Leave);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(353, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 28);
            this.label5.TabIndex = 173;
            this.label5.Text = "正側麥代碼：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDeliveryDate
            // 
            this.txtDeliveryDate.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDeliveryDate.Location = new System.Drawing.Point(1148, 28);
            this.txtDeliveryDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDeliveryDate.Name = "txtDeliveryDate";
            this.txtDeliveryDate.Size = new System.Drawing.Size(167, 28);
            this.txtDeliveryDate.TabIndex = 172;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(996, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 28);
            this.label3.TabIndex = 171;
            this.label3.Text = "交期：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewDate
            // 
            this.txtNewDate.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtNewDate.Location = new System.Drawing.Point(183, 105);
            this.txtNewDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNewDate.Name = "txtNewDate";
            this.txtNewDate.Size = new System.Drawing.Size(167, 28);
            this.txtNewDate.TabIndex = 170;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(31, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 28);
            this.label1.TabIndex = 169;
            this.label1.Text = "新建日期：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSaveDate
            // 
            this.lblSaveDate.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSaveDate.Location = new System.Drawing.Point(517, 142);
            this.lblSaveDate.Name = "lblSaveDate";
            this.lblSaveDate.Size = new System.Drawing.Size(147, 28);
            this.lblSaveDate.TabIndex = 167;
            this.lblSaveDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(365, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 28);
            this.label4.TabIndex = 166;
            this.label4.Text = "最後儲存日期：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUser.Location = new System.Drawing.Point(187, 142);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(147, 28);
            this.lblUser.TabIndex = 165;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOrder_Inq
            // 
            this.btnOrder_Inq.BackColor = System.Drawing.Color.Lime;
            this.btnOrder_Inq.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOrder_Inq.Location = new System.Drawing.Point(377, 68);
            this.btnOrder_Inq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrder_Inq.Name = "btnOrder_Inq";
            this.btnOrder_Inq.Size = new System.Drawing.Size(43, 38);
            this.btnOrder_Inq.TabIndex = 164;
            this.btnOrder_Inq.Text = "...";
            this.btnOrder_Inq.UseVisualStyleBackColor = false;
            this.btnOrder_Inq.Click += new System.EventHandler(this.btnOrder_Inq_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSelect);
            this.panel2.Controls.Add(this.dgvData);
            this.panel2.Location = new System.Drawing.Point(579, 182);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 358);
            this.panel2.TabIndex = 163;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSelect.Location = new System.Drawing.Point(37, 246);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(123, 42);
            this.btnSelect.TabIndex = 163;
            this.btnSelect.Text = "選取";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.產品編號,
            this.數量,
            this.業務,
            this.na6_price,
            this.na6_qty,
            this.na6_qtycal,
            this.na6_yftype});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(195, 12);
            this.dgvData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 21;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(540, 300);
            this.dgvData.TabIndex = 162;
            this.dgvData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellEndEdit);
            // 
            // 產品編號
            // 
            this.產品編號.DataPropertyName = "產品編號";
            this.產品編號.FillWeight = 205.1748F;
            this.產品編號.HeaderText = "產品編號";
            this.產品編號.MinimumWidth = 6;
            this.產品編號.Name = "產品編號";
            this.產品編號.ReadOnly = true;
            // 
            // 數量
            // 
            this.數量.DataPropertyName = "數量";
            this.數量.FillWeight = 48.12834F;
            this.數量.HeaderText = "數量";
            this.數量.MinimumWidth = 6;
            this.數量.Name = "數量";
            // 
            // 業務
            // 
            this.業務.DataPropertyName = "業務";
            this.業務.FillWeight = 46.69684F;
            this.業務.HeaderText = "業務";
            this.業務.MinimumWidth = 6;
            this.業務.Name = "業務";
            this.業務.ReadOnly = true;
            // 
            // na6_price
            // 
            this.na6_price.DataPropertyName = "na6_price";
            this.na6_price.HeaderText = "na6_price";
            this.na6_price.MinimumWidth = 6;
            this.na6_price.Name = "na6_price";
            this.na6_price.Visible = false;
            // 
            // na6_qty
            // 
            this.na6_qty.HeaderText = "na6_qty";
            this.na6_qty.MinimumWidth = 6;
            this.na6_qty.Name = "na6_qty";
            this.na6_qty.Visible = false;
            // 
            // na6_qtycal
            // 
            this.na6_qtycal.HeaderText = "na6_qtycal";
            this.na6_qtycal.MinimumWidth = 6;
            this.na6_qtycal.Name = "na6_qtycal";
            this.na6_qtycal.Visible = false;
            // 
            // na6_yftype
            // 
            this.na6_yftype.HeaderText = "na6_yftype";
            this.na6_yftype.MinimumWidth = 6;
            this.na6_yftype.Name = "na6_yftype";
            this.na6_yftype.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvProduct);
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Location = new System.Drawing.Point(35, 182);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 358);
            this.panel1.TabIndex = 162;
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.AllowUserToOrderColumns = true;
            this.dgvProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProduct.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProduct.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.odi_customerid,
            this.odi_line});
            this.dgvProduct.EnableHeadersVisualStyles = false;
            this.dgvProduct.Location = new System.Drawing.Point(3, 12);
            this.dgvProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.RowHeadersVisible = false;
            this.dgvProduct.RowHeadersWidth = 51;
            this.dgvProduct.RowTemplate.Height = 21;
            this.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduct.Size = new System.Drawing.Size(536, 300);
            this.dgvProduct.TabIndex = 156;
            // 
            // odi_customerid
            // 
            this.odi_customerid.DataPropertyName = "odi_customerid";
            this.odi_customerid.FillWeight = 167.9145F;
            this.odi_customerid.HeaderText = "產品編號";
            this.odi_customerid.MinimumWidth = 6;
            this.odi_customerid.Name = "odi_customerid";
            this.odi_customerid.ReadOnly = true;
            // 
            // odi_line
            // 
            this.odi_line.DataPropertyName = "odi_line";
            this.odi_line.FillWeight = 32.08556F;
            this.odi_line.HeaderText = "線路";
            this.odi_line.MinimumWidth = 8;
            this.odi_line.Name = "odi_line";
            this.odi_line.ReadOnly = true;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Location = new System.Drawing.Point(472, 320);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(67, 28);
            this.lblCount.TabIndex = 155;
            this.lblCount.Text = "0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrderID
            // 
            this.txtOrderID.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtOrderID.Location = new System.Drawing.Point(183, 68);
            this.txtOrderID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(167, 28);
            this.txtOrderID.TabIndex = 152;
            this.txtOrderID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderID_KeyDown);
            this.txtOrderID.Leave += new System.EventHandler(this.txtOrderID_Leave);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(31, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 28);
            this.label12.TabIndex = 150;
            this.label12.Text = "訂單單號：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSign
            // 
            this.txtSign.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtSign.Location = new System.Drawing.Point(1148, 68);
            this.txtSign.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(167, 28);
            this.txtSign.TabIndex = 147;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(35, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 28);
            this.label8.TabIndex = 145;
            this.label8.Text = "最後儲存用戶：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(996, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(147, 28);
            this.label13.TabIndex = 136;
            this.label13.Text = "Sign：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtOrderDate.Location = new System.Drawing.Point(828, 28);
            this.txtOrderDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.Size = new System.Drawing.Size(167, 28);
            this.txtOrderDate.TabIndex = 82;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(676, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 28);
            this.label6.TabIndex = 80;
            this.label6.Text = "訂單日期：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomer.Location = new System.Drawing.Point(183, 28);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(167, 28);
            this.txtCustomer.TabIndex = 70;
            this.txtCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyDown);
            this.txtCustomer.Leave += new System.EventHandler(this.txtCustomer_Leave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(31, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 28);
            this.label2.TabIndex = 36;
            this.label2.Text = "客戶：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 664);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "訂單管理";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnNote;
        private System.Windows.Forms.Button btnPI_Cost;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPI_In;
        private System.Windows.Forms.Label lblSaveDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnOrder_Inq;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSign;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInq_Complaint;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInq_Order;
        private System.Windows.Forms.TextBox txtNewDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeliveryDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboShippingMark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQuotationID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkDeal_Yet;
        private System.Windows.Forms.CheckBox chkReplenish;
        private System.Windows.Forms.Button btnInq_Order_Modify;
        private System.Windows.Forms.Button btnComplaint;
        private System.Windows.Forms.Button btnOtherPay;
        private System.Windows.Forms.RadioButton radioWorkOrder_Full;
        private System.Windows.Forms.RadioButton radioWorkOrder;
        private System.Windows.Forms.RadioButton radioPI;
        private System.Windows.Forms.CheckBox chkOther;
        private System.Windows.Forms.DataGridViewTextBoxColumn odi_customerid;
        private System.Windows.Forms.DataGridViewTextBoxColumn odi_line;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn 產品編號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 數量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 業務;
        private System.Windows.Forms.DataGridViewTextBoxColumn na6_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn na6_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn na6_qtycal;
        private System.Windows.Forms.DataGridViewTextBoxColumn na6_yftype;
        private System.Windows.Forms.Button btnSelect;
    }
}