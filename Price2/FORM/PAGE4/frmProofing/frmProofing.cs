using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Price2
{
    public partial class frmProofing : Form
    {
        string strCustomerName;
        public static string rstrProofing="";
        public frmProofing()
        {
            InitializeComponent();
        }

        private void frmProofing_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                txtProofingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                strCustomerName = "";
                String strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select distinct pas_username,pas_name from pas where pas_ywcode <> '' ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboSales.Items.Add(dt.Rows[i]["pas_username"].ToString());
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmProofing_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmProofing_Activated(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                txtProofingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmProofing_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtDeliveryDate.Focus();
            }
        }

        private void txtCustomer_Leave(object sender, EventArgs e)
        {
            if(txtCustomer.Text=="")
            {
                return;
            }
            String strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select * from cus where cus_id = '{ txtCustomer.Text.Trim() }' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strCustomerName = dt.Rows[0]["cus_name"].ToString();
                cboSales.Text = dt.Rows[0]["cus_yw"].ToString();
            }
            else
            {
                strCustomerName = "";
                cboSales.Text = "";
            }

            getData_Customer();
        }

        private void getData_Customer()
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select dyi_id, dyi_line from dyi where dyi_active=0 and dyi_czf<>'' and dyi_customer = '{txtCustomer.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvProofing.DataSource = dt;
                    lblCount.Text = dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData_Proofing" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProofing_Inq_Click(object sender, EventArgs e)
        {
            //查詢打樣單
            try
            {
                frmProofing_Inq frmProofing_Inq = new frmProofing_Inq();
                frmProofing_Inq.ShowInTaskbar = false;//圖示不顯示在工作列
                frmProofing_Inq.rstrCustomer = txtCustomer.Text.Trim();
                frmProofing_Inq.rstrProofing = txtProofing.Text.Trim();
                frmProofing_Inq.ShowDialog();
                if (rstrProofing != "")
                {
                    txtProofing.Text = rstrProofing;
                    getData_Proofing();
                }
                rstrProofing = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnProofing_Inq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProofing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDeliveryDate.Focus();
            }
        }

        private void txtProofing_Leave(object sender, EventArgs e)
        {
            getData_Proofing();
        }

        private void getData_Proofing()
        {
            if (txtProofing.Text == "" || txtProofing.Text == "S")
            {
                return;
            }
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select * from dyh where dyh_orderid = '{txtProofing.Text.Trim()}'";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count == 0)
            {
                strSQL = $@"select * from odh where odh_orderid = '{txtProofing.Text.Trim()}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("這個單號已被工作單所用,請重新分配一個打樣單號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (MessageBox.Show("並沒有找到該打樣單資料,你希望創建一個新打樣單嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                txtProofing.Text = dt.Rows[0]["dyh_orderid"].ToString();
                txtProofingDate.Text = Convert.ToDateTime(dt.Rows[0]["dyh_orderdate"]).ToString("yyyy/MM/dd");
                txtDeliveryDate.Text = dt.Rows[0]["dyh_delivedate"].ToString();
                txtCustomer.Text = dt.Rows[0]["dyh_customer"].ToString();
                cboSales.Text = dt.Rows[0]["dyh_sign"].ToString();
                strSQL = $@"select dyd_assy 產品編號, dyd_qty 數量 from dyd where dyd_orderid = '{txtProofing.Text.Trim()}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    //dgvData.DataSource = dt;
                    //清除GRID
                    dgvData.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvData.Rows.Add();
                        dgvData.Rows[i].Cells["產品編號"].Value = dt.Rows[i]["產品編號"].ToString();
                        dgvData.Rows[i].Cells["數量"].Value = dt.Rows[i]["數量"].ToString();
                        
                    }
                }
                getData_Customer();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            getSelect();
        }

        private void getSelect()
        {
            if(dgvProofing.CurrentRow != null)
            {
                //檢查重複選擇
                int iCount = 0;
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    if (dgvData.Rows[i].Cells["產品編號"].Value == dgvProofing.Rows[dgvProofing.CurrentRow.Index].Cells["dyi_id"].Value.ToString())
                    {
                        iCount++;
                    }
                }
                if(iCount>0)
                {
                    MessageBox.Show("產品編號重複!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                //datagridview加入欄位
                int index = dgvData.Rows.Count;
                dgvData.Rows.Add();
                dgvData.Rows[index].Cells["產品編號"].Value = dgvProofing.Rows[dgvProofing.CurrentRow.Index].Cells["dyi_id"].Value.ToString();
                

            }
        }

        private void dgvProofing_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                getSelect();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                txtCustomer.Text = "";
                txtProofingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtProofing.Text = "S";
                txtDeliveryDate.Text = "越快越好";
                cboSales.Text = "";
                //清除dgvProofing
                if (dgvProofing.Rows.Count>0)
                {
                    DataTable dt = (DataTable)dgvProofing.DataSource;
                    dt.Rows.Clear();
                    dgvProofing.DataSource = dt;
                }
                //清除dgvData
                dgvData.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Click(object sender, EventArgs e)
        {
            //查詢
            try
            {
                frmProofing_Inq frmProofing_Inq = new frmProofing_Inq();
                frmProofing_Inq.ShowInTaskbar = false;//圖示不顯示在工作列
                frmProofing_Inq.ShowInTaskbar = false;
                frmProofing_Inq.rstrCustomer = txtCustomer.Text.Trim();
                frmProofing_Inq.rstrProofing = txtProofing.Text.Trim();
                frmProofing_Inq.ShowDialog();
                if (rstrProofing != "")
                {
                    txtProofing.Text = rstrProofing;
                    getData_Proofing();
                }
                rstrProofing = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            //選取備註
            try
            {
                frmProofing_Note frmProofing_Note = new frmProofing_Note();
                frmProofing_Note.ShowInTaskbar = false;//圖示不顯示在工作列
                frmProofing_Note.ShowInTaskbar = false;
                frmProofing_Note.rstrCustomer = txtCustomer.Text.Trim();
                frmProofing_Note.rstrProofing = txtProofing.Text.Trim();
                frmProofing_Note.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnNote_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                if (txtProofing.Text == "" || txtProofing.Text == "S")
                {
                    return;
                }

                //確認權限
                if (clsGlobal.checkRightFlag("打樣單刪除") == false)
                {
                    MessageBox.Show("您沒有打樣單刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("你確定要刪除該打樣單的全部資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    strSQL = $@"delete dyi
                                from   dyi,
                                       dyd
                                where  dyi_id = dyd_assy
                                       and dyd_orderid = '{txtProofing.Text.Trim()}'
                                       and dyi_id not in (select distinct dyd_assy
                                                          from   dyd
                                                          where  dyd_orderid <> '{txtProofing.Text.Trim()}') ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"delete dyd where dyd_orderid = '{txtProofing.Text.Trim()}' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"delete dyh where dyh_orderid = '{txtProofing.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    btnClear_Click(null, null);
                    MessageBox.Show("已經刪除成功!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //複製
            try
            {
                if(txtProofing.Text == "" || txtProofing.Text == "S")
                {
                    MessageBox.Show("你沒有輸入任何一個打樣單號，不能複製!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //確認權限
                if (clsGlobal.checkRightFlag("打樣單複製") == false)
                {
                    MessageBox.Show("您沒有打樣單複製權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                InputBox input = new InputBox();
                input.ShowInTaskbar = false;//圖示不顯示在工作列
                input.lblInfo.Text = "輸入需要複製到的新打樣單編號:";
                input.Text = "複製打樣單";

                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (input.GetMsg() != "")
                    {
                        string strSQL = "";
                        DataTable dt = new DataTable();
                        strSQL = $@"select * from dyh where dyh_orderid = '{input.GetMsg()}'";
                        dt = clsDB.sql_select_dt(strSQL);
                        if(dt.Rows.Count>0)
                        {
                            MessageBox.Show("你輸入的打樣單資料已經存在，不能夠被複製!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            strSQL = $@"exec dyd_copy '{txtProofing.Text.Trim()}', '{input.GetMsg().Trim()}' ";
                            txtProofing.Text = input.GetMsg().Trim();
                            txtProofing.Focus();
                            MessageBox.Show("已經複製完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCopy_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                if (txtProofing.Text == "" || txtProofing.Text == "S")
                {
                    return;
                }

                //確認權限
                if (clsGlobal.checkRightFlag("打樣單儲存") == false)
                {
                    MessageBox.Show("您沒有打樣單儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("你確定要儲存嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    strSQL = $@"exec Dyd_save
                                  '{txtProofing.Text.Trim()}',
                                  '{txtProofingDate.Text.Trim()}',
                                  '{txtDeliveryDate.Text.Trim()}',
                                  '{txtCustomer.Text.Trim()}',
                                  '{strCustomerName.Trim()}',
                                  '',
                                  '',
                                  '{cboSales.Text.Trim()}',
                                  '' ";
                    clsDB.Execute(strSQL);

                    MessageBox.Show("已經儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //預覽列印
            try
            {
                if (txtProofing.Text == "" || txtProofing.Text == "S")
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select *
                            from   dyh,
                                   dyd,
                                    dyi
                            where  dyh_orderid = dyd_orderid
                                    and dyd_assy = dyi_id
                                    and dyh_orderid = '{txtProofing.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0 )
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "proofing";

                    frmReport.strRP[0] = dt.Rows[0]["dyh_orderid"].ToString();
                    frmReport.strRP[1] = dt.Rows[0]["dyh_customer"].ToString();
                    frmReport.strRP[2] = dt.Rows[0]["dyh_sign"].ToString();
                    frmReport.strRP[3] = dt.Rows[0]["dyh_delivedate"].ToString();
                    frmReport.strRP[4] = dt.Rows[0]["dyh_tempbz"].ToString();
                    frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["dyh_bz"].ToString()) ? "" : dt.Rows[0]["dyh_bz"].ToString());
                    frmReport.strSQL = strSQL;
                    frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                    frmReport.ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProofing_Click(object sender, EventArgs e)
        {
            //樣品製作
            try
            {
                //確認權限
                if (clsGlobal.checkRightFlag("打樣單樣品製作") == false)
                {
                    MessageBox.Show("您沒有打樣單樣品製作權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                frmProofing_CZF frmProofing_CZF = new frmProofing_CZF();
                frmProofing_CZF.ShowInTaskbar = false;//圖示不顯示在工作列
                if(dgvData.RowCount>0)
                {
                    if(dgvData.CurrentRow.Index>0)
                    {
                        frmProofing_CZF.rstrProductID = dgvData.Rows[dgvData.CurrentRow.Index].Cells["產品編號"].Value.ToString().Trim();
                    }
                    else
                    {
                        frmProofing_CZF.rstrProductID = dgvData.Rows[0].Cells["產品編號"].Value.ToString().Trim();
                    }
                }
                else
                {
                    frmProofing_CZF.rstrProductID = "";
                }
                frmProofing_CZF.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnProofing_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
