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
using System.Xml;

namespace Price2
{
    public partial class frmCopper_Price_Calculate : Form
    {
        string strQuery = "";
        public frmCopper_Price_Calculate()
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

        private void btnInq_Click(object sender, EventArgs e)
        {
            //查詢
            try
            {
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()
        {
            try
            {
                if (txtDate_E.Text != "" && txtDate_S.Text != "")
                {
                    if (Convert.ToDateTime(txtDate_S.Text) > Convert.ToDateTime(txtDate_E.Text))
                    {
                        MessageBox.Show("起始日期不可以大於結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                strSQL = $@"delete simulate_copper where HOST_NAME=host_name() ";
                clsDB.Execute(strSQL);
                if(chkDeal.Checked )
                {
                    strSQL = $@"insert simulate_copper
                                       (pri_customerid,
                                        odi_mo,
                                        pri_length,
                                        odi_czf,
                                        odi_line,
                                        quote,
                                        odi_oldll,
                                        pri_ll,
                                        host_name,
                                        odi_customer,
                                        odi_active,
                                        ord_newdate,
                                        pri_vendorid,
                                        pri_date,
                                        pri_autoflag,
                                        pri_convcost,
                                        cus_gb,
                                        cus_telgh,
                                        pri_hopelprice,
                                        pri_customerll,
                                        pri_fenlei,
                                        pri_currency,
                                        totalqty)
                                select distinct pri_customerid,
                                                odi_mo,
                                                pri_length,
                                                odi_czf,
                                                odi_line,
                                                case cus_gb
                                                  when 'TAIWAN' then odi_pricost
                                                  else odi_price
                                                end quote,
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
                                       and odi_customer = cus_id 
                                       and  pri_newcostchk like 'N%' 
                                       and odi_customerid=pri_customerid ";
                    strSQL = strSQL + Get_strWhere() + "order by pri_customerid ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update simulate_copper
                                set    totalqty=b.ordqty
                                from   simulate_copper a,
                                       (
                                                select   ord_assy,
                                                         Sum(ord_qty) as ordqty
                                                from     ord,
                                                         odh
                                                where    ord_orderid=odh_orderid "+
                                                        (txtCustomer.Text == "" ? "" : $@"and odh_customer like '{txtCustomer.Text.Trim()}%' ")+
                                                        (txtCustomerID.Text == "" ? "" : $@"and ord_assy like '%{txtCustomerID.Text.Trim()}%' ")+
                                                $@"group by ord_assy) as b
                                where  a.host_name=host_name()
                                and    a.pri_customerid<>''
                                and    a.pri_customerid=b.ord_assy ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"select distinct odi_customer,
                                            pri_autoflag,
                                            pri_fenlei,
                                            pri_customerid,
                                            pri_length,
                                            odi_czf,
                                            odi_line,
                                            pri_currency,
                                            quote,
                                            odi_oldll,
                                            pri_ll,
                                            pri_convcost,
                                            pri_ll2,
                                            pri_convcost2,
                                            pri_ll3,
                                            pri_convcost3
                            from   simulate_copper
                            where  host_name = Host_name() ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        lblCount.Text = "資料筆數：" + dt.Rows.Count.ToString();
                        dgvData.DataSource = dt;
                    }
                    else
                    {
                        lblCount.Text = "資料筆數：0";

                        dgvData.DataSource = dt;
                    }
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
                else
                {
                    strSQL = $@"insert simulate_copper
                                   (pri_customerid,
                                    odi_mo,
                                    pri_length,
                                    odi_czf,
                                    odi_line,
                                    quote,
                                    odi_oldll,
                                    pri_ll,
                                    host_name,
                                    odi_customer,
                                    odi_active,
                                    pri_vendorid,
                                    pri_date,
                                    pri_autoflag,
                                    pri_convcost,
                                    cus_gb,
                                    cus_telgh,
                                    pri_hopelprice,
                                    pri_customerll,
                                    pri_fenlei,
                                    pri_currency)
                            select distinct pri_customerid,
                                            odi_mo,
                                            pri_length,
                                            odi_czf,
                                            odi_line,
                                            case cus_gb
                                              when 'TAIWAN' then odi_pricost
                                              else odi_price
                                            end quote,
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
                            where  odi_customer = cus_id 
                                   and  pri_newcostchk like 'N%' 
                                   and odi_customerid=pri_customerid ";
                    strSQL = strSQL + Get_strWhere() + "order by pri_customerid ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update simulate_copper
                            set    ord_newdate = v.ord_newdate
                            from   simulate_copper,
                                   ord_newdate v
                            where  pri_customerid = ord_assy
                                   and host_name = Host_name() ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"select distinct odi_customer,
                                            pri_autoflag,
                                            pri_fenlei,
                                            pri_customerid,
                                            pri_length,
                                            odi_czf,
                                            odi_line,
                                            pri_currency,
                                            quote,
                                            odi_oldll,
                                            pri_ll,
                                            pri_convcost,
                                            pri_ll2,
                                            pri_convcost2,
                                            pri_ll3,
                                            pri_convcost3
                            from   simulate_copper
                            where  host_name = Host_name() ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        lblCount.Text = "資料筆數：" + dt.Rows.Count.ToString();
                        dgvData.DataSource = dt;
                    }
                    else
                    {
                        lblCount.Text = "資料筆數：0";

                        dgvData.DataSource = dt;
                    }
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
                strQuery = $@"select distinct pri_customerid,
                                                odi_mo,
                                                pri_length,
                                                odi_czf,
                                                odi_line,
                                                case cus_gb
                                                                when 'TAIWAN' then odi_pricost
                                                                else odi_price
                                                end quote,
                                                odi_oldll,
                                                pri_ll,
                                                Host_name() host_name,
                                                odi_customer,
                                                case odi_active
                                                                when 1 then '無效'
                                                                else ''
                                                end odi_active,
                                                pri_vendorid,
                                                pri_date,
                                                '⊕' pri_autoflag,
                                                pri_convcost,
                                                cus_gb,
                                                cus_telgh,
                                                pri_hopelprice,
                                                pri_customerll,
                                                pri_fenlei,
                                                pri_currency,
                                                pri_newcostchk,
                                                0,
                                                0,
                                                0,
                                                0
                                from            odi,
                                                pri,
                                                cus
                                where           odi_customer=cus_id 
                                                and pri_newcostchk like 'N%'
                                                and odi_customerid = pri_customerid ";
                strQuery = strQuery + Get_strWhere();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Get_strWhere()
        {
            string strWhere = "";
            //客戶
            strWhere = (txtCustomer.Text=="" ? "" : (txtCustomer.Text == "4-" ? "and odi_customer like '%4-%' " : (txtCustomer.Text == "4" ? "and (odi_customer='4' or substring(odi_customer,1,2)='4-') " : $@"and pri_customer='{txtCustomer.Text.Trim()}' ")));
            //已成交
            strWhere = strWhere + (chkDeal.Checked ? "and odi_customerid in (select distinct ord_assy from ord) " : "");
            //未成交
            strWhere = strWhere + (chkDeal_Yet.Checked ? "and odi_customerid not in (select distinct ord_assy from ord)  " : "");



            //線路
            strWhere = strWhere + (txtLine.Text == "" ? "" : $@"and odi_line like '%{txtLine.Text.Trim()}%' ");
            //客號
            if (txtCustomerID.Text.Trim() != "")//冒號分號多條件搜尋
            {
                strWhere = strWhere + clsGlobal.MulitSelect("odi_customerid", txtCustomerID.Text.Trim());
            }
            //參照法
            if (txtCZF.Text.Trim() != "")//冒號分號多條件搜尋
            {
                strWhere = strWhere + clsGlobal.MulitSelect("odi_czf", txtCZF.Text.Trim());
            }
            //日期
            strWhere = strWhere + (txtDate_S.Text == "" ? "" : $@"and pri_date between '{txtDate_S.Text}' and '{txtDate_E.Text}' ");
            //報價單號
            strWhere = strWhere + (txtQuotation.Text == "" ? "" : $@"and odi_customerid in (select distinct prd_assy from prd where prd_orderid= '%{txtQuotation.Text.Trim()}%') ");
            //線長
            strWhere = strWhere + (txtLength.Text == "" ? "" : $@"and pri_length = '{txtLength.Text.Trim()}' ");
            //分類
            strWhere = strWhere + (cboType.Text == ""  ? "" : $@"and pri_fenlei = '{cboType.Text.Trim()}' ");
            

            return strWhere;
        }

        private void chkDeal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeal.Checked)
            {
                chkDeal_Yet.Checked = false;
            }
        }

        private void chkDeal_Yet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeal_Yet.Checked)
            {
                chkDeal.Checked = false;
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

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //試算
            try
            {
                if(dgvData.Rows.Count == 0) 
                {
                    MessageBox.Show("請先作搜尋!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtCopper1.Text == "")
                {
                    MessageBox.Show("請先設定銅價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtCopper2.Text == "")
                {
                    MessageBox.Show("請先設定銅價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"truncate table simulate_copper_level0 ";
                clsDB.Execute(strSQL);

                strSQL = $@"insert into simulate_copper_level0 " + strQuery;
                clsDB.Execute(strSQL);

                strSQL = $@"truncate table simulate_copper_level1 ";
                clsDB.Execute(strSQL);
                strSQL = $@"truncate table simulate_copper_level2 ";
                clsDB.Execute(strSQL);
                strSQL = $@"truncate table simulate_copper_level3 ";
                clsDB.Execute(strSQL);
                strSQL = $@"truncate table simulate_copper_level4 ";
                clsDB.Execute(strSQL);
                strSQL = $@"truncate table simulate_copper_level5 ";
                clsDB.Execute(strSQL);

                int group_index;
                for (group_index = 1; group_index <= 3; group_index++)
                {
                    if (group_index == 2 && txtCopper2.Text == "")
                    {
                        continue;
                    }
                    if (group_index == 3 && txtCopper3.Text == "")
                    {
                        continue;
                    }

                    UpdateCluster(group_index);

                    UpdateUpPrice("simulate_copper_level5", "simulate_copper_level4", group_index);
                    UpdateUpPrice("simulate_copper_level4", "simulate_copper_level3", group_index);
                    UpdateUpPrice("simulate_copper_level3", "simulate_copper_level2", group_index);
                    UpdateUpPrice("simulate_copper_level2", "simulate_copper_level1", group_index);

                    UpdateLevel1Defect(group_index);

                    //把資料統計並更新至 simulate_copper_level0

                    strSQL = $@"select *
                                from   simulate_copper_level0 ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //strSQL = "";
                            strSQL = $@"update simulate_copper_level0 ";
                            switch (group_index)
                            {
                                case 1:
                                    strSQL = strSQL + "set pri_convcost = (  ";
                                    break;
                                case 2:
                                    strSQL = strSQL + "set pri_convcost2 = (  ";
                                    break;
                                case 3:
                                    strSQL = strSQL + "set pri_convcost3 = (  ";
                                    break;
                                default:

                                    break;
                            }
                            strSQL = strSQL + $@"select Round(
                                                              (
                                                              select Sum(pri_cost)
                                                              from   simulate_copper_level1
                                                              where  pri_customerid = '{dt.Rows[i]["pri_customerid"].ToString()}'
                                                              and    cluster = {group_index} ) /
                                                             (
                                                                    select cur_convert
                                                                    from   cur
                                                                    where  cur_code =
                                                                           (
                                                                                  select pri_currency
                                                                                  from   simulate_copper_level0
                                                                                  where  pri_customerid = '{dt.Rows[i]["pri_customerid"].ToString()}' ) ), 3) ) where pri_customerid = '{dt.Rows[i]["pri_customerid"].ToString()}'";
                            clsDB.Execute(strSQL);
                        }
                    }

                    //更新利潤 pri_ll
                    strSQL = $@"update simulate_copper_level0 ";
                    switch (group_index)
                    {
                        case 1:
                            strSQL = strSQL + "set pri_ll = round((quote - pri_convcost) * 100 / pri_convcost, 1)  ";
                            break;
                        case 2:
                            strSQL = strSQL + "set pri_ll2 = round((quote - pri_convcost2) * 100 / pri_convcost2, 1)  ";
                            break;
                        case 3:
                            strSQL = strSQL + "set pri_ll3 = round((quote - pri_convcost3) * 100 / pri_convcost3, 1)  ";
                            break;
                        default:

                            break;
                    }
                    clsDB.Execute(strSQL);
                }

            
                //把 simulate_copper_level0 的資料插入 simulate_copper
                strSQL = $@"delete simulate_copper
                            where  host_name = Host_name() ";
                clsDB.Execute(strSQL);
                strSQL = $@"insert into simulate_copper
                                        (odi_customer,
                                         pri_autoflag,
                                         pri_fenlei,
                                         pri_customerid,
                                         odi_active,
                                         odi_mo,
                                         pri_length,
                                         odi_czf,
                                         odi_line,
                                         pri_vendorid,
                                         pri_currency,
                                         quote,
                                         odi_oldll,
                                         pri_ll,
                                         pri_convcost,
                                         pri_hopelprice,
                                         pri_customerll,
                                         pri_date,
                                         host_name,
                                         pri_ll2,
                                         pri_convcost2,
                                         pri_ll3,
                                         pri_convcost3)
                            select odi_customer,
                                   pri_autoflag,
                                   pri_fenlei,
                                   pri_customerid,
                                   odi_active,
                                   odi_mo,
                                   pri_length,
                                   odi_czf,
                                   odi_line,
                                   pri_vendorid,
                                   pri_currency,
                                   quote,
                                   odi_oldll,
                                   pri_ll,
                                   pri_convcost,
                                   pri_hopelprice,
                                   pri_customerll,
                                   pri_date,
                                   Host_name(),
                                   pri_ll2,
                                   pri_convcost2,
                                   pri_ll3,
                                   pri_convcost3
                            from   simulate_copper_level0 ";
                clsDB.Execute(strSQL);
                strSQL = $@"select distinct odi_customer,
                                            pri_autoflag,
                                            pri_fenlei,
                                            pri_customerid,
                                            pri_length,
                                            odi_czf,
                                            odi_line,
                                            pri_currency,
                                            quote,
                                            odi_oldll,
                                            pri_ll,
                                            pri_convcost,
                                            pri_ll2,
                                            pri_convcost2,
                                            pri_ll3,
                                            pri_convcost3
                            from   simulate_copper
                            where  host_name = Host_name()";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    lblCount.Text = "資料筆數：" + dt.Rows.Count.ToString();
                    dgvData.DataSource = dt;
                }
                else
                {
                    lblCount.Text = "資料筆數：0";

                    dgvData.DataSource = dt;
                }
                MessageBox.Show("模擬完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCalculate_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCluster(int cluster)
        {
            string COPPER_COST = "";
            //銅價
            switch (cluster)
            {
                case 1:
                    COPPER_COST = txtCopper1.Text;
                    break;
                case 2:
                    COPPER_COST = txtCopper2.Text;
                    break;
                case 3:
                    COPPER_COST = txtCopper3.Text;
                    break;
                default:

                    break;
            }

            //插入表格 simulate_copper_level1
            string strSQL = "";
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            strSQL = $@"select *
                        from   simulate_copper_level0 ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i <dt.Rows.Count; i++)
                {
                    strSQL = $@"insert into simulate_copper_level1
                                select pri_part,
                                       pri_tbprice,
                                       Round(pri_perqty, 6)    pri_perqty,
                                       pri_cost,
                                       pri_um,
                                       pri_firstname,
                                       pri_perqtycal,
                                       case
                                         when asp_line is null then ''
                                         else asp_line
                                       end                     as asp_line,
                                       case
                                         when ptx_type = '1' then 'V'
                                         when ptx_type = '2' then 'R'
                                         when asp_name = 'Y' then '下'
                                         else ''
                                       end                     as ptx_chk,
                                       Isnull(asp_name, '')    asp_name,
                                       Isnull(asp_vnweight, 0) asp_vnweight,
                                       Isnull(asp_vnpcs, 0)    asp_vnpcs,
                                       pri_customerid,
                                       pri_date,
                                       pri_assy,
                                       pri_newcostchk,
                                       {cluster}
                                from   pri
                                       left join asp
                                              on asp_id = pri_part
                                       left join ptx
                                              on ptx_customerid = pri_customerid
                                                 and ptx_name = pri_part
                                where  pri_customerid = '{dt.Rows[i]["pri_customerid"].ToString()}'
                                       and pri_date = '{Convert.ToDateTime(dt.Rows[i]["pri_date"]).ToString("yyyy/MM/dd HH:mm:ss")}'
                                       and pri_assy = '{dt.Rows[i]["odi_line"].ToString()}'
                                order  by pri_part ";
                    clsDB.Execute(strSQL);
                }
            }


            //插入表格 simulate_copper_level2
            strSQL = $@"select *
                        from   simulate_copper_level1
                        where  ptx_chk = '下'
                               and cluster = {cluster} ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //模擬挑選「選擇材料品號」
                    strSQL = $@"select top 1 aspnum_num,
                                             case
                                               when asp_vendormaterialno = aspnum_num then 'V'
                                               else ''
                                             end o1,
                                             case
                                               when aa.pri_assy = aspnum_num then 'V'
                                               else ''
                                             end o2
                                from   Price.dbo.aspnum
                                       left join Price.dbo.asp
                                              on asp_id = aspnum_id
                                       left join(select distinct pri_customerid,
                                                                 pri_assy
                                                 from   pri
                                                 where  pri_newcostchk like 'Y%') as aa
                                              on aa.pri_customerid = aspnum_id
                                                 and aa.pri_assy = aspnum_num
                                where  aspnum_id = '{dt.Rows[i]["pri_part"].ToString()}'
                                order  by o2 desc,
                                          o1 desc ";
                    string aspnum_num = "";
                    dt2 = clsDB.sql_select_dt(strSQL);
                    if (dt2.Rows.Count > 0)
                    {
                        aspnum_num = dt2.Rows[0]["aspnum_num"].ToString();
                        strSQL = $@"insert into simulate_copper_level2
                                    select pri_part,
                                            pri_tbprice,
                                            Round(pri_perqty, 6)                      pri_perqty,
                                            pri_cost,
                                            pri_um,
                                            pri_firstname,
                                            pri_perqtycal,
                                            case
                                                when asp_line is null then ''
                                                else asp_line
                                            end                                       as asp_line,
                                            case
                                                when ptx_type = '1' then 'V'
                                                when ptx_type = '2' then 'R'
                                                when asp_name = 'Y' then '下'
                                                else ''
                                            end                                       as ptx_chk,
                                            Isnull(asp_name, '')                      asp_name,
                                            Isnull(asp_vnweight, 0)                   asp_vnweight,
                                            Isnull(asp_vnpcs, 0)                      asp_vnpcs,
                                            pri_customerid,
                                            pri_date,
                                            pri_assy,
                                            '{dt.Rows[i]["pri_customerid"].ToString()}' up_pri_customerid,
                                            pri_newcostchk,
                                            {cluster}
                                    from   pri
                                            left join asp
                                                    on asp_id = pri_part
                                            left join ptx
                                                    on ptx_customerid = pri_customerid
                                                        and ptx_name = pri_part
                                    where  pri_customerid = '{dt.Rows[i]["pri_part"].ToString()}'
                                            and pri_assy = '{aspnum_num}'
                                    order  by pri_part ";
                        clsDB.Execute(strSQL);

                    }
                }
                //刪除重覆的資料
                strSQL = $@"delete from simulate_copper_level2
                            where  cluster = {cluster}
                                   and id not in(select Max(id) as MaxRecordID
                                                 from   simulate_copper_level2
                                                 where  cluster = {cluster}
                                                 group  by pri_part,
                                                           pri_customerid,
                                                           cluster) ";
                clsDB.Execute(strSQL);

                //插入表格 simulate_copper_level3
                strSQL = $@"select *
                            from   simulate_copper_level2
                            where  ptx_chk = '下'
                            and    cluster = {cluster} ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //模擬挑選「選擇材料品號」
                        strSQL = $@"select top 1 aspnum_num,
                                             case
                                               when asp_vendormaterialno = aspnum_num then 'V'
                                               else ''
                                             end o1,
                                             case
                                               when aa.pri_assy = aspnum_num then 'V'
                                               else ''
                                             end o2
                                from   Price.dbo.aspnum
                                       left join Price.dbo.asp
                                              on asp_id = aspnum_id
                                       left join(select distinct pri_customerid,
                                                                 pri_assy
                                                 from   pri
                                                 where  pri_newcostchk like 'Y%') as aa
                                              on aa.pri_customerid = aspnum_id
                                                 and aa.pri_assy = aspnum_num
                                where  aspnum_id = '{dt.Rows[i]["pri_part"].ToString()}'
                                order  by o2 desc,
                                          o1 desc ";
                        string aspnum_num = "";
                        dt2 = clsDB.sql_select_dt(strSQL);
                        if (dt2.Rows.Count > 0)
                        {
                            aspnum_num = dt2.Rows[0]["aspnum_num"].ToString();
                            strSQL = $@"insert into simulate_copper_level3
                                    select pri_part,
                                            pri_tbprice,
                                            Round(pri_perqty, 6)                      pri_perqty,
                                            pri_cost,
                                            pri_um,
                                            pri_firstname,
                                            pri_perqtycal,
                                            case
                                                when asp_line is null then ''
                                                else asp_line
                                            end                                       as asp_line,
                                            case
                                                when ptx_type = '1' then 'V'
                                                when ptx_type = '2' then 'R'
                                                when asp_name = 'Y' then '下'
                                                else ''
                                            end                                       as ptx_chk,
                                            Isnull(asp_name, '')                      asp_name,
                                            Isnull(asp_vnweight, 0)                   asp_vnweight,
                                            Isnull(asp_vnpcs, 0)                      asp_vnpcs,
                                            pri_customerid,
                                            pri_date,
                                            pri_assy,
                                            '{dt.Rows[i]["pri_customerid"].ToString()}' up_pri_customerid,
                                            pri_newcostchk,
                                            {cluster}
                                    from   pri
                                            left join asp
                                                    on asp_id = pri_part
                                            left join ptx
                                                    on ptx_customerid = pri_customerid
                                                        and ptx_name = pri_part
                                    where  pri_customerid = '{dt.Rows[i]["pri_part"].ToString()}'
                                            and pri_assy = '{aspnum_num}'
                                    order  by pri_part ";
                            clsDB.Execute(strSQL);
                        }
                    }
                }
                //刪除重覆的資料
                strSQL = $@"delete from simulate_copper_level3
                            where  cluster = {cluster}
                                   and id not in(select Max(id) as MaxRecordID
                                                 from   simulate_copper_level3
                                                 where  cluster = {cluster}
                                                 group  by pri_part,
                                                           pri_customerid,
                                                           cluster) ";
                clsDB.Execute(strSQL);

                //插入表格 simulate_copper_level4
                strSQL = $@"select *
                            from   simulate_copper_level3
                            where  ptx_chk = '下'
                            and    cluster = {cluster} ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //模擬挑選「選擇材料品號」
                        strSQL = $@"select top 1 aspnum_num,
                                             case
                                               when asp_vendormaterialno = aspnum_num then 'V'
                                               else ''
                                             end o1,
                                             case
                                               when aa.pri_assy = aspnum_num then 'V'
                                               else ''
                                             end o2
                                from   Price.dbo.aspnum
                                       left join Price.dbo.asp
                                              on asp_id = aspnum_id
                                       left join(select distinct pri_customerid,
                                                                 pri_assy
                                                 from   pri
                                                 where  pri_newcostchk like 'Y%') as aa
                                              on aa.pri_customerid = aspnum_id
                                                 and aa.pri_assy = aspnum_num
                                where  aspnum_id = '{dt.Rows[i]["pri_part"].ToString()}'
                                order  by o2 desc,
                                          o1 desc ";
                        string aspnum_num = "";
                        dt2 = clsDB.sql_select_dt(strSQL);
                        if (dt2.Rows.Count > 0)
                        {
                            aspnum_num = dt2.Rows[0]["aspnum_num"].ToString();
                            strSQL = $@"insert into simulate_copper_level4
                                    select pri_part,
                                            pri_tbprice,
                                            Round(pri_perqty, 6)                      pri_perqty,
                                            pri_cost,
                                            pri_um,
                                            pri_firstname,
                                            pri_perqtycal,
                                            case
                                                when asp_line is null then ''
                                                else asp_line
                                            end                                       as asp_line,
                                            case
                                                when ptx_type = '1' then 'V'
                                                when ptx_type = '2' then 'R'
                                                when asp_name = 'Y' then '下'
                                                else ''
                                            end                                       as ptx_chk,
                                            Isnull(asp_name, '')                      asp_name,
                                            Isnull(asp_vnweight, 0)                   asp_vnweight,
                                            Isnull(asp_vnpcs, 0)                      asp_vnpcs,
                                            pri_customerid,
                                            pri_date,
                                            pri_assy,
                                            '{dt.Rows[i]["pri_customerid"].ToString()}' up_pri_customerid,
                                            pri_newcostchk,
                                            {cluster}
                                    from   pri
                                            left join asp
                                                    on asp_id = pri_part
                                            left join ptx
                                                    on ptx_customerid = pri_customerid
                                                        and ptx_name = pri_part
                                    where  pri_customerid = '{dt.Rows[i]["pri_part"].ToString()}'
                                            and pri_assy = '{aspnum_num}'
                                    order  by pri_part ";
                            clsDB.Execute(strSQL);
                        }
                    }
                }
                //刪除重覆的資料
                strSQL = $@"delete from simulate_copper_level4
                            where  cluster = {cluster}
                                   and id not in(select Max(id) as MaxRecordID
                                                 from   simulate_copper_level4
                                                 where  cluster = {cluster}
                                                 group  by pri_part,
                                                           pri_customerid,
                                                           cluster) ";
                clsDB.Execute(strSQL);

                //插入表格 simulate_copper_level5
                strSQL = $@"select *
                            from   simulate_copper_level4
                            where  ptx_chk = '下'
                            and    cluster = {cluster} ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //模擬挑選「選擇材料品號」
                        strSQL = $@"select top 1 aspnum_num,
                                             case
                                               when asp_vendormaterialno = aspnum_num then 'V'
                                               else ''
                                             end o1,
                                             case
                                               when aa.pri_assy = aspnum_num then 'V'
                                               else ''
                                             end o2
                                from   Price.dbo.aspnum
                                       left join Price.dbo.asp
                                              on asp_id = aspnum_id
                                       left join(select distinct pri_customerid,
                                                                 pri_assy
                                                 from   pri
                                                 where  pri_newcostchk like 'Y%') as aa
                                              on aa.pri_customerid = aspnum_id
                                                 and aa.pri_assy = aspnum_num
                                where  aspnum_id = '{dt.Rows[i]["pri_part"].ToString()}'
                                order  by o2 desc,
                                          o1 desc ";
                        string aspnum_num = "";
                        dt2 = clsDB.sql_select_dt(strSQL);
                        if (dt2.Rows.Count > 0)
                        {
                            aspnum_num = dt2.Rows[0]["aspnum_num"].ToString();
                            strSQL = $@"insert into simulate_copper_level5
                                    select pri_part,
                                            pri_tbprice,
                                            Round(pri_perqty, 6)                      pri_perqty,
                                            pri_cost,
                                            pri_um,
                                            pri_firstname,
                                            pri_perqtycal,
                                            case
                                                when asp_line is null then ''
                                                else asp_line
                                            end                                       as asp_line,
                                            case
                                                when ptx_type = '1' then 'V'
                                                when ptx_type = '2' then 'R'
                                                when asp_name = 'Y' then '下'
                                                else ''
                                            end                                       as ptx_chk,
                                            Isnull(asp_name, '')                      asp_name,
                                            Isnull(asp_vnweight, 0)                   asp_vnweight,
                                            Isnull(asp_vnpcs, 0)                      asp_vnpcs,
                                            pri_customerid,
                                            pri_date,
                                            pri_assy,
                                            '{dt.Rows[i]["pri_customerid"].ToString()}' up_pri_customerid,
                                            pri_newcostchk,
                                            {cluster}
                                    from   pri
                                            left join asp
                                                    on asp_id = pri_part
                                            left join ptx
                                                    on ptx_customerid = pri_customerid
                                                        and ptx_name = pri_part
                                    where  pri_customerid = '{dt.Rows[i]["pri_part"].ToString()}'
                                            and pri_assy = '{aspnum_num}'
                                    order  by pri_part ";
                            clsDB.Execute(strSQL);
                        }
                    }
                }
                //刪除重覆的資料
                strSQL = $@"delete from simulate_copper_level5
                            where  cluster = {cluster}
                                   and id not in(select Max(id) as MaxRecordID
                                                 from   simulate_copper_level5
                                                 where  cluster = {cluster}
                                                 group  by pri_part,
                                                           pri_customerid,
                                                           cluster) ";
                clsDB.Execute(strSQL);

                //更新 level5 銅價
                strSQL = $@"update simulate_copper_level5
                            set    pri_tbprice = {COPPER_COST},
                                   pri_cost = {COPPER_COST} * pri_perqty
                            where  pri_part = N'銅桿OD2.6mm/kg'
                                   and cluster = {cluster} ";
                clsDB.Execute(strSQL);

                //更新 level4 銅價
                strSQL = $@"update simulate_copper_level4
                            set    pri_tbprice = {COPPER_COST},
                                   pri_cost = {COPPER_COST} * pri_perqty
                            where  pri_part = N'銅桿OD2.6mm/kg'
                                   and cluster = {cluster} ";
                clsDB.Execute(strSQL);

                //更新 level3 銅價
                strSQL = $@"update simulate_copper_level3
                            set    pri_tbprice = {COPPER_COST},
                                   pri_cost = {COPPER_COST} * pri_perqty
                            where  pri_part = N'銅桿OD2.6mm/kg'
                                   and cluster = {cluster} ";
                clsDB.Execute(strSQL);

                //更新 level2 銅價
                strSQL = $@"update simulate_copper_level2
                            set    pri_tbprice = {COPPER_COST},
                                   pri_cost = {COPPER_COST} * pri_perqty
                            where  pri_part = N'銅桿OD2.6mm/kg'
                                   and cluster = {cluster} ";
                clsDB.Execute(strSQL);

                //更新 level1 銅價
                strSQL = $@"update simulate_copper_level1
                            set    pri_tbprice = {COPPER_COST},
                                   pri_cost = {COPPER_COST} * pri_perqty
                            where  pri_part = N'銅桿OD2.6mm/kg'
                                   and cluster = {cluster} ";
                clsDB.Execute(strSQL);
            }
        }

