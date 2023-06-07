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
    public partial class frmDealReport : Form
    {
        string strYear = "";    //年分
        public frmDealReport()
        {
            InitializeComponent();
        }

        private void frmDealReport_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                //日期
                dtpDateS.Value = new DateTime(DateTime.Now.Year, 1, 1); //本年年初;
                //dtpDateE.Value = new DateTime(DateTime.Now.Year, 12, 31); //本年年尾;
                dtpDateE.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                //dtpYear.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                strYear = DateTime.Now.Year.ToString();
                //Chart
                setChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmDealReport_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            chart1.Series.Add("C");
            chart1.Series["C"].LegendText = "";
            //設置統計對象統計圖類型
            chart1.Series["C"].ChartType = SeriesChartType.Column;
            //設置統計對象顏色
            chart1.Series["C"].Color = Color.Blue;
            //設置統計對象粗細, 單位PIXEL
            chart1.Series["C"].BorderWidth = 1;
            chart1.Series["C"]["PointWidth"] = "0.4";
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
            double[] Y = { Convert.ToDouble((string.IsNullOrEmpty(strQty[1]) ? "0":strQty[1])),
                           Convert.ToDouble((string.IsNullOrEmpty(strQty[2]) ? "0":strQty[2])),
                           Convert.ToDouble((string.IsNullOrEmpty(strQty[3]) ? "0":strQty[3])),
                           Convert.ToDouble((string.IsNullOrEmpty(strQty[4]) ? "0":strQty[4])),
                           Convert.ToDouble((string.IsNullOrEmpty(strQty[5]) ? "0":strQty[5]))};

            //綁定數據
            chart1.Series["C"].Points.DataBindXY(X, Y);
            //顏色不同,不指定顏色
            chart1.Series["C"].Palette = ChartColorPalette.BrightPastel;
            //顏色不同,指定顏色
            //chart1.Series["C"].Points[1].Color = Color.Green;

            //欄位輸入
            //數量/萬
            lblQty1.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[1]) ? "0" : strQty[1])) / 10000).ToString("N0");
            lblQty2.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[2]) ? "0" : strQty[2])) / 10000).ToString("N0");
            lblQty3.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[3]) ? "0" : strQty[3])) / 10000).ToString("N0");
            lblQty4.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[4]) ? "0" : strQty[4])) / 10000).ToString("N0");
            lblQty5.Text = (Convert.ToDouble((string.IsNullOrEmpty(strQty[5]) ? "0" : strQty[5])) / 10000).ToString("N0");

            //年增率
            if (Convert.ToDouble(strQty[0]) == 0)
            {
                lblY1.Text = "0" + "%";
                lblY1.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strQty[1]) - Convert.ToDouble(strQty[0])) / Convert.ToDouble(strQty[0]) * 100 > 0)
                {
                    lblY1.ForeColor = Color.Red;
                }
                else
                {
                    lblY1.ForeColor = Color.Green;
                }
                lblY1.Text = ((Convert.ToDouble(strQty[1]) - Convert.ToDouble(strQty[0])) / Convert.ToDouble(strQty[0]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strQty[1]) == 0)
            {
                lblY2.Text = "0" + "%";
                lblY2.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strQty[2]) - Convert.ToDouble(strQty[1])) / Convert.ToDouble(strQty[1]) * 100 > 0)
                {
                    lblY2.ForeColor = Color.Red;
                }
                else
                {
                    lblY2.ForeColor = Color.Green;
                }
                lblY2.Text = ((Convert.ToDouble(strQty[2]) - Convert.ToDouble(strQty[1])) / Convert.ToDouble(strQty[1]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strQty[2]) == 0)
            {
                lblY3.Text = "0" + "%";
                lblY3.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strQty[3]) - Convert.ToDouble(strQty[2])) / Convert.ToDouble(strQty[2]) * 100 > 0)
                {
                    lblY3.ForeColor = Color.Red;
                }
                else
                {
                    lblY3.ForeColor = Color.Green;
                }
                lblY3.Text = ((Convert.ToDouble(strQty[3]) - Convert.ToDouble(strQty[2])) / Convert.ToDouble(strQty[2]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strQty[3]) == 0)
            {
                lblY4.Text = "0" + "%";
                lblY4.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strQty[4]) - Convert.ToDouble(strQty[3])) / Convert.ToDouble(strQty[3]) * 100 > 0)
                {
                    lblY4.ForeColor = Color.Red;
                }
                else
                {
                    lblY4.ForeColor = Color.Green;
                }
                lblY4.Text = ((Convert.ToDouble(strQty[4]) - Convert.ToDouble(strQty[3])) / Convert.ToDouble(strQty[3]) * 100).ToString("0.##") + "%";
            }

            if (Convert.ToDouble(strQty[4]) == 0)
            {
                lblY5.Text = "0" + "%";
                lblY5.ForeColor = Color.Green;
            }
            else
            {
                if ((Convert.ToDouble(strQty[5]) - Convert.ToDouble(strQty[4])) / Convert.ToDouble(strQty[4]) * 100 > 0)
                {
                    lblY5.ForeColor = Color.Red;
                }
                else
                {
                    lblY5.ForeColor = Color.Green;
                }
                lblY5.Text = ((Convert.ToDouble(strQty[5]) - Convert.ToDouble(strQty[4])) / Convert.ToDouble(strQty[4]) * 100).ToString("0.##") + "%";
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

        private void dtpDateE_Enter(object sender, EventArgs e)
        {
            chkAll_year.Checked = false;
        }

        private void dtpDateS_Enter(object sender, EventArgs e)
        {
            chkAll_year.Checked = false;
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
                getData();
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string[] strQty = new string[6];        //數量
        //string[] strRevenue = new string[6];    //成交
        //string[] strProfit_Rate = new string[6];     //毛利率
        string[] strDateS = new string[6];      //起始日
        string[] strDateE = new string[6];      //結束日
        private void getData()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            for (int i = 0; i <= 5; i++)
            {
                //strDateS[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/" + dtpDateS.Value.ToString("MM/dd");
                //strDateE[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/" + dtpDateE.Value.ToString("MM/dd");
                strDateS[i] = (Convert.ToInt32(strYear) - 5 + i).ToString() + "/" + dtpDateS.Value.ToString("MM/dd");
                strDateE[i] = (Convert.ToInt32(strYear) - 5 + i).ToString() + "/" + dtpDateE.Value.ToString("MM/dd");
                strSQL = $@"select Isnull(Sum(tab.ord_qty),0) Qty
                            from   (
                                          select *
                                          from   ord
                                          where  ord_adddate between '{strDateS[i]}' and    '{strDateE[i]}' "
                                        + Get_strWhere()
                                        + ") tab ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strQty[i] = (string.IsNullOrEmpty(dt.Rows[0]["QTY"].ToString()) ? "0" : dt.Rows[0]["QTY"].ToString());
                }
            }
            getChart();
        }

        private string Get_strWhere()
        {
            string strWhere = "";

            //工廠別
            if (cboFactory.Text != "")
            {
                strWhere = strWhere + (cboFactory.Text == "冠志" ? $@"and substring(ord_orderid,4,1) != 'V' " : $@"and substring(ord_orderid,4,1) != 'V' ");
            }
                
            
            //產品別
            if (cboClass.Text == "電源")
            {
                strWhere = strWhere + $@"and ord_assy in (select distinct pri_customerid from pri where pri_fenlei = '7 Power cord') ";
            }
            else if (cboClass.Text == "光纖")
            {
                strWhere = strWhere + $@"and ord_assy in (select distinct pri_customerid from pri where pri_fenlei = '14 Fiber Cable')  ";
            }
            else if (cboClass.Text == "其他")
            {
                strWhere = strWhere + $@"and ord_assy not in (select distinct pri_customerid from pri where pri_fenlei = '7 Power cord') and ord_assy not in (select distinct pri_customerid from pri where pri_fenlei = '14 Fiber Cable') ";
            }

            return strWhere;
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
            lblQty1.Text = "";
            lblQty2.Text = "";
            lblQty3.Text = "";
            lblQty4.Text = "";
            lblQty5.Text = "";

            lblY1.Text = "";
            lblY2.Text = "";
            lblY3.Text = "";
            lblY4.Text = "";
            lblY5.Text = "";

            chart1.Series["C"].Points.Clear();
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
