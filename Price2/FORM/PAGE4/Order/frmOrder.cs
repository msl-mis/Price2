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
    public partial class frmOrder : Form
    {
        public static string rstrOrderID = "";
        public static string rstrButton = "";
        string strPI = "";
        string customername;
        string delivery="";
        string shipmark = "";
        string delivedate1 = "";
        string zm1 = "";
        string zm2 = "";
        string zm3 = "";
        string cm = "";
        int piflag = 2;
        public frmOrder()
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

        private void btnOrder_Inq_Click(object sender, EventArgs e)
        {
            //查詢訂單
            try
            {
                frmOrder_Inq frmOrder_Inq = new frmOrder_Inq();
                frmOrder_Inq.ShowInTaskbar = false;//圖示不顯示在工作列
                frmOrder_Inq.rstrForm = "frmOrder";
                //frmOrder_Inq.rstrOrderID = txtOrderID.Text.Trim();
                frmOrder_Inq.ShowDialog();
                if (rstrOrderID != "")
                {
                    txtOrderID.Text = rstrOrderID;
                    getData_OrderID();
                }
                rstrOrderID = "";
                dgvData.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnOrder_Inq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData_OrderID()
        {
            try
            {
                if (txtOrderID.Text == "")
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select *
                        from   odh,
                               cus
                        where  odh_orderid = '{txtOrderID.Text}'
                               and odh_customer = cus_id ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count == 0)
                {
                    strSQL = $@"select * from dyh where dyh_orderid = '{txtOrderID.Text.Trim()}'";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("這個單號已被打樣單所用,請重新分配一個訂單號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtOrderID.Focus();
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("並沒有找到該訂單資料,你希望創建一個新訂單資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            txtDeliveryDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                            txtNewDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                            txtOrderDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                            txtCustomer.Text = "";
                            cboShippingMark.Text = "N";
                            txtPO.Text = "";
                            txtSign.Text = "";
                            txtQuotationID.Text = "";
                            lblSaveDate.Text = "";
                            lblUser.Text = "";
                            chkOther.Checked = false;
                            chkReplenish.Checked = false;
                            this.Cursor = Cursors.Default;//滑鼠還原預設
                            return;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;//滑鼠還原預設
                            return;
                        }
                    }
                }
                else
                {
                    strSQL = $@"select ois_orderid from ois where ois_issueqty<>0 and ois_orderid = '{txtOrderID.Text.Trim()}'";
                    DataTable dt2 = new DataTable();
                    dt2 = clsDB.sql_select_dt(strSQL);
                    if (dt2.Rows.Count > 0)
                    {
                        MessageBox.Show("這個訂單已經有發料記錄,你將不能儲存!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    strPI = (string.IsNullOrEmpty(dt.Rows[0]["cus_pihead"].ToString()) ? "MSL" : dt.Rows[0]["cus_pihead"].ToString());
                    txtOrderID.Text = dt.Rows[0]["odh_orderid"].ToString();
                    txtOrderDate.Text = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                    //txtDeliveryDate.Text = Convert.ToDateTime(dt.Rows[0]["odh_delivedate"]).ToString("yyyy/MM/dd");
                    txtDeliveryDate.Text = dt.Rows[0]["odh_delivedate"].ToString();
                    txtCustomer.Text = dt.Rows[0]["odh_customer"].ToString();
                    customername = dt.Rows[0]["odh_customername"].ToString();
                    delivery = dt.Rows[0]["odh_delivery"].ToString();
                    shipmark = dt.Rows[0]["odh_shipmark"].ToString();
                    txtSign.Text = dt.Rows[0]["odh_sign"].ToString();
                    txtNewDate.Text = Convert.ToDateTime(dt.Rows[0]["odh_newdate"]).ToString("yyyy/MM/dd");
                    txtPO.Text = dt.Rows[0]["odh_po"].ToString();
                    txtQuotationID.Text = dt.Rows[0]["odh_bjdb"].ToString();
                    delivedate1 = dt.Rows[0]["odh_delivedate1"].ToString();
                    zm1 = dt.Rows[0]["odh_zm1"].ToString();
                    zm2 = dt.Rows[0]["odh_zm2"].ToString();
                    zm3 = dt.Rows[0]["odh_zm3"].ToString();
                    cm = dt.Rows[0]["odh_cm"].ToString();
                    lblSaveDate.Text = Convert.ToDateTime(dt.Rows[0]["odh_adddate"]).ToString("yyyy/MM/dd");
                    lblUser.Text = dt.Rows[0]["odh_username"].ToString();
                    cboShippingMark.Text = dt.Rows[0]["odh_zmtype"].ToString();
                    if (dt.Rows[0]["odh_piother"].ToString() == "0")
                    {
                        chkOther.Checked = false;
                    }
                    else
                    {
                        chkOther.Checked = true;
                    }
                    if (dt.Rows[0]["odh_bh"].ToString() == "0")
                    {
                        chkReplenish.Checked = false;
                    }
                    else
                    {
                        chkReplenish.Checked = true;
                    }

                    strSQL = $@"select ord_assy 產品編號,
                                   ord_qty 數量,
                                   ord_ywcode 業務,
                                   ord_yftype,
                                   ord_price
                            from   ord
                            where  ord_orderid = '{txtOrderID.Text.Trim()}'";
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
                            dgvData.Rows[i].Cells["業務"].Value = dt.Rows[i]["業務"].ToString();
                            dgvData.Rows[i].Cells["na6_yftype"].Value = dt.Rows[i]["ord_yftype"].ToString();
                            dgvData.Rows[i].Cells["na6_price"].Value = dt.Rows[i]["ord_price"].ToString();
                            dgvData.Rows[i].Cells["na6_qty"].Value = dt.Rows[i]["數量"].ToString();
                            dgvData.Rows[i].Cells["na6_qtycal"].Value = dt.Rows[i]["數量"].ToString();
                        }
                    }
                    getData_Customer();
                }
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-getData_OrderID" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOrder_Inq.Focus();
            }
        }

        private void txtOrderID_Leave(object sender, EventArgs e)
        {
            getData_OrderID();
        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOrderID.Focus();
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
                if (txtCustomer.Text == "4" )
                {
                    piflag = 3;
                }
                if (txtCustomer.Text.Length>=2)
                {
                    if (txtCustomer.Text.Substring(0, 2) == "4-")
                    {
                        piflag = 3;
                    }
                }

                if (txtCustomer.Text == "")
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select pas_controluser from pas where pas_username = '{clsGlobal.strG_User}' ";
                dt = clsDB.sql_select_dt(strSQL);
                string userflag = "";
                if (dt.Rows.Count > 0)
                {
                    userflag = dt.Rows[0]["pas_controluser"].ToString();
                }
                else
                {
                    userflag = "";
                }
                
                if (txtCustomer.Text.Substring(0, 1) != "Y" && userflag != "")
                {
                    MessageBox.Show("你不能創建或調用不是以Y開頭的客戶的工單資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                strSQL = $@"select distinct czc_zmtype from czc where czc_customer = '{txtCustomer.Text}' order by czc_zmtype ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    cboShippingMark.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        cboShippingMark.Items.Add(dr[0].ToString());
                    }
                }

                strSQL = $@"select * from czc, cus where cus_id=czc_customer and czc_customer = '{txtCustomer.Text}' and czc_zmtype = 'A' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    customername = dt.Rows[0]["cus_name"].ToString();
                    zm1 = dt.Rows[0]["czc_zm1"].ToString();
                    //zm2 = dt.Rows[0]["czc_zm2"].ToString(); //已經沒有czc_zm2
                    zm3 = dt.Rows[0]["czc_zm3"].ToString(); 
                    cm = dt.Rows[0]["czc_cm"].ToString(); 
                    cboShippingMark.Text = dt.Rows[0]["cus_zmtype"].ToString();
                    strPI = dt.Rows[0]["cus_pihead"].ToString(); 
                }
                else
                {
                    customername = "";
                    zm1 = "";
                    zm2 = "";
                    zm3 = "";
                    cm = "";
                    cboShippingMark.Text = "A";
                    strPI = "MSL";
                }

                //判斷成交否? 0:已成交,1:未成交
                if(chkDeal_Yet.Checked== false) 
                {
                    strSQL = $@"select odi_customerid,
                                       odi_line
                                from   odi
                                where  odi_customer = '{txtCustomer.Text}'
                                       and odi_customerid in (select distinct ord_assy
                                                              from   ord)
                                       and odi_customerid in (select distinct pri_customerid
                                                              from   pri
                                                              where  pri_newcostchk like 'N%')
                                order  by odi_customerid ";
                }
                else
                {
                    strSQL = $@"select odi_customerid,
                                       odi_line
                                from   odi
                                where  odi_customer = '{txtCustomer.Text}'
                                       and odi_customerid not in (select distinct ord_assy
                                                                  from   ord)
                                       and odi_customerid in (select distinct pri_customerid
                                                              from   pri
                                                              where  pri_newcostchk like 'N%')
                                order  by odi_customerid ";
                }
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvProduct.DataSource = dt;
                    lblCount.Text = dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData_Customer" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            //填入
            try
            {
                txtSign.Text = clsGlobal.strG_User;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSign_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPI_Cost_Click(object sender, EventArgs e)
        {
            //成本PI
            try
            {
                if (txtOrderID.Text == "" )
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       bzd,
                                       cus
                                where  cus_id = odh_customer
                                       and odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = bzd_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    if (strPI == "ALL WELL" || txtCustomer.Text == "1" || txtCustomer.Text == "1G" || txtCustomer.Text == "1K" || txtCustomer.Text == "1GG" || txtCustomer.Text == "1C" || txtCustomer.Text == "1S" || txtCustomer.Text == "1B" || txtCustomer.Text == "1X" || txtCustomer.Text == "1W" || txtCustomer.Text == "1F")
                    {
                        frmReport.strReportName = "pinvoicecbi";
                    }
                    else
                    {
                        frmReport.strReportName = "pinvoicecb";
                    }

                    frmReport.strRP[0] = dt.Rows[0]["odh_customername"].ToString();
                    frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                    frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                    frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["cus_fkfs"].ToString()) ? "" : dt.Rows[0]["cus_fkfs"].ToString());
                    frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempoutbz"].ToString()) ? "" : dt.Rows[0]["odt_tempoutbz"].ToString());
                    frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["bzd_bz"].ToString()) ? "" : dt.Rows[0]["bzd_bz"].ToString());
                    frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_sign"].ToString()) ? "" : dt.Rows[0]["odh_sign"].ToString());
                    frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                    //frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_otherpay"].ToString()) ? "" : dt.Rows[0]["odh_otherpay"].ToString());
                    frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_payflag"].ToString()) ? "" : dt.Rows[0]["odh_payflag"].ToString());
                    string strSQL2 = $@"select * from oop where oop_orderid = '{txtOrderID.Text.Trim()}' ";
                    DataTable dt2 = new DataTable();
                    dt2 = clsDB.sql_select_dt(strSQL2);
                    if (dt2.Rows.Count > 0)
                    {
                        string oop_assy = "";
                        string oop_currency = "";
                        string oop_cost = "";
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            oop_assy = oop_assy + dt2.Rows[i]["oop_assy"].ToString() + "\n";
                            oop_currency = oop_currency + dt2.Rows[i]["oop_currency"].ToString() + "\n";
                            oop_cost = oop_cost + Convert.ToDouble(dt2.Rows[i]["oop_cost"]).ToString("#,#0.000") + "\n";
                        }
                        frmReport.strRP[9] = oop_assy;
                        frmReport.strRP[10] = oop_currency;
                        frmReport.strRP[11] = oop_cost;
                    }
                    else
                    {
                        frmReport.strRP[9] = "";
                        frmReport.strRP[10] = "";
                        frmReport.strRP[11] = "";
                    }
                    frmReport.strSQL = strSQL;
                    frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                    frmReport.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPI_Cost_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPI_In_Click(object sender, EventArgs e)
        {
            //國內部PI
            try
            {
                if (txtOrderID.Text == "")
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       bzd,
                                       cus
                                where  cus_id = odh_customer
                                       and odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = bzd_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "pincnymsl";

                    frmReport.strRP[0] = dt.Rows[0]["odh_customername"].ToString();
                    frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                    frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                    frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["cus_fkfs"].ToString()) ? "" : dt.Rows[0]["cus_fkfs"].ToString());
                    frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempoutbz"].ToString()) ? "" : dt.Rows[0]["odt_tempoutbz"].ToString());
                    frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["bzd_bz"].ToString()) ? "" : dt.Rows[0]["bzd_bz"].ToString());
                    frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_sign"].ToString()) ? "" : dt.Rows[0]["odh_sign"].ToString());
                    frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                    //frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_otherpay"].ToString()) ? "" : dt.Rows[0]["odh_otherpay"].ToString());
                    frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_payflag"].ToString()) ? "" : dt.Rows[0]["odh_payflag"].ToString());
                    string strSQL2 = $@"select * from oop where oop_orderid = '{txtOrderID.Text.Trim()}' ";
                    DataTable dt2 = new DataTable();
                    dt2 = clsDB.sql_select_dt(strSQL2);
                    if (dt2.Rows.Count > 0)
                    {
                        string oop_assy = "";
                        string oop_currency = "";
                        string oop_cost = "";
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            oop_assy = oop_assy + dt2.Rows[i]["oop_assy"].ToString() + "\n";
                            oop_currency = oop_currency + dt2.Rows[i]["oop_currency"].ToString() + "\n";
                            oop_cost = oop_cost + Convert.ToDouble(dt2.Rows[i]["oop_cost"]).ToString("#,#0.000") + "\n";
                        }
                        frmReport.strRP[9] = oop_assy;
                        frmReport.strRP[10] = oop_currency;
                        frmReport.strRP[11] = oop_cost;
                    }
                    else
                    {
                        frmReport.strRP[9] = "";
                        frmReport.strRP[10] = "";
                        frmReport.strRP[11] = "";
                    }
                    frmReport.strSQL = strSQL;
                    frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                    frmReport.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPI_In_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //預覽列印
            try
            {
                if (txtOrderID.Text == "")
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"update ord
                            set    ord_price = Round(ord_price, 3)
                            where  ord_orderid = '{txtOrderID.Text.Trim()}' ";
                clsDB.Execute(strSQL);

                if (radioPI.Checked == true)   //PI
                {
                    strSQL = $@"update odh
                                set    odh_approval = 'Ray Huang'
                                where  ( odh_customer = '4'
                                          or Substring(odh_customer, 1, 2) = '4-' )
                                       and odh_orderid = '{txtOrderID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    
                    strSQL = $@"update odh
                                set    odh_approval = 'Jennifer Chen'
                                where  odh_customer <> '4'
                                       and Substring(odh_customer, 1, 2) <> '4-'
                                       and odh_orderid = '{txtOrderID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);

                    if (chkOther.Checked == false)
                    {
                        strSQL = $@"select *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       bzd,
                                       cus
                                where  cus_id = odh_customer
                                       and odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = bzd_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            frmReport frmReport = new frmReport();
                            //傳入參數
                            if (strPI == "ALL WELL" || txtCustomer.Text == "1" || txtCustomer.Text == "1G" || txtCustomer.Text == "1K" || txtCustomer.Text == "1GG" || txtCustomer.Text == "1C" || txtCustomer.Text == "1S" || txtCustomer.Text == "1B" || txtCustomer.Text == "1X" || txtCustomer.Text == "1W" || txtCustomer.Text == "1F")
                            {
                                frmReport.strReportName = "pinvoicei";
                            }
                            else
                            {
                                frmReport.strReportName = "pinvoice";
                            }

                            frmReport.strRP[0] = dt.Rows[0]["odh_customername"].ToString();
                            frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                            frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                            frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["cus_fkfs"].ToString()) ? "" : dt.Rows[0]["cus_fkfs"].ToString());
                            frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempoutbz"].ToString()) ? "" : dt.Rows[0]["odt_tempoutbz"].ToString());
                            frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["bzd_bz"].ToString()) ? "" : dt.Rows[0]["bzd_bz"].ToString());
                            frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_sign"].ToString()) ? "" : dt.Rows[0]["odh_sign"].ToString());
                            frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                            //frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_otherpay"].ToString()) ? "" : dt.Rows[0]["odh_otherpay"].ToString());
                            frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_payflag"].ToString()) ? "" : dt.Rows[0]["odh_payflag"].ToString());
                            string strSQL2 = $@"select * from oop where oop_orderid = '{txtOrderID.Text.Trim()}' ";
                            DataTable dt2 = new DataTable();
                            dt2 = clsDB.sql_select_dt(strSQL2);
                            if (dt2.Rows.Count > 0)
                            {
                                string oop_assy = "";
                                string oop_currency = "";
                                string oop_cost = "";
                                for (int i = 0; i < dt2.Rows.Count; i++)
                                {
                                    oop_assy = oop_assy + dt2.Rows[i]["oop_assy"].ToString() + "\n";
                                    oop_currency = oop_currency + dt2.Rows[i]["oop_currency"].ToString() + "\n";
                                    oop_cost = oop_cost + Convert.ToDouble(dt2.Rows[i]["oop_cost"]).ToString("#,#0.000") + "\n";
                                }
                                frmReport.strRP[9] = oop_assy;
                                frmReport.strRP[10] = oop_currency;
                                frmReport.strRP[11] = oop_cost;
                            }
                            else
                            {
                                frmReport.strRP[9] = "";
                                frmReport.strRP[10] = "";
                                frmReport.strRP[11] = "";
                            }
                            frmReport.strRP[12] = (string.IsNullOrEmpty(dt.Rows[0]["odh_approval"].ToString()) ? "" : dt.Rows[0]["odh_approval"].ToString());
                            frmReport.strSQL = strSQL;
                            frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                            frmReport.ShowDialog();
                        }
                    }
                    else
                    {
                        strSQL = $@"select *
                        from   odh,
                               odt,
                               bzd,
                               cus
                        where  cus_id = odh_customer
                               and odh_orderid = odt_orderid
                               and odh_orderid = bzd_orderid
                               and odh_orderid = '{txtOrderID.Text.Trim()}' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            frmReport frmReport = new frmReport();
                            //傳入參數
                            if (strPI == "ALL WELL" || txtCustomer.Text == "1" || txtCustomer.Text == "1G" || txtCustomer.Text == "1K" || txtCustomer.Text == "1GG" || txtCustomer.Text == "1C" || txtCustomer.Text == "1S" || txtCustomer.Text == "1B" || txtCustomer.Text == "1X" || txtCustomer.Text == "1W" )
                            {
                                frmReport.strReportName = "piotheri";
                            }
                            else
                            {
                                frmReport.strReportName = "piother";
                            }

                            frmReport.strRP[0] = dt.Rows[0]["odh_customername"].ToString();
                            frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                            frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                            frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["cus_fkfs"].ToString()) ? "" : dt.Rows[0]["cus_fkfs"].ToString());
                            frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempoutbz"].ToString()) ? "" : dt.Rows[0]["odt_tempoutbz"].ToString());
                            frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["bzd_bz"].ToString()) ? "" : dt.Rows[0]["bzd_bz"].ToString());
                            frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_sign"].ToString()) ? "" : dt.Rows[0]["odh_sign"].ToString());
                            frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                            //frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_otherpay"].ToString()) ? "" : dt.Rows[0]["odh_otherpay"].ToString());
                            frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_payflag"].ToString()) ? "" : dt.Rows[0]["odh_payflag"].ToString());
                            string strSQL2 = $@"select * from oop where oop_orderid = '{txtOrderID.Text.Trim()}' ";
                            DataTable dt2 = new DataTable();
                            dt2 = clsDB.sql_select_dt(strSQL2);
                            if (dt2.Rows.Count > 0)
                            {
                                string oop_assy = "";
                                string oop_currency = "";
                                string oop_cost = "";
                                for (int i = 0; i < dt2.Rows.Count; i++)
                                {
                                    oop_assy = oop_assy + dt2.Rows[i]["oop_assy"].ToString() + "\n";
                                    oop_currency = oop_currency + dt2.Rows[i]["oop_currency"].ToString() + "\n";
                                    oop_cost = oop_cost + Convert.ToDouble(dt2.Rows[i]["oop_cost"]).ToString("#,#0.000") + "\n";
                                }
                                frmReport.strRP[9] = oop_assy;
                                frmReport.strRP[10] = oop_currency;
                                frmReport.strRP[11] = oop_cost;
                            }
                            else
                            {
                                frmReport.strRP[9] = "";
                                frmReport.strRP[10] = "";
                                frmReport.strRP[11] = "";
                            }
                            frmReport.strRP[12] = (string.IsNullOrEmpty(dt.Rows[0]["odh_approval"].ToString()) ? "" : dt.Rows[0]["odh_approval"].ToString());
                            frmReport.strSQL = strSQL;
                            frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                            frmReport.ShowDialog();
                        }
                    }
                }

                if (radioWorkOrder.Checked == true)    //工單
                {
                    //一般訂單
                    strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and ord_wg = 0
                                       and odi_gp = 0
                                       and odi_gc = 0
                                       and pri_fenlei <> '14 Fiber Cable' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        frmReport frmReport = new frmReport();
                        //傳入參數
                        frmReport.strReportName = "workoda";
                        frmReport.Text = "工單_一般訂單";
                        frmReport.strRP[0] = dt.Rows[0]["odh_customer"].ToString();
                        frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                        frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                        frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["odh_delivedate"].ToString()) ? "" : dt.Rows[0]["odh_delivedate"].ToString());
                        frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempinbz"].ToString()) ? "" : dt.Rows[0]["odt_tempinbz"].ToString());
                        frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["odh_inbz"].ToString()) ? "" : dt.Rows[0]["odh_inbz"].ToString());
                        frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                        frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm1"].ToString()) ? "" : dt.Rows[0]["odh_zm1"].ToString());
                        frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm3"].ToString()) ? "" : dt.Rows[0]["odh_zm3"].ToString());
                        frmReport.strRP[9] = (string.IsNullOrEmpty(dt.Rows[0]["odh_cm"].ToString()) ? "" : dt.Rows[0]["odh_cm"].ToString());
                        frmReport.strRP[10] = (string.IsNullOrEmpty(dt.Rows[0]["ord_ywcode"].ToString()) ? "" : dt.Rows[0]["ord_ywcode"].ToString());
                        frmReport.strSQL = strSQL;
                        //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                        
                        frmReport.Show();
                    }

                    //外購訂單
                    strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and ord_wg = 1
                                       and odi_gp = 0
                                       and odi_gc = 0
                                       and pri_fenlei <> '14 Fiber Cable'";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        frmReport frmReport = new frmReport();
                        //傳入參數
                        frmReport.strReportName = "workodsa";
                        frmReport.Text = "工單_外購訂單";
                        frmReport.strRP[0] = dt.Rows[0]["odh_customer"].ToString();
                        frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                        frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                        frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["odh_delivedate"].ToString()) ? "" : dt.Rows[0]["odh_delivedate"].ToString());
                        frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempinbz"].ToString()) ? "" : dt.Rows[0]["odt_tempinbz"].ToString());
                        frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["odh_inbz"].ToString()) ? "" : dt.Rows[0]["odh_inbz"].ToString());
                        frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                        frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm1"].ToString()) ? "" : dt.Rows[0]["odh_zm1"].ToString());
                        frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm3"].ToString()) ? "" : dt.Rows[0]["odh_zm3"].ToString());
                        frmReport.strRP[9] = (string.IsNullOrEmpty(dt.Rows[0]["odh_cm"].ToString()) ? "" : dt.Rows[0]["odh_cm"].ToString());
                        frmReport.strRP[10] = (string.IsNullOrEmpty(dt.Rows[0]["ord_ywcode"].ToString()) ? "" : dt.Rows[0]["ord_ywcode"].ToString());
                        frmReport.strSQL = strSQL;
                        //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmReport.WindowState = FormWindowState.Normal;
                        frmReport.Show();
                    }

                    //電源訂單
                    strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and ord_wg = 2
                                       and odi_gp = 0
                                       and odi_gc = 0
                                       and pri_fenlei <> '14 Fiber Cable' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        frmReport frmReport = new frmReport();
                        //傳入參數
                        frmReport.strReportName = "workodpa";
                        frmReport.Text = "工單_電源訂單";
                        frmReport.strRP[0] = dt.Rows[0]["odh_customer"].ToString();
                        frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                        frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                        frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["odh_delivedate"].ToString()) ? "" : dt.Rows[0]["odh_delivedate"].ToString());
                        frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempinbz"].ToString()) ? "" : dt.Rows[0]["odt_tempinbz"].ToString());
                        frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["odh_inbz"].ToString()) ? "" : dt.Rows[0]["odh_inbz"].ToString());
                        frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                        frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm1"].ToString()) ? "" : dt.Rows[0]["odh_zm1"].ToString());
                        frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm3"].ToString()) ? "" : dt.Rows[0]["odh_zm3"].ToString());
                        frmReport.strRP[9] = (string.IsNullOrEmpty(dt.Rows[0]["odh_cm"].ToString()) ? "" : dt.Rows[0]["odh_cm"].ToString());
                        frmReport.strRP[10] = (string.IsNullOrEmpty(dt.Rows[0]["ord_ywcode"].ToString()) ? "" : dt.Rows[0]["ord_ywcode"].ToString());
                        frmReport.strSQL = strSQL;
                        //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmReport.WindowState = FormWindowState.Normal;
                        frmReport.Show();
                    }

                    //光纖訂單
                    strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and pri_fenlei = '14 Fiber Cable' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        frmReport frmReport = new frmReport();
                        //傳入參數
                        frmReport.strReportName = "workodfa";
                        frmReport.Text = "工單_光纖訂單";
                        frmReport.strRP[0] = dt.Rows[0]["odh_customer"].ToString();
                        frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                        frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                        frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["odh_delivedate"].ToString()) ? "" : dt.Rows[0]["odh_delivedate"].ToString());
                        frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempinbz"].ToString()) ? "" : dt.Rows[0]["odt_tempinbz"].ToString());
                        frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["odh_inbz"].ToString()) ? "" : dt.Rows[0]["odh_inbz"].ToString());
                        frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                        frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm1"].ToString()) ? "" : dt.Rows[0]["odh_zm1"].ToString());
                        frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm3"].ToString()) ? "" : dt.Rows[0]["odh_zm3"].ToString());
                        frmReport.strRP[9] = (string.IsNullOrEmpty(dt.Rows[0]["odh_cm"].ToString()) ? "" : dt.Rows[0]["odh_cm"].ToString());
                        frmReport.strRP[10] = (string.IsNullOrEmpty(dt.Rows[0]["ord_ywcode"].ToString()) ? "" : dt.Rows[0]["ord_ywcode"].ToString());
                        frmReport.strSQL = strSQL;
                        //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmReport.WindowState = FormWindowState.Normal;
                        frmReport.Show();
                    }

                    //成朋訂單
                    strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and odi_gp = 1
                                       and pri_fenlei <> '14 Fiber Cable'";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        frmReport frmReport = new frmReport();
                        //傳入參數
                        frmReport.strReportName = "workodgpa";
                        frmReport.Text = "工單_成朋訂單";
                        frmReport.strRP[0] = dt.Rows[0]["odh_customer"].ToString();
                        frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                        frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                        frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["odh_delivedate"].ToString()) ? "" : dt.Rows[0]["odh_delivedate"].ToString());
                        frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempinbz"].ToString()) ? "" : dt.Rows[0]["odt_tempinbz"].ToString());
                        frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["odh_inbz"].ToString()) ? "" : dt.Rows[0]["odh_inbz"].ToString());
                        frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                        frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm1"].ToString()) ? "" : dt.Rows[0]["odh_zm1"].ToString());
                        frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm3"].ToString()) ? "" : dt.Rows[0]["odh_zm3"].ToString());
                        frmReport.strRP[9] = (string.IsNullOrEmpty(dt.Rows[0]["odh_cm"].ToString()) ? "" : dt.Rows[0]["odh_cm"].ToString());
                        frmReport.strRP[10] = (string.IsNullOrEmpty(dt.Rows[0]["ord_ywcode"].ToString()) ? "" : dt.Rows[0]["ord_ywcode"].ToString());
                        frmReport.strSQL = strSQL;
                        //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmReport.WindowState = FormWindowState.Normal;
                        frmReport.Show();
                    }

                    //晶元訂單
                    strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and odi_gc = 1
                                       and pri_fenlei <> '14 Fiber Cable' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        frmReport frmReport = new frmReport();
                        //傳入參數
                        frmReport.strReportName = "workodgca";
                        frmReport.Text = "工單_晶元訂單";
                        frmReport.strRP[0] = dt.Rows[0]["odh_customer"].ToString();
                        frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                        frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                        frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["odh_delivedate"].ToString()) ? "" : dt.Rows[0]["odh_delivedate"].ToString());
                        frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempinbz"].ToString()) ? "" : dt.Rows[0]["odt_tempinbz"].ToString());
                        frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["odh_inbz"].ToString()) ? "" : dt.Rows[0]["odh_inbz"].ToString());
                        frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                        frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm1"].ToString()) ? "" : dt.Rows[0]["odh_zm1"].ToString());
                        frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm3"].ToString()) ? "" : dt.Rows[0]["odh_zm3"].ToString());
                        frmReport.strRP[9] = (string.IsNullOrEmpty(dt.Rows[0]["odh_cm"].ToString()) ? "" : dt.Rows[0]["odh_cm"].ToString());
                        frmReport.strRP[10] = (string.IsNullOrEmpty(dt.Rows[0]["ord_ywcode"].ToString()) ? "" : dt.Rows[0]["ord_ywcode"].ToString());
                        frmReport.strSQL = strSQL;
                        //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmReport.WindowState = FormWindowState.Normal;
                        frmReport.Show();
                    }
                }

                if (radioWorkOrder_Full.Checked == true) //工單(完整)
                {
                    //一般訂單
                    strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and ord_wg = 0
                                       and odi_gp = 0
                                       and odi_gc = 0
                                       and pri_fenlei <> '14 Fiber Cable' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        frmReport frmReport = new frmReport();
                        //傳入參數
                        frmReport.strReportName = "workod";
                        frmReport.Text = "工單(完整)_一般訂單";
                        frmReport.strRP[0] = dt.Rows[0]["odh_customer"].ToString();
                        frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                        frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                        frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["odh_delivedate"].ToString()) ? "" : dt.Rows[0]["odh_delivedate"].ToString());
                        frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempinbz"].ToString()) ? "" : dt.Rows[0]["odt_tempinbz"].ToString());
                        frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["odh_inbz"].ToString()) ? "" : dt.Rows[0]["odh_inbz"].ToString());
                        frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                        frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm1"].ToString()) ? "" : dt.Rows[0]["odh_zm1"].ToString());
                        frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm3"].ToString()) ? "" : dt.Rows[0]["odh_zm3"].ToString());
                        frmReport.strRP[9] = (string.IsNullOrEmpty(dt.Rows[0]["odh_cm"].ToString()) ? "" : dt.Rows[0]["odh_cm"].ToString());
                        frmReport.strRP[10] = (string.IsNullOrEmpty(dt.Rows[0]["ord_ywcode"].ToString()) ? "" : dt.Rows[0]["ord_ywcode"].ToString());
                        frmReport.strSQL = strSQL;
                        //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmReport.Show();
                    }

                    //外購訂單
                    strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and ord_wg = 1
                                       and odi_gp = 0
                                       and odi_gc = 0
                                       and pri_fenlei <> '14 Fiber Cable'";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        frmReport frmReport = new frmReport();
                        //傳入參數
                        frmReport.strReportName = "workods";
                        frmReport.Text = "工單(完整)_外購訂單";
                        frmReport.strRP[0] = dt.Rows[0]["odh_customer"].ToString();
                        frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                        frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                        frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["odh_delivedate"].ToString()) ? "" : dt.Rows[0]["odh_delivedate"].ToString());
                        frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempinbz"].ToString()) ? "" : dt.Rows[0]["odt_tempinbz"].ToString());
                        frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["odh_inbz"].ToString()) ? "" : dt.Rows[0]["odh_inbz"].ToString());
                        frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                        frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm1"].ToString()) ? "" : dt.Rows[0]["odh_zm1"].ToString());
                        frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm3"].ToString()) ? "" : dt.Rows[0]["odh_zm3"].ToString());
                        frmReport.strRP[9] = (string.IsNullOrEmpty(dt.Rows[0]["odh_cm"].ToString()) ? "" : dt.Rows[0]["odh_cm"].ToString());
                        frmReport.strRP[10] = (string.IsNullOrEmpty(dt.Rows[0]["ord_ywcode"].ToString()) ? "" : dt.Rows[0]["ord_ywcode"].ToString());
                        frmReport.strSQL = strSQL;
                        //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmReport.WindowState = FormWindowState.Normal;
                        frmReport.Show();
                    }

                    //電源訂單
                    strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and ord_wg = 2
                                       and odi_gp = 0
                                       and odi_gc = 0
                                       and pri_fenlei <> '14 Fiber Cable' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        frmReport frmReport = new frmReport();
                        //傳入參數
                        frmReport.strReportName = "workodp";
                        frmReport.Text = "工單(完整)_電源訂單";
                        frmReport.strRP[0] = dt.Rows[0]["odh_customer"].ToString();
                        frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                        frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                        frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["odh_delivedate"].ToString()) ? "" : dt.Rows[0]["odh_delivedate"].ToString());
                        frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempinbz"].ToString()) ? "" : dt.Rows[0]["odt_tempinbz"].ToString());
                        frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["odh_inbz"].ToString()) ? "" : dt.Rows[0]["odh_inbz"].ToString());
                        frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                        frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm1"].ToString()) ? "" : dt.Rows[0]["odh_zm1"].ToString());
                        frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm3"].ToString()) ? "" : dt.Rows[0]["odh_zm3"].ToString());
                        frmReport.strRP[9] = (string.IsNullOrEmpty(dt.Rows[0]["odh_cm"].ToString()) ? "" : dt.Rows[0]["odh_cm"].ToString());
                        frmReport.strRP[10] = (string.IsNullOrEmpty(dt.Rows[0]["ord_ywcode"].ToString()) ? "" : dt.Rows[0]["ord_ywcode"].ToString());
                        frmReport.strSQL = strSQL;
                        //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmReport.WindowState = FormWindowState.Normal;
                        frmReport.Show();
                    }

                    //光纖訂單
                    strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and pri_fenlei = '14 Fiber Cable' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        frmReport frmReport = new frmReport();
                        //傳入參數
                        frmReport.strReportName = "workodf";
                        frmReport.Text = "工單(完整)_光纖訂單";
                        frmReport.strRP[0] = dt.Rows[0]["odh_customer"].ToString();
                        frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                        frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                        frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["odh_delivedate"].ToString()) ? "" : dt.Rows[0]["odh_delivedate"].ToString());
                        frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempinbz"].ToString()) ? "" : dt.Rows[0]["odt_tempinbz"].ToString());
                        frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["odh_inbz"].ToString()) ? "" : dt.Rows[0]["odh_inbz"].ToString());
                        frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                        frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm1"].ToString()) ? "" : dt.Rows[0]["odh_zm1"].ToString());
                        frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm3"].ToString()) ? "" : dt.Rows[0]["odh_zm3"].ToString());
                        frmReport.strRP[9] = (string.IsNullOrEmpty(dt.Rows[0]["odh_cm"].ToString()) ? "" : dt.Rows[0]["odh_cm"].ToString());
                        frmReport.strRP[10] = (string.IsNullOrEmpty(dt.Rows[0]["ord_ywcode"].ToString()) ? "" : dt.Rows[0]["ord_ywcode"].ToString());
                        frmReport.strSQL = strSQL;
                        //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmReport.WindowState = FormWindowState.Normal;
                        frmReport.Show();
                    }

                    //成朋訂單
                    strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and odi_gp = 1
                                       and pri_fenlei <> '14 Fiber Cable'";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        frmReport frmReport = new frmReport();
                        //傳入參數
                        frmReport.strReportName = "workodgp";
                        frmReport.Text = "工單(完整)_成朋訂單";
                        frmReport.strRP[0] = dt.Rows[0]["odh_customer"].ToString();
                        frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                        frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                        frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["odh_delivedate"].ToString()) ? "" : dt.Rows[0]["odh_delivedate"].ToString());
                        frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempinbz"].ToString()) ? "" : dt.Rows[0]["odt_tempinbz"].ToString());
                        frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["odh_inbz"].ToString()) ? "" : dt.Rows[0]["odh_inbz"].ToString());
                        frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                        frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm1"].ToString()) ? "" : dt.Rows[0]["odh_zm1"].ToString());
                        frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm3"].ToString()) ? "" : dt.Rows[0]["odh_zm3"].ToString());
                        frmReport.strRP[9] = (string.IsNullOrEmpty(dt.Rows[0]["odh_cm"].ToString()) ? "" : dt.Rows[0]["odh_cm"].ToString());
                        frmReport.strRP[10] = (string.IsNullOrEmpty(dt.Rows[0]["ord_ywcode"].ToString()) ? "" : dt.Rows[0]["ord_ywcode"].ToString());
                        frmReport.strSQL = strSQL;
                        //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmReport.WindowState = FormWindowState.Normal;
                        frmReport.Show();
                    }

                    //晶元訂單
                    strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and odi_gc = 1
                                       and pri_fenlei <> '14 Fiber Cable' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        frmReport frmReport = new frmReport();
                        //傳入參數
                        frmReport.strReportName = "workodgc";
                        frmReport.Text = "工單(完整)_晶元訂單";
                        frmReport.strRP[0] = dt.Rows[0]["odh_customer"].ToString();
                        frmReport.strRP[1] = dt.Rows[0]["odh_orderid"].ToString();
                        frmReport.strRP[2] = Convert.ToDateTime(dt.Rows[0]["odh_orderdate"]).ToString("yyyy/MM/dd");
                        frmReport.strRP[3] = (string.IsNullOrEmpty(dt.Rows[0]["odh_delivedate"].ToString()) ? "" : dt.Rows[0]["odh_delivedate"].ToString());
                        frmReport.strRP[4] = (string.IsNullOrEmpty(dt.Rows[0]["odt_tempinbz"].ToString()) ? "" : dt.Rows[0]["odt_tempinbz"].ToString());
                        frmReport.strRP[5] = (string.IsNullOrEmpty(dt.Rows[0]["odh_inbz"].ToString()) ? "" : dt.Rows[0]["odh_inbz"].ToString());
                        frmReport.strRP[6] = (string.IsNullOrEmpty(dt.Rows[0]["odh_po"].ToString()) ? "" : dt.Rows[0]["odh_po"].ToString());
                        frmReport.strRP[7] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm1"].ToString()) ? "" : dt.Rows[0]["odh_zm1"].ToString());
                        frmReport.strRP[8] = (string.IsNullOrEmpty(dt.Rows[0]["odh_zm3"].ToString()) ? "" : dt.Rows[0]["odh_zm3"].ToString());
                        frmReport.strRP[9] = (string.IsNullOrEmpty(dt.Rows[0]["odh_cm"].ToString()) ? "" : dt.Rows[0]["odh_cm"].ToString());
                        frmReport.strRP[10] = (string.IsNullOrEmpty(dt.Rows[0]["ord_ywcode"].ToString()) ? "" : dt.Rows[0]["ord_ywcode"].ToString());
                        frmReport.strSQL = strSQL;
                        //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmReport.WindowState = FormWindowState.Normal;
                        frmReport.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOtherPay_Click(object sender, EventArgs e)
        {
            //國外其他費用
            try
            {
                if(txtOrderID.Text.Trim()=="")
                {
                    return;
                }
                frmOrder_OtherPay frmOrder_OtherPay = new frmOrder_OtherPay();
                frmOrder_OtherPay.ShowInTaskbar = false;//圖示不顯示在工作列
                frmOrder_OtherPay.rstrOrderID = txtOrderID.Text.Trim();
                frmOrder_OtherPay.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnOtherPay_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                txtOrderID.Text = "";
                txtCustomer.Text = "";
                cboShippingMark.Text = "A";
                txtOrderDate.Text = "";
                txtDeliveryDate.Text = "";
                txtPO.Text = "";
                txtSign.Text = "";
                txtNewDate.Text = "";
                txtQuotationID.Text = "";
                lblSaveDate.Text = "";
                lblUser.Text = "";
                lblCount.Text = "";
                if (dgvProduct.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvProduct.DataSource;
                    dt.Rows.Clear();
                    dgvProduct.DataSource = dt;
                }
                dgvData.Rows.Clear();
                radioPI.Checked = true;
                chkDeal_Yet.Checked = false;
                chkOther.Checked = false;
                chkReplenish.Checked = false;
                piflag = 0;
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
                if (txtOrderID.Text == "" )
                {
                    return;
                }

                //確認權限
                if (clsGlobal.checkRightFlag("訂單刪除") == false)
                {
                    MessageBox.Show("您沒有訂單刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("你確定要刪除該訂單的全部資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    strSQL = $@"delete ord where ord_orderid = '{txtOrderID.Text.Trim()}'";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete odh where odh_orderid = '{txtOrderID.Text.Trim()}'";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete odt where odt_orderid = '{txtOrderID.Text.Trim()}'";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete sbz where sbz_orderid = '{txtOrderID.Text.Trim()}'";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete odc where odc_orderid = '{txtOrderID.Text.Trim()}'";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete odt where odt_orderid = '{txtOrderID.Text.Trim()}'";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete odm where odm_orderid = '{txtOrderID.Text.Trim()}'";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete oop where oop_orderid = '{txtOrderID.Text.Trim()}'";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("已經刪除成功!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();
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
                if (txtOrderID.Text == "" )
                {
                    MessageBox.Show("你沒有輸入任何一個訂單號，不能複製!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //確認權限
                if (clsGlobal.checkRightFlag("訂單複製") == false)
                {
                    MessageBox.Show("您沒有訂單複製權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                InputBox input = new InputBox();
                input.ShowInTaskbar = false;//圖示不顯示在工作列
                input.lblInfo.Text = "請輸入要複製的新訂單編號:";
                input.Text = "複製訂單";

                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (input.GetMsg() != "")
                    {
                        string strSQL = "";
                        DataTable dt = new DataTable();
                        strSQL = $@"select * from odh where odh_orderid = '{input.GetMsg()}'";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("你輸入的訂單資料已經存在，不能夠被複製!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            strSQL = $@"exec ord_copy '{txtOrderID.Text.Trim()}', '{input.GetMsg().Trim()}' ";
                            txtOrderID.Text = input.GetMsg().Trim();
                            txtOrderID.Focus();
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
            try
            {
                if(txtOrderID.Text=="")
                {
                    return;
                }
                
                //確認權限
                if (clsGlobal.checkRightFlag("訂單儲存") == false)
                {
                    MessageBox.Show("您沒有訂單儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int piother = 0;
                if (chkOther.Checked)
                {
                    piother = 1;
                }
                else
                {
                    piother = 0;
                }

                int bh = 0;
                if (chkReplenish.Checked)
                {
                    bh = 1;
                }
                else
                {
                    bh = 0;
                }

                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select ois_orderid from ois where ois_issueqty<>0 and ois_orderid = '{txtOrderID.Text.Trim()}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("這個訂單已經有發料記錄,你不能儲存!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //先將dgvdata存到na6
                strSQL = $@"delete na6 where na6_computername=host_name() ";
                clsDB.Execute(strSQL);
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    strSQL = $@"insert into na6
                                            (na6_assy,
                                             na6_qty,
                                             na6_computername,
                                             na6_yftype,
                                             na6_qtycal,
                                             na6_qtyc,
                                             na6_price,
                                             na6_ywcode)
                                values     ( '{dgvData.Rows[i].Cells["產品編號"].Value.ToString()}',
                                             {dgvData.Rows[i].Cells["na6_qty"].Value.ToString()},
                                             Host_name(),
                                             '{dgvData.Rows[i].Cells["na6_yftype"].Value.ToString()}',
                                             '{dgvData.Rows[i].Cells["na6_qtycal"].Value.ToString()}',
                                             '{dgvData.Rows[i].Cells["數量"].Value.ToString()}',
                                             '{dgvData.Rows[i].Cells["na6_price"].Value.ToString()}',
                                             '{dgvData.Rows[i].Cells["na6_ywcode"].Value.ToString()}') ";
                    clsDB.Execute(strSQL);
                }

                cboShippingMark_Leave(null, null);

                strSQL = $@"select * from odh where odh_orderid = '{txtOrderID.Text.Trim()}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    if (MessageBox.Show("是否需更新本訂單最新單價及成本?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        frmOrder_RefreshPrice frmOrder_RefreshPrice = new frmOrder_RefreshPrice();
                        frmOrder_RefreshPrice.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmOrder_RefreshPrice.rstrOrderID = txtOrderID.Text.Trim();
                        for (int i = 0; i < dgvData.Rows.Count; i++)
                        {
                            frmOrder_RefreshPrice.dgvData.Rows.Add();
                            frmOrder_RefreshPrice.dgvData.Rows[i].Cells["CHK"].Value = true;
                            frmOrder_RefreshPrice.dgvData.Rows[i].Cells["產品編號"].Value = dgvData.Rows[i].Cells["產品編號"].Value.ToString();
                            frmOrder_RefreshPrice.dgvData.Rows[i].Cells["數量"].Value = dgvData.Rows[i].Cells["數量"].Value.ToString();
                            frmOrder_RefreshPrice.dgvData.Rows[i].Cells["業務"].Value = dgvData.Rows[i].Cells["業務"].Value.ToString();
                        }
                        
                        frmOrder_RefreshPrice.ShowDialog();
                        if (rstrButton == "Save")
                        {
                            strSQL = $@"exec ord_saveflag
                                  '{txtOrderID.Text.Trim()}',
                                  '{txtOrderDate.Text.Trim()}',
                                  '{txtDeliveryDate.Text.Trim()}',
                                  '{txtCustomer.Text.Trim()}',
                                  '{customername}',
                                  '{delivery}',
                                  '{shipmark}',
                                  '{txtSign.Text.Trim()}',
                                  '{txtPO.Text.Trim()}',
                                  '{zm1}',
                                  '{zm2}',
                                  '{zm3}',
                                  '{cm}',
                                  '{cboShippingMark.Text.Trim()}',
                                  {piother},
                                  '{txtNewDate.Text.Trim()}',
                                  {bh},
                                  {piflag},
                                  '',
                                  '{txtQuotationID.Text.Trim()}' ";
                            clsDB.Execute(strSQL);
                            strSQL = $@"exec ord_calld '{txtOrderID.Text.Trim()}' ";
                            clsDB.Execute(strSQL);
                            rstrButton = "";
                        }
                    }
                    else
                    {
                        strSQL = $@"exec ord_savenot
                                  '{txtOrderID.Text.Trim()}',
                                  '{txtOrderDate.Text.Trim()}',
                                  '{txtDeliveryDate.Text.Trim()}',
                                  '{txtCustomer.Text.Trim()}',
                                  '{customername}',
                                  '{delivery}',
                                  '{shipmark}',
                                  '{txtSign.Text.Trim()}',
                                  '{txtPO.Text.Trim()}',
                                  '{zm1}',
                                  '{zm2}',
                                  '{zm3}',
                                  '{cm}',
                                  '{cboShippingMark.Text.Trim()}',
                                  {piother},
                                  '{txtNewDate.Text.Trim()}',
                                  {bh},
                                  {piflag},
                                  '',
                                  '{txtQuotationID.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                    }
                }
                else
                {
                    
                    //Do_ord_save();
                    strSQL = $@"exec Ord_save
                                  '{txtOrderID.Text.Trim()}',
                                  '{txtOrderDate.Text.Trim()}',
                                  '{txtDeliveryDate.Text.Trim()}',
                                  '{txtCustomer.Text.Trim()}',
                                  '{customername}',
                                  '{delivery}',
                                  '{shipmark}',
                                  '{txtSign.Text.Trim()}',
                                  '{txtPO.Text.Trim()}',
                                  '{zm1}',
                                  '{zm2}',
                                  '{zm3}',
                                  '{cm}',
                                  '{cboShippingMark.Text.Trim()}',
                                  {piother},
                                  '{txtNewDate.Text.Trim()}',
                                  {bh},
                                  {piflag},
                                  '',
                                  '{txtQuotationID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                }
                //更新該工單的量大值
                strSQL = $@"exec ord_calld '{txtOrderID.Text.Trim()}' ";
                clsDB.Execute(strSQL);

                strSQL = $@"select distinct ord_orderid,
                                            ord_assy,
                                            pri_customerid,
                                            ord_convprice,
                                            pri_clcost,
                                            Round(Abs(( ( ord_convprice - pri_clcost ) / pri_clcost ) * 100)
                                            , 2) as
                                            'op_diff'
                            from   ord,
                                   pri
                            where  pri_customerid = ord_assy
                                   and ord_convprice <> 0
                                   and Round(Abs(( ( ord_convprice - pri_clcost ) / pri_clcost ) * 100), 2)
                                       >= 30
                                   and ord_orderid = '{txtOrderID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count>0)
                {
                    string rtmp = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        rtmp = rtmp + "[" + dt.Rows[0]["ord_assy"].ToString() + "]誤差=>" + dt.Rows[0]["op_diff"].ToString() + "%" + "\n";
                    }
                    MessageBox.Show("下列產品編號的成本價異常,與現行成本價誤差超過30%!" + "\n" + rtmp + "\n" + "請重新儲存選擇更新單價,若還有警示請洽IT人員.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("已經儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getData_OrderID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCopy_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Do_ord_save()
        {
            //全新的訂單儲存
            try
            {
                int piother = 0;
                if (chkOther.Checked)
                {
                    piother = 1;
                }
                else
                {
                    piother = 0;
                }

                int bh = 0;
                if (chkReplenish.Checked)
                {
                    bh = 1;
                }
                else
                {
                    bh = 0;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"insert odh
                                   (odh_orderid,
                                    odh_orderdate,
                                    odh_delivedate,
                                    odh_customer,
                                    odh_customername,
                                    odh_delivery,
                                    odh_shipmark,
                                    odh_sign,
                                    odh_po,
                                    odh_zm1,
                                    odh_zm2,
                                    odh_zm3,
                                    odh_cm,
                                    odh_zmtype,
                                    odh_adddate,
                                    odh_piother,
                                    odh_newdate,
                                    odh_bh,
                                    odh_piflag,
                                    odh_delivedate1,
                                    odh_bjdb)
                            values('{txtOrderID.Text.Trim()}',
                                   '{txtOrderDate.Text.Trim()}',
                                   '{txtDeliveryDate.Text.Trim()}',
                                   '{txtCustomer.Text.Trim()}',
                                   '{customername}',
                                   '{delivery}',
                                   '{shipmark}',
                                   '{txtSign.Text.Trim()}',
                                   '{txtPO.Text.Trim()}',
                                   '{zm1}',
                                   '{zm2}',
                                   '{zm3}',
                                   '{cm}',
                                   '{cboShippingMark.Text.Trim()}',
                                   Format(Getdate(), 'yyyy/MM/dd'),
                                   {piother},
                                   '{txtNewDate.Text.Trim()}',
                                   {bh},
                                   0,
                                   '',
                                   '{txtQuotationID.Text.Trim()}') ";
                clsDB.Execute(strSQL);
                
                strSQL = $@"update odh set odh_yw=cus_yw from odh, cus where odh_customer=cus_id and odh_orderid = '{txtOrderID.Text.Trim()}' ";
                clsDB.Execute(strSQL);


            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-Do_ord_save" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string strSQL = "";
                DataTable dt = new DataTable();
                //加入報價單判斷,以免造成選取客號時抓到材料單的價格為0
                strSQL = $@"select * from pri where pri_customerid = '{dgvProduct.Rows[dgvProduct.CurrentRow.Index].Cells["odi_customerid"].Value.ToString()}' and pri_newcostchk like 'N%' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["pri_fenlei"].ToString().Trim()=="")
                    {
                        MessageBox.Show("此項未選訂單分類,請先定義分類!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

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
                dgvData.Rows[index].Cells["數量"].Value = 0;
                strSQL = $@"select cus_yw from odi,cus where cus_id=odi_customer and odi_customerid = '{dgvProduct.Rows[dgvProduct.CurrentRow.Index].Cells["odi_customerid"].Value.ToString()}' ";

                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.Rows[index].Cells["業務"].Value = dt.Rows[0]["cus_yw"].ToString();
                }
                dgvData.Focus();
                dgvData.CurrentCell = dgvData[1, index];
                dgvData.BeginEdit(true);
            }
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && dgvData.Rows[dgvData.CurrentRow.Index].Cells[1].Value.ToString() != "")
            {
                dgvData.Rows[dgvData.CurrentRow.Index].Cells["na6_qtycal"].Value = dgvData.Rows[dgvData.CurrentRow.Index].Cells[1].Value.ToString();
            }
        }

        private void cboShippingMark_Leave(object sender, EventArgs e)
        {
            if(cboShippingMark.Text=="")
            {
                cboShippingMark.Text = "A";
            }
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select *
                        from   czc
                        where  czc_customer = '{txtCustomer.Text.Trim()}'
                               and czc_zmtype = '{cboShippingMark.Text.Trim()}' ";
            dt = clsDB.sql_select_dt(strSQL);
            if(dt.Rows.Count>0)
            {
                zm1 = dt.Rows[0]["czc_zm1"].ToString();
                zm3 = dt.Rows[0]["czc_zm3"].ToString();
                cm = dt.Rows[0]["czc_cm"].ToString();
            }
        }

        private void chkDeal_Yet_CheckedChanged(object sender, EventArgs e)
        {
            //判斷成交否? 0:已成交,1:未成交
            string strSQL = "";
            this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
            DataTable dt = new DataTable();
            if (chkDeal_Yet.Checked == false)
            {
                strSQL = $@"select odi_customerid,
                                       odi_line
                                from   odi
                                where  odi_customer = '{txtCustomer.Text}'
                                       and odi_customerid in (select distinct ord_assy
                                                              from   ord)
                                       and odi_customerid in (select distinct pri_customerid
                                                              from   pri
                                                              where  pri_newcostchk like 'N%')
                                order  by odi_customerid ";
            }
            else
            {
                strSQL = $@"select odi_customerid,
                                       odi_line
                                from   odi
                                where  odi_customer = '{txtCustomer.Text}'
                                       and odi_customerid not in (select distinct ord_assy
                                                                  from   ord)
                                       and odi_customerid in (select distinct pri_customerid
                                                              from   pri
                                                              where  pri_newcostchk like 'N%')
                                order  by odi_customerid ";
            }
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dgvProduct.DataSource = dt;
                lblCount.Text = dt.Rows.Count.ToString();
            }
            this.Cursor = Cursors.Default;//滑鼠還原預設
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            //選取備註
            try
            {
                frmOrder_Note frmOrder_Note = new frmOrder_Note();
                frmOrder_Note.ShowInTaskbar = false;//圖示不顯示在工作列
                frmOrder_Note.ShowInTaskbar = false;
                frmOrder_Note.rstrCustomer = txtCustomer.Text.Trim();
                frmOrder_Note.rstrOrderID = txtOrderID.Text.Trim();
                if(radioPI.Checked )
                {
                    frmOrder_Note.rstrType = "OUT";
                }
                else
                {
                    frmOrder_Note.rstrType = "IN";
                }
                frmOrder_Note.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnNote_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Order_Modify_Click(object sender, EventArgs e)
        {
            //工單修改紀錄
            try
            {
                if (txtOrderID.Text.Trim() == "")
                {
                    return;
                }
                frmOrder_Inq_Modify frmOrder_Inq_Modify = new frmOrder_Inq_Modify();
                frmOrder_Inq_Modify.ShowInTaskbar = false;//圖示不顯示在工作列
                frmOrder_Inq_Modify.ShowInTaskbar = false;
                frmOrder_Inq_Modify.rstrOrderID = txtOrderID.Text.Trim();

                frmOrder_Inq_Modify.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Order_Modify_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnComplaint_Click(object sender, EventArgs e)
        {
            //客訴
            try
            {
                if (txtOrderID.Text.Trim() == "")
                {
                    return;
                }
                frmOrder_Complaint frmOrder_Complaint = new frmOrder_Complaint();
                frmOrder_Complaint.ShowInTaskbar = false;//圖示不顯示在工作列
                frmOrder_Complaint.ShowInTaskbar = false;
                frmOrder_Complaint.rstrOrderID = txtOrderID.Text.Trim();
                frmOrder_Complaint.rstrCustomer = txtCustomer.Text.Trim();
                frmOrder_Complaint.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnComplaint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Complaint_Click(object sender, EventArgs e)
        {
            //客訴查詢
            try
            {
                frmOrder_Inq_Complaint frmOrder_Inq_Complaint = new frmOrder_Inq_Complaint();
                frmOrder_Inq_Complaint.ShowInTaskbar = false;//圖示不顯示在工作列
                frmOrder_Inq_Complaint.ShowDialog();
                if (rstrOrderID != "")
                {
                    txtOrderID.Text = rstrOrderID;
                    getData_OrderID();
                }
                rstrOrderID = "";
                dgvData.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Complaint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Order_Click(object sender, EventArgs e)
        {
            //訂單查詢
            try
            {
                //權限
                if (clsGlobal.checkRightFlag("訂單查看利潤") == true)
                {
                    frmOrder_Inq_Order_P frmOrder_Inq_Order_P = new frmOrder_Inq_Order_P();
                    frmOrder_Inq_Order_P.ShowInTaskbar = false;//圖示不顯示在工作列
                    frmOrder_Inq_Order_P.ShowDialog();
                    if (rstrOrderID != "")
                    {
                        txtOrderID.Text = rstrOrderID;
                        getData_OrderID();
                    }
                    rstrOrderID = "";
                    dgvData.Focus();
                }
                else
                {
                    frmOrder_Inq_Order frmOrder_Inq_Order = new frmOrder_Inq_Order();
                    frmOrder_Inq_Order.ShowInTaskbar = false;//圖示不顯示在工作列
                    frmOrder_Inq_Order.ShowDialog();
                    if (rstrOrderID != "")
                    {
                        txtOrderID.Text = rstrOrderID;
                        getData_OrderID();
                    }
                    rstrOrderID = "";
                    dgvData.Focus();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Order_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkReplenish_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}