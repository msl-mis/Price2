using Sunny.UI.Win32;
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
    public partial class frmEPS : Form
    {
        public frmEPS()
        {
            InitializeComponent();
        }

        private void frmEPS_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                //日期
                dtpYear.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                //日期欄位
                for (int i = 1; i <= 5; i++)
                {
                    //年
                    Label label_Y = (Label)tlp1.GetControlFromPosition(i, 0);
                    label_Y.Text = (Convert.ToInt32(dtpYear.Value.ToString("yyyy")) - 5 + i).ToString() + "年";
                    //半年
                    Label label_H = (Label)tlp2.GetControlFromPosition(i, 0);
                    label_H.Text = (Convert.ToInt32(dtpYear.Value.ToString("yyyy")) - 5 + i).ToString() + "年";
                    //季
                    Label label_Q = (Label)tlp3.GetControlFromPosition(i, 0);
                    label_Q.Text = (Convert.ToInt32(dtpYear.Value.ToString("yyyy")) - 5 + i).ToString() + "年";

                }
                getClear();
                panel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmEPS_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getClear()
        {
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    //年
                    Label label_Y = (Label)tlp1.GetControlFromPosition(i, j);
                    label_Y.Text = "";
                }
                for (int j = 1; j <= 4; j++)
                {
                    //半年
                    Label label_H = (Label)tlp2.GetControlFromPosition(i, j);
                    label_H.Text = "";
                }
                for (int j = 1; j <= 8; j++)
                {
                    //季
                    Label label_Q = (Label)tlp3.GetControlFromPosition(i, j);
                    label_Q.Text = "";
                }
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

        private void dtpYear_Leave(object sender, EventArgs e)
        {
            
        }

        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = radio1.Checked;
        }

        private void radio2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = radio2.Checked;
        }

        private void radio3_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = radio3.Checked;
        }

        private void btnInq_Click(object sender, EventArgs e)
        {
            //查詢
            try
            {
                //日期欄位
                for (int i = 1; i <= 5; i++)
                {
                    //年
                    Label label_Y = (Label)tlp1.GetControlFromPosition(i, 0);
                    label_Y.Text = (Convert.ToInt32(dtpYear.Value.ToString("yyyy")) - 5 + i).ToString() + "年";
                    //半年
                    Label label_H = (Label)tlp2.GetControlFromPosition(i, 0);
                    label_H.Text = (Convert.ToInt32(dtpYear.Value.ToString("yyyy")) - 5 + i).ToString() + "年";
                    //季
                    Label label_Q = (Label)tlp3.GetControlFromPosition(i, 0);
                    label_Q.Text = (Convert.ToInt32(dtpYear.Value.ToString("yyyy")) - 5 + i).ToString() + "年";
                }
                getYear();
                getHalf();
                getQuarter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Get_strWhere()
        {
            string strWhere = "";

            //部門
            if (cboDivision.Text == "")
            {
                strWhere = strWhere + $@"and odi_customer != '168' ";
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
                strWhere = strWhere + $@"and (odi_customer != '4' and substring(odi_customer,1,2) != '4-'and odi_customer != '168') ";
            }

            
            return strWhere;
        }

        string[] strDateS = new string[6];      //起始日
        string[] strDateE = new string[6];      //結束日
        private void getYear()
        {
            string strSQL = "";
            DataTable dt = new DataTable();

            for (int i = 1; i <= 5; i++)
            {
                strDateS[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/01/01";
                strDateE[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/12/31";
                Label label_Profit = (Label)tlp1.GetControlFromPosition(i, 1);
                label_Profit.Text = getProfit(strDateS[i], strDateE[i]);
                Label label_ESP = (Label)tlp1.GetControlFromPosition(i, 2);
                label_ESP.Text = (Convert.ToDouble(label_Profit.Text) / 28080000).ToString("0.##");
            }
        }
        private void getHalf()
        {
            string strSQL = "";
            DataTable dt = new DataTable();

            for (int i = 1; i <= 5; i++)
            {
                strDateS[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/01/01";
                strDateE[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/06/30";
                Label label_Profit = (Label)tlp2.GetControlFromPosition(i, 1);
                label_Profit.Text = getProfit(strDateS[i], strDateE[i]);
                Label label_ESP = (Label)tlp2.GetControlFromPosition(i, 2);
                label_ESP.Text = (Convert.ToDouble(label_Profit.Text) / 28080000).ToString("0.##");
            }
            for (int i = 1; i <= 5; i++)
            {
                strDateS[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/07/01";
                strDateE[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/12/31";
                Label label_Profit = (Label)tlp2.GetControlFromPosition(i, 3);
                label_Profit.Text = getProfit(strDateS[i], strDateE[i]);
                Label label_ESP = (Label)tlp2.GetControlFromPosition(i, 4);
                label_ESP.Text = (Convert.ToDouble(label_Profit.Text) / 28080000).ToString("0.##");
            }
        }

        private void getQuarter()
        {
            string strSQL = "";
            DataTable dt = new DataTable();

            for (int i = 1; i <= 5; i++)
            {
                strDateS[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/01/01";
                strDateE[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/03/31";
                Label label_Profit = (Label)tlp3.GetControlFromPosition(i, 1);
                label_Profit.Text = getProfit(strDateS[i], strDateE[i]);
                Label label_ESP = (Label)tlp3.GetControlFromPosition(i, 2);
                label_ESP.Text = (Convert.ToDouble(label_Profit.Text) / 28080000).ToString("0.##");
            }
            for (int i = 1; i <= 5; i++)
            {
                strDateS[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/04/01";
                strDateE[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/06/30";
                Label label_Profit = (Label)tlp3.GetControlFromPosition(i, 3);
                label_Profit.Text = getProfit(strDateS[i], strDateE[i]);
                Label label_ESP = (Label)tlp3.GetControlFromPosition(i, 4);
                label_ESP.Text = (Convert.ToDouble(label_Profit.Text) / 28080000).ToString("0.##");
            }
            for (int i = 1; i <= 5; i++)
            {
                strDateS[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/07/01";
                strDateE[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/09/30";
                Label label_Profit = (Label)tlp3.GetControlFromPosition(i, 5);
                label_Profit.Text = getProfit(strDateS[i], strDateE[i]);
                Label label_ESP = (Label)tlp3.GetControlFromPosition(i, 6);
                label_ESP.Text = (Convert.ToDouble(label_Profit.Text) / 28080000).ToString("0.##");
            }
            for (int i = 1; i <= 5; i++)
            {
                strDateS[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/10/01";
                strDateE[i] = (Convert.ToInt32(dtpYear.Text) - 5 + i).ToString() + "/12/31";
                Label label_Profit = (Label)tlp3.GetControlFromPosition(i, 7);
                label_Profit.Text = getProfit(strDateS[i], strDateE[i]);
                Label label_ESP = (Label)tlp3.GetControlFromPosition(i, 8);
                label_ESP.Text = (Convert.ToDouble(label_Profit.Text) / 28080000).ToString("0.##");
            }
        }

        public string getProfit(string strDateS, string strDateE)
        {
            string strKS = "";             //客訴
            string strProfit_Result = "";  //利潤(結果)
            string strProfit = "";         //利潤(依查詢條件)
            string strProfit_All = "";     //總利潤(年度)
            string strSpecial = "";        //特別支出
            string strSpecial_In = "";     //特別支出排除國內部
            string strSpecial_Out = "";    //特別支出排除國外部
            string strSpecial_All = "";    //特別支出不計入全部

            string strSQL = "";
            DataTable dt = new DataTable();

            //客訴
            strSQL = $@"select Isnull(Floor(Sum(( odc_qty - odc_cszr ) * odc_convert)), 0) as KS
                            from   odc
                            where  odc_adddate between '{strDateS}' and '{strDateE}'
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
                strKS = (string.IsNullOrEmpty(dt.Rows[0]["KS"].ToString()) ? "0" : dt.Rows[0]["KS"].ToString());
            }

            //利潤(依查詢條件)
            strSQL = $@"select Isnull(Floor(Sum(( ord_pricost - ord_convprice ) * ord_qty)), 0) as PROFIT
                            from   ord,
                                   odh,
                                   odi
                            where  ord_assy = odi_customerid
                                   and ord_orderid = odh_orderid
                                   and odh_newdate between '{strDateS}' and '{strDateE}' "
                             + Get_strWhere();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strProfit = (string.IsNullOrEmpty(dt.Rows[0]["PROFIT"].ToString()) ? "0" : dt.Rows[0]["PROFIT"].ToString());
            }

            //總利潤(年度)
            strSQL = $@"select Isnull(Floor(Sum(( ord_pricost - ord_convprice ) * ord_qty)), 0) as PROFIT_ALL
                            from   ord,
                                   odh,
                                   odi
                            where  ord_assy = odi_customerid
                                   and ord_orderid = odh_orderid
                                   and odh_newdate between '{strDateS}' and '{strDateE}' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strProfit_All = (string.IsNullOrEmpty(dt.Rows[0]["PROFIT_ALL"].ToString()) ? "0" : dt.Rows[0]["PROFIT_ALL"].ToString());
            }

            //特別支出
            strSQL = $@"select Isnull(Floor(Sum(odca_convcost)), 0) as SPECIAL
                            from   odca
                            where  odca_date between '{strDateS}' and '{strDateE}' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strSpecial = (string.IsNullOrEmpty(dt.Rows[0]["SPECIAL"].ToString()) ? "0" : dt.Rows[0]["SPECIAL"].ToString());
            }

            //特別支出排除國內部
            strSQL = $@"select Isnull(Floor(Sum(odca_convcost)), 0) as SPECIAL_IN
                            from   odca
                            where  odca_date between '{strDateS}' and '{strDateE}'
                                   and odca_division = '國內部' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strSpecial_In = (string.IsNullOrEmpty(dt.Rows[0]["SPECIAL_IN"].ToString()) ? "0" : dt.Rows[0]["SPECIAL_IN"].ToString());
            }

            //特別支出排除國外部
            strSQL = $@"select Isnull(Floor(Sum(odca_convcost)), 0) as SPECIAL_OUT
                            from   odca
                            where  odca_date between '{strDateS}' and '{strDateE}'
                                   and odca_division = '國外部' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strSpecial_Out = (string.IsNullOrEmpty(dt.Rows[0]["SPECIAL_OUT"].ToString()) ? "0" : dt.Rows[0]["SPECIAL_OUT"].ToString());
            }

            //特別支出不計入全部
            strSQL = $@"select Isnull(Floor(Sum(odca_convcost)), 0) as SPECIAL_ALL
                            from   odca
                            where  odca_date between '{strDateS}' and '{strDateE}'
                                   and odca_division = '全部' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strSpecial_All = (string.IsNullOrEmpty(dt.Rows[0]["SPECIAL_ALL"].ToString()) ? "0" : dt.Rows[0]["SPECIAL_ALL"].ToString());
            }


            if (cboDivision.Text == "")
            {
                //利潤=利潤(依查詢條件)-(特別支出-特別支出排除)*(利潤(依查詢條件)/總利潤(年度))
                strProfit_Result = (Convert.ToDouble(strProfit) - (Convert.ToDouble(strSpecial) - Convert.ToDouble(strSpecial_All)) * (Convert.ToDouble(strProfit) / Convert.ToDouble(strProfit_All))).ToString("N0");
            }
            else if (cboDivision.Text == "國內部")
            {
                //利潤 = 利潤(依查詢條件) - (特別支出 - 特別支出排除)*(利潤(依查詢條件)/總利潤(年度)) - 特別支出排除
                strProfit_Result = (Convert.ToDouble(strProfit) - (Convert.ToDouble(strSpecial) - Convert.ToDouble(strSpecial_All) - Convert.ToDouble(strSpecial_In) - Convert.ToDouble(strSpecial_Out)) * (Convert.ToDouble(strProfit) / Convert.ToDouble(strProfit_All)) - Convert.ToDouble(strSpecial_Out)).ToString("N0");
            }
            else
            {
                //利潤 = 利潤(依查詢條件) - (特別支出 - 特別支出排除)*(利潤(依查詢條件)/總利潤(年度)) - 特別支出排除
                strProfit_Result = (Convert.ToDouble(strProfit) - (Convert.ToDouble(strSpecial) - Convert.ToDouble(strSpecial_All) - Convert.ToDouble(strSpecial_In) - Convert.ToDouble(strSpecial_Out)) * (Convert.ToDouble(strProfit) / Convert.ToDouble(strProfit_All)) - Convert.ToDouble(strSpecial_In)).ToString("N0");
            }

            return strProfit_Result;
        }

        

        
    }
}
