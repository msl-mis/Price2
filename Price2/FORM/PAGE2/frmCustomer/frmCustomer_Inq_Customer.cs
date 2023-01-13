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
    public partial class frmCustomer_Inq_Customer : Form
    {
        public frmCustomer_Inq_Customer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Inq_Customer_Activated(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                cboYw.Items.Clear();
                cboYw.Items.Add("(ALL)");
                String strSQL = $@"select distinct cus_yw from cus where cus_yw <> ''";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboYw.Items.Add(dt.Rows[i]["cus_yw"].ToString());
                    }
                }
                cboYw.Text = "(ALL)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmCustomer_Inq_Customer_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) //結束
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

        private void btnInq_Click(object sender, EventArgs e)   //搜尋
        {
            //搜尋
            try
            {
                string strSQL = "";
                DataTable dt;
                strSQL = $@"select cus_id ,cus_name ,cus_contact ,cus_tel ,cus_yw from cus where ";
                //IIf(Text1.Text = "4", " (cus_id='4' or substring(cus_id,1,2)='4-')", IIf(Text1.Text = "4-", " substring(cus_id,1,2)='4-'", " cus_id like '%" & RTrim(Text1.Text) & "%'"))
                string strTmp1 = "";
                if (txtCustomerID.Text == "4")
                {
                    strTmp1 = " (cus_id='4' or substring(cus_id,1,2)='4-')";
                }
                else
                {
                    if (txtCustomerID.Text == "4-")
                    {
                        strTmp1 = " substring(cus_id,1,2)='4-'";
                    }
                    else
                    {
                        strTmp1 = " cus_id like '%" + txtCustomerID.Text.Trim() + "%'";
                    }
                }
                strSQL = strSQL + strTmp1;
                //IIf(Combo3.Text = "(ALL)", "", " and cus_yw='" & RTrim(Combo3.Text) & "'") & " order by cus_id"
                string strTmp2 = "";
                if (cboYw.Text == "(ALL)")
                {
                    strTmp2 = " order by cus_id";
                }
                else
                {
                    strTmp2 = " and cus_yw='" + cboYw.Text.Trim() + "'" + " order by cus_id";
                }
                strSQL = strSQL + strTmp2;
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            //clsGlobal clsGlobal = new clsGlobal();

            clsGlobal.ExportExcel("選擇客戶", dgvData);
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                frmCustomer.strCustomerID = dgvData.Rows[e.RowIndex].Cells["cus_id"].Value.ToString();
                this.Close();
            }
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnInq.PerformClick();  
            }
        }
    }
}
