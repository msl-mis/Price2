using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Reflection;



namespace Price2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void frmMain_Activated(object sender, System.EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                if (clsGlobal.strG_Area == "正式區")
                {
                    this.Text = ("(正式區)報價系統--" + "Ver：" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString() + " ；使用者：" + clsGlobal.strG_User);
                }
                else
                {
                    this.Text = ("(測試區)報價系統--" + "Ver：" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString() + " ；使用者：" + clsGlobal.strG_User);
                }
                startSocket();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmMain_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                #region 將form加到tabcontrol
                #region 加入第1頁
                //frmPage1 frmPage1 = new frmPage1
                //{
                //    //不要顯示Title
                //    FormBorderStyle = FormBorderStyle.None,
                //    //非最上層
                //    TopLevel = false,
                //    //顯示From，要加上去才會顯示Form
                //    Visible = true,
                //    //設定From位置
                //    Top = 0,
                //    Left = 0
                //};
                ////將Form加入tabPage中
                //tabPage1.Controls.Add(gb1);
                gb1.Visible=true;
                #endregion
                #region 加入第2頁
                //tabPage2.Controls.Add(gb2);
                gb2.Visible = true;
                #endregion
                #region 加入第3頁
                gb3.Visible = true;
                #endregion
                #region 加入第4頁
                gb4.Visible = true;
                #endregion
                #region 加入第5頁
                gb5.Visible = true;
                #endregion
                #region 加入第6頁
                gb6.Visible = true;
                #endregion

                #endregion

                //顯示tabPage
                tabPage1.Show();

                //tabMain.ItemSize= New Size(20, 100)
                tabMain.SizeMode = TabSizeMode.Fixed;
                tabMain.ItemSize = new Size((tabMain.Width-6)/6,0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmMain_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) //離開
        {
            if (flagLogout == true)  //直接退出不詢問
            {
                String strSQL = $@"update wus set wus_flag='' where wus_computername=host_name()";
                clsDB.Execute(strSQL);
                strSQL = $@"exec pri_quit";
                clsDB.Execute(strSQL);
                Environment.Exit(Environment.ExitCode);
            }

            if (MessageBox.Show(this, "確定退出？", "退出視窗通知", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                String strSQL = $@"update wus set wus_flag='' where wus_computername=host_name()";
                clsDB.Execute(strSQL);
                strSQL = $@"exec pri_quit";
                clsDB.Execute(strSQL);
                Environment.Exit(Environment.ExitCode);
            }
        }



        #region Menu區
        private void menu_Exit_Click(object sender, EventArgs e)    //離開
        {
            //離開
            this.Close();
        }
        public void menu1_1_Click(object sender, EventArgs e)   //1_1.用戶管理
        {
            //1_1.用戶管理
            try
            {
                string[] strModule=menu1_1.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1])==false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                tabMain.SelectedTab = tabPage1;
                gb1.Visible = true;
                frmUserManagement frmUserManagement = new frmUserManagement(); //宣告newform為FormSub的型態
                frmUserManagement.MdiParent = this;
                frmUserManagement.FormClosed += childForm_FormClosed;
                //frmUserManagement.Anchor = AnchorStyles.None;
                //frmUserManagement.Dock = DockStyle.Fill;
                frmUserManagement.StartPosition = FormStartPosition.CenterScreen;
                //frmUserManagement.Location = new Point(0, 0);
                //frmUserManagement.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = frmUserManagement.BackColor;
                }
                gbMain.Visible = false;
                frmUserManagement.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu1_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void menu1_2_Click(object sender, EventArgs e)  //1_2.用戶密碼修改
        {
            //1_2.用戶密碼修改
            try
            {
                string[] strModule = menu1_2.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                tabMain.SelectedTab = tabPage1;
                gb1.Visible = true;
                frmUserChangePassword frmUserChangePassword = new frmUserChangePassword();
                frmUserChangePassword.MdiParent = this;
                frmUserChangePassword.FormClosed += childForm_FormClosed;
                frmUserChangePassword.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmUserChangePassword.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu1_2_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void menu1_3_Click(object sender, EventArgs e)  //1_3.其他用戶登入系統
        {
            //1_3.其他用戶登入系統
            try
            {
                string[] strModule = menu1_3.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                tabMain.SelectedTab = tabPage1;
                gb1.Visible = true;
                frmUserLoginChange frmUserLoginChange = new frmUserLoginChange();
                frmUserLoginChange.MdiParent = this;
                frmUserLoginChange.FormClosed += childForm_FormClosed;
                frmUserLoginChange.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmUserLoginChange.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu1_3_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void menu1_4_Click(object sender, EventArgs e)  //1_4.發送消息
        {
            //1_4.發送消息
            try
            {
                string[] strModule = menu1_4.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show(this, "你是否想發送消息到本地網絡的所有電腦?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    InputBox input = new InputBox();
                    DialogResult dr = input.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        if (input.GetMsg() != "")
                        {
                            //String strSQL = $@"select distinct wus_userip from wus where wus_userip <> '' and wus_using >='{DateTime.Now.ToString("yyyy/MM/dd")}' and wus_computername<>HOST_NAME()";
                            String strSQL = $@"select distinct wus_userip from wus where wus_userip <> '' and wus_using >='{DateTime.Now.ToString("yyyy/MM/dd")}' ";
                            DataTable dt = clsDB.sql_select_dt(strSQL);

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                startConnect(dt.Rows[i]["wus_userip"].ToString()); //先連線
                                //客戶端向伺服器傳送訊息
                                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(clsGlobal.strG_User+"發送消息"+"\n"+ input.GetMsg());
                                socketSend_Client.Send(buffer);
                            }
                            MessageBox.Show("傳送完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu1_4_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu1_6_Click(object sender, EventArgs e)  //1_6.當前系統用戶狀況
        {
            //1_6.當前系統用戶狀況
            try
            {
                string[] strModule = menu1_6.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                tabMain.SelectedTab = tabPage1;
                gb1.Visible = true;
                frmUserStatus frmUserStatus = new frmUserStatus();
                frmUserStatus.MdiParent = this;
                frmUserStatus.FormClosed += childForm_FormClosed;
                frmUserStatus.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmUserStatus.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu1_6_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu2_1_Click(object sender, EventArgs e)  //2_1.電話簿
        {
            //2_1.電話簿
            try
            {
                string[] strModule = menu2_1.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                tabMain.SelectedTab = tabPage2;
                gb2.Visible = true;
                frmTelephone frmTelephone = new frmTelephone();
                frmTelephone.MdiParent = this;
                frmTelephone.FormClosed += childForm_FormClosed;
                frmTelephone.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmTelephone.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu2_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void menu2_2_Click(object sender, EventArgs e)  //2_2客戶資料建立
        {
            //2_2客戶資料建立
            try
            {
                string[] strModule = menu2_2.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                tabMain.SelectedTab = tabPage2;
                gb2.Visible = true;
                frmCustomer frmCustomer = new frmCustomer();
                frmCustomer.MdiParent = this;
                frmCustomer.FormClosed += childForm_FormClosed;
                frmCustomer.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmCustomer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu2_2_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu2_3_Click(object sender, EventArgs e)  //2_3廠商資料建立
        {
            //2_3廠商資料建立
            try
            {
                string[] strModule = menu2_3.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                tabMain.SelectedTab = tabPage2;
                gb2.Visible = true;
                frmVender frmVendor = new frmVender();
                frmVendor.MdiParent = this;
                frmVendor.FormClosed += childForm_FormClosed;
                frmVendor.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmVendor.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu2_3_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu3_1_Click(object sender, EventArgs e)  //3_1火車頭資料建立
        {
            //3_1火車頭資料建立
            try
            {
                string[] strModule = menu3_1.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                tabMain.SelectedTab = tabPage3;
                gb3.Visible = true;
                frmProduct frmProduct = new frmProduct();
                frmProduct.MdiParent = this;
                frmProduct.FormClosed += childForm_FormClosed;
                frmProduct.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmProduct.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu3_2_Click(object sender, EventArgs e)
        {
            //3_2 BOM產品結構建立
            try
            {
                Boolean blnHighlight = false;
                string[] strModule = menu3_2.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                tabMain.SelectedTab = tabPage3;
                gb3.Visible = true;
                string strSQL = "";
                DataTable dt;
                strSQL = $@"select pub_bomuse from pub ";
                dt = clsDB.sql_select_dt(strSQL);
                string pub_bomuse = dt.Rows[0]["pub_bomuse"].ToString();
                if (pub_bomuse != "")
                {
                    strSQL = $@"select pas_name from pas where pas_username='{ clsGlobal.strG_User}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows[0]["pas_name"].ToString() != pub_bomuse )
                    {
                        if (MessageBox.Show(this, "BOM產品結構建立[" + pub_bomuse + "] 正在使用, " + "\n" + "您要用唯讀模式進入嗎 ? ", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            blnHighlight = true;
                        }
                    }
                }
                frmBOM frmBOM = new frmBOM();
                frmBOM.MdiParent = this;
                frmBOM.FormClosed += childForm_FormClosed;
                frmBOM.StartPosition = FormStartPosition.CenterScreen;
                
                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                if(blnHighlight==true)
                {
                    frmBOM.blnHighlight = true;
                }
                else
                {
                    frmBOM.blnHighlight = false;
                }
                frmBOM.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_1_Click(object sender, EventArgs e)  //4_1 參照法資料輸入
        {
            //4_1 參照法資料輸入
            try
            {
                string[] strModule = menu4_1.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                tabMain.SelectedTab = tabPage4;
                gb4.Visible = true;
                frmRefer frmRefer = new frmRefer();
                frmRefer.MdiParent = this;
                frmRefer.FormClosed += childForm_FormClosed;
                frmRefer.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmRefer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_2_Click(object sender, EventArgs e)  //4_2 報價管理
        {
            //4_2 報價管理
            try
            {
                string[] strModule = menu4_2.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                //tabMain.SelectedTab = tabPage4;
                //gb4.Visible = true;
                frmBOMPrice frmBOMPrice = new frmBOMPrice();
                frmBOMPrice.MdiParent = this;
                frmBOMPrice.FormClosed += childForm_FormClosed;
                frmBOMPrice.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmBOMPrice.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_2_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_3_Click(object sender, EventArgs e)  //4_3 客人總檔
        {
            //4_3 客人總檔
            try
            {
                string[] strModule = menu4_3.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                //tabMain.SelectedTab = tabPage4;
                //gb4.Visible = true;
                frmCustomerFile frmCustomerFile = new frmCustomerFile();
                frmCustomerFile.MdiParent = this;
                frmCustomerFile.FormClosed += childForm_FormClosed;
                frmCustomerFile.StartPosition = FormStartPosition.CenterScreen;

                frmCustomerFile.Location = new Point(0, 55);
                frmCustomerFile.Width = this.Width - 25;
                frmCustomerFile.Height = this.Height - 80;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmCustomerFile.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_3_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_4_Click(object sender, EventArgs e)  //4_4 打樣單
        {
            //4_4 打樣單
            try
            {
                string[] strModule = menu4_4.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                //tabMain.SelectedTab = tabPage4;
                //gb4.Visible = true;
                frmProofing frmProofing = new frmProofing();
                frmProofing.MdiParent = this;
                frmProofing.FormClosed += childForm_FormClosed;
                frmProofing.StartPosition = FormStartPosition.CenterScreen;

                //frmProofing.Location = new Point(0, 55);
                //frmProofing.Width = this.Width - 25;
                //frmProofing.Height = this.Height - 80;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmProofing.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_4_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_5_Click(object sender, EventArgs e)  //4_5 客戶報價單
        {
            //4_5 客戶報價單
            try
            {
                string[] strModule = menu4_5.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                //tabMain.SelectedTab = tabPage4;
                //gb4.Visible = true;
                frmQuotation frmQuotation = new frmQuotation();
                frmQuotation.MdiParent = this;
                frmQuotation.FormClosed += childForm_FormClosed;
                frmQuotation.StartPosition = FormStartPosition.CenterScreen;

                //frmQuotation.Location = new Point(0, 55);
                //frmQuotation.Width = this.Width - 25;
                //frmQuotation.Height = this.Height - 80;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmQuotation.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_5_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_6_Click(object sender, EventArgs e)  //4_6 訂單管理
        {
            //4_6 訂單管理
            try
            {
                string[] strModule = menu4_6.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag(strModule[1]) == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                //tabMain.SelectedTab = tabPage4;
                //gb4.Visible = true;
                frmOrder frmOrder = new frmOrder();
                frmOrder.MdiParent = this;
                frmOrder.FormClosed += childForm_FormClosed;
                frmOrder.StartPosition = FormStartPosition.CenterScreen;

                //frmOrder.Location = new Point(0, 55);
                //frmOrder.Width = this.Width - 25;
                //frmOrder.Height = this.Height - 80;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmOrder.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_6_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Page1(系統)
        private void btn1_1_Click(object sender, EventArgs e)   //1.用戶管理
        {
            //1.用戶管理
            menu1_1.PerformClick();
        }
        private void btn1_2_Click(object sender, EventArgs e)   //2.用戶密碼修改
        {
            //2.用戶密碼修改
            menu1_2.PerformClick();
        }
        private void btn1_3_Click(object sender, EventArgs e)   //3.其他用戶登入系統
        {
            //3.其他用戶登入系統
            menu1_3.PerformClick();
        }
        private void btn1_4_Click(object sender, EventArgs e)   //4.發送消息
        {
            //4.發送消息
            menu1_4.PerformClick();

        }

        private void btn1_6_Click(object sender, EventArgs e)   //6.當前系統用戶狀況
        {
            //6.當前系統用戶狀況
            menu1_6.PerformClick();
        }

        #endregion

        #region Page2(基礎)
        private void btn2_1_Click(object sender, EventArgs e)   //2_1.電話簿
        {
            //2_1.電話簿
            menu2_1.PerformClick();
        }
        
        private void btn2_2_Click(object sender, EventArgs e)   //2_2.客戶資料建立
        {
            //2_2.客戶資料建立
            menu2_2.PerformClick();
        }

        private void btn2_3_Click(object sender, EventArgs e)   //2_3.廠商資料建立
        {
            //2_3.廠商資料建立
            menu2_3.PerformClick();
        }
        #endregion

        #region Page3(BOM)
        private void btn3_1_Click(object sender, EventArgs e)   //3_1.火車頭資料建立
        {
            //3_1.火車頭資料建立
            menu3_1.PerformClick();
        }

        private void btn3_2_Click(object sender, EventArgs e)   //3_2.BOM產品結構建立
        {
            //3_2.BOM產品結構建立
            menu3_2.PerformClick();
        }
        #endregion

        #region Page4(報價管理)
        private void btn4_1_Click(object sender, EventArgs e)   //4_1.參照法資料輸入
        {
            //4_1.參照法資料輸入
            menu4_1.PerformClick();
        }

        private void btn4_2_Click(object sender, EventArgs e)
        {
            //4_2.報價管理
            menu4_2.PerformClick();
        }

        private void btn4_3_Click(object sender, EventArgs e)
        {
            //4_3.客人總檔
            menu4_3.PerformClick();
        }

        private void btn4_4_Click(object sender, EventArgs e)
        {
            //4_4.打樣單
            menu4_4.PerformClick();
        }

        private void btn4_5_Click(object sender, EventArgs e)
        {
            //4_5.客戶報價單
            menu4_5.PerformClick();
        }

        private void btn4_6_Click(object sender, EventArgs e)
        {
            //4_6.訂單管理
            menu4_6.PerformClick();
        }

        #endregion

        private void startSocket()
        {
            try
            {
                //點選開始偵聽的時候，伺服器建立一個負責監聽IP地址跟埠號的Socket
                Socket socketwatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Any;
                //建立埠物件
                IPEndPoint point = new IPEndPoint(ip, 8001);
                //繫結
                socketwatch.Bind(point);

                //showMsg("監聽成功！");
                socketwatch.Listen(10);
                //建立一個執行緒
                Thread th = new Thread(Listen);
                th.IsBackground = true;
                th.Start(socketwatch);
            }
            catch
            {
                //showMsg("監聽失敗");
            }
        }

        Socket socketSend_Server;
        //等待客戶端的連線
        void Listen(Object o)
        {
            try
            {
                Socket socketwatch = o as Socket;
                while (true)
                {
                    //等待客戶端的連線
                    socketSend_Server = socketwatch.Accept();
                    //showMsg(socketSend_Server.RemoteEndPoint.ToString() + ":" + "連線成功！");
                    //開啟一個新的執行緒不斷的接收客戶端資訊
                    Thread th = new Thread(Receive_Server);
                    th.IsBackground = true;
                    th.Start(socketSend_Server);
                }
            }
            catch
            {

            }
        }
        //接收客戶端傳送的資訊
        void Receive_Server(Object o)
        {
            try
            {
                Socket socketSend_Server = o as Socket;
                while (true)
                {
                    byte[] buffer = new byte[1024 * 1024 * 2];
                    int r = socketSend_Server.Receive(buffer);
                    if (r == 0)
                    {
                        break;
                    }
                    string str = Encoding.UTF8.GetString(buffer, 0, r);
                    MessageBox.Show(str, "發送消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {

            }
        }
        
        Socket socketSend_Client;
        private void startConnect(string strIP)
        {
            socketSend_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint point = new IPEndPoint(IPAddress.Parse(strIP), 8001);
            socketSend_Client.Connect(point);
            //showMsg("連線成功!");
            Thread th = new Thread(Receive_Client);
            th.IsBackground = true;
            th.Start();
        }
        //客戶端接收伺服器傳送的訊息
        void Receive_Client()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 1024 * 2];
                    int r = socketSend_Client.Receive(buffer);
                    if (r == 0)
                    {
                        break;
                    }
                    string str = Encoding.UTF8.GetString(buffer, 0, r);
                    MessageBox.Show(str, "SERVER發送消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {

            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void btn1_5_Click(object sender, EventArgs e)
        {
            
        }
        Boolean flagLogout=false;
        private void timer_Tick(object sender, EventArgs e)
        {
            //BOM解鎖
            //確認權限
            String strSQL = "";
            string rs = "";
            if (clsGlobal.checkRightFlag("BOM解鎖") == true)
            {
                strSQL = $@"select pub_bomuse from pub";
                rs= clsDB.sql_select_String(strSQL, "pub_bomuse");
                toolTip.SetToolTip(this.lblBOM_Unlock, rs);
                if (rs !="")
                {
                    lblBOM_Unlock.Visible=true;
                }
                else
                {
                    lblBOM_Unlock.Visible=false;
                }
            }
            else
            {
                lblBOM_Unlock.Visible = false;
            }

            //剔除登錄者
            strSQL = $@"select wus_flag from wus where wus_computername=host_name()";
            rs = clsDB.sql_select_String(strSQL, "wus_flag");
            if(rs =="T")
            {
                flagLogout=true;
                //離開
                this.Close();
            }

        }

        private void lblBOM_Unlock_Click(object sender, EventArgs e)
        {
            //BOM解鎖
            try
            {
                string strSQL = "";
                DataTable dt;
                strSQL = $@"select pub_bomuse from pub ";
                dt = clsDB.sql_select_dt(strSQL);
                string pub_bomuse = dt.Rows[0]["pub_bomuse"].ToString();
                if (pub_bomuse != "")
                {
                    strSQL = $@"select pas_name from pas where pas_username='{clsGlobal.strG_User}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows[0]["pas_name"].ToString() != pub_bomuse)
                    {
                        if (MessageBox.Show(this, "BOM產品結構建立[" + pub_bomuse + "] 正在使用, " + "\n" + "請先與使用者確認有無在修改資料中,強制解鎖有可能會造成資料錯亂, " + "\n" + "您要解鎖嗎? ", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            strSQL = $@"update pub set pub_bomuse='' ";
                            clsDB.Execute(strSQL);
                            lblBOM_Unlock.Visible = false;
                            strSQL = $@"insert into bomlog
                                                    ([b_before],
                                                     [b_after],
                                                     [b_date],
                                                     [b_username],
                                                     [b_computername])
                                        values      ('BOM解鎖',
                                                     '原使用者{pub_bomuse}',
                                                     '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',
                                                     '{clsGlobal.strG_User}',
                                                     Host_name()) ";
                            clsDB.Execute(strSQL);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-lblBOM_Unlock_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void childForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            gbMain.Visible = true;
        }

        private void btnReturn_gb3_8_Click(object sender, EventArgs e)
        {
            gb3_8.Visible= false;
            gb3.Visible= true;
        }

        private void btnReturn_gb3_7_Click(object sender, EventArgs e)
        {
            gb3_7.Visible = false;
            gb3.Visible = true;
        }

        private void btnReturn_gb3_6_Click(object sender, EventArgs e)
        {
            gb3_6.Visible = false;
            gb3.Visible = true;
        }

        private void btn3_6_Click(object sender, EventArgs e)
        {
            gb3.Visible = false;
            gb3_6.Visible = true;
        }

        private void btn3_7_Click(object sender, EventArgs e)
        {
            gb3.Visible = false;
            gb3_7.Visible = true;
        }

        private void btn3_8_Click(object sender, EventArgs e)
        {
            gb3.Visible = false;
            gb3_8.Visible = true;
        }

        
    }
}
