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
    public partial class frmOrder_Inq_Complaint : Form
    {
        public frmOrder_Inq_Complaint()
        {
            InitializeComponent();
        }

        private void frmOrder_Inq_Complaint_Load(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmOrder_Inq_Complaint_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string strSQL2 = "";
                DataTable dt = new DataTable();
                
                strSQL = $@"select distinct odh_orderid'訂單編號',
                                            odc_customerid '客號',
                                            odh_customer'客戶',
                                            odh_orderdate'訂單日期',
                                            odc_date'客訴日期',
                                            odc_qty '客訴金額_原',
                                            odc_currency '客訴幣種',
                                            odc_convert '匯率',
                                            dbo.Formatstr(odc_ksval,0)'客訴金額_NT',
                                            dbo.Formatstr(odc_cszr*odc_convert,0)'廠商責任金額_NT',
                                            dbo.Formatstr(Isnull(Round(Sum((ord_pricost -ord_convprice)*ord_qty),0),0),0)'原利潤_NT',
                                            dbo.Formatstr(Isnull(Round(Sum((ord_pricost - ord_convprice) * ord_qty), 0), 0) - odh_ks, 0) '客訴後利潤_NT' ,
                                            odc_adddate '最後儲存日期'
                            from            odh,
                                            ord,
                                            odi,
                                            odc
                            where           odh_orderid=ord_orderid
                            and             ord_assy=odi_customerid
                            and             odh_orderid=odc_orderid ";

                strSQL2 = $@"group by       odh_orderid,
                                            odc_customerid,
                                            odh_customer,
                                            odh_orderdate,
                                            odc_date,
                                            odc_qty,
                                            odc_currency,
                                            odc_convert,
                                            odh_ks,
                                            odc_ksval,
                                            odc_cszr,
                                            odc_convert ,
                                            odc_adddate
                            order by        odc_date desc,
                                            odh_orderid,
                                            odc_customerid,
                                            odh_customer";
                strSQL = strSQL + Get_strWhere() + strSQL2;
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
                else
                {
                    dgvData.DataSource = dt;
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }

                strSQL = $@"select dbo.Formatstr(Isnull(Round(Sum(a.odc_ksval), 0), 0), 0) as kss
                            from   (select distinct odc_ksval,
                                                    odh_orderid
                                    from   ord,
                                           odh,
                                           odc,
                                           odi
                                    where  ord_assy = odi_customerid
                                           and ord_orderid = odh_orderid
                                           and odh_orderid = odc_orderid ";
                strSQL = strSQL + Get_strWhere() + ") as a ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count>0)
                {
                    lblSum.Text = "客訴加總：" + dt.Rows[0]["kss"].ToString();
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
            strWhere = strWhere + (txtNewDate_S.Text=="" ? "" : $@"and odh_newdate between '{txtNewDate_S.Text}' and '{txtNewDate_E.Text}' ");
            //客訴日期
            strWhere = strWhere + (txtDate_S.Text == "" ? "" : $@"and odc_adddate between '{txtDate_S.Text}' and '{txtDate_E.Text}' ");
            //客戶
            if (txtCustomer.Text == "4-")
            {
                strWhere = strWhere + $@"and odc_customer like '%4-%' ";
            }
            else if (txtCustomer.Text == "4")
            {
                strWhere = strWhere + $@"and (odc_customer ='4' or substring(odc_customer, 1, 2) = '4-') ";
            }
            else
            {
                strWhere = strWhere + (txtCustomer.Text == "" ? "" : $@"and odc_customer = '{txtCustomer.Text.Trim()}' ");
            }
            //線路
            strWhere = strWhere + (txtLine.Text == "" ? "" : $@"and ord_line like '%{txtLine.Text.Trim()}%' ");
            //訂單
            strWhere = strWhere + (txtOrder.Text == "" ? "" : $@"and odh_orderid like '%{txtOrder.Text.Trim()}%' ");
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
                strWhere = strWhere + (txtCustomerID.Text=="" ? "" : $@"and ord_assy like '%{txtCustomerID.Text.Trim()}%' ");
            }
            //業務
            strWhere = strWhere + (cboSales.Text == "" ? "" : $@"and odh_yw = '{cboSales.Text.Trim()}' ");
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
                strWhere = strWhere + (txtCZF.Text=="" ? "" : $@"and odi_czf like '%{txtCZF.Text.Trim()}%' ");
            }
            

            //電源
            strWhere = strWhere + (chkPower.Checked ? "and ord_wg = 2 and ord_assy = odc_customerid " : "");
            //光纖
            strWhere = strWhere + (chkFiber.Checked ? "and ord_assy in (select distinct pri_customerid from pri where pri_fenlei = '14 Fiber Cable') " : "");
            
            //P/O
            strWhere = strWhere + (txtPO.Text == "" ? "" : $@"and odh_po like '%{txtPO.Text}%' ");

            return strWhere;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("查詢客訴資料", dgvData);
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
                //客號
                txtCustomerID.Text = "";
                //業務
                cboSales.Text = "";
                //分類
                cboClass.Text = "";
                //參照法
                txtCZF.Text = "";


                //電源
                chkPower.Checked = false;
                //光纖
                chkFiber.Checked = false;

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
    }
}
