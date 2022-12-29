using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Price2
{
    public partial class frmRefer : Form
    {
        public static string rstrWho;   //判斷從哪個程式來的
        public static string strID;     //傳入的客號
        public static string strPartID = "";     //傳入的材料
        public static string strQty = "";     //傳入的數量
        Boolean tchk=false;     //
        Boolean schk = false;     //
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

                //ToolTip：當游標停滯在某個控制項時，就會跳出一個小視窗
                ToolTip toolTip1 = new ToolTip();

                // Set up the delays for the ToolTip.
                toolTip1.AutoPopDelay = 5000;
                toolTip1.InitialDelay = 100;
                toolTip1.ReshowDelay = 50;
                // Force the ToolTip text to be displayed whether or not the form is active.
                toolTip1.ShowAlways = true;

                // Set up the ToolTip text for the Button and Checkbox.
                toolTip1.SetToolTip(this.btnB, "選取材料");
                toolTip1.SetToolTip(this.btnZ, "選取材料");
                toolTip1.SetToolTip(this.btnU, "選取材料");
                toolTip1.SetToolTip(this.btnInq_Customer, "選取客號");

                if(rstrWho=="frmBOMPrice")
                {
                    btnInq_Customer.Visible = false;
                    btnDelete.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Enabled = false;
                }
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
                        txtCZF.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-txtID_KeyDown" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            getData();
        }

        private void btnClearMaterial_Click(object sender, EventArgs e) //清除材料
        {
            //清除材料相關欄位
            try
            {
                strPartID = "";
                strQty = "";
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
                if(rstrWho!="frmBOMPrice")
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

        private void btnClose_Click(object sender, EventArgs e) //結束
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

                    schk = false;
                    checkP();
                    if (txtQty_B.Text != "" || txtQty_Z.Text != "" || txtQty_U.Text != "" || txtRate.Text != "")
                    {
                        //frmBOMPrice.Label = "參照法有異動";
                    }
                    else
                    {
                        //frmBOMPrice.Label = "";
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
                    if(dt.Rows.Count==0)
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
                    if (dt.Rows.Count==0)
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
                    if (dt.Rows.Count==0)
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
                
                if (lbl_B.Text == "" && lbl_Z.Text == "" && lbl_U.Text == "" && lbl_R.Text == "" && schk == false)
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
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-checkP" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnInq_Customer_Click(object sender, EventArgs e)
        {
            //呼叫"選擇訂單的產品編號",並將結果傳入客號
            try
            {
                strID = "";
                frmRefer_Inq_Customer frmRefer_Inq_Customer = new frmRefer_Inq_Customer();
                frmRefer_Inq_Customer.ShowInTaskbar = false;    //圖示不顯示在工作列
                frmMain frmMain = (frmMain)this.MdiParent;
                frmRefer_Inq_Customer.Location = new Point(0, 55);
                frmRefer_Inq_Customer.Width = frmMain.gbMain.Width;
                frmRefer_Inq_Customer.Height = frmMain.gbMain.Height;
                frmRefer_Inq_Customer.ShowDialog();

                if (strID != "")
                {
                    txtID.Text = strID;
                    getData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Customer_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()
        {
            //取得客號相關DATA
            try
            {
                txtID.Text = txtID.Text.Trim();
                String strSQL = "";
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                strSQL = $@"select *
                                    from   odi
                                    where  odi_customerid = '{txtID.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    //檢查參照法材料名欄位是否空白,如果是自動帶入報價單中的包裝運材料
                    if (rstrWho == "frmBOMPrice" && dt.Rows[0]["odi_pripart01"].ToString() == "" && dt.Rows[0]["odi_pripart02"].ToString() == "" && dt.Rows[0]["odi_pripart04"].ToString() == "" && dt.Rows[0]["odi_pripart05"].ToString() == "")
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
                    txtLine.ReadOnly = true;  //關閉線路修改
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
                    if (string.IsNullOrEmpty(dt.Rows[0]["odi_pripart01"].ToString()) == false)    //外箱
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
                        curqty_R = ((double)dt2.Rows[0]["pri_tbprice"] * (double)dt2.Rows[0]["pri_perqty"]).ToString();
                    }
                    else
                    {
                        curqty_R = "0";
                    }
                    if (string.IsNullOrEmpty(dt.Rows[0]["odi_priqty04"].ToString()) == false && dt.Rows[0]["odi_priqty04"].ToString() != "0")  //不良率
                    {
                        txtRate.Text = ((double)dt.Rows[0]["odi_priqty04"] * 100).ToString();
                        oldqty_R = dt.Rows[0]["odi_priqty04"].ToString();
                    }
                    else
                    {
                        oldqty_R = "0";
                    }
                    btnSave.Enabled = false;
                }
                else
                {
                    if (MessageBox.Show(this, "你需要創建一個新的產品資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        lblUser.Text = "";    //用戶：36
                        lblDate.Text = "";    //最後儲存日期：38
                        lblUser_U.Text = "";    //用戶：69
                        lblDate_U.Text = "";    //最後儲存日期：71
                        txtPrice.Text = "";    //報價：16
                        txtLine.Text = "";    //線路：17
                        txtLine.Enabled = true;
                        txtCurrency.Text = "NT$";   //幣別：
                        strActive = "0";
                        txtCZF.Text = "";    //參照法14
                        txtName.Text = "";    //客戶：20
                        txtXZ.Text = "";    //材積：47
                        txtZX.Text = "";    //箱量：48
                        txtJZ.Text = "";    //淨重：64
                        txtMZ.Text = "";    //毛重：49
                        txtMO.Text = "MO";    //MO：50
                        lblUser_U.Text = "";    //用戶：
                        lblDate_U.Text = "";    //最後儲存日期：

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
                        curpart_Z = ""; //外箱
                        curpart_B = ""; //包裝
                        curpart_U = ""; //運費
                        curqty_Z = "0"; //外箱
                        curqty_B = "0"; //包裝
                        curqty_U = "0"; //運費
                        curqty_R="0";   //不良率

                        btnSave.Enabled = true; //儲存

                    }
                    else
                    {
                        btnClearCZF.PerformClick();
                    }
                }
                //檢查不良率

                if (txtRate.Text == "0" || txtRate.Text == "")
                {
                    checkDefect();
                }
                if (clsGlobal.ValidateString(txtQty_Z.Text, 11) == true //判斷浮點數
                    && clsGlobal.ValidateString(txtXZ.Text, 11) == true //判斷浮點數
                    && Convert.ToDouble(txtXZ.Text) > 0
                    && txtPart_Z.Text != "")
                {
                    txtQty_Z.Text = txtXZ.Text;
                }
                if (clsGlobal.ValidateString(txtQty_U.Text, 11) == true //判斷浮點數
                    && clsGlobal.ValidateString(txtXZ.Text, 11) == true //判斷浮點數
                    && Convert.ToDouble(txtXZ.Text) > 0
                    && txtPart_U.Text != "")
                {
                    txtQty_U.Text = txtXZ.Text;
                }
                schk = false;
                //材料數量異動檢查
                checkP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)    //刪除
        {
            //刪除
            try
            {
                
                string strSQL = "";
                DataTable dt = new DataTable();
                if (clsGlobal.checkRightFlag("參照法刪除權限") == false)
                {
                    MessageBox.Show("你沒有參照法刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                //strSQL = $@"exec odi_save1 '{txtID.Text.Trim()}','{txtCZF.Text.Trim()}','{strCZF1}',{txtPrice.Text.Trim()},'{txtLine.Text.Trim()}','{txtCurrency.Text.Trim()}','{txtName.Text.Trim()}','{txtMO.Text.Trim()},'{clsGlobal.strG_User}'," + strActive;
                strSQL = $@"select * from ord where ord_assy = '{txtID.Text.Trim()}'";
                dt=clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0)
                {
                    MessageBox.Show("該客號已有成交工單記錄,不能被刪除!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show(this, "你確定要刪除這個產品資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    strSQL = $@"delete odi where odi_customerid = '{txtID.Text.Trim()}'";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("已經刪除完成!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClearCZF.PerformClick(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnU_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            //查詢材料並傳入
            frmRefer_Inq_Material frmRefer_Inq_Material = new frmRefer_Inq_Material();
            frmRefer_Inq_Material.strID=txtID.Text;
            frmRefer_Inq_Material.ShowDialog();
            if(strPartID != "")
            {
                txtPart_B.Text = strPartID;
                txtQty_B.Text = strQty;
                checkP();
            }
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            //查詢材料並傳入
            frmRefer_Inq_Material frmRefer_Inq_Material = new frmRefer_Inq_Material();
            frmRefer_Inq_Material.strID = txtID.Text;
            frmRefer_Inq_Material.ShowDialog();
            if (strPartID != "")
            {
                txtPart_Z.Text = strPartID;
                txtQty_Z.Text = strQty;
                checkP();
            }
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            //查詢材料並傳入
            frmRefer_Inq_Material frmRefer_Inq_Material = new frmRefer_Inq_Material();
            frmRefer_Inq_Material.strID = txtID.Text;
            frmRefer_Inq_Material.ShowDialog();
            if (strPartID != "")
            {
                txtPart_U.Text = strPartID;
                txtQty_U.Text = strQty;
                checkP();
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            btnSaveMaterial.Enabled = true; //可以儲存材料
            schk = true;
        }

        private void txtPart_B_TextChanged(object sender, EventArgs e)
        {
            btnSaveMaterial.Enabled = true; //可以儲存材料
            schk = true;
        }

        private void txtQty_B_TextChanged(object sender, EventArgs e)
        {
            btnSaveMaterial.Enabled = true; //可以儲存材料
            schk = true;
        }

        private void txtPart_Z_TextChanged(object sender, EventArgs e)
        {
            btnSaveMaterial.Enabled = true; //可以儲存材料
            schk = true;
        }

        private void txtQty_Z_TextChanged(object sender, EventArgs e)
        {
            btnSaveMaterial.Enabled = true; //可以儲存材料
            schk = true;
        }

        private void txtPart_U_TextChanged(object sender, EventArgs e)
        {
            btnSaveMaterial.Enabled = true; //可以儲存材料
            schk = true;
        }

        private void txtQty_U_TextChanged(object sender, EventArgs e)
        {
            btnSaveMaterial.Enabled = true; //可以儲存材料
            schk = true;
        }

        private void txtZX_TextChanged(object sender, EventArgs e)
        {
            btnSaveMaterial.Enabled = true; //可以儲存材料
            schk = true;
        }

        private void txtXZ_TextChanged(object sender, EventArgs e)
        {
            btnSaveMaterial.Enabled = true; //可以儲存材料
            schk = true;
        }

        private void txtJZ_TextChanged(object sender, EventArgs e)
        {
            btnSaveMaterial.Enabled = true; //可以儲存材料
            schk = true;
        }

        private void txtMZ_TextChanged(object sender, EventArgs e)
        {
            btnSaveMaterial.Enabled = true; //可以儲存材料
            schk = true;
        }

        private void txtPart_B_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtPart_B.Text=="")
                {
                    txtQty_B.Text = "0";
                }
                txtQty_B.Focus();
            }
        }

        private void txtPart_Z_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPart_Z.Text == "")
                {
                    txtQty_Z.Text = "0";
                }
                txtQty_Z.Focus();
            }
        }

        private void txtPart_U_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPart_U.Text == "")
                {
                    txtQty_U.Text = "0";
                }
                txtQty_U.Focus();
            }
        }

        private void txtPart_B_Leave(object sender, EventArgs e)
        {
            if (txtPart_B.Text == "")
            {
                txtQty_B.Text = "0";
            }
            else
            {
                if( txtQty_B.Text == "0"|| txtQty_B.Text == "")
                {
                    txtQty_B.Text = "1";
                }
            }
            checkP();
        }

        private void txtPart_Z_Leave(object sender, EventArgs e)
        {
            if (txtPart_Z.Text == "")
            {
                txtQty_Z.Text = "0";
            }
            else
            {
                if (txtQty_Z.Text == "0" || txtQty_Z.Text == "")
                {
                    txtQty_Z.Text = "1";
                }
            }
            checkP();
        }

        private void txtPart_U_Leave(object sender, EventArgs e)
        {
            if (txtPart_U.Text == "")
            {
                txtQty_U.Text = "0";
            }
            else
            {
                if( txtQty_U.Text == "0"|| txtQty_U.Text == "")
                {
                    txtQty_U.Text = "1";
                }
            }
            checkP();
        }

        private void txtQty_B_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Enter)
            {
                txtPart_Z.Focus();
            }
        }

        private void txtQty_Z_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPart_U.Focus();
            }
        }

        private void txtQty_U_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtZX.Focus();
            }
        }

        private void txtQty_B_Leave(object sender, EventArgs e)
        {
            checkP();
        }

        private void txtQty_Z_Leave(object sender, EventArgs e)
        {
            checkP();
        }

        private void txtQty_U_Leave(object sender, EventArgs e)
        {
            checkP();
        }

        private void checkDefect()
        {
            try
            {
                if (txtID.Text == "")
                {
                    return;
                }
                String strSQL = "";
                DataTable dt = new DataTable();
                //包裝
                strSQL = $@"select distinct pri_part,
                                        pri_tbprice,
                                        pri_perqty
                        from   pri
                        where  pri_customerid = '{txtID.Text}'
                               and pri_part like '包/%'
                               and pri_newcostchk like 'N%'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count > 1)
                    {
                        MessageBox.Show("包/材料有" + dt.Rows.Count.ToString()  + "個,請檢查報價單或洽資訊人員檢查!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if(txtPart_B.Text=="")
                        {
                            oldpart_B = txtPart_B.Text;
                        }
                    }
                }
                //外箱
                strSQL = $@"select distinct pri_part,
                                        pri_tbprice,
                                        pri_perqty
                        from   pri
                        where  pri_customerid = '{txtID.Text}'
                               and pri_part like '裝/%'
                               and pri_newcostchk like 'N%'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count > 1)
                    {
                        MessageBox.Show("裝/材料有" + dt.Rows.Count.ToString() + "個,請檢查報價單或洽資訊人員檢查!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (txtPart_Z.Text == "")
                        {
                            oldpart_Z = txtPart_Z.Text;
                        }
                    }
                }
                //運費
                strSQL = $@"select distinct pri_part,
                                        pri_tbprice,
                                        pri_perqty
                        from   pri
                        where  pri_customerid = '{txtID.Text}'
                               and pri_part like '運/%'
                               and pri_newcostchk like 'N%'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count > 1)
                    {
                        MessageBox.Show("運/材料有" + dt.Rows.Count.ToString() + "個,請檢查報價單或洽資訊人員檢查!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (txtPart_U.Text == "")
                        {
                            oldpart_U = txtPart_U.Text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-checkDefect" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPart_B.Focus();
            }
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            checkP();
        }

        private void txtZX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtXZ.Focus();
            }
        }

        private void txtXZ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtJZ.Focus();
            }
        }

        private void txtJZ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMZ.Focus();
            }
        }

        private void txtMZ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void txtZX_Leave(object sender, EventArgs e)
        {
            if(txtZX.Text!="" && clsGlobal.ValidateString(txtZX.Text,11) ==false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtZX.Focus();
            }
        }

        private void txtXZ_Leave(object sender, EventArgs e)
        {
            if (txtXZ.Text != "" && clsGlobal.ValidateString(txtXZ.Text, 11) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtXZ.Focus();
            }
        }

        private void txtJZ_Leave(object sender, EventArgs e)
        {
            if (txtJZ.Text != "" && clsGlobal.ValidateString(txtJZ.Text, 11) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtJZ.Focus();
            }
        }

        private void txtMZ_Leave(object sender, EventArgs e)
        {
            if (txtMZ.Text != "" && clsGlobal.ValidateString(txtMZ.Text, 11) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMZ.Focus();
            }
        }

        private void txtZX_Enter(object sender, EventArgs e)
        {
            if(txtZX.Text == "" || clsGlobal.ValidateString(txtZX.Text, 11) == false)
            {
                return;
            }
            txtZX.Text = (txtZX.Text == "0" ? "" : txtZX.Text);
        }

        private void txtXZ_Enter(object sender, EventArgs e)
        {
            if (txtXZ.Text == "" || clsGlobal.ValidateString(txtXZ.Text, 11) == false)
            {
                return;
            }
            txtXZ.Text = (txtXZ.Text == "0" ? "" : txtXZ.Text);
        }

        private void txtJZ_Enter(object sender, EventArgs e)
        {
            if (txtJZ.Text == "" || clsGlobal.ValidateString(txtJZ.Text, 11) == false)
            {
                return;
            }
            txtJZ.Text = (txtJZ.Text == "0" ? "" : txtJZ.Text);
        }

        private void txtMZ_Enter(object sender, EventArgs e)
        {
            if (txtMZ.Text == "" || clsGlobal.ValidateString(txtMZ.Text, 11) == false)
            {
                return;
            }
            txtMZ.Text = (txtMZ.Text == "0" ? "" : txtMZ.Text);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            schk = true;
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtCZF.Focus();
            }
        }

        private void txtLine_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            schk = true;
        }

        private void txtLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtZX.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)  //儲存
        {
            //儲存
            try
            {
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                string strSQL = "";
                DataTable dt = new DataTable();
                if (clsGlobal.checkRightFlag("參照法上半部儲存") == false)
                {
                    MessageBox.Show("你沒有參照法上半部儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                txtPrice.Text = (txtPrice.Text==""? "0":txtPrice.Text);
                txtZX.Text = (txtZX.Text == "" ? "0" : txtZX.Text);
                txtXZ.Text = (txtXZ.Text == "" ? "0" : txtXZ.Text);
                txtJZ.Text = (txtJZ.Text == "" ? "0" : txtJZ.Text);
                txtMZ.Text = (txtMZ.Text == "" ? "0" : txtMZ.Text);
                //strSQL = $@"exec odi_save1 '{txtID.Text.Trim()}','{txtCZF.Text.Trim()}','{strCZF1}',{txtPrice.Text.Trim()},'{txtLine.Text.Trim()}','{txtCurrency.Text.Trim()}','{txtName.Text.Trim()}','{txtMO.Text.Trim()},'{clsGlobal.strG_User}'," + strActive;
                strSQL = $@"exec odi_save1 '{txtID.Text.Trim()}','{txtCZF.Text.Trim()}','',{txtPrice.Text.Trim()},'{txtLine.Text.Trim()}','{txtCurrency.Text.Trim()}','{txtName.Text.Trim()}','{txtMO.Text.Trim()},'{clsGlobal.strG_User}', 0 ";
                clsDB.Execute(strSQL);
                MessageBox.Show("已經儲存完成!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;//滑鼠還原預設
                schk=false;
                getData();
                if(txtQty_B.Text!="" || txtQty_Z.Text != "" || txtQty_U.Text != "" || txtRate.Text != "" )
                {
                    //frmBOMPrice.Label = "參照法有異動";
                }
                else
                {
                    //frmBOMPrice.Label = "";
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateQuote_Click(object sender, EventArgs e)   //更新報價
        {
            //更新報價
            try
            {
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                string strSQL = "";
                DataTable dt = new DataTable();
                
                if (clsGlobal.checkRightFlag("參照法更新報價") == false)
                {
                    MessageBox.Show("你沒有參照法更新報價權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                tchk = false;
                if (txtPart_B.Text != "" && txtQty_B.Text == "0")
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
                if (tchk == true)
                {
                    MessageBox.Show("材料數量不可為零,請檢查!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //if (frmBOMPrice.tsave == false)
                //{
                //    MessageBox.Show("產品報價有變更尚未儲存,請先儲存報價再進行更新報價!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                if (rstrWho != "frmBOMPrice")
                {
                    MessageBox.Show("更新報價請先進入產品報價作業!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show(this, "更新報價應由業務人員來處理,您確定要更新嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //包裝材料檢查
                    if(lbl_B.Text!="")  //檢查是否被修改
                    {
                        strSQL = $@"select na5_assy
                                    from   na5
                                    where  na5_computername = Host_name()
                                           and na5_assy = '{txtPart_B}' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if(((txtPart_B.Text!=curpart_B && dt.Rows.Count == 0) || txtQty_B.Text != curqty_B) 
                            && curpart_B != "" 
                            && txtPart_B.Text != "")    //正常修改狀況
                        {
                            strSQL = $@"update na5
                                        set    na5_assy = '{txtPart_B.Text}',
                                               na5_perqty = '{txtQty_B.Text}'
                                        where  na5_computername = Host_name()
                                               and na5_assy = '{curpart_B}' ";
                            clsDB.Execute(strSQL);
                            oldpart_B=txtPart_B.Text;
                            oldqty_B=txtQty_B.Text;
                            strSQL = $@"update na5
                                        set    na5_tbprice = ap3_tbprice,
                                               na5_cost = Round(na5_perqty * ap3_tbprice, 6)
                                        from   na5,
                                               ap3
                                        where  na5_computername = Host_name()
                                               and na5_assy = '{txtPart_B.Text}'
                                               and ap3_part = '{txtPart_B.Text}' ";
                            clsDB.Execute(strSQL);
                        }
                        else if(oldpart_B != "" && txtPart_B.Text == "" && oldpart_B == curpart_B)  //刪除狀況
                        {
                            strSQL = $@"delete na5 where na5_computername=HOST_NAME() and na5_assy='{oldpart_B}'";
                            clsDB.Execute(strSQL);
                            oldpart_B = "";
                        }
                        else if (curpart_B == "" && txtPart_B.Text != "" && dt.Rows.Count==0)  //新增狀況
                        {
                            strSQL = $@"insert na5
                                               (
                                                      na5_assy,
                                                      na5_tbprice,
                                                      na5_perqty,
                                                      na5_cost,
                                                      na5_um,
                                                      na5_firstname,
                                                      na5_computername,
                                                      na5_perqtycal,
                                                      na5_set
                                               )
                                        select top 1
                                                  '{txtPart_B.Text}',
                                                  ap3_tbprice,
                                                  '{txtQty_B.Text}',
                                                  ROUND(ap3_tbprice * {txtQty_B.Text},6),
                                                  '',
                                                  ap1_assy,
                                                  HOST_NAME(),
                                                  '',
                                                  ''
                                        from      pri,
                                                  ap3
                                        left join ap2
                                        on        ap2_part=ap3_assy
                                        left join ap1
                                        on        ap1_part=ap2_assy
                                        where     pri_customerid = '{txtID.Text}'
                                        and       ap3_part='{txtPart_B.Text}'
                                        and       ap1_assy is not null";
                            clsDB.Execute(strSQL);
                            oldpart_B = txtPart_B.Text;
                        }
                    }

                    //外箱材料檢查
                    if (lbl_Z.Text != "")  //檢查是否被修改
                    {
                        strSQL = $@"select na5_assy
                                    from   na5
                                    where  na5_computername = Host_name()
                                           and na5_assy = '{txtPart_Z}' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (((txtPart_Z.Text != curpart_Z && dt.Rows.Count == 0) || txtQty_Z.Text != curqty_B)
                            && curpart_Z != ""
                            && txtPart_Z.Text != "")    //正常修改狀況
                        {
                            strSQL = $@"update na5
                                        set    na5_assy = '{txtPart_Z.Text}',
                                               na5_perqty = '{txtQty_Z.Text}'
                                        where  na5_computername = Host_name()
                                               and na5_assy = '{curpart_Z}' ";
                            clsDB.Execute(strSQL);
                            oldpart_Z = txtPart_Z.Text;
                            oldqty_Z = txtQty_Z.Text;
                            strSQL = $@"update na5
                                        set    na5_tbprice = ap3_tbprice,
                                               na5_cost = Round(ap3_tbprice / na5_perqty, 6)
                                        from   na5,
                                               ap3
                                        where  na5_computername = Host_name()
                                               and na5_assy = '{txtPart_B.Text}'
                                               and ap3_part = '{txtPart_B.Text}' ";
                            clsDB.Execute(strSQL);
                        }
                        else if (oldpart_Z != "" && txtPart_Z.Text == "" && oldpart_Z == curpart_Z)  //刪除狀況
                        {
                            strSQL = $@"delete na5 where na5_computername=HOST_NAME() and na5_assy='{oldpart_Z}'";
                            clsDB.Execute(strSQL);
                            oldpart_Z = "";
                        }
                        else if (curpart_Z == "" && txtPart_Z.Text != "" && dt.Rows.Count == 0)  //新增狀況
                        {
                            strSQL = $@"insert na5
                                               (
                                                      na5_assy,
                                                      na5_tbprice,
                                                      na5_perqty,
                                                      na5_cost,
                                                      na5_um,
                                                      na5_firstname,
                                                      na5_computername,
                                                      na5_perqtycal,
                                                      na5_set
                                               )
                                        select top 1
                                                  '{txtPart_Z.Text}',
                                                  ap3_tbprice,
                                                  '{txtQty_Z.Text}',
                                                  ROUND(ap3_tbprice * {txtQty_Z.Text},6),
                                                  '',
                                                  ap1_assy,
                                                  HOST_NAME(),
                                                  '',
                                                  ''
                                        from      pri,
                                                  ap3
                                        left join ap2
                                        on        ap2_part=ap3_assy
                                        left join ap1
                                        on        ap1_part=ap2_assy
                                        where     pri_customerid = '{txtID.Text}'
                                        and       ap3_part='{txtPart_Z.Text}'
                                        and       ap1_assy is not null";
                            clsDB.Execute(strSQL);
                            oldpart_Z = txtPart_Z.Text;
                        }
                    }

                    //運費材料檢查
                    if (lbl_U.Text != "")  //檢查是否被修改
                    {
                        strSQL = $@"select na5_assy
                                    from   na5
                                    where  na5_computername = Host_name()
                                           and na5_assy = '{txtPart_U}' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (((txtPart_U.Text != curpart_U && dt.Rows.Count == 0) || txtQty_Z.Text != curqty_B)
                            && curpart_U != ""
                            && txtPart_U.Text != "")    //正常修改狀況
                        {
                            strSQL = $@"update na5
                                        set    na5_assy = '{txtPart_U.Text}',
                                               na5_perqty = '{txtQty_U.Text}'
                                        where  na5_computername = Host_name()
                                               and na5_assy = '{curpart_U}' ";
                            clsDB.Execute(strSQL);
                            oldpart_U = txtPart_U.Text;
                            oldqty_U = txtQty_U.Text;
                            strSQL = $@"update na5
                                        set    na5_tbprice = ap3_tbprice,
                                               na5_cost = Round(ap3_tbprice / na5_perqty, 6)
                                        from   na5,
                                               ap3
                                        where  na5_computername = Host_name()
                                               and na5_assy = '{txtPart_U.Text}'
                                               and ap3_part = '{txtPart_U.Text}' ";
                            clsDB.Execute(strSQL);
                        }
                        else if (oldpart_U != "" && txtPart_U.Text == "" )  //刪除狀況
                        {
                            strSQL = $@"delete na5 where na5_computername=HOST_NAME() and na5_assy='{oldpart_U}'";
                            clsDB.Execute(strSQL);
                            oldpart_U = "";
                        }
                        else if (curpart_U == "" && txtPart_U.Text != "" && dt.Rows.Count == 0)  //新增狀況
                        {
                            strSQL = $@"insert na5
                                               (
                                                      na5_assy,
                                                      na5_tbprice,
                                                      na5_perqty,
                                                      na5_cost,
                                                      na5_um,
                                                      na5_firstname,
                                                      na5_computername,
                                                      na5_perqtycal,
                                                      na5_set
                                               )
                                        select top 1
                                                  '{txtPart_U.Text}',
                                                  ap3_tbprice,
                                                  '{txtQty_U.Text}',
                                                  ROUND(ap3_tbprice * {txtQty_U.Text},6),
                                                  '',
                                                  ap1_assy,
                                                  HOST_NAME(),
                                                  '',
                                                  ''
                                        from      pri,
                                                  ap3
                                        left join ap2
                                        on        ap2_part=ap3_assy
                                        left join ap1
                                        on        ap1_part=ap2_assy
                                        where     pri_customerid = '{txtID.Text}'
                                        and       ap3_part='{txtPart_U.Text}'
                                        and       ap1_assy is not null";
                            clsDB.Execute(strSQL);
                            oldpart_U = txtPart_U.Text;
                        }
                    }

                    //不良率檢查
                    if(lbl_R.Text != "")
                    {
                        strSQL = $@"update na5
                                    set    na5_perqty = '{txtRate.Text}',
                                           na5_cost = Round('{txtRate.Text}' * na5_tbprice, 6 )
                                    where  na5_computername = Host_name()
                                           and na5_assy like '不良%'";
                        clsDB.Execute(strSQL);
                    }
                    
                    strSQL = $@"update odi
                                set    odi_oldpart01 = '{txtPart_Z.Text}',
                                       odi_oldpart02 = '{txtPart_B.Text}',
                                       odi_oldpart05 = '{txtPart_U.Text}'
                                where  odi_customerid = '{txtID.Text}'";
                    clsDB.Execute(strSQL);

                    //bomprice.chk_price 以後加
                    checkP();
                    MessageBox.Show("已經更新報價完成!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSaveMaterial.PerformClick();
                    btnUpdateQuote.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopyProofingCZF_Click(object sender, EventArgs e)   //複製打樣單參照法
        {
            //複製打樣單參照法
            try
            {
                InputBox input = new InputBox();
                input.ShowInTaskbar = false;//圖示不顯示在工作列
                input.lblInfo.Text = "請輸入打樣單產品編號:";
                input.Text = "複製打樣單參照法";
                input.txtIpnut.Text = txtID.Text;
                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if(input.GetMsg() != "")
                    {
                        string strSQL = "";
                        DataTable dt = new DataTable();
                        strSQL = $@"select distinct dyi_id,
                                                dyi_czf
                                    from   dyi
                                    where  dyi_id = '{input.GetMsg().Trim()}' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            txtCZF.Text = dt.Rows[0]["dyi_czf"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("無此客號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCopyProofingCZF_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)  //複製
        {
            //複製
            try
            {
                if (clsGlobal.checkRightFlag("參照法複製權限") == false)
                {
                    MessageBox.Show("你沒有參照法複製權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(txtID.Text=="")
                {
                    MessageBox.Show("你不能複製一個空號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                InputBox input = new InputBox();
                input.ShowInTaskbar = false;//圖示不顯示在工作列
                input.lblInfo.Text = "請輸入你要複製的新客號:";
                input.Text = "複製";
                input.txtIpnut.Text = "";
                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (input.GetMsg() != "")
                    {
                        string strSQL = "";
                        DataTable dt = new DataTable();
                        strSQL = $@"select * 
                                    from   odi
                                    where  odi_customerid = '{input.GetMsg().Trim()}' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            if (MessageBox.Show(this, "客號已經存在,你要覆蓋它嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                strSQL = $@"delete odi where odi_customerid='{input.GetMsg().Trim()}'";
                                clsDB.Execute(strSQL);
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("無此客號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        strSQL = $@"insert odi
                                           (odi_customerid,
                                            odi_czf,
                                            odi_czf1,
                                            odi_currency,
                                            odi_customer,
                                            odi_czftotal,
                                            odi_mo,
                                            odi_xz,
                                            odi_mz,
                                            odi_zx,
                                            odi_czfpi,
                                            odi_pricost,
                                            odi_jz,
                                            odi_username,
                                            odi_type,
                                            odi_wg,
                                            odi_vendorid,
                                            odi_oldll,
                                            odi_gp,
                                            odi_gc,
                                            odi_active)
                                    select '{input.GetMsg().Trim()}',
                                           odi_czf,
                                           odi_czf1,
                                           odi_currency,
                                           odi_customer,
                                           odi_czftotal,
                                           odi_mo,
                                           odi_xz,
                                           odi_mz,
                                           odi_zx,
                                           odi_czfpi,
                                           odi_pricost,
                                           odi_jz,
                                           '{clsGlobal.strG_User}',
                                           odi_type,
                                           odi_wg,
                                           odi_vendorid,
                                           odi_oldll,
                                           odi_gp,
                                           odi_gc,
                                           odi_active
                                    from   odi
                                    where  odi_customerid = '{txtID.Text.Trim()}' ";
                        clsDB.Execute(strSQL);

                        strSQL = $@"update odi
                                    set    odi_customer = pri_customer,
                                           odi_line = pri_assy,
                                           odi_price = pri_pricost,
                                           odi_currency = pri_currency
                                    from   odi,
                                           pri
                                    where  odi_customerid = pri_customerid
                                           and odi_customerid = 'input.GetMsg().Trim()' ";
                        clsDB.Execute(strSQL);

                        MessageBox.Show("已經複製完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClearCZF.PerformClick(); 
                        txtID.Text = input.GetMsg().Trim();
                        getData();
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
