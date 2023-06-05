namespace Price2
{
    partial class frmDealReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDealReport));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblQty5 = new System.Windows.Forms.Label();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lblQty4 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.lblQty3 = new System.Windows.Forms.Label();
            this.lblY1 = new System.Windows.Forms.Label();
            this.lblY2 = new System.Windows.Forms.Label();
            this.lblY3 = new System.Windows.Forms.Label();
            this.lblY4 = new System.Windows.Forms.Label();
            this.lblY5 = new System.Windows.Forms.Label();
            this.dtpDateE = new System.Windows.Forms.DateTimePicker();
            this.dtpDateS = new System.Windows.Forms.DateTimePicker();
            this.chkAll_year = new System.Windows.Forms.CheckBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cboFactory = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInq = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.PD = new System.Drawing.Printing.PrintDocument();
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
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.tableLayoutPanel1);
            this.groupBox.Controls.Add(this.dtpDateE);
            this.groupBox.Controls.Add(this.dtpDateS);
            this.groupBox.Controls.Add(this.chkAll_year);
            this.groupBox.Controls.Add(this.chart1);
            this.groupBox.Controls.Add(this.cboFactory);
            this.groupBox.Controls.Add(this.label17);
            this.groupBox.Controls.Add(this.label13);
            this.groupBox.Controls.Add(this.cboClass);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.btnPrint);
            this.groupBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 10F);
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(1112, 464);
            this.groupBox.TabIndex = 10;
            this.groupBox.TabStop = false;
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(101, 119);
            this.dtpYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(73, 27);
            this.dtpYear.TabIndex = 233;
            this.dtpYear.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(9, 119);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(87, 31);
            this.label3.TabIndex = 232;
            this.label3.Text = "年份：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(111, 406);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(73, 31);
            this.btnClear.TabIndex = 228;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Fuchsia;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(389, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(701, 4);
            this.label1.TabIndex = 227;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Controls.Add(this.lblQty5, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblQty1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblQty4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblQty2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblQty3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblY1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblY2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblY3, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblY4, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblY5, 5, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(389, 380);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 70);
            this.tableLayoutPanel1.TabIndex = 226;
            // 
            // lblQty5
            // 
            this.lblQty5.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQty5.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQty5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblQty5.Location = new System.Drawing.Point(520, 0);
            this.lblQty5.Name = "lblQty5";
            this.lblQty5.Size = new System.Drawing.Size(80, 35);
            this.lblQty5.TabIndex = 129;
            this.lblQty5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQty1
            // 
            this.lblQty1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQty1.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQty1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblQty1.Location = new System.Drawing.Point(88, 0);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(80, 35);
            this.lblQty1.TabIndex = 125;
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl2
            // 
            this.lbl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl2.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl2.ForeColor = System.Drawing.Color.Blue;
            this.lbl2.Location = new System.Drawing.Point(3, 35);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(79, 35);
            this.lbl2.TabIndex = 122;
            this.lbl2.Text = "年增率:";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQty4
            // 
            this.lblQty4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQty4.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQty4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblQty4.Location = new System.Drawing.Point(412, 0);
            this.lblQty4.Name = "lblQty4";
            this.lblQty4.Size = new System.Drawing.Size(80, 35);
            this.lblQty4.TabIndex = 128;
            this.lblQty4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl1
            // 
            this.lbl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl1.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl1.ForeColor = System.Drawing.Color.Blue;
            this.lbl1.Location = new System.Drawing.Point(3, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(79, 35);
            this.lbl1.TabIndex = 121;
            this.lbl1.Text = "數量/萬:";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQty2
            // 
            this.lblQty2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQty2.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQty2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblQty2.Location = new System.Drawing.Point(196, 0);
            this.lblQty2.Name = "lblQty2";
            this.lblQty2.Size = new System.Drawing.Size(80, 35);
            this.lblQty2.TabIndex = 126;
            this.lblQty2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQty3
            // 
            this.lblQty3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQty3.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQty3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblQty3.Location = new System.Drawing.Point(304, 0);
            this.lblQty3.Name = "lblQty3";
            this.lblQty3.Size = new System.Drawing.Size(80, 35);
            this.lblQty3.TabIndex = 127;
            this.lblQty3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY1
            // 
            this.lblY1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblY1.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblY1.Location = new System.Drawing.Point(88, 35);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(80, 35);
            this.lblY1.TabIndex = 138;
            this.lblY1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY2
            // 
            this.lblY2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblY2.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblY2.Location = new System.Drawing.Point(196, 35);
            this.lblY2.Name = "lblY2";
            this.lblY2.Size = new System.Drawing.Size(80, 35);
            this.lblY2.TabIndex = 136;
            this.lblY2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY3
            // 
            this.lblY3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblY3.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblY3.Location = new System.Drawing.Point(304, 35);
            this.lblY3.Name = "lblY3";
            this.lblY3.Size = new System.Drawing.Size(80, 35);
            this.lblY3.TabIndex = 137;
            this.lblY3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY4
            // 
            this.lblY4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblY4.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblY4.Location = new System.Drawing.Point(412, 35);
            this.lblY4.Name = "lblY4";
            this.lblY4.Size = new System.Drawing.Size(80, 35);
            this.lblY4.TabIndex = 144;
            this.lblY4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblY5
            // 
            this.lblY5.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblY5.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblY5.Location = new System.Drawing.Point(520, 35);
            this.lblY5.Name = "lblY5";
            this.lblY5.Size = new System.Drawing.Size(80, 35);
            this.lblY5.TabIndex = 140;
            this.lblY5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDateE
            // 
            this.dtpDateE.CustomFormat = "MM/dd";
            this.dtpDateE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateE.Location = new System.Drawing.Point(209, 151);
            this.dtpDateE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDateE.Name = "dtpDateE";
            this.dtpDateE.ShowUpDown = true;
            this.dtpDateE.Size = new System.Drawing.Size(65, 27);
            this.dtpDateE.TabIndex = 225;
            this.dtpDateE.Enter += new System.EventHandler(this.dtpDateE_Enter);
            // 
            // dtpDateS
            // 
            this.dtpDateS.CustomFormat = "MM/dd";
            this.dtpDateS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateS.Location = new System.Drawing.Point(101, 151);
            this.dtpDateS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDateS.Name = "dtpDateS";
            this.dtpDateS.ShowUpDown = true;
            this.dtpDateS.Size = new System.Drawing.Size(73, 27);
            this.dtpDateS.TabIndex = 224;
            this.dtpDateS.Enter += new System.EventHandler(this.dtpDateS_Enter);
            // 
            // chkAll_year
            // 
            this.chkAll_year.AutoSize = true;
            this.chkAll_year.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkAll_year.Location = new System.Drawing.Point(288, 155);
            this.chkAll_year.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkAll_year.Name = "chkAll_year";
            this.chkAll_year.Size = new System.Drawing.Size(81, 21);
            this.chkAll_year.TabIndex = 222;
            this.chkAll_year.Text = "全年度";
            this.chkAll_year.UseVisualStyleBackColor = true;
            this.chkAll_year.CheckedChanged += new System.EventHandler(this.chkAll_year_CheckedChanged);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(389, 18);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(700, 366);
            this.chart1.TabIndex = 221;
            this.chart1.Text = "chart1";
            // 
            // cboFactory
            // 
            this.cboFactory.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboFactory.FormattingEnabled = true;
            this.cboFactory.Items.AddRange(new object[] {
            "冠志",
            "越南"});
            this.cboFactory.Location = new System.Drawing.Point(109, 38);
            this.cboFactory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboFactory.Name = "cboFactory";
            this.cboFactory.Size = new System.Drawing.Size(172, 27);
            this.cboFactory.TabIndex = 219;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(175, 151);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label17.Size = new System.Drawing.Size(36, 31);
            this.label17.TabIndex = 217;
            this.label17.Text = "至";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(9, 152);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(87, 31);
            this.label13.TabIndex = 215;
            this.label13.Text = "日期：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboClass
            // 
            this.cboClass.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Items.AddRange(new object[] {
            "電源",
            "光纖",
            "其他"});
            this.cboClass.Location = new System.Drawing.Point(109, 70);
            this.cboClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(172, 27);
            this.cboClass.TabIndex = 186;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 31);
            this.label2.TabIndex = 126;
            this.label2.Text = "產品別：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(268, 406);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 31);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(13, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 31);
            this.label5.TabIndex = 110;
            this.label5.Text = "工廠別：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInq.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInq.Location = new System.Drawing.Point(32, 406);
            this.btnInq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(73, 31);
            this.btnInq.TabIndex = 93;
            this.btnInq.Text = "查詢";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrint.Location = new System.Drawing.Point(189, 406);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(73, 31);
            this.btnPrint.TabIndex = 92;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
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
            // PD
            // 
            this.PD.OriginAtMargins = true;
            this.PD.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.PD_BeginPrint);
            this.PD.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PD_PrintPage);
            this.PD.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.PD_QueryPageSettings);
            // 
            // frmDealReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 464);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDealReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "產品成交查詢";
            this.Load += new System.EventHandler(this.frmDealReport_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblY4;
        private System.Windows.Forms.Label lblY5;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.Label lblY2;
        private System.Windows.Forms.Label lblY3;
        private System.Windows.Forms.Label lblQty5;
        private System.Windows.Forms.Label lblQty1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lblQty4;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblQty2;
        private System.Windows.Forms.Label lblQty3;
        private System.Windows.Forms.DateTimePicker dtpDateE;
        private System.Windows.Forms.DateTimePicker dtpDateS;
        private System.Windows.Forms.CheckBox chkAll_year;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox cboFactory;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument PD;
    }
}