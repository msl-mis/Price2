using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Price2
{
    public partial class frmRevenueReport : Form
    {
        string strSales = "";   //業務
        public frmRevenueReport()
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

        private void frmProfit_Report_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select pas_username
                        from   ord
                               left join pas
                                      on ord_ywcode = pas_ywcode
                        where  pas_username != ''
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
                getData();
                //Chart
                setChart();
                //畫圖
                getChart();
                //欄位輸入
                getLable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmSpecialExpenes_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string[] strYear = new string[2];      //起始年
        double[] dblRevenue = new double[13];    //營業額
        private void getData()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            for (int i = 0; i <= 1; i++)
            {
                //strDateS[i] = DateTime.Now.AddYears(-5 + i).ToString("yyyy") + "/" + dtpDateS.Value.ToString("MM/dd");
                //strDateE[i] = DateTime.Now.AddYears(-5 + i).ToString("yyyy") + "/" + dtpDateE.Value.ToString("MM/dd");
                strYear[i] = (Convert.ToInt32(dtpYear.Text) - 1 + i).ToString() ;
            }
            strSQL = $@"select Datepart(mm, odh_newdate)                                   MM,
                               Isnull(Round(Sum(ord_qty * ord_price * ord_convert), 0), 0) as REVENUE
                        from   ord,
                               odh,
                               odi
                        where  ord_assy = odi_customerid
                               and ord_orderid = odh_orderid " + (strSales==""? "" : $@"and ord_ywcode = '{strSales}' ") + $@"
                               and Datepart(yy, odh_newdate) = {strYear[1]}
                        group  by Datepart(mm, odh_newdate) ";
            dt = clsDB.sql_select_dt(strSQL);

            dblRevenue[0] = 0; dblRevenue[1] = 0;
            dblRevenue[2] = 0; dblRevenue[3] = 0;
            dblRevenue[4] = 0; dblRevenue[5] = 0;
            dblRevenue[6] = 0; dblRevenue[7] = 0;
            dblRevenue[8] = 0; dblRevenue[9] = 0;
            dblRevenue[10] = 0; dblRevenue[11] = 0;
            dblRevenue[12] = 0;
            if (dt.Rows.Count > 0)
            {
                
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    dblRevenue[Convert.ToInt32(dt.Rows[i]["MM"].ToString()) ] =Convert.ToDouble( dt.Rows[i]["REVENUE"].ToString());
                }
                lblAVG.Text =( (double)dt.Compute("Avg(REVENUE)", string.Empty)).ToString("N0");
            }
            //前一年12月營業額
            strSQL = $@"select Isnull(Round(Sum(ord_qty * ord_price * ord_convert), 0), 0) as REVENUE
                        from   ord,
                               odh,
                               odi
                        where  ord_assy = odi_customerid
                               and ord_orderid = odh_orderid " + (strSales == "" ? "" : $@"and ord_ywcode = '{strSales}' ") + $@"
                               and Datepart(yy, odh_newdate) = {strYear[0]}
                               and datepart(mm,odh_newdate)=12 ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dblRevenue[0] = Convert.ToDouble(dt.Rows[0]["REVENUE"].ToString());
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
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
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
            chart1.Series["C"]["PointWidth"] = "0.7";
            //設置XY軸上的值類型
            //chart1.Series["C"].XValueType = ChartValueType.String;
            //chart1.Series["C"].YValueType = ChartValueType.Double;
            chart1.Series["C"].XValueType = ChartValueType.Double;
            chart1.Series["C"].YValueType = ChartValueType.String;

        }
        private void getChart()
        {
            //準備數據

            double[] X = new double[] { dblRevenue[1], dblRevenue[2], dblRevenue[3], dblRevenue[4], dblRevenue[5], dblRevenue[6], dblRevenue[7], dblRevenue[8], dblRevenue[9], dblRevenue[10], dblRevenue[11], dblRevenue[12] }; 
            string[] Y = new string[] { "1月", "2月", "2月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月" };

            //綁定數據
            chart1.Series["C"].Points.DataBindXY(Y, X);
            //顏色不同,不指定顏色
            chart1.Series["C"].Palette = ChartColorPalette.BrightPastel;
            
        }

        private void getLable()
        {
            //營業額
            
            lblQ12.Text = dblRevenue[1].ToString("N0");
            lblQ11.Text = dblRevenue[2].ToString("N0");
            lblQ10.Text = dblRevenue[3].ToString("N0");
            lblQ9.Text = dblRevenue[4].ToString("N0");
            lblQ8.Text = dblRevenue[5].ToString("N0");
            lblQ7.Text = dblRevenue[6].ToString("N0");
            lblQ6.Text = dblRevenue[7].ToString("N0");
            lblQ5.Text = dblRevenue[8].ToString("N0");
            lblQ4.Text = dblRevenue[9].ToString("N0");
            lblQ3.Text = dblRevenue[10].ToString("N0");
            lblQ2.Text = dblRevenue[11].ToString("N0");
            lblQ1.Text = dblRevenue[12].ToString("N0");
            //增長比例
            if(dblRevenue[0]==0)
            {
                lblP12.Text = "0" + "%";
            }
            else
            {
                lblP12.Text=((dblRevenue[1]- dblRevenue[0]) / dblRevenue[0]*100).ToString("0.##");
            }

            if (dblRevenue[1] == 0)
            {
                lblP11.Text = "0" + "%";
            }
            else
            {
                lblP11.Text = ((dblRevenue[2] - dblRevenue[1]) / dblRevenue[1] * 100).ToString("0.##");
            }

            if (dblRevenue[2] == 0)
            {
                lblP10.Text = "0" + "%";
            }
            else
            {
                lblP10.Text = ((dblRevenue[3] - dblRevenue[2]) / dblRevenue[2] * 100).ToString("0.##");
            }

            if (dblRevenue[3] == 0)
            {
                lblP9.Text = "0" + "%";
            }
            else
            {
                lblP9.Text = ((dblRevenue[4] - dblRevenue[3]) / dblRevenue[3] * 100).ToString("0.##");
            }

            if (dblRevenue[4] == 0)
            {
                lblP8.Text = "0" + "%";
            }
            else
            {
                lblP8.Text = ((dblRevenue[5] - dblRevenue[4]) / dblRevenue[4] * 100).ToString("0.##");
            }

            if (dblRevenue[5] == 0)
            {
                lblP7.Text = "0" + "%";
            }
            else
            {
                lblP7.Text = ((dblRevenue[6] - dblRevenue[5]) / dblRevenue[5] * 100).ToString("0.##");
            }

            if (dblRevenue[6] == 0)
            {
                lblP6.Text = "0" + "%";
            }
            else
            {
                lblP6.Text = ((dblRevenue[7] - dblRevenue[6]) / dblRevenue[6] * 100).ToString("0.##");
            }
            if (dblRevenue[7] == 0)
            {
                lblP5.Text = "0" + "%";
            }
            else
            {
                lblP5.Text = ((dblRevenue[8] - dblRevenue[7]) / dblRevenue[7] * 100).ToString("0.##");
            }

            if (dblRevenue[8] == 0)
            {
                lblP4.Text = "0" + "%";
            }
            else
            {
                lblP4.Text = ((dblRevenue[9] - dblRevenue[8]) / dblRevenue[8] * 100).ToString("0.##");
            }

            if (dblRevenue[9] == 0)
            {
                lblP3.Text = "0" + "%";
            }
            else
            {
                lblP3.Text = ((dblRevenue[10] - dblRevenue[9]) / dblRevenue[9] * 100).ToString("0.##");
            }

            if (dblRevenue[10] == 0)
            {
                lblP2.Text = "0" + "%";
            }
            else
            {
                lblP2.Text = ((dblRevenue[11] - dblRevenue[10]) / dblRevenue[10] * 100).ToString("0.##");
            }

            if (dblRevenue[11] == 0)
            {
                lblP1.Text = "0" + "%";
            }
            else
            {
                lblP1.Text = ((dblRevenue[12] - dblRevenue[11]) / dblRevenue[11] * 100).ToString("0.##");
            }
        }

        private void btnInq_Click(object sender, EventArgs e)
        {
            getClear();
            getData();

            //畫圖
            getChart();
            //欄位輸入
            getLable();
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

            lblAVG.Text = "";

            chart1.Series["C"].Points.Clear();
        }

    }
}
