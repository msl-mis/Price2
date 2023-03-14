using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Price2
{
    public partial class frmMaterial_Adjust : Form
    {
        string strQTY = ""; //數量的計算式
        public frmMaterial_Adjust()
        {
            InitializeComponent();
        }

        private void radioModify_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "變更";
            lblQty.Visible = true;
            txtQty.Visible = true;
            lblQty.Text = "數量為：";
        }

        private void radioAdd_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "新增";
            lblQty.Visible = true;
            txtQty.Visible = true;
            lblQty.Text = "數量：";
        }

        private void radioDelete_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Text = "刪除";
            lblQty.Visible = false;
            txtQty.Visible = false;
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtLength.Focus();
            }
        }

        private void txtCustomerID_Leave(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select distinct pri_customerid
                        from            pri
                        where           pri_customerid = '{txtCustomerID.Text.Trim()}'
                        and             pri_newcostchk like 'N%";
            dt = clsDB.sql_select_dt(strSQL);
            if(dt.Rows.Count==0)
            {
                MessageBox.Show("沒有此客號!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtCustomerID.Focus();
                return;
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(radioDelete.Checked )
                {
                    btnSave.Focus();
                }
                else
                {
                    txtQty.Focus();
                }
            }
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            if (radioModify.Checked )
            {
                strSQL = $@"select distinct pri_part,
                                            asp_line
                            from   pri
                                   left join asp
                                          on asp_id = pri_part
                            where  pri_part = '{txtID.Text.Trim()}'
                                   and pri_newcostchk like 'N%' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("沒有這個材料或報價中沒有用到這個材料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Text = "";
                    return;
                }
            }
            else
            {
                strSQL = $@"select asp_id from asp where asp_id = '{txtID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("沒有這個材料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Text = "";
                    return;
                }
            }
            
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            { 
                btnSave.Focus();
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            strQTY = "";
            if (txtQty.Text == "")
            {
                txtQty.Text = "0";
            }
            else
            {
                strQTY = txtQty.Text;
                //計算式  計算機 引用using System.Data
                txtQty.Text = Convert.ToDouble(new DataTable().Compute(txtQty.Text, null)).ToString("0.####");
            }
        }

        private void txtQty_Enter(object sender, EventArgs e)
        {
            if (strQTY != "")
            {
                txtQty.Text = strQTY;
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
                
                txtCustomer.Text = "";
                txtLine.Text = "";
                txtCustomerID.Text = "";
                txtLength.Text = "";
                txtQty.Text = "";
                txtID.Text = "";

                txtCustomer.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //變更新增刪除
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                if (txtID.Text == "")
                {
                    MessageBox.Show("沒有輸入材料,不能進行調整!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtLine.Text == "" && txtCustomerID.Text =="")
                {
                    MessageBox.Show("必須輸入線路或客號,才能進行調整!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(txtQty.Text=="")
                {
                    txtQty.Text = "0";
                }
                if (txtQty.Text == "0" && radioDelete.Checked==false)
                {
                    MessageBox.Show("調整數量不可以為零,不能進行調整!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtCustomer.Text == "" && txtLine.Text == "" && txtCustomerID.Text == "" && txtLength.Text == "")
                {
                    MessageBox.Show("沒有輸入任何條件,不能調整!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(radioModify.Checked)//更改材料數量
                {

                }
                if (radioAdd.Checked)//新增材料
                {

                }
                if (radioDelete.Checked)//刪除材料
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void doModify()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
        }

        private void doAdd()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
        }

        private void doDelete()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
        }
    }
}
