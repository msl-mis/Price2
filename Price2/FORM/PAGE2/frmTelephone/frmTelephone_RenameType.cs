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
    public partial class frmTelephone_RenameType : Form
    {
        public frmTelephone_RenameType()
        {
            InitializeComponent();
        }
        public static string strUser;
        public static string strItem;
        private void btnOK_Click(object sender, EventArgs e)    //確認
        {
            //確認
            try
            {
                if(cboType.Text=="")
                {
                    MessageBox.Show("沒有選擇子項，無法更名!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtItem.Text == "")
                {
                    MessageBox.Show("請輸入新的子項名稱", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String strSQL = $@"update tel
                                    set    tel_type = '{txtItem.Text.Trim()}'
                                    where tel_username = '{strUser}'
                                           and tel_type = '{cboType.Text.Trim()}' ";
                clsDB.Execute(strSQL);
                strItem = txtItem.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnOK_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)    //取消
        {
            //取消
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCancel_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmTelephone_RenameType_Activated(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                String strSQL = $@"select distinct tel_type
                                            from   tel
                                            where  tel_username = '{strUser}'
                                                   and Rtrim(tel_type) not in ('(ALL)')";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                //清除
                cboType.Items.Clear();
                //使用者加入
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cboType.Items.Add(dt.Rows[i]["tel_type"]);
                }
                if (strItem != "(ALL)")
                {
                    cboType.Text = strItem;
                }
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmTelephone_RenameType_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
