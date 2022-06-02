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
    public partial class frmCustomer_BankInfo : Form
    {
        public static string strCustomerID;
        public frmCustomer_BankInfo()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e) //重輸
        {
            //重輸
            txtPrincipal.Text = "";
            txtCapital.Text = "";
            txtBankInfo.Text = "";
            txtBankAccount.Text = "";
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSQL = $@"update cus
                               set    cus_fzr = '{txtPrincipal.Text}',
                                      cus_zbe = '{txtCapital.Text}',
                                      cus_bankinfo = '{txtBankInfo.Text}',
                                      cus_bankaccount = '{txtBankAccount.Text}'
                               where cus_id = '{strCustomerID}' ";
            clsDB.Execute(strSQL);
            MessageBox.Show("已經儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
