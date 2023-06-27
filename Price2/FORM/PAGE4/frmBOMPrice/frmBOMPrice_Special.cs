using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Price2
{
    public partial class frmBOMPrice_Special : Form
    {
        string strCal_PrePrice = ""; //單價計算式
        string strCal_Qty = ""; //數量計算式
        public static string rstrID = "";    //frmBOMPrice傳入的客號ID
        public static string rstrPart = "";    //frmBOMPrice傳入的材料ID
        public static string rstrPrice = "";    //frmBOMPrice傳入的台幣換算單價(金額)
        public static string rstrWho = "";  //frmBOMPrice傳入的功能
        public frmBOMPrice_Special()
        {
            InitializeComponent();
        }

        private void txtPerPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                strCal_PrePrice = "";
                if (txtPerPrice.Text == "")
                {
                    txtPerPrice.Text = "0";
                }
                else
                {
                    strCal_PrePrice = txtPerPrice.Text;
                    //計算式  計算機 引用using System.Data
                    txtPerPrice.Text = new DataTable().Compute(txtPerPrice.Text, null).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-txtPerPrice_Leave" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPerPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void txtPerPrice_Enter(object sender, EventArgs e)
        {
            if(strCal_PrePrice!="")
            {
                txtPerPrice.Text=strCal_PrePrice;    
            }
            else
            {
                txtPerPrice.Text = (txtPerPrice.Text == "0" ? txtPerPrice.Text = "" : txtPerPrice.Text = txtPerPrice.Text);
            }
        }

        private void txtPerPrice_DoubleClick(object sender, EventArgs e)
        {
            if (txtPerPrice.Text != "")
            {
                MessageBox.Show(" 計算式：  " + strCal_PrePrice, "計算式", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && radioSpecial.Checked)
            {
                txtVendorName.Focus();
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            try
            {
                strCal_Qty = "";
                if (txtQty.Text == "")
                {
                    txtQty.Text = "0";
                }
                else
                {
                    strCal_Qty = txtQty.Text;
                    //計算式  計算機 引用using System.Data
                    txtQty.Text = new DataTable().Compute(txtQty.Text, null).ToString();
                }
                if (txtQty.Text == "")
                {
                    txtQty.Text = "0";
                }
                if (txtPerPrice.Text == "")
                {
                    txtPerPrice.Text = "0";
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select cur_convert from cur where cur_code='{cboCurrency.Text}'";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0)
                {
                    lblTbPrice.Text = (Convert.ToDouble(txtPerPrice.Text) * Convert.ToDouble(txtQty.Text) * Convert.ToDouble(dt.Rows[0]["cur_convert"])).ToString("0.######");
                }
                else
                {
                    lblTbPrice.Text = (Convert.ToDouble(txtPerPrice.Text) * Convert.ToDouble(txtQty.Text)).ToString("0.######");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-txtPerPrice_Leave" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQty_Enter(object sender, EventArgs e)
        {
            if (strCal_Qty != "")
            {
                txtQty.Text = strCal_Qty;
            }
            else
            {
                txtQty.Text = (txtQty.Text == "0" ? txtQty.Text = "" : txtQty.Text = txtQty.Text);
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if(clsGlobal.StrLength(txtID.Text)>0)
            {
                lblStrLength.Text = clsGlobal.StrLength(txtID.Text).ToString();
            }
            else
            {
                lblStrLength.Text = "";
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPerPrice.Focus();
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select asp_id from asp where asp_id='{txtID.Text.Trim()}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("火車頭材料名已存在此名稱,請更換名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Focus();
                    return;
                }

                strSQL = $@"select * from ptx where ptx_name='{txtID.Text.Trim()}' and ptx_customerid='{rstrID}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    txtPerPrice.Text = dt.Rows[0]["ptx_tbdj"].ToString();
                    txtQty.Text = dt.Rows[0]["ptx_qty"].ToString();
                    txtVendorID.Text = (string.IsNullOrEmpty(dt.Rows[0]["ptx_vendorid"].ToString()) ? "" : dt.Rows[0]["ptx_vendorid"].ToString());
                    cboCurrency.Text = dt.Rows[0]["ptx_yfcurrency"].ToString();
                    if(dt.Rows[0]["ptx_tbdjcal"].ToString()!="")
                    {
                        strCal_PrePrice = dt.Rows[0]["ptx_tbdjcal"].ToString();
                    }
                    else
                    {
                        strCal_PrePrice = "";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-txtID_Leave" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                if (MessageBox.Show("您確定要刪除此特選材料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    strSQL = $@"select distinct pri_customerid from pri where pri_customerid='{rstrID}' and pri_part='{txtID.Text.Trim()}'";
                    dt = clsDB.sql_select_dt(strSQL);
                    if(dt.Rows.Count > 0)
                    {
                        strSQL = $@"delete from pri where pri_customerid='{rstrID}' and pri_part='{txtID.Text.Trim()}'";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete from ptx where ptx_customerid='{rstrID}' and ptx_name='{txtID.Text.Trim()}'";
                        clsDB.Execute(strSQL);

                        //回frmBOMPrice刪掉特選
                        frmBOMPrice.rstrPart = txtID.Text.Trim();
                        frmBOMPrice.rstrButton = "Delete";
                        MessageBox.Show("刪除完成!請記得儲存報價單!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("無此特選材料名,請檢查!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //結束
            try
            {
                frmBOMPrice.rstrButton = "Close";
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
                txtID.Text = "";
                txtPerPrice.Text = "0";
                txtQty.Text = "0";
                txtVendorID.Text = "";
                txtVendorName.Text = "";
                cboCurrency.Text = "臺幣";
                lblTbPrice.Text = "";
                btnDelete.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            //選取
            try
            {
                if(txtID.Text=="")
                {
                    MessageBox.Show("特選材料名不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Focus();
                    return;
                }
                if (clsGlobal.StrLength( txtID.Text )> 30)
                {
                    MessageBox.Show("材料名稱長度" + clsGlobal.StrLength( txtID.Text ).ToString() + "\n"  +"已超過30個字元!請修改!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Focus();
                    return;
                }
                txtPerPrice.Text = (txtPerPrice.Text == "" ? "0" : txtPerPrice.Text);
                txtQty.Text = (txtQty.Text == "" ? "0" : txtQty.Text);
                if(txtQty.Text=="0" && radioSpecial.Checked)
                {
                    MessageBox.Show("數量不可為零!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQty.Focus();
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select cur_convert from cur where cur_code='{cboCurrency.Text}'";
                dt = clsDB.sql_select_dt(strSQL);
                double convert = 1;
                if (dt.Rows.Count > 0)
                {
                    convert =  Convert.ToDouble(dt.Rows[0]["cur_convert"]);
                }
                else
                {
                    convert = 1;
                }
                lblTbPrice.Text = (Convert.ToDouble(txtPerPrice.Text) * Convert.ToDouble(txtQty.Text) * convert).ToString("0.######");
                strSQL = $@"select {txtPerPrice.Text} * cur_convert as ans from cur where cur_code='{cboCurrency.Text}'";
                dt = clsDB.sql_select_dt(strSQL);
                string tbprice = "";
                if(dt.Rows.Count > 0)
                {
                    tbprice = Convert.ToDouble(dt.Rows[0]["ans"]).ToString("0.######");
                }
                //傳資料回frmBOMPrice
                float ptx_aircost;
                float ptx_kd;
                string ptx_type;
                if (radioSpecial.Checked)
                {
                    frmBOMPrice.rstrPart=txtID.Text;
                    frmBOMPrice.rstrTbprice= tbprice;
                    frmBOMPrice.rstrPerQty=txtQty.Text;
                    frmBOMPrice.rstrCost=lblTbPrice.Text;
                    frmBOMPrice.rstrPtx_chk = "V";
                    frmBOMPrice.rstrQtyCal=strCal_Qty;
                    ptx_aircost = 1;
                    ptx_kd = 0;
                    ptx_type = "1";
                }
                else
                {
                    frmBOMPrice.rstrPart = txtID.Text;
                    frmBOMPrice.rstrTbprice = tbprice;
                    frmBOMPrice.rstrPerQty = txtQty.Text;
                    frmBOMPrice.rstrCost = lblTbPrice.Text;
                    frmBOMPrice.rstrPtx_chk = "R";
                    frmBOMPrice.rstrQtyCal = strCal_Qty;
                    ptx_aircost = 0;
                    ptx_kd = 1;
                    ptx_type = "2";
                }
                strSQL = $@"select distinct pri_assy from pri where pri_customerid='{rstrID}'";
                dt = clsDB.sql_select_dt(strSQL);
                string ptx_assy = "";
                if (dt.Rows.Count > 0)
                {
                    ptx_assy = dt.Rows[0]["pri_assy"].ToString();
                }


                //存回ptx
                strSQL = $@"select ptx_name from ptx where ptx_name='{txtID.Text}' and ptx_customerid = '{rstrID}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strSQL = $@"insert ptx
                                       (ptx_name,
                                        ptx_tbdj,
                                        ptx_qty,
                                        ptx_aircost,
                                        ptx_kd,
                                        ptx_perqty,
                                        ptx_perweight,
                                        ptx_perky,
                                        ptx_yfcurrency,
                                        ptx_vendorid,
                                        ptx_customerid,
                                        ptx_tbdjcal,
                                        ptx_venshortname,
                                        ptx_type,
                                        ptx_perqtycal,
                                        ptx_assy)
                                values ('{txtID.Text}',
                                        {txtPerPrice.Text},
                                        {txtQty.Text},
                                        {ptx_aircost},
                                        {ptx_kd},
                                        0,
                                        0,
                                        0,
                                        '{cboCurrency.Text}',
                                        '{txtVendorID.Text}',
                                        '{rstrID}',
                                        '{lblTbPrice.Text}',
                                        '{txtVendorName.Text}',
                                        '{ptx_type}',
                                        '{strCal_Qty}',
                                        '{ptx_assy}') ";
                    clsDB.Execute(strSQL);
                }
                else
                {
                    strSQL = $@"update ptx
                                set    ptx_tbdj = {txtPerPrice.Text},
                                       ptx_qty = {txtQty.Text},
                                       ptx_aircost = {ptx_aircost},
                                       ptx_kd = {ptx_kd},
                                       ptx_perqty = 0,
                                       ptx_perweight = 0,
                                       ptx_perky = 0,
                                       ptx_yfcurrency = '{cboCurrency.Text}',
                                       ptx_vendorid = '{txtVendorID.Text}',
                                       ptx_adddate = Getdate(),
                                       ptx_tbdjcal = '{lblTbPrice.Text}',
                                       ptx_venshortname = '{txtVendorName.Text}',
                                       ptx_type = '{ptx_type}',
                                       ptx_perqtycal = '{strCal_Qty}'
                                where  ptx_name = '{txtID.Text}'
                                       and ptx_customerid = '{rstrID}'
                                       and Isnull(ptx_assy, '') = '{ptx_assy}' ";
                    clsDB.Execute(strSQL);
                }
                //需要新增到ptb嗎???????????????????????
                strSQL = $@"truncate table ptb";
                clsDB.Execute(strSQL);
                strSQL = $@"insert ptb
                                   (ptb_name,
                                    ptb_customerid,
                                    ptb_yfcurrency)
                            values ('{txtID.Text}',
                                    '{rstrID}',
                                    '{cboCurrency.Text}') ";
                clsDB.Execute(strSQL);
                frmBOMPrice.rstrButton = "Select";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioSpecial_CheckedChanged(object sender, EventArgs e)
        {
            if(radioSpecial.Checked)
            {
                lblVendorID.Visible = true;
                lblVendorName.Visible = true;
                txtVendorID.Visible = true;
                txtVendorName.Visible = true;   
            }
            else
            {
                lblVendorID.Visible = false;
                lblVendorName.Visible = false;
                txtVendorID.Visible = false;
                txtVendorName.Visible = false;
            }
        }

        private void frmBOMPrice_Special_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                switch (rstrWho)
                {
                    case "Select":
                        this.Text = "選取其它料";
                        btnDelete.Visible = false;
                        break;
                    case "Inquiry":
                        this.Text = "選取其它料-查詢";
                        btnDelete.Visible = true;
                        txtID.Text = rstrPart;
                        strSQL = $@"select *
                                    from   ptx
                                    where  ptx_name = '{rstrPart}'
                                           and ptx_customerid = '{rstrID}' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if(dt.Rows.Count > 0)
                        {
                            txtPerPrice.Text = dt.Rows[0]["ptx_tbdj"].ToString();
                            txtQty.Text = dt.Rows[0]["ptx_qty"].ToString();
                            strCal_Qty = (string.IsNullOrEmpty(dt.Rows[0]["ptx_perqtycal"].ToString()) ? "" : dt.Rows[0]["ptx_perqtycal"].ToString());
                            if(dt.Rows[0]["ptx_type"].ToString()=="1")
                            {
                                radioSpecial.Checked=true;
                            }
                            else if (dt.Rows[0]["ptx_type"].ToString() == "2")
                            {
                                radioNote.Checked=true;
                            }
                            txtVendorID.Text = (string.IsNullOrEmpty(dt.Rows[0]["ptx_vendorid"].ToString()) ? "" : dt.Rows[0]["ptx_vendorid"].ToString());
                            txtVendorName.Text = (string.IsNullOrEmpty(dt.Rows[0]["ptx_venshortname"].ToString()) ? "" : dt.Rows[0]["ptx_venshortname"].ToString());
                            cboCurrency.Text = dt.Rows[0]["ptx_yfcurrency"].ToString();
                            lblTime.Text= dt.Rows[0]["ptx_adddate"].ToString();
                            strCal_PrePrice= (dt.Rows[0]["ptx_tbdjcal"].ToString()!="" ? dt.Rows[0]["ptx_tbdjcal"].ToString() : dt.Rows[0]["ptx_tbdj"].ToString());
                            lblTbPrice.Text = rstrPrice;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOMPrice_Special_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtVendorID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtVendorName.Focus();
            }
        }

        private void txtVendorID_Leave(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select isnull(ven_shortname,'') '廠號' from ven where ven_id='{txtVendorID.Text}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    txtVendorName.Text = dt.Rows[0]["廠號"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-txtVendorID_Leave" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtVendorName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtVendorID.Focus();
            }
        }

        private void txtVendorName_Leave(object sender, EventArgs e)
        {
            try
            {
               if(txtVendorName.Text.Trim().Length > 0)
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    strSQL = $@"select isnull(ven_id,'') '廠商' from ven where ven_shortname = '{txtVendorName.Text}'";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        txtVendorID.Text = dt.Rows[0]["廠商"].ToString();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-txtVendorName_Leave" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
