namespace Price2
{
    partial class frmUserStatus
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
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.wus_computername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wus_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wus_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wus_using = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox.Controls.Add(this.btnDeleteUser);
            this.groupBox.Controls.Add(this.dgvUser);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.btnRefresh);
            this.groupBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(803, 450);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDeleteUser.Location = new System.Drawing.Point(345, 391);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(132, 36);
            this.btnDeleteUser.TabIndex = 20;
            this.btnDeleteUser.Text = "刪除使用者";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.BackgroundColor = System.Drawing.Color.White;
            this.dgvUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.wus_computername,
            this.wus_username,
            this.wus_name,
            this.wus_using});
            this.dgvUser.Location = new System.Drawing.Point(12, 44);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.RowHeadersWidth = 51;
            this.dgvUser.RowTemplate.Height = 27;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(776, 315);
            this.dgvUser.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnClose.Location = new System.Drawing.Point(616, 391);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 36);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRefresh.Location = new System.Drawing.Point(96, 391);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(132, 36);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "重新整理";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chk
            // 
            this.chk.FalseValue = "False";
            this.chk.HeaderText = "";
            this.chk.MinimumWidth = 6;
            this.chk.Name = "chk";
            this.chk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chk.TrueValue = "True";
            this.chk.Width = 50;
            // 
            // wus_computername
            // 
            this.wus_computername.DataPropertyName = "wus_computername";
            this.wus_computername.HeaderText = "電腦名";
            this.wus_computername.MinimumWidth = 6;
            this.wus_computername.Name = "wus_computername";
            this.wus_computername.ReadOnly = true;
            this.wus_computername.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.wus_computername.Width = 200;
            // 
            // wus_username
            // 
            this.wus_username.DataPropertyName = "wus_username";
            this.wus_username.HeaderText = "用戶名";
            this.wus_username.MinimumWidth = 6;
            this.wus_username.Name = "wus_username";
            this.wus_username.ReadOnly = true;
            this.wus_username.Width = 125;
            // 
            // wus_name
            // 
            this.wus_name.DataPropertyName = "wus_name";
            this.wus_name.HeaderText = "姓名";
            this.wus_name.MinimumWidth = 6;
            this.wus_name.Name = "wus_name";
            this.wus_name.ReadOnly = true;
            this.wus_name.Width = 125;
            // 
            // wus_using
            // 
            this.wus_using.DataPropertyName = "wus_using";
            this.wus_using.HeaderText = "開始使用時間";
            this.wus_using.MinimumWidth = 6;
            this.wus_using.Name = "wus_using";
            this.wus_using.ReadOnly = true;
            this.wus_using.Width = 250;
            // 
            // frmUserStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUserStatus";
            this.Text = "當前系統用戶狀況";
            this.Activated += new System.EventHandler(this.frmUserStatus_Activated);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn wus_computername;
        private System.Windows.Forms.DataGridViewTextBoxColumn wus_username;
        private System.Windows.Forms.DataGridViewTextBoxColumn wus_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn wus_using;
    }
}