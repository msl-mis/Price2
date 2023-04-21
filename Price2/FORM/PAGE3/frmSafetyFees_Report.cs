using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Price2
{
    public partial class frmSafetyFees_Report : Form
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

        string strPricecal = "";
        public frmSafetyFees_Report()
        {
            InitializeComponent();
        }

        private void frmSafetyFees_Report_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                dtpDate.Value = DateTime.Now.AddYears(-1);
                cboMaterial.Text = "年費/一般安規線材/M";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmSafetyFees_Report_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSafetyFees_Report_Activated(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                btnInq.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmSafetyFees_Report_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (dgvCount.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)dgvCount.DataSource;
                    dt.Rows.Clear();
                    dgvCount.DataSource = dt;
                }
                if (dgvFees.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)dgvFees.DataSource;
                    dt.Rows.Clear();
                    dgvFees.DataSource = dt;
                }
                strPricecal = "";
                txtPurprice.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Click(object sender, EventArgs e)
        {
            //查詢
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                //欄位限制防呆
                if (cboMaterial.Text == "")
                {
                    MessageBox.Show("請選擇材料名!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                switch (cboMaterial.Text)
                {
                    case "年費/一般安規線材/M":
                        strSQL = $@"select {dtpDate.Value.AddYears(0).ToString("yyyy")} as '年份', Isnull( Sum (tab.長度M), 0 ) as '安規數量', Isnull( ( select Round( Sum(t.tbprice), 0 ) from ( select t1.tbprice from safety_fees t1 where Datediff(YEAR, t1.date, '{dtpDate.Value.AddYears(0).ToString("yyyy")}') = 0 and t1.cable = '一般線材' ) t ), 0 ) as '安規費用' 
                                    from ( select bb.客號, Round( Sum(bb.長度M), 0 ) as '長度M' 
                                    from ( select aa.客號, aa.umvalue as 長度M 
                                    from ( select distinct pri_customerid '客號', ord_orderid '訂單號', ord_qty '訂單數量', asp_um as um, case asp_um when 'FT' then Round(pri_perqty * 0.3048 * ord_qty, 1) when 'M' then Round(pri_perqty * ord_qty, 1) when 'CM' then Round(pri_perqty * 0.01 * ord_qty, 1) else 0 end as umvalue, format(odh_newdate, 'yyyy/MM/dd') '訂單日期' 
                                    from pri, ord, odh, asp where asp_id = pri_part and pri_wg <> 2 and asp_lengum = 'Y' and asp_vendorid in ('57', '58', '304', '57A') and pri_newcostchk like 'N%' and ord_assy = pri_customerid and odh_orderid = ord_orderid and Datediff(YEAR, odh_newdate, '{dtpDate.Value.AddYears(0).ToString("yyyy")}') = 0 ) as aa where aa.訂單數量 > 0 ) as bb group by bb.客號 ) tab 
                                    union 
                                    select {dtpDate.Value.AddYears(-1).ToString("yyyy")} as '年份', Isnull( Sum (tab.長度M), 0 ) as '安規數量', Isnull( ( select Round( Sum(t.tbprice), 0 ) from ( select t1.tbprice from safety_fees t1 where Datediff(YEAR, t1.date, '{dtpDate.Value.AddYears(-1).ToString("yyyy")}') = 0 and t1.cable = '一般線材' ) t ), 0 ) as '安規費用' 
                                    from ( select bb.客號, Round( Sum(bb.長度M), 0 ) as '長度M' 
                                    from ( select aa.客號, aa.umvalue as 長度M 
                                    from ( select distinct pri_customerid '客號', ord_orderid '訂單號', ord_qty '訂單數量', asp_um as um, case asp_um when 'FT' then Round(pri_perqty * 0.3048 * ord_qty, 1) when 'M' then Round(pri_perqty * ord_qty, 1) when 'CM' then Round(pri_perqty * 0.01 * ord_qty, 1) else 0 end as umvalue, format(odh_newdate, 'yyyy/MM/dd') '訂單日期' 
                                    from pri, ord, odh, asp where asp_id = pri_part and pri_wg <> 2 and asp_lengum = 'Y' and asp_vendorid in ('57', '58', '304', '57A') and pri_newcostchk like 'N%' and ord_assy = pri_customerid and odh_orderid = ord_orderid and Datediff(YEAR, odh_newdate, '{dtpDate.Value.AddYears(-1).ToString("yyyy")}') = 0 ) as aa where aa.訂單數量 > 0 ) as bb group by bb.客號 ) tab 
                                    union 
                                    select {dtpDate.Value.AddYears(-2).ToString("yyyy")} as '年份', Isnull( Sum (tab.長度M), 0 ) as '安規數量', Isnull( ( select Round( Sum(t.tbprice), 0 ) from ( select t1.tbprice from safety_fees t1 where Datediff(YEAR, t1.date, '{dtpDate.Value.AddYears(-2).ToString("yyyy")}') = 0 and t1.cable = '一般線材' ) t ), 0 ) as '安規費用' 
                                    from ( select bb.客號, Round( Sum(bb.長度M), 0 ) as '長度M' 
                                    from ( select aa.客號, aa.umvalue as 長度M 
                                    from ( select distinct pri_customerid '客號', ord_orderid '訂單號', ord_qty '訂單數量', asp_um as um, case asp_um when 'FT' then Round(pri_perqty * 0.3048 * ord_qty, 1) when 'M' then Round(pri_perqty * ord_qty, 1) when 'CM' then Round(pri_perqty * 0.01 * ord_qty, 1) else 0 end as umvalue, format(odh_newdate, 'yyyy/MM/dd') '訂單日期' 
                                    from pri, ord, odh, asp where asp_id = pri_part and pri_wg <> 2 and asp_lengum = 'Y' and asp_vendorid in ('57', '58', '304', '57A') and pri_newcostchk like 'N%' and ord_assy = pri_customerid and odh_orderid = ord_orderid and Datediff(YEAR, odh_newdate, '{dtpDate.Value.AddYears(-2).ToString("yyyy")}') = 0 ) as aa where aa.訂單數量 > 0 ) as bb group by bb.客號 ) tab";
                        break;
                    case "年費/電源插頭/頭":
                        strSQL = $@"select {dtpDate.Value.AddYears(0).ToString("yyyy")} as '年份', isnull( Sum(tab.插頭數量), 0 ) as '安規數量', isnull( ( select Round( Sum(t.tbprice), 0 ) from ( select t1.tbprice from safety_fees t1 where Datediff(YEAR, t1.date, '{dtpDate.Value.AddYears(0).ToString("yyyy")}') = 0 and t1.cable = '電源插頭' ) t ), 0 ) as '安規費用' 
                                    from ( select bb.材料名, Round( Sum(bb.插頭數量), 0 ) as '插頭數量' 
                                    from ( select aa.材料名, aa.數量 * aa.訂單數量 as '插頭數量', aa.客號, aa.訂單號, case aa.um when 'F' then convert(FLOAT, aa.umvalue) * 0.3048 * aa.訂單數量 when 'M' then convert(FLOAT, aa.umvalue) * aa.訂單數量 when 'I' then convert(FLOAT, aa.umvalue) * 0.0254 * aa.訂單數量 else 0 end as '長度M' 
                                    from ( select distinct pri_part '材料名', pri_perqty '數量', pri_customerid '客號', ord_orderid '訂單號', ord_qty '訂單數量', case when Len(pri_length) > 0 then right(pri_length, 1) else '' end as um, case when Len(pri_length) > 0 then left( pri_length, Len(pri_length) -1 ) else '' end as umvalue, format(odh_newdate, 'yyyy/MM/dd') '訂單日期' 
                                    from pri, ord, odh where pri_part like 'MSL-%' and pri_newcostchk like 'N%' and ord_assy = pri_customerid and odh_orderid = ord_orderid and Datediff(YEAR, odh_newdate, '{dtpDate.Value.AddYears(0).ToString("yyyy")}') = 0 ) as aa ) as bb group by bb.材料名 ) as tab 
                                    Union 
                                    select {dtpDate.Value.AddYears(-1).ToString("yyyy")} as '年份', isnull( Sum(tab.插頭數量), 0 ) as '安規數量', isnull( ( select Round( Sum(t.tbprice), 0 ) from ( select t1.tbprice from safety_fees t1 where Datediff(YEAR, t1.date, '{dtpDate.Value.AddYears(-1).ToString("yyyy")}') = 0 and t1.cable = '電源插頭' ) t ), 0 ) as '安規費用' 
                                    from ( select bb.材料名, Round( Sum(bb.插頭數量), 0 ) as '插頭數量' 
                                    from ( select aa.材料名, aa.數量 * aa.訂單數量 as '插頭數量', aa.客號, aa.訂單號, case aa.um when 'F' then convert(FLOAT, aa.umvalue) * 0.3048 * aa.訂單數量 when 'M' then convert(FLOAT, aa.umvalue) * aa.訂單數量 when 'I' then convert(FLOAT, aa.umvalue) * 0.0254 * aa.訂單數量 else 0 end as '長度M' 
                                    from ( select distinct pri_part '材料名', pri_perqty '數量', pri_customerid '客號', ord_orderid '訂單號', ord_qty '訂單數量', case when Len(pri_length) > 0 then right(pri_length, 1) else '' end as um, case when Len(pri_length) > 0 then left( pri_length, Len(pri_length) -1 ) else '' end as umvalue, format(odh_newdate, 'yyyy/MM/dd') '訂單日期' 
                                    from pri, ord, odh where pri_part like 'MSL-%' and pri_newcostchk like 'N%' and ord_assy = pri_customerid and odh_orderid = ord_orderid and Datediff(YEAR, odh_newdate, '{dtpDate.Value.AddYears(-1).ToString("yyyy")}') = 0 ) as aa ) as bb group by bb.材料名 ) as tab 
                                    Union 
                                    select {dtpDate.Value.AddYears(-2).ToString("yyyy")} as '年份', isnull( Sum(tab.插頭數量), 0 ) as '安規數量', isnull( ( select Round( Sum(t.tbprice), 0 ) from ( select t1.tbprice from safety_fees t1 where Datediff(YEAR, t1.date, '{dtpDate.Value.AddYears(-2).ToString("yyyy")}') = 0 and t1.cable = '電源插頭' ) t ), 0 ) as '安規費用' 
                                    from ( select bb.材料名, Round( Sum(bb.插頭數量), 0 ) as '插頭數量' 
                                    from ( select aa.材料名, aa.數量 * aa.訂單數量 as '插頭數量', aa.客號, aa.訂單號, case aa.um when 'F' then convert(FLOAT, aa.umvalue) * 0.3048 * aa.訂單數量 when 'M' then convert(FLOAT, aa.umvalue) * aa.訂單數量 when 'I' then convert(FLOAT, aa.umvalue) * 0.0254 * aa.訂單數量 else 0 end as '長度M' 
                                    from ( select distinct pri_part '材料名', pri_perqty '數量', pri_customerid '客號', ord_orderid '訂單號', ord_qty '訂單數量', case when Len(pri_length) > 0 then right(pri_length, 1) else '' end as um, case when Len(pri_length) > 0 then left( pri_length, Len(pri_length) -1 ) else '' end as umvalue, format(odh_newdate, 'yyyy/MM/dd') '訂單日期' 
                                    from pri, ord, odh where pri_part like 'MSL-%' and pri_newcostchk like 'N%' and ord_assy = pri_customerid and odh_orderid = ord_orderid and Datediff(YEAR, odh_newdate, '{dtpDate.Value.AddYears(-2).ToString("yyyy")}') = 0 ) as aa ) as bb group by bb.材料名 ) as tab";
                        break;
                    case "年費/電源線材/M":
                        strSQL = $@"select {dtpDate.Value.AddYears(0).ToString("yyyy")} as '年份', isnull( Sum(tab.長度M), 0 ) as '安規數量', isnull( ( select Round( Sum(t.tbprice), 0 ) from ( select t1.tbprice from safety_fees t1 where Datediff(YEAR, t1.date, '{dtpDate.Value.AddYears(0).ToString("yyyy")}') = 0 and t1.cable = '電源線材' ) t ), 0 ) as '安規費用' 
                                    from ( select bb.客號, Round( Sum(bb.長度M), 0 ) as '長度M' 
                                    from ( select aa.客號, aa.umvalue as 長度M 
                                    from ( select distinct pri_customerid '客號', ord_orderid '訂單號', ord_qty '訂單數量', asp_um as um, case asp_um when 'FT' then Round(pri_perqty * 0.3048 * ord_qty, 1) when 'M' then Round(pri_perqty * ord_qty, 1) when 'CM' then Round(pri_perqty * 0.01 * ord_qty, 1) else 0 end as umvalue, format(odh_newdate, 'yyyy/MM/dd') '訂單日期' 
                                    from pri, ord, odh, asp where asp_id = pri_part and pri_wg = 2 and asp_lengum = 'Y' and asp_vendorid in ('57', '58', '304', '57A', '5758') and pri_newcostchk like 'N%' and ord_assy = pri_customerid and odh_orderid = ord_orderid and Datediff(YEAR, odh_newdate, '{dtpDate.Value.AddYears(0).ToString("yyyy")}') = 0 ) as aa ) as bb group by bb.客號 ) tab 
                                    Union 
                                    select {dtpDate.Value.AddYears(-1).ToString("yyyy")} as '年份', isnull( Sum(tab.長度M), 0 ) as '安規數量', isnull( ( select Round( Sum(t.tbprice), 0 ) from ( select t1.tbprice from safety_fees t1 where Datediff(YEAR, t1.date, '{dtpDate.Value.AddYears(-1).ToString("yyyy")}') = 0 and t1.cable = '電源線材' ) t ), 0 ) as '安規費用' 
                                    from ( select bb.客號, Round( Sum(bb.長度M), 0 ) as '長度M' 
                                    from ( select aa.客號, aa.umvalue as 長度M 
                                    from ( select distinct pri_customerid '客號', ord_orderid '訂單號', ord_qty '訂單數量', asp_um as um, case asp_um when 'FT' then Round(pri_perqty * 0.3048 * ord_qty, 1) when 'M' then Round(pri_perqty * ord_qty, 1) when 'CM' then Round(pri_perqty * 0.01 * ord_qty, 1) else 0 end as umvalue, format(odh_newdate, 'yyyy/MM/dd') '訂單日期' 
                                    from pri, ord, odh, asp where asp_id = pri_part and pri_wg = 2 and asp_lengum = 'Y' and asp_vendorid in ('57', '58', '304', '57A', '5758') and pri_newcostchk like 'N%' and ord_assy = pri_customerid and odh_orderid = ord_orderid and Datediff(YEAR, odh_newdate, '{dtpDate.Value.AddYears(-1).ToString("yyyy")}') = 0 ) as aa ) as bb group by bb.客號 ) tab 
                                    Union 
                                    select {dtpDate.Value.AddYears(-2).ToString("yyyy")} as '年份', isnull( Sum(tab.長度M), 0 ) as '安規數量', isnull( ( select Round( Sum(t.tbprice), 0 ) from ( select t1.tbprice from safety_fees t1 where Datediff(YEAR, t1.date, '{dtpDate.Value.AddYears(-2).ToString("yyyy")}') = 0 and t1.cable = '電源線材' ) t ), 0 ) as '安規費用' 
                                    from ( select bb.客號, Round( Sum(bb.長度M), 0 ) as '長度M' 
                                    from ( select aa.客號, aa.umvalue as 長度M 
                                    from ( select distinct pri_customerid '客號', ord_orderid '訂單號', ord_qty '訂單數量', asp_um as um, case asp_um when 'FT' then Round(pri_perqty * 0.3048 * ord_qty, 1) when 'M' then Round(pri_perqty * ord_qty, 1) when 'CM' then Round(pri_perqty * 0.01 * ord_qty, 1) else 0 end as umvalue, format(odh_newdate, 'yyyy/MM/dd') '訂單日期' 
                                    from pri, ord, odh, asp where asp_id = pri_part and pri_wg = 2 and asp_lengum = 'Y' and asp_vendorid in ('57', '58', '304', '57A', '5758') and pri_newcostchk like 'N%' and ord_assy = pri_customerid and odh_orderid = ord_orderid and Datediff(YEAR, odh_newdate, '{dtpDate.Value.AddYears(-2).ToString("yyyy")}') = 0 ) as aa ) as bb group by bb.客號 ) tab";
                        break;
                    default:

                        break;
                }

                string strFees = "";
                string strQty = "";

                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvCount.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strFees = strFees + (string.IsNullOrEmpty(dt.Rows[i]["安規費用"].ToString()) == true ? "0" : dt.Rows[i]["安規費用"].ToString()) + "+";
                        strQty = strQty + (string.IsNullOrEmpty(dt.Rows[i]["安規數量"].ToString()) == true ? "0" : dt.Rows[i]["安規數量"].ToString()) + "+";
                    }
                }
                strPricecal = "(" + strFees.Substring(0, strFees.Length - 1) + ")" + "/" + "(" + strQty.Substring(0, strQty.Length - 1) + ")";
                //計算式  計算機 引用using System.Data
                txtPurprice.Text = Convert.ToDouble(new DataTable().Compute(strPricecal, null)).ToString("0.######");

                strSQL = $@"select spec                              規格,
                                   Round(Isnull(電源線材, 0), 0) 電源線材,
                                   Round(Isnull(電源插頭, 0), 0) 電源插頭,
                                   Round(Isnull(一般線材, 0), 0) 一般線材
                            from   (select spec,
                                           cable,
                                           tbprice
                                    from   safety_fees
                                    where  Datediff(YEAR, date, '{dtpDate.Value.AddYears(0).ToString("yyyy")}') = 0) as S
                                   pivot ( Sum(tbprice)
                                         for cable in ( 一般線材,
                                                        電源插頭,
                                                        電源線材 ) ) as P
                            order  by Charindex(spec, '美規歐規英規澳規其他外校費') ";
                int A1 = 0;
                int A2 = 0;
                int A3 = 0;
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvFees.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        A1 = A1 + Convert.ToInt32(dt.Rows[i]["電源線材"]);
                        A2 = A2 + Convert.ToInt32(dt.Rows[i]["電源插頭"]);
                        A3 = A3 + Convert.ToInt32(dt.Rows[i]["一般線材"]);
                    }
                }
                lblA1.Text = A1.ToString();
                lblA2.Text = A2.ToString();
                lblA3.Text = A3.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboMaterial_TextChanged(object sender, EventArgs e)
        {
            btnInq.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                //確認權限
                if (clsGlobal.checkRightFlag("材料採購明細儲存權限") == false)
                {
                    MessageBox.Show("您沒有材料採購明細儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtPurprice.Text == "")
                {
                    MessageBox.Show("請先做查詢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show(cboMaterial.Text + "單價=" + txtPurprice.Text + ", 是否要儲存", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                //先取得asp參數
                GetAsp(cboMaterial.Text);

                asp_purprice = Convert.ToDouble(txtPurprice.Text);      //單價
                asp_pricecal = strPricecal;                        //單價計算式
                DoUpdate_asp1();                     //更新asp資料(沒有做updateBOM)
                this.Cursor = Cursors.Default;//滑鼠還原預設

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

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
