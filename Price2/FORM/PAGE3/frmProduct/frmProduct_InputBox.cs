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
    public partial class frmProduct_InputBox : Form
    {
        public frmProduct_InputBox()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmProduct.rstrResult = "Cancel";
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmProduct.rstrResult = "OK";
            frmProduct.rstrNo = txtName.Text.Trim();
            frmProduct.rstrVendorID = txtVendor.Text.Trim();
            this.Close();
        }

        private void checkVendor()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select ven_id,ven_currency,ven_shortname from ven where ven_id='{txtVendor.Text.Trim()}'";
            dt=clsDB.sql_select_dt(strSQL);
            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("沒有這個廠商,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVendor.Focus();
            }
            
        }

        private void txtVendor_Leave(object sender, EventArgs e)
        {
            if (txtVendor.Text != "")
            {
                checkVendor();
            }
        }

        private void txtVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkVendor();
            }
        }
    }
}
