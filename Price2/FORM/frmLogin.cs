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

namespace Price2
{
    public partial class frmLogin : Form
    {
        //clsDB clsDB = new clsDB();
        bool blnComputerchk;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(Environment.ExitCode);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ///檢查欄位
                if(txtUser.Text == "")
                {
                    MessageBox.Show("請輸入用戶名", "系統警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("請輸入密碼", "系統警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //限制指定的帳號只能登入測試區
                //if (txtUser.Text== "test" && cboArea.Text=="正式區")
                if (txtUser.Text == "test" && radioOffical.Checked == true)
                {
                    MessageBox.Show("你的帳號只能登入測試區", "系統警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ///判斷區
                //if (cboArea.Text=="正式區")
                if (radioOffical.Checked == true)
                {
                    //clsDB._ServerName = "192.168.10.122";
                    clsDB._ServerName = "msl-price";
                    clsDB._DB_id = "sa";
                    clsDB._DB_password = "yzf";
                    clsDB._DB_name = "Test";
    }
                else
                {
                    //clsDB._ServerName = "192.168.10.122";
                    clsDB._ServerName = "msl-price";
                    clsDB._DB_id = "sa";
                    clsDB._DB_password = "yzf";
                    clsDB._DB_name = "Test";
                }
                ///檢查是否已有資料
                String strSQL = "";
                DataTable dt = new DataTable();
                //clsDB.Open();    //SQL連線
                strSQL = $@"select dbo.readpwd(pas_password) as pwd,* from pas where pas_username='{txtUser.Text}'";
                //string rs= clsDB.sql_select_String(strSQL,"pwd");
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["pwd"].ToString() == txtPassword.Text)    //密碼正確
                    {
                        clsGlobal.strG_User = dt.Rows[0]["pas_username"].ToString();    //記錄登入使用者名稱
                        clsGlobal.strG_Ywcode = dt.Rows[0]["pas_ywcode"].ToString();    //記錄登入使用者的業務代碼
                        //clsGlobal.strG_Area = cboArea.Text;                           //記錄登入區
                        if(radioOffical.Checked == true)                                //記錄登入區
                        {
                            clsGlobal.strG_Area = "正式區";
                        }
                        else
                        {
                            clsGlobal.strG_Area = "測試區";
                        } 
                        
                        //記憶密碼處理
                        if(chkRemember.Checked == true)
                        {
                            
                            string path = System.IO.Directory.GetCurrentDirectory();    //獲取應用程序的當前工作目錄
                            clsIniManager iniManager = new clsIniManager(path + "/Price2.ini");
                            iniManager.WriteIniFile("Login", "CHECK", "True");
                            iniManager.WriteIniFile("Login", "USER", dt.Rows[0]["pas_username"].ToString());
                            iniManager.WriteIniFile("Login", "PASSWORD", dt.Rows[0]["pwd"].ToString());
                            iniManager.WriteIniFile("Login", "AREA", radioOffical.Checked.ToString());
                        }
                        else
                        {
                            
                            string path = System.IO.Directory.GetCurrentDirectory();
                            clsIniManager iniManager = new clsIniManager(path + "/Price2.ini");
                            iniManager.WriteIniFile("Login", "CHECK", "False");
                            iniManager.WriteIniFile("Login", "USER", "");
                            iniManager.WriteIniFile("Login", "PASSWORD", "");
                            iniManager.WriteIniFile("Login", "AREA", "True");
                        }
                        //先確認有沒有正在導入系統外部成本
                        strSQL = $@"select pub_impidflag from pub";
                        string rs = clsDB.sql_select_String(strSQL, "pub_impidflag");
                        if (rs == "1")
                        {
                            MessageBox.Show("現在伺服器正在導入外部成本!", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //確認電腦名稱有沒有登錄在系統,沒有要新增一筆在wua
                        strSQL = $@"select wus_computername from wus where wus_computername=host_name()";
                        rs = clsDB.sql_select_String(strSQL, "wus_computername");
                        if (rs != "")
                        {
                            blnComputerchk = true;
                        }
                        else
                        {
                            blnComputerchk = false;
                            strSQL = $@"insert wus
                                           ([wus_computername],
                                            [wus_username],
                                            [wus_name],
                                            [wus_updateflag],
                                            [wus_using],
                                            [wus_whatuse],
                                            [wus_updarea],
                                            [wus_userip])
                                    values (Host_name(),
                                            '{txtUser.Text}',
                                            '',
                                            '',
                                            '',
                                            '',
                                            '臺灣',
                                            '{clsGlobal.strG_LocalIP}') ";
                            clsDB.Execute(strSQL);
                        }
                        //更新wus 資訊
                        strSQL = $@"update wus
                                set    wus_username = '{txtUser.Text}',
                                       wus_name = pas_name,
                                       wus_using = '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}',
                                       wus_userip = '{clsGlobal.strG_LocalIP}'
                                from   wus,
                                       pas
                                where  pas_username = '{txtUser.Text}'
                                       and wus_computername = Host_name() ";
                        clsDB.Execute(strSQL);
                        //離開
                        DialogResult = DialogResult.OK;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("密碼不正確", "系統警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("沒這個帳號", "系統警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show( this.Name + "-btnOK_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //clsDB.Close();
            }
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            //要載入很多東西
            try
            {
                //cboArea.SelectedIndex = 0;
                //取得Local IP
                System.Net.IPAddress SvrIP = new System.Net.IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
                clsGlobal.strG_LocalIP = SvrIP.ToString();
                txtUser.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmLogin_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //處裡記憶密碼
            string path = System.IO.Directory.GetCurrentDirectory();    //獲取應用程序的當前工作目錄
            clsIniManager iniManager = new clsIniManager(path + "/Price2.ini");
            if (iniManager.ReadIniFile("Login", "CHECK", "False")=="True")
            {
                chkRemember.Checked=true;
                txtUser.Text = iniManager.ReadIniFile("Login", "USER", "");
                txtPassword.Text = iniManager.ReadIniFile("Login", "PASSWORD", "");
                if(iniManager.ReadIniFile("Login", "AREA", "True")=="True")
                {
                    radioOffical.Checked=true;
                }
                else
                {
                    radioTest.Checked=true;
                }
            } 
        }

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRemember.Checked == true)
            {
                string path = System.IO.Directory.GetCurrentDirectory();    //獲取應用程序的當前工作目錄
                clsIniManager iniManager = new clsIniManager(path + "/Price2.ini");

                iniManager.WriteIniFile("Login", "CHECK", "True");
                
            }
            else
            {
                string path = System.IO.Directory.GetCurrentDirectory();    //獲取應用程序的當前工作目錄
                clsIniManager iniManager = new clsIniManager(path + "/Price2.ini");

                iniManager.WriteIniFile("Login", "CHECK", "False");
                
            }
        }

        //private void cboArea_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    ComboBox cbx = sender as ComboBox;
        //    if (cbx != null)
        //    {
        //        e.DrawBackground();
        //        if (e.Index >= 0)
        //        {
        //            //文字置中
        //            StringFormat sf = new StringFormat();
        //            sf.LineAlignment = StringAlignment.Far;
        //            sf.Alignment = StringAlignment.Near;

        //            Brush brush = new SolidBrush(cbx.ForeColor);
        //            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        //                brush = SystemBrushes.HighlightText;

        //            //重繪字串
        //            e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
        //        }
        //    }
        //}
    }
}
