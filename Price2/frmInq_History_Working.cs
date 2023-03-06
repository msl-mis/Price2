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
    public partial class frmInq_History_Working : Form
    {
        public frmInq_History_Working()
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                //更改日期
                //txtDate_S.Text = "";
                //txtDate_E.Text = "";

                if (dgvData.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)dgvData.DataSource;
                    dt.Rows.Clear();
                    dgvData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmInq_History_Working_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                txtDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtDate_S.Text = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd");
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmPriceSetting_Copper_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void getData()
        {
            if (Convert.ToDateTime(txtDate_S.Text) > Convert.ToDateTime(txtDate_E.Text))
            {
                MessageBox.Show("起始日期不可以大於結束日期!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string Date_S = txtDate_S.Text + " 00:00:00";
            string Date_E = txtDate_E.Text + " 23:59:59";

            this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select Format(create_date, 'yyyy/MM/dd HH:mm') '更改日期',
                               working_USD                             '加工費USD',
                               working_RMB                             '加工費RMB',
                               user_id                                 '修改人員'
                        from   copper_working_history
                        where  create_date between '{Date_S}' and '{Date_E}'
                        order  by create_date desc ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                dgvData.DataSource = dt;
            }
            this.Cursor = Cursors.Default;//滑鼠還原預設
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                if (MessageBox.Show("確定要刪除嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"delete from copper_working_history
                            where  Format(create_date, 'yyyy-MM-dd HH:mm') = '{Convert.ToDateTime(dgvData.Rows[dgvData.CurrentRow.Index].Cells["更改日期"].Value).ToString("yyyy-MM-dd HH:mm")}' ";
                clsDB.Execute(strSQL);
                getData();
                MessageBox.Show("刪除成功!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
