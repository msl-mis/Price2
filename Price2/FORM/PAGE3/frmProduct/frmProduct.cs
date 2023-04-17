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
    public partial class frmProduct : Form
    {
        string strSQL_0;
        string strSQL_1;
        string strSQL_2;

        string strPricecal = "";       // 計算式 
        string c8chg = "";              // 用來註記越南運費計重選項原始狀態, 以做為是否更新成本判斷
        string oldprice = "";           // 用來記錄材料的原來單價,當有對應材料單的單價被變更時,用來回復
        string strType = "";            // 紀錄asp_type
        string strName = "";            // 是否為材料單的旗標
        string strStandprice = "";      // 紀錄asp_standprice
        string strTjjz = "";            // 紀錄asp_tjjz
        string strArea = "";            // 紀錄asp_area
        string strSafeqty = "";         // 紀錄asp_safeqty
        string strWeight = "";          // 紀錄asp_weight
        string strPurleadtime = "";     // 紀錄asp_purleadtime
        string strMakeleadtime = "";    // 紀錄asp_makeleadtime
        string strLocation = "";        // 紀錄asp_location
        string strPurchprice = "";      // 紀錄asp_purchprice
        string strSalesprice = "";      // 紀錄asp_salesprice
        string strPurcurrency = "";     // 紀錄asp_purcurrency
        string oddate = "";             // 審核日期
        string oduser = "";             // 審核者

        /// <summary>
        /// asp欄位
        /// </summary>
        private String asp_id = "";                      // 產品編號(材料名)
        private String asp_type = "";                    // 產品類型
        private String asp_name = "";                    // 材料單
        private String asp_um = "";                      // 單位
        private Double asp_purprice = 0;                 // 單價
        private Double asp_standprice = 0;               // 
        private String asp_vendorid = "";                // 廠商
        private String asp_currency = "";                // 幣種
        private String asp_czf = "";                     // 參照法
        private Double asp_tjjz = 0;                     //
        private String asp_area = "";                    //
        private Double asp_safeqty = 0;                  // 一年內已成交數量
        private Double asp_weight = 0;                   //
        private Double asp_purleadtime = 0;              //
        private Double asp_makeleadtime = 0;             //
        private String asp_location = "";                //
        private Double asp_purchprice = 0;               // 數量計算式
        private String asp_purcurrency = "";             //
        private int asp_dummyflag = 0;                   // 控管材料
        private String asp_pricecal = "";                // 火車頭單價計算式
        private String asp_vendormaterialno = "";        // 品號
        private String asp_spec = "";                    // 規格
        private String asp_line = "";                    // 越南運費check
        private String asp_od = "";                      // 審核+越南材料check
        private String asp_multinum = "";                // 同品號
        private Double asp_vnweight = 0;                 // 越南運費-重量
        private Double asp_vnpcs = 0;                    // 越南運費-數量
        private String asp_lengum = "";                  // 安規線材check
        private String asp_oddate = "";                  // 審核日期
        private String asp_oduser = "";                  // 審核者
        private Double asp_salesprice = 0;               // 

        public static string strProductID = "";
        public static string rstrNo = "";     //回傳的品號
        public static string rstrID = "";     //回傳的ID
        public static string rstrVendorID = "";     //回傳的廠號
        public static string rstrVendorName = "";     //回傳的廠商
        public static string rstrResult = "";     //回傳的結果
        public frmProduct()
        {
            InitializeComponent();
        }

        private void getData()  //搜尋
        {
            //搜尋
            try
            {
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                strSQL_0 = "";
                strSQL_1 = "";
                strSQL_2 = "";
                string strSQL = "";
                string strSQL0_where = "";
                string strSQL_tmp = "";
                DataTable dt = new DataTable();
                btnFilter0.Enabled = true;
                btnFilter1.Enabled = true;
                btnFilter2.Enabled = true;
                btnFilter0.Text = "";
                btnFilter1.Text = "";
                btnFilter2.Text = "";
                if (txtID_Q.Text != "")
                {
                    if (txtID_Q.Text.IndexOf(";", 0) >= 0)
                    {
                        string[] strTmp = txtID_Q.Text.Split(';');
                        for (int i = 0; i < strTmp.Length; i++)
                        {
                            strSQL0_where = strSQL0_where + $@"asp_id like N'%{strTmp[i].Trim()}%'";
                            if (i < strTmp.Length)
                            {
                                strSQL0_where = strSQL0_where + " and";
                            }
                        }
                    }
                    else
                    {
                        strSQL0_where = strSQL0_where + $@"asp_id like N'%{txtID_Q.Text.Trim()}%'";
                    }
                }
                else
                {
                    strSQL0_where = strSQL0_where + $@"asp_id like N'%{txtID_Q.Text.Trim()}%'";
                }
                if (chkMeterial_Q.Checked == false) //材料單
                {
                    strSQL_tmp = "";
                }
                else
                {
                    strSQL_tmp = " and left(asp_name,1) = 'Y'";
                }
                strSQL0_where = strSQL0_where + strSQL_tmp;
                if (chkCheck_Q.Checked == false) //審核
                {
                    strSQL_tmp = "";
                }
                else
                {
                    strSQL_tmp = " and left(asp_od,1) = 'Y'";
                }
                strSQL0_where = strSQL0_where + strSQL_tmp;
                if (chkMaterial_VN_Q.Checked == false) //越南材料
                {
                    strSQL_tmp = "";
                }
                else
                {
                    strSQL_tmp = " and substring(asp_od,2,1) = 'Y'";
                }
                strSQL0_where = strSQL0_where + strSQL_tmp;
                if (chkShippingFee_VN_Q.Checked == false) //越南運費計重
                {
                    strSQL_tmp = "";
                }
                else
                {
                    strSQL_tmp = " and asp_line = 'Y'";
                }
                strSQL0_where = strSQL0_where + strSQL_tmp;
                if (chkControlMeterial_Q.Checked == false) //控管材料
                {
                    strSQL_tmp = "";
                }
                else
                {
                    strSQL_tmp = " and asp_dummyflag = '1'";
                }
                strSQL0_where = strSQL0_where + strSQL_tmp;
                if (cboBOM_Q.Text == "有登錄") //有登錄BOM
                {
                    strSQL_tmp = " and ba.acc > 0 ";
                }
                else if (cboBOM_Q.Text == "未登錄")
                {
                    strSQL_tmp = " and ba.acc is null ";
                }
                else
                {
                    strSQL_tmp = "";
                }
                strSQL0_where = strSQL0_where + strSQL_tmp;
                if (cboCurrency_Q.Text == "(ALL)") //幣種
                {
                    strSQL_tmp = "";
                }
                else
                {
                    strSQL_tmp = " and asp_currency='{cboCurrency_Q.Text}' ";
                }
                strSQL0_where = strSQL0_where + strSQL_tmp;
                if (chkUseless_Q.Checked == false) //查詢不在報價單和材料單組成材料中的材料
                {
                    strSQL_tmp = "";
                }
                else
                {
                    strSQL_tmp = " and asp_id not in (select distinct pri_part from pri) ";
                }
                strSQL0_where = strSQL0_where + strSQL_tmp;
                if (chkCheck_Q.Checked == true)
                {
                    if (txtDate_S.Text == "")
                    {
                        strSQL_tmp = "";
                    }
                    else
                    {
                        strSQL_tmp = " and (asp_oddate>='" + txtDate_S.Text.Trim() + " 0:00' and asp_oddate<='" + txtDate_E.Text.Trim() + " 23:59') ";
                    }
                    strSQL0_where = strSQL0_where + strSQL_tmp;
                }
                else
                {
                    if (txtDate_S.Text == "")
                    {
                        strSQL_tmp = "";
                    }
                    else
                    {
                        strSQL_tmp = " and ((asp_adddate between '" + txtDate_S.Text.Trim() + " 0:00' and '" + txtDate_E.Text.Trim() + " 23:59') or (aspnum_modifydate between '" + txtDate_S.Text.Trim() + " 0:00' and '" + txtDate_E.Text.Trim() + " 23:59')) ";
                    }
                    strSQL0_where = strSQL0_where + strSQL_tmp;
                }
                //檢查是否有匯入記錄
                if (chkRecord_Q.Checked == false) //審核
                {
                    strSQL_tmp = "";
                }
                else
                {
                    if (txtDate_S.Text == "")
                    {
                        strSQL_tmp = " and asp_id in (select distinct asb_id from asb where asb_user like '%匯入%' and asb_memo like '%價格變動%' ";
                    }
                    else
                    {
                        strSQL_tmp = " and asp_id in (select distinct asb_id from asb where asb_user like '%匯入%' and asb_memo like '%價格變動%' " + " and asb_changedate >= " + txtDate_S.Text.Trim() + " 00:00:00' and asb_changedate <= '" + txtDate_E.Text.Trim() + " 23:59:59' )";
                    }
                }
                strSQL0_where = strSQL0_where + strSQL_tmp;


                string strSQL1_where = "";
                string strSQL2_where = "";
                strSQL1_where = strSQL0_where;
                strSQL2_where = strSQL0_where;
                if (txtNo_Q.Text == "")   //品號
                {
                    strSQL_tmp = "";
                }
                else
                {
                    strSQL_tmp = " and ( " + SplitWhere("asp_vendormaterialno", txtNo_Q.Text) + " or " + SplitWhere("aspnum.aspnum_num", txtNo_Q.Text) + " or " + SplitWhere("asp_czf", txtNo_Q.Text) + " or " + SplitWhere("asp_multinum", txtNo_Q.Text) + ")";
                }
                strSQL0_where = strSQL0_where + strSQL_tmp;

                if (txtVendorID_Q.Text == "")   //廠號
                {
                    strSQL_tmp = "";
                }
                else
                {
                    strSQL_tmp = " and asp_vendorid like '" + txtVendorID_Q.Text.Trim() + "'";
                }
                strSQL0_where = strSQL0_where + strSQL_tmp;

                strSQL1_where = strSQL1_where + " And aspnum.aspnum_vendorid <> asp_vendorid";


                if (txtNo_Q.Text == "")   //品號
                {
                    strSQL_tmp = "";
                }
                else
                {
                    strSQL_tmp = " and " + SplitWhere("asp_vendormaterialno", txtNo_Q.Text) + " and aspnum.aspnum_num <> asp_vendormaterialno";
                }
                strSQL1_where = strSQL1_where + strSQL_tmp;

                if (txtVendorID_Q.Text == "")   //廠號
                {
                    strSQL_tmp = "";
                }
                else
                {
                    strSQL_tmp = " and aspnum_vendorid like '" + txtVendorID_Q.Text.Trim() + "' And aspnum.aspnum_vendorid <> asp_vendorid";
                }
                strSQL1_where = strSQL1_where + strSQL_tmp;

                if (txtNo_Q.Text == "")   //品號
                {
                    strSQL_tmp = "";
                }
                else
                {
                    strSQL_tmp = " and ( " + SplitWhere("asp_vendormaterialno", txtNo_Q.Text) + " or " + SplitWhere("aspnum.aspnum_num", txtNo_Q.Text) + " or " + SplitWhere("asp_czf", txtNo_Q.Text) + " or " + SplitWhere("asp_multinum", txtNo_Q.Text) + ")";
                }
                strSQL2_where = strSQL2_where + strSQL_tmp;

                if (txtVendorID_Q.Text == "")   //廠號
                {
                    strSQL_tmp = "";
                }
                else
                {
                    strSQL_tmp = " and (asp_vendorid like '" + txtVendorID_Q.Text.Trim() + "' or (aspnum_vendorid like '" + txtVendorID_Q.Text.Trim() + "' And aspnum.aspnum_vendorid <> asp_vendorid))";
                }
                strSQL2_where = strSQL2_where + strSQL_tmp;

                strSQL = $@"select distinct asp_id                                                      '材料名',
                                            asp_vendormaterialno                                        '品號',
                                            case
                                              when num.aspnum_count > 1 then 'V'
                                              else ''
                                            end                                                         '內層',
                                            case left (asp_name, 1)
                                              when 'Y' then 'V'
                                              else ''
                                            end                                                         '材料單',
                                            Isnull(ab.pri_vendorid, '')                                 '外購',
                                            asp_purprice  '單價',
                                            asp_pricecal                                                '計算式',
                                            asp_currency                                                '幣種',
                                            Round(asp_purprice * cur_convert, 6)                        '台幣',
                                            asp_um                                                      '單位',
                                            asp_vendorid                                                '廠商',
                                            Isnull(a01.pcount, 0)                                       '報價單筆數',
                                            Isnull(a02.pcount, 0)                                       '已成交筆數',
                                            Format(Round(Isnull(asp_stock, 0), 0), '#,0')               '二年內成交金額',
                                            Isnull(aa01.pcount, 0)                                      '材料單筆數',
                                            left(asp_od, 1)                                             '審核',
                                            asp_oduser                                                  '審核者',
                                            Substring(asp_od, 2, 1)                                     '越南材料',
                                            asp_line                                                    '越南運費',
                                            case
                                              when ba.acc > 0 then 'V'
                                              else ''
                                            end                                                         'BOM登錄',
                                            Format(asp_adddate, 'yyyy/MM/dd')                           '材料建立日期'
                            from   asp
                                   left join aspnum as aspnum
                                          on aspnum.aspnum_id = asp.asp_id
                                   left join (select aspnum.aspnum_id,
                                                     Count (aspnum_id) aspnum_count
                                              from   aspnum
                                              group  by aspnum.aspnum_id) num
                                          on num.aspnum_id = asp.asp_id
                                   left join (select pri_part,
                                                     Count(pri_customerid) as pcount
                                              from   pri
                                              where  left(pri_newcostchk, 1) = 'N'
                                              group  by pri_part) as aa
                                          on aa.pri_part = asp_id
                                   left join (select pri_part,
                                                     Count(pri_customerid) as pcount
                                              from   pri
                                              where  left(pri_newcostchk, 1) = 'Y'
                                              group  by pri_part) as aa01
                                          on aa01.pri_part = asp_id
                                   left join (select pri_part,
                                                     Count(pri_part) as pcount
                                              from   pri
                                              where  pri_newcostchk like 'N%'
                                                     and pri_part in (select asp_id
                                                                      from   asp)
                                              group  by pri_part) as a01
                                          on a01.pri_part = asp_id
                                   left join (select count(distinct ord_assy) as pcount, pri_part
												from   ord
												left join pri
                                                on ord_assy = pri_customerid
                                              where  pri_newcostchk like 'N%'
                                                     and pri_part in (select asp_id
                                                                      from   asp)
                                              group  by pri_part) as a02
                                          on a02.pri_part = asp_id
                                   left join (select distinct pri_part,
                                                              pri_vendorid,
                                                              ac.ven_id
                                              from   pri
                                                     left join (select ven_id,
                                                                       ven_shortname
                                                                from   ven) as ac
                                                            on ac.ven_shortname = pri_vendorid
                                              where  pri_vendorid <> ''
                                                     and pri_wg = '1'
                                                     and pri_newcostchk like 'N%') as ab
                                          on ab.pri_part = asp_id
                                             and ab.ven_id = asp_vendorid
                                   left join cur
                                          on cur_code = asp_currency
                                   left join (select ap3_part,
                                                     Count(ap3_part) as acc
                                              from   ap3
                                              group  by ap3_part) as ba
                                          on ba.ap3_part = asp_id ";
                //把btnFilter2拿掉
                //strSQL_2 = strSQL + " where " + strSQL2_where + " order by asp_id";
                //dt = clsDB.sql_select_dt(strSQL_2);
                strSQL_0 = strSQL + " where " + strSQL0_where + " order by asp_id";
                dt = clsDB.sql_select_dt(strSQL_0);
                dgvData.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    //btnFilter2.Text = "全：" + dt.Rows.Count.ToString();
                    //btnFilter2.BackColor = Color.FromArgb(255, 224, 192);

                    btnFilter0.Text = "外：" + dt.Rows.Count.ToString();
                    btnFilter0.BackColor = Color.FromArgb(255, 224, 192);
                    btnExport_Q.Enabled = true;
                }
                else
                {
                    btnExport_Q.Enabled = false;
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return;
                }

                //strSQL_0 = strSQL + " where " + strSQL0_where + " order by asp_id";
                //dt = clsDB.sql_select_dt(strSQL_0);
                //btnFilter0.Text = "外：" + dt.Rows.Count.ToString();
                //btnFilter0.BackColor = Color.FromArgb(224, 224, 224);

                strSQL_1 = strSQL + " where " + strSQL1_where + " order by asp_id";
                dt = clsDB.sql_select_dt(strSQL_1);
                btnFilter1.Text = "內：" + dt.Rows.Count.ToString();
                btnFilter1.BackColor = Color.FromArgb(224, 224, 224);
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SplitWhere(string txtField, string txtInput) //切割查詢欄位
        {
            //切割查詢欄位
            string SplitWhere = "";
            try
            {
                if (txtInput != "")
                {
                    SplitWhere = " (";
                    if (txtInput.IndexOf(":", 0) >= 0)
                    {
                        string[] arrOuter = txtInput.Split(':');
                        for (int i = 0; i < arrOuter.Length; i++)
                        {
                            if (arrOuter[i].IndexOf(";", 0) >= 0)
                            {
                                string[] arrInner = arrOuter[i].Split(';');
                                for (int j = 0; j < arrInner.Length; j++)
                                {
                                    SplitWhere = SplitWhere + " " + txtField + " LIKE N'%" + arrInner[j].Trim() + "%'";
                                    if (j < arrInner.Length)
                                    {
                                        SplitWhere = SplitWhere + " AND ";
                                    }
                                    else
                                    {
                                        SplitWhere = SplitWhere + " ) OR (";
                                    }
                                }

                            }
                            else
                            {
                                SplitWhere = SplitWhere + " " + txtField + " LIKE N'%" + arrOuter[i].Trim() + "%'";
                                if (i < arrOuter.Length)
                                {
                                    SplitWhere = SplitWhere + " ) OR ( ";
                                }
                            }
                        }
                    }
                    else
                    {
                        if (txtInput.IndexOf(";", 0) >= 0)
                        {
                            string[] arrOuter = txtInput.Split(';');
                            for (int i = 0; i < arrOuter.Length; i++)
                            {
                                SplitWhere = SplitWhere + " " + txtField + " LIKE N'%" + arrOuter[i].Trim() + "%'";
                                if (i < arrOuter.Length)
                                {
                                    SplitWhere = SplitWhere + " AND ";
                                }
                            }
                        }
                        else
                        {
                            SplitWhere = SplitWhere + " " + txtField + " LIKE N'%" + txtInput.Trim() + "%'";
                        }
                    }
                    SplitWhere = SplitWhere + " ) ";
                    //移除可能會多餘的查詢字串
                    SplitWhere = SplitWhere.Replace("OR ( )", "");
                    return SplitWhere;
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-SplitWhere" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

        }

        public void getID()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            try
            {
                if (txtID.Text == "")
                {
                    return;
                }
                txtID.Text = txtID.Text.Trim();
                //檢查多品號,若是多品號查詢按鈕顯示紅色.
                checkMultinum(txtID.Text);
                oldprice = "";
                c8chg = "";
                //檢查不能用的字符[]&
                strSQL = $@"select Isnull(Charindex('[', '{txtID.Text}'), 0) as c1,
                                   Isnull(Charindex(']', '{txtID.Text}'), 0) as c2,
                                   Isnull(Charindex('&', '{txtID.Text}'), 0) as c3 ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["c1"].ToString() == "0" && dt.Rows[0]["c2"].ToString() == "0" && dt.Rows[0]["c3"].ToString() == "0")
                    {

                    }
                    else
                    {
                        MessageBox.Show("你輸入的產品編號包括了一些不能用的字符[]&,不能繼續!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                strSQL = $@"select *
                            from   asp
                            where  asp_id = N'{txtID.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    txtID.Text = dt.Rows[0]["asp_id"].ToString().Trim();
                    strType = dt.Rows[0]["asp_type"].ToString();
                    strName = dt.Rows[0]["asp_name"].ToString();    //是否為材料單的旗標
                    cboUnit.Text = dt.Rows[0]["asp_um"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["asp_purprice"].ToString()) || dt.Rows[0]["asp_purprice"].ToString() == "")
                    {
                        txtPurprice.Text = "0";
                    }
                    else
                    {
                        txtPurprice.Text = dt.Rows[0]["asp_purprice"].ToString();
                    }
                    oldprice = txtPurprice.Text;    //先記錄單價到oldprice一份
                    strStandprice = dt.Rows[0]["asp_standprice"].ToString();
                    txtVendorID.Text = dt.Rows[0]["asp_vendorid"].ToString();
                    cboCurrency.Text = dt.Rows[0]["asp_currency"].ToString();
                    txtCzf.Text = dt.Rows[0]["asp_czf"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["asp_multinum"].ToString()))
                    {
                        txtMultinum.Text = "";
                    }
                    else
                    {
                        txtMultinum.Text = dt.Rows[0]["asp_multinum"].ToString();
                    }
                    strTjjz = dt.Rows[0]["asp_tjjz"].ToString();
                    strArea = dt.Rows[0]["asp_area"].ToString();
                    strSafeqty = dt.Rows[0]["asp_safeqty"].ToString();
                    strWeight = dt.Rows[0]["asp_weight"].ToString();
                    strPurleadtime = dt.Rows[0]["asp_purleadtime"].ToString();
                    strMakeleadtime = dt.Rows[0]["asp_makeleadtime"].ToString();
                    strLocation = dt.Rows[0]["asp_location"].ToString();
                    strPurchprice = dt.Rows[0]["asp_purchprice"].ToString();
                    txtNo.Text = dt.Rows[0]["asp_vendormaterialno"].ToString();
                    strSalesprice = dt.Rows[0]["asp_salesprice"].ToString();
                    strPurcurrency = dt.Rows[0]["asp_purcurrency"].ToString();
                    if (dt.Rows[0]["asp_dummyflag"].ToString() == "1")
                    {
                        chkControlMeterial.Checked = true;
                    }
                    else
                    {
                        chkControlMeterial.Checked = false;
                    }
                    txtSpec.Text = dt.Rows[0]["asp_spec"].ToString();
                    lblUser.Text = dt.Rows[0]["asp_user"].ToString();
                    if (string.IsNullOrEmpty(dt.Rows[0]["asp_pricecal"].ToString()))
                    {
                        strPricecal = "";
                    }
                    else
                    {
                        strPricecal = dt.Rows[0]["asp_pricecal"].ToString();
                    }
                    lblDate.Text = Convert.ToDateTime(dt.Rows[0]["asp_adddate"].ToString()).ToString("yyyy/MM/dd");

                    if (dt.Rows[0]["asp_line"].ToString() == "Y")  //越南運費計重
                    {
                        chkShippingFee_VN.Checked = true;
                        //重量
                        if (string.IsNullOrEmpty(dt.Rows[0]["asp_vnweight"].ToString()))
                        {
                            txtWeight.Text = "0";
                        }
                        else
                        {
                            txtWeight.Text = dt.Rows[0]["asp_vnweight"].ToString();
                        }
                        //數量
                        if (string.IsNullOrEmpty(dt.Rows[0]["asp_vnpcs"].ToString()))
                        {
                            txtQuantity.Text = "0";
                        }
                        else
                        {
                            txtQuantity.Text = dt.Rows[0]["asp_vnpcs"].ToString();
                        }
                    }
                    else
                    {
                        chkShippingFee_VN.Checked = false;
                    }

                    if (dt.Rows[0]["asp_lengum"].ToString() == "Y")  //UL標記
                    {
                        chkSafety.Checked = true;
                    }
                    else
                    {
                        chkSafety.Checked = false;
                    }
                    
                    if (dt.Rows[0]["asp_od"].ToString().Length>=1)  //審核標記
                    {
                        if (dt.Rows[0]["asp_od"].ToString().Substring(0, 1) == "Y")  
                        {
                            chkCheck.Checked = true;
                            oddate = Convert.ToDateTime(dt.Rows[0]["asp_oddate"].ToString()).ToString("yyyy/MM/dd");
                            if (string.IsNullOrEmpty(dt.Rows[0]["asp_oduser"].ToString()))
                            {
                                oduser = "";
                            }
                            else
                            {
                                oduser = dt.Rows[0]["asp_oduser"].ToString();
                            }
                            lblCheckDate.Text = oddate + " " + oduser;
                        }
                        else
                        {
                            chkCheck.Checked = false;
                            oddate = "";
                            oduser = "";
                            lblCheckDate.Text = "";
                        }
                    }
                    else
                    {
                        chkCheck.Checked = false;
                        oddate = "";
                        oduser = "";
                        lblCheckDate.Text = "";
                    }
                    if (dt.Rows[0]["asp_od"].ToString().Length>=2)  //越南材料
                    {
                        if (dt.Rows[0]["asp_od"].ToString().Substring(1, 1) == "Y")  //越南材料
                        {
                            chkMaterial_VN.Checked = true;
                        }
                        else
                        {
                            chkMaterial_VN.Checked = false;
                        }
                    }
                    else
                    {
                        chkMaterial_VN.Checked = false;
                    }
                        
                    if (txtVendorID.Text != "")
                    {
                        lblVendor.Text = getVendor(txtVendorID.Text);
                    }
                }
                else
                {
                    if (MessageBox.Show(this, "你想創建複製一個新的產品資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        strName = "";   //Text3.Text = ""是否為材料單的旗標
                        strStandprice = "";                //待查Text5.Text = ""
                        txtVendorID.Text = "";
                        txtPurprice.Text = "";
                        oldprice = "";
                        c8chg = "";
                        cboCurrency.Text = "人民幣";
                        cboUnit.Text = "PC";
                        strType = "";   //待查Combo1.Text = "線材類"
                        txtCzf.Text = "";   //TextBox1.Text = ""
                        btnCzf.BackColor = Color.FromArgb(255, 255, 192);   //mpage = "1"預設參照法顯現
                        txtCzf.Visible = true;
                        txtCzf.BackColor = Color.FromArgb(255, 255, 192);
                        txtMultinum.Text = "";   //TextBox2.Text = ""
                        btnMultinum.BackColor = Color.FromArgb(255, 255, 0);
                        txtMultinum.Visible = false;

                        //aspod_chk = False

                        strTjjz = "";   //Text11.Text = ""
                        strArea = "";   //Combo6.Text = "大陸"
                        strSafeqty = "";    //Text17.Text = ""
                        strWeight = ""; //Text16.Text = ""
                        strPurleadtime = "";    //Text14.Text = ""
                        strMakeleadtime = "";   //Text15.Text = ""
                        strLocation = "";   //Text18.Text = ""
                        strPurchprice = ""; //Text19.Text = ""
                        txtSpec.Text = "";
                        txtNo.Text = "";
                        txtWeight.Text = "";
                        txtWeight.Visible = false;
                        lblWeight.Visible = false;
                        txtQuantity.Text = "";
                        txtQuantity.Visible = false;
                        lblQuantity.Visible = false;
                        chkMaterial_VN.Checked = false;
                        chkCheck.Checked = false;
                        chkSafety.Checked = false;
                        lblCheckDate.Text = "";
                        oddate = ""; //20200311審核日期
                        oduser = ""; //20200311審核使用者
                        chkShippingFee_VN.Checked = false;
                        txtID.Focus();
                        strSalesprice = ""; //Text22.Text = ""
                        strPurcurrency = "";    //Combo7.Text = "人民幣"
                        chkControlMeterial.Checked = false;
                        lblUser.Text = "";
                        lblDate.Text = "";
                        strPricecal = "";    //Label35計算式
                        lblVendor.Text = "";
                    }
                    else
                    {
                        btnClear.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getID" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string getVendor(string ven_id)
        {
            String strSQL = $@"select ven_shortname from ven where ven_id='{ven_id}'";
            string rs = clsDB.sql_select_String(strSQL, "ven_shortname");
            if (rs == "")
            {
                MessageBox.Show("沒有這個廠商,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVendorID.Text = "";
                txtVendorID.Focus();
            }

            return rs;
        }

        private void checkMultinum(string aspnum_id)    //檢查多品號顯示
        {
            //檢查多品號顯示
            try
            {
                String strSQL = $@"select [aspnum_id]         as 材料名,
                                          [aspnum_num]        as 品號,
                                          [aspnum_modifydate] as 最後變動日期
                                   from   aspnum
                                   where  aspnum_id = '{aspnum_id}'
                                   order by aspnum_modifydate desc ";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 1)
                {
                    btnInq_No.BackColor = Color.FromArgb(255, 0, 0);  //red
                }
                else
                {
                    btnInq_No.BackColor = Color.FromArgb(192, 255, 192);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-checkMultinum" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static int getStrLength(string str) //取得字串長度 clsGlobal
        {
            //取得字串長度
            if (string.IsNullOrEmpty(str)) return 0;
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            byte[] s = ascii.GetBytes(str);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }
            }
            return tempLen;
        }

        private string checkPID(string strNo, string strID) // 檢查品號對應多材料名
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                string strOuterNo = "";   // 外層品號
                string strInnerNo = ""; // 內層品號

                /// 先檢查此品號前6碼是否一致
                if (strNo != "")
                {
                    strSQL = $@"select distinct Substring([aspnum_num], 1, 6) as pnum
                            from   aspnum
                            where  aspnum_id = '{strID}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["pnum"].ToString() != strNo.Substring(0, 6) || dt.Rows.Count > 1)
                        {
                            return "2";
                        }
                    }
                }
                /// 檢查此品號是否有被使用
                if (strNo != "")
                {
                    strSQL = $@"select asp_id,
                                   asp_vendormaterialno
                            from   asp
                            where  asp_vendormaterialno = '{strNo.Trim()}'
                                   and asp_id <> '{strID.Trim()}'";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (strID.Trim() != dt.Rows[i]["asp_id"].ToString())
                            {
                                strOuterNo = strOuterNo + dt.Rows[i]["asp_id"].ToString();
                            }
                        }
                    }

                    strSQL = $@"select aspnum_id,
                                   aspnum_num
                            from   aspnum
                            where  aspnum_num = '{strNo.Trim()}'
                                   and aspnum_id <> '{strID.Trim()}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (strID.Trim() != dt.Rows[i]["aspnum_id"].ToString())
                            {
                                strInnerNo = strInnerNo + dt.Rows[i]["aspnum_id"].ToString();
                            }
                        }
                    }
                }
                if (strOuterNo != "")
                {
                    strOuterNo = "此品號外層已有記錄,請檢查!" + "\n" + strOuterNo + "\n";
                }
                if (strInnerNo != "")
                {
                    strInnerNo = "此品號內層已有記錄,請檢查!" + "\n" + strInnerNo;
                }
                return strOuterNo + strInnerNo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-checkPID" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "檢查品號對應多材料名發生ERROR!!!";
            }
        }

        private void DoUpdate_asp() // 更新asp資料
        {

            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                /// intIDCount
                strSQL = $@"select * from asm where asm_id = '{asp_id}'";
                dt = clsDB.sql_select_dt(strSQL);
                int intIDCount = dt.Rows.Count; // intIDCount

                /// strUser
                strSQL = $@"select wus_name from wus where wus_computername=host_name()";
                string strUser = clsDB.sql_select_String(strSQL, "wus_name");  // strUser
                asp_vendormaterialno = asp_vendormaterialno.Replace("\n", "").Replace("\r", "").Trim();  //去ENTER 換行 空白

                /// 當材料名儲存時,一起同步多品號內層的資料
                strSQL = $@"select aspnum_id from aspnum where aspnum_id = '{asp_id}' and aspnum_num = '{asp_vendormaterialno}'";
                string aspnumid = clsDB.sql_select_String(strSQL, "aspnum_id");
                if (aspnumid != "")
                {
                    strSQL = $@"update aspnum
                                set    aspnum_price = {asp_purprice},
                                       aspnum_pricecal = '{asp_pricecal}',
                                       aspnum_spec = '{asp_spec}',
                                       aspnum_memo = '{asp_czf}',
                                       aspnum_currency = '{asp_currency}',
                                       aspnum_vendorid = '{asp_vendorid}',
                                       aspnum_um = '{asp_um}',
                                       aspnum_modifydate = Cast(Year(Getdate()) as VARCHAR(4)) + '/'
                                                           + Cast(Month(Getdate()) as VARCHAR(2)) + '/'
                                                           + Cast(Day(Getdate()) as VARCHAR(2))
                                from   aspnum
                                where  aspnum_id = '{asp_id}'
                                       and aspnum_num = '{asp_vendormaterialno}' ";
                    clsDB.Execute(strSQL);
                }

                strSQL = $@"select asp_id from asp where asp_id='{asp_id}'";
                string strID = clsDB.sql_select_String(strSQL, "asp_id");
                if (strID == "")
                {
                    strSQL = $@"insert asp
                                       (asp_id,
                                        asp_type,
                                        asp_name,
                                        asp_um,
                                        asp_purprice,
                                        asp_standprice,
                                        asp_vendorid,
                                        asp_currency,
                                        asp_czf,
                                        asp_tjjz,
                                        asp_area,
                                        asp_safeqty,
                                        asp_weight,
                                        asp_purleadtime,
                                        asp_makeleadtime,
                                        asp_location,
                                        asp_purchprice,
                                        asp_purcurrency,
                                        asp_dummyflag,
                                        asp_user,
                                        asp_pricecal,
                                        asp_vendormaterialno,
                                        asp_spec)
                                values ('{asp_id}',
                                        '{asp_type}',
                                        '{asp_name}',
                                        '{asp_um}',
                                        {asp_purprice},
                                        {asp_standprice},
                                        '{asp_vendorid}',
                                        '{asp_currency}',
                                        '{asp_czf}',
                                        {asp_tjjz},
                                        '{asp_area}',
                                        {asp_safeqty},
                                        {asp_weight},
                                        {asp_purleadtime},
                                        {asp_makeleadtime},
                                        '{asp_location}',
                                        {asp_purchprice},
                                        '{asp_purcurrency}',
                                        {asp_dummyflag},
                                        '{strUser}',
                                        '{asp_pricecal}',
                                        '{asp_vendormaterialno}',
                                        '{asp_spec}') ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"insert asm
                                       (asm_id,
                                        asm_um,
                                        asm_purprice,
                                        asm_vendorid,
                                        asm_currency,
                                        asm_materialno,
                                        asm_vendormaterialno,
                                        asm_area,
                                        asm_user,
                                        asm_czf)
                                values('{asp_id}',
                                       '{asp_um}',
                                       {asp_purprice},
                                       '{asp_vendorid}',
                                       '{asp_currency}',
                                       {asp_tjjz},
                                       '{asp_vendormaterialno}',
                                       '{asp_area}',
                                       '{strUser}',
                                       '{asp_czf}') ";
                    clsDB.Execute(strSQL);
                }
                else
                {
                    strSQL = $@"update asp
                                set    asp_adddate = Getdate(),
                                       asp_user = '{strUser}',
                                       asp_pricecal = '{asp_pricecal}',
                                       asp_vendormaterialno = '{asp_vendormaterialno}',
                                       asp_spec = '{asp_spec}',
                                       asp_purprice = Round({asp_purprice}, 6),
                                       asp_currency = '{asp_currency}',
                                       asp_location = '{asp_location}',
                                       asp_purchprice = {asp_purchprice},
                                       asp_purcurrency = '{asp_purcurrency}',
                                       asp_dummyflag = {asp_dummyflag},
                                       asp_tjjz = {asp_tjjz},
                                       asp_area = '{asp_area}',
                                       asp_safeqty = {asp_safeqty},
                                       asp_weight = {asp_weight},
                                       asp_purleadtime = {asp_purleadtime},
                                       asp_makeleadtime = {asp_makeleadtime},
                                       asp_name = '{asp_name}',
                                       asp_type = '{asp_type}',
                                       asp_um = '{asp_um}',
                                       asp_standprice = {asp_standprice},
                                       asp_vendorid = '{asp_vendorid}',
                                       asp_czf = '{asp_czf}'
                                where  asp_id = '{asp_id}' ";
                    clsDB.Execute(strSQL);
                    if (intIDCount == 0)
                    {
                        strSQL = $@"insert asm
                                           (asm_id,
                                            asm_um,
                                            asm_purprice,
                                            asm_vendorid,
                                            asm_currency,
                                            asm_materialno,
                                            asm_vendormaterialno,
                                            asm_area,
                                            asm_user,
                                            asm_czf)
                                    values('{asp_id}',
                                           '{asp_um}',
                                           {asp_purprice},
                                           '{asp_vendorid}',
                                           '{asp_currency}',
                                           {asp_tjjz},
                                           '{asp_vendormaterialno}',
                                           '{asp_area}',
                                           '{strUser}',
                                           '{asp_czf}') ";
                        clsDB.Execute(strSQL);
                    }
                    else if (intIDCount == 1)
                    {
                        strSQL = $@"update asm
                                    set    asm_um = '{asp_um}',
                                           asm_purprice = {asp_purprice},
                                           asm_vendorid = '{asp_vendorid}',
                                           asm_currency = '{asp_currency}',
                                           asm_materialno = {asp_tjjz},
                                           asm_vendormaterialno = '{asp_vendormaterialno}',
                                           asm_area = '{asp_area}',
                                           asm_user = '{strUser}',
                                           asm_czf = '{asp_czf}'
                                    where  asm_id = '{asp_id}'";
                        clsDB.Execute(strSQL);
                    }
                    else
                    {
                        strSQL = $@"update asm
                                    set    asm_um = '{asp_um}',
                                           asm_purprice = {asp_purprice},
                                           asm_vendorid = '{asp_vendorid}',
                                           asm_currency = '{asp_currency}',
                                           asm_vendormaterialno = '{asp_vendormaterialno}',
                                           asm_area = '{asp_area}',
                                           asm_user = '{strUser}',
                                           asm_czf = '{asp_czf}'
                                    where  asm_id = '{asp_id}'
                                           and asm_materialno = {asp_tjjz}";
                        clsDB.Execute(strSQL);
                    }
                }

                strSQL = $@"select avt_vendorid from avt where avt_id='{asp_id}' and avt_vendorid='{asp_vendorid}'";
                string strVID = clsDB.sql_select_String(strSQL, "avt_vendorid");
                if (strVID == "")
                {
                    strSQL = $@"insert avt
                                       (avt_id,
                                        avt_vendorid,
                                        avt_price,
                                        avt_vendorname,
                                        avt_currency,
                                        avt_fktj,
                                        avt_tb,
                                        avt_adddate,
                                        avt_kpercent,
                                        avt_vendormaterialno)
                                select '{asp_id}',
                                       '{asp_vendorid}',
                                       {asp_purprice},
                                       ven_shortname,
                                       '{asp_currency}',
                                       ven_payment,
                                       Round({asp_purprice} * cur_convert, 6),
                                       Getdate(),
                                       ven_kpercent,
                                       '{asp_vendormaterialno}'
                                from   ven,
                                       cur
                                where  ven_id = '{asp_vendorid}'
                                       and cur_code = '{asp_currency}' ";
                    clsDB.Execute(strSQL);
                }
                else
                {
                    strSQL = $@"update avt
                                set    avt_adddate = Getdate(),
                                       avt_vendormaterialno = '{asp_vendormaterialno}'
                                where  avt_id = '{asp_id}'
                                       and avt_vendorid = '{asp_vendorid}' ";
                    clsDB.Execute(strSQL);
                }

                string strName = "";
                strSQL = $@"select ptx_name
                            from   ptx
                            where  ptx_name = '{asp_id}' ";
                strName = clsDB.sql_select_String(strSQL, "ptx_name");

                strSQL = $@"update pri
                            set    pri_firstname = ap1_assy
                            from   ap1,
                                   ap2,
                                   ap3,
                                   ptx,
                                   pri
                            where  pri_part = '{asp_id}'
                                   and ap1_part = ap2_assy
                                   and ap2_part = ap3_assy
                                   and ap3_part = ptx_name
                                   and ptx_name = '{asp_id}' ";
                clsDB.Execute(strSQL);
                strSQL = $@"delete ptx where ptx_name='{asp_id}'";
                clsDB.Execute(strSQL);

                //strSQL = $@"select ptx_name from ptx where ptx_name='{asp_id}'";
                //string strName = clsDB.sql_select_String(strSQL, "ptx_name");
                if (strName != "")
                {
                    strSQL = $@"update pub set pub_aimlocked=1";
                    clsDB.Execute(strSQL);
                }

                //strSQL = $@"select count(pri_customerid) from pri where pri_newcostchk like 'Y%' and pri_part = '{asp_id}' ";
                strSQL = $@"select pri_customerid from pri where pri_newcostchk like 'Y%' and pri_part = '{asp_id}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    DoUpdate_BOM();
                    strSQL = $@"update pub set pub_aimlocked=1";
                    clsDB.Execute(strSQL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-DoUpdate_asp" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoUpdate_BOM() // DoUpdate_BOM
        {
            try
            {
                DoUpdatepriclcost1();  // 膠粒成本計算處理
                DoUpdatepriclcost2();  // 一般成本計算處理
                DoUpdatepriclcost3();  // 錫輔料成本計算
                DoUpdatepriclcost4();  // 抽線耗材成本計算
                DoUpdatepriclcost6();  // 鋁箔線材附加成本計算
                DoUpdatepriclcost7();  // 銅箔線材附加成本計算
                DoUpdatepriclcost11(); // 平均計算成本
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-DoUpdate_BOM" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoUpdatepriclcost1() // 膠粒成本計算處理
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                /// 取得目前時間
                string strTime = DateTime.Now.ToString("yyyy/M/dd HH:mm:ss");

                /// 更新材料單的單身，找出單價 * 數量跟報價不同者，單身材料名不為「不良率、佣金」，材料名結尾不為「才」字，材料分類不為「其它料」
                strSQL = $@"update pri
                            set    pri_cost = Round(pri_tbprice * pri_perqty, 6),
                                   pri_costflag = 'Y'
                            where  pri_cost <> Round(pri_tbprice * pri_perqty, 6)
                                   and left(pri_part, 3) <> '不良率'
                                   and left(pri_part, 2) <> '佣金'
                                   and left(pri_firstname, 1) <> '其'
                                   and right(pri_part, 1) <> '才'
                                   and pri_newcostchk = 'Y1' ";
                clsDB.Execute(strSQL);

                /// 更新材料單中不良率的金額不正確的單子
                strSQL = $@"update pri
                            set    pri_cost = aa.clsum
                            from   (select a.pri_customerid,
                                           a.pri_assy,
                                           Round(Sum(a.pri_cost) * b.pri_tbprice * b.pri_perqty, 6) as clsum
                                    from   pri as a with (NOLOCK)
                                           left join (select pri_tbprice,
                                                             pri_perqty,
                                                             pri_customerid,
                                                             pri_assy
                                                      from   pri nolock
                                                      where  left(pri_part, 3) = '不良率'
                                                             and pri_newcostchk = 'Y1') as b
                                                  on a.pri_customerid = b.pri_customerid
                                                     and a.pri_assy = b.pri_assy
                                    where  a.pri_newcostchk = 'Y1'
                                           and left(a.pri_part, 3) <> '不良率'
                                    group  by a.pri_customerid,
                                              a.pri_assy,
                                              b.pri_tbprice,
                                              b.pri_perqty) as aa,
                                   pri as bb
                            where  left(bb.pri_part, 3) = '不良率'
                                   and bb.pri_newcostchk = 'Y1'
                                   and bb.pri_customerid = aa.pri_customerid
                                   and bb.pri_assy = aa.pri_assy
                                   and aa.clsum <> bb.pri_cost ";
                clsDB.Execute(strSQL);

                /// 更新材料單的材料價(成本)
                strSQL = $@"update pri
                            set    pri_clcost = Round(ab.材料價, 6),
                                   pri_costflag = 'N'
                            from   (select distinct c.pri_customerid,
                                                    c.pri_assy,
                                                    ( case
                                                        when pri_um = 'Feet' then (
                                                        c1.clsum + c2.a1 + c3.cost +
                                                        c4.cost ) / 3.28084
                                                        else ( c1.clsum + c2.a1 + c3.cost + c4.cost )
                                                      end ) as 材料價
                                    from   pri as c with (NOLOCK)
                                           left join (select Sum(a.pri_cost) * b.pri_tbprice * b.pri_perqty as clsum,
                                                             a.pri_customerid,
                                                             a.pri_assy
                                                      from   pri as a with (NOLOCK)
                                                             left join (select pri_tbprice,
                                                                               pri_perqty,
                                                                               pri_customerid,
                                                                               pri_assy
                                                                        from   pri nolock
                                                                        where  left(pri_part, 2) = '不良'
                                                                               and pri_newcostchk = 'Y1') as b
                                                                    on a.pri_customerid = b.pri_customerid
                                                                       and a.pri_assy = b.pri_assy
                                                      where  a.pri_newcostchk = 'Y1'
                                                             and left(a.pri_part, 2) <> '不良'
                                                      group  by a.pri_customerid,
                                                                a.pri_assy,
                                                                b.pri_tbprice,
                                                                b.pri_perqty) as c1
                                                  on c1.pri_customerid = c.pri_customerid
                                                     and c1.pri_assy = c.pri_assy
                                           left join (select Sum(pri_cost) / Sum(pri_perqty) as a1,
                                                             pri_customerid,
                                                             pri_assy
                                                      from   pri nolock
                                                      where  pri_newcostchk = 'Y1'
                                                             and Substring(pri_part, 1, 2) not in ( '不良', '加工', '編織' )
                                                      group  by pri_customerid,
                                                                pri_assy) as c2
                                                  on c2.pri_customerid = c.pri_customerid
                                                     and c2.pri_assy = c.pri_assy
                                           left join (select Sum(pri_cost) as cost,
                                                             pri_customerid,
                                                             pri_assy
                                                      from   pri nolock
                                                      where  left(pri_part, 2) = '加工'
                                                             and pri_newcostchk = 'Y1'
                                                      group  by pri_customerid,
                                                                pri_assy) as c3
                                                  on c3.pri_customerid = c.pri_customerid
                                                     and c3.pri_assy = c.pri_assy
                                           left join (select Sum(pri_cost) as cost,
                                                             pri_customerid,
                                                             pri_assy
                                                      from   pri nolock
                                                      where  left(pri_part, 2) = '編織'
                                                             and pri_newcostchk = 'Y1'
                                                      group  by pri_customerid,
                                                                pri_assy) as c4
                                                  on c4.pri_customerid = c.pri_customerid
                                                     and c4.pri_assy = c.pri_assy) as ab,
                                   pri as ac
                            where  ac.pri_newcostchk = 'Y1'
                                   and ac.pri_customerid = ab.pri_customerid
                                   and ac.pri_assy = ab.pri_assy
                                   and ac.pri_clcost <> Round(ab.材料價, 6)";
                clsDB.Execute(strSQL);

                /// 找出火車頭單價跟材料單的成本不一致的
                strSQL = $@"update asp
                            set    asp_location = 'S',
                                   asp_purprice = Round(a01.pri_clcost, 6),
                                   asp_pricecal = Ltrim(Str(Round(a01.pri_clcost, 6), 100, 6)),
                                   asp_currency = '臺幣',
                                   asp_user = '系統更新'
                            from   (select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_clcost
                                    from   pri
                                    where  pri_newcostchk = 'Y1') as a01,
                                   asp
                            where  asp_id = a01.pri_customerid
                                   and asp_vendormaterialno = a01.pri_assy
                                   and a01.pri_clcost <> asp_purprice ";
                clsDB.Execute(strSQL);

                /// 找出火車頭內層單價跟材料單的成本不一致的
                strSQL = $@"update aspnum
                            set    aspnum_price = Round(a02.pri_clcost, 6),
                                   aspnum_pricecal = Ltrim(Str(Round(a02.pri_clcost, 6), 100, 6)),
                                   aspnum_currency = '臺幣'
                            from   (select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_clcost
                                    from   pri
                                    where  pri_newcostchk = 'Y1') as a02,
                                   aspnum
                            where  aspnum_id = a02.pri_customerid
                                   and aspnum_num = a02.pri_assy
                                   and a02.pri_clcost <> aspnum_price ";
                clsDB.Execute(strSQL);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-DoUpdatepriclcost1" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoUpdatepriclcost2() // 一般成本計算處理
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                /// 取得目前時間
                string strTime = DateTime.Now.ToString("yyyy/M/dd HH:mm:ss");

                /// 
                strSQL = $@"update pri
                            set    pri_cost = Round(pri_tbprice * pri_perqty, 6),
                                   pri_costflag = 'Y'
                            where  pri_cost <> Round(pri_tbprice * pri_perqty, 6)
                                   and left(pri_part, 3) <> '不良率'
                                   and left(pri_part, 2) <> '佣金'
                                   and left(pri_firstname, 1) <> '其'
                                   and right(pri_part, 1) <> '才'
                                   and pri_newcostchk = 'Y2' ";
                clsDB.Execute(strSQL);

                /// Y2不良率
                strSQL = $@"update pri
                            set    pri_cost = Round(c.qt * pri_tbprice * pri_perqty, 6),
                                   pri_costflag = 'Y'
                            from   (select a.nbr as ab,
                                           b.qty as qt
                                    from   (select pri_nbr as nbr,
                                                   pri_assy,
                                                   pri_date,
                                                   pri_customer,
                                                   pri_length,
                                                   pri_customerid
                                            from   pri
                                            where  left(pri_part, 3) = '不良率'
                                                   and pri_newcostchk = 'Y2') as a
                                           left outer join (select pri_assy,
                                                                   pri_date,
                                                                   pri_customer,
                                                                   pri_length,
                                                                   pri_customerid,
                                                                   Sum(pri_cost) as qty
                                                            from   pri
                                                            where  left(pri_part, 1) not in ( '包', '裝', '運', '不', '調' )
                                                                   and right(pri_part, 1) <> '才'
                                                                   and pri_newcostchk = 'Y2'
                                                            group  by pri_assy,
                                                                      pri_date,
                                                                      pri_customer,
                                                                      pri_length,
                                                                      pri_customerid) as b
                                                        on a.pri_assy = b.pri_assy
                                                           and a.pri_date = b.pri_date
                                                           and a.pri_customer = b.pri_customer
                                                           and a.pri_length = b.pri_length
                                                           and a.pri_customerid = b.pri_customerid) as c,
                                   pri
                            where  pri_nbr = c.ab
                                   and Round(pri_cost, 6) <> Round(c.qt * pri_tbprice * pri_perqty, 6)
                                   and pri_newcostchk = 'Y2'";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update pri
                            set    pri_cost = Round(pri_tbprice / pri_perqty, 6)
                            where  right(pri_part, 1) = '才'
                                   and pri_newcostchk = 'Y2'
                                   and pri_cost <> Round(pri_tbprice / pri_perqty, 6) ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update pri
                            set    pri_clcost = Round(c.ccost, 6),
                                   pri_costflag = 'N'
                            from   (select a.pri_nbr as nbr,
                                           ( case
                                               when a.pri_um = 'Feet'
                                                    and a.pri_newcostchk = 'Y2' then ( b.cost / 3.28084 )
                                               else b.cost
                                             end )   as ccost
                                    from   pri as a
                                           left outer join (select pri_assy       as assy,
                                                                   pri_customer   as customer,
                                                                   pri_date       as dat,
                                                                   pri_length     as length,
                                                                   pri_customerid as customerid,
                                                                   Sum(pri_cost)  as cost
                                                            from   pri nolock
                                                            group  by pri_assy,
                                                                      pri_customer,
                                                                      pri_date,
                                                                      pri_length,
                                                                      pri_customerid) as b
                                                        on a.pri_assy = b.assy
                                                           and a.pri_customer = b.customer
                                                           and a.pri_date = b.dat
                                                           and a.pri_length = b.length
                                                           and a.pri_customerid = b.customerid
                                                           and pri_newcostchk = 'Y2') as c,
                                   pri
                            where  c.nbr = pri_nbr
                                   and pri_newcostchk = 'Y2'
                                   and pri_clcost <> Round(c.ccost, 6) ";
                clsDB.Execute(strSQL);

                /// 轉換1筆1筆UPDATE
                //strSQL = $@"update asp
                //            set    asp_location = 'S',
                //                   asp_purprice = Round(a01.pri_clcost, 6),
                //                   asp_pricecal = Ltrim(Str(Round(a01.pri_clcost, 6), 100, 6)),
                //                   asp_currency = '臺幣',
                //                   asp_user = '系統更新'
                //            from   (select distinct pri_customerid,
                //                                    pri_assy,
                //                                    pri_clcost
                //                    from   pri
                //                    where  pri_newcostchk = 'Y2') as a01,
                //                   asp
                //            where  asp_id = a01.pri_customerid
                //                   and asp_vendormaterialno = a01.pri_assy
                //                   and a01.pri_clcost <> asp_purprice ";
                //clsDB.Execute(strSQL);

                strSQL = $@"select a01.pri_customerid as id,
                                   a01.pri_assy       as no,
                                   a01.pri_clcost     as price
                           from   (select distinct pri_customerid,
                                                   pri_assy,
                                                   pri_clcost
                                   from   pri
                                   where  pri_newcostchk = 'Y2') as a01,
                                   asp
                           where  asp_id = a01.pri_customerid
                                   and asp_vendormaterialno = a01.pri_assy
                                   and a01.pri_clcost <> asp_purprice ";
                dt = clsDB.sql_select_dt(strSQL);
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    strSQL = $@"update asp
                                set    asp_location = 'S',
                                       asp_purprice = Round({dt.Rows[i]["price"].ToString()}, 6),
                                       asp_pricecal = Ltrim(Str(Round({dt.Rows[i]["price"]}, 6), 100, 6)),
                                       asp_currency = '臺幣',
                                       asp_user = '系統更新'
                                where  asp_id = '{dt.Rows[i]["id"].ToString()}'
                                       and asp_vendormaterialno = '{dt.Rows[i]["no"].ToString()}' ";
                    clsDB.Execute(strSQL);
                }

                /// 
                strSQL = $@"update aspnum
                            set    aspnum_price = Round(a01.pri_clcost, 6),
                                   aspnum_pricecal = Ltrim(Str(Round(a01.pri_clcost, 6), 100, 6)),
                                   aspnum_currency = '臺幣'
                            from   (select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_clcost
                                    from   pri
                                    where  pri_newcostchk = 'Y2') as a01,
                                   aspnum
                            where  aspnum_id = a01.pri_customerid
                                   and aspnum_num = a01.pri_assy
                                   and a01.pri_clcost <> aspnum_price ";
                clsDB.Execute(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-DoUpdatepriclcost2" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoUpdatepriclcost3() // 錫輔料成本計算
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                /// 
                strSQL = $@"update pri
                            set    pri_cost = Round(pri_tbprice * pri_perqty, 6),
                                   pri_costflag = 'Y'
                            where  pri_cost <> Round(pri_tbprice * pri_perqty, 6)
                                   and left(pri_part, 3) <> '不良率'
                                   and left(pri_part, 2) <> '佣金'
                                   and left(pri_firstname, 1) <> '其'
                                   and right(pri_part, 1) <> '才'
                                   and pri_newcostchk = 'Y3' ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update pri
                            set    pri_clcost = Round(c1.pcost + c2.pri_cost, 6),
                                   pri_costflag = 'N'
                            from   pri
                                   left join (select pri_customerid       as pid,
                                                     Sum(pri_cost) / 1000 as pcost
                                              from   pri with (nolock)
                                              where  pri_newcostchk = 'Y3'
                                                     and left(pri_part, 4) <> '焊工補貼'
                                              group  by pri_customerid) as c1
                                          on c1.pid = pri_customerid
                                   left join (select pri_customerid as pid1,
                                                     pri_cost
                                              from   pri with (nolock)
                                              where  pri_newcostchk = 'Y3'
                                                     and left(pri_part, 4) = '焊工補貼') as c2
                                          on c2.pid1 = pri_customerid
                            where  pri_newcostchk = 'Y3'
                                   and pri_clcost <> Round(c1.pcost + c2.pri_cost, 6) ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update asp
                            set    asp_location = 'S',
                                   asp_purprice = a01.pri_clcost,
                                   asp_pricecal = Ltrim(Str(a01.pri_clcost, 100, 6)),
                                   asp_currency = '臺幣',
                                   asp_user = '系統更新'
                            from   (select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_clcost
                                    from   pri
                                    where  pri_newcostchk = 'Y3') as a01,
                                   asp
                            where  asp_id = a01.pri_customerid
                                   and asp_vendormaterialno = a01.pri_assy
                                   and a01.pri_clcost <> asp_purprice ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update aspnum
                            set    aspnum_price = a02.pri_clcost,
                                   aspnum_pricecal = Ltrim(Str(a02.pri_clcost, 100, 6)),
                                   aspnum_currency = '臺幣'
                            from   (select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_clcost
                                    from   pri
                                    where  pri_newcostchk = 'Y3') as a02,
                                   aspnum
                            where  aspnum_id = a02.pri_customerid
                                   and aspnum_num = a02.pri_assy
                                   and a02.pri_clcost <> aspnum_price ";
                clsDB.Execute(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-DoUpdatepriclcost3" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoUpdatepriclcost4() // 抽線耗材成本計算
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                /// 
                strSQL = $@"update pri
                            set    pri_cost = Round(pri_tbprice * pri_perqty, 6),
                                   pri_costflag = 'Y'
                            where  pri_cost <> Round(pri_tbprice * pri_perqty, 6)
                                   and left(pri_part, 3) <> '不良率'
                                   and left(pri_part, 2) <> '佣金'
                                   and left(pri_firstname, 1) <> '其'
                                   and right(pri_part, 1) <> '才'
                                   and pri_newcostchk = 'Y4' ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update pri
                            set    pri_clcost = aa.pcost,
                                    pri_costflag = 'N'
                            from   (select pri_customerid                    as pid,
                                            pri_assy                          as psn,
                                            Round(Sum(pri_cost) / 4500000, 6) as pcost
                                    from   pri
                                    where  pri_newcostchk = 'Y4'
                                    group  by pri_customerid,
                                                pri_assy) as aa
                            where  pri_customerid = aa.pid
                                    and pri_assy = aa.psn
                                    and pri_clcost <> aa.pcost ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update asp
                            set    asp_location = 'S',
                                   asp_purprice = a01.pri_clcost,
                                   asp_pricecal = Ltrim(Str(a01.pri_clcost, 100, 6)),
                                   asp_currency = '臺幣',
                                   asp_user = '系統更新'
                            from   (select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_clcost
                                    from   pri
                                    where  pri_newcostchk = 'Y4') as a01,
                                   asp
                            where  asp_id = a01.pri_customerid
                                   and asp_vendormaterialno = a01.pri_assy
                                   and a01.pri_clcost <> asp_purprice ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update aspnum
                            set    aspnum_price = a02.pri_clcost,
                                   aspnum_pricecal = Ltrim(Str(a02.pri_clcost, 100, 6)),
                                   aspnum_currency = '臺幣'
                            from   (select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_clcost
                                    from   pri
                                    where  pri_newcostchk = 'Y4') as a02,
                                   aspnum
                            where  aspnum_id = a02.pri_customerid
                                   and aspnum_num = a02.pri_assy
                                   and a02.pri_clcost <> aspnum_price ";
                clsDB.Execute(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-DoUpdatepriclcost4" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoUpdatepriclcost6() // 鋁箔線材附加成本計算
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                /// 
                strSQL = $@"update pri
                            set    pri_cost = Round(pri_tbprice * pri_perqty, 6),
                                   pri_costflag = 'Y'
                            where  pri_cost <> Round(pri_tbprice * pri_perqty, 6)
                                   and left(pri_part, 3) <> '不良率'
                                   and left(pri_part, 2) <> '佣金'
                                   and left(pri_firstname, 1) <> '其'
                                   and pri_newcostchk = 'Y6' ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update pri
                            set    pri_clcost = Round(( a1.t2 + a2.t1 ) / 4 / 2740, 6),
                                   pri_costflag = 'N'
                            from   pri as aa with (nolock)
                                   left join(select pri_customerid,
                                                    pri_assy,
                                                    Sum(pri_cost) / 2 as t2
                                             from   pri with (nolock)
                                             where  pri_newcostchk = 'Y6'
                                                    and left(pri_part, 2) = '雙面'
                                             group  by pri_customerid,
                                                       pri_assy) as a1
                                          on a1.pri_customerid = aa.pri_customerid
                                             and a1.pri_assy = aa.pri_assy
                                   left join(select pri_customerid,
                                                    pri_assy,
                                                    Sum(pri_cost) as t1
                                             from   pri with (nolock)
                                             where  pri_newcostchk = 'Y6'
                                                    and left(pri_part, 2) <> '雙面'
                                             group  by pri_customerid,
                                                       pri_assy) as a2
                                          on a2.pri_customerid = aa.pri_customerid
                                             and a2.pri_assy = aa.pri_assy
                            where  aa.pri_newcostchk = 'Y6'
                                   and pri_clcost <> Round(( a1.t2 + a2.t1 ) / 4 / 2740, 6) ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update asp
                            set    asp_location = 'S',
                                   asp_purprice = a01.pri_clcost,
                                   asp_pricecal = Ltrim(Str(a01.pri_clcost, 100, 6)),
                                   asp_currency = '臺幣',
                                   asp_user = '系統更新'
                            from   (select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_clcost
                                    from   pri
                                    where  pri_newcostchk = 'Y6') as a01,
                                   asp
                            where  asp_id = a01.pri_customerid
                                   and asp_vendormaterialno = a01.pri_assy
                                   and a01.pri_clcost <> asp_purprice ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update aspnum
                            set    aspnum_price = a02.pri_clcost,
                                   aspnum_pricecal = Ltrim(Str(a02.pri_clcost, 100, 6)),
                                   aspnum_currency = '臺幣'
                            from   (select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_clcost
                                    from   pri
                                    where  pri_newcostchk = 'Y6') as a02,
                                   aspnum
                            where  aspnum_id = a02.pri_customerid
                                   and aspnum_num = a02.pri_assy
                                   and a02.pri_clcost <> aspnum_price ";
                clsDB.Execute(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-DoUpdatepriclcost6" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoUpdatepriclcost7() // 銅箔線材附加成本計算
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                /// 
                strSQL = $@"update pri
                            set    pri_cost = Round(pri_tbprice * pri_perqty, 6),
                                   pri_costflag = 'Y'
                            where  pri_cost <> Round(pri_tbprice * pri_perqty, 6)
                                   and left(pri_part, 3) <> '不良率'
                                   and left(pri_part, 2) <> '佣金'
                                   and left(pri_firstname, 1) <> '其'
                                   and pri_newcostchk = 'Y7' ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update pri
                            set    pri_clcost = Round(( a2.t1 / 5 / 2740 ) + ( a1.t2 / 2740 ), 6),
                                   pri_costflag = 'N'
                            from   pri
                                   left join(select pri_customerid    as pid1,
                                                    pri_assy          as psn1,
                                                    Sum(pri_cost) / 2 as t2
                                             from   pri with (nolock)
                                             where  pri_newcostchk = 'Y7'
                                                    and left(pri_part, 2) = '雙面'
                                             group  by pri_customerid,
                                                       pri_assy) as a1
                                          on a1.pid1 = pri_customerid
                                             and a1.psn1 = pri_assy
                                   left join(select pri_customerid as pid2,
                                                    pri_assy       as psn2,
                                                    Sum(pri_cost)  as t1
                                             from   pri with (nolock)
                                             where  pri_newcostchk = 'Y7'
                                                    and left(pri_part, 2) <> '雙面'
                                             group  by pri_customerid,
                                                       pri_assy) as a2
                                          on a2.pid2 = pri_customerid
                                             and a2.psn2 = pri_assy
                            where  pri_newcostchk = 'Y7'
                                   and pri_clcost <> Round(( a2.t1 / 5 / 2740 ) + ( a1.t2 / 2740 ), 6) ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update asp
                            set    asp_location = 'S',
                                    asp_purprice = a01.pri_clcost,
                                    asp_pricecal = Ltrim(Str(a01.pri_clcost, 100, 6)),
                                    asp_currency = '臺幣',
                                    asp_user = '系統更新'
                            from   (select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_clcost
                                    from   pri
                                    where  pri_newcostchk = 'Y7') as a01,
                                    asp
                            where  asp_id = a01.pri_customerid
                                    and asp_vendormaterialno = a01.pri_assy
                                    and a01.pri_clcost <> asp_purprice ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update aspnum
                            set    aspnum_price = a02.pri_clcost,
                                   aspnum_pricecal = Ltrim(Str(a02.pri_clcost, 100, 6)),
                                   aspnum_currency = '臺幣'
                            from   (select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_clcost
                                    from   pri
                                    where  pri_newcostchk = 'Y7') as a02,
                                   aspnum
                            where  aspnum_id = a02.pri_customerid
                                   and aspnum_num = a02.pri_assy
                                   and a02.pri_clcost <> aspnum_price ";
                clsDB.Execute(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-DoUpdatepriclcost7" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void DoUpdatepriclcost11() // 平均計算成本
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                /// 
                strSQL = $@"update pri
                            set    pri_cost = Round(pri_tbprice * pri_perqty, 6),
                                   pri_costflag = 'Y'
                            where  pri_cost <> Round(pri_tbprice * pri_perqty, 6)
                                   and left(pri_part, 3) <> '不良率'
                                   and left(pri_part, 2) <> '佣金'
                                   and left(pri_firstname, 1) <> '其'
                                   and pri_newcostchk = 'YB' ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update pri
                            set    pri_clcost = Round(case pri_um
                                                        when 'Feet' then ( a1.pcost / a2.pcount ) / 3.28084
                                                        else ( a1.pcost / a2.pcount )
                                                      end, 6),
                                   pri_costflag = 'N'
                            from   pri
                                   left join(select pri_customerid          as pid1,
                                                    Sum(Round(pri_cost, 6)) as pcost
                                             from   pri with (nolock)
                                             where  pri_newcostchk = 'YB'
                                                    and left(pri_part, 3) <> '不良率'
                                             group  by pri_customerid) as a1
                                          on a1.pid1 = pri_customerid
                                   left join(select N.pid2,
                                                    Count(N.pri_part) as pcount
                                             from   (select distinct pri_customerid as pid2,
                                                                     pri_part
                                                     from   pri
                                                     where  pri_newcostchk like 'YB') as N
                                             group  by N.pid2) as a2
                                          on a2.pid2 = pri_customerid
                            where  pri_newcostchk = 'YB'
                                   and pri_clcost <> Round(case pri_um
                                                             when 'Feet' then ( a1.pcost / a2.pcount ) /
                                                                              3.28084
                                                             else ( a1.pcost / a2.pcount )
                                                           end, 6) ";
                clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update asp
                            set    asp_location = 'S',
                                   asp_purprice = a01.pri_clcost,
                                   asp_pricecal = Ltrim(Str(a01.pri_clcost, 100, 6)),
                                   asp_currency = '臺幣',
                                   asp_user = '系統更新'
                            from   (select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_clcost
                                    from   pri
                                    where  pri_newcostchk = 'YB') as a01,
                                   asp
                            where  asp_id = a01.pri_customerid
                                   and asp_vendormaterialno = a01.pri_assy
                                   and a01.pri_clcost <> asp_purprice ";
                                            clsDB.Execute(strSQL);

                /// 
                strSQL = $@"update aspnum
                            set    aspnum_price = a02.pri_clcost,
                                   aspnum_pricecal = Ltrim(Str(a02.pri_clcost, 100, 6)),
                                   aspnum_currency = '臺幣'
                            from   (select distinct pri_customerid,
                                                    pri_assy,
                                                    pri_clcost
                                    from   pri
                                    where  pri_newcostchk = 'YB') as a02,
                                   aspnum
                            where  aspnum_id = a02.pri_customerid
                                   and aspnum_num = a02.pri_assy
                                   and a02.pri_clcost <> aspnum_price ";
                                            clsDB.Execute(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-DoUpdatepriclcost11" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoUpdate_asp_od()     //更新審核+越南材料check
        {
            string odtmp;
            if (chkCheck.Checked == true)
            {
                odtmp = "Y";
            }
            else
            {
                odtmp = " ";
            }
            if (chkMaterial_VN.Checked == true)
            {
                odtmp = odtmp + "Y";
            }
            else
            {
                odtmp = odtmp + " ";
            }
            string strSQL = $@"update asp 
                                set   asp_od = '{odtmp}', 
                                      asp_oddate = '{oddate}', 
                                      asp_oduser = '{oduser}', 
                                      asp_multinum = N'{asp_multinum}' 
                                where asp_id = '{asp_id}'";
            clsDB.Execute(strSQL);
        }

        private void DoUpdate_asp_line()     //更新越南運費計重
        {
            if (chkShippingFee_VN.Checked == true)
            {
                //使用asp_line欄位來記錄越南運費計重,asp_vnweight記錄重量,asp_vnpcs記錄數量
                DoUpdate_asp_line_Y();
                //更新計重重量
                DoUpdateWeight();

            }
            else
            {
                //使用asp_line欄位來記錄越南運費計重,asp_vnweight記錄重量,asp_vnpcs記錄數量
                DoUpdate_asp_line_N();
                //更新計重重量
                DoUpdateWeight();
            }
        }

        private void DoUpdate_asp_line_Y()     //使用asp_line_Y欄位來記錄越南運費計重,asp_vnweight記錄重量,asp_vnpcs記錄數量
        {
            string strSQL = $@"update asp set asp_line='Y',asp_vnweight= {asp_vnweight} ,asp_vnpcs={asp_vnpcs} where asp_id='{asp_id}'";
            clsDB.Execute(strSQL);
        }

        private void DoUpdate_asp_line_N()     //使用asp_line_Y欄位來記錄越南運費計重,asp_vnweight記錄重量,asp_vnpcs記錄數量
        {
            string strSQL = $@"update asp set asp_line='',asp_vnweight= 0 ,asp_vnpcs=0 where asp_id='{asp_id}' and asp_line='Y'";
            clsDB.Execute(strSQL);
        }

        private void DoUpdateWeight()     //更新計重重量
        {
            string vid;
            string strSQL = $@"SELECT distinct pri_customerid from pri with (nolock) where pri_part in ( select pub_vnfreight from pub) and pri_customerid in (select pri_customerid from pri where pri_part = '{asp_id}')";
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vid = (string)dt.Rows[i]["pri_customerid"];

                    strSQL = $@"SELECT pri_perqty,isnull(asp_vnweight,0) 'asp_vnweight',isnull(asp_vnpcs,0) 'asp_vnpcs' from pri with (nolock) left join asp on asp_id=pri_part where pri_customerid ='{vid}' and asp_line='Y'";
                    Values V = GetValues(strSQL);       //取得vqtycal;vqtysum;
                    strSQL = $@"update pri set pri_perqty=round({V.vqtysum},6),pri_perqtycal='{V.vqtycal}',pri_cost=round(pri_tbprice*round({V.vqtysum},6),6),pri_costflag='Y' where pri_customerid='{vid}' and pri_part in (select pub_vnfreight from pub)";
                    clsDB.Execute(strSQL);       //執行SQL命令
                }
            }
        }

        private Values GetValues(string strSQL)      //取得vqtycal;vqtysum;
        {
            Values V = new Values();
            V.vqtycal = "";
            V.vqtysum = 0;
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (V.vqtycal == "")
                    {
                        if (dt.Rows[i]["asp_vnweight"].ToString() == "0")
                        {
                            V.vqtycal = ((double)dt.Rows[i]["pri_perqty"]).ToString("0." + new string('#', 339));
                            V.vqtysum = (double)dt.Rows[i]["pri_perqty"];
                        }
                        else
                        {
                            V.vqtycal = ((double)dt.Rows[i]["asp_vnweight"]).ToString("0." + new string('#', 339)) + "/" + ((double)dt.Rows[i]["asp_vnpcs"]).ToString("0." + new string('#', 339)) + "*" + ((double)dt.Rows[i]["pri_perqty"]).ToString("0." + new string('#', 339));
                            V.vqtysum = (double)dt.Rows[i]["asp_vnweight"] / (double)dt.Rows[i]["asp_vnpcs"] * (double)dt.Rows[i]["pri_perqty"];
                        }
                    }
                    else
                    {
                        if (dt.Rows[i]["asp_vnweight"].ToString() == "0")
                        {
                            V.vqtycal = V.vqtycal + "+" + ((double)dt.Rows[i]["pri_perqty"]).ToString("0." + new string('#', 339));
                            V.vqtysum = V.vqtysum + (double)dt.Rows[i]["pri_perqty"];
                        }
                        else
                        {
                            V.vqtycal = V.vqtycal + "+" + ((double)dt.Rows[i]["asp_vnweight"]).ToString("0." + new string('#', 339)) + "/" + ((double)dt.Rows[i]["asp_vnpcs"]).ToString("0." + new string('#', 339)) + "*" + ((double)dt.Rows[i]["pri_perqty"]).ToString("0." + new string('#', 339));
                            V.vqtysum = V.vqtysum + (double)dt.Rows[i]["asp_vnweight"] / (double)dt.Rows[i]["asp_vnpcs"] * (double)dt.Rows[i]["pri_perqty"];
                        }
                    }
                }
            }
            return V;
        }

        struct Values
        {
            public string vqtycal;
            public double vqtysum;
        }

        private void DoUpdate_asp_lengum()     //線材材料UL標記
        {
            if (chkSafety.Checked == true)
            {
                asp_lengum = "Y";
            }
            else
            {
                asp_lengum = "";
            }
            string strSQL = $@"update asp set asp_lengum='{asp_lengum}' where asp_id='{asp_id}'";
            clsDB.Execute(strSQL);
        }

        private void DoCheck_asp_vendormaterialno()     //檢查是否有品號,若有則檢查多品號設定
        {
            Boolean chknum = false;
            string strSQL = "";
            if (asp_vendormaterialno != "")
            {
                strSQL = $@"SELECT  [aspnum_id] as 材料名,[aspnum_num] AS 品號 From aspnum  where aspnum_id ='{asp_id}' and aspnum_num='{asp_vendormaterialno}'";
                DataTable dt = new DataTable();
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    chknum = true;
                }

                if (chknum != true)//'檢查多品號中是否已有資料,若有才處理,若沒有則要先建立好品號資料才能儲存
                {
                    strSQL = $@"INSERT INTO [dbo].[aspnum] 
                                ([aspnum_id],[aspnum_num],[aspnum_modifydate],[aspnum_price],[aspnum_currency],[aspnum_memo],[aspnum_pricecal],[aspnum_vendorid],[aspnum_spec],[aspnum_um]) 
                                VALUES 
                                ('{asp_id}','{asp_vendormaterialno}','{DateTime.Now.ToString("yyyy/MM/dd")}','{asp_purprice} ','{asp_currency} ','{asp_czf} ','{asp_pricecal} ','{asp_vendorid} ','{asp_spec} ','{asp_um} ')";
                    clsDB.Execute(strSQL);       //執行SQL命令
                }
            }
            else
            {
                strSQL = $@"delete from aspnum  where aspnum_id ='{asp_id}'";
                clsDB.Execute(strSQL);       //執行SQL命令
            }
        }

        private void DoCheck_pri_newcostchk()     //檢查材料單是否存在,若不存在則把標記去除
        {
            string strSQL = "";
            strSQL = $@"select * from pri where pri_customerid='{asp_id}' and pri_newcostchk like 'Y%'";
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count == 0)
            {
                strSQL = $@"update asp set asp_name='' where asp_id='{asp_id}'";
                clsDB.Execute(strSQL);       //執行SQL命令
            }
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
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                strSQL = $@"select asp_id from asp where asp_id='{txtID.Text}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    if (clsGlobal.checkRightFlag("火車頭資料儲存權限") == false)
                    {
                        MessageBox.Show("你沒有火車頭資料儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        return;
                    }
                    if (clsGlobal.checkRightFlag("火車頭控管材料儲存權限") == false)
                    {
                        MessageBox.Show("你沒有火車頭控管材料儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        return;
                    }
                    if (clsGlobal.checkRightFlag("火車頭審核") == false)
                    {
                        MessageBox.Show("你沒有火車頭審核權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        return;
                    }
                }
                if (txtID.Text == "")
                {
                    MessageBox.Show("材料名不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                if (getStrLength(txtID.Text) > 30)
                {
                    MessageBox.Show("材料名長度" + getStrLength(txtID.Text).ToString() + ",已超過30個字元長度.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                if (txtNo.Text == "")
                {
                    if (MessageBox.Show(this, "品號空白,若繼續儲存,則多品號資料會被清除,您確定要儲存嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        return;
                    }
                }
                ///限制由「5.設定」區域回寫的材料無法在此被修改
                if (txtID.Text == "工廠成本/分/vn" || txtID.Text == "焊工補貼" || txtID.Text == "社保/月" || txtID.Text == "人工成本/分" || txtID.Text == "工廠成本/分" || txtID.Text == "人工成本/分/vn")
                {
                    MessageBox.Show("此材料是由系統設定來調整,請勿在火車頭修改!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }

                ///檢查是否與廠商資料幣種不同
                //strSQL = $@"select ven_currency
                //            from   asp,
                //                   ven
                //            where  asp_id = '{txtID.Text}'
                //                   and asp_vendormaterialno = '{txtNo.Text}'
                //                   and ven_id = asp_vendorid ";
                //dt=clsDB.sql_select_dt(strSQL);
                //if(dt.Rows.Count>0)
                //{
                //    if (dt.Rows[0]["ven_currency"].ToString() !=cboCurrency.Text)
                //    {
                //        if (MessageBox.Show(this, "幣種與該廠商基本資料不一致!" + "\n" + "廠商資料幣種為:" + dt.Rows[0]["ven_currency"].ToString() + "\n" + "您要儲存嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //        {
                //            this.Cursor = Cursors.Default;//滑鼠還原預設
                //            return;
                //        }
                //    }
                //}

                ///檢查越南運費的重量數量是否單一為0
                if (chkShippingFee_VN.Checked == true)
                {
                    if (Convert.ToDouble(txtWeight.Text) == 0 && Convert.ToDouble(txtQuantity.Text) > 0)
                    {
                        MessageBox.Show("越南運費的重量數量二個可為0," + "\n" + "但不可單一為0,請重新輸入.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        txtWeight.Focus();
                        return;
                    }
                    if (Convert.ToDouble(txtQuantity.Text) == 0 && Convert.ToDouble(txtWeight.Text) > 0)
                    {
                        MessageBox.Show("越南運費的重量數量二個可為0," + "\n" + "但不可單一為0,請重新輸入.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        txtQuantity.Focus();
                        return;
                    }
                }
                string strPID = checkPID(txtNo.Text, txtID.Text);
                if (strPID != "")
                {
                    if (strPID == "2")
                    {
                        MessageBox.Show("此品號前6碼不一致,請檢查!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        txtNo.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("此品號前6碼不一致,請檢查!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        txtNo.Focus();
                        return;
                    }
                }
                else
                {
                    /// 材料名資料儲存
                    if (txtPurprice.Text == "")
                    {
                        txtPurprice.Text = "0";
                    }

                    if (strStandprice == "")
                    {
                        strStandprice = "0";
                    }
                    if (strSafeqty == "")
                    {
                        strSafeqty = "0";
                    }
                    if (strWeight == "")
                    {
                        strWeight = "0";
                    }
                    if (strPurleadtime == "")
                    {
                        strPurleadtime = "0";
                    }
                    if (strMakeleadtime == "")
                    {
                        strMakeleadtime = "0";
                    }
                    if (strPurchprice == "")
                    {
                        strPurchprice = "0";
                    }
                    if (strSalesprice == "")
                    {
                        strSalesprice = "0";
                    }
                    if (strTjjz == "")
                    {
                        strTjjz = "0";
                    }
                    asp_multinum = txtMultinum.Text;
                    if (strPricecal == "")
                    {
                        strPricecal = "0";
                    }
                    if (txtWeight.Text == "")
                    {
                        txtWeight.Text = "0";
                    }
                    asp_vnweight = Convert.ToDouble(txtWeight.Text);
                    if (txtQuantity.Text == "")
                    {
                        txtQuantity.Text = "0";
                    }
                    asp_vnpcs = Convert.ToDouble(txtQuantity.Text);

                    asp_id = txtID.Text;
                    asp_type = strType;
                    asp_name = strName;
                    asp_um = cboUnit.Text;
                    asp_purprice = Convert.ToDouble(txtPurprice.Text);
                    asp_standprice = Convert.ToDouble(strStandprice);
                    asp_vendorid = txtVendorID.Text;
                    asp_currency = cboCurrency.Text;
                    asp_czf = txtCzf.Text;
                    asp_tjjz = Convert.ToDouble(strTjjz);
                    asp_area = strArea;
                    asp_safeqty = Convert.ToDouble(strSafeqty);
                    asp_weight = Convert.ToDouble(strWeight);
                    asp_purleadtime = Convert.ToDouble(strPurleadtime);
                    asp_makeleadtime = Convert.ToDouble(strMakeleadtime);
                    asp_salesprice = Convert.ToDouble(strSalesprice);
                    asp_purchprice = Convert.ToDouble(strPurchprice);
                    if (chkControlMeterial.Checked == true)
                    {
                        asp_dummyflag = 1;
                    }
                    else
                    {
                        asp_dummyflag = 0;
                    }
                    asp_pricecal = strPricecal;
                    asp_vendormaterialno = txtNo.Text;
                    asp_spec = txtSpec.Text;
                    asp_location = strLocation;
                    #region 更新 asp(OLD)
                    //if (txtPurprice.Text == oldprice)  // 修改單價不改加速火車頭儲存
                    //{
                    //    strSQL = $@"exec asp_save1 N'{asp_id}',
                    //                               '{asp_type}',
                    //                               '{asp_name}',
                    //                               '{asp_um}',
                    //                               {asp_purprice},
                    //                               {asp_standprice},
                    //                               '{asp_vendorid}',
                    //                               '{asp_currency}',
                    //                               N'{asp_czf}',
                    //                               '{asp_tjjz}',
                    //                               '{asp_area}',
                    //                               {asp_safeqty},
                    //                               {asp_weight},
                    //                               {asp_purleadtime},
                    //                               {asp_makeleadtime},
                    //                               '',
                    //                               {asp_purchprice},
                    //                               '{asp_purcurrency}',
                    //                               {asp_dummyflag},
                    //                               '{asp_pricecal}',
                    //                               '{asp_vendormaterialno}',
                    //                               N'{asp_spec}'";
                    //    clsDB.Execute(strSQL);
                    //}
                    //else
                    //{
                    //    strSQL = $@"exec asp_save N'{asp_id}',
                    //                              '{asp_type}',
                    //                              '{asp_name}',
                    //                              '{asp_um}',
                    //                              {asp_purprice},
                    //                              {asp_standprice},
                    //                              '{asp_vendorid}',
                    //                              '{asp_currency}',
                    //                              N'{asp_czf}',
                    //                              '{asp_tjjz}',
                    //                              '{asp_area}',
                    //                              {asp_safeqty},
                    //                              {asp_weight},
                    //                              {asp_purleadtime},
                    //                              {asp_makeleadtime},
                    //                              '',
                    //                              {asp_purchprice},
                    //                              '{asp_purcurrency}',
                    //                              {asp_dummyflag},
                    //                              '{asp_pricecal}',
                    //                              '{asp_vendormaterialno}',
                    //                              N'{asp_spec}'";
                    //    clsDB.Execute(strSQL);
                    //} 
                    #endregion

                    DoUpdate_asp();                     //更新asp資料
                    DoUpdate_asp_od();                  //更新審核+越南材料check
                    DoUpdate_asp_line();                //更新越南運費計重
                    DoUpdate_asp_lengum();              //線材材料UL標記
                    DoCheck_asp_vendormaterialno();     //檢查是否有品號,若有則檢查多品號設定
                    DoCheck_pri_newcostchk();           //檢查材料單是否存在,若不存在則把標記去除

                    MessageBox.Show("已經儲存完成!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Q_Click(object sender, EventArgs e) //搜尋
        {
            getData();  
        }

        private void btnClear_Q_Click(object sender, EventArgs e)   //清除
        {
            //清除
            try
            {
                txtID_Q.Text = "";
                txtNo_Q.Text = "";
                txtVendorID_Q.Text = "";
                txtDate_S.Text = "";
                txtDate_E.Text = "";
                chkUseless_Q.Checked = false;
                chkMeterial_Q.Checked = false;
                chkCheck_Q.Checked = false;
                chkMaterial_VN_Q.Checked = false;
                chkShippingFee_VN_Q.Checked = false;
                chkControlMeterial_Q.Checked = false;
                chkRecord_Q.Checked = false;
                //內外層筆數顯示清除
                btnFilter0.Text = "";
                btnFilter1.Text = "";
                btnFilter2.Text = "";
                btnFilter0.BackColor = Color.FromArgb(224, 224, 224);
                btnFilter1.BackColor = Color.FromArgb(224, 224, 224);
                btnFilter2.BackColor = Color.FromArgb(224, 224, 224);
                btnFilter0.Enabled = false;
                btnFilter1.Enabled = false;
                btnFilter2.Enabled = false;
                btnInq_Material_Q.Enabled = false;

                cboBOM_Q.Text = "(ALL)";
                cboCurrency_Q.Text = "(ALL)";
                //清除dgv
                if (dgvData.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvData.DataSource;
                    dt.Rows.Clear();
                    dgvData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Q_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Q_Click(object sender, EventArgs e)  //匯出
        {
            //匯出
            //clsGlobal clsGlobal = new clsGlobal();
            clsGlobal.ExportExcel("火車頭資料查詢", dgvData);
        }

        private void btnFilter0_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL_0);
            dgvData.DataSource = dt;
            btnFilter0.Text = "外：" + dt.Rows.Count.ToString();
            btnFilter0.BackColor = Color.FromArgb(255, 224, 192);
            btnFilter2.BackColor = Color.FromArgb(224, 224, 224);
            btnFilter1.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void btnFilter1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL_1);
            dgvData.DataSource = dt;
            btnFilter1.Text = "內：" + dt.Rows.Count.ToString();
            btnFilter1.BackColor = Color.FromArgb(255, 224, 192);
            btnFilter2.BackColor = Color.FromArgb(224, 224, 224);
            btnFilter0.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void btnFilter2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = clsDB.sql_select_dt(strSQL_2);
            dgvData.DataSource = dt;
            btnFilter2.Text = "全：" + dt.Rows.Count.ToString();
            btnFilter2.BackColor = Color.FromArgb(255, 224, 192);
            btnFilter0.BackColor = Color.FromArgb(224, 224, 224);
            btnFilter1.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void txtID_Q_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                MessageBox.Show("不可輸入特殊字元< ' >!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.KeyChar = (char)0;   //處理非法字符
            }
        }

        private void txtID_Q_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtID_Q.Text != "")
                {
                    this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                    txtID_Q.Text.Replace("\n", "").Replace("\r", "").Trim();  //去ENTER 換行 空白
                    getData();
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
            }
        }

        private void txtNo_Q_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                MessageBox.Show("不可輸入特殊字元< ' >!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.KeyChar = (char)0;   //處理非法字符
            }
        }

        private void txtNo_Q_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNo_Q.Text != "")
                {
                    txtNo_Q.Text.Replace("\n", "").Replace("\r", "").Trim();  //去ENTER 換行 空白
                    getData();
                }
            }
        }

        private void txtDate_S_TextChanged(object sender, EventArgs e)
        {
            if (txtDate_S.Text == "")
            {
                txtDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtDate_E_TextChanged(object sender, EventArgs e)
        {
            if (txtDate_E.Text == "")
            {
                txtDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtID.Text != "")
                {
                    txtID.Text = txtID.Text.Replace("\n", "").Replace("\r", "").Trim();  //去ENTER 換行 空白
                }
                if (txtID.Text.Length > 30)
                {
                    MessageBox.Show("已超過30個字元長度,材料名將儲存在30個字元長度,請注意.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                getID();
                txtNo.Focus();
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                MessageBox.Show("不可輸入特殊字元< ' >!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.KeyChar = (char)0;   //處理非法字符
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            //ToolTip：當游標停滯在某個控制項時，就會跳出一個小視窗
            ToolTip toolTip1 = new ToolTip();
            //SetToolTip：定義控制項會跳出提示的文字
            toolTip1.SetToolTip(txtID, "名稱長度:" + getStrLength(txtID.Text).ToString());
            if (txtID.Text.Length > 0)
            {
                lblLength.Text = getStrLength(txtID.Text).ToString();   //取得字串長度
            }
            else
            {
                lblLength.Text = "";
            }
        }

        private void frmProduct_Activated(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {

                btnClear_Q.PerformClick();
                btnClear.PerformClick();
                if (clsGlobal.checkRightFlag("火車頭審核") == true)
                {
                    chkCheck.Visible = true;
                    chkCheck.Enabled = true;
                }
                else
                {
                    chkCheck.Visible = true;
                    chkCheck.Enabled = false;
                }
                if (clsGlobal.checkRightFlag("火車頭控管材料儲存權限") == true)
                {
                    chkControlMeterial.Enabled = true;
                }
                else
                {
                    chkControlMeterial.Enabled = false;
                }
                lblLength.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmMain_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) //清除
        {
            //清除
            try
            {
                txtID.Text = "";
                strName = "";   //待查Text3.Text = ""是否為材料單的旗標
                strStandprice = "";                //待查Text5.Text = ""
                txtVendorID.Text = "";
                txtPurprice.Text = "";
                oldprice = "";
                c8chg = "";
                cboCurrency.Text = "人民幣";
                cboUnit.Text = "PC";
                strType = "";   //待查Combo1.Text = "線材類"
                txtCzf.Text = "";   //TextBox1.Text = ""
                btnCzf.BackColor = Color.FromArgb(192, 255, 255);   //mpage = "1"預設參照法顯現
                txtCzf.Visible = true;
                txtCzf.BackColor = Color.FromArgb(192, 255, 255);
                txtMultinum.Text = "";   //TextBox2.Text = ""
                btnMultinum.BackColor = Color.FromArgb(0, 255, 255);
                txtMultinum.Visible = false;

                //aspod_chk = False

                strTjjz = "";   //Text11.Text = ""
                strArea = "";   //Combo6.Text = "大陸"
                strSafeqty = "";    //Text17.Text = ""
                strWeight = ""; //Text16.Text = ""
                strPurleadtime = "";    //Text14.Text = ""
                strMakeleadtime = "";   //Text15.Text = ""
                strLocation = "";   //Text18.Text = ""
                strPurchprice = ""; //Text19.Text = ""
                txtSpec.Text = "";
                txtNo.Text = "";
                txtWeight.Text = "";
                txtWeight.Visible = false;
                lblWeight.Visible = false;
                txtQuantity.Text = "";
                txtQuantity.Visible = false;
                lblQuantity.Visible = false;
                chkMaterial_VN.Checked = false;
                chkCheck.Checked = false;
                chkSafety.Checked = false;
                lblCheckDate.Text = "";
                oddate = ""; //20200311審核日期
                oduser = ""; //20200311審核使用者
                chkShippingFee_VN.Checked = false;
                txtID.Focus();
                strSalesprice = ""; //Text22.Text = ""
                strPurcurrency = "";    //Combo7.Text = "人民幣"
                chkControlMeterial.Checked = false;
                lblUser.Text = "";
                lblDate.Text = "";
                strPricecal = "";    //Label35計算式
                lblVendor.Text = "";
                btnInq_No.BackColor = Color.FromArgb(192, 255, 192);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (dgvData.Rows[e.RowIndex].Cells["材料單"].Value.ToString() == "V")
                    {
                        btnInq_Material_Q.Enabled = true;
                    }
                    else
                    {
                        btnInq_Material_Q.Enabled = false;
                    }

                    btnClear.PerformClick();
                    txtID.Text = dgvData.Rows[e.RowIndex].Cells["材料名"].Value.ToString();
                    getID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellDoubleClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCzf_Click(object sender, EventArgs e)
        {
            //btnCzf.BackColor = Color.FromArgb(192, 255, 255);
            //txtCzf.BackColor = Color.FromArgb(192, 255, 255);
            txtCzf.Visible = true;
            //btnMultinum.BackColor = Color.FromArgb(0, 255, 255);
            txtMultinum.Visible = false;
        }

        private void btnMultinum_Click(object sender, EventArgs e)
        {
            //btnMultinum.BackColor = Color.FromArgb(192, 255, 255);
            //txtMultinum.BackColor = Color.FromArgb(192, 255, 255);
            txtMultinum.Visible = true;
            //btnCzf.BackColor = Color.FromArgb(0, 255, 255);
            txtCzf.Visible = false;
        }

        private void txtPurprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                MessageBox.Show("不可輸入特殊字元< ' >!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.KeyChar = (char)0;   //處理非法字符
            }
        }

        private void txtPurprice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtVendorID.Focus();
            }
        }

        private void txtPurprice_DoubleClick(object sender, EventArgs e)
        {
            if (txtPurprice.Text != "")
            {
                MessageBox.Show(" 計算式：  " + strPricecal, "計算式", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPurprice_TextChanged(object sender, EventArgs e)
        {
            //檢查廠商代碼57材料單的單價不可更改
            if (strName == "Y" && txtPurprice.Text != "" && oldprice != "" && checkBom(txtNo.Text))
            {
                if (txtPurprice.Text != oldprice)
                {
                    MessageBox.Show("此材料名已有材料單對應或設定處理,不可變更單價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPurprice.Text = oldprice;
                }
            }

            //檢查"銅桿OD2.6mm/kg"單價不可更改
            if (txtID.Text == "銅桿OD2.6mm/kg" && txtPurprice.Text != "" && oldprice != "")
            {
                if (txtPurprice.Text != oldprice)
                {
                    MessageBox.Show("此材料名已有材料單對應或設定處理,不可變更單價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPurprice.Text = oldprice;
                }
            }
            if (txtID.Text == "PVC粉S-60" && txtPurprice.Text != "" && oldprice != "")
            {
                if (txtPurprice.Text != oldprice)
                {
                    MessageBox.Show("此材料名已有材料單對應或設定處理,不可變更單價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPurprice.Text = oldprice;
                }
            }
            if (txtID.Text == "PVC粉S-65" && txtPurprice.Text != "" && oldprice != "")
            {
                if (txtPurprice.Text != oldprice)
                {
                    MessageBox.Show("此材料名已有材料單對應或設定處理,不可變更單價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPurprice.Text = oldprice;
                }
            }
            if (txtID.Text == "芯線料/HDPE 9007(3364)/kg" && txtPurprice.Text != "" && oldprice != "")
            {
                if (txtPurprice.Text != oldprice)
                {
                    MessageBox.Show("此材料名已有材料單對應或設定處理,不可變更單價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPurprice.Text = oldprice;
                }
            }
            if (txtID.Text == "可塑劑 DOTP" && txtPurprice.Text != "" && oldprice != "")
            {
                if (txtPurprice.Text != oldprice)
                {
                    MessageBox.Show("此材料名已有材料單對應或設定處理,不可變更單價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPurprice.Text = oldprice;
                }
            }
            if (txtID.Text == "可塑劑 TOTM" && txtPurprice.Text != "" && oldprice != "")
            {
                if (txtPurprice.Text != oldprice)
                {
                    MessageBox.Show("此材料名已有材料單對應或設定處理,不可變更單價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPurprice.Text = oldprice;
                }
            }
            if (txtID.Text == "填充劑活性鈣 HX-CCR 3000" && txtPurprice.Text != "" && oldprice != "")
            {
                if (txtPurprice.Text != oldprice)
                {
                    MessageBox.Show("此材料名已有材料單對應或設定處理,不可變更單價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPurprice.Text = oldprice;
                }
            }
            if (txtID.Text == "填充劑中性碳酸鈣XD-2" && txtPurprice.Text != "" && oldprice != "")
            {
                if (txtPurprice.Text != oldprice)
                {
                    MessageBox.Show("此材料名已有材料單對應或設定處理,不可變更單價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPurprice.Text = oldprice;
                }
            }
            
        }

        private void chkShippingFee_VN_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShippingFee_VN.Checked == true)
            {
                lblWeight.Visible = true;
                lblQuantity.Visible = true;
                txtWeight.Visible = true;
                txtQuantity.Visible = true;
                if (txtWeight.Text == "")
                {
                    txtWeight.Text = "0";
                }
                if (txtQuantity.Text == "")
                {
                    txtQuantity.Text = "0";
                }
            }
            else
            {
                lblWeight.Visible = false;
                lblQuantity.Visible = false;
                txtWeight.Visible = false;
                txtQuantity.Visible = false;
                txtWeight.Text = "";
                txtQuantity.Text = "";
            }
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            if (txtWeight.Text.Trim() == "")
            {
                txtWeight.Text = "0";
                txtWeight.SelectAll();
            }
        }

        private void txtWeight_Click(object sender, EventArgs e)
        {
            txtWeight.SelectAll();
        }

        private void txtWeight_Validated(object sender, EventArgs e)
        {
            ///檢查是否為數字
            if (clsGlobal.ValidateString(txtWeight.Text, 7) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWeight.Text = "";
                txtWeight.Focus();
            }
        }

        private void txtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantity.Focus();
                txtQuantity.SelectAll();
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Trim() == "")
            {
                txtQuantity.Text = "0";
                txtQuantity.SelectAll();
            }
        }

        private void txtQuantity_Click(object sender, EventArgs e)
        {
            txtQuantity.SelectAll();
        }

        private void txtQuantity_Validated(object sender, EventArgs e)
        {
            ///檢查是否為數字
            if (clsGlobal.ValidateString(txtQuantity.Text, 7) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Text = "";
                txtQuantity.Focus();
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWeight.Focus();
                txtWeight.SelectAll();
            }
        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheck.Checked == true)
            {
                lblCheckDate.Visible = true;
                oddate = DateTime.Now.ToString("yyyy/MM/dd");
                oduser = clsGlobal.strG_User;
                lblCheckDate.Text = oddate + " " + oduser;
            }
            else
            {
                lblCheckDate.Visible = false;
                oddate = "";
                oduser = "";
                lblCheckDate.Text = "";
            }
        }

        private void btnForceUpdate_Click(object sender, EventArgs e)   //強制更新
        {
            //強制更新
            try
            {
                if (clsGlobal.checkRightFlag("火車頭強制更新") == false)
                {
                    MessageBox.Show("你沒有火車頭強制更新權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"update pub set pub_aimlocked = 1 ";
                clsDB.Execute(strSQL);

                DoUpdate_Priclcost();   //更新價格

                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show("系統已強制更新!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnForceUpdate_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoUpdate_Priclcost()   //更新價格
        {
            //更新價格
            try
            {
                string strSQL = "";
                string rs = "";
                DataTable dt = new DataTable();
                strSQL = $@"select pub_aimlocked
                            from   pub with (NOLOCK)";
                rs = clsDB.sql_select_String(strSQL, "pub_aimlocked");
                if(rs=="1")
                {
                    float rmb = 0;
                    strSQL = $@"select cur_convert
                                from   cur
                                where  cur_code = '人民幣' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        rmb = float.Parse( dt.Rows[0]["cur_convert"].ToString());
                    }

                    strSQL = $@"update pri
                                set    pri_tbprice = Round(Cast(asp_purprice * cur_convert as DECIMAL(20, 9)), 6)
                                from   pri
                                       left join asp
                                              on asp_id = pri_part
                                       left join cur
                                              on cur_code = asp_currency
                                where  Round(pri_tbprice, 6) <> ( Round(Cast(asp_purprice * cur_convert as DECIMAL(20, 9)), 6) )
                                       and pri_part <> '地稅(地方稅)' ";
                    clsDB.Execute(strSQL);

                    DoUpdate_BOM(); //更新材料單價格

                    ///同步材料單價
                    strSQL = $@"update ap3
                                set    ap3_purprice = asp_purprice,
                                       ap3_tbprice = Round(Cast(asp_purprice * cur_convert as DECIMAL(20, 9)), 6)
                                from   asp,
                                       cur,
                                       ap3
                                where  asp_id = ap3_part
                                       and ap3_currency = cur_code
                                       and ( Round(ap3_purprice, 6) <> Round(asp_purprice, 6)
                                              or Round(ap3_tbprice, 6) <> Round(Cast(asp_purprice * cur_convert as DECIMAL(20, 9)), 6) ) ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pri
                                set    pri_tbprice = ap3_tbprice
                                from   ap3
                                where  pri_part = ap3_part
                                       and Round(pri_tbprice, 6) <> Round(ap3_tbprice, 6)
                                       and pri_part <> '地稅(地方稅)' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pri
                                set    pri_cost = Round(Cast(pri_pricost * {rmb} * 0.03 * pri_perqty as DECIMAL(20, 9)), 6),
                                       pri_tbprice = Round(Cast(pri_pricost * {rmb} * 0.03 as DECIMAL(20, 9)), 6)
                                where  pri_part = '地稅(地方稅)'
                                       and pri_newcostchk = 'N '
                                       and ( pri_cost <> Round(Cast(pri_pricost * {rmb} * 0.03 * pri_perqty as  DECIMAL(20, 9)), 6)
                                              or pri_tbprice <> Round(Cast(pri_pricost * {rmb} * 0.03 as DECIMAL(20, 9)), 6) )";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pri
                                set    pri_assy = ''
                                where  pri_assy is null
                                       and pri_newcostchk = 'N ' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pri
                                set    pri_customer = ''
                                where  pri_customer is null
                                       and pri_newcostchk = 'N ' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pri
                                set    pri_date = ''
                                where  pri_date is null
                                       and pri_newcostchk = 'N ' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pri
                                set    pri_length = ''
                                where  pri_length is null
                                       and pri_newcostchk = 'N ' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pri
                                set    pri_cost = 0
                                where  pri_cost is null
                                       and left(pri_part, 3) <> '不良率'
                                       and left(pri_part, 2) <> '佣金'
                                       and left(pri_firstname, 1) <> '其'
                                       and pri_newcostchk = 'N ' ";
                    clsDB.Execute(strSQL);

                    ///改成小數點6位
                    strSQL = $@"update pri
                                set    pri_cost = Isnull(Round(Cast(pri_tbprice * pri_perqty as DECIMAL(20, 9)), 6), 0)
                                where  left(pri_part, 3) <> '不良率'
                                       and left(pri_part, 2) <> '佣金'
                                       and right(pri_part, 1) <> '才'
                                       and left(pri_firstname, 1) <> '其'
                                       and pri_cost <> Round(Cast(pri_tbprice * pri_perqty as DECIMAL(20, 9)), 6) ";
                    clsDB.Execute(strSQL);

                    ///
                    strSQL = $@"update pri
                                set    pri_cost = c.nqt
                                from   (select a.nbr
                                               as ab,
                                               b.qty
                                               as qt,
                                               Isnull(Round(Cast(a.tb * a.tp * b.qty as DECIMAL(20, 9)), 6), 0)
                                               as nqt
                                        from   (select pri_nbr     as nbr,
                                                       pri_assy,
                                                       pri_date,
                                                       pri_customer,
                                                       pri_length,
                                                       pri_customerid,
                                                       pri_tbprice as tb,
                                                       pri_perqty  as tp
                                                from   pri
                                                where  left(pri_part, 3) = '不良率') as a
                                               left join (select pri_assy,
                                                                 pri_date,
                                                                 pri_customer,
                                                                 pri_length,
                                                                 pri_customerid,
                                                                 Sum(pri_cost) as qty
                                                          from   pri
                                                          where  left(pri_part, 1) not in ( '包', '裝', '運', '不', '調' )
                                                                 and right(pri_part, 1) <> '才'
                                                          group  by pri_assy,
                                                                    pri_date,
                                                                    pri_customer,
                                                                    pri_length,
                                                                    pri_customerid) as b
                                                      on a.pri_assy = b.pri_assy
                                                         and a.pri_customerid = b.pri_customerid) as c,
                                       pri
                                where  pri_nbr = c.ab
                                       and pri_newcostchk = 'N '
                                       and Round(Cast(pri_cost as DECIMAL(20, 9)), 6) <> c.nqt ";
                    clsDB.Execute(strSQL);

                    ///加入紙箱計算為單價/數量
                    strSQL = $@"update pri
                                set    pri_cost = Isnull(Round(Cast(pri_tbprice / pri_perqty as DECIMAL(20, 9)), 6), 0)
                                where  right(pri_part, 1) = '才'
                                       and pri_cost <> Round(Cast(pri_tbprice / pri_perqty as DECIMAL(20, 9)), 6 ) ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pri
                                set    pri_clcost = Round(c.ccost, 6)
                                from   (select a.pri_nbr as nbr,
                                               ( case
                                                   when a.pri_um = 'Feet'
                                                        and a.pri_newcostchk = 'Y2' then ( b.cost / 3.28084 )
                                                   else b.cost
                                                 end )   as ccost
                                        from   pri as a
                                               left outer join (select pri_assy                 as assy,
                                                                       pri_customerid           as customerid,
                                                                       Isnull(Sum(pri_cost), 0) as cost
                                                                from   pri nolock
                                                                where  pri_newcostchk = 'N '
                                                                group  by pri_assy,
                                                                          pri_customerid) as b
                                                            on a.pri_assy = b.assy
                                                               and a.pri_customerid = b.customerid
                                                               and pri_newcostchk = 'N ') as c,
                                       pri
                                where  c.nbr = pri_nbr
                                       and pri_clcost <> Round(c.ccost, 6)
                                       and pri_newcostchk = 'N '";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pri
                                set    pri_convcost = Round(Cast(pri_clcost / cur_convert as DECIMAL(20, 9)), 3)
                                from   pri,
                                       cur nolock
                                where  pri_currency = cur_code
                                       and pri_newcostchk = 'N '
                                       and pri_convcost <> Round(Cast(pri_clcost / cur_convert as DECIMAL(20, 9)), 3) ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pri
                                set    pri_ll = Round(Cast(( pri_pricost - pri_convcost ) * 100 / pri_convcost as DECIMAL(20, 9)), 1),
                                       pri_customerll = Round(( pri_hopelprice - pri_convcost ) * 100 / pri_convcost, 1)
                                where  pri_convcost <> 0
                                       and pri_newcostchk = 'N '
                                       and ( pri_ll <> Round(( pri_pricost - pri_convcost ) * 100 / pri_convcost, 1)
                                              or pri_customerll <> Round(Cast(( pri_hopelprice - pri_convcost ) * 100 / pri_convcost as DECIMAL(20, 9)), 1)) ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pri
                                set    pri_cost = Round(Cast(pri_pricost * cur_convert * pri_tbprice as DECIMAL(20, 9)), 6)
                                from   pri,
                                       cur nolock
                                where  pri_currency = cur_code
                                       and left(pri_part, 2) = '佣金'
                                       and pri_currency <> 'US$'
                                       and pri_currency <> 'EUR'
                                       and pri_newcostchk = 'N '
                                       and pri_cost <> Round(Cast(pri_pricost * cur_convert * pri_tbprice as DECIMAL(20, 9)), 6) ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pri
                                set    pri_cost = Round(Cast(pri_pricost * cur_convert * pri_tbprice as DECIMAL(20, 9)), 6)
                                from   pri,
                                       cur nolock
                                where  left(pri_part, 2) = '佣金'
                                       and pri_currency = 'US$'
                                       and cur_code = '美金賣'
                                       and pri_newcostchk = 'N '
                                       and pri_cost <> Round(Cast(pri_pricost * cur_convert * pri_tbprice as DECIMAL(20, 9)), 6) ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pri
                                set    pri_cost = Round(Cast(pri_pricost * cur_convert * pri_tbprice as DECIMAL(20, 9)), 6)
                                from   pri,
                                       cur nolock
                                where  left(pri_part, 2) = '佣金'
                                       and pri_currency = 'EUR'
                                       and cur_code = '歐元賣'
                                       and pri_newcostchk = 'N '
                                       and pri_cost <> Round(Cast(pri_pricost * cur_convert * pri_tbprice as DECIMAL(20, 9)), 6) ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update odi
                                set    odi_price = pri_convcost
                                from   odi,
                                       pri_aspupdate1
                                where  odi_customerid = pri_customerid
                                       and pri_customer = '4'
                                       and odi_price <> pri_convcost ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update odi
                                set    odi_price = pri_convcost
                                from   odi,
                                       pri_aspupdate1
                                where  odi_customerid = pri_customerid
                                       and Substring(pri_customer, 1, 2) = '4-'
                                       and odi_price <> pri_convcost  ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update odi
                                set    odi_price = pri_pricost
                                from   odi,
                                       pri_aspupdate1
                                where  odi_customerid = pri_customerid
                                       and odi_customer <> '4'
                                       and Substring(odi_customer, 1, 2) <> '4-'
                                       and odi_price <> pri_pricost ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pld
                                set    pld_pricost = pri_pricost,
                                       pld_ll = pri_ll,
                                       pld_hopecost = pri_hopelprice,
                                       pld_hopell = pri_customerll,
                                       pld_date = convert(VARCHAR(2), Datepart(mm, Getdate()))
                                                  + '/'
                                                  + convert(VARCHAR(2), Datepart(dd, Getdate()))
                                                  + '/'
                                                  + convert(VARCHAR(4), Datepart(yyyy, Getdate()))
                                from   pld,
                                       pri
                                where  pld_customerid = pri_customerid
                                       and pld_name = '一般價'
                                       and pld_pricost <> pri_pricost ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pld
                                set    pld_ll = Round(Cast(( pld_pricost - pri_convcost ) * 100 / pri_convcost as DECIMAL(20, 9)), 1),
                                       pld_hopell = Round(Cast(( pld_hopecost - pri_convcost ) * 100 / pri_convcost as DECIMAL(20, 9)), 1)
                                from   pld,
                                       pri nolock
                                where  pld_customerid = pri_customerid
                                       and pld_name <> '一般價'
                                       and pld_pricost <> pri_pricost ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update pub
                                set    pub_asplocked = 0,
                                       pub_aimlocked = 0 ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update asp
                                set    asp_import = 0
                                where  asp_import = 1 ";
                    clsDB.Execute(strSQL);



                }
                strSQL = $@"update asp
                            set    asp_import = 0
                            where  asp_import = 1 ";
                clsDB.Execute(strSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnForceUpdate_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Material_Q_Click(object sender, EventArgs e)
        {

        }

        private void btnInq_PositionInBOM_Click(object sender, EventArgs e) //查詢材料在BOM的位置
        {
            //查詢材料在BOM的位置
            try
            {
                if (txtID.Text=="")
                {
                    MessageBox.Show("請輸入材料名!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    strSQL = $@"select ap1_assy,
                                       ap2_assy,
                                       ap3_assy
                                from   ap3
                                       left join ap2
                                              on ap2_part = ap3_assy
                                       left join ap1
                                              on ap1_part = ap2_assy
                                where  ap3_part = '{txtID.Text}'";
                    dt=clsDB.sql_select_dt(strSQL);
                    if(dt.Rows.Count>0)
                    {
                        string strTmp= "第一層: " + dt.Rows[0]["ap1_assy"] + "\n" + "第二層: " + dt.Rows[0]["ap2_assy"] + "\n" + "第三層: " + dt.Rows[0]["ap3_assy"] + "\n" ;
                        MessageBox.Show(strTmp, "材料在BOM表的位置", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("材料未登錄在BOM表中!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_PositionInBOM_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)    //刪除
        {
            //刪除
            try
            {
                if (txtID.Text == "")
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                
                if (clsGlobal.checkRightFlag("火車頭資料刪除權限") == false)
                {
                    MessageBox.Show("你沒有火車頭資料刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
               
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select pri_part from pri where pri_part='{txtID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count>0)
                {
                    MessageBox.Show("你不能刪除該產品,因為它已經有報價記錄!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }

                strSQL = $@"select * from bom where bom_part='{txtID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("你不能刪除該產品,因為它在採購BOM中有用到!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }

                if (MessageBox.Show(this, "你確定要刪除該產品嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    strSQL = $@"delete asp where asp_id = '{txtID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete aspnum where aspnum_id = '{txtID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete asb where asb_id = '{txtID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete pri where pri_customerid = '{txtID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);

                    MessageBox.Show("已經刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();

                }
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_HistoryPrice_Click(object sender, EventArgs e)  //查價史
        {
            //查價史
            try
            {
                if(txtID.Text == "")
                {
                    return;
                }
                frmProduct_History frmProduct_History = new frmProduct_History();
                frmProduct_History.ShowInTaskbar = false;//圖示不顯示在工作列
                frmProduct_History.strID = txtID.Text;
                frmProduct_History.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_HistoryPrice_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Q_Click(object sender, EventArgs e)  //全部刪除
        {
            //全部刪除
            try
            {
                if(dgvData.Rows.Count==0)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                if (clsGlobal.checkRightFlag("火車頭全部刪除權限") == false)
                {
                    MessageBox.Show("你沒有火車頭全部刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                if (MessageBox.Show(this, "你確定要刪除該產品嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    for (int i=0; i<dgvData.Rows.Count; i++)
                    {
                        strSQL = $@"delete ap3 where ap3_part = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete aspnum where aspnum_id = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete asp where asp_id = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete asb where asb_id not in (select asp_id from asp)' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete pri where pri_customerid = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}' ";
                        clsDB.Execute(strSQL);
                    }
                    MessageBox.Show("已經刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();
                    getData();
                }
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnDelete_Q_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBOM_Inq_Click(object sender, EventArgs e)   //查詢BOM產品結構資料
        {
            //查詢BOM產品結構資料
            try
            {
                strProductID = "";
                frmBOM frmBOM = new frmBOM();
                frmBOM.ShowInTaskbar = false;//圖示不顯示在工作列
                frmBOM.ShowInTaskbar = false;
                frmBOM.blnInquery = true;
                frmBOM.ShowDialog();
                if (strProductID!="")
                {
                    txtID.Text = strProductID;
                    getID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnBOM_Inq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangNo_Click(object sender, EventArgs e)   //更換品號
        {
            //更換品號
            try
            {
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                if (clsGlobal.checkRightFlag("火車頭更換品號權限") == false)
                {
                    MessageBox.Show("你沒有火車頭更換品號權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select aspnum_id from aspnum where aspnum_id='{txtID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 1)
                {
                    if (MessageBox.Show(this, "內層有多品號,若新品號前六碼不同請先[更換品號前六碼]!" + "\n" + "您要繼續嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        return;
                    }
                }
                if(txtNo.Text!="" && txtNo.Text.Length>=6)
                {
                    rstrNo = "";
                    rstrVendorID = "";
                    frmProduct_InputBox frmProduct_InputBox = new frmProduct_InputBox();
                    frmProduct_InputBox.ShowInTaskbar = false;//圖示不顯示在工作列
                    frmProduct_InputBox.txtName.Text = txtNo.Text;
                    frmProduct_InputBox.ShowDialog();
                   
                    if (rstrResult=="OK")
                    {
                        if (rstrNo != "" && rstrVendorID !="")
                        {
                            //string strNo = input.GetMsg().Trim().ToUpper();
                            if (rstrNo != txtNo.Text)
                            {
                                //檢查是否有多品號,若有再檢查前六碼是否一致.
                                strSQL = $@"select aspnum_id,
                                                    aspnum_num
                                            from   aspnum
                                            where  aspnum_id = '{txtID.Text.Trim()}'
                                                    and aspnum_num<> '{txtNo.Text}' ";
                                dt = clsDB.sql_select_dt(strSQL);
                                if (dt.Rows.Count > 0)
                                {
                                    if(dt.Rows[0]["aspnum_num"].ToString().Substring(0,6)!= rstrNo.Substring(0,6))
                                    {
                                        MessageBox.Show("新品號前6碼不一致,請檢查!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Cursor = Cursors.Default;//滑鼠還原預設
                                        return;
                                    }
                                }

                                strSQL = $@"select asp_id
                                            from   asp
                                            where  asp_vendormaterialno = '{rstrNo}' ";
                                dt = clsDB.sql_select_dt(strSQL);
                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("新品號與下列材料相同!請重新執行!!" + "\n" + dt.Rows[0]["asp_id"].ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Cursor = Cursors.Default;//滑鼠還原預設
                                    return;
                                }

                                strSQL = $@"update ap3
                                            set    ap3_vendorid = '{rstrVendorID}'
                                            where  ap3_part = '{txtID.Text.Trim()}' ";
                                clsDB.Execute(strSQL);

                                strSQL = $@"update avt
                                            set    avt_vendormaterialno = '{rstrNo}',
                                                   avt_vendorid = '{rstrVendorID}'
                                            where  avt_id = '{txtID.Text.Trim()}'
                                                   and avt_vendormaterialno = '{txtNo.Text.Trim()}' ";
                                clsDB.Execute(strSQL);

                                strSQL = $@"update asp
                                            set    asp_vendormaterialno = '{rstrNo}',
                                                   asp_vendorid = '{rstrVendorID}',
                                                   asp_user = Isnull((select wus_name
                                                                       from wus
                                                                       where wus_computername = Host_name()),
                                                               '{clsGlobal.strG_User}'),
                                                   asp_adddate = Getdate()
                                            where  asp_id = '{txtID.Text.Trim()}' ";
                                clsDB.Execute(strSQL);

                                strSQL = $@"update aspnum
                                            set    aspnum_num = '{rstrNo}', 
                                                   asp_vendorid = '{rstrVendorID}'
                                            where aspnum_id = '{txtID.Text.Trim()}'
                                                    and aspnum_num = '{txtNo.Text.Trim()}' ";
                                clsDB.Execute(strSQL);

                                strSQL = $@"update asm
                                            set    asm_vendormaterialno = '{rstrNo}',
                                                   asm_vendorid = '{rstrVendorID}'
                                            where  asm_id = '{txtID.Text.Trim()}'
                                                   and asm_vendormaterialno = '{txtNo.Text.Trim()}' ";
                                clsDB.Execute(strSQL);

                                strSQL = $@"update pri
                                            set    pri_assy = '{rstrNo}'
                                            where pri_customerid = '{txtID.Text.Trim()}'
                                                    and pri_newcostchk like'Y%'
                                                    and pri_assy = '{txtNo.Text}' ";
                                clsDB.Execute(strSQL);
                                rstrNo = "";
                                MessageBox.Show("新品號更換完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                getID();
                                this.Cursor = Cursors.Default;//滑鼠還原預設
                            }
                        }
                    }
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
                else
                {
                    if(txtNo.Text=="")
                    {
                        MessageBox.Show("品號欄位空白,請先建立品號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("品號長度錯誤,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnChangNo_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangeNo_6_Click(object sender, EventArgs e)    //更換品號前6碼
        {
            //更換品號前6碼
            try
            {
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                if (clsGlobal.checkRightFlag("火車頭更換品號前六碼權限") == false)
                {
                    MessageBox.Show("你沒有火車頭更換品號前六碼權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                if (txtNo.Text != "" && txtNo.Text.Length >= 6)
                {
                    InputBox input = new InputBox();
                    input.ShowInTaskbar = false;//圖示不顯示在工作列
                    input.lblInfo.Text = "請輸入新的品號前6碼:";
                    input.Text = "更換品號前6碼";
                    input.txtIpnut.Text = txtNo.Text.Substring(0, 6);
                    DialogResult dr = input.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        if (input.GetMsg() != "" && input.GetMsg().Length==6)
                        {
                            string strNo = input.GetMsg().Trim().ToUpper();
                            if (strNo!=txtNo.Text.ToUpper().Substring(0, 6))
                            {
                                string strSQL = "";
                                DataTable dt = new DataTable();
                                strSQL = $@"select asp_id
                                            from   asp
                                            where  left(asp_vendormaterialno, 6) = '{strNo}'
                                                   and asp_id<> '{txtID.Text.Trim()}' ";
                                dt = clsDB.sql_select_dt(strSQL);
                                if (dt.Rows.Count > 0)
                                {
                                    if (MessageBox.Show(this, "新品號前6碼與下列材料相同!您要繼續嗎?" + "\n" + dt.Rows[0]["asp_id"].ToString(), "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    {
                                        this.Cursor = Cursors.Default;//滑鼠還原預設
                                        return;
                                    }
                                }

                                strSQL = $@"select asp_id
                                            from   asp
                                            where  asp_vendormaterialno = '{strNo}{txtNo.Text.Substring(6, txtNo.Text.Length-6)}' ";
                                dt = clsDB.sql_select_dt(strSQL);
                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("新品號與下列材料品號相同!請重新檢查!" + "\n" + dt.Rows[0]["asp_id"].ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Cursor = Cursors.Default;//滑鼠還原預設
                                    return;
                                }

                                strSQL = $@"update asp
                                                set    asp_vendormaterialno = '{strNo}' + right(asp_vendormaterialno,len(asp_vendormaterialno)-6),
                                                       asp_user = Isnull((select wus_name
                                                                          from wus
                                                                          where wus_computername = Host_name()),
                                                                  '{clsGlobal.strG_User}'),
                                                       asp_adddate = Getdate()
                                                where asp_id = '{txtID.Text.Trim()}' ";
                                clsDB.Execute(strSQL);
                                strSQL = $@"update aspnum
                                                set    aspnum_num = '{strNo}' + right(aspnum_num,len(aspnum_num)-6)
                                                where aspnum_id = '{txtID.Text.Trim()}' ";
                                clsDB.Execute(strSQL);
                                strSQL = $@"update pri
                                                set    pri_assy = '{strNo}' + right(pri_assy,len(pri_assy)-6) 
                                                where pri_customerid = '{txtID.Text.Trim()}'
                                                       and pri_newcostchk like'Y%' ";

                                clsDB.Execute(strSQL);

                                MessageBox.Show("品號更換完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                getID();
                                this.Cursor = Cursors.Default;//滑鼠還原預設
                            }
                        }
                    }
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
                else
                {
                    if (txtNo.Text == "")
                    {
                        MessageBox.Show("品號欄位空白,請先建立品號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("品號長度錯誤,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnChangeNo_6_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)  //複製
        {
            //複製
            try
            {
                if (clsGlobal.checkRightFlag("火車頭複製權限") == false)
                {
                    MessageBox.Show("你沒有火車頭複製權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string strOldID = "";
                strOldID = txtID.Text;
                InputBox input = new InputBox();
                input.ShowInTaskbar = false;//圖示不顯示在工作列
                input.lblInfo.Text = "原材料名:"+txtID.Text;
                input.Text = "複製";
                input.txtIpnut.Text = txtID.Text;
                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (input.GetMsg() != "")
                    {
                        string strNewID = input.GetMsg().Trim();
                        string strSQL = "";
                        DataTable dt = new DataTable();

                        //檢查問題字符
                        strSQL = $@"select Isnull(Charindex('[', '{strNewID}'), 0) as c1,
                                           Isnull(Charindex(']', '{strNewID}'), 0) as c2,
                                           Isnull(Charindex('&', '{strNewID}'), 0) as c3 ";
                        dt=clsDB.sql_select_dt(strSQL);
                        if(dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["c1"].ToString()=="0" && dt.Rows[0]["c2"].ToString() == "0" && dt.Rows[0]["c3"].ToString() == "0")
                            {

                            }
                            else
                            {
                                MessageBox.Show("你輸入的產品編號包括了一些不能用的字符[]&,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        //檢查重複材料名
                        strSQL = $@"select * from asp where asp_id='{strNewID}'";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("名稱重覆,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        //都沒問題就開始複製到asp
                        //依李先生要求,複製時品號空白.所以先清空品號,並在材料價史記錄此新材料是由複製產生的.
                        btnInq_No.BackColor = Color.FromArgb(0, 255, 0);    //檢查品號變回綠色
                        txtID.Text = strNewID;
                        txtNo.Text = "";    //品號清空
                        strName = "";   //材料單設定清空
                        chkCheck.Checked = false;   //審核清空
                        chkSafety.Checked = false;  //安規清空
                        //txtCzf.Text = "";   //參照法清空
                        //txtMultinum.Text = "";   //同品號清空
                        
                        DoCopy_asp_save();  //複製到asp

                        strSQL = $@"update asb
                                    set    asb_memo = N'[複製材料]由此材料複製=>{strOldID}'
                                    where  asb_id = N'{txtID.Text}'
                                           and asb_changedate = '{DateTime.Now.ToString("yyyy/MM/dd")}'";
                        clsDB.Execute(strSQL);
                        MessageBox.Show("已經複製完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCopy_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRename_Click(object sender, EventArgs e)    //更名
        {
            //更名
            try
            {
                if(txtID.Text=="")
                {
                    return;
                }
                if (clsGlobal.checkRightFlag("火車頭更名權限") == false)
                {
                    MessageBox.Show("你沒有火車頭更名權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select pub_bomuse from pub";
                string rs = clsDB.sql_select_String(strSQL, "pub_bomuse");
                if(rs!="")
                {
                    MessageBox.Show(rs + "使用者正在BOM產品結構作業,暫停更名.請稍候再試!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                strSQL = $@"select * from asp where asp_id = '{txtID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("請先輸入已存在材料名!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Focus();
                    return;
                }

                InputBox input = new InputBox();
                input.ShowInTaskbar = false;//圖示不顯示在工作列
                input.lblInfo.Text = "原材料名:" + txtID.Text;
                input.Text = "材料名更名";
                input.txtIpnut.Text = txtID.Text;
                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (input.GetMsg() != "")
                    {
                        string strOldID= txtID.Text.Trim();
                        string strNewID = input.GetMsg().Trim();
                        //檢查字數
                        if (getStrLength(strNewID) > 30)
                        {
                            MessageBox.Show("材料名長度" + getStrLength(txtID.Text).ToString() + ",不可以超過30個英文字元!請重新輸.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //檢查特殊字元
                        if (strNewID.IndexOf("'") >= 0)
                        {
                            MessageBox.Show("不可輸入特殊字元< ' >", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //檢查問題字符
                        strSQL = $@"select Isnull(Charindex('[', '{strNewID}'), 0) as c1,
                                           Isnull(Charindex(']', '{strNewID}'), 0) as c2,
                                           Isnull(Charindex('&', '{strNewID}'), 0) as c3 ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["c1"].ToString() == "0" && dt.Rows[0]["c2"].ToString() == "0" && dt.Rows[0]["c3"].ToString() == "0")
                            {

                            }
                            else
                            {
                                MessageBox.Show("你輸入的產品編號包括了一些不能用的字符[]&,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        //檢查重複材料名
                        strSQL = $@"select * from asp where asp_id='{strNewID}'";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("名稱重覆,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        //都沒問題就開始更名
                        strSQL = $@"update asp
                                    set    asp_id = N'{strNewID}',
                                           asp_user = '{clsGlobal.strG_User}',
                                           asp_adddate = Getdate()
                                    where  asp_id = N'{strOldID}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"update ap3
                                    set    ap3_part = N'{strNewID}'
                                    where  ap3_part = N'{strOldID}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"update pri
                                    set    pri_part = N'{strNewID}'
                                    where  pri_part = N'{strOldID}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"update pri
                                    set    pri_customerid = N'{strNewID}'
                                    where  pri_customerid = N'{strOldID}'
                                           and pri_newcostchk like 'Y%' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"exec cal_parttotalbyname N'{strNewID}'";//組合pri_parttotal
                        clsDB.Execute(strSQL);
                        strSQL = $@"update avt
                                    set    avt_id = N'{strNewID}'
                                    where  avt_id = N'{strOldID}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"update asb
                                    set    asb_id = N'{strNewID}'
                                    where  asb_id = N'{strOldID}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"update aspnum
                                    set    aspnum_id = N'{strNewID}'
                                    where  aspnum_id = N'{strOldID}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"update pub
                                    set    pub_vnfreight = N'{strNewID}'
                                    where  pub_vnfreight = N'{strOldID}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"insert asb
                                           (asb_id,
                                            asb_changedate,
                                            asb_price,
                                            asb_vendorid,
                                            asb_user,
                                            asb_currency,
                                            asb_memo,
                                            asb_pricecal)
                                    values (N'{strNewID}',
                                            Getdate(),
                                            '{txtPurprice.Text}',
                                            '{txtVendorID.Text}',
                                            '{clsGlobal.strG_User}',
                                            '{cboCurrency.Text}',
                                            N'[更名] 原材料名->{strOldID}',
                                            '{strPricecal}') ";
                        clsDB.Execute(strSQL);

                        //連參照法內的包裝運材料名也要檢查
                        if(txtID.Text.Substring(0,2)== "包/")
                        {
                            strSQL = $@"update odi
                                        set    odi_pripart02 = '{strNewID}'
                                        where  odi_pripart02 = '{strOldID}' ";
                            clsDB.Execute(strSQL);
                        }
                        if (txtID.Text.Substring(0, 2) == "裝/")
                        {
                            strSQL = $@"update odi
                                        set    odi_pripart01 = '{strNewID}'
                                        where  odi_pripart01 = '{strOldID}' ";
                            clsDB.Execute(strSQL);
                        }
                        if (txtID.Text.Substring(0, 2) == "運/")
                        {
                            strSQL = $@"update odi
                                        set    odi_pripart05 = '{strNewID}'
                                        where  odi_pripart05 = '{strOldID}' ";
                            clsDB.Execute(strSQL);
                        }
                        if (txtID.Text.Substring(0, 2) == "不良")
                        {
                            strSQL = $@"update odi
                                        set    odi_pripart04 = '{strNewID}'
                                        where  odi_pripart04 = '{strOldID}' ";
                            clsDB.Execute(strSQL);
                        }
                        txtID.Text = strNewID;
                        MessageBox.Show("已經更名替換完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnRename_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_No_Click(object sender, EventArgs e)
        {
            //查詢品號
            try
            {
                if(txtID.Text=="")
                {
                    return;
                }
                if (txtNo.Text == "")
                {
                    MessageBox.Show("品號欄位空白,請先輸入品號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String strSQL = "";
                DataTable dt = new DataTable();
                //檢查有無aspnum,無則新建aspnum
                strSQL = $@"select * from aspnum where aspnum_id = '{txtID.Text.Trim()}'";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count==0)
                {
                    strSQL = $@"insert into aspnum
                                            (aspnum_id,
                                             aspnum_num,
                                             aspnum_modifydate,
                                             aspnum_price,
                                             aspnum_currency,
                                             aspnum_memo,
                                             aspnum_pricecal,
                                             aspnum_vendorid,
                                             aspnum_spec,
                                             aspnum_um)
                                values      ('{txtID.Text.Trim()}',
                                             '{txtNo.Text.Trim()}',
                                             '{DateTime.Now.ToString("yyyy/MM/dd")}',
                                             '{txtPurprice.Text.Trim()}',
                                             '{cboCurrency.Text.Trim()}',
                                             '{txtCzf.Text.Trim()}',
                                             '{strPricecal}',
                                             '{txtVendorID.Text.Trim()}',
                                             '{txtSpec.Text.Trim()}',
                                             '{cboUnit.Text.Trim()}') ";
                    clsDB.Execute(strSQL);
                }
                rstrNo = "";
                frmProduct_Inq_No frmProduct_Inq_No = new frmProduct_Inq_No();
                frmProduct_Inq_No.ShowInTaskbar = false;//圖示不顯示在工作列
                frmProduct_Inq_No.rstrID = txtID.Text.Trim();
                frmProduct_Inq_No.ShowDialog();
                //檢查多品號,若是多品號查詢按鈕顯示紅色.
                checkMultinum(txtID.Text);
                if(rstrNo!="")
                {
                    //品號改變;更新相關資訊
                    
                    strSQL = $@"select aspnum_id                                          as 材料名,
                               aspnum_num                                                 as 品號,
                               convert (VARCHAR(10), aspnum_modifydate, 120)              as 最後變動日期,
                               Cast(convert(DECIMAL(18, 6), aspnum_price) as VARCHAR(18)) as 最新價格,
                               aspnum_vendorid                                            as 廠商,
                               aspnum_currency                                            as 幣種,
                               aspnum_um                                                  as 單位,
                               aspnum_memo                                                as 參照法,
                               aspnum_spec                                                as 規格,
                               aspnum_pricecal                                            as 計算式
                        from   aspnum
                        where  aspnum_id = '{txtID.Text}' and aspnum_num='{rstrNo}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        txtNo.Text = dt.Rows[0]["品號"].ToString();
                        txtPurprice.Text = dt.Rows[0]["最新價格"].ToString();
                        oldprice = txtPurprice.Text;
                        txtVendorID.Text = dt.Rows[0]["廠商"].ToString();
                        cboCurrency.Text = dt.Rows[0]["幣種"].ToString();
                        cboUnit.Text = dt.Rows[0]["單位"].ToString();
                        txtCzf.Text = dt.Rows[0]["參照法"].ToString();
                        txtSpec.Text = dt.Rows[0]["規格"].ToString();
                        strPricecal = dt.Rows[0]["計算式"].ToString();
                    }
                }
                else
                {
                    //品號不變更;重新更新相關資訊
                    strSQL = $@"select aspnum_id                                          as 材料名,
                               aspnum_num                                                 as 品號,
                               convert (VARCHAR(10), aspnum_modifydate, 120)              as 最後變動日期,
                               Cast(convert(DECIMAL(18, 6), aspnum_price) as VARCHAR(18)) as 最新價格,
                               aspnum_vendorid                                            as 廠商,
                               aspnum_currency                                            as 幣種,
                               aspnum_um                                                  as 單位,
                               aspnum_memo                                                as 參照法,
                               aspnum_spec                                                as 規格,
                               aspnum_pricecal                                            as 計算式
                        from   aspnum
                        where  aspnum_id = '{txtID.Text}' and aspnum_num='{txtNo.Text}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        txtNo.Text = dt.Rows[0]["品號"].ToString();
                        txtPurprice.Text = dt.Rows[0]["最新價格"].ToString();
                        oldprice = txtPurprice.Text;
                        txtVendorID.Text = dt.Rows[0]["廠商"].ToString();
                        cboCurrency.Text = dt.Rows[0]["幣種"].ToString();
                        cboUnit.Text = dt.Rows[0]["單位"].ToString();
                        txtCzf.Text = dt.Rows[0]["參照法"].ToString();
                        txtSpec.Text = dt.Rows[0]["規格"].ToString();
                        strPricecal = dt.Rows[0]["計算式"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnBOM_Inq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean checkBom(string strNo)
        {
            //檢查材料單
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select distinct pri_customerid from pri where pri_assy ='{strNo}' and pri_newcostchk like 'Y%'";
            dt = clsDB.sql_select_dt(strSQL);
            if(dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DoCopy_asp_save()
        {
            //複製到asp 
            try
            {
                /// 材料名資料儲存
                if (txtPurprice.Text == "")
                {
                    txtPurprice.Text = "0";
                }

                if (strStandprice == "")
                {
                    strStandprice = "0";
                }
                if (strSafeqty == "")
                {
                    strSafeqty = "0";
                }
                if (strWeight == "")
                {
                    strWeight = "0";
                }
                if (strPurleadtime == "")
                {
                    strPurleadtime = "0";
                }
                if (strMakeleadtime == "")
                {
                    strMakeleadtime = "0";
                }
                if (strPurchprice == "")
                {
                    strPurchprice = "0";
                }
                if (strSalesprice == "")
                {
                    strSalesprice = "0";
                }
                if (strTjjz == "")
                {
                    strTjjz = "0";
                }
                asp_multinum = txtMultinum.Text;
                if (strPricecal == "")
                {
                    strPricecal = "0";
                }
                if (txtWeight.Text == "")
                {
                    txtWeight.Text = "0";
                }
                asp_vnweight = Convert.ToDouble(txtWeight.Text);
                if (txtQuantity.Text == "")
                {
                    txtQuantity.Text = "0";
                }
                asp_vnpcs = Convert.ToDouble(txtQuantity.Text);

                asp_id = txtID.Text;
                asp_type = strType;
                asp_name = strName;
                asp_um = cboUnit.Text;
                asp_purprice = Convert.ToDouble(txtPurprice.Text);
                asp_standprice = Convert.ToDouble(strStandprice);
                asp_vendorid = txtVendorID.Text;
                asp_currency = cboCurrency.Text;
                asp_czf = txtCzf.Text;
                asp_tjjz = Convert.ToDouble(strTjjz);
                asp_area = strArea;
                asp_safeqty = Convert.ToDouble(strSafeqty);
                asp_weight = Convert.ToDouble(strWeight);
                asp_purleadtime = Convert.ToDouble(strPurleadtime);
                asp_makeleadtime = Convert.ToDouble(strMakeleadtime);
                asp_salesprice = Convert.ToDouble(strSalesprice);
                asp_purchprice = Convert.ToDouble(strPurchprice);
                if (chkControlMeterial.Checked == true)
                {
                    asp_dummyflag = 1;
                }
                else
                {
                    asp_dummyflag = 0;
                }
                asp_pricecal = strPricecal;
                asp_vendormaterialno = txtNo.Text;
                asp_spec = txtSpec.Text;
                asp_location = strLocation;
                

                DoUpdate_asp();                     //更新asp資料
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-DoCopy_asp_save" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPurprice_Enter(object sender, EventArgs e)
        {
            if (strPricecal != "")
            {
                txtPurprice.Text = strPricecal;
            }
        }

        private void txtPurprice_Leave(object sender, EventArgs e)
        {
            strPricecal = txtPurprice.Text;
            //計算式  計算機 引用using System.Data
            txtPurprice.Text = Convert.ToDouble(new DataTable().Compute(txtPurprice.Text, null)).ToString("0.######");
        }

        private void txtNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtSpec.Focus();
            }
        }

        private void txtNo_Leave(object sender, EventArgs e)
        {
            txtNo.Text = txtNo.Text.Replace("\n", "").Replace("\r", "").Trim();  //去ENTER 換行 空白
            if (txtNo.Text!="")
            {
                if (txtID.Text == "")
                {
                    frmProduct_Inq_No2 frmProduct_Inq_No2 = new frmProduct_Inq_No2();
                    frmProduct_Inq_No2.ShowInTaskbar = false;//圖示不顯示在工作列
                    frmProduct_Inq_No2.rstrNo = txtNo.Text.Trim();
                    frmProduct_Inq_No2.ShowDialog();
                    if(rstrID!="")
                    {
                        txtID.Text = rstrID;
                        getID();
                        rstrID = "";
                        txtNo.Focus();
                    }
                    
                }
            }
            
        }

        private void btnInq_Vendor_Click(object sender, EventArgs e)
        {
            //呼叫"廠商查詢",並將結果傳入廠號廠商
            try
            {
                rstrVendorID = "";
                rstrVendorName = "";
                frmVendor_Inq frmVendor_Inq = new frmVendor_Inq();
                frmVendor_Inq.ShowInTaskbar = false;    //圖示不顯示在工作列
                frmVendor_Inq.strWhoCall = "frmProduct";
                frmVendor_Inq.ShowDialog();

                if (rstrVendorID != "")
                {
                    txtVendorID.Text = rstrVendorID;
                    lblVendor.Text = rstrVendorName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Vendor_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtVendorID_Q_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtVendorID_Q.Text != "")
                {
                    this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                    txtVendorID_Q.Text.Replace("\n", "").Replace("\r", "").Trim();  //去ENTER 換行 空白
                    getData();
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
            }
        }

        private void txtVendorID_Q_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                MessageBox.Show("不可輸入特殊字元< ' >!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.KeyChar = (char)0;   //處理非法字符
            }
        }

        private void txtVendorID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtVendorID.Text != "")
                {
                    lblVendor.Text = getVendor(txtVendorID.Text);
                    if (lblVendor.Text != "")
                    {
                        String strSQL = $@"select ven_currency from ven where ven_id='{lblVendor.Text}'";
                        string rs = clsDB.sql_select_String(strSQL, "ven_currency");
                        cboCurrency.Text = rs;
                    }
                }
            }
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
