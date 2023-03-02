using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Price2
{
    public partial class frmPriceSetting_Copper : Form
    {
        string strCreatedate = "";
        double dblFinal = 0;    //最終判定
        public frmPriceSetting_Copper()
        {
            InitializeComponent();
        }

        private void frmPriceSetting_Copper_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                txtAvgDate.Text = DateTime.Now.ToString("yyyy/MM");
                txtOrderDate.Text = DateTime.Now.ToString("yyyy/MM");


            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmPriceSetting_Copper_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPriceSetting_Copper_Activated(object sender, EventArgs e)
        {
            btnInq_Avg.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void btnInq_Avg_Click(object sender, EventArgs e)
        {
            //查詢_AVG
            try
            {
                getData_Avg();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Avg_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData_Avg()
        {
            try
            {
                
                Double dblAvgPrice = 0;     //當月均價/kg
                Double dblLME = 0;          //LME/NTD
                Double dblSHFE = 0;         //SHFE/NTD
                Double dblAvgPrice_1 = 0;     //上月均價/kg
                Double dblLME_1 = 0;          //LME/NTD
                Double dblSHFE_1 = 0;         //SHFE/NTD
                Double dblAvgMonth = 0;     //當月採購均價
                Double dblAvgTotal = 0;     //(LME+SHFE+當月採購均價)/3

                string strSQL = "";
                DataTable dt = new DataTable();

                dblLME = GetCopper("LME");
                dblSHFE = GetCopper("SHFE");
                if (dblLME == 0 && dblSHFE == 0)
                {
                    MessageBox.Show("每月銅現價" + Convert.ToDateTime(txtAvgDate.Text).ToString("yyyy/MM") + "查不到資料", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                lblLME_NTD.Text= dblLME.ToString("0.##");
                
                lblSHFE_NTD.Text = dblSHFE.ToString("0.##");
                dblAvgPrice = (dblLME + dblSHFE) / 2;
                lblAvgPrice.Text = dblAvgPrice.ToString("0.##");

                //登錄加工費查詢
                WorkingIqr();

                //登錄銅價查詢
                PriceIqr();

                //銅價採購成交價查詢
                txtOrderDate.Text = txtAvgDate.Text;

                //當月平均成交價=(數量/kg)總和/金額(NTD)總和
                dblAvgMonth = GetCopperAvgMonth();
                lblAVG_MONTH.Text= dblAvgMonth.ToString("0.##");

                //(LME + SHFE + 上月採購均價) / 3
                if (dblAvgMonth == 0)          //如果沒有當月採購均價;(LME+SHFE+當月採購均價)/3=火車頭設定價
                {
                    dblAvgTotal = GetAspPrice("銅桿OD2.6mm/kg");
                }
                else
                {
                    dblAvgTotal = (dblLME + dblSHFE + dblAvgMonth) / 3;
                }
                lblAvgTotal.Text= dblAvgTotal.ToString("0.##");

                //當月成交價(dblAvgMonth)與上月均價盈虧(dblAvgPrice_1)
                dblLME_1 = GetCopper_1("LME");
                dblSHFE_1 = GetCopper_1("SHFE");
                dblAvgPrice_1 = (dblLME_1 + dblSHFE_1) / 2;
                lblProfit_Loss.Text = (dblAvgPrice_1 - dblAvgMonth).ToString("0.##");

                //預期下月銅價走勢=(當月均價-asp的銅單價)/asp的銅單價
                lblExpectedTrend.Text = ((dblAvgPrice - GetAspPrice("銅桿OD2.6mm/kg")) / GetAspPrice("銅桿OD2.6mm/kg")*100).ToString("0.##")+"%";


                //比較得出最終價格
                if(dblAvgPrice>dblAvgTotal)
                {
                    dblFinal = Convert.ToDouble(lblAvgPrice.Text);
                    lblAvgPrice.BackColor = Color.FromArgb(255, 0, 0);
                    lblAvgTotal.BackColor = Color.FromArgb(192, 255, 255);
                }
                else
                {
                    dblFinal = Convert.ToDouble(lblAvgTotal.Text);
                    lblAvgPrice.BackColor = Color.FromArgb(192, 255, 255);
                    lblAvgTotal.BackColor = Color.FromArgb(255, 0, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData_Avg" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Double GetCopper(string strCopper)     //取得當月銅價
        {
            Double dblLME = 0;            //LME價格
            Double dblSHFE = 0;           //SHFE價格
            string strSQL = $@"select t1.login_date_from as login_date,
                                       t1.lme             as lme_copper,
                                       t1.shfe            as shfe_copper,
                                       t2.working_USD     as working_USD,
                                       t2.working_RMB     as working_RMB
                                from   (select login_date_from,
                                               Avg(lme_copper)  lme,
                                               Avg(shfe_copper) shfe
                                        from   copper_price_detail
                                        where  login_date_from = '{Convert.ToDateTime(txtAvgDate.Text).ToString("yyyy/MM")}'
                                        group  by login_date_from) t1
                                       left join copper_price t2
                                              on t1.login_date_from = t2.login_date ";
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dblLME = (Double)dt.Rows[0]["lme_copper"] + (Double)dt.Rows[0]["working_USD"];
                dblSHFE = (Double)dt.Rows[0]["shfe_copper"] + (Double)dt.Rows[0]["working_RMB"];
                lblLME_avg.Text = Convert.ToDouble(dt.Rows[0]["lme_copper"]).ToString("0.##");
                lblSHFE_avg.Text = Convert.ToDouble(dt.Rows[0]["shfe_copper"]).ToString("0.##");
            }
            switch (strCopper)
            {
                case "LME":
                    return (Double)(dblLME / 1000 * GetExchangeRate("美金"));
                case "SHFE":
                    return (Double)(dblSHFE / 1000 / 1.11 * GetExchangeRate("人民幣"));
                default:
                    return 0;
            }
        }

        private Double GetExchangeRate(string strCurrency)     //取得當月匯率
        {
            Double dblExchangeRate = 0;
            string strSQL = $@"select cum_convert
                                from   cum
                                where  cum_code='{strCurrency}'
                                and    cum_adddate= (　select max(cum_adddate) from cum where cum_code='{strCurrency}' and　format(cum_adddate,'yyyyMM')<='{Convert.ToDateTime(txtAvgDate.Text).ToString("yyyyMM")}') ";
            DataTable dt= new DataTable();
            dt = clsDB.sql_select_dt(strSQL);
            if(dt.Rows.Count > 0 )
            {
                dblExchangeRate = (Double)dt.Rows[0]["cum_convert"];
            }
            
            return dblExchangeRate;
        }

        private Double GetCopper_1(string strCopper)     //取得上月銅價
        {
            Double dblLME = 0;            //LME價格
            Double dblSHFE = 0;           //SHFE價格
            string strSQL = $@"select t1.login_date_from as login_date,
                                       t1.lme             as lme_copper,
                                       t1.shfe            as shfe_copper,
                                       t2.working_USD     as working_USD,
                                       t2.working_RMB     as working_RMB
                                from   (select login_date_from,
                                               Avg(lme_copper)  lme,
                                               Avg(shfe_copper) shfe
                                        from   copper_price_detail
                                        where  login_date_from = '{Convert.ToDateTime(txtAvgDate.Text).AddMonths(-1).ToString("yyyy/MM")}'
                                        group  by login_date_from) t1
                                       left join copper_price t2
                                              on t1.login_date_from = t2.login_date ";
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dblLME = (Double)dt.Rows[0]["lme_copper"] + (Double)dt.Rows[0]["working_USD"];
                dblSHFE = (Double)dt.Rows[0]["shfe_copper"] + (Double)dt.Rows[0]["working_RMB"];
                lblLME_avg.Text = Convert.ToDouble(dt.Rows[0]["lme_copper"]).ToString("0.##");
                lblSHFE_avg.Text = Convert.ToDouble(dt.Rows[0]["shfe_copper"]).ToString("0.##");
            }
            switch (strCopper)
            {
                case "LME":
                    return (Double)(dblLME / 1000 * GetExchangeRate_1("美金"));
                case "SHFE":
                    return (Double)(dblSHFE / 1000 / 1.11 * GetExchangeRate_1("人民幣"));
                default:
                    return 0;
            }
        }

        private Double GetExchangeRate_1(string strCurrency)     //取得上月匯率
        {
            Double dblExchangeRate = 0;
            string strSQL = $@"select cum_convert
                                from   cum
                                where  cum_code='{strCurrency}'
                                and    cum_adddate= (　select max(cum_adddate) from cum where cum_code='{strCurrency}' and　format(cum_adddate,'yyyyMM')<='{Convert.ToDateTime(txtAvgDate.Text).AddMonths(-1).ToString("yyyyMM")}') ";
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dblExchangeRate = (Double)dt.Rows[0]["cum_convert"];
            }

            return dblExchangeRate;
        }

        private Double GetCopperAvgMonth()     //取得當月採購均價
        {
            Double dblNTD = 0;      //金額(NTD)
            Double dblWeight = 0;   //數量/kg

            string strSQL = $@"select      PURTC.TC003                                          as 採購日期,
                                           PURTC.TC002                                          as 採購單號,
                                           PURTC.TC004 + ' ' + PURMA.MA002                      as 廠商,
                                           PURTD.TD006                                          as 規格,
                                           PURTD.TD010* cum_convert/1.11                        as 銅價未稅,
                                           PURTD.TD008                                          as 數量,
                                           (PURTD.TD010 * PURTD.TD008 / 1.11 ) * cum_convert    as 金額,
                                           PURTC.TC009                                          as 備註
                                from       [ERPDB].[MSLCN].dbo.PURTC
                                inner join [ERPDB].[MSLCN].dbo.PURTD
                                on         PURTC.TC001 = PURTD.TD001
                                and        PURTC.TC002 = PURTD.TD002
                                inner join [ERPDB].[MSLCN].dbo.PURMA
                                on         PURMA.MA001 = PURTC.TC004,
                                           cum
                                where      ( PURTC.TC001 = N'C330' )
                                and        ( PURTD.TD004 like N'A6HA01%' )
                                and        ( cum_code = '人民幣' )
                                and        ( PURTC.TC014 = 'Y' )
                                and        cum_adddate= (　select MAX(cum_adddate) from cum where cum_code='人民幣' and　format(cum_adddate,'yyyyMM')<='{Convert.ToDateTime(txtOrderDate.Text).AddDays(0).ToString("yyyyMM")}')
                                and        ( PURTC.TC003 between '{Convert.ToDateTime(txtOrderDate.Text).AddMonths(-1).ToString("yyyyMM26")}' and '{Convert.ToDateTime(txtOrderDate.Text).AddMonths(0).ToString("yyyyMM25")}' )
                                union all
                                select     PURTC.TC003                                      as 採購日期,
                                           PURTC.TC002                                      as 採購單號,
                                           PURTC.TC004 + ' ' + PURMA.MA002                  as 廠商,
                                           PURTD.TD006                                      as 規格,
                                           (PURTD.TD010 / 1000)* cum_convert                as 銅價未稅,
                                           PURTD.TD008*1000                                 as 數量,
                                           (PURTD.TD010 * PURTD.TD008) * cum_convert        as 金額,
                                           PURTC.TC009                                      as 備註
                                from       [ERPDB].[TESTMVE1].dbo.PURTC
                                inner join [ERPDB].[TESTMVE1].dbo.PURTD
                                on         PURTC.TC001 = PURTD.TD001
                                and        PURTC.TC002 = PURTD.TD002
                                inner join [ERPDB].[TESTMVE1].dbo.PURMA
                                on         PURMA.MA001 = PURTC.TC004,
                                           cum
                                where      ( PURTC.TC001 = N'M330' )
                                and        ( PURTD.TD004 like N'A6HA01%' )
                                and        ( cum_code = '美金' )
                                and        ( PURTC.TC014 = 'Y' )
                                and        cum_adddate= (　select MAX(cum_adddate) from cum where cum_code='美金' and　format(cum_adddate,'yyyyMM')<='{Convert.ToDateTime(txtOrderDate.Text).AddDays(0).ToString("yyyyMM")}')
                                and        ( PURTC.TC003 between '{Convert.ToDateTime(txtOrderDate.Text).AddMonths(-1).ToString("yyyyMM26")}' and '{Convert.ToDateTime(txtOrderDate.Text).AddMonths(0).ToString("yyyyMM25")}' )
                                order by   採購單號";
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dblNTD = dblNTD + (Double)dt.Rows[0]["金額"];
                dblWeight = dblWeight + (Double)(Decimal)dt.Rows[0]["數量"];
                dgvOrder.DataSource = dt;
            }
            else
            {
                dgvOrder.DataSource = dt;
                MessageBox.Show("銅價採購成交價查不到資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            if (dblWeight == 0)
            {
                return 0;
            }
            else
            {
                return dblNTD / dblWeight;
            }
        }

        private Double GetAspPrice(string strID)     //取得火車頭設定價
        {
            Double dblAsbPrice = 0;

            string strSQL = $@"select asb_price
                                from   asb
                                where  asb_id = '{strID}'
                                       and asb_changedate = (select Max(asb_changedate)
                                                             from   asb
                                                             where  asb_id = '{strID}'
                                                                    and Format(asb_changedate, 'yyyyMM') <= '{Convert.ToDateTime(txtAvgDate.Text).ToString("yyyyMM")}')";
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dblAsbPrice = (Double)dt.Rows[0]["asb_price"];
            } 
            if (dblAsbPrice == 0)
            {
                return 0;
            }
            else
            {
                return dblAsbPrice;
            }
        }

        private void WorkingIqr()     //查詢每月登錄加工費
        {
            string strSQL = $@"select login_date,
                                       working_USD,
                                       working_RMB
                                from   copper_price
                                where  login_date = '{Convert.ToDateTime(txtAvgDate.Text).ToString("yyyy/MM")}' ";
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                txtUSD_working.Text = dt.Rows[0]["working_USD"].ToString();
                txtRMB_working.Text = dt.Rows[0]["working_RMB"].ToString();
            }
        }

        private void PriceIqr()     //查詢每日登錄銅價
        {
            string strYYYYMM_S = Convert.ToDateTime(txtAvgDate.Text).ToString("yyyy/MM") + "/01";
            string strYYYYMM_E = Convert.ToDateTime(txtAvgDate.Text).ToString("yyyy/MM") + "/31";
            string strSQL = $@"select login_date '日期',
                                       lme_copper 'LME銅板現貨',
                                       shfe_copper 'SHFE銅板現貨',
                                       user_id '修改人員',
                                       create_date
                                from   copper_price_detail
                                where  login_date between '{strYYYYMM_S}' and '{strYYYYMM_E}'
                                order  by login_date desc ";
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dgvPrice.DataSource = dt;  
            }
            else
            {
                MessageBox.Show("每日登錄銅價查不到資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void Clear_Avg()
        {
            try
            {
                lblLME_NTD.Text="";
                lblSHFE_NTD.Text = "";
                lblAvgPrice.Text = "";
                lblAvgPrice.BackColor= Color.FromArgb(192, 255, 255);
                lblAvgTotal.Text = "";
                lblAvgTotal.BackColor = Color.FromArgb(192, 255, 255);
                lblAVG_MONTH.Text = "";
                lblExpectedTrend.Text = "";
                dblFinal=0;
                lblProfit_Loss.Text = "";
                Clear_Price();
                Clear_Order();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-Clear_Avg" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear_Price()
        {
            try
            {
                txtLME.Text = "";
                txtSHFE.Text = "";
                lblLME_avg.Text = "";
                lblSHFE_avg.Text = "";
                strCreatedate = "";
                if (dgvPrice.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)dgvPrice.DataSource;
                    dt.Rows.Clear();
                    dgvPrice.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-Clear_Price" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear_Order()
        {
            try
            {
                if (dgvOrder.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)dgvOrder.DataSource;
                    dt.Rows.Clear();
                    dgvOrder.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-Clear_Order" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Avg_Click(object sender, EventArgs e)
        {
            //清除_AVG
            try
            {
                Clear_Avg();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Avg_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Order_Click(object sender, EventArgs e)
        {
            //清除_ORDER
            try
            {
                Clear_Order();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Order_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Order_Click(object sender, EventArgs e)
        {
            //查詢_ORDER
            try
            {
                GetCopperAvgMonth();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Order_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
