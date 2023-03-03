using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Price2
{
    public partial class frmUserManagement : Form
    {
        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==13)
            {
                getData_UserName(txtUserName.Text); //取得用戶名相關資料或創建新用戶
            }
        }

        private void getData_UserName(string strUserName)
        {
            //取得用戶名相關資料或創建新用戶
            try
            {
                //clsDB.Open();    //SQL連線
                String strSQL = $@"select dbo.Readpwd(pas_password) as pwd,
                                          *
                                   from   pas
                                   where  pas_username = '{strUserName}' ";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0)
                {
                    txtPassword.Text= dt.Rows[0]["pwd"].ToString();
                    txtName.Text= dt.Rows[0]["pas_name"].ToString();
                    txtBusinessCode.Text = dt.Rows[0]["pas_ywcode"].ToString();
                    txtDepartment.Text = dt.Rows[0]["pas_quote"].ToString();

                    //先把checkbox歸零
                    for (int i = 0; i < dgvUser.RowCount; i++)
                    {
                        dgvUser.Rows[i].Cells["chk"].Value = false;
                    }
                    string rs = "";
                    //再把checkbox依條件打勾
                    for (int i = 0; i < dgvUser.RowCount; i++)
                    {
                        strSQL = $@"select mod_flag
                                    from   mod
                                    where  mod_username = '{strUserName}'
                                           and mod_modulename = '{dgvUser.Rows[i].Cells["mod_modulename"].Value}' ";
                        rs = clsDB.sql_select_String(strSQL, "mod_flag");
                        if (rs == "1")
                        {
                            dgvUser.Rows[i].Cells["chk"].Value = true;
                        }
                    }
                    txtPassword.Focus();
                }
                else
                {
                    if (MessageBox.Show("你想創建一個新用戶嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtPassword.Text = "";
                        txtName.Text = "";
                        txtBusinessCode.Text = "";
                        txtDepartment.Text = "";
                        txtPassword.Focus();
                    }
                    else
                    {
                        //清除
                        btnClear.PerformClick();
                    }
                }
                //clsDB.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData_UserName" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //結束
            try
            {
                //frmMain frmMain = (frmMain)this.MdiParent;
                //frmMain.gbMain.Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-_btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtName.Text = "";
                txtBusinessCode.Text = "";
                txtDepartment.Text = "";
                for (int i = 0; i < dgvUser.RowCount; i++)
                {
                    dgvUser.Rows[i].Cells["chk"].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-_btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 儲存
            try
            {
                if (MessageBox.Show("你確定要儲存嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //clsDB.Open();
                    String strSQL = $@"exec pas_save
                                            '{txtUserName.Text.Trim()}',
                                            '{txtPassword.Text.Trim()}',
                                            '{txtName.Text.Trim()}',
                                            '{txtBusinessCode.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    string rs = "";
                    strSQL = $@"update pas
                                set    pas_quote = '{txtDepartment.Text.Trim()}'
                                where pas_username = '{txtUserName.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    int mod_flag = 0;
                    for (int i = 0; i < dgvUser.RowCount; i++)
                    {
                        if(dgvUser.Rows[i].Cells["chk"].Value.ToString() == "True")
                        {
                            mod_flag = 1;
                        }
                        else
                        {
                            mod_flag = 0;
                        }
                        //mod_flag = (dgvUser.Rows[i].Cells["chk"].Value == true ? 1 : 0);

                        //查詢mod是否有值,有就UPDATE;沒有就INSERT
                        strSQL = $@"select mod_modulename
                                    from   mod
                                    where  mod_username = '{txtUserName.Text.Trim()}'
                                            and mod_modulename = '{dgvUser.Rows[i].Cells["mod_modulename"].Value.ToString()}' ";
                        rs = clsDB.sql_select_String(strSQL, "mod_modulename");
                        if (rs != "")
                        {
                            strSQL = $@"update mod
                                        set    mod_username = '{txtUserName.Text.Trim()}',
                                               mod_flag = {mod_flag},
                                               mod_orderflag = '{dgvUser.Rows[i].Cells["mod_orderflag"].Value.ToString()}',
                                               mod_dispflag = '{dgvUser.Rows[i].Cells["mod_dispflag"].Value.ToString()}'
                                        where mod_username = '{txtUserName.Text.Trim()}'
                                               and mod_modulename = '{dgvUser.Rows[i].Cells["mod_modulename"].Value.ToString()}' ";
                            clsDB.Execute(strSQL);
                        }
                        else
                        {
                            strSQL = $@"insert into [dbo].[mod]
                                                    ([mod_username],
                                                     [mod_menu],
                                                     [mod_modulename],
                                                     [mod_flag],
                                                     [mod_orderflag],
                                                     mod_dispflag)
                                        values     ('{txtUserName.Text.Trim()}',
                                                    '{dgvUser.Rows[i].Cells["mod_menu"].Value.ToString()}',
                                                    '{dgvUser.Rows[i].Cells["mod_modulename"].Value.ToString()}',
                                                    {mod_flag},
                                                    '{dgvUser.Rows[i].Cells["mod_orderflag"].Value.ToString()}',
                                                    '{dgvUser.Rows[i].Cells["mod_dispflag"].Value.ToString()}') ";
                            clsDB.Execute(strSQL);
                        }   
                    }
                    strSQL = $@"select Isnull(mod_flag, 0) as flag
                                    from   mod
                                    where  mod_username = '{txtUserName.Text.Trim()}'
                                           and mod_modulename = '受限為Y客戶' ";
                    rs = clsDB.sql_select_String(strSQL, "mod_modulename");
                    if (rs != "")
                    {
                        string strControluser = (rs == "1" ? "√" : "");
                        strSQL = $@"update pas
                                        set    pas_controluser = '{strControluser}'
                                        where pas_username = '{txtUserName.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                    }
                    //clsDB.Close();
                    MessageBox.Show("已經存盤完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                if (txtUserName.Text.Trim()=="YZF")
                {
                    MessageBox.Show("你不能刪除此用戶!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; 
                }
                //clsDB.Open();
                String strSQL = $@"select * from pas where pas_username='{txtUserName.Text.Trim()}'";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    if (MessageBox.Show("你要刪除這個用戶嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        strSQL = $@"delete from pas where pas_username='{txtUserName.Text.Trim()}'";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete from mod where mod_username='{txtUserName.Text.Trim()}'";
                        clsDB.Execute(strSQL);
                        MessageBox.Show("已經刪除成功!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClear.PerformClick();
                    }
                }
                else
                {
                    MessageBox.Show("沒有這個用戶!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //clsDB.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmUserManagement_Activated(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                //clsDB.Open();    //SQL連線
                String strSQL = $@"select mod_modulename,
                                          mod_dispflag,
                                          mod_menu,
                                          mod_orderflag
                                   from   mod
                                   where  mod_username = 'yzf'
                                   order  by mod_orderflag,
                                             mod_menu,
                                             mod_modulename collate chinese_taiwan_stroke_cs_as_ks_ws ";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                dgvUser.DataSource = dt;
                //先把checkbox歸零
                for (int i = 0; i < dgvUser.RowCount; i++)
                {
                    dgvUser.Rows[i].Cells["chk"].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmUserManagement_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            //匯出EXCEL
            try
            {
                lblTime.Visible=true;
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                Boolean blnPassprn = false;   //權限
                int I = 0;
                int J = 0;
                int K = 0;
                string strSQL = "";
                DataTable dt;
                if (clsGlobal.strG_User.ToUpper() == "LENNY" || clsGlobal.strG_User.ToUpper() == "YZF")
                {
                    blnPassprn = true;
                }
                else
                {
                    blnPassprn = false;
                }
                //首先初始化excel object
                Excel.Application excelApp = new Excel.ApplicationClass();

                //在建立excel workbook之前，檢查系統是否安裝excel
                if (excelApp == null)
                {
                    // if equal null means EXCEL is not installed.
                    MessageBox.Show("Excel is not properly installed!");
                    return;
                }

                //判斷檔案是否存在，如果存在就開啟workbook，如果不存在就新建一個
                Excel.Workbook workBook;
                //if (File.Exists(filename))
                //{
                //    workBook = excelApp.Workbooks.Open(filename, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                //}
                //else
                //{
                //    workBook = excelApp.Workbooks.Add(true);
                //}

                workBook = excelApp.Workbooks.Add(true);    //新建一個

                Excel.Worksheet workSheet = workBook.ActiveSheet as Excel.Worksheet;    //new a worksheet

                //write data
                workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);//獲得第i個sheet，準備寫入
                Excel.Range range;
                strSQL = $@"delete from na67 where na67_computername=HOST_NAME()";
                clsDB.Execute(strSQL);

                strSQL = $@"insert into na67
                        select '',
                               mod_menu,
                               mod_modulename,
                               Host_name(),
                               mod_orderflag,
                               '',
                               '',
                               ''
                        from   mod
                        where  mod_username = 'yzf'
                        order  by mod_orderflag ";
                clsDB.Execute(strSQL);

                workSheet.Range["A1:C1"].MergeCells = true;
                workSheet.Cells[1, 1] = "使用者權限清單";
                workSheet.Cells.Font.Name = "新細明體";
                workSheet.Cells.Font.FontStyle = "粗體";
                workSheet.Cells.Font.Size = 12;
                workSheet.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                workSheet.Cells.Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle;

                if (blnPassprn == true)
                {
                    workSheet.Range["A2:A5"].MergeCells = true;
                    workSheet.Range["B2:C2"].MergeCells = true;
                    workSheet.Range["B3:C3"].MergeCells = true;
                    workSheet.Range["B4:C4"].MergeCells = true;
                    workSheet.Range["B5:C5"].MergeCells = true;
                    workSheet.Cells[2, 1] = "模組";
                    workSheet.Cells[2, 2] = "用戶名";
                    workSheet.Cells[3, 2] = "密碼";
                    workSheet.Cells[4, 2] = "名字";
                    workSheet.Cells[5, 2] = "單位";
                    I = 6;
                }
                else
                {
                    workSheet.Range["A2:A4"].MergeCells = true;
                    workSheet.Range["B2:C2"].MergeCells = true;
                    workSheet.Range["B3:C3"].MergeCells = true;
                    workSheet.Range["B4:C4"].MergeCells = true;
                    workSheet.Cells[2, 1] = "模組";
                    workSheet.Cells[2, 2] = "用戶名";
                    workSheet.Cells[3, 2] = "名字";
                    workSheet.Cells[4, 2] = "單位";
                    I = 5;
                }

                strSQL = $@"select mod_menu,
                                mod_dispflag,
                                mod_modulename
                        from   mod
                        where  mod_username = 'yzf'
                        order  by mod_orderflag,
                                    mod_menu,
                                    mod_modulename collate chinese_taiwan_stroke_cs_as_ks_ws ";
                dt = clsDB.sql_select_dt(strSQL);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    workSheet.Cells[I, 1] = dt.Rows[i]["mod_menu"].ToString().Trim(); //模塊名稱
                    workSheet.Cells[I, 2] = "'" + dt.Rows[i]["mod_dispflag"].ToString().Trim();  //模組名稱
                    workSheet.Cells.NumberFormatLocal = "@";
                    workSheet.Cells[I, 3] = dt.Rows[i]["mod_modulename"].ToString().Trim();  //模組名稱
                    strSQL = $@"update na67
                            set    na67_id = '{(I - 5).ToString().Trim()}'
                            where na67_orderid = '{dt.Rows[i]["mod_modulename"].ToString().Trim()}' ";
                    clsDB.Execute(strSQL);
                    I = I + 1;
                }

                K = I;
                J = 4;
                strSQL = $@"select na67_id,
                               pas_username,
                               pas_name,
                               pas_quote,
                               mod_menu,
                               mod_modulename,
                               mod_flag,
                               dbo.Readpwd(pas_password) 'pass'
                        from   mod
                               left join pas
                                      on pas_username = mod_username collate Chinese_Taiwan_Stroke_CI_AS
                               left join na67
                                      on na67_orderid = mod_modulename collate
                                                        Chinese_Taiwan_Stroke_CI_AS
                                         and na67_computername = Host_name()
                        where  mod_username <> 'yzf'
                        order  by mod_username,
                                  na67_id ";
                dt = clsDB.sql_select_dt(strSQL);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    range = (Excel.Range)workSheet.Cells[2, J]; //讀取位置[2, J]
                                                                //if (workSheet.Cells[2, J].ToString()!= "" && workSheet.Rows[2, J].ToString().Trim() != dt.Rows[i]["pas_username"].ToString().Trim())
                    if (range.Text.ToString() != "" && range.Text.ToString() != dt.Rows[i]["pas_username"].ToString().Trim())
                    {
                        J = J + 1;
                    }
                    if (blnPassprn == true)
                    {
                        range = (Excel.Range)workSheet.Cells[1, J];
                        if (range.Text.ToString() == "")
                        {
                            workSheet.Cells[1, J] = (J - 1).ToString().Trim();
                        }
                        range = (Excel.Range)workSheet.Cells[4, J];
                        if (range.Text.ToString() == "")
                        {
                            workSheet.Cells[4, J] = dt.Rows[i]["pas_name"].ToString().Trim();
                        }
                        range = (Excel.Range)workSheet.Cells[2, J];
                        if (range.Text.ToString() == "")
                        {
                            workSheet.Cells[2, J] = dt.Rows[i]["pas_username"].ToString().Trim();
                        }
                        range = (Excel.Range)workSheet.Cells[5, J];
                        if (range.Text.ToString() == "")
                        {
                            workSheet.Cells[5, J] = dt.Rows[i]["pas_quote"].ToString().Trim();
                        }
                        range = (Excel.Range)workSheet.Cells[3, J];
                        if (range.Text.ToString() == "")
                        {
                            if (blnPassprn == true)
                            {
                                workSheet.Cells[3, J] = dt.Rows[i]["pass"].ToString().Trim();
                            }
                            else
                            {
                                workSheet.Cells[3, J] = "*****";
                            }
                        }
                        if (dt.Rows[i]["mod_flag"].ToString() == "1")
                        {
                            workSheet.Cells[Int32.Parse(dt.Rows[i]["na67_id"].ToString()) + 5, J] = "V";
                        }
                        else
                        {
                            workSheet.Cells[Int32.Parse(dt.Rows[i]["na67_id"].ToString()) + 5, J] = "";
                        }
                    }
                    else
                    {
                        range = (Excel.Range)workSheet.Cells[1, J];
                        if (range.Text.ToString() == "")
                        {
                            workSheet.Cells[1, J] = (J - 1).ToString().Trim();
                        }
                        range = (Excel.Range)workSheet.Cells[3, J];
                        if (range.Text.ToString() == "")
                        {
                            workSheet.Cells[3, J] = dt.Rows[i]["pas_name"].ToString().Trim();
                        }
                        range = (Excel.Range)workSheet.Cells[2, J];
                        if (range.Text.ToString() == "")
                        {
                            workSheet.Cells[2, J] = dt.Rows[i]["pas_username"].ToString().Trim();
                        }
                        range = (Excel.Range)workSheet.Cells[4, J];
                        if (range.Text.ToString() == "")
                        {
                            workSheet.Cells[4, J] = dt.Rows[i]["pas_quote"].ToString().Trim();
                        }

                        if (dt.Rows[i]["mod_flag"].ToString() == "1")
                        {
                            workSheet.Cells[Int32.Parse(dt.Rows[i]["na67_id"].ToString()) + 5, J] = "V";
                        }
                        else
                        {
                            workSheet.Cells[Int32.Parse(dt.Rows[i]["na67_id"].ToString()) + 5, J] = "";
                        }
                    }
                }

                workSheet.Columns.EntireColumn.AutoFit();   //自動調整欄寬

                if (blnPassprn == true)
                {
                    //workSheet.Range["D6"].Select();
                    workSheet.Application.ActiveWindow.SplitRow = 5;
                    workSheet.Application.ActiveWindow.SplitColumn = 3;
                }
                else
                {
                    //workSheet.Range["D5"].Select();
                    workSheet.Application.ActiveWindow.SplitRow = 4;
                    workSheet.Application.ActiveWindow.SplitColumn = 3;
                }

                //excelApp.ActiveWindow.FreezePanes = true;
                workSheet.Application.ActiveWindow.FreezePanes = true;
                workSheet.Range["1:" + K.ToString()].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                if (blnPassprn == true)
                {
                    workSheet.Range["B6:C" + K.ToString()].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                }
                else
                {
                    workSheet.Range["B5:C" + K.ToString()].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                }
                string temp;
                //檢查資料夾；沒有就新增一個
                if (Directory.Exists(@"C:\\temp"))
                {
                    //資料夾存在
                }
                else
                {
                    //新增資料夾
                    Directory.CreateDirectory(@"C:\temp\");
                }
                if (Convert.ToDouble(excelApp.Version.ToString()) > 11)
                {
                    temp = "C:\\temp\\使用者權限清單" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                }
                else
                {
                    temp = "C:\\temp\\使用者權限清單" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                }

                workBook.SaveCopyAs(temp);


                //把執行的Excel資源釋放
                workBook.Close(false, Missing.Value, Missing.Value);
                excelApp.Quit();
                workSheet = null;
                workBook = null;
                excelApp = null;
                GC.Collect(); //強制回收
                //執行程式
                System.Diagnostics.Process.Start(temp);
                MessageBox.Show("查詢結果存放在:" + temp, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;//滑鼠還原預設
                lblTime.Visible = false;

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                lblTime.Visible = false;

                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
