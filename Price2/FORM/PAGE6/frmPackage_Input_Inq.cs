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
    public partial class frmPackage_Input_Inq : Form
    {
        public static string rstrCustomerID = "";   //客號
        public static string rstrCustomer = "";   //客戶
        public frmPackage_Input_Inq()
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("產品號資料清單", dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Click(object sender, EventArgs e)
        {
            //搜尋
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
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標

                strSQL = $@"select distinct odi_customerid'產品號',
                                            odi_zx        '材積',
                                            odi_xz        '箱量',
                                            odi_jz        '淨重',
                                            odi_mz        '毛重',
                                            odi_customer  '客戶',
                                            odi_line      '線路',
                                            odi_cjuser    '用戶',
                                            odi_cjadddate '儲存日期'
                            from   odi
                            where  odi_customerid like'%{txtCustomerID.Text.Trim()}%'
                                   and odi_customer like'%{txtCustomer.Text.Trim()}%' ";
                
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
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                frmPackage_Input.rstrCustomerID = dgvData.Rows[e.RowIndex].Cells["產品號"].Value.ToString();
                frmPackage_Input.rstrZX = dgvData.Rows[e.RowIndex].Cells["材積"].Value.ToString();
                frmPackage_Input.rstrXZ = dgvData.Rows[e.RowIndex].Cells["箱量"].Value.ToString();
                frmPackage_Input.rstrJZ = dgvData.Rows[e.RowIndex].Cells["淨重"].Value.ToString();
                frmPackage_Input.rstrMZ = dgvData.Rows[e.RowIndex].Cells["毛重"].Value.ToString();
                frmPackage_Input.rstrCustomer = dgvData.Rows[e.RowIndex].Cells["客戶"].Value.ToString();
                frmPackage_Input.rstrLine = dgvData.Rows[e.RowIndex].Cells["線路"].Value.ToString();
                frmPackage_Input.rstrUser = dgvData.Rows[e.RowIndex].Cells["用戶"].Value.ToString();
                frmPackage_Input.rstrDate = dgvData.Rows[e.RowIndex].Cells["儲存日期"].Value.ToString();

                this.Close();
            }
        }

        private void frmPackage_Input_Inq_Load(object sender, EventArgs e)
        {
            txtCustomerID.Text = rstrCustomerID;
            txtCustomer.Text = rstrCustomer;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //要求新增清除鍵
            txtCustomer.Text = "";
            txtCustomerID.Text = "";

            if (dgvData.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)dgvData.DataSource;
                dt.Rows.Clear();
                dgvData.DataSource = dt;
            }
        }
    }
}
