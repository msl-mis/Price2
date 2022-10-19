using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Price2
{
    public partial class frmBOMPrice : Form
    {
        List<string[]> listID = new List<string[]>();   //儲存ID,上層材料單搜尋用
        public static string rstrID = "";  //由frmBOMPrice_Grid回傳的材料名
        public static string rstrName = "";  //由frmBOMPrice_Grid回傳的品號
        public static string rstrMsg = "";  //由frmBOMPrice_Msgbox回傳的訊息

        public static string rstrPart = "";  //由frmBOMPrice_Special回傳的材料
        public static string rstrTbprice = "";  //由frmBOMPrice_Special回傳的台幣單價
        public static string rstrPerQty = "";  //由frmBOMPrice_Special回傳的數量
        public static string rstrCost = "";  //由frmBOMPrice_Special回傳的(臺幣單價*數量)價格(就是frmBOMPrice_Special臺幣換算單價)
        public static string rstrPtx_chk = "";  //由frmBOMPrice_Special回傳的"註"
        public static string rstrQtyCal = "";  //由frmBOMPrice_Special回傳的數量計算式
        public static string rstrButton = "";  //由frmBOMPrice_Special回傳的Button(Delete;Select)

        public static string rstrClass = "";  //由frmBOMPrice_Class回傳的分類
        public static string rstrNote = "";  //由frmBOMPrice_Note回傳的備註
        public static string rstrLarge = "";  //由frmBOMPrice_Large回傳的量大報價數

        Boolean blnPriceChange = false; //判斷單價是否變更
        Boolean blnCal = false; //判斷是否由input_box計算變更
        string newcost = "N";    //標記是否採用新成本報價價格計算
        string cid_reg = "";    //客號記憶
        Boolean tsave = true; //檢查是否已儲存旗標,設為已儲存
        string oldpid = ""; //記錄已讀取的客號
        string len_unit = "PC"; //材料單單位,預設為PC
        string odi_qty = "0";    //記錄參照法內的箱量, odi_zx 記錄參照法的材積,李先生並要求當輸入裝和運材料時,數量要求與參照法一致.若參照法為0則裝運材料數量要一致
        string strLevel4_ID = "";   //點選的第四層材料名
        string strQTY = ""; //數量的計算式
        string strNote = ""; //備註
        public frmBOMPrice()
        {
            InitializeComponent();
        }

        private void frmBOMPrice_Activated(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                //加入第一層名稱
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select distinct ap1_assy
                            from   ap1
                            order  by ap1_assy ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvLevel_1.DataSource=dt;
                }
                newcost = "N";    //標記是否採用新成本報價價格計算
                cid_reg = "";    //客號記憶
                tsave = true; //檢查是否已儲存旗標,設為已儲存
                oldpid = ""; //記錄已讀取的客號
                len_unit = "PC"; //材料單單位,預設為PC
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOM_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvLevel_1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //加入第二層名稱
            try
            {
                if (e.RowIndex >= 0)
                {
                    //先將後面三層清除
                    clear_dgvLevel_2();
                    clear_dgvLevel_3();
                    clear_dgvLevel_4();
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    strSQL = $@"select ap1_part
                            from   ap1
                            where  ap1_assy = '{dgvLevel_1.Rows[e.RowIndex].Cells["ap1_assy"].Value.ToString()}'
                            order  by ap1_part ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        dgvLevel_2.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvLevel_1_CellClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLevel_2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //加入第三層名稱
            try
            {
                //先將後面二層清除
                clear_dgvLevel_3();
                clear_dgvLevel_4();
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select ap2_part
                            from   ap2
                            where  ap2_assy = '{dgvLevel_2.Rows[e.RowIndex].Cells["ap1_part"].Value.ToString()}'
                            order  by ap2_part ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvLevel_3.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvLevel_2_CellClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLevel_3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //加入第四層名稱
            try
            {
                //先將後面一層清除
                clear_dgvLevel_4();
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select ap3_part,
                                   ap3_tbprice 
                            from   ap3
                            where  ap3_assy = '{dgvLevel_3.Rows[e.RowIndex].Cells["ap2_part"].Value.ToString()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvLevel_4.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-cboLevel3_TextChanged" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLevel_4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //紀錄第四層材料名稱
            try
            {
                strLevel4_ID = dgvLevel_4.Rows[e.RowIndex].Cells["ap3_part"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-cboLevel3_TextChanged" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clear_dgvLevel_1()
        {
            if (dgvLevel_1.Rows.Count > 0)
            {
                DataTable dt = (DataTable)dgvLevel_1.DataSource;
                dt.Rows.Clear();
                dgvLevel_1.DataSource = dt;
            }
        }

        private void clear_dgvLevel_2()
        {
            if (dgvLevel_2.Rows.Count > 0)
            {
                DataTable dt = (DataTable)dgvLevel_2.DataSource;
                dt.Rows.Clear();
                dgvLevel_2.DataSource = dt;
            }
        }

        private void clear_dgvLevel_3()
        {
            if (dgvLevel_3.Rows.Count > 0)
            {
                DataTable dt = (DataTable)dgvLevel_3.DataSource;
                dt.Rows.Clear();
                dgvLevel_3.DataSource = dt;
            }
        }

        private void clear_dgvLevel_4()
        {
            if (dgvLevel_4.Rows.Count > 0)
            {
                DataTable dt = (DataTable)dgvLevel_4.DataSource;
                dt.Rows.Clear();
                dgvLevel_4.DataSource = dt;
            }
            strLevel4_ID = "";  //清除記憶
        }

        private void clear_dgvData()
        {
            //if (dgvData.Rows.Count > 1)
            //{
            //    DataTable dt = (DataTable)dgvData.DataSource;
            //    dt.Rows.Clear();
            //    dgvData.DataSource = dt;
            //}
            dgvData.Rows.Clear();
        }

        private void getData()
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                //檢查客號text13,廠號text4,客戶text3等欄位是否為空白
                if (txtID.Text == "" && txtCustomer.Text == "" && txtName.Text == "")
                {
                    MessageBox.Show("你沒有輸入產品,不能選擇產品!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //檢查權限
                strSQL = $@"select pas_controluser from pas where pas_username='{clsGlobal.strG_User}'";
                dt = clsDB.sql_select_dt(strSQL);
                string tuserflag = "";
                if (dt.Rows.Count > 0)
                {
                    tuserflag = dt.Rows[0]["pas_controluser"].ToString();
                }
                else
                {
                    tuserflag = "";
                }

                //如果沒有客號,就以客戶/廠號/線長等欄位條件來查詢報價單
                if (txtID.Text.Trim() == "")
                {
                    if (chkMaterial.Checked)
                    {
                        strSQL = $@"select distinct pri_customer,
                                                    pri_assy,
                                                    pri_customerid,
                                                    pri_length,
                                                    pri_ll,
                                                    pri_customerll,
                                                    pri_pricost,
                                                    pri_date,
                                                    pri_clcost,
                                                    pri_hopelprice,
                                                    pri_currency,
                                                    pri_oldll,
                                                    pri_oldcustomerll,
                                                    pri_wg,
                                                    pri_vendorid,
                                                    pri_bzflag,
                                                    pri_ld,
                                                    pri_gp,
                                                    pri_gc,
                                                    pri_confirmflag,
                                                    pri_bz,
                                                    pri_wgtype,
                                                    pri_fenlei,
                                                    pri_newcostchk,
                                                    pri_um
                                    from   pri
                                    where  pri_assy = '{txtName.Text.Trim()}'
                                           and pri_newcostchk like 'Y%'";
                    }
                    else
                    {
                        strSQL = $@"select distinct pri_customer,
                                                pri_assy,
                                                pri_customerid,
                                                pri_length,
                                                pri_ll,
                                                pri_customerll,
                                                pri_pricost,
                                                pri_date,
                                                pri_clcost,
                                                pri_hopelprice,
                                                pri_currency,
                                                pri_oldll,
                                                pri_oldcustomerll,
                                                pri_wg,
                                                pri_vendorid,
                                                pri_bzflag,
                                                pri_ld,
                                                pri_gp,
                                                pri_gc,
                                                pri_confirmflag,
                                                pri_bz,
                                                pri_wgtype,
                                                pri_fenlei,
                                                pri_newcostchk,
                                                pri_um
                                from   pri
                                where  pri_customerid = ''
                                       and pri_assy = '{txtName.Text.Trim()}'
                                       and pri_customer = '{txtCustomer.Text.Trim()}'
                                       and pri_length = '{txtLength.Text.Trim()}'
                                       and pri_newcostchk like 'N%'";
                    }
                }
                else
                {
                    if (chkMaterial.Checked)
                    {
                        if (txtName.Text == "")
                        {
                            strSQL = $@"select distinct pri_customer,
                                                        pri_assy,
                                                        pri_customerid,
                                                        pri_length,
                                                        pri_ll,
                                                        pri_customerll,
                                                        pri_pricost,
                                                        pri_date,
                                                        pri_clcost,
                                                        pri_hopelprice,
                                                        pri_currency,
                                                        pri_oldll,
                                                        pri_oldcustomerll,
                                                        pri_wg,
                                                        pri_vendorid,
                                                        pri_convcost,
                                                        pri_bzflag,
                                                        pri_ld,
                                                        pri_gp,
                                                        pri_gc,
                                                        pri_confirmflag,
                                                        pri_bz,
                                                        pri_wgtype,
                                                        pri_fenlei,
                                                        pri_newcostchk,
                                                        pri_um,
                                                        Isnull(pri_verifyuser, '') 'pri_verifyuser',
                                                        Isnull(pri_verifyflag, 0)  'pri_verifyflag'
                                        from   pri
                                        where  pri_customerid = '{txtID.Text.Trim()}'
                                               and pri_newcostchk like 'Y%' ";
                        }
                        else
                        {
                            strSQL = $@"select distinct pri_customer,
                                                        pri_assy,
                                                        pri_customerid,
                                                        pri_length,
                                                        pri_ll,
                                                        pri_customerll,
                                                        pri_pricost,
                                                        pri_date,
                                                        pri_clcost,
                                                        pri_hopelprice,
                                                        pri_currency,
                                                        pri_oldll,
                                                        pri_oldcustomerll,
                                                        pri_wg,
                                                        pri_vendorid,
                                                        pri_convcost,
                                                        pri_bzflag,
                                                        pri_ld,
                                                        pri_gp,
                                                        pri_gc,
                                                        pri_confirmflag,
                                                        pri_bz,
                                                        pri_wgtype,
                                                        pri_fenlei,
                                                        pri_newcostchk,
                                                        pri_um,
                                                        Isnull(pri_verifyuser, '') 'pri_verifyuser',
                                                        Isnull(pri_verifyflag, 0)  'pri_verifyflag'
                                        from   pri
                                        where  pri_customerid = '{txtID.Text.Trim()}'
                                               and pri_assy = '{txtName.Text.Trim()}'
                                               and pri_newcostchk like 'Y%' ";
                        }
                    }
                    else
                    {
                        strSQL = $@"select distinct pri_customer,
                                                pri_assy,
                                                pri_customerid,
                                                pri_length,
                                                pri_ll,
                                                pri_customerll,
                                                pri_pricost,
                                                pri_date,
                                                pri_clcost,
                                                pri_hopelprice,
                                                pri_currency,
                                                pri_oldll,
                                                pri_oldcustomerll,
                                                pri_wg,
                                                pri_vendorid,
                                                pri_convcost,
                                                pri_bzflag,
                                                pri_ld,
                                                pri_gp,
                                                pri_gc,
                                                pri_confirmflag,
                                                pri_bz,
                                                pri_wgtype,
                                                pri_fenlei,
                                                pri_newcostchk,
                                                pri_um,
                                                Isnull(pri_verifyuser, '')     'pri_verifyuser',
                                                Isnull(pri_verifyflag, 0)      'pri_verifyflag',
                                                Isnull(pri_hopelprice_cal, '') 'pri_hopelprice_cal',
                                                Isnull(pri_pricost_cal, '')    'pri_pricost_cal'
                                from   pri
                                where  pri_customerid = '{txtID.Text.Trim()}'
                                       and pri_newcostchk like 'N%' ";
                    }
                }
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count == 0)
                {
                    if (chkMaterial.Checked)
                    {
                        if (MessageBox.Show("資料庫中沒有這個材料名的材料單記錄!你要新增嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            getClear();
                            txtID.Focus();
                        }
                        else
                        {
                            lblCZF.Text = "";   //參照異動旗標
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("資料庫中沒有這個產品的報價記錄!你要新增嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            getClear();
                            txtID.Focus();
                        }
                        else
                        {
                            lblCZF.Text = "";   //參照異動旗標
                        }
                    }

                    return;
                }

                //檢查是否有權限
                if(string.IsNullOrEmpty(dt.Rows[0]["pri_customer"].ToString())==false)
                {
                    if (dt.Rows[0]["pri_customer"].ToString().ToUpper().Substring(0, 1) != "Y" && tuserflag != "")
                    {
                        MessageBox.Show("你沒有權限調用該客號的報價記錄,因為該客號的客戶為:" + dt.Rows[0]["pri_customer"].ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                

                //記錄客號
                if (txtID.Text != "")
                {
                    oldpid = txtID.Text;
                }
                else
                {
                    oldpid = "";
                }
                HopePrice_Cal = "";    //希望買價計算式
                Quote_Cal = "";    //報價計算式
                if (chkMaterial.Checked == false)
                {
                    HopePrice_Cal = dt.Rows[0]["pri_hopelprice_cal"].ToString();    //希望買價計算式
                    Quote_Cal = dt.Rows[0]["pri_pricost_cal"].ToString();    //報價計算式
                }

                string tll = dt.Rows[0]["pri_ll"].ToString();
                string tcustomerll = dt.Rows[0]["pri_customerll"].ToString();
                string toldll = dt.Rows[0]["pri_oldll"].ToString();
                string toldcustomerll = dt.Rows[0]["pri_oldcustomerll"].ToString();
                string tpricost = dt.Rows[0]["pri_pricost"].ToString();
                string tclcost = dt.Rows[0]["pri_clcost"].ToString();
                string tdate = ((DateTime)dt.Rows[0]["pri_date"]).ToString("yyyy/MM/dd");
                string thopelprice = dt.Rows[0]["pri_hopelprice"].ToString();
                string tlength = dt.Rows[0]["pri_length"].ToString();
                string tcurrency = dt.Rows[0]["pri_currency"].ToString();
                string tcustomerid = dt.Rows[0]["pri_customerid"].ToString();
                //If Left(newcost, 1) = "Y" And Text13.Text = "" Then Text13.Text = tcustomerid
                if (chkMaterial.Checked && txtID.Text == "")
                {
                    txtID.Text = tcustomerid;
                }
                string tassy = dt.Rows[0]["pri_assy"].ToString();
                string twg = dt.Rows[0]["pri_wg"].ToString();
                string tbzflag = dt.Rows[0]["pri_bzflag"].ToString();
                string tld = dt.Rows[0]["pri_ld"].ToString();
                string tgp = dt.Rows[0]["pri_gp"].ToString();
                string tgc = dt.Rows[0]["pri_gc"].ToString();
                string tvendorid = dt.Rows[0]["pri_vendorid"].ToString();
                string tconfirmflag = dt.Rows[0]["pri_confirmflag"].ToString();
                string tbz = dt.Rows[0]["pri_bz"].ToString();
                string vflag = "";
                string vuser = "";

                if (chkMaterial.Checked == false)
                {
                    vflag = dt.Rows[0]["pri_verifyflag"].ToString();
                    vuser = dt.Rows[0]["pri_verifyuser"].ToString();
                }
                newcost = dt.Rows[0]["pri_newcostchk"].ToString();
                if (newcost.Substring(0, 1) == "Y" && chkMaterial.Checked == false)
                {
                    chkMaterial.Checked = true;
                    txtID.Text = cid_reg;
                    cid_reg = "";
                    txtID.Focus();
                    return;
                }
                len_unit = dt.Rows[0]["pri_um"].ToString();
                //Label25.Caption = MSRDC5.Resultset!pri_wgtype

                //檢查是否標註分類
                if (dt.Rows[0]["pri_fenlei"].ToString() == "")
                {
                    chkClassify.Checked = false;
                    pfenlei = "";
                }
                else
                {
                    chkClassify.Checked = true;
                    pfenlei = dt.Rows[0]["pri_fenlei"].ToString().Trim();
                }


                if (txtID.Text == "")//如果沒有客號,就以客戶/廠號/線長等欄位條件來查詢報價單
                {
                    strSQL = $@"select distinct pri_customerid,
                                                pri_length,
                                                pri_ll,
                                                pri_customerll,
                                                pri_pricost,
                                                pri_date,
                                                pri_clcost,
                                                pri_hopelprice,
                                                pri_currency,
                                                pri_oldll,
                                                pri_oldcustomerll,
                                                pri_wg,
                                                pri_vendorid,
                                                pri_bzflag,
                                                pri_ld,
                                                pri_gp,
                                                pri_gc,
                                                pri_confirmflag
                                from   pri
                                where  pri_customerid = ''
                                        and pri_assy = '{txtName.Text.Trim()}'
                                        and pri_customer = '{txtCustomer.Text.Trim()}'
                                        and pri_length = '{txtLength.Text.Trim()}'
                                        and pri_newcostchk like 'N%'";
                }
                else//以客號欄位條件來查詢報價單
                {
                    if (chkMaterial.Checked)
                    {
                        if (txtName.Text != "")//有品號則直接叫出材料單
                        {
                            strSQL = $@"select distinct pri_customerid,
                                                        pri_assy,
                                                        pri_customer,
                                                        pri_newcostchk
                                        from   pri
                                        where  pri_customerid = '{txtID.Text.Trim()}'
                                               and pri_assy = '{txtName.Text.Trim()}'
                                               and pri_newcostchk like 'Y%'";
                        }
                        else//沒有品號則檢查有多少筆材料單
                        {
                            strSQL = $@"select distinct pri_customerid,
                                                        pri_assy,
                                                        pri_customer,
                                                        pri_newcostchk
                                        from   pri
                                        where  pri_customerid = '{txtID.Text.Trim()}'
                                               and pri_newcostchk like 'Y%'
                                               and ( pri_assy in (select aspnum_num
                                                                  from   aspnum
                                                                  where  aspnum_id = '{txtID.Text.Trim()}')
                                                      or pri_assy in (select asp_vendormaterialno
                                                                      from   asp
                                                                      where  asp_id = '{txtID.Text.Trim()}') )";
                        }
                    }
                    else
                    {
                        strSQL = $@"select distinct pri_customerid,
                                                        pri_length,
                                                        pri_ll,
                                                        pri_customerll,
                                                        pri_pricost,
                                                        pri_date,
                                                        pri_clcost,
                                                        pri_hopelprice,
                                                        pri_currency,
                                                        pri_oldll,
                                                        pri_oldcustomerll,
                                                        pri_customer,
                                                        pri_wg,
                                                        pri_vendorid,
                                                        pri_bzflag,
                                                        pri_ld,
                                                        pri_gp,
                                                        pri_gc,
                                                        pri_confirmflag,
                                                        pri_newcostchk
                                        from   pri
                                        where  pri_customerid = '{txtID.Text.Trim()}'
                                               and pri_newcostchk like 'N%'";
                    }
                }
                dt = clsDB.sql_select_dt(strSQL);
                //取得查詢結果筆數
                int tcount = 0;
                if (dt.Rows.Count > 0)
                {
                    tcount = dt.Rows.Count;
                }
                else
                {
                    tcount = 0;
                }

                //若結果筆數大於一,則請使用者選擇要用那一筆資料
                if (tcount > 1)
                {
                    if (txtID.Text == "")
                    {
                        frmBOMPrice_Grid frmBOMPrice_Grid = new frmBOMPrice_Grid();
                        frmBOMPrice_Grid.strWho = "No_id";
                        frmBOMPrice_Grid.pri_assy = txtName.Text;
                        frmBOMPrice_Grid.pri_customer = txtCustomer.Text;
                        frmBOMPrice_Grid.pri_length = txtLength.Text;
                        frmBOMPrice_Grid.ShowDialog();
                    }
                    else
                    {
                        if (chkMaterial.Checked)
                        {
                            frmBOMPrice_Grid frmBOMPrice_Grid = new frmBOMPrice_Grid();
                            frmBOMPrice_Grid.strWho = "M_id";
                            frmBOMPrice_Grid.aspnum_id = txtID.Text;
                            frmBOMPrice_Grid.ShowDialog();
                        }
                        else
                        {
                            frmBOMPrice_Grid frmBOMPrice_Grid = new frmBOMPrice_Grid();
                            frmBOMPrice_Grid.strWho = "C_id";
                            frmBOMPrice_Grid.pri_customerid = txtID.Text;
                            frmBOMPrice_Grid.ShowDialog();
                        }
                    }
                    return;
                }
                else
                {
                    string multi = "";
                    if (chkMaterial.Checked && txtName.Text == "")
                    {
                        strSQL = $@"select distinct ab.aspnum_num '品號',
                                                    case
                                                      when asp_vendormaterialno = ab.aspnum_num then 'V'
                                                      else ''
                                                    end           '火車頭外層',
                                                    case
                                                      when ac.aspnum_num = ab.aspnum_num then 'V'
                                                      else ''
                                                    end           '火車頭內層',
                                                    case
                                                      when aa.pri_assy = ab.aspnum_num then 'V'
                                                      else ''
                                                    end           '有材料單'
                                    from   (select aspnum_id,
                                                   aspnum_num
                                            from   aspnum
                                            union all
                                            select distinct pri_customerid,
                                                            pri_assy
                                            from   pri
                                            where  pri_newcostchk like 'Y%') as ab
                                           left join asp
                                                  on asp_id = ab.aspnum_id
                                                     and asp_vendormaterialno = ab.aspnum_num
                                           left join aspnum as ac
                                                  on ac.aspnum_id = ab.aspnum_id
                                                     and ac.aspnum_num = ab.aspnum_num
                                           left join (select distinct pri_customerid,
                                                                      pri_assy
                                                      from   pri
                                                      where  pri_newcostchk like 'Y%') as aa
                                                  on aa.pri_customerid = ab.aspnum_id
                                                     and aa.pri_assy = ab.aspnum_num
                                    where  ab.aspnum_id = '{txtID.Text.Trim()}'
                                    order  by ab.aspnum_num ";
                        dt2 = clsDB.sql_select_dt(strSQL);

                        if (dt2.Rows.Count > 0)
                        {
                            if (dt2.Rows.Count > 1)
                            {

                                multi = "Y";
                            }
                            else
                            {
                                multi = "";
                            }
                        }
                    }

                    if (chkMaterial.Checked && txtName.Text == "" && multi == "Y")
                    {
                        frmBOMPrice_Grid frmBOMPrice_Grid = new frmBOMPrice_Grid();
                        frmBOMPrice_Grid.strWho = "No_name";
                        frmBOMPrice_Grid.aspnum_id = txtID.Text;
                        frmBOMPrice_Grid.ShowDialog();
                        txtID.Text = rstrID;
                        txtName.Text = rstrName;
                        getData();
                    }

                    if (txtID.Text.Trim() != "" && tcount > 0)
                    {
                        txtCustomer.Text = dt.Rows[0]["pri_customer"].ToString();
                    }

                    txtName.Text = tassy;
                    //取得單身材料明細
                    if (txtID.Text.Trim() == "")
                    {
                        strSQL = $@"select pri_part,
                                           pri_tbprice,
                                           cast(pri_perqty as Varchar) pri_perqty,
                                           pri_cost,
                                           pri_um,
                                           pri_firstname,
                                           pri_perqtycal,
                                           case
                                             when asp_line is null then ''
                                             else asp_line
                                           end asp_line
                                    from   pri
                                           left join asp
                                                  on asp_id = pri_part
                                    where  pri_assy = '{txtName.Text}'
                                           and pri_customer = '{txtCustomer.Text}'
                                           and pri_date = '{tdate}'
                                           and pri_length = '{txtLength.Text}'
                                           and pri_customerid = ''
                                    order  by pri_part ";
                        //strSQL = $@"exec pri_read'{txtName.Text.Trim()}','{txtCustomer.Text.Trim()}','{tdate}','{txtLength.Text.Trim()}'";
                        //clsDB.Execute(strSQL);
                    }
                    else
                    {
                        if (tdate != "")
                        {
                            strSQL = $@"select pri_part,
                                               pri_tbprice,
                                               cast(pri_perqty as Varchar) pri_perqty,
                                               pri_cost,
                                               pri_um,
                                               pri_firstname,
                                               pri_perqtycal,
                                               case
                                                 when asp_line is null then ''
                                                 else asp_line
                                               end as asp_line,
                                               case
                                                 when ptx_type = '1' then 'V'
                                                 when ptx_type = '2' then 'R'
                                                 when asp_name = 'Y' then '下'
                                                 else ''
                                               end as ptx_chk,
                                               Isnull(asp_name, '') asp_name,
                                               Isnull(asp_vnweight, 0) asp_vnweight,
                                               Isnull(asp_vnpcs, 0) asp_vnpcs
                                        from   pri
                                               left join asp
                                                      on asp_id = pri_part
                                               left join ptx
                                                      on ptx_customerid = pri_customerid
                                                         and ptx_name = pri_part
                                        where  pri_customerid = '{txtID.Text.Trim()}'
                                               and pri_date = '{tdate}'
                                               and pri_assy = '{txtName.Text.Trim()}'
                                        order  by pri_part ";
                        }
                        else
                        {
                            strSQL = $@"select pri_part,
                                               pri_tbprice,
                                               cast(pri_perqty as Varchar) pri_perqty,
                                               pri_cost,
                                               pri_um,
                                               pri_firstname,
                                               @computername,
                                               pri_perqtycal,
                                               case
                                                 when asp_line is null then ''
                                                 else asp_line
                                               end as asp_line,
                                               case
                                                 when ptx_type = '1' then 'V'
                                                 when ptx_type = '2' then 'R'
                                                 when asp_name = 'Y' then '下'
                                                 else ''
                                               end as ptx_chk,
                                               Isnull(asp_name, '') asp_name,
                                               Isnull(asp_vnweight, 0) asp_vnweight,
                                               Isnull(asp_vnpcs, 0) asp_vnpcs
                                        from   pri
                                               left join asp
                                                      on asp_id = pri_part
                                               left join ptx
                                                      on ptx_customerid = pri_customerid
                                                         and ptx_name = pri_part
                                        where  pri_customerid = '{txtID.Text.Trim()}' 
                                               and pri_assy = '{txtName.Text.Trim()}' 
                                        order  by pri_part ";
                        }
                        //strSQL = $@"exec pri_read1'{txtID.Text.Trim()}','{tdate}','{txtName.Text.Trim()}'";
                        //clsDB.Execute(strSQL);
                    }
                    
                    dt = clsDB.sql_select_dt(strSQL);
                    //dgvData.DataSource = dt;
                    //清除GRID
                    dgvData.Rows.Clear();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dgvData.Rows.Add();
                            dgvData.Rows[i].Cells["pri_part"].Value = dt.Rows[i]["pri_part"].ToString();
                            dgvData.Rows[i].Cells["pri_tbprice"].Value = dt.Rows[i]["pri_tbprice"].ToString();
                            dgvData.Rows[i].Cells["pri_perqty"].Value = dt.Rows[i]["pri_perqty"].ToString();
                            dgvData.Rows[i].Cells["pri_cost"].Value = dt.Rows[i]["pri_cost"].ToString();
                            dgvData.Rows[i].Cells["pri_firstname"].Value = dt.Rows[i]["pri_firstname"].ToString();
                            dgvData.Rows[i].Cells["pri_perqtycal"].Value = dt.Rows[i]["pri_perqtycal"].ToString();
                            dgvData.Rows[i].Cells["asp_line"].Value = dt.Rows[i]["asp_line"].ToString();
                            dgvData.Rows[i].Cells["ptx_chk"].Value = dt.Rows[i]["ptx_chk"].ToString();
                            dgvData.Rows[i].Cells["asp_name"].Value = dt.Rows[i]["asp_name"].ToString();
                            dgvData.Rows[i].Cells["asp_vnweight"].Value = dt.Rows[i]["asp_vnweight"].ToString();
                            dgvData.Rows[i].Cells["asp_vnpcs"].Value = dt.Rows[i]["asp_vnpcs"].ToString();
                            dgvData.Rows[i].Cells["pri_um"].Value = dt.Rows[i]["pri_um"].ToString();
                        }
                    }
                    txtHopePrice.Text = thopelprice;
                    txtLength.Text = tlength;
                    cboCurrency.Text = tcurrency;
                    txtHopePrice_Rate.Text = tcustomerll;
                    txtID.Text = tcustomerid;
                    if (tbzflag == "1")
                    {
                        chkNote.Checked = true;
                    }
                    else
                    {
                        chkNote.Checked = false;
                    }

                    chkOutsourcing.Checked = false;
                    chkPower.Checked = false;
                    if (tld == "1")
                    {
                        chkLarge.Checked = true;
                    }
                    else
                    {
                        chkLarge.Checked = false;
                    }

                    strNote = tbz;

                    if (twg == "1")
                    {
                        chkOutsourcing.Checked = true;
                    }
                    if (twg == "2")
                    {
                        chkPower.Checked = true;
                    }
                    txtVender.Text = tvendorid;
                    //檢查報價單身的價格加總
                    checkPrice();
                    txtQuote.Text = tpricost;
                    txtQuote_Rate.Text = tll;
                }

                if (chkMaterial.Checked == false)
                {
                    if (checkOdi(txtID.Text).Substring(0, 1) != "0")
                    {
                        lblCZF.Text = "參照法有異動";
                    }
                    else
                    {
                        lblCZF.Text = "";
                    }

                    //檢查參照法箱量
                    strSQL = $@"select odi_xz from odi where odi_customerid='{txtID.Text}'";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        odi_qty = dt.Rows[0]["odi_xz"].ToString();
                    }
                    else
                    {
                        odi_qty = "0";
                    }
                }
                
                //檢查是否有特選材料
                strSQL = $@"select pri_part,
                                   ptx_type
                            from   pri
                                   left join ptx
                                          on ptx_customerid = pri_customerid
                                             and ptx_name = pri_part
                            where  pri_customerid = '{txtID.Text}'
                                   and pri_firstname = '其它料'
                                   and ( ptx_type = '1'
                                          or ptx_type = '2' ) ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0)
                {
                    chkSpecial.Checked = true;
                }
                else
                {
                    chkSpecial.Checked = false;
                }

                if(newcost.Substring(0,1)=="N")
                {
                    if(vflag=="1")
                    {
                        chkCheck.Checked = true;
                    }
                    else
                    {
                        chkCheck.Checked = false;
                    }
                    toolTip1.SetToolTip(chkCheck, vuser);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkPrice()
        {
            //檢查報價單身的價格加總
            try
            {
                string partchk01 = ""; //記錄裝材料數量
                string partchk02 = ""; //記錄運材料數量
                string part01 = "";
                string part02 = "";
                double tmp = 0;
                double tcol1 = 0; //單價欄位加總,不包含加工/分,編織袋,不良率金額
                double tcol2 = 0; //數量欄位加總,不包含加工/分,編織袋,不良率金額
                double tcol3 = 0; //金額欄位加總,不包含加工/分,編織袋,不良率金額
                double suma = 0; //編織袋金額
                double sumb = 0; //加工/分金額
                double sumc = 0; //不良率金額
                double sumd = 0; //焊工補貼
                double sume = 0; //鋁箔雙面紙膠金額
                double sumf = 0; //熱縮套管成本
                double sumf1 = 0; //熱縮套管成本
                sum1 = 0; //新材料價金額加總
                sum2 = 0;
                sum3 = 0;
                sum4 = 0;
                sum5 = 0;
                sum6 = 0;
                sum7 = 0;
                sum8 = 0;
                sum9 = 0;
                sum10 = 0;
                double sum12 = 0; //越南運費重量計重總和
                string sum12cal = ""; //越南運費重量計重總和計算式
                
                string vncal = ""; //越南運費計算單項公式,火車頭重量/數量("0.#"));

                int sum12tmp = -1; //越南運費重量計重材料名所在位置行數
                int sumci = -1; //不良率的行數暫存

                string strSQL = "";
                DataTable dt = new DataTable();

                //檢查單身中各材料金額
                for (int i = 0; i < dgvData.Rows.Count-1; i++)
                {
                    
                    switch (dgvData.Rows[i].Cells["pri_part"].Value.ToString().Substring(0, 2))
                    {
                        case "不良":
                            sumci = i;
                            break;
                        case "加工":
                            sumb = sumb + Convert.ToDouble(dgvData.Rows[i].Cells["pri_cost"].Value);
                            break;
                        case "編織":
                            suma = suma + Convert.ToDouble(dgvData.Rows[i].Cells["pri_cost"].Value);
                            break;
                        case "焊工":
                            sumd = sumd + Convert.ToDouble(dgvData.Rows[i].Cells["pri_cost"].Value);
                            break;
                        case "雙面":
                            sume = sume + Convert.ToDouble(dgvData.Rows[i].Cells["pri_cost"].Value);
                            break;
                        default:
                            tcol1 = tcol1 + Convert.ToDouble(dgvData.Rows[i].Cells["pri_tbprice"].Value); //單價
                            tcol2 = tcol2 + Convert.ToDouble(dgvData.Rows[i].Cells["pri_perqty"].Value); //數量
                            tcol3 = tcol3 + Convert.ToDouble(dgvData.Rows[i].Cells["pri_cost"].Value); //金額
                            if (sum9 == 0)
                            {
                                sum9 = Convert.ToDouble(dgvData.Rows[i].Cells["pri_cost"].Value);
                            }
                            else
                            {
                                //相乘計算
                                sum9 = sum9 * Convert.ToDouble(dgvData.Rows[i].Cells["pri_cost"].Value);
                            }

                            if (sum10 == 0)
                            {
                                sum10 = Convert.ToDouble(dgvData.Rows[i].Cells["pri_cost"].Value);
                            }
                            else
                            {
                                if (Convert.ToDouble(dgvData.Rows[i].Cells["pri_cost"].Value) != 0)
                                {
                                    //相除計算
                                    sum10 = sum10 / Convert.ToDouble(dgvData.Rows[i].Cells["pri_cost"].Value);
                                }
                            }

                            if (Convert.ToDouble(dgvData.Rows[i].Cells["pri_perqty"].Value) >= 1)
                            {
                                sumf = sumf + Convert.ToDouble(dgvData.Rows[i].Cells["pri_cost"].Value);
                            }
                            else
                            {
                                sumf1 = sumf1 + Convert.ToDouble(dgvData.Rows[i].Cells["pri_cost"].Value);
                            }

                            if (dgvData.Rows[i].Cells["pri_part"].Value.ToString().Substring(0, 1) == "裝")
                            {
                                partchk01 = dgvData.Rows[i].Cells["pri_perqty"].Value.ToString();
                                part01 = dgvData.Rows[i].Cells["pri_part"].Value.ToString();
                            }

                            if (dgvData.Rows[i].Cells["pri_part"].Value.ToString().Substring(0, 1) == "運")
                            {
                                partchk02 = dgvData.Rows[i].Cells["pri_perqty"].Value.ToString();
                                part02 = dgvData.Rows[i].Cells["pri_part"].Value.ToString();
                            }

                            break;
                    }
                    

                    //處理材料單中的越南運費計重
                    if (chkMaterial.Checked)
                    {
                        if(string.IsNullOrEmpty(dgvData.Rows[i].Cells["asp_name"].Value.ToString())==false)
                        {
                            if(dgvData.Rows[i].Cells["asp_name"].Value.ToString()=="Y")
                            {
                                if(sum12cal == "")
                                {
                                    //若火車頭設有重量則帶入公式,重量/數量*材料數量
                                    if(Convert.ToDouble(dgvData.Rows[i].Cells["asp_vnweight"].Value)>0 && Convert.ToDouble(dgvData.Rows[i].Cells["asp_vnpcs"].Value)>0)
                                    {
                                        sum12cal = dgvData.Rows[i].Cells["asp_vnweight"].Value.ToString() + "/" + dgvData.Rows[i].Cells["asp_vnpcs"].Value.ToString() + "*" + dgvData.Rows[i].Cells["pri_perqty"].Value.ToString();
                                        sum12 = Convert.ToDouble(dgvData.Rows[i].Cells["asp_vnweight"].Value) / Convert.ToDouble(dgvData.Rows[i].Cells["asp_vnpcs"].Value) * Convert.ToDouble(dgvData.Rows[i].Cells["pri_perqty"].Value);
                                    }
                                    else
                                    {
                                        sum12cal = dgvData.Rows[i].Cells["pri_perqty"].Value.ToString();
                                        sum12 = Convert.ToDouble(dgvData.Rows[i].Cells["pri_perqty"].Value);
                                    }
                                }
                                else
                                {
                                    //若火車頭設有重量則帶入公式
                                    if (Convert.ToDouble(dgvData.Rows[i].Cells["asp_vnweight"].Value) > 0 && Convert.ToDouble(dgvData.Rows[i].Cells["asp_vnpcs"].Value) > 0)
                                    {
                                        sum12cal = sum12cal + "+" + dgvData.Rows[i].Cells["asp_vnweight"].Value.ToString() + "/" + dgvData.Rows[i].Cells["asp_vnpcs"].Value.ToString() + "*" + dgvData.Rows[i].Cells["pri_perqty"].Value.ToString();
                                        sum12 = sum12 + Convert.ToDouble(dgvData.Rows[i].Cells["asp_vnweight"].Value) / Convert.ToDouble(dgvData.Rows[i].Cells["asp_vnpcs"].Value) * Convert.ToDouble(dgvData.Rows[i].Cells["pri_perqty"].Value);
                                    }
                                    else
                                    {
                                        sum12cal = sum12cal + "+" + dgvData.Rows[i].Cells["pri_perqty"].Value.ToString();
                                        sum12 = sum12 + Convert.ToDouble(dgvData.Rows[i].Cells["pri_perqty"].Value);
                                    }

                                }

                            }
                        }
                        if (dgvData.Rows[i].Cells["pri_part"].Value.ToString() == "vnfreight")
                        {
                            //越南運費重量計重材料名所在位置行數
                            sum12tmp = i;
                        }
                        if (dgvData.Rows[i].Cells["pri_part"].Value.ToString() == "運/進/台灣→越南/kg")
                        {
                            //越南運費重量計重材料名所在位置行數
                            sum12tmp = i;
                        }
                        if (dgvData.Rows[i].Cells["pri_part"].Value.ToString() == "運/進/海防→南定/kg")
                        {
                            //越南運費重量計重材料名所在位置行數
                            sum12tmp = i;
                        }
                    }
                }

                //檢查越南運費計重

                //檢查如果抓不到其他有標註運費的材料時,則維持材料數量原設定
                if (sum12tmp >= 0 && sum12 != 0)
                {
                    dgvData.Rows[sum12tmp].Cells["pri_perqtycal"].Value = sum12cal;
                    dgvData.Rows[sum12tmp].Cells["pri_perqty"].Value = sum12.ToString("0.######");
                    if(Convert.ToDouble(dgvData.Rows[sum12tmp].Cells["pri_cost"].Value) != (Convert.ToDouble(dgvData.Rows[sum12tmp].Cells["pri_tbprice"].Value) * Convert.ToDouble(dgvData.Rows[sum12tmp].Cells["pri_perqty"].Value)))
                    {
                        tcol3 = tcol3 +  (Convert.ToDouble(dgvData.Rows[sum12tmp].Cells["pri_tbprice"].Value) * Convert.ToDouble(dgvData.Rows[sum12tmp].Cells["pri_perqty"].Value) - Convert.ToDouble(dgvData.Rows[sum12tmp].Cells["pri_cost"].Value)) ;
                    }
                    dgvData.Rows[sum12tmp].Cells["pri_cost"].Value= (Convert.ToDouble(dgvData.Rows[sum12tmp].Cells["pri_tbprice"].Value) * Convert.ToDouble(dgvData.Rows[sum12tmp].Cells["pri_perqty"].Value)).ToString("0.######");
                }

                //檢查是否有不良率,若有則予以計算不良率
                if (sumci>= 0)
                {
                    //區別新舊材料不良率計算
                    if( newcost == "Y1" )
                    {
                        sumc = (tcol3 + suma + sumb) * Convert.ToDouble(dgvData.Rows[sumci].Cells["pri_tbprice"].Value) * Convert.ToDouble(dgvData.Rows[sumci].Cells["pri_perqty"].Value);
                    }

                    //Y2金額總合計算成本或報價不良率金額計算
                    if(newcost == "Y2" || newcost.Substring(0,1)=="N")
                    {
                        //材料名第一個字為包/裝/運/不的不記入不良率.
                        strSQL = $@"select Sum(pri_cost) as cost
                                    from   pri
                                    where  pri_customerid = '{txtID.Text}'
                                           and pri_part <> ''
                                           and Substring(pri_part, 1, 1) not in ( '包', '裝', '運', '不', '調' )
                                           and pri_part not like '%才' ";
                        double tcost = 0;
                        dt=clsDB.sql_select_dt(strSQL);
                        if(dt.Rows.Count>0)
                        {
                            tcost = Convert.ToDouble(dt.Rows[0]["cost"]);
                            sumc = tcost * Convert.ToDouble(dgvData.Rows[sumci].Cells["pri_tbprice"].Value) * Convert.ToDouble(dgvData.Rows[sumci].Cells["pri_perqty"].Value);
                        }

                        dgvData.Rows[sumci].Cells["pri_cost"].Value=sumc.ToString("0.######");
                    }
                }

                //預防分母為0的錯誤
                if (tcol2 != 0)
                {
                    //新材料價金額處理
                    sum1 = tcol3 / tcol2 + suma + sumb + sumc;
                }
                else
                {
                    //新材料價金額處理
                    sum1 = suma + sumb + sumc;
                }
                sum2 = tcol3 + suma + sumb + sumc + sumd + sume; //+ sumf //舊材料價金額處理
                sum3 = tcol3 / 1000 + sumd ;    //焊工補貼成本
                sum4 = tcol3 / 4500000 ;    //抽線耗材成本
                sum5 = tcol3 / 1000 ;   //無鹵料成本
                sum6 = (sume / 2 + tcol3) / 4 / 2740 ;  //鋁箔線材附加成本,原始計算式=>(sume/2+tcol3)/4/27.4/100
                sum7 = (tcol3 / 5 / 2740) + (sume / 2 / 2740) ; //銅箔線材附加成本,原始計算式=>((tcol3/5/27.4/100)+(sume/2/27.4/100)
                sum8 = (sumf1 + sumf * 0.104 / 70) / 100 ;  //熱縮套管成本,((有百分比的金額加總)+(沒百分比的加總)/70*10.4) /100 /100

                if(tcol3!=0 && dgvData.Rows.Count>0)
                {
                    sum11 = tcol3 / dgvData.Rows.Count; //平均成本
                }
                getDisplay(newcost);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-checkPrice" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string checkOdi(string strID)
        {
            //檢查參照法差異
            //回傳值:00->查無資料,11->包材料數量一致,A0->包材料名差異,1A->包數量差異,22->裝材料數量一致,B0->裝材料差異,2B->裝數量差異,33->運材料數量一致,C0->運材料差異,3C->運數量差異,44->不良率一致,4D->不良率差異
            try
            {
                string strTmp = "";
                string strSum = "0";
                string strSum1 = "0";
                string strSum2 = "0";
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select odi_customerid,
                                   Isnull(odi_xz, 0) 'odi_xz',
                                   odi_pripart01,
                                   odi_pripart05,
                                   odi_priqty01,
                                   odi_priqty05
                            from   odi
                            where  odi_customerid = '{strID}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0)
                {
                    if (Convert.ToDouble(dt.Rows[0]["odi_xz"]) ==0)
                    {
                        if(dt.Rows[0]["odi_pripart01"].ToString()!="")
                        {
                            if(dt.Rows[0]["odi_pripart01"].ToString() != dt.Rows[0]["odi_xz"].ToString() )
                            {
                                strSum2 = "1";
                            }
                        }
                        if (dt.Rows[0]["odi_pripart05"].ToString() != "")
                        {
                            if (dt.Rows[0]["odi_pripart05"].ToString() != dt.Rows[0]["odi_xz"].ToString())
                            {
                                strSum2 = "1";
                            }
                        }
                    }
                    else
                    {
                        strSum2 = "0";
                    }
                }

                strSQL = $@"select odi_customerid,
                                   case
                                     when Isnull(odi_pripart02, '') = Isnull(a01.pri_part, '空白') then odi_pripart02
                                     when Isnull(odi_pripart02, '') = '' then '無包材料'
                                     else '差異'
                                   end                               as '包材料',
                                   case
                                     when Isnull(a01.pri_perqty, 0) = Isnull(odi_priqty02, 0) then Isnull(a01.pri_perqty, 0)
                                     else '-1'
                                   end                               as '包數量',
                                   case
                                     when Isnull(odi_pripart01, '') = Isnull(a02.pri_part, '空白') then odi_pripart01
                                     when Isnull(odi_pripart01, '') = '' then '無裝材料'
                                     else '差異'
                                   end                               as '裝材料',
                                   case
                                     when Isnull(a02.pri_perqty, 0) = Isnull(odi_priqty01, 0) then Isnull(a02.pri_perqty, 0)
                                     else '-1'
                                   end                               as '裝數量',
                                   case
                                     when Isnull(odi_pripart05, '') = Isnull(a03.pri_part, '空白') then odi_pripart05
                                     when Isnull(odi_pripart05, '') = '' then '無運材料'
                                     else '差異'
                                   end                               as '運材料',
                                   case
                                     when Isnull(a03.pri_perqty, 0) = Isnull(odi_priqty05, 0) then Isnull(a03.pri_perqty, 0)
                                     else '-1'
                                   end                               as '運數量',
                                   Round(Isnull(odi_priqty04, 0), 4) '不良',
                                   case
                                     when Round(Isnull(a04.pri_perqty, 0), 0) = Round(Isnull(odi_priqty04, 0) * 100, 0) then Isnull(a04.pri_perqty, 0)
                                     else '-1'
                                   end                               as '不良率'
                            from   odi
                                   left join (select pri_part, pri_perqty, pri_customerid from pri) as a01
                                          on a01.pri_customerid = '{txtID.Text}'
                                             and a01.pri_part = odi_pripart02
                                             and a01.pri_part like '包%'
                                   left join (select pri_part, pri_perqty, pri_customerid from pri) as a02
                                          on a02.pri_customerid = '{txtID.Text}' 
                                             and a02.pri_part = odi_pripart01
                                             and a02.pri_part like '裝%'
                                   left join (select pri_part, pri_perqty, pri_customerid from pri) as a03
                                          on a03.pri_customerid = '{txtID.Text}' 
                                             and a03.pri_part = odi_pripart05
                                             and a03.pri_part like '運%'
                                   left join (select pri_part, pri_perqty, pri_customerid from pri) as a04
                                          on a04.pri_customerid = '{txtID.Text}' 
                                             and a04.pri_part = odi_pripart04
                                             and a04.pri_part like '不良%'
                            where  odi_customerid = '{strID}' ";
                dt=clsDB.sql_select_dt(strSQL);
                if( dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["包材料"].ToString()== "差異")
                    {
                        strTmp = "A0";
                        strSum  = "1";
                    }
                    else if(Convert.ToDouble(dt.Rows[0]["包數量"]) < 0)
                    {
                        strTmp = "1A";
                        strSum = "1";
                    }
                    else
                    {
                        strTmp = "11";
                    }

                    if (dt.Rows[0]["裝材料"].ToString() == "差異")
                    {
                        strTmp = "B0";
                        strSum = "1";
                    }
                    else if (Convert.ToDouble(dt.Rows[0]["裝數量"]) < 0)
                    {
                        strTmp = "2B";
                        strSum = "1";
                    }
                    else
                    {
                        strTmp = "22";
                    }

                    if (dt.Rows[0]["運材料"].ToString() == "差異")
                    {
                        strTmp = "C0";
                        strSum = "1";
                    }
                    else if (Convert.ToDouble(dt.Rows[0]["運數量"]) < 0)
                    {
                        strTmp = "3C";
                        strSum = "1";
                    }
                    else
                    {
                        strTmp = "33";
                    }

                    if (dt.Rows[0]["不良"].ToString() != "0")
                    {
                        if(Convert.ToDouble(dt.Rows[0]["不良率"]) < 0)
                        {
                            strTmp = strTmp + "4D";
                            strSum = "1";
                        }
                        else
                        {
                            strTmp = strTmp + "44";
                        }
                    }
                    else
                    {
                        strTmp = strTmp + "44";
                    }
                }
                else
                {
                    strTmp = "99999999";
                }

                strSQL = $@"select  odi_customerid,
                                    case
                                            when Isnull(odi_pripart02,'')=Isnull(p01.pri_part,'空白') then odi_pripart02
                                            when Isnull(odi_pripart02,'') = '' then '無包材料'
                                            else '差異'
                                    end as 'P包材料',
                                    case
                                            when Isnull(p01.pri_perqty,0) = Isnull(odi_priqty02,0) then Isnull(p01.pri_perqty,0)
                                            else '-1'
                                    end as 'P包數量',
                                    case
                                            when Isnull(odi_pripart01,'')=Isnull(p02.pri_part,'空白') then odi_pripart01
                                            when Isnull(odi_pripart01,'') = '' then '無裝材料'
                                            else '差異'
                                    end as 'P裝材料',
                                    case
                                            when Isnull(p02.pri_perqty,0) = Isnull(odi_priqty01,0) then Isnull(p02.pri_perqty,0)
                                            else '-1'
                                    end as 'P裝數量',
                                    case
                                            when Isnull(odi_pripart05,'')=Isnull(p03.pri_part,'空白') then odi_pripart05
                                            when Isnull(odi_pripart05,'') = '' then '無運材料'
                                            else '差異'
                                    end as 'P運材料',
                                    case
                                            when Isnull(p03.pri_perqty,0) = Isnull(odi_priqty05,0) then Isnull(p03.pri_perqty,0)
                                            else '-1'
                                    end as 'P運數量',
                                    Round(Isnull(odi_priqty04,0),4) '不良',
                                    case
                                            when Isnull(p04.pri_perqty,0) = Isnull(odi_priqty04,0)*100 then Isnull(p04.pri_perqty,0)
                                            else '-1'
                                    end as 'P不良率'
                        from odi
                        left join
                                    (
                                            select pri_customerid,
                                                pri_part,
                                                pri_perqty
                                            from   pri) as p01
                        on        p01.pri_customerid=odi_customerid
                        and       p01.pri_part=odi_pripart02
                        and       p01.pri_part like '包%'
                        left join
                                    (
                                            select pri_customerid,
                                                pri_part,
                                                pri_perqty
                                            from   pri) as p02
                        on        p02.pri_customerid=odi_customerid
                        and       p02.pri_part=odi_pripart01
                        and       p02.pri_part like '裝%'
                        left join
                                    (
                                            select pri_customerid,
                                                pri_part,
                                                pri_perqty
                                            from   pri) as p03
                        on        p03.pri_customerid=odi_customerid
                        and       p03.pri_part=odi_pripart05
                        and       p03.pri_part like '運%'
                        left join
                                    (
                                            select pri_customerid,
                                                pri_part,
                                                pri_perqty
                                            from   pri) as p04
                        on        p04.pri_customerid=odi_customerid
                        and       p04.pri_part=odi_pripart04
                        and       p04.pri_part like '不良%'
                        where     odi_customerid='{strID}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["P包材料"].ToString() == "差異")
                    {
                        strTmp = strTmp + "A0";
                        strSum1 = "1";
                    }
                    else if (Convert.ToDouble(dt.Rows[0]["P包數量"]) < 0)
                    {
                        strTmp = strTmp + "1A";
                        strSum1 = "1";
                    }
                    else
                    {
                        strTmp = strTmp + "11";
                    }

                    if (dt.Rows[0]["P裝材料"].ToString() == "差異")
                    {
                        strTmp = strTmp + "B0";
                        strSum1 = "1";
                    }
                    else if (Convert.ToDouble(dt.Rows[0]["P裝數量"]) < 0)
                    {
                        strTmp = strTmp + "2B";
                        strSum1 = "1";
                    }
                    else
                    {
                        strTmp = strTmp + "22";
                    }

                    if (dt.Rows[0]["P運材料"].ToString() == "差異")
                    {
                        strTmp = strTmp + "C0";
                        strSum1 = "1";
                    }
                    else if (Convert.ToDouble(dt.Rows[0]["P運數量"]) < 0)
                    {
                        strTmp = strTmp + "3C";
                        strSum1 = "1";
                    }
                    else
                    {
                        strTmp = strTmp + "33";
                    }

                    if (dt.Rows[0]["不良"].ToString() != "0")
                    {
                        if (Convert.ToDouble(dt.Rows[0]["P不良率"]) < 0)
                        {
                            strTmp = strTmp + "4D";
                            strSum1 = "1";
                        }
                        else
                        {
                            strTmp = strTmp + "44";
                        }
                    }
                    else
                    {
                        strTmp = strTmp + "44";
                    }
                }
                else
                {
                    strTmp = strTmp + "99999999";
                }
                if (strSum2 == "1")
                {
                    strSum="2"; 
                }
                return strSum + strSum1 + strTmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-checkOdi" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private void getCalculate()
        {
            //計算成本,希望買價,報價
            try
            {
                txtCost.Text = (txtTBCost.Text == "0" ? "0" : (Convert.ToDouble(txtTBCost.Text) / readCurconvert()).ToString("0.###") );
                txtHopePrice_Rate.Text = (txtHopePrice.Text == "" ? "0" : ((Convert.ToDouble(txtHopePrice.Text) - Convert.ToDouble(txtCost.Text)) * 100 / Convert.ToDouble(txtCost.Text)).ToString("0.#"));
                txtQuote_Rate.Text = (txtQuote_Rate.Text == "" ? "0" : ((Convert.ToDouble(txtQuote.Text) - Convert.ToDouble(txtCost.Text)) * 100 / Convert.ToDouble(txtCost.Text)).ToString("0.#"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getCalculate" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private double readCurconvert()
        {
            //讀取現有幣別匯率處理
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select cur_convert from cur where cur_code='{cboCurrency.Text}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToDouble(dt.Rows[0]["cur_convert"]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-readCurconvert" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        string pfenlei = "";
        string bom_oldcid = "";
        string Quote_Cal = "";
        string HopePrice_Cal = "";
        
        private void getClear()
        {
            //清除
            try
            {
                pfenlei = "";
                bom_oldcid = "";
                clear_dgvData();
                txtTBCost.Text = "0";
                txtCustomer.Text = "";
                txtID.Text = "";
                txtID.ForeColor = Color.FromArgb(0, 0, 0);
                txtName.Text = "";
                //Panel_M的
                txtID.Text = "";
                txtID.ForeColor = Color.FromArgb(0, 0, 0);
                txtName.Text = "";
                //
                txtLength.Text = "";
                txtQuote.Text = "0";
                txtQuote_Rate.Text = "0";
                Quote_Cal = "";
                txtHopePrice.Text = "0";
                txtHopePrice_Rate.Text = "0";
                HopePrice_Cal = "";
                lblCZF.Text = "";   //顯示參照法是否有異動
                cboCurrency.Text = "US$";
                chkOutsourcing.Checked = false;
                chkPower.Checked = false;
                chkNote.Checked = false;
                chkLarge.Checked = false;
                chkClassify.Checked = false;
                chkSpecial.Checked = false;
                chkCheck.Checked = false;   //審核

                tsave = true;   //檢查是否已儲存旗標,設為已儲存
                oldpid = "";    //記錄已讀取的客號
                if(chkMaterial.Checked)
                {
                    len_unit = "PC";
                    radioMeter.Checked = true;
                }
                else
                {
                    len_unit = "";
                    radioFeet.Checked = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getClear" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkMaterial_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMaterial.Checked)
            {
                chkSpecial.Visible = false;
            }
            else
            {
                chkSpecial.Visible = true;
            }
        }
        double sum1 = 0;
        double sum2 = 0;
        double sum3 = 0;
        double sum4 = 0;
        double sum5 = 0;
        double sum6 = 0;
        double sum7 = 0;
        double sum8 = 0;
        double sum9 = 0;
        double sum10 = 0;
        double sum11 = 0;

        private void getDisplay(string chk)
        {
            //畫面顯示
            try
            {
                if(chkMaterial.Checked==true)
                {
                    this.Text = "材料單";
                    radioFeet.Visible = false;
                    radioMeter.Visible = false;
                    radioInch.Visible = false;
                    panel.Visible = false;
                    panel_M.Visible = true;
                    pnlID_M.Controls.Add(txtID);
                    txtID.Dock = DockStyle.Fill;
                    pnlName_M.Controls.Add(txtName);
                    txtName.Dock = DockStyle.Fill;
                    btnUpLevel.Visible = true;
                    btnDownLevel.Visible = false;
                    btnOrder.Visible = false;
                    btnCFZ.Visible = false;
                    cboUnit.Text = len_unit;
                    if (chk == "Y1")
                    {
                        cboCostMode.Text = "膠粒成本";
                        txtTBCost.Text = sum1.ToString("0.######");
                    }
                    if (chk == "Y2")
                    {
                        cboCostMode.Text = "一般成本";
                        if (len_unit != "Feet")
                        {
                            txtTBCost.Text = sum2.ToString("0.######");
                        }
                        else
                        {
                            txtTBCost.Text = (sum2 / 3.28084).ToString("0.######");
                        }
                    }
                    if (chk == "Y3")
                    {
                        cboCostMode.Text = "焊錫成本";
                        txtTBCost.Text = sum3.ToString("0.######");
                    }
                    if (chk == "Y4")
                    {
                        cboCostMode.Text = "抽線耗材";
                        txtTBCost.Text = sum4.ToString("0.######");
                    }
                    if (chk == "Y5")
                    {
                        cboCostMode.Text = "無鹵料";
                        txtTBCost.Text = sum5.ToString("0.######");
                    }
                    if (chk == "Y6")
                    {
                        cboCostMode.Text = "鋁箔附加";
                        txtTBCost.Text = sum6.ToString("0.######");
                    }
                    if (chk == "Y7")
                    {
                        cboCostMode.Text = "銅箔附加";
                        txtTBCost.Text = sum7.ToString("0.######");
                    }
                    if (chk == "Y8")
                    {
                        cboCostMode.Text = "熱縮套管";
                        txtTBCost.Text = sum8.ToString("0.######");
                    }
                    if (chk == "Y9")
                    {
                        cboCostMode.Text = "相乘計算";
                        txtTBCost.Text = sum9.ToString("0.######");
                    }
                    if (chk == "Y10")
                    {
                        cboCostMode.Text = "相除計算";
                        txtTBCost.Text = sum10.ToString("0.######");
                    }
                    if (chk == "Y11")
                    {
                        cboCostMode.Text = "平均成本";
                        txtTBCost.Text = sum11.ToString("0.######");
                    }
                }
                else
                {
                    this.Text = "報價單";
                    radioFeet.Visible = true;
                    radioMeter.Visible = true;
                    radioInch.Visible = true;
                    panel.Visible = true;
                    panel_M.Visible = false;
                    pnlID.Controls.Add(txtID);
                    txtID.Dock = DockStyle.Fill;
                    pnlName.Controls.Add(txtName);
                    txtName.Dock = DockStyle.Fill;
                    btnUpLevel.Visible = false;
                    btnDownLevel.Visible = false;
                    btnOrder.Visible = true;
                    btnCFZ.Visible = true;
                    if(sum2!=0)
                    {
                        txtTBCost.Text = sum2.ToString("0.######");
                    }
                }
                if(dgvData.Rows.Count>1)
                {
                    if (dgvData.Rows[0].Cells["asp_name"].Value.ToString()=="Y")
                    {
                        btnDownLevel.Visible=true;
                    }
                    else
                    {
                        btnDownLevel.Visible=false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getDisplay" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQty_Enter(object sender, EventArgs e)
        {
            txtQty.Text = "";
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                MessageBox.Show("不可輸入特殊字元< ' >!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.KeyChar = (char)0;   //處理非法字符
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGet.Focus();
            }
        }
        
        private void txtQty_Leave(object sender, EventArgs e)
        {
            try
            {
                strQTY = "";
                if (txtQty.Text == "")
                {
                    txtQty.Text = "0";
                }
                else
                {
                    strQTY = txtQty.Text;
                    //計算式  計算機 引用using System.Data
                    txtQty.Text = new DataTable().Compute(txtQty.Text, null).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-txtQty_Leave" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtID.Text = txtID.Text.TrimEnd((char[])"/n/r".ToCharArray()).Trim();  //去ENTER 換行 空白
                txtName.Focus();
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

        private void txtID_Leave(object sender, EventArgs e)
        {
            //客號欄位處理
            try
            {
                //listID.Clear(); //初始化
                string strSQL = "";
                DataTable dt = new DataTable();
                if (txtID.Text != "")
                {
                    txtID.Text = txtID.Text.TrimEnd((char[])"/n/r".ToCharArray()).Trim();  //去ENTER 換行 空白
                    if (chkMaterial.Checked == false)
                    {
                        //檢查有沒有特選材料
                        strSQL = $@"select pri_customerid,
                                    pri_newcostchk
                            from   pri
                            where  pri_customerid = '{txtID.Text}'
                                    and pri_firstname = '其它料'
                                    and pri_newcostchk like 'N%' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            chkSpecial.Checked = true;
                        }
                        else
                        {
                            chkSpecial.Checked = false;
                        }

                        //若客號也是材料名時則把客號變成藍字
                        strSQL = $@"select distinct pri_customerid,
                                            pri_newcostchk
                            from   pri
                            where  pri_customerid = '{txtID.Text}'
                                    and pri_newcostchk like 'Y%' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            txtID.ForeColor = Color.FromArgb(0, 0, 255);
                        }
                        else
                        {
                            txtID.ForeColor = Color.FromArgb(0, 0, 0);
                        }

                        //若材料名有/vn或/vc的材料時,則把材料名變成紅字
                        strSQL = $@"select distinct pri_customerid
                            from   pri
                            where  pri_newcostchk like 'Y%'
                                    and pri_customerid in (select distinct Left(pri_customerid, Len(
                                                                            pri_customerid) - 3)
                                                            from   pri
                                                            where  pri_newcostchk like 'Y%'
                                                                    and ( pri_customerid like '%/vn' )) ";
                        if (txtID.Text.Substring(txtID.Text.Length - 3, 3) == "/vn")
                        {
                            strSQL = strSQL + $@"and pri_customerid= '{txtID.Text.Substring(0, txtID.Text.Length - 3)}'";
                        }
                        else
                        {
                            strSQL = strSQL + $@"and pri_customerid= '{txtID.Text}'";
                        }
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            txtID.ForeColor = Color.FromArgb(255, 0, 0);
                        }
                    }
                    else
                    {
                        //若客號也是材料名時則把客號變成藍字
                        strSQL = $@"select distinct pri_customerid,
                                            pri_newcostchk
                            from   pri
                            where  pri_customerid = '{txtID.Text}'
                                    and pri_newcostchk like 'N%' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            txtID.ForeColor = Color.FromArgb(0, 0, 255);
                            toolTip1.SetToolTip(txtID, "有相同的 客號/材料名");
                        }
                        else
                        {
                            txtID.ForeColor = Color.FromArgb(0, 0, 0);
                            toolTip1.SetToolTip(txtID, "");
                        }

                        //若材料名有/vn或/vc的材料時,則把材料名變成紅字
                        strSQL = $@"select distinct pri_customerid
                                from            pri
                                where           pri_newcostchk like 'Y%'
                                and             pri_customerid in
                                                                    (
                                                                    select distinct left(pri_customerid,Len(pri_customerid)-3)
                                                                    from            pri
                                                                    where           pri_newcostchk like 'Y%'
                                                                    and             (
                                                                                                    pri_customerid like '%/vn'
                                                                                    or              pri_customerid like '%/vc')) ";
                        if (txtID.Text.Substring(txtID.Text.Length - 3, 3) == "/vc" || txtID.Text.Substring(txtID.Text.Length - 3, 3) == "/vn")
                        {
                            strSQL = strSQL + $@"and pri_customerid= '{txtID.Text.Substring(0, txtID.Text.Length - 3)}'";
                        }
                        else
                        {
                            strSQL = strSQL + $@"and pri_customerid= '{txtID.Text}'";
                        }
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            txtID.ForeColor = Color.FromArgb(255, 0, 0);
                            toolTip1.SetToolTip(txtID, "有相同的/vn或/vc材料");
                        }
                        else
                        {
                            txtID.ForeColor = Color.FromArgb(0, 0, 0);
                            toolTip1.SetToolTip(txtID, "");
                        }
                    }
                    //檢查客號如果不是空白,則開始執行讀取資料
                    getData();
                    //Label20.Caption = 0
                    blnPriceChange = false;
                    getCalculate();

                }
                //DataGrid5.Row = 0
                tsave = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-txtID_Leave" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownLevel_Click(object sender, EventArgs e)
        {
            //展開下層資料
            try
            {
                string strID = dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["pri_part"].Value.ToString();
                if(strID == "人工成本/分")
                {
                    //人工成本設定表單未完成
                }
                if (strID == "工廠成本/分")
                {
                    //人工成本設定表單未完成
                }
                if (strID == "社保/月")
                {
                    //人工成本設定表單未完成
                }
                if (strID == "人工成本/分/vn")
                {
                    //人工成本設定表單未完成
                }
                if (strID == "工廠成本/分/vn")
                {
                    //人工成本設定表單未完成
                }
                if (strID == "焊工補貼")
                {
                    //人工成本設定表單未完成
                }
                //儲存ID,上層材料單搜尋用
                if (newcost.Trim() == "N")
                {
                    if(txtID.Text!="")
                    {
                        string[] tmp = { "N" + txtID.Text, txtName.Text };
                        listID.Add(tmp);
                    }
                    else
                    {
                        //MessageBox.Show("客號空白", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return;
                    }
                }
                else
                {
                    string[] tmp = { "Y" + txtID.Text, txtName.Text };
                    listID.Add(tmp);
                }
                chkMaterial.Checked = true;
                txtID.Text = strID;
                txtName.Text = "";
                btnDownLevel.Visible = false;
                btnUpLevel.Visible = true;
                txtID_Leave(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDownLevel_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //顯示目前點選第幾項
            try
            {
                //if (string.IsNullOrEmpty( dgvData.Rows[e.RowIndex].Cells["pri_part"].Value.ToString())==false)
                if (dgvData.Rows.Count == 1 || e.RowIndex == dgvData.Rows.Count - 1)    //空白GRID防呆不動作
                {
                    return;
                }
                if (string.IsNullOrEmpty((string)dgvData.Rows[e.RowIndex].Cells["pri_part"].Value) == false)
                {
                    if (dgvData.Rows[e.RowIndex].Cells["asp_name"].Value.ToString() == "Y")
                    {
                        btnDownLevel.Visible = true;
                    }
                    else
                    {
                        btnDownLevel.Visible = false;
                    }
                }
                else
                {
                    btnDownLevel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                MessageBox.Show("不可輸入特殊字元< ' >!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.KeyChar = (char)0;   //處理非法字符
            }
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (dgvData.Rows[dgvData.CurrentCell.RowIndex].Cells["pri_part"].Value.ToString().Length>30)
            {
                MessageBox.Show("已超過名稱最大長度30個字元限制!無法繼續輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //第五層資料單身處理
            try
            {
                if (dgvData.Rows.Count == 1)    //空白GRID防呆不動作
                {
                    return;
                }
                string vendorid = "";
                string adddate = "";
                string vendormaterialno = "";
                string salesprice = "";
                string currency = "";
                string purprice = "";
                string user = "";
                string czf = "";
                string tjjz = "";
                string um = "";
                string name = "";    //是否有材料單旗標
                string line = ""; //越南運費計重
                string ulflag = "";   //UL標記
                string pricecal = ""; //火車頭單價計算式
                string name3 = "";    //ap3_assy
                string name2 = "";    //ap2_assy
                string name1 = "";    //ap1_assy


                //處理數量;數量計算式string.IsNullOrEmpty((string)dgvData.Rows[e.RowIndex].Cells["pri_part"].Value
                if (string.IsNullOrEmpty( dgvData.Rows[e.RowIndex].Cells["pri_perqty"].Value.ToString())== false && e.ColumnIndex==2)
                {
                    InputBox input = new InputBox();
                    input.ShowInTaskbar = false;//圖示不顯示在工作列
                    input.lblInfo.Text = "輸入數量計算式:";
                    input.Text = "計算";
                    if(string.IsNullOrEmpty((string)dgvData.Rows[e.RowIndex].Cells["pri_perqtycal"].Value) ==false)
                    {
                        input.txtIpnut.Text = dgvData.Rows[e.RowIndex].Cells["pri_perqtycal"].Value.ToString();
                    }
                    
                    DialogResult dr = input.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        if (input.GetMsg() != "")
                        {
                            dgvData.Rows[e.RowIndex].Cells["pri_perqtycal"].Value = input.GetMsg();
                            dgvData.Rows[e.RowIndex].Cells["pri_perqty"].Value= new DataTable().Compute(input.GetMsg(), null).ToString();
                            dgvData.Rows[e.RowIndex].Cells[0].Selected = true;
                        }
                    }
                    blnCal = true;
                    DoCellEdit(e.RowIndex,e.ColumnIndex);
                    return;
                }

                //檢查材料名是否在BOM裡
                string strSQL = "";
                DataTable dt =new DataTable();
                strSQL = $@"select ap3_assy from ap3 where ap3_part='{dgvData.Rows[e.RowIndex].Cells["pri_part"].Value.ToString()}'";
                dt=clsDB.sql_select_dt(strSQL);
                //材料名有在BOM裡
                if (dt.Rows.Count > 0)
                {
                    name3 = dt.Rows[0]["ap3_assy"].ToString();
                    strSQL = $@"select ap2_assy from ap2 where ap2_part='{name3}'";
                    dt = clsDB.sql_select_dt(strSQL);
                    if(dt.Rows.Count > 0)
                    {
                        name2 = dt.Rows[0]["ap2_assy"].ToString();
                        strSQL = $@"select ap1_assy from ap1 where ap1_part='{name2}'";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            name1 = dt.Rows[0]["ap1_assy"].ToString();
                        }
                        else
                        {
                            name1 = "";
                        }
                        strSQL = $@"select asp_vendorid,
                                           asp_adddate,
                                           asp_vendormaterialno,
                                           asp_salesprice,
                                           asp_currency,
                                           asp_purprice as purprice,
                                           asp_user,
                                           asp_czf,
                                           asp_tjjz,
                                           asp_name,
                                           asp_line,
                                           asp_lengum,
                                           asp_pricecal,
                                           asp_um
                                    from   asp
                                    where  asp_id = '{dgvData.Rows[e.RowIndex].Cells["pri_part"].Value.ToString()}' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            vendorid = dt.Rows[0]["asp_vendorid"].ToString();
                            adddate = dt.Rows[0]["asp_adddate"].ToString();
                            vendormaterialno = dt.Rows[0]["asp_vendormaterialno"].ToString();
                            salesprice = dt.Rows[0]["asp_salesprice"].ToString();
                            currency = dt.Rows[0]["asp_currency"].ToString();
                            purprice = dt.Rows[0]["purprice"].ToString();
                            user = dt.Rows[0]["asp_user"].ToString();
                            czf = dt.Rows[0]["asp_czf"].ToString();
                            tjjz = dt.Rows[0]["asp_tjjz"].ToString();
                            name = (dt.Rows[0]["asp_name"].ToString() == "Y" ? "Y" : "N");   //是否有材料單旗標
                            line = (dt.Rows[0]["asp_line"].ToString() == "Y" ? "Y" : "N");   //越南運費計重
                            ulflag = (dt.Rows[0]["asp_lengum"].ToString() == "Y" ? "Y" : "N");   //UL標記
                            pricecal = dt.Rows[0]["asp_pricecal"].ToString();   //火車頭單價計算式
                            um = dt.Rows[0]["asp_um"].ToString();
                        }
                        else
                        {
                            vendorid = "";
                            adddate = "";
                            vendormaterialno = "";
                            salesprice = "";
                            currency = "";
                            purprice = "";
                            user = "";
                            czf = "";
                            tjjz = "";
                            name = "N";   //是否有材料單旗標
                            line = (dgvData.Rows[e.RowIndex].Cells["asp_line"].ToString() == "Y" ? "Y" : "N");   //越南運費計重
                            ulflag = "N";   //UL標記
                            pricecal = "";   //火車頭單價計算式
                            um = "";
                        }
                    }
                    else
                    {
                        name1 = "";
                        name2 = "";
                        vendorid = "";
                        adddate = "";
                        vendormaterialno = "";
                        salesprice = "";
                        currency = "";
                        purprice = "";
                        vendorid = "";
                        czf = "";
                        tjjz = "";
                        name = "N";   //是否有材料單旗標
                        line = (dgvData.Rows[e.RowIndex].Cells["asp_line"].ToString() == "Y" ? "Y" : "N");   //越南運費計重
                        ulflag = "N";   //UL標記
                        pricecal = "";   //火車頭單價計算式
                        um = "";
                    }

                    if(name=="Y")
                    {
                        frmBOMPrice_Msgbox frmBOMPrice_Msgbox = new frmBOMPrice_Msgbox();
                        frmBOMPrice_Msgbox.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmBOMPrice_Msgbox.rtxtMsg.Text = $@"[該名稱的路徑為: {name1} -> {name2} -> {name3} -> {dgvData.Rows[e.RowIndex].Cells[0].Value.ToString()}]"
                                                            + "\n" + $@"[品號:{vendormaterialno}], [廠商:{vendorid}]"
                                                            + "\n" + $@"[最后存盤日期:{Convert.ToDateTime( adddate).ToString("yyyy/MM/dd")}], [用戶名:{user}]"
                                                            + "\n" + $@"[單價:{currency}{purprice}], [單價計算式:{pricecal}], [單位:{um}]"
                                                            + "\n" + $@"[是否有材料單:{name }], [越南運費計重:{line}], [UL標記:{ulflag}]"
                                                            + "\n" + $@"參照法:"
                                                            + "\n" + $@"{czf}"
                                                            + "\n" + $@"此材料有材料單要進入查詢嗎?";
                        frmBOMPrice_Msgbox.btnOK.Visible = true;
                        frmBOMPrice_Msgbox.btnNG.Visible = true;
                        frmBOMPrice_Msgbox.btnOK.Text = "是(Y)";
                        frmBOMPrice_Msgbox.btnNG.Text = "否(N)";
                        frmBOMPrice_Msgbox.ShowDialog();
                        if (rstrMsg == "OK")
                        {
                            //儲存ID,上層材料單搜尋用
                            if (newcost.Trim() == "N")
                            {
                                string[] tmp = { "N" + txtID.Text, txtName.Text };
                                listID.Add(tmp);
                            }
                            else
                            {
                                string[] tmp = { "Y" + txtID.Text, txtName.Text };
                                listID.Add(tmp);
                            }
                            txtID.Text = dgvData.Rows[e.RowIndex].Cells[0].Value.ToString();
                            txtName.Text = "";
                            chkMaterial.Checked = true;
                            getData();
                        }
                    }
                    else
                    {
                        frmBOMPrice_Msgbox frmBOMPrice_Msgbox = new frmBOMPrice_Msgbox();
                        frmBOMPrice_Msgbox.ShowInTaskbar = false;//圖示不顯示在工作列
                        frmBOMPrice_Msgbox.rtxtMsg.Text = $@"[該名稱的路徑為: {name1} -> {name2} -> {name3} -> {dgvData.Rows[e.RowIndex].Cells[0].Value.ToString()}]"
                                                            + "\n" + $@"[品號:{vendormaterialno}], [廠商:{vendorid}]"
                                                            + "\n" + $@"[最后存盤日期:{Convert.ToDateTime(adddate).ToString("yyyy/MM/dd")}], [用戶名:{user}]"
                                                            + "\n" + $@"[單價:{currency}{purprice}], [單價計算式:{pricecal}], [單位:{um}]"
                                                            + "\n" + $@"[是否有材料單:{name}], [越南運費計重:{line}], [UL標記:{ulflag}]"
                                                            + "\n" + $@"參照法:"
                                                            + "\n" + $@"{czf}";
                        frmBOMPrice_Msgbox.btnOK.Visible=false;
                        frmBOMPrice_Msgbox.btnNG.Visible = true;
                        frmBOMPrice_Msgbox.btnOK.Text = "";
                        frmBOMPrice_Msgbox.btnNG.Text = "確定";
                        frmBOMPrice_Msgbox.ShowDialog();
                    }
                }
                else   //材料名沒有在BOM裡
                {
                    //檢查材料名有沒有在特選裡
                    strSQL = $@"select *,
                                       Isnull(ven_shortname, '') '廠商'
                                from   ptx
                                       left join ven
                                              on ven_id = ptx_vendorid
                                where  ptx_name = '{dgvData.Rows[e.RowIndex].Cells["pri_part"]}'
                                       and ptx_customerid = '{txtID.Text}' ";
                    dt = clsDB.sql_select_dt(strSQL);   
                    if(dt.Rows.Count > 0)
                    {
                        MessageBox.Show("有特選,尚未完成程式!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("無特選,尚未完成程式!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellDoubleClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvData.Rows.Count == 1)    //空白GRID防呆不動作
                {
                    return;
                }
                DoCellEdit(e.RowIndex, e.ColumnIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellEndEdit" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoCellEdit(int RowIndex, int ColumnIndex)
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                //檢查是否有修改單價,若有則記錄起來,做為判斷不能給予儲存
                if (ColumnIndex == 1)
                {
                    blnPriceChange = true;
                }

                //檢查材料名稱是否有變動修改
                if (ColumnIndex == 0 && string.IsNullOrEmpty((string)dgvData.Rows[RowIndex].Cells[0].Value) == false)
                {
                    //檢查該材料名是否有被選(重複)
                    string tmpID = dgvData.Rows[RowIndex].Cells[0].Value.ToString();
                    int count = 0;
                    for (int i = 0; i < dgvData.Rows.Count - 1; i++)
                    {
                        if (dgvData.Rows[i].Cells[0].Value.ToString() == tmpID)
                        {
                            count = count + 1;
                        }
                    }
                    if (count > 1)//如果材料名已存在,則告知有被選過,並不予處理
                    {
                        MessageBox.Show("這個名稱已經被選擇,請刪除這行!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvData.Rows[RowIndex].Cells[0].Value = "";
                        return;
                    }
                    else
                    {
                        //取得材料價格和幣
                        string tmpCurrency = "";    //幣別
                        double tmpPurprice = 0;     //單價
                        double tmpConvert = 0;      //匯率
                        double tmpConvert_CN = 0;      //大陸匯率
                        strSQL = $@"select asp_purprice,
                                       asp_currency,
                                       asp_name
                                from   asp
                                where  asp_id = '{dgvData.Rows[RowIndex].Cells[0].Value.ToString()}' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)//如果有找到該材料則開始處理匯率換算
                        {
                            tmpCurrency = dt.Rows[0]["asp_currency"].ToString();
                            tmpPurprice = Convert.ToDouble(dt.Rows[0]["asp_purprice"]);
                            //檢查材料是否有越南運費計重註記
                            strSQL = $@"select asp_line,
                                           Isnull(asp_name, '') 'asp_name',
                                           asp_vnweight,
                                           asp_vnpcs,
                                           asp_um
                                    from   asp
                                    where  asp_id = '{dgvData.Rows[RowIndex].Cells[0].Value.ToString()}' ";
                            dt = clsDB.sql_select_dt(strSQL);
                            if (dt.Rows.Count > 0)
                            {
                                dgvData.Rows[RowIndex].Cells[8].Value = dt.Rows[0]["asp_name"].ToString();
                                if (dgvData.Rows[RowIndex].Cells[8].Value.ToString() == "Y")
                                {
                                    dgvData.Rows[RowIndex].Cells[4].Value = "下";
                                }
                                if (dt.Rows[0]["asp_line"].ToString() == "")
                                {
                                    dgvData.Rows[RowIndex].Cells[7].Value = "1";
                                }
                                else
                                {
                                    dgvData.Rows[RowIndex].Cells[7].Value = dt.Rows[0]["asp_line"].ToString();
                                }
                                dgvData.Rows[RowIndex].Cells[9].Value = (string.IsNullOrEmpty(dt.Rows[0]["asp_vnweight"].ToString()) == true ? "0" : dt.Rows[0]["asp_vnweight"].ToString());
                                dgvData.Rows[RowIndex].Cells[10].Value = (string.IsNullOrEmpty(dt.Rows[0]["asp_vnpcs"].ToString()) == true ? "0" : dt.Rows[0]["asp_vnpcs"].ToString());
                                if ((dgvData.Rows[RowIndex].Cells[9].Value.ToString() == "0" || dgvData.Rows[RowIndex].Cells[10].Value.ToString() == "0")
                                    && dgvData.Rows[RowIndex].Cells[8].Value.ToString() == ""
                                    && dgvData.Rows[RowIndex].Cells[7].Value.ToString() == "Y"
                                    && dt.Rows[0]["asp_um"].ToString() != "KG"
                                    && chkMaterial.Checked)
                                {
                                    MessageBox.Show("此材料越南運費的重量和數量有異常,請到火車頭檢查!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                dgvData.Rows[RowIndex].Cells[7].Value = "";
                            }
                            //取得第一層名稱
                            strSQL = $@"select ap1_assy
                                    from   ap1
                                    where  ap1_part in (select ap2_assy
                                                        from   ap2
                                                        where  ap2_part in (select ap3_assy
                                                                            from   ap3
                                                                            where
                                                               ap3_part = '{dgvData.Rows[RowIndex].Cells[0].Value.ToString()}')) ";
                            dt = clsDB.sql_select_dt(strSQL);
                            if (dt.Rows.Count > 0)
                            {
                                dgvData.Rows[RowIndex].Cells[5].Value = dt.Rows[0]["ap1_assy"].ToString();
                            }
                            //取得幣別匯率
                            strSQL = $@"select cur_convert from cur where cur_code='{tmpCurrency}' ";
                            dt = clsDB.sql_select_dt(strSQL);
                            if (dt.Rows.Count > 0)
                            {
                                tmpConvert = Convert.ToDouble(dt.Rows[0]["cur_convert"]);
                                dgvData.Rows[RowIndex].Cells[1].Value = (tmpPurprice * tmpConvert).ToString("0.######");
                                dgvData.Rows[RowIndex].Cells[2].Value = 1;
                                dgvData.Rows[RowIndex].Cells[3].Value = (tmpPurprice * tmpConvert).ToString("0.######");
                                //計算不良率金額
                                if (dgvData.Rows[RowIndex].Cells[0].Value.ToString().Substring(0, 3) == "不良率")
                                {
                                    //計算不良率金額
                                    string[] strArray = { "包", "裝", "運", "不", "調" };
                                    string strValue = "";
                                    double tmpCost = 0; //不良率金額
                                    for (int i = 0; i < dgvData.Rows.Count - 1; i++)
                                    {
                                        if (dgvData.Rows[i].Cells[0].Value.ToString().Length >= 1)
                                        {
                                            strValue = dgvData.Rows[i].Cells[0].Value.ToString().Substring(0, 1);
                                            int index = Array.IndexOf(strArray, strValue);
                                            if (index == -1)//不屬於{ "包", "裝", "運", "不", "調" }
                                            {
                                                tmpCost = tmpCost + Convert.ToDouble(dgvData.Rows[i].Cells[3].Value);
                                            }
                                        }
                                    }
                                    dgvData.Rows[RowIndex].Cells[3].Value = (tmpCost == 0 ? "0" : (tmpCost * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value)).ToString("0.######"));
                                }
                            }
                            else//如果查不到匯率則直接以材料價顯示
                            {
                                dgvData.Rows[RowIndex].Cells[1].Value = tmpPurprice;
                                dgvData.Rows[RowIndex].Cells[2].Value = 1;
                                dgvData.Rows[RowIndex].Cells[3].Value = tmpPurprice;
                            }

                            //先得到人民幣匯率,再算稅
                            strSQL = $@"select cur_convert from cur where cur_code = '人民幣' ";
                            dt = clsDB.sql_select_dt(strSQL);
                            if (dt.Rows.Count > 0)
                            {
                                tmpConvert_CN = Convert.ToDouble(dt.Rows[0]["cur_convert"]);
                            }

                            if (dgvData.Rows[RowIndex].Cells[0].Value.ToString() == "地稅(地方稅)")
                            {
                                dgvData.Rows[RowIndex].Cells[1].Value = (Convert.ToDouble(txtQuote.Text) * 0.03).ToString("0.######");
                                dgvData.Rows[RowIndex].Cells[3].Value = (Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value) * tmpConvert_CN).ToString("0.######");
                            }

                            if (dgvData.Rows[RowIndex].Cells[0].Value.ToString() == "國稅(增值稅)")
                            {
                                dgvData.Rows[RowIndex].Cells[1].Value = (Convert.ToDouble(txtQuote.Text) * 0.17).ToString("0.######");
                                dgvData.Rows[RowIndex].Cells[3].Value = (Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value) * tmpConvert_CN).ToString("0.######");
                            }
                        }
                        else
                        {
                            MessageBox.Show("沒有此材料,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvData.Rows[RowIndex].Cells[0].Value = "";
                            return;
                        }
                    }

                    checkPrice();//重新檢查材料價加總和不良率計算
                    getDisplay(newcost);
                    return;
                }
                //檢查數量是否有被修改
                if (ColumnIndex == 2 && string.IsNullOrEmpty((string)dgvData.Rows[RowIndex].Cells[0].Value) == false)
                {
                    //Check12.Value = 0
                    //changeDataGrid = True//
                    if (dgvData.Rows[RowIndex].Cells[2].Value.ToString() == "")
                    {
                        MessageBox.Show("數量不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (dgvData.Rows[RowIndex].Cells[2].Value.ToString() != "0")
                    {
                        if (blnCal == false)
                        {
                            dgvData.Rows[RowIndex].Cells[6].Value = dgvData.Rows[RowIndex].Cells[2].Value.ToString();
                            //計算式  計算機 引用using System.Data
                            dgvData.Rows[RowIndex].Cells[2].Value = Convert.ToDouble(new DataTable().Compute(dgvData.Rows[RowIndex].Cells[2].Value.ToString(), null)).ToString("0.######");
                        }
                        blnCal = false;
                    }

                    //檢查該筆是否為不良率
                    if (dgvData.Rows[RowIndex].Cells[0].Value.ToString().Substring(0, 3) == "不良率")
                    {
                        //計算不良率金額
                        string[] strArray = { "包", "裝", "運", "不", "調" };
                        string strValue = "";
                        double tmpCost = 0; //不良率金額
                        for (int i = 0; i < dgvData.Rows.Count - 1; i++)
                        {
                            if (dgvData.Rows[i].Cells[0].Value.ToString().Length >= 1)
                            {
                                strValue = dgvData.Rows[i].Cells[0].Value.ToString().Substring(0, 1);
                                int index = Array.IndexOf(strArray, strValue);
                                if (index == -1)//不屬於{ "包", "裝", "運", "不", "調" }
                                {
                                    tmpCost = tmpCost + Convert.ToDouble(dgvData.Rows[i].Cells[3].Value);
                                }
                            }
                        }
                        dgvData.Rows[RowIndex].Cells[3].Value = (tmpCost == 0 ? "0" : (tmpCost * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value)).ToString("0.######"));
                    }
                    else
                    {
                        if (dgvData.Rows[RowIndex].Cells[5].Value.ToString() != "其它料")
                        {
                            if (dgvData.Rows[RowIndex].Cells[0].Value.ToString().Substring(dgvData.Rows[RowIndex].Cells[0].Value.ToString().Length - 1, 1) == "才"
                                || dgvData.Rows[RowIndex].Cells[0].Value.ToString().Substring(0, 1) == "裝")
                            {
                                if (dgvData.Rows[RowIndex].Cells[2].Value.ToString() != "0")
                                {
                                    dgvData.Rows[RowIndex].Cells[3].Value = (Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) / Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value)).ToString("0.######");
                                }
                                else
                                {
                                    MessageBox.Show("數量不可為零,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                dgvData.Rows[RowIndex].Cells[3].Value = (Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value)).ToString("0.######");
                            }
                        }
                        else
                        {
                            dgvData.Rows[RowIndex].Cells[3].Value = (Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value)).ToString("0.######");
                        }
                    }
                    checkPrice();//檢查報價單身的價格加總
                    return;
                }

                //檢查單價是否有被修改
                if (ColumnIndex == 1 && dgvData.Rows[RowIndex].Cells[0].Value.ToString() != "")
                {
                    //檢查該筆是否為不良率
                    if (dgvData.Rows[RowIndex].Cells[0].Value.ToString().Substring(0, 3) == "不良率")
                    {
                        //計算不良率金額
                        string[] strArray = { "包", "裝", "運", "不", "調" };
                        string strValue = "";
                        double tmpCost = 0; //不良率金額
                        for (int i = 0; i < dgvData.Rows.Count - 1; i++)
                        {
                            if (dgvData.Rows[i].Cells[0].Value.ToString().Length >= 1)
                            {
                                strValue = dgvData.Rows[i].Cells[0].Value.ToString().Substring(0, 1);
                                int index = Array.IndexOf(strArray, strValue);
                                if (index == -1)//不屬於{ "包", "裝", "運", "不", "調" }
                                {
                                    tmpCost = tmpCost + Convert.ToDouble(dgvData.Rows[i].Cells[3].Value);
                                }
                            }
                        }
                        dgvData.Rows[RowIndex].Cells[3].Value = (tmpCost == 0 ? "0" : (tmpCost * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value)).ToString("0.######"));
                    }
                    else
                    {
                        if (dgvData.Rows[RowIndex].Cells[5].Value.ToString() != "其它料")
                        {
                            if (dgvData.Rows[RowIndex].Cells[0].Value.ToString().Substring(dgvData.Rows[RowIndex].Cells[0].Value.ToString().Length - 1, 1) == "才"
                                || dgvData.Rows[RowIndex].Cells[0].Value.ToString().Substring(0, 1) == "裝")
                            {
                                if (dgvData.Rows[RowIndex].Cells[2].Value.ToString() != "0")
                                {
                                    dgvData.Rows[RowIndex].Cells[3].Value = (Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) / Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value)).ToString("0.######");
                                }
                                else
                                {
                                    MessageBox.Show("數量不可為零,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                dgvData.Rows[RowIndex].Cells[3].Value = (Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value)).ToString("0.######");
                            }
                        }
                        else
                        {
                            dgvData.Rows[RowIndex].Cells[3].Value = (Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value)).ToString("0.######");
                        }
                    }
                    checkPrice();//檢查報價單身的價格加總
                    return;
                }

                //處理金額不可以直接更改警告訊息
                if (ColumnIndex == 3 && dgvData.Rows[RowIndex].Cells[0].Value.ToString() != "")
                {
                    MessageBox.Show("金額不可直接更改,請更改數量或單價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //檢查該筆是否為不良率
                    if (dgvData.Rows[RowIndex].Cells[0].Value.ToString().Substring(0, 3) == "不良率")
                    {
                        //計算不良率金額
                        string[] strArray = { "包", "裝", "運", "不", "調" };
                        string strValue = "";
                        double tmpCost = 0; //不良率金額
                        for (int i = 0; i < dgvData.Rows.Count - 1; i++)
                        {
                            if (dgvData.Rows[i].Cells[0].Value.ToString().Length >= 1)
                            {
                                strValue = dgvData.Rows[i].Cells[0].Value.ToString().Substring(0, 1);
                                int index = Array.IndexOf(strArray, strValue);
                                if (index == -1)//不屬於{ "包", "裝", "運", "不", "調" }
                                {
                                    tmpCost = tmpCost + Convert.ToDouble(dgvData.Rows[i].Cells[3].Value);
                                }
                            }
                        }
                        dgvData.Rows[RowIndex].Cells[3].Value = (tmpCost == 0 ? "0" : (tmpCost * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value)).ToString("0.######"));
                    }
                    else
                    {
                        if (dgvData.Rows[RowIndex].Cells[5].Value.ToString() != "其它料")
                        {
                            if (dgvData.Rows[RowIndex].Cells[0].Value.ToString().Substring(dgvData.Rows[RowIndex].Cells[0].Value.ToString().Length - 1, 1) == "才"
                                || dgvData.Rows[RowIndex].Cells[0].Value.ToString().Substring(0, 1) == "裝")
                            {
                                if (dgvData.Rows[RowIndex].Cells[2].Value.ToString() != "0")
                                {
                                    dgvData.Rows[RowIndex].Cells[3].Value = (Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) / Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value)).ToString("0.######");
                                }
                                else
                                {
                                    MessageBox.Show("數量不可為零,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                dgvData.Rows[RowIndex].Cells[3].Value = (Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value)).ToString("0.######");
                            }
                        }
                        else
                        {
                            dgvData.Rows[RowIndex].Cells[3].Value = (Convert.ToDouble(dgvData.Rows[RowIndex].Cells[1].Value) * Convert.ToDouble(dgvData.Rows[RowIndex].Cells[2].Value)).ToString("0.######");
                        }
                    }
                    checkPrice();//檢查報價單身的價格加總
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-DoCellEdit" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //if (e.Exception != null)
            //{
            //    if (e.ColumnIndex == 2)
            //    {
            //        dgvData.Rows[e.RowIndex].Cells[2].Value = 0;
            //    }
            //}
        }

        private void btnUpLevel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listID.Count > 0)
                {
                    string tmpID = listID[listID.Count - 1][0].ToString();
                    string tmpName = listID[listID.Count - 1][1].ToString();
                    if (tmpID.Substring(0, 1) == "N")
                    {
                        chkMaterial.Checked = false;
                    }
                    else
                    {
                        chkMaterial.Checked = true;
                    }
                    if (tmpID != "")
                    {
                        txtID.Text = tmpID.Substring(1, tmpID.Length - 1);
                        txtName.Text = tmpName;
                        listID.RemoveAt(listID.Count - 1);
                        getData();
                    }
                    else
                    {
                        MessageBox.Show("無上層材料單材料名!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("無上層材料單!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnUpLevel_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnInq_Click(object sender, EventArgs e)
        {

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                if (strLevel4_ID == "")
                {
                    MessageBox.Show("請選擇第四層名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //檢查選取的材料名是否同材料單的材料名
                if (dgvLevel_4.Rows[dgvLevel_4.CurrentCell.RowIndex].Cells["ap3_part"].Value.ToString()==txtID.Text && chkMaterial.Checked==true)
                {
                    MessageBox.Show("不可選取與材料單材料名相同的材料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgvLevel_4.Rows[dgvLevel_4.CurrentCell.RowIndex].Cells["ap3_part"].Value.ToString() == "稅票X17%" && txtQuote.Text == "0")
                {
                    MessageBox.Show("現在的報價資料為零,你不能選取稅票X17%!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgvLevel_4.Rows[dgvLevel_4.CurrentCell.RowIndex].Cells["ap3_part"].Value.ToString() == "佣金" && txtQuote.Text == "0")
                {
                    MessageBox.Show("現在的報價資料為零,你不能選取佣金資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //檢查該材料是否已有選過
                if(dgvData.Rows.Count > 1)
                {
                    for(int i = 0; i < dgvData.Rows.Count-1; i++)
                    {
                        if (dgvData.Rows[i].Cells["pri_part"].Value.ToString() == dgvLevel_4.Rows[dgvLevel_4.CurrentCell.RowIndex].Cells["ap3_part"].Value.ToString())
                        {
                            MessageBox.Show("你不能重復選取該產品,你已經有選取了該產品!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }

                //檢查數量是否為0
                if(txtQty.Text == "")
                {
                    txtQty.Text = "0";
                }
                if(txtQty.Text == "0")
                {
                    MessageBox.Show("數量為零不可以選取!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //長度單位檢查
                double tper = 1;        //長度
                string m_asp_um;    //單位
                strSQL = $@"select asp_um from asp where asp_id ='{strLevel4_ID}'";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0)
                {
                    m_asp_um = dt.Rows[0]["asp_um"].ToString();
                }
                else
                {
                    m_asp_um = "";
                }
                if(m_asp_um == "FT" || m_asp_um == "Feet")
                {
                    if (radioFeet.Checked)
                    {
                        tper = 1; //Feet 呎
                    }
                    if (radioMeter.Checked)
                    {
                        tper = 3.28; //Meter 米
                    }
                    if (radioInch.Checked)
                    {
                        tper = 0.0833; //Inch 英吋
                    }
                    if (tper != 1)
                    {
                        if(chkMaterial.Checked==false)
                        {
                            if (MessageBox.Show("此材料單位為呎Feet,您選擇的長度單位不是Feet,要繼續選取嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                }
                else if(m_asp_um == "M")
                {
                    if (radioFeet.Checked)
                    {
                        tper = 0.3048; //Feet 呎
                    }
                    if (radioMeter.Checked)
                    {
                        tper = 1; //Meter 米
                    }
                    if (radioInch.Checked)
                    {
                        tper = 0.0254; //Inch 英吋
                    }
                    if (tper != 1)
                    {
                        if (chkMaterial.Checked == false)
                        {
                            if (MessageBox.Show("此材料單位為米Meter,您選擇的長度單位不是Meter,要繼續選取嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                }
                else
                {
                    tper = 1;
                }
                int intRow= dgvData.Rows.Count - 1;
                dgvData.Rows.Add();
                dgvData.Rows[intRow].Cells["pri_part"].Value = dgvLevel_4.Rows[dgvLevel_4.CurrentCell.RowIndex].Cells["ap3_part"].Value.ToString();
                dgvData.Rows[intRow].Cells["pri_tbprice"].Value = dgvLevel_4.Rows[dgvLevel_4.CurrentCell.RowIndex].Cells["ap3_tbprice"].Value.ToString();
                dgvData.Rows[intRow].Cells["pri_perqty"].Value = (Convert.ToDouble(txtQty.Text) * tper).ToString("0.######");
                dgvData.Rows[intRow].Cells["pri_firstname"].Value = dgvLevel_1.Rows[dgvLevel_1.CurrentCell.RowIndex].Cells["ap1_assy"].Value.ToString();

                //檢查材料是否有越南運費計重註記
                strSQL = $@"select asp_line,isnull(asp_name,'') 'asp_name',asp_vnweight,asp_vnpcs,asp_um from asp where asp_id='{dgvData.Rows[intRow].Cells["pri_part"].Value.ToString()}'";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0)
                {
                    dgvData.Rows[intRow].Cells["asp_name"].Value = dt.Rows[0]["asp_name"].ToString();   
                    if(dgvData.Rows[intRow].Cells["asp_name"].Value.ToString() == "Y" )
                    {
                        dgvData.Rows[intRow].Cells["ptx_chk"].Value = "下";
                    }
                    if(dt.Rows[0]["asp_line"].ToString()=="")
                    {
                        dgvData.Rows[intRow].Cells["asp_line"].Value = "1";
                    }
                    else
                    {
                        dgvData.Rows[intRow].Cells["asp_line"].Value = dt.Rows[0]["asp_line"].ToString();
                    }
                    dgvData.Rows[intRow].Cells["asp_vnweight"].Value = (string.IsNullOrEmpty(dt.Rows[0]["asp_vnweight"].ToString()) ? "0" : dt.Rows[0]["asp_vnweight"].ToString());
                    dgvData.Rows[intRow].Cells["asp_vnpcs"].Value = (string.IsNullOrEmpty(dt.Rows[0]["asp_vnpcs"].ToString()) ? "0" : dt.Rows[0]["asp_vnpcs"].ToString());
                    if ((dgvData.Rows[intRow].Cells["asp_vnweight"].Value.ToString() == "0" || dgvData.Rows[intRow].Cells["asp_vnpcs"].Value.ToString() == "0") && 
                        dgvData.Rows[intRow].Cells["asp_name"].Value.ToString() == "" && 
                        dgvData.Rows[intRow].Cells["asp_line"].Value.ToString() == "Y" && 
                        dt.Rows[0]["asp_um"].ToString() != "KG" && 
                        chkMaterial.Checked)
                    {
                        MessageBox.Show("此材料越南運費的重量和數量有異常,請到火車頭檢查.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    dgvData.Rows[intRow].Cells["asp_line"].Value = "";
                }

                //計算式處理
                if (strQTY != "")
                {
                    dgvData.Rows[intRow].Cells["pri_perqtycal"].Value = strQTY;
                }

                //檢查插入材料是否為不良率,若是則要把所有材料加總再乘以不良率,為不良率的金額
                if (dgvData.Rows[intRow].Cells["pri_part"].Value.ToString().Substring(0, 3) == "不良率")
                {
                    //計算不良率金額
                    string[] strArray = { "包", "裝", "運", "不", "調" };
                    string strValue = "";
                    double tmpCost = 0; //不良率金額
                    for (int i = 0; i < intRow; i++)
                    {
                        if (dgvData.Rows[i].Cells[0].Value.ToString().Length >= 1)
                        {
                            strValue = dgvData.Rows[i].Cells[0].Value.ToString().Substring(0, 1);
                            int index = Array.IndexOf(strArray, strValue);
                            if (index == -1)//不屬於{ "包", "裝", "運", "不", "調" }
                            {
                                tmpCost = tmpCost + Convert.ToDouble(dgvData.Rows[i].Cells[3].Value);
                            }
                        }
                    }
                    dgvData.Rows[intRow].Cells["pri_cost"].Value = (tmpCost == 0 ? "0" : (tmpCost * Convert.ToDouble(dgvData.Rows[intRow].Cells["pri_tbprice"].Value) * Convert.ToDouble(dgvData.Rows[intRow].Cells["pri_perqty"].Value)).ToString("0.######"));
                }
                else
                {
                    if (dgvData.Rows[intRow].Cells["pri_part"].Value.ToString().Substring(0, 2) == "傭金" || 
                        dgvData.Rows[intRow].Cells["pri_part"].Value.ToString().Trim() == "稅票X17%")
                    {
                        if(dgvData.Rows[intRow].Cells["pri_part"].Value.ToString().Trim() == "稅票X17%")
                        {
                            strSQL = $@"select * from cur where cur_code='人民幣'";
                            dt = clsDB.sql_select_dt(strSQL);
                            if (dt.Rows.Count > 0)
                            {
                                dgvData.Rows[intRow].Cells["pri_cost"].Value = (Convert.ToDouble(txtQuote.Text) * Convert.ToDouble(dt.Rows[0]["cur_convert"])).ToString("0.######");
                                dgvData.Rows[intRow].Cells["pri_tbprice"].Value = dgvData.Rows[intRow].Cells["pri_cost"].Value.ToString();
                            }
                        }
                        else
                        {
                            strSQL = $@"select * from cur where cur_code='人民幣'";
                            dt = clsDB.sql_select_dt(strSQL);
                            if (dt.Rows.Count > 0)
                            {
                                dgvData.Rows[intRow].Cells["pri_cost"].Value = (Convert.ToDouble(txtQuote.Text) * Convert.ToDouble(dt.Rows[0]["cur_convert"]) * Convert.ToDouble(dgvData.Rows[intRow].Cells["pri_tbprice"].Value)).ToString("0.######");

                            }
                        }
                    }
                    else
                    {
                        //包裝紙箱計算是以單價除以數量
                        if (dgvData.Rows[intRow].Cells["pri_part"].Value.ToString().Substring(dgvData.Rows[intRow].Cells["pri_part"].Value.ToString().Length - 1, 1) == "才")
                        {
                            dgvData.Rows[intRow].Cells["pri_cost"].Value = (Convert.ToDouble(dgvData.Rows[intRow].Cells["pri_tbprice"].Value)/(Convert.ToDouble(txtQuote.Text) * tper ) ).ToString("0.######");
                        }
                        else
                        {
                            dgvData.Rows[intRow].Cells["pri_cost"].Value = (Convert.ToDouble(dgvData.Rows[intRow].Cells["pri_tbprice"].Value) * (Convert.ToDouble(txtQuote.Text) * tper)).ToString("0.######");
                        }
                    }
                    
                }
                strSQL = $@"select * from cur where cur_code='人民幣'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    if (dgvData.Rows[intRow].Cells["pri_part"].Value.ToString() == "地稅(地方稅)")
                    {
                        dgvData.Rows[intRow].Cells["pri_tbprice"].Value = (Convert.ToDouble(txtQuote.Text) * 0.03 * Convert.ToDouble(dt.Rows[0]["cur_convert"])).ToString("0.######");
                        dgvData.Rows[intRow].Cells["pri_cost"].Value = (Convert.ToDouble(dgvData.Rows[intRow].Cells["pri_tbprice"].Value) * Convert.ToDouble(dgvData.Rows[intRow].Cells["pri_perqty"].Value)).ToString("0.######");
                    }
                    if (dgvData.Rows[intRow].Cells["pri_part"].Value.ToString() == "國稅(增值稅)")
                    {
                        dgvData.Rows[intRow].Cells["pri_tbprice"].Value = (Convert.ToDouble(txtQuote.Text) * 0.17 * Convert.ToDouble(dt.Rows[0]["cur_convert"])).ToString("0.######");
                        dgvData.Rows[intRow].Cells["pri_cost"].Value = (Convert.ToDouble(dgvData.Rows[intRow].Cells["pri_tbprice"].Value) * Convert.ToDouble(dgvData.Rows[intRow].Cells["pri_perqty"].Value)).ToString("0.######");
                    }
                }
                //檢查報價單身的價格加總
                checkPrice();

                string strUM;
                if (radioFeet.Checked)
                {
                    strUM = "Feet"; //Feet 呎
                }
                if (radioMeter.Checked)
                {
                    strUM = "Meter"; //Meter 米
                }
                if (radioInch.Checked)
                {
                    strUM = "Inch"; //Inch 英吋
                }
                
                if (dgvLevel_1.Rows[dgvLevel_1.CurrentCell.RowIndex].Cells["ap1_assy"].Value.ToString() != "2.線材")
                {
                    strUM = "Feet"; //Feet 呎
                }

                if (chkMaterial.Checked == false)
                {
                    radioFeet.Checked = true;
                }

                txtQty.Text = "1";

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnGet_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //dgvData.Rows.Clear();
            getClear();
        }

        private void chkMaterial_Click(object sender, EventArgs e)
        {
            if (chkMaterial.Checked == true)
            {
                newcost = "Y2";
                if (txtID.Text != "")
                {
                    cid_reg = txtID.Text;
                }
            }
            else
            {
                newcost = "N";
            }

            getClear();
            getDisplay(newcost);

            if (newcost == "N" && cid_reg != "")
            {
                txtID.Text = cid_reg;
                cid_reg = "";
            }
            if (newcost == "Y2" && cid_reg != "")
            {
                txtID.Text = cid_reg;
                cid_reg = "";
            }
            if (txtID.Text != "")
            {
                txtName.Focus();
            }
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select cur_convert from cur where cur_code='{cboCurrency.Text}'";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    txtCost.Text =( Convert.ToDouble(txtTBCost.Text) / Convert.ToDouble(dt.Rows[0]["cur_convert"])).ToString("0.###");
                    txtHopePrice_Rate.Text = (txtHopePrice.Text == "" ? "0" : ((Convert.ToDouble(txtHopePrice.Text) - Convert.ToDouble(txtCost.Text)) * 100 / Convert.ToDouble(txtCost.Text)).ToString("0.#"));
                    txtQuote_Rate.Text = (txtQuote.Text == "" ? "0" : ((Convert.ToDouble(txtQuote.Text) - Convert.ToDouble(txtCost.Text)) * 100 / Convert.ToDouble(txtCost.Text)).ToString("0.#"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-txtCost_TextChanged" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLevel_4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >=0)
            {
                btnGet_Click(null,null);
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                if (txtName.Text != "")
                {
                    txtID.Text = txtID.Text.TrimEnd((char[])"/n/r".ToCharArray()).Trim();  //去ENTER 換行 空白
                }
                else
                {
                    return;
                }
                if (txtName.Text.Substring(0, 1).ToUpper() == "M")
                {
                    chkOutsourcing.Checked = false;
                    if (txtName.Text.ToUpper() != "M621" && txtName.Text.ToUpper() != "M219" && txtName.Text.ToUpper() != "M304")
                    {
                        chkOutsourcing.Checked = true;
                    }
                    string strVenderID = txtName.Text.Trim().Substring(1, txtName.Text.Length-1);
                    strSQL = $@"select ven_shortname from ven where ven_id='{strVenderID}'";
                    dt= clsDB.sql_select_dt(strSQL);
                    if(dt.Rows.Count > 0)
                    {
                        txtVender.Text = dt.Rows[0]["ven_shortname"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-txtName_Leave" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                MessageBox.Show("不可輸入特殊字元< ' >!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.KeyChar = (char)0;   //處理非法字符
            }
        }

        private void chkSpecial_Click(object sender, EventArgs e)
        {
            //特選
            try
            {
                if(txtID.Text=="")
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                //檢查是要新增特選(Select)還是要查詢特選(Inquiry)
                frmBOMPrice_Special frmBOMPrice_Special = new frmBOMPrice_Special();
                if (dgvData.Rows[dgvData.CurrentRow.Index].Cells["pri_part"].Value.ToString()!="")
                {
                    strSQL = $@"select *,
                                       Isnull(ven_shortname, '') '廠商'
                                from   ptx
                                       left join ven
                                              on ven_id = ptx_vendorid
                                where  ptx_name = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["pri_part"].Value.ToString()}'
                                       and ptx_customerid = '{txtID.Text}' ";
                    dt= clsDB.sql_select_dt(strSQL);
                    if(dt.Rows.Count>0)
                    {

                        //查詢特選(Inquiry)
                        frmBOMPrice_Special.rstrWho = "Inquiry";
                        frmBOMPrice_Special.rstrID = dt.Rows[0]["ptx_customerid"].ToString();
                        frmBOMPrice_Special.rstrPart = dt.Rows[0]["ptx_name"].ToString();
                        frmBOMPrice_Special.rstrPrice = dgvData.Rows[dgvData.CurrentRow.Index].Cells["pri_cost"].Value.ToString();
                        frmBOMPrice_Special.ShowInTaskbar = false;    //圖示不顯示在工作列
                        frmBOMPrice_Special.ShowDialog();
                        if(rstrButton=="Delete")
                        {
                            for(int i=0;i<dgvData.Rows.Count-1;i++)
                            {
                                if (dgvData.Rows[i].Cells["pri_part"].Value.ToString()==rstrPart)
                                {
                                    dgvData.Rows.RemoveAt(i);
                                    break;
                                }
                            }
                            //檢查報價單身的價格加總
                            checkPrice();
                        }
                        if (rstrButton == "Select")
                        {
                            int i = dgvData.Rows.Count - 1;
                            dgvData.Rows.Add();
                            dgvData.Rows[i].Cells["pri_part"].Value = rstrPart;
                            dgvData.Rows[i].Cells["pri_tbprice"].Value = rstrTbprice;
                            dgvData.Rows[i].Cells["pri_perqty"].Value = rstrPerQty;
                            dgvData.Rows[i].Cells["pri_cost"].Value = rstrCost;
                            dgvData.Rows[i].Cells["ptx_chk"].Value = rstrPtx_chk;
                            dgvData.Rows[i].Cells["pri_firstname"].Value = "其它料";
                            dgvData.Rows[i].Cells["pri_perqtycal"].Value = rstrQtyCal;
                            dgvData.Rows[i].Cells["asp_line"].Value = "";
                            dgvData.Rows[i].Cells["asp_name"].Value = "";
                            //檢查報價單身的價格加總
                            checkPrice();
                        }
                        return;
                    }
                }

                //新增特選(Select)
                frmBOMPrice_Special.rstrWho = "Select";
                frmBOMPrice_Special.rstrID = txtID.Text;
                
                frmBOMPrice_Special.ShowInTaskbar = false;    //圖示不顯示在工作列
                frmBOMPrice_Special.ShowDialog();
                if (rstrButton == "Select")
                {
                    int i = dgvData.Rows.Count - 1;
                    dgvData.Rows.Add();
                    dgvData.Rows[i].Cells["pri_part"].Value = rstrPart;
                    dgvData.Rows[i].Cells["pri_tbprice"].Value = rstrTbprice;
                    dgvData.Rows[i].Cells["pri_perqty"].Value = rstrPerQty;
                    dgvData.Rows[i].Cells["pri_cost"].Value = rstrCost;
                    dgvData.Rows[i].Cells["ptx_chk"].Value = rstrPtx_chk;
                    dgvData.Rows[i].Cells["pri_firstname"].Value = "其它料";
                    dgvData.Rows[i].Cells["pri_perqtycal"].Value = rstrQtyCal;
                    dgvData.Rows[i].Cells["asp_line"].Value = "";
                    dgvData.Rows[i].Cells["asp_name"].Value = "";
                    //檢查報價單身的價格加總
                    checkPrice();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-chkSpecial_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkClassify_Click(object sender, EventArgs e)
        {
            //分類
            try
            {
                if(txtID.Text=="")
                {
                    return;
                }
                //確認權限
                if (clsGlobal.checkRightFlag("報價單分類儲存權限") == false)
                {
                    MessageBox.Show("您沒有報價單分類儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmBOMPrice_Class frmBOMPrice_Class = new frmBOMPrice_Class();
                frmBOMPrice_Class.rstrID = txtID.Text;
                
                frmBOMPrice_Class.ShowInTaskbar = false;    //圖示不顯示在工作列
                frmBOMPrice_Class.ShowDialog();
                if (rstrButton == "Save")
                {
                    if (rstrClass == "7 Power cord")
                    {
                        chkPower.Checked = true;
                    }
                    if(rstrClass == "")
                    {
                        chkClassify.Checked = false;
                        pfenlei = "";
                    }
                    else
                    {
                        chkClassify.Checked = true;
                        pfenlei = rstrClass;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPower_Click(object sender, EventArgs e)
        {
            //電源
            try
            {
                if(chkPower.Checked && txtVender.Text != "冠源")
                {
                    chkOutsourcing.Checked = false;
                    pfenlei = "7 Power cord";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-chkPower_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkCheck_Click(object sender, EventArgs e)
        {
            //審核
            try
            {
                if(chkCheck.Checked)
                {
                    toolTip1.SetToolTip(chkCheck, clsGlobal.strG_User);
                }
                else
                {
                    toolTip1.SetToolTip(chkCheck, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-chkCheck_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkNote_Click(object sender, EventArgs e)
        {
            //備註
            try
            {
                if (txtID.Text == "")
                {
                    return;
                }
                //確認權限
                if (clsGlobal.checkRightFlag("報價單備註儲存權限") == false)
                {
                    MessageBox.Show("您沒有報價單備註儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmBOMPrice_Note frmBOMPrice_Note = new frmBOMPrice_Note();
                frmBOMPrice_Note.rstrID = txtID.Text;

                frmBOMPrice_Note.ShowInTaskbar = false;    //圖示不顯示在工作列
                frmBOMPrice_Note.ShowDialog();
                if (rstrButton == "Save")
                {
                    strNote = rstrNote;
                    if(rstrNote=="")
                    {
                        chkNote.Checked=false;
                    }
                    else
                    {
                        chkNote.Checked=true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkOutsourcing_Click(object sender, EventArgs e)
        {
            //外購
            try
            {
                if (chkOutsourcing.Checked)
                {
                    chkPower.Checked=false;
                    if(txtName.Text== "M621")
                    {
                        chkOutsourcing.Checked=false;
                    }
                    if (txtName.Text == "M219")
                    {
                        chkOutsourcing.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-chkOutsourcing_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkLarge_Click(object sender, EventArgs e)
        {
            //量大
            try
            {
                if (txtID.Text == "")
                {
                    return;
                }
                //確認權限
                if (clsGlobal.checkRightFlag("報價單量大儲存權限") == false)
                {
                    MessageBox.Show("您沒有報價單量大儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmBOMPrice_Large frmBOMPrice_Large = new frmBOMPrice_Large();
                frmBOMPrice_Large.rstrID = txtID.Text;
                frmBOMPrice_Large.rstrCost = txtCost.Text;
                frmBOMPrice_Large.ShowInTaskbar = false;    //圖示不顯示在工作列
                frmBOMPrice_Large.ShowDialog();
                if (rstrButton == "Save")
                {
                    if (Convert.ToDouble(rstrLarge) > 0)
                    {
                        chkLarge.Checked=true;
                    }
                    else
                    {
                        chkLarge.Checked=false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
