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
    public partial class frmOrder_Note : Form
    {
        public static string rstrOrderID = "";   //傳來的報價單
        public static string rstrCustomer = "";   //傳來的客戶
        public static string rstrType = "";   //傳來的類別
        string strType = "";
        public frmOrder_Note()
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
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select obz_no '備註代碼' from obz where obz_customer = '{txtCustomer.Text.Trim()}' order by obz_no ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    //dgvData.DataSource = dt;
                    //清除GRID
                    dgvData_S.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvData_S.Rows.Add();
                        dgvData_S.Rows[i].Cells["備註代碼"].Value = dt.Rows[i]["備註代碼"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmOrder_Note_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                txtOrderID.Text = rstrOrderID;
                txtCustomer.Text = rstrCustomer;
                if (rstrType=="OUT")
                {
                    radioOut.Checked= true;
                    strType = "OUT";
                }
                else
                {
                    radioIn.Checked = true;
                    strType = "IN";
                }
                getData();

                //取得訂單備註代碼
                String strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select sbz_bzno '備註代碼' from sbz where sbz_orderid = '{txtOrderID.Text}' and sbz_type = '{strType}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvData_R.Rows.Add();
                        dgvData_R.Rows[i].Cells["備註代碼R"].Value = dt.Rows[i]["備註代碼"].ToString();
                    }
                }

                //取得訂單臨時備註
                strSQL = $@"select * from odt where odt_orderid = '{txtOrderID.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    if(strType=="OUT")
                    {
                        txtNote_Tmp.Text = dt.Rows[0]["odt_tempoutbz"].ToString();
                    }
                    else
                    {
                        txtNote_Tmp.Text = dt.Rows[0]["odt_tempinbz"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmOrder_Note_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioOut_CheckedChanged(object sender, EventArgs e)
        {
            if(radioOut.Checked)
            {
                strType = "OUT";
                getData();
                //取得報價單臨時備註
                String strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select * from odt where odt_orderid = '{txtOrderID.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    txtNote_Tmp.Text = dt.Rows[0]["odt_tempoutbz"].ToString();
                }
                else
                {
                    txtNote_Tmp.Text = "";
                }
            }
        }

        private void radioIn_CheckedChanged(object sender, EventArgs e)
        {
            if(radioIn.Checked)
            {
                strType = "IN";
                getData();
                //取得報價單臨時備註
                String strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select * from odt where odt_orderid = '{txtOrderID.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    txtNote_Tmp.Text = dt.Rows[0]["odt_tempinbz"].ToString();
                }
                else
                {
                    txtNote_Tmp.Text = "";
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //選擇
            try
            {
                getSelect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSelect_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getSelect()
        {
            if (dgvData_S.CurrentRow != null)
            {
                //檢查重複選擇
                int iCount = 0;
                for (int i = 0; i < dgvData_R.Rows.Count; i++)
                {
                    if (dgvData_R.Rows[i].Cells["備註代碼R"].Value == dgvData_S.Rows[dgvData_S.CurrentRow.Index].Cells["備註代碼"].Value.ToString())
                    {
                        iCount++;
                    }
                }
                if (iCount > 0)
                {
                    return;
                }

                //datagridview加入欄位
                int index = dgvData_R.Rows.Count;
                dgvData_R.Rows.Add();
                dgvData_R.Rows[index].Cells["備註代碼R"].Value = dgvData_S.Rows[dgvData_S.CurrentRow.Index].Cells["備註代碼"].Value.ToString();
            }
        }

        private void dgvData_S_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    strSQL = $@"select * from obz where obz_no = '{dgvData_S.Rows[e.RowIndex].Cells["備註代碼"].Value.ToString()}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        txtNote.Text = dt.Rows[0]["obz_description"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_S_CellClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_S_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                getSelect();
            }
        }

        private void dgvData_R_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    strSQL = $@"select * from obz where obz_no = '{dgvData_R.Rows[e.RowIndex].Cells["備註代碼R"].Value.ToString()}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        txtNote.Text = dt.Rows[0]["obz_description"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_R_CellClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNote_Manage_Click(object sender, EventArgs e)
        {
            //管理備註代碼
            try
            {
                //確認權限
                if (clsGlobal.checkRightFlag("備註資料輸入") == false)
                {
                    MessageBox.Show("您沒有備註資料輸入權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmProofing_Note_Manage frmProofing_Note_Manage = new frmProofing_Note_Manage();
                frmProofing_Note_Manage.ShowInTaskbar = false;//圖示不顯示在工作列
                frmProofing_Note_Manage.rstrCustomer = txtCustomer.Text.Trim();
                frmProofing_Note_Manage.ShowDialog();
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnNote_Manage_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                getDelete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getDelete()
        {
            //刪除
            try
            {
                //確認權限
                if (clsGlobal.checkRightFlag("訂單備註刪除") == false)
                {
                    MessageBox.Show("您沒有訂單備註刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgvData_R.CurrentRow != null)
                {
                    dgvData_R.Rows.RemoveAt(dgvData_R.CurrentRow.Index);
                    txtNote.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getDelete" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                //確認權限
                if (clsGlobal.checkRightFlag("訂單備註儲存") == false)
                {
                    MessageBox.Show("您沒有訂單備註儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"delete sbz where sbz_orderid = '{txtOrderID.Text.Trim()}' and sbz_type = '{strType}' ";
                clsDB.Execute(strSQL);
                if (dgvData_R.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvData_R.Rows.Count; i++)
                    {
                        strSQL = $@"exec sbz_save '{txtOrderID.Text.Trim()}', '{dgvData_R.Rows[i].Cells["備註代碼R"].Value.ToString().Trim()}', '{strType}' ";
                        clsDB.Execute(strSQL);
                    }
                }

                strSQL = $@"exec ord_calbz '{txtOrderID.Text.Trim()}', '{strType}' ";
                clsDB.Execute(strSQL);

                strSQL = $@"exec odt_save '{strType}, '{txtOrderID.Text.Trim()}', '{txtNote_Tmp.Text.Trim()}' ";
                clsDB.Execute(strSQL);

                MessageBox.Show("已經儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_R_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                getDelete();
            }
        }
    }
}
