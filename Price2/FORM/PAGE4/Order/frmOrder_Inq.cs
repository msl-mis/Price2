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
    public partial class frmOrder_Inq : Form
    {
        public static string rstrOrderID = "";   //傳來的訂單編號
        public static string rstrCustomer = "";   //傳來的客戶
        public frmOrder_Inq()
        {
            InitializeComponent();
        }

        private void btnInq_Click(object sender, EventArgs e)
        {
            //查詢
            try
            {
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                if (txtDate_E.Text != "" && txtDate_S.Text != "")
                {
                    if (Convert.ToDateTime(txtDate_S.Text) > Convert.ToDateTime(txtDate_E.Text))
                    {
                        MessageBox.Show("起始日期不可以大於結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        return;
                    }
                }

                string strSQL = "";
                DataTable dt = new DataTable();
                //strSQL = $@"select a.odh_customer                '客戶',
                //               a.odh_orderid                 '訂單編號',
                //               dbo.Formatstr(b.nmqty, 0)     '一般訂單',
                //               dbo.Formatstr(b.wgqty, 0)     '外購訂單',
                //               dbo.Formatstr(b.dyqty, 0)     '電源訂單',
                //               dbo.Formatstr(b.fiber_qty, 0) '光纖訂單',
                //               dbo.Formatstr(b.gcqty, 0)     '晶元訂單',
                //               dbo.Formatstr(b.gpqty, 0)     '成朋訂單',
                //               a.odh_orderdate               '訂單日期'
                //        from   odh a,
                //               ordqty b
                //        where  a.odh_orderid = b.odh_orderid ";
                strSQL = $@"select a.odh_customer                '客戶',
                               a.odh_orderid                 '訂單編號',
                               b.nmqty     '一般訂單',
                               b.wgqty     '外購訂單',
                               b.dyqty     '電源訂單',
                               b.fiber_qty '光纖訂單',
                               b.gcqty     '晶元訂單',
                               b.gpqty     '成朋訂單',
                               a.odh_orderdate               '訂單日期'
                        from   odh a,
                               ordqty b
                        where  a.odh_orderid = b.odh_orderid ";
                strSQL = strSQL + Get_strWhere() + "order by a.odh_customer, a.odh_orderid ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    //dgvData.DataSource = dt;
                    dgvData.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvData.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5], dt.Rows[i][6], dt.Rows[i][7], Convert.ToDateTime(dt.Rows[i][8]).ToString("yyyy/MM/dd"));
                    }
                    dgvData.Rows.Add();
                    dgvData.Rows[dgvData.Rows.Count - 1].Cells["訂單編號"].Value = "Total:";
                    dgvData.Rows[dgvData.Rows.Count - 1].Cells["一般訂單"].Value = dt.Compute("Sum(一般訂單)", null).ToString();
                    dgvData.Rows[dgvData.Rows.Count - 1].Cells["外購訂單"].Value = dt.Compute("Sum(外購訂單)", null).ToString();
                    dgvData.Rows[dgvData.Rows.Count - 1].Cells["電源訂單"].Value = dt.Compute("Sum(電源訂單)", null).ToString();
                    dgvData.Rows[dgvData.Rows.Count - 1].Cells["光纖訂單"].Value = dt.Compute("Sum(光纖訂單)", null).ToString();
                    dgvData.Rows[dgvData.Rows.Count - 1].Cells["晶元訂單"].Value = dt.Compute("Sum(晶元訂單)", null).ToString();
                    dgvData.Rows[dgvData.Rows.Count - 1].Cells["成朋訂單"].Value = dt.Compute("Sum(成朋訂單)", null).ToString();
                    
                    lblCount.Text = "共：" + dt.Rows.Count.ToString() + "筆";
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
                else
                {
                    //dgvData.DataSource = dt;
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Get_strWhere()
        {
            string strWhere = "";
            //訂單編號
            strWhere = strWhere + (txtOrderID.Text=="" ? "" : $@"and a.odh_orderid like '%{txtOrderID.Text}%' ");
            //客戶
            strWhere = (txtCustomer.Text=="" ? "" : (txtCustomer.Text == "4-" ? "and a.odh_customer like '%4-%' " : (txtCustomer.Text == "4" ? "and (a.odh_customer = '4' or substring(a.odh_customer,1,2) = '4-') " : $@"and a.odh_customer = '{txtCustomer.Text.Trim()}' ")));
            //新增日期
            strWhere = strWhere + (txtDate_S.Text=="" ? "" : $@"and a.odh_newdate between '{txtDate_S.Text}' and '{txtDate_E.Text}' ");
            
            return strWhere;
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

        private void txtDate_S_Click(object sender, EventArgs e)
        {
            if (txtDate_S.Text == "")
            {
                txtDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtDate_E_Click(object sender, EventArgs e)
        {
            if (txtDate_E.Text == "")
            {
                txtDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                txtOrderID.Text = "";
                txtCustomer.Text = "";
                txtDate_E.Text = "";
                txtDate_S.Text = "";
                dgvData.Rows.Clear();   
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                if (clsGlobal.checkRightFlag("訂單刪除") == false)
                {
                    MessageBox.Show("你沒有訂單刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show(this, "你確定要刪除該訂單嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    strSQL = $@"delete ord where ord_orderid ='{dgvData.Rows[dgvData.CurrentRow.Index].Cells["訂單編號"].Value.ToString()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete odh where odh_orderid ='{dgvData.Rows[dgvData.CurrentRow.Index].Cells["訂單編號"].Value.ToString()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete odt where odt_orderid ='{dgvData.Rows[dgvData.CurrentRow.Index].Cells["訂單編號"].Value.ToString()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete sbz where sbz_orderid ='{dgvData.Rows[dgvData.CurrentRow.Index].Cells["訂單編號"].Value.ToString()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete odc where odc_orderid ='{dgvData.Rows[dgvData.CurrentRow.Index].Cells["訂單編號"].Value.ToString()}' ";
                    clsDB.Execute(strSQL);

                    MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnInq.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            //全部刪除
            try
            {
                if (clsGlobal.checkRightFlag("訂單刪除全部") == false)
                {
                    MessageBox.Show("你沒有訂單刪除全部權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show(this, "你確定要刪除符合這些條件的所有訂單嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    for (int i = 0; i < dgvData.Rows.Count-1; i++)
                    {
                        strSQL = $@"delete ord where ord_orderid ='{dgvData.Rows[i].Cells["訂單編號"].Value.ToString()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete odh where odh_orderid ='{dgvData.Rows[i].Cells["訂單編號"].Value.ToString()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete odt where odt_orderid ='{dgvData.Rows[i].Cells["訂單編號"].Value.ToString()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete sbz where sbz_orderid ='{dgvData.Rows[i].Cells["訂單編號"].Value.ToString()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete odc where odc_orderid ='{dgvData.Rows[i].Cells["訂單編號"].Value.ToString()}' ";
                        clsDB.Execute(strSQL);
                    }
                    

                    MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnInq.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex!= dgvData.Rows.Count-1)
                {
                    frmOrder.rstrOrderID = dgvData.Rows[e.RowIndex].Cells["訂單編號"].Value.ToString();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellDoubleClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmOrder_Inq_Load(object sender, EventArgs e)
        {
            txtDate_S.Text = DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd");
            txtDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }
    }
}
