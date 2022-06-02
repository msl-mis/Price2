namespace Price2
{
    partial class frmCustomer_Inq_Tel
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInq = new System.Windows.Forms.Button();
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
            this.groupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.txtTel);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(875, 519);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cus_id,
            this.cus_name,
            this.cus_contact,
            this.cus_tel,
            this.cus_yw});
            this.dgvData.Location = new System.Drawing.Point(22, 77);
            this.dgvData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(831, 416);
            this.dgvData.TabIndex = 50;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(23, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 34);
            this.label2.TabIndex = 36;
            this.label2.Text = "搜尋電話：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtTel.Location = new System.Drawing.Point(144, 27);
            this.txtTel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(200, 34);
            this.txtTel.TabIndex = 3;
            this.txtTel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTel_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(769, 27);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 42);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInq.Location = new System.Drawing.Point(589, 27);
            this.btnInq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(84, 42);
            this.btnInq.TabIndex = 14;
            this.btnInq.Text = "搜尋";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
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
            // cus_yw
            // 
            this.cus_yw.DataPropertyName = "cus_yw";
            this.cus_yw.HeaderText = "業務";
            this.cus_yw.MinimumWidth = 6;
            this.cus_yw.Name = "cus_yw";
            this.cus_yw.ReadOnly = true;
            this.cus_yw.Width = 125;
            // 
            // frmCustomer_Inq_Tel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(875, 516);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCustomer_Inq_Tel";
            this.ShowInTaskbar = false;
            this.Text = "按電話選擇客戶";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cus_yw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInq;
    }
}