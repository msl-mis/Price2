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
    public partial class frmRefer_Inq_Customer : Form
    {
        string strCustomerID = "";  //grid客號
        public frmRefer_Inq_Customer()
        {
            InitializeComponent();
        }

        private void frmRefer_Inq_Customer_Load(object sender, EventArgs e)
        {

        }

        private void frmRefer_Inq_Customer_Activated(object sender, EventArgs e)
        {
            
        }

        private void btnInq_Click(object sender, EventArgs e)   //查詢
        {
            //查詢
            try
            {
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                strCustomerID = ""; //清除grid客號
                if (txtDate_E.Text != "" && txtDate_S.Text != "")
                {
                    if (Convert.ToDateTime(txtDate_S.Text) > Convert.ToDateTime(txtDate_E.Text))
                    {
                        MessageBox.Show("起始日期不可以大於結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        return;
                    }
                }

                if (txtDate_E.Text != "" && txtDate_S.Text == "")
                {
                    MessageBox.Show("請選擇起始日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                if (txtDate_E.Text == "" && txtDate_S.Text != "")
                {
                    MessageBox.Show("請選擇結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                string strSQL = "";
                string strSQLwhere = "";
                DataTable dt = new DataTable();
                if (txtID.Text!="")
                {
                    if(txtID.Text.IndexOf(";")>-1)
                    {
                        string[] tmp = txtID.Text.Split(';');
                        for(int i = 0; i < tmp.Length; i++)
                        {
                            strSQLwhere = strSQLwhere + $@" and odi_customerid like N'%{tmp[i].Trim()}%'";
                        }
                    }
                    else
                    {
                        strSQLwhere =$@" and odi_customerid like N'%{txtID.Text.Trim()}%'";
                    }
                }
                else
                {
                    strSQLwhere = $@" and odi_customerid like N'%{txtID.Text.Trim()}%'";
                }
                if(chkNoQuote.Checked)
                {
                    strSQLwhere= strSQLwhere + $@" and odi_customerid not in (select distinct pri_customerid from pri)";
                }
                if(txtDate_S.Text!="")
                {
                    strSQLwhere = strSQLwhere + $@" and odi_adddate>='{txtDate_S.Text} 00:00:00' and odi_adddate<='{txtDate_E.Text} 23:59:59'";
                }
                if(chkOutsourcing.Checked) 
                {
                    strSQL= $@"select odi_customerid '客號', odi_czf '參照法', odi_line '線路', odi_customer '客戶' from odi where substring(odi_line,1,1)='M' " 
                        + (txtName.Text == "" ? " and odi_customer<>'dsfsd'" : $@" and odi_customer ='{txtName.Text.Trim()}' ") 
                        + (chkDeal.Checked==false ? "" : " and odi_customerid in (select distinct ord_assy from ord) ") 
                        + (txtLine.Text=="" ? "" : $@" and odi_line='{txtLine.Text.Trim()}' ")
                        + strSQLwhere;
                }
                else
                {
                    strSQL = $@"select odi_customerid '客號', odi_czf '參照法', odi_line '線路', odi_customer '客戶' from odi where "
                        + (txtName.Text == "" ? " odi_customer<>'dsfsd'" : $@" odi_customer ='{txtName.Text.Trim()}'")
                        + (chkDeal.Checked == false ? "" : " and odi_customerid in (select distinct ord_assy from ord)")
                        + (txtLine.Text == "" ? "" : $@" and odi_line='{txtLine.Text.Trim()}'")
                        + strSQLwhere;
                }
                dt=clsDB.sql_select_dt(strSQL);
                dgvData.DataSource=dt;
                lblCount.Text=dt.Rows.Count.ToString();
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnInq.PerformClick();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInq.PerformClick();
            }
        }

        private void txtLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnInq.PerformClick();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)    //匯出
        {
            //匯出
            try
            {
                //clsGlobal clsGlobal = new clsGlobal();
                clsGlobal.ExportExcel("訂單產品編號清單", dgvData);
                //clsGlobal.ExportCsv( dgvData);
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
                lblCount.Text = "0";                //查詢筆數
                txtID.Text = "";                    //客號
                txtName.Text = "";                  //客戶
                txtLine.Text = "";                  //線路
                txtDate_S.Text = "";                //起始日期
                txtDate_E.Text = "";                //結束日期
                chkOutsourcing.Checked = false;     //外購
                chkDeal.Checked = false;            //成交
                chkNoQuote.Checked = false;         //無報價
                strCustomerID = "";                 //grid客號
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

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                frmRefer.strID = dgvData.Rows[e.RowIndex].Cells["客號"].Value.ToString();
                this.Close();
            }  
        }

        private void btnDelete_Click(object sender, EventArgs e)    //刪除
        {
            //刪除
            try
            {
                if (MessageBox.Show(this, "你確定要刪除這個參照法嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                string strSQL = "";
                string strSQLwhere = "";
                DataTable dt = new DataTable();
                if (txtID.Text != "")
                {
                    if (txtID.Text.IndexOf(";") > -1)
                    {
                        string[] tmp = txtID.Text.Split(';');
                        for (int i = 0; i < tmp.Length; i++)
                        {
                            strSQLwhere = strSQLwhere + $@" and odi_customerid like N'%{tmp[i].Trim()}%'";
                        }
                    }
                    else
                    {
                        strSQLwhere = $@" and odi_customerid like N'%{txtID.Text.Trim()}%'";
                    }
                }
                else
                {
                    strSQLwhere = $@" and odi_customerid like N'%{txtID.Text.Trim()}%'";
                }
                if (chkNoQuote.Checked)
                {
                    strSQLwhere = strSQLwhere + $@" and odi_customerid not in (select distinct pri_customerid from pri)";
                }
                if (txtDate_S.Text != "")
                {
                    strSQLwhere = strSQLwhere + $@" and odi_adddate>='{txtDate_S.Text} 00:00:00' and odi_adddate<='{txtDate_E.Text} 23:59:59'";
                }
                if (chkOutsourcing.Checked)
                {
                    strSQLwhere = $@" and substring(odi_line,1,1)='M' "
                        + (txtName.Text == "" ? "" : $@" and odi_customer ='{txtName.Text.Trim()}' ")
                        + (chkDeal.Checked == false ? "" : " and odi_customerid in (select distinct ord_assy from ord) ")
                        + (txtLine.Text == "" ? "" : $@" and odi_line='{txtLine.Text.Trim()}' ")
                        + strSQLwhere;
                }
                else
                {
                    strSQLwhere = (txtName.Text == "" ? "" : $@" odi_customer ='{txtName.Text.Trim()}'")
                        + (chkDeal.Checked == false ? "" : " and odi_customerid in (select distinct ord_assy from ord)")
                        + (txtLine.Text == "" ? "" : $@" and odi_line='{txtLine.Text.Trim()}'")
                        + strSQLwhere;
                }
                strSQL = $@"delete odi where odi_customerid not in (select distinct pri_customerid from pri) and odi_customerid not in (select distinct ord_assy from ord) and odi_customerid='{strCustomerID}'" + strSQLwhere;
                clsDB.Execute(strSQL);
                MessageBox.Show("刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnInq.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                frmRefer.strID = dgvData.Rows[e.RowIndex].Cells["客號"].Value.ToString();
            }
        }
    }
}
