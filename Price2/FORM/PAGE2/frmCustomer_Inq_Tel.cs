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
    public partial class frmCustomer_Inq_Tel : Form
    {
        public frmCustomer_Inq_Tel()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) //結束
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
            //搜尋
            try
            {
                string strSQL = "";
                DataTable dt;
                strSQL = $@"select cus_id,
                                   cus_name,
                                   cus_contact,
                                   cus_tel,
                                   cus_yw
                            from   cus
                            where  cus_tel like '%{txtTel.Text.Trim()}%'
                                    or cus_tel2 like '%{txtTel.Text.Trim()}%'
                                    or cus_fax like '%{txtTel.Text.Trim()}%'
                                    or cus_fax2 like '%{txtTel.Text.Trim()}%' ";

                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                frmCustomer.strCustomerID = dgvData.Rows[e.RowIndex].Cells["cus_id"].Value.ToString();
                this.Close();
            }
        }

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInq.PerformClick();
            }
        }
    }
}
