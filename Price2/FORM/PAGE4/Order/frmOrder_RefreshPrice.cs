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
    public partial class frmOrder_RefreshPrice : Form
    {
        public static string rstrOrderID = "";
        public frmOrder_RefreshPrice()
        {
            InitializeComponent();
        }

        private void frmOrder_RefreshPrice_Load(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmOrder_RefreshPrice_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    dgvData.Rows[i].Cells["CHK"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    dgvData.Rows[i].Cells["CHK"].Value = false;
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            //先將dgvdata存到na54
            strSQL = $@"delete na54 where na54_computername=host_name() ";
            clsDB.Execute(strSQL);
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                string CHK = "";
                if(dgvData.Rows[i].Cells["CHK"].Value.Equals(true) )
                {
                    CHK = "⊕";
                }
                else
                {
                    CHK = "";
                }
                strSQL = $@"insert into na54
                                            (na54_assy,
                                             na54_flag,
                                             na54_computername)
                                values     ( '{dgvData.Rows[i].Cells["產品編號"].Value.ToString()}',
                                             '{CHK}',
                                             Host_name()) ";
                clsDB.Execute(strSQL);
            }
            frmOrder.rstrButton = "Save";
            this.Close();
        }
    }
}
