using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Price2
{
    public partial class frmUserLoginChange : Form
    {
        public frmUserLoginChange()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //結束
            try
            {
                //因為沒變更成功按離開,所以要恢復原來使用的區
                ///判斷區
                if (strOriginalArea == "正式區")
                {
                    //clsDB._ServerName = "192.168.10.122";
                    clsDB._ServerName = "msl-price";
                    clsDB._DB_id = "sa";
                    clsDB._DB_password = "yzf";
                    clsDB._DB_name = "Price";
                }
                else
                {
                    //clsDB._ServerName = "192.168.10.122";
                    clsDB._ServerName = "msl-price";
                    clsDB._DB_id = "sa";
                    clsDB._DB_password = "yzf";
                    clsDB._DB_name = "Test";
                }

                //frmMain frmMain = (frmMain)this.MdiParent;
                //frmMain.gbMain.Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-_btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //登入
            try
            {
                ///判斷區
                //if (cboArea.Text == "正式區")
                if (radioOffical.Checked == true)
                {
                    //clsDB._ServerName = "192.168.10.122";
                    clsDB._ServerName = "msl-price";
                    clsDB._DB_id = "sa";
                    clsDB._DB_password = "yzf";
                    clsDB._DB_name = "Price";
                }
                else
                {
                    //clsDB._ServerName = "192.168.10.122";
                    clsDB._ServerName = "msl-price";
                    clsDB._DB_id = "sa";
                    clsDB._DB_password = "yzf";
                    clsDB._DB_name = "Test";
                }
                String strSQL = $@"select dbo.Readpwd(pas_password) as pwd,
                                          pas_ywcode,
                                          pas_username
                                   from   pas
                                   where  pas_username = '{txtUser.Text.Trim().ToUpper()}' ";
                DataTable dt = clsDB.sql_select_dt(strSQL);

                if (dt.Rows[0]["pwd"].ToString() == txtPassword.Text)    //密碼正確
                {
                    clsGlobal.strG_User = dt.Rows[0]["pas_username"].ToString();    //記錄登入使用者名稱
                    clsGlobal.strG_Ywcode = dt.Rows[0]["pas_ywcode"].ToString();    //記錄登入使用者的業務代碼
                    //clsGlobal.strG_Area = cboArea.Text;                             //記錄登入區
                    if (radioOffical.Checked == true)                                //記錄登入區
                    {
                        clsGlobal.strG_Area = "正式區";
                    }
                    else
                    {
                        clsGlobal.strG_Area = "測試區";
                    }
                    #region 變更登入不用確認
                    ////先確認有沒有正在導入系統外部成本
                    //strSQL = $@"select pub_impidflag from pub";
                    //string rs = clsDB.sql_select_String(strSQL, "pub_impidflag");
                    //if (rs == "1")
                    //{
                    //    MessageBox.Show("現在伺服器正在導入外部成本!", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    ////確認電腦名稱有沒有登錄在系統,沒有要新增一筆在wua
                    //strSQL = $@"select wus_computername from wus where wus_computername=host_name()";
                    //rs = clsDB.sql_select_String(strSQL, "wus_computername");
                    //if (rs != "")
                    //{
                    //    blnComputerchk = true;
                    //}
                    //else
                    //{
                    //    blnComputerchk = false;
                    //    strSQL = $@"insert wus
                    //                       ([wus_computername],
                    //                        [wus_username],
                    //                        [wus_name],
                    //                        [wus_updateflag],
                    //                        [wus_using],
                    //                        [wus_whatuse],
                    //                        [wus_updarea],
                    //                        [wus_userip])
                    //                values (Host_name(),
                    //                        '{txtUser.Text}',
                    //                        '',
                    //                        '',
                    //                        '',
                    //                        '',
                    //                        '臺灣',
                    //                        '{clsGlobal.strG_LocalIP }') ";
                    //    clsDB.Execute(strSQL);
                    //} 
                    #endregion
                    //更新wus 資訊
                    strSQL = $@"update wus
                                set    wus_username = '{txtUser.Text}',
                                       wus_name = pas_name,
                                       wus_using = '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}',
                                       wus_userip = '{clsGlobal.strG_LocalIP }'
                                from   wus,
                                       pas
                                where  pas_username = '{txtUser.Text}'
                                       and wus_computername = Host_name() ";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("已經更改完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMain frmMain = (frmMain)this.MdiParent;
                    frmMain.gbMain.Visible = true;
                    //離開
                    this.Close();
                }
                else
                {
                    MessageBox.Show("請確認帳號和密碼", "系統警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnOK_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string strOriginalArea = ""; //原來的區
        private void frmUserLoginChange_Activated(object sender, EventArgs e)
        {
            strOriginalArea = clsGlobal.strG_Area;
        }


    }
}
