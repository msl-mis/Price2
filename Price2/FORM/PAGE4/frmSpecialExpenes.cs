using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using static Sunny.UI.IdentityCard;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Price2
{
    public partial class frmSpecialExpenes : Form
    {
        string strCal = "";
        string strNbr = "";
        string strType_ID = "";
        string strItem_ID = "";
        bool blnCopy=false;
        public frmSpecialExpenes()
        {
            InitializeComponent();
        }

        private void frmSpecialExpenes_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                //加入支出類別
                strSQL = $@"select type_id, type_name from odca_type order by type_serial_no ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboType.Items.Add(dt.Rows[i]["type_name"].ToString());
                    }
                }
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmSpecialExpenes_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //btnDelete.Enabled = false; //刪除
                //btnDeleteAll.Enabled = false; //刪除
                btnSave.Enabled = false; //儲存
                btnCopy.Enabled = false; //複製
                blnCopy = false; //複製顯示
                txtReason.Text = ""; //支出原因
                txtExpense.Text = ""; //支出金額
                txtDate.Text = ""; //支出日期
                cboCurrency.Text = ""; //幣別
                lblCount.Text = "資料筆數：0"; //筆數
                lblTotal.Text = "總金額(萬)：0";
                strNbr = ""; //選取資料序號
                strCal = ""; //計算式
                txtDate_S.Text = "";
                txtDate_E.Text = "";
                txtNote.Text = "";

                txtOrder.Text = ""; //訂單號碼 
                txtUsePeriod.Text = ""; //使用年限
                txtVendor.Text = "";  //廠商代碼
                txtUsePeriod.Enabled = true;
                //txtUsePeriod.BackColor = &H80000005;
                cboType.Text = "";
                cboItem.Items.Clear();
                cboItem.Text = "";
                cboDivision.Text = "";
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Click(object sender, EventArgs e)
        {
            //搜尋
            try
            {
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()
        {
            try
            {
                if (txtDate_E.Text != "" && txtDate_S.Text != "")
                {
                    if (Convert.ToDateTime(txtDate_S.Text) > Convert.ToDateTime(txtDate_E.Text))
                    {
                        MessageBox.Show("起始日期不可以大於結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return ;
                    }
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標

                strSQL = $@"select 
                                   odca_date                        '支出日期',
                                   (select type_name
                                    from   odca_type
                                    where  type_id = odca_type)     '支出類別',
                                   (select item_name
                                    from   odca_item
                                    where  type_id = odca_type
                                           and item_id = odca_item) '類別子項',
                                   odca_freason                     '支出原因',
                                   odca_ksval                       '支出金額',
                                   odca_currency                    '幣別',
                                   Round(odca_convcost, 0)          '臺幣',
                                   odca_division                    '不計入',
                                   odca_user                        '修改人員',
                                   odca_nbr                         'nbr',
                                   odca_orders_id                   '訂單號碼',
                                   odca_pcal                        '計算式',
                                   odca_note                        '備註',
                                   odca_salary                      '月薪',
                                   odca_ven_id                      '廠商'
                            from   odca
                            where  1 = 1 ";
                strSQL = strSQL + Get_strWhere() + "order by odca_date, odca_freason ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    lblCount.Text = "資料筆數：" + dt.Rows.Count.ToString();
                    Single sngTotal = 0;
                    for(int i = 0; i < dt.Rows.Count;i++)
                    {
                        sngTotal = sngTotal + Convert.ToSingle(dt.Rows[i]["臺幣"]);
                    }
                    lblTotal.Text = "總金額(萬)："+(sngTotal/10000).ToString("#,##0");
                    dgvData.DataSource = dt;
                }
                else
                {
                    lblCount.Text = "資料筆數：0";
                    lblTotal.Text = "總金額(萬)：0";
                    dgvData.DataSource = dt;
                }
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Get_strWhere()
        {
            string strWhere = "";
            //日期
            strWhere = strWhere + (txtDate_S.Text == "" ? "" : $@"and odca_date between '{txtDate_S.Text}' and '{txtDate_E.Text}' ");
            //支出原因
            if (txtReason.Text.Trim() != "")//冒號分號多條件搜尋
            {
                strWhere = strWhere + clsGlobal.MulitSelect("odca_freason", txtReason.Text.Trim());
            }
            //幣別
            strWhere = strWhere + (cboCurrency.Text == "" || cboCurrency.Text == "ALL" ? "" : $@"and odca_currency = '{cboCurrency.Text.Trim()}' ");
            //支出類別
            strWhere = strWhere + (cboType.Text == "" || cboType.Text == "ALL" ? "" : $@"and odca_type = '{strType_ID}' ");
            //類別子項
            strWhere = strWhere + (cboItem.Text == "" || cboItem.Text == "ALL" ? "" : $@"and odca_item = '{strItem_ID}' ");
            //不計入
            strWhere = strWhere + (cboDivision.Text == "" || cboDivision.Text == "ALL" ? "" : $@"and odca_division = '{cboDivision.Text.Trim()}' ");
            //備註
            strWhere = strWhere + (txtNote.Text == "" ? "" : $@"and odca_note like '%{txtNote.Text.Trim()}%' ");
            //訂單號碼
            strWhere = strWhere + (txtOrder.Text == "" ? "" : $@"and odca_orders_id like '%{txtOrder.Text.Trim()}%' ");
            //廠商代碼
            strWhere = strWhere + (txtVendor.Text == "" ? "" : $@"and odca_ven_id like '%{txtVendor.Text.Trim()}%' ");

            return strWhere;
        }

        private void txtDate_S_Click(object sender, EventArgs e)
        {
            if (txtDate_S.Text == "")
            {
                txtDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtDate_E_Click(object sender, EventArgs e)
        {
            if (txtDate_E.Text == "")
            {
                txtDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void cboType_TextChanged(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            //加入類別子項
            strSQL = $@"select a.type_id   type_id,
                               a.type_name type_name,
                               b.item_id   item_id,
                               b.item_name item_name
                        from   odca_type a,
                               odca_item b
                        where  a.type_id = b.type_id
                               and type_name = '{cboType.Text}'
                        order  by item_serial_no ";
            dt = clsDB.sql_select_dt(strSQL);
            cboItem.Items.Clear();  
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cboItem.Items.Add(dt.Rows[i]["item_name"].ToString());
                }
                strType_ID = dt.Rows[0]["type_id"].ToString();
            }
        }

        private void cboItem_TextChanged(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            //加入類別子項
            strSQL = $@"select item_id
                        from   odca_item
                        where  type_id = '{strType_ID}'
                               and item_name = '{cboItem.Text}' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                strItem_ID = dt.Rows[0]["item_id"].ToString();
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                //更新畫面中的欄位資料
                strNbr= dgvData.Rows[e.RowIndex].Cells["nbr"].Value.ToString();//nbr
                txtDate.Text = Convert.ToDateTime( dgvData.Rows[e.RowIndex].Cells["支出日期"].Value).ToString("yyyy/MM/dd");//支出日期
                cboType.Text = dgvData.Rows[e.RowIndex].Cells["支出類別"].Value.ToString();//支出類別
                strSQL = $@"select type_id from odca_type where type_name = '{cboType.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strType_ID = dt.Rows[0]["type_id"].ToString();
                }
                cboItem.Text = dgvData.Rows[e.RowIndex].Cells["類別子項"].Value.ToString();//類別子項
                if(cboItem.Text!="")
                {
                    strSQL = $@"select item_id from odca_item where type_id = '{strType_ID}' and item_name = '{cboItem.Text}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        strItem_ID = dt.Rows[0]["item_id"].ToString();
                    }
                }
                txtReason.Text = dgvData.Rows[e.RowIndex].Cells["支出原因"].Value.ToString();//支出原因
                txtExpense.Text = dgvData.Rows[e.RowIndex].Cells["支出金額"].Value.ToString();//支出金額
                txtOrder.Text = dgvData.Rows[e.RowIndex].Cells["訂單號碼"].Value.ToString();//訂單號碼
                cboCurrency.Text = dgvData.Rows[e.RowIndex].Cells["幣別"].Value.ToString();//幣別
                strCal = dgvData.Rows[e.RowIndex].Cells["計算式"].Value.ToString();//計算式
                if(strCal.LastIndexOf("/")>=0)
                {
                    if(txtReason.Text.IndexOf("間接") >=0 || txtReason.Text.IndexOf("年終") >= 0)
                    {

                    }
                    else
                    {
                        txtUsePeriod.Text=strCal.Substring(strCal.LastIndexOf("/")+1,strCal.Length- strCal.LastIndexOf("/")-1);
                    }
                }


                txtNote.Text = dgvData.Rows[e.RowIndex].Cells["備註"].Value.ToString();//備註
                txtVendor.Text = dgvData.Rows[e.RowIndex].Cells["廠商"].Value.ToString();//廠商

                cboDivision.Text = dgvData.Rows[e.RowIndex].Cells["不計入"].Value.ToString();//不計入
                btnSave.Enabled = true; //儲存
                btnCopy.Enabled = true; //複製
                blnCopy = false;//新增顯示
                btnCopy.Focus();
                txtUsePeriod.Enabled = false;
                
            }
        }

        private void txtExpense_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void txtExpense_TextChanged(object sender, EventArgs e)
        {
            if(txtExpense.Text!="")
            {
                btnSave.Enabled = true;
            }
        }

        private void txtExpense_Leave(object sender, EventArgs e)
        {
            try
            {
                strCal = "";
                if (txtExpense.Text == "")
                {
                    txtExpense.Text = "0";
                }
                else
                {
                    strCal = txtExpense.Text;
                    //計算式  計算機 引用using System.Data
                    txtExpense.Text = new DataTable().Compute(txtExpense.Text, null).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-txtExpense_Leave" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtExpense_Enter(object sender, EventArgs e)
        {
            if(strCal!="")
            {
                txtExpense.Text = strCal;
            }
        }

        private void txtExpense_DoubleClick(object sender, EventArgs e)
        {
            if(txtExpense.Text!="")
            {
                MessageBox.Show("計算式："+strCal, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //複製
            try
            {
                strNbr = "";
                txtUsePeriod.Enabled = true;
                txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                blnCopy = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCopy_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("特別支出查詢", dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            //子項維護
            try
            {
                frmSpecialExpenes_Item frmSpecialExpenes_Item = new frmSpecialExpenes_Item();
                frmSpecialExpenes_Item.ShowInTaskbar = false;//圖示不顯示在工作列

                frmSpecialExpenes_Item.ShowDialog();
                btnClear.PerformClick();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnItem_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                //欄位限制防呆
                if (blnCopy == true)
                {
                    //檢查是否有相同支出原因,支出日期
                    strSQL = $@"select * from odca where odca_date='{txtDate.Text}' and odca_freason='{txtReason.Text}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("支出原因已存在,不可複製!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                
                if (txtReason.Text == "")
                {
                    MessageBox.Show("支出原因不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtExpense.Text == ""|| txtExpense.Text == "0")
                {
                    MessageBox.Show("支出金額不可為0或空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (clsGlobal.ValidateString( txtExpense.Text,8)==false )
                {
                    MessageBox.Show("支出金額請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cboCurrency.Text == "" || cboCurrency.Text == "ALL")
                {
                    MessageBox.Show("請選擇幣別!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                if(txtUsePeriod.Text != "")
                {
                    if(clsGlobal.ValidateString(txtExpense.Text, 6) == false)
                    {
                        MessageBox.Show("使用年限請輸入整數!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    
                }

                if (cboType.Text == "" || cboType.Text == "ALL")
                {
                    MessageBox.Show("請選擇支出類別!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string strSalary ="";
                string strItem = "";
                if(cboItem.Text == "ALL" || cboItem.Text == "")
                {
                    strItem = ""; 
                }
                else
                {
                    strItem = cboItem.Text.Trim();
                    strItem = strItem_ID;
                }

                string strDivision = "";
                if (cboDivision.Text == "ALL" || cboDivision.Text == "")
                {
                    strDivision = "";
                }
                else
                {
                    strDivision = cboDivision.Text.Trim();
                }

                if(strNbr!="")//修改資料
                {
                    if (MessageBox.Show("確定要修改嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    strSalary = "odca_salary='0'";

                    strSQL = $@"update odca
                                set    odca_date='{txtDate.Text}',
                                       odca_freason='{txtReason.Text.Trim()}',
                                       odca_ksval='{txtExpense.Text.Trim()}',
                                       odca_currency='{cboCurrency.Text}',
                                       odca_convert=cur_convert,
                                       odca_convcost=cur_convert*{txtExpense.Text.Trim()} ,
                                       odca_pcal='{strCal.Trim()}',
                                       odca_type='{strType_ID}',
                                       odca_item='{strItem}',
                                       odca_division='{strDivision}',
                                       odca_note='{txtNote.Text}',
                                       {strSalary},
                                       odca_user='{clsGlobal.strG_User}',
                                       odca_orders_id='{txtOrder.Text}',
                                       odca_ven_id='{txtVendor.Text}'
                                from   odca,
                                       cur
                                where  odca_nbr={strNbr}
                                and    cur_code='{cboCurrency.Text}'";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("已儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else//新增資料
                {
                    if (MessageBox.Show("確定要新增嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    strSalary = "0";
                    if(txtUsePeriod.Text == ""|| txtUsePeriod.Text == "0")//無使用年限
                    {
                        strSQL = $@"insert into odca
                                                (odca_date,
                                                 odca_freason,
                                                 odca_ksval,
                                                 odca_currency,
                                                 odca_convert,
                                                 odca_convcost,
                                                 odca_pcal,
                                                 odca_type,
                                                 odca_item,
                                                 odca_division,
                                                 odca_note,
                                                 odca_salary,
                                                 odca_orders_id,
                                                 odca_user,
                                                 odca_ven_id)
                                    select '{txtDate.Text}',
                                           '{txtReason.Text.Trim()}',
                                           '{txtExpense.Text.Trim()}',
                                           '{cboCurrency.Text}',
                                           cur_convert,
                                           cur_convert * {txtExpense.Text.Trim()},
                                           '{strCal.Trim()}',
                                           '{strType_ID}',
                                           '{strItem}',
                                           '{strDivision}',
                                           '{txtNote.Text}',
                                           '{strSalary}',
                                           '{txtOrder.Text}',
                                           '{clsGlobal.strG_User}',
                                           '{txtVendor.Text}'
                                    from   cur
                                    where  cur_code = '{cboCurrency.Text}' ";
                        clsDB.Execute(strSQL);
                        MessageBox.Show("已儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else//有使用年限
                    {
                        int iCount = 0;
                        string ksval = "";    //支出金額
                        string freason = "";    //支出原因
                        string orderID = "";   //定單號碼
                        string strDate = "";   //使用年限日期
                        string strCount = "";  //計算式
                        strCount = strCal + "/" + txtUsePeriod.Text;
                        for (int i = 1; i <= Convert.ToInt32(txtUsePeriod.Text); i++)
                        {
                            strDate = (Convert.ToInt32(txtDate.Text.Substring(0, 4)) + iCount - 1).ToString() + Text.Substring(4, 6);
                            freason = txtReason.Text + "-" + iCount.ToString() ;
                            ksval = (Convert.ToDouble(txtExpense.Text) / Convert.ToDouble(txtUsePeriod.Text)).ToString("0");
                            orderID = txtOrder.Text;
                            strSQL = $@"insert into odca
                                                    (odca_date,
                                                     odca_freason,
                                                     odca_ksval,
                                                     odca_currency,
                                                     odca_convert,
                                                     odca_convcost,
                                                     odca_pcal,
                                                     odca_type,
                                                     odca_item,
                                                     odca_division,
                                                     odca_note,
                                                     odca_salary,
                                                     odca_orders_id,
                                                     odca_user,
                                                     odca_ven_id)
                                        select '{strDate}',
                                               '{freason}',
                                               '{ksval}',
                                               '{cboCurrency.Text}',
                                               cur_convert,
                                               cur_convert * {ksval},
                                               '{strCount}',
                                               '{strType_ID}',
                                               '{strItem}',
                                               '{cboDivision.Text}',
                                               '{txtNote.Text}',
                                               '{strSalary}',
                                               '{orderID}',
                                               '{clsGlobal.strG_User}',
                                               '{txtVendor.Text}'
                                        from   cur
                                        where  cur_code = '{cboCurrency.Text}' ";
                            clsDB.Execute(strSQL);
                        }
                        MessageBox.Show("已儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //if(blnCopy==true)
                    //{
                    //    MessageBox.Show("已複製完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }

                //輸入後顯示查詢
                getData();
                //清除欄位
                blnCopy = false; //複製顯示
                txtReason.Text = ""; //支出原因
                txtExpense.Text = ""; //支出金額
                txtDate.Text = ""; //支出日期
                cboCurrency.Text = ""; //幣別

                strNbr = ""; //選取資料序號
                strCal = ""; //計算式
                txtDate_S.Text = "";
                txtDate_E.Text = "";
                txtNote.Text = "";

                txtOrder.Text = ""; //訂單號碼  
                txtUsePeriod.Text = ""; //使用年限
                txtVendor.Text = "";  //廠商代碼 
                txtUsePeriod.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //更新畫面中的欄位資料
            strNbr = dgvData.Rows[e.RowIndex].Cells["nbr"].Value.ToString();//nbr
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                if (strNbr=="")
                {
                    return;
                }
                if (MessageBox.Show("確定要刪除嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                strSQL = $@"delete odca where odca_nbr = '{strNbr}'";
                clsDB.Execute(strSQL);
                btnClear.PerformClick();
                MessageBox.Show("已刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            //全部刪除
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                if (MessageBox.Show("是否確定要刪除已查詢的資料?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                for(int i = 0; i <dgvData.Rows.Count; i++)
                {
                    strSQL = $@"delete odca where odca_nbr = '{dgvData.Rows[i].Cells["nbr"].Value.ToString()}'";
                    clsDB.Execute(strSQL);
                }
                
                btnClear.PerformClick();
                MessageBox.Show("已刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (strNbr != "")
                {
                    btnDelete.PerformClick();
                }
            }
        }
    }
}
