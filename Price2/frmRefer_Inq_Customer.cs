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
    public partial class frmRefer_Inq_Customer : Form
    {
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
                    strSQL= $@"select odi_customerid'客號',odi_czf'參照法',odi_line'線路',odi_customer'客戶' from odi where substring(odi_line,1,1)='M' " 
                        + (txtName.Text == "" ? " and odi_customer<>'dsfsd'" : $@" and odi_customer ='{txtName.Text.Trim()}' ") 
                        + (chkDeal.Checked==false ? "" : " and odi_customerid in (select distinct ord_assy from ord) ") 
                        + (txtLine.Text=="" ? "" : $@" and odi_line='{txtLine.Text.Trim()}' ")
                        + strSQLwhere;
                }
                else
                {
                    strSQL = $@"select odi_customerid'客號',odi_czf'參照法',odi_line'線路',odi_customer'客戶' from odi where "
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
    }
}
