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
    public partial class frmBOM_Level1 : Form
    {
        string strID = ""; //第一層名稱
        
        public frmBOM_Level1()
        {
            InitializeComponent();
        }

        private void frmBOM_Level1_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {

                string strSQL = "";
                DataTable dt;
                strSQL = $@"select distinct ap1_assy
                            from   ap1
                            order  by ap1_assy ";
                dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;

                txtID.Focus();


            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOM_Level1_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnInq_Click(object sender, EventArgs e)   //查詢
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)   //新增
        {
            //新增
            try
            {
                String strSQL = "";
                DataTable dt = new DataTable();
                //欄位檢查
                if (txtID.Text == "")
                {
                    MessageBox.Show("請輸入第一層名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Focus();
                    return;
                }
                strSQL = $@"select ap1_assy
                            from   ap1
                            where  ap1_assy = '{txtID.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0)
                {
                    MessageBox.Show("你輸入的名稱有重複!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Focus();
                    return;
                }
                if (MessageBox.Show(this, "確定新增?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    strSQL = $@"insert into ap1
                                            (ap1_assy,
                                             ap1_part,
                                             ap1_adddate)
                                values      ('{txtID.Text}',
                                             '',
                                             Getdate())";
                    clsDB.Execute(strSQL);
                    strSQL = $@"insert into bomlog
                                (
                                            b_before,
                                            b_after,
                                            b_date,
                                            b_username,
                                            b_computername
                                )
                                values
                                (
                                            '1:',
                                            '{txtID.Text}',
                                            Getdate(),
                                            HOST_NAME(),
                                            '{clsGlobal.strG_User}'
                                )";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("新增完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //清除欄位
                    Clear();
                    //刪除後顯示查詢
                    Inquire();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnAdd_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex>=0)
                {
                    strID = dgvData.Rows[e.RowIndex].Cells["ap1_assy"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    txtID.Text = dgvData.Rows[e.RowIndex].Cells["ap1_assy"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellDoubleClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)    //修改
        {
            //修改
            try
            {
                String strSQL = "";
                DataTable dt = new DataTable();
                //欄位檢查
                if (txtID.Text == "")
                {
                    MessageBox.Show("請輸入第一層名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Focus();
                    return;
                }
                strSQL = $@"select ap1_assy
                            from   ap1
                            where  ap1_assy = '{txtID.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("你輸入的名稱有重複!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Focus();
                    return;
                }
                if (MessageBox.Show(this, "確定修改?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    strSQL = $@"update ap1
                                set    ap1_assy = '{txtID.Text}',
                                       ap1_adddate = getdate()
                                where  ap1_assy = '{strID}' ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"insert into bomlog
                                (
                                            b_before,
                                            b_after,
                                            b_date,
                                            b_username,
                                            b_computername
                                )
                                values
                                (
                                            '1:{strID}',
                                            '{txtID.Text}',
                                            Getdate(),
                                            HOST_NAME(),
                                            '{clsGlobal.strG_User}'
                                )";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("修改完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //清除欄位
                    Clear();
                    //刪除後顯示查詢
                    Inquire();

                }
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
                if (strID == "")
                {
                    MessageBox.Show("請選擇要刪除的第一層名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String strSQL = "";
                DataTable dt = new DataTable();
                //防呆確認
                if (MessageBox.Show(this, "確定刪除?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(txtID.Text!="")
                    {
                        strSQL = $@"delete from ap1
                                where  ap1_assy = '{txtID.Text}' ";
                    }
                    else
                    {
                        strSQL = $@"delete from ap1
                                    where  ap1_assy = '{strID}' ";
                    }

                    clsDB.Execute(strSQL);
                    strSQL = $@"insert into bomlog
                                (
                                            b_before,
                                            b_after,
                                            b_date,
                                            b_username,
                                            b_computername
                                )
                                values
                                (
                                            '1: delete-{strID}',
                                            '',
                                            Getdate(),
                                            HOST_NAME(),
                                            '{clsGlobal.strG_User}'
                                )";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //清除欄位
                    Clear();
                    //刪除後顯示查詢
                    Inquire();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (strID == "")
                    {
                        MessageBox.Show("請選擇要刪除的第一層名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    String strSQL = "";
                    DataTable dt = new DataTable();
                    //防呆確認
                    if (MessageBox.Show(this, "確定刪除?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        strSQL = $@"delete from ap1
                                where  ap1_assy = '{strID}' ";


                        clsDB.Execute(strSQL);
                        strSQL = $@"insert into bomlog
                                (
                                            b_before,
                                            b_after,
                                            b_date,
                                            b_username,
                                            b_computername
                                )
                                values
                                (Clear
                                            '1: delete-{strID}',
                                            '',
                                            Getdate(),
                                            HOST_NAME(),
                                            '{clsGlobal.strG_User}'
                                )";
                        clsDB.Execute(strSQL);
                        MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //清除欄位
                        Clear();
                        //刪除後顯示查詢
                        Inquire();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_KeyDown" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()    //清除
        {
            //清除
            try
            {
                DataTable dt = new DataTable(); ;
                dt = (DataTable)dgvData.DataSource;
                dt.Rows.Clear();
                dgvData.DataSource = dt;
                txtID.Text = "";
                strID = "";
                txtID.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-Clear" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inquire()  //查詢
        {
            //查詢
            try
            {
                string strSQL = "";
                DataTable dt;
                strSQL = $@"select distinct ap1_assy
                            from   ap1
                            order  by ap1_assy ";
                dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-Inquire" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
