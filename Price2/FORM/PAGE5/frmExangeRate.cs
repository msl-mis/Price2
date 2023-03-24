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
    public partial class frmExangeRate : Form
    {
        string[] strRP = new string[20];
        string strCode = "";
        public frmExangeRate()
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
                btnSave.Enabled = false; 
                getData();
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
            strSQL = $@"select cur_code, cur_convert from cur ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                for(int i=0; i<dt.Rows.Count;i++)
                {
                    switch (dt.Rows[i]["cur_code"].ToString())
                    {
                        case "HK$":
                            textBox1.Text= dt.Rows[i]["cur_convert"].ToString();
                            strRP[1] = dt.Rows[i]["cur_convert"].ToString();
                            break;
                        case "港幣":
                            textBox2.Text = dt.Rows[i]["cur_convert"].ToString();
                            strRP[2] = dt.Rows[i]["cur_convert"].ToString();
                            break;
                        case "RMB":
                            textBox3.Text = dt.Rows[i]["cur_convert"].ToString();
                            strRP[3] = dt.Rows[i]["cur_convert"].ToString();
                            break;
                        case "人民幣":
                            textBox4.Text = dt.Rows[i]["cur_convert"].ToString();
                            strRP[4] = dt.Rows[i]["cur_convert"].ToString();
                            break;
                        case "US$":
                            textBox5.Text = dt.Rows[i]["cur_convert"].ToString();
                            strRP[5] = dt.Rows[i]["cur_convert"].ToString();
                            break;
                        case "美金":
                            textBox6.Text = dt.Rows[i]["cur_convert"].ToString();
                            strRP[6] = dt.Rows[i]["cur_convert"].ToString();
                            break;
                        case "越南盾":
                            textBox7.Text = dt.Rows[i]["cur_convert"].ToString();
                            strRP[7] = dt.Rows[i]["cur_convert"].ToString();
                            break;
                        case "越南盾(US$)":
                            textBox8.Text = dt.Rows[i]["cur_convert"].ToString();
                            strRP[8] = dt.Rows[i]["cur_convert"].ToString();
                            break;
                        case "越南盾(NT$)":
                            textBox9.Text = dt.Rows[i]["cur_convert"].ToString();
                            strRP[9] = dt.Rows[i]["cur_convert"].ToString();
                            break;
                        case "歐元":
                            textBox10.Text = dt.Rows[i]["cur_convert"].ToString();
                            strRP[10] = dt.Rows[i]["cur_convert"].ToString();
                            break;
                        case "英磅":
                            textBox11.Text = dt.Rows[i]["cur_convert"].ToString();
                            strRP[11] = dt.Rows[i]["cur_convert"].ToString();
                            break;
                        case "瑞士法郎":
                            textBox12.Text = dt.Rows[i]["cur_convert"].ToString();
                            strRP[12] = dt.Rows[i]["cur_convert"].ToString();
                            break;
                        default:

                            break;
                    }
                }
            }
        }

        private void frmExangeRate_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                btnSave.Enabled = false;
                radioButton1.Checked = true;
                strCode = radioButton1.Text;
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmExangeRate_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (clsGlobal.ValidateString(textBox1.Text, 8) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            else
            {
                if (textBox1.Text != strRP[1])
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (clsGlobal.ValidateString(textBox2.Text, 8) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            else
            {
                if (textBox2.Text != strRP[2])
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (clsGlobal.ValidateString(textBox3.Text, 8) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            else
            {
                if (textBox3.Text != strRP[3])
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (clsGlobal.ValidateString(textBox4.Text, 8) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            else
            {
                if (textBox4.Text != strRP[4])
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (clsGlobal.ValidateString(textBox5.Text, 8) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Focus();
                return;
            }
            else
            {
                if (textBox5.Text != strRP[5])
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (clsGlobal.ValidateString(textBox6.Text, 8) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox6.Focus();
                return;
            }
            else
            {
                if (textBox6.Text != strRP[6])
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (clsGlobal.ValidateString(textBox7.Text, 8) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox7.Focus();
                return;
            }
            else
            {
                if (textBox7.Text != strRP[7])
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (clsGlobal.ValidateString(textBox8.Text, 8) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox8.Focus();
                return;
            }
            else
            {
                if (textBox8.Text != strRP[8])
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (clsGlobal.ValidateString(textBox9.Text, 8) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox9.Focus();
                return;
            }
            else
            {
                if (textBox9.Text != strRP[9])
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (clsGlobal.ValidateString(textBox10.Text, 8) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox10.Focus();
                return;
            }
            else
            {
                if (textBox10.Text != strRP[10])
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (clsGlobal.ValidateString(textBox11.Text, 8) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox11.Focus();
                return;
            }
            else
            {
                if (textBox11.Text != strRP[11])
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (clsGlobal.ValidateString(textBox12.Text, 8) == false)
            {
                MessageBox.Show("請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox12.Focus();
                return;
            }
            else
            {
                if (textBox12.Text != strRP[12])
                {
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                if (MessageBox.Show("您確定要更新匯率嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                string strSQL = "";

                if (textBox1.Text != strRP[1])
                {
                    strSQL = $@"cur_update '{radioButton1.Text}',{textBox1.Text},'{clsGlobal.strG_User}' ";
                    clsDB.Execute(strSQL);
                }

                if (textBox2.Text != strRP[2])
                {
                    strSQL = $@"cur_update '{radioButton2.Text}',{textBox2.Text},'{clsGlobal.strG_User}' ";
                    clsDB.Execute(strSQL);
                }

                if (textBox3.Text != strRP[3])
                {
                    strSQL = $@"cur_update '{radioButton3.Text}',{textBox3.Text},'{clsGlobal.strG_User}' ";
                    clsDB.Execute(strSQL);
                }

                if (textBox4.Text != strRP[4])
                {
                    strSQL = $@"cur_update '{radioButton4.Text}',{textBox4.Text},'{clsGlobal.strG_User}' ";
                    clsDB.Execute(strSQL);
                }

                if (textBox5.Text != strRP[5])
                {
                    strSQL = $@"cur_update '{radioButton5.Text}',{textBox5.Text},'{clsGlobal.strG_User}' ";
                    clsDB.Execute(strSQL);
                }

                if (textBox6.Text != strRP[6])
                {
                    strSQL = $@"cur_update '{radioButton6.Text}',{textBox6.Text},'{clsGlobal.strG_User}' ";
                    clsDB.Execute(strSQL);
                }

                if (textBox7.Text != strRP[7])
                {
                    strSQL = $@"cur_update '{radioButton7.Text}',{textBox7.Text},'{clsGlobal.strG_User}' ";
                    clsDB.Execute(strSQL);
                }

                if (textBox8.Text != strRP[8])
                {
                    strSQL = $@"cur_update '{radioButton8.Text}',{textBox8.Text},'{clsGlobal.strG_User}' ";
                    clsDB.Execute(strSQL);
                }

                if (textBox9.Text != strRP[9])
                {
                    strSQL = $@"cur_update '{radioButton9.Text}',{textBox9.Text},'{clsGlobal.strG_User}' ";
                    clsDB.Execute(strSQL);
                }

                if (textBox10.Text != strRP[10])
                {
                    strSQL = $@"cur_update '{radioButton10.Text}',{textBox10.Text},'{clsGlobal.strG_User}' ";
                    clsDB.Execute(strSQL);
                }

                if (textBox11.Text != strRP[11])
                {
                    strSQL = $@"cur_update '{radioButton11.Text}',{textBox11.Text},'{clsGlobal.strG_User}' ";
                    clsDB.Execute(strSQL);
                }

                if (textBox12.Text != strRP[12])
                {
                    strSQL = $@"cur_update '{radioButton12.Text}',{textBox12.Text},'{clsGlobal.strG_User}' ";
                    clsDB.Execute(strSQL);
                }
                getData();
                btnSave.Enabled = false;
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show("儲存成功,價格已更新!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            //匯率修改紀錄
            try
            {
                frmExangeRate_History frmExangeRate_History = new frmExangeRate_History();
                frmExangeRate_History.ShowInTaskbar = false;//圖示不顯示在工作列
                frmExangeRate_History.rstrCode = strCode;

                frmExangeRate_History.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnHistory_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                strCode = radioButton1.Text;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                strCode = radioButton2.Text;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                strCode = radioButton3.Text;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                strCode = radioButton4.Text;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                strCode = radioButton5.Text;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                strCode = radioButton6.Text;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                strCode = radioButton7.Text;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                strCode = radioButton8.Text;
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
            {
                strCode = radioButton9.Text;
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                strCode = radioButton10.Text;
            }
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked)
            {
                strCode = radioButton11.Text;
            }
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton12.Checked)
            {
                strCode = radioButton12.Text;
            }
        }
    }
}
