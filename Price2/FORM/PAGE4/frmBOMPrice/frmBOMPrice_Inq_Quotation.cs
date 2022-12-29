using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Price2
{
    public partial class frmBOMPrice_Inq_Quotation : Form
    {
        public static string rstrID = "";  //由frmBOMPrice傳的材料ID
        public static string rstrName = "";  //由frmBOMPrice傳的材料Name
        public static string rstrLength = "";  //由frmBOMPrice傳的線長
        public static string rstrCustomer = "";  //由frmBOMPrice傳的客戶
        public frmBOMPrice_Inq_Quotation()
        {
            InitializeComponent();
        }

        private void frmBOMPrice_Inq_Quotation_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                //BUTTON顯示
                if (clsGlobal.checkRightFlag("報價單查詢刪除") == false)
                {
                    btnDelete.Visible = false;
                }
                if (clsGlobal.checkRightFlag("報價單查詢全部刪除權限") == false)
                {
                    btnDeleteAll.Visible = false;
                }
                //清除
                GetClear();
                //COMBO加入ITEM
                string strSQL = "";
                DataTable dt = new DataTable();
                //用戶
                strSQL = $@"select distinct pas_username
                            from   pas
                            where  pas_username <> ''
                                   and pas_username <> 'yzf'
                            order  by pas_username ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    cboUser.Items.Clear();
                    cboUser.Items.Add("(ALL)");
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboUser.Items.Add(dt.Rows[i]["pas_username"].ToString());
                    }
                }
                //審核
                strSQL = $@"select distinct mod_username
                            from   mod
                            where  mod_modulename = '報價單審核'
                                   and mod_username <> 'YZF'
                                   and mod_flag = '1' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    cboChecker.Items.Clear();
                    cboChecker.Items.Add("(ALL)");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboUser.Items.Add(dt.Rows[i]["mod_username"].ToString());
                    }
                }
                //傳入的參數
                if(rstrID!="")
                {
                    chkID.Checked = false;
                    txtID.Text = rstrID;
                }
                if (rstrName != "")
                {
                    chkLine.Checked = false;
                    txtLine.Text = rstrName;
                }
                if (rstrLength != "")
                {
                    chkLength.Checked = false;
                    txtLength.Text = rstrLength;
                }
                if (rstrCustomer != "")
                {
                    chkCustomer.Checked = false;
                    txtCustomer.Text = rstrCustomer;
                }

                //搜尋
                GetInq();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOMPrice_Inq_Quotation_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Click(object sender, EventArgs e)   //搜尋
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
                string strSQL = "";
                string strWhere = "";
                string strOrder = "";
                DataTable dt = new DataTable();
                strSQL = $@"select distinct pri_assy                   線路,
                                            pri_vendorid               廠商,
                                            pri_length                 線長,
                                            pri_customer               客戶,
                                            pri_customerid             客號,
                                            pri_newdate                新建日期,
                                            pri_date                   報價日期,
                                            pri_convcost               成本,
                                            pri_pricost                報價金額,
                                            pri_hopelprice             希望買價,
                                            pri_ll                     利潤,
                                            pri_clcost                 總價,
                                            pri_currency               報價幣種,
                                            pri_username               用戶,
                                            pri_addusername            新建用戶,
                                            pri_lenstr                 標識符,
                                            case pri_verifyflag
                                              when '1' then 'Y'
                                              else 'N'
                                            end                        審核,
                                            Isnull(pri_verifyuser, '') 審核者,
                                            case
                                              when pri_verifydate < '1901-01-01'
                                                    or pri_verifydate is null then ''
                                              else Format(pri_verifydate, 'yyyy-MM-dd HH:mm:ss')
                                            end                        審核日期
                            from   pri
                            where  pri_newcostchk like 'N%'";
                

                strOrder = $@"order by  pri_assy,
                                        pri_lenstr,
                                        pri_length,
                                        pri_customer,
                                        pri_date desc ";
                strSQL = strSQL + Get_strWhere() + strOrder;
                dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;
                lblCount.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Get_strWhere()
        {
            string strWhere = "";
            //客戶
            strWhere = (chkCustomer.Checked ? "" : (txtCustomer.Text == "4-" ? "and pri_customer like '%4-%' " : (txtCustomer.Text == "4" ? "and (pri_customer='4' or substring(pri_customer,1,2)='4-') " : $@"and pri_customer='{txtCustomer.Text.Trim()}' ")));
            //新增日期
            strWhere = strWhere + (chkNewDate.Checked ? "" : $@"and pri_newdate between '{txtNewDate_S.Text}' and '{txtNewDate_E.Text}' ");
            //報價日期
            strWhere = strWhere + (chkQuoteDate.Checked ? "" : $@"and pri_newdate between '{txtQuoteDate_S.Text}' and '{txtQuoteDate_E.Text}' ");
            //線長
            strWhere = strWhere + (chkLength.Checked ? "" : $@"and pri_length = '{txtLength.Text.Trim()}' ");
            //線路
            if (txtLine.Text.IndexOf(";") >= 0)//分號多條件搜尋
            {
                string[] str = txtLine.Text.Split(';');
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Trim();
                    strWhere = strWhere + $@"and pri_assy like '%{str[i].Trim()}%' ";
                }
            }
            else
            {
                strWhere = strWhere + (chkLine.Checked ? "" : $@"and pri_assy like '%{txtLine.Text.Trim()}%' ");
            }
            //客號
            if (txtID.Text.IndexOf(";") >= 0)//分號多條件搜尋
            {
                string[] str = txtID.Text.Split(';');
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Trim();
                    strWhere = strWhere + $@"and pri_customerid like '%{str[i].Trim()}%' ";
                }
            }
            else
            {
                strWhere = strWhere + (chkID.Checked ? "" : $@"and pri_customerid like '%{txtID.Text.Trim()}%' ");
            }
            //報價單材料名
            if (chkFullInq.Checked)
            {
                strWhere = strWhere + (chkLine.Checked ? "" : $@"and pri_part = '{txtPart.Text.Trim()}' ");
            }
            else
            {
                if (txtPart.Text.IndexOf(";") >= 0)//分號多條件搜尋
                {
                    string[] str = txtPart.Text.Split(';');
                    for (int i = 0; i < str.Length; i++)
                    {
                        str[i] = str[i].Trim();
                        strWhere = strWhere + $@"and pri_part like '%{str[i].Trim()}%' ";
                    }
                }
                else
                {
                    strWhere = strWhere + (chkPart.Checked ? "" : $@"and pri_part like '%{txtPart.Text.Trim()}%' ");
                }
            }
            if (chkCheck.Checked)
            {
                //審核
                strWhere = strWhere + (chkCheck.Checked ? "and pri_verifyflag = 1 " : "");
                //審核者
                strWhere = strWhere + (cboChecker.Text == "(ALL)" ? "" : $@"and pri_verifyuser = '{cboChecker.Text.Trim()}' ");
                //審核日期
                strWhere = strWhere + (chkCheckDate.Checked ? "" : $@"and pri_verifydate between '{txtCheckDate_S.Text}' and '{txtCheckDate_E.Text}' ");
            }

            //成交
            strWhere = strWhere + (chkDeal.Checked ? "and pri_customerid in (select distinct ord_assy from ord) " : "");
            //未成交
            strWhere = strWhere + (chkDeal_Yet.Checked ? "and pri_customerid not in (select distinct ord_assy from ord) " : "");
            //負利潤
            strWhere = strWhere + (chkDeficit.Checked ? "and pri_ll < 0 " : "");
            //外購
            strWhere = strWhere + (chkOutsourcing.Checked ? "and pri_wg = 1 " : "");
            //電源
            strWhere = strWhere + (chkPower.Checked ? "and pri_wg = 2 " : "");
            //光纖
            strWhere = strWhere + (chkFiber.Checked ? "and pri_fenlei = '14 Fiber Cable' " : "");
            //廠商
            strWhere = strWhere + (chkVender.Checked ? "" : $@"and pri_vendorid = '{txtVender.Text.Trim()}' ");
            //用戶
            strWhere = strWhere + (cboUser.Text == "(ALL)" ? "" : $@"and pri_username = '{cboUser.Text.Trim()}' ");
            //國別
            strWhere = strWhere + (cboCountry.Text == "(ALL)" ? "" : $@"and pri_customerid in (select distinct pri_customerid from pri, cus where pri_customer = cus_id and cus_gb= '{cboCountry.Text.Trim()}') ");
            //分類
            strWhere = strWhere + (cboClass.Text == "(ALL)" ? "" : $@"and pri_fenlei = '{cboClass.Text.Trim()}' ");

            return strWhere;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //結束
            try
            {
                frmBOMPrice.rstrButton = "Close";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //導出
            try
            {
                if (dgvData.CurrentRow != null)
                {
                    getExport();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getExport()
        {
            try
            {
                frmBOMPrice.rstrID = dgvData.Rows[dgvData.CurrentRow.Index].Cells["客號"].Value.ToString();
                frmBOMPrice.rstrName = dgvData.Rows[dgvData.CurrentRow.Index].Cells["線路"].Value.ToString();
                frmBOMPrice.rstrButton = "ExportInq";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getExport" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                getExport();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e) //列印
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("查詢報價單", dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnExport_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) //清除
        {
            //清除
            try
            {
                GetClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetClear()
        {
            try
            {
                chkLine.Checked = true;
                chkCustomer.Checked = true;
                chkNewDate.Checked = true;
                chkQuoteDate.Checked = true;    
                chkCheckDate.Checked = true;
                chkLength.Checked = true;
                chkID.Checked = true;
                chkPart.Checked = true;
                chkVender.Checked = true;
                cboChecker.Text = "(ALL)";
                cboUser.Text = "(ALL)";
                cboCountry.Text = "(ALL)";
                cboClass.Text = "(ALL)";
                lblCount.Text = "0";

                chkCheck.Checked = false;
                chkDeal.Checked = false;
                chkDeal_Yet.Checked = false;
                chkDeficit.Checked = false;
                chkOutsourcing.Checked = false;
                chkPower.Checked = false;
                chkFiber.Checked = false;

                if (dgvData.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvData.DataSource;
                    dt.Rows.Clear();
                    dgvData.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-GetClear" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkNewDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewDate.Checked)
            {
                txtNewDate_S.Text = "(ALL)";
                txtNewDate_E.Text = "(ALL)";
            }
            else
            {
                txtNewDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtNewDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtNewDate_E_Enter(object sender, EventArgs e)
        {
            chkNewDate.Checked = false;  
        }

        private void txtNewDate_S_Enter(object sender, EventArgs e)
        {
            chkNewDate.Checked = false;
        }

        private void chkQuoteDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQuoteDate.Checked)
            {
                txtQuoteDate_S.Text = "(ALL)";
                txtQuoteDate_E.Text = "(ALL)";
            }
            else
            {
                txtQuoteDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtQuoteDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtQuoteDate_E_Enter(object sender, EventArgs e)
        {
            chkQuoteDate.Checked = false;
        }

        private void txtQuoteDate_S_Enter(object sender, EventArgs e)
        {
            chkQuoteDate.Checked = false;
        }

        private void chkCheckDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheckDate.Checked)
            {
                txtCheckDate_S.Text = "(ALL)";
                txtCheckDate_E.Text = "(ALL)";
            }
            else
            {
                txtCheckDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtCheckDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtCheckDate_E_Enter(object sender, EventArgs e)
        {
            chkCheckDate.Checked = false;
        }

        private void txtCheckDate_S_Enter(object sender, EventArgs e)
        {
            chkCheckDate.Checked = false;
        }

        private void chkLine_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLine.Checked)
            {
                txtLine.Text = "(ALL)";
            }
            else
            {
                txtLine.Text = "";
            }
        }

        private void chkID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkID.Checked)
            {
                txtID.Text = "(ALL)";
            }
            else
            {
                txtID.Text = "";
            }
        }

        private void chkPart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPart.Checked)
            {
                txtPart.Text = "(ALL)";
                chkFullInq.Checked = false;
            }
            else
            {
                txtPart.Text = "";
            }
        }

        private void chkLength_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLength.Checked)
            {
                txtLength.Text = "(ALL)";
            }
            else
            {
                txtLength.Text = "";
            }
        }

        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomer.Checked)
            {
                txtCustomer.Text = "(ALL)";
            }
            else
            {
                txtCustomer.Text = "";
            }
        }

        private void chkVender_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVender.Checked)
            {
                txtVender.Text = "(ALL)";
            }
            else
            {
                txtVender.Text = "";
            }
        }

        private void chkFullInq_CheckedChanged(object sender, EventArgs e)
        {
            if(chkFullInq.Checked)
            {
                chkPart.Checked = false;
            }
        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            if( chkCheck.Checked)
            {
                pnlCheck.Visible=true;
            }
            else
            {
                pnlCheck.Visible = false;
            }
        }

        private void chkDeal_CheckedChanged(object sender, EventArgs e)
        {
            if(chkDeal.Checked)
            {
                chkDeal_Yet.Checked = false;
            }
        }

        private void chkDeal_Yet_CheckedChanged(object sender, EventArgs e)
        {
            if(chkDeal_Yet.Checked)
            {
                chkDeal.Checked = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)    //刪除
        {
            //刪除
            try
            {
                //先檢查有沒有選擇GRID
                if(dgvData.CurrentRow==null)
                {
                    return;
                }
                //確認權限
                if (clsGlobal.checkRightFlag("報價單查詢刪除") == false )
                {
                    MessageBox.Show("您沒有報價單查詢刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                //再次確認
                if (MessageBox.Show("你確定要刪除它嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    //先檢查有沒有成交
                    strSQL = $@"select * from ord where ord_assy='{dgvData.Rows[dgvData.CurrentRow.Index].Cells["客號"].Value.ToString()}'";
                    dt = clsDB.sql_select_dt(strSQL);
                    if(dt.Rows.Count> 0)
                    {
                        MessageBox.Show("該客號已有成交工單記錄,不能被刪除!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        strSQL = $@"delete pri
                                    where  pri_assy = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["線路"].Value.ToString()}'
                                           and pri_customer = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["客戶"].Value.ToString()}'
                                           and pri_length = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["線長"].Value.ToString()}'
                                           and pri_customerid = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["客號"].Value.ToString()}'
                                           and pri_newcostchk like 'N%'";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete pld where pld_customerid = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["客號"].Value.ToString()}'";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete prb where prb_customerid = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["客號"].Value.ToString()}'";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete dyi where dyi_id = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["客號"].Value.ToString()}'";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete odi
                                    where  odi_customerid = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["客號"].Value.ToString()}'
                                           and odi_customerid not in (select distinct ord_assy
                                                                      from   ord
                                                                      where
                                               ord_assy = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["客號"].Value.ToString()}') ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete ptx where ptx_customerid <> '' and ptx_customerid = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["客號"].Value.ToString()}'";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete pmd where pmd_customerid <> '' and pmd_customerid = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["客號"].Value.ToString()}'";
                        clsDB.Execute(strSQL);
                        MessageBox.Show("已刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetInq();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e) //全部刪除
        {
            //全部刪除
            try
            {
                //先檢查有沒有選擇GRID
                if (dgvData.CurrentRow == null)
                {
                    return;
                }
                //確認權限
                if (clsGlobal.checkRightFlag("報價單查詢全部刪除權限") == false)
                {
                    MessageBox.Show("您沒有報價單查詢全部刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                //再次確認
                if (MessageBox.Show("你確認要刪除所有符合這些條件的資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    //先檢查有沒有成交
                    strSQL = $@"select * from ord,pri where ord_assy = pri_customerid ";
                    strSQL = strSQL + Get_strWhere();
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("這些客號中已有成交工單記錄,不能被刪除全部,請重設條件!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        strSQL = $@"delete pri
                                    where  pri_newcostchk like 'N%' ";
                        strSQL = strSQL + Get_strWhere();
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete pld from pld, pri where pld_customerid = pri_customerid ";
                        strSQL = strSQL + Get_strWhere();
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete prb from prb, pri where prb_customerid = pri_customerid ";
                        strSQL = strSQL + Get_strWhere();
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete dyi from dyi, pri where dyi_id = pri_customerid ";
                        strSQL = strSQL + Get_strWhere();
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete odi from odi, pri where  odi_customerid = pri_customerid ";
                        strSQL = strSQL + Get_strWhere();
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete ptx from ptx, pri where ptx_customerid <> '' and ptx_customerid = pri_customerid ";
                        strSQL = strSQL + Get_strWhere();
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete pmd from pmd, pri where pmd_customerid <> '' and pmd_customerid = pri_customerid ";
                        strSQL = strSQL + Get_strWhere();
                        clsDB.Execute(strSQL);
                        MessageBox.Show("已刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetInq();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDeleteAll_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProfit_0_Click(object sender, EventArgs e)
        {
            //全部刪除
            try
            {
                //先檢查有沒有選擇GRID
                if (dgvData.CurrentRow == null)
                {
                    return;
                }
                //確認權限
                if (clsGlobal.checkRightFlag("報價單查詢利潤歸零") == false)
                {
                    MessageBox.Show("您沒有報價單查詢利潤歸零權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                //再次確認
                if (MessageBox.Show("您確定要把查詢到的報價單利潤變更為零利潤嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    for(int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        strSQL = $@"update pri
                                    set    pri_oldll = pri_ll,
                                           pri_ll = 0,
                                           pri_pricost = pri_convcost,
                                           pri_date = '{DateTime.Now.ToString("yyyy/MM/dd")}',
                                           pri_adddate = '{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}',
                                           pri_username = '{clsGlobal.strG_User}'
                                    where  pri_customerid = '{dgvData.Rows[i].Cells["客號"].Value.ToString()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"update odi
                                    set    odi_price = pri_convcost,
                                           odi_oldll = pri_ll
                                    from   pri,
                                           odi
                                    where  pri_customerid = '{dgvData.Rows[i].Cells["客號"].Value.ToString()}'
                                           and odi_customerid = pri_customerid ";
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
                                    select pri_customer,
                                           '{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}',
                                           pri_ll,
                                           pri_pricost,
                                           pri_hopelprice,
                                           pri_customerid,
                                           pri_length,
                                           pri_wg,
                                           '{clsGlobal.strG_User}',
                                           'N'
                                    from   pri
                                    where  pri_customerid = '{dgvData.Rows[i].Cells["客號"].Value.ToString()}' ";
                        clsDB.Execute(strSQL);
                    }
                    MessageBox.Show("利潤變更完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetInq();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDeleteAll_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLine_Enter(object sender, EventArgs e)
        {
            chkLine.Checked = false;
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            chkID.Checked = false;
        }

        private void txtPart_Enter(object sender, EventArgs e)
        {
            chkPart.Checked = false;
        }

        private void txtLength_Enter(object sender, EventArgs e)
        {
            chkLength.Checked = false;
        }

        private void txtCustomer_Enter(object sender, EventArgs e)
        {
            chkCheck.Checked = false;
        }

        private void txtVender_Enter(object sender, EventArgs e)
        {
            chkVender.Checked = false;
        }
    }
}
