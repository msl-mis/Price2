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
    public partial class frmInq_Material_Status : Form
    {
        public static string rstrMaterialID = "";
        public frmInq_Material_Status()
        {
            InitializeComponent();
        }

        private void btnInq_Bom_Click(object sender, EventArgs e)
        {
            //查詢BOM產品結構資料
            try
            {
                frmBOM frmBOM = new frmBOM();
                frmBOM.ShowInTaskbar = false;//圖示不顯示在工作列
                frmBOM.blnInq_Material = true;
                frmBOM.ShowDialog();
                if (rstrMaterialID != "")
                {
                    txtMaterialID.Text = rstrMaterialID;
                    rstrMaterialID = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnBOM_Inq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //訂單日期
                txtDate_S.Text = "";
                txtDate_E.Text = "";
                //客戶
                txtCustomer.Text = "";
                //第四層材料名稱
                txtMaterialID.Text = "";

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
                clsGlobal.ExportExcel("查詢材料名使用情形", dgvData);
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
                if (txtDate_E.Text != "" && txtDate_S.Text != "")
                {
                    if (Convert.ToDateTime(txtDate_S.Text) > Convert.ToDateTime(txtDate_E.Text))
                    {
                        MessageBox.Show("起始日期不可以大於結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        return;
                    }
                }
                string strSQL = "";
                string strSQL2 = "";

                DataTable dt = new DataTable();

                strSQL = $@"select a.ord_customer'客戶',
                                   a.ord_orderid'訂單編號',
                                   dbo.Formatstr(Sum(a.ord_qty),0)'訂單數',
                                   a.odh_orderdate'訂單日期'
                            from   (
                                                   select distinct ord_customer,
                                                                   ord_orderid,
                                                                   ord_assy,
                                                                   Round(ord_qty*pri_perqty,2) as ord_qty,
                                                                   odh_orderdate
                                                   from            ord,
                                                                   ap3,
                                                                   odi,
                                                                   pri,
                                                                   odh,
                                                                   asp
                                                   where           odh_orderid=ord_orderid
                                                   and             ord_assy=odi_customerid
                                                   and             ord_assy=pri_customerid
                                                   and             ap3_part=asp_id
                                                   and             pri_part=ap3_part
                                                   and             ap3_part = '{txtMaterialID.Text}' ";

                strSQL2 = $@") as a group by ord_customer, ord_orderid, odh_orderdate order by ord_customer, ord_orderid ";


                strSQL = strSQL + Get_strWhere() + strSQL2;
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    lblCount.Text = "共 " + dt.Rows.Count.ToString() + " 筆";

                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
                else
                {
                    dgvData.DataSource = dt;
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblCount.Text = "共 0 筆";
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }


                strSQL = $@"select dbo.Formatstr(Isnull(Sum(ord_qty),0),0) as ordqty
                            from   (
                                                    select distinct ord_customer,
                                                                    ord_orderid,
                                                                    ord_assy,
                                                                    Round(ord_qty*pri_perqty,2) as ord_qty,
                                                                    odh_orderdate
                                                    from            ord,
                                                                    ap3,
                                                                    asp,
                                                                    odi,
                                                                    pri,
                                                                    odh
                                                    where           odh_orderid=ord_orderid
                                                    and             ord_assy=odi_customerid
                                                    and             ord_assy=pri_customerid
                                                    and             pri_part=ap3_part
                                                    and             pri_part=asp_id
                                                    and             ap3_part = '{txtMaterialID.Text}' ";

                strSQL2 = $@") as a ";


                strSQL = strSQL + Get_strWhere() + strSQL2;
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    lblQty.Text = "Total：" + dt.Rows[0]["ordqty"].ToString();
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
                else
                {
                    lblQty.Text = "Total：0";
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Get_strWhere()
        {
            string strWhere = "";

            //訂單日期
            strWhere = strWhere + (txtDate_S.Text == "" ? "" : $@"and odh_newdate between '{txtDate_S.Text}' and '{txtDate_E.Text}' ");
            //客戶
            if (txtCustomer.Text == "4-")
            {
                strWhere = strWhere + $@"and odh_customer like '%4-%' ";
            }
            else if (txtCustomer.Text == "4")
            {
                strWhere = strWhere + $@"and (odh_customer ='4' or substring(odh_customer, 1, 2) = '4-') ";
            }
            else
            {
                strWhere = strWhere + (txtCustomer.Text == "" ? "" : $@"and odh_customer = '{txtCustomer.Text.Trim()}' ");
            }
            


            return strWhere;
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
