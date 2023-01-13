using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Price2
{
    public partial class frmReport : Form
    {
        public static string[] strRP = new string[10];
        public static double[] dblRP = new double[10];
        public static string strSQL;
        public static string strReportName;
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            btnClose.Left = 500;
            DataTable dt = new DataTable();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer1.LocalReport;
            switch (strReportName)
            {
                case "bomlist":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.bomlist.rdlc";
                    //載入參數
                    ReportParameter var1 = new ReportParameter("rpLevel1", strRP[0]);
                    ReportParameter var2 = new ReportParameter("rpLevel2", strRP[1]);
                    ReportParameter var3 = new ReportParameter("rpLevel3", strRP[2]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { var1, var2, var3 });
                    break;
                case "proofing":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.proofing.rdlc";
                    //載入參數
                    ReportParameter proofing1 = new ReportParameter("Proofing", strRP[0]);
                    ReportParameter proofing2 = new ReportParameter("Customer", strRP[1]);
                    ReportParameter proofing3 = new ReportParameter("Sales", strRP[2]);
                    ReportParameter proofing4 = new ReportParameter("DeliveryDate", strRP[3]);
                    ReportParameter proofing5 = new ReportParameter("tempbz", strRP[4]);
                    ReportParameter proofing6 = new ReportParameter("bz", strRP[5]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { proofing1, proofing2, proofing3, proofing4, proofing5, proofing6 });
                    break;
                default:
                    break;
            }
            dt = clsDB.sql_select_dt(strSQL);
            reportViewer1.LocalReport.DataSources.Clear();
            //載入資料集
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);


            ////直接輸出EXCEL
            //Warning[] Warnings;
            //string[] strStreamIds;
            //string strMimeType;
            //string strEncoding;
            //string strFileNameExtension;

            //byte[] bytes = this.reportViewer1.LocalReport.Render("Excel", null, out strMimeType, out strEncoding, out strFileNameExtension, out strStreamIds, out Warnings);

            //string strFilePath = @"D:/report.xls";

            //using (System.IO.FileStream fs = new FileStream(strFilePath, FileMode.Create))
            //{
            //    fs.Write(bytes, 0, bytes.Length);
            //}

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
