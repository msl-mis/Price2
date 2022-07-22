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
    public partial class frmBOM_TrackChanges : Form
    {
        public frmBOM_TrackChanges()
        {
            InitializeComponent();
        }

        private void frmBOM_TrackChanges_Activated(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select b_date,
                                   b_username,
                                   b_before,
                                   b_after
                            from   bomlog
                            where  b_date >= ( Getdate() - 7 )
                            order  by b_date desc ";
                dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOM_TrackChanges_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radWeek_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(radWeek.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    strSQL = $@"select b_date,
                                   b_username,
                                   b_before,
                                   b_after
                            from   bomlog
                            where  b_date >= ( Getdate() - 7 )
                            order  by b_date desc ";
                    dt = clsDB.sql_select_dt(strSQL);
                    dgvData.DataSource = dt;
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-radWeek_CheckedChanged" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radMonth_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radMonth.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    strSQL = $@"select b_date,
                                   b_username,
                                   b_before,
                                   b_after
                            from   bomlog
                            where  b_date >= ( Getdate() - 30 )
                            order  by b_date desc ";
                    dt = clsDB.sql_select_dt(strSQL);
                    dgvData.DataSource = dt;
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-radMonth_CheckedChanged" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radYear_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radYear.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    strSQL = $@"select b_date,
                                   b_username,
                                   b_before,
                                   b_after
                            from   bomlog
                            where  b_date >= ( Getdate() - 180 )
                            order  by b_date desc ";
                    dt = clsDB.sql_select_dt(strSQL);
                    dgvData.DataSource = dt;
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-radYear_CheckedChanged" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radAll.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    strSQL = $@"select b_date,
                                   b_username,
                                   b_before,
                                   b_after
                            from   bomlog
                            order  by b_date desc ";
                    dt = clsDB.sql_select_dt(strSQL);
                    dgvData.DataSource = dt;
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-radAll_CheckedChanged" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
