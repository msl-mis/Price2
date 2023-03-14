using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Price2
{
    public partial class frmLabel_UL817_Input : Form
    {
        string strCreateDate = "";
        public frmLabel_UL817_Input()
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

        private void frmLabel_UL817_Input_Load(object sender, EventArgs e)
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
                MessageBox.Show(this.Name + "-frmLabel_UL817_Input_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLabel_UL817_Input_Activated(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                getData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmLabel_UL817_Input_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dtpDateS.Value > dtpDateE.Value)
            {
                MessageBox.Show("起始日期不可以大於結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string strDateS = dtpDateS.Value.ToString("yyyyMMdd");
            string strDateE = dtpDateE.Value.ToString("yyyyMMdd");
            this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select factory,
                               Format(order_date, 'yyyy/MM/dd') as order_date,
                               label_type,
                               quantity,
                               purprice,
                               fees_label,
                               fees_shipping,
                               fees_handling,
                               usd_price,
                               tb_price,
                               label_type_25,
                               label_type_50,
                               label_type_100,
                               label_type_cordset,
                               note,
                               user_id,
                               create_date
                        from   ul817_label
                        where  Format(order_date, 'yyyyMMdd') between
                               '{strDateS}' and '{strDateE}' ";
            strSQL = strSQL + Get_strWhere() + " order by order_date";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                lblCount.Text = "資料筆數：" + dt.Rows.Count.ToString();
                dgvData.DataSource = dt;
            }
            else
            {
                lblCount.Text = "資料筆數：0";
                dgvData.DataSource = dt;
                MessageBox.Show("查不到資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Cursor = Cursors.Default;//滑鼠還原預設
        }

        private string Get_strWhere()
        {
            string strWhere = "";

            //廠區
            strWhere = strWhere + (cboFactory.Text == "" ? "" : $@"and factory = '{cboFactory.Text.Trim()}' ");
            //標籤種類
            strWhere = strWhere + (cboType.Text == "" ? "" : $@"and label_type = '{cboType.Text.Trim()}' ");

            return strWhere;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                cboFactory.Text = "";
                cboType.Text = "";
                txtHandling.Text = "";
                txtNote.Text = "";
                txtPurprice.Text = "";
                txtQuantity.Text = "";
                txtShipping.Text = "";
                txtType_100.Text = "";
                txtType_25.Text = "";
                txtType_50.Text = "";
                txtType_Cordset.Text = "";
                strCreateDate = "";

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

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("UL817標籤數量與價格登錄查詢", dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //新增
            try
            {
                Double dblQuantity = 0;
                Double dblPurprice = 0;
                Double dblLabel_fee = 0;
                Double dblShipping_fee = 0;
                Double dblHandling_fee = 0;
                Double dblPrice_usd = 0;
                Double dblPrice_tb = 0;
                Double dblType_25 = 0;
                Double dblType_50 = 0;
                Double dblType_100 = 0;
                Double dblType_Cordset = 0;

                string strPrice_usd = "";
                string strSQL = "";
                DataTable dt = new DataTable();
                //欄位限制防呆
                if (cboFactory.Text == "")
                {
                    MessageBox.Show("請選擇廠別!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboType.Text == "")
                {
                    MessageBox.Show("請選擇標籤種類!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtQuantity.Text == "")
                {
                    MessageBox.Show("購買數量/K張 不能為空!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtQuantity.Text == "0")
                {
                    MessageBox.Show("購買數量/K張 不能為0!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtPurprice.Text == "")
                {
                    MessageBox.Show("單價/卷 不能為空!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtPurprice.Text == "0")
                {
                    MessageBox.Show("單價/卷 不能為0!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("確定要新增嗎 ?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if(cboType.Text == "外箱標籤")
                {
                    dblQuantity = Convert.ToDouble(txtQuantity.Text);
                    dblPurprice = Convert.ToDouble(txtPurprice.Text);
                    dblLabel_fee = dblQuantity * dblPurprice;    //標籤費用=(購買數量/K張)*(單價/卷);

                    if(txtShipping.Text == "")
                    {
                        txtShipping.Text = "0";
                    }
                    dblShipping_fee = Convert.ToDouble(txtShipping.Text);
                    if (txtHandling.Text == "")
                    {
                        txtHandling.Text = "0";
                    }
                    dblHandling_fee = Convert.ToDouble(txtHandling.Text);

                    dblPrice_usd = dblLabel_fee + dblShipping_fee + dblHandling_fee; //總費用(美金)=標籤費用+船運費用+管理費
                    
                    //先換算臺幣
                    strSQL = $@"select cum_convert
                            from   cum
                            where  cum_code='美金'
                            and    cum_adddate= (　select MAX(cum_adddate) from cum where cum_code = '美金' and　format(cum_adddate,'yyyyMM') <= '{dtpDate.Value.ToString("yyyyMM")}')";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        dblPrice_tb = dblPrice_usd * Convert.ToSingle(dt.Rows[0]["cum_convert"]);
                    }

                    if (txtType_25.Text == "")
                    {
                        txtType_25.Text = "0";
                    }
                    if (txtType_50.Text == "")
                    {
                        txtType_50.Text = "0";
                    }
                    if (txtType_100.Text == "")
                    {
                        txtType_100.Text = "0";
                    }
                    dblType_25 = Convert.ToDouble(txtType_25.Text);
                    dblType_50 = Convert.ToDouble(txtType_50.Text);
                    dblType_100 = Convert.ToDouble(txtType_100.Text);

                    strSQL = $@"insert into ul817_label
                                            (factory,
                                             order_date,
                                             label_type,
                                             quantity,
                                             purprice,
                                             fees_label,
                                             fees_shipping,
                                             fees_handling,
                                             usd_price,
                                             tb_price,
                                             label_type_25,
                                             label_type_50,
                                             label_type_100,
                                             note,
                                             user_id,
                                             create_date)
                                values      ('{cboFactory.Text}',
                                             '{dtpDate.Value.ToString("yyyy/MM/dd")}',
                                             '{cboType.Text}',
                                             {dblQuantity},
                                             {dblPurprice},
                                             {dblLabel_fee},
                                             {dblShipping_fee},
                                             {dblHandling_fee},
                                             {dblPrice_usd},
                                             {dblPrice_tb},
                                             {dblType_25},
                                             {dblType_50},
                                             {dblType_100},
                                             '{txtNote.Text}',
                                             '{clsGlobal.strG_User}',
                                             Getdate()) ";
                    clsDB.Execute(strSQL);
                    //清除欄位
                    cboFactory.Text = "";
                    cboType.Text = "";
                    txtQuantity.Text = "";
                    txtPurprice.Text = "";
                    txtShipping.Text = "";
                    txtHandling.Text = "";
                    txtType_25.Text = "";
                    txtType_50.Text= "";
                    txtType_100.Text = "";
                    txtType_Cordset.Text = "";
                    strCreateDate = "";
                    dtpDate.Value = DateTime.Now;
                    txtNote.Text = "";
                    //新增後顯示查詢
                    getData();
                    MessageBox.Show("新增完畢", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if(cboType.Text == "CORD SET")
                {
                    dblQuantity = Convert.ToDouble(txtQuantity.Text);
                    dblPurprice = Convert.ToDouble(txtPurprice.Text);
                    dblLabel_fee = dblQuantity * dblPurprice;    //標籤費用=(購買數量/K張)*(單價/卷);

                    if (txtShipping.Text == "")
                    {
                        txtShipping.Text = "0";
                    }
                    dblShipping_fee = Convert.ToDouble(txtShipping.Text);
                    if (txtHandling.Text == "")
                    {
                        txtHandling.Text = "0";
                    }
                    dblHandling_fee = Convert.ToDouble(txtHandling.Text);

                    dblPrice_usd = dblLabel_fee + dblShipping_fee + dblHandling_fee; //總費用(美金)=標籤費用+船運費用+管理費

                    //先換算臺幣
                    strSQL = $@"select cum_convert
                            from   cum
                            where  cum_code='美金'
                            and    cum_adddate= (　select MAX(cum_adddate) from cum where cum_code = '美金' and　format(cum_adddate,'yyyyMM') <= '{dtpDate.Value.ToString("yyyyMM")}')";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        dblPrice_tb = dblPrice_usd * Convert.ToSingle(dt.Rows[0]["cum_convert"]);
                    }

                    if (txtType_Cordset.Text == "")
                    {
                        txtType_Cordset.Text = "0";
                    }
                    dblType_Cordset = Convert.ToDouble(txtType_Cordset.Text);
                  

                    strSQL = $@"insert into ul817_label
                                            (factory,
                                             order_date,
                                             label_type,
                                             quantity,
                                             purprice,
                                             fees_label,
                                             fees_shipping,
                                             fees_handling,
                                             usd_price,
                                             tb_price,
                                             label_type_cordset,
                                             note,
                                             user_id,
                                             create_date)
                                values      ('{cboFactory.Text}',
                                             '{dtpDate.Value.ToString("yyyy/MM/dd")}',
                                             '{cboType.Text}',
                                             {dblQuantity},
                                             {dblPurprice},
                                             {dblLabel_fee},
                                             {dblShipping_fee},
                                             {dblHandling_fee},
                                             {dblPrice_usd},
                                             {dblPrice_tb},
                                             {dblType_Cordset},
                                             '{txtNote.Text}',
                                             '{clsGlobal.strG_User}',
                                             Getdate()) ";
                    clsDB.Execute(strSQL);
                    //清除欄位
                    cboFactory.Text = "";
                    cboType.Text = "";
                    txtQuantity.Text = "";
                    txtPurprice.Text = "";
                    txtShipping.Text = "";
                    txtHandling.Text = "";
                    txtType_25.Text = "";
                    txtType_50.Text = "";
                    txtType_100.Text = "";
                    txtType_Cordset.Text = "";
                    strCreateDate = "";
                    dtpDate.Value = DateTime.Now;
                    txtNote.Text = "";
                    //新增後顯示查詢
                    getData();
                    MessageBox.Show("新增完畢", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnAdd_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //修改
            try
            {
                Double dblQuantity = 0;
                Double dblPurprice = 0;
                Double dblLabel_fee = 0;
                Double dblShipping_fee = 0;
                Double dblHandling_fee = 0;
                Double dblPrice_usd = 0;
                Double dblPrice_tb = 0;
                Double dblType_25 = 0;
                Double dblType_50 = 0;
                Double dblType_100 = 0;
                Double dblType_Cordset = 0;

                string strSQL = "";
                DataTable dt = new DataTable();
                //欄位限制防呆
                if (cboFactory.Text == "")
                {
                    MessageBox.Show("請選擇廠別!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboType.Text == "")
                {
                    MessageBox.Show("請選擇標籤種類!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtQuantity.Text == "")
                {
                    MessageBox.Show("購買數量/K張 不能為空!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtQuantity.Text == "0")
                {
                    MessageBox.Show("購買數量/K張 不能為0!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtPurprice.Text == "")
                {
                    MessageBox.Show("單價/卷 不能為空!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtPurprice.Text == "0")
                {
                    MessageBox.Show("單價/卷 不能為0!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("確定要修改嗎 ?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if (cboType.Text == "外箱標籤")
                {
                    dblQuantity = Convert.ToDouble(txtQuantity.Text);
                    dblPurprice = Convert.ToDouble(txtPurprice.Text);
                    dblLabel_fee = dblQuantity * dblPurprice;    //標籤費用=(購買數量/K張)*(單價/卷);

                    if (txtShipping.Text == "")
                    {
                        txtShipping.Text = "0";
                    }
                    dblShipping_fee = Convert.ToDouble(txtShipping.Text);
                    if (txtHandling.Text == "")
                    {
                        txtHandling.Text = "0";
                    }
                    dblHandling_fee = Convert.ToDouble(txtHandling.Text);

                    dblPrice_usd = dblLabel_fee + dblShipping_fee + dblHandling_fee; //總費用(美金)=標籤費用+船運費用+管理費

                    //先換算臺幣
                    strSQL = $@"select cum_convert
                            from   cum
                            where  cum_code='美金'
                            and    cum_adddate= (　select MAX(cum_adddate) from cum where cum_code = '美金' and　format(cum_adddate,'yyyyMM') <= '{dtpDate.Value.ToString("yyyyMM")}')";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        dblPrice_tb = dblPrice_usd * Convert.ToSingle(dt.Rows[0]["cum_convert"]);
                    }

                    if (txtType_25.Text == "")
                    {
                        txtType_25.Text = "0";
                    }
                    if (txtType_50.Text == "")
                    {
                        txtType_50.Text = "0";
                    }
                    if (txtType_100.Text == "")
                    {
                        txtType_100.Text = "0";
                    }
                    dblType_25 = Convert.ToDouble(txtType_25.Text);
                    dblType_50 = Convert.ToDouble(txtType_50.Text);
                    dblType_100 = Convert.ToDouble(txtType_100.Text);

                    strSQL = $@"update ul817_label
                                set    factory = '{cboFactory.Text}',
                                       order_date = '{dtpDate.Value.ToString("yyyy/MM/dd")}',
                                       label_type = '{cboType.Text}',
                                       quantity = {dblQuantity},
                                       purprice = {dblPurprice},
                                       fees_label = {dblLabel_fee},
                                       fees_shipping = {dblShipping_fee},
                                       fees_handling = {dblHandling_fee},
                                       usd_price = {dblPrice_usd},
                                       tb_price = {dblPrice_tb},
                                       label_type_25 = {dblType_25},
                                       label_type_50 = {dblType_50},
                                       label_type_100 = {dblType_100},
                                       note = '{txtNote.Text}',
                                       user_id = '{clsGlobal.strG_User}',
                                       update_date = Getdate()
                                where Format(create_date, 'yyyyMMddHHmmss') = '{Convert.ToDateTime(strCreateDate).ToString("yyyyMMddHHmmss")}' ";
                    clsDB.Execute(strSQL);
                    //清除欄位
                    cboFactory.Text = "";
                    cboType.Text = "";
                    txtQuantity.Text = "";
                    txtPurprice.Text = "";
                    txtShipping.Text = "";
                    txtHandling.Text = "";
                    txtType_25.Text = "";
                    txtType_50.Text = "";
                    txtType_100.Text = "";
                    txtType_Cordset.Text = "";
                    strCreateDate = "";
                    dtpDate.Value = DateTime.Now;
                    txtNote.Text = "";
                    //新增後顯示查詢
                    getData();
                    MessageBox.Show("修改完畢", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (cboType.Text == "CORD SET")
                {
                    dblQuantity = Convert.ToDouble(txtQuantity.Text);
                    dblPurprice = Convert.ToDouble(txtPurprice.Text);
                    dblLabel_fee = dblQuantity * dblPurprice;    //標籤費用=(購買數量/K張)*(單價/卷);

                    if (txtShipping.Text == "")
                    {
                        txtShipping.Text = "0";
                    }
                    dblShipping_fee = Convert.ToDouble(txtShipping.Text);
                    if (txtHandling.Text == "")
                    {
                        txtHandling.Text = "0";
                    }
                    dblHandling_fee = Convert.ToDouble(txtHandling.Text);

                    dblPrice_usd = dblLabel_fee + dblShipping_fee + dblHandling_fee; //總費用(美金)=標籤費用+船運費用+管理費

                    //先換算臺幣
                    strSQL = $@"select cum_convert
                            from   cum
                            where  cum_code='美金'
                            and    cum_adddate= (　select MAX(cum_adddate) from cum where cum_code = '美金' and　format(cum_adddate,'yyyyMM') <= '{dtpDate.Value.ToString("yyyyMM")}')";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        dblPrice_tb = dblPrice_usd * Convert.ToSingle(dt.Rows[0]["cum_convert"]);
                    }

                    if (txtType_Cordset.Text == "")
                    {
                        txtType_Cordset.Text = "0";
                    }
                    dblType_Cordset = Convert.ToDouble(txtType_Cordset.Text);


                    strSQL = $@"update ul817_label
                                set    factory = '{cboFactory.Text}',
                                       order_date = '{dtpDate.Value.ToString("yyyy/MM/dd")}',
                                       label_type = '{cboType.Text}',
                                       quantity = {dblQuantity},
                                       purprice = {dblPurprice},
                                       fees_label = {dblLabel_fee},
                                       fees_shipping = {dblShipping_fee},
                                       fees_handling = {dblHandling_fee},
                                       usd_price = {dblPrice_usd},
                                       tb_price = {dblPrice_tb},
                                       label_type_cordset = {dblType_Cordset},
                                       note = '{txtNote.Text}',
                                       user_id = '{clsGlobal.strG_User}',
                                       update_date = Getdate()
                                where  Format(create_date, 'yyyyMMddHHmmss') = '{Convert.ToDateTime(strCreateDate).ToString("yyyyMMddHHmmss")}' ";
                    clsDB.Execute(strSQL);
                    //清除欄位
                    cboFactory.Text = "";
                    cboType.Text = "";
                    txtQuantity.Text = "";
                    txtPurprice.Text = "";
                    txtShipping.Text = "";
                    txtHandling.Text = "";
                    txtType_25.Text = "";
                    txtType_50.Text = "";
                    txtType_100.Text = "";
                    txtType_Cordset.Text = "";
                    strCreateDate = "";
                    dtpDate.Value = DateTime.Now;
                    txtNote.Text = "";
                    //新增後顯示查詢
                    getData();
                    MessageBox.Show("修改完畢", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnModify_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboType_TextChanged(object sender, EventArgs e)
        {
            if(cboType.Text == "外箱標籤")
            {
                txtType_Cordset.Text = "";
                txtType_Cordset.Enabled = false;
                txtType_25.Enabled = true;
                txtType_50.Enabled = true;
                txtType_100.Enabled = true;
            }
            else if (cboType.Text == "CORD SET")
            {
                txtType_Cordset.Enabled = true;
                txtType_25.Text = "";
                txtType_25.Enabled = false;
                txtType_50.Text = "";
                txtType_50.Enabled = false;
                txtType_100.Text = "";
                txtType_100.Enabled = false;
            }
            else
            {
                txtType_Cordset.Enabled = true;
                txtType_25.Enabled = true;
                txtType_50.Enabled = true;
                txtType_100.Enabled = true;
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                //更新畫面中的欄位資料
                cboFactory.Text = dgvData.Rows[e.RowIndex].Cells["factory"].Value.ToString();
                dtpDate.Text = dgvData.Rows[e.RowIndex].Cells["order_date"].Value.ToString();
                cboType.Text = dgvData.Rows[e.RowIndex].Cells["label_type"].Value.ToString();
                txtQuantity.Text = dgvData.Rows[e.RowIndex].Cells["quantity"].Value.ToString();
                txtPurprice.Text = dgvData.Rows[e.RowIndex].Cells["purprice"].Value.ToString();
                txtShipping.Text = dgvData.Rows[e.RowIndex].Cells["fees_shipping"].Value.ToString();
                txtHandling.Text = dgvData.Rows[e.RowIndex].Cells["fees_handling"].Value.ToString();
                txtType_25.Text = dgvData.Rows[e.RowIndex].Cells["label_type_25"].Value.ToString();
                txtType_50.Text = dgvData.Rows[e.RowIndex].Cells["label_type_50"].Value.ToString();
                txtType_100.Text = dgvData.Rows[e.RowIndex].Cells["label_type_100"].Value.ToString();

                txtType_Cordset.Text = dgvData.Rows[e.RowIndex].Cells["label_type_cordset"].Value.ToString();
                txtNote.Text = dgvData.Rows[e.RowIndex].Cells["note"].Value.ToString();
                dgvData.Rows[e.RowIndex].Cells["create_date"].Value.ToString();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                if (strCreateDate == "")
                {
                    return;
                }
                if (MessageBox.Show("確定要刪除嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                strSQL = $@"delete from ul817_label 
                            where  Format(create_date, 'yyyyMMddHHmmss') = '{Convert.ToDateTime(strCreateDate).ToString("yyyyMMddHHmmss")}' ";
                clsDB.Execute(strSQL);

                //清除欄位
                cboFactory.Text = "";
                cboType.Text = "";
                txtQuantity.Text = "";
                txtPurprice.Text = "";
                txtShipping.Text = "";
                txtHandling.Text = "";
                txtType_25.Text = "";
                txtType_50.Text = "";
                txtType_100.Text = "";
                txtType_Cordset.Text = "";
                strCreateDate = "";
                dtpDate.Value = DateTime.Now;
                txtNote.Text = "";
                //新增後顯示查詢
                getData();
                MessageBox.Show("刪除成功", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                strCreateDate = dgvData.Rows[e.RowIndex].Cells["create_date"].Value.ToString();
            }
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (strCreateDate != "")
                {
                    btnDelete_Click(null, null);
                }
            }
        }
    }
}
