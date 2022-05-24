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
    public partial class frmUserChangePassword : Form
    {
        public frmUserChangePassword()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //變更密碼
            try
            {
                
                String strSQL = $@"select dbo.Readpwd(pas_password) as pwd, *
                                   from   pas
                                   where  pas_username = '{clsGlobal.strG_User}'
                                          and dbo.Readpwd(pas_password) = '{txtOldPwd.Text.Trim().ToUpper()}'";
                string rs= clsDB.sql_select_String(strSQL,"pwd");
                if (rs == "")
                {
                    MessageBox.Show("你輸入的舊密碼不正確!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (MessageBox.Show(this, "你確定要更改這個用戶的密碼？", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        strSQL = $@"update pas set pas_password=dbo.savepwd('{txtNewPwd.Text.Trim()}') where pas_username='{clsGlobal.strG_User}'";
                        clsDB.Execute(strSQL);
                        MessageBox.Show("已經更改完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmMain frmMain = (frmMain)this.MdiParent;
                        frmMain.gbMain.Visible = true;
                        //離開
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //結束
            try
            {
                frmMain frmMain = (frmMain)this.MdiParent;
                frmMain.gbMain.Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-_btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
