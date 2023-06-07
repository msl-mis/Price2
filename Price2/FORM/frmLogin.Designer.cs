namespace Price2
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label3 = new System.Windows.Forms.Label();
            this.picuser = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioOffical = new System.Windows.Forms.RadioButton();
            this.radioTest = new System.Windows.Forms.RadioButton();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.btnOK = new Sunny.UI.UISymbolButton();
            this.btnEnd = new Sunny.UI.UISymbolButton();
            this.txtUser = new Sunny.UI.UITextBox();
            this.txtPassword = new Sunny.UI.UITextBox();
            this.userlogin = new Sunny.UI.UILine();
            this.V = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picuser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(2, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(376, 47);
            this.label3.TabIndex = 117;
            this.label3.Text = "MSL-PRICE 報價系統";
            // 
            // picuser
            // 
            this.picuser.BackColor = System.Drawing.Color.Transparent;
            this.picuser.Image = global::Price2.Properties.Resources.user;
            this.picuser.InitialImage = ((System.Drawing.Image)(resources.GetObject("picuser.InitialImage")));
            this.picuser.Location = new System.Drawing.Point(426, 166);
            this.picuser.Margin = new System.Windows.Forms.Padding(2);
            this.picuser.Name = "picuser";
            this.picuser.Size = new System.Drawing.Size(32, 32);
            this.picuser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picuser.TabIndex = 110;
            this.picuser.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(426, 208);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 111;
            this.pictureBox1.TabStop = false;
            // 
            // radioOffical
            // 
            this.radioOffical.AutoSize = true;
            this.radioOffical.BackColor = System.Drawing.Color.Transparent;
            this.radioOffical.Checked = true;
            this.radioOffical.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioOffical.Location = new System.Drawing.Point(432, 283);
            this.radioOffical.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioOffical.Name = "radioOffical";
            this.radioOffical.Size = new System.Drawing.Size(75, 24);
            this.radioOffical.TabIndex = 112;
            this.radioOffical.TabStop = true;
            this.radioOffical.Text = "正式區";
            this.radioOffical.UseVisualStyleBackColor = false;
            // 
            // radioTest
            // 
            this.radioTest.AutoSize = true;
            this.radioTest.BackColor = System.Drawing.Color.Transparent;
            this.radioTest.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioTest.Location = new System.Drawing.Point(525, 283);
            this.radioTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioTest.Name = "radioTest";
            this.radioTest.Size = new System.Drawing.Size(75, 24);
            this.radioTest.TabIndex = 113;
            this.radioTest.Text = "測試區";
            this.radioTest.UseVisualStyleBackColor = false;
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.BackColor = System.Drawing.Color.Transparent;
            this.chkRemember.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chkRemember.Location = new System.Drawing.Point(484, 248);
            this.chkRemember.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(92, 24);
            this.chkRemember.TabIndex = 114;
            this.chkRemember.Text = "記住密碼";
            this.chkRemember.UseVisualStyleBackColor = false;
            this.chkRemember.CheckedChanged += new System.EventHandler(this.chkRemember_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOK.Location = new System.Drawing.Point(430, 317);
            this.btnOK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 30);
            this.btnOK.Style = Sunny.UI.UIStyle.Custom;
            this.btnOK.StyleCustomMode = true;
            this.btnOK.TabIndex = 118;
            this.btnOK.Text = "進入";
            this.btnOK.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnEnd.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnEnd.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnEnd.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEnd.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEnd.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnEnd.Location = new System.Drawing.Point(528, 317);
            this.btnEnd.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnEnd.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnEnd.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEnd.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEnd.Size = new System.Drawing.Size(76, 30);
            this.btnEnd.Style = Sunny.UI.UIStyle.Red;
            this.btnEnd.StyleCustomMode = true;
            this.btnEnd.Symbol = 61453;
            this.btnEnd.TabIndex = 119;
            this.btnEnd.Text = "結束";
            this.btnEnd.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // txtUser
            // 
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtUser.Location = new System.Drawing.Point(465, 168);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUser.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtUser.Name = "txtUser";
            this.txtUser.ShowText = false;
            this.txtUser.Size = new System.Drawing.Size(150, 29);
            this.txtUser.TabIndex = 120;
            this.txtUser.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtUser.Watermark = "請輸入帳號";
            this.txtUser.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPassword.Location = new System.Drawing.Point(465, 210);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ShowText = false;
            this.txtPassword.Size = new System.Drawing.Size(150, 29);
            this.txtPassword.TabIndex = 121;
            this.txtPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtPassword.Watermark = "請輸入密碼";
            this.txtPassword.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // userlogin
            // 
            this.userlogin.BackColor = System.Drawing.Color.Transparent;
            this.userlogin.FillColor = System.Drawing.Color.Transparent;
            this.userlogin.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.userlogin.LineColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.userlogin.Location = new System.Drawing.Point(407, 122);
            this.userlogin.MinimumSize = new System.Drawing.Size(1, 1);
            this.userlogin.Name = "userlogin";
            this.userlogin.Size = new System.Drawing.Size(217, 29);
            this.userlogin.Style = Sunny.UI.UIStyle.Custom;
            this.userlogin.TabIndex = 122;
            this.userlogin.Text = "用戶登錄";
            this.userlogin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // V
            // 
            this.V.BackColor = System.Drawing.Color.Transparent;
            this.V.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.V.Location = new System.Drawing.Point(393, 413);
            this.V.Name = "V";
            this.V.Size = new System.Drawing.Size(324, 16);
            this.V.TabIndex = 123;
            this.V.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.V.Click += new System.EventHandler(this.V_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Price2.Properties.Resources.PriceLogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(729, 438);
            this.ControlBox = false;
            this.Controls.Add(this.V);
            this.Controls.Add(this.userlogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.radioTest);
            this.Controls.Add(this.radioOffical);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picuser);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用戶驗證";
            this.Activated += new System.EventHandler(this.frmLogin_Activated);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picuser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picuser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioOffical;
        private System.Windows.Forms.RadioButton radioTest;
        private System.Windows.Forms.CheckBox chkRemember;
        private Sunny.UI.UISymbolButton btnOK;
        private Sunny.UI.UISymbolButton btnEnd;
        private Sunny.UI.UITextBox txtUser;
        private Sunny.UI.UITextBox txtPassword;
        private Sunny.UI.UILine userlogin;
        private System.Windows.Forms.Label V;
    }
}