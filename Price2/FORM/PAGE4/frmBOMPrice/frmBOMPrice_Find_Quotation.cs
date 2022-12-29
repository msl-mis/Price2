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
    public partial class frmBOMPrice_Find_Quotation : Form
    {
        public static string rstrID = "";  //由frmBOMPrice傳的材料ID

        public frmBOMPrice_Find_Quotation()
        {
            InitializeComponent();
        }

        private void radioAll_Click(object sender, EventArgs e) //全部
        {
            //全部
            try
            {
                GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-radioAll_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetAll()
        {
            try
            {
                string strWhere = "";
                strWhere = strWhere + (chkCustomer.Checked ? "" : $@" and pri_customer = '{txtCustomer.Text}'");
                strWhere = strWhere + (chkNewDate.Checked ? "" : $@" and pri_newdate between '{txtNewDate_S.Text}' and '{txtNewDate_E.Text}'");
                strWhere = strWhere + (chkDealDate.Checked ? "" : $@" and pri_adddate between '{txtDealDate_S.Text}' and '{txtDealDate_E.Text}'");
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select distinct pri_customer          '客戶',
                                            pri_customerid        '客號',
                                            pri_assy              '線路',
                                            pri_length            '線長',
                                            pri_newdate           '報價新建日期',
                                            pri_adddate           '最後成交日期',
                                            Isnull(aa.CNT, '') '成交總數量',
                                            format(Isnull(aa.PROFIT, ''), '0.#') '最後成交利潤',
                                            pri_ll                '即時利潤',
                                            pri_username          '用戶',
                                            pri_addusername       '新建用戶'
                            from   (select *
                                    from   pri tabA
                                            left join(select ord_assy     ,
                                                            Sum(ord_qty) CNT,
                                                            ord_line,
                                                            case Isnull(Sum(ord_convprice * ord_qty), 0)
                                                                when 0 then 0
                                                                else ( Isnull(Sum((ord_pricost - ord_convprice ) * ord_qty), 0) ) / ( Isnull(Sum(ord_convprice * ord_qty ), 0) ) * 100
                                                            end          PROFIT
                                                        from   ord
                                                        group  by ord_assy,
                                                                ord_line) tabB
                                                    on tabA.pri_customerid = tabB.ord_assy
                                                        and tabA.pri_assy = tabB.ord_line) aa
                            where  pri_part = '{rstrID}'
                                    and pri_newcostchk = 'N' ";
                strSQL = strSQL + strWhere;
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    lblCount.Text = dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-GetAll" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioDeal_Click(object sender, EventArgs e)    //成交
        {
            //成交
            try
            {
                GetDeal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-radioDeal_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetDeal()
        {
            try
            {
                string strWhere = "";
                strWhere = strWhere + (chkCustomer.Checked ? "" : $@" and pri_customer = '{txtCustomer.Text}'");
                strWhere = strWhere + (chkNewDate.Checked ? "" : $@" and pri_newdate between '{txtNewDate_S.Text}' and '{txtNewDate_E.Text}'");
                strWhere = strWhere + (chkDealDate.Checked ? "" : $@" and pri_adddate between '{txtDealDate_S.Text}' and '{txtDealDate_E.Text}'");
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select distinct pri_customer          '客戶',
                                            pri_customerid        '客號',
                                            pri_assy              '線路',
                                            pri_length            '線長',
                                            pri_newdate           '報價新建日期',
                                            pri_adddate           '最後成交日期',
                                            Isnull(aa.CNT, '') '成交總數量',
                                            format(Isnull(aa.PROFIT, ''), '0.#') '最後成交利潤',
                                            pri_ll                '即時利潤',
                                            pri_username          '用戶',
                                            pri_addusername       '新建用戶'
                            from   (select *
                                    from   pri tabA
                                            left join(select ord_assy     ,
                                                            Sum(ord_qty) CNT,
                                                            ord_line,
                                                            case Isnull(Sum(ord_convprice * ord_qty), 0)
                                                                when 0 then 0
                                                                else ( Isnull(Sum((ord_pricost - ord_convprice ) * ord_qty), 0) ) / ( Isnull(Sum(ord_convprice * ord_qty ), 0) ) * 100
                                                            end          PROFIT
                                                        from   ord
                                                        group  by ord_assy,
                                                                ord_line) tabB
                                                    on tabA.pri_customerid = tabB.ord_assy
                                                        and tabA.pri_assy = tabB.ord_line) aa
                            where  pri_part = '{rstrID}'
                                    and pri_newcostchk = 'N' 
                                    and pri_customerid in (select distinct ord_assy from ord) ";
                strSQL = strSQL + strWhere;
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    lblCount.Text = dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-GetDeal" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioDealYet_Click(object sender, EventArgs e) //未成交
        {
            //未成交
            try
            {
                GetDealYet();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-radioDealYet_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetDealYet()
        {
            try
            {
                string strWhere = "";
                strWhere = strWhere + (chkCustomer.Checked ? "" : $@" and pri_customer = '{txtCustomer.Text}'");
                strWhere = strWhere + (chkNewDate.Checked ? "" : $@" and pri_newdate between '{txtNewDate_S.Text}' and '{txtNewDate_E.Text}'");
                strWhere = strWhere + (chkDealDate.Checked ? "" : $@" and pri_adddate between '{txtDealDate_S.Text}' and '{txtDealDate_E.Text}'");
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select distinct pri_customer          '客戶',
                                            pri_customerid        '客號',
                                            pri_assy              '線路',
                                            pri_length            '線長',
                                            pri_newdate           '報價新建日期',
                                            pri_adddate           '最後成交日期',
                                            Isnull(aa.CNT, '') '成交總數量',
                                            format(Isnull(aa.PROFIT, ''), '0.#') '最後成交利潤',
                                            pri_ll                '即時利潤',
                                            pri_username          '用戶',
                                            pri_addusername       '新建用戶'
                            from   (select *
                                    from   pri tabA
                                            left join(select ord_assy     ,
                                                            Sum(ord_qty) CNT,
                                                            ord_line,
                                                            case Isnull(Sum(ord_convprice * ord_qty), 0)
                                                                when 0 then 0
                                                                else ( Isnull(Sum((ord_pricost - ord_convprice ) * ord_qty), 0) ) / ( Isnull(Sum(ord_convprice * ord_qty ), 0) ) * 100
                                                            end          PROFIT
                                                        from   ord
                                                        group  by ord_assy,
                                                                ord_line) tabB
                                                    on tabA.pri_customerid = tabB.ord_assy
                                                        and tabA.pri_assy = tabB.ord_line) aa
                            where  pri_part = '{rstrID}'
                                    and pri_newcostchk = 'N' 
                                    and pri_customerid not in (select distinct ord_assy from ord) ";
                strSQL = strSQL + strWhere;
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    lblCount.Text = dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-GetDealYet" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkNewDate_CheckedChanged(object sender, EventArgs e)
        {
            if(chkNewDate.Checked)
            {
                txtNewDate_S.Text = "(ALL)";
                txtNewDate_E.Text = "(ALL)";
            }
            else
            {
                txtNewDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtNewDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void chkDealDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDealDate.Checked)
            {
                txtDealDate_S.Text = "(ALL)";
                txtDealDate_E.Text = "(ALL)";
            }
            else
            {
                txtDealDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtDealDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtNewDate_S_Enter(object sender, EventArgs e)
        {
            chkNewDate.Checked=false;
        }

        private void txtNewDate_E_Enter(object sender, EventArgs e)
        {
            chkNewDate.Checked = false;
        }

        private void txtDealDate_S_Enter(object sender, EventArgs e)
        {
            chkDealDate.Checked = false;
        }

        private void txtDealDate_E_Enter(object sender, EventArgs e)
        {
            chkDealDate.Checked = false;
        }

        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if(chkCustomer.Checked)
            {
                txtCustomer.Text = "(ALL)";
            }
            else
            {
                txtCustomer.Text = "";
            }
        }

        private void txtCustomer_Enter(object sender, EventArgs e)
        {
            chkCustomer.Checked=false;
        }

        private void btnClose_Click(object sender, EventArgs e) //結束
        {
            //結束
            try
            {
                frmBOMPrice.rstrButton = "Close";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBOMPrice_Find_Quotation_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                chkCustomer.Checked=true;
                chkNewDate.Checked = true;
                chkDealDate.Checked = true;
                GetAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOMPrice_Find_Quotation_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e) //列印
        {
            //列印
            try
            {
                //clsGlobal clsGlobal = new clsGlobal();
                clsGlobal.ExportExcel("報價尋找結果", dgvData);
                //clsGlobal.ExportCsv( dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Click(object sender, EventArgs e)   //搜尋
        {
            //搜尋
            try
            {
                if(radioAll.Checked)
                {
                    GetAll();
                }
                if(radioDeal.Checked)
                {
                    GetDeal();
                }
                if(radioDealYet.Checked)
                {
                    GetDealYet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex>=0)
            {
                getExport();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)    //導出
        {
            //導出
            try
            {
                if (dgvData.CurrentRow != null)
                {
                    getExport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getExport()
        {
            try
            {
                frmBOMPrice.rstrID = dgvData.Rows[dgvData.CurrentRow.Index].Cells["客號"].Value.ToString();
                frmBOMPrice.rstrName = dgvData.Rows[dgvData.CurrentRow.Index].Cells["線路"].Value.ToString();
                frmBOMPrice.rstrButton = "Export";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getExport" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)    //資料刪除
        {
            //資料刪除
            try
            {
                //確認權限
                if (clsGlobal.checkRightFlag("報價單尋找資料刪除") == false )
                {
                    MessageBox.Show("您沒有報價單尋找資料刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                if(radioAll.Checked)
                {
                    MessageBox.Show("可能有含成交資料不可全部刪除!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                if(radioDeal.Checked)
                {
                    MessageBox.Show("成交資料不可刪除!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                if(radioDealYet.Checked)
                {
                    if (MessageBox.Show("你確定要刪除未成交報價單嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        for (int i = 0; i < dgvData.Rows.Count ; i++)
                        {
                            string strSQL = $@"delete from pri
                                                    where  pri_assy = '{dgvData.Rows[i].Cells["線路"].Value.ToString()}'
                                                           and pri_customerid = '{dgvData.Rows[i].Cells["客號"].Value.ToString()}'
                                                           and pri_newcostchk = 'N' ";
                            clsDB.Execute(strSQL);
                        }
                        MessageBox.Show("刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnInq.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getExport" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            //按空格顯示參照法
            try
            {
                if(e.KeyCode == Keys.Space)
                {
                    if(dgvData.CurrentRow.Index >= 0)
                    {
                        string strSQL = "";
                        DataTable dt = new DataTable();
                        strSQL = $@"select odi_czf
                            from   odi
                            where  odi_customerid = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["客號"].Value.ToString()}' ";

                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show(dt.Rows[0]["odi_czf"].ToString(), "參照法顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("(無參照法)", "參照法顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getExport" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCustomer_Enter_1(object sender, EventArgs e)
        {
            chkCustomer.Checked = false;
        }
    }
}
