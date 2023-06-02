namespace Price2
{
    partial class frmSalesReport
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesReport));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboJ = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblM5 = new System.Windows.Forms.Label();
            this.lblM3 = new System.Windows.Forms.Label();
            this.lblM4 = new System.Windows.Forms.Label();
            this.lblY4 = new System.Windows.Forms.Label();
            this.lblY5 = new System.Windows.Forms.Label();
            this.lblM1 = new System.Windows.Forms.Label();
            this.lblM2 = new System.Windows.Forms.Label();
            this.lblR5 = new System.Windows.Forms.Label();
            this.lblY1 = new System.Windows.Forms.Label();
            this.lblY2 = new System.Windows.Forms.Label();
            this.lblY3 = new System.Windows.Forms.Label();
            this.lblR1 = new System.Windows.Forms.Label();
            this.lblR2 = new System.Windows.Forms.Label();
            this.lblR3 = new System.Windows.Forms.Label();
            this.lblR4 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lblQty5 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lblQty4 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.lblQty3 = new System.Windows.Forms.Label();
            this.dtpDateE = new System.Windows.Forms.DateTimePicker();
            this.dtpDateS = new System.Windows.Forms.DateTimePicker();
            this.chkAll_year = new System.Windows.Forms.CheckBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cboSales = new System.Windows.Forms.ComboBox();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.cboDivision = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.radio2 = new System.Windows.Forms.RadioButton();
            this.radio1 = new System.Windows.Forms.RadioButton();
            this.cboVendorID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInq = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.PD = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.groupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.dtpYear);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.cboJ);
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.tableLayoutPanel1);
            this.groupBox.Controls.Add(this.dtpDateE);
            this.groupBox.Controls.Add(this.dtpDateS);
            this.groupBox.Controls.Add(this.chkAll_year);
            this.groupBox.Controls.Add(this.chart1);
            this.groupBox.Controls.Add(this.cboSales);
            this.groupBox.Controls.Add(this.cboClass);
            this.groupBox.Controls.Add(this.cboDivision);
            this.groupBox.Controls.Add(this.label17);
            this.groupBox.Controls.Add(this.label13);
            this.groupBox.Controls.Add(this.radio2);
            this.groupBox.Controls.Add(this.radio1);
            this.groupBox.Controls.Add(this.cboVendorID);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label18);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.btnPrint);
            this.groupBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 10F);
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox.Size = new System.Drawing.Size(886, 460);
            this.groupBox.TabIndex = 9;
            this.groupBox.TabStop = false;
            // 
            // dtpYear
            // 
            this.dtpYear.CalendarFont = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(70, 179);
            this.dtpYear.Margin = new System.Windows.Forms.Padding(2);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(61, 27);
            this.dtpYear.TabIndex = 233;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(9, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 232;
            this.label3.Text = "年份：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboJ
            // 
            this.cboJ.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboJ.FormattingEnabled = true;
            this.cboJ.Items.AddRange(new object[] {
            "NO.1",
            "其他"});
            this.cboJ.Location = new System.Drawing.Point(160, 134);
            this.cboJ.Margin = new System.Windows.Forms.Padding(2);
            this.cboJ.Name = "cboJ";
            this.cboJ.Size = new System.Drawing.Size(88, 24);
            this.cboJ.TabIndex = 229;
            this.cboJ.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(90, 320);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(51, 33);
            this.btnClear.TabIndex = 228;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Magenta;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(332, 316);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(526, 2);
            this.label1.TabIndex = 227;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.Controls.Add(this.lblM5, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblM3, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblM4, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblY4, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblY5, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblM1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblM2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblR5, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblY1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblY2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblY3, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblR1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblR2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblR3, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblR4, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblQty5, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblQty1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblQty4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblQty2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblQty3, 3, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(332, 320);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 98);
            this.tableLayoutPanel1.TabIndex = 226;
            // 
            // lblM5
            // 
            this.lblM5.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblM5.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblM5.Location = new System.Drawing.Point(390, 72);
            this.lblM5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblM5.Name = "lblM5";
            this.lblM5.Size = new System.Drawing.Size(60, 26);
            this.lblM5.TabIndex = 227;
            this.lblM5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblM3
            // 
            this.lblM3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblM3.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblM3.Location = new System.Drawing.Point(228, 72);
            this.lblM3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblM3.Name = "lblM3";
            this.lblM3.Size = new System.Drawing.Size(60, 26);
            this.lblM3.TabIndex = 146;
            this.lblM3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblM4
            // 
            this.lblM4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblM4.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblM4.Location = new System.Drawing.Point(309, 72);
            this.lblM4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblM4.Name = "lblM4";
            this.lblM4.Size = new System.Drawing.Size(60, 26);
            this.lblM4.TabIndex = 147;
            this.lblM4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY4
            // 
            this.lblY4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblY4.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblY4.Location = new System.Drawing.Point(309, 48);
            this.lblY4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblY4.Name = "lblY4";
            this.lblY4.Size = new System.Drawing.Size(60, 24);
            this.lblY4.TabIndex = 144;
            this.lblY4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY5
            // 
            this.lblY5.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblY5.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblY5.Location = new System.Drawing.Point(390, 48);
            this.lblY5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblY5.Name = "lblY5";
            this.lblY5.Size = new System.Drawing.Size(60, 24);
            this.lblY5.TabIndex = 140;
            this.lblY5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblM1
            // 
            this.lblM1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblM1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblM1.Location = new System.Drawing.Point(66, 72);
            this.lblM1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblM1.Name = "lblM1";
            this.lblM1.Size = new System.Drawing.Size(60, 26);
            this.lblM1.TabIndex = 141;
            this.lblM1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblM2
            // 
            this.lblM2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblM2.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblM2.Location = new System.Drawing.Point(147, 72);
            this.lblM2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblM2.Name = "lblM2";
            this.lblM2.Size = new System.Drawing.Size(60, 26);
            this.lblM2.TabIndex = 142;
            this.lblM2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblR5
            // 
            this.lblR5.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblR5.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblR5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblR5.Location = new System.Drawing.Point(390, 24);
            this.lblR5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblR5.Name = "lblR5";
            this.lblR5.Size = new System.Drawing.Size(60, 24);
            this.lblR5.TabIndex = 139;
            this.lblR5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY1
            // 
            this.lblY1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblY1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblY1.Location = new System.Drawing.Point(66, 48);
            this.lblY1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(60, 24);
            this.lblY1.TabIndex = 138;
            this.lblY1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY2
            // 
            this.lblY2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblY2.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblY2.Location = new System.Drawing.Point(147, 48);
            this.lblY2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(60, 24);
            this.lblY2.TabIndex = 136;
            this.lblY2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY3
            // 
            this.lblY3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblY3.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblY3.Location = new System.Drawing.Point(228, 48);
            this.lblY3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblY3.Name = "lblY3";
            this.lblY3.Size = new System.Drawing.Size(60, 24);
            this.lblY3.TabIndex = 137;
            this.lblY3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblR1
            // 
            this.lblR1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblR1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblR1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblR1.Location = new System.Drawing.Point(66, 24);
            this.lblR1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblR1.Name = "lblR1";
            this.lblR1.Size = new System.Drawing.Size(60, 24);
            this.lblR1.TabIndex = 130;
            this.lblR1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblR2
            // 
            this.lblR2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblR2.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblR2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblR2.Location = new System.Drawing.Point(147, 24);
            this.lblR2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblR2.Name = "lblR2";
            this.lblR2.Size = new System.Drawing.Size(60, 24);
            this.lblR2.TabIndex = 133;
            this.lblR2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblR3
            // 
            this.lblR3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblR3.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblR3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblR3.Location = new System.Drawing.Point(228, 24);
            this.lblR3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblR3.Name = "lblR3";
            this.lblR3.Size = new System.Drawing.Size(60, 24);
            this.lblR3.TabIndex = 131;
            this.lblR3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblR4
            // 
            this.lblR4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblR4.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblR4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblR4.Location = new System.Drawing.Point(309, 24);
            this.lblR4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblR4.Name = "lblR4";
            this.lblR4.Size = new System.Drawing.Size(60, 24);
            this.lblR4.TabIndex = 132;
            this.lblR4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl4
            // 
            this.lbl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl4.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl4.ForeColor = System.Drawing.Color.Blue;
            this.lbl4.Location = new System.Drawing.Point(2, 72);
            this.lbl4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(60, 26);
            this.lbl4.TabIndex = 124;
            this.lbl4.Text = "毛利率:";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQty5
            // 
            this.lblQty5.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQty5.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQty5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblQty5.Location = new System.Drawing.Point(390, 0);
            this.lblQty5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQty5.Name = "lblQty5";
            this.lblQty5.Size = new System.Drawing.Size(60, 24);
            this.lblQty5.TabIndex = 129;
            this.lblQty5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl3
            // 
            this.lbl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl3.ForeColor = System.Drawing.Color.Blue;
            this.lbl3.Location = new System.Drawing.Point(2, 48);
            this.lbl3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(60, 24);
            this.lbl3.TabIndex = 123;
            this.lbl3.Text = "年增率:";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQty1
            // 
            this.lblQty1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQty1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQty1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblQty1.Location = new System.Drawing.Point(66, 0);
            this.lblQty1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(60, 24);
            this.lblQty1.TabIndex = 125;
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl2
            // 
            this.lbl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl2.ForeColor = System.Drawing.Color.Blue;
            this.lbl2.Location = new System.Drawing.Point(2, 24);
            this.lbl2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(60, 24);
            this.lbl2.TabIndex = 122;
            this.lbl2.Text = "成交/萬:";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQty4
            // 
            this.lblQty4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQty4.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQty4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblQty4.Location = new System.Drawing.Point(309, 0);
            this.lblQty4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQty4.Name = "lblQty4";
            this.lblQty4.Size = new System.Drawing.Size(60, 24);
            this.lblQty4.TabIndex = 128;
            this.lblQty4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl1
            // 
            this.lbl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl1.ForeColor = System.Drawing.Color.Blue;
            this.lbl1.Location = new System.Drawing.Point(2, 0);
            this.lbl1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(60, 24);
            this.lbl1.TabIndex = 121;
            this.lbl1.Text = "數量/萬:";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQty2
            // 
            this.lblQty2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQty2.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQty2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblQty2.Location = new System.Drawing.Point(147, 0);
            this.lblQty2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQty2.Name = "lblQty2";
            this.lblQty2.Size = new System.Drawing.Size(60, 24);
            this.lblQty2.TabIndex = 126;
            this.lblQty2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQty3
            // 
            this.lblQty3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQty3.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQty3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblQty3.Location = new System.Drawing.Point(228, 0);
            this.lblQty3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQty3.Name = "lblQty3";
            this.lblQty3.Size = new System.Drawing.Size(60, 24);
            this.lblQty3.TabIndex = 127;
            this.lblQty3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDateE
            // 
            this.dtpDateE.CalendarFont = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpDateE.CustomFormat = "MM/dd";
            this.dtpDateE.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpDateE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateE.Location = new System.Drawing.Point(158, 208);
            this.dtpDateE.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDateE.Name = "dtpDateE";
            this.dtpDateE.ShowUpDown = true;
            this.dtpDateE.Size = new System.Drawing.Size(58, 27);
            this.dtpDateE.TabIndex = 225;
            this.dtpDateE.Enter += new System.EventHandler(this.dtpDateE_Enter);
            // 
            // dtpDateS
            // 
            this.dtpDateS.CalendarFont = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpDateS.CustomFormat = "MM/dd";
            this.dtpDateS.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpDateS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateS.Location = new System.Drawing.Point(70, 208);
            this.dtpDateS.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDateS.Name = "dtpDateS";
            this.dtpDateS.ShowUpDown = true;
            this.dtpDateS.Size = new System.Drawing.Size(61, 27);
            this.dtpDateS.TabIndex = 224;
            this.dtpDateS.Enter += new System.EventHandler(this.dtpDateS_Enter);
            // 
            // chkAll_year
            // 
            this.chkAll_year.AutoSize = true;
            this.chkAll_year.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkAll_year.Location = new System.Drawing.Point(227, 211);
            this.chkAll_year.Margin = new System.Windows.Forms.Padding(2);
            this.chkAll_year.Name = "chkAll_year";
            this.chkAll_year.Size = new System.Drawing.Size(74, 20);
            this.chkAll_year.TabIndex = 222;
            this.chkAll_year.Text = "全年度";
            this.chkAll_year.UseVisualStyleBackColor = true;
            this.chkAll_year.CheckedChanged += new System.EventHandler(this.chkAll_year_CheckedChanged);
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(332, 30);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart1.Size = new System.Drawing.Size(525, 296);
            this.chart1.TabIndex = 221;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // cboSales
            // 
            this.cboSales.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboSales.FormattingEnabled = true;
            this.cboSales.Location = new System.Drawing.Point(66, 134);
            this.cboSales.Margin = new System.Windows.Forms.Padding(2);
            this.cboSales.Name = "cboSales";
            this.cboSales.Size = new System.Drawing.Size(90, 24);
            this.cboSales.TabIndex = 220;
            this.cboSales.SelectedIndexChanged += new System.EventHandler(this.cboSales_SelectedIndexChanged);
            // 
            // cboClass
            // 
            this.cboClass.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(66, 100);
            this.cboClass.Margin = new System.Windows.Forms.Padding(2);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(130, 24);
            this.cboClass.TabIndex = 219;
            // 
            // cboDivision
            // 
            this.cboDivision.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboDivision.FormattingEnabled = true;
            this.cboDivision.Location = new System.Drawing.Point(66, 67);
            this.cboDivision.Margin = new System.Windows.Forms.Padding(2);
            this.cboDivision.Name = "cboDivision";
            this.cboDivision.Size = new System.Drawing.Size(144, 24);
            this.cboDivision.TabIndex = 218;
            this.cboDivision.SelectedIndexChanged += new System.EventHandler(this.cboDivision_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(130, 208);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label17.Size = new System.Drawing.Size(27, 25);
            this.label17.TabIndex = 217;
            this.label17.Text = "至";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(9, 208);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(59, 25);
            this.label13.TabIndex = 215;
            this.label13.Text = "日期：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radio2
            // 
            this.radio2.AutoSize = true;
            this.radio2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radio2.ForeColor = System.Drawing.Color.Blue;
            this.radio2.Location = new System.Drawing.Point(132, 31);
            this.radio2.Margin = new System.Windows.Forms.Padding(2);
            this.radio2.Name = "radio2";
            this.radio2.Size = new System.Drawing.Size(57, 20);
            this.radio2.TabIndex = 213;
            this.radio2.Text = "利潤";
            this.radio2.UseVisualStyleBackColor = true;
            this.radio2.CheckedChanged += new System.EventHandler(this.radio2_CheckedChanged);
            // 
            // radio1
            // 
            this.radio1.AutoSize = true;
            this.radio1.Checked = true;
            this.radio1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radio1.ForeColor = System.Drawing.Color.Blue;
            this.radio1.Location = new System.Drawing.Point(19, 31);
            this.radio1.Margin = new System.Windows.Forms.Padding(2);
            this.radio1.Name = "radio1";
            this.radio1.Size = new System.Drawing.Size(105, 20);
            this.radio1.TabIndex = 212;
            this.radio1.TabStop = true;
            this.radio1.Text = "營業額比較";
            this.radio1.UseVisualStyleBackColor = true;
            this.radio1.CheckedChanged += new System.EventHandler(this.radio1_CheckedChanged);
            // 
            // cboVendorID
            // 
            this.cboVendorID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboVendorID.FormattingEnabled = true;
            this.cboVendorID.Location = new System.Drawing.Point(251, 100);
            this.cboVendorID.Margin = new System.Windows.Forms.Padding(2);
            this.cboVendorID.Name = "cboVendorID";
            this.cboVendorID.Size = new System.Drawing.Size(70, 24);
            this.cboVendorID.TabIndex = 186;
            this.cboVendorID.SelectedIndexChanged += new System.EventHandler(this.cboVendorID_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(199, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 126;
            this.label2.Text = "廠號：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(9, 68);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 25);
            this.label18.TabIndex = 120;
            this.label18.Text = "部門：";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(214, 320);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(51, 33);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(9, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 25);
            this.label5.TabIndex = 110;
            this.label5.Text = "分類：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInq.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInq.Location = new System.Drawing.Point(28, 320);
            this.btnInq.Margin = new System.Windows.Forms.Padding(2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(51, 33);
            this.btnInq.TabIndex = 93;
            this.btnInq.Text = "查詢";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(9, 135);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 25);
            this.label6.TabIndex = 113;
            this.label6.Text = "業務：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrint.Location = new System.Drawing.Point(152, 320);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(51, 33);
            this.btnPrint.TabIndex = 92;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // PD
            // 
            this.PD.OriginAtMargins = true;
            this.PD.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.PD_BeginPrint);
            this.PD.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PD_PrintPage);
            this.PD.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.PD_QueryPageSettings);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // frmSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 460);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成交查詢";
            this.Load += new System.EventHandler(this.frmSalesReport_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cboVendorID;
        private System.Windows.Forms.RadioButton radio2;
        private System.Windows.Forms.RadioButton radio1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox cboSales;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.ComboBox cboDivision;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkAll_year;
        private System.Windows.Forms.Label lblQty1;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblQty5;
        private System.Windows.Forms.Label lblQty4;
        private System.Windows.Forms.Label lblQty3;
        private System.Windows.Forms.Label lblQty2;
        private System.Windows.Forms.DateTimePicker dtpDateE;
        private System.Windows.Forms.DateTimePicker dtpDateS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblM5;
        private System.Windows.Forms.Label lblM3;
        private System.Windows.Forms.Label lblM4;
        private System.Windows.Forms.Label lblY4;
        private System.Windows.Forms.Label lblY5;
        private System.Windows.Forms.Label lblM1;
        private System.Windows.Forms.Label lblM2;
        private System.Windows.Forms.Label lblR5;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.Label lblY2;
        private System.Windows.Forms.Label lblY3;
        private System.Windows.Forms.Label lblR1;
        private System.Windows.Forms.Label lblR2;
        private System.Windows.Forms.Label lblR3;
        private System.Windows.Forms.Label lblR4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cboJ;
        private System.Drawing.Printing.PrintDocument PD;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Label label3;
    }
}