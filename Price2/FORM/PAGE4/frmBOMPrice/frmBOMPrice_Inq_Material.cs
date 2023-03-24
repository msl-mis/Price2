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
    public partial class frmBOMPrice_Inq_Material : Form
    {
        public static string rstrID = "";  //由frmBOMPrice傳的材料ID
        public static string rstrName = "";  //由frmBOMPrice傳的材料Name
        public static string rstrUnit = "";  //由frmBOMPrice傳的單位

        public frmBOMPrice_Inq_Material()
        {
            InitializeComponent();
        }

        private void frmBOMPrice_Inq_Material_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                //BUTTON顯示
                if (clsGlobal.checkRightFlag("材料單查詢刪除") == false)
                {
                    btnDelete.Visible = false;
                }
                if (clsGlobal.checkRightFlag("材料單查詢全部刪除") == false)
                {
                    btnDeleteAll.Visible = false;
                }
                //清除
                GetClear();
                
                //傳入的參數
                if (rstrID != "")
                {
                    chkID.Checked = false;
                    txtID.Text = rstrID;
                }
                if (rstrName != "")
                {
                    chkLine.Checked = false;
                    txtLine.Text = rstrName;
                }
                if (rstrUnit != "")
                {
                    cboUnit.Text = rstrUnit;    
                }

                //搜尋
                GetInq();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOMPrice_Inq_Material_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) //結束
        {
            //結束
            try
            {
                frmBOMPrice.rstrButton = "Close";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)    //導出
        {
            //導出
            try
            {
                if (dgvData.CurrentRow != null)
                {
                    getExport();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getExport()
        {
            try
            {
                frmBOMPrice.rstrID = dgvData.Rows[dgvData.CurrentRow.Index].Cells["材料名"].Value.ToString();
                frmBOMPrice.rstrName = dgvData.Rows[dgvData.CurrentRow.Index].Cells["品號"].Value.ToString();
                frmBOMPrice.rstrButton = "ExportInq";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getExport" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e) //列印
        {
            //列印
            try
            {
                clsGlobal.ExportExcel("查詢材料單", dgvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnExport_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInq_Click(object sender, EventArgs e)   //搜尋
        {
            //搜尋
            try
            {
                GetInq();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetInq()
        {
            //搜尋
            try
            {
                string strSQL = "";
                string strWhere = "";
                string strOrder = "";
                DataTable dt = new DataTable();
                strSQL = $@"select distinct pri_customerid'材料名',
                                            pri_assy'品號',
                                            pri_newdate'新建日期',
                                            pri_clcost'材料價',
                                            pri_date'變動日期',
                                            pri_um '單位',
                                            case pri_newcostchk
                                                            when 'Y1' then '膠粒成本'
                                                            when 'Y2' then '一般成本'
                                                            when 'Y3'then '焊錫成本'
                                                            when 'Y4' then '抽線耗材'
                                                            when 'Y5' then '無鹵料'
                                                            when 'Y6' then '鋁箔附加'
                                                            when 'Y7' then '銅箔附加'
                                                            when 'Y8' then '熱縮套管'
                                                            when 'Y9' then '相乘計算'
                                                            when 'YA' then '相除計算'
                                                            when 'YB' then '平均成本'
                                                            else ''
                                            end '成本模式' ,
                                            pri_addusername'新建用戶'
                            from            pri
                            where  pri_newcostchk like 'Y%'";


                strOrder = $@"order by      pri_customerid,
                                            pri_assy,
                                            pri_newdate";
                strSQL = strSQL + Get_strWhere() + strOrder;
                dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;
                lblCount.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnInq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Get_strWhere()
        {
            string strWhere = "";
            
            //新增日期
            strWhere = strWhere + (chkNewDate.Checked ? "" : $@"and pri_newdate between '{txtNewDate_S.Text}' and '{txtNewDate_E.Text}' ");
            //變動日期
            strWhere = strWhere + (chkQuoteDate.Checked ? "" : $@"and pri_date between '{txtQuoteDate_S.Text}' and '{txtQuoteDate_E.Text}' ");
            //品號
            if (txtLine.Text.IndexOf(";") >= 0)//分號多條件搜尋
            {
                string[] str = txtLine.Text.Split(';');
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Trim();
                    strWhere = strWhere + $@"and pri_assy like '%{str[i].Trim()}%' ";
                }
            }
            else
            {
                strWhere = strWhere + (chkLine.Checked ? "" : $@"and pri_assy like '%{txtLine.Text.Trim()}%' ");
            }
            //材料名
            if (txtID.Text.IndexOf(";") >= 0)//分號多條件搜尋
            {
                string[] str = txtID.Text.Split(';');
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Trim();
                    strWhere = strWhere + $@"and pri_customerid like '%{str[i].Trim()}%' ";
                }
            }
            else
            {
                strWhere = strWhere + (chkID.Checked ? "" : $@"and pri_customerid like '%{txtID.Text.Trim()}%' ");
            }
            //BOM材料名
            if (chkFullInq.Checked)
            {
                strWhere = strWhere + (chkLine.Checked ? "" : $@"and pri_part = '{txtPart.Text.Trim()}' ");
            }
            else
            {
                if (txtPart.Text.IndexOf(";") >= 0)//分號多條件搜尋
                {
                    string[] str = txtPart.Text.Split(';');
                    for (int i = 0; i < str.Length; i++)
                    {
                        str[i] = str[i].Trim();
                        strWhere = strWhere + $@"and pri_part like '%{str[i].Trim()}%' ";
                    }
                }
                else
                {
                    strWhere = strWhere + (chkPart.Checked ? "" : $@"and pri_part like '%{txtPart.Text.Trim()}%' ");
                }
            }
            
            //未成交
            strWhere = strWhere + (chkUse_Yet.Checked ? "and pri_customerid not in (select distinct pri_part from pri) " : "");
            //光纖
            strWhere = strWhere + (chkFiber.Checked ? "and pri_fenlei = '14 Fiber Cable' " : "");
            //廠商
            strWhere = strWhere + (chkVendor.Checked ? "" : $@"and pri_vendorid = '{txtVendor.Text.Trim()}' ");
            //單位
            strWhere = strWhere + (cboUnit.Text == "(ALL)" ? "" : $@"and pri_um = '{cboUnit.Text.Trim()}' ");

            return strWhere;
        }

        private void btnClear_Click(object sender, EventArgs e) //清除
        {
            //清除
            try
            {
                GetClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetClear()
        {
            try
            {
                chkLine.Checked = true;

                chkNewDate.Checked = true;
                chkQuoteDate.Checked = true;

                chkID.Checked = true;
                chkPart.Checked = true;
                chkVendor.Checked = true;

                cboUnit.Text = "(ALL)";
                lblCount.Text = "0";


                chkUse_Yet.Checked = false;

                chkFiber.Checked = false;

                if (dgvData.Rows.Count > 0)
                {
                    DataTable dt = (DataTable)dgvData.DataSource;
                    dt.Rows.Clear();
                    dgvData.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-GetClear" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkNewDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewDate.Checked)
            {
                txtNewDate_S.Text = "(ALL)";
                txtNewDate_E.Text = "(ALL)";
            }
            else
            {
                txtNewDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtNewDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtNewDate_E_Enter(object sender, EventArgs e)
        {
            chkNewDate.Checked=false;
        }

        private void txtNewDate_S_Enter(object sender, EventArgs e)
        {
            chkNewDate.Checked = false;
        }

        private void chkQuoteDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQuoteDate.Checked)
            {
                txtQuoteDate_S.Text = "(ALL)";
                txtQuoteDate_E.Text = "(ALL)";
            }
            else
            {
                txtQuoteDate_S.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtQuoteDate_E.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void txtQuoteDate_E_Enter(object sender, EventArgs e)
        {
            chkQuoteDate.Checked = false;
        }

        private void txtQuoteDate_S_TextChanged(object sender, EventArgs e)
        {
            chkQuoteDate.Checked = false;
        }

        private void chkLine_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLine.Checked)
            {
                txtLine.Text = "(ALL)";
            }
            else
            {
                txtLine.Text = "";
            }
        }

        private void txtLine_Enter(object sender, EventArgs e)
        {
            chkLine.Checked = false;
        }

        private void chkID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkID.Checked)
            {
                txtID.Text = "(ALL)";
            }
            else
            {
                txtID.Text = "";
            }
        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            chkID.Checked = false;
        }

        private void chkPart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPart.Checked)
            {
                txtPart.Text = "(ALL)";
                chkFullInq.Checked = false;
            }
            else
            {
                txtPart.Text = "";
            }
        }

        private void txtPart_Enter(object sender, EventArgs e)
        {
            chkPart.Checked = false;
        }

        private void chkFullInq_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFullInq.Checked)
            {
                chkPart.Checked = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)    //刪除
        {
            //刪除
            try
            {
                //先檢查有沒有選擇GRID
                if (dgvData.CurrentRow == null)
                {
                    return;
                }
                //確認權限
                if (clsGlobal.checkRightFlag("材料單查詢刪除") == false)
                {
                    MessageBox.Show("您沒有材料單查詢刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                //再次確認
                if (MessageBox.Show("你確定要刪除它嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    //先檢查有沒有報價記錄
                    strSQL = $@"select pri_part from pri where pri_part = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["材料名"].Value.ToString()}'";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("此材料已有報價記錄,不能被刪除!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        strSQL = $@"delete pri
                                    where  pri_assy = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["品號"].Value.ToString()}'
                                           and pri_customerid = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["材料名"].Value.ToString()}'
                                           and pri_newcostchk like 'Y%' ";
                        clsDB.Execute(strSQL);
                        //檢查要刪除的材料名是否還有其他材料單,若沒有則把火車頭的標記移除
                        strSQL = $@"select pri_customerid
                                    from   pri
                                    where  pri_customerid = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["材料名"].Value.ToString()}'
                                           and pri_newcostchk like 'Y%' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if(dt.Rows.Count == 0)
                        {
                            strSQL = $@"update asp set asp_name = '' where asp_id = '{dgvData.Rows[dgvData.CurrentRow.Index].Cells["材料名"].Value.ToString()}'";
                            clsDB.Execute(strSQL);
                        }
                        
                        
                        MessageBox.Show("已刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetInq();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e) //全部刪除
        {
            //全部刪除
            try
            {
                //先檢查有沒有選擇GRID
                if (dgvData.CurrentRow == null)
                {
                    return;
                }
                //確認權限
                if (clsGlobal.checkRightFlag("材料單查詢全部刪除") == false)
                {
                    MessageBox.Show("您沒有材料單查詢全部刪除權限!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;//滑鼠還原預設
                    return;
                }
                //再次確認
                if (MessageBox.Show("你確認要刪除所有符合這些條件的資料嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    //先檢查有沒有報價記錄
                    for(int i=0;i<dgvData.Rows.Count;i++)
                    {
                        strSQL = $@"select pri_part from pri where pri_part = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}'";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("部分材料已有報價記錄,不能被刪除全部,請重設條件!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    for (int i = 0; i < dgvData.Rows.Count; i++)
                    {
                        strSQL = $@"delete pri
                                    where  pri_assy = '{dgvData.Rows[i].Cells["品號"].Value.ToString()}'
                                           and pri_customerid = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}'
                                           and pri_newcostchk like 'Y%' ";
                        clsDB.Execute(strSQL);
                        //檢查要刪除的材料名是否還有其他材料單,若沒有則把火車頭的標記移除
                        strSQL = $@"select pri_customerid
                                    from   pri
                                    where  pri_customerid = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}'
                                           and pri_newcostchk like 'Y%' ";
                        dt = clsDB.sql_select_dt(strSQL);
                        if (dt.Rows.Count == 0)
                        {
                            strSQL = $@"update asp set asp_name = '' where asp_id = '{dgvData.Rows[i].Cells["材料名"].Value.ToString()}'";
                            clsDB.Execute(strSQL);
                        }
                    }

                    strSQL = $@"select * from ord,pri where ord_assy = pri_customerid ";
                    MessageBox.Show("已刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetInq();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDeleteAll_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                getExport();
            }
        }
    }
}
