﻿namespace Price2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.groupBox.BackColor = System.Drawing.Color.Transparent;
            this.groupBox.Controls.Add(this.btnDeleteUser);
            this.groupBox.Controls.Add(this.dgvUser);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.btnRefresh);
            this.groupBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(11, 5);
            this.groupBox.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.groupBox.Size = new System.Drawing.Size(696, 335);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDeleteUser.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDeleteUser.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDeleteUser.Location = new System.Drawing.Point(290, 289);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(99, 33);
            this.btnDeleteUser.TabIndex = 20;
            this.btnDeleteUser.Text = "刪除使用者";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToOrderColumns = true;
            this.dgvUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUser.BackgroundColor = System.Drawing.Color.White;
            this.dgvUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.wus_computername,
            this.wus_username,
            this.wus_name,
            this.wus_using});
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.Location = new System.Drawing.Point(20, 25);
            this.dgvUser.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.RowHeadersWidth = 51;
            this.dgvUser.RowTemplate.Height = 27;
            this.dgvUser.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(656, 252);
            this.dgvUser.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(439, 289);
            this.btnClose.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 33);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRefresh.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRefresh.Location = new System.Drawing.Point(141, 289);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(99, 33);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "重新整理";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chk
            // 
            this.chk.FalseValue = "False";
            this.chk.FillWeight = 20F;
            this.chk.HeaderText = "";
            this.chk.MinimumWidth = 20;
            this.chk.Name = "chk";
            this.chk.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chk.TrueValue = "True";
            this.chk.Width = 20;
            // 
            // wus_computername
            // 
            this.wus_computername.DataPropertyName = "wus_computername";
            this.wus_computername.FillWeight = 150F;
            this.wus_computername.HeaderText = "電腦名";
            this.wus_computername.MinimumWidth = 150;
            this.wus_computername.Name = "wus_computername";
            this.wus_computername.ReadOnly = true;
            this.wus_computername.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.wus_computername.Width = 150;
            // 
            // wus_username
            // 
            this.wus_username.DataPropertyName = "wus_username";
            this.wus_username.HeaderText = "用戶名";
            this.wus_username.MinimumWidth = 100;
            this.wus_username.Name = "wus_username";
            this.wus_username.ReadOnly = true;
            // 
            // wus_name
            // 
            this.wus_name.DataPropertyName = "wus_name";
            this.wus_name.HeaderText = "姓名";
            this.wus_name.MinimumWidth = 100;
            this.wus_name.Name = "wus_name";
            this.wus_name.ReadOnly = true;
            // 
            // wus_using
            // 
            this.wus_using.DataPropertyName = "wus_using";
            this.wus_using.FillWeight = 350F;
            this.wus_using.HeaderText = "開始使用時間";
            this.wus_using.MinimumWidth = 350;
            this.wus_using.Name = "wus_using";
            this.wus_using.ReadOnly = true;
            this.wus_using.Width = 350;
            // 
            // frmUserStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(717, 339);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
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