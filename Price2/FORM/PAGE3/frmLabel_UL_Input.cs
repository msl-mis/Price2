using Sunny.UI.Win32;
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
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Price2
{
    public partial class frmLabel_UL_Input : Form
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

        string strCreateDate = "";
        public frmLabel_UL_Input()
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
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()
        {
            if(dtpDateS.Value>dtpDateE.Value)
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
                               class,
                               product_category,
                               id,
                               no,
                               invoice_no,
                               invoice_date,
                               label_type,
                               length,
                               quantity,
                               fees_yield,
                               fees_pcs,
                               fees_1000pcs,
                               fees_handling,
                               fees_service,
                               fees_label,
                               tb_price,
                               note,
                               user_id,
                               create_date,
                               q1,
                               r1,
                               q2,
                               r2,
                               q3,
                               r3
                        from   ul_label
                        where  Format(invoice_date, 'yyyyMMdd') between
                               '{strDateS}' and '{strDateE}' ";
            strSQL = strSQL  + " order by invoice_date";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                lblCount.Text = "資料筆數：" + dt.Rows.Count.ToString();
                dgvData.DataSource = dt;
            }
            else
            {
                lblCount.Text = "資料筆數：0";
                MessageBox.Show("查不到資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Cursor = Cursors.Default;//滑鼠還原預設
        }

        private void frmLabel_UL_Input_Load(object sender, EventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                cboID.Text = "";
                txtNo.Text = "";
                cboCategory.Text = "";
                cboLabeltype.Text = "";
                cboClass.Text = "";
                cboFactory.Text = "";
                txtInvoiceNo.Text = "";

                txtL.Enabled = true;
                txtQ.Enabled = true;
                txtA.Enabled = true;
                txtB.Enabled = true;
                txtB1.Enabled = true;
                txtB2.Enabled = true;
                txtC.Enabled = true;

                txtL.Text = "";
                txtQ.Text = "";
                txtA.Text = "";
                txtB.Text = "";
                txtB1.Text = "";
                txtB2.Text = "";
                txtC.Text = "";

                txtQ1.Enabled = true;
                txtQ2.Enabled = true;
                txtQ3.Enabled = true;

                txtR1.Enabled = true;
                txtR2.Enabled = true;
                txtR3.Enabled = true;

                txtQ1.Text = "";
                txtQ2.Text = "";
                txtQ3.Text = "";

                txtR1.Text = "";
                txtR2.Text = "";
                txtR3.Text = "";
                txtNote.Text = "";

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

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                //更新畫面中的欄位資料
                cboFactory.Text = dgvData.Rows[e.RowIndex].Cells["factory"].Value.ToString();
                cboClass.Text = dgvData.Rows[e.RowIndex].Cells["classS"].Value.ToString();
                cboCategory.Text = dgvData.Rows[e.RowIndex].Cells["product_category"].Value.ToString();
                cboID.Text = dgvData.Rows[e.RowIndex].Cells["id"].Value.ToString();
                txtNo.Text = dgvData.Rows[e.RowIndex].Cells["no"].Value.ToString();
                txtInvoiceNo.Text = dgvData.Rows[e.RowIndex].Cells["invoice_no"].Value.ToString();
                dtpDate.Text = dgvData.Rows[e.RowIndex].Cells["invoice_date"].Value.ToString();
                cboLabeltype.Text = dgvData.Rows[e.RowIndex].Cells["label_type"].Value.ToString();
                txtL.Text = dgvData.Rows[e.RowIndex].Cells["length"].Value.ToString();
                txtQ.Text = dgvData.Rows[e.RowIndex].Cells["quantity"].Value.ToString();
                
                txtA.Text = dgvData.Rows[e.RowIndex].Cells["fees_yield"].Value.ToString();
                txtB.Text = dgvData.Rows[e.RowIndex].Cells["fees_pcs"].Value.ToString();
                txtB1.Text = dgvData.Rows[e.RowIndex].Cells["fees_1000pcs"].Value.ToString();
                txtB2.Text = dgvData.Rows[e.RowIndex].Cells["fees_handling"].Value.ToString();
                txtC.Text = dgvData.Rows[e.RowIndex].Cells["fees_service"].Value.ToString();

                txtNote.Text = dgvData.Rows[e.RowIndex].Cells["note"].Value.ToString();
                strCreateDate = dgvData.Rows[e.RowIndex].Cells["create_date"].Value.ToString();
                txtQ1.Text = dgvData.Rows[e.RowIndex].Cells["q1"].Value.ToString();
                txtR1.Text = dgvData.Rows[e.RowIndex].Cells["r1"].Value.ToString();
                txtQ2.Text = dgvData.Rows[e.RowIndex].Cells["q2"].Value.ToString();
                txtR2.Text = dgvData.Rows[e.RowIndex].Cells["r2"].Value.ToString();
                txtQ3.Text = dgvData.Rows[e.RowIndex].Cells["q3"].Value.ToString();
                txtR3.Text = dgvData.Rows[e.RowIndex].Cells["r3"].Value.ToString();
            }
        }

        private void cboID_TextChanged(object sender, EventArgs e)
        {
            switch (cboID.Text)
            {
                case "軸貼/UL62標籤貼紙(100FT/軸)":
                    txtNo.Text = "A3FT03-0692";
                    cboCategory.Text = "UL62電源線";
                    cboLabeltype.Text = "鐳射標籤(100FT)";
                    cboClass.Text = "貼紙";
                    cboFactory.Text = "CN";
                    break;
                case "軸貼/UL758標籤貼紙(1000FT/軸)":
                    txtNo.Text = "A3FS70-0692";
                    cboCategory.Text = "UL758電子線";
                    cboLabeltype.Text = "藍色標籤(1000FT)";
                    cboClass.Text = "貼紙";
                    cboFactory.Text = "CN";
                    break;
                case "易拉箱/UL鐳射貼紙":
                    txtNo.Text = "ABAH35-0692";
                    cboCategory.Text = "UL444網絡線";
                    cboLabeltype.Text = "鐳射標籤(1000FT)";
                    cboClass.Text = "貼紙";
                    cboFactory.Text = "CN";
                    break;
                case "箱貼/UL Wire Harness":
                    txtNo.Text = "A3FS66-0692";
                    cboCategory.Text = "UL764線束產品";
                    cboLabeltype.Text = "FROM N";
                    cboClass.Text = "箱貼";
                    cboFactory.Text = "CN";
                    break;
                case "箱貼/UL Wire Harness(1-N)":
                    txtNo.Text = "A3FS67-0692";
                    cboCategory.Text = "UL764線束產品";
                    cboLabeltype.Text = "FROM 1-N";
                    cboClass.Text = "箱貼";
                    cboFactory.Text = "CN";
                    break;
                case "易拉箱/UL鐳射貼紙/vn":
                    txtNo.Text = "A3FT04-0692";
                    cboCategory.Text = "UL444網絡線";
                    cboLabeltype.Text = "鐳射標籤(1000FT)";
                    cboClass.Text = "貼紙";
                    cboFactory.Text = "VN";
                    break;
                case "箱貼/UL Wire Harness/vn":
                    txtNo.Text = "A3FT05-0692";
                    cboCategory.Text = "UL764線束產品";
                    cboLabeltype.Text = "FROM 1-N";
                    cboClass.Text = "箱貼";
                    cboFactory.Text = "VN";
                    break;
                case "箱貼/電源線UL鐳射貼紙(1/pc)":
                    txtNo.Text = "A3FS65-0692";
                    cboCategory.Text = "UL817電源插頭";
                    cboLabeltype.Text = "UL817外箱標籤";
                    cboClass.Text = "箱貼";
                    cboFactory.Text = "兩廠";
                    break;
                case "線貼/電源線UL鐳射貼紙":
                    txtNo.Text = "A3FS60-0692";
                    cboCategory.Text = "UL817電源插頭";
                    cboLabeltype.Text = "普通與戶外用 CORD SET(線上標籤)";
                    cboClass.Text = "貼紙";
                    cboFactory.Text = "兩廠";
                    break;
                default:

                    break;
            }
        }

        private void cboLabeltype_TextChanged(object sender, EventArgs e)
        {
            if (cboLabeltype.Text == "鐳射標籤(100FT)" || cboLabeltype.Text == "藍色標籤(1000FT)" || cboLabeltype.Text == "鐳射標籤(1000FT)")
            {
                txtL.Text = "";
                txtQ.Text = "";
                txtA.Text = "";
                txtB.Text = "";
                txtB1.Text = "";
                txtB2.Text = "";
                txtC.Text = "";
                txtQ1.Text = "";
                txtQ2.Text = "";
                txtQ3.Text = "";

                txtL.Enabled = true;
                txtQ.Enabled = true;
                txtA.Enabled = true;
                txtB.Enabled = false;
                txtB1.Enabled = true;
                txtB2.Enabled = true;
                txtC.Enabled = false;

                txtQ1.Enabled = false;
                txtQ2.Enabled = false;
                txtQ3.Enabled = false;

                txtR1.Enabled = false;
                txtR2.Enabled = false;
                txtR3.Enabled = false;
            }
            else if (cboLabeltype.Text == "FROM N" || cboLabeltype.Text == "FROM 1-N")
            {
                txtL.Text = "";
                txtQ.Text = "";
                txtA.Text = "";
                txtB.Text = "";
                txtB1.Text = "";
                txtB2.Text = "";
                txtC.Text = "";
                txtQ1.Text = "";
                txtQ2.Text = "";
                txtQ3.Text = "";

                txtL.Enabled = false;
                txtQ.Enabled = false;
                txtA.Enabled = false;
                txtB.Enabled = false;
                txtB1.Enabled = true;
                txtB2.Enabled = true;
                txtC.Enabled = true;

                txtQ1.Enabled = true;
                txtQ2.Enabled = true;
                txtQ3.Enabled = true;

                txtR1.Enabled = true;
                txtR2.Enabled = true;
                txtR3.Enabled = true;
            }
            else if (cboLabeltype.Text == "UL817外箱標籤")
            {
                txtL.Text = "";
                txtQ.Text = "";
                txtA.Text = "";
                txtB.Text = "";
                txtB1.Text = "";
                txtB2.Text = "";
                txtC.Text = "";
                txtQ1.Text = "";
                txtQ2.Text = "";
                txtQ3.Text = "";

                txtL.Enabled = false;
                txtQ.Enabled = false;
                txtA.Enabled = false;
                txtB.Enabled = true;
                txtB1.Enabled = false;
                txtB2.Enabled = false;
                txtC.Enabled = true;

                txtQ1.Enabled = false;
                txtQ2.Enabled = false;
                txtQ3.Enabled = false;

                txtR1.Enabled = false;
                txtR2.Enabled = false;
                txtR3.Enabled = false;

                Single Lblsum25 = 0;
                Single Lblsum50 = 0;
                Single Lblsum100 = 0;
                Single Outerlblsum = 0;
                Single Outpcsum = 0;

                //計算B
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select usd_price,
                                   label_type_25,
                                   label_type_50,
                                   label_type_100
                            from   UL817_label
                            where  label_type = '外箱標籤'
                                   and Datediff(YEAR, order_date, Getdate()) <= 3 ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Lblsum25 = Lblsum25 + Convert.ToSingle(dt.Rows[i]["label_type_25"]);
                        Lblsum50 = Lblsum50 + Convert.ToSingle(dt.Rows[i]["label_type_50"]);
                        Lblsum100 = Lblsum100 + Convert.ToSingle(dt.Rows[i]["label_type_100"]);
                        Outerlblsum = Outerlblsum + Convert.ToSingle(dt.Rows[i]["usd_price"]);
                    }
                }
                Outpcsum = Lblsum25 + Lblsum50 + Lblsum100;
                txtB.Text = (Outerlblsum / Outpcsum).ToString("#0.#########");
            }
            else if (cboLabeltype.Text == "普通與戶外用 CORD SET(線上標籤)")
            {
                txtL.Text = "";
                txtQ.Text = "";
                txtA.Text = "";
                txtB.Text = "";
                txtB1.Text = "";
                txtB2.Text = "";
                txtC.Text = "";
                txtQ1.Text = "";
                txtQ2.Text = "";
                txtQ3.Text = "";

                txtL.Enabled = false;
                txtQ.Enabled = false;
                txtA.Enabled = false;
                txtB.Enabled = true;
                txtB1.Enabled = false;
                txtB2.Enabled = false;
                txtC.Enabled = true;

                txtQ1.Enabled = false;
                txtQ2.Enabled = false;
                txtQ3.Enabled = false;

                txtR1.Enabled = false;
                txtR2.Enabled = false;
                txtR3.Enabled = false;

                Single LblsumCordSet = 0;
                Single Cordsetsum = 0;

                //計算B
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select usd_price,
                                   label_type_cordset
                            from   UL817_label
                            where  label_type = 'CORD SET'
                                   and Datediff(YEAR, order_date, Getdate()) <= 3 ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        LblsumCordSet = LblsumCordSet + Convert.ToSingle(dt.Rows[i]["label_type_cordset"]);
                        Cordsetsum = Cordsetsum + Convert.ToSingle(dt.Rows[i]["usd_price"]);

                    }
                }
                txtB.Text = (Cordsetsum / LblsumCordSet).ToString("#0.#########");

            }
            else
            {
                txtL.Text = "";
                txtQ.Text = "";
                txtA.Text = "";
                txtB.Text = "";
                txtB1.Text = "";
                txtB2.Text = "";
                txtC.Text = "";
                txtQ1.Text = "";
                txtQ2.Text = "";
                txtQ3.Text = "";

                txtL.Enabled = true;
                txtQ.Enabled = true;
                txtA.Enabled = true;
                txtB.Enabled = true;
                txtB1.Enabled = true;
                txtB2.Enabled = true;
                txtC.Enabled = true;

                txtQ1.Enabled = true;
                txtQ2.Enabled = true;
                txtQ3.Enabled = true;

                txtR1.Enabled = true;
                txtR2.Enabled = true;
                txtR3.Enabled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("UL標籤費用與成本登錄查詢", dgvData);
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
                Double dblL =0;
                Double dblQ = 0;
                Double dblA = 0;
                Double dblB = 0;
                Double dblB1 = 0;
                Double dblB2 = 0;
                Double dblC = 0;
                Double dblPrice_usd = 0;
                Double dblPrice_tb = 0;
                Double dblQ1 = 0;
                Double dblQ2 = 0;
                Double dblQ3 = 0;
                Double dblR1 = 0;
                Double dblR2 = 0;
                Double dblR3 = 0;


                string strPrice_usd = "";
                string strSQL = "";
                DataTable dt = new DataTable();
                //欄位限制防呆
                if (cboID.Text == "")
                {
                    MessageBox.Show("材料名 不能為空!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtNo.Text == "")
                {
                    MessageBox.Show("品號 不能為空!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboCategory.Text == "")
                {
                    MessageBox.Show("請選擇產品類別!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboLabeltype.Text == "")
                {
                    MessageBox.Show("請選擇標籤種類!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboClass.Text == "")
                {
                    MessageBox.Show("請選擇分類!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboFactory.Text == "")
                {
                    MessageBox.Show("請選擇廠區!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboClass.Text == "貼紙" && cboCategory.Text != "UL817電源插頭")
                {
                    if(txtQ.Text == "" || txtQ.Text == "0")
                    {
                        MessageBox.Show("購買卷數數不可為0或空!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (cboClass.Text == "貼紙" && cboCategory.Text != "UL817電源插頭")
                {
                    //先把空白補0
                    if (txtL.Text == "" )
                    {
                        txtL.Text = "0";
                    }
                    dblL = Convert.ToDouble(txtL.Text);

                    if (txtQ.Text == "")
                    {
                        txtQ.Text = "0";
                    }
                    dblQ = Convert.ToDouble(txtQ.Text);

                    if (txtA.Text == "")
                    {
                        txtA.Text = "0";
                    }
                    dblA = Convert.ToDouble(txtA.Text);

                    if (txtB1.Text == "")
                    {
                        txtB1.Text = "0";
                    }
                    dblB1 = Convert.ToDouble(txtB1.Text);

                    if (txtB2.Text == "")
                    {
                        txtB2.Text = "0";
                    }
                    dblB2 = Convert.ToDouble(txtB2.Text);

                    if (txtC.Text == "")
                    {
                        txtC.Text = "0";
                    }
                    dblC = Convert.ToDouble(txtC.Text);

                    dblPrice_usd = (dblB1 * dblQ + dblB2) / (1000 * dblQ) + (dblA / 1000) * dblL;
                    strPrice_usd = dblPrice_usd.ToString("#0.#########");
                }
                else if (cboClass.Text == "箱貼" && cboCategory.Text != "UL817電源插頭")
                {
                    if (txtB1.Text == "")
                    {
                        txtB1.Text = "0";
                    }
                    dblB1 = Convert.ToDouble(txtB1.Text);

                    if (txtB2.Text == "")
                    {
                        txtB2.Text = "0";
                    }
                    dblB2 = Convert.ToDouble(txtB2.Text);

                    if (txtC.Text == "")
                    {
                        txtC.Text = "0";
                    }
                    dblC = Convert.ToDouble(txtC.Text);

                    if (txtQ1.Text == "")
                    {
                        txtQ1.Text = "0";
                    }
                    dblQ1 = Convert.ToDouble(txtQ1.Text);

                    if (txtQ2.Text == "")
                    {
                        txtQ2.Text = "0";
                    }
                    dblQ2 = Convert.ToDouble(txtQ2.Text);

                    if (txtQ3.Text == "")
                    {
                        txtQ3.Text = "0";
                    }
                    dblQ3 = Convert.ToDouble(txtQ3.Text);

                    if (txtR1.Text == "")
                    {
                        txtR1.Text = "0";
                    }
                    dblR1 = Convert.ToDouble(txtR1.Text);

                    if (txtR2.Text == "")
                    {
                        txtR2.Text = "0";
                    }
                    dblR2 = Convert.ToDouble(txtR2.Text);

                    if (txtR3.Text == "")
                    {
                        txtR3.Text = "0";
                    }
                    dblR3 = Convert.ToDouble(txtR3.Text);
                    dblPrice_usd = (dblB1 + dblB2) / (dblQ1 * dblR1 + dblQ2 * dblR2 + dblQ3 * dblR3) / 10 + dblC;
                    strPrice_usd = dblPrice_usd.ToString("#0.#########");
                }
                else if (cboLabeltype.Text == "普通與戶外用 CORD SET(線上標籤)")
                {
                    if (txtB.Text == "")
                    {
                        txtB.Text = "0";
                    }
                    dblB = Convert.ToDouble(txtB.Text);

                    if (txtC.Text == "")
                    {
                        txtC.Text = "0";
                    }
                    dblC = Convert.ToDouble(txtC.Text);

                    dblPrice_usd = dblB + dblC;
                    strPrice_usd = dblPrice_usd.ToString("#0.#########");
                }
                else if (cboLabeltype.Text == "UL817外箱標籤")
                {
                    if (txtB.Text == "")
                    {
                        txtB.Text = "0";
                    }
                    dblB = Convert.ToDouble(txtB.Text);

                    if (txtC.Text == "")
                    {
                        txtC.Text = "0";
                    }
                    dblC = Convert.ToDouble(txtC.Text);

                    Single Lblsum25 = 0;
                    Single Lblsum50 = 0;
                    Single Lblsum100 = 0;
                    Single Outerlblsum = 0;
                    Single Outpcsum = 0;

                    //計算B
                    strSQL = $@"select usd_price,
                                   label_type_25,
                                   label_type_50,
                                   label_type_100
                            from   UL817_label
                            where  label_type = '外箱標籤'
                                   and Datediff(YEAR, order_date, Getdate()) <= 3 ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Lblsum25 = Lblsum25 + Convert.ToSingle(dt.Rows[i]["label_type_25"]);
                            Lblsum50 = Lblsum50 + Convert.ToSingle(dt.Rows[i]["label_type_50"]);
                            Lblsum100 = Lblsum100 + Convert.ToSingle(dt.Rows[i]["label_type_100"]);
                            Outerlblsum = Outerlblsum + Convert.ToSingle(dt.Rows[i]["usd_price"]);
                        }
                    }
                    double Outqtysum = Lblsum25 * 25 + Lblsum50 * 50 + Lblsum100 * 100;
                    dblPrice_usd = (Outerlblsum / Outqtysum) + dblC;

                    strPrice_usd = dblPrice_usd.ToString("#0.#########");
                }
                else
                {
                    MessageBox.Show("標籤費用/PC(USD)無法計算!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("標籤費用 / PC(USD) = "+ strPrice_usd +"確定要新增嗎 ?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                //先換算臺幣
                strSQL = $@"select cum_convert
                            from   cum
                            where  cum_code='美金'
                            and    cum_adddate= (　select MAX(cum_adddate) from cum where cum_code = '美金' and　format(cum_adddate,'yyyyMM') <= '{dtpDate.Value.ToString("yyyyMM")}')";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dblPrice_tb = Convert.ToSingle(strPrice_usd) * Convert.ToSingle(dt.Rows[0]["cum_convert"]);
                }

                strSQL = $@"insert into ul_label
                                        (factory,
                                         class,
                                         product_category,
                                         id,
                                         no,
                                         invoice_no,
                                         invoice_date,
                                         label_type,
                                         length,
                                         quantity,
                                         fees_yield,
                                         fees_pcs,
                                         fees_1000pcs,
                                         fees_handling,
                                         fees_service,
                                         fees_label,
                                         tb_price,
                                         note,
                                         user_id,
                                         create_date,
                                         q1,
                                         r1,
                                         q2,
                                         r2,
                                         q3,
                                         r3)
                            values      ('{ cboFactory.Text }',
                                         '{ cboClass.Text }',
                                         '{ cboCategory.Text }',
                                         '{ cboID.Text }',
                                         '{ txtNo.Text }',
                                         '{ txtInvoiceNo.Text }',
                                         '{ dtpDate.Value.ToString("yyyy/MM/dd") }',
                                         '{ cboLabeltype.Text }',
                                         { dblL },
                                         { dblQ },
                                         { dblA },
                                         { dblB },
                                         { dblB1 },
                                         { dblB2 },
                                         { dblC },
                                         { dblPrice_usd },
                                         { dblPrice_tb },
                                         '{ txtNote.Text }',
                                         '{ clsGlobal.strG_User }',
                                         Getdate(),
                                         { dblQ1 },
                                         { dblR1 },
                                         { dblQ2 },
                                         { dblR2 },
                                         { dblQ3 },
                                         { dblR3 }) ";
                clsDB.Execute(strSQL);

                //儲存火車頭
                //先取得asp參數
                GetAsp(cboID.Text);

                asp_purprice = Convert.ToDouble(strPrice_usd);      //單價
                asp_pricecal = strPrice_usd;                        //單價計算式
                DoUpdate_asp1();                     //更新asp資料(沒有做updateBOM)

                //清除欄位
                txtL.Enabled = true;
                txtQ.Enabled = true;
                txtA.Enabled = true;
                txtB.Enabled = true;
                txtB1.Enabled = true;
                txtB2.Enabled = true;
                txtC.Enabled = true;

                txtQ1.Enabled = true;
                txtQ2.Enabled = true;
                txtQ3.Enabled = true;

                txtR1.Enabled = true;
                txtR2.Enabled = true;
                txtR3.Enabled = true;

                cboFactory.Text = "";
                cboClass.Text = "";
                cboCategory.Text = "";
                cboID.Text = "";
                txtNo.Text = "";
                txtInvoiceNo.Text = "";
                cboLabeltype.Text = "";
                txtL.Text = "";
                txtQ.Text = "";
                txtA.Text = "";
                txtB.Text = "";
                txtB1.Text = "";
                txtB2.Text = "";
                txtC.Text = "";

                txtQ1.Text = "";
                txtQ2.Text = "";
                txtQ3.Text = "";

                txtR1.Text = "";
                txtR2.Text = "";
                txtR3.Text = "";

                strCreateDate = "";
                dtpDate.Value = DateTime.Now;
                txtNote.Text = "";
                //輸入後顯示查詢
                getData();
                MessageBox.Show("新增完畢;系統將回寫材料單價....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnAdd_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                if(strCreateDate=="")
                {
                    return;
                }
                if (MessageBox.Show("確定要刪除嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                strSQL = $@"delete from ul_label 
                            where  Format(create_date, 'yyyyMMddHHmmss') = '{Convert.ToDateTime(strCreateDate).ToString("yyyyMMddHHmmss")}' ";
                clsDB.Execute(strSQL);

                //清除欄位
                txtL.Enabled = true;
                txtQ.Enabled = true;
                txtA.Enabled = true;
                txtB.Enabled = true;
                txtB1.Enabled = true;
                txtB2.Enabled = true;
                txtC.Enabled = true;

                txtQ1.Enabled = true;
                txtQ2.Enabled = true;
                txtQ3.Enabled = true;

                txtR1.Enabled = true;
                txtR2.Enabled = true;
                txtR3.Enabled = true;

                cboFactory.Text = "";
                cboClass.Text = "";
                cboCategory.Text = "";
                cboID.Text = "";
                txtNo.Text = "";
                txtInvoiceNo.Text = "";
                cboLabeltype.Text = "";
                txtL.Text = "";
                txtQ.Text = "";
                txtA.Text = "";
                txtB.Text = "";
                txtB1.Text = "";
                txtB2.Text = "";
                txtC.Text = "";

                txtQ1.Text = "";
                txtQ2.Text = "";
                txtQ3.Text = "";

                txtR1.Text = "";
                txtR2.Text = "";
                txtR3.Text = "";

                strCreateDate = "";
                dtpDate.Value = DateTime.Now;
                txtNote.Text = "";
                //輸入後顯示查詢
                getData();
                MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmLabel_UL_Input_Activated(object sender, EventArgs e)
        {
            getData();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
