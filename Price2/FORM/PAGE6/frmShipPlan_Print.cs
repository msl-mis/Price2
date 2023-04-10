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
    public partial class frmShipPlan_Print : Form
    {
        public static string rstrOrderID = "";
        public frmShipPlan_Print()
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
                frmOrder_Inq.rstrForm = "frmShipPlan_Print";
                frmOrder_Inq.ShowDialog();
                if (rstrOrderID != "")
                {
                    txtOrderID.Text = rstrOrderID;
                }
                rstrOrderID = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnOrder_Inq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                if (txtOrderID.Text == "")
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                if (chkBeginNo.Checked)
                {
                    //strSQL = $@"exec cal_orderbeginxx '{txtOrderID.Text.Trim()}',{ txtBeginNo.Text} ";
                    //clsDB.Execute(strSQL);
                    //do_InsertTable(Convert.ToInt32(txtBeginNo.Text));
                }
                else
                {
                    //strSQL = $@"exec cal_orderxx '{txtOrderID.Text.Trim()}' ";
                    //clsDB.Execute(strSQL);
                    //do_InsertTable(0);
                }

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
                                   and pri_fenlei <> '14 Fiber Cable'
                            order  by ord.ord_beginxx ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "ordch";
                    frmReport.Text = "一般工單出貨計畫";
                    frmReport.strRP[0] = dt.Rows[0]["ord_orderid"].ToString();
                    frmReport.strRP[1] = dt.Rows[0]["odh_delivedate"].ToString();
                    frmReport.strRP[2] = dt.Rows[0]["odh_zm1"].ToString();
                    frmReport.strRP[3] = dt.Rows[0]["odh_cm"].ToString();
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
                                       and pri_fenlei <> '14 Fiber Cable'
                                order  by ord.ord_beginxx ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "ordch";
                    frmReport.Text = "外購工單出貨計畫";
                    frmReport.strRP[0] = dt.Rows[0]["ord_orderid"].ToString() + "S";
                    frmReport.strRP[1] = dt.Rows[0]["odh_delivedate"].ToString();
                    frmReport.strRP[2] = dt.Rows[0]["odh_zm1"].ToString();
                    frmReport.strRP[3] = dt.Rows[0]["odh_cm"].ToString();
                    frmReport.strSQL = strSQL;
                    //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列

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
                                       and pri_fenlei <> '14 Fiber Cable' 
                                order  by ord.ord_beginxx ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "ordch";
                    frmReport.Text = "電源工單出貨計畫";
                    frmReport.strRP[0] = dt.Rows[0]["ord_orderid"].ToString() + "P";
                    frmReport.strRP[1] = dt.Rows[0]["odh_delivedate"].ToString();
                    frmReport.strRP[2] = dt.Rows[0]["odh_zm1"].ToString();
                    frmReport.strRP[3] = dt.Rows[0]["odh_cm"].ToString();
                    frmReport.strSQL = strSQL;
                    //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列

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
                                       and pri_fenlei = '14 Fiber Cable' 
                                order  by ord.ord_beginxx ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "ordch";
                    frmReport.Text = "光纖工單出貨計畫";
                    frmReport.strRP[0] = dt.Rows[0]["ord_orderid"].ToString() + "FO";
                    frmReport.strRP[1] = dt.Rows[0]["odh_delivedate"].ToString() ;
                    frmReport.strRP[2] = dt.Rows[0]["odh_zm1"].ToString();
                    frmReport.strRP[3] = dt.Rows[0]["odh_cm"].ToString();
                    frmReport.strSQL = strSQL;
                    //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列

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
                                       and pri_fenlei <> '14 Fiber Cable'
                                order  by ord.ord_beginxx ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "ordch";
                    frmReport.Text = "成朋工單出貨計畫";
                    frmReport.strRP[0] = dt.Rows[0]["ord_orderid"].ToString() + "W";
                    frmReport.strRP[1] = dt.Rows[0]["odh_delivedate"].ToString();
                    frmReport.strRP[2] = dt.Rows[0]["odh_zm1"].ToString();
                    frmReport.strRP[3] = dt.Rows[0]["odh_cm"].ToString();
                    frmReport.strSQL = strSQL;
                    //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列

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
                                       and pri_fenlei <> '14 Fiber Cable'
                                order  by ord.ord_beginxx ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "ordch";
                    frmReport.Text = "晶元工單出貨計畫";
                    frmReport.strRP[0] = dt.Rows[0]["ord_orderid"].ToString() + "H";
                    frmReport.strRP[1] = dt.Rows[0]["odh_delivedate"].ToString();
                    frmReport.strRP[2] = dt.Rows[0]["odh_zm1"].ToString();
                    frmReport.strRP[3] = dt.Rows[0]["odh_cm"].ToString();
                    frmReport.strSQL = strSQL;
                    //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列

                    frmReport.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
