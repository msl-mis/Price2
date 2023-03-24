using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Price2
{
    public partial class frmMaterial_Adjust : Form
    {
        string strQTY = ""; //數量的計算式
        public frmMaterial_Adjust()
        {
            InitializeComponent();
        }

        private void radioModify_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "變更";
            lblQty.Visible = true;
            txtQty.Visible = true;
            lblQty.Text = "數量為：";
        }

        private void radioAdd_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "新增";
            lblQty.Visible = true;
            txtQty.Visible = true;
            lblQty.Text = "數量：";
        }

        private void radioDelete_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "刪除";
            lblQty.Visible = false;
            txtQty.Visible = false;
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLength.Focus();
            }
        }

        private void txtCustomerID_Leave(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select distinct pri_customerid
                        from            pri
                        where           pri_customerid = '{txtCustomerID.Text.Trim()}'
                        and             pri_newcostchk like 'N%";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("沒有此客號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtCustomerID.Focus();
                return;
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (radioDelete.Checked)
                {
                    btnSave.Focus();
                }
                else
                {
                    txtQty.Focus();
                }
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            if (radioModify.Checked)
            {
                strSQL = $@"select distinct pri_part,
                                            asp_line
                            from   pri
                                   left join asp
                                          on asp_id = pri_part
                            where  pri_part = '{txtID.Text.Trim()}'
                                   and pri_newcostchk like 'N%' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("沒有這個材料或報價中沒有用到這個材料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Text = "";
                    return;
                }
            }
            else
            {
                strSQL = $@"select asp_id from asp where asp_id = '{txtID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("沒有這個材料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Text = "";
                    return;
                }
            }

        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            strQTY = "";
            if (txtQty.Text == "")
            {
                txtQty.Text = "0";
            }
            else
            {
                strQTY = txtQty.Text;
                //計算式  計算機 引用using System.Data
                txtQty.Text = Convert.ToDouble(new DataTable().Compute(txtQty.Text, null)).ToString("0.####");
            }
        }

        private void txtQty_Enter(object sender, EventArgs e)
        {
            if (strQTY != "")
            {
                txtQty.Text = strQTY;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {

                txtCustomer.Text = "";
                txtLine.Text = "";
                txtCustomerID.Text = "";
                txtLength.Text = "";
                txtQty.Text = "";
                txtID.Text = "";

                txtCustomer.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //變更新增刪除
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                if (txtID.Text == "")
                {
                    MessageBox.Show("沒有輸入材料,不能進行調整!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtLine.Text == "" && txtCustomerID.Text == "")
                {
                    MessageBox.Show("必須輸入線路或客號,才能進行調整!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtQty.Text == "")
                {
                    txtQty.Text = "0";
                }
                if (txtQty.Text == "0" && radioDelete.Checked == false)
                {
                    MessageBox.Show("調整數量不可以為零,不能進行調整!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtCustomer.Text == "" && txtLine.Text == "" && txtCustomerID.Text == "" && txtLength.Text == "")
                {
                    MessageBox.Show("沒有輸入任何條件,不能調整!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (radioModify.Checked)//更改材料數量
                {
                    doModify();
                }
                if (radioAdd.Checked)//新增材料
                {
                    doAdd();
                }
                if (radioDelete.Checked)//刪除材料
                {
                    doDelete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void doModify()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select distinct pri_customerid
                        from            pri
                        where           pri_part='{txtID.Text.Trim()}' 
                        and             pri_newcostchk like 'N%' ";
            strSQL = strSQL + Get_strWhere();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("符合條件的報價單共有" + dt.Rows.Count.ToString() + "筆,您確定要變更嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                strSQL = $@"update pri
                            set    pri_perqty={txtQty.Text},
                                   pri_perqtycal='{strQTY}'
                            where  pri_part='{txtID.Text.Trim()}'
                            and    pri_newcostchk like 'N%' ";
                strSQL = strSQL + Get_strWhere();
                clsDB.Execute(strSQL);
                strSQL = $@"update pri
                            set    pri_cost=Isnull(Round(pri_tbprice*pri_perqty,4),0)
                            where  Substring(pri_part,1,3)<>'不良率'
                            and    Substring(pri_part,1,2)<>'佣金'
                            and    Substring(pri_firstname,1,1)<>'其'
                            and    pri_part='{txtID.Text.Trim()}'
                            and    pri_newcostchk like 'N%' ";
                strSQL = strSQL + Get_strWhere();
                clsDB.Execute(strSQL);
                strSQL = $@"update pri
                            set    pri_cost=Isnull(Round(pri_tbprice*pri_perqty*cur_convert,4),0)
                            from   pri,
                                   cur,
                                   ptx
                            where  cur_code=ptx_yfcurrency
                            and    pri_customerid=ptx_customerid
                            and    pri_part=ptx_name
                            and    Substring(pri_part,1,3)<>'不良率'
                            and    Substring(pri_part,1,2)<>'佣金'
                            and    Substring(pri_firstname,1,1)='其'
                            and    pri_part='{txtID.Text.Trim()}'
                            and    pri_newcostchk like 'N%' ";
                strSQL = strSQL + Get_strWhere();
                clsDB.Execute(strSQL);
                strSQL = $@"update pub set pub_aimlocked=1";
                clsDB.Execute(strSQL);
                strSQL = $@"exec updatepriclcost";
                clsDB.Execute(strSQL);
                for (int i = 0; i < dt.Rows.Count; i++)//更新價史
                {
                    strSQL = $@"insert prb
                                       (prb_customer,
                                        prb_date,
                                        prb_adddate,
                                        prb_ll,
                                        prb_pricost,
                                        prb_hopelprice,
                                        prb_customerid,
                                        prb_length,
                                        prb_lenstr,
                                        prb_wg,
                                        prb_username,
                                        prb_newcostchk,
                                        prb_memo)
                                select distinct pri_customer,
                                                Getdate(),
                                                pri_adddate,
                                                pri_ll,
                                                pri_pricost,
                                                pri_hopelprice,
                                                pri_customerid,
                                                pri_length,
                                                pri_lenstr,
                                                pri_wg,
                                                '[報價調整]{clsGlobal.strG_User}',
                                                pri_newcostchk,
                                                '[報價調整]{clsGlobal.strG_User}調整材料=>{txtID.Text.Trim()}'
                                from   pri
                                where  pri_newcostchk like 'N%'
                                       and pri_customerid = '{dt.Rows[i]["pri_customerid"].ToString()}' ";
                    clsDB.Execute(strSQL);
                }
                MessageBox.Show("變更" + dt.Rows.Count.ToString() + "筆報價。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear.PerformClick();
            }
        }

        private void doAdd()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            strSQL = $@"select distinct pri_customerid
                        from            pri
                        where           pri_customerid in
                                                            (
                                                            select distinct pri_customerid
                                                            from            pri
                                                            where           pri_part='{txtID.Text.Trim()}'
                                                            and             pri_newcostchk like 'N%') "+ Get_strWhere() + ") and pri_newcostchk like 'N%' ";
            dt = clsDB.sql_select_dt(strSQL);
            int iCount = dt.Rows.Count;
            strSQL = $@"select distinct pri_customerid
                        from            pri
                        where           pri_customerid not in
                                                            (
                                                            select distinct pri_customerid
                                                            from            pri
                                                            where           pri_part='{txtID.Text.Trim()}'
                                                            and             pri_newcostchk like 'N%') " + Get_strWhere() + ") and pri_newcostchk like 'N%' ";
            dt = clsDB.sql_select_dt(strSQL);
            if(dt.Rows.Count==0)
            {
                if(iCount>0)
                {
                    MessageBox.Show("有" +iCount.ToString()+ "筆報價單已有該筆材料。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (MessageBox.Show("符合條件的報價單共有" + dt.Rows.Count.ToString() + "筆,您確定要新增嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                strSQL = $@"select *
                            from   ap3
                                   left join ap2
                                          on ap2_part = ap3_assy
                                   left join ap1
                                          on ap1_part = ap2_assy
                                   left join asp
                                          on asp_id = ap3_part
                            where  ap3_part = '{txtID.Text.Trim()}' ";
                dt2 = clsDB.sql_select_dt(strSQL);

                string ptbprice = dt2.Rows[0]["ap3_tbprice"].ToString(); //台幣價
                string pfirstname = dt2.Rows[0]["ap1_assy"].ToString(); //firstname
                string pqty = txtQty.Text;
                string pum = "Feet";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strSQL = $@"insert into pri
                                            (pri_tbprice,
                                             pri_perqty,
                                             pri_cost,
                                             pri_part,
                                             pri_um,
                                             pri_firstname,
                                             pri_adddate,
                                             pri_perqtycal,
                                             pri_costflag,
                                             pri_assy,
                                             pri_customer,
                                             pri_date,
                                             pri_ll,
                                             pri_pricost,
                                             pri_clcost,
                                             pri_hopelprice,
                                             pri_customerid,
                                             pri_currency,
                                             pri_length,
                                             pri_customerll,
                                             pri_lenstr,
                                             pri_oldll,
                                             pri_oldcustomerll,
                                             pri_convcost,
                                             pri_parttotal,
                                             pri_wg,
                                             pri_vendorid,
                                             pri_bz,
                                             pri_bzflag,
                                             pri_ld,
                                             pri_gp,
                                             pri_gc,
                                             pri_username,
                                             pri_newdate,
                                             pri_confirmflag,
                                             pri_confirmuser,
                                             pri_confirmdate,
                                             pri_addusername,
                                             pri_wgtype,
                                             pri_fenlei,
                                             pri_newcostchk,
                                             pri_verifyuser,
                                             pri_verifyflag,
                                             pri_verifydate)
                                select distinct { ptbprice },
                                                { pqty },
                                                { (Convert.ToSingle(ptbprice) * Convert.ToSingle(pqty)).ToString("0.######") },
                                                '{txtID.Text.Trim()}',
                                                '{ pum }',
                                                '{ pfirstname }',
                                                Getdate(),
                                                '{ strQTY }',
                                                'N',
                                                pri_assy,
                                                pri_customer,
                                                pri_date,
                                                pri_ll,
                                                pri_pricost,
                                                pri_clcost,
                                                pri_hopelprice,
                                                pri_customerid,
                                                pri_currency,
                                                pri_length,
                                                pri_customerll,
                                                pri_lenstr,
                                                pri_oldll,
                                                pri_oldcustomerll,
                                                pri_convcost,
                                                pri_parttotal,
                                                pri_wg,
                                                pri_vendorid,
                                                pri_bz,
                                                pri_bzflag,
                                                pri_ld,
                                                pri_gp,
                                                pri_gc,
                                                pri_username,
                                                pri_newdate,
                                                pri_confirmflag,
                                                pri_confirmuser,
                                                pri_confirmdate,
                                                pri_addusername,
                                                pri_wgtype,
                                                pri_fenlei,
                                                pri_newcostchk,
                                                pri_verifyuser,
                                                pri_verifyflag,
                                                pri_verifydate
                                from   pri
                                where  pri_newcostchk like 'N%'
                                       and pri_customerid = '{dt.Rows[i]["pri_customerid"].ToString()}' ";
                    clsDB.Execute(strSQL);
                }
                strSQL = $@"update pub set pub_aimlocked=1";
                clsDB.Execute(strSQL);
                strSQL = $@"exec updatepriclcost";
                clsDB.Execute(strSQL);
                for (int i = 0; i < dt.Rows.Count; i++)//更新價史
                {
                    strSQL = $@"insert prb
                                       (prb_customer,
                                        prb_date,
                                        prb_adddate,
                                        prb_ll,
                                        prb_pricost,
                                        prb_hopelprice,
                                        prb_customerid,
                                        prb_length,
                                        prb_lenstr,
                                        prb_wg,
                                        prb_username,
                                        prb_newcostchk,
                                        prb_memo)
                                select distinct pri_customer,
                                                Getdate(),
                                                pri_adddate,
                                                pri_ll,
                                                pri_pricost,
                                                pri_hopelprice,
                                                pri_customerid,
                                                pri_length,
                                                pri_lenstr,
                                                pri_wg,
                                                '[報價調整]{clsGlobal.strG_User}',
                                                pri_newcostchk,
                                                '[報價調整]{clsGlobal.strG_User}新增材料=>{txtID.Text.Trim()}'
                                from   pri
                                where  pri_newcostchk like 'N%'
                                       and pri_customerid = '{dt.Rows[i]["pri_customerid"].ToString()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"update pri
                                set    pri_parttotal = pri_parttotal + '{txtID.Text.Trim()}'
                                where  pri_newcostchk like 'N%'
                                       and pri_customerid = '{dt.Rows[i]["pri_customerid"].ToString()}' ";
                    clsDB.Execute(strSQL);
                }
                MessageBox.Show("已新增材料到" + dt.Rows.Count.ToString() + "筆報價。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear.PerformClick();
            }
        }

        private void doDelete()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select distinct pri_customerid
                        from            pri
                        where           pri_part='{txtID.Text.Trim()}' 
                        and             pri_newcostchk like 'N%' ";
            strSQL = strSQL + Get_strWhere();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("符合條件的報價單共有" + dt.Rows.Count.ToString() + "筆,您確定要刪除嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                strSQL = $@"delete pri
                            where  pri_part={txtID.Text.Trim()},
                            and    pri_newcostchk like 'N%' ";
                strSQL = strSQL + Get_strWhere();
                clsDB.Execute(strSQL);
                strSQL = $@"update pub set pub_aimlocked=1";
                clsDB.Execute(strSQL);
                strSQL = $@"exec updatepriclcost";
                clsDB.Execute(strSQL);
                for (int i = 0; i < dt.Rows.Count; i++)//更新價史
                {
                    strSQL = $@"insert prb
                                       (prb_customer,
                                        prb_date,
                                        prb_adddate,
                                        prb_ll,
                                        prb_pricost,
                                        prb_hopelprice,
                                        prb_customerid,
                                        prb_length,
                                        prb_lenstr,
                                        prb_wg,
                                        prb_username,
                                        prb_newcostchk,
                                        prb_memo)
                                select distinct pri_customer,
                                                Getdate(),
                                                pri_adddate,
                                                pri_ll,
                                                pri_pricost,
                                                pri_hopelprice,
                                                pri_customerid,
                                                pri_length,
                                                pri_lenstr,
                                                pri_wg,
                                                '[報價調整]{clsGlobal.strG_User}',
                                                pri_newcostchk,
                                                '[報價調整]{clsGlobal.strG_User}刪除材料=>{txtID.Text.Trim()}'
                                from   pri
                                where  pri_newcostchk like 'N%'
                                       and pri_customerid = '{dt.Rows[i]["pri_customerid"].ToString()}' ";
                    clsDB.Execute(strSQL);
                }
                MessageBox.Show("已刪除" + dt.Rows.Count.ToString() + "筆報價。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear.PerformClick();
            }
        }
        private string Get_strWhere()
        {
            string strWhere = "";

            //客戶
            strWhere = strWhere + (txtCustomer.Text == "" ? "" : $@"and pri_customer = '{txtCustomer.Text.Trim()}' ");
            //線路
            strWhere = strWhere + (txtLine.Text == "" ? "" : $@"and pri_assy = '{txtLine.Text.Trim()}' ");
            //客號
            strWhere = strWhere + (txtCustomerID.Text == "" ? "" : $@"and pri_customerid = '{txtCustomerID.Text.Trim()}' ");
            //線長
            strWhere = strWhere + (txtLength.Text == "" ? "" : $@"and pri_length = '{txtLength.Text.Trim()}' ");

            return strWhere;
        }
    }
}
