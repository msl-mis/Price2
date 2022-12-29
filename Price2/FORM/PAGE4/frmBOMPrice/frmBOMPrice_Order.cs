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
    public partial class frmBOMPrice_Order : Form
    {
        public frmBOMPrice_Order()
        {
            InitializeComponent();
        }

        public static string rstrID = "";  //由frmBOMPrice傳的材料ID
        private void frmBOMPrice_Order_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                ChkID.Checked = false;
                txtID.Text = rstrID;
                
                GetInq();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOMPrice_Order_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Click(object sender, EventArgs e)   //搜尋
        {
            //搜尋
            try
            {
                GetInq();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetInq()
        {
            try
            {
                string strWhere = "";
                strWhere = strWhere + (ChkLine.Checked ? "" : $@" and ord_line='{txtLine.Text.Trim()}'");
                strWhere = strWhere + (chkCustomer.Checked ? "" : $@" and odh_customer='{txtCustomer.Text.Trim()}'");
                strWhere = strWhere + (ChkID.Checked ? "" : $@" and ord_assy='{txtID.Text.Trim()}'");
                strWhere = strWhere + (chkNewDate.Checked ? "" : $@" and odh_newdate between '{txtNewDate_S.Text}' and '{txtNewDate_E.Text}'");

                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select Isnull(Sum(ord_qty),0) as totalqty
                            from   ord,
                                   odh
                            where  ord_orderid=odh_orderid ";
                strSQL = strSQL + strWhere;
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    lblSum.Text = "總數量: " + dt.Rows[0]["totalqty"].ToString();
                }
                else
                {
                    lblSum.Text = "總數量: 0";
                }
                strSQL = $@"select tab.客戶 '客戶', tab.訂單編號 '訂單編號', tab.PO 'PO',tab.報價單號 '報價單號', tab.客號 '客號', 
                                    tab.線路 '線路', tab.數量 '數量', tab.客訴 '客訴', tab.新建日期 '新建日期', tab.出貨日期 '出貨日期', 
                                    Format(tab.報價,'0.###') '報價', Format(tab.換算價,'0.###') '換算價', tab.匯率 '匯率',  Format(tab.利潤,'0.#') '利潤'
                            from(
                            select distinct ord_customer'客戶',
                                            ord_orderid'訂單編號',
                                            odh_po'PO',
                                            odh_bjdb '報價單號',
                                            ord_assy'客號',
                                            ord_line'線路',
                                            ord_qty'數量',
                                            odc_qty * odc_convert '客訴',
                                            odh_newdate'新建日期',
                                            odh_delivedate'出貨日期',
                                            ord_pricost  /ord_convert'報價',
                                            ord_convprice/ord_convert'換算價',
                                            ord_convert'匯率',
                                            case Isnull(Sum(ord_convprice * ord_qty), 0)
                                                when 0 then 0
                                                else ( ( Isnull(Sum((ord_pricost - ord_convprice ) * ord_qty), 0) ) / ( Isnull(Sum(ord_convprice * ord_qty ), 0) ) * 100)
                                            end '利潤'
                            from            ord,
                                            odh
                            left join       odc
                            on              odh_orderid = odc_orderid
                            where           ord_orderid=odh_orderid ";
                string strSQL2 = $@"group by        odh_newdate,
                                                    ord_customer,
                                                    ord_orderid,
                                                    odh_po,
                                                    odh_bjdb,
                                                    ord_assy,
                                                    ord_line,
                                                    ord_qty,
                                                    odh_delivedate,
                                                    ord_pricost  /ord_convert,
                                                    ord_convprice/ord_convert,
                                                    ord_convert,
                                                    odh_ks,
                                                    odc_qty,
                                                    odc_convert)tab
                                    order by        tab.新建日期 desc,
                                                    tab.訂單編號,
                                                    tab.客號";
                strSQL = strSQL + strWhere + strSQL2;
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    lblCount.Text = "總筆數: "+dt.Rows.Count.ToString();
                }
                else
                {
                    lblCount.Text = "總筆數: 0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-GetInq" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) //結束
        {
            //結束
            try
            {
                frmBOMPrice.rstrButton = "Close";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkNewDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewDate.Checked)
            {
                txtNewDate_S.Text = "(ALL)";
                txtNewDate_E.Text = "(ALL)";
            }
            else
            {
                txtNewDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtNewDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtNewDate_S_Enter(object sender, EventArgs e)
        {
            chkNewDate.Checked = false;
        }

        private void txtNewDate_E_Enter(object sender, EventArgs e)
        {
            chkNewDate.Checked = false;
        }

        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomer.Checked)
            {
                txtCustomer.Text = "(ALL)";
            }
            else
            {
                txtCustomer.Text = "";
            }
        }

        private void txtCustomer_Enter(object sender, EventArgs e)
        {
            chkCustomer.Checked = false;
        }

        private void ChkLine_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkLine.Checked)
            {
                txtLine.Text = "(ALL)";
            }
            else
            {
                txtLine.Text = "";
            }
        }

        private void txtLine_Enter(object sender, EventArgs e)
        {
            ChkLine.Checked=false;
        }

        private void ChkID_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkID.Checked)
            {
                txtID.Text = "(ALL)";
            }
            else
            {
                txtID.Text = "";
            }
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            ChkID.Checked=false;
        }

        private void btnClear_Click(object sender, EventArgs e) //清除
        {
            //清除
            try
            {
                chkCustomer.Checked=true;
                ChkID.Checked= true;
                chkNewDate.Checked= true;
                ChkLine.Checked= true;
                lblCount.Text = "";
                lblSum.Text = "";
                //清除dgvData
                if (dgvData.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvData.DataSource;
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
            //尚未完成等訂單管理
        }
    }
}
