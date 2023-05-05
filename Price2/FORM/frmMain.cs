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
                #region 加入第7頁
                gb7.Visible = true;
                #endregion
                #endregion

                //顯示tabPage
                tabPage1.Show();

                //tabMain.ItemSize= New Size(20, 100)
                tabMain.SizeMode = TabSizeMode.Fixed;
                tabMain.ItemSize = new Size((tabMain.Width - 6) / 7, 0);
                tabMain.Location=new Point((gbMain.Width-tabMain.Width)/2, (gbMain.Height - tabMain.Height) / 2);
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
                frmVendor frmVendor = new frmVendor();
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

        private void menu3_1_Click(object sender, EventArgs e)  //3_1 火車頭資料建立
        {
            //3_1 火車頭資料建立
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

        private void menu3_2_Click(object sender, EventArgs e)  //3_2 BOM產品結構建立
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

        private void menu3_3_Click(object sender, EventArgs e)  //3_3 查材料位置明細表
        {
            //3_3 查材料位置明細表
            try
            {
                string[] strModule = menu3_3.Text.Split('.');
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
                frmInq_Material_Detial frmInq_Material_Detial = new frmInq_Material_Detial();
                frmInq_Material_Detial.MdiParent = this;
                frmInq_Material_Detial.FormClosed += childForm_FormClosed;
                frmInq_Material_Detial.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmInq_Material_Detial.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_3_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu3_4_Click(object sender, EventArgs e)  //3_4 查材料名使用情形
        {
            //3_4 查材料名使用情形
            try
            {
                string[] strModule = menu3_4.Text.Split('.');
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
                frmInq_Material_Status frmInq_Material_Status = new frmInq_Material_Status();
                frmInq_Material_Status.MdiParent = this;
                frmInq_Material_Status.FormClosed += childForm_FormClosed;
                frmInq_Material_Status.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmInq_Material_Status.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_4_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu3_5_1_Click(object sender, EventArgs e)    //3_5_1 更名(報價單)
        {
            //3_5_1 更名(報價單)
            try
            {
                string[] strModule = menu3_5_1.Text.Split('.');
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
                frmReName_Quotation frmReName_Quotation = new frmReName_Quotation();
                frmReName_Quotation.MdiParent = this;
                frmReName_Quotation.FormClosed += childForm_FormClosed;
                frmReName_Quotation.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmReName_Quotation.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_5_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu3_5_2_Click(object sender, EventArgs e)    //3_5_2 更名(材料單)
        {
            //3_5_2 更名(材料單)
            try
            {
                string[] strModule = menu3_5_1.Text.Split('.');
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
                frmReName_Material frmReName_Material = new frmReName_Material();
                frmReName_Material.MdiParent = this;
                frmReName_Material.FormClosed += childForm_FormClosed;
                frmReName_Material.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmReName_Material.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_5_2_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu3_5_3_Click(object sender, EventArgs e)    //3_5_3 批次修改參照法
        {
            //3_5_3 批次修改參照法
            try
            {
                string[] strModule = menu3_5_1.Text.Split('.');
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
                frmModify_CZF frmModify_CZF = new frmModify_CZF();
                frmModify_CZF.MdiParent = this;
                frmModify_CZF.FormClosed += childForm_FormClosed;
                frmModify_CZF.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmModify_CZF.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_5_3_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu3_6_1_Click(object sender, EventArgs e)    //3_6_1 銅桿價設定
        {
            //3_6_1 銅桿價設定
            try
            {
                string[] strModule = menu3_6_1.Text.Split('.');
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
                frmPriceSetting_Copper frmPriceSetting_Copper = new frmPriceSetting_Copper();
                frmPriceSetting_Copper.MdiParent = this;
                frmPriceSetting_Copper.FormClosed += childForm_FormClosed;
                frmPriceSetting_Copper.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmPriceSetting_Copper.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_6_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu3_6_2_Click(object sender, EventArgs e)    //3_6_2 材料採購明細
        {
            //3_6_2 材料採購明細
            try
            {
                string[] strModule = menu3_6_2.Text.Split('.');
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
                frmPriceSetting_Others frmPriceSetting_Others = new frmPriceSetting_Others();
                frmPriceSetting_Others.MdiParent = this;
                frmPriceSetting_Others.FormClosed += childForm_FormClosed;
                frmPriceSetting_Others.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmPriceSetting_Others.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_6_2_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu3_7_1_Click(object sender, EventArgs e)    //3_7_1 每月安規費用登錄
        {
            //3_7_1 每月安規費用登錄
            try
            {
                string[] strModule = menu3_7_1.Text.Split('.');
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
                frmSafetyFees_Input frmSafetyFees_Input = new frmSafetyFees_Input();
                frmSafetyFees_Input.MdiParent = this;
                frmSafetyFees_Input.FormClosed += childForm_FormClosed;
                frmSafetyFees_Input.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmSafetyFees_Input.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_7_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu3_7_2_Click(object sender, EventArgs e)    //3_7_2 安規費用分攤統計表
        {
            //3_7_2 安規費用分攤統計表
            try
            {
                string[] strModule = menu3_7_2.Text.Split('.');
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
                frmSafetyFees_Report frmSafetyFees_Report = new frmSafetyFees_Report();
                frmSafetyFees_Report.MdiParent = this;
                frmSafetyFees_Report.FormClosed += childForm_FormClosed;
                frmSafetyFees_Report.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmSafetyFees_Report.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_7_2_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu3_7_3_Click(object sender, EventArgs e)    //3_7_3 USB2.0協會年費分攤
        {
            //3_7_3 USB2.0協會年費分攤
            try
            {
                //string[] strModule = menu3_7_3.Text.Split('.');
                //確認權限
                //if (clsGlobal.checkRightFlag(strModule[1]) == false)
                if (clsGlobal.checkRightFlag("USB2.0協會年費分攤") == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                //顯示tabPage
                frmUSB2_Input frmUSB2_Input = new frmUSB2_Input();
                frmUSB2_Input.MdiParent = this;
                frmUSB2_Input.FormClosed += childForm_FormClosed;
                frmUSB2_Input.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmUSB2_Input.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_7_3_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu3_8_1_Click(object sender, EventArgs e)    //3_8_1 UL標籤費用與成本登錄
        {
            //3_8_1 UL標籤費用與成本登錄
            try
            {
                string[] strModule = menu3_8_1.Text.Split('.');
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
                frmLabel_UL_Input frmLabel_UL_Input = new frmLabel_UL_Input();
                frmLabel_UL_Input.MdiParent = this;
                frmLabel_UL_Input.FormClosed += childForm_FormClosed;
                frmLabel_UL_Input.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmLabel_UL_Input.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_8_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu3_8_2_Click(object sender, EventArgs e)    //3_8_2 UL817標籤數量與價格登錄
        {
            //3_8_2 UL817標籤數量與價格登錄
            try
            {
                string[] strModule = menu3_8_2.Text.Split('.');
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
                frmLabel_UL817_Input frmLabel_UL817_Input = new frmLabel_UL817_Input();
                frmLabel_UL817_Input.MdiParent = this;
                frmLabel_UL817_Input.FormClosed += childForm_FormClosed;
                frmLabel_UL817_Input.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmLabel_UL817_Input.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu3_8_2_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void menu4_7_Click(object sender, EventArgs e)  //4_7 客戶檔樣管理
        {
            //4_7 客戶檔樣管理
            try
            {
                string[] strModule = menu4_7.Text.Split('.');
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

                frmProofingFile frmProofingFile = new frmProofingFile();
                frmProofingFile.MdiParent = this;
                frmProofingFile.FormClosed += childForm_FormClosed;
                frmProofingFile.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmProofingFile.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_7_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_9_Click(object sender, EventArgs e)  //4_9 客戶成交查詢
        {
            
        }

        private void menu4_9_1_Click(object sender, EventArgs e)    //4_9_1 成交查詢_CHART
        {
            //4_9_1 成交查詢_CHART
            try
            {
                string[] strModule = menu4_9.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag("成交查詢") == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }

                frmSalesReport frmSalesReport = new frmSalesReport();
                frmSalesReport.MdiParent = this;
                frmSalesReport.FormClosed += childForm_FormClosed;
                frmSalesReport.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmSalesReport.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_9_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_9_2_Click(object sender, EventArgs e)    //4_9_2 成交查詢_GRID
        {
            //4_9_2 成交查詢_GRID
            try
            {
                string[] strModule = menu4_9.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag("成交查詢") == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }

                frmSalesReport_Grid frmSalesReport_Grid = new frmSalesReport_Grid();
                frmSalesReport_Grid.MdiParent = this;
                frmSalesReport_Grid.FormClosed += childForm_FormClosed;
                frmSalesReport_Grid.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmSalesReport_Grid.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_9_2_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_9_3_Click(object sender, EventArgs e)    //4_9_3 分類利潤報表
        {
            //4_9_3 分類利潤報表
            try
            {
                string[] strModule = menu4_9.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag("成交查詢") == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }

                frmClassReport frmClassReport = new frmClassReport();
                frmClassReport.MdiParent = this;
                frmClassReport.FormClosed += childForm_FormClosed;
                frmClassReport.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmClassReport.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_9_3_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_9_4_Click(object sender, EventArgs e)    //4_9_4 月份營業額報表
        {
            //4_9_4 月份營業額報表
            try
            {
                string[] strModule = menu4_9.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag("成交查詢") == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }

                frmRevenueReport frmRevenueReport = new frmRevenueReport();
                frmRevenueReport.MdiParent = this;
                frmRevenueReport.FormClosed += childForm_FormClosed;
                frmRevenueReport.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmRevenueReport.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_9_4_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_9_5_Click(object sender, EventArgs e)    //4_9_5 產品成交查詢
        {
            //4_9_5 產品成交查詢
            try
            {
                string[] strModule = menu4_9.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag("成交查詢") == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }

                frmDealReport frmDealReport = new frmDealReport();
                frmDealReport.MdiParent = this;
                frmDealReport.FormClosed += childForm_FormClosed;
                frmDealReport.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmDealReport.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_9_5_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_9_6_Click(object sender, EventArgs e)    //4_9_6 廠商採購查詢
        {
            //4_9_6 廠商採購查詢
            try
            {
                string[] strModule = menu4_9.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag("成交查詢") == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }

                frmProcurementReport frmProcurementReport = new frmProcurementReport();
                frmProcurementReport.MdiParent = this;
                frmProcurementReport.FormClosed += childForm_FormClosed;
                frmProcurementReport.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmProcurementReport.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_9_6_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_10_Click(object sender, EventArgs e) //4_10 客戶客訴查詢
        {
            //4_10 客戶客訴查詢
            try
            {
                string[] strModule = menu4_10.Text.Split('.');
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

                frmComplaintReport frmComplaintReport = new frmComplaintReport();
                frmComplaintReport.MdiParent = this;
                frmComplaintReport.FormClosed += childForm_FormClosed;
                frmComplaintReport.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmComplaintReport.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_10_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void menu4_11_Click(object sender, EventArgs e) //4_11 調整報價加工分/不良率
        {
            //4_11 調整報價加工分/不良率
            try
            {
                string[] strModule = menu4_11.Text.Split('.');
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

                frmWorking_Adjust frmWorking_Adjust = new frmWorking_Adjust();
                frmWorking_Adjust.MdiParent = this;
                frmWorking_Adjust.FormClosed += childForm_FormClosed;
                frmWorking_Adjust.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmWorking_Adjust.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_11_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_12_Click(object sender, EventArgs e) //4_12 調整報價材料
        {
            //4_12 調整報價材料
            try
            {
                string[] strModule = menu4_12.Text.Split('.');
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

                frmMaterial_Adjust frmMaterial_Adjust = new frmMaterial_Adjust();
                frmMaterial_Adjust.MdiParent = this;
                frmMaterial_Adjust.FormClosed += childForm_FormClosed;
                frmMaterial_Adjust.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmMaterial_Adjust.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_12_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_13_Click(object sender, EventArgs e)
        {
            //4_13 量大資料查詢
            try
            {
                string[] strModule = menu4_13.Text.Split('.');
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

                frmInq_Large frmInq_Large = new frmInq_Large();
                frmInq_Large.MdiParent = this;
                frmInq_Large.FormClosed += childForm_FormClosed;
                frmInq_Large.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmInq_Large.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_13_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_14_Click(object sender, EventArgs e) //4_14 特選材料查詢更名
        {
            //4_14 特選材料查詢更名
            try
            {
                string[] strModule = menu4_13.Text.Split('.');
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

                frmTemporary_Replace frmTemporary_Replace = new frmTemporary_Replace();
                frmTemporary_Replace.MdiParent = this;
                frmTemporary_Replace.FormClosed += childForm_FormClosed;
                frmTemporary_Replace.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmTemporary_Replace.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_14_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_15_Click(object sender, EventArgs e)
        {
            //4_15 特別支出
            try
            {
                string[] strModule = menu4_13.Text.Split('.');
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

                frmSpecialExpenes frmSpecialExpenes = new frmSpecialExpenes();
                frmSpecialExpenes.MdiParent = this;
                frmSpecialExpenes.FormClosed += childForm_FormClosed;
                frmSpecialExpenes.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmSpecialExpenes.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_15_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_16_Click(object sender, EventArgs e) //4_16 銅價試算
        {
            //4_16 銅價試算
            try
            {
                string[] strModule = menu4_16.Text.Split('.');
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

                frmCopper_Price_Calculate frmCopper_Price_Calculate = new frmCopper_Price_Calculate();
                frmCopper_Price_Calculate.MdiParent = this;
                frmCopper_Price_Calculate.FormClosed += childForm_FormClosed;
                frmCopper_Price_Calculate.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmCopper_Price_Calculate.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_16_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu4_17_Click(object sender, EventArgs e) //4_17 備註資料輸入
        {
            //4_17 備註資料輸入
            try
            {
                string[] strModule = menu4_17.Text.Split('.');
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

                frmProofing_Note_Manage frmProofing_Note_Manage = new frmProofing_Note_Manage();
                frmProofing_Note_Manage.MdiParent = this;
                frmProofing_Note_Manage.FormClosed += childForm_FormClosed;
                frmProofing_Note_Manage.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmProofing_Note_Manage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_17_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu5_1_Click(object sender, EventArgs e)  //5_1 匯率設定
        {
            //5_1 匯率設定
            try
            {
                string[] strModule = menu5_1.Text.Split('.');
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

                frmExangeRate frmExangeRate = new frmExangeRate();
                frmExangeRate.MdiParent = this;
                frmExangeRate.FormClosed += childForm_FormClosed;
                frmExangeRate.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmExangeRate.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu5_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu5_2_Click(object sender, EventArgs e)  //5_2 焊工補貼設定
        {
            //5_2 焊工補貼設定
            try
            {
                string[] strModule = menu5_2.Text.Split('.');
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

                frmWelderAllowance frmWelderAllowance = new frmWelderAllowance();
                frmWelderAllowance.MdiParent = this;
                frmWelderAllowance.FormClosed += childForm_FormClosed;
                frmWelderAllowance.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmWelderAllowance.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu5_2_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu5_3_Click(object sender, EventArgs e)  //5_3 國稅設定
        {
            //5_3 國稅設定
            try
            {
                string[] strModule = menu5_3.Text.Split('.');
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

                frmTaxRate frmTaxRate = new frmTaxRate();
                frmTaxRate.MdiParent = this;
                frmTaxRate.FormClosed += childForm_FormClosed;
                frmTaxRate.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmTaxRate.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu5_3_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu5_4_1_Click(object sender, EventArgs e)    //5_4_1 人工成本/CN設定
        {
            //5_4_1 人工成本/CN設定
            try
            {
                string[] strModule = menu5_4_1.Text.Split('.');
                //確認權限
                //if (clsGlobal.checkRightFlag(strModule[1]) == false)
                //{
                //    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }

                frmLaborCost_CN frmLaborCost_CN = new frmLaborCost_CN();
                frmLaborCost_CN.MdiParent = this;
                frmLaborCost_CN.FormClosed += childForm_FormClosed;
                frmLaborCost_CN.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmLaborCost_CN.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu5_4_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu6_1_Click(object sender, EventArgs e)  //6_1 客號材積箱量與重量輸入
        {
            //6_1 客號材積箱量與重量輸入
            try
            {
                string[] strModule = menu6_1.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag("業務") == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }

                frmPackage_Input frmPackage_Input = new frmPackage_Input();
                frmPackage_Input.MdiParent = this;
                frmPackage_Input.FormClosed += childForm_FormClosed;
                frmPackage_Input.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmPackage_Input.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu6_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu6_2_Click(object sender, EventArgs e)  //6_2 出貨箱號列印
        {
            //6_2 出貨箱號列印
            try
            {
                string[] strModule = menu6_2.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag("業務") == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }

                frmShipBox_Print frmShipBox_Print = new frmShipBox_Print();
                frmShipBox_Print.MdiParent = this;
                frmShipBox_Print.FormClosed += childForm_FormClosed;
                frmShipBox_Print.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmShipBox_Print.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu6_2_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu6_3_Click(object sender, EventArgs e)  //6_3 出貨計畫列印
        {
            //6_3 出貨計畫列印
            try
            {
                string[] strModule = menu6_2.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag("業務") == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }

                frmShipPlan_Print frmShipPlan_Print = new frmShipPlan_Print();
                frmShipPlan_Print.MdiParent = this;
                frmShipPlan_Print.FormClosed += childForm_FormClosed;
                frmShipPlan_Print.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmShipPlan_Print.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu6_3_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Menu7(共用資料)
        private void menu7_1_Click(object sender, EventArgs e)  //7_1 查詢有訂單無品號的材料
        {
            //7_1 查詢有訂單無品號的材料
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select asp_id         材料名,
                                   pri_customerid 客號,
                                   ord_orderid    訂單號,
                                   pri_username   修改人
                            from   asp,
                                   pri,
                                   ord
                            where  asp_vendormaterialno = ''
                                   and asp_id = pri_part
                                   and pri_customerid = ord_assy
                                   and asp_id in (select distinct asp_id
                                                  from   asp,
                                                         pri,
                                                         ord
                                                  where  asp_vendormaterialno = ''
                                                         and asp_id = pri_part
                                                         and pri_customerid = ord_assy)
                            order  by asp_id, ord_orderid desc ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    clsGlobal.ExportExcel("有訂單無品號的材料名檢查表", dgvData);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu7_1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu7_2_Click(object sender, EventArgs e)  //7_2 檢查品號對應多材料名
        {
            //7_2 檢查品號對應多材料名
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"exec chk_pid_pnum";
                clsDB.Execute(strSQL);

                strSQL = $@"select na67_id 品號,
                                   na67_customerid 次數,
                                   na67_orderid 材料名
                            from   na67
                            where  na67_computername = Host_name()
                            order  by na67_idnum desc,
                                      na67_id ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    clsGlobal.ExportExcel("品號對應多材料名檢查表", dgvData);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu7_2_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void menu7_3_Click(object sender, EventArgs e)  //7_3 檢查材料單回寫品號是否不一致
        {
            //7_3 檢查材料單回寫品號是否不一致
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"exec chk_aspid_pricustomerid";
                clsDB.Execute(strSQL);

                strSQL = $@"select na67_id         材料名,
                                   na67_customerid 材料單品號,
                                   na67_orderid    火車頭外層品號,
                                   na67_idnum      火車頭內層品號
                            from   na67
                            where  na67_computername = Host_name()
                            order  by na67_idnum desc,
                                      na67_id ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    clsGlobal.ExportExcel("材料單回寫品號是否不一致檢查表", dgvData);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu7_3_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu7_4_Click(object sender, EventArgs e)  //7_4 檢查是否有包裝運開頭自訂材料名
        {
            //7_4 檢查是否有包裝運開頭自訂材料名
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"exec chk_pri_part";
                clsDB.Execute(strSQL);

                strSQL = $@"select na67_id 客戶,
                                   na67_customerid 客號,
                                   na67_orderid 材料名
                            from   na67
                            where  na67_computername = Host_name()
                            order  by na67_idnum desc,
                                      na67_id ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    clsGlobal.ExportExcel("包裝運開頭自訂材料名檢查表", dgvData);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu7_4_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void menu7_5_Click(object sender, EventArgs e)  //7_5 檢查品號前六碼不一致
        {
            //7_5 檢查品號前六碼不一致
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"exec chk_pid_6";
                clsDB.Execute(strSQL);

                strSQL = $@"select na67_id 材料名,
                                   na67_customerid 位置,
                                   na67_idnum 品號
                            from   na67
                            where  na67_computername = Host_name()
                            order  by na67_idnum desc,
                                      na67_id ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    clsGlobal.ExportExcel("檢查品號前六碼不一致", dgvData);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu7_5_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu7_6_Click(object sender, EventArgs e)  //7_6 參照法異動未更新報價檢查表
        {
            //7_6 參照法異動未更新報價檢查表
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"exec chk_odimodify";
                clsDB.Execute(strSQL);

                strSQL = $@"select na67_orderid    客戶,
                                   na67_id         客號,
                                   na67_datetime   異動時間,
                                   na67_customerid 修改人,
                                   na67_idnum      業務
                            from   na67
                            where  na67_computername = Host_name()
                            order  by na67_customerid,
                                      na67_orderid ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    clsGlobal.ExportExcel("參照法異動未更新報價檢查表", dgvData);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu7_6_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu7_7_Click(object sender, EventArgs e)  //7_7 檢查報價單中有二個包裝材料
        {
            //7_7 檢查報價單中有二個包裝材料
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"exec chk_bp_pnum";
                clsDB.Execute(strSQL);

                strSQL = $@"select na67_id         客號,
                                   na67_idnum      客戶,
                                   na67_customerid 包數量
                            from   na67
                            where  na67_computername = Host_name()
                            order  by na67_idnum desc,
                                      na67_id ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    clsGlobal.ExportExcel("報價單中有二個包裝材料檢查表", dgvData);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu7_7_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu7_8_Click(object sender, EventArgs e)  //7_8 檢查報價單材料不在火車頭和特選
        {
            //7_8 檢查報價單材料不在火車頭和特選
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"exec chk_bp_nonpid";
                clsDB.Execute(strSQL);

                strSQL = $@"select na67_id         客戶,
                                   na67_customerid 客號,
                                   na67_orderid    材料名
                            from   na67
                            where  na67_computername = Host_name()
                            order  by na67_idnum desc,
                                      na67_id ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    clsGlobal.ExportExcel("報價單中材料不在火車頭和特選檢查表", dgvData);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu7_8_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu7_9_Click(object sender, EventArgs e)  //7_9 客戶成交查詢異常資料檢查表
        {
            //7_9 客戶成交查詢異常資料檢查表
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"exec chk_order_price {DateTime.Now.ToString("yyyy")} ";
                clsDB.Execute(strSQL);

                strSQL = $@"select na67_id         '訂單號',
                                   na67_customerid '客號',
                                   na67_qtysum     '報價',
                                   na67_lengthsum  '轉換價',
                                   na67_idnum      '利潤%'
                            from   na67
                            where  na67_computername = Host_name()
                            order  by na67_id,
                                      na67_idnum desc ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    clsGlobal.ExportExcel("客戶成交查詢異常資料檢查表", dgvData);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu7_9_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu7_10_Click(object sender, EventArgs e) //7_10 安規線材火車頭設定檢查表
        {
            //7_10 安規線材火車頭設定檢查表
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"exec chk_ULSET ";
                clsDB.Execute(strSQL);

                strSQL = $@"select na67_id         材料名,
                                   na67_customerid 單位,
                                   na67_orderid    廠商,
                                   na67_idnum      錯誤原因
                            from   na67
                            where  na67_computername = Host_name()
                            order  by na67_idnum desc,
                                      na67_id ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    clsGlobal.ExportExcel("安規線材火車頭設定檢查表", dgvData);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu7_10_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu7_11_Click(object sender, EventArgs e) //7_11 報價低於成本價檢查表(未完成)
        {
            //7_11 報價低於成本價檢查表
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                clsDB.Execute(strSQL);

                //strSQL = $@"select distinct pri_customer       '客戶編號' ,
                //                                    pld_customerid     '客號',
                //                                    pld_name           '量大數量',
                //                                    pld_pricost        '差別報價',
                //                                    pri_convcost       '成本價',
                //                                    Round(( ( pld_pricost - pri_convcost ) / pri_convcost ) * 100, 3 ) '負利潤%',
                //                                    pld_date           '建立日期'
                //                    from   pld
                //                           left join pri
                //                                  on pri_customerid = pld_customerid
                //                    where  pld_name <> '一般價'
                //                           and pld_pricost < pri_convcost ";
                strSQL = $@"";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    clsGlobal.ExportExcel("安規線材火車頭設定檢查表", dgvData);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu7_11_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu7_12_Click(object sender, EventArgs e)
        {
            //7_12 有鼎新採購品號卻無Price品號
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"exec chk_ULSET ";
                clsDB.Execute(strSQL);

                strSQL = $@"select distinct asp_id               '材料名',
                                            asp_vendormaterialno '品號',
                                            MB001                '鼎新品號'
                            from   asp
                                   left join [ERPDB].MSLCN.dbo.INVMB
                                          on MB002 = asp_id collate Chinese_Taiwan_Stroke_CI_AS
                            where  asp_vendormaterialno = ''
                                   and MB001 <> ''
                            order  by asp_id,
                                      MB001 ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    clsGlobal.ExportExcel("有鼎新採購品號卻無Price品號", dgvData);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu7_12_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menu7_13_Click(object sender, EventArgs e) //7_13 304材料在火車頭外層檢查表
        {
            //7_13 304材料在火車頭外層檢查表
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                clsDB.Execute(strSQL);

                strSQL = $@"select asp_id               材料名,
                                   asp_vendormaterialno 品號,
                                   asp_vendorid         廠商,
                                   asp_user             用戶
                            from   asp
                            where  asp_vendorid = '304' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    clsGlobal.ExportExcel("有鼎新採購品號卻無Price品號", dgvData);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu7_13_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btn3_3_Click(object sender, EventArgs e)   //3_3.查材料位置明細表
        {
            //3_3.查材料位置明細表
            menu3_3.PerformClick();
        }

        private void btn3_4_Click(object sender, EventArgs e)   //3_4.查材料名使用情形
        {
            //3_4.查材料名使用情形
            menu3_4.PerformClick();
        }

        private void btn3_5_1_Click(object sender, EventArgs e) //3_5_1.更名(報價單)
        {
            //3_5_1.更名(報價單)
            menu3_5_1.PerformClick();
        }

        private void btn3_5_2_Click(object sender, EventArgs e) //3_5_2.更名(材料單)
        {
            //3_5_2.更名(材料單)
            menu3_5_2.PerformClick();
        }

        private void btn3_5_3_Click(object sender, EventArgs e) //3_5_3.批次修改參照法
        {
            //3_5_3.批次修改參照法
            menu3_5_3.PerformClick();
        }

        private void btn3_6_1_Click(object sender, EventArgs e) //3_6_1.銅桿價設定
        {
            //3_6_1.銅桿價設定
            menu3_6_1.PerformClick();
        }

        private void btn3_6_2_Click(object sender, EventArgs e) //3_6_2.材料採購明細
        {
            //3_6_2.材料採購明細
            menu3_6_2.PerformClick();
        }

        private void btn3_7_1_Click(object sender, EventArgs e) //3_7_1.每月安規費用登錄
        {
            //3_7_1.每月安規費用登錄
            menu3_7_1.PerformClick();
        }

        private void btn3_7_2_Click(object sender, EventArgs e) //3_7_2.安規費用分攤統計表
        {
            //3_7_2.安規費用分攤統計表
            menu3_7_2.PerformClick();
        }

        private void btn3_7_3_Click(object sender, EventArgs e) //3_7_3.USB2.0協會年費分攤
        {
            //3_7_3.USB2.0協會年費分攤
            menu3_7_3.PerformClick();
        }

        private void btn3_8_1_Click(object sender, EventArgs e) //3_8_1.UL標籤費用與成本登錄
        {
            //3_8_1.UL標籤費用與成本登錄
            menu3_8_1.PerformClick();
        }

        private void btn3_8_2_Click(object sender, EventArgs e) //3_8_2.UL817標籤數量與價格登錄
        {
            //3_8_2.UL817標籤數量與價格登錄
            menu3_8_2.PerformClick();
        }
        #endregion

        #region Page4(報價管理)
        private void btn4_1_Click(object sender, EventArgs e)   //4_1.參照法資料輸入
        {
            //4_1.參照法資料輸入
            menu4_1.PerformClick();
        }

        private void btn4_2_Click(object sender, EventArgs e)   //4_2.報價管理
        {
            //4_2.報價管理
            menu4_2.PerformClick();
        }

        private void btn4_3_Click(object sender, EventArgs e)   //4_3.客人總檔
        {
            //4_3.客人總檔
            menu4_3.PerformClick();
        }

        private void btn4_4_Click(object sender, EventArgs e)   //4_4.打樣單
        {
            //4_4.打樣單
            menu4_4.PerformClick();
        }

        private void btn4_5_Click(object sender, EventArgs e)   //4_5.客戶報價單
        {
            //4_5.客戶報價單
            menu4_5.PerformClick();
        }

        private void btn4_6_Click(object sender, EventArgs e)   //4_6.訂單管理
        {
            //4_6.訂單管理
            menu4_6.PerformClick();
        }

        private void btn4_7_Click(object sender, EventArgs e)   //4_7.客戶打樣總檔
        {
            //4_7.客戶打樣總檔
            menu4_7.PerformClick();
        }

        private void btn4_9_Click(object sender, EventArgs e)
        {
            //4_9.客戶成交查詢
            gb4.Visible = false;
            gb4_9.Visible = true;
        }

        private void btn4_9_1_Click(object sender, EventArgs e) //4_9_1.成交查詢_CHART
        {
            //4_9_1.成交查詢_CHART
            menu4_9_1.PerformClick();
        }

        private void btn4_9_2_Click(object sender, EventArgs e) //4_9_2.成交查詢_GRID
        {
            //4_9_2.成交查詢_GRID
            menu4_9_2.PerformClick();
        }

        private void btn4_9_3_Click(object sender, EventArgs e)     //4_9_3.分類利潤查詢
        {
            //4_9_3.分類利潤查詢
            menu4_9_3.PerformClick();
        }

        private void btn4_9_4_Click(object sender, EventArgs e) //4_9_4.月分營業額報表
        {
            //4_9_4.月分營業額報表
            menu4_9_4.PerformClick();
        }

        private void btn4_9_5_Click(object sender, EventArgs e) //4_9_5.產品成交查詢
        {
            //4_9_5.產品成交查詢
            menu4_9_5.PerformClick();
        }

        private void btn4_9_6_Click(object sender, EventArgs e) //4_9_6.廠商採購查詢
        {
            //4_9_6.廠商採購查詢
            menu4_9_6.PerformClick();
        }

        private void btn4_10_Click(object sender, EventArgs e)  //4_10.客戶客訴查詢
        {
            //4_10.客戶客訴查詢
            menu4_10.PerformClick();
        }

        private void btn4_11_Click(object sender, EventArgs e)  //4_11.調整報價加工分/不良率
        {
            //4_11.調整報價加工分/不良率
            menu4_11.PerformClick();
        }

        private void btn4_12_Click(object sender, EventArgs e)  //4_12.調整報價材料
        {
            //4_12.調整報價材料
            menu4_12.PerformClick();
        }

        private void btn4_13_Click(object sender, EventArgs e)
        {
            //4_13.量大資料查詢
            menu4_13.PerformClick();
        }

        private void btn4_14_Click(object sender, EventArgs e)  //4_14.特選材料查詢更名
        {
            //4_14.特選材料查詢更名
            menu4_14.PerformClick();
        }

        private void btn4_15_Click(object sender, EventArgs e)  //4_15.特別支出
        {
            //4_15.特別支出
            menu4_15.PerformClick();
        }

        private void btn4_16_Click(object sender, EventArgs e)  //4_16.銅價試算
        {
            //4_16.銅價試算
            menu4_16.PerformClick();
        }

        private void btn4_17_Click(object sender, EventArgs e)  //4_17.備註資料輸入
        {
            //4_17.備註資料輸入
            menu4_17.PerformClick();
        }
        #endregion

        #region Page5(資料設定)
        private void btn5_1_Click(object sender, EventArgs e)   //5_1.匯率設定
        {
            //5_1.匯率設定
            menu5_1.PerformClick();
        }

        private void btn5_2_Click(object sender, EventArgs e)   //5_2.焊工補貼設定
        {
            //5_2.焊工補貼設定
            menu5_2.PerformClick();
        }

        private void btn5_3_Click(object sender, EventArgs e)
        {
            //5_3.國稅設定
            menu5_3.PerformClick();
        }

        private void btn5_4_1_Click(object sender, EventArgs e) //5_4_1.人工成本/CN設定
        {
            //5_4_1.人工成本/CN設定
            menu5_4_1.PerformClick();
        }

        #endregion

        #region Page6(業務)
        private void btn6_1_Click(object sender, EventArgs e)   //6_1.客號材積箱量與重量輸入
        {
            //6_1.客號材積箱量與重量輸入
            menu6_1.PerformClick();
        }

        private void btn6_2_Click(object sender, EventArgs e)   //6_2.出貨箱號列印
        {
            //6_2.出貨箱號列印
            menu6_2.PerformClick();
        }

        private void btn6_3_Click(object sender, EventArgs e)   //6_3.出貨計畫列印
        {
            //6_3.出貨計畫列印
            menu6_3.PerformClick();
        }
        #endregion

        #region Page7(公用資料)
        private void btn7_1_Click(object sender, EventArgs e)   //7_1.查詢有訂單無品號的材料
        {
            //7_1.查詢有訂單無品號的材料
            menu7_1.PerformClick();
        }

        private void btn7_2_Click(object sender, EventArgs e)   //7_2.檢查品號對應多材料名
        {
            //7_2.檢查品號對應多材料名
            menu7_2.PerformClick();
        }

        private void btn7_3_Click(object sender, EventArgs e)   //7_3.檢查材料單回寫品號是否不一致
        {
            //7_3.檢查材料單回寫品號是否不一致
            menu7_3.PerformClick();
        }

        private void btn7_4_Click(object sender, EventArgs e)   //7_4.檢查是否有包裝運開頭自訂材料名
        {
            //7_4.檢查是否有包裝運開頭自訂材料名
            menu7_4.PerformClick();
        }

        private void btn7_5_Click(object sender, EventArgs e)   //7_5.檢查品號前六碼不一致
        {
            //7_5.檢查品號前六碼不一致
            menu7_5.PerformClick();
        }

        private void btn7_6_Click(object sender, EventArgs e)   //7_6.參照法異動未更新報價檢查表
        {
            //7_6.參照法異動未更新報價檢查表
            menu7_6.PerformClick();
        }

        private void btn7_7_Click(object sender, EventArgs e)   //7_7.檢查報價單中有二個包裝材料
        {
            //7_7.檢查報價單中有二個包裝材料
            menu7_7.PerformClick();
        }

        private void btn7_8_Click(object sender, EventArgs e)   //7_8.檢查報價單材料不在火車頭和特選
        {
            //7_8.檢查報價單材料不在火車頭和特選
            menu7_8.PerformClick();
        }

        private void btn7_9_Click(object sender, EventArgs e)   //7_9.客戶成交查詢異常資料檢查表
        {
            //7_9.客戶成交查詢異常資料檢查表
            menu7_9.PerformClick();
        }

        private void btn7_10_Click(object sender, EventArgs e)  //7_10.安規線材火車頭設定檢查表
        {
            //7_10.安規線材火車頭設定檢查表
            menu7_10.PerformClick();
        }

        private void btn7_11_Click(object sender, EventArgs e)  //7_11.報價低於成本價檢查表
        {
            //7_11.報價低於成本價檢查表
            menu7_11.PerformClick();
        }

        private void btn7_12_Click(object sender, EventArgs e)  //7_12.有鼎新採購品號卻無Price品號
        {
            //7_12.有鼎新採購品號卻無Price品號
            menu7_12.PerformClick();
        }

        private void btn7_13_Click(object sender, EventArgs e)  //7_13.304材料在火車頭外層檢查表
        {
            //7_13.304材料在火車頭外層檢查表
            menu7_13.PerformClick();
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

        private void btnReturn_gb3_5_Click(object sender, EventArgs e)
        {
            gb3_5.Visible = false;
            gb3.Visible = true;
        }

        private void btn3_5_Click(object sender, EventArgs e)
        {
            gb3.Visible = false;
            gb3_5.Visible = true;
        }

        

        private void btnReturn_gb5_5_Click(object sender, EventArgs e)
        {
            gb5_5.Visible = false;
            gb5.Visible = true;
        }

        private void btnReturn_gb5_4_Click(object sender, EventArgs e)
        {
            gb5_4.Visible = false;
            gb5.Visible = true;
        }

        private void btn5_4_Click(object sender, EventArgs e)
        {
            gb5.Visible = false;
            gb5_4.Visible = true;
        }

        private void btn5_5_Click(object sender, EventArgs e)
        {
            gb5.Visible = false;
            gb5_5.Visible = true;
        }

        private void btnReturn_gb4_9_Click(object sender, EventArgs e)
        {
            gb4_9.Visible = false;
            gb4.Visible = true;
        }

        private void menu4_9_7_Click(object sender, EventArgs e)    //4_9_7 EPS查詢
        {
            //4_9_7 EPS查詢
            try
            {
                string[] strModule = menu4_9.Text.Split('.');
                //確認權限
                if (clsGlobal.checkRightFlag("成交查詢") == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }

                frmEPS frmEPS = new frmEPS();
                frmEPS.MdiParent = this;
                frmEPS.FormClosed += childForm_FormClosed;
                frmEPS.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmEPS.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu4_9_7_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn4_9_7_Click(object sender, EventArgs e) //4_9_7.EPS查詢
        {
            //4_9_7.EPS查詢
            menu4_9_7.PerformClick();
        }

        private void menu1_5_Click(object sender, EventArgs e)  //1_5 代辦事項
        {
            //1_5 代辦事項
            try
            {
                string[] strModule = menu1_5.Text.Split('.');
                //確認權限
                //if (clsGlobal.checkRightFlag(strModule[1]) == false)
                //{
                //    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                frmTodo_List frmTodo_List = new frmTodo_List();
                frmTodo_List.MdiParent = this;
                frmTodo_List.FormClosed += childForm_FormClosed;
                frmTodo_List.StartPosition = FormStartPosition.CenterScreen;

                foreach (Control ctl in this.Controls.OfType<MdiClient>())
                {
                    ctl.BackColor = Color.FromArgb(192, 255, 255);
                }
                gbMain.Visible = false;
                frmTodo_List.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-menu1_5_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn1_5_Click(object sender, EventArgs e)   //1_5.代辦事項
        {
            //1_5.代辦事項
            menu1_5.PerformClick();
        }
    }
}

