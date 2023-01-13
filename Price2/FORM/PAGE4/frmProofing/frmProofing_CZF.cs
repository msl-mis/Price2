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
    public partial class frmProofing_CZF : Form
    {
        public static string rstrProductID = "";   //傳來的產品編號
        public frmProofing_CZF()
        {
            InitializeComponent();
        }

        private void frmProofing_CZF_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select distinct pas_username from pas where pas_ywcode <> '' order by pas_username ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0 )
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboSales.Items.Add(dt.Rows[i]["pas_username"].ToString());
                    }
                }
                txtProductID.Text = rstrProductID;
                if(txtProductID.Text!="")
                {
                    getData();
                    rstrProductID = "";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmProofing_CZF_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()
        {
            try
            {
                if(txtProductID.Text.Trim()=="")
                {
                    return;
                }
                txtProductID.Text = txtProductID.Text.Trim();
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select *
                            from   dyi
                                   left join pas
                                          on pas_ywcode = dyi_ywcode
                                             and dyi_ywcode <> ''
                            where  dyi_id = '{txtProductID.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    txtProductID.Text = dt.Rows[0]["dyi_id"].ToString();
                    txtLine.Text = dt.Rows[0]["dyi_line"].ToString();
                    txtCZF.Text = dt.Rows[0]["dyi_czf"].ToString();
                    txtMO.Text = dt.Rows[0]["dyi_mo"].ToString();
                    txtCustomer.Text = dt.Rows[0]["dyi_customer"].ToString();
                    lblUser.Text = dt.Rows[0]["dyi_username"].ToString();
                    lblSaveDate.Text = dt.Rows[0]["dyi_adddate"].ToString();
                    cboSales.Text = dt.Rows[0]["pas_username"].ToString();
                    txtCustomer.Focus();    
                }
                else
                {
                    strSQL = $@"select *
                                from   pri
                                       left join odi
                                              on odi_customerid = pri_customerid
                                where  pri_customerid = '{txtProductID.Text}' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        
                        txtLine.Text = dt.Rows[0]["odi_line"].ToString();
                        txtCZF.Text = dt.Rows[0]["odi_czf"].ToString();
                        txtMO.Text = dt.Rows[0]["odi_mo"].ToString();
                        txtCustomer.Text = dt.Rows[0]["pri_customer"].ToString(); ;
                        lblUser.Text = "";
                        lblSaveDate.Text = "";
                        cboSales.Text = dt.Rows[0]["odi_username"].ToString();
                        txtCustomer.Focus();
                    }
                    else
                    {
                        if (MessageBox.Show("你需要創建一個新的產品資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            
                        }
                        else
                        {
                            btnClear.PerformClick();
                            txtProductID.Focus();
                        }
                    }
                }
                

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

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                txtProductID.Text = "";
                txtLine.Text = "";
                txtCZF.Text = "";
                txtMO.Text = "MO";
                txtCustomer.Text = "";
                lblUser.Text = "";
                lblSaveDate.Text = "";
                cboSales.Text = "";
                txtCustomer.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnProofing_CZF_Product_Inq.Focus();
            }
        }

        private void txtProductID_Leave(object sender, EventArgs e)
        {
            getData();
        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCZF.Focus();
            }
        }

        private void txtCustomer_Leave(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select cus_yw,
                               pas_username
                        from   cus
                               left join pas
                                      on pas_ywcode = cus_yw
                                         and cus_yw <> ''
                        where  cus_id = '{txtCustomer.Text}' ";
            dt = clsDB.sql_select_dt(strSQL);
            if(dt.Rows.Count>0)
            {
                cboSales.Text = dt.Rows[0]["pas_username"].ToString();
            }
            else
            {
                cboSales.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                if(txtProductID.Text.Trim()=="")
                {
                    return;
                }
                //確認權限
                if (clsGlobal.checkRightFlag("打樣單樣品製作刪除") == false)
                {
                    MessageBox.Show("您沒有打樣單樣品製作刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("你確定要刪除這個打樣單產品資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    strSQL = $@"delete dyi where dyi_id = '{txtProductID.Text.Trim()}'";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("已經刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                if (txtProductID.Text.Trim() == "")
                {
                    return;
                }
                //確認權限
                if (clsGlobal.checkRightFlag("打樣單樣品製作儲存") == false)
                {
                    MessageBox.Show("您沒有打樣單樣品製作儲存權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select * from pas where pas_username = '{cboSales.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                string strSales = "";
                if (dt.Rows.Count > 0 )
                {
                    strSales = dt.Rows[0]["pas_ywcode"].ToString();
                }

                strSQL = $@"exec Dyi_save
                              '{txtProductID.Text.Trim()}',
                              '{txtLine.Text.Trim()}',
                              '{txtCZF.Text.Trim()}',
                              '{txtMO.Text.Trim()}',
                              '{txtCustomer.Text.Trim()}',
                              0,
                              '{strSales}' ";
                clsDB.Execute(strSQL);
                MessageBox.Show("已經儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //複製
            try
            {
                //確認權限
                if (clsGlobal.checkRightFlag("打樣單樣品製作複製") == false)
                {
                    MessageBox.Show("您沒有打樣單樣品製作複製權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                InputBox input = new InputBox();
                input.ShowInTaskbar = false;//圖示不顯示在工作列
                input.lblInfo.Text = "請輸入你要複製到的新打樣單產品號:";
                input.Text = "複製打樣單產品號";

                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (input.GetMsg() != "")
                    {
                        string strSQL = "";
                        DataTable dt = new DataTable();
                        strSQL = $@"select * from dyi where dyi_id = '{input.GetMsg()}'";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            if (MessageBox.Show("已經存在這個產品編號,你要不要覆蓋它?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                strSQL = $@"delete dyi where dyi_id = '{input.GetMsg()}'";
                                clsDB.Execute(strSQL);
                            }
                            else
                            {
                                return;
                            }
                        }
                        strSQL = $@"insert dyi
                                           (dyi_id,
                                            dyi_line,
                                            dyi_czf,
                                            dyi_mo,
                                            dyi_customer,
                                            dyi_active,
                                            dyi_ywcode)
                                    select '{input.GetMsg()}',
                                           dyi_line,
                                           dyi_czf,
                                           dyi_mo,
                                           dyi_customer,
                                           dyi_active,
                                           dyi_ywcode
                                    from   dyi
                                    where  dyi_id = '{txtProductID.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                        MessageBox.Show("已經複製完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtProductID.Text = input.GetMsg();
                        getData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCopy_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProofing_CZF_Product_Inq_Click(object sender, EventArgs e)
        {
            //查詢打樣單的產品編號
            try
            {
                frmProofing_CZF_Product_Inq frmProofing_CZF_Product_Inq = new frmProofing_CZF_Product_Inq();
                frmProofing_CZF_Product_Inq.ShowInTaskbar = false;//圖示不顯示在工作列

                frmProofing_CZF_Product_Inq.ShowDialog();
                if (rstrProductID != "")
                {
                    txtProductID.Text = rstrProductID;
                    getData();
                }
                rstrProductID = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnProofing_Inq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
