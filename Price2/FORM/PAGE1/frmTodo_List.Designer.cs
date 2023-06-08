namespace Price2
{
    partial class frmTodo_List
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkT = new System.Windows.Forms.CheckBox();
            this.chkF = new System.Windows.Forms.CheckBox();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateE = new System.Windows.Forms.DateTimePicker();
            this.dtpDateS = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnInq = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkOK = new System.Windows.Forms.CheckBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.uuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finish_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.groupBox3);
            this.groupBox.Controls.Add(this.groupBox2);
            this.groupBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 10F);
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox.Size = new System.Drawing.Size(646, 482);
            this.groupBox.TabIndex = 10;
            this.groupBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox3.Controls.Add(this.chkT);
            this.groupBox3.Controls.Add(this.chkF);
            this.groupBox3.Controls.Add(this.cboUser);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtpDateE);
            this.groupBox3.Controls.Add(this.dtpDateS);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.dgvData);
            this.groupBox3.Controls.Add(this.btnInq);
            this.groupBox3.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(0, 240);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(645, 240);
            this.groupBox3.TabIndex = 130;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "資料查詢";
            // 
            // chkT
            // 
            this.chkT.AutoSize = true;
            this.chkT.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkT.Location = new System.Drawing.Point(500, 18);
            this.chkT.Margin = new System.Windows.Forms.Padding(2);
            this.chkT.Name = "chkT";
            this.chkT.Size = new System.Drawing.Size(65, 17);
            this.chkT.TabIndex = 233;
            this.chkT.Text = "已完成";
            this.chkT.UseVisualStyleBackColor = true;
            this.chkT.CheckedChanged += new System.EventHandler(this.chkT_CheckedChanged);
            // 
            // chkF
            // 
            this.chkF.AutoSize = true;
            this.chkF.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkF.Location = new System.Drawing.Point(500, 40);
            this.chkF.Margin = new System.Windows.Forms.Padding(2);
            this.chkF.Name = "chkF";
            this.chkF.Size = new System.Drawing.Size(65, 17);
            this.chkF.TabIndex = 232;
            this.chkF.Text = "未完成";
            this.chkF.UseVisualStyleBackColor = true;
            this.chkF.CheckedChanged += new System.EventHandler(this.chkF_CheckedChanged);
            // 
            // cboUser
            // 
            this.cboUser.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(82, 23);
            this.cboUser.Margin = new System.Windows.Forms.Padding(2);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(100, 23);
            this.cboUser.TabIndex = 231;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(4, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 27);
            this.label2.TabIndex = 230;
            this.label2.Text = "使用者：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDateE
            // 
            this.dtpDateE.CustomFormat = "yyyy/MM/dd";
            this.dtpDateE.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpDateE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateE.Location = new System.Drawing.Point(400, 23);
            this.dtpDateE.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDateE.Name = "dtpDateE";
            this.dtpDateE.ShowUpDown = true;
            this.dtpDateE.Size = new System.Drawing.Size(88, 25);
            this.dtpDateE.TabIndex = 229;
            // 
            // dtpDateS
            // 
            this.dtpDateS.CustomFormat = "yyyy/MM/dd";
            this.dtpDateS.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpDateS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateS.Location = new System.Drawing.Point(278, 23);
            this.dtpDateS.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDateS.Name = "dtpDateS";
            this.dtpDateS.ShowUpDown = true;
            this.dtpDateS.Size = new System.Drawing.Size(88, 25);
            this.dtpDateS.TabIndex = 228;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(369, 21);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label17.Size = new System.Drawing.Size(27, 25);
            this.label17.TabIndex = 227;
            this.label17.Text = "至";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(186, 21);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(88, 25);
            this.label13.TabIndex = 226;
            this.label13.Text = "日期區間：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeight = 25;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uuid,
            this.user_name,
            this.finish_date,
            this.item,
            this.chk});
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(15, 66);
            this.dgvData.Margin = new System.Windows.Forms.Padding(2);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 25;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(609, 163);
            this.dgvData.TabIndex = 167;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnInq.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnInq.Location = new System.Drawing.Point(574, 22);
            this.btnInq.Margin = new System.Windows.Forms.Padding(2);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(50, 28);
            this.btnInq.TabIndex = 162;
            this.btnInq.Text = "查詢";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.chkOK);
            this.groupBox2.Controls.Add(this.txtItem);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.dtpDate);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.btnModify);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(645, 240);
            this.groupBox2.TabIndex = 129;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "資料建立";
            // 
            // chkOK
            // 
            this.chkOK.AutoSize = true;
            this.chkOK.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkOK.Location = new System.Drawing.Point(195, 29);
            this.chkOK.Margin = new System.Windows.Forms.Padding(2);
            this.chkOK.Name = "chkOK";
            this.chkOK.Size = new System.Drawing.Size(52, 17);
            this.chkOK.TabIndex = 223;
            this.chkOK.Text = "完成";
            this.chkOK.UseVisualStyleBackColor = true;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(92, 54);
            this.txtItem.Margin = new System.Windows.Forms.Padding(2);
            this.txtItem.Multiline = true;
            this.txtItem.Name = "txtItem";
            this.txtItem.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtItem.Size = new System.Drawing.Size(457, 165);
            this.txtItem.TabIndex = 163;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 27);
            this.label1.TabIndex = 162;
            this.label1.Text = "日期：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAdd.Location = new System.Drawing.Point(574, 26);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 28);
            this.btnAdd.TabIndex = 152;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy/MM/dd";
            this.dtpDate.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(92, 26);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.ShowUpDown = true;
            this.dtpDate.Size = new System.Drawing.Size(88, 25);
            this.dtpDate.TabIndex = 161;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDelete.Location = new System.Drawing.Point(574, 106);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 28);
            this.btnDelete.TabIndex = 141;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(4, 50);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 27);
            this.label22.TabIndex = 155;
            this.label22.Text = "代辦事項：";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnModify.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnModify.Location = new System.Drawing.Point(574, 66);
            this.btnModify.Margin = new System.Windows.Forms.Padding(2);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(50, 28);
            this.btnModify.TabIndex = 142;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(574, 146);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 28);
            this.btnClose.TabIndex = 153;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // uuid
            // 
            this.uuid.DataPropertyName = "uuid";
            this.uuid.FillWeight = 125F;
            this.uuid.HeaderText = "uuid";
            this.uuid.MinimumWidth = 125;
            this.uuid.Name = "uuid";
            this.uuid.ReadOnly = true;
            this.uuid.Visible = false;
            // 
            // user_name
            // 
            this.user_name.DataPropertyName = "user_name";
            this.user_name.HeaderText = "使用者";
            this.user_name.MinimumWidth = 100;
            this.user_name.Name = "user_name";
            this.user_name.ReadOnly = true;
            // 
            // finish_date
            // 
            this.finish_date.DataPropertyName = "finish_date";
            this.finish_date.FillWeight = 125F;
            this.finish_date.HeaderText = "日期";
            this.finish_date.MinimumWidth = 100;
            this.finish_date.Name = "finish_date";
            this.finish_date.ReadOnly = true;
            this.finish_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // item
            // 
            this.item.DataPropertyName = "item";
            this.item.FillWeight = 400F;
            this.item.HeaderText = "代辦事項";
            this.item.MinimumWidth = 280;
            this.item.Name = "item";
            this.item.ReadOnly = true;
            this.item.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chk
            // 
            this.chk.DataPropertyName = "chk";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.chk.DefaultCellStyle = dataGridViewCellStyle2;
            this.chk.HeaderText = "是否完成";
            this.chk.MinimumWidth = 100;
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            this.chk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // frmTodo_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 482);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTodo_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "待辦事項";
            this.Activated += new System.EventHandler(this.frmTodo_List_Activated);
            this.Load += new System.EventHandler(this.frmTodo_List_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkT;
        private System.Windows.Forms.CheckBox chkF;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateE;
        private System.Windows.Forms.DateTimePicker dtpDateS;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkOK;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn uuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn finish_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn chk;
    }
}