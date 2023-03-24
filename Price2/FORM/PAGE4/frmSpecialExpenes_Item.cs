using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Price2
{
    public partial class frmSpecialExpenes_Item : Form
    {
        string strTypeID = ""; //type_id
        string strItemID = ""; //item_id
        public frmSpecialExpenes_Item()
        {
            InitializeComponent();
        }

        private void frmSpecialExpenes_Item_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                //加入支出類別
                strSQL = $@"select type_id, type_name from odca_type order by type_serial_no ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboType.Items.Add(dt.Rows[i]["type_name"].ToString());
                    }
                    cboType.Text = dt.Rows[0]["type_name"].ToString();
                    strTypeID = dt.Rows[0]["type_id"].ToString();
                }
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmSpecialExpenes_Item_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select a.type_id        type_id,
                               a.type_name      type_name,
                               b.item_id        item_id,
                               b.item_name      item_name,
                               b.item_serial_no item_serial_no
                        from   odca_type a,
                               odca_item b
                        where  a.type_id = b.type_id
                               and type_name = '{cboType.Text}'
                        order  by item_serial_no ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dgvData.DataSource = dt;
                strTypeID = dt.Rows[0]["type_id"].ToString();
            }
            else
            {
                MessageBox.Show("查不到資料!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvData.DataSource = dt;
            }
        }

        private void cboType_TextChanged(object sender, EventArgs e)
        {
            getData();
        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if(clsGlobal.ValidateString(txtID.Text, 6)==false)
            {
                MessageBox.Show("序號請輸入數字!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.SelectionStart=0; 
                txtID.SelectionLength=txtID.Text.Length;
                txtID.Focus();

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
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                //更新畫面中的欄位資料 
                strTypeID = dgvData.Rows[e.RowIndex].Cells["type_id"].Value.ToString();//type_id
                cboType.Text = dgvData.Rows[e.RowIndex].Cells["type_name"].Value.ToString();//type_name
                txtID.Text = dgvData.Rows[e.RowIndex].Cells["item_serial_no"].Value.ToString();//序號
                txtName.Text = dgvData.Rows[e.RowIndex].Cells["item_name"].Value.ToString();//item_name
                strItemID = dgvData.Rows[e.RowIndex].Cells["item_id"].Value.ToString();//item_id
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                //更新畫面中的欄位資料
                strTypeID = dgvData.Rows[e.RowIndex].Cells["type_id"].Value.ToString();//type_id
                strItemID = dgvData.Rows[e.RowIndex].Cells["item_id"].Value.ToString();//item_id
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //新增
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                //欄位限制防呆
                if(txtID.Text == "")
                {
                    MessageBox.Show("序號不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtName.Text == "")
                {
                    MessageBox.Show("子項名稱不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //檢查是否有相同子項名稱
                strSQL = $@"select * from odca_item where type_id = '{strTypeID}' and item_name = '{txtName.Text.Trim()}'";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count>0)
                {
                    MessageBox.Show("有相同子項名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("確定要新增嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                //先取得item_id
                strSQL = $@"select * from odca_item where type_id = '{strTypeID}' ";
                dt = clsDB.sql_select_dt(strSQL);
                string strID = "000";
                if (dt.Rows.Count > 0)
                {
                    strID = dt.Rows.Count.ToString("000");
                }

                //新增
                strSQL = $@"insert into odca_item
                                        (type_id,
                                         item_id,
                                         item_name,
                                         item_serial_no)
                            values      ('{strTypeID}',
                                         '{strID}',
                                         '{txtName.Text}',
                                         '{txtID.Text}') ";
                clsDB.Execute(strSQL);
                //輸入後顯示查詢
                getData();
                //清除欄位
                txtID.Text = "";
                txtName.Text = "";
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
                DataTable dt = new DataTable();
                //欄位限制防呆
                if (txtID.Text == "")
                {
                    MessageBox.Show("序號不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtName.Text == "")
                {
                    MessageBox.Show("子項名稱不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("確定要修改嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                //修改
                strSQL = $@"update odca_item
                            set    item_name = '{txtName.Text}',
                                   item_serial_no = '{txtID.Text}'
                            where  type_id = '{strTypeID}'
                                   and item_id = '{strItemID}' ";
                clsDB.Execute(strSQL);
                //輸入後顯示查詢
                getData();
                //清除欄位
                txtID.Text = "";
                txtName.Text = "";
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
                DataTable dt = new DataTable();
                //欄位限制防呆
                //查詢odca是否有資料
                strSQL = $@"select * from odca where odca_type = '{strTypeID}' and odca_item = '{strItemID}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("此子項類別在特別支出已有資料,不可刪除!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("確定要刪除嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                //刪除
                strSQL = $@"delete from odca_item where type_id = '{strTypeID}' and item_id = '{strItemID}' ";
                clsDB.Execute(strSQL);
                //輸入後顯示查詢
                getData();
                //清除欄位
                txtID.Text = "";
                txtName.Text = "";
                MessageBox.Show("刪除完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if (strItemID != "")
                {
                    btnDelete.PerformClick();   
                }
            }
        }
    }
}
