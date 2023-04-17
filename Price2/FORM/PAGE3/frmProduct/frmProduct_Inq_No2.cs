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
    public partial class frmProduct_Inq_No2 : Form
    {
        public static string rstrNo = "";   //傳來的品號
        public frmProduct_Inq_No2()
        {
            InitializeComponent();
        }

        private void frmProduct_Inq_No2_Load(object sender, EventArgs e)
        {
            txtNo.Text = rstrNo;
            getData();
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

        private void btnInq_Click(object sender, EventArgs e)
        {
            //查詢
            try
            {
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()
        {
            
            this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select *
                        from   (
                                               select distinct asp_id               as 材料名,
                                                               asp_vendormaterialno as 品號,
                                                               asp_czf              as 參照法
                                               from            asp ";
            strSQL = strSQL + Get_strWhere() ;
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                lblCount.Text = "資料筆數：" + dt.Rows.Count.ToString();
                dgvData.DataSource = dt;
            }
            else
            {
                lblCount.Text = "資料筆數：0";
                dgvData.DataSource = dt;
                MessageBox.Show("查不到資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Cursor = Cursors.Default;//滑鼠還原預設
        }

        private string Get_strWhere()
        {
            string strWhere = "";

            //
            strWhere = strWhere + (chkOut.Checked || chkCZF.Checked || chkSame.Checked ? $@"where asp_id <> 'yzf' and " : $@"where asp_id = 'yzf' ");
            //
            strWhere = strWhere + (chkOut.Checked ? $@"(asp_vendormaterialno like '%{txtNo.Text.Trim()}%'  {(chkSame.Checked ? "or " : "")} " : "");

            strWhere = strWhere + (chkSame.Checked ? $@"asp_multinum like '%{txtNo.Text.Trim()}%' " : "");

            strWhere = strWhere + (chkCZF.Checked ? (chkOut.Checked ? "or " : "") + $@"asp_czf like '%{txtNo.Text.Trim()}%' " : "");

            strWhere = strWhere + (chkOut.Checked ? $@") " : "");

            strWhere = strWhere + $@"union all select aspnum_id as 材料名,aspnum_num as 品號,'(內層品號)' as 參照法 from aspnum, asp where ";

            strWhere = strWhere + (chkIn.Checked ? $@"aspnum_num like '%{txtNo.Text.Trim()}%' and asp_id=aspnum_id and aspnum_num <> asp_vendormaterialno " : "aspnum_num='yzf' ");

            strWhere = strWhere + ") as aa order by aa.品號, aa.材料名 ";
            return strWhere;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                txtNo.Text = "";
                //清除dgv
                if (dgvData.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvData.DataSource;
                    dt.Rows.Clear();
                    dgvData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Q_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("火車頭品號查詢", dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                frmProduct.rstrID = dgvData.Rows[e.RowIndex].Cells["材料名"].Value.ToString();
                this.Close();
            }
        }
    }
}
