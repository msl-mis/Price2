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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Price2
{
    public partial class frmQuotation : Form
    {

        public static string rstrQuotation = "";

        string delivedate = "";
        string customername = "";
        string delivery = "";
        string shipmark = "";
        string po = "";
        string zm1 = "";
        string zm2 = "";
        string zm3 = "";
        string cm = "";
        public frmQuotation()
        {
            InitializeComponent();
        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtQuotationID.Focus();
            }
        }

        private void txtCustomer_Leave(object sender, EventArgs e)
        {
            txtCustomer.Text = txtCustomer.Text.Trim();
            getData_Customer();
        }

        private void getData_Customer()
        {
            try
            {
                if(txtCustomer.Text == "") 
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select odi_customerid,
                                   odi_line
                            from   odi
                            where  odi_customer = '{txtCustomer.Text.Trim()}'
                                   and odi_customerid in (select distinct pri_customerid
                                                          from   pri
                                                          where  pri_newcostchk like 'N%')
                            order  by odi_customerid ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvProduct.DataSource = dt;
                    lblCount.Text = dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData_Proofing" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuotation_Inq_Click(object sender, EventArgs e)
        {
            //查詢報價單
            try
            {
                frmQuotation_Inq frmQuotation_Inq = new frmQuotation_Inq();
                frmQuotation_Inq.ShowInTaskbar = false;//圖示不顯示在工作列
                frmQuotation_Inq.rstrCustomer = txtCustomer.Text.Trim();
                frmQuotation_Inq.rstrQuotation = txtQuotationID.Text.Trim();
                frmQuotation_Inq.ShowDialog();
                if (rstrQuotation != "")
                {
                    txtQuotationID.Text = rstrQuotation;
                    getData_Quotation();
                }
                rstrQuotation = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnProofing_Inq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData_Quotation()
        {
            if (txtQuotationID.Text == "" || txtQuotationID.Text == "Q")
            {
                return;
            }
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select * from pdh where pdh_orderid = '{txtQuotationID.Text.Trim()}'";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count == 0)
            {
                strSQL = $@"select * from dyh where dyh_orderid = '{txtQuotationID.Text.Trim()}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("這個單號已被打樣單所用,請重新分配一個訂單號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (MessageBox.Show("並沒有找到該訂單資料,你希望創建一個新訂單資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                txtQuotationID.Text = dt.Rows[0]["pdh_orderid"].ToString();
                txtQuotationDate.Text = Convert.ToDateTime(dt.Rows[0]["pdh_orderdate"]).ToString("yyyy/MM/dd");

                delivedate = dt.Rows[0]["pdh_delivedate"].ToString(); ;
                customername = dt.Rows[0]["pdh_customername"].ToString(); ;
                delivery = dt.Rows[0]["pdh_delivery"].ToString(); ;
                shipmark = dt.Rows[0]["pdh_shipmark"].ToString(); ;
                po = dt.Rows[0]["pdh_po"].ToString(); ;
                zm1 = dt.Rows[0]["pdh_zm1"].ToString(); ;
                zm2 = dt.Rows[0]["pdh_zm2"].ToString(); ;
                zm3 = dt.Rows[0]["pdh_zm3"].ToString(); ;
                cm = dt.Rows[0]["pdh_cm"].ToString(); ;


                txtCustomer.Text = dt.Rows[0]["pdh_customer"].ToString();
                txtSign.Text = dt.Rows[0]["pdh_sign"].ToString();
                lblUser.Text = dt.Rows[0]["pdh_username"].ToString();
                lblSaveDate.Text = dt.Rows[0]["pdh_adddate"].ToString();
                strSQL = $@"select prd_assy 產品編號, prd_price 價格 from prd where prd_orderid = '{txtQuotationID.Text.Trim()}'";
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
                        dgvData.Rows[i].Cells["價格"].Value = dt.Rows[i]["價格"].ToString();
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
            if (dgvProduct.CurrentRow != null)
            {
                //檢查重複選擇
                int iCount = 0;
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    if (dgvData.Rows[i].Cells["產品編號"].Value == dgvProduct.Rows[dgvProduct.CurrentRow.Index].Cells["odi_customerid"].Value.ToString())
                    {
                        iCount++;
                    }
                }
                if (iCount > 0)
                {
                    MessageBox.Show("產品編號重複!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //datagridview加入欄位
                int index = dgvData.Rows.Count;
                dgvData.Rows.Add();
                dgvData.Rows[index].Cells["產品編號"].Value = dgvProduct.Rows[dgvProduct.CurrentRow.Index].Cells["odi_customerid"].Value.ToString();
                string strSQL = "";
                DataTable dt = new DataTable();
                if(txtCustomer.Text.Length > 1)
                {
                    if (txtCustomer.Text.Substring(0, 2) == "4-")
                    {
                        strSQL = $@"select odi_pricost as price from odi where odi_customerid = '{dgvProduct.Rows[dgvProduct.CurrentRow.Index].Cells["odi_customerid"].Value.ToString()}' ";
                    }
                    else
                    {
                        strSQL = $@"select odi_price as price from odi where odi_customerid = '{dgvProduct.Rows[dgvProduct.CurrentRow.Index].Cells["odi_customerid"].Value.ToString()}' ";
                    }
                }
                else
                {
                    strSQL = $@"select odi_price as price from odi where odi_customerid = '{dgvProduct.Rows[dgvProduct.CurrentRow.Index].Cells["odi_customerid"].Value.ToString()}' ";
                }
                
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count>0)
                {
                    dgvData.Rows[index].Cells["價格"].Value = dt.Rows[0]["price"].ToString();
                }
            }
        }

        private void txtQuotationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInq.Focus();
            }
        }

        private void txtQuotationID_Leave(object sender, EventArgs e)
        {
            getData_Quotation();
        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                getSelect();
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                
                frmBOMPrice frmBOMPrice = new frmBOMPrice();
                frmBOMPrice.rstrID = dgvData.Rows[dgvData.CurrentRow.Index].Cells["產品編號"].Value.ToString();
                frmBOMPrice.ShowInTaskbar = false;//圖示不顯示在工作列
                frmBOMPrice.ShowDialog();
                getData_Quotation();
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

        private void btnNote_Click(object sender, EventArgs e)
        {
            //選取備註
            try
            {
                frmQuotation_Note frmQuotation_Note = new frmQuotation_Note();
                frmQuotation_Note.ShowInTaskbar = false;//圖示不顯示在工作列
                frmQuotation_Note.ShowInTaskbar = false;
                frmQuotation_Note.rstrCustomer = txtCustomer.Text.Trim();
                frmQuotation_Note.rstrQuotation = txtQuotationID.Text.Trim();
                frmQuotation_Note.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnNote_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //複製
            try
            {
                if (txtQuotationID.Text == "" || txtQuotationID.Text == "S")
                {
                    MessageBox.Show("你沒有輸入任何一個訂單號，不能複製!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //確認權限
                if (clsGlobal.checkRightFlag("客戶報價單複製") == false)
                {
                    MessageBox.Show("您沒有客戶報價單複製權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                InputBox input = new InputBox();
                input.ShowInTaskbar = false;//圖示不顯示在工作列
                input.lblInfo.Text = "輸入需要複製到的新報價單編號:";
                input.Text = "複製報價單";

                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (input.GetMsg() != "")
                    {
                        string strSQL = "";
                        DataTable dt = new DataTable();
                        strSQL = $@"select * from pdh where pdh_orderid = '{input.GetMsg()}'";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("你輸入的報價單資料已經存在，不能夠被複製!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            strSQL = $@"exec prd_copy '{txtQuotationID.Text.Trim()}', '{input.GetMsg().Trim()}' ";
                            txtQuotationID.Text = input.GetMsg().Trim();
                            txtQuotationID.Focus();
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

        private void btnInq_Click(object sender, EventArgs e)
        {
            //查詢
            try
            {
                frmQuotation_Inq frmQuotation_Inq = new frmQuotation_Inq();
                frmQuotation_Inq.ShowInTaskbar = false;//圖示不顯示在工作列
                frmQuotation_Inq.rstrCustomer = txtCustomer.Text.Trim();
                frmQuotation_Inq.rstrQuotation = txtQuotationID.Text.Trim();
                frmQuotation_Inq.ShowDialog();
                if (rstrQuotation != "")
                {
                    txtQuotationID.Text = rstrQuotation;
                    getData_Quotation();
                }
                rstrQuotation = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnProofing_Inq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                if (txtQuotationID.Text == "" || txtQuotationID.Text == "Q")
                {
                    return;
                }

                //確認權限
                if (clsGlobal.checkRightFlag("客戶報價單刪除") == false)
                {
                    MessageBox.Show("您沒有客戶報價單刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("你確定要刪除該報價單的全部資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();

                    strSQL = $@"delete prd where prd_orderid = '{txtQuotationID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete pdh where pdh_orderid = '{txtQuotationID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete odt where odt_orderid = '{txtQuotationID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete sbz where sbz_orderid = '{txtQuotationID.Text.Trim()}' ";
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                txtCustomer.Text = "";
                txtQuotationDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtQuotationID.Text = "Q";
                txtSign.Text = "";
                lblUser.Text = "";
                lblSaveDate.Text = "";
                lblCount.Text = "";

                delivedate = "";
                customername = "";
                delivery = "";
                shipmark = "";
                po = "";
                zm1 = "";
                zm2 = "";
                zm3 = "";
                cm = "";
                //清除dgvProduct
                if (dgvProduct.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvProduct.DataSource;
                    dt.Rows.Clear();
                    dgvProduct.DataSource = dt;
                }
                //清除dgvData
                dgvData.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                if (txtQuotationID.Text == "" || txtQuotationID.Text == "Q")
                {
                    return;
                }

                //確認權限
                if (clsGlobal.checkRightFlag("客戶報價單儲存") == false)
                {
                    MessageBox.Show("您沒有客戶報價單儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select ois_orderid from ois where ois_issueqty<>0 and ois_orderid = '{txtQuotationID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count>0)
                {
                    MessageBox.Show("這個報價單已經有發料記錄,你不能儲存!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("你確定要儲存嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //strSQL = $@"exec prd_save
                    //              '{txtQuotationID.Text.Trim()}',
                    //              '{txtQuotationDate.Text.Trim()}',
                    //              '{delivedate}',
                    //              '{txtCustomer.Text.Trim()}',
                    //              '{customername}',
                    //              '{delivery}',
                    //              '{shipmark}',
                    //              '{txtSign.Text.Trim()}',
                    //              '{po}', '{zm1}', '{zm2}', '{zm3}', '{cm}' ";
                    //clsDB.Execute(strSQL);

                    strSQL = $@"delete prd where prd_orderid = '{txtQuotationID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"select * from pdh where pdh_orderid = '{txtQuotationID.Text.Trim()}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count == 0)
                    {
                        strSQL = $@"insert pdh
                                           (pdh_orderid,
                                            pdh_orderdate,
                                            pdh_delivedate,
                                            pdh_customer,
                                            pdh_customername,
                                            pdh_delivery,
                                            pdh_shipmark,
                                            pdh_sign,
                                            pdh_po,
                                            pdh_zm1,
                                            pdh_zm2,
                                            pdh_zm3,
                                            pdh_cm)
                                    values('{txtQuotationID.Text.Trim()}',
                                           '{txtQuotationDate.Text.Trim()}',
                                           '{delivedate}',
                                           '{txtCustomer.Text.Trim()}',
                                           '{customername}',
                                           '{delivery}',
                                           '{shipmark}',
                                           '{txtSign.Text.Trim()}',
                                           '{po}',
                                           '{zm1}',
                                           '{zm2}',
                                           '{zm3}',
                                           '{cm}') ";
                        clsDB.Execute(strSQL);
                    }
                    else
                    {
                        strSQL = $@"update pdh
                                    set    pdh_orderdate = '{txtQuotationDate.Text.Trim()}',
                                           pdh_delivedate = '{delivedate}',
                                           pdh_customer = '{txtCustomer.Text.Trim()}',
                                           pdh_customername = '{customername}',
                                           pdh_delivery = '{delivery}',
                                           pdh_shipmark = '{shipmark}',
                                           pdh_sign = '{txtSign.Text.Trim()}',
                                           pdh_po = '{po}',
                                           pdh_zm1 = '{zm1}',
                                           pdh_zm2 = '{zm2}',
                                           pdh_zm3 = '{zm3}',
                                           pdh_cm = '{cm}'
                                    where  pdh_orderid = '{txtQuotationID.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                    }

                    strSQL = $@"update pdh
                                set    pdh_username = wus_username
                                from   pdh,
                                       wus
                                where  pdh_orderid = '{txtQuotationID.Text.Trim()}'
                                       and wus_computername = Host_name() ";
                    clsDB.Execute(strSQL);

                    //將grid新增到prd
                    for (int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        strSQL = $@"select odi_czf, odi_czfpi from odi where odi_customerid = '{dgvData.Rows[i].Cells["產品編號"].Value.ToString()}' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            strSQL = $@"insert prd
                                           (prd_orderid,
                                            prd_assy,
                                            prd_qty,
                                            prd_customer,
                                            prd_cz,
                                            prd_czfpi,
                                            prd_yf,
                                            prd_yftype)
                                    values('{txtQuotationID.Text.Trim()}',
                                           '{dgvData.Rows[i].Cells["產品編號"].Value.ToString()}',
                                           '{dgvData.Rows[i].Cells["數量"].Value.ToString()}',
                                           '{txtCustomer.Text.Trim()}',
                                           '{dt.Rows[0]["odi_czf"].ToString()}',
                                           '{dt.Rows[0]["odi_czfpi"].ToString()}',
                                           0,
                                           '') ";
                            clsDB.Execute(strSQL);
                        }
                    }

                    strSQL = $@"update prd
                                set    prd_price = odi_price,
                                       prd_wg = odi_wg,
                                       prd_vendorid = odi_vendorid,
                                       prd_mo = odi_mo
                                from   prd,
                                       odi
                                where  prd_orderid = '{txtQuotationID.Text.Trim()}'
                                       and prd_assy = odi_customerid ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update prd
                                set    prd_price = pri_pricost
                                from   prd,
                                       pri,
                                       pdh
                                where  prd_assy = pri_customerid
                                       and prd_orderid = '{txtQuotationID.Text.Trim()}'
                                       and ( pdh_customer = '4'
                                              or Substring(pdh_customer, 1, 2) = '4-' )
                                       and pdh_orderid = prd_orderid ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"select * from odt where odt_orderid = '{txtQuotationID.Text.Trim()}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count == 0)
                    {
                        strSQL = $@"insert odt(odt_orderid) values('{txtQuotationID.Text.Trim()}') ";
                        clsDB.Execute(strSQL);
                    }

                    strSQL = $@"update pdh set pdh_adddate = getdate() where pdh_orderid = '{txtQuotationID.Text.Trim()}' ";
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
                if (txtQuotationID.Text == "" || txtQuotationID.Text == "Q")
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select *
                            from   pdh,
                                   prd,
                                   odi,
                                   odt,
                                   cus
                            where  pdh_orderid = prd_orderid
                                   and prd_assy = odi_customerid
                                   and pdh_orderid = odt_orderid
                                   and pdh_customer = cus_id
                                   and pdh_orderid = '{txtQuotationID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "quotation";

                    frmReport.strRP[0] = dt.Rows[0]["cus_name"].ToString();
                    frmReport.strRP[1] = dt.Rows[0]["pdh_orderid"].ToString();
                    frmReport.strRP[2] = Convert.ToDateTime( dt.Rows[0]["pdh_orderdate"]).ToString("yyyy/MM/dd");
                    frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempinbz"].ToString()) ? "" : dt.Rows[0]["odt_tempinbz"].ToString());
                    frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempoutbz"].ToString()) ? "" : dt.Rows[0]["odt_tempoutbz"].ToString());
                    frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["pdh_bz"].ToString()) ? "" : dt.Rows[0]["pdh_bz"].ToString());
                    frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["pdh_sign"].ToString()) ? "" : dt.Rows[0]["pdh_sign"].ToString());
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
    }
}
