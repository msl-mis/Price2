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
        public static Boolean blnHighlight;
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
                DataTable dt;
                strSQL = $@"select distinct ap1_assy
                            from   ap1
                            order  by ap1_assy ";
                dt= clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboLevel1.Items.Add(dt.Rows[i]["ap1_assy"].ToString());
                    }
                }
                
                cboLevel2.Enabled = false;
                cboLevel3.Enabled = false;
                //清除cboLevel4
                strSQL = $@"select ap3_part,
                                   ap3_purprice,
                                   ap3_vendorid,
                                   ap3_currency,
                                   ap3_tbprice,
                                   ap3_adddate
                            from   ap3
                            where  1 != 1 ";
                dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;
                cboLevel1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOM_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  



        private void dgvLevel1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //string strSQL = "";
            //DataTable dt = new DataTable();
            //if (dgvLevel1.Rows[e.RowIndex].Cells["na1_assy"].Value.ToString() == "" && strUpd01.Contains("delete") == false)
            //{
            //    //清除第二層
            //dt = (DataTable)dgvLevel2.DataSource;
            //dt.Rows.Clear();
            //dgvLevel2.DataSource = dt;
            //    return;
            //}
            //else
            //{
            //    blnUpdchk1 = false;
            //    strSQL = $@"select *
            //                from   na1
            //                where  na1_assy <> ''
            //                       and na1_computername = Host_name()
            //                       and na1_assy = '{dgvLevel1.Rows[e.RowIndex].Cells["na1_assy"].Value.ToString()}' ";
            //    dt = clsDB.sql_select_dt(strSQL);
            //    if(dt.Rows.Count > 0)
            //    {
            //        MessageBox.Show("你輸入的名稱有重複!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dgvLevel1.Rows[e.RowIndex].Cells["na1_assy"].Value = strUpd01;
            //        return;
            //    }
            //    else
            //    {
            //        if (dgvLevel1.Rows[e.RowIndex].Cells["na1_assy"].Value.ToString() != strUpd01)
            //        {
            //            blnUpdchk1 = true;
            //            btnDelete.Enabled = true;
            //        }
            //strSQL = $@"select na2_assy,
            //                       na2_nbr
            //                from   na2
            //                where  na2_computername = Host_name() ";
            //dt = clsDB.sql_select_dt(strSQL);
            //dgvLevel2.DataSource = dt;
            //    }

            //    if (blnUpdchk1 == true)
            //    {
            //        if (strUpd01.Contains("delete") == false)
            //        {
            //            strSQL = $@"insert into na64
            //                                (na64_before,
            //                                 na64_after,
            //                                 na64_date,
            //                                 na64_username)
            //                    values     ('1:{strUpd01}',
            //                                '',
            //                                '{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")}',
            //                                '{clsGlobal.strG_User}') ";
            //            clsDB.Execute(strSQL);
            //        }
            //        else
            //        {
            //            strSQL = $@"insert into na64
            //                    (na64_before,
            //                     na64_after,
            //                     na64_date,
            //                     na64_username)
            //        values     ('1:{strUpd01}',
            //                    '{dgvLevel4.Rows[e.RowIndex].Cells["na1_assy"].Value.ToString()}',
            //                    '{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")}',
            //                    '{clsGlobal.strG_User}') ";
            //            clsDB.Execute(strSQL);
            //        }
            //    }
            //}

        }

        private void cboLevel1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //打開第二層名稱
                cboLevel2.Enabled = true;
                //清除第二層名稱
                cboLevel2.Items.Clear();
                //加入第二層名稱
                string strSQL = "";
                DataTable dt;
                strSQL = $@"select ap1_part
                            from   ap1
                            where  ap1_assy = '{cboLevel1.Text}'
                                   and ap1_part != '' 
                            order  by ap1_part ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboLevel2.Items.Add(dt.Rows[i]["ap1_part"].ToString());
                    }
                }
                //清除第三層名稱
                cboLevel3.Items.Clear();
                //關閉第三層名稱
                cboLevel3.Enabled = false;
                //清除第四層名稱
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-cboLevel1_TextChanged" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboLevel2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //打開第三層名稱
                cboLevel3.Enabled = true;
                //清除第三層名稱
                cboLevel3.Items.Clear();
                //加入第三層名稱
                string strSQL = "";
                DataTable dt;
                strSQL = $@"select distinct ap2_part
                            from   ap2
                            where  ap2_assy = '{cboLevel2.Text}'
                            order  by ap2_part ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboLevel3.Items.Add(dt.Rows[i]["ap2_part"].ToString());
                    }
                }
                //清除第四層名稱
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-cboLevel2_TextChanged" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cboLevel3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //加入第四層名稱
                string strSQL = "";
                DataTable dt;
                strSQL = $@"select ap3_part,
                                   ap3_purprice,
                                   ap3_vendorid,
                                   ap3_currency,
                                   ap3_tbprice,
                                   ap3_adddate
                            from   ap3
                            where  ap3_assy = '{cboLevel3.Text}' ";
                dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource=dt;    
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-cboLevel3_TextChanged" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) //結束
        {
            //結束
            try
            {
                frmMain frmMain = (frmMain)this.MdiParent;
                frmMain.gbMain.Visible = true;
                if (lblHighlight.Visible==false)    //清除BOM使用旗標
                {
                    string strSQL = $@"update pub set pub_bomuse='' ";
                    clsDB.Execute(strSQL);
                    //BOM解鎖 label隱藏
                    frmMain.lblBOM_Unlock.Visible = false;
                }
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
                frmBOM_Level1.ShowDialog();
                //item清空,重新查詢
                cboLevel1.Text = "";
                cboLevel1.Items.Clear();
                string strSQL = "";
                DataTable dt;
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

                cboLevel2.Text = "";
                cboLevel3.Text = "";
                cboLevel2.Enabled = false;
                cboLevel3.Enabled = false;
                //清除cboLevel4
                Clear();
                cboLevel1.Focus();
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
                frmBOM_Level2.ShowDialog();
                //item清空,重新查詢
                cboLevel2.Items.Clear();
                string strSQL = "";
                DataTable dt;
                strSQL = $@"select distinct ap1_part
                            from   ap1
                            where  ap1_assy = '{cboLevel1.Text}'
                            order  by ap1_part ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboLevel2.Items.Add(dt.Rows[i]["ap1_part"].ToString());
                    }
                }
                //清除第三層名稱
                cboLevel3.Items.Clear();
                //關閉第三層名稱
                cboLevel3.Enabled = false;
                //清除第四層名稱
                Clear();
                cboLevel2.Focus();
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
                frmBOM_Level3.ShowDialog();
                //item清空,重新查詢
                cboLevel3.Items.Clear();
                string strSQL = "";
                DataTable dt;
                strSQL = $@"select distinct ap2_part
                            from   ap2
                            where  ap2_assy = '{cboLevel2.Text}'
                            order  by ap2_part ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cboLevel3.Items.Add(dt.Rows[i]["ap2_part"].ToString());
                    }
                }
                ////清除第三層名稱
                //cboLevel3.Items.Clear();
                ////關閉第三層名稱
                //cboLevel3.Enabled = false;
                //清除第四層名稱
                Clear();
                cboLevel3.Focus();
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
                if (e.RowIndex >= 0)
                {
                    txtID.Text = dgvData.Rows[e.RowIndex].Cells["ap3_part"].Value.ToString();
                    txtPurprice.Text = dgvData.Rows[e.RowIndex].Cells["ap3_purprice"].Value.ToString();
                    txtVendorid.Text = dgvData.Rows[e.RowIndex].Cells["ap3_vendorid"].Value.ToString();
                    txtCurrency.Text = dgvData.Rows[e.RowIndex].Cells["ap3_currency"].Value.ToString();
                    txtTbprice.Text = dgvData.Rows[e.RowIndex].Cells["ap3_tbprice"].Value.ToString();

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
                if(cboLevel3.Text=="")
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
                                   and ap3_assy = '{cboLevel3.Text}' ";
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
                if(cboLevel3.Text=="")
                {
                    MessageBox.Show("你不能列印該表,因為你還沒有移到第三層名稱上!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("你確定要列印該BOM資料表嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                frmReport frmReport = new frmReport();
                //傳入參數
                frmReport.strReportName = "bomlist";
                frmReport.strRP[0] = cboLevel1.Text;
                frmReport.strRP[1] = cboLevel2.Text;
                frmReport.strRP[2] = cboLevel3.Text;
                frmReport.strSQL = $@"select ap3_part,
                                             asp_vendormaterialno,
                                             ap3_purprice,
                                             ap3_currency,
                                             ap3_tbprice,
                                             ap3_vendorid
                                      from   ap3,
                                             asp
                                      where  ap3_part = asp_id
                                             and ap3_assy = '{cboLevel3.Text}' ";
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
                            where  ap3_assy = '{cboLevel3.Text}' ";
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
                                   and ap3_assy = '{cboLevel3.Text}' ";
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
                                values      ('{cboLevel3.Text}',
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
                                            '{cboLevel3.Text},{txtID.Text},{txtPurprice.Text},{txtVendorid.Text},{txtCurrency.Text},{txtTbprice.Text}',
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
                                       and ap3_assy = '{cboLevel3.Text}' ";
                        }
                        else
                        {
                            strSQL = $@"delete from ap3
                                    where  ap3_part = '{strID}' 
                                           and ap3_assy = '{cboLevel3.Text}' ";
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
                                            '4: delete-{cboLevel3.Text},{strID}',
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
                                       and ap3_assy = '{cboLevel3.Text}' ";
                    }
                    else
                    {
                        strSQL = $@"delete from ap3
                                    where  ap3_part = '{strID}' 
                                           and ap3_assy = '{cboLevel3.Text}' ";
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
                                            '4: delete-{cboLevel3.Text},{strID}',
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
    }
}
