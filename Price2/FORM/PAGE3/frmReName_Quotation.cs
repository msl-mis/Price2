using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Price2
{
    public partial class frmReName_Quotation : Form
    {
        public frmReName_Quotation()
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                txtName1.Text = "";
                txtName1_R.Text = "";
                txtName2.Text = "";
                txtName2_R.Text = "";
                txtName3.Text = "";
                txtName3_R.Text = "";
                txtName4.Text = "";
                txtName4_R.Text = "";
                txtName5.Text = "";
                txtName5_R.Text = "";
                txtName6.Text = "";
                txtName6_R.Text = "";
                txtLength.Text= "";
                txtCustomer.Text = "";
                txtCustomerID.Text = "";
                txtLine.Text = "";
                lblCount.Text = "";
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
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            if(radio1.Checked)
            {
                panel1.Visible = false;
                btnClear.PerformClick();
            }
        }

        private void radio2_CheckedChanged(object sender, EventArgs e)
        {
            if (radio2.Checked)
            {
                panel1.Visible = false;
                btnClear.PerformClick();
            }
        }

        private void radio3_CheckedChanged(object sender, EventArgs e)
        {
            if (radio3.Checked)
            {
                panel1.Visible = false;
                btnClear.PerformClick();
            }
        }

        private void radio4_CheckedChanged(object sender, EventArgs e)
        {
            if (radio4.Checked)
            {
                panel1.Visible = false;
                btnClear.PerformClick();
            }
        }

        private void radio5_CheckedChanged(object sender, EventArgs e)
        {
            if (radio5.Checked)
            {
                panel1.Visible = false;
                btnClear.PerformClick();
            }
        }

        private void radio6_CheckedChanged(object sender, EventArgs e)
        {
            if (radio6.Checked)
            {
                panel1.Visible = true;
                btnClear.PerformClick();
            }
        }

        private void txtName1_Click(object sender, EventArgs e)
        {
            if(txtName1.Text=="")
            {
                radio1.Checked= true;
            }
        }

        private void txtName1_R_Click(object sender, EventArgs e)
        {
            if (txtName1_R.Text == "")
            {
                radio1.Checked = true;
            }
        }

        private void txtName2_Click(object sender, EventArgs e)
        {
            if (txtName2.Text == "")
            {
                radio2.Checked = true;
            }
        }

        private void txtName2_R_Click(object sender, EventArgs e)
        {
            if (txtName2_R.Text == "")
            {
                radio2.Checked = true;
            }
        }

        private void txtName3_Click(object sender, EventArgs e)
        {
            if (txtName3.Text == "")
            {
                radio3.Checked = true;
            }
        }

        private void txtName3_R_Click(object sender, EventArgs e)
        {
            if (txtName3_R.Text == "")
            {
                radio3.Checked = true;
            }
        }

        private void txtName4_Click(object sender, EventArgs e)
        {
            if (txtName4.Text == "")
            {
                radio4.Checked = true;
            }
        }

        private void txtName4_R_Click(object sender, EventArgs e)
        {
            if (txtName4_R.Text == "")
            {
                radio4.Checked = true;
            }
        }

        private void txtName5_Click(object sender, EventArgs e)
        {
            if (txtName5.Text == "")
            {
                radio5.Checked = true;
            }
        }

        private void txtName5_R_Click(object sender, EventArgs e)
        {
            if (txtName5_R.Text == "")
            {
                radio5.Checked = true;
            }
        }

        private void txtName6_Click(object sender, EventArgs e)
        {
            if (txtName6.Text == "")
            {
                radio6.Checked = true;
            }
        }

        private void txtName6_R_Click(object sender, EventArgs e)
        {
            if (txtName6_R.Text == "")
            {
                radio6.Checked = true;
            }
        }

        private void btnRDLC_Click(object sender, EventArgs e)
        {
            //預覽列印
            try
            {
                if (chkText())
                {
                    MessageBox.Show("查詢條件輸入不完全或相同材料名,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (getData() == false)
                {
                    return;
                }
                if (radio3.Checked)
                {
                    clsGlobal.ExportExcel("修改的訂單", dgvData);
                }
                else
                {
                    clsGlobal.ExportExcel("修改的客號", dgvData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool getData()
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                if(radio1.Checked)
                {
                    strSQL = $@"select asp_id from asp where asp_id = '{txtName1_R.Text.Trim()}'";
                    dt = clsDB.sql_select_dt(strSQL);
                    if(dt.Rows.Count>0)
                    {
                        MessageBox.Show("新材料名已存在,請改用更換已存在材料名來操作!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    
                    strSQL = $@"select distinct pri_customerid as '客號' from pri where pri_part = '{txtName1.Text.Trim()}' and pri_newcostchk like 'N%'";
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
                    return true;
                }

                if (radio2.Checked)
                {
                    strSQL = $@"select distinct pri_customerid as '客號' from pri where pri_assy = '{txtName2.Text.Trim()}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        lblCount.Text = "資料筆數：" + dt.Rows.Count.ToString();
                        dgvData.DataSource = dt;
                    }
                    else
                    {
                        lblCount.Text = "資料筆數：0" ;
                        dgvData.DataSource = dt;
                    }
                    return true;
                }

                if (radio3.Checked)
                {
                    strSQL = $@"select * from pri where pri_customerid = '{txtName3.Text.Trim()}' and pri_newcostchk like 'N%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("不存在這個客號:" + txtName3.Text.Trim() + ",不能更換!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    strSQL = $@"select * from pri where pri_customerid = '{txtName3_R.Text.Trim()}' and pri_newcostchk like 'N%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("這個客號:" + txtName3.Text.Trim() + "已經存在,不能更換", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    strSQL = $@"select ord_orderid as '客號' from ord where ord_assy = '{txtName3.Text.Trim()}' ";
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
                    return true;
                }

                if (radio4.Checked)
                {
                    strSQL = $@"select cus_id from cus where cus_id='{txtName4.Text.Trim()}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("客戶代號不存在:" + txtName4.Text.Trim() + ",不能更換!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    strSQL = $@"select distinct pri_customerid as id from pri where pri_customer = '{txtName4.Text.Trim()}' ";
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
                    return true;
                }

                if (radio5.Checked)
                {
                    strSQL = $@"select * from ven where ven_id ='{txtName5.Text.Trim()}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("不存在這個廠商:" + txtName5.Text.Trim() + "!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    return true;
                }

                if (radio6.Checked)
                {
                    
                    strSQL = $@"select distinct pri_customerid as id from pri where pri_part = '{txtName6.Text.Trim()}' " + Get_strWhere();
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
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string Get_strWhere()
        {
            string strWhere = "";
            //客戶
            if (txtCustomer.Text == "4-")
            {
                strWhere = strWhere + $@"and pri_customer like '%4-%' ";
            }
            else if (txtCustomer.Text == "4")
            {
                strWhere = strWhere + $@"and (pri_customer ='4' or substring(pri_customer, 1, 2) = '4-') ";
            }
            else
            {
                strWhere = strWhere + (txtCustomer.Text == "" ? "" : $@"and pri_customer = '{txtCustomer.Text.Trim()}' ");
            }
            //線路
            strWhere = strWhere + (txtLine.Text == "" ? "" : $@"and pri_assy = '{txtLine.Text.Trim()}' ");
            //線長
            strWhere = strWhere + (txtLength.Text == "" ? "" : $@"and pri_length = '{txtLength.Text.Trim()}' ");
            //客號
            strWhere = strWhere + (txtCustomerID.Text == "" ? "" : $@"and pri_customerid = '{txtCustomerID.Text.Trim()}' ");

            return strWhere;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkText())
                {
                    MessageBox.Show("查詢條件輸入不完全或相同材料名,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("你確定要替換嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                string strSQL = "";
                DataTable dt = new DataTable();
                
                if(radio1.Checked)
                {
                    strSQL = $@"select pub_bomuse from pub";
                    string bomuser = clsDB.sql_select_String(strSQL, "pub_bomuse");
                    if(bomuser !="")
                    {
                        MessageBox.Show("["+bomuser + "] 使用者正在BOM產品結構作業,暫停更名.請稍候再試!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if(getData()==false)
                    {
                        return;
                    }
                    strSQL = $@"update asp set asp_id = '{txtName1_R.Text.Trim()}', asp_user = '{clsGlobal.strG_User}', asp_adddate = getdate() where asp_id = '{txtName1.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update aspnum set aspnum_id = '{txtName1_R.Text.Trim()}' where aspnum_id = '{txtName1.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update ap3 set ap3_part = '{txtName1_R.Text.Trim()}' where ap3_part = '{txtName1.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    if (txtName1.Text.Substring(0, 2) == "包/")
                    {
                        strSQL = $@"update odi set odi_pripart02 = '{txtName1_R.Text.Trim()}' where odi_pripart02 = '{txtName1.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                    }
                    if (txtName1.Text.Substring(0, 2) == "裝/")
                    {
                        strSQL = $@"update odi set odi_pripart01 = '{txtName1_R.Text.Trim()}' where odi_pripart01 = '{txtName1.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                    }
                    if (txtName1.Text.Substring(0, 2) == "運/")
                    {
                        strSQL = $@"update odi set odi_pripart05 = '{txtName1_R.Text.Trim()}' where odi_pripart05 = '{txtName1.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                    }
                    if (txtName1.Text.Substring(0, 2) == "不良")
                    {
                        strSQL = $@"update odi set odi_pripart04 = '{txtName1_R.Text.Trim()}' where odi_pripart04 = '{txtName1.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                    }

                    strSQL = $@"update pri set pri_part = '{txtName1_R.Text.Trim()}' where pri_part = '{txtName1.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update pri set pri_customerid = '{txtName1_R.Text.Trim()}' where pri_customerid = '{txtName1.Text.Trim()}' and pri_newcostchk like 'Y%' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"exec cal_parttotalbyname = '{txtName1_R.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update avt set avt_id = '{txtName1_R.Text.Trim()}' where avt_id = '{txtName1.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update asb set asb_id = '{txtName1_R.Text.Trim()}' where asb_id = '{txtName1.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"insert asb
                                       (asb_id,
                                        asb_changedate,
                                        asb_price,
                                        asb_vendorid,
                                        asb_user,
                                        asb_currency,
                                        asb_memo,
                                        asb_pricecal)
                                select asp_id,
                                       Getdate(),
                                       asp_purprice,
                                       asp_vendorid,
                                       '"" & pricemdi.puser & ""',
                                       asp_currency,
                                       '[更名] 原材料名->{txtName1.Text.Trim()}',
                                       asp_pricecal
                                from   asp
                                where  asp_id = '{txtName1_R.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    //清除特選材料
                    strSQL = $@"delete from ptx where ptx_type='1' and ptx_name = '{txtName1_R.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("已經替換完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (radio2.Checked)
                {
                    if (getData() == false)
                    {
                        return;
                    }
                    strSQL = $@"update pri set pri_assy = '{txtName2_R.Text.Trim()}' where pri_assy = '{txtName2.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update odi set odi_line = '{txtName2_R.Text.Trim()}' where odi_line = '{txtName2.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update dyi set dyi_line = '{txtName2_R.Text.Trim()}' where dyi_line = '{txtName2.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    
                    MessageBox.Show("已經替換完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (radio3.Checked)
                {
                    if (getData() == false)
                    {
                        return;
                    }
                    strSQL = $@"update dyi set dyi_id = '{txtName3_R.Text.Trim()}' where dyi_id = '{txtName3.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update dyd set dyd_assy = '{txtName3_R.Text.Trim()}' where dyd_assy = '{txtName3.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update ord set ord_assy = '{txtName3_R.Text.Trim()}' where ord_assy = '{txtName3.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update odi set odi_customerid = '{txtName3_R.Text.Trim()}' where odi_customerid = '{txtName3.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update pri set pri_customerid = '{txtName3_R.Text.Trim()}' where pri_customerid = '{txtName3.Text.Trim()}' and pri_newcostchk like 'N%' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update prb set prb_customerid = '{txtName3_R.Text.Trim()}' where prb_customerid = '{txtName3.Text.Trim()}' and pri_newcostchk like 'N%' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update pld set pld_customerid = '{txtName3_R.Text.Trim()}' where pld_customerid = '{txtName3.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update prd set prd_assy = '{txtName3_R.Text.Trim()}' where prd_assy = '{txtName3.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update ptx set ptx_customerid = '{txtName3_R.Text.Trim()}' where ptx_customerid = '{txtName3.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update pmd set pmd_customerid = '{txtName3_R.Text.Trim()}' where pmd_customerid = '{txtName3.Text.Trim()}' ";
                    clsDB.Execute(strSQL);


                    MessageBox.Show("已經替換完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (radio4.Checked)
                {
                    if (getData() == false)
                    {
                        return;
                    }
                    strSQL = $@"update pri set pri_customer = '{txtName4_R.Text.Trim()}' where pri_customer = '{txtName4.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update prb set prb_customer = '{txtName4_R.Text.Trim()}' where prb_customer = '{txtName4.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    bool chknewcust;
                    //檢查新客戶是否已建立旗標
                    strSQL = $@"select cus_id from cus where cus_id = '{txtName4_R.Text.Trim()}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if(dt.Rows.Count>0)
                    {
                        chknewcust = true;
                    }
                    else
                    {
                        chknewcust = false;
                        //如果新客戶資料不存在就把舊客戶直接變更成新客戶
                        strSQL = $@"update cus set cus_id = '{txtName4_R.Text.Trim()}' where cus_id = '{txtName4.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                    }

                    strSQL = $@"update odi set odi_customer = '{txtName4_R.Text.Trim()}' where odi_customer = '{txtName4.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update dyi set dyi_customer = '{txtName4_R.Text.Trim()}' where dyi_customer = '{txtName4.Text.Trim()}' and pri_newcostchk like 'N%' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update odh set odh_customer = '{txtName4_R.Text.Trim()}' where odh_customer = '{txtName4.Text.Trim()}' and pri_newcostchk like 'N%' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update dyh set dyh_customer = '{txtName4_R.Text.Trim()}' where dyh_customer = '{txtName4.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update czc set czc_customer = '{txtName4_R.Text.Trim()}' where czc_customer = '{txtName4.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update obz set obz_customer = '{txtName4_R.Text.Trim()}' where obz_customer = '{txtName4.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update ord set ord_customer = '{txtName4_R.Text.Trim()}' where ord_customer = '{txtName4.Text.Trim()}' ";
                    clsDB.Execute(strSQL);


                    MessageBox.Show("已經替換完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (radio5.Checked)
                {
                    if (getData() == false)
                    {
                        return;
                    }
                    strSQL = $@"update ven set ven_id = '{txtName5_R.Text.Trim()}' where ven_id = '{txtName5.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update asp set asp_vendorid = '{txtName5_R.Text.Trim()}' where asp_vendorid = '{txtName5.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update asm set asm_vendorid = '{txtName5_R.Text.Trim()}' where asm_vendorid = '{txtName5.Text.Trim()}' and pri_newcostchk like 'N%' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update asv set asv_vendorid = '{txtName5_R.Text.Trim()}' where asv_vendorid = '{txtName5.Text.Trim()}' and pri_newcostchk like 'N%' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update avt set avt_vendorid = '{txtName5_R.Text.Trim()}' where avt_vendorid = '{txtName5.Text.Trim()}' ";
                    clsDB.Execute(strSQL);

                    MessageBox.Show("已經替換完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (radio6.Checked)
                {
                    strSQL = $@"select pub_bomuse from pub";
                    string bomuser = clsDB.sql_select_String(strSQL, "pub_bomuse");
                    if (bomuser != "")
                    {
                        MessageBox.Show("[" + bomuser + "] 使用者正在BOM產品結構作業,暫停更名.請稍候再試!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (getData() == false)
                    {
                        return;
                    }
                    string tpurprice = "0";
                    string tvendorid = "";
                    string tcurrency = "";
                    string tconvert = "0";
                    
                    strSQL = $@"select asp_purprice, asp_vendorid, asp_currency from asp where asp_id = '{txtName6_R.Text.Trim()}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if(dt.Rows.Count>0)
                    {
                        tpurprice = dt.Rows[0]["asp_purprice"].ToString();
                        tvendorid = dt.Rows[0]["asp_vendorid"].ToString();
                        tcurrency = dt.Rows[0]["asp_currency"].ToString();
                    }
                    else
                    {
                        tpurprice = "0";
                        tvendorid = "";
                        tcurrency = "";
                    }

                    strSQL = $@"select cur_convert from cur where cur_code = '{tcurrency}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        tconvert = dt.Rows[0]["cur_convert"].ToString();
                    }
                    else
                    {
                        tconvert = "1";
                    }

                    if (txtName1.Text.Substring(0, 2) == "包/")
                    {
                        strSQL = $@"update odi set odi_pripart02 = '{txtName6_R.Text.Trim()}' where odi_pripart02 = '{txtName6.Text.Trim()}' and odi_customerid in (select distinct pri_customerid from pri where pri_part = '{txtName6.Text.Trim()}' " + Get_strWhere()+ ")";
                        clsDB.Execute(strSQL);
                    }
                    if (txtName1.Text.Substring(0, 2) == "裝/")
                    {
                        strSQL = $@"update odi set odi_pripart01 = '{txtName6_R.Text.Trim()}' where odi_pripart01 = '{txtName6.Text.Trim()}' and odi_customerid in (select pri_customerid from pri where pri_part = '{txtName6.Text.Trim()}' " + Get_strWhere() + ")";
                        clsDB.Execute(strSQL);
                    }
                    if (txtName1.Text.Substring(0, 2) == "運/")
                    {
                        strSQL = $@"update odi set odi_pripart05 = '{txtName6_R.Text.Trim()}' where odi_pripart05 = '{txtName6.Text.Trim()}' and odi_customerid in (select pri_customerid from pri where pri_part = '{txtName6.Text.Trim()}' " + Get_strWhere() + ")";
                        clsDB.Execute(strSQL);
                    }
                    if (txtName1.Text.Substring(0, 2) == "不良")
                    {
                        strSQL = $@"update odi set odi_pripart04 = '{txtName6_R.Text.Trim()}' where odi_pripart04 = '{txtName6.Text.Trim()}' and odi_customerid in (select pri_customerid from pri where pri_part = ' {txtName6.Text.Trim()} ' " + Get_strWhere() + ")";
                        clsDB.Execute(strSQL);
                    }


                    

                    strSQL = $@"update pri set pri_part = '{txtName6_R.Text.Trim()}', pri_tbprice = {tpurprice} where pri_part = '{txtName6.Text.Trim()}' and pri_customerid not in (select distinct pri_customerid from pri where pri_part = '{txtName6_R.Text.Trim()}') " + Get_strWhere();
                    clsDB.Execute(strSQL);

                    if(Get_strWhere()=="")
                    {
                        strSQL = $@"delete pri where pri_part = '{txtName6_R.Text.Trim()}' and pri_customerid in (select distinct pri_customerid from pri where pri_part = '{txtName6.Text.Trim()}')";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete ap3 where ap3_part = '{txtName6_R.Text.Trim()}' and ap3_assy in (select distinct ap3_assy from ap3 where ap3_part = '{txtName6.Text.Trim()}')";
                        clsDB.Execute(strSQL);
                        strSQL = $@"update ap3 set ap3_part = '{txtName6_R.Text.Trim()}', ap3_tbprice = Round({tpurprice} * {tconvert}, 3) , ap3_purprice = {tpurprice}, ap3_vendorid = '{ tvendorid}', ap3_currency = '{ tcurrency}' where ap3_part = '{txtName6.Text.Trim()}'";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete asp where asp_id = '{txtName6.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete aspnum where aspnum_id = '{txtName6.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete asm where asm_id = '{txtName6.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"update asp set asp_id = '{txtName6_R.Text.Trim()}', asp_purprice = {tpurprice}, asp_vendorid = '{tvendorid}', asp_currency = '{tcurrency}' where asp_id = '{txtName6.Text.Trim()}'";
                        clsDB.Execute(strSQL);
                        strSQL = $@"update asm set asm_id = '{txtName6_R.Text.Trim()}' where asm_id = '{txtName6.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                    }

                    strSQL = $@"exec cal_parttotalbyname '{txtName6_R.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update pub set pub_updid = '{txtName6_R.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"exec asp_updrename ";
                    clsDB.Execute(strSQL);

                    MessageBox.Show("已經替換完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool chkText()
        {
            if (radio1.Checked)
            {
                if (txtName1.Text != "" && txtName1_R.Text != "" && txtName1.Text != txtName1_R.Text)
                {
                    return false;
                }
            }
            if (radio2.Checked)
            {
                if (txtName2.Text != "" && txtName2_R.Text != "" && txtName2.Text != txtName2_R.Text)
                {
                    return false;
                }
            }
            if (radio3.Checked)
            {
                if (txtName3.Text != "" && txtName3_R.Text != "" && txtName3.Text != txtName3_R.Text)
                {
                    return false;
                }
            }
            if (radio4.Checked)
            {
                if (txtName4.Text != "" && txtName4_R.Text != "" && txtName4.Text != txtName4_R.Text)
                {
                    return false;
                }
            }
            if (radio5.Checked)
            {
                if (txtName5.Text != "" && txtName5_R.Text != "" && txtName5.Text != txtName5_R.Text)
                {
                    return false;
                }
            }
            if (radio6.Checked)
            {
                if (txtName6.Text != "" && txtName6_R.Text != "" && txtName6.Text != txtName6_R.Text)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
