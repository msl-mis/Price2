using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price2
{
    class clsDB
    {
        //public static string _ServerName = "";
        //public static string _DB_id = "";
        //public static string _DB_password = "";
        //public static string _DB_name = "";

        //public static string _sql_serverName = "192.168.10.122";
        //public static string _sql_dbid = "sa";
        //public static string _sql_dbPw = "yzf";
        //public static string _sql_dbName = "Test";
        
        public static string _ServerName ;
        public static string _DB_id ;
        public static string _DB_password ;
        public static string _DB_name ;

        public static SqlConnection _sql_con = new SqlConnection();
        public static SqlTransaction _Transation=null;

        public static void Open()
        {
            //_ServerName= _sql_serverName ;
            //_DB_id = _sql_dbid;
            //_DB_password= _sql_dbPw ;
            //_DB_name = _sql_dbName;
            //string connStr = "Server=" + _ServerName + ";database=" + _DB_name + ";uid=" + _DB_id + ";pwd=" + _DB_password + ";";
            string connStr = "Data Source = " + _ServerName + "; Initial Catalog = " + _DB_name + "; Persist Security Info = false; User ID = " + _DB_id + "; Password = " + _DB_password + "; ";
            _sql_con = new SqlConnection(connStr);
            _sql_con.Open();
        }

        public static string sql_select_String(string _commend,string _row)
        {
            if (_sql_con.State == ConnectionState.Closed)
            {
                Open();
            }
            string re_string = "";
            SqlCommand cmd = new SqlCommand(_commend,_sql_con);
            SqlDataAdapter da=new SqlDataAdapter(cmd);  
            DataSet ds=new DataSet();
            da.Fill(ds);    
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                re_string = row[_row].ToString();
            }
            Close();
            return re_string;
            
        }

        public static ArrayList sql_select_ls(string _commend)
        {
            if(_sql_con.State==ConnectionState.Closed)
            {
                Open();
            }
            ArrayList ls= new ArrayList();
            SqlCommand cmd = new SqlCommand(_commend,_sql_con);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                ls.Add(dr);
            }
            Close();
            return ls;
        }

        public static DataTable sql_select_dt(string _commend)
        {
            if (_sql_con.State == ConnectionState.Closed)
            {
                Open();
            }
            SqlCommand cmd = new SqlCommand(_commend,_sql_con,_Transation);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Close();
            return dt;
        }

        public static void Execute(string _sqlcommand)
        {
            if(_sql_con.State == ConnectionState.Closed)
            {
                Open();
            }
            SqlCommand MSSqlCmd= new SqlCommand(_sqlcommand,_sql_con,_Transation);
            MSSqlCmd.ExecuteNonQuery();
            Close();
        }

        public static void ExecuteNoClose(string _sqlcommand)
        {
            if (_sql_con.State == ConnectionState.Closed)
            {
                Open();
            }
            SqlCommand MSSqlCmd = new SqlCommand(_sqlcommand, _sql_con, _Transation);
            MSSqlCmd.ExecuteNonQuery();
            //Close();
        }

        public static void Close()
        {
            if (_sql_con.State == ConnectionState.Open)
            {
                _sql_con.Close();
                _sql_con.Dispose();
            }
            //_ServerName = "";
            //_DB_id = "";
            //_DB_password = "";
            //_DB_name = "";
        }

    }
}
