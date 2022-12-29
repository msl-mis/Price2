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
    public partial class frmBOMPrice_Large : Form
    {
        public static string rstrID = "";    //frmBOMPrice傳入的客號ID
        public static string rstrCost = "";    //frmBOMPrice傳入的成本
        public static string rstr_pricost = "";    //frmBOMPrice傳入的報價
        public static string rstr_pri_ll = "";    //frmBOMPrice傳入的利潤
        public static string rstr_hopelprice = "";    //frmBOMPrice傳入的希望買價
        public static string rstr_customerll = "";    //frmBOMPrice傳入的希望買價利潤
        
        double pricost = 0; //一般價的差別報價
        double hopecost = 0;  //一般價的希望買價
        public frmBOMPrice_Large()
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

        private void frmBOMPrice_Large_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                lblID.Text = rstrID;
                string strSQL = "";
                DataTable dt = new DataTable();
                strSQL = $@"select pld_name,
                                   pld_pricost,
                                   pld_ll,
                                   pld_hopecost,
                                   pld_hopell,
                                   Format(pld_date, 'yyyy/MM/dd') pld_date,
                                   pld_oldll
                            from   pld
                            where  pld_customerid = '{rstrID}'
                            order  by pld_name desc ";
                dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvData.Rows.Add();
                        dgvData.Rows[i].Cells["pld_name"].Value = dt.Rows[i]["pld_name"].ToString();
                        dgvData.Rows[i].Cells["pld_pricost"].Value = dt.Rows[i]["pld_pricost"].ToString();
                        dgvData.Rows[i].Cells["pld_ll"].Value = dt.Rows[i]["pld_ll"].ToString();
                        dgvData.Rows[i].Cells["pld_hopecost"].Value = dt.Rows[i]["pld_hopecost"].ToString();
                        dgvData.Rows[i].Cells["pld_hopell"].Value = dt.Rows[i]["pld_hopell"].ToString();
                        dgvData.Rows[i].Cells["pld_date"].Value = dt.Rows[i]["pld_date"].ToString();
                        dgvData.Rows[i].Cells["pld_oldll"].Value = dt.Rows[i]["pld_oldll"].ToString();
                    }
                }
                else
                {
                    strSQL = $@"select distinct '一般價'　name,
                                                pri_pricost,
                                                pri_ll,
                                                pri_hopelprice,
                                                pri_customerll,
                                                Format(GETDATE(), 'yyyy/MM/dd') date,
                                                pri_ll
                                from   pri
                                where  pri_customerid = '{rstrID}'
                                       and pri_newcostchk like 'N%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dgvData.Rows.Add();
                            dgvData.Rows[i].Cells["pld_name"].Value = "一般價";
                            dgvData.Rows[i].Cells["pld_pricost"].Value = dt.Rows[i]["pri_pricost"].ToString();
                            dgvData.Rows[i].Cells["pld_ll"].Value = dt.Rows[i]["pri_ll"].ToString();
                            dgvData.Rows[i].Cells["pld_hopecost"].Value = dt.Rows[i]["pri_hopelprice"].ToString();
                            dgvData.Rows[i].Cells["pld_hopell"].Value = dt.Rows[i]["pri_customerll"].ToString();
                            dgvData.Rows[i].Cells["pld_date"].Value = dt.Rows[i]["date"].ToString();
                            dgvData.Rows[i].Cells["pld_oldll"].Value = dt.Rows[i]["pri_ll"].ToString();
                        }
                    }
                    else
                    {
                        dgvData.Rows.Add();
                        dgvData.Rows[0].Cells["pld_name"].Value = "一般價";
                        dgvData.Rows[0].Cells["pld_pricost"].Value = rstr_pricost;
                        dgvData.Rows[0].Cells["pld_ll"].Value = rstr_pri_ll;
                        dgvData.Rows[0].Cells["pld_hopecost"].Value = rstr_hopelprice;
                        dgvData.Rows[0].Cells["pld_hopell"].Value = rstr_customerll;
                        dgvData.Rows[0].Cells["pld_date"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        dgvData.Rows[0].Cells["pld_oldll"].Value = rstr_pri_ll;
                    }
                }
                //取得一般價的差別報價和一般價的希望買價
                for (int i=0;i<dgvData.Rows.Count-1;i++)
                {
                    if(dgvData.Rows[i].Cells["pld_name"].Value.ToString() == "一般價")
                    {
                        pricost = Convert.ToDouble(dgvData.Rows[i].Cells["pld_pricost"].Value);
                        hopecost = Convert.ToDouble(dgvData.Rows[i].Cells["pld_hopecost"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOMPrice_Large_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == 1)
                {
                    if (dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_pricost"].Value.ToString()!="")
                    {
                        if(Convert.ToDouble(dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_pricost"].Value)> pricost)
                        {
                            MessageBox.Show("差別報價不可以大於一般價的差別報價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_pricost"].Value = "0";
                            dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_ll"].Value = "0";
                            return;
                        }
                        else
                        {
                            dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_ll"].Value=((Convert.ToDouble(dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_pricost"].Value)-Convert.ToDouble(rstrCost))*100/ Convert.ToDouble(rstrCost)).ToString("0.#");
                            //不知道舊利潤=新利潤有什麼意義
                            dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_oldll"].Value = dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_ll"].Value;
                        }
                    }
                    else
                    {
                        dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_ll"].Value = "0";
                    }
                }
                if (e.ColumnIndex == 3)
                {
                    if (dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_hopecost"].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_hopecost"].Value) > hopecost)
                        {
                            MessageBox.Show("希望買價不可以大於一般價的希望買價!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_hopecost"].Value = "0";
                            dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_hopell"].Value = "0";
                            return;
                        }
                        else
                        {
                            dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_hopell"].Value = ((Convert.ToDouble(dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_hopecost"].Value) - Convert.ToDouble(rstrCost)) * 100 / Convert.ToDouble(rstrCost)).ToString("0.#");
                        }
                    }
                    else
                    {
                        dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_hopecost"].Value = "0";
                        dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_hopell"].Value = "0";
                    }
                }
                dgvData.Rows[dgvData.CurrentRow.Index].Cells["pld_date"].Value = DateTime.Now.ToString("yyyy/MM/dd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-dgvData_CellEndEdit" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                int iCount = 0;
                for(int i=0; i<dgvData.Rows.Count-1; i++)
                {
                    if (dgvData.Rows[i].Cells["pld_name"].Value.ToString() != "一般價" || 
                        dgvData.Rows[i].Cells["pld_name"].Value.ToString() != "")
                    {
                        iCount = iCount + 1;
                    }
                }
                frmBOMPrice.rstrLarge = iCount.ToString();
                strSQL = $@"delete pld where pld_customerid = '{rstrID}'";
                clsDB.Execute(strSQL);
                for (int i = 0; i < dgvData.Rows.Count - 1; i++)
                {
                    string _pricost = (dgvData.Rows[i].Cells["pld_pricost"].Value==null || dgvData.Rows[i].Cells["pld_pricost"].Value == "" ? "NULL" : dgvData.Rows[i].Cells["pld_pricost"].Value.ToString());
                    string _ll = (dgvData.Rows[i].Cells["pld_ll"].Value==null || dgvData.Rows[i].Cells["pld_ll"].Value == "" ? "NULL" : dgvData.Rows[i].Cells["pld_ll"].Value.ToString());
                    string _hopecost = (dgvData.Rows[i].Cells["pld_hopecost"].Value==null || dgvData.Rows[i].Cells["pld_hopecost"].Value == "" ? "NULL" : dgvData.Rows[i].Cells["pld_hopecost"].Value.ToString());
                    string _hopell = (dgvData.Rows[i].Cells["pld_hopell"].Value==null || dgvData.Rows[i].Cells["pld_hopell"].Value == "" ? "NULL" : dgvData.Rows[i].Cells["pld_hopell"].Value.ToString());
                    string _oldll = (dgvData.Rows[i].Cells["pld_oldll"].Value==null || dgvData.Rows[i].Cells["pld_oldll"].Value == "" ? "NULL" : dgvData.Rows[i].Cells["pld_oldll"].Value.ToString());
                    strSQL = $@"insert into pld
                                            (pld_customerid,
                                             pld_name,
                                             pld_pricost,
                                             pld_ll,
                                             pld_hopecost,
                                             pld_hopell,
                                             pld_date,
                                             pld_oldll)
                                values      ('{rstrID}',
                                             '{dgvData.Rows[i].Cells["pld_name"].Value.ToString()}',
                                             {_pricost},
                                             {_ll},
                                             {_hopecost},
                                             {_hopell},
                                             '{dgvData.Rows[i].Cells["pld_date"].Value.ToString()}',
                                             {_oldll}) ";
                    clsDB.Execute(strSQL);
                }
                if(iCount>0)
                {
                    strSQL = $@"update pri set pri_ld = 1 where pri_customerid = '{rstrID}'";
                    clsDB.Execute(strSQL);
                }
                else
                {
                    strSQL = $@"update pri set pri_ld = 0 where pri_customerid = '{rstrID}'";
                    clsDB.Execute(strSQL);
                }
                MessageBox.Show("儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmBOMPrice.rstrButton = "Save";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
