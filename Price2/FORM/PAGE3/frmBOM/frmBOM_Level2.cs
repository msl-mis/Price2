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
    public partial class frmBOM_Level2 : Form
    {
        public static string ID1 = "";
        string strID = ""; //第二層名稱

        public frmBOM_Level2()
        {
            InitializeComponent();
        }

        private void frmBOM_Level2_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {

                string strSQL = "";
                DataTable dt;
                cboLevel1.Items.Clear();
                strSQL = $@"select distinct ap1_assy
                            from   ap1
                            order  by ap1_assy ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboLevel1.Items.Add(dt.Rows[i]["ap1_assy"].ToString());
                    }
                }

                strSQL = $@"select distinct ap1_part
                            from   ap1
                            where  1!=1 ";
                dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;

                cboLevel1.Text = ID1;
                cboLevel1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOM_Level2_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLevel1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Clear();
                //加入第二層名稱
                string strSQL = "";
                DataTable dt;
                strSQL = $@"select ap1_part
                            from   ap1
                            where  ap1_assy = '{cboLevel1.Text}'
                                   and ap1_part != '' 
                            order  by ap1_part ";
                dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;
                txtID.Text = "";
                
                txtID.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-cboLevel3_TextChanged" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)dgvData.DataSource;
                dt.Rows.Clear();
                dgvData.DataSource = dt;
                txtID.Text = "";
                strID = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-Clear" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //新增
            try
            {
                String strSQL = "";
                DataTable dt = new DataTable();
                //欄位檢查
                if (txtID.Text == "")
                {
                    MessageBox.Show("請輸入第二層名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Focus();
                    return;
                }
                strSQL = $@"select ap1_part
                            from   ap1
                            where  ap1_part = '{txtID.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
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
                                values      ('{cboLevel1.Text}',
                                             '{txtID.Text}',
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
                                            '2:',
                                            '{cboLevel1.Text},{txtID.Text}',
                                            Getdate(),
                                            HOST_NAME(),
                                            '{clsGlobal.strG_User}'
                                )";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("新增完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //清除欄位
                    Clear();
                    txtID.Text = "";
                    //新增後顯示查詢
                    Inquire();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnAdd_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inquire()  //查詢
        {
            //查詢
            try
            {
                String strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select ap1_part
                            from   ap1
                            where  ap1_assy = '{cboLevel1.Text}'
                                   and ap1_part != '' ";
                dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-Inquire" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //修改
            try
            {
                String strSQL = "";
                DataTable dt = new DataTable();
                //欄位檢查
                if (txtID.Text == "")
                {
                    MessageBox.Show("請輸入第二層名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Focus();
                    return;
                }
                if(strID=="")
                {
                    MessageBox.Show("請點選欲修改的第二層名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Focus();
                    return;
                }
                strSQL = $@"select ap1_part
                            from   ap1
                            where  ap1_part = '{txtID.Text}' ";
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
                                set    ap1_part = '{txtID.Text}',
                                       ap1_adddate = getdate()
                                where  ap1_part = '{strID}' ";
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
                                            '2:,{cboLevel1.Text},{strID}',
                                            '{cboLevel1.Text},{txtID.Text}',
                                            Getdate(),
                                            HOST_NAME(),
                                            '{clsGlobal.strG_User}'
                                )";
                    clsDB.Execute(strSQL);
                    //修改ap2
                    strSQL = $@"update ap2
                                set    ap2_assy = '{txtID.Text}',
                                       ap2_adddate = getdate()
                                where  ap2_assy = '{strID}' ";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("修改完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //清除欄位
                    Clear();
                    txtID.Text = "";
                    //新增後顯示查詢
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
                    MessageBox.Show("請選擇要刪除的第二層名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String strSQL = "";
                DataTable dt = new DataTable();
                //防呆確認
                if (MessageBox.Show(this, "確定刪除?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtID.Text != "")
                    {
                        strSQL = $@"delete from ap1
                                where  ap1_part = '{txtID.Text}' ";
                    }
                    else
                    {
                        strSQL = $@"delete from ap1
                                    where  ap1_part = '{strID}' ";
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
                                            '2: delete-{strID}',
                                            '',
                                            Getdate(),
                                            HOST_NAME(),
                                            '{clsGlobal.strG_User}'
                                )";
                    clsDB.Execute(strSQL);
                    //刪除ap2
                    strSQL = $@"delete from ap2
                                where  ap2_assy = '{strID}' ";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //清除欄位
                    Clear();
                    txtID.Text = "";
                    //新增後顯示查詢
                    Inquire();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnModify_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    strID = dgvData.Rows[e.RowIndex].Cells["ap1_part"].Value.ToString();
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
                    txtID.Text = dgvData.Rows[e.RowIndex].Cells["ap1_part"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellDoubleClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("請選擇要刪除的第二層名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    String strSQL = "";
                    DataTable dt = new DataTable();
                    //防呆確認
                    if (MessageBox.Show(this, "確定刪除?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //刪除ap1
                        strSQL = $@"delete from ap1
                                    where  ap1_part = '{strID}' ";
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
                                            '2: delete-{strID}',
                                            '',
                                            Getdate(),
                                            HOST_NAME(),
                                            '{clsGlobal.strG_User}'
                                )";
                        clsDB.Execute(strSQL);
                        //刪除ap2
                        strSQL = $@"delete from ap2
                                where  ap2_assy = '{strID}' ";
                        clsDB.Execute(strSQL);
                        MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //清除欄位
                        Clear();
                        txtID.Text = "";
                        //新增後顯示查詢
                        Inquire();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_KeyDown" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
