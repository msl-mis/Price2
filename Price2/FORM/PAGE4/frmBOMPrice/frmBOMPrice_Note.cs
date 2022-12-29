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
    public partial class frmBOMPrice_Note : Form
    {
        public static string rstrID = "";    //frmBOMPrice傳入的客號ID
        public frmBOMPrice_Note()
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
                frmBOMPrice.rstrNote = rtxtNote.Text;
                frmBOMPrice.rstrButton = "Save";
                string strSQL = "";
                DataTable dt = new DataTable();
                if(rtxtNote.Text == "")
                {
                    strSQL = $@"update pri
                                set    pri_bzflag = 0,
                                       pri_bz = '{rtxtNote.Text.Trim()}'
                                where  pri_customerid = '{rstrID}' ";

                    clsDB.Execute(strSQL);
                }
                else
                {
                    strSQL = $@"update pri
                                set    pri_bzflag = 1,
                                       pri_bz = '{rtxtNote.Text.Trim()}'
                                where  pri_customerid = '{rstrID}' ";

                    clsDB.Execute(strSQL);
                }
                
                MessageBox.Show("儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBOMPrice_Note_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                lblID.Text = rstrID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOMPrice_Large_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
