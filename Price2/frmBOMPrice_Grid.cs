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
    public partial class frmBOMPrice_Grid : Form
    {
        //strWho = "No_id"  沒有客號,就以客戶/廠號/線長等欄位條件來查詢報價單,取得查詢結果筆數>1
        //strWho = "C_id"   有客號,報價單取得查詢結果筆數>1
        //strWho = "M_id"   有客號,材料單取得查詢結果筆數>1
        //strWho = "No_name"   有客號,沒有品號,材料單取得查詢結果筆數>1
        public static string strWho = "";
        public static string pri_assy = "";
        public static string pri_customer = "";
        public static string pri_length = "";
        public static string aspnum_id = "";
        public static string pri_customerid = "";

        string strID = "";
        public frmBOMPrice_Grid()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            getExport();
        }

        private void getExport()
        {
            try
            {
                switch (strWho)
                {
                    case "No_id":
                        
                        break;
                    case "C_id":
                        
                        break;
                    case "M_id":
                        
                        break;
                    case "No_name":
                        frmBOMPrice.rstrID = aspnum_id.Trim();
                        frmBOMPrice.rstrName = dgvData.Rows[dgvData.CurrentRow.Index].Cells["品號"].Value.ToString();
                        break;
                    default:

                        break;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getExport" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBOMPrice_Grid_Activated(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                switch (strWho)
                {
                    case "No_id":
                        this.Text = "選擇讀取產品的報價日期";
                        strSQL = $@"select distinct pri_date'報價日期'
                                from   pri
                                where  pri_assy = '{pri_assy.Trim()}'
                                       and pri_customer = '{pri_customer.Trim()}'
                                       and pri_newcostchk like 'N%'
                                       and pri_length = '{pri_length.Trim()}'
                                order  by pri_date ";
                        dt = clsDB.sql_select_dt(strSQL);
                        dgvData.DataSource = dt;
                        //設置DataGridView的欄位填充整個顯示區
                        dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvData.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "C_id":
                        this.Text = "選擇讀取產品的報價日期";
                        strSQL = $@"select distinct pri_date'報價日期'
                                        from   pri
                                        where  pri_newcostchk like 'N%'
                                                and pri_customerid = '{pri_customerid.Trim()}'
                                        order  by pri_date ";
                        dt = clsDB.sql_select_dt(strSQL);
                        dgvData.DataSource = dt;
                        //設置DataGridView的欄位填充整個顯示區
                        dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvData.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "M_id":
                        this.Text = "選擇材料品號";
                        strSQL = $@"select aspnum_num '品號',
                                       case
                                         when asp_vendormaterialno = aspnum_num then 'V'
                                         else ''
                                       end        '火車頭使用中',
                                       case
                                         when aa.pri_assy = aspnum_num then 'V'
                                         else ''
                                       end        '有材料單'
                                from   Price.dbo.aspnum
                                       left join Price.dbo.asp
                                              on asp_id = aspnum_id
                                       left join (select distinct pri_customerid,
                                                                  pri_assy
                                                  from   pri
                                                  where  pri_newcostchk like 'Y%') as aa
                                              on aa.pri_customerid = aspnum_id
                                                 and aa.pri_assy = aspnum_num
                                where  aspnum_id = '{aspnum_id.Trim()}'
                                order  by aspnum_id ";
                        dt = clsDB.sql_select_dt(strSQL);
                        dgvData.DataSource = dt;
                        //設置DataGridView的欄位填充整個顯示區 自動調整欄位
                        dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvData.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgvData.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvData.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "No_name":
                        this.Text = "選擇材料品號";
                        strSQL = $@"select distinct ab.aspnum_num '品號',
                                                case
                                                    when asp_vendormaterialno = ab.aspnum_num then 'V'
                                                    else ''
                                                end           '火車頭外層',
                                                case
                                                    when ac.aspnum_num = ab.aspnum_num then 'V'
                                                    else ''
                                                end           '火車頭內層',
                                                case
                                                    when aa.pri_assy = ab.aspnum_num then 'V'
                                                    else ''
                                                end           '有材料單'
                                from   (select aspnum_id,
                                                aspnum_num
                                        from   aspnum
                                        union all
                                        select distinct pri_customerid,
                                                        pri_assy
                                        from   pri
                                        where  pri_newcostchk like 'Y%') as ab
                                        left join Price.dbo.asp
                                                on asp_id = ab.aspnum_id
                                                    and asp_vendormaterialno = ab.aspnum_num
                                        left join Price.dbo.aspnum as ac
                                                on ac.aspnum_id = ab.aspnum_id
                                                    and ac.aspnum_num = ab.aspnum_num
                                        left join (select distinct pri_customerid,
                                                                    pri_assy
                                                    from   pri
                                                    where  pri_newcostchk like 'Y%') as aa
                                                on aa.pri_customerid = ab.aspnum_id
                                                    and aa.pri_assy = ab.aspnum_num
                                where  ab.aspnum_id = '{aspnum_id.Trim()}'
                                order  by ab.aspnum_num ";
                        dt = clsDB.sql_select_dt(strSQL);
                        dgvData.DataSource = dt;
                        //設置DataGridView的欄位填充整個顯示區 自動調整欄位
                        dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvData.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgvData.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvData.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvData.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    default:

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOMPrice_Grid_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >=0)
            {
                getExport();
            }
        }
    }
}
