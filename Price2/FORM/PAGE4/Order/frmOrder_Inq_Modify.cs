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
    public partial class frmOrder_Inq_Modify : Form
    {
        public static string rstrOrderID = "";   //傳來的訂單編號
        public frmOrder_Inq_Modify()
        {
            InitializeComponent();
        }

        private void frmOrder_Inq_Modify_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                
                String strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select odm_orderid      工單編號,
                                   format(odm_adddate,'yyyy/MM/dd')      修改日期,
                                   odm_username     用戶,
                                   odm_computername 電腦名,
                                   odm_bz           備註,
                                   odm_nbr
                            from   odm
                            where  odm_orderid = '{rstrOrderID}'
                            order  by odm_adddate ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmOrder_Note_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                if (clsGlobal.checkRightFlag("訂單工單修改記錄儲存") == false)
                {
                    MessageBox.Show("你沒有訂單工單修改記錄儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string strSQL = "";
                for (int i = 0; i < dgvData.Rows.Count ; i++)
                {
                    strSQL = $@"update odm
                                set    odm_bz = '{dgvData.Rows[i].Cells["備註"].Value.ToString().Trim()}'
                                where  odm_nbr = {dgvData.Rows[i].Cells["odm_nbr"].Value.ToString().Trim()} ";
                    clsDB.Execute(strSQL);
                }
                

                MessageBox.Show("已經存盤完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
