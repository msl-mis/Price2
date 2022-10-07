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
    public partial class frmRefer_Inq_Material : Form
    {
        public static string strID = "";
        public frmRefer_Inq_Material()
        {
            InitializeComponent();
        }

        private void frmRefer_Inq_Material_Activated(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {

                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select pri_part   as 材料名項目,
                                   pri_perqty as 數量
                            from   pri
                            where  pri_customerid = '{strID}'
                                   and pri_newcostchk like 'N%' ";
                dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmMain_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    frmRefer.strPartID = dgvData.Rows[e.RowIndex].Cells["材料名項目"].Value.ToString();
                    frmRefer.strQty = dgvData.Rows[e.RowIndex].Cells["數量"].Value.ToString();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellDoubleClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
