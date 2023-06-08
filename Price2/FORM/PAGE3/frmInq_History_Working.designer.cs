namespace Price2
{
    partial class frmInq_History_Working
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
            this.label17 = new System.Windows.Forms.Label();
            this.txtDate_E = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDate_S = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInq = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.更改日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.加工費USD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.加工費RMB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.修改人員 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.label17);
            this.groupBox.Controls.Add(this.txtDate_E);
            this.groupBox.Controls.Add(this.label13);
            this.groupBox.Controls.Add(this.txtDate_S);
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.btnDelete);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.dgvData);
            this.groupBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox.Size = new System.Drawing.Size(600, 360);
            this.groupBox.TabIndex = 9;
            this.groupBox.TabStop = false;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(227, 33);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label17.Size = new System.Drawing.Size(27, 25);
            this.label17.TabIndex = 127;
            this.label17.Text = "至";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDate_E
            // 
            this.txtDate_E.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDate_E.Location = new System.Drawing.Point(258, 33);
            this.txtDate_E.Margin = new System.Windows.Forms.Padding(2);
            this.txtDate_E.Name = "txtDate_E";
            this.txtDate_E.Size = new System.Drawing.Size(98, 25);
            this.txtDate_E.TabIndex = 126;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(30, 33);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(90, 25);
            this.label13.TabIndex = 125;
            this.label13.Text = "更改日期：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDate_S
            // 
            this.txtDate_S.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDate_S.Location = new System.Drawing.Point(125, 33);
            this.txtDate_S.Margin = new System.Windows.Forms.Padding(2);
            this.txtDate_S.Name = "txtDate_S";
            this.txtDate_S.Size = new System.Drawing.Size(98, 25);
            this.txtDate_S.TabIndex = 124;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(397, 45);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(53, 25);
            this.btnClear.TabIndex = 123;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(454, 19);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(53, 25);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelete.Location = new System.Drawing.Point(454, 45);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(53, 25);
            this.btnDelete.TabIndex = 97;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInq.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInq.Location = new System.Drawing.Point(397, 19);
            this.btnInq.Margin = new System.Windows.Forms.Padding(2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(53, 25);
            this.btnInq.TabIndex = 93;
            this.btnInq.Text = "查詢";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.更改日期,
            this.加工費USD,
            this.加工費RMB,
            this.修改人員});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(11, 82);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.RowTemplate.Height = 21;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(578, 247);
            this.dgvData.TabIndex = 80;
            // 
            // 更改日期
            // 
            this.更改日期.DataPropertyName = "更改日期";
            this.更改日期.FillWeight = 232F;
            this.更改日期.HeaderText = "更改日期";
            this.更改日期.MinimumWidth = 150;
            this.更改日期.Name = "更改日期";
            this.更改日期.ReadOnly = true;
            // 
            // 加工費USD
            // 
            this.加工費USD.DataPropertyName = "加工費USD";
            this.加工費USD.FillWeight = 150F;
            this.加工費USD.HeaderText = "加工費USD";
            this.加工費USD.MinimumWidth = 150;
            this.加工費USD.Name = "加工費USD";
            this.加工費USD.ReadOnly = true;
            // 
            // 加工費RMB
            // 
            this.加工費RMB.DataPropertyName = "加工費RMB";
            this.加工費RMB.FillWeight = 150F;
            this.加工費RMB.HeaderText = "加工費RMB";
            this.加工費RMB.MinimumWidth = 150;
            this.加工費RMB.Name = "加工費RMB";
            this.加工費RMB.ReadOnly = true;
            // 
            // 修改人員
            // 
            this.修改人員.DataPropertyName = "修改人員";
            this.修改人員.FillWeight = 150F;
            this.修改人員.HeaderText = "修改人員";
            this.修改人員.MinimumWidth = 150;
            this.修改人員.Name = "修改人員";
            this.修改人員.ReadOnly = true;
            // 
            // frmInq_History_Working
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmInq_History_Working";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查價史_加工費";
            this.Load += new System.EventHandler(this.frmInq_History_Working_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDate_E;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDate_S;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn 更改日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 加工費USD;
        private System.Windows.Forms.DataGridViewTextBoxColumn 加工費RMB;
        private System.Windows.Forms.DataGridViewTextBoxColumn 修改人員;
    }
}