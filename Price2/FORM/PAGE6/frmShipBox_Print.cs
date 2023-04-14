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
    public partial class frmShipBox_Print : Form
    {
        public static string rstrOrderID = "";
        public frmShipBox_Print()
        {
            InitializeComponent();
        }

        private void btnOrder_Inq_Click(object sender, EventArgs e)
        {
            //查詢訂單
            try
            {
                frmOrder_Inq2 frmOrder_Inq2 = new frmOrder_Inq2();
                frmOrder_Inq2.ShowInTaskbar = false;//圖示不顯示在工作列
                frmOrder_Inq2.rstrForm = "frmShipBox_Print";
                frmOrder_Inq2.ShowDialog();
                if (rstrOrderID != "")
                {
                    txtOrderID.Text = rstrOrderID;
                }
                rstrOrderID = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnOrder_Inq_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //列印
            try
            {
                if(txtOrderID.Text=="")
                {
                    return;
                }
                string strSQL = "";
                DataTable dt = new DataTable();
                if(chkBeginNo.Checked)
                {
                    //strSQL = $@"exec cal_orderbeginxx '{txtOrderID.Text.Trim()}',{ txtBeginNo.Text} ";
                    //clsDB.Execute(strSQL);
                    if (clsGlobal.ValidateString(txtBeginNo.Text,2))
                    {
                        do_InsertTable(Convert.ToInt32(txtBeginNo.Text));
                    }
                    else
                    {
                        MessageBox.Show("請填入開始箱號", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBeginNo.Focus();
                        return;
                    }
                        
                }
                else
                {
                    //strSQL = $@"exec cal_orderxx '{txtOrderID.Text.Trim()}' ";
                    //clsDB.Execute(strSQL);
                    
                    do_InsertTable(0);
                }

                //一般訂單
                strSQL = $@"select ord_orderid,
                                   ord_customer,
                                   odh_delivedate,
                                   na31_assy,
                                   na31_pntxh
                            from   ord,
                                   odh,
                                   na31
                            where  ord_orderid = odh_orderid
                                   and odh_orderid = na31_orderid collate database_default
                                   and ord_assy = na31_assy collate database_default
                                   and ord_orderid = '{txtOrderID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "chxh";
                    frmReport.Text = "一般工單出貨箱號";
                    frmReport.strRP[0] = dt.Rows[0]["ord_orderid"].ToString();
                    frmReport.strRP[1] = dt.Rows[0]["ord_customer"].ToString();
                    frmReport.strRP[2] = dt.Rows[0]["odh_delivedate"].ToString();
                    frmReport.strSQL = strSQL;
                    //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列

                    frmReport.Show();
                }

                //外購訂單
                strSQL = $@"select ord_orderid,
                                   ord_customer,
                                   odh_delivedate,
                                   na32_assy,
                                   na32_pntxh
                            from   ord,
                                   odh,
                                   na32
                            where  ord_orderid = odh_orderid
                                   and odh_orderid = na32_orderid collate database_default
                                   and ord_assy = na32_assy collate database_default
                                   and ord_orderid = '{txtOrderID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "chxhs";
                    frmReport.Text = "外購工單出貨箱號";
                    frmReport.strRP[0] = dt.Rows[0]["ord_orderid"].ToString() + "S";
                    frmReport.strRP[1] = dt.Rows[0]["ord_customer"].ToString();
                    frmReport.strRP[2] = dt.Rows[0]["odh_delivedate"].ToString();
                    frmReport.strSQL = strSQL;
                    //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列

                    frmReport.Show();
                }

                //電源訂單
                strSQL = $@"select ord_orderid,
                                   ord_customer,
                                   odh_delivedate,
                                   na33_assy,
                                   na33_pntxh
                            from   ord,
                                   odh,
                                   na33
                            where  ord_orderid = odh_orderid
                                   and odh_orderid = na33_orderid collate database_default
                                   and ord_assy = na33_assy collate database_default
                                   and ord_orderid = '{txtOrderID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "chxhp";
                    frmReport.Text = "電源工單出貨箱號";
                    frmReport.strRP[0] = dt.Rows[0]["ord_orderid"].ToString() + "P";
                    frmReport.strRP[1] = dt.Rows[0]["ord_customer"].ToString();
                    frmReport.strRP[2] = dt.Rows[0]["odh_delivedate"].ToString();
                    frmReport.strSQL = strSQL;
                    //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列

                    frmReport.Show();
                }

                //光纖訂單
                strSQL = $@"select ord_orderid,
                                   ord_customer,
                                   odh_delivedate,
                                   na34_assy,
                                   na34_pntxh
                            from   ord,
                                   odh,
                                   na34
                            where  ord_orderid = odh_orderid
                                   and odh_orderid = na34_orderid collate database_default
                                   and ord_assy = na34_assy collate database_default
                                   and ord_orderid = '{txtOrderID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "chxhf";
                    frmReport.Text = "光纖工單出貨箱號";
                    frmReport.strRP[0] = dt.Rows[0]["ord_orderid"].ToString() + "FO";
                    frmReport.strRP[1] = dt.Rows[0]["ord_customer"].ToString();
                    frmReport.strRP[2] = dt.Rows[0]["odh_delivedate"].ToString();
                    frmReport.strSQL = strSQL;
                    //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列

                    frmReport.Show();
                }

                //成朋訂單
                strSQL = $@"select ord_orderid,
                                   ord_customer,
                                   odh_delivedate,
                                   na35_assy,
                                   na35_pntxh
                            from   ord,
                                   odh,
                                   na35
                            where  ord_orderid = odh_orderid
                                   and odh_orderid = na35_orderid collate database_default
                                   and ord_assy = na35_assy collate database_default
                                   and ord_orderid = '{txtOrderID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "chxhgp";
                    frmReport.Text = "成朋工單出貨箱號";
                    frmReport.strRP[0] = dt.Rows[0]["ord_orderid"].ToString() + "W";
                    frmReport.strRP[1] = dt.Rows[0]["ord_customer"].ToString();
                    frmReport.strRP[2] = dt.Rows[0]["odh_delivedate"].ToString();
                    frmReport.strSQL = strSQL;
                    //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列

                    frmReport.Show();
                }

                //晶元訂單
                strSQL = $@"select ord_orderid,
                                   ord_customer,
                                   odh_delivedate,
                                   na36_assy,
                                   na36_pntxh
                            from   ord,
                                   odh,
                                   na36
                            where  ord_orderid = odh_orderid
                                   and odh_orderid = na36_orderid collate database_default
                                   and ord_assy = na36_assy collate database_default
                                   and ord_orderid = '{txtOrderID.Text.Trim()}' ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    frmReport frmReport = new frmReport();
                    //傳入參數
                    frmReport.strReportName = "chxhgc";
                    frmReport.Text = "晶元工單出貨箱號";
                    frmReport.strRP[0] = dt.Rows[0]["ord_orderid"].ToString() + "H";
                    frmReport.strRP[1] = dt.Rows[0]["ord_customer"].ToString();
                    frmReport.strRP[2] = dt.Rows[0]["odh_delivedate"].ToString();
                    frmReport.strSQL = strSQL;
                    //frmReport.ShowInTaskbar = false;//圖示不顯示在工作列

                    frmReport.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void do_InsertTable(int iNo)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            //一般訂單
            strSQL = $@"truncate table na31 ";
            clsDB.Execute(strSQL);

            strSQL = $@"select distinct ord_assy,
                                        ord_beginxx,
                                        ord_endxx,
                                        ord_xs
                        from   odh,
                               ord,
                               odi,
                               odt,
                               pri_fenleichk
                        where  odh_orderid = ord_orderid
                               and ord_assy = odi_customerid
                               and pri_customerid = ord_assy
                               and odh_orderid = odt_orderid
                               and odh_orderid = '{txtOrderID.Text.Trim()}'
                               and ord_wg = 0
                               and odi_gp = 0
                               and odi_gc = 0
                               and pri_fenlei <> '14 Fiber Cable'
                        order  by ord.ord_beginxx ";
            dt = clsDB.sql_select_dt(strSQL);
            if(dt.Rows.Count>0)
            {
                for(int i =0; i<dt.Rows.Count; i++)
                {
                    for (int j = Convert.ToInt32(dt.Rows[i]["ord_beginxx"]) + iNo; j <= Convert.ToInt32(dt.Rows[i]["ord_endxx"]) + iNo; j++)
                    {
                        strSQL = $@"insert into na31
                                                (na31_orderid,
                                                 na31_assy,
                                                 na31_pntxh)
                                    values     ('{txtOrderID.Text.Trim()}',
                                                '{dt.Rows[i]["ord_assy"].ToString()}',
                                                '{j.ToString("00000")}') ";
                        clsDB.Execute(strSQL);
                    }
                }
            }

            //外購訂單
            strSQL = $@"truncate table na32 ";
            clsDB.Execute(strSQL);

            strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and ord_wg = 1
                                       and odi_gp = 0
                                       and odi_gc = 0
                                       and pri_fenlei <> '14 Fiber Cable'
                                order  by ord.ord_beginxx ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = Convert.ToInt32(dt.Rows[i]["ord_beginxx"]) + iNo; j <= Convert.ToInt32(dt.Rows[i]["ord_endxx"]) + iNo; j++)
                    {
                        strSQL = $@"insert into na32
                                                (na32_orderid,
                                                 na32_assy,
                                                 na32_pntxh)
                                    values     ('{txtOrderID.Text.Trim()}',
                                                '{dt.Rows[i]["ord_assy"].ToString()}',
                                                '{j.ToString("00000")}') ";
                        clsDB.Execute(strSQL);
                    }
                }
            }

            //電源訂單
            strSQL = $@"truncate table na33 ";
            clsDB.Execute(strSQL);

            strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and ord_wg = 2
                                       and odi_gp = 0
                                       and odi_gc = 0
                                       and pri_fenlei <> '14 Fiber Cable' 
                                order  by ord.ord_beginxx ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = Convert.ToInt32(dt.Rows[i]["ord_beginxx"]) + iNo; j <= Convert.ToInt32(dt.Rows[i]["ord_endxx"]) + iNo; j++)
                    {
                        strSQL = $@"insert into na33
                                                (na33_orderid,
                                                 na33_assy,
                                                 na33_pntxh)
                                    values     ('{txtOrderID.Text.Trim()}',
                                                '{dt.Rows[i]["ord_assy"].ToString()}',
                                                '{j.ToString("00000")}') ";
                        clsDB.Execute(strSQL);
                    }
                }
            }

            //光纖訂單
            strSQL = $@"truncate table na34 ";
            clsDB.Execute(strSQL);

            strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and pri_fenlei = '14 Fiber Cable' 
                                order  by ord.ord_beginxx ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = Convert.ToInt32(dt.Rows[i]["ord_beginxx"]) + iNo; j <= Convert.ToInt32(dt.Rows[i]["ord_endxx"]) + iNo; j++)
                    {
                        strSQL = $@"insert into na34
                                                (na34_orderid,
                                                 na34_assy,
                                                 na34_pntxh)
                                    values     ('{txtOrderID.Text.Trim()}',
                                                '{dt.Rows[i]["ord_assy"].ToString()}',
                                                '{j.ToString("00000")}') ";
                        clsDB.Execute(strSQL);
                    }
                }
            }

            //成朋訂單
            strSQL = $@"truncate table na35 ";
            clsDB.Execute(strSQL);

            strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and odi_gp = 1
                                       and pri_fenlei <> '14 Fiber Cable'
                                order  by ord.ord_beginxx ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = Convert.ToInt32(dt.Rows[i]["ord_beginxx"]) + iNo; j <= Convert.ToInt32(dt.Rows[i]["ord_endxx"]) + iNo; j++)
                    {
                        strSQL = $@"insert into na35
                                                (na35_orderid,
                                                 na35_assy,
                                                 na35_pntxh)
                                    values     ('{txtOrderID.Text.Trim()}',
                                                '{dt.Rows[i]["ord_assy"].ToString()}',
                                                '{j.ToString("00000")}') ";
                        clsDB.Execute(strSQL);
                    }
                }
            }

            //晶元訂單
            strSQL = $@"truncate table na36 ";
            clsDB.Execute(strSQL);

            strSQL = $@"select distinct *
                                from   odh,
                                       ord,
                                       odi,
                                       odt,
                                       pri_fenleichk
                                where  odh_orderid = ord_orderid
                                       and ord_assy = odi_customerid
                                       and pri_customerid = ord_assy
                                       and odh_orderid = odt_orderid
                                       and odh_orderid = '{txtOrderID.Text.Trim()}'
                                       and odi_gc = 1
                                       and pri_fenlei <> '14 Fiber Cable' 
                                order  by ord.ord_beginxx ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = Convert.ToInt32(dt.Rows[i]["ord_beginxx"]) + iNo; j <= Convert.ToInt32(dt.Rows[i]["ord_endxx"]) + iNo; j++)
                    {
                        strSQL = $@"insert into na36
                                                (na36_orderid,
                                                 na36_assy,
                                                 na36_pntxh)
                                    values     ('{txtOrderID.Text.Trim()}',
                                                '{dt.Rows[i]["ord_assy"].ToString()}',
                                                '{j.ToString("00000")}') ";
                        clsDB.Execute(strSQL);
                    }
                }
            }
        }

        private void frmShipBox_Print_Load(object sender, EventArgs e)
        {
            txtOrderID.Focus();
        }

        private void frmShipBox_Print_Activated(object sender, EventArgs e)
        {
            txtOrderID.Focus();
        }

        private void txtOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnPrint.Focus();
            }
        }
    }
}
