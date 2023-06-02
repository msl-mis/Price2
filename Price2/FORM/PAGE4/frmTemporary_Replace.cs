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
    public partial class frmTemporary_Replace : Form
    {
        public frmTemporary_Replace()
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
                string strSQL = "";
                DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標

                strSQL = $@"select distinct pri_customer                           '客戶',
                                            pri_customerid                         '客號',
                                            pri_part                               '材料名',
                                            ptx_tbdj                               '原幣價',
                                            pri_tbprice                            '臺幣價',
                                            pri_perqty                             '用量',
                                            ptx_vendorid                           '廠號',
                                            ptx_venshortname                       '廠商',
                                            pri_assy                               '線路',
                                            ptx_yfcurrency                         '幣種',
                                            convert(VARCHAR(10), ptx_adddate, 121) '新建時間',
                                            convert(VARCHAR(10), orderdate, 121)   '最後成交日'
                            from   pri,
                                   ptx
                                   left join ven
                                          on ven_id = ptx_vendorid
                                   left join maxorderdate
                                          on ord_assy = ptx_customerid
                            where  pri_firstname = '其它料'
                                   and pri_customerid = ptx_customerid
                                   and pri_part = ptx_name
                                   and ptx_customerid <> '' ";
                strSQL = strSQL + Get_strWhere() + "order by pri_customer, pri_customerid, pri_part ";
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
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Get_strWhere()
        {
            string strWhere = "";
            
            //客號
            if (txtCustomerID.Text.Trim() != "")//冒號分號多條件搜尋
            {
                strWhere = strWhere + clsGlobal.MulitSelect("pri_customerid", txtCustomerID.Text.Trim());
            }
            //客戶
            strWhere = strWhere + (txtCustomer.Text == "" ? "" : $@"and pri_customer like '{txtCustomer.Text.Trim()}%' ");
            //特選材料名
            strWhere = strWhere + (txtID_Temp.Text == ""  ? "" : $@"and pri_part like '%{txtID_Temp.Text.Trim()}%' ");
            //廠號
            strWhere = strWhere + (txtVendorID.Text == "" ? "" : $@"and ptx_vendorid like '%{txtVendorID.Text.Trim()}%' ");
            //廠商
            strWhere = strWhere + (txtVendorName.Text == "" ? "" : $@"and ven_shortname like '%{txtVendorName.Text.Trim()}%' ");
            //線路
            strWhere = strWhere + (txtLine.Text == "" ? "" : $@"and pri_assy like '%{txtLine.Text.Trim()}%' ");
            //已成交
            strWhere = strWhere + (chkDeal.Checked ? "and pri_customerid in (select distinct ord_assy from ord) " : "");
            //未成交
            strWhere = strWhere + (chkDeal_Yet.Checked ? "and pri_customerid not in (select distinct ord_assy from ord)  " : "");
            //特選/備註
            strWhere = strWhere + (radioTemp.Checked ? $@"and ptx_type = '1' " : $@"and ptx_type = '2' ");
            

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                //客號
                txtCustomerID.Text = "";
                //特選材料名
                txtID_Temp.Text = "";
                //替代材料名
                txtID_Replace.Text = "";
                //客戶
                txtCustomer.Text = "";
                //線路
                txtLine.Text = "";
                //廠商
                txtVendorName.Text = "";
                //廠號
                txtVendorID.Text = "";
                //已成交
                chkDeal.Checked = false;
                //未成交
                chkDeal_Yet.Checked = false;
                radioTemp.Checked = true;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                if(radioTemp.Checked)
                {
                    clsGlobal.ExportExcel("特選材料清單", dgvData);
                }
                else
                {
                    clsGlobal.ExportExcel("備註材料清單", dgvData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            //替換
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                if (txtID_Temp.Text == "")
                {
                    MessageBox.Show("材料名不可以為空!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtID_Replace.Text=="")
                {
                    MessageBox.Show("替代材料名不可以為空!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string pdname=txtID_Replace.Text.Trim();
                strSQL = $@"select ap3_part from ap3 where ap3_part='{pdname}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("此材料不存在BOM表中,請檢查重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID_Replace.SelectionStart = 0;
                    txtID_Replace.SelectionLength = txtID_Replace.Text.Length;
                    txtID_Replace.Focus();
                    return;
                }

                if (MessageBox.Show("您確定要替代特選材料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                for (int i =0; i< dgvData.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgvData.Rows[i].Cells["CHK"];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == true)
                    {
                        strSQL = $@"update pri
                                    set    pri_part = '{pdname}',
                                           pri_tbprice = ap3.ap3_tbprice,
                                           pri_cost = Round(ap3_tbprice * pri_perqty, 6),
                                           pri_firstname = ap1_assy
                                    from   pri,
                                           (select distinct ap3_part,
                                                            ap3_tbprice,
                                                            ap1_assy
                                            from   ap3
                                                   left join ap2
                                                          on ap2_part = ap3_assy
                                                   left join ap1
                                                          on ap1_part = ap2_assy) as ap3
                                    where  pri_customerid = '{dgvData.Rows[i].Cells["客號"].Value.ToString()}'
                                           and pri_part = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}'
                                           and ap3.ap3_part = '{pdname}' ";
                        clsDB.Execute(strSQL);

                        strSQL = $@"delete from ptx
                                    where  ptx_customerid = '{dgvData.Rows[i].Cells["客號"].Value.ToString()}'
                                           and ptx_name = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}'
                                           and ptx_type = '1' ";
                        clsDB.Execute(strSQL);
                    }
                }
                strSQL = $@"update pub set pub_aimlocked = 1 ";
                clsDB.Execute(strSQL);
                strSQL = $@"exec updatepriclcost ";
                clsDB.Execute(strSQL);
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgvData.Rows[i].Cells["CHK"];
                    Boolean flag = Convert.ToBoolean(checkCell.Value);
                    if (flag == true)
                    {
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
                                            prb_newcostchk,
                                            prb_memo)
                                    select distinct pri_customer,
                                                    '{DateTime.Now.ToString("yyyy-mm-dd hh:MM:ss")}',
                                                    pri_ll,
                                                    pri_pricost,
                                                    pri_hopelprice,
                                                    pri_customerid,
                                                    pri_length,
                                                    pri_wg,
                                                    '{clsGlobal.strG_User}特選轉正',
                                                    pri_newcostchk,
                                    '特選:{dgvData.Rows[i].Cells["材料名"].Value.ToString()}轉為正式材料:{pdname}'
                                    from   pri
                                    where  pri_customerid = '{dgvData.Rows[i].Cells["客號"].Value.ToString()}'
                                           and pri_part = '{pdname}' ";
                        clsDB.Execute(strSQL);
                    }
                }
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show("更新完成,報價將會在十分鐘左右生效!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnReplace_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtLine_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
