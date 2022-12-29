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
    public partial class frmBOMPrice_Class : Form
    {
        public static string rstrID = "";    //frmBOMPrice傳入的客號ID

        public frmBOMPrice_Class()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //結束
            try
            {
                frmBOMPrice.rstrButton = "Close";
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                frmBOMPrice.rstrClass = cboClass.Text;
                frmBOMPrice.rstrButton = "Save";
                string strSQL = "";
                DataTable dt = new DataTable();
                string strWhere = $@"where pri_customerid = '{rstrID}' ";
                strSQL = $@"update pri
                            set    pri_fenlei='{cboClass.Text}' "
                            + (cboClass.Text=="7 Power cord" ? "pri_wg='2' " : "") 
                            + strWhere;
                clsDB.Execute(strSQL);
                MessageBox.Show("儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBOMPrice_Class_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select pri_fenlei from pri where pri_customerid='{rstrID.Trim()}'";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0)
                {
                    cboClass.Text = dt.Rows[0]["pri_fenlei"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOMPrice_Special_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
