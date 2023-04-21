namespace Price2
{
    partial class frmBOMPrice_Msgbox
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
            this.btnNG = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rtxtMsg = new System.Windows.Forms.RichTextBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox.Controls.Add(this.btnNG);
            this.groupBox.Controls.Add(this.btnOK);
            this.groupBox.Controls.Add(this.rtxtMsg);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox.Size = new System.Drawing.Size(529, 450);
            this.groupBox.TabIndex = 5;
            this.groupBox.TabStop = false;
            // 
            // btnNG
            // 
            this.btnNG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNG.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNG.Location = new System.Drawing.Point(242, 395);
            this.btnNG.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNG.Name = "btnNG";
            this.btnNG.Size = new System.Drawing.Size(63, 34);
            this.btnNG.TabIndex = 88;
            this.btnNG.Text = "否(N)";
            this.btnNG.UseVisualStyleBackColor = false;
            this.btnNG.Click += new System.EventHandler(this.btnNG_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(141, 395);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(63, 34);
            this.btnOK.TabIndex = 87;
            this.btnOK.Text = "是(Y)";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rtxtMsg
            // 
            this.rtxtMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtxtMsg.Location = new System.Drawing.Point(2, 22);
            this.rtxtMsg.Name = "rtxtMsg";
            this.rtxtMsg.Size = new System.Drawing.Size(525, 352);
            this.rtxtMsg.TabIndex = 0;
            this.rtxtMsg.Text = "";
            // 
            // frmBOMPrice_Msgbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 450);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox);
            this.Name = "frmBOMPrice_Msgbox";
            this.Text = "材料名細";
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        public System.Windows.Forms.RichTextBox rtxtMsg;
        public System.Windows.Forms.Button btnNG;
        public System.Windows.Forms.Button btnOK;
    }
}