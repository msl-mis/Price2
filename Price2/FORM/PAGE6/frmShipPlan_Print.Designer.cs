﻿namespace Price2
{
    partial class frmShipPlan_Print
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
            this.btnOrder_Inq = new System.Windows.Forms.Button();
            this.chkBeginNo = new System.Windows.Forms.CheckBox();
            this.txtBeginNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.btnOrder_Inq);
            this.groupBox.Controls.Add(this.chkBeginNo);
            this.groupBox.Controls.Add(this.txtBeginNo);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.btnPrint);
            this.groupBox.Controls.Add(this.txtOrderID);
            this.groupBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 10F);
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(505, 204);
            this.groupBox.TabIndex = 14;
            this.groupBox.TabStop = false;
            // 
            // btnOrder_Inq
            // 
            this.btnOrder_Inq.BackColor = System.Drawing.Color.PaleGreen;
            this.btnOrder_Inq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOrder_Inq.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOrder_Inq.Location = new System.Drawing.Point(428, 44);
            this.btnOrder_Inq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrder_Inq.Name = "btnOrder_Inq";
            this.btnOrder_Inq.Size = new System.Drawing.Size(37, 30);
            this.btnOrder_Inq.TabIndex = 165;
            this.btnOrder_Inq.Text = "...";
            this.btnOrder_Inq.UseVisualStyleBackColor = false;
            this.btnOrder_Inq.Click += new System.EventHandler(this.btnOrder_Inq_Click);
            // 
            // chkBeginNo
            // 
            this.chkBeginNo.AutoSize = true;
            this.chkBeginNo.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkBeginNo.ForeColor = System.Drawing.Color.Red;
            this.chkBeginNo.Location = new System.Drawing.Point(71, 94);
            this.chkBeginNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkBeginNo.Name = "chkBeginNo";
            this.chkBeginNo.Size = new System.Drawing.Size(174, 22);
            this.chkBeginNo.TabIndex = 139;
            this.chkBeginNo.Text = "需要輸入開始箱號";
            this.chkBeginNo.UseVisualStyleBackColor = true;
            this.chkBeginNo.Visible = false;
            // 
            // txtBeginNo
            // 
            this.txtBeginNo.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBeginNo.Location = new System.Drawing.Point(271, 89);
            this.txtBeginNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBeginNo.Name = "txtBeginNo";
            this.txtBeginNo.Size = new System.Drawing.Size(151, 31);
            this.txtBeginNo.TabIndex = 138;
            this.txtBeginNo.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(25, 44);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(240, 31);
            this.label4.TabIndex = 135;
            this.label4.Text = "輸入需列印的工作單號：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(283, 148);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 31);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPrint.Location = new System.Drawing.Point(156, 148);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(71, 31);
            this.btnPrint.TabIndex = 123;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtOrderID
            // 
            this.txtOrderID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtOrderID.Location = new System.Drawing.Point(271, 44);
            this.txtOrderID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(151, 31);
            this.txtOrderID.TabIndex = 131;
            this.txtOrderID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderID_KeyDown);
            // 
            // frmShipPlan_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 204);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmShipPlan_Print";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出貨計畫列印";
            this.Activated += new System.EventHandler(this.frmShipPlan_Print_Activated);
            this.Load += new System.EventHandler(this.frmShipPlan_Print_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnOrder_Inq;
        private System.Windows.Forms.CheckBox chkBeginNo;
        private System.Windows.Forms.TextBox txtBeginNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtOrderID;
    }
}