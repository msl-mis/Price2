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
        public static string[] strRP = new string[20];
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
                    localReport.ReportEmbeddedResource = "Price2.RDLC.bomlist.rdlc";
                    //載入參數
                    ReportParameter var1 = new ReportParameter("rpLevel1", strRP[0]);
                    ReportParameter var2 = new ReportParameter("rpLevel2", strRP[1]);
                    ReportParameter var3 = new ReportParameter("rpLevel3", strRP[2]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { var1, var2, var3 });
                    break;
                case "proofing":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.proofing.rdlc";
                    //載入參數
                    ReportParameter proofing1 = new ReportParameter("Proofing", strRP[0]);
                    ReportParameter proofing2 = new ReportParameter("Customer", strRP[1]);
                    ReportParameter proofing3 = new ReportParameter("Sales", strRP[2]);
                    ReportParameter proofing4 = new ReportParameter("DeliveryDate", strRP[3]);
                    ReportParameter proofing5 = new ReportParameter("tempbz", strRP[4]);
                    ReportParameter proofing6 = new ReportParameter("bz", strRP[5]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { proofing1, proofing2, proofing3, proofing4, proofing5, proofing6 });
                    break;
                case "quotation":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.quotation.rdlc";
                    //載入參數
                    ReportParameter quotation1 = new ReportParameter("name", strRP[0]);
                    ReportParameter quotation2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter quotation3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter quotation4 = new ReportParameter("tempinbz", strRP[3]);
                    ReportParameter quotation5 = new ReportParameter("tempoutbz", strRP[4]);
                    ReportParameter quotation6 = new ReportParameter("bz", strRP[5]);
                    ReportParameter quotation7 = new ReportParameter("sign", strRP[6]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { quotation1, quotation2, quotation3, quotation4, quotation5, quotation6, quotation7 });
                    break;
                case "pinvoicecbi":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.pinvoicecbi.rdlc";
                    //載入參數
                    ReportParameter pinvoicecbi1 = new ReportParameter("name", strRP[0]);
                    ReportParameter pinvoicecbi2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter pinvoicecbi3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter pinvoicecbi4 = new ReportParameter("fkfs", strRP[3]);
                    ReportParameter pinvoicecbi5 = new ReportParameter("tempoutbz", strRP[4]);
                    ReportParameter pinvoicecbi6 = new ReportParameter("bz", strRP[5]);
                    ReportParameter pinvoicecbi7 = new ReportParameter("sign", strRP[6]);
                    ReportParameter pinvoicecbi8 = new ReportParameter("po", strRP[7]);
                    ReportParameter pinvoicecbi9 = new ReportParameter("payflag", strRP[8]);
                    ReportParameter pinvoicecbi10 = new ReportParameter("oop_assy", strRP[9]);
                    ReportParameter pinvoicecbi11 = new ReportParameter("oop_currency", strRP[10]);
                    ReportParameter pinvoicecbi12 = new ReportParameter("oop_cost", strRP[11]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pinvoicecbi1, pinvoicecbi2, pinvoicecbi3, pinvoicecbi4, pinvoicecbi5, pinvoicecbi6, pinvoicecbi7, pinvoicecbi8, pinvoicecbi9, pinvoicecbi10, pinvoicecbi11, pinvoicecbi12 });
                    break;
                case "pinvoicecb":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.pinvoicecb.rdlc";
                    //載入參數
                    ReportParameter pinvoicecb1 = new ReportParameter("name", strRP[0]);
                    ReportParameter pinvoicecb2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter pinvoicecb3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter pinvoicecb4 = new ReportParameter("fkfs", strRP[3]);
                    ReportParameter pinvoicecb5 = new ReportParameter("tempoutbz", strRP[4]);
                    ReportParameter pinvoicecb6 = new ReportParameter("bz", strRP[5]);
                    ReportParameter pinvoicecb7 = new ReportParameter("sign", strRP[6]);
                    ReportParameter pinvoicecb8 = new ReportParameter("po", strRP[7]);
                    ReportParameter pinvoicecb9 = new ReportParameter("payflag", strRP[8]);
                    ReportParameter pinvoicecb10 = new ReportParameter("oop_assy", strRP[9]);
                    ReportParameter pinvoicecb11 = new ReportParameter("oop_currency", strRP[10]);
                    ReportParameter pinvoicecb12 = new ReportParameter("oop_cost", strRP[11]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pinvoicecb1, pinvoicecb2, pinvoicecb3, pinvoicecb4, pinvoicecb5, pinvoicecb6, pinvoicecb7, pinvoicecb8, pinvoicecb9, pinvoicecb10, pinvoicecb11, pinvoicecb12 });
                    break;
                case "pincnymsl":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.pincnymsl.rdlc";
                    //載入參數
                    ReportParameter pincnymsl1 = new ReportParameter("name", strRP[0]);
                    ReportParameter pincnymsl2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter pincnymsl3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter pincnymsl4 = new ReportParameter("fkfs", strRP[3]);
                    ReportParameter pincnymsl5 = new ReportParameter("tempoutbz", strRP[4]);
                    ReportParameter pincnymsl6 = new ReportParameter("bz", strRP[5]);
                    ReportParameter pincnymsl7 = new ReportParameter("sign", strRP[6]);
                    ReportParameter pincnymsl8 = new ReportParameter("po", strRP[7]);
                    ReportParameter pincnymsl9 = new ReportParameter("payflag", strRP[8]);
                    ReportParameter pincnymsl10 = new ReportParameter("oop_assy", strRP[9]);
                    ReportParameter pincnymsl11 = new ReportParameter("oop_currency", strRP[10]);
                    ReportParameter pincnymsl12 = new ReportParameter("oop_cost", strRP[11]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pincnymsl1, pincnymsl2, pincnymsl3, pincnymsl4, pincnymsl5, pincnymsl6, pincnymsl7, pincnymsl8, pincnymsl9, pincnymsl10, pincnymsl11, pincnymsl12 });
                    break;
                case "pinvoicei":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.pinvoicei.rdlc";
                    //載入參數
                    ReportParameter pinvoicei1 = new ReportParameter("name", strRP[0]);
                    ReportParameter pinvoicei2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter pinvoicei3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter pinvoicei4 = new ReportParameter("fkfs", strRP[3]);
                    ReportParameter pinvoicei5 = new ReportParameter("tempoutbz", strRP[4]);
                    ReportParameter pinvoicei6 = new ReportParameter("bz", strRP[5]);
                    ReportParameter pinvoicei7 = new ReportParameter("sign", strRP[6]);
                    ReportParameter pinvoicei8 = new ReportParameter("po", strRP[7]);
                    ReportParameter pinvoicei9 = new ReportParameter("payflag", strRP[8]);
                    ReportParameter pinvoicei10 = new ReportParameter("oop_assy", strRP[9]);
                    ReportParameter pinvoicei11 = new ReportParameter("oop_currency", strRP[10]);
                    ReportParameter pinvoicei12 = new ReportParameter("oop_cost", strRP[11]);
                    ReportParameter pinvoicei13 = new ReportParameter("approval", strRP[12]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pinvoicei1, pinvoicei2, pinvoicei3, pinvoicei4, pinvoicei5, pinvoicei6, pinvoicei7, pinvoicei8, pinvoicei9, pinvoicei10, pinvoicei11, pinvoicei12, pinvoicei13 });
                    break;
                case "pinvoice":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.pinvoice.rdlc";
                    //載入參數
                    ReportParameter pinvoice1 = new ReportParameter("name", strRP[0]);
                    ReportParameter pinvoice2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter pinvoice3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter pinvoice4 = new ReportParameter("fkfs", strRP[3]);
                    ReportParameter pinvoice5 = new ReportParameter("tempoutbz", strRP[4]);
                    ReportParameter pinvoice6 = new ReportParameter("bz", strRP[5]);
                    ReportParameter pinvoice7 = new ReportParameter("sign", strRP[6]);
                    ReportParameter pinvoice8 = new ReportParameter("po", strRP[7]);
                    ReportParameter pinvoice9 = new ReportParameter("payflag", strRP[8]);
                    ReportParameter pinvoice10 = new ReportParameter("oop_assy", strRP[9]);
                    ReportParameter pinvoice11 = new ReportParameter("oop_currency", strRP[10]);
                    ReportParameter pinvoice12 = new ReportParameter("oop_cost", strRP[11]);
                    ReportParameter pinvoice13 = new ReportParameter("approval", strRP[12]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pinvoice1, pinvoice2, pinvoice3, pinvoice4, pinvoice5, pinvoice6, pinvoice7, pinvoice8, pinvoice9, pinvoice10, pinvoice11, pinvoice12, pinvoice13 });
                    break;
                case "piotheri":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.piotheri.rdlc";
                    //載入參數
                    ReportParameter piotheri1 = new ReportParameter("name", strRP[0]);
                    ReportParameter piotheri2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter piotheri3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter piotheri4 = new ReportParameter("fkfs", strRP[3]);
                    ReportParameter piotheri5 = new ReportParameter("tempoutbz", strRP[4]);
                    ReportParameter piotheri6 = new ReportParameter("bz", strRP[5]);
                    ReportParameter piotheri7 = new ReportParameter("sign", strRP[6]);
                    ReportParameter piotheri8 = new ReportParameter("po", strRP[7]);
                    ReportParameter piotheri9 = new ReportParameter("payflag", strRP[8]);
                    ReportParameter piotheri10 = new ReportParameter("oop_assy", strRP[9]);
                    ReportParameter piotheri11 = new ReportParameter("oop_currency", strRP[10]);
                    ReportParameter piotheri12 = new ReportParameter("oop_cost", strRP[11]);
                    ReportParameter piotheri13 = new ReportParameter("approval", strRP[12]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { piotheri1, piotheri2, piotheri3, piotheri4, piotheri5, piotheri6, piotheri7, piotheri8, piotheri9, piotheri10, piotheri11, piotheri12, piotheri13 });
                    break;
                case "piother":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.piother.rdlc";
                    //載入參數
                    ReportParameter piother1 = new ReportParameter("name", strRP[0]);
                    ReportParameter piother2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter piother3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter piother4 = new ReportParameter("fkfs", strRP[3]);
                    ReportParameter piother5 = new ReportParameter("tempoutbz", strRP[4]);
                    ReportParameter piother6 = new ReportParameter("bz", strRP[5]);
                    ReportParameter piother7 = new ReportParameter("sign", strRP[6]);
                    ReportParameter piother8 = new ReportParameter("po", strRP[7]);
                    ReportParameter piother9 = new ReportParameter("payflag", strRP[8]);
                    ReportParameter piother10 = new ReportParameter("oop_assy", strRP[9]);
                    ReportParameter piother11 = new ReportParameter("oop_currency", strRP[10]);
                    ReportParameter piother12 = new ReportParameter("oop_cost", strRP[11]);
                    ReportParameter piother13 = new ReportParameter("approval", strRP[12]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { piother1, piother2, piother3, piother4, piother5, piother6, piother7, piother8, piother9, piother10, piother11, piother12, piother13 });
                    break;
                case "workoda":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.workoda.rdlc";
                    //載入參數
                    ReportParameter workoda1 = new ReportParameter("customer", strRP[0]);
                    ReportParameter workoda2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter workoda3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter workoda4 = new ReportParameter("delivedate", strRP[3]);
                    ReportParameter workoda5 = new ReportParameter("tempinbz", strRP[4]);
                    ReportParameter workoda6 = new ReportParameter("inbz", strRP[5]);
                    ReportParameter workoda7 = new ReportParameter("po", strRP[6]);
                    ReportParameter workoda8 = new ReportParameter("zm1", strRP[7]);
                    ReportParameter workoda9 = new ReportParameter("zm3", strRP[8]);
                    ReportParameter workoda10 = new ReportParameter("cm", strRP[9]);
                    ReportParameter workoda11 = new ReportParameter("ywcode", strRP[10]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { workoda1, workoda2, workoda3, workoda4, workoda5, workoda6, workoda7, workoda8, workoda9, workoda10, workoda11 });
                    break;
                case "workodsa":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.workodsa.rdlc";
                    //載入參數
                    ReportParameter workodsa1 = new ReportParameter("customer", strRP[0]);
                    ReportParameter workodsa2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter workodsa3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter workodsa4 = new ReportParameter("delivedate", strRP[3]);
                    ReportParameter workodsa5 = new ReportParameter("tempinbz", strRP[4]);
                    ReportParameter workodsa6 = new ReportParameter("inbz", strRP[5]);
                    ReportParameter workodsa7 = new ReportParameter("po", strRP[6]);
                    ReportParameter workodsa8 = new ReportParameter("zm1", strRP[7]);
                    ReportParameter workodsa9 = new ReportParameter("zm3", strRP[8]);
                    ReportParameter workodsa10 = new ReportParameter("cm", strRP[9]);
                    ReportParameter workodsa11 = new ReportParameter("ywcode", strRP[10]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { workodsa1, workodsa2, workodsa3, workodsa4, workodsa5, workodsa6, workodsa7, workodsa8, workodsa9, workodsa10, workodsa11 });
                    break;
                case "workodpa":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.workodpa.rdlc";
                    //載入參數
                    ReportParameter workodpa1 = new ReportParameter("customer", strRP[0]);
                    ReportParameter workodpa2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter workodpa3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter workodpa4 = new ReportParameter("delivedate", strRP[3]);
                    ReportParameter workodpa5 = new ReportParameter("tempinbz", strRP[4]);
                    ReportParameter workodpa6 = new ReportParameter("inbz", strRP[5]);
                    ReportParameter workodpa7 = new ReportParameter("po", strRP[6]);
                    ReportParameter workodpa8 = new ReportParameter("zm1", strRP[7]);
                    ReportParameter workodpa9 = new ReportParameter("zm3", strRP[8]);
                    ReportParameter workodpa10 = new ReportParameter("cm", strRP[9]);
                    ReportParameter workodpa11 = new ReportParameter("ywcode", strRP[10]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { workodpa1, workodpa2, workodpa3, workodpa4, workodpa5, workodpa6, workodpa7, workodpa8, workodpa9, workodpa10, workodpa11 });
                    break;
                case "workodfa":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.workodfa.rdlc";
                    //載入參數
                    ReportParameter workodfa1 = new ReportParameter("customer", strRP[0]);
                    ReportParameter workodfa2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter workodfa3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter workodfa4 = new ReportParameter("delivedate", strRP[3]);
                    ReportParameter workodfa5 = new ReportParameter("tempinbz", strRP[4]);
                    ReportParameter workodfa6 = new ReportParameter("inbz", strRP[5]);
                    ReportParameter workodfa7 = new ReportParameter("po", strRP[6]);
                    ReportParameter workodfa8 = new ReportParameter("zm1", strRP[7]);
                    ReportParameter workodfa9 = new ReportParameter("zm3", strRP[8]);
                    ReportParameter workodfa10 = new ReportParameter("cm", strRP[9]);
                    ReportParameter workodfa11 = new ReportParameter("ywcode", strRP[10]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { workodfa1, workodfa2, workodfa3, workodfa4, workodfa5, workodfa6, workodfa7, workodfa8, workodfa9, workodfa10, workodfa11 });
                    break;
                case "workodgpa":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.workodgpa.rdlc";
                    //載入參數
                    ReportParameter workodgpa1 = new ReportParameter("customer", strRP[0]);
                    ReportParameter workodgpa2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter workodgpa3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter workodgpa4 = new ReportParameter("delivedate", strRP[3]);
                    ReportParameter workodgpa5 = new ReportParameter("tempinbz", strRP[4]);
                    ReportParameter workodgpa6 = new ReportParameter("inbz", strRP[5]);
                    ReportParameter workodgpa7 = new ReportParameter("po", strRP[6]);
                    ReportParameter workodgpa8 = new ReportParameter("zm1", strRP[7]);
                    ReportParameter workodgpa9 = new ReportParameter("zm3", strRP[8]);
                    ReportParameter workodgpa10 = new ReportParameter("cm", strRP[9]);
                    ReportParameter workodgpa11 = new ReportParameter("ywcode", strRP[10]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { workodgpa1, workodgpa2, workodgpa3, workodgpa4, workodgpa5, workodgpa6, workodgpa7, workodgpa8, workodgpa9, workodgpa10, workodgpa11 });
                    break;
                case "workodgca":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.workodgca.rdlc";
                    //載入參數
                    ReportParameter workodgca1 = new ReportParameter("customer", strRP[0]);
                    ReportParameter workodgca2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter workodgca3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter workodgca4 = new ReportParameter("delivedate", strRP[3]);
                    ReportParameter workodgca5 = new ReportParameter("tempinbz", strRP[4]);
                    ReportParameter workodgca6 = new ReportParameter("inbz", strRP[5]);
                    ReportParameter workodgca7 = new ReportParameter("po", strRP[6]);
                    ReportParameter workodgca8 = new ReportParameter("zm1", strRP[7]);
                    ReportParameter workodgca9 = new ReportParameter("zm3", strRP[8]);
                    ReportParameter workodgca10 = new ReportParameter("cm", strRP[9]);
                    ReportParameter workodgca11 = new ReportParameter("ywcode", strRP[10]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { workodgca1, workodgca2, workodgca3, workodgca4, workodgca5, workodgca6, workodgca7, workodgca8, workodgca9, workodgca10, workodgca11 });
                    break;
                case "workod":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.workod.rdlc";
                    //載入參數
                    ReportParameter workod1 = new ReportParameter("customer", strRP[0]);
                    ReportParameter workod2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter workod3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter workod4 = new ReportParameter("delivedate", strRP[3]);
                    ReportParameter workod5 = new ReportParameter("tempinbz", strRP[4]);
                    ReportParameter workod6 = new ReportParameter("inbz", strRP[5]);
                    ReportParameter workod7 = new ReportParameter("po", strRP[6]);
                    ReportParameter workod8 = new ReportParameter("zm1", strRP[7]);
                    ReportParameter workod9 = new ReportParameter("zm3", strRP[8]);
                    ReportParameter workod10 = new ReportParameter("cm", strRP[9]);
                    ReportParameter workod11 = new ReportParameter("ywcode", strRP[10]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { workod1, workod2, workod3, workod4, workod5, workod6, workod7, workod8, workod9, workod10, workod11 });
                    break;
                case "workods":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.workods.rdlc";
                    //載入參數
                    ReportParameter workods1 = new ReportParameter("customer", strRP[0]);
                    ReportParameter workods2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter workods3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter workods4 = new ReportParameter("delivedate", strRP[3]);
                    ReportParameter workods5 = new ReportParameter("tempinbz", strRP[4]);
                    ReportParameter workods6 = new ReportParameter("inbz", strRP[5]);
                    ReportParameter workods7 = new ReportParameter("po", strRP[6]);
                    ReportParameter workods8 = new ReportParameter("zm1", strRP[7]);
                    ReportParameter workods9 = new ReportParameter("zm3", strRP[8]);
                    ReportParameter workods10 = new ReportParameter("cm", strRP[9]);
                    ReportParameter workods11 = new ReportParameter("ywcode", strRP[10]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { workods1, workods2, workods3, workods4, workods5, workods6, workods7, workods8, workods9, workods10, workods11 });
                    break;
                case "workodp":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.workodp.rdlc";
                    //載入參數
                    ReportParameter workodp1 = new ReportParameter("customer", strRP[0]);
                    ReportParameter workodp2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter workodp3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter workodp4 = new ReportParameter("delivedate", strRP[3]);
                    ReportParameter workodp5 = new ReportParameter("tempinbz", strRP[4]);
                    ReportParameter workodp6 = new ReportParameter("inbz", strRP[5]);
                    ReportParameter workodp7 = new ReportParameter("po", strRP[6]);
                    ReportParameter workodp8 = new ReportParameter("zm1", strRP[7]);
                    ReportParameter workodp9 = new ReportParameter("zm3", strRP[8]);
                    ReportParameter workodp10 = new ReportParameter("cm", strRP[9]);
                    ReportParameter workodp11 = new ReportParameter("ywcode", strRP[10]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { workodp1, workodp2, workodp3, workodp4, workodp5, workodp6, workodp7, workodp8, workodp9, workodp10, workodp11 });
                    break;
                case "workodf":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.workodf.rdlc";
                    //載入參數
                    ReportParameter workodf1 = new ReportParameter("customer", strRP[0]);
                    ReportParameter workodf2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter workodf3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter workodf4 = new ReportParameter("delivedate", strRP[3]);
                    ReportParameter workodf5 = new ReportParameter("tempinbz", strRP[4]);
                    ReportParameter workodf6 = new ReportParameter("inbz", strRP[5]);
                    ReportParameter workodf7 = new ReportParameter("po", strRP[6]);
                    ReportParameter workodf8 = new ReportParameter("zm1", strRP[7]);
                    ReportParameter workodf9 = new ReportParameter("zm3", strRP[8]);
                    ReportParameter workodf10 = new ReportParameter("cm", strRP[9]);
                    ReportParameter workodf11 = new ReportParameter("ywcode", strRP[10]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { workodf1, workodf2, workodf3, workodf4, workodf5, workodf6, workodf7, workodf8, workodf9, workodf10, workodf11 });
                    break;
                case "workodgp":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.workodgp.rdlc";
                    //載入參數
                    ReportParameter workodgp1 = new ReportParameter("customer", strRP[0]);
                    ReportParameter workodgp2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter workodgp3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter workodgp4 = new ReportParameter("delivedate", strRP[3]);
                    ReportParameter workodgp5 = new ReportParameter("tempinbz", strRP[4]);
                    ReportParameter workodgp6 = new ReportParameter("inbz", strRP[5]);
                    ReportParameter workodgp7 = new ReportParameter("po", strRP[6]);
                    ReportParameter workodgp8 = new ReportParameter("zm1", strRP[7]);
                    ReportParameter workodgp9 = new ReportParameter("zm3", strRP[8]);
                    ReportParameter workodgp10 = new ReportParameter("cm", strRP[9]);
                    ReportParameter workodgp11 = new ReportParameter("ywcode", strRP[10]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { workodgp1, workodgp2, workodgp3, workodgp4, workodgp5, workodgp6, workodgp7, workodgp8, workodgp9, workodgp10, workodgp11 });
                    break;
                case "workodgc":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.workodgc.rdlc";
                    //載入參數
                    ReportParameter workodgc1 = new ReportParameter("customer", strRP[0]);
                    ReportParameter workodgc2 = new ReportParameter("orderid", strRP[1]);
                    ReportParameter workodgc3 = new ReportParameter("orderdate", strRP[2]);
                    ReportParameter workodgc4 = new ReportParameter("delivedate", strRP[3]);
                    ReportParameter workodgc5 = new ReportParameter("tempinbz", strRP[4]);
                    ReportParameter workodgc6 = new ReportParameter("inbz", strRP[5]);
                    ReportParameter workodgc7 = new ReportParameter("po", strRP[6]);
                    ReportParameter workodgc8 = new ReportParameter("zm1", strRP[7]);
                    ReportParameter workodgc9 = new ReportParameter("zm3", strRP[8]);
                    ReportParameter workodgc10 = new ReportParameter("cm", strRP[9]);
                    ReportParameter workodgc11 = new ReportParameter("ywcode", strRP[10]);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { workodgc1, workodgc2, workodgc3, workodgc4, workodgc5, workodgc6, workodgc7, workodgc8, workodgc9, workodgc10, workodgc11 });
                    break;
                case "bomuse":
                    //載入rdlc
                    localReport.ReportEmbeddedResource = "Price2.RDLC.bomuse.rdlc";
                    //載入參數
                    ReportParameter bomuse1 = new ReportParameter("rpProduct", strRP[0]);
                    ReportParameter bomuse2 = new ReportParameter("rpLevel1", strRP[1]);
                    ReportParameter bomuse3 = new ReportParameter("rpLevel2", strRP[2]);
                    ReportParameter bomuse4 = new ReportParameter("rpLevel3", strRP[3]);

                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { bomuse1, bomuse2, bomuse3, bomuse4 });
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
