using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Price2
{
    public partial class frmComplaintReport_Inq : Form
    {
        public static string rstrSQL = "";  //傳來的SQL語法
        public frmComplaintReport_Inq()
        {
            InitializeComponent();
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

        private void frmComplaintReport_Inq_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {

                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = rstrSQL;
                dt = clsDB.sql_select_dt(strSQL);
                //建立一筆新的DataRow，並且等於新的dt row
                DataRow row = dt.NewRow();

                //指定每個欄位要儲存的資料
                row["工單號"] = "Total:";
                row["工單客訴額(NTD)"] = dt.Compute("Sum([工單客訴額(NTD)])", string.Empty);
                row["工廠累計賠償額(NTD)"] = dt.Compute("Sum([工廠累計賠償額(NTD)])", string.Empty);
                row["工廠累計賠償額(RMB)"] = dt.Compute("Sum([工廠累計賠償額(RMB)])", string.Empty);
                //新增資料至DataTable的dt內
                dt.Rows.Add(row);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmSpecialExpenes_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("工廠累計賠償額明細表", dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
