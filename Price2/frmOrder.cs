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
        string strPI = "";
        string customername;
        string delivery="";
        string shipmark = "";
        string delivedate1 = "";
        string zm1 = "";
        string zm2 = "";
        string zm3 = "";
        string cm = "";
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
                //frmOrder_Inq.rstrCustomer = txtCustomer.Text.Trim();
                //frmOrder_Inq.rstrOrderID = txtOrderID.Text.Trim();
                frmOrder_Inq.ShowDialog();
                if (rstrOrderID != "")
                {
                    txtOrderID.Text = rstrOrderID;
                    getData_OrderID();
                }
                rstrOrderID = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnProofing_Inq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtDeliveryDate.Text = Convert.ToDateTime(dt.Rows[0]["odh_delivedate"]).ToString("yyyy/MM/dd");
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
                                   ord_ywcode 業務
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
    }
}
