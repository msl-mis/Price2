using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Price2
{
    public partial class frmPriceSetting_Copper : Form
    {
        String asp_id = "";                     //產品編號(材料名)
        String asp_type = "";                   //產品類型
        String asp_name = "";                   //材料單
        String asp_um = "";                     //單位
        Double asp_purprice = 0;                //單價
        Double asp_standprice = 0;              //
        String asp_vendorid = "";               //廠商
        String asp_currency = "";               //幣種
        String asp_czf = "";                    //參照法
        Double asp_tjjz = 0;                   //
        String asp_area = "";                   //
        Double asp_safeqty = 0;                 //一年內已成交數量
        Double asp_weight = 0;                  //
        Double asp_purleadtime = 0;             //
        Double asp_makeleadtime = 0;            //
        String asp_location = "";               //
        Double asp_purchprice = 0;              //數量計算式
        String asp_purcurrency = "";           //
        int asp_dummyflag = 0;                  //控管材料
        String asp_pricecal = "";               //火車頭單價計算式
        String asp_vendormaterialno = "";       //品號
        String asp_spec = "";                   //規格
        String asp_line = "";                   //越南運費check
        String asp_od = "";                     //審核+越南材料check
        String asp_multinum = "";               //同品號
        Double asp_vnweight = 0;                //越南運費-重量
        Double asp_vnpcs = 0;                   //越南運費-數量
        String asp_lengum = "";                 //安規線材check
        String asp_oddate = "";                 //審核日期
        String asp_oduser = "";                 //審核者
        String oddate = "";                      //審核日期
        String oduser = "";                      //審核者

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
            getData_Avg();
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
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                string strSQL = "";
                DataTable dt = new DataTable();

                dblLME = GetCopper("LME");
                dblSHFE = GetCopper("SHFE");
                if (dblLME == 0 && dblSHFE == 0)
                {
                    MessageBox.Show("每月銅現價" + Convert.ToDateTime(txtAvgDate.Text).ToString("yyyy/MM") + "查不到資料", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                lblLME_NTD.Text = dblLME.ToString("0.##");

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
                lblAVG_MONTH.Text = dblAvgMonth.ToString("0.##");

                //(LME + SHFE + 上月採購均價) / 3
                if (dblAvgMonth == 0)          //如果沒有當月採購均價;(LME+SHFE+當月採購均價)/3=火車頭設定價
                {
                    dblAvgTotal = GetAspPrice("銅桿OD2.6mm/kg");
                }
                else
                {
                    dblAvgTotal = (dblLME + dblSHFE + dblAvgMonth) / 3;
                }
                lblAvgTotal.Text = dblAvgTotal.ToString("0.##");

                //當月成交價(dblAvgMonth)與上月均價盈虧(dblAvgPrice_1)
                dblLME_1 = GetCopper_1("LME");
                dblSHFE_1 = GetCopper_1("SHFE");
                dblAvgPrice_1 = (dblLME_1 + dblSHFE_1) / 2;
                lblProfit_Loss.Text = (dblAvgPrice_1 - dblAvgMonth).ToString("0.##");

                //預期下月銅價走勢=(當月均價-asp的銅單價)/asp的銅單價
                lblExpectedTrend.Text = ((dblAvgPrice - GetAspPrice("銅桿OD2.6mm/kg")) / GetAspPrice("銅桿OD2.6mm/kg") * 100).ToString("0.##") + "%";

                //比較得出最終價格
                if (dblAvgPrice > dblAvgTotal)
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
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
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
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
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
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dblNTD = dblNTD + (Double)dt.Rows[i]["金額"];
                    dblWeight = dblWeight + (Double)(Decimal)dt.Rows[i]["數量"];
                }
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
                lblLME_NTD.Text = "";
                lblSHFE_NTD.Text = "";
                lblAvgPrice.Text = "";
                lblAvgPrice.BackColor = Color.FromArgb(192, 255, 255);
                lblAvgTotal.Text = "";
                lblAvgTotal.BackColor = Color.FromArgb(192, 255, 255);
                lblAVG_MONTH.Text = "";
                lblExpectedTrend.Text = "";
                dblFinal = 0;
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

        private void btnAdd_Price_Click(object sender, EventArgs e)
        {
            //新增
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                string strDate = "";    //日期
                string strLME = "";     //LME銅板現貨價
                string strSHFE = "";    //SHFE銅板現貨價
                //欄位限制防呆
                if (txtLME.Text == "" || txtLME.Text == "0")
                {
                    strLME = "NULL";
                }
                else
                {
                    strLME = txtLME.Text;
                }

                if (txtSHFE.Text == "" || txtSHFE.Text == "0")
                {
                    strSHFE = "NULL";
                }
                else
                {
                    strSHFE = txtSHFE.Text;
                }

                strDate = Convert.ToDateTime(txtDate.Text).ToString("yyyy/MM/dd");

                //先查詢是否有值
                strSQL = $@"select * from copper_price_detail where login_date = '{strDate}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("此日期已有資料,請進行修改!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (MessageBox.Show("確定要新增嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    strSQL = $@"insert into copper_price_detail
                                            (login_date,
                                             login_date_from,
                                             lme_copper,
                                             shfe_copper,
                                             user_id,
                                             create_date)
                                values      ('{strDate}',
                                             '{strDate.Substring(0, 7)}',
                                             {strLME},
                                             {strSHFE},
                                             '{clsGlobal.strG_User}',
                                             Getdate()) ";
                    clsDB.Execute(strSQL);
                    //輸入後顯示查詢
                    txtAvgDate.Text = Convert.ToDateTime(txtDate.Text).ToString("yyyy/MM");
                    getData_Avg();
                    //清除欄位
                    txtLME.Text = "";
                    txtSHFE.Text = "";
                    strCreatedate = "";
                    MessageBox.Show("新增完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnAdd_Price_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModify_Price_Click(object sender, EventArgs e)
        {
            //修改
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                string strDate = "";    //日期
                string strLME = "";     //LME銅板現貨價
                string strSHFE = "";    //SHFE銅板現貨價
                //欄位限制防呆
                if (strCreatedate == "")
                {
                    MessageBox.Show("請雙擊欲修改欄位!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                strDate = Convert.ToDateTime(txtDate.Text).ToString("yyyy/MM/dd");

                if (MessageBox.Show("確定要修改嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if (txtLME.Text == "" || txtLME.Text == "0")
                {
                    strLME = "NULL";
                }
                else
                {
                    strLME = txtLME.Text;
                }

                if (txtSHFE.Text == "" || txtSHFE.Text == "0")
                {
                    strSHFE = "NULL";
                }
                else
                {
                    strSHFE = txtSHFE.Text;
                }

                strSQL = $@"update copper_price_detail
                            set    lme_copper = {strLME},
                                   shfe_copper = {strSHFE},
                                   user_id = '{clsGlobal.strG_User}',
                                   update_date = Getdate()
                            where  Format(create_date, 'yyyyMMddHHmmss') =
                                   '{Convert.ToDateTime(strCreatedate).ToString("yyyyMMddHHmmss")}' ";
                clsDB.Execute(strSQL);
                //輸入後顯示查詢
                txtAvgDate.Text = Convert.ToDateTime(txtDate.Text).ToString("yyyy/MM");
                getData_Avg();
                //清除欄位
                txtLME.Text = "";
                txtSHFE.Text = "";
                strCreatedate = "";
                MessageBox.Show("修改完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnModify_Price_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Price_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                string strDate = "";    //日期
                string strLME = "";     //LME銅板現貨價
                string strSHFE = "";    //SHFE銅板現貨價
                //欄位限制防呆
                if (strCreatedate == "")
                {
                    MessageBox.Show("請雙擊欲刪除欄位!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                strDate = Convert.ToDateTime(txtDate.Text).ToString("yyyy/MM/dd");

                if (MessageBox.Show("確定要刪除嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                strSQL = $@"delete from copper_price_detail
                            where  Format(create_date, 'yyyyMMddHHmmss') =
                                   '{Convert.ToDateTime(strCreatedate).ToString("yyyyMMddHHmmss")}' ";
                clsDB.Execute(strSQL);
                //輸入後顯示查詢
                txtAvgDate.Text = Convert.ToDateTime(txtDate.Text).ToString("yyyy/MM");
                getData_Avg();
                //清除欄位
                txtLME.Text = "";
                txtSHFE.Text = "";
                strCreatedate = "";
                MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Price_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Price_Click(object sender, EventArgs e)
        {
            //清除_PRICE
            try
            {
                Clear_Price();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Price_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPrice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //更新畫面中的欄位資料
            txtDate.Text = dgvPrice.Rows[e.RowIndex].Cells["日期"].Value.ToString();            //採購日期
            txtLME.Text = dgvPrice.Rows[e.RowIndex].Cells["LME銅板現貨"].Value.ToString();          //LME銅板現貨
            txtSHFE.Text = dgvPrice.Rows[e.RowIndex].Cells["SHFE銅板現貨"].Value.ToString();        //SHFE銅板現貨
            strCreatedate = dgvPrice.Rows[e.RowIndex].Cells["create_date"].Value.ToString();        //create_date
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //修改_加工費
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                string strDate = "";    //日期
                string strLME = "";     //LME銅板現貨價
                string strSHFE = "";    //SHFE銅板現貨價
                //欄位限制防呆
                if (txtUSD_working.Text == "" || clsGlobal.ValidateString(txtUSD_working.Text, 8))
                {
                    MessageBox.Show("USD加工費/T請填數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtRMB_working.Text == "" || clsGlobal.ValidateString(txtRMB_working.Text, 8))
                {
                    MessageBox.Show("RMB加工費/T請填數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                strDate = DateTime.Now.ToString("yyyy/MM");

                if (MessageBox.Show("確定要修改嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                strSQL = $@"update copper_price
                            set    working_usd = {txtUSD_working.Text},
                                   working_rmb = {txtRMB_working.Text},
                                   user_id = '{clsGlobal.strG_User}',
                                   update_date = Getdate()
                            where  login_date = '{strDate} ' ";
                clsDB.Execute(strSQL);

                //上傳copper_working_history
                strSQL = $@"insert into copper_working_history
                                        (working_usd,
                                            working_rmb,
                                            user_id,
                                            create_date)
                            values      ({txtUSD_working.Text},
                                            {txtRMB_working.Text},
                                            '{clsGlobal.strG_User}',
                                            Getdate()) ";
                clsDB.Execute(strSQL);


                //輸入後顯示查詢

                WorkingIqr();

                MessageBox.Show("修改完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnModify_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {

                //確認權限
                if (clsGlobal.checkRightFlag("銅桿價設定儲存權限") == false)
                {
                    MessageBox.Show("您沒有銅桿價設定儲存權限權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                if (dblFinal == 0)
                {
                    MessageBox.Show("請先做查詢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                if (MessageBox.Show("儲存的銅價=" + dblFinal + ", 是否要儲存", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                //先取得asp參數
                GetAsp("銅桿OD2.6mm/kg");
                
                asp_purprice = dblFinal;      //單價
                asp_pricecal = asp_purprice.ToString();                                  //銅價火車頭單價計算式=單價
                DoUpdate_asp1();                     //更新asp資料(沒有做updateBOM)
                this.Cursor = Cursors.Default;//滑鼠還原預設

                MessageBox.Show("儲存完成!系統將回寫材料單價....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetAsp(string strID)     //取得asp參數
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select * from asp where asp_id= '{strID}'";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                asp_id = (string)dt.Rows[0]["asp_id"];
                asp_type = (string)dt.Rows[0]["asp_type"];
                asp_name = (string)dt.Rows[0]["asp_name"];
                asp_um = (string)dt.Rows[0]["asp_um"];
                asp_purprice = (Double)dt.Rows[0]["asp_purprice"];
                asp_standprice = (Double)dt.Rows[0]["asp_standprice"];
                asp_vendorid = (string)dt.Rows[0]["asp_vendorid"];
                asp_currency = (string)dt.Rows[0]["asp_currency"];
                asp_czf = (string)dt.Rows[0]["asp_czf"];
                asp_tjjz = (Double)dt.Rows[0]["asp_tjjz"];
                asp_area = (string)dt.Rows[0]["asp_area"];
                asp_safeqty = (Double)dt.Rows[0]["asp_safeqty"];
                asp_weight = (Double)dt.Rows[0]["asp_weight"];
                asp_purleadtime = (Double)dt.Rows[0]["asp_purleadtime"];
                asp_makeleadtime = (Double)dt.Rows[0]["asp_makeleadtime"];
                asp_location = (string)dt.Rows[0]["asp_location"];
                asp_purchprice = (Double)dt.Rows[0]["asp_purchprice"];
                asp_purcurrency = (string)dt.Rows[0]["asp_purcurrency"];
                asp_dummyflag = (int)dt.Rows[0]["asp_dummyflag"];
                asp_pricecal = (string)dt.Rows[0]["asp_pricecal"];
                asp_vendormaterialno = (string)dt.Rows[0]["asp_vendormaterialno"];
                asp_spec = (string)dt.Rows[0]["asp_spec"];
                asp_line = (string)dt.Rows[0]["asp_line"];
                asp_od = (string)dt.Rows[0]["asp_od"];
                asp_multinum = (string)dt.Rows[0]["asp_multinum"];
                asp_vnweight = (Double)dt.Rows[0]["asp_vnweight"];
                asp_vnpcs = (Double)dt.Rows[0]["asp_vnpcs"];
                asp_lengum = (string)dt.Rows[0]["asp_lengum"];
                asp_oddate = ((DateTime)dt.Rows[0]["asp_oddate"]).ToString("yyyy/MM/dd");
                asp_oduser = (string)dt.Rows[0]["asp_oduser"];
            }
        }

        private void DoUpdate_asp1() // 更新asp資料(沒有做updateBOM)
        {

            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                /// intIDCount
                strSQL = $@"select * from asm where asm_id = '{asp_id}'";
                dt = clsDB.sql_select_dt(strSQL);
                int intIDCount = dt.Rows.Count; // intIDCount

                /// strUser
                strSQL = $@"select wus_name from wus where wus_computername=host_name()";
                string strUser = clsDB.sql_select_String(strSQL, "wus_name");  // strUser
                asp_vendormaterialno = asp_vendormaterialno.Replace("\n", "").Replace("\r", "").Trim();  //去ENTER 換行 空白

                /// 當材料名儲存時,一起同步多品號內層的資料
                strSQL = $@"select aspnum_id from aspnum where aspnum_id = '{asp_id}' and aspnum_num = '{asp_vendormaterialno}'";
                string aspnumid = clsDB.sql_select_String(strSQL, "aspnum_id");
                if (aspnumid != "")
                {
                    strSQL = $@"update aspnum
                                set    aspnum_price = {asp_purprice},
                                       aspnum_pricecal = '{asp_pricecal}',
                                       aspnum_spec = '{asp_spec}',
                                       aspnum_memo = '{asp_czf}',
                                       aspnum_currency = '{asp_currency}',
                                       aspnum_vendorid = '{asp_vendorid}',
                                       aspnum_um = '{asp_um}',
                                       aspnum_modifydate = Cast(Year(Getdate()) as VARCHAR(4)) + '/'
                                                           + Cast(Month(Getdate()) as VARCHAR(2)) + '/'
                                                           + Cast(Day(Getdate()) as VARCHAR(2))
                                from   aspnum
                                where  aspnum_id = '{asp_id}'
                                       and aspnum_num = '{asp_vendormaterialno}' ";
                    clsDB.Execute(strSQL);
                }

                strSQL = $@"select asp_id from asp where asp_id='{asp_id}'";
                string strID = clsDB.sql_select_String(strSQL, "asp_id");
                if (strID == "")
                {
                    strSQL = $@"insert asp
                                       (asp_id,
                                        asp_type,
                                        asp_name,
                                        asp_um,
                                        asp_purprice,
                                        asp_standprice,
                                        asp_vendorid,
                                        asp_currency,
                                        asp_czf,
                                        asp_tjjz,
                                        asp_area,
                                        asp_safeqty,
                                        asp_weight,
                                        asp_purleadtime,
                                        asp_makeleadtime,
                                        asp_location,
                                        asp_purchprice,
                                        asp_purcurrency,
                                        asp_dummyflag,
                                        asp_user,
                                        asp_pricecal,
                                        asp_vendormaterialno,
                                        asp_spec)
                                values ('{asp_id}',
                                        '{asp_type}',
                                        '{asp_name}',
                                        '{asp_um}',
                                        {asp_purprice},
                                        {asp_standprice},
                                        '{asp_vendorid}',
                                        '{asp_currency}',
                                        '{asp_czf}',
                                        {asp_tjjz},
                                        '{asp_area}',
                                        {asp_safeqty},
                                        {asp_weight},
                                        {asp_purleadtime},
                                        {asp_makeleadtime},
                                        '{asp_location}',
                                        {asp_purchprice},
                                        '{asp_purcurrency}',
                                        {asp_dummyflag},
                                        '{strUser}',
                                        '{asp_pricecal}',
                                        '{asp_vendormaterialno}',
                                        '{asp_spec}') ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"insert asm
                                       (asm_id,
                                        asm_um,
                                        asm_purprice,
                                        asm_vendorid,
                                        asm_currency,
                                        asm_materialno,
                                        asm_vendormaterialno,
                                        asm_area,
                                        asm_user,
                                        asm_czf)
                                values('{asp_id}',
                                       '{asp_um}',
                                       {asp_purprice},
                                       '{asp_vendorid}',
                                       '{asp_currency}',
                                       {asp_tjjz},
                                       '{asp_vendormaterialno}',
                                       '{asp_area}',
                                       '{strUser}',
                                       '{asp_czf}') ";
                    clsDB.Execute(strSQL);
                }
                else
                {
                    strSQL = $@"update asp
                                set    asp_adddate = Getdate(),
                                       asp_user = '{strUser}',
                                       asp_pricecal = '{asp_pricecal}',
                                       asp_vendormaterialno = '{asp_vendormaterialno}',
                                       asp_spec = '{asp_spec}',
                                       asp_purprice = Round({asp_purprice}, 6),
                                       asp_currency = '{asp_currency}',
                                       asp_location = '{asp_location}',
                                       asp_purchprice = {asp_purchprice},
                                       asp_purcurrency = '{asp_purcurrency}',
                                       asp_dummyflag = {asp_dummyflag},
                                       asp_tjjz = {asp_tjjz},
                                       asp_area = '{asp_area}',
                                       asp_safeqty = {asp_safeqty},
                                       asp_weight = {asp_weight},
                                       asp_purleadtime = {asp_purleadtime},
                                       asp_makeleadtime = {asp_makeleadtime},
                                       asp_name = '{asp_name}',
                                       asp_type = '{asp_type}',
                                       asp_um = '{asp_um}',
                                       asp_standprice = {asp_standprice},
                                       asp_vendorid = '{asp_vendorid}',
                                       asp_czf = '{asp_czf}'
                                where  asp_id = '{asp_id}' ";
                    clsDB.Execute(strSQL);
                    if (intIDCount == 0)
                    {
                        strSQL = $@"insert asm
                                           (asm_id,
                                            asm_um,
                                            asm_purprice,
                                            asm_vendorid,
                                            asm_currency,
                                            asm_materialno,
                                            asm_vendormaterialno,
                                            asm_area,
                                            asm_user,
                                            asm_czf)
                                    values('{asp_id}',
                                           '{asp_um}',
                                           {asp_purprice},
                                           '{asp_vendorid}',
                                           '{asp_currency}',
                                           {asp_tjjz},
                                           '{asp_vendormaterialno}',
                                           '{asp_area}',
                                           '{strUser}',
                                           '{asp_czf}') ";
                        clsDB.Execute(strSQL);
                    }
                    else if (intIDCount == 1)
                    {
                        strSQL = $@"update asm
                                    set    asm_um = '{asp_um}',
                                           asm_purprice = {asp_purprice},
                                           asm_vendorid = '{asp_vendorid}',
                                           asm_currency = '{asp_currency}',
                                           asm_materialno = {asp_tjjz},
                                           asm_vendormaterialno = '{asp_vendormaterialno}',
                                           asm_area = '{asp_area}',
                                           asm_user = '{strUser}',
                                           asm_czf = '{asp_czf}'
                                    where  asm_id = '{asp_id}'";
                        clsDB.Execute(strSQL);
                    }
                    else
                    {
                        strSQL = $@"update asm
                                    set    asm_um = '{asp_um}',
                                           asm_purprice = {asp_purprice},
                                           asm_vendorid = '{asp_vendorid}',
                                           asm_currency = '{asp_currency}',
                                           asm_vendormaterialno = '{asp_vendormaterialno}',
                                           asm_area = '{asp_area}',
                                           asm_user = '{strUser}',
                                           asm_czf = '{asp_czf}'
                                    where  asm_id = '{asp_id}'
                                           and asm_materialno = {asp_tjjz}";
                        clsDB.Execute(strSQL);
                    }
                }

                strSQL = $@"select avt_vendorid from avt where avt_id='{asp_id}' and avt_vendorid='{asp_vendorid}'";
                string strVID = clsDB.sql_select_String(strSQL, "avt_vendorid");
                if (strVID == "")
                {
                    strSQL = $@"insert avt
                                       (avt_id,
                                        avt_vendorid,
                                        avt_price,
                                        avt_vendorname,
                                        avt_currency,
                                        avt_fktj,
                                        avt_tb,
                                        avt_adddate,
                                        avt_kpercent,
                                        avt_vendormaterialno)
                                select '{asp_id}',
                                       '{asp_vendorid}',
                                       {asp_purprice},
                                       ven_shortname,
                                       '{asp_currency}',
                                       ven_payment,
                                       Round({asp_purprice} * cur_convert, 6),
                                       Getdate(),
                                       ven_kpercent,
                                       '{asp_vendormaterialno}'
                                from   ven,
                                       cur
                                where  ven_id = '{asp_vendorid}'
                                       and cur_code = '{asp_currency}' ";
                    clsDB.Execute(strSQL);
                }
                else
                {
                    strSQL = $@"update avt
                                set    avt_adddate = Getdate(),
                                       avt_vendormaterialno = '{asp_vendormaterialno}'
                                where  avt_id = '{asp_id}'
                                       and avt_vendorid = '{asp_vendorid}' ";
                    clsDB.Execute(strSQL);
                }

                string strName = "";
                strSQL = $@"select ptx_name
                            from   ptx
                            where  ptx_name = '{asp_id}' ";
                strName = clsDB.sql_select_String(strSQL, "ptx_name");

                strSQL = $@"update pri
                            set    pri_firstname = ap1_assy
                            from   ap1,
                                   ap2,
                                   ap3,
                                   ptx,
                                   pri
                            where  pri_part = '{asp_id}'
                                   and ap1_part = ap2_assy
                                   and ap2_part = ap3_assy
                                   and ap3_part = ptx_name
                                   and ptx_name = '{asp_id}' ";
                clsDB.Execute(strSQL);
                strSQL = $@"delete ptx where ptx_name='{asp_id}'";
                clsDB.Execute(strSQL);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-DoUpdate_asp" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoUpdate_asp()     //更新asp資料
        {
            DataTable dt = new DataTable();
            SqlCommand cmd;
            string strSQL = $@"exec asp_save1 N'{asp_id}',
                                            '{asp_type}',
                                            '{asp_name}',
                                            '{asp_um}',
                                            {asp_purprice},
                                            {asp_standprice},
                                            '{asp_vendorid}',
                                            '{asp_currency}',
                                            N'{asp_czf}',
                                            '{asp_tjjz}',
                                            '{asp_area}',
                                            {asp_safeqty},
                                            {asp_weight},
                                            {asp_purleadtime},
                                            {asp_makeleadtime},
                                            '',
                                            {asp_purchprice},
                                            '{asp_purcurrency}',
                                            {asp_dummyflag},
                                            '{asp_pricecal}',
                                            '{asp_vendormaterialno}',
                                            N'{asp_spec}'";
            clsDB.Execute(strSQL);
        }

        private void DoUpdate_asp_od()     //更新審核+越南材料check
        {
            string odtmp;
            if (asp_od.Substring(0, 1) == "Y")
            {
                odtmp = "Y";
            }
            else
            {
                odtmp = " ";
            }
            if (asp_od.Substring(1, 1) == "Y")
            {
                odtmp = odtmp + "Y";
            }
            else
            {
                odtmp = odtmp + " ";
            }

            string strSQL = $@"update asp 
                                set   asp_od = '{odtmp}', 
                                      asp_oddate = '{oddate}', 
                                      asp_oduser = '{oduser}', 
                                      asp_multinum = N'{asp_multinum}' 
                                where asp_id = '{asp_id}'";
            clsDB.Execute(strSQL);
        }

        private void DoUpdate_asp_line()     //更新越南運費計重
        {
            if (asp_line == "Y")
            {
                //使用asp_line欄位來記錄越南運費計重,asp_vnweight記錄重量,asp_vnpcs記錄數量
                DoUpdate_asp_line_Y();
                //更新計重重量
                DoUpdateWeight();

            }
            else
            {
                //使用asp_line欄位來記錄越南運費計重,asp_vnweight記錄重量,asp_vnpcs記錄數量
                DoUpdate_asp_line_N();
                //更新計重重量
                DoUpdateWeight();
            }
        }

        private void DoUpdate_asp_line_Y()     //使用asp_line_Y欄位來記錄越南運費計重,asp_vnweight記錄重量,asp_vnpcs記錄數量
        {
            string strSQL = $@"update asp set asp_line='Y',asp_vnweight= {asp_vnweight} ,asp_vnpcs={asp_vnpcs} where asp_id='{asp_id}'";
            clsDB.Execute(strSQL);
        }
        private void DoUpdate_asp_line_N()     //使用asp_line_Y欄位來記錄越南運費計重,asp_vnweight記錄重量,asp_vnpcs記錄數量
        {

            string strSQL = $@"update asp set asp_line='',asp_vnweight= 0 ,asp_vnpcs=0 where asp_id='{asp_id}' and asp_line='Y'";
            clsDB.Execute(strSQL);
        }
        private void DoUpdateWeight()     //更新計重重量
        {
            string vid;
            DataTable dt = new DataTable();
            string strSQL = $@"SELECT distinct pri_customerid from pri with (nolock) where pri_part in ( select pub_vnfreight from pub) and pri_customerid in (select pri_customerid from pri where pri_part = '{asp_id}')";

            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                vid = (string)dt.Rows[0]["pri_customerid"];

                strSQL = $@"SELECT pri_perqty,isnull(asp_vnweight,0) 'asp_vnweight',isnull(asp_vnpcs,0) 'asp_vnpcs' from pri with (nolock) left join asp on asp_id=pri_part where pri_customerid ='{vid}' and asp_line='Y'";
                Values V = GetValues(strSQL);       //取得vqtycal;vqtysum;


                strSQL = $@"update pri set pri_perqty=round({V.vqtysum},6),pri_perqtycal='{V.vqtycal}',pri_cost=round(pri_tbprice*round({V.vqtysum},6),6),pri_costflag='Y' where pri_customerid='{vid}' and pri_part in (select pub_vnfreight from pub)";
                clsDB.Execute(strSQL);       //執行SQL命令}
            }
        }

        private static Values GetValues(string strSQL)      //取得vqtycal;vqtysum;
        {
            Values V = new Values();
            V.vqtycal = "";
            V.vqtysum = 0;
            DataTable dt= new DataTable();
            dt=clsDB.sql_select_dt(strSQL);
            if(dt.Rows.Count > 0 )
            {
                if (V.vqtycal == "")
                {
                    if (dt.Rows[0]["asp_vnweight"].ToString() == "0")
                    {
                        V.vqtycal = ((double)dt.Rows[0]["pri_perqty"]).ToString("0." + new string('#', 339));
                        V.vqtysum = (double)dt.Rows[0]["pri_perqty"];
                    }
                    else
                    {
                        V.vqtycal = ((double)dt.Rows[0]["asp_vnweight"]).ToString("0." + new string('#', 339)) + "/" + ((double)dt.Rows[0]["asp_vnpcs"]).ToString("0." + new string('#', 339)) + "*" + ((double)dt.Rows[0]["pri_perqty"]).ToString("0." + new string('#', 339));
                        V.vqtysum = (double)dt.Rows[0]["asp_vnweight"] / (double)dt.Rows[0]["asp_vnpcs"] * (double)dt.Rows[0]["pri_perqty"];
                    }
                }
                else
                {
                    if (dt.Rows[0]["asp_vnweight"].ToString() == "0")
                    {
                        V.vqtycal = V.vqtycal + "+" + ((double)dt.Rows[0]["pri_perqty"]).ToString("0." + new string('#', 339));
                        V.vqtysum = V.vqtysum + (double)dt.Rows[0]["pri_perqty"];
                    }
                    else
                    {
                        V.vqtycal = V.vqtycal + "+" + ((double)dt.Rows[0]["asp_vnweight"]).ToString("0." + new string('#', 339)) + "/" + ((double)dt.Rows[0]["asp_vnpcs"]).ToString("0." + new string('#', 339)) + "*" + ((double)dt.Rows[0]["pri_perqty"]).ToString("0." + new string('#', 339));
                        V.vqtysum = V.vqtysum + (double)dt.Rows[0]["asp_vnweight"] / (double)dt.Rows[0]["asp_vnpcs"] * (double)dt.Rows[0]["pri_perqty"];
                    }
                }
            }

            return V;
        }

        private void DoUpdate_asp_lengum()     //線材材料UL標記
        {
            if (asp_lengum == "Y")
            {
                asp_lengum = "Y";
            }
            else
            {
                asp_lengum = "";
            }

            string strSQL = $@"update asp set asp_lengum='{asp_lengum}' where asp_id='{asp_id}'";
            clsDB.Execute(strSQL);
        }

        private void DoCheck_asp_vendormaterialno()     //檢查是否有品號,若有則檢查多品號設定
        {
            Boolean chknum = false;
            string strSQL = "";
            DataTable dt = new DataTable();
            
            if (asp_vendormaterialno != "")
            {
                strSQL = $@"SELECT  [aspnum_id] as 材料名,[aspnum_num] AS 品號 From aspnum  where aspnum_id ='{asp_id}' and aspnum_num='{asp_vendormaterialno}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    chknum = true;
                } 
                if (chknum != true)//'檢查多品號中是否已有資料,若有才處理,若沒有則要先建立好品號資料才能儲存
                {
                    strSQL = $@"INSERT INTO [dbo].[aspnum] 
                                ([aspnum_id],[aspnum_num],[aspnum_modifydate],[aspnum_price],[aspnum_currency],[aspnum_memo],[aspnum_pricecal],[aspnum_vendorid],[aspnum_spec],[aspnum_um]) 
                                VALUES 
                                ('{asp_id}','{asp_vendormaterialno}','{DateTime.Now.ToString("yyyy/MM/dd")}','{asp_purprice} ','{asp_currency} ','{asp_czf} ','{asp_pricecal} ','{asp_vendorid} ','{asp_spec} ','{asp_um} ')";
                    clsDB.Execute(strSQL);
                }
            }
            else
            {
                strSQL = $@"delete from aspnum  where aspnum_id ='{asp_id}'";
                clsDB.Execute(strSQL);
            }

        }
        private void DoCheck_pri_newcostchk()     //檢查材料單是否存在,若不存在則把標記去除
        {
            string strSQL = "";
            strSQL = $@"select * from pri where pri_customerid='{asp_id}' and pri_newcostchk like 'Y%'";
            DataTable dt= new DataTable();
            dt = clsDB.sql_select_dt(strSQL);
            if(dt.Rows.Count > 0 )
            {
                strSQL = $@"update asp set asp_name='' where asp_id='{asp_id}'";
                clsDB.Execute(strSQL);
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

        private void btnHistory_Click(object sender, EventArgs e)
        {
            //查價史
            try
            {
                frmInq_History_Working frmInq_History_Working = new frmInq_History_Working();
                frmInq_History_Working.ShowInTaskbar = false;//圖示不顯示在工作列
                frmInq_History_Working.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnHistory_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDate_Click(object sender, EventArgs e)
        {
            if (txtDate.Text == "")
            {
                txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }
    }
    struct Values
    {
        public string vqtycal;
        public double vqtysum;
    }


}
