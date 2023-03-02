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
    public partial class frmProofingFile : Form
    {
        public frmProofingFile()
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
            //搜尋
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
                string strSQL11 = "";
                string strSQL12 = "";

                DataTable dt = new DataTable();

                strSQL11 = $@"select dyd_orderid '打樣編號',
                                     dyi_id '產品編號',
                                     dyi_mo 'MO',
                                     dyi_czf '參照法',
                                     dyi_line '線路',
                                     dyh_orderdate '打樣日期'
                            from     dyi,
                                     dyd,
                                     dyh
                            where    dyi_active=0
                            and      dyi_id=dyd_assy
                            and      dyd_orderid=dyh_orderid
                            and      dyi_czf<>'' ";

                strSQL12 = $@"order by dyh_orderdate desc,
                                     dyd_orderid,
                                     dyi_id ";


                strSQL = strSQL11 + Get_strWhere() + strSQL12;
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    lblCount.Text = "共 " + dt.Rows.Count.ToString() + " 筆";

                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
                else
                {
                    dgvData.DataSource = dt;
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblCount.Text = "共 0 筆";
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
            
            //打樣日期
            strWhere = strWhere + (txtDate_S.Text == "" ? "" : $@"and dyh_orderdate between '{txtDate_S.Text}' and '{txtDate_E.Text}' ");
            //客戶
            strWhere = strWhere + (txtCustomer.Text == "" ? "" : $@"and dyi_customer = '{txtCustomer.Text.Trim()}' ");
            //線路
            strWhere = strWhere + (txtLine.Text == "" ? "" : $@"and dyi_line like '%{txtLine.Text.Trim()}%' ");
            //打樣編號
            strWhere = strWhere + (txtProofingID.Text == "" ? "" : $@"and dyd_orderid like '%{txtProofingID.Text.Trim()}%' ");
            //客號
            if (txtCustomerID.Text.IndexOf(";") >= 0)//分號多條件搜尋
            {
                string[] str = txtCustomerID.Text.Split(';');
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Trim();
                    strWhere = strWhere + $@"and dyi_id like '%{str[i].Trim()}%' ";
                }
            }
            else
            {
                strWhere = strWhere + (txtCustomerID.Text == "" ? "" : $@"and dyi_id like '%{txtCustomerID.Text.Trim()}%' ");
            }
            //參照法
            if (txtCZF.Text.IndexOf(";") >= 0)//分號多條件搜尋
            {
                string[] str = txtCZF.Text.Split(';');
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Trim();
                    strWhere = strWhere + $@"and dyi_czf like '%{str[i].Trim()}%' ";
                }
            }
            else
            {
                strWhere = strWhere + (txtCZF.Text == "" ? "" : $@"and dyi_czf like '%{txtCZF.Text.Trim()}%' ");
            }

            //已成交
            strWhere = strWhere + (chkDeal.Checked ? "and dyi_id in (select distinct ord_assy from ord) " : "");
            //未成交
            strWhere = strWhere + (chkDeal_Yet.Checked ? "and dyi_id not in (select distinct ord_assy from ord)  " : "");
            
            return strWhere;
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

        private void chkDeal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeal.Checked)
            {
                chkDeal_Yet.Checked = false;
            }
        }

        private void chkDeal_Yet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeal_Yet.Checked)
            {
                chkDeal.Checked = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                //客訴日期
                txtDate_S.Text = "";
                txtDate_E.Text = "";
                //客戶
                txtCustomer.Text = "";
                //線路
                txtLine.Text = "";
                //客號
                txtCustomerID.Text = "";
                //參照法
                txtCZF.Text = "";
                //已成交
                chkDeal.Checked = false;
                //未成交
                chkDeal_Yet.Checked = false;
                //打樣編號
                txtProofingID.Text = "";

                if (dgvData.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)dgvData.DataSource;
                    dt.Rows.Clear();
                    dgvData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("打樣單客人總檔", dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 )
                {
                    MessageBox.Show(dgvData.Rows[e.RowIndex].Cells["參照法"].Value.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("你需要導出該打樣單資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmProofing frmProofing = new frmProofing();
                        frmProofing.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmProofing.rstrProofing = dgvData.Rows[e.RowIndex].Cells["打樣編號"].Value.ToString();
                        frmProofing.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellDoubleClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                if (dgvData.CurrentRow.Index >= 0 )
                {
                    //確認權限
                    if (clsGlobal.checkRightFlag("打樣單刪除") == false)
                    {
                        MessageBox.Show("您沒有打樣單刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        return;
                    }
                    if (MessageBox.Show("你確定要刪除該打樣單嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string strSQL = "";
                        strSQL = $@"delete dyh where dyh_orderid = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["打樣編號"].Value.ToString()}'";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete dyd where dyd_orderid = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["打樣編號"].Value.ToString()}'";
                        clsDB.Execute(strSQL);
                        MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnInq.PerformClick();
                    }
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
                //確認權限
                if (clsGlobal.checkRightFlag("打樣單刪除全部") == false)
                {
                    MessageBox.Show("您沒有打樣單刪除全部權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                if (MessageBox.Show("你確定要刪除全部所查出來的打樣單嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    for (int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        strSQL = $@"delete dyh where dyh_orderid = '{dgvData.Rows[i].Cells["打樣編號"].Value.ToString()}'";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete dyd where dyd_orderid = '{dgvData.Rows[i].Cells["打樣編號"].Value.ToString()}'";
                        clsDB.Execute(strSQL);
                    }
                        
                    MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnInq.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDeleteAll_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
