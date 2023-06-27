namespace Price2
{
    partial class frmBOMPrice_Special
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblStrLength = new System.Windows.Forms.Label();
            this.radioSpecial = new System.Windows.Forms.RadioButton();
            this.radioNote = new System.Windows.Forms.RadioButton();
            this.lblTime = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTbPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPerPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVendorID = new System.Windows.Forms.TextBox();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblVendorID = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.btnDelete);
            this.groupBox.Controls.Add(this.lblStrLength);
            this.groupBox.Controls.Add(this.radioSpecial);
            this.groupBox.Controls.Add(this.radioNote);
            this.groupBox.Controls.Add(this.lblTime);
            this.groupBox.Controls.Add(this.label9);
            this.groupBox.Controls.Add(this.lblTbPrice);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.txtPerPrice);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.txtQty);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.txtVendorID);
            this.groupBox.Controls.Add(this.lblVendorName);
            this.groupBox.Controls.Add(this.cboCurrency);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.txtVendorName);
            this.groupBox.Controls.Add(this.txtID);
            this.groupBox.Controls.Add(this.label6);
            this.groupBox.Controls.Add(this.lblVendorID);
            this.groupBox.Controls.Add(this.btnGet);
            this.groupBox.Controls.Add(this.btnClose);
            this.groupBox.Controls.Add(this.btnClear);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox.Size = new System.Drawing.Size(481, 244);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "特選材料";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(183, 192);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 34);
            this.btnDelete.TabIndex = 146;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblStrLength
            // 
            this.lblStrLength.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblStrLength.ForeColor = System.Drawing.Color.Red;
            this.lblStrLength.Location = new System.Drawing.Point(285, 62);
            this.lblStrLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStrLength.Name = "lblStrLength";
            this.lblStrLength.Size = new System.Drawing.Size(40, 26);
            this.lblStrLength.TabIndex = 145;
            this.lblStrLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioSpecial
            // 
            this.radioSpecial.AutoSize = true;
            this.radioSpecial.Checked = true;
            this.radioSpecial.Location = new System.Drawing.Point(54, 24);
            this.radioSpecial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioSpecial.Name = "radioSpecial";
            this.radioSpecial.Size = new System.Drawing.Size(89, 20);
            this.radioSpecial.TabIndex = 141;
            this.radioSpecial.TabStop = true;
            this.radioSpecial.Text = "特選材料";
            this.radioSpecial.UseVisualStyleBackColor = true;
            this.radioSpecial.CheckedChanged += new System.EventHandler(this.radioSpecial_CheckedChanged);
            // 
            // radioNote
            // 
            this.radioNote.AutoSize = true;
            this.radioNote.Location = new System.Drawing.Point(210, 24);
            this.radioNote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioNote.Name = "radioNote";
            this.radioNote.Size = new System.Drawing.Size(71, 20);
            this.radioNote.TabIndex = 140;
            this.radioNote.Text = "備註 R";
            this.radioNote.UseVisualStyleBackColor = true;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTime.Location = new System.Drawing.Point(81, 200);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(98, 26);
            this.lblTime.TabIndex = 139;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(11, 200);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 26);
            this.label9.TabIndex = 138;
            this.label9.Text = "儲存時間：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTbPrice
            // 
            this.lblTbPrice.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTbPrice.Location = new System.Drawing.Point(287, 102);
            this.lblTbPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTbPrice.Name = "lblTbPrice";
            this.lblTbPrice.Size = new System.Drawing.Size(123, 26);
            this.lblTbPrice.TabIndex = 137;
            this.lblTbPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(159, 102);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 26);
            this.label5.TabIndex = 136;
            this.label5.Text = "台幣換算單價：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPerPrice
            // 
            this.txtPerPrice.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtPerPrice.Location = new System.Drawing.Point(374, 62);
            this.txtPerPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtPerPrice.Name = "txtPerPrice";
            this.txtPerPrice.Size = new System.Drawing.Size(86, 27);
            this.txtPerPrice.TabIndex = 135;
            this.txtPerPrice.DoubleClick += new System.EventHandler(this.txtPerPrice_DoubleClick);
            this.txtPerPrice.Enter += new System.EventHandler(this.txtPerPrice_Enter);
            this.txtPerPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPerPrice_KeyDown);
            this.txtPerPrice.Leave += new System.EventHandler(this.txtPerPrice_Leave);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(328, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 26);
            this.label4.TabIndex = 134;
            this.label4.Text = "單價";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtQty.Location = new System.Drawing.Point(54, 145);
            this.txtQty.Margin = new System.Windows.Forms.Padding(2);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(86, 27);
            this.txtQty.TabIndex = 133;
            this.txtQty.Enter += new System.EventHandler(this.txtQty_Enter);
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(9, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 26);
            this.label2.TabIndex = 132;
            this.label2.Text = "數量";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVendorID
            // 
            this.txtVendorID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVendorID.Location = new System.Drawing.Point(374, 145);
            this.txtVendorID.Margin = new System.Windows.Forms.Padding(2);
            this.txtVendorID.Name = "txtVendorID";
            this.txtVendorID.Size = new System.Drawing.Size(86, 27);
            this.txtVendorID.TabIndex = 131;
            this.txtVendorID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVendorID_KeyDown);
            this.txtVendorID.Leave += new System.EventHandler(this.txtVendorID_Leave);
            // 
            // lblVendorName
            // 
            this.lblVendorName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblVendorName.Location = new System.Drawing.Point(328, 145);
            this.lblVendorName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(40, 26);
            this.lblVendorName.TabIndex = 130;
            this.lblVendorName.Text = "廠號";
            this.lblVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCurrency
            // 
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.ItemHeight = 16;
            this.cboCurrency.Items.AddRange(new object[] {
            "人民幣",
            "美金",
            "港幣",
            "台幣",
            "英鎊",
            "越南盾",
            "歐元"});
            this.cboCurrency.Location = new System.Drawing.Point(54, 104);
            this.cboCurrency.Margin = new System.Windows.Forms.Padding(2);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(86, 24);
            this.cboCurrency.TabIndex = 129;
            this.cboCurrency.Text = "臺幣";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(9, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 26);
            this.label3.TabIndex = 128;
            this.label3.Text = "幣種";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVendorName
            // 
            this.txtVendorName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtVendorName.Location = new System.Drawing.Point(209, 145);
            this.txtVendorName.Margin = new System.Windows.Forms.Padding(2);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(86, 27);
            this.txtVendorName.TabIndex = 127;
            this.txtVendorName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVendorName_KeyDown);
            this.txtVendorName.Leave += new System.EventHandler(this.txtVendorName_Leave);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtID.Location = new System.Drawing.Point(54, 61);
            this.txtID.Margin = new System.Windows.Forms.Padding(2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(230, 27);
            this.txtID.TabIndex = 124;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            this.txtID.Leave += new System.EventHandler(this.txtID_Leave);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(9, 61);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 26);
            this.label6.TabIndex = 125;
            this.label6.Text = "名稱";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVendorID
            // 
            this.lblVendorID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblVendorID.Location = new System.Drawing.Point(164, 145);
            this.lblVendorID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVendorID.Name = "lblVendorID";
            this.lblVendorID.Size = new System.Drawing.Size(40, 26);
            this.lblVendorID.TabIndex = 126;
            this.lblVendorID.Text = "廠商";
            this.lblVendorID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGet
            // 
            this.btnGet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGet.Location = new System.Drawing.Point(325, 192);
            this.btnGet.Margin = new System.Windows.Forms.Padding(2);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(63, 34);
            this.btnGet.TabIndex = 19;
            this.btnGet.Text = "選取";
            this.btnGet.UseVisualStyleBackColor = false;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Location = new System.Drawing.Point(396, 192);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 34);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "結束";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Location = new System.Drawing.Point(254, 192);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(63, 34);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmBOMPrice_Special
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 244);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmBOMPrice_Special";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "選取其他料";
            this.Load += new System.EventHandler(this.frmBOMPrice_Special_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblVendorID;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPerPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVendorID;
        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.RadioButton radioSpecial;
        private System.Windows.Forms.RadioButton radioNote;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTbPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStrLength;
        private System.Windows.Forms.Button btnDelete;
    }
}