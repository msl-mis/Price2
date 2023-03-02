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
    public partial class frmOrder_OtherPay : Form
    {
        public static string rstrOrderID = "";   //傳來的訂單編號
        string nbr = "0";
        public frmOrder_OtherPay()
        {
            InitializeComponent();
        }

        private void frmOrder_OtherPay_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                txtOrderID.Text = rstrOrderID;
                txtCost.Text = "0";
                String strSQL = "";
                DataTable dt = new DataTable();

                //將客號加入COMBLE
                strSQL = $@"select oop_assy, oop_cost, oop_currency, oop_nbr from oop where oop_orderid = '{txtOrderID.Text.Trim()}' order by oop_nbr ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                    cboCurrency.Text = dt.Rows[0]["oop_currency"].ToString();
                }
                
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
                strSQL = $@"select oop_assy, oop_cost, oop_currency, oop_nbr from oop where oop_orderid = '{txtOrderID.Text.Trim()}' order by oop_nbr ";
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

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    txtAssy.Text = dgvData.Rows[e.RowIndex].Cells["oop_assy"].Value.ToString();
                    txtCost.Text = dgvData.Rows[e.RowIndex].Cells["oop_cost"].Value.ToString();
                    cboCurrency.Text = dgvData.Rows[e.RowIndex].Cells["oop_currency"].Value.ToString();
                    nbr = dgvData.Rows[e.RowIndex].Cells["oop_nbr"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellDoubleClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //新增
            try
            {
                if (clsGlobal.checkRightFlag("訂單國外其他費用儲存") == false)
                {
                    MessageBox.Show("你沒有訂單國外其他費用儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                strSQL = $@"select * from oop where oop_assy = '{txtAssy.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count == 0)
                {
                    strSQL = $@"insert oop
                                       (oop_orderid,
                                        oop_assy,
                                        oop_currency,
                                        oop_cost)
                                values( '{txtOrderID.Text.Trim()}',
                                        '{txtAssy.Text.Trim()}',
                                        '{cboCurrency.Text.Trim()}',
                                        {txtCost.Text.Trim()}) ";
                    clsDB.Execute(strSQL);

                    string totalassy = "";
                    string totalcost = "0";

                    strSQL = $@"select Round(Isnull(Sum(oop_cost), 0), 3) totalcost
                                from   oop
                                where  oop_orderid = '{txtOrderID.Text.Trim()}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if(dt.Rows.Count>0)
                    {
                        totalcost = dt.Rows[0]["totalcost"].ToString();
                    }

                    strSQL = $@"select (oop_assy
                                       + Space(88-Datalength(oop_assy))
                                       + oop_currency
                                       + Space(15-Datalength(dbo.Formatstr(Round(oop_cost, 3), 3)))
                                       + dbo.Formatstr(Round(oop_cost, 3), 3)
                                       + Char(13)) totalassy
                                from   oop
                                where  oop_orderid = '{txtOrderID.Text.Trim()}' order by oop_nbr ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            totalassy = totalassy + dt.Rows[i]["totalassy"].ToString();
                        }
                    }

                    strSQL = $@"update odh
                                set    odh_otherpay = '{totalassy}',
                                       odh_othercost = {totalcost},
                                       odh_adddate = Getdate()
                                where  odh_orderid = '{txtOrderID.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                }
                else
                {
                    MessageBox.Show("費用名稱重複,請選擇修改!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnModify_Click(object sender, EventArgs e)
        {
            //修改
            try
            {
                if (clsGlobal.checkRightFlag("訂單國外其他費用儲存") == false)
                {
                    MessageBox.Show("你沒有訂單國外其他費用儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                strSQL = $@"select * from oop where oop_assy = '{txtAssy.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("沒有這個費用名稱,請選擇新增!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    strSQL = $@"update oop
                                set    oop_assy = '{txtAssy.Text.Trim()}',
                                       oop_currency = '{cboCurrency.Text.Trim()}',
                                       oop_cost = {txtCost.Text.Trim()}
                                where  oop_nbr = {nbr} ";
                    clsDB.Execute(strSQL);

                    string totalassy = "";
                    string totalcost = "0";

                    strSQL = $@"select Round(Isnull(Sum(oop_cost), 0), 3) totalcost
                                from   oop
                                where  oop_orderid = '{txtOrderID.Text.Trim()}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        totalcost = dt.Rows[0]["totalcost"].ToString();
                    }

                    strSQL = $@"select (oop_assy
                                       + Space(88-Datalength(oop_assy))
                                       + oop_currency
                                       + Space(15-Datalength(dbo.Formatstr(Round(oop_cost, 3), 3)))
                                       + dbo.Formatstr(Round(oop_cost, 3), 3)
                                       + Char(13)) totalassy
                                from   oop
                                where  oop_orderid = '{txtOrderID.Text.Trim()}' order by oop_nbr ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            totalassy = totalassy + dt.Rows[i]["totalassy"].ToString();
                        }
                    }

                    strSQL = $@"update odh
                                set    odh_otherpay = '{totalassy}',
                                       odh_othercost = {totalcost},
                                       odh_adddate = Getdate()
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

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                
                nbr = dgvData.Rows[e.RowIndex].Cells["oop_nbr"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                if (clsGlobal.checkRightFlag("訂單國外其他費用儲存") == false)
                {
                    MessageBox.Show("你沒有訂單國外其他費用儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(nbr=="0")
                {
                    return;
                }
                if (MessageBox.Show("確定要刪除這筆費用嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();

                strSQL = $@"delete oop
                            where  oop_nbr = {nbr}
                                   and oop_orderid = '{txtOrderID.Text.Trim()}' ";
                clsDB.Execute(strSQL);

                string totalassy = "";
                string totalcost = "0";

                strSQL = $@"select Round(Isnull(Sum(oop_cost), 0), 3) totalcost
                                from   oop
                                where  oop_orderid = '{txtOrderID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    totalcost = dt.Rows[0]["totalcost"].ToString();
                }

                strSQL = $@"select (oop_assy
                                       + Space(88-Datalength(oop_assy))
                                       + oop_currency
                                       + Space(15-Datalength(dbo.Formatstr(Round(oop_cost, 3), 3)))
                                       + dbo.Formatstr(Round(oop_cost, 3), 3)
                                       + Char(13)) totalassy
                                from   oop
                                where  oop_orderid = '{txtOrderID.Text.Trim()}' order by oop_nbr ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        totalassy = totalassy + dt.Rows[i]["totalassy"].ToString();
                    }
                }

                strSQL = $@"update odh
                                set    odh_otherpay = '{totalassy}',
                                       odh_othercost = {totalcost},
                                       odh_adddate = Getdate()
                                where  odh_orderid = '{txtOrderID.Text.Trim()}' ";
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
