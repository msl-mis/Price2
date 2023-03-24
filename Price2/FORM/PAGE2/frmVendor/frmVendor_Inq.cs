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
    public partial class frmVendor_Inq : Form
    {
        public static string strWhoCall;    //傳入的form
        public frmVendor_Inq()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) //結束
        {
            //結束
            try
            {
                //frmMain frmMain = (frmMain)this.MdiParent;
                //frmMain.gbMain.Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-_btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Click(object sender, EventArgs e)   //搜尋
        {
            //搜尋
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                string strWhere = "";
                strWhere = strWhere + (txtID.Text == "" ? "" : $@"and ven_id like '%{txtID.Text}%'");
                strWhere = strWhere + (txtName.Text == "" ? "" : $@"and ven_shortname like '%{txtName.Text}%'");
                strWhere = strWhere + (cboClass.Text == "" ? "" : $@"and ven_maxtype like '%{cboClass.Text}%'");
                strWhere = strWhere + (cboItem.Text == "" ? "" : $@"and ven_type like '%{cboItem.Text}%'");
                strWhere = strWhere + (txtName_TW.Text == "" ? "" : $@"and ven_twname like '%{txtName_TW.Text}%'");
                strWhere = strWhere + (txtName_CN.Text == "" ? "" : $@"and ven_dlname like '%{txtName_CN.Text}%'");
                strWhere = strWhere + (txtPhone_TW.Text == "" ? "" : $@"and ven_twtel1 like '%{txtPhone_TW.Text}%'");
                strWhere = strWhere + (txtPhone_CN.Text == "" ? "" : $@"and ven_dltel1 like '%{txtPhone_CN.Text}%'");
                strWhere = strWhere + (txtContact_TW.Text == "" ? "" : $@"and ven_twcontact1 like '%{txtContact_TW.Text}%'");
                strWhere = strWhere + (txtContact_CN.Text == "" ? "" : $@"and ven_dlcontact like '%{txtContact_CN.Text}%'");
                strSQL = $@"select ven_id         廠號,
                                   ven_shortname  廠商,
                                   ven_type       項目,
                                   ven_twname     台灣名稱,
                                   ven_dlname     大陸名稱,
                                   ven_twtel1     台灣電話,
                                   ven_dltel1     大陸電話, 
                                   ven_twcontact1 台灣聯絡人,
                                   ven_dlcontact  大陸聯絡人
                            from   ven
                            where  ven_id != '' ";
                strSQL = strSQL + strWhere;
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

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select vent_option from vent where vent_type = '{cboClass.Text} '";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                cboItem.Text = "";
                cboItem.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cboItem.Items.Add(dt.Rows[i]["vent_option"].ToString().Trim());
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e) //清除
        {
            //清除
            try
            {
                if (dgvData.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)dgvData.DataSource;
                    dt.Rows.Clear();
                    dgvData.DataSource = dt;
                }
                txtID.Text = "";
                txtName.Text = "";
                txtName_TW.Text = "";
                txtName_CN.Text = "";
                txtPhone_TW.Text = "";
                txtPhone_TW.Text = "";
                txtContact_TW.Text = "";
                txtContact_CN.Text = "";
                cboClass.Text = "";
                cboItem.Text = "";
                cboItem.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)    //匯出
        {
            //匯出
            try
            {
                clsGlobal.ExportExcel("廠商查詢", dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >=0)
            {
                if(strWhoCall=="frmVendor")
                {
                    frmVendor.rstrID=dgvData.Rows[e.RowIndex].Cells["廠號"].Value.ToString();
                    this.Close();
                }
                if (strWhoCall == "frmProduct")
                {
                    frmProduct.rstrVendorID = dgvData.Rows[e.RowIndex].Cells["廠號"].Value.ToString();
                    frmProduct.rstrVendorName = dgvData.Rows[e.RowIndex].Cells["廠商"].Value.ToString();
                    this.Close();
                }
            }
        }
    }
}
