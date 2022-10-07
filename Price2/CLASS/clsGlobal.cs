using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Price2
{
    public class clsGlobal
    {
        public static string strG_User;     //記錄登入使用者名稱
        public static string strG_Ywcode;   //記錄登入使用者的業務代碼
        public static string strG_Area;     //紀錄正式區或測試區
        public static string strG_LocalIP;  //紀錄LocalIP


        public static bool checkRightFlag(string strModuleName) //確認權限
        {
            String strSQL = $@"select mod_flag from mod where mod_username='{clsGlobal.strG_User}' and mod_modulename='{strModuleName}'";
            string rs= clsDB.sql_select_String(strSQL, "mod_flag");
            if (rs == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static bool ValidateString(String _value, int _kind) // 判斷輸入的字串類型
        {
            #region 說明
            /// 判斷輸入的字串類型。　
            ///

            /// 輸入的字串。(string)
            /// 要驗証的類型，可選擇之類型如下列表。(int)
            ///
            ///  1: 由26個英文字母組成的字串
            ///  2: 正整數
            ///  3: 非負整數（正整數 + 0)
            ///  4: 非正整數（負整數 + 0）
            ///  5: 負整數
            ///  6: 整數
            ///  7: 非負浮點數（正浮點數 + 0）
            ///  8: 正浮點數
            ///  9: 非正浮點數（負浮點數 + 0)
            /// 10: 負浮點數
            /// 11: 浮點數
            /// 12: 由26個英文字母的大寫組成的字串
            /// 13: 由26個英文字母的小寫組成的字串
            /// 14: 由數位和26個英文字母組成的字串
            /// 15: 由數位、26個英文字母或者下劃線組成的字串
            /// 16: Email
            /// 17: URL
            /// 18: 只能輸入入中文
            /// 19: 只能輸入0和非0打頭的數字
            /// 20: 只能輸入數字
            /// 21: 只能輸入數字加2位小數
            /// 22: 只能輸入0和非0打頭的數字加2位小數
            /// 23: 只能輸入0和非0打頭的數字加2位小數，但不匹配0.00
            /// 24: "^[0-9]+(.[0-9]{1,3})?$"   該實數只能帶3位小數

            /// 26: 驗證日期:YYYYMM

            /// 27: 驗證日期: YYYYMMDD
            /// 28: 驗證日期:YYYY/MM/DD
            /// 29:
            /// 驗証通過則傳回 True，反之則為 False。 
            #endregion

            string RegularExpressions = null;

            switch (_kind)
            {
                case 1:
                    //由26個英文字母組成的字串
                    RegularExpressions = "^[A-Za-z]+$";
                    break;
                case 2:
                    //正整數
                    RegularExpressions = "^[0-9]*[1-9][0-9]*$";
                    break;
                case 3:
                    //非負整數（正整數 + 0)
                    RegularExpressions = "^\\d+$";
                    break;
                case 4:
                    //非正整數（負整數 + 0）
                    RegularExpressions = "^((-\\d+)|(0+))$";
                    break;
                case 5:
                    //負整數
                    RegularExpressions = "^-[0-9]*[1-9][0-9]*$";
                    break;
                case 6:
                    //整數
                    RegularExpressions = "^-?\\d+$";
                    break;
                case 7:
                    //非負浮點數（正浮點數 + 0）
                    RegularExpressions = "^\\d+(\\.\\d+)?$";
                    break;
                case 8:
                    //正浮點數
                    RegularExpressions = "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
                    break;
                case 9:
                    //非正浮點數（負浮點數 + 0）
                    RegularExpressions = "^((-\\d+(\\.\\d+)?)|(0+(\\.0+)?))$";
                    break;
                case 10:
                    //負浮點數
                    RegularExpressions = "^(-(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";
                    break;
                case 11:
                    //浮點數
                    RegularExpressions = "^(-?\\d+)(\\.\\d+)?$";
                    break;
                case 12:
                    //由26個英文字母的大寫組成的字串
                    RegularExpressions = "^[A-Z]+$";
                    break;
                case 13:
                    //由26個英文字母的小寫組成的字串
                    RegularExpressions = "^[a-z]+$";
                    break;
                case 14:
                    //由數位和26個英文字母組成的字串
                    RegularExpressions = "^[A-Za-z0-9]+$";
                    break;
                case 15:
                    //由數位、26個英文字母或者下劃線組成的字串
                    RegularExpressions = "^[0-9a-zA-Z_]+$";
                    break;
                case 16:
                    //email地址
                    RegularExpressions = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                    break;
                case 17:
                    //url
                    RegularExpressions = "^[a-zA-z]+://(\\w+(-\\w+)*)(\\.(\\w+(-\\w+)*))*(\\?\\S*)?$";
                    break;
                case 18:
                    //只能輸入中文
                    RegularExpressions = "^[^\u4E00-\u9FA5]";
                    break;
                case 19:
                    //只能輸入0和非0打頭的數字
                    RegularExpressions = "^(0|[1-9][0-9]*)$";
                    break;
                case 20:
                    //只能輸入數字
                    RegularExpressions = "^[0-9]*$";
                    break;
                case 21:
                    //只能輸入數字加2位小數
                    RegularExpressions = "^[0-9]+(.[0-9]{1,2})?$";
                    break;
                case 22:
                    //只能輸入0和非0打頭的數字加2位小數
                    RegularExpressions = "^(0|[1-9]+)(.[0-9]{1,2})?$";
                    break;
                case 23:
                    //只能輸入0和非0打頭的數字加2位小數，但不匹配0.00
                    RegularExpressions = "^(0(.(0[1-9]|[1-9][0-9]))?|[1-9]+(.[0-9]{1,2})?)$";
                    break;
                case 24:
                    //驗證日期格式 YYYYMMDD, 範圍19000101~20991231
                    RegularExpressions = "(19|20)\\d\\d+(0[1-9]|1[012])+(0[1-9]|[12][0-9]|3[01])$";
                    break;
                case 25:
                    //驗證日期格式 MMDDYYYY
                    RegularExpressions = "(0[1-9]|1[012])+(0[1-9]|[12][0-9]|3[01])+(19|20)\\d\\d$";
                    break;
                case 26:
                    //驗證日期格式 YYYYMM
                    RegularExpressions = "(19|20)\\d\\d+(0[1-9]|1[012])$";
                    break;
                case 27:
                    //驗證日期格式 YYYYMMDD, 範圍00010101~99991231
                    RegularExpressions = "(^0000|0001|9999|[0-9]{4})+(0[1-9]|1[0-2])+(0[1-9]|[12][0-9]|3[01])$";
                    break;
                default:
                    break;
            }

            Match m = Regex.Match(_value, RegularExpressions);

            if (m.Success)
                return true;
            else
                return false;
        }
        public static void ExportCsv(DataGridView DG)
        {
            //export EXcel=new excel 
            if (DG.Rows.Count > 200000)
            {
                MessageBox.Show("資料超過20萬筆會出現超過記憶體限制錯誤，請查詢小於20萬筆的資料！！", "系統警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FileStream output = default(FileStream);
            StreamWriter writer = default(StreamWriter);
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Excel Files(*.csv)|*.csv";
            file.Title = "儲存CSV檔(Excel)";
            DialogResult result = file.ShowDialog();
            string filename = null;
            string FileText = null;
            int i = 0;
            int j = 0;

            if (!DG.Rows.Count.Equals(0))
            {
                file.CheckFileExists = false;
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                filename = file.FileName;
                if ((string.IsNullOrEmpty(filename) || filename == null))
                {
                    MessageBox.Show("錯誤名稱檔案!!", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        output = new FileStream(filename, FileMode.Create, FileAccess.Write);
                        writer = new StreamWriter(output, System.Text.Encoding.Unicode);
                        //DataGridView行開頭名稱
                        //FileText="";
                        //FileText= "報表查詢區間 ："+ _TimeS + " ~ " + _TimeE + "\r\n\r\n";
                        for (j = 0; j < DG.Columns.Count; j++)
                        {
                            FileText += DG.Columns[j].HeaderText.ToString() + char.ConvertFromUtf32((int)9);
                        }
                        writer.WriteLine(FileText);
                        for (i = 0; i < DG.Rows.Count; i++)
                        {
                            FileText = "";
                            for (j = 0; j < DG.Columns.Count; j++)
                            {
                                FileText += DG[j, i].Value + char.ConvertFromUtf32((int)9);
                            }
                            writer.WriteLine(FileText);
                        }
                        MessageBox.Show("Excel輸出已完畢!!", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show("檔案沒有儲存" + Environment.NewLine + ex.ToString(), "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    writer.Flush();
                    writer.Close();
                    file.Dispose();
                    System.Diagnostics.Process.Start(filename);
                }
            }
            else
            {
                MessageBox.Show("沒資料，請先查詢後再匯出資料!", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        public static void ExportExcel(string strCaption, DataGridView myDGV)
        {
            
            int ColIndex = 0;
            int RowIndex = 0;
            int ColCount = myDGV.ColumnCount;
            int RowCount = myDGV.RowCount;
            
            // 建立Excel物件
            Excel.Application excelApp = new Excel.ApplicationClass();
            //在建立excel workbook之前，檢查系統是否安裝excel
            if (excelApp == null)
            {
                // if equal null means EXCEL is not installed.
                MessageBox.Show("Excel is not properly installed!");
                return;
            }
            try
            {
                //Excel.Workbook workBook;
                //workBook = excelApp.Workbooks.Add(true);    //新建一個
                // 建立Excel工作薄
                Excel.Workbook workBook = excelApp.Workbooks.Add(true);
                Excel.Worksheet workSheet = workBook.ActiveSheet as Excel.Worksheet;    //new a worksheet
                workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);   //獲得第i個sheet，準備寫入
                //Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets[1];
                // 設定標題
                Excel.Range range = workSheet.get_Range(excelApp.Cells[1, 1], excelApp.Cells[1, ColCount]); //標題所佔的單元格數與DataGridView中的列數相同
                range.MergeCells = true;
                excelApp.ActiveCell.FormulaR1C1 = strCaption;
                excelApp.ActiveCell.Font.Size = 14;
                excelApp.ActiveCell.Font.Bold = true;
                excelApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;
                // 建立快取資料
                object[,] objData = new object[RowCount  + 1, ColCount];
                //獲取列標題
                foreach (DataGridViewColumn col in myDGV.Columns)
                {
                    objData[RowIndex, ColIndex] = col.HeaderText;
                    ColIndex++;
                }
                // 獲取資料
                for (RowIndex = 1; RowIndex <= RowCount; RowIndex++)
                {
                    for (ColIndex = 0; ColIndex < ColCount; ColIndex++)
                    {
                        if (myDGV[ColIndex, RowIndex - 1].ValueType == typeof(string)
                        || myDGV[ColIndex, RowIndex - 1].ValueType == typeof(DateTime))//這裡就是驗證DataGridView單元格中的型別,如果是string或是DataTime型別,則在放入快取時在該內容前加入" ";
                        {
                            objData[RowIndex, ColIndex] = " " + myDGV[ColIndex, RowIndex - 1].Value;
                        }
                        else
                        {
                            objData[RowIndex, ColIndex] = myDGV[ColIndex, RowIndex - 1].Value;
                        }

                    }
                    //System.Windows.Forms.Application.DoEvents();
                }
                // 寫入Excel
                range = workSheet.get_Range(excelApp.Cells[3, 1], excelApp.Cells[RowCount+3, ColCount]);
                range.Value2 = objData;

                workSheet.get_Range(excelApp.Cells[3, 1], excelApp.Cells[3+RowCount, ColCount]).Borders.LineStyle = Excel.XlLineStyle.xlContinuous; //外框

                //workSheet.Range["A3:H8"].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;   //對齊
                
                workSheet.Columns.EntireColumn.AutoFit();   //自動調整欄寬
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
                string temp;
                if (Convert.ToDouble(excelApp.Version.ToString()) > 11)
                {
                    temp = "C:\\temp\\" + strCaption + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                }
                else
                {
                    temp = "C:\\temp\\" + strCaption + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                }

                workBook.SaveCopyAs(temp);    //另存新檔
                                              //把執行的Excel資源釋放
                workBook.Close(false, Missing.Value, Missing.Value);
                excelApp.Quit();
                workSheet = null;
                workBook = null;
                excelApp = null;
                GC.Collect(); //強制回收
                System.Diagnostics.Process.Start(temp); //開啟檔案

                MessageBox.Show("查詢結果存放在:" + temp, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("clsGlobal-ExportExcel" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
