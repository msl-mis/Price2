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
    public partial class frmBOM : Form
    {
        public static Boolean blnHighlight; //判斷是否唯讀
        public static Boolean blnInquery; //判斷是否查詢
        public static Boolean blnInq_Material; //判斷是否查材料名使用情形傳來(frmInq_Material_Status)
        string strUpd01="";    //第一層上傳字串
        Boolean blnUpdchk1=false; //檢查第一層上資料是否有被修改
        Boolean blnDgv1=false;  //資料載入完成
        string strID = ""; //第四層名稱
        public frmBOM()
        {
            InitializeComponent();
        }

        private void frmBOM_Load(object sender, EventArgs e)
        {

        }

        private void frmBOM_Activated(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                if(blnHighlight)
                {
                    lblHighlight.Visible = true;
                    btnAdd.Visible = false;
                    btnDelete.Visible = false;
                    btnModify_L1.Visible = false;
                    btnModify_L2.Visible = false;
                    btnModify_L3.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    txtID.Visible = false;
                    txtPurprice.Visible = false;
                    txtVendorid.Visible = false;
                    txtCurrency.Visible = false;
                    txtTbprice.Visible = false;
                    
                }
                else if(blnInquery)
                {
                    btnAdd.Visible = false;
                    btnDelete.Visible = false;
                    btnModify_L1.Visible = false;
                    btnModify_L2.Visible = false;
                    btnModify_L3.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    txtID.Visible = false;
                    txtPurprice.Visible = false;
                    txtVendorid.Visible = false;
                    txtCurrency.Visible = false;
                    txtTbprice.Visible = false;
                    this.Text = "查詢BOM產品結構資料";
                    lblHighlight.Visible = false;
                    btnTrackChanges.Visible = false;
                }
                else if (blnInq_Material)
                {
                    btnAdd.Visible = false;
                    btnDelete.Visible = false;
                    btnModify_L1.Visible = false;
                    btnModify_L2.Visible = false;
                    btnModify_L3.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    txtID.Visible = false;
                    txtPurprice.Visible = false;
                    txtVendorid.Visible = false;
                    txtCurrency.Visible = false;
                    txtTbprice.Visible = false;
                    this.Text = "查詢BOM產品結構資料";
                    lblHighlight.Visible = false;
                    btnTrackChanges.Visible = false;
                }
                else
                {
                    lblHighlight.Visible = false;
                    btnAdd.Visible = true;
                    btnDelete.Visible = true;
                    btnModify_L1.Visible = true;
                    btnModify_L2.Visible = true;
                    btnModify_L3.Visible = true;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select distinct ap1_assy
                            from   ap1
                            order  by ap1_assy ";
                dt= clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count>0)
                {
                    dgvLevel_1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOM_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            try
            {
                if(dgvData.Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)dgvData.DataSource;
                    dt.Rows.Clear();
                    dgvData.DataSource = dt;
                }
                
                strID = "";
                txtID.Text = "";
                txtPurprice.Text = "";
                txtVendorid.Text = "";
                txtCurrency.Text = "";
                txtTbprice.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-Clear" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) //結束
        {
            //結束
            try
            {
                if (blnInquery!=true)
                {
                    frmMain frmMain = (frmMain)this.MdiParent;
                    frmMain.gbMain.Visible = true;
                    if (lblHighlight.Visible == false)    //清除BOM使用旗標
                    {
                        string strSQL = $@"update pub set pub_bomuse='' ";
                        clsDB.Execute(strSQL);
                        //BOM解鎖 label隱藏
                        frmMain.lblBOM_Unlock.Visible = false;
                    }
                }
                blnInquery = false;
                blnHighlight = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModify_L1_Click(object sender, EventArgs e)
        {
            try
            {
                frmBOM_Level1 frmBOM_Level1 = new frmBOM_Level1();
                frmBOM_Level1.ShowInTaskbar = false;//圖示不顯示在工作列
                frmBOM_Level1.ShowDialog();
                //item清空,重新查詢
                
                clear_dgvLevel_1();
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select distinct ap1_assy
                            from   ap1
                            order  by ap1_assy ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    cboLevel1.Items.Add(dt.Rows[i]["ap1_assy"].ToString());
                    //}
                    dgvLevel_1.DataSource = dt;
                }
                clear_dgvLevel_2();
                clear_dgvLevel_3();
                clear_dgvLevel_4();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnModify_L1_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModify_L2_Click(object sender, EventArgs e)
        {
            try
            {
                frmBOM_Level2 frmBOM_Level2 = new frmBOM_Level2();
                frmBOM_Level2.ShowInTaskbar = false;//圖示不顯示在工作列
                frmBOM_Level2.ID1 = dgvLevel_1.Rows[dgvLevel_1.CurrentRow.Index].Cells["ap1_assy"].Value.ToString();
                frmBOM_Level2.ShowDialog();
                //item清空,重新查詢
                clear_dgvLevel_2();
                //清除第三層名稱
                clear_dgvLevel_3();
                //清除第四層名稱
                clear_dgvLevel_4();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnModify_L2_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModify_L3_Click(object sender, EventArgs e)
        {
            try
            {
                frmBOM_Level3 frmBOM_Level3 = new frmBOM_Level3();
                frmBOM_Level3.ShowInTaskbar = false;//圖示不顯示在工作列
                frmBOM_Level3.ID1 = dgvLevel_1.Rows[dgvLevel_1.CurrentRow.Index].Cells["ap1_assy"].Value.ToString();
                frmBOM_Level3.ID2 = dgvLevel_2.Rows[dgvLevel_2.CurrentRow.Index].Cells["ap1_part"].Value.ToString();
                frmBOM_Level3.ShowDialog();
                //item清空,重新查詢
                clear_dgvLevel_3();
                //清除第四層名稱
                clear_dgvLevel_4();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnModify_L2_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    strID = dgvData.Rows[e.RowIndex].Cells["ap3_part"].Value.ToString();
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
                    if(blnInquery)
                    {
                        frmProduct.strProductID = dgvData.Rows[e.RowIndex].Cells["ap3_part"].Value.ToString();
                        blnInquery = false;
                        this.Close();
                    }
                    else if(blnInq_Material)
                    {
                        frmInq_Material_Status.rstrMaterialID = dgvData.Rows[e.RowIndex].Cells["ap3_part"].Value.ToString();
                        blnInq_Material = false;
                        this.Close();
                    }
                    else
                    {
                        txtID.Text = dgvData.Rows[e.RowIndex].Cells["ap3_part"].Value.ToString();
                        txtPurprice.Text = dgvData.Rows[e.RowIndex].Cells["ap3_purprice"].Value.ToString();
                        txtVendorid.Text = dgvData.Rows[e.RowIndex].Cells["ap3_vendorid"].Value.ToString();
                        txtCurrency.Text = dgvData.Rows[e.RowIndex].Cells["ap3_currency"].Value.ToString();
                        txtTbprice.Text = dgvData.Rows[e.RowIndex].Cells["ap3_tbprice"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellDoubleClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(dgvLevel_3.RowCount==0)
                {
                    return;
                }
                txtPurprice.Text = "";
                txtVendorid.Text = "";
                txtCurrency.Text = "";
                txtTbprice.Text = "";
                if (txtID.Text == "")
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                //先判斷是否重複
                strSQL = $@"select ap3_part
                            from   ap3
                            where  ap3_part = '{txtID.Text.Trim()}'
                                   and ap3_assy = '{dgvLevel_3.Rows[dgvLevel_3.CurrentCell.RowIndex].Cells["ap2_part"].Value.ToString()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("你輸入的名稱有重複!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //沒重複則將欄位填入
                strSQL = $@"select asp_purprice,
                                asp_currency,
                                asp_vendorid
                        from   asp
                        where  asp_id = '{txtID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0)
                {
                    txtPurprice.Text = dt.Rows[0]["asp_purprice"].ToString();
                    txtVendorid.Text = dt.Rows[0]["asp_vendorid"].ToString();
                    txtCurrency.Text = dt.Rows[0]["asp_currency"].ToString();
                    string strSQL2 = $@"select cur_convert
                                        from   cur
                                        where  cur_code = '{txtCurrency.Text}' ";
                    DataTable dt2 = new DataTable();
                    dt2 = clsDB.sql_select_dt(strSQL2);
                    if(dt2.Rows.Count > 0)
                    {
                        txtTbprice.Text =( Convert.ToDouble(dt2.Rows[0]["cur_convert"].ToString())* Convert.ToDouble(txtPurprice.Text)).ToString("#0.######");
                    }
                }
                else
                {
                    MessageBox.Show("沒有該產品,請先在基本資料中輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //檢查欄位
                if(dgvData.RowCount==0)
                {
                    MessageBox.Show("你不能列印該表,因為你還沒有移到第四層名稱上!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("你確定要列印該BOM資料表嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                frmReport frmReport = new frmReport();
                //傳入參數
                frmReport.strReportName = "bomlist";
                frmReport.strRP[0] = dgvLevel_1.Rows[dgvLevel_1.CurrentCell.RowIndex].Cells["ap1_assy"].Value.ToString();
                frmReport.strRP[1] = dgvLevel_2.Rows[dgvLevel_2.CurrentCell.RowIndex].Cells["ap1_part"].Value.ToString();
                frmReport.strRP[2] = dgvLevel_3.Rows[dgvLevel_3.CurrentCell.RowIndex].Cells["ap2_part"].Value.ToString();
                frmReport.strSQL = $@"select ap3_part,
                                             asp_vendormaterialno,
                                             ap3_purprice,
                                             ap3_currency,
                                             ap3_tbprice,
                                             ap3_vendorid
                                      from   ap3,
                                             asp
                                      where  ap3_part = asp_id
                                             and ap3_assy = '{dgvLevel_3.Rows[dgvLevel_3.CurrentCell.RowIndex].Cells["ap2_part"].Value.ToString()}' ";
                frmReport.ShowInTaskbar = false;//圖示不顯示在工作列
                frmReport.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTrackChanges_Click(object sender, EventArgs e)
        {
            try
            {
                frmBOM_TrackChanges frmBOM_TrackChanges = new frmBOM_TrackChanges();
                frmBOM_TrackChanges.ShowInTaskbar = false;//圖示不顯示在工作列
                frmBOM_TrackChanges.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnTrackChanges_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inquire()  //查詢
        {
            //查詢
            try
            {
                String strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select ap3_part,
                                   ap3_purprice,
                                   ap3_vendorid,
                                   ap3_currency,
                                   ap3_tbprice,
                                   ap3_adddate
                            from   ap3
                            where  ap3_assy = '{dgvLevel_3.Rows[dgvLevel_3.CurrentCell.RowIndex].Cells["ap2_part"].Value.ToString()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-Inquire" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (txtID.Text == ""||txtPurprice.Text=="")
                {
                    MessageBox.Show("請輸入第四層名稱並按下ENTER!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Focus();
                    return;
                }
                //判斷是否重複
                strSQL = $@"select ap3_part
                            from   ap3
                            where  ap3_part = '{txtID.Text.Trim()}'
                                   and ap3_assy = '{dgvLevel_3.Rows[dgvLevel_3.CurrentCell.RowIndex].Cells["ap2_part"].Value.ToString()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("你輸入的名稱有重複!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show(this, "確定新增?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    strSQL = $@"insert into ap3
                                            (ap3_assy,
                                             ap3_part,
                                             ap3_purprice,
                                             ap3_vendorid,
                                             ap3_currency,
                                             ap3_tbprice,
                                             ap3_adddate)
                                values      ('{dgvLevel_3.Rows[dgvLevel_3.CurrentCell.RowIndex].Cells["ap2_part"].Value.ToString()}',
                                             '{txtID.Text}',
                                             {txtPurprice.Text},
                                             '{txtVendorid.Text}',
                                             '{txtCurrency.Text}',
                                             {txtTbprice.Text},
                                             Getdate()) ";
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
                                            '4:',
                                            '{dgvLevel_3.Rows[dgvLevel_3.CurrentCell.RowIndex].Cells["ap2_part"].Value.ToString()},{txtID.Text},{txtPurprice.Text},{txtVendorid.Text},{txtCurrency.Text},{txtTbprice.Text}',
                                            Getdate(),
                                            HOST_NAME(),
                                            '{clsGlobal.strG_User}'
                                )";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("新增完畢!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //清除欄位
                    Clear();
                    //新增後顯示查詢
                    Inquire();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnAdd_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if(blnHighlight|| blnInquery)
                    {
                        return;
                    }
                    if (strID == "")
                    {
                        MessageBox.Show("請選擇要刪除的第四層名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    String strSQL = "";
                    DataTable dt = new DataTable();
                    //防呆確認
                    if (MessageBox.Show(this, "確定刪除?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (txtID.Text != "")
                        {
                            strSQL = $@"delete from ap3
                                where  ap3_part = '{txtID.Text}' 
                                       and ap3_assy = '{dgvLevel_3.Rows[dgvLevel_3.CurrentCell.RowIndex].Cells["ap2_part"].Value.ToString()}' ";
                        }
                        else
                        {
                            strSQL = $@"delete from ap3
                                    where  ap3_part = '{strID}' 
                                           and ap3_assy = '{dgvLevel_3.Rows[dgvLevel_3.CurrentCell.RowIndex].Cells["ap2_part"].Value.ToString()}' ";
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
                                            '4: delete-{dgvLevel_3.Rows[dgvLevel_3.CurrentCell.RowIndex].Cells["ap2_part"].Value.ToString()},{strID}',
                                            '',
                                            Getdate(),
                                            HOST_NAME(),
                                            '{clsGlobal.strG_User}'
                                )";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                if(strID=="")
                {
                    MessageBox.Show("請選擇要刪除的第四層名稱!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                String strSQL = "";
                DataTable dt = new DataTable();
                //防呆確認
                if (MessageBox.Show(this, "確定刪除?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (txtID.Text != "")
                    {
                        strSQL = $@"delete from ap3
                                where  ap3_part = '{txtID.Text}' 
                                       and ap3_assy = '{dgvLevel_3.Rows[dgvLevel_3.CurrentCell.RowIndex].Cells["ap2_part"].Value.ToString()}' ";
                    }
                    else
                    {
                        strSQL = $@"delete from ap3
                                    where  ap3_part = '{strID}' 
                                           and ap3_assy = '{dgvLevel_3.Rows[dgvLevel_3.CurrentCell.RowIndex].Cells["ap2_part"].Value.ToString()}' ";
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
                                            '4: delete-{dgvLevel_3.Rows[dgvLevel_3.CurrentCell.RowIndex].Cells["ap2_part"].Value.ToString()},{strID}',
                                            '',
                                            Getdate(),
                                            HOST_NAME(),
                                            '{clsGlobal.strG_User}'
                                )";
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

        private void clear_dgvLevel_1()
        {
            if (dgvLevel_1.Rows.Count > 0)
            {
                DataTable dt = (DataTable)dgvLevel_1.DataSource;
                dt.Rows.Clear();
                dgvLevel_1.DataSource = dt;
            }
        }

        private void clear_dgvLevel_2()
        {
            if (dgvLevel_2.Rows.Count > 0)
            {
                DataTable dt = (DataTable)dgvLevel_2.DataSource;
                dt.Rows.Clear();
                dgvLevel_2.DataSource = dt;
            }
        }

        private void clear_dgvLevel_3()
        {
            if (dgvLevel_3.Rows.Count > 0)
            {
                DataTable dt = (DataTable)dgvLevel_3.DataSource;
                dt.Rows.Clear();
                dgvLevel_3.DataSource = dt;
            }
        }

        private void clear_dgvLevel_4()
        {
            if (dgvData.Rows.Count > 0)
            {
                DataTable dt = (DataTable)dgvData.DataSource;
                dt.Rows.Clear();
                dgvData.DataSource = dt;
                //dgvData.Rows.Clear();
            }
        }

        private void dgvLevel_1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //加入第二層名稱
            try
            {
                if (e.RowIndex >= 0)
                {
                    //先將後面三層清除
                    clear_dgvLevel_2();
                    clear_dgvLevel_3();
                    clear_dgvLevel_4();
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    strSQL = $@"select ap1_part
                            from   ap1
                            where  ap1_assy = '{dgvLevel_1.Rows[e.RowIndex].Cells["ap1_assy"].Value.ToString()}'
                            order  by ap1_part ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        dgvLevel_2.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvLevel_1_CellClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLevel_2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //加入第三層名稱
            try
            {
                //先將後面二層清除
                clear_dgvLevel_3();
                clear_dgvLevel_4();
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select ap2_part
                            from   ap2
                            where  ap2_assy = '{dgvLevel_2.Rows[e.RowIndex].Cells["ap1_part"].Value.ToString()}'
                            order  by ap2_part ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvLevel_3.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvLevel_2_CellClick" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLevel_3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //加入第四層名稱
            try
            {
                //先將後面一層清除
                clear_dgvLevel_4();
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select ap3_part,
                                   ap3_purprice,   
                                   ap3_vendorid,
                                   ap3_currency,
                                   ap3_tbprice,
                                   ap3_adddate
                            from   ap3
                            where  ap3_assy = '{dgvLevel_3.Rows[e.RowIndex].Cells["ap2_part"].Value.ToString()}' ";

                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    dgvData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-cboLevel3_TextChanged" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
