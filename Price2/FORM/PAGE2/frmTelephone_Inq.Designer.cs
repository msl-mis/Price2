namespace Price2
{
    partial class frmTelephone_Inq
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.tel_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel_twphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel_dlphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel_twfax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel_twmobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel_dlfax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel_dlmobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInq = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.btnExport);
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Controls.Add(this.cboType);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.txtKey);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(1, 18);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(1045, 541);
            this.groupBox.TabIndex = 5;
            this.groupBox.TabStop = false;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tel_name,
            this.tel_twphone,
            this.tel_dlphone,
            this.tel_twfax,
            this.tel_twmobile,
            this.tel_dlfax,
            this.tel_dlmobile,
            this.tel_type});
            this.dgvData.Location = new System.Drawing.Point(13, 85);
            this.dgvData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1011, 422);
            this.dgvData.TabIndex = 49;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // tel_name
            // 
            this.tel_name.DataPropertyName = "tel_name";
            this.tel_name.HeaderText = "姓名";
            this.tel_name.MinimumWidth = 6;
            this.tel_name.Name = "tel_name";
            this.tel_name.ReadOnly = true;
            this.tel_name.Width = 125;
            // 
            // tel_twphone
            // 
            this.tel_twphone.DataPropertyName = "tel_twphone";
            this.tel_twphone.HeaderText = "臺灣手機";
            this.tel_twphone.MinimumWidth = 6;
            this.tel_twphone.Name = "tel_twphone";
            this.tel_twphone.ReadOnly = true;
            this.tel_twphone.Width = 125;
            // 
            // tel_dlphone
            // 
            this.tel_dlphone.DataPropertyName = "tel_dlphone";
            this.tel_dlphone.HeaderText = "大陸手機";
            this.tel_dlphone.MinimumWidth = 6;
            this.tel_dlphone.Name = "tel_dlphone";
            this.tel_dlphone.ReadOnly = true;
            this.tel_dlphone.Width = 125;
            // 
            // tel_twfax
            // 
            this.tel_twfax.DataPropertyName = "tel_twfax";
            this.tel_twfax.HeaderText = "臺灣公司";
            this.tel_twfax.MinimumWidth = 6;
            this.tel_twfax.Name = "tel_twfax";
            this.tel_twfax.ReadOnly = true;
            this.tel_twfax.Width = 125;
            // 
            // tel_twmobile
            // 
            this.tel_twmobile.DataPropertyName = "tel_twmobile";
            this.tel_twmobile.HeaderText = "臺灣住家";
            this.tel_twmobile.MinimumWidth = 6;
            this.tel_twmobile.Name = "tel_twmobile";
            this.tel_twmobile.ReadOnly = true;
            this.tel_twmobile.Width = 125;
            // 
            // tel_dlfax
            // 
            this.tel_dlfax.DataPropertyName = "tel_dlfax";
            this.tel_dlfax.HeaderText = "大陸公司";
            this.tel_dlfax.MinimumWidth = 6;
            this.tel_dlfax.Name = "tel_dlfax";
            this.tel_dlfax.ReadOnly = true;
            this.tel_dlfax.Width = 125;
            // 
            // tel_dlmobile
            // 
            this.tel_dlmobile.DataPropertyName = "tel_dlmobile";
            this.tel_dlmobile.HeaderText = "大陸住家";
            this.tel_dlmobile.MinimumWidth = 6;
            this.tel_dlmobile.Name = "tel_dlmobile";
            this.tel_dlmobile.ReadOnly = true;
            this.tel_dlmobile.Width = 125;
            // 
            // tel_type
            // 
            this.tel_type.DataPropertyName = "tel_type";
            this.tel_type.HeaderText = "分類";
            this.tel_type.MinimumWidth = 6;
            this.tel_type.Name = "tel_type";
            this.tel_type.ReadOnly = true;
            this.tel_type.Width = 125;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExport.Location = new System.Drawing.Point(724, 29);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(69, 36);
            this.btnExport.TabIndex = 48;
            this.btnExport.Text = "匯出";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.Location = new System.Drawing.Point(804, 29);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(69, 36);
            this.btnClear.TabIndex = 44;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(413, 29);
            this.cboType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(193, 33);
            this.cboType.TabIndex = 21;
            this.cboType.Text = "(ALL)";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(308, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 34);
            this.label3.TabIndex = 20;
            this.label3.Text = "分類：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(884, 29);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 36);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInq.Location = new System.Drawing.Point(644, 29);
            this.btnInq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(69, 36);
            this.btnInq.TabIndex = 14;
            this.btnInq.Text = "搜尋";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtKey.Location = new System.Drawing.Point(108, 29);
            this.txtKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(193, 34);
            this.txtKey.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "關鍵字：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmTelephone_Inq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1039, 561);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmTelephone_Inq";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "私人電話簿用戶查詢";
            this.Activated += new System.EventHandler(this.frmTelephone_Inq_Activated);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel_twphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel_dlphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel_twfax;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel_twmobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel_dlfax;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel_dlmobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel_type;
    }
}