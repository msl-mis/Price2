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
    public partial class frmTodo_List : Form
    {
        int intUUID = 0;
        public frmTodo_List()
        {
            InitializeComponent();
        }

        private void frmTodo_List_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {

                string strSQL = "";
                DataTable dt = new DataTable();

                //加入使用者
                strSQL = $@"select pas_username from pas order by pas_username ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboUser.Items.Add(dt.Rows[i]["pas_username"].ToString());
                    }
                }
                cboUser.Text = clsGlobal.strG_User;

                //日期
                dtpDateS.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.Now.Day);

                dtpDateE.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmTodo_List_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTodo_List_Activated(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                getData();
                btnInq.Focus(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmTodo_List_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkT.Checked)
            {
                chkF.Checked = false;
            }
        }

        private void chkF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkF.Checked)
            {
                chkT.Checked = false;
            }
        }

        private void getData()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            if (dtpDateS.Value > dtpDateE.Value)
            {
                MessageBox.Show("起始日期不可以大於結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string strWhere = "";
            strWhere = strWhere + (cboUser.Text.Trim() == "" ? "" : $@"and user_name = '{cboUser.Text.Trim()}' ");
            strWhere = strWhere + (chkT.Checked ? $@"and chk = 'V' " : "");
            strWhere = strWhere + (chkF.Checked ? $@"and chk = 'X' " : "");

            strSQL = $@"select uuid,
                               user_name,
                               finish_date,
                               item,
                               chk
                        from   todo_list
                        where  finish_date between '{dtpDateS.Text}' and '{dtpDateE.Text}' ";
            strSQL = strSQL + strWhere + "order by finish_date";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dgvData.DataSource = dt;
            }
            else
            {
                dgvData.DataSource = dt;
                MessageBox.Show("查不到資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnInq_Click(object sender, EventArgs e)
        {
            //查詢
            try
            {
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string strSQL = "";
                string strCHK = "";
                //欄位限制防呆
                if (txtItem.Text == "")
                {
                    MessageBox.Show("待辦事項不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtItem.Focus();
                    return;
                }
                if (MessageBox.Show("確定要新增嗎 ?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if (chkOK.Checked)
                {
                    strCHK = "V";
                }
                else
                {
                    strCHK = "X";
                }

                strSQL = $@"insert into todo_list
                                        (user_name,
                                         finish_date,
                                         item,
                                         chk,
                                         userid,
                                         create_date)
                            values      ('{clsGlobal.strG_User}',
                                         '{dtpDate.Text}',
                                         '{txtItem.Text}',
                                         '{strCHK}',
                                         '{clsGlobal.strG_User}',
                                         Getdate()) ";
                clsDB.Execute(strSQL);
                //輸入後顯示查詢
                getData();
                //清除欄位

                txtItem.Text = "";
                chkOK.Checked = false;
                MessageBox.Show("新增完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string strSQL = "";
                string strCHK = "";
                //欄位限制防呆
                if (intUUID == 0)
                {
                    MessageBox.Show("請選擇欲修改項目!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtItem.Text == "")
                {
                    MessageBox.Show("待辦事項不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtItem.Focus();
                    return;
                }
                if (MessageBox.Show("確定要修改嗎 ?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if (chkOK.Checked)
                {
                    strCHK = "V";
                }
                else
                {
                    strCHK = "X";
                }

                strSQL = $@"update todo_list
                            set    finish_date = '{dtpDate.Text}',
                                   item = '{txtItem.Text}',
                                   chk = '{strCHK}',
                                   userid = '{clsGlobal.strG_User}',
                                   update_date = Getdate()
                            where  uuid = {intUUID} ";
                clsDB.Execute(strSQL);
                //輸入後顯示查詢
                getData();
                //清除欄位

                txtItem.Text = "";
                chkOK.Checked = false;
                MessageBox.Show("修改完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string strSQL = "";
                string strCHK = "";
                //欄位限制防呆
                if (intUUID == 0)
                {
                    MessageBox.Show("請選擇欲刪除項目!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("確定要刪除嗎 ?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                strSQL = $@"delete from todo_list where uuid = {intUUID} ";
                clsDB.Execute(strSQL);
                //輸入後顯示查詢
                getData();
                //清除欄位

                txtItem.Text = "";
                chkOK.Checked = false;
                MessageBox.Show("刪除成功!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnModify_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //更新畫面中的欄位資料
            intUUID = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["uuid"].Value);            //UUID
            dtpDate.Text = dgvData.Rows[e.RowIndex].Cells["finish_date"].Value.ToString();          //日期
            txtItem.Text = dgvData.Rows[e.RowIndex].Cells["item"].Value.ToString();        //待辦事項
            if (dgvData.Rows[e.RowIndex].Cells["chk"].Value.ToString()=="V")
            {
                chkOK.Checked = true;
            }
            else
            {
                chkOK.Checked = false;
            }

        }
    }
}
