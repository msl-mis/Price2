using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
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
    public partial class frmWorking_Adjust : Form
    {
        public static string rstrID = "";   //傳來的ID
        public static string rstrQty = "";   //傳來的Qty
        public static string rstrItem = "";   //傳來的Item
        public static string tsql1 = "";   //傳來的tsql1
        public static string tsql33 = "";   //傳來的tsql33
        string tsql = "";
        string tsql2 = "";
        string tsql32 = "";
        string tsql31 = "";
        string ttype = "";
        public frmWorking_Adjust()
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
            if(txtLine.Text == "" && txtCustomerID.Text == "" && txtCustomer.Text == "")
            {
                MessageBox.Show("請輸入查詢條件!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtLine.Focus();
                return;
            }
            if (cboItem.Text == "")
            {
                MessageBox.Show("調整參數不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //cboItem.Focus();
                return;
            }
            

            this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
            string strSQL = "";
            DataTable dt = new DataTable();
            
            tsql = "";
            tsql2 = "";
            tsql32 = "";
            tsql31 = "";
            ttype = "";

            if(cboItem.Text== "加工/分")
            {
                if(txtLine.Text=="")
                {
                    ttype = "電腦線";
                }
                else
                {
                    if(txtLine.Text.Substring(0,1)== "F")
                    {
                        ttype = "電源線";
                    }
                    else if(txtLine.Text.Substring(0, 1) == "8")
                    {
                        ttype = "網路線";
                    }
                    else
                    {
                        ttype = "電腦線";
                    }
                }
            }
            else
            {
                ttype = "";
            }

            tsql = tsql + "and pri_assy<>'' " + (txtCustomer.Text == "" ? "" : $@"and pri_customer = '{txtCustomer.Text}' ") + (radioDeal.Checked ? "and pri_customerid in (select distinct ord_assy from ord) " : (radioDeal_Yet.Checked ? "and pri_customerid not in (select distinct ord_assy from ord) " : ""));
            tsql2 = tsql2 + (txtLine.Text == "" ? "" : $@"and pri_assy = '{txtLine.Text}' ");
            tsql31 = tsql31 + "and aa.pri_assy<>'' " + (txtLine.Text == "" ? "" : $@"and aa.pri_assy='{txtLine.Text }' ") + (radioDeal.Checked ? "and aa.pri_customerid in (select distinct ord_assy from ord) " : (radioDeal_Yet.Checked ? "and aa.pri_customerid not in (select distinct ord_assy from ord) " : ""));
            tsql32 = tsql32 + (txtCustomer.Text == ""? "": $@"and aa.pri_customer like '{txtCustomer.Text}' ");

            if (txtCustomerID.Text != "")
            {
                if (txtCustomerID.Text.IndexOf(";") >= 0)//分號多條件搜尋
                {
                    string[] str = txtCustomerID.Text.Split(';');
                    for (int i = 0; i < str.Length; i++)
                    {
                        str[i] = str[i].Trim();
                        tsql = tsql + $@"and pri_customerid like '%{str[i].Trim()}%' ";
                        tsql32 = tsql32 + $@"and aa.pri_customerid like '%{str[i].Trim()}%' ";
                    }
                }
                else
                {
                    tsql = tsql+ $@"and pri_customerid like '%{txtCustomerID.Text.Trim()}%' ";
                    tsql32 = tsql32 + $@"and aa.pri_customerid like '%{txtCustomerID.Text.Trim()}%' ";
                }
            }
            strSQL = $@"select distinct aa.pri_assy '線路',
                                        ab.pri_perqty '加工分',
                                        ac.pri_perqty '不良率',
                                        aa.pri_customer '客戶',
                                        aa.pri_customerid'客號',
                                        aa.pri_length '線長',
                                        odi_czf '參照法'
                        from            pri as aa
                        left join       odi
                        on              odi_customerid=pri_customerid
                        left join
                                        (
                                                select *
                                                from   pri
                                                where  pri_part like '加工/分%'
                                                and    pri_newcostchk like 'N%') as ab
                        on              ab.pri_customerid=aa.pri_customerid
                        left join
                                        (
                                                select *
                                                from   pri
                                                where  pri_part like '不良%'
                                                and    pri_newcostchk like 'N%') as ac
                        on              ac.pri_customerid=aa.pri_customerid
                        where           aa.pri_newcostchk like 'N%'  ";
            strSQL = strSQL + tsql31 + tsql32  + tsql33 + "order by aa.pri_assy, aa.pri_customer, aa.pri_customerid ";
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
                MessageBox.Show("查不到資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Cursor = Cursors.Default;//滑鼠還原預設
        }

        private void txtLine_TextChanged(object sender, EventArgs e)
        {
            //if(txtLine.Text=="")
            //{
            //    btnAdjust.Enabled = false;
            //    return;
            //}
            //else
            //{
                
            //    if(dgvData.Rows.Count>0)
            //    {
            //        btnAdjust.Enabled = true;
            //    } 
            //}
        }

        private void txtLine_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtM.Text = "";
                cboItem.Focus();
            }
        }

        private void txtLine_Leave(object sender, EventArgs e)
        {
            getData();
            if (dgvData.Rows.Count > 0)
            {
                btnAdjust.Enabled = true;
            }
        }

        private void cboItem_TextChanged(object sender, EventArgs e)
        {
            txtM.Text = "";
            txtH.Text = "";
            gbH.Visible = false;
            gbM.Visible = false;
        }

        private void btnAdjust_Click(object sender, EventArgs e)    
        {
            //調整規範
            try
            {
                frmWorking_Adjust_Spec frmWorking_Adjust_Spec = new frmWorking_Adjust_Spec();
                frmWorking_Adjust_Spec.ShowInTaskbar = false;//圖示不顯示在工作列
                frmWorking_Adjust_Spec.ShowInTaskbar = false;
                frmWorking_Adjust_Spec.rstrItem = cboItem.Text;
                frmWorking_Adjust_Spec.rstrLine= txtLine.Text;
                frmWorking_Adjust_Spec.ShowDialog();
                if(rstrID!="")
                {
                    btnSave.Enabled = true;
                    if(cboItem.Text== "加工/分")
                    {
                        gbM.Visible = true;
                        gbH.Visible = true;
                        gbM.Text = "線長區間：" + rstrID;
                        lblItem.Text = rstrItem+ "調整為：";
                        txtM.Text = rstrQty;
                        getData();
                    }
                    else
                    {
                        gbM.Visible = true;
                        gbH.Visible = false;
                        gbM.Text = rstrID+"類";
                        lblItem.Text =  "不良率調整為：";
                        txtM.Text = rstrQty;
                        getData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnAdjust_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnInq.Focus();
            }
        }

        private void txtCustomerID_Leave(object sender, EventArgs e)
        {
            getData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                clsGlobal.ExportExcel(ttype+cboItem.Text, dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //調整更新
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                if (txtLine.Text=="")
                {
                    MessageBox.Show("線路不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLine.Focus();    
                    return;
                }
                if (txtM.Text == "")
                {
                    MessageBox.Show("調整數值不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtM.Focus();
                    return;
                }
                if (txtH.Text == "" && cboItem.Text!="不良率")
                {
                    MessageBox.Show("調整時數不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtH.Focus();
                    return;
                }

                if (MessageBox.Show("你確定要更新報價嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                if (cboItem.Text== "不良率")
                {
                    strSQL = $@"update pri
                                set    pri_perqty = {txtM.Text},
                                       pri_perqtycal = ''
                                from   pri
                                where  pri_part like '{cboItem.Text}%'
                                       and pri_assy = '{txtLine.Text.Trim()}'
                                       and pri_newcostchk like 'N%' "+ tsql;
                    clsDB.Execute(strSQL);

                    strSQL = $@"update odi
                                set    odi_priqty04 = {txtM.Text} * 0.01
                                from   odi
                                       left join pri
                                              on pri_customerid = odi_customerid
                                where  odi_line = '{txtLine.Text.Trim()}'
                                       and pri_newcostchk like 'N%' " + tsql;
                    clsDB.Execute(strSQL);
                }
                else
                {
                    Single sng =Convert.ToSingle(txtH.Text)* Convert.ToSingle(txtM.Text);
                    strSQL = $@"update pri
                                set    pri_perqty = {sng.ToString("0.######")},
                                       pri_perqtycal = '{txtH.Text.Trim()}*{txtM.Text.Trim()}'
                                from   pri
                                where  pri_part like '{cboItem.Text}%'
                                       and pri_assy = '{txtLine.Text.Trim()}'
                                       and pri_newcostchk like 'N%'" + tsql+ tsql1;
                    clsDB.Execute(strSQL);
                }

                strSQL = $@"update pub set pub_aimlocked = 1";
                clsDB.Execute(strSQL);
                strSQL = $@"exec updatepriclcost";
                clsDB.Execute(strSQL);

                if (cboItem.Text == "不良率")
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
                                        prb_newcostchk)
                                select distinct pri_customer,
                                                Getdate(),
                                                pri_ll,
                                                pri_pricost,
                                                pri_hopelprice,
                                                pri_customerid,
                                                pri_length,
                                                pri_wg,
                                                '{clsGlobal.strG_User}調整不良率',
                                                pri_newcostchk
                                from   pri
                                where  pri_part like '{cboItem.Text}%'
                                       and pri_assy = '{txtLine.Text.Trim()}'
                                       and pri_newcostchk like 'N%'" + tsql;
                    clsDB.Execute(strSQL);
                }
                else
                {
                    Single sng = Convert.ToSingle(txtH.Text) * Convert.ToSingle(txtM.Text);
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
                                                Getdate(),
                                                pri_ll,
                                                pri_pricost,
                                                pri_hopelprice,
                                                pri_customerid,
                                                pri_length,
                                                pri_wg,
                                                '{clsGlobal.strG_User}調整加工分',
                                                pri_newcostchk
                                from   pri
                                where  pri_part like '{cboItem.Text}%'
                                       and pri_assy = '{txtLine.Text.Trim()}'
                                       and pri_newcostchk like 'N%'" + tsql + tsql1;
                    clsDB.Execute(strSQL);
                }
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show("更新完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getData();
                txtLine.Focus();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                if (dgvData.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvData.DataSource;
                    dt.Rows.Clear();
                    dgvData.DataSource = dt;
                }
                lblCount.Text = "資料筆數：0";
                txtCustomer.Text = "";
                txtLine.Text = "";
                txtM.Text = "";
                txtH.Text = "";
                txtCustomerID.Text = "";
                gbH.Visible = false;
                gbM.Visible = false;
                ttype = "";
                tsql = "";
                tsql1 = "";
                tsql2 = "";
                tsql31 = "";
                tsql32 = "";
                tsql33 = "";
                radioAll.Checked = true;
                btnAdjust.Enabled = false;
                btnSave.Enabled = false;
                cboItem.Text = "加工/分";
                txtLine.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
