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
    public partial class frmExangeRate_History : Form
    {
        public static string rstrCode = "";
        public frmExangeRate_History()
        {
            InitializeComponent();
        }

        private void frmExangeRate_History_Load(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select cum_code        '幣種',
                               cum_convert     '匯率',
                               cum_adddate     '修改日期',
                               cum_username    '用戶',
                               cum_computername'電腦'
                        from   cum
                        where  cum_code = '{rstrCode}'
                        order  by cum_adddate desc ";
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
