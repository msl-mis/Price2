﻿namespace Price2
{
    partial class frmOrder_Note
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
            this.btnSelect = new System.Windows.Forms.Button();
            this.dgvData_R = new System.Windows.Forms.DataGridView();
            this.備註代碼R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNote_Manage = new System.Windows.Forms.Button();
            this.txtNote_Tmp = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.btnInq = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvData_S = new System.Windows.Forms.DataGridView();
            this.備註代碼 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.radioOut = new System.Windows.Forms.RadioButton();
            this.radioIn = new System.Windows.Forms.RadioButton();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData_S)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.radioIn);
            this.groupBox.Controls.Add(this.radioOut);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.btnSelect);
            this.groupBox.Controls.Add(this.dgvData_R);
            this.groupBox.Controls.Add(this.btnNote_Manage);
            this.groupBox.Controls.Add(this.txtNote_Tmp);
            this.groupBox.Controls.Add(this.txtNote);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.txtOrderID);
            this.groupBox.Controls.Add(this.btnInq);
            this.groupBox.Controls.Add(this.btnSave);
            this.groupBox.Controls.Add(this.btnDelete);
            this.groupBox.Controls.Add(this.dgvData_S);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.txtCustomer);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(1067, 562);
            this.groupBox.TabIndex = 9;
            this.groupBox.TabStop = false;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSelect.Location = new System.Drawing.Point(206, 304);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(84, 42);
            this.btnSelect.TabIndex = 68;
            this.btnSelect.Text = "選取";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dgvData_R
            // 
            this.dgvData_R.AllowUserToAddRows = false;
            this.dgvData_R.AllowUserToDeleteRows = false;
            this.dgvData_R.AllowUserToOrderColumns = true;
            this.dgvData_R.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData_R.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData_R.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData_R.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData_R.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData_R.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.備註代碼R});
            this.dgvData_R.EnableHeadersVisualStyles = false;
            this.dgvData_R.Location = new System.Drawing.Point(296, 142);
            this.dgvData_R.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvData_R.Name = "dgvData_R";
            this.dgvData_R.ReadOnly = true;
            this.dgvData_R.RowHeadersVisible = false;
            this.dgvData_R.RowHeadersWidth = 51;
            this.dgvData_R.RowTemplate.Height = 27;
            this.dgvData_R.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData_R.Size = new System.Drawing.Size(173, 342);
            this.dgvData_R.TabIndex = 67;
            this.dgvData_R.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_R_CellClick);
            this.dgvData_R.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvData_R_KeyDown);
            // 
            // 備註代碼R
            // 
            this.備註代碼R.HeaderText = "備註代碼";
            this.備註代碼R.MinimumWidth = 6;
            this.備註代碼R.Name = "備註代碼R";
            this.備註代碼R.ReadOnly = true;
            // 
            // btnNote_Manage
            // 
            this.btnNote_Manage.BackColor = System.Drawing.Color.Yellow;
            this.btnNote_Manage.Location = new System.Drawing.Point(21, 488);
            this.btnNote_Manage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNote_Manage.Name = "btnNote_Manage";
            this.btnNote_Manage.Size = new System.Drawing.Size(173, 42);
            this.btnNote_Manage.TabIndex = 66;
            this.btnNote_Manage.Text = "管理備註代碼";
            this.btnNote_Manage.UseVisualStyleBackColor = false;
            this.btnNote_Manage.Click += new System.EventHandler(this.btnNote_Manage_Click);
            // 
            // txtNote_Tmp
            // 
            this.txtNote_Tmp.BackColor = System.Drawing.Color.White;
            this.txtNote_Tmp.Location = new System.Drawing.Point(500, 373);
            this.txtNote_Tmp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNote_Tmp.Multiline = true;
            this.txtNote_Tmp.Name = "txtNote_Tmp";
            this.txtNote_Tmp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNote_Tmp.Size = new System.Drawing.Size(537, 156);
            this.txtNote_Tmp.TabIndex = 65;
            this.txtNote_Tmp.WordWrap = false;
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.White;
            this.txtNote.Location = new System.Drawing.Point(500, 72);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNote.Size = new System.Drawing.Size(537, 261);
            this.txtNote.TabIndex = 64;
            this.txtNote.WordWrap = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(496, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 33);
            this.label3.TabIndex = 63;
            this.label3.Text = "臨時備註：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(496, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 33);
            this.label1.TabIndex = 62;
            this.label1.Text = "備註內容：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(18, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 33);
            this.label4.TabIndex = 61;
            this.label4.Text = "訂單編號：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOrderID
            // 
            this.txtOrderID.BackColor = System.Drawing.Color.White;
            this.txtOrderID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtOrderID.Location = new System.Drawing.Point(152, 27);
            this.txtOrderID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(216, 31);
            this.txtOrderID.TabIndex = 60;
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInq.Location = new System.Drawing.Point(386, 60);
            this.btnInq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(84, 42);
            this.btnInq.TabIndex = 54;
            this.btnInq.Text = "查詢";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(206, 488);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 42);
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDelete.Location = new System.Drawing.Point(296, 488);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 42);
            this.btnDelete.TabIndex = 51;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvData_S
            // 
            this.dgvData_S.AllowUserToAddRows = false;
            this.dgvData_S.AllowUserToDeleteRows = false;
            this.dgvData_S.AllowUserToOrderColumns = true;
            this.dgvData_S.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData_S.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData_S.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData_S.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData_S.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData_S.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.備註代碼});
            this.dgvData_S.EnableHeadersVisualStyles = false;
            this.dgvData_S.Location = new System.Drawing.Point(21, 142);
            this.dgvData_S.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvData_S.Name = "dgvData_S";
            this.dgvData_S.ReadOnly = true;
            this.dgvData_S.RowHeadersVisible = false;
            this.dgvData_S.RowHeadersWidth = 51;
            this.dgvData_S.RowTemplate.Height = 27;
            this.dgvData_S.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData_S.Size = new System.Drawing.Size(173, 342);
            this.dgvData_S.TabIndex = 50;
            this.dgvData_S.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_S_CellClick);
            this.dgvData_S.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_S_CellDoubleClick);
            // 
            // 備註代碼
            // 
            this.備註代碼.HeaderText = "備註代碼";
            this.備註代碼.MinimumWidth = 6;
            this.備註代碼.Name = "備註代碼";
            this.備註代碼.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(18, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 33);
            this.label2.TabIndex = 36;
            this.label2.Text = "客戶：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomer
            // 
            this.txtCustomer.BackColor = System.Drawing.Color.White;
            this.txtCustomer.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCustomer.Location = new System.Drawing.Point(152, 65);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(216, 31);
            this.txtCustomer.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.Location = new System.Drawing.Point(386, 488);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 42);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(18, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 33);
            this.label5.TabIndex = 69;
            this.label5.Text = "類別：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioOut
            // 
            this.radioOut.AutoSize = true;
            this.radioOut.Checked = true;
            this.radioOut.Location = new System.Drawing.Point(152, 106);
            this.radioOut.Name = "radioOut";
            this.radioOut.Size = new System.Drawing.Size(70, 24);
            this.radioOut.TabIndex = 70;
            this.radioOut.TabStop = true;
            this.radioOut.Text = "國外";
            this.radioOut.UseVisualStyleBackColor = true;
            this.radioOut.CheckedChanged += new System.EventHandler(this.radioOut_CheckedChanged);
            // 
            // radioIn
            // 
            this.radioIn.AutoSize = true;
            this.radioIn.Location = new System.Drawing.Point(284, 106);
            this.radioIn.Name = "radioIn";
            this.radioIn.Size = new System.Drawing.Size(70, 24);
            this.radioIn.TabIndex = 71;
            this.radioIn.Text = "國內";
            this.radioIn.UseVisualStyleBackColor = true;
            this.radioIn.CheckedChanged += new System.EventHandler(this.radioIn_CheckedChanged);
            // 
            // frmOrder_Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Name = "frmOrder_Note";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "選取備註";
            this.Load += new System.EventHandler(this.frmOrder_Note_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData_S)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView dgvData_R;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備註代碼R;
        private System.Windows.Forms.Button btnNote_Manage;
        private System.Windows.Forms.TextBox txtNote_Tmp;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvData_S;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備註代碼;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton radioIn;
        private System.Windows.Forms.RadioButton radioOut;
        private System.Windows.Forms.Label label5;
    }
}