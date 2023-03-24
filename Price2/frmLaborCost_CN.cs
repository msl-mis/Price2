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
    public partial class frmLaborCost_CN : Form
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

        string[] strCal = new string[100];//計算式
        double dblConvert = 0;//匯率
        public frmLaborCost_CN()
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
            //讀取
            try
            {
                getData();
                getCal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            //讀取人民幣匯率
            strSQL = $@"select * from cur where cur_code = '人民幣' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dblConvert = Convert.ToDouble(dt.Rows[0]["cur_convert"].ToString());
            }
            strSQL = $@"select * from freight where fre_id='人工成本設定' ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i< dt.Rows.Count; i++)
                {
                    switch (dt.Rows[i]["fre_pricecal"].ToString().Trim())
                    {
                        case "工資/月":
                            textBox1.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[1]= dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "平均工作天數/月":
                            textBox2.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[2] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "年休與國定假日/年":
                            textBox3.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[3] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "假日平均工作天數/月":
                            textBox4.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[4] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "正常工作/H":
                            textBox5.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[5] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "平日加班/H":
                            textBox6.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[6] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "假日加班/H":
                            textBox7.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[7] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "工資/H":
                            textBox8.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[8] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "平日加班工資/H":
                            textBox9.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[9] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "假日加班工資/H":
                            textBox10.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[10] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "養老保險繳費基數":
                            textBox11.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[11] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "養老保險繳費比例":
                            textBox12.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[12] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "養老保險/月":
                            textBox13.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[13] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "醫療保險繳費基數":
                            textBox14.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[14] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "醫療保險繳費比例":
                            textBox15.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[15] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "醫療保險/月":
                            textBox16.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[16] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "工傷保險繳費基數":
                            textBox17.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[17] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "工傷保險繳費比例":
                            textBox18.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[18] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "工傷保險/月":
                            textBox19.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[19] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "失業保險繳費基數":
                            textBox20.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[20] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "失業保險繳費比例":
                            textBox21.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[21] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "失業保險/月":
                            textBox22.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[22] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "生育保險繳費基數":
                            textBox23.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[23] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "生育保險繳費比例":
                            textBox24.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[24] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "生育保險/月":
                            textBox25.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[25] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "住房公積金繳費基數":
                            textBox26.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[26] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "住房公積金繳費比例":
                            textBox27.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[27] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "住房公積金/月":
                            textBox28.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[28] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "食宿費/月":
                            textBox29.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[29] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "年終獎金/月":
                            textBox30.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[30] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "正常工資 /月":
                            textBox31.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[31] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        case "每月可生產總時數":
                            textBox32.Text = dt.Rows[i]["fre_price"].ToString().Trim();
                            strCal[32] = dt.Rows[i]["fre_label"].ToString().Trim();
                            break;
                        default:
                            
                            break;
                    }
                }
            }
        }

        private void getCal()
        {
            //工資/H
            if (Convert.ToDouble( textBox1.Text) > 0 && Convert.ToDouble(textBox2.Text) > 0 && Convert.ToDouble(textBox5.Text) > 0)
            {
                textBox8.Text = (Convert.ToDouble(textBox1.Text) / Convert.ToDouble(textBox2.Text) / Convert.ToDouble(textBox5.Text)).ToString("0.##");
            }
            //平日加班工資/H
            textBox9.Text = (Convert.ToDouble(textBox8.Text) * 1.5).ToString("0.##");
            //假日加班工資/H
            textBox10.Text = (Convert.ToDouble(textBox8.Text) * 2).ToString("0.##");
            //養老保險繳費基數
            textBox11.Text =( (Convert.ToDouble(textBox1.Text)+ Convert.ToDouble(textBox1.Text) * 1.5)/2).ToString();
            //養老保險/月
            textBox13.Text = (Convert.ToDouble(textBox11.Text) * Convert.ToDouble(textBox12.Text)).ToString("0.####");
            //醫療保險/月
            textBox16.Text = (Convert.ToDouble(textBox14.Text) * Convert.ToDouble(textBox15.Text)).ToString("0.####");
            //工傷保險繳費基數
            textBox17.Text = ((Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox1.Text) * 1.5) / 2).ToString();
            //工傷保險/月
            textBox19.Text = (Convert.ToDouble(textBox17.Text) * Convert.ToDouble(textBox18.Text)).ToString("0.####");
            //失業保險繳費基數
            textBox20.Text = (Convert.ToDouble(textBox1.Text) ).ToString();
            //失業保險/月
            textBox22.Text = (Convert.ToDouble(textBox20.Text) * Convert.ToDouble(textBox21.Text)).ToString("0.####");
            //生育保險繳費基數
            textBox23.Text = ((Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox1.Text) * 1.5) / 2).ToString();
            //生育保險/月
            textBox25.Text = (Convert.ToDouble(textBox23.Text) * Convert.ToDouble(textBox24.Text)).ToString("0.####");
            //住房公積金繳費基數
            textBox26.Text = ((Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox1.Text) * 1.5) / 2).ToString();
            //住房公積金/月
            textBox28.Text = (Convert.ToDouble(textBox26.Text) * Convert.ToDouble(textBox27.Text)).ToString("0.####");
            //年終獎金/月
            textBox30.Text = (Convert.ToDouble(textBox1.Text) / 12).ToString("0.####");
            //正常工資 /月
            textBox31.Text = (
                Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox5.Text) * Convert.ToDouble(textBox2.Text)
                + Convert.ToDouble(textBox8.Text) * Convert.ToDouble(textBox5.Text) * Convert.ToDouble(textBox2.Text) * Convert.ToDouble(textBox3.Text)
                + Convert.ToDouble(textBox9.Text) * Convert.ToDouble(textBox6.Text) * Convert.ToDouble(textBox2.Text)
                + Convert.ToDouble(textBox10.Text) * Convert.ToDouble(textBox7.Text) * Convert.ToDouble(textBox4.Text)
                + Convert.ToDouble(textBox13.Text)
                + Convert.ToDouble(textBox16.Text)
                + Convert.ToDouble(textBox19.Text)
                + Convert.ToDouble(textBox22.Text)
                + Convert.ToDouble(textBox25.Text)
                + Convert.ToDouble(textBox28.Text)
                + Convert.ToDouble(textBox29.Text)
                + Convert.ToDouble(textBox30.Text)
                ).ToString("0.######");
            //每月可生產總時數
            textBox32.Text = (
                Convert.ToDouble(textBox5.Text) * Convert.ToDouble(textBox2.Text)
                + Convert.ToDouble(textBox6.Text) * Convert.ToDouble(textBox2.Text) 
                + Convert.ToDouble(textBox7.Text) * Convert.ToDouble(textBox4.Text) 
                ).ToString("0.######");

            //人工成本/分
            if (Convert.ToDouble(textBox31.Text) > 0 && Convert.ToDouble(textBox32.Text) > 0 )
            {
                txtCost.Text = (Convert.ToDouble(textBox31.Text) / Convert.ToDouble(textBox32.Text) / 60).ToString("0.######");
                txtCost_NT.Text= (Convert.ToDouble(txtCost.Text)*dblConvert).ToString("0.######");
            }
        }

        private void frmLaborCost_CN_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                getData();
                getCal();
                //btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmLaborCost_CN_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (strCal[1] != "")
            {
                textBox1.Text = strCal[1];
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (strCal[2] != "")
            {
                textBox2.Text = strCal[2];
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (strCal[3] != "")
            {
                textBox3.Text = strCal[3];
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (strCal[4] != "")
            {
                textBox4.Text = strCal[4];
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (strCal[5] != "")
            {
                textBox5.Text = strCal[5];
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (strCal[6] != "")
            {
                textBox6.Text = strCal[6];
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (strCal[7] != "")
            {
                textBox7.Text = strCal[7];
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (strCal[8] != "")
            {
                textBox8.Text = strCal[8];
            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (strCal[9] != "")
            {
                textBox9.Text = strCal[9];
            }
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            if (strCal[10] != "")
            {
                textBox10.Text = strCal[10];
            }
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            if (strCal[12] != "")
            {
                textBox12.Text = strCal[12];
            }
        }

        private void textBox14_Enter(object sender, EventArgs e)
        {
            if (strCal[14] != "")
            {
                textBox14.Text = strCal[14];
            }
        }

        private void textBox15_Enter(object sender, EventArgs e)
        {
            if (strCal[15] != "")
            {
                textBox15.Text = strCal[15];
            }
        }

        private void textBox18_Enter(object sender, EventArgs e)
        {
            if (strCal[18] != "")
            {
                textBox18.Text = strCal[18];
            }
        }

        private void textBox21_Enter(object sender, EventArgs e)
        {
            if (strCal[21] != "")
            {
                textBox21.Text = strCal[21];
            }
        }

        private void textBox24_Enter(object sender, EventArgs e)
        {
            if (strCal[24] != "")
            {
                textBox24.Text = strCal[24];
            }
        }

        private void textBox27_Enter(object sender, EventArgs e)
        {
            if (strCal[27] != "")
            {
                textBox27.Text = strCal[27];
            }
        }

        private void textBox29_Enter(object sender, EventArgs e)
        {
            if (strCal[29] != "")
            {
                textBox29.Text = strCal[29];
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            strCal[1] = textBox1.Text;
            textBox1.Text = Convert.ToDouble(new DataTable().Compute(textBox1.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            strCal[2] = textBox2.Text;
            textBox2.Text = Convert.ToDouble(new DataTable().Compute(textBox2.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            strCal[3] = textBox3.Text;
            textBox3.Text = Convert.ToDouble(new DataTable().Compute(textBox3.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            strCal[4] = textBox4.Text;
            textBox4.Text = Convert.ToDouble(new DataTable().Compute(textBox4.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            strCal[5] = textBox5.Text;
            textBox5.Text = Convert.ToDouble(new DataTable().Compute(textBox5.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            strCal[6] = textBox6.Text;
            textBox6.Text = Convert.ToDouble(new DataTable().Compute(textBox6.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            strCal[7] = textBox7.Text;
            textBox7.Text = Convert.ToDouble(new DataTable().Compute(textBox7.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            strCal[8] = textBox8.Text;
            textBox8.Text = Convert.ToDouble(new DataTable().Compute(textBox8.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            strCal[9] = textBox9.Text;
            textBox9.Text = Convert.ToDouble(new DataTable().Compute(textBox9.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            strCal[10] = textBox10.Text;
            textBox10.Text = Convert.ToDouble(new DataTable().Compute(textBox10.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            strCal[12] = textBox12.Text;
            textBox12.Text = Convert.ToDouble(new DataTable().Compute(textBox12.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            strCal[14] = textBox14.Text;
            textBox14.Text = Convert.ToDouble(new DataTable().Compute(textBox14.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            strCal[15] = textBox15.Text;
            textBox15.Text = Convert.ToDouble(new DataTable().Compute(textBox15.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            strCal[18] = textBox18.Text;
            textBox18.Text = Convert.ToDouble(new DataTable().Compute(textBox18.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox21_Leave(object sender, EventArgs e)
        {
            strCal[21] = textBox21.Text;
            textBox21.Text = Convert.ToDouble(new DataTable().Compute(textBox21.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox24_Leave(object sender, EventArgs e)
        {
            strCal[24] = textBox24.Text;
            textBox24.Text = Convert.ToDouble(new DataTable().Compute(textBox24.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox27_Leave(object sender, EventArgs e)
        {
            strCal[27] = textBox27.Text;
            textBox27.Text = Convert.ToDouble(new DataTable().Compute(textBox27.Text, null)).ToString("0.######");
            getCal();
        }

        private void textBox29_Leave(object sender, EventArgs e)
        {
            strCal[29] = textBox29.Text;
            textBox29.Text = Convert.ToDouble(new DataTable().Compute(textBox29.Text, null)).ToString("0.######");
            getCal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                if (MessageBox.Show("確定要儲存嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select * from freight where fre_id='人工成本設定' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        switch (dt.Rows[i]["fre_pricecal"].ToString().Trim())
                        {
                            case "工資/月":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox1.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[1]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "平均工作天數/月":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox2.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[2]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "年休與國定假日/年":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox3.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[3]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "假日平均工作天數/月":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox4.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[4]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "正常工作/H":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox5.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[5]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "平日加班/H":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox6.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[6]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "假日加班/H":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox7.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[7]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "工資/H":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox8.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[8]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "平日加班工資/H":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox9.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[9]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "假日加班工資/H":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox10.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[10]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "養老保險繳費基數":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox11.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[11]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "養老保險繳費比例":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox12.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[12]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "養老保險/月":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox13.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[13]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "醫療保險繳費基數":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox14.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[14]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "醫療保險繳費比例":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox15.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[15]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "醫療保險/月":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox16.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[16]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "工傷保險繳費基數":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox17.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[17]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "工傷保險繳費比例":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox18.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[18]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "工傷保險/月":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox19.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[19]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "失業保險繳費基數":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox20.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[20]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "失業保險繳費比例":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox21.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[21]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "失業保險/月":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox22.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[22]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                strCal[22] = dt.Rows[i]["fre_label"].ToString().Trim();
                                break;
                            case "生育保險繳費基數":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox23.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[23]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "生育保險繳費比例":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox24.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[24]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "生育保險/月":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox25.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[25]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "住房公積金繳費基數":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox26.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[26]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "住房公積金繳費比例":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox27.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[27]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "住房公積金/月":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox28.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[28]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "食宿費/月":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox29.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[29]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "年終獎金/月":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox30.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[30]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "正常工資 /月":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox31.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[31]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            case "每月可生產總時數":
                                strSQL = $@"update freight
                                            set    fre_price = {textBox32.Text},
                                                   fre_modifydate = Getdate(),
                                                   fre_modifyuser = '{clsGlobal.strG_User}',
                                                   fre_label = '{strCal[32]}'
                                            where  fre_id = '人工成本設定'
                                                   and fre_pricecal = '{dt.Rows[i]["fre_pricecal"].ToString().Trim()}' ";
                                clsDB.Execute(strSQL);
                                break;
                            default:

                                break;
                        }
                    }
                }

                //更新材料單價
                //先取得asp參數
                GetAsp("人工成本/分");
                asp_purprice = Convert.ToDouble(txtCost.Text);      //單價
                asp_pricecal = txtCost.Text;                        //單價計算式

                DoUpdate_asp1();                     //更新asp資料(沒有做updateBOM)
                MessageBox.Show("儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
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
                //asp_oddate = ((DateTime)dt.Rows[0]["asp_oddate"]).ToString("yyyy/MM/dd");
                //asp_oduser = (string)dt.Rows[0]["asp_oduser"];
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
