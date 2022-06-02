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
                frmUserManagement frmUserManagement = new frmUserManagement(); //宣告newform為FormSub的型態
                frmUserManagement.MdiParent = this;
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
                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                frmUserChangePassword frmUserChangePassword = new frmUserChangePassword();
                frmUserChangePassword.MdiParent = this;
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

                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                frmUserLoginChange frmUserLoginChange = new frmUserLoginChange();
                frmUserLoginChange.MdiParent = this;
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

                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                frmUserStatus frmUserStatus = new frmUserStatus();
                frmUserStatus.MdiParent = this;
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

                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                frmTelephone frmTelephone = new frmTelephone();
                frmTelephone.MdiParent = this;
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
        private void menu2_2_Click(object sender, EventArgs e)
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

                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                frmCustomer frmCustomer = new frmCustomer();
                frmCustomer.MdiParent = this;
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

        private void menu2_3_Click(object sender, EventArgs e)
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

                if (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
                frmVendor frmVendor = new frmVendor();
                frmVendor.MdiParent = this;
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
        
        private void btn2_2_Click(object sender, EventArgs e)
        {
            //2_2.客戶資料建立
            menu2_2.PerformClick();
        }

        private void btn2_3_Click(object sender, EventArgs e)
        {
            //2_3.廠商資料建立
            menu2_3.PerformClick();
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

        
    }
}
