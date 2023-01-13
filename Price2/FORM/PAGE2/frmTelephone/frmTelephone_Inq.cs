using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;


namespace Price2
{
    public partial class frmTelephone_Inq : Form
    {
        public static string strUserName;
        public frmTelephone_Inq()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e) //結束
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtKey.Text = "";
            DataTable dt = (DataTable)dgvData.DataSource;
            dt.Rows.Clear();
            dgvData.DataSource = dt;
            //dgvData.Rows.Clear();
        }

        private void btnInq_Click(object sender, EventArgs e)
        {
            string strWhere = "";
            if (txtKey.Text!="")
            {
                if(txtKey.Text.IndexOf(";",0)>0)
                {
                    string[] sArray = Regex.Split(txtKey.Text, ";");
                    for(int i = 0; i < sArray.Length; i++)
                    {
                        strWhere = strWhere + $@"(tel_name like '%{sArray[i].Trim()}%' 
                                                    or tel_twphone like '%{sArray[i].Trim()}%' 
                                                    or tel_twfax like '%{sArray[i].Trim()}%' 
                                                    or tel_twmobile like '%{sArray[i].Trim()}%' 
                                                    or tel_dlphone like '%{sArray[i].Trim()}%' 
                                                    or tel_dlfax like '%{sArray[i].Trim()}%' 
                                                    or tel_dlmobile like '%{sArray[i].Trim()}%') ";
                        //or tel_dlemail like '%{sArray[i].Trim()}%' 
                        //or tel_twemail like '%{sArray[i].Trim()}%' 
                        //or tel_twaddress like '%{sArray[i].Trim()}%' 
                        //or tel_dladdress like '%{sArray[i].Trim()}%' 
                        //or tel_bz like '%{sArray[i].Trim()}%' )  ";
                        if(i+1< sArray.Length)
                        {
                            strWhere = strWhere + " and ";
                        }
                    }
                }
                else
                {
                    strWhere = $@"tel_name like'%{txtKey.Text.Trim()}%' 
                                    or tel_twphone like'%{txtKey.Text.Trim()}%' 
                                    or tel_twfax like'%{txtKey.Text.Trim()}%' 
                                    or tel_twmobile like'%{txtKey.Text.Trim()}%' 
                                    or tel_dlphone like'%{txtKey.Text.Trim()}%' 
                                    or tel_dlfax like'%{txtKey.Text.Trim()}%' 
                                    or tel_dlmobile like'%{txtKey.Text.Trim()}%' ";
                    //or tel_dlemail like'%{txtKey.Text.Trim()}%' 
                    //or tel_twemail like'%{txtKey.Text.Trim()}%' 
                    //or tel_twaddress like'%{txtKey.Text.Trim()}%' 
                    //or tel_dladdress like'%{txtKey.Text.Trim()}%' 
                    //or tel_bz like'%{txtKey.Text.Trim()}%' ";
                }
                string strSQL = "";
                if (cboType.Text=="(ALL)")
                {
                    strSQL = $@"select tel_name, 
                                          tel_twphone, 
                                          tel_dlphone, 
                                          tel_twfax, 
                                          tel_twmobile, 
                                          tel_dlfax, 
                                          tel_dlmobile, 
                                          tel_type 
                                   from tel 
                                   where tel_username='{strUserName}' and " + strWhere ;
                }
                else
                {
                    strSQL = $@"select tel_name, 
                                          tel_twphone, 
                                          tel_dlphone, 
                                          tel_twfax, 
                                          tel_twmobile, 
                                          tel_dlfax, 
                                          tel_dlmobile, 
                                          tel_type 
                                   from tel 
                                   where tel_username= '{strUserName}' and tel_type= '{cboType.Text}' and " + strWhere;
                }
                DataTable dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;
            }
            else
            {
                string strSQL = "";
                if (cboType.Text == "(ALL)")
                {
                    strSQL = $@"select tel_name, 
                                          tel_twphone, 
                                          tel_dlphone, 
                                          tel_twfax, 
                                          tel_twmobile, 
                                          tel_dlfax, 
                                          tel_dlmobile, 
                                          tel_type 
                                   from tel 
                                   where tel_username='{strUserName}' ";
                }
                else
                {
                    strSQL = $@"select tel_name, 
                                          tel_twphone, 
                                          tel_dlphone, 
                                          tel_twfax, 
                                          tel_twmobile, 
                                          tel_dlfax, 
                                          tel_dlmobile, 
                                          tel_type 
                                   from tel 
                                   where tel_username= '{strUserName}' and tel_type= '{cboType.Text}' ";
                }
                DataTable dt = clsDB.sql_select_dt(strSQL);
                dgvData.DataSource = dt;
                //foreach (DataRow row in dt.Rows)
                //{
                //    var dataGridRow = new DataGridViewRow();
                //    dataGridRow.CreateCells(dgvData);
                //    for (int i = 0; i < row.ItemArray.Length; i++)
                //    {
                //        dataGridRow.Cells[i].Value = row.ItemArray[i];
                //    }
                //    dgvData.Rows.Add(dataGridRow);
                //}
            }
        }

        private void frmTelephone_Inq_Activated(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmTelephone_Inq_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            export_csv(dgvData);
        }
        private void export_csv(DataGridView DG)
        {
            //export EXcel=new excel 
            if(dgvData.Rows.Count >200000)
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
            
            if(!DG.Rows.Count.Equals(0))
            {
                file.CheckFileExists = false;
                if(result== DialogResult.Cancel)
                {
                    return;
                }
                filename=file.FileName;
                if((string.IsNullOrEmpty(filename) || filename==null))
                {
                    MessageBox.Show("錯誤名稱檔案!!", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        output=new FileStream(filename, FileMode.Create, FileAccess.Write);
                        writer = new StreamWriter(output, System.Text.Encoding.Unicode);
                        //DataGridView美行開頭名稱
                        //FileText="";
                        //FileText= "報表查詢區間 ："+ _TimeS + " ~ " + _TimeE + "\r\n\r\n";
                        for(j = 0; j < DG.Columns.Count; j++)
                        {
                            FileText += DG.Columns[j].HeaderText.ToString() + char.ConvertFromUtf32((int)9);
                        }
                        writer.WriteLine(FileText);
                        for(i = 0; i < DG.Rows.Count; i++)
                        {
                            FileText = "";
                            for(j = 0; j < DG.Columns.Count; j++)
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            //clsGlobal clsGlobal = new clsGlobal();

            clsGlobal.ExportExcel("私人電話簿", dgvData);

        }
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //frmTelephone frmTelephone ;
            frmTelephone.strName = dgvData.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.Close();
        }
    }
}
