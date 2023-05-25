using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Price2
{
    public partial class frmOrder_Inq_Order_P : Form
    {
        public frmOrder_Inq_Order_P()
        {
            InitializeComponent();
        }

        private void frmOrder_Inq_Order_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                String strSQL = "";
                DataTable dt = new DataTable();
                //加入業務
                strSQL = $@"select distinct cus_yw from cus ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboSales.Items.Add(dt.Rows[i]["cus_yw"].ToString());
                    }
                }

                //加入第二層
                strSQL = $@"select distinct ap2_assy from ap2 order by ap2_assy ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboAp2.Items.Add(dt.Rows[i]["ap2_assy"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmOrder_Inq_Order_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNewDate_S_Click(object sender, EventArgs e)
        {
            if (txtNewDate_S.Text == "")
            {
                txtNewDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtNewDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtNewDate_E_Click(object sender, EventArgs e)
        {
            if (txtNewDate_E.Text == "")
            {
                txtNewDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtNewDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtDate_S_Click(object sender, EventArgs e)
        {
            if (txtDate_S.Text == "")
            {
                txtDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtDate_E_Click(object sender, EventArgs e)
        {
            if (txtDate_E.Text == "")
            {
                txtDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
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
                if (txtDate_E.Text != "" && txtDate_S.Text != "")
                {
                    if (Convert.ToDateTime(txtDate_S.Text) > Convert.ToDateTime(txtDate_E.Text))
                    {
                        MessageBox.Show("起始日期不可以大於結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        return;
                    }
                }
                if (txtNewDate_E.Text != "" && txtNewDate_S.Text != "")
                {
                    if (Convert.ToDateTime(txtNewDate_S.Text) > Convert.ToDateTime(txtNewDate_E.Text))
                    {
                        MessageBox.Show("起始日期不可以大於結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        return;
                    }
                }
                string strSQL = "";
                string strSQL11 = "";
                string strSQL12 = "";
                string strSQL21 = "";
                string strSQL22 = "";
                DataTable dt = new DataTable();

                strSQL11 = $@"select distinct odh_customer'客戶',
                                            odh_orderid'訂單編號',
                                            dbo.Formatstr(Isnull(Round(Sum((ord_pricost-ord_convprice)*ord_qty),1),0)-odh_ks,0)'盈虧', (
                                            case Isnull(Sum(ord_convprice * ord_qty), 0)
                                                            when 0 then 0
                                                            else Round(( Isnull(Sum((ord_pricost-ord_convprice)*ord_qty), 0) - odh_ks ) / ( ( Sum(ord_convprice * ord_qty) ) * 100 ), 0)
                                            end )'利潤',
                                            dbo.Formatstr(Isnull(Round(Sum(ord_qty*ord_pricost),0),0),0)'訂單金額',
                                            odh_yw'業務代碼',
                                            odh_orderdate'訂單日期',
                                            odh_newdate'新建日期',
                                            odh_delivedate'交期',
                                            odh_po 'PO',
                                            odh_bjdb '報價單號'
                            from            odh,
                                            ord,
                                            odi
                            where           odh_orderid=ord_orderid
                            and             ord_assy=odi_customerid
                            and             (
                                                            odh_customer='4'
                                            or              Substring(odh_customer,1,2)='4-') ";

                strSQL12 = $@"group by        odh_customer,
                                            odh_orderid,
                                            odh_orderdate,
                                            odh_newdate,
                                            odh_delivedate,
                                            odh_ks,
                                            odh_yw,
                                            odh_po,
                                            odh_bjdb ";

                strSQL21 = $@"select distinct odh_customer'客戶',
                                            odh_orderid'訂單編號',
                                            dbo.Formatstr(Isnull(Round(Sum((ord_pricost-ord_convprice)*ord_qty),1),0)-odh_ks,0)'盈虧', (
                                            case Isnull(Sum(ord_convprice * ord_qty), 0)
                                                            when 0 then 0
                                                            else Round(( Isnull(Sum((ord_pricost-ord_convprice)*ord_qty), 0) - odh_ks ) /  ( Sum(ord_convprice * ord_qty) ) * 100 , 0)
                                            end )'利潤',
                                            dbo.Formatstr(Isnull(Round(Sum(ord_qty*ord_price*ord_convert),0),0),0)'訂單金額',
                                            odh_yw'業務代碼',
                                            odh_orderdate'訂單日期',
                                            odh_newdate'新建日期',
                                            odh_delivedate'交期',
                                            odh_po 'P/O',
                                            odh_bjdb '報價單號'
                            from            odh,
                                            ord,
                                            odi
                            where           odh_orderid=ord_orderid
                            and             ord_assy=odi_customerid
                            and             odh_customer<>'4'
                            and             Substring(odh_customer,1,2)<>'4-' ";

                strSQL22 = $@"group by        odh_customer,
                                            odh_orderid,
                                            odh_orderdate,
                                            odh_newdate,
                                            odh_delivedate,
                                            odh_ks,
                                            odh_yw,
                                            odh_po,
                                            odh_bjdb
                            order by        odh_newdate desc,
                                            odh_customer,
                                            odh_orderid desc";
                strSQL = strSQL11 + Get_strWhere() + strSQL12 + " union all " + strSQL21 + Get_strWhere() + strSQL22;
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    lblCount.Text="共 "+dt.Rows.Count.ToString()+" 筆";

                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
                else
                {
                    dgvData.DataSource = dt;
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblCount.Text = "共 0 筆";
                    lblSum_Profit.Text = "Total：0";
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }

                strSQL = $@"select Isnull(Round(Sum(a.odh_ks), 0), 0) as kss
                            from   (select distinct odh_ks
                                    from   ord,
                                           odh,
                                           odi
                                    where  ord_orderid = odh_orderid
                                           and ord_assy = odi_customerid ";
                strSQL = strSQL + Get_strWhere() + ") as a ";
                dt = clsDB.sql_select_dt(strSQL);
                string tks = "";
                if (dt.Rows.Count > 0)
                {
                    tks = dt.Rows[0]["kss"].ToString();
                }
                else
                {
                    tks = "0";
                }
                if(chkGP.Checked)
                {
                    tks = "0";
                }

                strSQL = $@"select distinct Isnull(Round(Sum(( ord_pricost - ord_convprice ) * ord_qty), 0), 0) as yk,
                                            Sum(ord_qty) as yk1
                            from   ord,
                                   odh,
                                   odi
                            where  ord_orderid = odh_orderid
                                   and ord_assy = odi_customerid ";
                strSQL = strSQL + Get_strWhere() ;
                dt = clsDB.sql_select_dt(strSQL);
                string yk = "";
                if (dt.Rows.Count > 0)
                {
                    yk = dt.Rows[0]["yk"].ToString();
                    lblSum_Profit.Text = "總利潤："+ (Convert.ToDouble(tks) + Convert.ToDouble(yk)).ToString("N0");
                    lblProfit_Sum.Text = "利潤加總：" + (Convert.ToDouble(tks) + Convert.ToDouble(yk)).ToString("N0");

                }
                else
                {
                    lblSum_Profit.Text = "總利潤：0";
                    lblProfit_Sum.Text = "利潤加總：0";
                }

                strSQL = $@"select Isnull(Round(Sum(ord_qty), 0), 0)               as ttotalqty,
                                   Isnull(Round(Sum(ord_qty * ord_pricost), 0), 0) as costing
                            from   odh,
                                   ord,
                                   odi
                            where  odh_orderid = ord_orderid
                                   and ord_assy = odi_customerid
                                   and ( odh_customer = '4'
                                          or Substring(odh_customer, 1, 2) = '4-' ) ";
                strSQL = strSQL + Get_strWhere();
                dt = clsDB.sql_select_dt(strSQL);
                string tcosting = "";
                string totalqty = "";
                if (dt.Rows.Count > 0)
                {
                    tcosting = dt.Rows[0]["costing"].ToString();
                    totalqty = dt.Rows[0]["ttotalqty"].ToString();
                }
                else
                {
                    tcosting = "0";
                    totalqty = "0";
                }

                strSQL = $@"select Isnull(Round(Sum(ord_qty), 0), 0)                           as ttotalqty,
                                   Isnull(Round(Sum(ord_qty * ord_price * ord_convert), 0), 0) as costing
                            from   odh,
                                   ord,
                                   odi
                            where  odh_orderid = ord_orderid
                                   and ord_assy = odi_customerid
                                   and odh_customer <> '4'
                                   and Substring(odh_customer, 1, 2) <> '4-' ";
                strSQL = strSQL + Get_strWhere();
                dt = clsDB.sql_select_dt(strSQL);

                if (dt.Rows.Count > 0)
                {
                    tcosting = (Convert.ToDouble(tcosting) + Convert.ToDouble(dt.Rows[0]["costing"])).ToString("N0");
                    totalqty = (Convert.ToDouble(totalqty) + Convert.ToDouble(dt.Rows[0]["ttotalqty"])).ToString("N0");
                }
                lblSum_Price.Text = "總金額："+tcosting;
                lblSum_Qty.Text = "總數量：" + totalqty;
                lblOrder_Sum.Text = "訂單加總：" + tcosting;

                strSQL = $@"select ( case Sum(ord_convprice * ord_qty)
                                       when 0 then 0
                                       else Round(( Isnull(Sum(( ord_pricost - ord_convprice ) * ord_qty), 0 ) ) / ( Sum(ord_convprice * ord_qty) ) * 100, 1)
                                     end ) as pll
                            from   odh,
                                   ord,
                                   odi
                            where  odh_orderid = ord_orderid
                                   and ord_assy = odi_customerid ";
                strSQL = strSQL + Get_strWhere();
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    lblProfit_Avg.Text = "平均利潤：" + dt.Rows[0]["pll"]+"%";
                }
                else
                {
                    lblProfit_Avg.Text = "平均利潤：0%" ;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Get_strWhere()
        {
            string strWhere = "";

            //新增日期
            strWhere = strWhere + (txtNewDate_S.Text == "" ? "" : $@"and odh_newdate between '{txtNewDate_S.Text}' and '{txtNewDate_E.Text}' ");
            //成交日期
            strWhere = strWhere + (txtDate_S.Text == "" ? "" : $@"and odh_orderdate between '{txtDate_S.Text}' and '{txtDate_E.Text}' ");
            //客戶
            if (txtCustomer.Text == "4-")
            {
                strWhere = strWhere + $@"and odh_customer like '%4-%' ";
            }
            else if (txtCustomer.Text == "4")
            {
                strWhere = strWhere + $@"and (odh_customer ='4' or substring(odh_customer, 1, 2) = '4-') ";
            }
            else
            {
                strWhere = strWhere + (txtCustomer.Text == "" ? "" : $@"and odh_customer = '{txtCustomer.Text.Trim()}' ");
            }
            //線路
            strWhere = strWhere + (txtLine.Text == "" ? "" : $@"and ord_line like '%{txtLine.Text.Trim()}%' ");
            //訂單
            strWhere = strWhere + (txtOrder.Text == "" ? "" : $@"and odh_orderid like '%{txtOrder.Text.Trim()}%' ");
            //報價單號
            strWhere = strWhere + (txtQuotation.Text == "" ? "" : $@"and odh_bjdb like '%{txtQuotation.Text.Trim()}%' ");
            //交期
            strWhere = strWhere + (txtDelivery.Text == "" ? "" : $@"and pdh_delivedate = '{txtDelivery.Text.Trim()}' ");
            //客號
            if (txtCustomerID.Text.IndexOf(";") >= 0)//分號多條件搜尋
            {
                string[] str = txtCustomerID.Text.Split(';');
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Trim();
                    strWhere = strWhere + $@"and ord_assy like '%{str[i].Trim()}%' ";
                }
            }
            else
            {
                strWhere = strWhere + (txtCustomerID.Text == "" ? "" : $@"and ord_assy like '%{txtCustomerID.Text.Trim()}%' ");
            }
            //業務
            strWhere = strWhere + (cboSales.Text == "" ? "" : $@"and odh_yw = '{cboSales.Text.Trim()}' ");
            //第二層
            strWhere = strWhere + (cboAp2.Text == "" ? "" : $@"and ord_assy in (select distinct pri_customerid from pri, (select distinct ap3_part, ap2_assy from ap2, ap3 where ap2_part = ap3_assy and ap2_assy = '{cboAp2.Text.Trim()}') as aa where pri_part = aa.ap3_part) ");
            //分類
            strWhere = strWhere + (cboClass.Text == "" ? "" : $@"and ord_assy in (select distinct pri_customerid from pri where pri_fenlei = '{cboClass.Text.Trim()}' ) ");
            //參照法
            if (txtCZF.Text.IndexOf(";") >= 0)//分號多條件搜尋
            {
                string[] str = txtCZF.Text.Split(';');
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Trim();
                    strWhere = strWhere + $@"and odi_czf like '%{str[i].Trim()}%' ";
                }
            }
            else
            {
                strWhere = strWhere + (txtCZF.Text == "" ? "" : $@"and odi_czf like '%{txtCZF.Text.Trim()}%' ");
            }


            //電源
            strWhere = strWhere + (chkPower.Checked ? "and ord_wg = 2 " : "");
            //光纖
            strWhere = strWhere + (chkFiber.Checked ? "and ord_assy in (select distinct pri_customerid from pri where pri_fenlei = '14 Fiber Cable') " : "");
            //成朋
            strWhere = strWhere + (chkGP.Checked ? "and odi_gp = 1 " : "");
            //晶元
            strWhere = strWhere + (chkGC.Checked ? "and odi_gc = 1 " : "");
            //P/O
            strWhere = strWhere + (txtPO.Text == "" ? "" : $@"and odh_po like '%{txtPO.Text}%' ");

            return strWhere;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                //新增日期
                txtNewDate_S.Text = "";
                txtNewDate_E.Text = "";
                //客訴日期
                txtDate_S.Text = "";
                txtDate_E.Text = "";
                //客戶
                txtCustomer.Text = "";
                //線路
                txtLine.Text = "";
                //訂單
                txtOrder.Text = "";
                //報價單
                txtQuotation.Text = "";
                //交期
                txtDelivery.Text = "";
                //客號
                txtCustomerID.Text = "";
                //業務
                cboSales.Text = "";
                //第二層
                cboAp2.Text = "";

                //分類
                cboClass.Text = "";
                //參照法
                txtCZF.Text = "";


                //電源
                chkPower.Checked = false;
                //光纖
                chkFiber.Checked = false;
                //成朋
                chkGP.Checked = false;
                //晶元
                chkGC.Checked = false;
                //P/O
                txtPO.Text = "";

                if (dgvData.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)dgvData.DataSource;
                    dt.Rows.Clear();
                    dgvData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                //clsGlobal.ExportExcel("查詢訂單資料", dgvData);
                getEXCEL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex != dgvData.Rows.Count - 1)
                {
                    frmOrder.rstrOrderID = dgvData.Rows[e.RowIndex].Cells["訂單編號"].Value.ToString();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellDoubleClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getEXCEL()
        {
            //列印
            int ColIndex = 0;
            int RowIndex = 0;

            
            try
            {
                // 建立Excel物件
                Excel.Application excelApp = new Excel.ApplicationClass();
                //在建立excel workbook之前，檢查系統是否安裝excel
                if (excelApp == null)
                {
                    // if equal null means EXCEL is not installed.
                    MessageBox.Show("Excel is not properly installed!");
                    return;
                }
                // 建立Excel工作薄
                Excel.Workbook workBook = excelApp.Workbooks.Add(true);
                Excel.Worksheet workSheet = workBook.ActiveSheet as Excel.Worksheet;    //new a worksheet
                workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);   //獲得第i個sheet，準備寫入
                workSheet.Cells.NumberFormat = "@"; //還沒空清楚定義，但大概是遇到數字的，強迫以文字來儲存。
                //Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets[1];
                // 設定標題
                string strCaption= "訂單查看利潤";
                Excel.Range range = workSheet.get_Range(excelApp.Cells[1, 1], excelApp.Cells[1, 12]); //標題所佔的單元格數與DataGridView中的列數相同
                range.MergeCells = true;
                excelApp.ActiveCell.FormulaR1C1 = strCaption;
                excelApp.ActiveCell.Font.Size = 14;
                excelApp.ActiveCell.Font.Bold = true;
                excelApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;

                workSheet.Cells[3, 1] = "客戶";
                workSheet.Cells[3, 2] = "訂單編號";
                workSheet.Cells[3, 3] = "新建日期";
                workSheet.Cells[3, 4] = "產品編號";
                workSheet.Cells[3, 5] = "報價";
                workSheet.Cells[3, 6] = "成本";
                workSheet.Cells[3, 7] = "匯率";
                workSheet.Cells[3, 8] = "數量";
                workSheet.Cells[3, 9] = "盈虧";
                workSheet.Cells[3, 10] = "利潤%";
                workSheet.Cells[3, 11] = "幣種";
                workSheet.Cells[3, 12] = "業務";

                // 建立資料
                string strSQL = "";
                string strSQL11 = "";
                string strSQL12 = "";
                DataTable dt= new DataTable();

                strSQL11 = $@"select Round(( a.ord_pricost - a.ord_convprice ) * a.ord_qty - Isnull((
                                                    ( b.odc_qty -
                                                      b.odc_cszr ) * b.odc_convert ), 0), 0) '盈虧',
                                       case Isnull(a.ord_convprice * a.ord_qty, 0)
                                         when 0 then null
                                         else Round(( ( a.ord_pricost - a.ord_convprice ) * a.ord_qty - Isnull((
                                                                   ( b.odc_qty -
                                                                     b.odc_cszr ) * b.odc_convert ), 0) ) / (
                                                                 a.ord_convprice * a.ord_qty ) * 100, 1)
                                       end                                                   '利潤',
                                       *
                                from   (select *
                                        from   odh,
                                               ord,
                                               odi
                                        where  odh_orderid = ord_orderid
                                               and ord_assy = odi_customerid ";
                strSQL12 = $@") a left join odc b
                                        on b.odc_customerid = a.ord_assy order by odh_newdate desc, odh_customer, odh_orderid desc ";
                strSQL = strSQL11 + Get_strWhere() + strSQL12;
                 
                dt= clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0 )
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        workSheet.Cells[i + 4, 1] = dt.Rows[i]["odh_customer"].ToString();
                        workSheet.Cells[i + 4, 2] = dt.Rows[i]["odh_orderid"].ToString();
                        workSheet.Cells[i + 4, 3] = Convert.ToDateTime(dt.Rows[i]["odh_newdate"]).ToString("yyyy/MM/dd");
                        workSheet.Cells[i + 4, 4] = dt.Rows[i]["ord_assy"].ToString();
                        workSheet.Cells[i + 4, 5] = dt.Rows[i]["ord_pricost"].ToString();
                        workSheet.Cells[i + 4, 6] = dt.Rows[i]["ord_convprice"].ToString();
                        workSheet.Cells[i + 4, 7] = dt.Rows[i]["ord_convert"].ToString();
                        workSheet.Cells[i + 4, 8] = dt.Rows[i]["ord_qty"].ToString();
                        workSheet.Cells[i + 4, 9] = dt.Rows[i]["盈虧"].ToString();
                        workSheet.Cells[i + 4, 10] = dt.Rows[i]["利潤"].ToString();
                        workSheet.Cells[i + 4, 11] = dt.Rows[i]["ord_currency"].ToString();
                        workSheet.Cells[i + 4, 12] = dt.Rows[i]["ord_ywcode"].ToString();
                    }
                }
                workSheet.get_Range(excelApp.Cells[3, 1], excelApp.Cells[3 + dt.Rows.Count, 12]).Borders.LineStyle = Excel.XlLineStyle.xlContinuous; //外框
                workSheet.Columns.EntireColumn.AutoFit();   //自動調整欄寬

                workSheet.get_Range(excelApp.Cells[5 + dt.Rows.Count, 1], excelApp.Cells[5 + dt.Rows.Count, 12]).Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous; //外框
                workSheet.get_Range(excelApp.Cells[5 + dt.Rows.Count, 1], excelApp.Cells[5 + dt.Rows.Count, 12]).Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).Weight = Excel.XlBorderWeight.xlThin; //外框
                range = workSheet.get_Range(excelApp.Cells[5 + dt.Rows.Count, 1], excelApp.Cells[5 + dt.Rows.Count, 12]); 
                range.MergeCells = true;
                workSheet.Cells[6 + dt.Rows.Count, 7] = "TOTAL:";
                workSheet.Cells[6 + dt.Rows.Count, 9] =  dt.Compute("SUM(盈虧)", string.Empty);
                workSheet.Cells[8 + dt.Rows.Count, 7] = "半年獲利潤:";
                workSheet.Cells[8 + dt.Rows.Count, 9] = Convert.ToDouble(dt.Compute("SUM(盈虧)", string.Empty))/2;
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
                if (Convert.ToDouble(excelApp.Version.ToString()) > 11)
                {
                    temp = "C:\\temp\\" + strCaption + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                }
                else
                {
                    temp = "C:\\temp\\" + strCaption + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                }

                workBook.SaveCopyAs(temp);    //另存新檔
                                              //把執行的Excel資源釋放
                workBook.Close(false, Missing.Value, Missing.Value);
                excelApp.Quit();
                workSheet = null;
                workBook = null;
                excelApp = null;
                GC.Collect(); //強制回收
                System.Diagnostics.Process.Start(temp); //開啟檔案

                MessageBox.Show("查詢結果存放在:" + temp, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getEXCEL" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
