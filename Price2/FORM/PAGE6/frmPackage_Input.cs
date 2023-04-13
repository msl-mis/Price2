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
    public partial class frmPackage_Input : Form
    {
        public static string rstrCustomerID = "";   //客號
        public static string rstrZX = "";           //材積
        public static string rstrXZ = "";           //箱量
        public static string rstrJZ = "";           //淨重
        public static string rstrMZ = "";           //毛重
        public static string rstrCustomer = "";     //客戶
        public static string rstrLine = "";         //線路
        public static string rstrUser = "";         //用戶
        public static string rstrDate = "";         //最後儲存日期

        public frmPackage_Input()
        {
            InitializeComponent();
        }

        private void btnCustomerID_Inq_Click(object sender, EventArgs e)
        {
            //查詢訂單
            try
            {
                frmPackage_Input_Inq frmPackage_Input_Inq = new frmPackage_Input_Inq();
                frmPackage_Input_Inq.ShowInTaskbar = false;//圖示不顯示在工作列
                frmPackage_Input_Inq.rstrCustomerID= txtCustomerID.Text;
                frmPackage_Input_Inq.rstrCustomer = txtCustomer.Text;
                frmPackage_Input_Inq.ShowDialog();
                if (rstrCustomerID != "")
                {
                    txtCustomerID.Text = rstrCustomerID;
                    txtZX.Text = rstrZX;
                    txtXZ.Text = rstrXZ;
                    txtJZ.Text = rstrJZ;
                    txtMZ.Text = rstrMZ;
                    txtCustomer.Text = rstrCustomer;
                    txtLine.Text = rstrLine;
                    lblUser.Text = rstrUser;
                    lblDate.Text = Convert.ToDateTime( rstrDate).ToString("yyyy/MM/dd");
                }
                rstrCustomerID = "";
                rstrZX = "";
                rstrXZ = "";
                rstrJZ = "";
                rstrMZ = "";
                rstrCustomer = "";
                rstrLine = "";
                rstrUser = "";
                rstrDate = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCustomerID_Inq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtCustomerID.Text = "";
                txtZX.Text = "";
                txtXZ.Text = "";
                txtJZ.Text = "";
                txtMZ.Text = "";
                txtCustomer.Text = "";
                txtLine.Text = "";
                lblUser.Text = "";
                lblDate.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                if(txtCustomerID.Text == "")
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"update odi
                            set    odi_zx = {txtZX.Text.Trim()},
                                   odi_xz = {txtXZ.Text.Trim()},
                                   odi_jz = {txtJZ.Text.Trim()},
                                   odi_mz = {txtMZ.Text.Trim()},
                                   odi_cjuser = '{clsGlobal.strG_User}',
                                   odi_cjadddate = Getdate()
                            where  odi_customerid = '{txtCustomerID.Text.Trim()}' ";
                clsDB.Execute(strSQL);
                getData();
                MessageBox.Show("儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtXZ.Focus();
            }
        }

        private void txtCustomerID_Leave(object sender, EventArgs e)
        {
            getData();
        }

        private void getData()
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標

                strSQL = $@"select distinct odi_customerid'產品號',
                                            odi_zx        '材積',
                                            odi_xz        '箱量',
                                            odi_jz        '淨重',
                                            odi_mz        '毛重',
                                            odi_customer  '客戶',
                                            odi_line      '線路',
                                            odi_cjuser    '用戶',
                                            odi_cjadddate '儲存日期'
                            from   odi
                            where  odi_customerid ='{txtCustomerID.Text.Trim()}' ";

                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    txtCustomerID.Text = dt.Rows[0]["產品號"].ToString();
                    txtZX.Text = dt.Rows[0]["材積"].ToString();
                    txtXZ.Text = dt.Rows[0]["箱量"].ToString();
                    txtJZ.Text = dt.Rows[0]["淨重"].ToString();
                    txtMZ.Text = dt.Rows[0]["毛重"].ToString();
                    txtCustomer.Text = dt.Rows[0]["客戶"].ToString();
                    txtLine.Text = dt.Rows[0]["線路"].ToString();
                    lblUser.Text = dt.Rows[0]["用戶"].ToString();
                    lblDate.Text = Convert.ToDateTime(dt.Rows[0]["儲存日期"]).ToString("yyyy/MM/dd");
                }
                
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPackage_Input_Load(object sender, EventArgs e)
        {
            txtCustomerID.Focus();
        }

        private void frmPackage_Input_Activated(object sender, EventArgs e)
        {
            txtCustomerID.Focus();
        }
    }
}
