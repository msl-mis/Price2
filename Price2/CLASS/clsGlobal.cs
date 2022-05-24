using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Price2
{
    public class clsGlobal
    {
        public static string strG_User;     //記錄登入使用者名稱
        public static string strG_Ywcode;   //記錄登入使用者的業務代碼
        public static string strG_Area;     //紀錄正式區或測試區
        public static string strG_LocalIP;  //紀錄LocalIP

        public void export_csv(DataGridView DG)
        {

        }
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
        public static bool ValidateString(String _value, int _kind)
        {
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
    }
}
