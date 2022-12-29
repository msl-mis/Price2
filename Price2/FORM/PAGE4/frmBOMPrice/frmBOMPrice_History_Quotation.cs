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
    public partial class frmBOMPrice_History_Quotation : Form
    {
        public static string rstrID = "";  //由frmBOMPrice傳的材料ID
        public frmBOMPrice_History_Quotation()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) //結束
        {
            //結束
            try
            {
                frmBOMPrice.rstrButton = "Close";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e) //列印
        {
            //列印
            try
            {
                //clsGlobal clsGlobal = new clsGlobal();
                clsGlobal.ExportExcel("報價單價史", dgvData);
                //clsGlobal.ExportCsv( dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Click(object sender, EventArgs e)   //搜尋
        {
            //搜尋
            try
            {
                GetInq();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetInq()
        {
            try
            {
                string strWhere = "";
                strWhere = strWhere + (chkNewDate.Checked ? "" : $@" and prb_date between '{txtNewDate_S.Text}' and '{txtNewDate_E.Text}'");

                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select distinct prb_customer  '客戶',
                                            prb_customerid'客號',
                                            prb_date      '報價日期',
                                            prb_pricost   '報價金額',
                                            prb_hopelprice'希望買價',
                                            prb_ll        '利潤',
                                            prb_username  '用戶',
                                            prb_lenstr    '標識符'
                            from   prb
                            where  prb_customerid = '{rstrID}' ";
                strSQL = strSQL + strWhere + "order  by '報價日期' desc";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    lblCount.Text = dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-GetInq" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBOMPrice_History_Quotation_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {

                GetInq();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOMPrice_History_Quotation_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkNewDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewDate.Checked)
            {
                txtNewDate_S.Text = "(ALL)";
                txtNewDate_E.Text = "(ALL)";
            }
            else
            {
                txtNewDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtNewDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtNewDate_E_Enter(object sender, EventArgs e)
        {
            chkNewDate.Checked = false;
        }

        private void txtNewDate_S_Enter(object sender, EventArgs e)
        {
            chkNewDate.Checked = false;
        }

        private void btndelete_Click(object sender, EventArgs e)    //刪除
        {
            //刪除
            try
            {
                if(dgvData.CurrentRow.Index>=0)
                {
                    GetDelete();//單筆刪除
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btndelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void GetDelete()
        {
            try
            {
                //確認權限
                if (clsGlobal.checkRightFlag("報價單查價史刪除") == false)
                {
                    MessageBox.Show("您沒有報價單查價史刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                //有成交工單記錄,不能被刪除
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select *
                                from   ord
                                where  ord_assy = '{rstrID}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("該客號已有成交工單記錄,不能被刪除!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //防呆確認
                if (MessageBox.Show("你確定要刪除它嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    strSQL = $@"delete prb
                                where  prb_customerid = '{rstrID}'
                                       and Format(prb_date, 'yyyy/MM/dd HH:mm:ss') = '{Convert.ToDateTime( dgvData.Rows[dgvData.CurrentRow.Index].Cells["報價日期"].Value).ToString("yyyy/MM/dd HH:mm:ss")}' ";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-GetDelete" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if(dgvData.CurrentRow.Index >= 0)
                {
                    GetDelete();//單筆刪除
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e) //全部刪除
        {
            //全部刪除
            try
            {
                //沒有資料則忽略
                if(dgvData.Rows.Count == 0)
                {
                    return;
                }
                //確認權限
                if (clsGlobal.checkRightFlag("報價單查價史全部刪除") == false)
                {
                    MessageBox.Show("您沒有報價單查價史全部刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                //有成交工單記錄,不能被刪除
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select *
                                from   ord
                                where  ord_assy = '{rstrID}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("該客號已有成交工單記錄,不能被刪除!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //防呆確認
                if (MessageBox.Show("你確認要刪除所有符合這些條件的資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        strSQL = $@"delete prb
                                where  prb_customerid = '{rstrID}'
                                       and Format(prb_date, 'yyyy/MM/dd HH:mm:ss') = '{Convert.ToDateTime(dgvData.Rows[i].Cells["報價日期"].Value).ToString("yyyy/MM/dd HH:mm:ss")}' ";
                        clsDB.Execute(strSQL);
                    }
                    
                    MessageBox.Show("刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-GetDelete" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
