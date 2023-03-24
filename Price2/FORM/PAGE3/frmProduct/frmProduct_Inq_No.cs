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
    public partial class frmProduct_Inq_No : Form
    {
        public static string rstrID = "";   //傳來的材料名
        string strCal = ""; //計算式
        string strNo = "";  //點選的品號
        string strPrice = "";   //原來的單價
        public frmProduct_Inq_No()
        {
            InitializeComponent();
        }

        private void frmProduct_Inq_No_Load(object sender, EventArgs e)
        {
            txtID.Text = rstrID;
            getData(rstrID);
            if(dgvData.Rows.Count > 0)
            {
                txtID.Text = dgvData.Rows[0].Cells["材料名"].Value.ToString();
                txtDate.Text = dgvData.Rows[0].Cells["最後變動日期"].Value.ToString();
                txtNo.Text = dgvData.Rows[0].Cells["品號"].Value.ToString();
                txtPrice.Text = dgvData.Rows[0].Cells["最新價格"].Value.ToString();
                strPrice = txtPrice.Text;
                cboCurrency.Text = dgvData.Rows[0].Cells["幣種"].Value.ToString();
                txtMemo.Text = dgvData.Rows[0].Cells["參照法"].Value.ToString();
                txtSpec.Text = dgvData.Rows[0].Cells["規格"].Value.ToString();
                strCal = dgvData.Rows[0].Cells["計算式"].Value.ToString();
                txtVendor.Text = dgvData.Rows[0].Cells["廠商"].Value.ToString();
                cboUnit.Text = dgvData.Rows[0].Cells["單位"].Value.ToString();
            }
            btnDelete.Enabled = false;
            //btnSave.Enabled = false;
        }

        private void frmProduct_Inq_No_Activated(object sender, EventArgs e)
        {
            
        }

        private void getData(string strID)
        {
            String strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select aspnum_id                                                  as 材料名,
                               aspnum_num                                                 as 品號,
                               convert (VARCHAR(10), aspnum_modifydate, 120)              as 最後變動日期,
                               Cast(convert(DECIMAL(18, 6), aspnum_price) as VARCHAR(18)) as 最新價格,
                               Round(aspnum_price * cur_convert, 6)                       as 台幣單價,
                               aspnum_vendorid                                            as 廠商,
                               ven.ven_shortname                                          as 廠商名稱,
                               aspnum_currency                                            as 幣種,
                               aspnum_um                                                  as 單位,
                               aspnum_memo                                                as 參照法,
                               aspnum_spec                                                as 規格,
                               aspnum_pricecal                                            as 計算式
                        from   aspnum
                               left join ven
                                      on ven.ven_id = aspnum_vendorid
                               left join cur
                                      on cur_code = aspnum_currency
                        where  aspnum_id = '{strID}'
                        order  by '台幣單價',
                                  aspnum_price,
                                  aspnum_modifydate desc,
                                  aspnum_vendorid ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dgvData.DataSource = dt;
                #region 計算57和304價格相差比率;目前沒有304所以沒用
                //計算57和304價格相差比率
                double dblVen57 = 0;
                double dblVen304 = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["廠商"].ToString() == "57")
                    {
                        if (dt.Rows[i]["單位"].ToString().Substring(0, 1) == "M")
                        {
                            dblVen57 = Convert.ToDouble(dt.Rows[i]["最新價格"].ToString()) / 3.28;   //單位轉換=>米->呎
                        }
                        else
                        {
                            dblVen57 = Convert.ToDouble(dt.Rows[i]["最新價格"].ToString());
                        }
                    }
                    if (dt.Rows[i]["廠商"].ToString() == "304")
                    {
                        if (dt.Rows[i]["單位"].ToString().Substring(0, 1) == "M")
                        {
                            dblVen304 = Convert.ToDouble(dt.Rows[i]["最新價格"].ToString()) / 3.28;   //單位轉換=>米->呎
                        }
                        else
                        {
                            dblVen304 = Convert.ToDouble(dt.Rows[i]["最新價格"].ToString());
                        }
                    }
                }
                if (dblVen57 > 0 && dblVen304 > 0)
                {
                    if (dblVen304 > dblVen57)
                    {
                        lblPriceDiff.Text = "價格相差比率: " + ((dblVen304 - dblVen57) / dblVen57 * 100).ToString("0.##") + "%";
                    }
                    else if (dblVen57 > dblVen304)
                    {
                        lblPriceDiff.Text = "價格相差比率: " + ((dblVen57 - dblVen304) / dblVen304 * 100).ToString("0.##") + "%";
                    }
                    else
                    {
                        lblPriceDiff.Text = "價格相差比率: 0%";
                    }
                } 
                #endregion
            }
            else
            {
                strSQL = $@"";
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

        private void btnClear_Click(object sender, EventArgs e) //清除
        {
            //清除
            txtDate.Text = "";  
            txtNo.Text = "";
            txtPrice.Text = "";
            strPrice = "";
            txtSpec.Text = "";
            txtVendor.Text = "";
            txtMemo.Text = "";
            cboCurrency.Text = "";
            cboUnit.Text = "";
            strCal = "";
            strNo = "";
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void txtNo_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)    //刪除
        {
            //刪除
            try
            {
                if (clsGlobal.checkRightFlag("火車頭資料刪除權限") == false)
                {
                    MessageBox.Show("你沒有火車頭資料刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String strSQL = "";
                DataTable dt = new DataTable();
                if (strNo == "")
                {
                    MessageBox.Show("請選擇要刪除的品號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                strSQL = $@"select * from asp where asp_vendormaterialno='{strNo}'";
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("不可以在此刪除外層品號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show(this, "你確定要刪除該產品嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    strSQL = $@"delete from aspnum where aspnum_id ='{txtID.Text}' and aspnum_num='{strNo}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete from pri where pri_assy ='{strNo}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete from asm where asm_vendormaterialno ='{strNo}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"delete from avt where avt_vendormaterialno ='{strNo}' ";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("品號已刪除!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();
                }
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
                if(txtNo.Text=="")
                {
                    MessageBox.Show("品號不可為空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtPrice.Text == "")
                {
                    MessageBox.Show("單價不可為空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (clsGlobal.checkRightFlag("火車頭資料儲存權限") == false)
                {
                    MessageBox.Show("你沒有火車頭資料儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //先檢查多品號問題
                string strPID = checkPID(txtNo.Text, txtID.Text);
                if(strPID=="")
                {
                    String strSQL = "";
                    DataTable dt = new DataTable();
                    //檢查品號是否已存在
                    strSQL = $@"select aspnum_id                            as 材料名,
                                       aspnum_num                           as 品號,
                                       aspnum_modifydate                    as 最後變動日期,
                                       aspnum_price                         as 最新價格,
                                       Round(aspnum_price * cur_convert, 6) as 台幣單價,
                                       aspnum_vendorid                      as 廠商,
                                       ven.ven_shortname                    as 廠商名稱,
                                       aspnum_currency                      as 幣種,
                                       aspnum_um                            as 單位,
                                       aspnum_memo                          as 參照法,
                                       aspnum_spec                          as 規格,
                                       aspnum_pricecal                      as 計算式
                                from   aspnum
                                       left join ven
                                              on ven.ven_id = aspnum_vendorid
                                       left join cur
                                              on cur_code = aspnum_currency
                                where  aspnum_id = '{txtID.Text}'
                                       and aspnum_num = '{txtNo.Text.Trim()}'
                                order  by '台幣單價',
                                          aspnum_price,
                                          aspnum_modifydate desc,
                                          aspnum_vendorid ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if(dt.Rows.Count>0)
                    {
                        //如果已有品號資料則予以更新
                        strSQL = $@"update aspnum
                                    set    aspnum_price = '{txtPrice.Text.Trim()}',
                                           aspnum_modifydate = '{DateTime.Now.ToString("yyyy/MM/dd")}',
                                           aspnum_currency = '{cboCurrency.Text.Trim()}',
                                           aspnum_memo = '{txtMemo.Text.Trim()}',
                                           aspnum_pricecal = '{strCal}',
                                           aspnum_vendorid = '{txtVendor.Text.Trim()}',
                                           aspnum_spec = '{txtSpec.Text.Trim()}',
                                           aspnum_um = '{cboUnit.Text.Trim()}'
                                    where  aspnum_id = '{txtID.Text.Trim()}'
                                           and aspnum_num = '{txtNo.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                    }
                    else
                    {
                        //如果沒有品號資料則予以新增
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
                                                 '{txtPrice.Text.Trim()}',
                                                 '{cboCurrency.Text.Trim()}',
                                                 '{txtMemo.Text.Trim()}',
                                                 '{strCal}',
                                                 '{txtVendor.Text.Trim()}',
                                                 '{txtSpec.Text.Trim()}',
                                                 '{cboUnit.Text.Trim()}') ";
                        clsDB.Execute(strSQL);
                    }
                    MessageBox.Show("儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();
                }
                else
                {
                    if (strPID == "2")
                    {
                        MessageBox.Show("此品號前6碼不一致,請檢查!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("此品號已有記錄,請檢查!("+ strPID + ")", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtID.Text = dgvData.Rows[e.RowIndex].Cells["材料名"].Value.ToString();
                txtDate.Text = dgvData.Rows[e.RowIndex].Cells["最後變動日期"].Value.ToString();
                txtNo.Text = dgvData.Rows[e.RowIndex].Cells["品號"].Value.ToString();
                txtPrice.Text = dgvData.Rows[e.RowIndex].Cells["最新價格"].Value.ToString();
                strPrice = txtPrice.Text;
                cboCurrency.Text = dgvData.Rows[e.RowIndex].Cells["幣種"].Value.ToString();
                txtMemo.Text = dgvData.Rows[e.RowIndex].Cells["參照法"].Value.ToString();
                txtSpec.Text = dgvData.Rows[e.RowIndex].Cells["規格"].Value.ToString();
                strCal = dgvData.Rows[e.RowIndex].Cells["計算式"].Value.ToString();
                txtVendor.Text = dgvData.Rows[e.RowIndex].Cells["廠商"].Value.ToString();
                cboUnit.Text = dgvData.Rows[e.RowIndex].Cells["單位"].Value.ToString();
                strNo = dgvData.Rows[e.RowIndex].Cells["品號"].Value.ToString();
                btnDelete.Enabled = true;
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                frmProduct.rstrNo = dgvData.Rows[e.RowIndex].Cells["品號"].Value.ToString();
                this.Close();
            }
        }

        private Boolean checkBom(string strNo)
        {
            //檢查材料單
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select distinct pri_customerid from pri where pri_assy ='{strNo}' and pri_newcostchk like 'Y%'";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtPrice_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("計算式："+strCal, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            if(strCal!="")
            {
                txtPrice.Text = strCal;
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            strCal = txtPrice.Text;
            //計算式 取小數點6位 計算機 引用using System.Data
            txtPrice.Text =Convert.ToDouble( new DataTable().Compute(txtPrice.Text, null)).ToString("0.######");
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if(strPrice!="" && checkBom(txtNo.Text))
            {
                if (txtPrice.Text!=strPrice)
                {
                    MessageBox.Show("此材料名已有材料單對應或設定處理,不可變更單價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPrice.Text = strPrice;
                }
            }
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

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtVendor.Focus();
            }
        }
    }
}
