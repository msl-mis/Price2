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
    public partial class frmOrder_Complaint : Form
    {
        public static string rstrOrderID = "";   //傳來的訂單編號
        public static string rstrCustomer = "";   //傳來的客戶
        string nbr = "0";
        public frmOrder_Complaint()
        {
            InitializeComponent();
        }

        private void frmOrder_Complaint_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                txtCustomer.Text = rstrCustomer;
                txtOrderID.Text = rstrOrderID;
                txtCszr.Text = "0";
                txtQty.Text = "0";
                String strSQL = "";
                DataTable dt = new DataTable();

                //將客號加入COMBLE
                strSQL = $@"select ord_assy from ord where ord_orderid = '{txtOrderID.Text.Trim()}' order by ord_orderid ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for(int i=0; i<dt.Rows.Count; i++)
                    {
                        cboCustomerID.Items.Add(dt.Rows[i]["ord_assy"].ToString());
                    }
                }

                txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmOrder_Complaint_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()
        {
            try
            {
                String strSQL = "";
                DataTable dt = new DataTable();

                //將查詢加入GRID
                strSQL = $@"select odc_customerid,
                                   odc_freason,
                                   odc_desc,
                                   odc_qty,
                                   odc_cszr,
                                   odc_currency,
                                   format(odc_date, 'yyyy/MM/dd') odc_date,
                                   odc_nbr
                            from   odc
                            where  odc_orderid = '{txtOrderID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);

                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            //新增
            try
            {
                if (clsGlobal.checkRightFlag("訂單客訴儲存") == false)
                {
                    MessageBox.Show("你沒有訂單客訴儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if( Convert.ToDouble(txtCszr.Text.Trim())> Convert.ToDouble(txtQty.Text.Trim())) 
                {
                    MessageBox.Show("廠商責任金額不可大於客訴金額!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cboCustomerID.Text=="")
                {
                    MessageBox.Show("客號不能空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cboCurrency.Text == "")
                {
                    MessageBox.Show("幣種不能空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string strSQL = "";
                DataTable dt= new DataTable();

                //查詢是否存在;存在就修改;否則新增
                strSQL = $@"select * from odc where odc_orderid = '{txtOrderID.Text.Trim()}' and odc_customerid = '{cboCustomerID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count==0 )
                {
                    string freason = "";
                    if(chkFreason.Checked )
                    {
                        freason = "⊕";
                    }
                    else
                    {
                        freason = "";
                    }

                    strSQL = $@"insert odc
                                       (odc_customer,
                                        odc_customerid,
                                        odc_orderid,
                                        odc_desc,
                                        odc_qty,
                                        odc_currency,
                                        odc_date,
                                        odc_freason,
                                        odc_ksval,
                                        odc_convert,
                                        odc_cszr)
                                values( '{txtCustomer.Text.Trim()}',
                                        '{cboCustomerID.Text.Trim()}',
                                        '{txtOrderID.Text.Trim()}',
                                        '{txtDesc.Text.Trim()}',
                                        {txtQty.Text.Trim()},
                                        '{cboCurrency.Text.Trim()}',
                                        '{txtDate.Text.Trim()}',
                                        '{freason}',
                                        round({txtQty.Text.Trim()}*(select cur_convert from cur where cur_code ='{cboCurrency.Text.Trim()}'),0),
                                        (select cur_convert from cur where cur_code ='{cboCurrency.Text.Trim()}'),
                                        {txtCszr.Text.Trim()} ) ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update odh
                                set    odh_ks = (select Isnull(Sum(( odc_qty - odc_cszr ) * cur_convert), 0)
                                                 from   odc,
                                                        cur
                                                 where  odc_currency = cur_code
                                                        and odc_orderid = '{txtOrderID.Text.Trim()}')
                                where  odh_orderid = '{txtOrderID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                }
                else
                {
                    MessageBox.Show("客號重複,請選擇修改!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                MessageBox.Show("已經新增完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nbr = "0";
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnNew_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    cboCustomerID.Text = dgvData.Rows[e.RowIndex].Cells["odc_customerid"].Value.ToString();
                    if (dgvData.Rows[e.RowIndex].Cells["odc_freason"].Value.ToString() == "⊕")
                    {
                        chkFreason.Checked = true;
                    }
                    else
                    {
                        chkFreason.Checked = false;
                    }
                    txtDesc.Text = dgvData.Rows[e.RowIndex].Cells["odc_desc"].Value.ToString();
                    txtQty.Text = dgvData.Rows[e.RowIndex].Cells["odc_qty"].Value.ToString();
                    txtCszr.Text = dgvData.Rows[e.RowIndex].Cells["odc_cszr"].Value.ToString();
                    cboCurrency.Text = dgvData.Rows[e.RowIndex].Cells["odc_currency"].Value.ToString();
                    txtDate.Text = Convert.ToDateTime( dgvData.Rows[e.RowIndex].Cells["odc_date"].Value).ToString("yyyy/MM/dd");
                    nbr = dgvData.Rows[e.RowIndex].Cells["odc_nbr"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellDoubleClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //修改
            try
            {
                if (clsGlobal.checkRightFlag("訂單客訴儲存") == false)
                {
                    MessageBox.Show("你沒有訂單客訴儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Convert.ToDouble(txtCszr.Text.Trim()) > Convert.ToDouble(txtQty.Text.Trim()))
                {
                    MessageBox.Show("廠商責任金額不可大於客訴金額!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cboCustomerID.Text == "")
                {
                    MessageBox.Show("客號不能空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cboCurrency.Text == "")
                {
                    MessageBox.Show("幣種不能空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();

                //查詢是否存在;存在就修改;否則新增
                strSQL = $@"select * from odc where odc_orderid = '{txtOrderID.Text.Trim()}' and odc_customerid = '{cboCustomerID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("沒有這個客號,請選擇新增!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    string freason = "";
                    if (chkFreason.Checked)
                    {
                        freason = "⊕";
                    }
                    else
                    {
                        freason = "";
                    }

                    strSQL = $@"update odc
                                set    odc_customer = '{txtCustomer.Text.Trim()}',
                                       odc_customerid = '{cboCustomerID.Text.Trim()}',
                                       odc_orderid = '{txtOrderID.Text.Trim()}',
                                       odc_desc = '{txtDesc.Text.Trim()}',
                                       odc_qty = {txtQty.Text.Trim()},
                                       odc_currency = '{cboCurrency.Text.Trim()}',
                                       odc_date = '{txtDate.Text.Trim()}',
                                       odc_freason = '{freason}',
                                       odc_ksval = Round({txtQty.Text.Trim()} * (select cur_convert
                                                                                 from   cur
                                                                                 where
                                                         cur_code = '{cboCurrency.Text.Trim()}'), 0),
                                       odc_convert = (select cur_convert
                                                      from   cur
                                                      where  cur_code = '{cboCurrency.Text.Trim()}'),
                                       odc_cszr = {txtCszr.Text.Trim()}
                                where  odc_nbr = {nbr} ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update odh
                                set    odh_ks = (select Isnull(Sum(( odc_qty - odc_cszr ) * cur_convert), 0)
                                                 from   odc,
                                                        cur
                                                 where  odc_currency = cur_code
                                                        and odc_orderid = '{txtOrderID.Text.Trim()}')
                                where  odh_orderid = '{txtOrderID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                }

                MessageBox.Show("已經修改完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nbr = "0";
                getData();
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
                if (clsGlobal.checkRightFlag("訂單客訴刪除") == false)
                {
                    MessageBox.Show("你沒有訂單客訴刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("您要刪除所有客訴嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"delete odc where odc_orderid = '{txtOrderID.Text.Trim()}' ";
                clsDB.Execute(strSQL);

                strSQL = $@"update odh set odh_ks = 0 where odh_orderid = '{txtOrderID.Text.Trim()}' ";
                clsDB.Execute(strSQL);

                MessageBox.Show("已經刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nbr = "0";
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnModify_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
