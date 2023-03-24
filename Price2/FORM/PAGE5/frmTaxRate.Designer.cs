namespace Price2
{
    partial class frmTaxRate
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
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVN_Untaxed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVN_Tax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCN_Untaxed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCN_Tax = new System.Windows.Forms.TextBox();
            this.lblCal = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.txtVN_Untaxed);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.txtVN_Tax);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.txtCN_Untaxed);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.btnSave);
            this.groupBox.Controls.Add(this.txtCN_Tax);
            this.groupBox.Controls.Add(this.lblCal);
            this.groupBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 10F);
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(800, 450);
            this.groupBox.TabIndex = 12;
            this.groupBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(66, 188);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(591, 95);
            this.label5.TabIndex = 142;
            this.label5.Text = "更新國稅時間，約一至二小時，更新後還要等待中午或晚上12點系統自動\r\n成本更新作業執行後才算完成。請在下班時或無人使用系統狀態下才執行\r\n更新作業。";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(351, 132);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(150, 31);
            this.label3.TabIndex = 141;
            this.label3.Text = "越南 未稅價：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVN_Untaxed
            // 
            this.txtVN_Untaxed.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVN_Untaxed.Location = new System.Drawing.Point(507, 132);
            this.txtVN_Untaxed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVN_Untaxed.Name = "txtVN_Untaxed";
            this.txtVN_Untaxed.Size = new System.Drawing.Size(150, 29);
            this.txtVN_Untaxed.TabIndex = 140;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(39, 132);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(150, 31);
            this.label2.TabIndex = 139;
            this.label2.Text = "越南 稅價：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVN_Tax
            // 
            this.txtVN_Tax.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVN_Tax.Location = new System.Drawing.Point(195, 132);
            this.txtVN_Tax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVN_Tax.Name = "txtVN_Tax";
            this.txtVN_Tax.Size = new System.Drawing.Size(150, 29);
            this.txtVN_Tax.TabIndex = 138;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(351, 82);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(150, 31);
            this.label1.TabIndex = 137;
            this.label1.Text = "中國 未稅價：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCN_Untaxed
            // 
            this.txtCN_Untaxed.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCN_Untaxed.Location = new System.Drawing.Point(507, 82);
            this.txtCN_Untaxed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCN_Untaxed.Name = "txtCN_Untaxed";
            this.txtCN_Untaxed.Size = new System.Drawing.Size(150, 29);
            this.txtCN_Untaxed.TabIndex = 136;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(39, 82);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(150, 31);
            this.label4.TabIndex = 135;
            this.label4.Text = "中國 稅價：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(418, 306);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 28);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSave.Location = new System.Drawing.Point(243, 306);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(67, 28);
            this.btnSave.TabIndex = 123;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCN_Tax
            // 
            this.txtCN_Tax.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtCN_Tax.Location = new System.Drawing.Point(195, 82);
            this.txtCN_Tax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCN_Tax.Name = "txtCN_Tax";
            this.txtCN_Tax.Size = new System.Drawing.Size(150, 29);
            this.txtCN_Tax.TabIndex = 131;
            // 
            // lblCal
            // 
            this.lblCal.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCal.ForeColor = System.Drawing.Color.Blue;
            this.lblCal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCal.Location = new System.Drawing.Point(468, 56);
            this.lblCal.Name = "lblCal";
            this.lblCal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCal.Size = new System.Drawing.Size(232, 31);
            this.lblCal.TabIndex = 130;
            this.lblCal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmTaxRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Name = "frmTaxRate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "國稅設定";
            this.Load += new System.EventHandler(this.frmTaxRate_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVN_Untaxed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVN_Tax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCN_Untaxed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCN_Tax;
        private System.Windows.Forms.Label lblCal;
    }
}