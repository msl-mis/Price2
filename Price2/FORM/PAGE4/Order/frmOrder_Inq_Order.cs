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
    public partial class frmOrder_Inq_Order : Form
    {
        public frmOrder_Inq_Order()
        {
            InitializeComponent();
        }

        private void frmOrder_Inq_Order_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                String strSQL = "";
                DataTable dt = new DataTable();
                //加入業務
                strSQL = $@"select distinct cus_yw from cus ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboSales.Items.Add(dt.Rows[i]["cus_yw"].ToString());
                    }
                }

                //加入第二層
                strSQL = $@"select distinct ap2_assy from ap2 order by ap2_assy ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboAp2.Items.Add(dt.Rows[i]["ap2_assy"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmOrder_Inq_Order_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNewDate_S_Click(object sender, EventArgs e)
        {
            if (txtNewDate_S.Text == "")
            {
                txtNewDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtNewDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtNewDate_E_Click(object sender, EventArgs e)
        {
            if (txtNewDate_E.Text == "")
            {
                txtNewDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtNewDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
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
            if (txtDate_S.Text == "")
            {
                txtDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("查詢訂單資料", dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                //新增日期
                txtNewDate_S.Text = "";
                txtNewDate_E.Text = "";
                //客訴日期
                txtDate_S.Text = "";
                txtDate_E.Text = "";
                //客戶
                txtCustomer.Text = "";
                //線路
                txtLine.Text = "";
                //訂單
                txtOrder.Text = "";
                //報價單
                txtQuotation.Text = "";
                //交期
                txtDelivery.Text = "";
                //客號
                txtCustomerID.Text = "";
                //業務
                cboSales.Text = "";
                //第二層
                cboAp2.Text = "";

                //分類
                cboClass.Text = "";
                //參照法
                txtCZF.Text = "";


                //電源
                chkPower.Checked = false;
                //光纖
                chkFiber.Checked = false;
                //成朋
                chkGP.Checked = false;
                //晶元
                chkGC.Checked = false;
                //P/O
                txtPO.Text = "";

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

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex != dgvData.Rows.Count - 1)
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
                if (txtNewDate_E.Text != "" && txtNewDate_S.Text != "")
                {
                    if (Convert.ToDateTime(txtNewDate_S.Text) > Convert.ToDateTime(txtNewDate_E.Text))
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

                strSQL11 = $@"select distinct odh_orderid'訂單編號',
                                            odh_orderdate'訂單日期',
                                            odh_newdate'新建日期',
                                            odh_customer'客戶',
                                            odh_customername'客戶名稱',
                                            odh_delivedate'交期',
                                            dbo.Formatstr(Isnull(Sum(ord_qty),0),0)'數量',
                                            odh_po'PO',
                                            odh_bjdb '報價單號'
                            from            odh,
                                            ord,
                                            odi
                            where           odh_orderid=ord_orderid
                            and             ord_assy=odi_customerid ";

                strSQL12 = $@"group by        odh_orderid,
                                            odh_orderdate,
                                            odh_newdate,
                                            odh_customer,
                                            odh_customername,
                                            odh_delivedate,
                                            odh_po,
                                            odh_bjdb
                            order by        odh_newdate desc ,
                                            odh_orderid desc ";


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

            //新增日期
            strWhere = strWhere + (txtNewDate_S.Text == "" ? "" : $@"and odh_newdate between '{txtNewDate_S.Text}' and '{txtNewDate_E.Text}' ");
            //成交日期
            strWhere = strWhere + (txtDate_S.Text == "" ? "" : $@"and odh_orderdate between '{txtDate_S.Text}' and '{txtDate_E.Text}' ");
            //客戶
            if (txtCustomer.Text == "4-")
            {
                strWhere = strWhere + $@"and odh_customer like '%4-%' ";
            }
            else if (txtCustomer.Text == "4")
            {
                strWhere = strWhere + $@"and (odh_customer ='4' or substring(odh_customer, 1, 2) = '4-') ";
            }
            else
            {
                strWhere = strWhere + (txtCustomer.Text == "" ? "" : $@"and odh_customer = '{txtCustomer.Text.Trim()}' ");
            }
            //線路
            strWhere = strWhere + (txtLine.Text == "" ? "" : $@"and ord_line like '%{txtLine.Text.Trim()}%' ");
            //訂單
            strWhere = strWhere + (txtOrder.Text == "" ? "" : $@"and odh_orderid like '%{txtOrder.Text.Trim()}%' ");
            //報價單號
            strWhere = strWhere + (txtQuotation.Text == "" ? "" : $@"and odh_bjdb like '%{txtQuotation.Text.Trim()}%' ");
            //交期
            strWhere = strWhere + (txtDelivery.Text == "" ? "" : $@"and pdh_delivedate = '{txtDelivery.Text.Trim()}' ");
            //客號
            if (txtCustomerID.Text.IndexOf(";") >= 0)//分號多條件搜尋
            {
                string[] str = txtCustomerID.Text.Split(';');
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Trim();
                    strWhere = strWhere + $@"and ord_assy like '%{str[i].Trim()}%' ";
                }
            }
            else
            {
                strWhere = strWhere + (txtCustomerID.Text == "" ? "" : $@"and ord_assy like '%{txtCustomerID.Text.Trim()}%' ");
            }
            //業務
            strWhere = strWhere + (cboSales.Text == "" ? "" : $@"and odh_yw = '{cboSales.Text.Trim()}' ");
            //第二層
            strWhere = strWhere + (cboAp2.Text == "" ? "" : $@"and ord_assy in (select distinct pri_customerid from pri, (select distinct ap3_part, ap2_assy from ap2, ap3 where ap2_part = ap3_assy and ap2_assy = '{cboAp2.Text.Trim()}') as aa where pri_part = aa.ap3_part) ");
            //分類
            strWhere = strWhere + (cboClass.Text == "" ? "" : $@"and ord_assy in (select distinct pri_customerid from pri where pri_fenlei = '{cboClass.Text.Trim()}' ) ");
            //參照法
            if (txtCZF.Text.IndexOf(";") >= 0)//分號多條件搜尋
            {
                string[] str = txtCZF.Text.Split(';');
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Trim();
                    strWhere = strWhere + $@"and odi_czf like '%{str[i].Trim()}%' ";
                }
            }
            else
            {
                strWhere = strWhere + (txtCZF.Text == "" ? "" : $@"and odi_czf like '%{txtCZF.Text.Trim()}%' ");
            }


            //電源
            strWhere = strWhere + (chkPower.Checked ? "and ord_wg = 2 " : "");
            //光纖
            strWhere = strWhere + (chkFiber.Checked ? "and ord_assy in (select distinct pri_customerid from pri where pri_fenlei = '14 Fiber Cable') " : "");
            //成朋
            strWhere = strWhere + (chkGP.Checked ? "and odi_gp = 1 " : "");
            //晶元
            strWhere = strWhere + (chkGC.Checked ? "and odi_gc = 1 " : "");
            //P/O
            strWhere = strWhere + (txtPO.Text == "" ? "" : $@"and odh_po like '%{txtPO.Text}%' ");

            return strWhere;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtPO_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
