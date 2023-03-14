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
    public partial class frmUSB2_Input : Form
    {
        String asp_id = "";                     //產品編號(材料名)
        String asp_type = "";                   //產品類型
        String asp_name = "";                   //材料單
        String asp_um = "";                     //單位
        Double asp_purprice = 0;                //單價
        Double asp_standprice = 0;              //
        String asp_vendorid = "";               //廠商
        String asp_currency = "";               //幣種
        String asp_czf = "";                    //參照法
        Double asp_tjjz = 0;                   //
        String asp_area = "";                   //
        Double asp_safeqty = 0;                 //一年內已成交數量
        Double asp_weight = 0;                  //
        Double asp_purleadtime = 0;             //
        Double asp_makeleadtime = 0;            //
        String asp_location = "";               //
        Double asp_purchprice = 0;              //數量計算式
        String asp_purcurrency = "";           //
        int asp_dummyflag = 0;                  //控管材料
        String asp_pricecal = "";               //火車頭單價計算式
        String asp_vendormaterialno = "";       //品號
        String asp_spec = "";                   //規格
        String asp_line = "";                   //越南運費check
        String asp_od = "";                     //審核+越南材料check
        String asp_multinum = "";               //同品號
        Double asp_vnweight = 0;                //越南運費-重量
        Double asp_vnpcs = 0;                   //越南運費-數量
        String asp_lengum = "";                 //安規線材check
        String asp_oddate = "";                 //審核日期
        String asp_oduser = "";                 //審核者
        String oddate = "";                      //審核日期
        String oduser = "";                      //審核者
        public frmUSB2_Input()
        {
            InitializeComponent();
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

        private void btnInq_Click(object sender, EventArgs e)
        {
            //查詢
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                //(Y-1)年
                strSQL = $@"select Sum(ord_qty) ord_qty
                            from   ord,
                                   odh
                            where  odh_newdate >= '{dtpDate.Value.AddYears(-1).ToString("yyyy")}/1/1 00:00:00'
                                   and odh_newdate <= '{dtpDate.Value.AddYears(-1).ToString("yyyy")}/12/31 11:59:59'
                                   and odh_orderid = ord_orderid
                                   and ord_assy in (select pri_customerid
                                                    from   pri
                                                    where
                                       pri_part like '線貼/USB協會貼15*75mm(含年費)') ";

                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    txtYear_1.Text = dt.Rows[0]["ord_qty"].ToString();
                }
                else
                {
                    MessageBox.Show(dtpDate.Value.AddYears(-1).ToString("yyyy") + "年"+ "查不到資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //(Y-2)年
                strSQL = $@"select Sum(ord_qty) ord_qty
                            from   ord,
                                   odh
                            where  odh_newdate >= '{dtpDate.Value.AddYears(-2).ToString("yyyy")}/1/1 00:00:00'
                                   and odh_newdate <= '{dtpDate.Value.AddYears(-2).ToString("yyyy")}/12/31 11:59:59'
                                   and odh_orderid = ord_orderid
                                   and ord_assy in (select pri_customerid
                                                    from   pri
                                                    where
                                       pri_part like '線貼/USB協會貼15*75mm(含年費)') ";

                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    txtYear_2.Text = dt.Rows[0]["ord_qty"].ToString();
                }
                else
                {
                    MessageBox.Show(dtpDate.Value.AddYears(-2).ToString("yyyy") + "年" + "查不到資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //USB協會年費
                strSQL = $@"select usb_fees from usb_fees where adddate = {dtpDate.Value.AddYears(0).ToString("yyyy")} order by create_date desc ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    txtUSB_Fees.Text = dt.Rows[0]["usb_fees"].ToString();
                }
                else
                {
                    strSQL = $@"select usb_fees from usb_fees where adddate <= {dtpDate.Value.AddYears(0).ToString("yyyy")} order by adddate, create_date desc ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        txtUSB_Fees.Text = dt.Rows[0]["usb_fees"].ToString();
                    }
                }

                //年費分攤金額
                txtPrice.Text = (Convert.ToSingle(txtUSB_Fees.Text) / ((Convert.ToSingle(txtYear_1.Text) + Convert.ToSingle(txtYear_2.Text)) / 2)).ToString("0.######");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUSB2_Input_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                dtpDate.Value = DateTime.Now.AddYears(0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmUSB2_Input_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUSB2_Input_Activated(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                btnInq.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmUSB2_Input_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                if (txtUSB_Fees.Text == "")
                {
                    MessageBox.Show("不可為空白, 請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                //先取得asp參數
                GetAsp("年費/USB2.0協會(兩年量分攤)");

                asp_purprice = Convert.ToDouble(txtPrice.Text);      //單價
                asp_pricecal = txtPrice.Text;                        //單價計算式
                DoUpdate_asp1();                     //更新asp資料(沒有做updateBOM)
                this.Cursor = Cursors.Default;//滑鼠還原預設

                string strSQL = $@"insert into usb_fees
                                    values      ({txtUSB_Fees.Text},
                                                 '{clsGlobal.strG_User}',
                                                 {dtpDate.Value.AddYears(0).ToString("yyyy")},
                                                 Getdate()) ";
                clsDB.Execute(strSQL);
                
                MessageBox.Show("儲存完成!系統將回寫材料單價....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetAsp(string strID)     //取得asp參數
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select * from asp where asp_id= '{strID}'";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                asp_id = (string)dt.Rows[0]["asp_id"];
                asp_type = (string)dt.Rows[0]["asp_type"];
                asp_name = (string)dt.Rows[0]["asp_name"];
                asp_um = (string)dt.Rows[0]["asp_um"];
                asp_purprice = (Double)dt.Rows[0]["asp_purprice"];
                asp_standprice = (Double)dt.Rows[0]["asp_standprice"];
                asp_vendorid = (string)dt.Rows[0]["asp_vendorid"];
                asp_currency = (string)dt.Rows[0]["asp_currency"];
                asp_czf = (string)dt.Rows[0]["asp_czf"];
                asp_tjjz = (Double)dt.Rows[0]["asp_tjjz"];
                asp_area = (string)dt.Rows[0]["asp_area"];
                asp_safeqty = (Double)dt.Rows[0]["asp_safeqty"];
                asp_weight = (Double)dt.Rows[0]["asp_weight"];
                asp_purleadtime = (Double)dt.Rows[0]["asp_purleadtime"];
                asp_makeleadtime = (Double)dt.Rows[0]["asp_makeleadtime"];
                asp_location = (string)dt.Rows[0]["asp_location"];
                asp_purchprice = (Double)dt.Rows[0]["asp_purchprice"];
                asp_purcurrency = (string)dt.Rows[0]["asp_purcurrency"];
                asp_dummyflag = (int)dt.Rows[0]["asp_dummyflag"];
                asp_pricecal = (string)dt.Rows[0]["asp_pricecal"];
                asp_vendormaterialno = (string)dt.Rows[0]["asp_vendormaterialno"];
                asp_spec = (string)dt.Rows[0]["asp_spec"];
                asp_line = (string)dt.Rows[0]["asp_line"];
                asp_od = (string)dt.Rows[0]["asp_od"];
                asp_multinum = (string)dt.Rows[0]["asp_multinum"];
                //asp_vnweight = (Double)dt.Rows[0]["asp_vnweight"];
                //asp_vnpcs = (Double)dt.Rows[0]["asp_vnpcs"];
                asp_lengum = (string)dt.Rows[0]["asp_lengum"];
                asp_oddate = ((DateTime)dt.Rows[0]["asp_oddate"]).ToString("yyyy/MM/dd");
                asp_oduser = (string)dt.Rows[0]["asp_oduser"];
            }
        }

        private void DoUpdate_asp1() // 更新asp資料(沒有做updateBOM)
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-DoUpdate_asp" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
