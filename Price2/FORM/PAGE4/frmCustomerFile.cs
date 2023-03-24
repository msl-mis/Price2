using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Price2
{
    public partial class frmCustomerFile : Form
    {
        
        public frmCustomerFile()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) //結束
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
            //搜尋
            try
            {
                GetInq();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetInq()
        {
            //搜尋
            try
            {
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                string strSQL = "";
                string strWhere = "";
                string strOrder = "";
                DataTable dt = new DataTable();
                strSQL = $@"delete na40 where na40_computername = host_name()";
                clsDB.Execute(strSQL);
                if(chkDeal.Checked)
                {
                    if(txtOrderNO.Text=="")
                    {
                        strSQL = $@"insert na40
                                           (na40_customerid,
                                            na40_mo,
                                            na40_length,
                                            na40_czf,
                                            na40_line,
                                            na40_price,
                                            na40_oldll,
                                            na40_ll,
                                            na40_computername,
                                            na40_customer,
                                            na40_activename,
                                            na40_newdate,
                                            na40_vendorid,
                                            na40_odiupdatedate,
                                            na40_autoflag,
                                            na40_convcost,
                                            na40_gb,
                                            na40_telgh,
                                            na40_hopelprice,
                                            na40_customerll,
                                            na40_fenlei,
                                            na40_currency,
                                            na40_totalqty)
                                    select distinct pri_customerid,
                                                    odi_mo,
                                                    pri_length,
                                                    odi_czf,
                                                    odi_line,
                                                    pri_pricost as odi_price,
                                                    odi_oldll,
                                                    pri_ll,
                                                    Host_name(),
                                                    odi_customer,
                                                    case odi_active
                                                      when 1 then '無效'
                                                      else ''
                                                    end,
                                                    ord_newdate,
                                                    pri_vendorid,
                                                    pri_date,
                                                    '⊕',
                                                    pri_convcost,
                                                    cus_gb,
                                                    cus_telgh,
                                                    pri_hopelprice,
                                                    pri_customerll,
                                                    pri_fenlei,
                                                    pri_currency,
                                                    0
                                    from   odi,
                                           pri,
                                           ord_newdate,
                                           cus
                                    where  odi_customerid = ord_assy
                                           and odi_customer = cus_id ";
                        strSQL = strSQL + Get_strWhere();
                        clsDB.Execute(strSQL);
                    }
                    else
                    {
                        strSQL = $@"insert na40
                                           (na40_customerid,
                                            na40_mo,
                                            na40_length,
                                            na40_czf,
                                            na40_line,
                                            na40_price,
                                            na40_oldll,
                                            na40_ll,
                                            na40_computername,
                                            na40_customer,
                                            na40_activename,
                                            na40_newdate,
                                            na40_vendorid,
                                            na40_odiupdatedate,
                                            na40_autoflag,
                                            na40_convcost,
                                            na40_gb,
                                            na40_telgh,
                                            na40_qty,
                                            na40_hopelprice,
                                            na40_customerll,
                                            na40_fenlei,
                                            na40_currency,
                                            na40_totalqty)
                                    select distinct pri_customerid,
                                                    odi_mo,
                                                    pri_length,
                                                    odi_czf,
                                                    odi_line,
                                                    pri_pricost as odi_price,
                                                    odi_oldll,
                                                    pri_ll,
                                                    Host_name(),
                                                    odi_customer,
                                                    case odi_active
                                                      when 1 then '無效'
                                                      else ''
                                                    end,
                                                    ord_newdate,
                                                    pri_vendorid,
                                                    pri_date,
                                                    '⊕',
                                                    pri_convcost,
                                                    cus_gb,
                                                    cus_telgh,
                                                    ord_qty,
                                                    pri_hopelprice,
                                                    pri_customerll,
                                                    pri_fenlei,
                                                    pri_currency,
                                                    0
                                    from   odi,
                                           pri,
                                           ord_newdate,
                                           cus,
                                           ord
                                    where  odi_customerid = ord.ord_assy
                                           and odi_customerid = ord_newdate.ord_assy
                                           and odi_customer = cus_id ";
                        strSQL = strSQL + Get_strWhere();
                        clsDB.Execute(strSQL);

                        strSQL = $@"update na40
                                    set    na40_ll = Round(case Isnull(ord_convprice * ord_qty, 0)
                                                             when 0 then 0
                                                             else ( Isnull(( ord_pricost - ord_convprice ) * ord_qty, 0) )/( Isnull(ord_convprice * ord_qty, 0) ) * 100
                                                           end, 1)
                                    from   na40,
                                           ord
                                    where  na40_customerid = ord_assy
                                           and na40_computername = Host_name()
                                           and ord_pricost <> 0
                                           and ord_convprice <> 0
                                           and ord_orderid = '{txtOrderNO.Text.Trim()}' ";
                        strSQL = strSQL + Get_strWhere();
                        clsDB.Execute(strSQL);

                        strSQL = $@"update na40
                                    set    na40_price = ord_price,
                                           na40_qty = ord_qty
                                    from   na40,
                                           ord
                                    where  na40_computername = Host_name()
                                           and na40_customerid = ord_assy
                                           and ord_orderid = '{txtOrderNO.Text.Trim()}'";
                    clsDB.Execute(strSQL);
                    }
                    strSQL = $@"update na40
                                set    na40_totalqty=b.ordqty
                                from   na40 a,
                                       (select ord_assy,
                                               Sum(ord_qty) as ordqty
                                        from   ord, odh
                                        where  ord_orderid=odh_orderid " + 
                                        (txtCustomer.Text == ""? "" : $@"and odh_customer like '{txtCustomer.Text.Trim()}%' ") +
                                        (txtID.Text == "" ? "" : $@"and ord_assy  like '{txtID.Text.Trim()}%' ") +
                                        (txtOrderDate_S.Text == "" ? "" : $@"and odh_newdate between '{txtOrderDate_S.Text}' and '{txtOrderDate_E.Text}' ") +
                                        "group by ord_assy) as b where a.na40_computername = host_name() and a.na40_customerid <> '' and a.na40_customerid = b.ord_assy ";
                    clsDB.Execute(strSQL);
                    
                }
                else
                {
                    if (txtOrderNO.Text == "")
                    {
                        strSQL = $@"insert na40
                                           (na40_customerid,
                                            na40_mo,
                                            na40_length,
                                            na40_czf,
                                            na40_line,
                                            na40_price,
                                            na40_oldll,
                                            na40_ll,
                                            na40_computername,
                                            na40_customer,
                                            na40_activename,
                                            na40_vendorid,
                                            na40_odiupdatedate,
                                            na40_autoflag,
                                            na40_convcost,
                                            na40_gb,
                                            na40_telgh,
                                            na40_hopelprice,
                                            na40_customerll,
                                            na40_fenlei,
                                            na40_currency)
                                    select distinct pri_customerid,
                                                    odi_mo,
                                                    pri_length,
                                                    odi_czf,
                                                    odi_line,
                                                    pri_pricost as odi_price,
                                                    odi_oldll,
                                                    pri_ll,
                                                    Host_name(),
                                                    odi_customer,
                                                    case odi_active
                                                      when 1 then '無效'
                                                      else ''
                                                    end,
                                                    pri_vendorid,
                                                    pri_date,
                                                    '⊕',
                                                    pri_convcost,
                                                    cus_gb,
                                                    cus_telgh,
                                                    pri_hopelprice,
                                                    pri_customerll,
                                                    pri_fenlei,
                                                    pri_currency
                                    from   odi,
                                           pri,
                                           cus
                                    where  odi_customer = cus_id ";
                        strSQL = strSQL + Get_strWhere();
                        clsDB.Execute(strSQL);
                    }
                    else
                    {
                        strSQL = $@"insert na40
                                           (na40_customerid,
                                            na40_mo,
                                            na40_length,
                                            na40_czf,
                                            na40_line,
                                            na40_price,
                                            na40_oldll,
                                            na40_ll,
                                            na40_computername,
                                            na40_customer,
                                            na40_activename,
                                            na40_vendorid,
                                            na40_odiupdatedate,
                                            na40_autoflag,
                                            na40_convcost,
                                            na40_gb,
                                            na40_telgh,
                                            na40_qty,
                                            na40_hopelprice,
                                            na40_customerll,
                                            na40_fenlei,
                                            na40_currency)
                                    select distinct pri_customerid,
                                                    odi_mo,
                                                    pri_length,
                                                    odi_czf,
                                                    odi_line,
                                                    pri_pricost as odi_price,
                                                    odi_oldll,
                                                    pri_ll,
                                                    Host_name(),
                                                    odi_customer,
                                                    case odi_active
                                                      when 1 then '無效'
                                                      else ''
                                                    end,
                                                    pri_vendorid,
                                                    pri_date,
                                                    '⊕',
                                                    pri_convcost,
                                                    cus_gb,
                                                    cus_telgh,
                                                    ord_qty,
                                                    pri_hopelprice,
                                                    pri_customerll,
                                                    pri_fenlei,
                                                    pri_currency
                                    from   odi,
                                           pri,
                                           cus,
                                           ord
                                    where  odi_customerid = ord_assy
                                           and odi_customer = cus_id ";
                        strSQL = strSQL + Get_strWhere();
                        clsDB.Execute(strSQL);

                        strSQL = $@"update na40
                                    set    na40_ll = Round(case Isnull(ord_convprice * ord_qty, 0)
                                                             when 0 then 0
                                                             else ( Isnull(( ord_pricost - ord_convprice ) * ord_qty, 0) )/( Isnull(ord_convprice * ord_qty, 0) ) * 100
                                                           end, 1)
                                    from   na40,
                                           ord
                                    where  na40_customerid = ord_assy
                                           and na40_computername = Host_name()
                                           and ord_pricost <> 0
                                           and ord_convprice <> 0
                                           and ord_orderid = '{txtOrderNO.Text.Trim()}' ";
                        clsDB.Execute(strSQL);

                        strSQL = $@"update na40
                                    set    na40_convcost = Round(ord_convprice / ord_convert, 3)
                                    from   na40,
                                           ord
                                    where  na40_customerid = ord_assy
                                           and ord_convprice <> 0
                                           and ord_convert <> 0
                                           and na40_computername = Host_name()
                                           and ord_orderid = '{txtOrderNO.Text.Trim()}' ";
                        clsDB.Execute(strSQL);

                        strSQL = $@"update na40
                                    set    na40_price = ord_price,
                                           na40_qty = ord_qty
                                    from   na40,
                                           ord
                                    where  na40_computername = Host_name()
                                           and na40_customerid = ord_assy
                                           and ord_orderid = '{txtOrderNO.Text.Trim()}' ";
                        clsDB.Execute(strSQL);

                        strSQL = $@"update na40
                                set    na40_price = 0,
                                       na40_oldll = 0,
                                       na40_ll = 0
                                from   na40,
                                       odh,
                                       ord
                                where  odh_orderid = ord_orderid
                                       and odh_bh = 1
                                       and na40_customerid = ord_assy
                                       and na40_computername = Host_name()
                                       and odh_orderid = '{txtOrderNO.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                    }

                    strSQL = $@"update na40
                                set    na40_newdate = ord_newdate
                                from   na40,
                                       ord_newdate
                                where  na40_customerid = ord_assy
                                       and na40_computername = Host_name() ";
                    clsDB.Execute(strSQL);

                }



                strSQL = $@"select distinct na40_customer,
                                                na40_autoflag,
                                                na40_fenlei,
                                                na40_customerid,
                                                na40_activename,
                                                na40_mo,
                                                na40_length,
                                                na40_czf,
                                                na40_line,
                                                na40_vendorid,
                                                na40_currency,
                                                na40_price,
                                                na40_oldll,
                                                na40_ll,
                                                na40_convcost,
                                                na40_qty,
                                                na40_hopelprice,
                                                na40_customerll,
                                                na40_newdate,
                                                na40_odiupdatedate,
                                                na40_totalqty,
                                                na40_nbr
                                from   na40
                                where  na40_computername = Host_name() ";
                dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;

                lblCount.Text = "總記錄數："+dt.Rows.Count.ToString();
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Get_strWhere()
        {
            if(txtLL.Text=="")
            {
                txtLL.Text = "0";
            }
            string strWhere = "and pri_newcostchk like 'N%' and odi_customerid = pri_customerid ";
            //客戶
            strWhere = strWhere + (txtCustomer.Text == "" ? "" : (txtCustomer.Text == "4-" ? "and odi_customer like '%4-%' " : (txtCustomer.Text == "4" ? "and (odi_customer ='4' or substring(odi_customer,1,2)='4-') " : $@"and odi_customer='{txtCustomer.Text.Trim()}' ")));
            //成交
            strWhere = strWhere + (chkDeal.Checked ? "and odi_customerid in (select distinct ord_assy from ord) " : "");
            //未成交
            strWhere = strWhere + (chkDeal_Yet.Checked ? "and odi_customerid not in (select distinct ord_assy from ord) " : "");
            //線路
            strWhere = strWhere + (txtLine.Text== "" ? "" : $@"and odi_line like '%{txtLine.Text.Trim()}%' ");
            //外購
            strWhere = strWhere + (chkOutsourcing.Checked ? "and odi_wg = 1 " : "");
            //電源
            strWhere = strWhere + (chkPower.Checked ? "and odi_wg = 2 " : "");
            //負利潤
            strWhere = strWhere + (chkDeficit.Checked ? "and pri_ll < 0 " : "");
            //客號
            if (txtID.Text.IndexOf(";") >= 0)//分號多條件搜尋
            {
                string[] str = txtID.Text.Split(';');
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Trim();
                    strWhere = strWhere + $@"and odi_customerid like '%{str[i].Trim()}%' ";
                }
            }
            else
            {
                strWhere = strWhere + (txtID.Text == "" ? "" : $@"and odi_customerid like '%{txtID.Text.Trim()}%' ");
            }
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
            //利潤
            strWhere = strWhere + (txtLL.Text == "" || txtLL.Text == "0" ? "" : $@"and pri_ll<= '{txtLL.Text.Trim()}' ");
            //廠商
            strWhere = strWhere + (txtVendor.Text == "" ? "" : $@"and pri_vendorid = '{txtVendor.Text.Trim()}' ");
            //最後儲存日期
            strWhere = strWhere + (txtNewDate_S.Text == "" ? "" : $@"and pri_date between '{txtNewDate_S.Text}' and '{txtNewDate_E.Text}' ");
            //報價單號
            strWhere = strWhere + (txtPriceNO.Text == "" ? "" : $@"and odi_customerid in (select distinct prd_assy from prd where prd_orderid = '{txtPriceNO.Text.Trim()}') ");
            //舊利潤比較
            strWhere = strWhere + (cboCompare.Text == "(ALL)" ? "" : (cboCompare.Text == "大於" ? $@"and odi_oldll > pri_ll + {txtOldLL} " : $@"and pri_ll - odi_oldll > {txtOldLL} "));
            //線長
            strWhere = strWhere + (txtLength.Text == "" ? "" : $@"and pri_length = '{txtLength.Text.Trim()}' ");
            //國別
            strWhere = strWhere + (cboCountry.Text == "(ALL)" ? "" : $@"and cus_gb = '{cboCountry.Text.Trim()}') ");
            //客號備註
            strWhere = strWhere + (txtNote.Text == "" ? "" : $@"and pri_bz like '%{txtNote.Text.Trim()}%' ");
            //分類
            strWhere = strWhere + (cboClass.Text == "(ALL)" ? "" : $@"and pri_fenlei = '{cboClass.Text.Trim()}' ");

            if(chkDeal.Checked)
            {
                //最後成交日期
                strWhere = strWhere + (txtDealDate_S.Text == "" ? "" : $@"and ord_newdate between '{txtDealDate_S.Text}' and '{txtDealDate_E.Text}' ");
            }
            //訂單日期
            strWhere = strWhere + (txtOrderDate_S.Text == "" ? "" : $@"and odi_customerid in(select distinct ord_assy from odh, ord where odh_orderid = ord_orderid and odh_newdate between '{txtOrderDate_S.Text}' and '{txtOrderDate_E.Text}') ");
            //光纖
            strWhere = strWhere + (chkFiber.Checked ? "and pri_fenlei = '14 Fiber Cable' " : "");
            //排序
            if(txtOrderNO.Text=="")
            {
                strWhere = strWhere + $@"order by odi_line, pri_convcost ";
            }
            else
            {
                strWhere = strWhere + $@"and ord_orderid = '{txtOrderNO.Text.Trim()}' order by odi_line, pri_convcost ";
            }
            

            return strWhere;
        }

        private void btnClear_Click(object sender, EventArgs e) //清除
        {
            //清除
            try
            {
                chkDeal.Checked = false;
                chkDeal_Yet.Checked = false;
                chkDeficit.Checked = false;
                chkFiber.Checked = false;
                chkOutsourcing.Checked = false;
                chkPower.Checked = false;

                txtID.Text = "";
                txtLine.Text = "";
                txtLength.Text = "";
                txtCustomer.Text = "";
                txtCZF.Text = "";
                txtVendor.Text = "";
                txtOrderDate_S.Text = "";
                txtPriceNO.Text = "";
                txtNote.Text = "";
                txtNewDate_S.Text = "";
                txtNewDate_E.Text = "";
                txtOrderDate_S.Text = "";
                txtOrderDate_E.Text = "";
                txtDealDate_S.Text = "";
                txtDealDate_E.Text = "";

                txtLL.Text = "0";
                txtOldLL.Text = "0";
                txtSpecify.Text = "0";
                txtDigit.Text = "2";

                cboClass.Text = "(ALL)";
                cboCompare.Text = "(ALL)";
                cboCountry.Text = "(ALL)";

                cboAdjustment.Text = "調漲";
                cboCountry.Text = "(ALL)";

                lblCount.Text = "總記錄數：";

                radioAdjustment.Checked = true;

                //清除dgvData
                if (dgvData.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvData.DataSource;
                    dt.Rows.Clear();
                    dgvData.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e) //列印
        {
            //列印
            try
            {
                //clsGlobal clsGlobal = new clsGlobal();
                clsGlobal.ExportExcel("客人總檔清單", dgvData);
                //clsGlobal.ExportCsv( dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExec_Click(object sender, EventArgs e)  //執行
        {
            //執行
            try
            {
                if(dgvData.Rows.Count == 0)
                {
                    return;
                }
                string strSQL = "";
                //確認權限
                if (clsGlobal.checkRightFlag("執行調整利潤") == false)
                {
                    MessageBox.Show("你沒有執行調整利潤權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                if(radioSpecify.Checked == true)    //指定利潤
                {
                    if (MessageBox.Show("選取項目⊕, 將自動依 " + txtSpecify.Text + "% 計算新單價 ?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        strSQL = $@"update pri
                                    set    pri_pricost = Round(pri_convcost * ( 1 + {txtSpecify.Text} / 100.0 ), {txtDigit.Text}),
                                           pri_username = '{clsGlobal.strG_User}'
                                    from   pri,
                                           odi
                                    where  pri_customerid = odi_customerid
                                           and pri_customerid <> ''
                                           and pri_customerid in (select distinct na40_customerid
                                                                  from   na40
                                                                  where  na40_computername = Host_name()
                                                                         and na40_customerid <> ''
                                                                         and na40_autoflag <> '') ";
                        clsDB.Execute(strSQL);
                        
                        strSQL = $@"update odi
                                    set    odi_price = Round(pri_convcost * ( 1 + {txtSpecify.Text} / 100.0 ), {txtDigit.Text})
                                    from   pri,
                                           odi
                                    where  pri_customerid = odi_customerid
                                           and pri_customerid <> ''
                                           and pri_customerid in (select distinct na40_customerid
                                                                  from   na40
                                                                  where  na40_computername = Host_name()
                                                                         and na40_customerid <> ''
                                                                         and na40_autoflag <> '') ";
                        clsDB.Execute(strSQL);
                        
                        strSQL = $@"update pri
                                    set    pri_oldll = pri_ll,
                                           pri_pricost_cal = '',
                                           pri_date = Getdate('yyyy/MM/dd'),
                                           pri_adddate = Getdate('yyyy/MM/dd'),
                                           pri_ll = Round(( pri_pricost - pri_convcost ) / pri_convcost * 100, 3),
                                           pri_username = '{clsGlobal.strG_User}'
                                    from   pri,
                                           odi
                                    where  pri_customerid = odi_customerid
                                           and pri_customerid <> ''
                                           and pri_customerid in (select distinct na40_customerid
                                                                  from   na40
                                                                  where  na40_computername = Host_name()
                                                                         and na40_customerid <> ''
                                                                         and na40_autoflag <> '') ";
                        clsDB.Execute(strSQL);

                        strSQL = $@"delete na51 where na51_computername = host_name()";
                        clsDB.Execute(strSQL);
                        
                        strSQL = $@"insert na51 (na51_customerid,na51_computername) select na40_customerid,host_name() from na40maxview";
                        clsDB.Execute(strSQL);
                        
                        strSQL = $@"delete prb
                                    from   prb,
                                           na51
                                    where  prb_customerid = na51_customerid
                                           and na51_computername = Host_name()
                                           and prb_date = Getdate('yyyy/MM/dd') ";
                        clsDB.Execute(strSQL);

                        strSQL = $@"insert prb
                                           (prb_customer,
                                            prb_date,
                                            prb_ll,
                                            prb_pricost,
                                            prb_hopelprice,
                                            prb_customerid,
                                            prb_length,
                                            prb_wg,
                                            prb_username,
                                            prb_newcostchk)
                                    select distinct pri_customer,
                                                    Getdate('yyyy/MM/dd'),
                                                    pri_ll,
                                                    pri_pricost,
                                                    pri_hopelprice,
                                                    pri_customerid,
                                                    pri_length,
                                                    pri_wg,
                                                    pri_username,
                                                    pri_newcostchk
                                    from   pri,
                                           na51
                                    where  pri_customerid <> ''
                                           and pri_customerid = na51_customerid ";
                        clsDB.Execute(strSQL);

                        strSQL = $@"update odi
                                    set    odi_oldll = pri_ll
                                    from   pri,
                                           odi
                                    where  pri_customerid = odi_customerid
                                           and pri_customerid <> ''
                                           and pri_customerid in (select distinct na40_customerid
                                                                  from   na40
                                                                  where  na40_computername = Host_name()
                                                                         and na40_customerid <> ''
                                                                         and na40_autoflag <> '') ";
                        clsDB.Execute(strSQL);

                        strSQL = $@"update prb
                                    set    prb_date = Getdate('yyyy/MM/dd'),
                                           prb_ll = pri_ll,
                                           prb_newcostchk = pri_newcostchk
                                    from   prb,
                                           prbmaxdate,
                                           na40,
                                           pri
                                    where  prb.prb_customerid = pri.pri_customerid
                                           and prb.prb_customerid = prbmaxdate.prb_customerid
                                           and prb.prb_date = prbmaxdate.prb_date
                                           and prbmaxdate.prb_customerid = na40_customerid
                                           and na40_computername = Host_name() ";
                        clsDB.Execute(strSQL);
                        MessageBox.Show("已經計算完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetInq();
                        return;
                    }
                }
                if(radioAdjustment.Checked) //調漲調降
                {
                    if(cboAdjustment.Text == "調漲")
                    {
                        if (MessageBox.Show("選取項目⊕將自動依舊利潤漲價,是否確認執行自動計算新報價?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            strSQL = $@"update pri
                                        set    pri_pricost = Round(pri_convcost * ( 1 + odi_oldll / 100.0 ), {txtDigit.Text}),
                                               pri_pricost_cal = '',
                                               pri_username = '{clsGlobal.strG_User}'
                                        from   pri,
                                               odi
                                        where  pri_customerid = odi_customerid
                                               and pri_customerid <> ''
                                               and odi_oldll > pri_ll
                                               and pri_customerid in (select distinct na40_customerid
                                                                      from   na40
                                                                      where  na40_computername = Host_name()
                                                                             and na40_customerid <> ''
                                                                             and na40_autoflag <> '') ";
                            clsDB.Execute(strSQL);

                            strSQL = $@"update odi
                                        set    odi_price = Round(pri_convcost * ( 1 + odi_oldll / 100.0 ), {txtDigit.Text})
                                        from   pri,
                                               odi
                                        where  pri_customerid = odi_customerid
                                               and pri_customerid <> ''
                                               and odi_oldll > pri_ll
                                               and pri_customerid in (select distinct na40_customerid
                                                                      from   na40
                                                                      where  na40_computername = Host_name()
                                                                             and na40_customerid <> ''
                                                                             and na40_autoflag <> '') ";
                            clsDB.Execute(strSQL);

                            strSQL = $@"update pri
                                        set    pri_date = Getdate('yyyy/MM/dd'),
                                               pri_adddate = Getdate('yyyy/MM/dd'),
                                               pri_ll = Round(( pri_pricost - pri_convcost ) / pri_convcost * 100, 3),
                                               pri_username = '{clsGlobal.strG_User}'
                                        from   pri,
                                               odi
                                        where  pri_customerid = odi_customerid
                                               and pri_customerid <> ''
                                               and odi_oldll > pri_ll
                                               and pri_customerid in (select distinct na40_customerid
                                                                      from   na40
                                                                      where  na40_computername = Host_name()
                                                                             and na40_customerid <> ''
                                                                             and na40_autoflag <> '') ";
                            clsDB.Execute(strSQL);

                            strSQL = $@"delete na51 where na51_computername = host_name()";
                            clsDB.Execute(strSQL);

                            strSQL = $@"insert na51 (na51_customerid,na51_computername) select na40_customerid,host_name() from na40maxview";
                            clsDB.Execute(strSQL);

                            strSQL = $@"delete prb
                                    from   prb,
                                           na51
                                    where  prb_customerid = na51_customerid
                                           and na51_computername = Host_name()
                                           and prb_date = Getdate('yyyy/MM/dd') ";
                            clsDB.Execute(strSQL);

                            strSQL = $@"insert prb
                                           (prb_customer,
                                            prb_date,
                                            prb_ll,
                                            prb_pricost,
                                            prb_hopelprice,
                                            prb_customerid,
                                            prb_length,
                                            prb_wg,
                                            prb_username,
                                            prb_newcostchk)
                                    select distinct pri_customer,
                                                    Getdate('yyyy/MM/dd'),
                                                    pri_ll,
                                                    pri_pricost,
                                                    pri_hopelprice,
                                                    pri_customerid,
                                                    pri_length,
                                                    pri_wg,
                                                    pri_username,
                                                    pri_newcostchk
                                    from   pri,
                                           na51
                                    where  pri_customerid <> ''
                                           and pri_customerid = na51_customerid ";
                            clsDB.Execute(strSQL);

                            strSQL = $@"update prb
                                    set    prb_date = Getdate('yyyy/MM/dd'),
                                           prb_ll = pri_ll,
                                           prb_newcostchk = pri_newcostchk
                                    from   prb,
                                           prbmaxdate,
                                           na40,
                                           pri
                                    where  prb.prb_customerid = pri.pri_customerid
                                           and prb.prb_customerid = prbmaxdate.prb_customerid
                                           and prb.prb_date = prbmaxdate.prb_date
                                           and prbmaxdate.prb_customerid = na40_customerid
                                           and na40_computername = Host_name() ";
                            clsDB.Execute(strSQL);

                            MessageBox.Show("已經計算完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetInq();
                            return;
                        }
                    }
                    if (cboAdjustment.Text == "調降")
                    {
                        if (MessageBox.Show("選取項目⊕將自動依舊利潤降價,是否確認執行自動計算新報價?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            strSQL = $@"update pri
                                        set    pri_pricost = Round(pri_convcost * ( 1 + odi_oldll / 100.0 ), {txtDigit.Text}),
                                               pri_pricost_cal = '',
                                               pri_username = '{clsGlobal.strG_User}'
                                        from   pri,
                                               odi
                                        where  pri_customerid = odi_customerid
                                               and pri_customerid <> ''
                                               and odi_oldll < pri_ll
                                               and pri_customerid in (select distinct na40_customerid
                                                                      from   na40
                                                                      where  na40_computername = Host_name()
                                                                             and na40_customerid <> ''
                                                                             and na40_autoflag <> '') ";
                            clsDB.Execute(strSQL);

                            strSQL = $@"update odi
                                        set    odi_price = Round(pri_convcost * ( 1 + odi_oldll / 100.0 ), {txtDigit.Text})
                                        from   pri,
                                                odi
                                        where  pri_customerid = odi_customerid
                                                and pri_customerid <> ''
                                                and odi_oldll < pri_ll
                                                and pri_customerid in (select distinct na40_customerid
                                                                        from   na40
                                                                        where  na40_computername = Host_name()
                                                                                and na40_customerid <> ''
                                                                                and na40_autoflag <> '') ";
                            clsDB.Execute(strSQL);

                            strSQL = $@"update pri
                                        set    pri_date = Getdate('yyyy/MM/dd'),
                                               pri_adddate = Getdate('yyyy/MM/dd'),
                                               pri_ll = Round(( pri_pricost - pri_convcost ) / pri_convcost * 100, 3),
                                               pri_username = '{clsGlobal.strG_User}'
                                        from   pri,
                                               odi
                                        where  pri_customerid = odi_customerid
                                               and pri_customerid <> ''
                                               and odi_oldll < pri_ll
                                               and pri_customerid in (select distinct na40_customerid
                                                                      from   na40
                                                                      where  na40_computername = Host_name()
                                                                             and na40_customerid <> ''
                                                                             and na40_autoflag <> '') ";
                            clsDB.Execute(strSQL);

                            strSQL = $@"delete na51 where na51_computername = host_name()";
                            clsDB.Execute(strSQL);

                            strSQL = $@"insert na51 (na51_customerid,na51_computername) select na40_customerid,host_name() from na40maxview";
                            clsDB.Execute(strSQL);

                            strSQL = $@"delete prb
                                    from   prb,
                                           na51
                                    where  prb_customerid = na51_customerid
                                           and na51_computername = Host_name()
                                           and prb_date = Getdate('yyyy/MM/dd') ";
                            clsDB.Execute(strSQL);

                            strSQL = $@"insert prb
                                           (prb_customer,
                                            prb_date,
                                            prb_ll,
                                            prb_pricost,
                                            prb_hopelprice,
                                            prb_customerid,
                                            prb_length,
                                            prb_wg,
                                            prb_username,
                                            prb_newcostchk)
                                    select distinct pri_customer,
                                                    Getdate('yyyy/MM/dd'),
                                                    pri_ll,
                                                    pri_pricost,
                                                    pri_hopelprice,
                                                    pri_customerid,
                                                    pri_length,
                                                    pri_wg,
                                                    pri_username,
                                                    pri_newcostchk
                                    from   pri,
                                           na51
                                    where  pri_customerid <> ''
                                           and pri_customerid = na51_customerid ";
                            clsDB.Execute(strSQL);

                            strSQL = $@"update prb
                                    set    prb_date = Getdate('yyyy/MM/dd'),
                                           prb_ll = pri_ll,
                                           prb_newcostchk = pri_newcostchk
                                    from   prb,
                                           prbmaxdate,
                                           na40,
                                           pri
                                    where  prb.prb_customerid = pri.pri_customerid
                                           and prb.prb_customerid = prbmaxdate.prb_customerid
                                           and prb.prb_date = prbmaxdate.prb_date
                                           and prbmaxdate.prb_customerid = na40_customerid
                                           and na40_computername = Host_name() ";
                            clsDB.Execute(strSQL);

                            MessageBox.Show("已經計算完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetInq();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnExec_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDealDate_S_Enter(object sender, EventArgs e)
        {
            if(txtDealDate_S.Text=="")
            {
                txtDealDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtDealDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
                chkDeal.Checked = true;
            }
        }

        private void txtDealDate_E_Enter(object sender, EventArgs e)
        {
            if (txtDealDate_E.Text == "")
            {
                txtDealDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtDealDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
                chkDeal.Checked = true;
            }
        }

        private void txtNewDate_S_Enter(object sender, EventArgs e)
        {
            if (txtNewDate_S.Text == "")
            {
                txtNewDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtNewDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtNewDate_E_Enter(object sender, EventArgs e)
        {
            if (txtNewDate_E.Text == "")
            {
                txtNewDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtNewDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtOrderDate_S_Enter(object sender, EventArgs e)
        {
            if (txtOrderDate_S.Text == "")
            {
                txtOrderDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtOrderDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtOrderDate_E_Enter(object sender, EventArgs e)
        {
            if (txtOrderDate_E.Text == "")
            {
                txtOrderDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtOrderDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }
    }
}
