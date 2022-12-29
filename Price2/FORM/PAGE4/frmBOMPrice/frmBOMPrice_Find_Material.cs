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
    public partial class frmBOMPrice_Find_Material : Form
    {
        public static string rstrID = "";  //由frmBOMPrice傳的材料ID
        public frmBOMPrice_Find_Material()
        {
            InitializeComponent();
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
                strWhere = strWhere + (chkNewDate.Checked ? "" : $@" and pri_newdate between '{txtNewDate_S.Text}' and '{txtNewDate_E.Text}'");
                
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select distinct pri_customerid '材料名',
                                            pri_assy       '品號',
                                            pri_clcost     '材料價',
                                            pri_newdate    '變動日期'
                            from   pri
                            where  pri_part = '{rstrID}'
                                   and pri_newcostchk != 'N' ";
                strSQL = strSQL + strWhere;
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
                clsGlobal.ExportExcel("材料單尋找結果", dgvData);
                //clsGlobal.ExportCsv( dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)    //導出
        {
            //導出
            try
            {
                if (dgvData.CurrentRow!= null)
                {
                    getExport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getExport()
        {
            try
            {
                frmBOMPrice.rstrID = dgvData.Rows[dgvData.CurrentRow.Index].Cells["材料名"].Value.ToString();
                frmBOMPrice.rstrName = dgvData.Rows[dgvData.CurrentRow.Index].Cells["品號"].Value.ToString();
                frmBOMPrice.rstrButton = "Export";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getExport" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                getExport();
            }
        }

        private void frmBOMPrice_Find_Material_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                
                GetInq();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOMPrice_Find_Material_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
