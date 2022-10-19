namespace Price2
{
    partial class frmCustomer_Inq_Country
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
            this.chkDeal = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cus_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cus_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cus_contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cus_tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInq = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.chkDeal);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.cboCountry);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.lblCount);
            this.groupBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox.Size = new System.Drawing.Size(656, 415);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            // 
            // chkDeal
            // 
            this.chkDeal.Location = new System.Drawing.Point(272, 27);
            this.chkDeal.Margin = new System.Windows.Forms.Padding(2);
            this.chkDeal.Name = "chkDeal";
            this.chkDeal.Size = new System.Drawing.Size(68, 25);
            this.chkDeal.TabIndex = 52;
            this.chkDeal.Text = "成交";
            this.chkDeal.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(13, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 27);
            this.label2.TabIndex = 51;
            this.label2.Text = "搜尋國別：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
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
            this.cus_id,
            this.cus_name,
            this.cus_contact,
            this.cus_tel});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(16, 62);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(526, 333);
            this.dgvData.TabIndex = 50;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // cus_id
            // 
            this.cus_id.DataPropertyName = "cus_id";
            this.cus_id.HeaderText = "客戶編號";
            this.cus_id.MinimumWidth = 6;
            this.cus_id.Name = "cus_id";
            this.cus_id.ReadOnly = true;
            this.cus_id.Width = 125;
            // 
            // cus_name
            // 
            this.cus_name.DataPropertyName = "cus_name";
            this.cus_name.HeaderText = "客戶名稱";
            this.cus_name.MinimumWidth = 6;
            this.cus_name.Name = "cus_name";
            this.cus_name.ReadOnly = true;
            this.cus_name.Width = 200;
            // 
            // cus_contact
            // 
            this.cus_contact.DataPropertyName = "cus_contact";
            this.cus_contact.HeaderText = "聯絡人";
            this.cus_contact.MinimumWidth = 6;
            this.cus_contact.Name = "cus_contact";
            this.cus_contact.ReadOnly = true;
            this.cus_contact.Width = 125;
            // 
            // cus_tel
            // 
            this.cus_tel.DataPropertyName = "cus_tel";
            this.cus_tel.HeaderText = "電話";
            this.cus_tel.MinimumWidth = 6;
            this.cus_tel.Name = "cus_tel";
            this.cus_tel.ReadOnly = true;
            this.cus_tel.Width = 200;
            // 
            // cboCountry
            // 
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Items.AddRange(new object[] {
            "AUSTRIA",
            "BELGIUM",
            "BULGARIA",
            "CHINA",
            "COLUMBIA",
            "CANADA",
            "FRANCE",
            "GERMANY",
            "HK",
            "HUNGARY",
            "INDIA",
            "ISRAEL",
            "ITALY",
            "JAPAN",
            "KOREA",
            "NETHERLANDS",
            "POLAND",
            "RUSSIA",
            "SINGAPORE",
            "SOUTH AFRICA",
            "SPAIN",
            "SRI LANKA",
            "SWEDEN",
            "SWITZERLAND",
            "TAIWAN",
            "THAI",
            "TURKEY",
            "UK",
            "UNITED ARAB",
            "USA",
            "VIETNAM"});
            this.cboCountry.Location = new System.Drawing.Point(104, 26);
            this.cboCountry.Margin = new System.Windows.Forms.Padding(2);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(151, 24);
            this.cboCountry.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(480, 18);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 34);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInq.Location = new System.Drawing.Point(345, 18);
            this.btnInq.Margin = new System.Windows.Forms.Padding(2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(63, 34);
            this.btnInq.TabIndex = 14;
            this.btnInq.Text = "搜尋";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Location = new System.Drawing.Point(412, 22);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(73, 27);
            this.lblCount.TabIndex = 35;
            this.lblCount.Text = "筆數";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCustomer_Inq_Country
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 413);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCustomer_Inq_Country";
            this.Text = "選擇客戶[國別條件]";
            this.Activated += new System.EventHandler(this.frmCustomer_Inq_Country_Activated);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.CheckBox chkDeal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_tel;
    }
}