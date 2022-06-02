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
    public partial class frmCustomer_Inq_Country : Form
    {
        public frmCustomer_Inq_Country()
        {
            InitializeComponent();
        }

        private void frmCustomer_Inq_Country_Activated(object sender, EventArgs e)
        {
            lblCount.Text = "";

        }

        private void btnInq_Click(object sender, EventArgs e)   //搜尋
        {
            //搜尋
            string strSQL = "";
            DataTable dt;
            strSQL = $@"select   cus_name,
                                 cus_id,
                                 cus_contact,
                                 cus_tel
                        from     cus
                        where    cus_gb like'%{cboCountry.Text.Trim()}%'";
            string strTmp1 = "";
            if (chkDeal.Checked == false)
            {
                strTmp1 = " order by cus_name";
            }
            else
            {
                strTmp1 = " and cus_id in (select distinct odh_customer from odh) order by cus_name";
            }
            strSQL = strSQL + strTmp1;
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dgvData.DataSource = dt;
            }
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

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                frmCustomer.strCustomerID = dgvData.Rows[e.RowIndex].Cells["cus_id"].Value.ToString();
                this.Close();
            }
        }
    }
}
