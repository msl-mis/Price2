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
    public partial class frmReName_Material : Form
    {
        public frmReName_Material()
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
                txtCustomerID.Text = "";
                txtAssy.Text = "";
                
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
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                if (getData() == false)
                {
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                clsGlobal.ExportExcel("修改的材料單", dgvData);
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool getData()
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();



                strSQL = $@"select pri_customerid '材料名',
                                   pri_assy '品號'
                            from   pri
                            where  pri_newcostchk like 'Y%' and pri_part = '{txtName1.Text}' ";
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
            
            //品號
            if(txtAssy.Text.Trim()!="")
            {
                strWhere = strWhere + clsGlobal.MulitSelect("pri_assy", txtAssy.Text.Trim());
            }

            //材料名
            if (txtCustomerID.Text.Trim() != "")
            {
                strWhere = strWhere + clsGlobal.MulitSelect("pri_customerid", txtCustomerID.Text.Trim());
            }
            return strWhere;
        }

        private bool chkText()
        {
            if (txtName1.Text != "" && txtName1_R.Text != "" && txtName1.Text != txtName1_R.Text)
            {
                return false;
            }
            return true;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            //替換
            try
            {
                if (chkText())
                {
                    MessageBox.Show("查詢條件輸入不完全或相同材料名,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("你確定要替換嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                if (getData() == false)
                {
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();

                //備份檔案到 pri_replace_back
                strSQL = $@"insert into pri_replace_back
                            select * ,
                                   Getdate()
                            from   pri
                            where  pri_customerid in
                                   (
                                          select pri_customerid
                                          from   pri
                                          where  pri_newcostchk like 'Y%' 
                                            and  pri_part = '{txtName1.Text}' ";
                strSQL = strSQL + Get_strWhere() + ") ";
                clsDB.Execute(strSQL);

                //開始 update 資料
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    //複製舊的材料名到新的材料名
                    strSQL = $@"insert into pri
                                        (pri_assy,
                                         pri_customer,
                                         pri_date,
                                         pri_tbprice,
                                         pri_perqty,
                                         pri_cost,
                                         pri_ll,
                                         pri_pricost,
                                         pri_part,
                                         pri_clcost,
                                         pri_hopelprice,
                                         pri_customerid,
                                         pri_currency,
                                         pri_length,
                                         pri_customerll,
                                         pri_lenstr,
                                         pri_oldll,
                                         pri_oldcustomerll,
                                         pri_um,
                                         pri_firstname,
                                         pri_convcost,
                                         pri_parttotal,
                                         pri_adddate,
                                         pri_wg,
                                         pri_vendorid,
                                         pri_bz,
                                         pri_bzflag,
                                         pri_ld,
                                         pri_gp,
                                         pri_gc,
                                         pri_username,
                                         pri_newdate,
                                         pri_perqtycal,
                                         pri_confirmflag,
                                         pri_confirmuser,
                                         pri_confirmdate,
                                         pri_addusername,
                                         pri_wgtype,
                                         pri_fenlei,
                                         pri_newcostchk,
                                         pri_costflag,
                                         pri_verifyuser,
                                         pri_verifyflag,
                                         pri_verifydate,
                                         pri_hopelprice_cal,
                                         pri_pricost_cal)
                            select pri_assy,
                                   pri_customer,
                                   pri_date,
                                   pri_tbprice,
                                   pri_perqty,
                                   pri_cost,
                                   pri_ll,
                                   pri_pricost,
                                   '{txtName1_R.Text.Trim()}',
                                   pri_clcost,
                                   pri_hopelprice,
                                   pri_customerid,
                                   pri_currency,
                                   pri_length,
                                   pri_customerll,
                                   pri_lenstr,
                                   pri_oldll,
                                   pri_oldcustomerll,
                                   pri_um,
                                   pri_firstname,
                                   pri_convcost,
                                   pri_parttotal,
                                   pri_adddate,
                                   pri_wg,
                                   pri_vendorid,
                                   pri_bz,
                                   pri_bzflag,
                                   pri_ld,
                                   pri_gp,
                                   pri_gc,
                                   pri_username,
                                   pri_newdate,
                                   pri_perqtycal,
                                   pri_confirmflag,
                                   pri_confirmuser,
                                   pri_confirmdate,
                                   pri_addusername,
                                   pri_wgtype,
                                   pri_fenlei,
                                   pri_newcostchk,
                                   pri_costflag,
                                   pri_verifyuser,
                                   pri_verifyflag,
                                   pri_verifydate,
                                   pri_hopelprice_cal,
                                   pri_pricost_cal
                            from   pri
                            where  pri_newcostchk like 'Y%'
                                   and pri_customerid = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}'
                                   and pri_part = '{txtName1.Text.Trim()}' ";
                    clsDB.Execute(strSQL);

                    //刪除舊的材料名
                    strSQL = $@"delete from pri
                                where  pri_newcostchk like 'Y%'
                                       and pri_customerid = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}'
                                       and pri_part = '{txtName1.Text.Trim()}' ";
                    clsDB.Execute(strSQL);

                    //從 BOM 的價格資料來更新替代料的價格
                    strSQL = $@"update p
                                set    p.pri_tbprice = Round(a.ap3_purprice, 6)
                                from   pri as p
                                       inner join ap3 as a
                                               on p.pri_part = a.ap3_part
                                where  p.pri_newcostchk like 'Y%'
                                       and p.pri_customerid = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}'
                                       and p.pri_part = '{txtName1_R.Text.Trim()}' ";
                    clsDB.Execute(strSQL);

                    //更新 pri_cost = pri_tbprice * pri_perqty
                    strSQL = $@"update pri
                    set    pri_cost = Round(pri_tbprice * pri_perqty, 6)
                    where  pri_newcostchk like 'Y%'
                           and pri_customerid = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}'
                           and pri_part = '{txtName1_R.Text.Trim()}' ";
                    clsDB.Execute(strSQL);

                    //pri_clcost = 所有單身的 pri_cost 相加
                    strSQL = $@"declare @pri_cost FLOAT(53)

                                select @pri_cost = Sum(pri_cost)
                                from   pri
                                where  pri_newcostchk like 'Y%'
                                       and pri_customerid = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}'

                                update pri
                                set    pri_clcost = Round(@pri_cost, 6)
                                where  pri_newcostchk like 'Y%'
                                       and pri_customerid = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}' ";
                    clsDB.Execute(strSQL);

                    //pri_customerll 希望買價獲利率% = 希望買價 - 換算價
                    strSQL = $@"declare @pri_customerll FLOAT(53)

                                select @pri_customerll = case pri_convcost
                                                           when 0 then pri_convcost
                                                           else ( pri_hopelprice - pri_convcost ) * 100 /
                                                                pri_convcost
                                                         end
                                from   pri
                                where  pri_newcostchk like 'Y%'
                                       and pri_customerid = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}'
                                       and pri_part = '{txtName1_R.Text.Trim()}'

                                update pri
                                set    pri_customerll = Round(@pri_customerll, 1)
                                where  pri_newcostchk like 'Y%'
                                       and pri_customerid = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}' ";
                    clsDB.Execute(strSQL);

                    //pri_ll 報價獲利率% = 報價 - 換算價
                    strSQL = $@"declare @pri_ll FLOAT(53)

                                select @pri_ll = case pri_convcost
                                                   when 0 then pri_convcost
                                                   else ( pri_pricost - pri_convcost ) * 100 / pri_convcost
                                                 end
                                from   pri
                                where  pri_newcostchk like 'Y%'
                                       and pri_customerid = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}'
                                       and pri_part = '{txtName1_R.Text.Trim()}'

                                update pri
                                set    pri_ll = Round(@pri_ll, 1)
                                where  pri_newcostchk like 'Y%'
                                       and pri_customerid = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}' ";
                    clsDB.Execute(strSQL);
                }
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show("已經替換完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnReplace_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
