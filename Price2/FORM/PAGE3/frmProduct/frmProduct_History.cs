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
    public partial class frmProduct_History : Form
    {
        public static string strID;
        string strNo = "";
        public frmProduct_History()
        {
            InitializeComponent();
        }

        private void frmProduct_History_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                lblCount.Text = "";
                txtDate_S.Text = "";
                txtDate_E.Text = "";
                strNo = "";
                txtID.Text = strID;
                btnInq.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmProduct_History_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) //結束
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

        private void btnInq_Click(object sender, EventArgs e)   //查詢
        {
            //查詢
            try
            {
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                if (txtDate_E.Text != "" && txtDate_S.Text != "")
                {
                    if (Convert.ToDateTime(txtDate_S.Text) > Convert.ToDateTime(txtDate_E.Text))
                    {
                        MessageBox.Show("起始日期不可以大於結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Cursor = Cursors.Default;//滑鼠還原預設
                        return;
                    }
                }
                    
                if(txtDate_E.Text!="" && txtDate_S.Text=="")
                {
                    MessageBox.Show("請選擇起始日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                if (txtDate_E.Text == "" && txtDate_S.Text != "")
                {
                    MessageBox.Show("請選擇結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }

                string strSQL = "";
                DataTable dt = new DataTable();
                if(txtDate_E.Text == "" && txtDate_S.Text == "")
                {
                    strSQL = $@"select Format(asb_changedate, 'yyyy-MM-dd') '更改日期',
                                       asb_currency                         '幣別',
                                       asb_price                            '單價',
                                       Isnull(asb_pricecal, '')             '計算式',
                                       Round(asb_price * cur_convert, 4)    '臺幣換算價',
                                       asb_vendorid                         '廠商',
                                       asb_user                             '用戶',
                                       asb_nbr                              '編號',
                                       Isnull(asb_memo, '')                 '備註'
                                from   asb,
                                       cur
                                where  asb_currency = cur_code
                                and asb_id = '{txtID.Text}'
                                order by asb_changedate desc  ";
                }
                else
                {
                    string strDate_S=txtDate_S.Text+" 00:00:00";
                    string strDate_E = txtDate_E.Text + " 23:59:59";
                    strSQL = $@"select Format(asb_changedate, 'yyyy-MM-dd') '更改日期',
                                       asb_currency                         '幣別',
                                       asb_price                            '單價',
                                       Isnull(asb_pricecal, '')             '計算式',
                                       Round(asb_price * cur_convert, 4)    '臺幣換算價',
                                       asb_vendorid                         '廠商',
                                       asb_user                             '用戶',
                                       asb_nbr                              '編號',
                                       Isnull(asb_memo, '')                 '備註'
                                from   asb,
                                       cur
                                where  asb_currency = cur_code
                                and asb_id = '{txtID.Text}'
                                and asb_changedate between '{strDate_S}' and '{strDate_E}'
                                order by asb_changedate desc  ";
                }
                dt=clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count >0)
                {
                    dgvData.DataSource = dt;
                    lblCount.Text = "共："+dt.Rows.Count.ToString()+"筆";
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
                else
                {
                    dgvData.DataSource = dt;
                    MessageBox.Show("查無資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
                strNo = "";
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) //清除
        {
            //清除
            try
            {
                //清除dgv
                if (dgvData.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvData.DataSource;
                    dt.Rows.Clear();
                    dgvData.DataSource = dt;
                }
                txtDate_S.Text = "";
                txtDate_E.Text = "";
                strNo = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)    //刪除
        {
            //刪除
            try
            {
                if (txtDate_E.Text == "" && txtDate_S.Text == "")
                {
                    if (strNo != "")
                    {
                        if (MessageBox.Show(this, "你確定要刪除該材料價史嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string strSQL = $@"delete asb
                                        where asb_nbr = {strNo} ";
                            clsDB.Execute(strSQL);
                            MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnInq.PerformClick();
                        }
                    }
                    else
                    {
                        MessageBox.Show("請選擇欲刪除之材料價史!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    if (MessageBox.Show(this, "你確定要依日期條件刪除嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string strDate_S = txtDate_S.Text + " 00:00:00";
                        string strDate_E = txtDate_E.Text + " 23:59:59";
                        string strSQL = $@"delete asb
                                           where  asb_id = '{txtID.Text}'
                                                  and asb_changedate between '{strDate_S}' and '{strDate_E}' ";
                        clsDB.Execute(strSQL);
                        MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnInq.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDate_S_Click(object sender, EventArgs e)
        {
            if(txtDate_S.Text == "")
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

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                strNo = dgvData.Rows[e.RowIndex].Cells["編號"].Value.ToString();
            }
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (strNo != "")
                {
                    if (MessageBox.Show(this, "你確定要刪除該材料價史嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string strSQL = $@"delete asb
                                        where asb_nbr = {strNo} ";
                        clsDB.Execute(strSQL);
                        MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnInq.PerformClick();
                    }
                }
                else
                {
                    MessageBox.Show("請選擇欲刪除之材料價史!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }   
        }
    }
}
