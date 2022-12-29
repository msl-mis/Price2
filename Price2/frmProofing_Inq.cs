using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Price2
{
    public partial class frmProofing_Inq : Form
    {
        public static string rstrProofing = "";   //傳來的打樣單
        public static string rstrCustomer = "";   //傳來的客戶
        public frmProofing_Inq()
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

                if (txtDate_E.Text != "" && txtDate_S.Text == "")
                {
                    MessageBox.Show("請選擇起始日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                if (txtDate_E.Text == "" && txtDate_S.Text != "")
                {
                    MessageBox.Show("請選擇結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }

                string strSQL = "";
                DataTable dt = new DataTable();
                if (txtDate_E.Text == "" && txtDate_S.Text == "")
                {
                    strSQL = $@"select distinct dyh_orderid'打樣單號',
                                                dyh_customer'客戶',
                                                dyh_orderdate'打樣日期',
                                                dyh_delivedate '交期'
                                from            dyh
                                where           dyh_orderid like'%{txtProofing.Text.Trim()}%' "
                                +(txtCustomer.Text.Trim()==""? "" : $@"and dyh_customer = '{txtCustomer.Text.Trim()}' ")
                                + $@"order by        dyh_orderdate desc,
                                                dyh_orderid desc  ";
                }
                else
                {
                    string strDate_S = txtDate_S.Text + " 00:00:00";
                    string strDate_E = txtDate_E.Text + " 23:59:59";
                    strSQL = $@"select distinct dyh_orderid'打樣單號',
                                                dyh_customer'客戶',
                                                dyh_orderdate'打樣日期',
                                                dyh_delivedate '交期'
                                from            dyh
                                where           dyh_orderid like'%{txtProofing.Text.Trim()}%' "
                                + (txtCustomer.Text.Trim() == "" ? "" : $@"and dyh_customer = '{txtCustomer.Text.Trim()}' ")
                                + $@"and             dyh_orderdate between '{strDate_S}' and '{strDate_E}'
                                order by        dyh_orderdate desc,
                                                dyh_orderid desc  ";
                }
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    lblCount.Text = "共：" + dt.Rows.Count.ToString() + "筆";
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
                else
                {
                    dgvData.DataSource = dt;
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

        private void frmProofing_Inq_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                txtProofing.Text = rstrProofing;
                txtCustomer.Text = rstrCustomer;
                btnInq.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmProofing_Inq_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProofing.Text = "S";
            txtCustomer.Text = "";
            txtDate_E.Text = "";
            txtDate_S.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                if (clsGlobal.checkRightFlag("打樣單編號查詢刪除") == false)
                {
                    MessageBox.Show("你沒有打樣單編號查詢刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show(this, "你確定要刪除打樣單["+ dgvData.Rows[dgvData.CurrentRow.Index].Cells["打樣單號"].Value.ToString() + "]?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = $@"delete dyi
                                       from   dyi,
                                              dyd
                                       where  dyi_id = dyd_assy
                                              and dyd_orderid = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["打樣單號"].Value.ToString()}'
                                              and dyi_id not in (select distinct dyd_assy
                                                                   from   dyd
                                                                  where   dyd_orderid <> '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["打樣單號"].Value.ToString()}')  ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete dyd where dyd_orderid='{dgvData.Rows[dgvData.CurrentRow.Index].Cells["打樣單號"].Value.ToString()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete dyh where dyh_orderid='{dgvData.Rows[dgvData.CurrentRow.Index].Cells["打樣單號"].Value.ToString()}' ";
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

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    frmProofing.rstrProofing= dgvData.Rows[e.RowIndex].Cells["打樣單號"].Value.ToString();
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
