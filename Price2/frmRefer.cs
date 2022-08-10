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
    public partial class frmRefer : Form
    {
        public static string whocall;   //判斷從哪個程式來的
        Boolean tchk=false;     //
        string strCZF1 = "";
        string strActive ="0";
        string curpart_B = "";  //包/材料名
        string oldpart_B = "";  //包/材料名
        string curqty_B = "0";  //包/數量
        string oldqty_B = "0";  //包/數量
        string curpart_Z = "";  //裝/材料名
        string oldpart_Z = "";  //裝/材料名
        string curqty_Z = "0";  //裝/數量
        string oldqty_Z = "0";  //裝/數量
        string curpart_U = "";  //運/材料名
        string oldpart_U = "";  //運/材料名
        string curqty_U = "0";  //運/數量
        string oldqty_U = "0";  //運/數量
        string curqty_R = "0";    //不良率/數量
        string oldqty_R = "0";    //不良率/數量

        public frmRefer()
        {
            InitializeComponent();
        }

        private void frmRefer_Activated(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                //lblUser.Text = "";
                //lblDate.Text = "";
                //lblUser_U.Text = "";
                //lblDate_U.Text = "";
                //strCZF1 = "";
                //strActive = "0";
                //btnCopy.Enabled = false;
                //btnDelete.Enabled = false;
                //btnSaveMaterial.Enabled = false;
                //btnUpdateQuote.Enabled = false;
                //lbl_B.Text = "";
                //lbl_B.Text = "";
                //lbl_B.Text = "";
                //lbl_B.Text = "";

                this.WindowState = FormWindowState.Normal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmRefer_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRefer_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                lblUser.Text = "";
                lblDate.Text = "";
                lblUser_U.Text = "";
                lblDate_U.Text = "";
                strCZF1 = "";
                strActive = "0";
                btnCopy.Enabled = false;
                btnDelete.Enabled = false;
                btnSaveMaterial.Enabled = false;
                btnUpdateQuote.Enabled = false;
                lbl_B.Text = "";
                lbl_Z.Text = "";
                lbl_U.Text = "";
                lbl_R.Text = "";

                //this.WindowState = FormWindowState.Normal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmRefer_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtID.Text != "")
                    {
                        
                        txtID.Text = txtID.Text.Trim();
                        String strSQL = "";
                        DataTable dt = new DataTable();
                        DataTable dt2 = new DataTable();
                        strSQL = $@"select *
                                    from   odi
                                    where  odi_customerid = '{txtID.Text}' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if(dt.Rows.Count > 0)
                        {
                            //檢查參照法材料名欄位是否空白,如果是自動帶入報價單中的包裝運材料
                            if(whocall=="bom" && dt.Rows[0]["odi_pripart01"].ToString()=="" && dt.Rows[0]["odi_pripart02"].ToString() == "" && dt.Rows[0]["odi_pripart04"].ToString() == "" && dt.Rows[0]["odi_pripart05"].ToString() == "")
                            {
                                strSQL = $@"exec odi_chkpri '{txtID.Text}' ";
                                clsDB.Execute(strSQL);
                                strSQL = $@"select *
                                    from   odi
                                    where  odi_customerid = '{txtID.Text}' ";
                                dt = clsDB.sql_select_dt(strSQL);
                            }
                            txtCZF.Text = dt.Rows[0]["odi_czf"].ToString();
                            strCZF1 = dt.Rows[0]["odi_czf1"].ToString();
                            txtPrice.Text = dt.Rows[0]["odi_price"].ToString();
                            txtLine.Text = dt.Rows[0]["odi_line"].ToString();
                            txtLine.ReadOnly=true;  //關閉線路修改
                            txtName.Text = dt.Rows[0]["odi_customer"].ToString();
                            txtZX.Text = dt.Rows[0]["odi_zx"].ToString();
                            txtXZ.Text = dt.Rows[0]["odi_xz"].ToString();
                            txtMZ.Text = dt.Rows[0]["odi_mz"].ToString();
                            txtMO.Text = dt.Rows[0]["odi_mo"].ToString();
                            txtJZ.Text = dt.Rows[0]["odi_jz"].ToString();
                            lblUser.Text = dt.Rows[0]["odi_username"].ToString();
                            lblDate.Text = Convert.ToDateTime(dt.Rows[0]["odi_adddate"]).ToString("yyyy/MM/dd");
                            btnCopy.Enabled = true;
                            btnSave.Enabled = false;
                            btnDelete.Enabled = true;
                            btnSaveMaterial.Enabled = true; 
                            txtCurrency.Text = dt.Rows[0]["odi_currency"].ToString();
                            strActive = dt.Rows[0]["odi_active"].ToString();
                            //取得現有報價單中的裝/材料名和數量
                            strSQL = $@"select pri_part,
                                           pri_perqty
                                    from   pri
                                    where  pri_customerid = '{txtID.Text}'
                                           and pri_part like '裝%'
                                           and pri_newcostchk like 'N%' ";
                            dt2 = clsDB.sql_select_dt(strSQL);
                            if (dt2.Rows.Count > 0)
                            {
                                curpart_Z = dt2.Rows[0]["pri_part"].ToString();
                                curqty_Z = dt2.Rows[0]["pri_perqty"].ToString();
                            }
                            else
                            {
                                curpart_Z = "";
                                curqty_Z = "0";
                            }
                            //再取得參照法內的裝/材料名
                            if (string.IsNullOrEmpty(dt.Rows[0]["odi_pripart01"].ToString())==false)    //外箱
                            {
                                txtPart_Z.Text = dt.Rows[0]["odi_pripart01"].ToString();
                                oldpart_Z = txtPart_Z.Text;
                            }
                            else
                            {
                                oldpart_Z = "";
                            }
                            if (string.IsNullOrEmpty(dt.Rows[0]["odi_priqty01"].ToString()) == false && dt.Rows[0]["odi_priqty01"].ToString() != "0")  //外箱數量
                            {
                                txtQty_Z.Text = dt.Rows[0]["odi_priqty01"].ToString();
                                oldqty_Z = txtQty_Z.Text;
                            }
                            else
                            {
                                oldqty_Z = "0";
                            }
                            //取得現有報價單中的包/材料名和數量
                            strSQL = $@"select pri_part,
                                           pri_perqty
                                    from   pri
                                    where  pri_customerid = '{txtID.Text}'
                                           and pri_part like '包%'
                                           and pri_newcostchk like 'N%' ";
                            dt2 = clsDB.sql_select_dt(strSQL);
                            if (dt2.Rows.Count > 0)
                            {
                                curpart_B = dt2.Rows[0]["pri_part"].ToString();
                                curqty_B = dt2.Rows[0]["pri_perqty"].ToString();
                            }
                            else
                            {
                                curpart_B = "";
                                curqty_B = "0";
                            }
                            //再取得參照法內的包/材料名
                            if (string.IsNullOrEmpty(dt.Rows[0]["odi_pripart02"].ToString()) == false)  //包裝
                            {
                                txtPart_B.Text = dt.Rows[0]["odi_pripart02"].ToString();
                                oldpart_B = txtPart_B.Text;
                            }
                            else
                            {
                                oldpart_B = "";
                            }
                            if (string.IsNullOrEmpty(dt.Rows[0]["odi_priqty02"].ToString()) == false && dt.Rows[0]["odi_priqty02"].ToString() != "0")  //包裝數量
                            {
                                txtQty_B.Text = dt.Rows[0]["odi_priqty02"].ToString();
                                oldqty_B = txtQty_B.Text;
                            }
                            else
                            {
                                oldqty_B = "0";
                            }
                            //取得現有報價單中的運/材料名和數量
                            strSQL = $@"select pri_part,
                                           pri_perqty
                                    from   pri
                                    where  pri_customerid = '{txtID.Text}'
                                           and pri_part like '運%'
                                           and pri_newcostchk like 'N%' ";
                            dt2 = clsDB.sql_select_dt(strSQL);
                            if (dt2.Rows.Count > 0)
                            {
                                curpart_U = dt2.Rows[0]["pri_part"].ToString();
                                curqty_U = dt2.Rows[0]["pri_perqty"].ToString();
                            }
                            else
                            {
                                curpart_U = "";
                                curqty_U = "0";
                            }
                            //再取得參照法內的運/材料名
                            if (string.IsNullOrEmpty(dt.Rows[0]["odi_pripart05"].ToString()) == false)  //運費
                            {
                                txtPart_U.Text = dt.Rows[0]["odi_pripart05"].ToString();
                                oldpart_U = txtPart_U.Text;
                            }
                            else
                            {
                                oldpart_U = "";
                            }
                            if (string.IsNullOrEmpty(dt.Rows[0]["odi_priqty05"].ToString()) == false && dt.Rows[0]["odi_priqty05"].ToString() != "0")  //運費數量
                            {
                                txtQty_U.Text = dt.Rows[0]["odi_priqty05"].ToString();
                                oldqty_U = txtQty_U.Text;
                            }
                            else
                            {
                                oldqty_U = "0";
                            }
                            //取得報價單中的不良率
                            strSQL = $@"select pri_part,
                                               pri_perqty,
                                               pri_tbprice
                                        from   pri
                                        where  pri_customerid = '{txtID.Text}'
                                               and pri_part like '不良%'
                                               and pri_newcostchk like 'N%'";
                            dt2 = clsDB.sql_select_dt(strSQL);
                            if (dt2.Rows.Count > 0)
                            {
                                curqty_R = ((double)dt2.Rows[0]["pri_tbprice"]* (double)dt2.Rows[0]["pri_perqty"]).ToString();
                            }
                            else
                            {
                                curqty_R = "0";
                            }
                            if (string.IsNullOrEmpty(dt.Rows[0]["odi_priqty04"].ToString()) == false && dt.Rows[0]["odi_priqty04"].ToString()!="0")  //不良率
                            {
                                txtRate.Text = ((double)dt.Rows[0]["odi_priqty04"]*100).ToString();
                                oldqty_R = dt.Rows[0]["odi_priqty04"].ToString();
                            }
                            else
                            {
                                oldqty_R = "0";
                            }

                        }
                        else
                        {
                            if (MessageBox.Show(this, "你需要創建一個新的產品資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                this.Cursor = Cursors.Default;//滑鼠還原預設
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-txtID_KeyDown" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearMaterial_Click(object sender, EventArgs e) //清除材料
        {
            //清除材料相關欄位
            try
            {
                txtPart_Z.Text = ""; //外箱
                txtPart_B.Text = ""; //包裝
                txtPart_U.Text = ""; //運費
                txtQty_B.Text = "0"; //包裝數量
                txtQty_Z.Text = "0"; //外箱數量
                txtQty_U.Text = "0"; //運費數量
                txtRate.Text = "0"; //不良率
                oldpart_Z = ""; //外箱
                oldpart_B = ""; //包裝
                oldpart_U = ""; //運費
                //schk = False
                lbl_B.Text = ""; //包裝 更改判斷
                lbl_Z.Text = ""; //外箱 更改判斷
                lbl_R.Text = ""; //不良率更改判斷
                lbl_U.Text = ""; //運費 更改判斷
                btnUpdateQuote.Enabled=false;   //更新報價
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClearMaterial_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearCZF_Click(object sender, EventArgs e)  //清除參照法
        {
            //清除全部
            try
            {
                if(whocall!="bom")
                {
                    txtID.Text = "";    //客號
                    lblUser.Text = "";    //用戶：
                    lblDate.Text = "";    //最後儲存日期：
                    lblUser_U.Text = "";    //用戶：
                    lblDate_U.Text = "";    //最後儲存日期：
                    txtPrice.Text = "";    //報價：
                    txtLine.Text = "";    //線路：
                    txtCurrency.Text = "NT$";   //幣別：
                    btnSave.Enabled = false; //儲存
                }
                else
                {
                    btnSave.Enabled = true; //儲存
                }
                txtCZF.Text = "";    //參照法
                txtName.Text = "";    //客戶：
                txtXZ.Text = "";    //材積：
                txtZX.Text = "";    //箱量：
                txtJZ.Text = "";    //淨重：
                txtMZ.Text = "";    //毛重：
                txtMO.Text = "MO";    //MO：
                lblUser_U.Text = "";    //用戶：
                lblDate_U.Text = "";    //最後儲存日期：

                strActive = "0";
                btnClearMaterial.PerformClick();
                btnUpdateQuote.Enabled = false; //報價更新
                btnSaveMaterial.Enabled = false; //儲存材料
                btnDelete.Enabled = false; //刪除
                btnCopy.Enabled = false; //複製
                //schk = True
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClearCZF_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //結束
            try
            {
                lblUser.Text = "";
                lblDate.Text = "";
                lblUser_U.Text = "";
                lblDate_U.Text = "";
                strCZF1 = "";
                strActive = "0";
                btnCopy.Enabled = false;
                btnDelete.Enabled = false;
                btnSaveMaterial.Enabled = false;
                btnUpdateQuote.Enabled = false;
                lbl_B.Text = "";
                lbl_Z.Text = "";
                lbl_U.Text = "";
                lbl_R.Text = "";
                //frmMain frmMain = (frmMain)this.MdiParent;
                //frmMain.gbMain.Visible = true;
                //this.MdiParent.Controls.OfType<GroupBox>().ToList()[0].Visible=true;
                //(this.MdiParent as frmMain).gbMain.Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-_btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveMaterial_Click(object sender, EventArgs e)  //儲存材料
        {
            //儲存材料
            try
            {
                if (txtID.Text != "")
                {
                    if (clsGlobal.checkRightFlag("參照法下半部儲存材料") == false)
                    {
                        MessageBox.Show("你沒有參照法下半部儲存材料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    tchk = false;
                    if(txtPart_B.Text!="" && txtQty_B.Text=="0")
                    {
                        tchk = true;
                    }
                    if (txtPart_Z.Text != "" && txtQty_Z.Text == "0")
                    {
                        tchk = true;
                    }
                    if (txtPart_U.Text != "" && txtQty_U.Text == "0")
                    {
                        tchk = true;
                    }
                    if (tchk==true)
                    {
                        MessageBox.Show("材料數量不可為零,請檢查!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //檢查材料數量是否與報價單相同,若不同代表已被變更
                    checkP();
                    if (tchk == true)
                    {
                        return;
                    }
                    if (txtPrice.Text == "") { txtPrice.Text = "0"; }
                    if (txtZX.Text == "") { txtPrice.Text = "0"; }
                    if (txtXZ.Text == "") { txtPrice.Text = "0"; }
                    if (txtMZ.Text == "") { txtPrice.Text = "0"; }
                    if (txtJZ.Text == "") { txtPrice.Text = "0"; }

                    String strSQL = "";
                    DataTable dt = new DataTable();

                    strSQL = $@"update odi
                                set    odi_oldpart01 = '{oldpart_Z}',
                                       odi_oldpart02 = '{oldpart_B}',
                                       odi_oldpart03 = '',
                                       odi_oldpart05 = '{oldpart_U}',
                                       odi_oldpart06 = '',
                                       odi_pripart06 = '',
                                       odi_pripart01 = '{txtPart_Z.Text}',
                                       odi_pripart02 = '{txtPart_B.Text}',
                                       odi_pripart05 = '{txtPart_U.Text}',
                                       odi_pripart04 = '不良率%',
                                       odi_priqty01 = '{txtQty_Z.Text}',
                                       odi_priqty02 = '{txtQty_B.Text}',
                                       odi_priqty04 = '{(Convert.ToDouble(txtRate.Text)/100).ToString()}',
                                       odi_priqty05 = '{txtQty_U.Text}',
                                       odi_zx = '{txtZX.Text}',
                                       odi_xz = '{txtXZ.Text}',
                                       odi_mz = '{txtMZ.Text}',
                                       odi_jz = '{txtJZ.Text}',
                                       odi_priqty06 = 0,
                                       odi_username1 = '{clsGlobal.strG_User}',
                                       odi_adddate1 = convert(VARCHAR(4), Datepart(yyyy, Getdate()))
                                                      + '/'
                                                      + convert(VARCHAR(4), Datepart(mm, Getdate()))
                                                      + '/'
                                                      + convert(VARCHAR(4), Datepart(dd, Getdate()))
                                where odi_customerid = '{txtID.Text}' ";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("材料已經儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //用手動輸人包裝運材料
                    oldpart_B = txtPart_B.Text;
                    oldpart_Z = txtPart_Z.Text;
                    oldpart_U = txtPart_U.Text;
                    oldqty_B = txtQty_B.Text;
                    oldqty_Z = txtQty_Z.Text;
                    oldqty_U = txtQty_U.Text;
                    if(txtRate.Text != "")
                    {
                        oldqty_R=(Convert.ToDouble(txtRate.Text)/100).ToString();
                    }
                    else
                    {
                        oldqty_R = "0";
                    }

                    //schk = False
                    checkP();
                    if(lbl_B.Text!="" && lbl_Z.Text != "" && lbl_U.Text != "" && lbl_R.Text != "" )
                    {

                    }

                    btnSaveMaterial.Enabled = false;
                    lblUser_U.Text = clsGlobal.strG_User;
                    lblDate_U.Text = DateTime.Now.ToString("yyyy/MM/dd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSaveMaterial_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkP()
        {
            //檢查材料數量是否與報價單相同,若不同代表已被變更
            try
            {
                String strSQL = "";
                DataTable dt = new DataTable();
                if (curqty_B=="")
                {
                    curqty_B = "0";
                }
                if (curqty_Z == "")
                {
                    curqty_Z = "0";
                }
                if (curqty_U == "")
                {
                    curqty_U = "0";
                }
                if (curqty_R == "")
                {
                    curqty_R = "0";
                }
                if (oldqty_B == "")
                {
                    oldqty_B = "0";
                }
                if (oldqty_Z == "")
                {
                    oldqty_Z = "0";
                }
                if (oldqty_U == "")
                {
                    oldqty_U = "0";
                }
                if (oldqty_R == "")
                {
                    oldqty_R = "0";
                }

                //不良率檢查
                if(txtRate.Text!="" && txtRate.Text!="0")
                {
                    if(Convert.ToDouble(oldqty_R) * 100!= Convert.ToDouble(txtRate.Text)|| Convert.ToDouble(curqty_R) * 100 != Convert.ToDouble(txtRate.Text))
                    {
                        lbl_R.Text = "有變更";
                    }
                    else
                    {
                        lbl_R.Text = "";
                    }
                }

                //包裝檢查
                if(txtPart_B.Text!="")
                {
                    if(check_P1(txtPart_B.Text,1))
                    {
                        MessageBox.Show("材料名重覆,請檢查!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tchk = true;
                        return;
                    }
                    //先檢查材料名正不正確
                    strSQL = $@"select asp_id
                                from   asp
                                where  asp_id = '{txtPart_B.Text}'
                                        and asp_id like '包/%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if(dt == null)
                    {
                        MessageBox.Show("包/材料名不存在請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tchk = true;
                        btnSaveMaterial.Enabled = false;
                        btnUpdateQuote.Enabled = false;
                        return;
                    }
                    if(txtPart_B.Text!=oldpart_B || txtPart_B.Text != curpart_B)
                    {
                        if(oldpart_B=="")
                        {
                            lbl_B.Text = "新建立";
                        }
                        else
                        {
                            lbl_B.Text = "材料變更";
                        }
                    }
                    else
                    {
                        if (curqty_B != txtQty_B.Text || oldqty_B != txtQty_B.Text)
                        {
                            lbl_B.Text = "數量變更";
                        }
                        else
                        {
                            lbl_B.Text = "";
                        }
                    }
                }
                else
                //欄位空白,但舊材料名有存在代表此材料被刪除了
                {
                    if (oldpart_B != "")
                    {
                        lbl_B.Text = "材料變更";
                    }
                    else
                    {
                        lbl_B.Text = "";
                    }
                }

                //外箱檢查
                if (txtPart_Z.Text != "")
                {
                    if (check_P1(txtPart_Z.Text, 3))
                    {
                        MessageBox.Show("材料名重覆,請檢查!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tchk = true;
                        return;
                    }
                    //先檢查材料名正不正確
                    strSQL = $@"select asp_id
                                from   asp
                                where  asp_id = '{txtPart_Z.Text}'
                                        and asp_id like '裝/%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt == null)
                    {
                        MessageBox.Show("裝/材料名不存在請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tchk = true;
                        btnSaveMaterial.Enabled = false;
                        btnUpdateQuote.Enabled = false;
                        return;
                    }
                    if (txtPart_Z.Text != oldpart_Z || txtPart_Z.Text != curpart_Z)
                    {
                        if (oldpart_Z == "")
                        {
                            lbl_Z.Text = "新建立";
                        }
                        else
                        {
                            lbl_Z.Text = "材料變更";
                        }
                    }
                    else
                    {
                        if (curqty_Z != txtQty_Z.Text || oldqty_Z != txtQty_Z.Text)
                        {
                            lbl_Z.Text = "數量變更";
                        }
                        else
                        {
                            lbl_Z.Text = "";
                        }
                    }
                }

                //運費檢查
                if (txtPart_U.Text != "")
                {
                    if (check_P1(txtPart_U.Text, 4))
                    {
                        MessageBox.Show("材料名重覆,請檢查!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tchk = true;
                        return;
                    }
                    //先檢查材料名正不正確
                    strSQL = $@"select asp_id
                            from   asp
                            where  asp_id = '{txtPart_U.Text}'
                                    and asp_id like '運/%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt == null)
                    {
                        MessageBox.Show("裝/材料名不存在請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tchk = true;
                        btnSaveMaterial.Enabled = false;
                        btnUpdateQuote.Enabled = false;
                        return;
                    }
                    if (txtPart_U.Text != oldpart_U || txtPart_U.Text != curpart_U)
                    {
                        if (oldpart_U == "")
                        {
                            lbl_U.Text = "新建立";
                        }
                        else
                        {
                            lbl_U.Text = "材料變更";
                        }
                    }
                    else
                    {
                        if (curqty_U != txtQty_U.Text || oldqty_U != txtQty_U.Text)
                        {
                            lbl_U.Text = "數量變更";
                        }
                        else
                        {
                            lbl_U.Text = "";
                        }
                    }
                }
                else
                //欄位空白,但舊材料名有存在代表此材料被刪除了
                {
                    if (oldpart_U != "")
                    {
                        lbl_U.Text = "材料變更";
                    }
                    else
                    {
                        lbl_U.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-checkP" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(lbl_B.Text=="" && lbl_Z.Text == "" && lbl_U.Text == "" && lbl_R.Text == "" )
            {
                btnSaveMaterial.Enabled = false;
                btnUpdateQuote.Enabled = false;
            }
            else
            {
                btnSaveMaterial.Enabled = true;
                if (clsGlobal.checkRightFlag("參照法更新報價") == false)
                {
                    btnUpdateQuote.Enabled = false;
                }
                else
                {
                    btnUpdateQuote.Enabled = true;
                }
            }
        }

        private Boolean check_P1(string strPart,int intPart)
        {
            Boolean Flag = false;
            if(strPart == txtPart_B.Text && intPart!=1)
            {
                Flag = true;
            }
            if (strPart == txtPart_Z.Text && intPart != 3)
            {
                Flag = true;
            }
            if (strPart == txtPart_U.Text && intPart != 4)
            {
                Flag = true;
            }
            return Flag;
        }
        public static string strCustomerID = "";
        private void btnInq_Customer_Click(object sender, EventArgs e)
        {
            frmRefer_Inq_Customer frmRefer_Inq_Customer = new frmRefer_Inq_Customer();
            frmRefer_Inq_Customer.ShowInTaskbar = false;//圖示不顯示在工作列
            frmMain frmMain = (frmMain)this.MdiParent;
            frmRefer_Inq_Customer.Location = new Point(0,55);
            //frmRefer_Inq_Customer.Location = frmMain.gbMain.Location;
            //frmRefer_Inq_Customer.Width = System.Windows.Forms.SystemInformation.WorkingArea.Width;
            //frmRefer_Inq_Customer.Height=System.Windows.Forms.SystemInformation.WorkingArea.Height-60;
            frmRefer_Inq_Customer.Width = frmMain.gbMain.Width;
            frmRefer_Inq_Customer.Height = frmMain.gbMain.Height;

            //frmRefer_Inq_Customer.FormBorderStyle = FormBorderStyle.None;
            //frmRefer_Inq_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            frmRefer_Inq_Customer.ShowDialog();
            if (strCustomerID != "")
            {

            }
            else
            {

            }
        }

        
    }
}
