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
    public partial class frmBOMPrice_Copy_Material : Form
    {
        public static string rstrID = "";  //由frmBOMPrice傳的ID
        public static string rstrName = "";  //由frmBOMPrice傳的ID
        public frmBOMPrice_Copy_Material()
        {
            InitializeComponent();
        }

        private void frmBOMPrice_Copy_Material_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                lblOldID.Text = rstrID;
                txtID.Text = rstrID;
                lblOldName.Text = rstrName;
                txtName.Text = rstrName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOMPrice_Special_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)    //取消
        {
            //取消
            try
            {
                frmBOMPrice.rstrButton = "Cancle";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCancel_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //確認
            try
            {
                if (txtID.Text == "")
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                if(radioMaterial.Checked)   //複製材料單
                {
                    if(txtID.Text!="")
                    {
                        strSQL = $@"select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_date
                                    from   pri
                                    where  pri_customerid = '{txtID.Text.Trim()}'
                                           and pri_assy = '{txtName.Text.Trim()}'
                                           and pri_newcostchk like 'Y%' ";
                        dt = clsDB.sql_select_dt(strSQL);   
                        if(dt.Rows.Count>0)
                        {
                            MessageBox.Show("此新材料名和品號已存在,請檢查!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            frmBOMPrice.rstrID=txtID.Text.Trim();
                            frmBOMPrice.rstrName=txtName.Text.Trim();
                            frmBOMPrice.rstrButton = "radioMaterial";
                            this.Close();
                        }
                    }
                }
                else
                {
                    if (txtID.Text != "")
                    {
                        strSQL = $@"select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_date
                                    from   pri
                                    where  pri_customerid = '{txtID.Text.Trim()}'
                                            and pri_newcostchk like 'N%' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            if (MessageBox.Show("複製會覆蓋原報價單組成,您要繼續嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                frmBOMPrice.rstrID = dt.Rows[0]["pri_customerid"].ToString();
                                frmBOMPrice.rstrName = dt.Rows[0]["pri_assy"].ToString();
                                frmBOMPrice.rstrDate =Convert.ToDateTime( dt.Rows[0]["pri_date"]).ToString("yyyy/MM/dd");
                                frmBOMPrice.rstrButton = "radioMaterial_Quotation";
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("無此客號,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtID.Focus();
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnOK_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (clsGlobal.StrLength(txtID.Text) > 0)
            {
                lblLength.Text = clsGlobal.StrLength(txtID.Text).ToString();
            }
            else
            {
                lblLength.Text = "";
            }
        }

        private void radioQuotation_Material_CheckedChanged(object sender, EventArgs e)
        {
            if(radioQuotation_Material.Checked)
            {
                lblOldID.Visible = false;
                lblOldID_.Visible = false;
                lblOldName.Visible = false;
                lblOldName_.Visible = false;
                lblNewName_.Visible = false;
                txtName.Visible = false;
            }
        }

        private void radioMaterial_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMaterial.Checked)
            {
                lblOldID.Visible = true;
                lblOldID_.Visible = true;
                lblOldName.Visible = true;
                lblOldName_.Visible = true;
                lblNewName_.Visible = true;
                txtName.Visible = true;
            }
        }
    }
}