        private void UpdateUpPrice(string tableDown, string tableUp, int cluster)
        {
            //統計下層表格資料以更新上層表格
            double sum_tbprice=0; //單價
            double sum_perqty = 0; //數量
            double sum_cost = 0; //金額
            double sum_weave = 0; //編織袋
            double sum_process = 0; //加工
            double sum_defect = 0; //不良率
            double sum_welding = 0; //焊工補貼
            double sum_double = 0; //鋁箔雙面紙膠
            string is_defect="";   //是否有不良
            double defect_tbprice = 0; //不良單價
            double defect_perqty = 0; //不良數量
            string newcostchk = "";   //成本模式
            string pri_part = "";   //BOM 材料名
            string pri_customerid = "";   //材料名
            string pri_um = "";   //單位
            int list_count = 0;   //筆數
            double sum_result = 0; //最終加總結果


            //下層群組統計
            string strSQL = "";
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            strSQL = $@"select Sum(pri_cost) total,
                                pri_customerid,
                                up_pri_customerid
                        from   {tableDown}
                        where  cluster = { cluster}
                        group  by pri_customerid,
                                    up_pri_customerid ";
            dt = clsDB.sql_select_dt(strSQL);
            if(dt.Rows.Count>0)
            {
                for(int i =0; i< dt.Rows.Count;i++)
                {
                    
                    //依個別群組搜尋清單
                    strSQL = $@"select *
                    from   {tableDown}
                    where  cluster = {cluster}
                           and pri_customerid = '{dt.Rows[i]["pri_customerid"].ToString()}' ";

                    sum_tbprice = 0;
                    sum_perqty = 0;
                    sum_cost = 0;
                    sum_weave = 0;
                    sum_process = 0;
                    sum_defect = 0;
                    sum_welding = 0;
                    sum_double = 0;
                    is_defect = "N";
                    list_count = 0;
                    dt2 = clsDB.sql_select_dt(strSQL);
                    if (dt2.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            list_count = list_count + 1;
                            switch (dt2.Rows[j]["pri_part"].ToString().Substring(0,2))
                            {
                                case "不良":
                                    is_defect = "Y";
                                    defect_tbprice = Convert.ToDouble(dt2.Rows[j]["pri_tbprice"].ToString());
                                    defect_perqty = Convert.ToDouble(dt2.Rows[j]["pri_perqty"].ToString());
                                    pri_part = dt2.Rows[j]["pri_part"].ToString();
                                    break;
                                case "加工":
                                    sum_process = sum_process + Convert.ToDouble(dt2.Rows[j]["pri_cost"].ToString());
                                    break;
                                case "編織":
                                    sum_weave = sum_weave + Convert.ToDouble(dt2.Rows[j]["pri_cost"].ToString());
                                    break;
                                case "焊工":
                                    sum_welding = sum_welding + Convert.ToDouble(dt2.Rows[j]["pri_cost"].ToString());
                                    break;
                                case "雙面":
                                    sum_double = sum_double + Convert.ToDouble(dt2.Rows[j]["pri_cost"].ToString());
                                    break;
                                default:
                                    sum_tbprice = sum_tbprice + Convert.ToDouble(dt2.Rows[j]["pri_tbprice"].ToString());  //單價
                                    sum_perqty = sum_perqty + Convert.ToDouble(dt2.Rows[j]["pri_perqty"].ToString());   //數量
                                    sum_cost = sum_cost + Convert.ToDouble(dt2.Rows[j]["pri_cost"].ToString());  //金額
                                    break;
                            }
                            newcostchk = dt2.Rows[j]["pri_newcostchk"].ToString();
                            pri_customerid = dt2.Rows[j]["pri_customerid"].ToString();
                            pri_um = dt2.Rows[j]["pri_um"].ToString();
                        }
                    }
                    //檢查是否有不良率,若有則予以計算不良率
                    if(is_defect == "Y")
                    {
                        //區別新舊材料不良率計算
                        if (newcostchk == "Y1")
                        {
                            sum_defect = (sum_cost + sum_weave + sum_process) * defect_tbprice * defect_perqty;
                        }
                        //Y2金額總合計算成本或報價不良率金額計算
                        if(newcostchk == "Y2" || newcostchk.Substring(0, 1) == "N")
                        {
                            strSQL = $@"select Isnull(Sum(pri_cost), 0) as cost
                                        from   {tableDown}
                                        where  cluster = {cluster}
                                                and pri_customerid = '{pri_customerid}'
                                                and Substring(pri_part, 1, 1) not in ( '包', '裝', '運', '不', '調')
                                                and pri_part not like '%才' ";
                            dt3 = clsDB.sql_select_dt(strSQL);
                            double tcost = 0;
                            if (dt3.Rows.Count > 0)
                            {
                                tcost = Convert.ToDouble(dt3.Rows[0]["cost"].ToString());
                                
                            }
                            sum_defect = tcost * defect_tbprice * defect_perqty;
                        }
                        sum_defect = Convert.ToDouble(sum_defect.ToString("0.######"));
                        //更新下層不良項目的 pri_cost
                        strSQL = $@"update {tableDown}
                                    set    pri_cost = {sum_defect}
                                    where  cluster = {cluster}
                                           and pri_customerid = '{pri_customerid}'
                                           and pri_part = '{pri_part}' ";
                        clsDB.Execute(strSQL);
                    }

                    sum_result = 0;
                    switch (newcostchk)
                    {
                        case "Y1":
                            if (sum_perqty != 0)
                            {
                                sum_result = sum_cost / sum_perqty + sum_weave + sum_process + sum_defect;
                            }
                            else
                            {
                                sum_result = sum_weave + sum_process + sum_defect;
                            }
                            break;
                        case "Y2":
                            sum_result = sum_cost + sum_weave + sum_process + sum_defect;
                            break;
                        case "Y3":
                            sum_result = sum_cost / 1000 + sum_welding;
                            break;
                        case "Y4":
                            sum_result = sum_cost / 4500000;
                            break;
                        case "Y6":
                            //鋁箔線材附加成本
                            sum_result = (sum_double / 2 + sum_cost) / 4 / 2740;
                            break;
                        case "Y7":
                            //銅箔線材附加成本
                            sum_result = (sum_cost / 5 / 2740) + (sum_double / 2 / 2740);
                            break;
                        case "YB":
                            //平均成本
                            sum_result = sum_cost / list_count;
                            break;
                        default:
                            sum_result = sum_cost + sum_weave + sum_process + sum_defect;  
                            break;
                    }
                    sum_result = Convert.ToDouble(sum_result.ToString("0.######"));
                    //特殊單位計算
                    if (pri_um == "Feet")
                    {
                        sum_result = Convert.ToDouble((sum_result / 3.28084).ToString("0.######"));
                    }

                    //更新上層 pri_tbprice、pri_cost
                    strSQL = $@"update {tableUp}
                                set    pri_tbprice = {sum_result},
                                        pri_cost = Round({ sum_result} * pri_perqty, 6)
                                where  cluster = { cluster }
                                        and pri_part = '{pri_customerid}' ";
                    clsDB.Execute(strSQL);
                    //特殊包材計算
                    strSQL = $@"update {tableUp}
                                set    pri_cost = Round(pri_tbprice / pri_perqty, 6)
                                where  cluster = {cluster}
                                       and pri_part like '%才'
                                        or pri_part like '%裝' ";
                    clsDB.Execute(strSQL);
                }


            }

        }

        private void UpdateLevel1Defect(int cluster)
        {
            //根據不良更新 simulate_copper_level1 的資料
            double sum_tbprice = 0; //單價
            double sum_perqty = 0; //數量
            double sum_cost = 0; //金額
            double sum_weave = 0; //編織袋
            double sum_process = 0; //加工
            double sum_defect = 0; //不良率
            double sum_welding = 0; //焊工補貼
            double sum_double = 0; //鋁箔雙面紙膠
            string is_defect = "";   //是否有不良
            double defect_tbprice = 0; //不良單價
            double defect_perqty = 0; //不良數量
            string newcostchk = "";   //成本模式
            string pri_part = "";   //BOM 材料名
            string pri_customerid = "";   //材料名
            string pri_um = "";   //單位
            int list_count = 0;   //筆數
            double sum_result = 0; //最終加總結果

            //群組統計
            string strSQL = "";
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            strSQL = $@"select Sum(pri_cost) total,
                                pri_customerid
                        from   simulate_copper_level1
                        where  cluster = {cluster}
                        group  by pri_customerid ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //依個別群組搜尋清單
                    strSQL = $@"select *
                    from   simulate_copper_level1
                    where  cluster = {cluster}
                           and pri_customerid = '{dt.Rows[i]["pri_customerid"].ToString()}' ";

                    sum_tbprice = 0;
                    sum_perqty = 0;
                    sum_cost = 0;
                    sum_weave = 0;
                    sum_process = 0;
                    sum_defect = 0;
                    sum_welding = 0;
                    sum_double = 0;
                    is_defect = "N";
                    list_count = 0;
                    dt2 = clsDB.sql_select_dt(strSQL);
                    if (dt2.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            list_count = list_count + 1;
                            switch (dt2.Rows[j]["pri_part"].ToString().Substring(0, 2))
                            {
                                case "不良":
                                    is_defect = "Y";
                                    defect_tbprice = Convert.ToDouble(dt2.Rows[j]["pri_tbprice"].ToString());
                                    defect_perqty = Convert.ToDouble(dt2.Rows[j]["pri_perqty"].ToString());
                                    pri_part = dt2.Rows[j]["pri_part"].ToString();
                                    break;
                                case "加工":
                                    sum_process = sum_process + Convert.ToDouble(dt2.Rows[j]["pri_cost"].ToString());
                                    break;
                                case "編織":
                                    sum_weave = sum_weave + Convert.ToDouble(dt2.Rows[j]["pri_cost"].ToString());
                                    break;
                                case "焊工":
                                    sum_welding = sum_welding + Convert.ToDouble(dt2.Rows[j]["pri_cost"].ToString());
                                    break;
                                case "雙面":
                                    sum_double = sum_double + Convert.ToDouble(dt2.Rows[j]["pri_cost"].ToString());
                                    break;
                                default:
                                    sum_tbprice = sum_tbprice + Convert.ToDouble(dt2.Rows[j]["pri_tbprice"].ToString());  //單價
                                    sum_perqty = sum_perqty + Convert.ToDouble(dt2.Rows[j]["pri_perqty"].ToString());   //數量
                                    sum_cost = sum_cost + Convert.ToDouble(dt2.Rows[j]["pri_cost"].ToString());  //金額
                                    break;
                            }
                            newcostchk = dt2.Rows[j]["pri_newcostchk"].ToString();
                            pri_customerid = dt2.Rows[j]["pri_customerid"].ToString();
                            pri_um = dt2.Rows[j]["pri_um"].ToString();
                        }
                    }
                    //檢查是否有不良率,若有則予以計算不良率
                    if (is_defect == "Y")
                    {
                        //區別新舊材料不良率計算
                        if (newcostchk == "Y1")
                        {
                            sum_defect = (sum_cost + sum_weave + sum_process) * defect_tbprice * defect_perqty;
                        }
                        //Y2金額總合計算成本或報價不良率金額計算
                        if (newcostchk == "Y2" || newcostchk.Substring(0, 1) == "N")
                        {
                            //材料名第一個字為包/裝/運/不的不記入不良率
                            strSQL = $@"select Isnull(Sum(pri_cost), 0) as cost
                                        from   simulate_copper_level1
                                        where  cluster = {cluster}
                                                and pri_customerid = '{pri_customerid}'
                                                and Substring(pri_part, 1, 1) not in ( '包', '裝', '運', '不', '調')
                                                and pri_part not like '%才' ";
                            dt3 = clsDB.sql_select_dt(strSQL);
                            double tcost = 0;
                            if (dt3.Rows.Count > 0)
                            {
                                tcost = Convert.ToDouble(dt3.Rows[0]["cost"].ToString());
                                
                            }
                            sum_defect = tcost * defect_tbprice * defect_perqty;
                        }
                        sum_defect = Convert.ToDouble(sum_defect.ToString("0.######"));
                        //更新下層不良項目的 pri_cost
                        strSQL = $@"update simulate_copper_level1
                                    set    pri_cost = {sum_defect}
                                    where  cluster = {cluster}
                                           and pri_customerid = '{pri_customerid}'
                                           and pri_part = '{pri_part}' ";
                        clsDB.Execute(strSQL);
                    }
                    sum_result = 0;
                    switch (newcostchk)
                    {
                        case "Y1":
                            if (sum_perqty != 0)
                            {
                                sum_result = sum_cost / sum_perqty + sum_weave + sum_process + sum_defect;
                            }
                            else
                            {
                                sum_result = sum_weave + sum_process + sum_defect;
                            }
                            break;
                        case "Y2":
                            sum_result = sum_cost + sum_weave + sum_process + sum_defect;
                            break;
                        case "Y3":
                            sum_result = sum_cost / 1000 + sum_welding;
                            break;
                        case "Y4":
                            sum_result = sum_cost / 4500000;
                            break;
                        case "Y6":
                            //鋁箔線材附加成本
                            sum_result = (sum_double / 2 + sum_cost) / 4 / 2740;
                            break;
                        case "Y7":
                            //銅箔線材附加成本
                            sum_result = (sum_cost / 5 / 2740) + (sum_double / 2 / 2740);
                            break;
                        case "YB":
                            //平均成本
                            sum_result = sum_cost / list_count;
                            break;
                        default:
                            sum_result = sum_cost + sum_weave + sum_process + sum_defect;
                            break;
                    }
                    sum_result = Convert.ToDouble(sum_result.ToString("0.######"));
                    //更新pri_tbprice、pri_cost
                    strSQL = $@"update simulate_copper_level1
                                set    pri_tbprice = {sum_result},
                                        pri_cost = Round({sum_result} * pri_perqty, 6)
                                where  cluster = {cluster}
                                        and pri_part = '{pri_customerid}' ";
                    clsDB.Execute(strSQL);
                }
            }
        }

        private void frmCopper_Price_Calculate_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                //加入支出類別
                strSQL = $@"select asp_purprice
                            from   asp
                            where  asp_id = '銅桿OD2.6mm/kg' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    txtCopper1.Text = dt.Rows[0]["asp_purprice"].ToString();
                    txtCopper2.Text = dt.Rows[0]["asp_purprice"].ToString();
                    txtCopper3.Text = dt.Rows[0]["asp_purprice"].ToString();
                }
                else
                {
                    txtCopper1.Text = "0";
                    txtCopper2.Text = "0";
                    txtCopper3.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmSpecialExpenes_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("銅價試算清單", dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                //客號
                txtCustomerID.Text = "";
                //線長
                txtLength.Text = "";
                //參照法
                txtCZF.Text = "";
                //客戶
                txtCustomer.Text = "";
                //線路
                txtLine.Text = "";
                //日期
                txtDate_S.Text = "";

                txtDate_E.Text = "";
                //已成交
                chkDeal.Checked = false;
                //未成交
                chkDeal_Yet.Checked = false;
                //分類
                cboType.Text = "";
                //報價單號
                txtQuotation.Text = "";
                lblCount.Text = "資料筆數：0";

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
    }
}
