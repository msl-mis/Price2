namespace Price2
{
    partial class frmBOMPrice_Copy_Material
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
            this.lblLength = new System.Windows.Forms.Label();
            this.lblOldName = new System.Windows.Forms.Label();
            this.lblOldName_ = new System.Windows.Forms.Label();
            this.radioQuotation_Material = new System.Windows.Forms.RadioButton();
            this.radioMaterial = new System.Windows.Forms.RadioButton();
            this.lblNewName_ = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblNewID_ = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblOldID = new System.Windows.Forms.Label();
            this.lblOldID_ = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.lblLength);
            this.groupBox.Controls.Add(this.lblOldName);
            this.groupBox.Controls.Add(this.lblOldName_);
            this.groupBox.Controls.Add(this.radioQuotation_Material);
            this.groupBox.Controls.Add(this.radioMaterial);
            this.groupBox.Controls.Add(this.lblNewName_);
            this.groupBox.Controls.Add(this.txtName);
            this.groupBox.Controls.Add(this.lblNewID_);
            this.groupBox.Controls.Add(this.btnOK);
            this.groupBox.Controls.Add(this.lblOldID);
            this.groupBox.Controls.Add(this.lblOldID_);
            this.groupBox.Controls.Add(this.txtID);
            this.groupBox.Controls.Add(this.btnCancel);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(614, 302);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            // 
            // lblLength
            // 
            this.lblLength.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblLength.ForeColor = System.Drawing.Color.Red;
            this.lblLength.Location = new System.Drawing.Point(555, 52);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(45, 40);
            this.lblLength.TabIndex = 155;
            this.lblLength.Text = "0";
            this.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOldName
            // 
            this.lblOldName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOldName.ForeColor = System.Drawing.Color.Blue;
            this.lblOldName.Location = new System.Drawing.Point(190, 180);
            this.lblOldName.Name = "lblOldName";
            this.lblOldName.Size = new System.Drawing.Size(360, 40);
            this.lblOldName.TabIndex = 154;
            this.lblOldName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOldName_
            // 
            this.lblOldName_.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOldName_.ForeColor = System.Drawing.Color.Blue;
            this.lblOldName_.Location = new System.Drawing.Point(57, 180);
            this.lblOldName_.Name = "lblOldName_";
            this.lblOldName_.Size = new System.Drawing.Size(128, 40);
            this.lblOldName_.TabIndex = 153;
            this.lblOldName_.Text = "原品號：";
            this.lblOldName_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioQuotation_Material
            // 
            this.radioQuotation_Material.AutoSize = true;
            this.radioQuotation_Material.ForeColor = System.Drawing.Color.Red;
            this.radioQuotation_Material.Location = new System.Drawing.Point(291, 18);
            this.radioQuotation_Material.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioQuotation_Material.Name = "radioQuotation_Material";
            this.radioQuotation_Material.Size = new System.Drawing.Size(251, 28);
            this.radioQuotation_Material.TabIndex = 152;
            this.radioQuotation_Material.Text = "複製報價單材料組成";
            this.radioQuotation_Material.UseVisualStyleBackColor = true;
            this.radioQuotation_Material.CheckedChanged += new System.EventHandler(this.radioQuotation_Material_CheckedChanged);
            // 
            // radioMaterial
            // 
            this.radioMaterial.AutoSize = true;
            this.radioMaterial.Checked = true;
            this.radioMaterial.ForeColor = System.Drawing.Color.Red;
            this.radioMaterial.Location = new System.Drawing.Point(66, 18);
            this.radioMaterial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioMaterial.Name = "radioMaterial";
            this.radioMaterial.Size = new System.Drawing.Size(155, 28);
            this.radioMaterial.TabIndex = 151;
            this.radioMaterial.TabStop = true;
            this.radioMaterial.Text = "複製材料單";
            this.radioMaterial.UseVisualStyleBackColor = true;
            this.radioMaterial.CheckedChanged += new System.EventHandler(this.radioMaterial_CheckedChanged);
            // 
            // lblNewName_
            // 
            this.lblNewName_.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNewName_.ForeColor = System.Drawing.Color.Black;
            this.lblNewName_.Location = new System.Drawing.Point(48, 96);
            this.lblNewName_.Name = "lblNewName_";
            this.lblNewName_.Size = new System.Drawing.Size(136, 40);
            this.lblNewName_.TabIndex = 150;
            this.lblNewName_.Text = "新品號：";
            this.lblNewName_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtName.Location = new System.Drawing.Point(190, 96);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(358, 36);
            this.txtName.TabIndex = 149;
            // 
            // lblNewID_
            // 
            this.lblNewID_.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblNewID_.ForeColor = System.Drawing.Color.Black;
            this.lblNewID_.Location = new System.Drawing.Point(48, 52);
            this.lblNewID_.Name = "lblNewID_";
            this.lblNewID_.Size = new System.Drawing.Size(136, 40);
            this.lblNewID_.TabIndex = 148;
            this.lblNewID_.Text = "新材料名：";
            this.lblNewID_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOK.Location = new System.Drawing.Point(90, 224);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 51);
            this.btnOK.TabIndex = 146;
            this.btnOK.Text = "確定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblOldID
            // 
            this.lblOldID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOldID.ForeColor = System.Drawing.Color.Blue;
            this.lblOldID.Location = new System.Drawing.Point(190, 140);
            this.lblOldID.Name = "lblOldID";
            this.lblOldID.Size = new System.Drawing.Size(360, 40);
            this.lblOldID.TabIndex = 136;
            this.lblOldID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOldID_
            // 
            this.lblOldID_.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblOldID_.ForeColor = System.Drawing.Color.Blue;
            this.lblOldID_.Location = new System.Drawing.Point(52, 140);
            this.lblOldID_.Name = "lblOldID_";
            this.lblOldID_.Size = new System.Drawing.Size(132, 40);
            this.lblOldID_.TabIndex = 128;
            this.lblOldID_.Text = "原材料名：";
            this.lblOldID_.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtID.Location = new System.Drawing.Point(190, 52);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(358, 36);
            this.txtID.TabIndex = 124;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCancel.Location = new System.Drawing.Point(404, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 51);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmBOMPrice_Copy_Material
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 302);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmBOMPrice_Copy_Material";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "複製";
            this.Load += new System.EventHandler(this.frmBOMPrice_Copy_Material_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblOldName;
        private System.Windows.Forms.Label lblOldName_;
        private System.Windows.Forms.RadioButton radioQuotation_Material;
        private System.Windows.Forms.RadioButton radioMaterial;
        private System.Windows.Forms.Label lblNewName_;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblNewID_;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblOldID;
        private System.Windows.Forms.Label lblOldID_;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnCancel;
    }
}