using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Price2
{
    public partial class frmSafetyFees_Input : Form
    {
        string strCal = ""; //計算式
        string strCreateDate = "";
        public frmSafetyFees_Input()
        {
            InitializeComponent();
        }

        private void frmSafetyFees_Input_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                dtpDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                dtpDateS.Text = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd"); //年初
                dtpDateE.Text = DateTime.Now.ToString("yyyy/MM/dd");

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmSafetyFees_Input_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnInq_Click(object sender, EventArgs e)
        {
            //查詢
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
            string strDateS = dtpDateS.Value.ToString("yyyyMMdd");
            string strDateE = dtpDateE.Value.ToString("yyyyMMdd");
            this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select factory                    '工廠別',
                               cable                      '電源線材分類',
                               category                   '費用類別',
                               spec                       '規格',
                               agency                     '收費機構',
                               item                       '收費項目',
                               Format(date, 'yyyy/MM/dd') as 'Invoice日期',
                               invoice                    'InvoiceNo',
                               currency                   '幣別',
                               purprice                   '原幣金額',
                               tbprice                    '臺幣金額',
                               note                       '備註',
                               user_id                    '修改人員',
                               pcal,
                               create_date
                        from   safety_fees
                        where  Format(date, 'yyyyMMdd') between '{strDateS}' and '{strDateE}' ";
            strSQL = strSQL + Get_strWhere() + " order by date";
            dt = clsDB.sql_select_dt(strSQL);
            if(dt.Rows.Count>0)
            {
                lblCount.Text = "資料筆數：" + dt.Rows.Count.ToString();
                dgvData.DataSource = dt;    
            }
            else
            {
                MessageBox.Show("查不到資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Cursor = Cursors.Default;//滑鼠還原預設
        }

        private string Get_strWhere()
        {
            string strWhere = "";

            //工廠別
            strWhere = strWhere + (cboFactory.Text == "" ? "" : $@"and factory = '{cboFactory.Text.Trim()}' ");
            //電源線材分類
            strWhere = strWhere + (cboCable.Text == "" ? "" : $@"and cable = '{cboCable.Text.Trim()}' ");
            //費用類別
            strWhere = strWhere + (cboCategory.Text == "" ? "" : $@"and category = '{cboCategory.Text.Trim()}' ");
            //規格
            strWhere = strWhere + (cboSpec.Text == "" ? "" : $@"and spec = '{cboSpec.Text.Trim()}' ");
            //收費機構
            strWhere = strWhere + (cboAgency.Text == "" ? "" : $@"and agency = '{cboAgency.Text.Trim()}' ");
            //收費項目
            if (txtItem.Text.Trim() != "")//冒號分號多條件搜尋
            {
                strWhere = strWhere + clsGlobal.MulitSelect("item", txtItem.Text.Trim());
            }


            return strWhere;
        }

        private void cboSpec_TextChanged(object sender, EventArgs e)
        {
            //美規
            string[] strA = { "UL", "CSA" };
            //歐規
            string[] strB = { "CEBEC", "Dekra", "Demko", "Fimko", "IMQ", "Nemko", "Semko", "VDE", "OVE", "Swiss 瑞士" };
            //英規
            string[] strC = { "BSI" };
            //澳規
            string[] strD = { "SAA" };
            //其他
            string[] strE = { "ETL", "USB", "HDMI", "VESA" };
            //外校
            string[] strF = { "CN", "VN" };

            string[] strArr = new string[] { };
            switch (cboSpec.Text)
            {
                case "美規":
                    strArr = strA;
                    break;
                case "歐規":
                    strArr = strB;
                    break;
                case "英規":
                    strArr = strC;
                    break;
                case "澳規":
                    strArr = strD;
                    break;
                case "其他":
                    strArr = strE;
                    break;
                case "外校":
                    strArr = strF;
                    break;
                default:

                    break;
            }
            cboAgency.Text = "";
            cboAgency.Items.Clear();
            for (int i = 0; i < strArr.Length; i++)
            {
                cboAgency.Items.Add(strArr[i]);
            }
        }

        private void cboAgency_Enter(object sender, EventArgs e)
        {
            if(cboSpec.Text=="")
            {
                MessageBox.Show("請先選擇規格!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void txtPurprice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtNote.Focus();
            }
        }

        private void getCal()
        {
            strCal = txtPurprice.Text;

            //計算式  計算機 引用using System.Data
            txtPurprice.Text = Convert.ToDouble(new DataTable().Compute(txtPurprice.Text, null)).ToString("0.###");
            
        }

        private void txtPurprice_Enter(object sender, EventArgs e)
        {
            if (strCal != "")
            {
                txtPurprice.Text = strCal;
            }
        }

        private void txtPurprice_DoubleClick(object sender, EventArgs e)
        {
            if (strCal != "")
            {
                MessageBox.Show("計算式:  "+strCal, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void txtPurprice_Leave(object sender, EventArgs e)
        {
            getCal();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                cboSpec.Text = "";
                cboAgency.Text = "";

                cboCable.Text = "";
                cboCategory.Text = "";
                txtItem.Text = "";
                txtInvoiceNo.Text = "";
                cboCurrency.Text = "";
                txtPurprice.Text = "";
                strCreateDate = "";
                strCal = "";
                txtNote.Text = "";
                lblCount.Text = "資料筆數：0";
                if (dgvData.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)dgvData.DataSource;
                    dt.Rows.Clear();
                    dgvData.DataSource = dt;
                }
                //時間初始化設定
                dtpDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                dtpDateS.Text = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd"); //年初
                dtpDateE.Text = DateTime.Now.ToString("yyyy/MM/dd");
                cboFactory.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //新增
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                //欄位限制防呆
                if(cboSpec.Text=="")
                {
                    MessageBox.Show("規格不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboAgency.Text == "")
                {
                    MessageBox.Show("收費機構不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboCable.Text == "")
                {
                    MessageBox.Show("電源線材不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboCategory.Text == "")
                {
                    MessageBox.Show("費用類別不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtItem.Text == "")
                {
                    MessageBox.Show("收費項目不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboCurrency.Text == "")
                {
                    MessageBox.Show("幣種不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtPurprice.Text == "")
                {
                    MessageBox.Show("金額不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboFactory.Text == "")
                {
                    MessageBox.Show("工廠別不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("確定要新增嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                //先換算臺幣
                Single sngTP = 0;
                strSQL = $@"select cum_convert
                            from   cum
                            where  cum_code='{cboCurrency.Text}'
                            and    cum_adddate= (　select MAX(cum_adddate) from cum where cum_code = '{cboCurrency.Text}' and　format(cum_adddate,'yyyyMM') <= '{dtpDate.Value.ToString("yyyyMM")}')";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count>0)
                {
                    sngTP = Convert.ToSingle(txtPurprice.Text) * Convert.ToSingle(dt.Rows[0]["cum_convert"]);
                }

                strSQL = $@"insert into safety_fees
                                        (spec,
                                         agency,
                                         cable,
                                         category,
                                         date,
                                         item,
                                         invoice,
                                         currency,
                                         purprice,
                                         note,
                                         pcal,
                                         user_id,
                                         tbprice,
                                         factory,
                                         create_date)
                            values      ('{ cboSpec.Text }',
                                         '{ cboAgency.Text}',
                                         '{ cboCable.Text}',
                                         '{ cboCategory.Text}',
                                         '{ dtpDate.Text}',
                                         '{ txtItem.Text}',
                                         '{ txtInvoiceNo.Text}',
                                         '{ cboCurrency.Text}',
                                         { txtPurprice.Text},
                                         '{ txtNote.Text}',
                                         '{ strCal }',
                                         '{ clsGlobal.strG_User }',
                                         '{ sngTP.ToString("0.##") }',
                                         '{ cboFactory.Text }',
                                         Getdate()) ";
                clsDB.Execute(strSQL);
                
                //清除欄位
                cboSpec.Text = "";
                cboAgency.Text = "";
                cboCable.Text = "";
                cboCategory.Text = "";
                txtItem.Text = "";
                txtInvoiceNo.Text = "";
                cboCurrency.Text = "";
                txtPurprice.Text = "";
                strCreateDate = "";
                txtNote.Text = "";
                strCal = "";
                cboFactory.Text = "";
                //輸入後顯示查詢
                getData();
                MessageBox.Show("新增完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnAdd_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                strCreateDate = dgvData.Rows[e.RowIndex].Cells["create_date"].Value.ToString();
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                //更新畫面中的欄位資料
                cboFactory.Text = dgvData.Rows[e.RowIndex].Cells["工廠別"].Value.ToString();
                cboCable.Text = dgvData.Rows[e.RowIndex].Cells["電源線材分類"].Value.ToString();
                cboCategory.Text = dgvData.Rows[e.RowIndex].Cells["費用類別"].Value.ToString();
                cboSpec.Text = dgvData.Rows[e.RowIndex].Cells["規格"].Value.ToString();
                cboAgency.Text = dgvData.Rows[e.RowIndex].Cells["收費機構"].Value.ToString();
                txtItem.Text = dgvData.Rows[e.RowIndex].Cells["收費項目"].Value.ToString();
                dtpDate.Text = dgvData.Rows[e.RowIndex].Cells["Invoice日期"].Value.ToString();
                txtInvoiceNo.Text = dgvData.Rows[e.RowIndex].Cells["InvoiceNo"].Value.ToString();
                cboCurrency.Text = dgvData.Rows[e.RowIndex].Cells["幣別"].Value.ToString();
                txtPurprice.Text = dgvData.Rows[e.RowIndex].Cells["原幣金額"].Value.ToString();
                //台幣金額(11)
                //修改人員(12)
                txtNote.Text = dgvData.Rows[e.RowIndex].Cells["備註"].Value.ToString();
                strCal = dgvData.Rows[e.RowIndex].Cells["PCal"].Value.ToString();
                strCreateDate = dgvData.Rows[e.RowIndex].Cells["create_date"].Value.ToString();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //修改
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                //欄位限制防呆
                if (cboSpec.Text == "")
                {
                    MessageBox.Show("規格不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboAgency.Text == "")
                {
                    MessageBox.Show("收費機構不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboCable.Text == "")
                {
                    MessageBox.Show("電源線材不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboCategory.Text == "")
                {
                    MessageBox.Show("費用類別不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtItem.Text == "")
                {
                    MessageBox.Show("收費項目不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboCurrency.Text == "")
                {
                    MessageBox.Show("幣種不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtPurprice.Text == "")
                {
                    MessageBox.Show("金額不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboFactory.Text == "")
                {
                    MessageBox.Show("工廠別不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("確定要新增嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                //先換算臺幣
                Single sngTP = 0;
                strSQL = $@"select cum_convert
                            from   cum
                            where  cum_code='{cboCurrency.Text}'
                            and    cum_adddate= (　select MAX(cum_adddate) from cum where cum_code = '{cboCurrency.Text}' and　format(cum_adddate,'yyyyMM') <= '{dtpDate.Value.ToString("yyyyMM")}')";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    sngTP = Convert.ToSingle(txtPurprice.Text) * Convert.ToSingle(dt.Rows[0]["cum_convert"]);
                }

                strSQL = $@"update safety_fees
                            set    spec = '{cboSpec.Text}',
                                   agency = '{cboAgency.Text}',
                                   cable = '{cboCable.Text}',
                                   category = '{cboCategory.Text}',
                                   date = '{dtpDate.Text}',
                                   item = '{txtItem.Text}',
                                   invoice = '{txtInvoiceNo.Text}',
                                   currency = '{cboCurrency.Text}',
                                   purprice = {txtPurprice.Text},
                                   note = '{txtNote.Text}',
                                   pcal = '{strCal}',
                                   user_id = '{clsGlobal.strG_User}',
                                   tbprice = '{sngTP.ToString("0.##")}',
                                   factory = '{cboFactory.Text}',
                                   update_date = Getdate() 
                            where  format(create_date,'yyyyMMddHHmmss') = '{Convert.ToDateTime(strCreateDate).ToString("yyyyMMddHHmmss")}' ";
                clsDB.Execute(strSQL);
                
                //清除欄位
                cboSpec.Text = "";
                cboAgency.Text = "";
                cboCable.Text = "";
                cboCategory.Text = "";
                txtItem.Text = "";
                txtInvoiceNo.Text = "";
                cboCurrency.Text = "";
                txtPurprice.Text = "";
                strCreateDate = "";
                txtNote.Text = "";
                strCal = "";
                cboFactory.Text = "";
                //輸入後顯示查詢
                getData();
                MessageBox.Show("修改完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnModify_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();

                if (MessageBox.Show("確定要刪除嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                strSQL = $@"delete from safety_fees
                            where  Format(create_date, 'yyyyMMddHHmmss') = '{Convert.ToDateTime(strCreateDate).ToString("yyyyMMddHHmmss")}' ";
                clsDB.Execute(strSQL);
                
                //清除欄位
                cboSpec.Text = "";
                cboAgency.Text = "";
                cboCable.Text = "";
                cboCategory.Text = "";
                txtItem.Text = "";
                txtInvoiceNo.Text = "";
                cboCurrency.Text = "";
                txtPurprice.Text = "";
                strCreateDate = "";
                txtNote.Text = "";
                strCal = "";
                cboFactory.Text = "";
                //輸入後顯示查詢
                getData();
                MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if(strCreateDate!="")
                {
                    btnDelete_Click(null, null);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("每月安規費用登錄明細查詢", dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
