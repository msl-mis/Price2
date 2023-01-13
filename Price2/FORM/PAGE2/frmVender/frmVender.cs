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
    public partial class frmVender : Form
    {
        public static string rstrID;     //傳入的廠號
        public frmVender()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnInq_Click(object sender, EventArgs e)
        {
            //呼叫"廠商查詢",並將結果傳入廠號
            try
            {
                rstrID = "";
                frmVender_Inq frmVender_Inq = new frmVender_Inq();
                frmVender_Inq.ShowInTaskbar = false;    //圖示不顯示在工作列
                frmVender_Inq.strWhoCall = "frmVender";
                frmVender_Inq.ShowDialog();

                if (rstrID != "")
                {
                    txtID.Text = rstrID;
                    getData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Customer_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if(txtID.Text!="")
            {
                getData();
            }
        }

        private void getData()
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select * from ven where ven_id = '{txtID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    txtID.Text = dt.Rows[0]["ven_id"].ToString();
                    txtName.Text = dt.Rows[0]["ven_shortname"].ToString();
                    cboClass.Text = dt.Rows[0]["ven_maxtype"].ToString();
                    lvwItem.Items.Clear();

                    strSQL = $@"select vent_option from vent where vent_type = '{cboClass.Text}'";
                    DataTable dt2 = new DataTable();
                    dt2 = clsDB.sql_select_dt(strSQL);
                    if(dt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            lvwItem.Items.Add(dt2.Rows[i]["vent_option"].ToString());
                            if (dt.Rows[0]["ven_type"].ToString().IndexOf(dt2.Rows[i]["vent_option"].ToString().Trim()) >= 0)
                            {
                                lvwItem.Items[i].Checked = true;
                            }
                        }
                    }
                    //cboItem.Text = dt.Rows[0]["ven_type"].ToString();
                    txtName_TW.Text = dt.Rows[0]["ven_twname"].ToString();
                    txtName_CN.Text = dt.Rows[0]["ven_dlname"].ToString();
                    txtPhone_TW.Text = dt.Rows[0]["ven_twtel1"].ToString();
                    txtPhone_CN.Text = dt.Rows[0]["ven_dltel1"].ToString();
                    txtFax_TW.Text = dt.Rows[0]["ven_twfax"].ToString();
                    txtFax_CN.Text = dt.Rows[0]["ven_dlfax"].ToString();
                    txtEmail_TW.Text = dt.Rows[0]["ven_twemail"].ToString();
                    txtEmail_CN.Text = dt.Rows[0]["ven_dlemail"].ToString();
                    txtWeb_TW.Text = dt.Rows[0]["ven_website"].ToString();
                    txtWeb_CN.Text = dt.Rows[0]["ven_dlwebsite"].ToString();
                    txtContact_TW.Text = dt.Rows[0]["ven_twcontact1"].ToString();
                    txtContact_CN.Text = dt.Rows[0]["ven_dlcontact"].ToString();
                    txtAddress_TW.Text = dt.Rows[0]["ven_twaddress"].ToString();
                    txtAddress_CN.Text = dt.Rows[0]["ven_dladdress"].ToString();
                    txtPayment.Text = dt.Rows[0]["ven_payment"].ToString();
                    cboCurrency.Text = dt.Rows[0]["ven_currency"].ToString();
                    lblUser.Text = dt.Rows[0]["ven_user"].ToString();
                    lblDate.Text = ((DateTime)dt.Rows[0]["ven_adddate"]).ToString("yyyy/MM/dd");
                    txtNote.Text = dt.Rows[0]["ven_bz"].ToString();
                }
                else
                {
                    if (MessageBox.Show(this, "你要創建一個新的廠商資料嗎? ", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //清除資料除了廠號
                        txtName.Text = "";
                        cboClass.Text = "";
                        //cboItem.Text = "";
                        lvwItem.Items.Clear();
                        txtName_TW.Text = "";
                        txtName_CN.Text = "";
                        txtPhone_TW.Text = "";
                        txtPhone_CN.Text = "";
                        txtFax_TW.Text = "";
                        txtFax_CN.Text = "";
                        txtEmail_TW.Text = "";
                        txtEmail_CN.Text = "";
                        txtWeb_TW.Text = "";
                        txtWeb_CN.Text = "";
                        txtContact_TW.Text = "";
                        txtContact_CN.Text = "";
                        txtAddress_TW.Text = "";
                        txtAddress_CN.Text = "";
                        txtPayment.Text = "";
                        cboCurrency.Text = "臺幣";
                        lblUser.Text = "";
                        lblDate.Text = "";
                        txtNote.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) //清除
        {
            //清除
            try
            {
                txtID.Text = "";
                txtName.Text = "";
                cboClass.Text = "";
                //cboItem.Text = "";
                lvwItem.Items.Clear();
                txtName_TW.Text = "";
                txtName_CN.Text = "";
                txtPhone_TW.Text = "";
                txtPhone_CN.Text = "";
                txtFax_TW.Text = "";
                txtFax_CN.Text = "";
                txtEmail_TW.Text = "";
                txtEmail_CN.Text = "";
                txtWeb_TW.Text = "";
                txtWeb_CN.Text = "";
                txtContact_TW.Text = "";
                txtContact_CN.Text = "";
                txtAddress_TW.Text = "";
                txtAddress_CN.Text = "";
                txtPayment.Text = "";
                cboCurrency.Text = "臺幣";
                lblUser.Text = "";
                lblDate.Text = "";
                txtNote.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lvwItem.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lvwItem.Items.Add(dt.Rows[i]["vent_option"].ToString());
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)    //刪除
        {
            //刪除
            try
            {
                if (MessageBox.Show(this, "你確定想刪除這個廠商資料嗎? ", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    strSQL = $@"delete ven where ven_id = '{txtID.Text}' ";
                    clsDB.Execute(strSQL);
                    
                    MessageBox.Show("已經刪除成功!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();
                    txtID.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmVendor_Load(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            cboClass.Text = "";
            //cboItem.Text = "";
            lvwItem.Items.Clear();
            txtName_TW.Text = "";
            txtName_CN.Text = "";
            txtPhone_TW.Text = "";
            txtPhone_CN.Text = "";
            txtFax_TW.Text = "";
            txtFax_CN.Text = "";
            txtEmail_TW.Text = "";
            txtEmail_CN.Text = "";
            txtWeb_TW.Text = "";
            txtWeb_CN.Text = "";
            txtContact_TW.Text = "";
            txtContact_CN.Text = "";
            txtAddress_TW.Text = "";
            txtAddress_CN.Text = "";
            txtPayment.Text = "";
            cboCurrency.Text = "臺幣";
            lblUser.Text = "";
            lblDate.Text = "";
            txtNote.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)  //儲存
        {
            //儲存
            try
            {
                if(txtID.Text=="")
                {
                    return;
                }
                //先組合項目
                string strItem = "";
                for(int i = 0; i < lvwItem.Items.Count; i++)
                {
                    if(lvwItem.Items[i].Checked )
                    {
                        strItem = strItem+lvwItem.Items[i].Text;    
                    }
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                //查詢有無廠商資訊
                strSQL = $@"select * from ven where ven_id = '{txtID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count>0)
                {
                    //有資訊,update
                    strSQL = $@"update ven
                                set    ven_twname = '{txtName_TW.Text.Trim()}',
                                       ven_twtel1 = '{txtPhone_TW.Text.Trim()}',
                                       ven_twtel2 = '',
                                       ven_twfax = '{txtFax_TW.Text.Trim()}',
                                       ven_twemail = '{txtEmail_TW.Text.Trim()}',
                                       ven_twcontact1 = '{txtContact_TW.Text.Trim()}',
                                       ven_twcall1 = '',
                                       ven_twcontact2 = '',
                                       ven_twcall2 = '',
                                       ven_twaddress = '{txtAddress_TW.Text.Trim()}',
                                       ven_dladdress = '{txtAddress_CN.Text.Trim()}',
                                       ven_dlname = '{txtName_CN.Text.Trim()}',
                                       ven_dltel1 = '{txtPhone_CN.Text.Trim()}',
                                       ven_dltel2 = '',
                                       ven_dlfax = '{txtFax_CN.Text.Trim()}',
                                       ven_dlemail = '{txtEmail_CN.Text.Trim()}',
                                       ven_dlcontact = '{txtContact_CN.Text.Trim()}',
                                       ven_dlcall = '',
                                       ven_payment = '{txtPayment.Text.Trim()}',
                                       ven_shortname = '{txtName.Text.Trim()}',
                                       ven_kpercent = 0,
                                       ven_bz = '{txtNote.Text.Trim()}',
                                       ven_stopflag = 0,
                                       ven_currency = '{cboCurrency.Text.Trim()}',
                                       ven_adddate = Getdate(),
                                       ven_type = '{strItem}',
                                       ven_website = '{txtWeb_TW.Text.Trim()}',
                                       ven_dlwebsite = '{txtWeb_CN.Text.Trim()}',
                                       ven_user = '{clsGlobal.strG_User}',
                                       ven_maxtype = '{cboClass.Text.Trim()}'
                                where  ven_id = '{txtID.Text.Trim()}'  ";
                    clsDB.Execute(strSQL);
                }
                else
                {
                    //無資訊,insert
                    strSQL = $@"insert ven
                                       (ven_id,
                                        ven_twname,
                                        ven_twtel1,
                                        ven_twtel2,
                                        ven_twfax,
                                        ven_twemail,
                                        ven_twcontact1,
                                        ven_twcall1,
                                        ven_twcontact2,
                                        ven_twcall2,
                                        ven_twaddress,
                                        ven_dladdress,
                                        ven_dlname,
                                        ven_dltel1,
                                        ven_dltel2,
                                        ven_dlfax,
                                        ven_dlemail,
                                        ven_dlcontact,
                                        ven_dlcall,
                                        ven_payment,
                                        ven_shortname,
                                        ven_kpercent,
                                        ven_bz,
                                        ven_stopflag,
                                        ven_currency,
                                        ven_adddate,
                                        ven_type,
                                        ven_website,
                                        ven_dlwebsite,
                                        ven_user,
                                        ven_maxtype)
                                values ('{txtID.Text.Trim()}',
                                        '{txtName_TW.Text.Trim()}',
                                        '{txtPhone_TW.Text.Trim()}',
                                        '',
                                        '{txtFax_TW.Text.Trim()}',
                                        '{txtEmail_TW.Text.Trim()}',
                                        '{txtContact_TW.Text.Trim()}',
                                        '',
                                        '',
                                        '',
                                        '{txtAddress_TW.Text.Trim()}',
                                        '{txtAddress_CN.Text.Trim()}',
                                        '{txtName_CN.Text.Trim()}',
                                        '{txtPhone_CN.Text.Trim()}',
                                        '',
                                        '{txtFax_CN.Text.Trim()}',
                                        '{txtEmail_CN.Text.Trim()}',
                                        '{txtContact_CN.Text.Trim()}',
                                        '',
                                        '{txtPayment.Text.Trim()}',
                                        '{txtName.Text.Trim()}',
                                        0,
                                        '{txtNote.Text.Trim()}',
                                        0,
                                        '{cboCurrency.Text.Trim()}',
                                        Getdate(),
                                        '{strItem}',
                                        '{txtWeb_TW.Text.Trim()}',
                                        '{txtWeb_CN.Text.Trim()}',
                                        '{clsGlobal.strG_User}',
                                        '{cboClass.Text.Trim()}')  ";
                    clsDB.Execute(strSQL);
                }
                
                //以下不知道會不會用到
                strSQL = $@"update avt
                            set    avt_fktj = '{txtPayment.Text.Trim()}',
                                   avt_kpercent = 0
                            where  avt_vendorid = '{txtID.Text.Trim()}' ";
                clsDB.Execute(strSQL);
                strSQL = $@"update avt
                            set    avt_currency = ven_currency
                            from   ven,
                                   avt
                            where  ven_id = avt_vendorid
                                   and ven_currency <> ''
                                   and avt_currency <> ven_currency
                                   and ven_id = '{txtID.Text.Trim()}' ";
                clsDB.Execute(strSQL);

                MessageBox.Show("已經儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRename_Click(object sender, EventArgs e)    //廠號變更
        {
            //廠號變更
            try
            {
                if(txtID.Text=="")
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select * from ven where ven_id = '{txtID.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count==0)
                {
                    MessageBox.Show("請先輸入已存在廠號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                InputBox input = new InputBox();
                input.ShowInTaskbar = false;//圖示不顯示在工作列
                input.lblInfo.Text = "請輸入新廠商編號:";
                input.Text = "廠號變更";
                input.txtIpnut.Text = txtID.Text;
                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (input.GetMsg() != "")
                    {
                        string strNewID = input.GetMsg().Trim();
                        if (strNewID != txtID.Text)
                        {
                            strSQL = $@"select * from ven where ven_id = '{strNewID}' ";
                            dt = clsDB.sql_select_dt(strSQL);
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("該廠商編號已存在,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                //先變更資料庫
                                strSQL = $@"update ven
                                            set    ven_id = '{strNewID}'
                                            where  ven_id = '{txtID.Text}' ";
                                clsDB.Execute(strSQL);
                                strSQL = $@"update asp
                                            set    asp_vendorid = '{strNewID}'
                                            where  asp_vendorid = '{txtID.Text}' ";
                                clsDB.Execute(strSQL);
                                strSQL = $@"update aspnum
                                            set    aspnum_vendorid = '{strNewID}'
                                            where  aspnum_vendorid = '{txtID.Text}' ";
                                clsDB.Execute(strSQL);
                                //再變更原廠號
                                txtID.Text = strNewID;
                                //在儲存一次
                                btnSave.PerformClick();
                            }
                        }
                        else
                        {
                            MessageBox.Show("廠商編號不可相同,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnRename_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)  //複製
        {
            //複製
            try
            {
                if (txtID.Text == "")
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select * from ven where ven_id = '{txtID.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("請先輸入已存在廠號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                InputBox input = new InputBox();
                input.ShowInTaskbar = false;//圖示不顯示在工作列
                input.lblInfo.Text = "請輸入新廠商編號:";
                input.Text = "複製廠商資料";
                input.txtIpnut.Text = txtID.Text;
                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (input.GetMsg() != "")
                    {
                        string strNewID = input.GetMsg().Trim();
                        if (strNewID != txtID.Text)
                        {
                            strSQL = $@"select * from ven where ven_id = '{strNewID}' ";
                            dt = clsDB.sql_select_dt(strSQL);
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("該廠商編號已存在,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                //變更原廠號
                                txtID.Text = strNewID;
                                //在儲存一次
                                btnSave.PerformClick();
                            }
                        }
                        else
                        {
                            MessageBox.Show("廠商編號不可相同,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCopy_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
