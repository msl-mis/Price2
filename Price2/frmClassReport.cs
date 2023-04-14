using Sunny.UI.Win32;
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

namespace Price2
{
    public partial class frmClassReport : Form
    {
        string strVendor = "";  //廠商
        string strSales = "";   //業務
        public frmClassReport()
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

        private void frmClassReport_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                //加入分類
                //strSQL = $@"select distinct Cast(left(pri_fenlei, 2) as INTEGER),
                //                            pri_fenlei
                //            from   pri
                //            where  pri_fenlei <> ''
                //            order  by Cast(left(pri_fenlei, 2) as INTEGER) ";
                //dt = clsDB.sql_select_dt(strSQL);
                //if (dt.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        cboClass.Items.Add(dt.Rows[i]["pri_fenlei"].ToString());
                //    }
                //}
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
                    cboSales.Text = clsGlobal.strG_User;
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

        private void setChart()
        {
            //設置統計圖標題
            //chart1.Titles.Add("營業額");
            //設置XY軸上的標籤
            //chart1.ChartAreas[0].AxisX.Title = "年分";
            //chart1.ChartAreas[0].AxisY.Title = "萬";
            //設置Y軸數值不顯示
            chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            //設定 X 軸線不要線
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Empty;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Empty;
            
            //增加統計對象
            chart1.Series.Add("C");
            chart1.Series["C"].LegendText = "";
            //設置統計對象統計圖類型
            //chart1.Series["C"].ChartType = SeriesChartType.Column;
            chart1.Series["C"].ChartType = SeriesChartType.Bar;
            //設置統計對象顏色
            chart1.Series["C"].Color = Color.Blue;
            //設置統計對象粗細, 單位PIXEL
            chart1.Series["C"].BorderWidth = 1;
            chart1.Series["C"]["PointWidth"] = "0.3";
            //設置XY軸上的值類型
            //chart1.Series["C"].XValueType = ChartValueType.String;
            //chart1.Series["C"].YValueType = ChartValueType.Double;
            chart1.Series["C"].XValueType = ChartValueType.Double;
            chart1.Series["C"].YValueType = ChartValueType.String;

        }

        private void btnInq_Click(object sender, EventArgs e)
        {
            //查詢
            try
            {
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                getData();
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        string[] strRevenue = new string[15];    //成交
        string[] strProfit_Rate = new string[15];//毛利率
        string[] strDateS = new string[6];      //起始日
        string[] strDateE = new string[6];      //結束日

        string[] pf = new string[15];
        
        string strProfit0 = "";     //利潤(依查詢條件)去年
        string strProfit = "";      //利潤(依查詢條件)今年
        string[] strProfit0_Class = new string[15];     //利潤(分類)去年
        string[] strProfit_Class = new string[15];      //利潤(分類)今年
        string strSpecial0 = "";    //特別支出去年
        string strSpecial = "";     //特別支出今年
        string[] strKS0_Class = new string[15];     //客訴(分類)去年
        string[] strKS_Class = new string[15];      //客訴(分類)今年
        string[] strQty0_Class = new string[15];        //數量(分類)去年
        string[] strQty_Class = new string[15];        //數量(分類)今年
        double[] dblResult = new double[15];  //結果

        //取最大值
        double dblMax = 0;
        private void getData()
        {
            //取得日期
            for (int i = 0; i <= 1; i++)
            {
                //strDateS[i] = DateTime.Now.AddYears(-1 + i).ToString("yyyy") + "/" + dtpDateS.Value.ToString("MM/dd");
                //strDateE[i] = DateTime.Now.AddYears(-1 + i).ToString("yyyy") + "/" + dtpDateE.Value.ToString("MM/dd");
                strDateS[i] = (Convert.ToInt32(dtpYear.Text) - 1 + i).ToString() + "/" + dtpDateS.Value.ToString("MM/dd");
                strDateE[i] = (Convert.ToInt32(dtpYear.Text) - 1 + i).ToString() + "/" + dtpDateE.Value.ToString("MM/dd");
            }
            string strSQL = "";
            DataTable dt = new DataTable();
            //利潤(依查詢條件)去年
            strSQL = $@"select Isnull(Floor(Sum(( ord_pricost - ord_convprice ) * ord_qty)), 0) as PROFIT
                            from   ord,
                                   odh,
                                   odi
                            where  ord_assy = odi_customerid
                                   and ord_orderid = odh_orderid
                                   and odh_newdate between '{strDateS[0]}' and '{strDateE[0]}' "
                             + Get_strWhere();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strProfit0 = (string.IsNullOrEmpty(dt.Rows[0]["PROFIT"].ToString()) ? "0" : dt.Rows[0]["PROFIT"].ToString());
            }

            //利潤(依查詢條件)今年
            strSQL = $@"select Isnull(Floor(Sum(( ord_pricost - ord_convprice ) * ord_qty)), 0) as PROFIT
                            from   ord,
                                   odh,
                                   odi
                            where  ord_assy = odi_customerid
                                   and ord_orderid = odh_orderid
                                   and odh_newdate between '{strDateS[1]}' and '{strDateE[1]}' "
                             + Get_strWhere();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strProfit = (string.IsNullOrEmpty(dt.Rows[0]["PROFIT"].ToString()) ? "0" : dt.Rows[0]["PROFIT"].ToString());
            }

            //特別支出去年
            strSQL = $@"select Isnull(Floor(Sum(odca_convcost)), 0) as SPECIAL
                            from   odca
                            where  odca_date between '{strDateS[0]}' and '{strDateE[0]}' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strSpecial0 = (string.IsNullOrEmpty(dt.Rows[0]["SPECIAL"].ToString()) ? "0" : dt.Rows[0]["SPECIAL"].ToString());
            }

