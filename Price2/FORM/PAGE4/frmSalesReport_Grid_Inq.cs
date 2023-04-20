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
    public partial class frmSalesReport_Grid_Inq : Form
    {
        public static string rstrSQL = "";  //傳來的SQL語法
        public frmSalesReport_Grid_Inq()
        {
            InitializeComponent();
        }

        private void frmSalesReport_Grid_Inq_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {

                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = rstrSQL;
                dt=clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0 )
                {
                    dgvData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmSpecialExpenes_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
