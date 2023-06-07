using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Price2
{
    public partial class frmComplaintReport : Form
    {
        string strYear = "";    //年分
        public frmComplaintReport()
        {
            InitializeComponent();
        }

        private void frmComplaintReport_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                
                


                //日期
                dtpDateS.Value = new DateTime(DateTime.Now.Year, 1, 1); //本年年初;
                dtpDateE.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                //dtpYear.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                strYear = DateTime.Now.Year.ToString();

                dtpDate2S.Value = new DateTime(DateTime.Now.Year, 1, 1); //本年年初;
                dtpDate2E.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                //dtpYear2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                //Chart
                setChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmSalesReport_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //設定 X 軸線不要線
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Empty;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Empty;
            //增加統計對象
            chart1.Series.Add("CT");
            chart1.Series["CT"].LegendText = "客訴總額";
            //設置統計對象統計圖類型
            chart1.Series["CT"].ChartType = SeriesChartType.Column;
            //設置統計對象顏色
            chart1.Series["CT"].Color = Color.Blue;
            //chart1.Series["CT"].Palette = ChartColorPalette.BrightPastel;
            //設置統計對象粗細, 單位PIXEL
            chart1.Series["CT"].BorderWidth = 1;
            chart1.Series["CT"]["PointWidth"] = "0.4";
            //設置XY軸上的值類型
            chart1.Series["CT"].XValueType = ChartValueType.String;
            chart1.Series["CT"].YValueType = ChartValueType.Double;

            //增加統計對象
            chart1.Series.Add("CF");
            chart1.Series["CF"].LegendText = "工廠承擔金額";
            //設置統計對象統計圖類型
            chart1.Series["CF"].ChartType = SeriesChartType.Column;
            //設置統計對象顏色
            chart1.Series["CF"].Color = Color.SaddleBrown;
            //設置統計對象粗細, 單位PIXEL
            chart1.Series["CF"].BorderWidth = 1;
            chart1.Series["CF"]["PointWidth"] = "0.4";
            //設置XY軸上的值類型
            chart1.Series["CF"].XValueType = ChartValueType.String;
            chart1.Series["CF"].YValueType = ChartValueType.Double;

            //增加統計對象
            chart1.Series.Add("CV");
            chart1.Series["CV"].LegendText = "供應商承擔金額";
            //設置統計對象統計圖類型
            chart1.Series["CV"].ChartType = SeriesChartType.Column;
            //設置統計對象顏色
            chart1.Series["CV"].Color = Color.Fuchsia;
            //設置統計對象粗細, 單位PIXEL
            chart1.Series["CV"].BorderWidth = 1;
            chart1.Series["CV"]["PointWidth"] = "0.4";
            //設置XY軸上的值類型
            chart1.Series["CV"].XValueType = ChartValueType.String;
            chart1.Series["CV"].YValueType = ChartValueType.Double;

            //增加統計對象
            chart1.Series.Add("CC");
            chart1.Series["CC"].LegendText = "公司承擔金額";
            //設置統計對象統計圖類型
            chart1.Series["CC"].ChartType = SeriesChartType.Column;
            //設置統計對象顏色
            chart1.Series["CC"].Color = Color.Green;
            //設置統計對象粗細, 單位PIXEL
            chart1.Series["CC"].BorderWidth = 1;
            chart1.Series["CC"]["PointWidth"] = "0.4";
            //設置XY軸上的值類型
            chart1.Series["CC"].XValueType = ChartValueType.String;
            chart1.Series["CC"].YValueType = ChartValueType.Double;



            //設置Y軸數值不顯示
            chart2.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            //設定 X 軸線不要線
            chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Empty;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Empty;
            //增加統計對象
            chart2.Series.Add("C");
            chart2.Series["C"].LegendText = "";
            //設置統計對象統計圖類型
            chart2.Series["C"].ChartType = SeriesChartType.Column;
            //設置統計對象顏色
            //chart2.Series["C"].Color = Color.Blue;
            chart2.Series["C"].Palette = ChartColorPalette.BrightPastel;
            //設置統計對象粗細, 單位PIXEL
            chart2.Series["C"].BorderWidth = 1;
            chart2.Series["C"]["PointWidth"] = "0.3";
            //設置XY軸上的值類型
            chart2.Series["C"].XValueType = ChartValueType.String;
            chart2.Series["C"].YValueType = ChartValueType.Double;
        }

        string[] strCT = new string[6];         //客訴總額
        string[] strCF = new string[6];         //工廠承擔金額
        string[] strCV = new string[6];         //供應商承擔金額
        string[] strCC = new string[6];         //公司承擔金額
        string[] strDateS = new string[6];      //起始日
        string[] strDateE = new string[6];      //結束日
        private void getData1()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            for (int i = 0; i <= 5; i++)
            {
                //strDateS[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/" + dtpDateS.Value.ToString("MM/dd");
                //strDateE[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/" + dtpDateE.Value.ToString("MM/dd");
                strDateS[i] = (Convert.ToInt32(strYear) - 5 + i).ToString() + "/" + dtpDateS.Value.ToString("MM/dd");
                strDateE[i] = (Convert.ToInt32(strYear) - 5 + i).ToString() + "/" + dtpDateE.Value.ToString("MM/dd");
                strSQL = $@"select Isnull(Round(Sum(odc_qty * odc_convert), 0), 0)                   as
                                   CT,
                                   Isnull(Round(Sum(odc_cszr * odc_convert), 0), 0)                   as
                                   CV
                            from   odc,
                                   odh
                            where  odh_orderid = odc_orderid
                                   and odc_adddate between '{strDateS[i]}' and '{strDateE[i]}' "
                                + Get_strWhere();

                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strCT[i] = (string.IsNullOrEmpty(dt.Rows[0]["CT"].ToString()) ? "0" : dt.Rows[0]["CT"].ToString());
                    strCV[i] = (string.IsNullOrEmpty(dt.Rows[0]["CV"].ToString()) ? "0" : dt.Rows[0]["CV"].ToString());
                    strCF[i] = ((Convert.ToDouble(strCT[i])- Convert.ToDouble(strCV[i]))*0.2).ToString();
                    strCC[i] = (Convert.ToDouble(strCT[i]) - Convert.ToDouble(strCV[i]) - Convert.ToDouble(strCF[i])).ToString();
                }
            }
            //畫CHART
            getChart1();
            //欄位輸入
            getLable1();
        }

        string[] strKS = new string[6];         //工廠每年客訴金額
        string[] strDate2S = new string[6];      //起始日
        string[] strDate2E = new string[6];      //結束日
        private void getData2()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            for (int i = 0; i <= 5; i++)
            {
                //strDate2S[i] = (Convert.ToInt32(dtpYear2.Text) - 5 + i).ToString() + "/" + dtpDate2S.Value.ToString("MM/dd");
                //strDate2E[i] = (Convert.ToInt32(dtpYear2.Text) - 5 + i).ToString() + "/" + dtpDate2E.Value.ToString("MM/dd");
                strDate2S[i] = (Convert.ToInt32(strYear) - 5 + i).ToString() + "/" + dtpDate2S.Value.ToString("MM/dd");
                strDate2E[i] = (Convert.ToInt32(strYear) - 5 + i).ToString() + "/" + dtpDate2E.Value.ToString("MM/dd");
                strSQL = $@"select Isnull(Round(( ab.toc - aa.tocc ) * 0.2 / (select cur_convert
                                                                              from   cur
                                                                              where  cur_code = '人民幣')
                                          , 0), 0
                                   ) as KS
                            from   (select Isnull(Round(Sum(odc_cszr * odc_convert), 0), 0) as tocc
                                    from   odc
                                    where  odc_adddate between '{strDate2S[i]}' and '{strDate2E[i]}' "
                                        + Get_strWhere()
                                        + $@"
                                           and odc_freason <> '⊕') as aa,
                                   (select Isnull(Round(Sum(odc_ksval), 0), 0) as toc
                                    from   odc
                                    where  odc_adddate between '{strDate2S[i]}' and '{strDate2E[i]}' "
                                        + Get_strWhere()
                                        + $@"
                                           and odc_freason <> '⊕') as ab ";

                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strKS[i] = (string.IsNullOrEmpty(dt.Rows[0]["KS"].ToString()) ? "0" : dt.Rows[0]["KS"].ToString());
                    
                }
            }
            //畫CHART
            getChart2();
            //欄位輸入
            getLable2();
        }

        private void getChart1()
        {
            //準備數據
            string[] X = { strDateS[1] + "\n" + "至" + "\n" + strDateE[1],
                           strDateS[2] + "\n" + "至" + "\n" + strDateE[2],
                           strDateS[3] + "\n" + "至" + "\n" + strDateE[3],
                           strDateS[4] + "\n" + "至" + "\n" + strDateE[4],
                           strDateS[5] + "\n" + "至" + "\n" + strDateE[5] };
            double[] Y = { Convert.ToDouble((string.IsNullOrEmpty(strCT[1]) ? "0":strCT[1])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCT[2]) ? "0":strCT[2])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCT[3]) ? "0":strCT[3])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCT[4]) ? "0":strCT[4])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCT[5]) ? "0":strCT[5]))};

            //綁定數據
            chart1.Series["CT"].Points.DataBindXY(X, Y);

            string[] X2 = { strDateS[1] + "\n" + "至" + "\n" + strDateE[1],
                           strDateS[2] + "\n" + "至" + "\n" + strDateE[2],
                           strDateS[3] + "\n" + "至" + "\n" + strDateE[3],
                           strDateS[4] + "\n" + "至" + "\n" + strDateE[4],
                           strDateS[5] + "\n" + "至" + "\n" + strDateE[5] };
            double[] Y2 = { Convert.ToDouble((string.IsNullOrEmpty(strCF[1]) ? "0":strCF[1])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCF[2]) ? "0":strCF[2])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCF[3]) ? "0":strCF[3])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCF[4]) ? "0":strCF[4])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCF[5]) ? "0":strCF[5]))};

            //綁定數據
            chart1.Series["CF"].Points.DataBindXY(X2, Y2);

            string[] X3 = { strDateS[1] + "\n" + "至" + "\n" + strDateE[1],
                           strDateS[2] + "\n" + "至" + "\n" + strDateE[2],
                           strDateS[3] + "\n" + "至" + "\n" + strDateE[3],
                           strDateS[4] + "\n" + "至" + "\n" + strDateE[4],
                           strDateS[5] + "\n" + "至" + "\n" + strDateE[5] };
            double[] Y3 = { Convert.ToDouble((string.IsNullOrEmpty(strCV[1]) ? "0":strCV[1])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCV[2]) ? "0":strCV[2])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCV[3]) ? "0":strCV[3])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCV[4]) ? "0":strCV[4])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCV[5]) ? "0":strCV[5]))};

            //綁定數據
            chart1.Series["CV"].Points.DataBindXY(X3, Y3);

            string[] X4 = { strDateS[1] + "\n" + "至" + "\n" + strDateE[1],
                           strDateS[2] + "\n" + "至" + "\n" + strDateE[2],
                           strDateS[3] + "\n" + "至" + "\n" + strDateE[3],
                           strDateS[4] + "\n" + "至" + "\n" + strDateE[4],
                           strDateS[5] + "\n" + "至" + "\n" + strDateE[5] };
            double[] Y4 = { Convert.ToDouble((string.IsNullOrEmpty(strCC[1]) ? "0":strCC[1])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCC[2]) ? "0":strCC[2])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCC[3]) ? "0":strCC[3])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCC[4]) ? "0":strCC[4])),
                           Convert.ToDouble((string.IsNullOrEmpty(strCC[5]) ? "0":strCC[5]))};

            //綁定數據
            chart1.Series["CC"].Points.DataBindXY(X4, Y4);

        }

        private void getLable1()
        {
            //客訴總額
            lblCT5.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCT[5]) ? "0" : strCT[5])) ).ToString("N0");
            lblCT4.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCT[4]) ? "0" : strCT[4])) ).ToString("N0");
            lblCT3.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCT[3]) ? "0" : strCT[3])) ).ToString("N0");
            lblCT2.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCT[2]) ? "0" : strCT[2])) ).ToString("N0");
            lblCT1.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCT[1]) ? "0" : strCT[1])) ).ToString("N0");
            //工廠承擔金額
            lblCF5.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCF[5]) ? "0" : strCF[5]))).ToString("N0");
            lblCF4.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCF[4]) ? "0" : strCF[4]))).ToString("N0");
            lblCF3.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCF[3]) ? "0" : strCF[3]))).ToString("N0");
            lblCF2.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCF[2]) ? "0" : strCF[2]))).ToString("N0");
            lblCF1.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCF[1]) ? "0" : strCF[1]))).ToString("N0");
            //供應商承擔金額
            lblCV5.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCV[5]) ? "0" : strCV[5]))).ToString("N0");
            lblCV4.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCV[4]) ? "0" : strCV[4]))).ToString("N0");
            lblCV3.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCV[3]) ? "0" : strCV[3]))).ToString("N0");
            lblCV2.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCV[2]) ? "0" : strCV[2]))).ToString("N0");
            lblCV1.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCV[1]) ? "0" : strCV[1]))).ToString("N0");
            //公司承擔金額
            lblCC5.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCC[5]) ? "0" : strCC[5]))).ToString("N0");
            lblCC4.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCC[4]) ? "0" : strCC[4]))).ToString("N0");
            lblCC3.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCC[3]) ? "0" : strCC[3]))).ToString("N0");
            lblCC2.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCC[2]) ? "0" : strCC[2]))).ToString("N0");
            lblCC1.Text = (Convert.ToDouble((string.IsNullOrEmpty(strCC[1]) ? "0" : strCC[1]))).ToString("N0");
        }

        private void getChart2()
        {
            //準備數據
            string[] X = { strDate2S[1] + "\n" + "至" + "\n" + strDate2E[1],
                           strDate2S[2] + "\n" + "至" + "\n" + strDate2E[2],
                           strDate2S[3] + "\n" + "至" + "\n" + strDate2E[3],
                           strDate2S[4] + "\n" + "至" + "\n" + strDate2E[4],
                           strDate2S[5] + "\n" + "至" + "\n" + strDate2E[5] };
            double[] Y = { Convert.ToDouble((string.IsNullOrEmpty(strKS[1]) ? "0":strKS[1])),
                           Convert.ToDouble((string.IsNullOrEmpty(strKS[2]) ? "0":strKS[2])),
                           Convert.ToDouble((string.IsNullOrEmpty(strKS[3]) ? "0":strKS[3])),
                           Convert.ToDouble((string.IsNullOrEmpty(strKS[4]) ? "0":strKS[4])),
                           Convert.ToDouble((string.IsNullOrEmpty(strKS[5]) ? "0":strKS[5]))};

            //綁定數據
            chart2.Series["C"].Points.DataBindXY(X, Y);

            

        }

        private void getLable2()
        {
            //累計賠償額(RMB)
            lblKS5.Text = (Convert.ToDouble((string.IsNullOrEmpty(strKS[5]) ? "0" : strKS[5]))).ToString("N0");
            lblKS4.Text = (Convert.ToDouble((string.IsNullOrEmpty(strKS[4]) ? "0" : strKS[4]))).ToString("N0");
            lblKS3.Text = (Convert.ToDouble((string.IsNullOrEmpty(strKS[3]) ? "0" : strKS[3]))).ToString("N0");
            lblKS2.Text = (Convert.ToDouble((string.IsNullOrEmpty(strKS[2]) ? "0" : strKS[2]))).ToString("N0");
            lblKS1.Text = (Convert.ToDouble((string.IsNullOrEmpty(strKS[1]) ? "0" : strKS[1]))).ToString("N0");
            //增長比率
            if (Convert.ToDouble(strKS[0]) == 0)
            {
                lblR1.Text = "0" + "%";
                lblR1.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strKS[1]) - Convert.ToDouble(strKS[0])) / Convert.ToDouble(strKS[0]) * 100 > 0)
                {
                    lblR1.ForeColor = Color.Red;
                }
                else
                {
                    lblR1.ForeColor = Color.Green;
                }
                lblR1.Text = ((Convert.ToDouble(strKS[1]) - Convert.ToDouble(strKS[0])) / Convert.ToDouble(strKS[0]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strKS[1]) == 0)
            {
                lblR2.Text = "0" + "%";
                lblR2.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strKS[2]) - Convert.ToDouble(strKS[1])) / Convert.ToDouble(strKS[1]) * 100 > 0)
                {
                    lblR2.ForeColor = Color.Red;
                }
                else
                {
                    lblR2.ForeColor = Color.Green;
                }
                lblR2.Text = ((Convert.ToDouble(strKS[2]) - Convert.ToDouble(strKS[1])) / Convert.ToDouble(strKS[1]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strKS[2]) == 0)
            {
                lblR3.Text = "0" + "%";
                lblR3.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strKS[3]) - Convert.ToDouble(strKS[2])) / Convert.ToDouble(strKS[2]) * 100 > 0)
                {
                    lblR3.ForeColor = Color.Red;
                }
                else
                {
                    lblR3.ForeColor = Color.Green;
                }
                lblR3.Text = ((Convert.ToDouble(strKS[3]) - Convert.ToDouble(strKS[2])) / Convert.ToDouble(strKS[2]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strKS[3]) == 0)
            {
                lblR4.Text = "0" + "%";
                lblR4.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strKS[4]) - Convert.ToDouble(strKS[3])) / Convert.ToDouble(strKS[3]) * 100 > 0)
                {
                    lblR4.ForeColor = Color.Red;
                }
                else
                {
                    lblR4.ForeColor = Color.Green;
                }
                lblR4.Text = ((Convert.ToDouble(strKS[4]) - Convert.ToDouble(strKS[3])) / Convert.ToDouble(strKS[3]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strKS[4]) == 0)
            {
                lblR5.Text = "0" + "%";
                lblR5.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strKS[5]) - Convert.ToDouble(strKS[4])) / Convert.ToDouble(strKS[4]) * 100 > 0)
                {
                    lblR5.ForeColor = Color.Red;
                }
                else
                {
                    lblR5.ForeColor = Color.Green;
                }
                lblR5.Text = ((Convert.ToDouble(strKS[5]) - Convert.ToDouble(strKS[4])) / Convert.ToDouble(strKS[4]) * 100).ToString("0.##") + "%";
            }
        }

        private string Get_strWhere()
        {
            string strWhere = "";

            //部門
            if (cboDivision.Text == "")
            {
                strWhere = strWhere + $@"and odc_customer <> 'dsfasd' ";
            }
            else if (cboDivision.Text == "國內部")
            {
                strWhere = strWhere + $@"and (odc_customer = '4' or substring(odc_customer,1,2) = '4-') ";
            }
            else if (cboDivision.Text == "國外部")
            {
                strWhere = strWhere + $@"and (odc_customer != '4' and substring(odc_customer,1,2) != '4-') ";
            }
            return strWhere;
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

        private void chkAll_year_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll_year.Checked)
            {
                dtpDateS.Value = new DateTime(DateTime.Now.Year, 1, 1); //本年年初;
                dtpDateE.Value = new DateTime(DateTime.Now.Year, 12, 31); //本年年尾;
            }
        }

        private void dtpDateS_Enter(object sender, EventArgs e)
        {
            chkAll_year.Checked = false;
        }

        private void dtpDateE_Enter(object sender, EventArgs e)
        {
            chkAll_year.Checked = false;
        }

        private void chkAll_year2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll_year2.Checked)
            {
                dtpDate2S.Value = new DateTime(DateTime.Now.Year, 1, 1); //本年年初;
                dtpDate2E.Value = new DateTime(DateTime.Now.Year, 12, 31); //本年年尾;
            }
        }

        private void dtpDate2S_Enter(object sender, EventArgs e)
        {
            chkAll_year2.Checked = false;
        }

        private void dtpDate2E_Enter(object sender, EventArgs e)
        {
            chkAll_year2.Checked = false;
        }

        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible= radio1.Checked;
            panel11.Visible = radio1.Checked;
        }

        private void radio2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = radio2.Checked;
            panel22.Visible = radio2.Checked;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty( strDate2S[1]))
            {
                return;
            }
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select odh_customer                                        '客戶',
                               odh_orderid                                         '工單號',
                               Round(odc_qty * odc_convert, 0)
                               '工單客訴額(NTD)',
                               Round(odc_qty * odc_convert * 0.2, 0)
                               '工廠累計賠償額(NTD)',
                               Round(odc_qty * odc_convert * 0.2 / cur_convert, 0)
                               '工廠累計賠償額(RMB)',
                               odh_newdate                                         '工單新建日期',
                               odc_adddate                                         '客訴日期',
                               odh_odcbz                                           '備註'
                        from   odh
                               left join odc
                                      on odc_orderid = odh_orderid
                               left join cur
                                      on cur_code = '人民幣'
                        where  odc_adddate between '{strDate2S[1]}' and '{strDate2E[1]}' "
                                        + Get_strWhere()
                                        + $@"
                               and odc_freason <> '⊕'
                        order  by odh_customer,
                                  odh_orderid ";
            frmComplaintReport_Inq frmComplaintReport_Inq = new frmComplaintReport_Inq();
            frmComplaintReport_Inq.ShowInTaskbar = false;//圖示不顯示在工作列
            frmComplaintReport_Inq.rstrSQL = strSQL;
            frmComplaintReport_Inq.ShowDialog();

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(strDate2S[2]))
            {
                return;
            }
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select odh_customer                                        '客戶',
                               odh_orderid                                         '工單號',
                               Round(odc_qty * odc_convert, 0)
                               '工單客訴額(NTD)',
                               Round(odc_qty * odc_convert * 0.2, 0)
                               '工廠累計賠償額(NTD)',
                               Round(odc_qty * odc_convert * 0.2 / cur_convert, 0)
                               '工廠累計賠償額(RMB)',
                               odh_newdate                                         '工單新建日期',
                               odc_adddate                                         '客訴日期',
                               odh_odcbz                                           '備註'
                        from   odh
                               left join odc
                                      on odc_orderid = odh_orderid
                               left join cur
                                      on cur_code = '人民幣'
                        where  odc_adddate between '{strDate2S[2]}' and '{strDate2E[2]}' "
                                        + Get_strWhere()
                                        + $@"
                               and odc_freason <> '⊕'
                        order  by odh_customer,
                                  odh_orderid ";
            frmComplaintReport_Inq frmComplaintReport_Inq = new frmComplaintReport_Inq();
            frmComplaintReport_Inq.ShowInTaskbar = false;//圖示不顯示在工作列
            frmComplaintReport_Inq.rstrSQL = strSQL;
            frmComplaintReport_Inq.ShowDialog();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(strDate2S[3]))
            {
                return;
            }
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select odh_customer                                        '客戶',
                               odh_orderid                                         '工單號',
                               Round(odc_qty * odc_convert, 0)
                               '工單客訴額(NTD)',
                               Round(odc_qty * odc_convert * 0.2, 0)
                               '工廠累計賠償額(NTD)',
                               Round(odc_qty * odc_convert * 0.2 / cur_convert, 0)
                               '工廠累計賠償額(RMB)',
                               odh_newdate                                         '工單新建日期',
                               odc_adddate                                         '客訴日期',
                               odh_odcbz                                           '備註'
                        from   odh
                               left join odc
                                      on odc_orderid = odh_orderid
                               left join cur
                                      on cur_code = '人民幣'
                        where  odc_adddate between '{strDate2S[3]}' and '{strDate2E[3]}' "
                                        + Get_strWhere()
                                        + $@"
                               and odc_freason <> '⊕'
                        order  by odh_customer,
                                  odh_orderid ";
            frmComplaintReport_Inq frmComplaintReport_Inq = new frmComplaintReport_Inq();
            frmComplaintReport_Inq.ShowInTaskbar = false;//圖示不顯示在工作列
            frmComplaintReport_Inq.rstrSQL = strSQL;
            frmComplaintReport_Inq.ShowDialog();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(strDate2S[4]))
            {
                return;
            }
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select odh_customer                                        '客戶',
                               odh_orderid                                         '工單號',
                               Round(odc_qty * odc_convert, 0)
                               '工單客訴額(NTD)',
                               Round(odc_qty * odc_convert * 0.2, 0)
                               '工廠累計賠償額(NTD)',
                               Round(odc_qty * odc_convert * 0.2 / cur_convert, 0)
                               '工廠累計賠償額(RMB)',
                               odh_newdate                                         '工單新建日期',
                               odc_adddate                                         '客訴日期',
                               odh_odcbz                                           '備註'
                        from   odh
                               left join odc
                                      on odc_orderid = odh_orderid
                               left join cur
                                      on cur_code = '人民幣'
                        where  odc_adddate between '{strDate2S[4]}' and '{strDate2E[4]}' "
                                        + Get_strWhere()
                                        + $@"
                               and odc_freason <> '⊕'
                        order  by odh_customer,
                                  odh_orderid ";
            frmComplaintReport_Inq frmComplaintReport_Inq = new frmComplaintReport_Inq();
            frmComplaintReport_Inq.ShowInTaskbar = false;//圖示不顯示在工作列
            frmComplaintReport_Inq.rstrSQL = strSQL;
            frmComplaintReport_Inq.ShowDialog();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(strDate2S[5]))
            {
                return;
            }
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select odh_customer                                        '客戶',
                               odh_orderid                                         '工單號',
                               Round(odc_qty * odc_convert, 0)
                               '工單客訴額(NTD)',
                               Round(odc_qty * odc_convert * 0.2, 0)
                               '工廠累計賠償額(NTD)',
                               Round(odc_qty * odc_convert * 0.2 / cur_convert, 0)
                               '工廠累計賠償額(RMB)',
                               odh_newdate                                         '工單新建日期',
                               odc_adddate                                         '客訴日期',
                               odh_odcbz                                           '備註'
                        from   odh
                               left join odc
                                      on odc_orderid = odh_orderid
                               left join cur
                                      on cur_code = '人民幣'
                        where  odc_adddate between '{strDate2S[5]}' and '{strDate2E[5]}' "
                                        + Get_strWhere()
                                        + $@"
                               and odc_freason <> '⊕'
                        order  by odh_customer,
                                  odh_orderid ";
            frmComplaintReport_Inq frmComplaintReport_Inq = new frmComplaintReport_Inq();
            frmComplaintReport_Inq.ShowInTaskbar = false;//圖示不顯示在工作列
            frmComplaintReport_Inq.rstrSQL = strSQL;
            frmComplaintReport_Inq.ShowDialog();
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
            printDocument1 = new PrintDocument();
            //加入列印事件(當要送出資料列印時觸發)
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.QueryPageSettings += new QueryPageSettingsEventHandler(printDocument1_QueryPageSettings);

            printDocument1.PrintController = new StandardPrintController();//不顯示對話框
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, e.MarginBounds);
        }

        private void printDocument1_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            e.PageSettings.Landscape = true;
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
            lblCT1.Text = "";
            lblCT2.Text = "";
            lblCT3.Text = "";
            lblCT4.Text = "";
            lblCT5.Text = "";
            
            lblCF1.Text = "";
            lblCF2.Text = "";
            lblCF3.Text = "";
            lblCF4.Text = "";
            lblCF5.Text = "";

            lblCV1.Text = "";
            lblCV2.Text = "";
            lblCV3.Text = "";
            lblCV4.Text = "";
            lblCV5.Text = "";

            lblCC1.Text = "";
            lblCC2.Text = "";
            lblCC3.Text = "";
            lblCC4.Text = "";
            lblCC5.Text = "";

            lblKS1.Text = "";
            lblKS2.Text = "";
            lblKS3.Text = "";
            lblKS4.Text = "";
            lblKS5.Text = "";

            lblR1.Text = "";
            lblR2.Text = "";
            lblR3.Text = "";
            lblR4.Text = "";
            lblR5.Text = "";

            //陣列初始化
            Array.Clear(strDateS, 0, 6);
            Array.Clear(strDateE, 0, 6);
            Array.Clear(strDate2S, 0, 6);
            Array.Clear(strDate2E, 0, 6);

            //strDateS = Enumerable.Repeat("", 6).ToArray();
            //strDateE = Enumerable.Repeat("", 6).ToArray();
            //strDate2S = Enumerable.Repeat("", 6).ToArray();
            //strDate2E = Enumerable.Repeat("", 6).ToArray();
            chart1.Series["CT"].Points.Clear();
            chart1.Series["CF"].Points.Clear();
            chart1.Series["CV"].Points.Clear();
            chart1.Series["CC"].Points.Clear();
            chart2.Series["C"].Points.Clear();
            
        }
        byte[] _SourceImage;
        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存圖片
            try
            {
                ////全螢幕
                //Bitmap myImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                //Graphics g = Graphics.FromImage(myImage);
                //g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                //程式畫面
                Bitmap myImage = new Bitmap(this.Width, this.Height);
                Graphics g = Graphics.FromImage(myImage);
                g.CopyFromScreen(new Point(this.Location.X, this.Location.Y), new Point(0, 0), new Size(this.Width, this.Height));
                IntPtr dc1 = g.GetHdc();
                g.ReleaseHdc(dc1);
                //檢查資料夾；沒有就新增一個
                if (Directory.Exists(@"C:\\temp"))
                {
                    //資料夾存在
                }
                else
                {
                    //新增資料夾
                    Directory.CreateDirectory(@"C:\temp\");
                }
                string temp;
                temp = "C:\\temp\\" + "screen" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                myImage.Save(temp);
                MessageBox.Show("畫面已儲存在=>" + temp, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