            //特別支出今年
            strSQL = $@"select Isnull(Floor(Sum(odca_convcost)), 0) as SPECIAL
                            from   odca
                            where  odca_date between '{strDateS[1]}' and '{strDateE[1]}' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strSpecial = (string.IsNullOrEmpty(dt.Rows[0]["SPECIAL"].ToString()) ? "0" : dt.Rows[0]["SPECIAL"].ToString());
            }


            strSQL = $@"select a1.pf,
                               Isnull(a1.PROFIT0, 0) as PROFIT0,
                               Isnull(a2.KS0, 0)     as KS0,
                               Isnull(a3.QTY0, 0)    as QTY0,
                               Isnull(a21.PROFIT, 0) as PROFIT,
                               Isnull(a22.KS, 0)     as KS,
                               Isnull(a23.QTY, 0)    as QTY
                        from   (select pb.pf,
                                       Isnull(Floor(Sum(( ord_pricost - ord_convprice ) * ord_qty)), 0) as PROFIT0
                                from   ord,
                                       odh,
                                       odi
                                       left join (select distinct pri_customerid as pid,
                                                                  pri_fenlei     as pf
                                                  from   pri
                                                  where  pri_newcostchk like 'N%') as pb
                                              on pb.pid = odi_customerid
                                where  ord_assy = odi_customerid
                                       and ord_orderid = odh_orderid
                                       and odh_newdate between '{strDateS[0]}' and '{strDateE[0]}' " + Get_strWhere() + $@"
                                group  by pb.pf) as a1
                               left join (select pa.pf,
                                                 Isnull(Floor(Sum(( odc_qty - odc_cszr ) * odc_convert)), 0) as KS0
                                          from   odc
                                                 left join (select distinct pri_customerid as pid,
                                                                            pri_fenlei     as pf
                                                            from   pri
                                                            where  pri_newcostchk like 'N%') as pa
                                                        on pa.pid = odc_customerid
                                          where  odc_adddate between '{strDateS[0]}' and '{strDateE[0]}' 
                                                 and odc_freason <> '⊕'
                                                 and odc_orderid in (select distinct odh_orderid
                                                                     from   ord,
                                                                            odh,
                                                                            odi
                                                                     where  ord_assy = odi_customerid " + Get_strWhere() + $@"
                                                                            and ord_orderid =
                                                                                odh_orderid)
                                          group  by pa.pf) as a2
                                      on a2.pf = a1.pf
                               left join (select pc.pf,
                                                 dbo.Formatstr(Isnull(Floor(Sum(ord_qty)), 0), 0) as QTY0
                                          from   ord,
                                                 odh,
                                                 odi
                                                 left join (select distinct pri_customerid as pid,
                                                                            pri_fenlei     as pf
                                                            from   pri
                                                            where  pri_newcostchk like 'N%') as pc
                                                        on pc.pid = odi_customerid
                                          where  ord_assy = odi_customerid
                                                 and ord_orderid = odh_orderid
                                                 and odh_newdate between '{strDateS[0]}' and '{strDateE[0]}' " + Get_strWhere() + $@"
                                          group  by pc.pf) as a3
                                      on a3.pf = a1.pf
                               left join (select pb.pf,
                                                 Isnull(Floor(Sum(( ord_pricost - ord_convprice ) * ord_qty)), 0) as PROFIT
                                          from   ord,
                                                 odh,
                                                 odi
                                                 left join (select distinct pri_customerid as pid,
                                                                            pri_fenlei     as pf
                                                            from   pri
                                                            where  pri_newcostchk like 'N%') as pb
                                                        on pb.pid = odi_customerid
                                          where  ord_assy = odi_customerid
                                                 and ord_orderid = odh_orderid
                                                 and odh_newdate between '{strDateS[1]}' and '{strDateE[1]}' " + Get_strWhere() + $@"
                                          group  by pb.pf) as a21
                                      on a21.pf = a1.pf
                               left join (select pa.pf,
                                                 Isnull(Floor(Sum(( odc_qty - odc_cszr ) * odc_convert)), 0) as KS
                                          from   odc
                                                 left join (select distinct pri_customerid as pid,
                                                                            pri_fenlei     as pf
                                                            from   pri
                                                            where  pri_newcostchk like 'N%') as pa
                                                        on pa.pid = odc_customerid
                                          where  odc_adddate between '{strDateS[1]}' and '{strDateE[1]}' 
                                                 and odc_freason <> '⊕'
                                                 and odc_orderid in (select distinct odh_orderid
                                                                     from   ord,
                                                                            odh,
                                                                            odi
                                                                     where  ord_assy = odi_customerid " + Get_strWhere() + $@"
                                                                            and ord_orderid =
                                                                                odh_orderid)
                                          group  by pa.pf) as a22
                                      on a22.pf = a1.pf
                               left join (select pc.pf,
                                                 dbo.Formatstr(Isnull(Floor(Sum(ord_qty)), 0), 0) as QTY
                                          from   ord,
                                                 odh,
                                                 odi
                                                 left join (select distinct pri_customerid as pid,
                                                                            pri_fenlei     as pf
                                                            from   pri
                                                            where  pri_newcostchk like 'N%') as pc
                                                        on pc.pid = odi_customerid
                                          where  ord_assy = odi_customerid
                                                 and ord_orderid = odh_orderid
                                                 and odh_newdate between '{strDateS[1]}' and '{strDateE[1]}' " + Get_strWhere() + $@"
                                          group  by pc.pf) as a23
                                      on a23.pf = a1.pf
                        order  by convert(INT, Substring(a1.pf, 1, 2)) desc ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dblMax = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    pf[i] = dt.Rows[i]["pf"].ToString();            //分類
                    strKS0_Class[i] = (string.IsNullOrEmpty(dt.Rows[i]["KS0"].ToString()) ? "0" : dt.Rows[i]["KS0"].ToString());  //客訴(分類)去年
                    strKS_Class[i] = (string.IsNullOrEmpty(dt.Rows[i]["KS"].ToString()) ? "0" : dt.Rows[i]["KS"].ToString());   //客訴(分類)今年
                    strProfit0_Class[i] = (string.IsNullOrEmpty(dt.Rows[i]["PROFIT0"].ToString()) ? "0" : dt.Rows[i]["PROFIT0"].ToString());     //利潤(分類)去年
                    strProfit0_Class[i] = (Convert.ToDouble(strProfit0_Class[i]) - Convert.ToDouble(strKS0_Class[i])).ToString();
                    strProfit0_Class[i] = (Convert.ToDouble(strProfit0_Class[i]) - Convert.ToDouble(strSpecial0) * (Convert.ToDouble(strProfit0_Class[i]) + Convert.ToDouble(strKS0_Class[i])) / Convert.ToDouble(strProfit0)).ToString("0");
                    strProfit_Class[i] = (string.IsNullOrEmpty(dt.Rows[i]["PROFIT"].ToString()) ? "0" : dt.Rows[i]["PROFIT"].ToString());     //利潤(分類)今年
                    strProfit_Class[i] = (Convert.ToDouble(strProfit_Class[i]) - Convert.ToDouble(strKS_Class[i])).ToString();
                    strProfit_Class[i] = (Convert.ToDouble(strProfit_Class[i]) - Convert.ToDouble(strSpecial) * (Convert.ToDouble(strProfit_Class[i]) + Convert.ToDouble(strKS_Class[i])) / Convert.ToDouble(strProfit)).ToString("0");
                    strQty0_Class[i] = (string.IsNullOrEmpty(dt.Rows[i]["QTY0"].ToString()) ? "0" : dt.Rows[i]["QTY0"].ToString());     //數量(分類)去年
                    strQty_Class[i] = (string.IsNullOrEmpty(dt.Rows[i]["QTY"].ToString()) ? "0" : dt.Rows[i]["QTY"].ToString());     //數量(分類)今年
                    //取最大值
                    if(Convert.ToDouble(strProfit_Class[i])> dblMax)
                    {
                        dblMax = Convert.ToDouble(strProfit_Class[i]);
                    }
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    if (radio1.Checked)
                    {
                        dblResult[i] = (strProfit0_Class[i] == "0" ? 0 : Convert.ToDouble(((Convert.ToDouble(strProfit_Class[i]) - Convert.ToDouble(strProfit0_Class[i])) / Convert.ToDouble(strProfit0_Class[i]) * 100).ToString("0.##")));
                    }
                    if (radio2.Checked)
                    {
                        dblResult[i] = (dblMax == 0 ? 0 : Convert.ToDouble((Convert.ToDouble(strProfit_Class[i]) / dblMax * 100).ToString("0.##")));
                    }
                }
                //畫CHART
                getChart();

                //欄位輸入
                getLable();
            }
            else
            {
                MessageBox.Show("查無資料!!" , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            
        }

        private string Get_strWhere()
        {
            string strWhere = "";

            //部門
            if (cboDivision.Text == "")
            {
                //strWhere = strWhere + $@"and odi_customer != '168' ";
            }
            else if (cboDivision.Text == "國內部")
            {
                strWhere = strWhere + $@"and (odi_customer = '4' or substring(odi_customer,1,2) = '4-') ";
            }
            else if (cboDivision.Text == "越南")
            {
                strWhere = strWhere + $@"and odi_customer = '168' ";
            }
            else if (cboDivision.Text == "國外部")
            {
                //strWhere = strWhere + $@"and (odi_customer != '4' and substring(odi_customer,1,2) != '4-'and odi_customer != '168') ";
                strWhere = strWhere + $@"and (odi_customer != '4' and substring(odi_customer,1,2) != '4-') ";
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
            //strWhere = strWhere + (cboClass.Text == "" ? "" : $@"and odi_customerid in (select distinct pri_customerid from pri where pri_fenlei='{cboClass.Text}') ");

            
            return strWhere;
        }

        private void getChart()
        {
            //準備數據
            
            double[] X = dblResult;
            string[] Y = pf;

            //綁定數據
            chart1.Series["C"].Points.DataBindXY(Y, X);
            //顏色不同,不指定顏色
            //chart1.Series["C"].Palette = ChartColorPalette.Bright;
            //顏色不同,指定顏色
            //取最大值
            double dblFinal = 0;

            for(int i=0;i<X.Length;i++)
            {
                if (dblResult[i] > 0)
                {
                    chart1.Series["C"].Points[i].Color = Color.Red;
                }
                else
                {
                    chart1.Series["C"].Points[i].Color = Color.Green;
                }
                if(Math.Abs(dblResult[i])> dblFinal)
                {
                    dblFinal = Math.Abs(dblResult[i]);
                }
            }
            chart1.ChartAreas[0].AxisY.Maximum = dblFinal;
            chart1.ChartAreas[0].AxisY.Minimum = -dblFinal;
            //chart1.Series["C"].Points[1].Color = Color.Green;
        }

        private void getLable()
        {
            //數量/萬
            lblQ15.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[0]) ? "0" : strQty_Class[0])) / 10000).ToString("0");
            lblQ14.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[1]) ? "0" : strQty_Class[1])) / 10000).ToString("0");
            lblQ13.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[2]) ? "0" : strQty_Class[2])) / 10000).ToString("0");
            lblQ12.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[3]) ? "0" : strQty_Class[3])) / 10000).ToString("0");
            lblQ11.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[4]) ? "0" : strQty_Class[4])) / 10000).ToString("0");
            lblQ10.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[5]) ? "0" : strQty_Class[5])) / 10000).ToString("0");
            lblQ9.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[6]) ? "0" : strQty_Class[6])) / 10000).ToString("0");
            lblQ8.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[7]) ? "0" : strQty_Class[7])) / 10000).ToString("0");
            lblQ7.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[8]) ? "0" : strQty_Class[8])) / 10000).ToString("0");
            lblQ6.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[9]) ? "0" : strQty_Class[9])) / 10000).ToString("0");
            lblQ5.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[10]) ? "0" : strQty_Class[10])) / 10000).ToString("0");
            lblQ4.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[11]) ? "0" : strQty_Class[11])) / 10000).ToString("0");
            lblQ3.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[12]) ? "0" : strQty_Class[12])) / 10000).ToString("0");
            lblQ2.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[13]) ? "0" : strQty_Class[13])) / 10000).ToString("0");
            lblQ1.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty_Class[14]) ? "0" : strQty_Class[14])) / 10000).ToString("0");
            //成交/萬
            lblP15.Text = (Convert.ToDouble(strProfit_Class[0]) / 10000).ToString("0");
            lblP14.Text = (Convert.ToDouble(strProfit_Class[1]) / 10000).ToString("0");
            lblP13.Text = (Convert.ToDouble(strProfit_Class[2]) / 10000).ToString("0");
            lblP12.Text = (Convert.ToDouble(strProfit_Class[3]) / 10000).ToString("0");
            lblP11.Text = (Convert.ToDouble(strProfit_Class[4]) / 10000).ToString("0");
            lblP10.Text = (Convert.ToDouble(strProfit_Class[5]) / 10000).ToString("0");
            lblP9.Text = (Convert.ToDouble(strProfit_Class[6]) / 10000).ToString("0");
            lblP8.Text = (Convert.ToDouble(strProfit_Class[7]) / 10000).ToString("0");
            lblP7.Text = (Convert.ToDouble(strProfit_Class[8]) / 10000).ToString("0");
            lblP6.Text = (Convert.ToDouble(strProfit_Class[9]) / 10000).ToString("0");
            lblP5.Text = (Convert.ToDouble(strProfit_Class[10]) / 10000).ToString("0");
            lblP4.Text = (Convert.ToDouble(strProfit_Class[11]) / 10000).ToString("0");
            lblP3.Text = (Convert.ToDouble(strProfit_Class[12]) / 10000).ToString("0");
            lblP2.Text = (Convert.ToDouble(strProfit_Class[13]) / 10000).ToString("0");
            lblP1.Text = (Convert.ToDouble(strProfit_Class[14]) / 10000).ToString("0");
            //年增率
            if ((Convert.ToDouble(dblResult[0])) > 0)
            {
                lblR15.ForeColor = Color.Red;
            }
            else
            {
                lblR15.ForeColor = Color.Green;
            }
            lblR15.Text = (Convert.ToDouble(dblResult[0])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[1])) > 0)
            {
                lblR14.ForeColor = Color.Red;
            }
            else
            {
                lblR14.ForeColor = Color.Green;
            }
            lblR14.Text = (Convert.ToDouble(dblResult[1])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[2])) > 0)
            {
                lblR13.ForeColor = Color.Red;
            }
            else
            {
                lblR13.ForeColor = Color.Green;
            }
            lblR13.Text = (Convert.ToDouble(dblResult[2])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[3])) > 0)
            {
                lblR12.ForeColor = Color.Red;
            }
            else
            {
                lblR12.ForeColor = Color.Green;
            }
            lblR12.Text = (Convert.ToDouble(dblResult[3])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[4])) > 0)
            {
                lblR11.ForeColor = Color.Red;
            }
            else
            {
                lblR11.ForeColor = Color.Green;
            }
            lblR11.Text = (Convert.ToDouble(dblResult[4])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[5])) > 0)
            {
                lblR10.ForeColor = Color.Red;
            }
            else
            {
                lblR10.ForeColor = Color.Green;
            }
            lblR10.Text = (Convert.ToDouble(dblResult[5])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[6])) > 0)
            {
                lblR9.ForeColor = Color.Red;
            }
            else
            {
                lblR9.ForeColor = Color.Green;
            }
            lblR9.Text = (Convert.ToDouble(dblResult[6])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[7])) > 0)
            {
                lblR8.ForeColor = Color.Red;
            }
            else
            {
                lblR8.ForeColor = Color.Green;
            }
            lblR8.Text = (Convert.ToDouble(dblResult[7])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[8])) > 0)
            {
                lblR7.ForeColor = Color.Red;
            }
            else
            {
                lblR7.ForeColor = Color.Green;
            }
            lblR7.Text = (Convert.ToDouble(dblResult[8])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[9])) > 0)
            {
                lblR6.ForeColor = Color.Red;
            }
            else
            {
                lblR6.ForeColor = Color.Green;
            }
            lblR6.Text = (Convert.ToDouble(dblResult[9])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[10])) > 0)
            {
                lblR5.ForeColor = Color.Red;
            }
            else
            {
                lblR5.ForeColor = Color.Green;
            }
            lblR5.Text = (Convert.ToDouble(dblResult[10])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[11])) > 0)
            {
                lblR4.ForeColor = Color.Red;
            }
            else
            {
                lblR4.ForeColor = Color.Green;
            }
            lblR4.Text = (Convert.ToDouble(dblResult[11])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[12])) > 0)
            {
                lblR3.ForeColor = Color.Red;
            }
            else
            {
                lblR3.ForeColor = Color.Green;
            }
            lblR3.Text = (Convert.ToDouble(dblResult[12])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[13])) > 0)
            {
                lblR2.ForeColor = Color.Red;
            }
            else
            {
                lblR2.ForeColor = Color.Green;
            }
            lblR2.Text = (Convert.ToDouble(dblResult[13])).ToString("0.##") + "%";

            if ((Convert.ToDouble(dblResult[14])) > 0)
            {
                lblR1.ForeColor = Color.Red;
            }
            else
            {
                lblR1.ForeColor = Color.Green;
            }
            lblR1.Text = (Convert.ToDouble(dblResult[14])).ToString("0.##") + "%";
        }

        private void chkAll_year_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll_year.Checked)
            {
                dtpDateS.Value = new DateTime(DateTime.Now.Year, 1, 1); //本年年初;
                dtpDateE.Value = new DateTime(DateTime.Now.Year, 12, 31); //本年年尾;
            }
        }

        private void dtpDateE_Enter(object sender, EventArgs e)
        {
            chkAll_year.Checked = false;
        }

        private void dtpDateS_Enter(object sender, EventArgs e)
        {
            chkAll_year.Checked = false;
        }

        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            if(radio1.Checked)
            {
                lbl3.Text = "年增率";
            }
            if (dblMax!=0)
            {
                for (int i = 0; i <15; i++)
                {
                    dblResult[i] = (strProfit0_Class[i] == "0" ? 0 : Convert.ToDouble(((Convert.ToDouble(strProfit_Class[i]) - Convert.ToDouble(strProfit0_Class[i])) / Convert.ToDouble(strProfit0_Class[i]) * 100).ToString("0.##")));
                }
                //畫圖
                getChart();
                //欄位輸入
                getLable();
            }
        }

        private void radio2_CheckedChanged(object sender, EventArgs e)
        {
            if (radio2.Checked)
            {
                lbl3.Text = "成交比";
            }
            if (dblMax != 0)
            {
                for (int i = 0; i < 15; i++)
                {
                    dblResult[i] = (dblMax == 0 ? 0 : Convert.ToDouble((Convert.ToDouble(strProfit_Class[i]) / dblMax * 100).ToString("0.##")));
                }
                //畫圖
                getChart();
                //欄位輸入
                getLable();
            }
        }

        private void cboDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            if (cboDivision.Text == "")
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
        }

        private void cboVendorID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVendorID.Text == "")
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
                strVendor = dt.Rows[0]["ven_shortname"].ToString();
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

            //建立列印物件
            PD = new PrintDocument();
            //加入列印事件(當要送出資料列印時觸發)
            PD.PrintPage += new PrintPageEventHandler(PD_PrintPage);
            PD.QueryPageSettings += new QueryPageSettingsEventHandler(PD_QueryPageSettings);

            PD.PrintController = new StandardPrintController();//不顯示對話框
            PD.Print();
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

        private void getClear()
        {
            lblQ1.Text = "";
            lblQ2.Text = "";
            lblQ3.Text = "";
            lblQ4.Text = "";
            lblQ5.Text = "";
            lblQ6.Text = "";
            lblQ7.Text = "";
            lblQ8.Text = "";
            lblQ9.Text = "";
            lblQ10.Text = "";
            lblQ11.Text = "";
            lblQ12.Text = "";
            lblQ13.Text = "";
            lblQ14.Text = "";
            lblQ15.Text = "";


            lblR1.Text = "";
            lblR2.Text = "";
            lblR3.Text = "";
            lblR4.Text = "";
            lblR5.Text = "";
            lblR6.Text = "";
            lblR7.Text = "";
            lblR8.Text = "";
            lblR9.Text = "";
            lblR10.Text = "";
            lblR11.Text = "";
            lblR12.Text = "";
            lblR13.Text = "";
            lblR14.Text = "";
            lblR15.Text = "";

            lblP1.Text = "";
            lblP2.Text = "";
            lblP3.Text = "";
            lblP4.Text = "";
            lblP5.Text = "";
            lblP6.Text = "";
            lblP7.Text = "";
            lblP8.Text = "";
            lblP9.Text = "";
            lblP10.Text = "";
            lblP11.Text = "";
            lblP12.Text = "";
            lblP13.Text = "";
            lblP14.Text = "";
            lblP15.Text = "";

            chart1.Series["C"].Points.Clear();
        }

        private void PD_BeginPrint(object sender, PrintEventArgs e)
        {

        }

        private void PD_PrintPage(object sender, PrintPageEventArgs e)
        {
            //e.Graphics.DrawImage(memoryImage, 0, 0);
            //e.Graphics.DrawImage(memoryImage, e.PageBounds);
            e.Graphics.DrawImage(memoryImage, e.MarginBounds);
        }

        private void PD_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            e.PageSettings.Landscape = true;
        }
    }
}
