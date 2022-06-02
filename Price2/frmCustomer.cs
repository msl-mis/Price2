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
    public partial class frmCustomer : Form
    {
        public static string strCustomerID = "";
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void cboCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCountryCode.Text=cboCountryCode.Items[cboCountry.SelectedIndex].ToString();
        }

        private void cboCountryCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCountry.Text = cboCountry.Items[cboCountryCode.SelectedIndex].ToString();
        }

        private void frmCustomer_Activated(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                lblYwName.Text = "";
                cboCode.Items.Clear();
                //cboCountry.Items.Clear();
                //cboCountryCode.Items.Clear();
                cboYw.Items.Clear();
                string strSQL = "";
                DataTable dt;
                //業務：
                strSQL = $@"select distinct pas_ywcode,
                                            pas_name
                            from   pas
                            where  pas_ywcode <> '' ";
                dt= clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboYw.Items.Add(dt.Rows[i]["pas_ywcode"]);
                        cboYwName.Items.Add(dt.Rows[i]["pas_name"]);
                    }
                }
                //代碼：
                strSQL = $@"select distinct czc_zmtype
                            from   czc
                            where  czc_zmtype <> ''";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboCode.Items.Add(dt.Rows[i]["czc_zmtype"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmCustomer_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) //結束
        {
            //結束
            try
            {
                frmMain frmMain = (frmMain)this.MdiParent;
                frmMain.gbMain.Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-_btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) //清除
        {
            //清除
            try
            {
                txtCustomerID.Text = "";
                txtCustomerInfo.Text = "";
                txtTel1.Text = "";
                txtFax1.Text = "";
                txtEmail.Text = "";
                txtMark.Text = "";
                txtDigiwinID.Text = "";
                txtShippingMark.Text = "";
                txtSideMark.Text = "";
                txtTel2.Text = "";
                txtFax2.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                txtShortName.Text = "";
                txtWeb.Text = "";
                cboPaymentTerms.Text = "";
                cboCountry.Text = "";
                cboYw.Text = "";
                cboCountryCode.Text = "";
                cboTitle.Text = "MSL";
                lblSaveDate.Text = "";
                lblUser.Text = "";
                txtPipeline.Text = "";
                txtStartDate.Text = "";
                cboCode.Text = "A";
                txtCustomerID.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCustomerID_Validated(object sender, EventArgs e)
        {
            //當客戶編號失去駐點;做查詢動作
            getData();  //取得與客戶編號相關資料
        }

        private void getData()  //取得與客戶編號相關資料
        {
            //取得與客戶編號相關資料
            try
            {
                if (txtCustomerID.Text == "")
                {
                    return;
                }
                String strSQL = $@"select *
                                    from   cus
                                           left join pas
                                                  on pas_ywcode = cus_yw
                                                     and pas_ywcode <> ''
                                           left join czc
                                                  on czc_customer = cus_id
                                                     and czc_zmtype = cus_zmtype
                                    where  cus_id = '{txtCustomerID.Text.Trim()}' ";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    //txtCustomerID.Text = dt.Rows[0]["cus_name"].ToString();
                    txtCustomerInfo.Text = dt.Rows[0]["cus_name"].ToString();
                    txtTel1.Text = dt.Rows[0]["cus_tel"].ToString();
                    txtFax1.Text = dt.Rows[0]["cus_fax"].ToString();
                    txtEmail.Text = dt.Rows[0]["cus_email"].ToString();
                    //txtMark.Text = dt.Rows[0]["cus_name"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["cus_zm1"].ToString()))
                    {
                        txtMark.Text = "";
                    }
                    else
                    {
                        txtMark.Text = dt.Rows[0]["cus_zm1"].ToString();
                    }
                    txtDigiwinID.Text = dt.Rows[0]["DS_CUS_NO"].ToString();
                    //txtShippingMark.Text = dt.Rows[0]["cus_name"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["cus_zm3"].ToString()))
                    {
                        txtShippingMark.Text = "";
                    }
                    else
                    {
                        txtShippingMark.Text = dt.Rows[0]["cus_zm3"].ToString();
                    }
                    //txtSideMark.Text = dt.Rows[0]["cus_name"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["cus_cm"].ToString()))
                    {
                        txtSideMark.Text = "";
                    }
                    else
                    {
                        txtSideMark.Text = dt.Rows[0]["cus_cm"].ToString();
                    }
                    txtTel2.Text = dt.Rows[0]["cus_tel2"].ToString();
                    txtFax2.Text = dt.Rows[0]["cus_fax2"].ToString();
                    txtAddress.Text = dt.Rows[0]["cus_cusaddress"].ToString();
                    txtContact.Text = dt.Rows[0]["cus_cuscontact"].ToString();
                    txtShortName.Text = dt.Rows[0]["cus_shortname"].ToString();
                    txtWeb.Text = dt.Rows[0]["cus_website"].ToString();
                    cboPaymentTerms.Text = dt.Rows[0]["cus_fkfs"].ToString();
                    cboCountry.Text = dt.Rows[0]["cus_gb"].ToString();
                    cboYw.Text = dt.Rows[0]["cus_yw"].ToString();
                    cboCountryCode.Text = dt.Rows[0]["cus_telgh"].ToString();
                    //cboTitle.Text = "MSL";
                    if (string.IsNullOrEmpty(dt.Rows[0]["cus_pihead"].ToString()))
                    {
                        cboTitle.Text = "";
                    }
                    else
                    {
                        cboTitle.Text = dt.Rows[0]["cus_pihead"].ToString();
                    }
                    lblSaveDate.Text = dt.Rows[0]["cus_adddate"].ToString();
                    lblUser.Text = dt.Rows[0]["cus_user"].ToString();
                    txtPipeline.Text = dt.Rows[0]["cus_lsgd"].ToString();
                    txtStartDate.Text = dt.Rows[0]["cus_begindate"].ToString();
                    if (dt.Rows[0]["cus_zmtype"].ToString() == "")
                    {
                        cboCode.Text = "A";
                    }
                    else
                    {
                        cboCode.Text = dt.Rows[0]["cus_zmtype"].ToString();
                    }
                    //txtCustomerID.Focus();
                }
                else
                {
                    if (MessageBox.Show(this, "你要建立一個新的客戶資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtCustomerInfo.Text = "";
                        txtTel1.Text = "";
                        txtFax1.Text = "";
                        txtEmail.Text = "";
                        txtMark.Text = "";
                        txtDigiwinID.Text = "";
                        txtShippingMark.Text = "";
                        txtSideMark.Text = "";
                        txtTel2.Text = "";
                        txtFax2.Text = "";
                        txtAddress.Text = "";
                        txtContact.Text = "";
                        txtShortName.Text = "";
                        txtWeb.Text = "";
                        cboPaymentTerms.Text = "";
                        cboCountry.Text = "";
                        cboYw.Text = "";
                        cboCountryCode.Text = "";
                        cboTitle.Text = "MSL";
                        lblSaveDate.Text = "";
                        lblUser.Text = "";
                        txtPipeline.Text = "";
                        txtStartDate.Text = "";
                        cboCode.Text = "A";
                        txtCustomerInfo.Focus();
                    }
                    else
                    {
                        //btnClear.PerformClick();
                        btnClear_Click(null,null);
                        txtCustomerID.Text = "";
                        txtCustomerID.Focus();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-txtCustomerID_Validated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)  //複製
        {
            //複製
            try
            {
                InputBox input = new InputBox();
                input.lblInfo.Text = "請輸入你要複製的新客戶編號:";
                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (input.GetMsg() != "")
                    {
                        String strSQL = $@"select *
                                            from   cus
                                            where  cus_id = '{input.GetMsg()}' ";
                        DataTable dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("你不能複製到這個客戶資料中,這個客戶已經存在!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        strSQL = $@"insert cus
                                           (cus_id,
                                            cus_name,
                                            cus_tel,
                                            cus_fax,
                                            cus_contact,
                                            cus_email,
                                            cus_address,
                                            cus_zm1,
                                            cus_zm2,
                                            cus_zm3,
                                            cus_cm,
                                            cus_tel2,
                                            cus_fax2,
                                            cus_email2,
                                            cus_cusaddress,
                                            cus_cuscontact,
                                            cus_zmtype,
                                            cus_shortname,
                                            cus_website,
                                            cus_user,
                                            cus_gb,
                                            cus_telgh,
                                            cus_fkfs,
                                            cus_yw,
                                            cus_lsgd,
                                            cus_begindate,
                                            DS_CUS_NO)
                                    select '{input.GetMsg()}',
                                           cus_name,
                                           cus_tel,
                                           cus_fax,
                                           cus_contact,
                                           cus_email,
                                           cus_address,
                                           cus_zm1,
                                           cus_zm2,
                                           cus_zm3,
                                           cus_cm,
                                           cus_tel2,
                                           cus_fax2,
                                           cus_email2,
                                           cus_cusaddress,
                                           cus_cuscontact,
                                           cus_zmtype,
                                           cus_shortname,
                                           cus_website,
                                           cus_user,
                                           cus_gb,
                                           cus_telgh,
                                           cus_fkfs,
                                           cus_yw,
                                           cus_lsgd,
                                           cus_begindate,
                                           DS_CUS_NO
                                    from   cus
                                    where  cus_id = '{txtCustomerID.Text.Trim()}' ";
                        clsDB.Execute(strSQL);

                        strSQL = $@"delete czc
                                    where  czc_customer = '{input.GetMsg()}' ";
                        clsDB.Execute(strSQL);

                        strSQL = $@"insert czc
                                           (czc_customer,
                                            czc_zmtype,
                                            czc_zm1,
                                            czc_zm3,
                                            czc_cm,
                                            czc_adddate)
                                    select '{input.GetMsg()}',
                                           czc_zmtype,
                                           czc_zm1,
                                           czc_zm3,
                                           czc_cm,
                                           czc_adddate
                                    from   czc
                                    where  czc_customer = '{txtCustomerID.Text.Trim()}' ";
                        clsDB.Execute(strSQL);

                        MessageBox.Show("複製完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCustomerID.Text = input.GetMsg();
                        txtCustomerID.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCopy_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)    //刪除
        {
            //刪除
            try
            {
                String strSQL = "";
                DataTable dt;
                if (txtCustomerID.Text=="")
                {
                    MessageBox.Show("請輸入欲刪除的客戶編號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustomerID.Focus();
                    return;
                }
                strSQL = $@"select odh_customer
                            from   odh
                            where  odh_customer = '{txtCustomerID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("這個客戶不能刪除,因為這個客戶已經有了工單資料了!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustomerID.Focus();
                    return;
                }
                strSQL = $@"select pri_customer
                            from   pri
                            where  pri_customer = '{txtCustomerID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("這個客戶不能刪除,因為這個客戶已經有了報價資料了!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustomerID.Focus();
                    return;
                }

                if (MessageBox.Show(this, "你確定要刪除這個客戶資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    strSQL = $@"delete cus
                                where  cus_id = '{txtCustomerID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)  //儲存
        {
            //儲存
            try
            {
                String strSQL = "";
                DataTable dt;
                if (txtCustomerID.Text == "")
                {
                    MessageBox.Show("請輸入欲儲存的客戶編號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustomerID.Focus();
                    return;
                }
                if(cboCode.Text=="")
                {
                    cboCode.Text = "A";
                }
                strSQL = $@"exec cus_save'{txtCustomerID.Text.Trim()}', '{txtCustomerInfo.Text.Trim()}',
                                            '{txtTel1.Text.Trim()}', '{txtFax1.Text.Trim()}',
                                            '', '{txtEmail.Text.Trim()}',
                                            '', '{txtMark.Text.Trim()}',
                                            '{txtDigiwinID.Text.Trim()}', '{txtShippingMark.Text.Trim()}',
                                            '{txtSideMark.Text.Trim()}', '{txtTel2.Text.Trim()}',
                                            '{txtFax2.Text.Trim()}', '',
                                            '{txtAddress.Text.Trim()}', '{txtContact.Text.Trim()}',
                                            '{cboCode.Text.Trim()}', '{txtShortName.Text.Trim()}',
                                            '{txtWeb.Text.Trim()}', '{cboCountry.Text.Trim()}',
                                            '{cboCountryCode.Text.Trim()}', '{cboPaymentTerms.Text.Trim()}',
                                            '{cboYw.Text.Trim()}', '{txtPipeline.Text.Trim()}',
                                            '{txtStartDate.Text.Trim()}', '{cboTitle.Text.Trim()}' ";
                clsDB.Execute(strSQL);
                MessageBox.Show("已經儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerID.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Customer_Click(object sender, EventArgs e)
        {
            frmCustomer_Inq_Customer frmCustomer_Inq_Customer = new frmCustomer_Inq_Customer();
            //frmCustomer_Inq_Customer.strUserName = cboUser.Text;
            frmCustomer_Inq_Customer.ShowDialog();
            if(strCustomerID!="")
            {
                txtCustomerID.Text = strCustomerID;
                getData();
                strCustomerID = "";
            }
            else
            {
                btnClear_Click(null, null);
            }
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtShortName.Focus();
            }
        }

        private void cboYw_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboYwName.Text = cboYwName.Items[cboYw.SelectedIndex].ToString();
            lblYwName.Text = cboYwName.Text;
            if(cboYw.Text=="")
            {
                lblYwName.Text = "";
            }
        }

        private void txtStartDate_Click(object sender, EventArgs e)
        {
            if(txtStartDate.Text=="")
            {
                txtStartDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void btnBankInfo_Click(object sender, EventArgs e)
        {
            if(txtCustomerID.Text=="")
            {
                MessageBox.Show("請輸入客戶編號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerID.Focus();
                return;
            }
            string strSQL = $@"select cus_id
                               from   cus
                               where  cus_id = '{txtCustomerID.Text}' ";
            DataTable dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                frmCustomer_BankInfo frmCustomer_BankInfo = new frmCustomer_BankInfo();
                frmCustomer_BankInfo.strCustomerID = txtCustomerID.Text;
                frmCustomer_BankInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("系統中無此客戶,請先建立!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerID.Focus();
                return;
            }
        }

        private void btnInq_ShortName_Click(object sender, EventArgs e)
        {
            frmCustomer_Inq_ShortName frmCustomer_Inq_ShortName = new frmCustomer_Inq_ShortName();
            frmCustomer_Inq_ShortName.ShowDialog();
            if (strCustomerID != "")
            {
                txtCustomerID.Text = strCustomerID;
                getData();
                strCustomerID = "";
            }
            else
            {
                btnClear_Click(null, null);
            }
        }
    }
}
