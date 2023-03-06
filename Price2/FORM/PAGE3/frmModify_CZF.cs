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
    public partial class frmModify_CZF : Form
    {
        public frmModify_CZF()
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
                //客戶
                txtCustomer.Text = "";
                //線路
                txtLine.Text = "";
                //客號
                txtCustomerID.Text = "";
                //線長
                txtLength.Text = "";
                //已成交
                chkDeal.Checked = false;
                //未成交
                chkDeal_Yet.Checked = false;
                //裝材料
                chkZ.Checked = false;
                //運材料
                chkU.Checked = false;
                //數量
                txtQty.Text = "";
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
                DataTable dt = new DataTable();

                strSQL = $@"select distinct odi_customerid 客號,
                                            odi_customer   客戶,
                                            odi_line       線路,
                                            pri_length     線長,
                                            odi_pripart01  裝材料,
                                            odi_priqty01   裝數量,
                                            odi_pripart05  運材料,
                                            odi_priqty05   運數量
                            from   pri,
                                   odi,
                                   ord
                            where  odi_customerid = pri_customerid ";
                strSQL = strSQL + Get_strWhere();
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

        private string Get_strWhere()
        {
            string strWhere = "";
            //客號
            if (txtCustomerID.Text.Trim() != "")
            {
                strWhere = strWhere + clsGlobal.MulitSelect("odi_customerid", txtCustomerID.Text.Trim());
            }
            //客戶
            strWhere = strWhere + (txtCustomer.Text == "" ? "" : $@"and odi_customer = '{txtCustomer.Text.Trim()}' ");
            //線路
            strWhere = strWhere + (txtLine.Text == "" ? "" : $@"and odi_line = '{txtLine.Text.Trim()}' ");
            //線長
            strWhere = strWhere + (txtLength.Text == "" ? "" : $@"and pri_length = '{txtLength.Text.Trim()}' ");
            //已成交
            strWhere = strWhere + (chkDeal.Checked ? "and pri_customerid in (select distinct ord_assy from ord) " : "");
            //未成交
            strWhere = strWhere + (chkDeal_Yet.Checked ? "and pri_customerid not in (select distinct ord_assy from ord)  " : "");

            return strWhere;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //修改
            try
            {
                if(txtQty.Text=="")
                {
                    MessageBox.Show("請填入數量!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQty.Focus();
                    return;
                }
                if(dgvData.Rows.Count == 0 )
                {
                    MessageBox.Show("請先搜尋!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("你確定要替換嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標

                string strSQL = "";
                DataTable dt = new DataTable();
                for (int i = 0; i < dgvData.Rows.Count; i++)
                { 
                    if(chkZ.Checked)
                    {
                        strSQL = $@"update odi set odi_priqty01 = {txtQty.Text.Trim()} where odi_customerid = '{dgvData.Rows[i].Cells["客號"].Value.ToString()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"update pri set pri_perqty = {txtQty.Text.Trim()} where pri_customerid = '{dgvData.Rows[i].Cells["客號"].Value.ToString()}' and pri_part like '%裝/%' ";
                        clsDB.Execute(strSQL);
                    }
                    if(chkU.Checked)
                    {
                        strSQL = $@"update odi set odi_priqty05 = {txtQty.Text.Trim()} where odi_customerid = '{dgvData.Rows[i].Cells["客號"].Value.ToString()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"update pri set pri_perqty = {txtQty.Text.Trim()} where pri_customerid = '{dgvData.Rows[i].Cells["客號"].Value.ToString()}' and pri_part like '%運/%' ";
                        clsDB.Execute(strSQL);
                    }
                }
                //強制更新
                strSQL = $@"update pub set pub_aimlocked = 1 ";
                clsDB.Execute(strSQL);
                strSQL = $@"exec updatepriclcost ";
                clsDB.Execute(strSQL);
                
                btnInq.PerformClick();
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show("修改完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
