using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Price2
{
    public partial class frmInq_Large : Form
    {
        public frmInq_Large()
        {
            InitializeComponent();
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("量大資料清單", dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Click(object sender, EventArgs e)
        {
            //搜尋
            try
            {
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                if (getData() == false)
                {
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }

                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool getData()
        {
            try
            {
                string strSQL = "";
                string strWhere = "";
                DataTable dt = new DataTable();
                //參照法
                if (txtCZF.Text.IndexOf(";") >= 0)//分號多條件搜尋
                {
                    string[] str = txtCZF.Text.Split(';');
                    for (int i = 0; i < str.Length; i++)
                    {
                        str[i] = str[i].Trim();
                        strWhere = strWhere + $@"and odi_czf like '%{str[i].Trim()}%' ";
                    }
                    strWhere = strWhere + "and pld.pld_customerid in (select distinct odi_customerid from odi where odi_czf <>'' " + strWhere + ") ";
                }
                else
                {
                    strWhere = strWhere + (txtCZF.Text == "" ? "" : $@"and pld.pld_customerid in (select distinct odi_customerid from odi where odi_czf like '%{txtCZF.Text.Trim()}%') ");
                }
                //線長
                strWhere = strWhere + (txtLength.Text == "" ? "" : $@"and pld.pld_customerid in (select distinct pri_customerid from pri where pri_length like '{txtLength.Text.Trim()}%') ");
                //廠號
                strWhere = strWhere + (txtVendor.Text == "" ? "" : $@"and pld.pld_customerid in (select distinct pri_customerid from pri where pri_vendorid like '%{lblVendor.Text.Trim()}%') ");
                //已成交
                strWhere = strWhere + (chkDeal.Checked ? "and pld.pld_customerid in (select distinct ord_assy from ord) " : "");
                //未成交
                strWhere = strWhere + (chkDeal_Yet.Checked ? "and pld.pld_customerid not in (select distinct ord_assy from ord) " : "");
                //客號
                if (txtCustomerID.Text.IndexOf(";") >= 0)//分號多條件搜尋
                {
                    string[] str = txtCustomerID.Text.Split(';');
                    for (int i = 0; i < str.Length; i++)
                    {
                        str[i] = str[i].Trim();
                        strWhere = strWhere + $@"and pld.pld_customerid like '%{str[i].Trim()}%' ";
                    }
                }
                else
                {
                    strWhere = strWhere + (txtCustomerID.Text == "" ? "" : $@"and pld.pld_customerid like '%{txtCustomerID.Text.Trim()}%' ");
                }

                strSQL = $@"select   pld_ybj.pri_customer'客戶',
                                     pld.pld_customerid'客號',
                                     pld.pld_name'數量',
                                     pld.pld_pricost'差別報價',
                                     pld.pld_ll'利潤',
                                     pld.pld_oldll'舊利潤',
                                     pld_ybj.pri_date'單價日期',
                                     pld.pld_adddate'儲存日期'
                            from     pld,
                                     pld_ybj
                            where    pld.pld_name<>'一般價'
                            and      pld.pld_customerid=pld_ybj.pld_customerid " +
                            (chkPlus.Checked ? $@"and pld.pld_name<>'一般價' and pld.pld_pricost>pld_ybj.pld_pricost " : "") +
                            (txtCustomer.Text == "" ? "" : $@"and pri_customer = '{txtCustomer.Text.Trim()}' ") +
                            (chkMinus.Checked ? $@"and pld.pld_ll < 0 " : "") +
                            strWhere +
                            "order by pld.pld_customerid, pld.pld_name ";

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
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void txtVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnInq.Focus();
            }
        }

        private void txtVendor_Leave(object sender, EventArgs e)
        {
            if(txtVendor.Text=="")
            {
                lblVendor.Text = "";
                return;
            }
            string strSQL = "";
            DataTable dt = new DataTable();
            string strVendor = "";
            if(txtVendor.Text.Substring(0, 1) =="M")
            {
                strVendor = txtVendor.Text.Substring(1, txtVendor.Text.Length - 1);
            }
            else
            {
                strVendor= txtVendor.Text;
            }
            strSQL = $@"select ven_shortname from ven where ven_id = '{strVendor}' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count>0)
            {
                lblVendor.Text = dt.Rows[0]["ven_shortname"].ToString();
            }
        }
    }
}
