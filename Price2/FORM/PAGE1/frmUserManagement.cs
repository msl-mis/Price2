using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Price2
{
    public partial class frmUserManagement : Form
    {
        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==13)
            {
                getData_UserName(txtUserName.Text); //取得用戶名相關資料或創建新用戶
            }
        }

        private void getData_UserName(string strUserName)
        {
            //取得用戶名相關資料或創建新用戶
            try
            {
                //clsDB.Open();    //SQL連線
                String strSQL = $@"select dbo.Readpwd(pas_password) as pwd,
                                          *
                                   from   pas
                                   where  pas_username = '{strUserName}' ";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count > 0)
                {
                    txtPassword.Text= dt.Rows[0]["pwd"].ToString();
                    txtName.Text= dt.Rows[0]["pas_name"].ToString();
                    txtBusinessCode.Text = dt.Rows[0]["pas_ywcode"].ToString();
                    txtDepartment.Text = dt.Rows[0]["pas_quote"].ToString();

                    //先把checkbox歸零
                    for (int i = 0; i < dgvUser.RowCount; i++)
                    {
                        dgvUser.Rows[i].Cells["chk"].Value = false;
                    }
                    string rs = "";
                    //再把checkbox依條件打勾
                    for (int i = 0; i < dgvUser.RowCount; i++)
                    {
                        strSQL = $@"select mod_flag
                                    from   mod
                                    where  mod_username = '{strUserName}'
                                           and mod_modulename = '{dgvUser.Rows[i].Cells["mod_modulename"].Value}' ";
                        rs = clsDB.sql_select_String(strSQL, "mod_flag");
                        if (rs == "1")
                        {
                            dgvUser.Rows[i].Cells["chk"].Value = true;
                        }
                    }
                    txtPassword.Focus();
                }
                else
                {
                    if (MessageBox.Show("你想創建一個新用戶嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtPassword.Text = "";
                        txtName.Text = "";
                        txtBusinessCode.Text = "";
                        txtDepartment.Text = "";
                        txtPassword.Focus();
                    }
                    else
                    {
                        //清除
                        btnClear.PerformClick();
                    }
                }
                //clsDB.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-getData_UserName" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //結束
            try
            {
                frmMain frmMain = (frmMain)this.MdiParent;
                frmMain.gbMain.Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-_btnClose_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //清除
            try
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
                txtName.Text = "";
                txtBusinessCode.Text = "";
                txtDepartment.Text = "";
                for (int i = 0; i < dgvUser.RowCount; i++)
                {
                    dgvUser.Rows[i].Cells["chk"].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-_btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 儲存
            try
            {
                if (MessageBox.Show("你確定要儲存嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //clsDB.Open();
                    String strSQL = $@"exec pas_save
                                            '{txtUserName.Text.Trim()}',
                                            '{txtPassword.Text.Trim()}',
                                            '{txtName.Text.Trim()}',
                                            '{txtBusinessCode.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    string rs = "";
                    strSQL = $@"update pas
                                set    pas_quote = '{txtDepartment.Text.Trim()}'
                                where pas_username = '{txtUserName.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    int mod_flag = 0;
                    for (int i = 0; i < dgvUser.RowCount; i++)
                    {
                        if(dgvUser.Rows[i].Cells["chk"].Value.ToString() == "True")
                        {
                            mod_flag = 1;
                        }
                        else
                        {
                            mod_flag = 0;
                        }
                        //mod_flag = (dgvUser.Rows[i].Cells["chk"].Value == true ? 1 : 0);

                        //查詢mod是否有值,有就UPDATE;沒有就INSERT
                        strSQL = $@"select mod_modulename
                                    from   mod
                                    where  mod_username = '{txtUserName.Text.Trim()}'
                                            and mod_modulename = '{dgvUser.Rows[i].Cells["mod_modulename"].Value.ToString()}' ";
                        rs = clsDB.sql_select_String(strSQL, "mod_modulename");
                        if (rs != "")
                        {
                            strSQL = $@"update mod
                                        set    mod_username = '{txtUserName.Text.Trim()}',
                                               mod_flag = {mod_flag},
                                               mod_orderflag = '{dgvUser.Rows[i].Cells["mod_orderflag"].Value.ToString()}',
                                               mod_dispflag = '{dgvUser.Rows[i].Cells["mod_dispflag"].Value.ToString()}'
                                        where mod_username = '{txtUserName.Text.Trim()}'
                                               and mod_modulename = '{dgvUser.Rows[i].Cells["mod_modulename"].Value.ToString()}' ";
                            clsDB.Execute(strSQL);
                        }
                        else
                        {
                            strSQL = $@"insert into [dbo].[mod]
                                                    ([mod_username],
                                                     [mod_menu],
                                                     [mod_modulename],
                                                     [mod_flag],
                                                     [mod_orderflag],
                                                     mod_dispflag)
                                        values     ('{txtUserName.Text.Trim()}',
                                                    '{dgvUser.Rows[i].Cells["mod_menu"].Value.ToString()}',
                                                    '{dgvUser.Rows[i].Cells["mod_modulename"].Value.ToString()}',
                                                    {mod_flag},
                                                    '{dgvUser.Rows[i].Cells["mod_orderflag"].Value.ToString()}',
                                                    '{dgvUser.Rows[i].Cells["mod_dispflag"].Value.ToString()}') ";
                            clsDB.Execute(strSQL);
                        }   
                    }
                    strSQL = $@"select Isnull(mod_flag, 0) as flag
                                    from   mod
                                    where  mod_username = '{txtUserName.Text.Trim()}'
                                           and mod_modulename = '受限為Y客戶' ";
                    rs = clsDB.sql_select_String(strSQL, "mod_modulename");
                    if (rs != "")
                    {
                        string strControluser = (rs == "1" ? "√" : "");
                        strSQL = $@"update pas
                                        set    pas_controluser = '{strControluser}'
                                        where pas_username = '{txtUserName.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                    }
                    //clsDB.Close();
                    MessageBox.Show("已經存盤完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //刪除
            try
            {
                if (txtUserName.Text.Trim()=="YZF")
                {
                    MessageBox.Show("你不能刪除此用戶!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; 
                }
                //clsDB.Open();
                String strSQL = $@"select * from pas where pas_username='{txtUserName.Text.Trim()}'";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    if (MessageBox.Show("你要刪除這個用戶嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        strSQL = $@"delete from pas where pas_username='{txtUserName.Text.Trim()}'";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete from mod where mod_username='{txtUserName.Text.Trim()}'";
                        clsDB.Execute(strSQL);
                        MessageBox.Show("已經刪除成功!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClear.PerformClick();
                    }
                }
                else
                {
                    MessageBox.Show("沒有這個用戶!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //clsDB.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            export_csv();
        }

        private void export_csv()
        {
            //export EXcel=new excel 
            FileStream output =default(FileStream);
            StreamWriter writer = default( StreamWriter);
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Excel Files(*.csv)|*.csv";
            file.Title = "儲存CSV檔(Excel)";
            DialogResult result = file.ShowDialog();
            string filename = null;
            string FileText = null;
            int i = 0;
            int j = 0;
            filename=file.FileName;
            output=new FileStream(filename, FileMode.Create, FileAccess.Write);
            writer = new StreamWriter(output,System.Text.Encoding.Unicode);
            writer.WriteLine(FileText);
            FileText = "TESR";
            writer.WriteLine(FileText);
            writer.Flush();
            writer.Close();
            file.Dispose();
            //output= new FileStream(filename, FileMode.Open);
            System.Diagnostics.Process.Start( filename);
        }

        private void frmUserManagement_Activated(object sender, EventArgs e)
        {
            //要加入很多初始化東西
            try
            {
                //clsDB.Open();    //SQL連線
                String strSQL = $@"select mod_modulename,
                                          mod_dispflag,
                                          mod_menu,
                                          mod_orderflag
                                   from   mod
                                   where  mod_username = 'yzf'
                                   order  by mod_orderflag,
                                             mod_menu,
                                             mod_modulename collate chinese_taiwan_stroke_cs_as_ks_ws ";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                dgvUser.DataSource = dt;
                //先把checkbox歸零
                for (int i = 0; i < dgvUser.RowCount; i++)
                {
                    dgvUser.Rows[i].Cells["chk"].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmMain_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
