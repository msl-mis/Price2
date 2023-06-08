namespace Price2
{
    partial class frmCustomer_Inq_Customer
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cboYw = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInq = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cus_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cus_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cus_contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cus_tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cus_yw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.cboYw);
            this.groupBox.Controls.Add(this.btnExport);
            this.groupBox.Controls.Add(this.txtCustomerID);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox.Size = new System.Drawing.Size(656, 413);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cus_id,
            this.cus_name,
            this.cus_contact,
            this.cus_tel,
            this.cus_yw});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(16, 62);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(623, 333);
            this.dgvData.TabIndex = 50;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(-4, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 27);
            this.label2.TabIndex = 36;
            this.label2.Text = "客戶：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboYw
            // 
            this.cboYw.FormattingEnabled = true;
            this.cboYw.Location = new System.Drawing.Point(262, 25);
            this.cboYw.Margin = new System.Windows.Forms.Padding(2);
            this.cboYw.Name = "cboYw";
            this.cboYw.Size = new System.Drawing.Size(122, 24);
            this.cboYw.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExport.Location = new System.Drawing.Point(509, 22);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(63, 29);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "匯出";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomerID.Location = new System.Drawing.Point(71, 24);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(113, 27);
            this.txtCustomerID.TabIndex = 3;
            this.txtCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(577, 22);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 29);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInq.Location = new System.Drawing.Point(442, 22);
            this.btnInq.Margin = new System.Windows.Forms.Padding(2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(63, 29);
            this.btnInq.TabIndex = 14;
            this.btnInq.Text = "搜尋";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(185, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 27);
            this.label1.TabIndex = 35;
            this.label1.Text = "業務：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cus_id
            // 
            this.cus_id.DataPropertyName = "cus_id";
            this.cus_id.FillWeight = 150F;
            this.cus_id.HeaderText = "客戶編號";
            this.cus_id.MinimumWidth = 124;
            this.cus_id.Name = "cus_id";
            this.cus_id.ReadOnly = true;
            // 
            // cus_name
            // 
            this.cus_name.DataPropertyName = "cus_name";
            this.cus_name.FillWeight = 300F;
            this.cus_name.HeaderText = "客戶名稱";
            this.cus_name.MinimumWidth = 170;
            this.cus_name.Name = "cus_name";
            this.cus_name.ReadOnly = true;
            // 
            // cus_contact
            // 
            this.cus_contact.DataPropertyName = "cus_contact";
            this.cus_contact.FillWeight = 150F;
            this.cus_contact.HeaderText = "聯絡人";
            this.cus_contact.MinimumWidth = 100;
            this.cus_contact.Name = "cus_contact";
            this.cus_contact.ReadOnly = true;
            // 
            // cus_tel
            // 
            this.cus_tel.DataPropertyName = "cus_tel";
            this.cus_tel.FillWeight = 150F;
            this.cus_tel.HeaderText = "電話";
            this.cus_tel.MinimumWidth = 100;
            this.cus_tel.Name = "cus_tel";
            this.cus_tel.ReadOnly = true;
            // 
            // cus_yw
            // 
            this.cus_yw.DataPropertyName = "cus_yw";
            this.cus_yw.FillWeight = 150F;
            this.cus_yw.HeaderText = "業務";
            this.cus_yw.MinimumWidth = 50;
            this.cus_yw.Name = "cus_yw";
            this.cus_yw.ReadOnly = true;
            // 
            // frmCustomer_Inq_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 413);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCustomer_Inq_Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "選擇客戶";
            this.Activated += new System.EventHandler(this.frmCustomer_Inq_Customer_Activated);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboYw;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_yw;
    }
}