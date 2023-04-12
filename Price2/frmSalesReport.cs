using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using System.Drawing.Printing;

namespace Price2
{
    public partial class frmSalesReport : Form
    {
        string strVendor = "";  //廠商
        string strSales = "";   //業務
        public frmSalesReport()
        {
            InitializeComponent();
        }

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                //加入分類
                strSQL = $@"select distinct Cast(left(pri_fenlei, 2) as INTEGER),
                                            pri_fenlei
                            from   pri
                            where  pri_fenlei <> ''
                            order  by Cast(left(pri_fenlei, 2) as INTEGER) ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboClass.Items.Add(dt.Rows[i]["pri_fenlei"].ToString());
                    }
                }
                //加入廠商
                strSQL = $@"select ven_id
                            from   ven ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboVendorID.Items.Add(dt.Rows[i]["ven_id"].ToString());
                    }
                }

                //確認權限
                if (clsGlobal.checkRightFlag("客戶成交查詢主管") == true)
                {
                    //加入部門
                    strSQL = $@"select pas_quote
                            from   pas
                            where  pas_username = '{clsGlobal.strG_User}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["pas_quote"].ToString() == "國內部" || dt.Rows[0]["pas_quote"].ToString() == "國外部" || dt.Rows[0]["pas_quote"].ToString() == "越南")
                        {
                            cboDivision.Items.Add(dt.Rows[0]["pas_quote"].ToString());
                            cboDivision.Text = dt.Rows[0]["pas_quote"].ToString();
                        }
                        else
                        {
                            cboDivision.Items.Add("國內部");
                            cboDivision.Items.Add("國外部");
                            cboDivision.Items.Add("越南");
                        }
                    }
                }
                else
                {
                    //加入部門
                    strSQL = $@"select pas_quote
                            from   pas
                            where  pas_username = '{clsGlobal.strG_User}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        cboDivision.Items.Add(dt.Rows[0]["pas_quote"].ToString());
                        cboDivision.Text = dt.Rows[0]["pas_quote"].ToString();
                    }
                    //限定業務
                    cboSales.Items.Clear();
                    cboSales.Items.Add(clsGlobal.strG_User);
                    cboSales.Text=clsGlobal.strG_User;
                    strSQL = $@"select distinct pas_ywcode
                        from   pas
                        where  pas_username = '{cboSales.Text}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        strSales = dt.Rows[0]["pas_ywcode"].ToString();
                    }
                }
                

                //日期
                dtpDateS.Value = new DateTime(DateTime.Now.Year, 1, 1); //本年年初;
                //dtpDateE.Value = new DateTime(DateTime.Now.Year, 12, 31); //本年年尾;
                dtpDateE.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                //dtpDateE.Text = DateTime.Now.ToString("yyyy/MM/dd");
                dtpYear.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                //dtpYear.Text = DateTime.Now.ToString("yyyy");
                //Chart
                setChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmSpecialExpenes_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            if(cboDivision.Text=="")
            {
                return;
            }
            cboSales.Items.Clear();
            strSQL = $@"select pas_username
                        from   ord
                               left join pas
                                      on ord_ywcode = pas_ywcode
                        where  pas_username != ''
                               and pas_quote = '{cboDivision.Text}'
                        group  by pas_username
                        order  by pas_username ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cboSales.Items.Add(dt.Rows[i]["pas_username"].ToString());
                }
            }
        }

        private void cboVendorID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboVendorID.Text=="")
            {
                strVendor = "";
            }
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select ven_shortname
                        from   ven
                        where  ven_id = '{cboVendorID.Text}' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strVendor=dt.Rows[0]["ven_shortname"].ToString();
            }
        }

        private void cboSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSales.Text == "")
            {
                strSales = "";
            }
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select distinct pas_ywcode
                        from   pas
                        where  pas_username = '{cboSales.Text}' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strSales = dt.Rows[0]["pas_ywcode"].ToString();
            }
            if(cboSales.Text == "jennifer")
            {
                cboJ.Visible= true;
            }
            else
            {
                cboJ.Visible = false;
                cboJ.Text = "";
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

        private void btnInq_Click(object sender, EventArgs e)
        {
            //查詢
            try
            {
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                if (radio1.Checked)
                {
                    getData1();
                }
                if (radio2.Checked)
                {
                    getData2();
                }
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string[] strQty = new string[6];        //數量
        string[] strRevenue = new string[6];    //成交
        string[] strProfit_Rate = new string[6];     //毛利率
        string[] strDateS = new string[6];      //起始日
        string[] strDateE = new string[6];      //結束日
        private void getData1()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            for (int i = 0; i<=5 ; i++)
            {
                //strDateS[i] = DateTime.Now.AddYears(-5 + i).ToString("yyyy") + "/" + dtpDateS.Value.ToString("MM/dd");
                //strDateE[i] = DateTime.Now.AddYears(-5 + i).ToString("yyyy") + "/" + dtpDateE.Value.ToString("MM/dd");
                strDateS[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/" + dtpDateS.Value.ToString("MM/dd");
                strDateE[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/" + dtpDateE.Value.ToString("MM/dd");
                strSQL = $@"select Sum(tab.ord_qty)                   QTY,
                                   ( Sum(tab.ord_pricost* tab.ord_qty) / Sum(tab.ord_convprice* tab.ord_qty) - 1 )                   PROFIT_RATE,
                                   Sum(tab.ord_pricost * tab.ord_qty) REVENUE
                            from   (
                                          select ord_qty,
                                                 ord_price,
                                                 ord_convprice,
                                                 ord_pricost,
                                                 odh_newdate
                                          from   ord,
                                                 odh,
                                                 odi
                                          where  ord_assy = odi_customerid
                                          and    ord_orderid = odh_orderid
                                          and    odh_newdate between '{strDateS[i]}' and '{strDateE[i]}' "
                                        + Get_strWhere()
                                        + ") tab ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count>0)
                {
                    strRevenue[i] = (string.IsNullOrEmpty(dt.Rows[0]["REVENUE"].ToString())?"0": dt.Rows[0]["REVENUE"].ToString());
                    strQty[i] = (string.IsNullOrEmpty(dt.Rows[0]["QTY"].ToString()) ? "0" : dt.Rows[0]["QTY"].ToString());
                    strProfit_Rate[i] = (string.IsNullOrEmpty(dt.Rows[0]["PROFIT_RATE"].ToString()) ? "0" : dt.Rows[0]["PROFIT_RATE"].ToString());
                }
            }

            //畫CHART
            getChart();

            //欄位輸入
            //數量/萬
            lblQty1.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[1]) ? "0" : strQty[1])) / 10000).ToString("0");
            lblQty2.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[2]) ? "0" : strQty[2])) / 10000).ToString("0");
            lblQty3.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[3]) ? "0" : strQty[3])) / 10000).ToString("0");
            lblQty4.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[4]) ? "0" : strQty[4])) / 10000).ToString("0");
            lblQty5.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[5]) ? "0" : strQty[5])) / 10000).ToString("0");
            //成交/萬
            lblR1.Text = (Convert.ToDouble(strRevenue[1]) / 10000).ToString("0");
            lblR2.Text = (Convert.ToDouble(strRevenue[2]) / 10000).ToString("0");
            lblR3.Text = (Convert.ToDouble(strRevenue[3]) / 10000).ToString("0");
            lblR4.Text = (Convert.ToDouble(strRevenue[4]) / 10000).ToString("0");
            lblR5.Text = (Convert.ToDouble(strRevenue[5]) / 10000).ToString("0");
            //毛利
            if ((Convert.ToDouble(strProfit_Rate[1]) * 100) > 0)
            {
                lblM1.ForeColor = Color.Red;
            }
            else
            {
                lblM1.ForeColor = Color.Green;
            }
            lblM1.Text = (Convert.ToDouble(strProfit_Rate[1]) * 100).ToString("0.##") + "%";

            if ((Convert.ToDouble(strProfit_Rate[2]) * 100) > 0)
            {
                lblM2.ForeColor = Color.Red;
            }
            else
            {
                lblM2.ForeColor = Color.Green;
            }
            lblM2.Text = (Convert.ToDouble(strProfit_Rate[2]) * 100).ToString("0.##") + "%";

            if ((Convert.ToDouble(strProfit_Rate[3]) * 100) > 0)
            {
                lblM3.ForeColor = Color.Red;
            }
            else
            {
                lblM3.ForeColor = Color.Green;
            }
            lblM3.Text = (Convert.ToDouble(strProfit_Rate[3]) * 100).ToString("0.##") + "%";

            if ((Convert.ToDouble(strProfit_Rate[4]) * 100) > 0)
            {
                lblM4.ForeColor = Color.Red;
            }
            else
            {
                lblM4.ForeColor = Color.Green;
            }
            lblM4.Text = (Convert.ToDouble(strProfit_Rate[4]) * 100).ToString("0.##") + "%";

            if ((Convert.ToDouble(strProfit_Rate[5]) * 100) > 0)
            {
                lblM5.ForeColor = Color.Red;
            }
            else
            {
                lblM5.ForeColor = Color.Green;
            }
            lblM5.Text = (Convert.ToDouble(strProfit_Rate[5]) * 100).ToString("0.##") + "%";

            //年增率
            if (Convert.ToDouble(strRevenue[0])==0)
            {
                lblY1.Text = "0"+"%";
                lblY1.ForeColor= Color.Green;
            }
            else
            {
                if((Convert.ToDouble(strRevenue[1])- Convert.ToDouble(strRevenue[0]))/ Convert.ToDouble(strRevenue[0])*100>0)
                {
                    lblY1.ForeColor = Color.Red;
                }
                else
                {
                    lblY1.ForeColor = Color.Green;
                }
                lblY1.Text = ((Convert.ToDouble(strRevenue[1]) - Convert.ToDouble(strRevenue[0])) / Convert.ToDouble(strRevenue[0]) * 100).ToString("0.##")+"%";
            }

            if (Convert.ToDouble(strRevenue[1]) == 0)
            {
                lblY2.Text = "0" + "%";
                lblY2.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strRevenue[2]) - Convert.ToDouble(strRevenue[1])) / Convert.ToDouble(strRevenue[1]) * 100 > 0)
                {
                    lblY2.ForeColor = Color.Red;
                }
                else
                {
                    lblY2.ForeColor = Color.Green;
                }
                lblY2.Text = ((Convert.ToDouble(strRevenue[2]) - Convert.ToDouble(strRevenue[1])) / Convert.ToDouble(strRevenue[1]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strRevenue[2]) == 0)
            {
                lblY3.Text = "0" + "%";
                lblY3.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strRevenue[3]) - Convert.ToDouble(strRevenue[2])) / Convert.ToDouble(strRevenue[2]) * 100 > 0)
                {
                    lblY3.ForeColor = Color.Red;
                }
                else
                {
                    lblY3.ForeColor = Color.Green;
                }
                lblY3.Text = ((Convert.ToDouble(strRevenue[3]) - Convert.ToDouble(strRevenue[2])) / Convert.ToDouble(strRevenue[2]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strRevenue[3]) == 0)
            {
                lblY4.Text = "0" + "%";
                lblY4.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strRevenue[4]) - Convert.ToDouble(strRevenue[3])) / Convert.ToDouble(strRevenue[3]) * 100 > 0)
                {
                    lblY4.ForeColor = Color.Red;
                }
                else
                {
                    lblY4.ForeColor = Color.Green;
                }
                lblY4.Text = ((Convert.ToDouble(strRevenue[4]) - Convert.ToDouble(strRevenue[3])) / Convert.ToDouble(strRevenue[3]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strRevenue[4]) == 0)
            {
                lblY5.Text = "0" + "%";
                lblY5.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strRevenue[5]) - Convert.ToDouble(strRevenue[4])) / Convert.ToDouble(strRevenue[4]) * 100 > 0)
                {
                    lblY5.ForeColor = Color.Red;
                }
                else
                {
                    lblY5.ForeColor = Color.Green;
                }
                lblY5.Text = ((Convert.ToDouble(strRevenue[5]) - Convert.ToDouble(strRevenue[4])) / Convert.ToDouble(strRevenue[4]) * 100).ToString("0.##") + "%";
            }
        }

        string[] strKS = new string[6];             //客訴
        string[] strProfit_Result = new string[6];  //利潤(結果)
        string[] strProfit = new string[6];         //利潤(依查詢條件)
        string[] strProfit_All = new string[6];     //總利潤(年度)
        string[] strSpecial = new string[6];        //特別支出
        string[] strSpecial_In = new string[6];     //特別支出排除國內部
        string[] strSpecial_Out = new string[6];    //特別支出排除國外部
        string[] strSpecial_All = new string[6];    //特別支出不計入全部
        private void getData2()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            for (int i = 0; i <= 5; i++)
            {
                //strDateS[i] = DateTime.Now.AddYears(-5 + i).ToString("yyyy") + "/" + dtpDateS.Value.ToString("MM/dd");
                //strDateE[i] = DateTime.Now.AddYears(-5 + i).ToString("yyyy") + "/" + dtpDateE.Value.ToString("MM/dd");
                strDateS[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/" + dtpDateS.Value.ToString("MM/dd");
                strDateE[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/" + dtpDateE.Value.ToString("MM/dd");
                strSQL = $@"select Sum(tab.ord_qty)                   QTY,
                                   ( Sum(tab.ord_pricost* tab.ord_qty) / Sum(tab.ord_convprice* tab.ord_qty) - 1 )                   PROFIT_RATE,
                                   Sum(tab.ord_pricost * tab.ord_qty) REVENUE
                            from   (
                                          select ord_qty,
                                                 ord_price,
                                                 ord_convprice,
                                                 ord_pricost,
                                                 odh_newdate
                                          from   ord,
                                                 odh,
                                                 odi
                                          where  ord_assy = odi_customerid
                                          and    ord_orderid = odh_orderid
                                          and    odh_newdate between '{strDateS[i]}' and '{strDateE[i]}' "
                                        + Get_strWhere()
                                        + ") tab ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strRevenue[i] = (string.IsNullOrEmpty(dt.Rows[0]["REVENUE"].ToString()) ? "0" : dt.Rows[0]["REVENUE"].ToString());
                    strQty[i] = (string.IsNullOrEmpty(dt.Rows[0]["QTY"].ToString()) ? "0" : dt.Rows[0]["QTY"].ToString());
                    strProfit_Rate[i] = (string.IsNullOrEmpty(dt.Rows[0]["PROFIT_RATE"].ToString()) ? "0" : dt.Rows[0]["PROFIT_RATE"].ToString());
                }


                //客訴
                strSQL = $@"select Isnull(Floor(Sum(( odc_qty - odc_cszr ) * odc_convert)), 0) as KS
                            from   odc
                            where  odc_adddate between '{strDateS[i]}' and '{strDateE[i]}'
                                    and odc_freason != '⊕'
                                    and odc_orderid in (select distinct odh_orderid
                                                        from ord,
                                                                odh,
                                                                odi
                                                        where ord_assy = odi_customerid
                                                                and ord_orderid = odh_orderid "
                                                              + Get_strWhere() 
                                                              + ") ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strKS[i] = (string.IsNullOrEmpty(dt.Rows[0]["KS"].ToString()) ? "0" : dt.Rows[0]["KS"].ToString());
                }

                //利潤(依查詢條件)
                strSQL = $@"select Isnull(Floor(Sum(( ord_pricost - ord_convprice ) * ord_qty)), 0) as PROFIT
                            from   ord,
                                   odh,
                                   odi
                            where  ord_assy = odi_customerid
                                   and ord_orderid = odh_orderid
                                   and odh_newdate between '{strDateS[i]}' and '{strDateE[i]}' "
                                 + Get_strWhere();
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strProfit[i] = (string.IsNullOrEmpty(dt.Rows[0]["PROFIT"].ToString()) ? "0" : dt.Rows[0]["PROFIT"].ToString());
                }

                //總利潤(年度)
                strSQL = $@"select Isnull(Floor(Sum(( ord_pricost - ord_convprice ) * ord_qty)), 0) as PROFIT_ALL
                            from   ord,
                                   odh,
                                   odi
                            where  ord_assy = odi_customerid
                                   and ord_orderid = odh_orderid
                                   and odh_newdate between '{strDateS[i]}' and '{strDateE[i]}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strProfit_All[i] = (string.IsNullOrEmpty(dt.Rows[0]["PROFIT_ALL"].ToString()) ? "0" : dt.Rows[0]["PROFIT_ALL"].ToString());
                }

                //特別支出
                strSQL = $@"select Isnull(Floor(Sum(odca_convcost)), 0) as SPECIAL
                            from   odca
                            where  odca_date between '{strDateS[i]}' and '{strDateE[i]}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strSpecial[i] = (string.IsNullOrEmpty(dt.Rows[0]["SPECIAL"].ToString()) ? "0" : dt.Rows[0]["SPECIAL"].ToString());
                }

                //特別支出排除國內部
                strSQL = $@"select Isnull(Floor(Sum(odca_convcost)), 0) as SPECIAL_IN
                            from   odca
                            where  odca_date between '{strDateS[i]}' and '{strDateE[i]}'
                                   and odca_division = '國內部' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strSpecial_In[i] = (string.IsNullOrEmpty(dt.Rows[0]["SPECIAL_IN"].ToString()) ? "0" : dt.Rows[0]["SPECIAL_IN"].ToString());
                }

                //特別支出排除國外部
                strSQL = $@"select Isnull(Floor(Sum(odca_convcost)), 0) as SPECIAL_OUT
                            from   odca
                            where  odca_date between '{strDateS[i]}' and '{strDateE[i]}'
                                   and odca_division = '國外部' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strSpecial_Out[i] = (string.IsNullOrEmpty(dt.Rows[0]["SPECIAL_OUT"].ToString()) ? "0" : dt.Rows[0]["SPECIAL_OUT"].ToString());
                }

                //特別支出不計入全部
                strSQL = $@"select Isnull(Floor(Sum(odca_convcost)), 0) as SPECIAL_ALL
                            from   odca
                            where  odca_date between '{strDateS[i]}' and '{strDateE[i]}'
                                   and odca_division = '全部' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strSpecial_All[i] = (string.IsNullOrEmpty(dt.Rows[0]["SPECIAL_ALL"].ToString()) ? "0" : dt.Rows[0]["SPECIAL_ALL"].ToString());
                }


                if (cboDivision.Text=="")
                {
                    //利潤=利潤(依查詢條件)-(特別支出-特別支出排除)*(利潤(依查詢條件)/總利潤(年度))
                    strProfit_Result[i] = (Convert.ToDouble(strProfit[i]) - (Convert.ToDouble(strSpecial[i]) - Convert.ToDouble(strSpecial_All[i])) * (Convert.ToDouble(strProfit[i]) / Convert.ToDouble(strProfit_All[i]))).ToString();
                }
                else if(cboDivision.Text == "國內部")
                {
                    //利潤 = 利潤(依查詢條件) - (特別支出 - 特別支出排除)*(利潤(依查詢條件)/總利潤(年度)) - 特別支出排除
                    strProfit_Result[i] = (Convert.ToDouble(strProfit[i]) - (Convert.ToDouble(strSpecial[i]) - Convert.ToDouble(strSpecial_All[i]) - Convert.ToDouble(strSpecial_In[i]) - Convert.ToDouble(strSpecial_Out[i])) * (Convert.ToDouble(strProfit[i]) / Convert.ToDouble(strProfit_All[i])) - Convert.ToDouble(strSpecial_Out[i])).ToString();
                }
                else
                {
                    //利潤 = 利潤(依查詢條件) - (特別支出 - 特別支出排除)*(利潤(依查詢條件)/總利潤(年度)) - 特別支出排除
                    strProfit_Result[i] = (Convert.ToDouble(strProfit[i]) - (Convert.ToDouble(strSpecial[i]) - Convert.ToDouble(strSpecial_All[i]) - Convert.ToDouble(strSpecial_In[i]) - Convert.ToDouble(strSpecial_Out[i])) * (Convert.ToDouble(strProfit[i]) / Convert.ToDouble(strProfit_All[i])) - Convert.ToDouble(strSpecial_In[i])).ToString();
                }
            }

            //畫CHART
            //準備數據
            string[] X = { strDateS[1] + "\n" + "至" + "\n" + strDateE[1],
                           strDateS[2] + "\n" + "至" + "\n" + strDateE[2],
                           strDateS[3] + "\n" + "至" + "\n" + strDateE[3],
                           strDateS[4] + "\n" + "至" + "\n" + strDateE[4],
                           strDateS[5] + "\n" + "至" + "\n" + strDateE[5] };
            double[] Y = { Convert.ToDouble((string.IsNullOrEmpty(strProfit_Result[1]) ? "0":strProfit_Result[1])),
                           Convert.ToDouble((string.IsNullOrEmpty(strProfit_Result[2]) ? "0":strProfit_Result[2])),
                           Convert.ToDouble((string.IsNullOrEmpty(strProfit_Result[3]) ? "0":strProfit_Result[3])),
                           Convert.ToDouble((string.IsNullOrEmpty(strProfit_Result[4]) ? "0":strProfit_Result[4])),
                           Convert.ToDouble((string.IsNullOrEmpty(strProfit_Result[5]) ? "0":strProfit_Result[5]))};

            //綁定數據
            chart1.Series["C"].Points.DataBindXY(X, Y);
            //顏色不同,不指定顏色
            chart1.Series["C"].Palette = ChartColorPalette.Bright;
            //顏色不同,指定顏色
            //chart1.Series["C"].Points[1].Color = Color.Green;

            //欄位輸入
            //數量/萬
            lblQty1.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[1]) ? "0" : strQty[1])) / 10000).ToString("0");
            lblQty2.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[2]) ? "0" : strQty[2])) / 10000).ToString("0");
            lblQty3.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[3]) ? "0" : strQty[3])) / 10000).ToString("0");
            lblQty4.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[4]) ? "0" : strQty[4])) / 10000).ToString("0");
            lblQty5.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[5]) ? "0" : strQty[5])) / 10000).ToString("0");
            //成交/萬
            lblR1.Text = (Convert.ToDouble(strProfit_Result[1]) / 10000).ToString("0");
            lblR2.Text = (Convert.ToDouble(strProfit_Result[2]) / 10000).ToString("0");
            lblR3.Text = (Convert.ToDouble(strProfit_Result[3]) / 10000).ToString("0");
            lblR4.Text = (Convert.ToDouble(strProfit_Result[4]) / 10000).ToString("0");
            lblR5.Text = (Convert.ToDouble(strProfit_Result[5]) / 10000).ToString("0");
            //毛利率
            if ((Convert.ToDouble(strProfit_Rate[1]) * 100) > 0)
            {
                lblM1.ForeColor = Color.Red;
            }
            else
            {
                lblM1.ForeColor = Color.Green;
            }
            lblM1.Text = (Convert.ToDouble(strProfit_Rate[1]) * 100).ToString("0.##") + "%";

            if ((Convert.ToDouble(strProfit_Rate[2]) * 100) > 0)
            {
                lblM2.ForeColor = Color.Red;
            }
            else
            {
                lblM2.ForeColor = Color.Green;
            }
            lblM2.Text = (Convert.ToDouble(strProfit_Rate[2]) * 100).ToString("0.##") + "%";

            if ((Convert.ToDouble(strProfit_Rate[3]) * 100) > 0)
            {
                lblM3.ForeColor = Color.Red;
            }
            else
            {
                lblM3.ForeColor = Color.Green;
            }
            lblM3.Text = (Convert.ToDouble(strProfit_Rate[3]) * 100).ToString("0.##") + "%";

            if ((Convert.ToDouble(strProfit_Rate[4]) * 100) > 0)
            {
                lblM4.ForeColor = Color.Red;
            }
            else
            {
                lblM4.ForeColor = Color.Green;
            }
            lblM4.Text = (Convert.ToDouble(strProfit_Rate[4]) * 100).ToString("0.##") + "%";

            if ((Convert.ToDouble(strProfit_Rate[5]) * 100) > 0)
            {
                lblM5.ForeColor = Color.Red;
            }
            else
            {
                lblM5.ForeColor = Color.Green;
            }
            lblM5.Text = (Convert.ToDouble(strProfit_Rate[5]) * 100).ToString("0.##") + "%";

            //年增率
            if (Convert.ToDouble(strRevenue[0]) == 0)
            {
                lblY1.Text = "0" + "%";
                lblY1.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strRevenue[1]) - Convert.ToDouble(strRevenue[0])) / Convert.ToDouble(strRevenue[0]) * 100 > 0)
                {
                    lblY1.ForeColor = Color.Red;
                }
                else
                {
                    lblY1.ForeColor = Color.Green;
                }
                lblY1.Text = ((Convert.ToDouble(strRevenue[1]) - Convert.ToDouble(strRevenue[0])) / Convert.ToDouble(strRevenue[0]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strRevenue[1]) == 0)
            {
                lblY2.Text = "0" + "%";
                lblY2.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strRevenue[2]) - Convert.ToDouble(strRevenue[1])) / Convert.ToDouble(strRevenue[1]) * 100 > 0)
                {
                    lblY2.ForeColor = Color.Red;
                }
                else
                {
                    lblY2.ForeColor = Color.Green;
                }
                lblY2.Text = ((Convert.ToDouble(strRevenue[2]) - Convert.ToDouble(strRevenue[1])) / Convert.ToDouble(strRevenue[1]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strRevenue[2]) == 0)
            {
                lblY3.Text = "0" + "%";
                lblY3.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strRevenue[3]) - Convert.ToDouble(strRevenue[2])) / Convert.ToDouble(strRevenue[2]) * 100 > 0)
                {
                    lblY3.ForeColor = Color.Red;
                }
                else
                {
                    lblY3.ForeColor = Color.Green;
                }
                lblY3.Text = ((Convert.ToDouble(strRevenue[3]) - Convert.ToDouble(strRevenue[2])) / Convert.ToDouble(strRevenue[2]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strRevenue[3]) == 0)
            {
                lblY4.Text = "0" + "%";
                lblY4.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strRevenue[4]) - Convert.ToDouble(strRevenue[3])) / Convert.ToDouble(strRevenue[3]) * 100 > 0)
                {
                    lblY4.ForeColor = Color.Red;
                }
                else
                {
                    lblY4.ForeColor = Color.Green;
                }
                lblY4.Text = ((Convert.ToDouble(strRevenue[4]) - Convert.ToDouble(strRevenue[3])) / Convert.ToDouble(strRevenue[3]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strRevenue[4]) == 0)
            {
                lblY5.Text = "0" + "%";
                lblY5.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strRevenue[5]) - Convert.ToDouble(strRevenue[4])) / Convert.ToDouble(strRevenue[4]) * 100 > 0)
                {
                    lblY5.ForeColor = Color.Red;
                }
                else
                {
                    lblY5.ForeColor = Color.Green;
                }
                lblY5.Text = ((Convert.ToDouble(strRevenue[5]) - Convert.ToDouble(strRevenue[4])) / Convert.ToDouble(strRevenue[4]) * 100).ToString("0.##") + "%";
            }
        }

        private string Get_strWhere()
        {
            string strWhere = "";

            //部門
            if(cboDivision.Text=="")
            {
                strWhere = strWhere + $@"and odi_customer != '168' ";
            }
            else if(cboDivision.Text == "國內部")
            {
                strWhere = strWhere + $@"and (odi_customer = '4' or substring(odi_customer,1,2) = '4-') ";
            }
            else if (cboDivision.Text == "越南")
            {
                strWhere = strWhere + $@"and odi_customer = '168' ";
            }
            else if (cboDivision.Text == "國外部")
            {
                strWhere = strWhere + $@"and (odi_customer != '4' and substring(odi_customer,1,2) != '4-'and odi_customer != '168') ";
            }
            else
            {
                strWhere = strWhere + $@"and odi_customer='{cboDivision.Text}' ";
            }
            //廠商
            strWhere = strWhere + (cboVendorID.Text == "" ? "" : $@"and odi_customerid in (select distinct pri_customerid from pri where pri_vendorid='{strVendor}') and odi_customerid in (select distinct ord_assy from ord) ");
            //業務
            strWhere = strWhere + (cboSales.Text == "" ? "" : $@"and ord_ywcode = '{strSales}' ");
            //分類
            strWhere = strWhere + (cboClass.Text == "" ? "" : $@"and odi_customerid in (select distinct pri_customerid from pri where pri_fenlei='{cboClass.Text}') ");
            //jennifer
            if (cboSales.Text == "jennifer" && cboJ.Text == "NO.1")
            {
                strWhere = strWhere + $@"and odi_customer in (select distinct cus_id from cus where cus_name like 'COMTOP%') ";
            }
            if (cboSales.Text == "jennifer" && cboJ.Text == "其他")
            {
                strWhere = strWhere + $@"and odi_customer not in (select distinct cus_id from cus where cus_name like 'COMTOP%') ";
            }
            return strWhere;
        }

        private void setChart()
        {
            //設置統計圖標題
            //chart1.Titles.Add("營業額");
            //設置XY軸上的標籤
            //chart1.ChartAreas[0].AxisX.Title = "年分";
            //chart1.ChartAreas[0].AxisY.Title = "萬";
            //設置Y軸數值不顯示
            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            //設定 X 軸線不要線
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Empty;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Empty;
            //增加統計對象
            chart1.Series.Add("C");
            chart1.Series["C"].LegendText = "";
            //設置統計對象統計圖類型
            chart1.Series["C"].ChartType = SeriesChartType.Column;
            //設置統計對象顏色
            chart1.Series["C"].Color = Color.Blue;
            //設置統計對象粗細, 單位PIXEL
            chart1.Series["C"].BorderWidth = 1;
            chart1.Series["C"]["PointWidth"] = "0.3";
            //設置XY軸上的值類型
            chart1.Series["C"].XValueType = ChartValueType.String;
            chart1.Series["C"].YValueType = ChartValueType.Double;
        }

        private void getChart()
        {
            //準備數據
            string[] X = { strDateS[1] + "\n" + "至" + "\n" + strDateE[1],
                           strDateS[2] + "\n" + "至" + "\n" + strDateE[2],
                           strDateS[3] + "\n" + "至" + "\n" + strDateE[3],
                           strDateS[4] + "\n" + "至" + "\n" + strDateE[4],
                           strDateS[5] + "\n" + "至" + "\n" + strDateE[5] };
            double[] Y = { Convert.ToDouble((string.IsNullOrEmpty(strRevenue[1]) ? "0":strRevenue[1])),
                           Convert.ToDouble((string.IsNullOrEmpty(strRevenue[2]) ? "0":strRevenue[2])),
                           Convert.ToDouble((string.IsNullOrEmpty(strRevenue[3]) ? "0":strRevenue[3])),
                           Convert.ToDouble((string.IsNullOrEmpty(strRevenue[4]) ? "0":strRevenue[4])),
                           Convert.ToDouble((string.IsNullOrEmpty(strRevenue[5]) ? "0":strRevenue[5]))};

            //綁定數據
            chart1.Series["C"].Points.DataBindXY(X, Y);
            //顏色不同,不指定顏色
            chart1.Series["C"].Palette = ChartColorPalette.Bright;
            //顏色不同,指定顏色
            //chart1.Series["C"].Points[1].Color = Color.Green;
        }

        private void chkAll_year_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAll_year.Checked) 
            {
                dtpDateS.Value = new DateTime(DateTime.Now.Year, 1, 1); //本年年初;
                dtpDateE.Value = new DateTime(DateTime.Now.Year, 12, 31); //本年年尾;
            }
        }

        private void dtpDateS_Enter(object sender, EventArgs e)
        {
            chkAll_year.Checked= false;
        }

        private void dtpDateE_Enter(object sender, EventArgs e)
        {
            chkAll_year.Checked = false;
        }

        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            if(radio1.Checked)
            {
                lbl2.Text = "成交/萬:";
                getClear();
            }
        }

        private void radio2_CheckedChanged(object sender, EventArgs e)
        {
            if (radio2.Checked)
            {
                lbl2.Text = "利潤/萬:";
                getClear();
            }
        }

        private void getClear()
        {
            lblQty1.Text = "";
            lblQty2.Text = "";
            lblQty3.Text = "";
            lblQty4.Text = "";
            lblQty5.Text = "";

            lblM1.Text = "";
            lblM2.Text = "";
            lblM3.Text = "";
            lblM4.Text = "";
            lblM5.Text = "";

            lblR1.Text = "";
            lblR2.Text = "";
            lblR3.Text = "";
            lblR4.Text = "";
            lblR5.Text = "";

            lblY1.Text = "";
            lblY2.Text = "";
            lblY3.Text = "";
            lblY4.Text = "";
            lblY5.Text = "";

            chart1.Series["C"].Points.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                getClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        Bitmap memoryImage;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);


            PrintPreviewDialog PPD = new PrintPreviewDialog();
            PPD.Document = new PrintDocument();
            PPD.Document.PrintPage += new PrintPageEventHandler(PD_PrintPage);
            PPD.Document.QueryPageSettings += new QueryPageSettingsEventHandler(PD_QueryPageSettings);
            PPD.Document.BeginPrint += new PrintEventHandler(PD_BeginPrint);
            //if (PPD.ShowDialog(this) == DialogResult.OK) { }


            ////寫到 += 的時候按下Tab鍵會自動跳出後面的內容

            //// 並且出現void PD_PrintPage(...)的列印事件

            //PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);

            //PrintPreviewDialog PPD = new PrintPreviewDialog();

            //PPD.Document = PD;

            //PPD.ShowDialog();

            PD.PrintController = new StandardPrintController();//不顯示對話框


            PD.Print();
        }


        private void PD_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
        private void PD_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            e.PageSettings.Landscape = true;
        }

        private void PD_BeginPrint(object sender, PrintEventArgs e)
        {

        }
    }
}
