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
    public partial class frmUserStatus : Form
    {
        public frmUserStatus()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //重新整理
            try
            {
                String strSQL = $@"select wus_computername,
                                          wus_username,
                                          wus_name,
                                          wus_using
                                   from   wus
                                   where  wus_username <> ''
                                          and Datepart(yy, wus_using) > 2000 ";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                dgvUser.DataSource = dt;
                //先把checkbox歸零
                for (int i = 0; i < dgvUser.RowCount; i++)
                {
                    dgvUser.Rows[i].Cells["chk"].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnRefresh_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //clsDB.Close();
            }
        }

        private void frmUserStatus_Activated(object sender, EventArgs e)
        {
            //要載入很多東西
            try
            {
                btnRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmUserStatus_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //clsDB.Close();
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

        private async void btnDeleteUser_Click(object sender, EventArgs e)    //剔除使用者
        {
            //剔除使用者
            try
            {
                //確認權限
                    string strComputer = "";
                string strSQL = "";
                if (clsGlobal.checkRightFlag("當前系統用戶狀況剔除權限") == false)
                {
                    MessageBox.Show("你沒有權限進入該塊!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show(this, "確定要剔除嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;//漏斗指標
                    for (int i = 0; i < dgvUser.RowCount; i++)
                    {
                        if (dgvUser.Rows[i].Cells["chk"].Value.ToString()== "True")    //只有左邊打勾才能執行
                        {
                            strComputer = dgvUser.Rows[i].Cells["wus_computername"].Value.ToString();   //目前要處理的電腦名
                            strSQL = $@"update wus set wus_flag='T' where wus_computername= '{strComputer}'";
                            clsDB.Execute(strSQL);
                        }
                    }
                    
                    await Task.Delay(5000); //延遲10秒
                    this.Cursor = Cursors.Default;//還原預設
                    btnRefresh.PerformClick();
                    MessageBox.Show("删除使用者成功!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//還原預設
                MessageBox.Show(this.Name + "-btnDeleteUser_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
