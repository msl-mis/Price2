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
    public partial class frmSalesReport_Grid : Form
    {
        string strVendor = "";  //廠商
        string strSales = "";   //業務
        public frmSalesReport_Grid()
        {
            InitializeComponent();
        }

        private void frmSalesReport_Grid_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                
                string strSQL = "";
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
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
                            //加入業務
                            cboSales.Items.Clear();
                            strSQL = $@"select pas_username
                                        from   ord
                                               left join dbo.pas
                                                      on ord_ywcode = pas_ywcode
                                        where  pas_username != ''
                                               and pas_quote = '{dt.Rows[0]["pas_quote"].ToString()}'
                                        group  by pas_username
                                        order  by pas_username ";
                            dt2 = clsDB.sql_select_dt(strSQL);
                            if (dt2.Rows.Count > 0)
                            {
                                for(int i=0; i<dt2.Rows.Count; i++)
                                {
                                    cboSales.Items.Add(dt2.Rows[i]["pas_username"].ToString());
                                }
                            }
                        }
                        else
                        {
                            //加入業務
                            cboSales.Items.Clear();
                            strSQL = $@"select pas_username
                                        from   ord
                                               left join dbo.pas
                                                      on ord_ywcode = pas_ywcode
                                        where  pas_username != ''
                                               and pas_quote in ( '越南', '國外部', '國內部' )
                                        group  by pas_username
                                        order  by pas_username ";
                            dt2 = clsDB.sql_select_dt(strSQL);
                            if (dt2.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt2.Rows.Count; i++)
                                {
                                    cboSales.Items.Add(dt2.Rows[i]["pas_username"].ToString());
                                }
                            }
                        }
                    }
                }
                else
                {
                    
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
                dtpDateE.Value = new DateTime(DateTime.Now.Year, 12, 31); //本年年尾;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmSpecialExpenes_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        string[] strDateS = new string[6];      //起始日
        string[] strDateE = new string[6];      //結束日
        private void btnInq_Click(object sender, EventArgs e)
        {
            //查詢
            try
            {
                for(int i = 0; i<=1; i++)
                {
                    strDateS[i] = DateTime.Now.AddYears(-1 + i).ToString("yyyy") + "/" + dtpDateS.Value.ToString("MM/dd");
                    strDateE[i] = DateTime.Now.AddYears(-1 + i).ToString("yyyy") + "/" + dtpDateE.Value.ToString("MM/dd");
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                if (radio1.Checked)
                {
                    strSQL = $@"select a.odh_customer                            '客戶',
                                       round(a.YEAR_1, 0)                    '營業額',
                                       round(a.YEAR_1 / Sum(a.YEAR_1)
                                                           over() * 100, 2) '總比例%',
                                       round(Isnull(b.YEAR_0, 0), 0)         '去年營業額',
                                       round(Isnull(( a.YEAR_1 - b.YEAR_0 ) / b.YEAR_0 * 100, 0), 2)
                                                                                 '同期比較%',
                                       (select pas_username
                                        from   pas
                                        where  pas_ywcode = a.ord_ywcode)        '業務'
                                from   (select Isnull(Round(Sum(ord_qty * ord_pricost), 2), 0) YEAR_1,
                                               odh_customer,
                                               ord_ywcode
                                        from   ord,
                                               odh,
                                               odi
                                        where  ord_assy = odi_customerid
                                               and ord_orderid = odh_orderid
                                               and odh_newdate between '{strDateS[1]}' and '{strDateE[1]}' "
                                        + Get_strWhere()
                                        + $@"  group  by odh_customer,
                                                  ord_ywcode) a
                                       left join (select Isnull(Round(Sum(ord_qty * ord_pricost), 2), 0) YEAR_0,
                                                         odh_customer,
                                                         ord_ywcode
                                                  from   ord,
                                                         odh,
                                                         odi
                                                  where  ord_assy = odi_customerid
                                                         and ord_orderid = odh_orderid
                                                         and odh_newdate between '{strDateS[0]}' and '{strDateE[0]}' "
                                        + Get_strWhere()
                                        + $@"     group  by odh_customer,
                                                            ord_ywcode) b
                                              on a.odh_customer = b.odh_customer ";
                }

                if (radio4.Checked)
                {
                    strSQL = $@"select a.odh_customer                                                '客戶',
                                       Round(a.YEAR_1, 0)                                            '盈虧',
                                       Round(a.YEAR_1 / Sum(a.YEAR_1)over() * 100, 2)                '總比例%',
                                       Round(Isnull(b.YEAR_0, 0), 0)                                 '去年盈虧',
                                       Round(Isnull(( a.YEAR_1 - b.YEAR_0 ) / b.YEAR_0 * 100, 0), 2) '同期比較%',
                                       (select pas_username
                                        from   pas
                                        where  pas_ywcode = a.ord_ywcode)                            '業務'
                                from   (select Round(Isnull(Sum(( ord_pricost - ord_convprice ) * ord_qty), 0)
                                                     - Isnull(Sum(( odc_qty - odc_cszr ) * odc_convert), 0), 2) YEAR_1,
                                               odh_customer,
                                               ord_ywcode
                                        from   ord
                                               left join odc
                                                      on odc_orderid = ord_orderid
                                                         and odc_customerid = ord_assy
                                               left join odh
                                                      on odh_orderid = ord_orderid
                                        where  odh_newdate between '{strDateS[1]}' and '{strDateE[1]}' "
                                        + Get_strWhere()
                                        + $@"  group  by odh_customer,
                                                  ord_ywcode) a
                                       left join (select Round(Isnull(Sum(( ord_pricost - ord_convprice ) * ord_qty), 0) 
                                                                - Isnull(Sum(( odc_qty - odc_cszr ) * odc_convert), 0), 2) YEAR_0,
                                                         odh_customer,
                                                         ord_ywcode
                                                  from   ord
                                                         left join odc
                                                                on odc_orderid = ord_orderid
                                                                   and odc_customerid = ord_assy
                                                         left join odh
                                                                on odh_orderid = ord_orderid
                                                  where  odh_newdate between '{strDateS[0]}' and '{strDateE[0]}' "
                                        + Get_strWhere()
                                        + $@"     group  by odh_customer,
                                                            ord_ywcode) b
                                              on a.odh_customer = b.odh_customer ";
                }

                if (radio3.Checked)
                {
                    strSQL = $@"select a.odh_customer                            '客戶',
                                       round(a.YEAR_1, 0)                    '營業額',
                                       round(a.YEAR_1 / Sum(a.YEAR_1)
                                                           over() * 100, 2) '總比例%',
                                       round(Isnull(b.YEAR_0, 0), 0)         '去年營業額',
                                       round(Isnull(( a.YEAR_1 - b.YEAR_0 ) / b.YEAR_0 * 100, 0), 2)
                                                                                 '同期比較%',
                                       (select pas_username
                                        from   pas
                                        where  pas_ywcode = a.ord_ywcode)        '業務'
                                from   (select Isnull(Round(Sum(ord_qty * ord_pricost), 2), 0) YEAR_1,
                                               odh_customer,
                                               ord_ywcode
                                        from   ord,
                                               odh,
                                               odi
                                        where  ord_assy = odi_customerid
                                               and ord_orderid = odh_orderid
                                               and odh_newdate between '{strDateS[1]}' and '{strDateE[1]}' "
                                        + Get_strWhere()
                                        + $@"  and ( odh_customer = '4'
                                                      or Substring(odi_customer, 1, 2) = '4-' )
                                        group  by odh_customer,
                                                  ord_ywcode) a
                                       left join (select Isnull(Round(Sum(ord_qty * ord_pricost), 2), 0) YEAR_0,
                                                         odh_customer,
                                                         ord_ywcode
                                                  from   ord,
                                                         odh,
                                                         odi
                                                  where  ord_assy = odi_customerid
                                                         and ord_orderid = odh_orderid
                                                         and odh_newdate between '{strDateS[0]}' and '{strDateE[0]}' "
                                        + Get_strWhere()
                                        + $@"  and ( odh_customer = '4'
                                                                or Substring(odi_customer, 1, 2) = '4-' )
                                                  group  by odh_customer,
                                                            ord_ywcode) b
                                              on a.odh_customer = b.odh_customer ";
                }

                if (radio4.Checked)
                {
                    strSQL = $@"select a.odh_customer                                                '客戶',
                                       Round(a.YEAR_1, 0)                                            '盈虧',
                                       Round(a.YEAR_1 / Sum(a.YEAR_1)over() * 100, 2)                '總比例%',
                                       Round(Isnull(b.YEAR_0, 0), 0)                                 '去年盈虧',
                                       Round(Isnull(( a.YEAR_1 - b.YEAR_0 ) / b.YEAR_0 * 100, 0), 2) '同期比較%',
                                       (select pas_username
                                        from   pas
                                        where  pas_ywcode = a.ord_ywcode)                            '業務'
                                from   (select Round(Isnull(Sum(( ord_pricost - ord_convprice ) * ord_qty), 0)
                                                     - Isnull(Sum(( odc_qty - odc_cszr ) * odc_convert), 0), 2) YEAR_1,
                                               odh_customer,
                                               ord_ywcode
                                        from   ord
                                               left join odc
                                                      on odc_orderid = ord_orderid
                                                         and odc_customerid = ord_assy
                                               left join odh
                                                      on odh_orderid = ord_orderid
                                        where  odh_newdate between '{strDateS[1]}' and '{strDateE[1]}' "
                                        + Get_strWhere()
                                        + $@"  and ( odh_customer = '4'
                                                      or Substring(odh_customer, 1, 2) = '4-' )
                                        group  by odh_customer,
                                                  ord_ywcode) a
                                       left join (select Round(Isnull(Sum(( ord_pricost - ord_convprice ) * ord_qty), 0) 
                                                                - Isnull(Sum(( odc_qty - odc_cszr ) * odc_convert), 0), 2) YEAR_0,
                                                         odh_customer,
                                                         ord_ywcode
                                                  from   ord
                                                         left join odc
                                                                on odc_orderid = ord_orderid
                                                                   and odc_customerid = ord_assy
                                                         left join odh
                                                                on odh_orderid = ord_orderid
                                                  where  odh_newdate between '{strDateS[0]}' and '{strDateE[0]}' "
                                        + Get_strWhere()
                                        + $@"     and ( odh_customer = '4'
                                                                or Substring(odh_customer, 1, 2) = '4-' )
                                                  group  by odh_customer,
                                                            ord_ywcode) b
                                              on a.odh_customer = b.odh_customer ";
                }
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    dgvData.Columns[1].DefaultCellStyle.Format = "N0";
                    dgvData.Columns[3].DefaultCellStyle.Format = "N0";
                    //DataGridViewCellStyle cellstyle1 = new DataGridViewCellStyle() { Format = "#,###" };
                    if(radio1.Checked ||radio3.Checked)
                    {
                        txtT1.Text = Convert.ToDouble(dt.Compute("SUM([營業額])", "")).ToString("N0");
                        txtT3.Text = Convert.ToDouble(dt.Compute("SUM([去年營業額])", "")).ToString();
                    }
                    else
                    {
                        txtT1.Text = Convert.ToDouble(dt.Compute("SUM([盈虧])", "")).ToString("N0");
                        txtT3.Text = Convert.ToDouble(dt.Compute("SUM([去年盈虧])", "")).ToString();
                    }
                    txtT2.Text = dt.Compute("SUM([總比例%] )", "").ToString();
                    
                    txtT4.Text =( (Convert.ToDouble(txtT1.Text) - Convert.ToDouble(txtT3.Text))/ Convert.ToDouble(txtT3.Text)*100).ToString("0.##");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Get_strWhere()
        {
            string strWhere = "";

            
            //廠商
            strWhere = strWhere + (cboVendorID.Text == "" ? "" : $@"and odi_customerid in (select distinct pri_customerid from pri where pri_vendorid='{strVendor}') and odi_customerid in (select distinct ord_assy from ord) ");
            //業務
            strWhere = strWhere + (cboSales.Text == "" ? "" : $@"and ord_ywcode = '{strSales}' ");
            //分類
            strWhere = strWhere + (cboClass.Text == "" ? "" : $@"and odi_customerid in (select distinct pri_customerid from pri where pri_fenlei='{cboClass.Text}') ");
            
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
            txtT1.Text = "";
            txtT2.Text = "";
            txtT3.Text = "";
            txtT4.Text = "";
            if (dgvData.Rows.Count > 0)
            {
                DataTable dt = (DataTable)dgvData.DataSource;
                dt.Rows.Clear();
                dgvData.DataSource = dt;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                if (radio1.Checked || radio3.Checked)
                {
                    clsGlobal.ExportExcel("客戶營業額比較結果", dgvData);
                }
                else
                {
                    clsGlobal.ExportExcel("客戶成交利潤比較結果", dgvData);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                e.ToolTipText = "雙擊顯示明細";
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i <= 1; i++)
            {
                strDateS[i] = DateTime.Now.AddYears(-1 + i).ToString("yyyy") + "/" + dtpDateS.Value.ToString("MM/dd");
                strDateE[i] = DateTime.Now.AddYears(-1 + i).ToString("yyyy") + "/" + dtpDateE.Value.ToString("MM/dd");
            }
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string strSQL = "";
                if (radio1.Checked || radio3.Checked)
                {
                    frmSalesReport_Grid_Inq frmSalesReport_Grid_Inq = new frmSalesReport_Grid_Inq();
                    frmSalesReport_Grid_Inq.ShowInTaskbar = false;//圖示不顯示在工作列
                    strSQL = $@"";
                    frmSalesReport_Grid_Inq.rstrSQL = strSQL;
                    frmSalesReport_Grid_Inq.ShowDialog();
                }
                else
                {
                    frmSalesReport_Grid_Inq frmSalesReport_Grid_Inq = new frmSalesReport_Grid_Inq();
                    frmSalesReport_Grid_Inq.ShowInTaskbar = false;//圖示不顯示在工作列
                    strSQL = $@"";
                    frmSalesReport_Grid_Inq.rstrSQL = strSQL;
                    frmSalesReport_Grid_Inq.ShowDialog();
                }
            }
        }
    }
}
