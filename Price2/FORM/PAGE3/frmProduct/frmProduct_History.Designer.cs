namespace Price2
{
    partial class frmProduct_History
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDate_E = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate_S = new System.Windows.Forms.TextBox();
            this.btnInq = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.更改日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.幣別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.單價 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.計算式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.臺幣換算價 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.廠商 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.編號 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.備註 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.lblCount);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.txtDate_E);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.txtDate_S);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Controls.Add(this.btnDelete);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.txtID);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox.Size = new System.Drawing.Size(580, 493);
            this.groupBox.TabIndex = 5;
            this.groupBox.TabStop = false;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCount.ForeColor = System.Drawing.Color.Blue;
            this.lblCount.Location = new System.Drawing.Point(439, 457);
            this.lblCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(126, 27);
            this.lblCount.TabIndex = 59;
            this.lblCount.Text = "共：";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(211, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 27);
            this.label3.TabIndex = 58;
            this.label3.Text = "至";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate_E
            // 
            this.txtDate_E.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDate_E.Location = new System.Drawing.Point(242, 53);
            this.txtDate_E.Margin = new System.Windows.Forms.Padding(2);
            this.txtDate_E.Name = "txtDate_E";
            this.txtDate_E.Size = new System.Drawing.Size(103, 27);
            this.txtDate_E.TabIndex = 57;
            this.txtDate_E.Click += new System.EventHandler(this.txtDate_E_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 27);
            this.label1.TabIndex = 56;
            this.label1.Text = "更改日期：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate_S
            // 
            this.txtDate_S.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDate_S.Location = new System.Drawing.Point(107, 53);
            this.txtDate_S.Margin = new System.Windows.Forms.Padding(2);
            this.txtDate_S.Name = "txtDate_S";
            this.txtDate_S.Size = new System.Drawing.Size(103, 27);
            this.txtDate_S.TabIndex = 55;
            this.txtDate_S.Click += new System.EventHandler(this.txtDate_S_Click);
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInq.Location = new System.Drawing.Point(362, 22);
            this.btnInq.Margin = new System.Windows.Forms.Padding(2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(63, 31);
            this.btnInq.TabIndex = 54;
            this.btnInq.Text = "查詢";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Location = new System.Drawing.Point(439, 22);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(63, 31);
            this.btnClear.TabIndex = 52;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(362, 54);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 31);
            this.btnDelete.TabIndex = 51;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.更改日期,
            this.幣別,
            this.單價,
            this.計算式,
            this.臺幣換算價,
            this.廠商,
            this.用戶,
            this.編號,
            this.備註});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(29, 89);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(536, 366);
            this.dgvData.TabIndex = 50;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            this.dgvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvData_KeyDown);
            // 
            // 更改日期
            // 
            this.更改日期.DataPropertyName = "更改日期";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.更改日期.DefaultCellStyle = dataGridViewCellStyle2;
            this.更改日期.FillWeight = 150F;
            this.更改日期.HeaderText = "更改日期";
            this.更改日期.MinimumWidth = 30;
            this.更改日期.Name = "更改日期";
            this.更改日期.ReadOnly = true;
            this.更改日期.Width = 130;
            // 
            // 幣別
            // 
            this.幣別.DataPropertyName = "幣別";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.幣別.DefaultCellStyle = dataGridViewCellStyle3;
            this.幣別.FillWeight = 80F;
            this.幣別.HeaderText = "幣別";
            this.幣別.MinimumWidth = 6;
            this.幣別.Name = "幣別";
            this.幣別.ReadOnly = true;
            this.幣別.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.幣別.Width = 80;
            // 
            // 單價
            // 
            this.單價.DataPropertyName = "單價";
            this.單價.HeaderText = "單價";
            this.單價.MinimumWidth = 6;
            this.單價.Name = "單價";
            this.單價.ReadOnly = true;
            this.單價.Width = 80;
            // 
            // 計算式
            // 
            this.計算式.DataPropertyName = "計算式";
            this.計算式.HeaderText = "計算式";
            this.計算式.MinimumWidth = 6;
            this.計算式.Name = "計算式";
            this.計算式.ReadOnly = true;
            this.計算式.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.計算式.Width = 150;
            // 
            // 臺幣換算價
            // 
            this.臺幣換算價.DataPropertyName = "臺幣換算價";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.臺幣換算價.DefaultCellStyle = dataGridViewCellStyle4;
            this.臺幣換算價.FillWeight = 150F;
            this.臺幣換算價.HeaderText = "臺幣換算價";
            this.臺幣換算價.MinimumWidth = 6;
            this.臺幣換算價.Name = "臺幣換算價";
            this.臺幣換算價.ReadOnly = true;
            this.臺幣換算價.Width = 120;
            // 
            // 廠商
            // 
            this.廠商.DataPropertyName = "廠商";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.廠商.DefaultCellStyle = dataGridViewCellStyle5;
            this.廠商.FillWeight = 80F;
            this.廠商.HeaderText = "廠商";
            this.廠商.MinimumWidth = 6;
            this.廠商.Name = "廠商";
            this.廠商.ReadOnly = true;
            this.廠商.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.廠商.Width = 80;
            // 
            // 用戶
            // 
            this.用戶.DataPropertyName = "用戶";
            this.用戶.FillWeight = 80F;
            this.用戶.HeaderText = "用戶";
            this.用戶.MinimumWidth = 6;
            this.用戶.Name = "用戶";
            this.用戶.ReadOnly = true;
            this.用戶.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.用戶.Width = 80;
            // 
            // 編號
            // 
            this.編號.DataPropertyName = "編號";
            this.編號.HeaderText = "編號";
            this.編號.MinimumWidth = 6;
            this.編號.Name = "編號";
            this.編號.ReadOnly = true;
            this.編號.Visible = false;
            this.編號.Width = 125;
            // 
            // 備註
            // 
            this.備註.DataPropertyName = "備註";
            this.備註.FillWeight = 500F;
            this.備註.HeaderText = "備註";
            this.備註.MinimumWidth = 6;
            this.備註.Name = "備註";
            this.備註.ReadOnly = true;
            this.備註.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.備註.Width = 200;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(26, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 27);
            this.label2.TabIndex = 36;
            this.label2.Text = "材料名：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtID.Location = new System.Drawing.Point(107, 22);
            this.txtID.Margin = new System.Windows.Forms.Padding(2);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(238, 27);
            this.txtID.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(439, 54);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 31);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmProduct_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 493);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmProduct_History";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "材料價史";
            this.Load += new System.EventHandler(this.frmProduct_History_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDate_E;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDate_S;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn 更改日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 幣別;
        private System.Windows.Forms.DataGridViewTextBoxColumn 單價;
        private System.Windows.Forms.DataGridViewTextBoxColumn 計算式;
        private System.Windows.Forms.DataGridViewTextBoxColumn 臺幣換算價;
        private System.Windows.Forms.DataGridViewTextBoxColumn 廠商;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用戶;
        private System.Windows.Forms.DataGridViewTextBoxColumn 編號;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備註;
    }
}