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
    public partial class frmProofing_Note_Manage : Form
    {
        public static string rstrCustomer = "";   //傳來的客戶
        public frmProofing_Note_Manage()
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

        private void frmProofing_Note_Manage_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                txtCustomer.Text = rstrCustomer;
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmProofing_Note_Manage_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()
        {
            try
            {
                String strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select obz_no,
                                   obz_description,
                                   Isnull(obz_adduser, '') obz_adduser,
                                   Format(obz_adddate, 'yyyy/MM/dd HH:mm:ss') obz_adddate 
                            from   obz
                            where  obz_customer = '{txtCustomer.Text.Trim()}'
                            order  by obz_nbr ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvData.Focus();
            }
        }

        private void txtCustomer_Leave(object sender, EventArgs e)
        {
            getData();
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0 && e.ColumnIndex>=0)
            {
                txtCode.Text = dgvData.Rows[e.RowIndex].Cells["obz_no"].Value.ToString();
                txtNote.Text = dgvData.Rows[e.RowIndex].Cells["obz_description"].Value.ToString();
                lblCreator.Text = dgvData.Rows[e.RowIndex].Cells["obz_adduser"].Value.ToString();
                lblDate.Text = dgvData.Rows[e.RowIndex].Cells["obz_adddate"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                if(txtCode.Text=="")
                {
                    return;
                }
                getDelete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getDelete()
        {
            //確認權限
            if (clsGlobal.checkRightFlag("打樣單管理備註代碼刪除") == false)
            {
                MessageBox.Show("您沒有備註代碼刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("你確認要要刪除嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"delete obz where obz_no = '{txtCode.Text.Trim()}' and obz_customer = '{txtCustomer.Text.Trim()}' ";
                clsDB.Execute(strSQL);
                MessageBox.Show("已經刪除成功!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //清除欄位
                txtCode.Text = "";
                txtNote.Text = "";
                lblCreator.Text = "";
                lblDate.Text = "";
                getData();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //新增
            try
            {
                if (txtCode.Text == "")
                {
                    return;
                }

                if (txtNote.Text == "")
                {
                    MessageBox.Show("請編輯備註內容!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNote.Focus();
                    return;
                }

                //檢查備註代碼是否重複
                String strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select * from obz where obz_no = '{txtCode.Text.Trim()}' and obz_customer = '{txtCustomer.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count>0)
                {
                    MessageBox.Show("已經存在這個備註代碼!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCode.Focus();
                    return;
                }
                else
                {
                    strSQL = $@"insert into obz
                                            (obz_no,
                                             obz_description,
                                             obz_customer,
                                             obz_adddate,
                                             obz_adduser)
                                values      ('{txtCode.Text.Trim()}',
                                             '{txtNote.Text.Trim()}',
                                             '{txtCustomer.Text.Trim()}',
                                             Getdate(),
                                             '{clsGlobal.strG_User}') ";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("已經新增成功!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //清除欄位
                    txtCode.Text = "";
                    txtNote.Text = "";
                    lblCreator.Text = "";
                    lblDate.Text = "";
                    getData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnAdd_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //修改
            try
            {
                if (txtCode.Text == "")
                {
                    return;
                }

                if (txtNote.Text == "")
                {
                    MessageBox.Show("請編輯備註內容!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNote.Focus();
                    return;
                }

                //檢查備註代碼是否重複
                String strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select * from obz where obz_no = '{txtCode.Text.Trim()}' and obz_customer = '{txtCustomer.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    strSQL = $@"update obz
                                set    obz_description = '{txtNote.Text.Trim()}',
                                       obz_customer = '{txtCustomer.Text.Trim()}',
                                       obz_adduser = '{clsGlobal.strG_User}',
                                       obz_adddate = Getdate()
                                where  obz_no = '{txtCode.Text.Trim()}'
                                       and obz_customer = '{txtCustomer.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("已經修改成功!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //清除欄位
                    txtCode.Text = "";
                    txtNote.Text = "";
                    lblCreator.Text = "";
                    lblDate.Text = "";
                    getData();
                }
                else
                {
                    MessageBox.Show("請選擇欲修改的備註代碼!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCode.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnAdd_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
