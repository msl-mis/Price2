using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Price2
{
    public partial class frmTelephone : Form
    {
        public static string strName = "";
        public frmTelephone()
        {
            InitializeComponent();
        }
        private void frmTelephone_Activated(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                List<string> sList = new List<string>();

                String strSQL = $@"select distinct pas_username from pas where pas_username<>'' order by pas_username";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                //清除
                //cboUser.Items.Clear();
                //使用者加入
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sList.Add(dt.Rows[i]["pas_username"].ToString());
                }
                cboUser.AutoCompleteCustomSource.AddRange(sList.ToArray());
                cboUser.AutoCompleteSource = AutoCompleteSource.ListItems;
                cboUser.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboUser.DataSource = sList.ToArray();
                //先設為clsGlobal.strG_User
                cboUser.Text = clsGlobal.strG_User;
                addItem();
                btnClear.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmTelephone_Activated" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)  //儲存
        {
            //儲存
            try
            {
                //檢查欄位
                if (cboName.SelectionLength>50)  //姓名
                {
                    MessageBox.Show("姓名長度超過,限制為50個英文字元<25個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtCellphone_TW.TextLength > 40)  //台灣手機
                {
                    MessageBox.Show("台灣手機長度超過,限制為40個英文字元<20個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtCompany_TW.TextLength > 40)  //台灣公司電話
                {
                    MessageBox.Show("台灣公司電話長度超過,限制為40個英文字元<20個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtHome_TW.TextLength > 40)  //台灣住家電話
                {
                    MessageBox.Show("台灣住家電話長度超過,限制為40個英文字元<20個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtAddress_TW.TextLength > 100)  //台灣地址
                {
                    MessageBox.Show("台灣地址長度超過,限制為100個英文字元<50個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtCellphone_CN.TextLength > 40)  //大陸手機
                {
                    MessageBox.Show("大陸手機長度超過,限制為40個英文字元<20個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtCompany_CN.TextLength > 40)  //大陸公司電話
                {
                    MessageBox.Show("大陸公司電話長度超過,限制為40個英文字元<20個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtHome_CN.TextLength > 40)  //大陸住家電話
                {
                    MessageBox.Show("大陸住家電話長度超過,限制為40個英文字元<20個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtAddress_CN.TextLength > 100)  //台大陸地址
                {
                    MessageBox.Show("大陸地址長度超過,限制為100個英文字元<50個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtNote.TextLength > 1000)  //備註
                {
                    MessageBox.Show("備註長度超過,限制為1000個英文字元<500個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtEmail_TW.TextLength > 40)  //台灣e-mail
                {
                    MessageBox.Show("台灣e-mail長度超過,限制為40個英文字元<20個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtEmail_CN.TextLength > 40)  //大陸e-mail
                {
                    MessageBox.Show("大陸e-mail長度超過,限制為40個英文字元<20個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //儲存資料到Tel
                String strSQL = $@"exec Tel_save
                                      '{cboUser.Text}',
                                      '{cboName.Text}',
                                      '{cboType.Text}',
                                      '{txtCellphone_TW.Text}',
                                      '{txtCompany_TW.Text}',
                                      '{txtHome_TW.Text}',
                                      '{txtAddress_TW.Text}',
                                      '{txtCellphone_CN.Text}',
                                      '{txtCompany_CN.Text}',
                                      '{txtHome_CN.Text}',
                                      '{txtAddress_CN.Text}',
                                      '{txtNote.Text}',
                                      '{txtEmail_TW.Text}',
                                      '{txtEmail_CN.Text}' ";
                clsDB.Execute(strSQL);

                //將子項加回
                addItem();
                MessageBox.Show("已經存盤成功!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void addItem()  //將子項加回
        {
            //將子項加回
            try
            {
                string strItem = "";
                if (cboName.Text!="")
                {
                    strItem = cboType.Text;
                }
                string strSQL = $@"select distinct tel_type
                                   from   tel
                                   where  tel_username = '{cboUser.Text}'
                                           and Rtrim(tel_type) not in ('(ALL)') ";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                //清除
                cboType.Items.Clear();
                //先加(ALL)
                cboType.Items.Add("(ALL)");
                //再加入tel_type
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cboType.Items.Add(dt.Rows[i]["tel_type"]);
                }
                //再設為strItem
                if(strItem=="")
                {
                    cboType.Text = "(ALL)";
                }
                else
                {
                    cboType.Text= strItem;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-addItem" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click(object sender, EventArgs e) //清除
        {
            //清除
            try
            {
                cboType.Text = "(ALL)";         //子項
                cboName.Text = "";              //姓名
                txtCellphone_TW.Text = "";      //台灣手機
                txtCompany_TW.Text = "";        //台灣公司電話
                txtHome_TW.Text = "";           //台灣住家電話
                txtAddress_TW.Text = "";        //台灣地址
                txtCellphone_CN.Text = "";      //大陸手機
                txtCompany_CN.Text = "";        //大陸公司電話
                txtHome_CN.Text = "";           //大陸住家電話
                txtAddress_CN.Text = "";        //台大陸地址
                txtNote.Text = "";              //備註
                txtEmail_TW.Text = "";          //台灣e-mail
                txtEmail_CN.Text = "";          //大陸e-mail
                cboUser.Focus();

                addItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnClear_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRename_Click(object sender, EventArgs e)    //更名
        {
            //更名
            try
            {
                if(cboName.Text==""||cboUser.Text=="")
                {
                    return;
                }

                again:

                InputBox input = new InputBox();
                input.lblInfo.Text = "輸入要改成什麼姓名:";
                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (input.GetMsg() != "")
                    {
                        if(input.GetMsg().Length>50)
                        {
                            MessageBox.Show("姓名長度超過,限制為50個英文字元<25個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            goto again;
                        }
                        String strSQL = $@"update tel
                                           set    tel_name = '{input.GetMsg()}'
                                           where  tel_username = '{cboUser.Text.Trim()}'
                                                  and tel_name = '{cboName.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                        cboName.Text = input.GetMsg();
                        cboName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnRename_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCopy_Click(object sender, EventArgs e)  //複製
        {
            //複製
            try
            {
                if (cboName.Text == "" || cboUser.Text == "")
                {
                    return;
                }

            again:

                InputBox input = new InputBox();
                input.lblInfo.Text = "輸入要複製到的姓名:";
                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (input.GetMsg() != "")
                    {
                        if (input.GetMsg().Length > 50)
                        {
                            MessageBox.Show("姓名長度超過,限制為50個英文字元<25個中文字>", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            goto again;
                        }
                        String strSQL = $@"select *
                                            from   tel
                                            where  tel_username = '{cboUser.Text.Trim()}'
                                                   and tel_name = '{input.GetMsg().Trim()}' ";
                        DataTable dt = clsDB.sql_select_dt(strSQL);
                        if(dt.Rows.Count > 0)
                        {
                            MessageBox.Show("不能複製到已存在的姓名中!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            strSQL = $@"insert tel
                                               (tel_username,
                                                tel_name,
                                                tel_type,
                                                tel_twmobile,
                                                tel_twphone,
                                                tel_twfax,
                                                tel_dlmobile,
                                                tel_dlphone,
                                                tel_dlfax,
                                                tel_twaddress,
                                                tel_dladdress,
                                                tel_bz,
                                                tel_twemail,
                                                tel_dlemail)
                                        select '{cboUser.Text.Trim()}',
                                               '{input.GetMsg().Trim()}',
                                               tel_type,
                                               tel_twmobile,
                                               tel_twphone,
                                               tel_twfax,
                                               tel_dlmobile,
                                               tel_dlphone,
                                               tel_dlfax,
                                               tel_twaddress,
                                               tel_dladdress,
                                               tel_bz,
                                               tel_twemail,
                                               tel_dlemail
                                        from   tel
                                        where  tel_username = '{cboUser.Text.Trim()}'
                                               and tel_name = '{cboName.Text.Trim()}' ";
                            clsDB.Execute(strSQL);
                        }
                        cboName.Text = input.GetMsg();
                        cboName.Focus();
                        MessageBox.Show("已經複製完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCopy_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)    //刪除
        {
            //刪除
            try
            {
                if (cboName.Text == "" )
                {
                    return;
                }
                if (MessageBox.Show(this, "你確定要刪除該用戶的電話簿嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strSQL = $@"delete tel
                                       where  tel_username = '{cboUser.Text.Trim()}'
                                              and tel_name = '{cboName.Text.Trim()}' ";
                    clsDB.Execute(strSQL);
                    btnClear.PerformClick();
                    MessageBox.Show("刪除完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnDelete_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e) //列印
        {
            //列印
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(PrintImage);
                pd.DefaultPageSettings.Landscape = true;
                
                pd.Print();
                MessageBox.Show("列印完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnPrint_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void PrintImage(object o, PrintPageEventArgs e)
	    { 
	        int x = SystemInformation.WorkingArea.X; 
	        int y = SystemInformation.WorkingArea.Y; 
	        int width = this.Width; 
	        int height = this.Height;

            Rectangle bounds = new Rectangle(x, y, width , height );
            
            Bitmap img = new Bitmap(width, height ); 
	 
	        this.DrawToBitmap(img, bounds); 
	        Point p = new Point(100, 100);
            e.Graphics.DrawImage(img, p); 
	    }
        private void btnClose_Click(object sender, EventArgs e) //結束
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
        private void cboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnClear.PerformClick();
            addItem();
            string strSQL = $@"select tel_name
                                    from   tel
                                    where  tel_username = '{cboUser.Text.Trim()}' ";
            DataTable dt = clsDB.sql_select_dt(strSQL);
            //cboName.Items.Clear();
            List<string> sList = new List<string>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //cboNameListOld.Add(dt.Rows[i]["tel_name"].ToString());
                    sList.Add(dt.Rows[i]["tel_name"].ToString());
                }
                //cboName.Items.AddRange(cboNameListOld.ToArray());
                cboName.AutoCompleteCustomSource.AddRange(sList.ToArray());
                cboName.AutoCompleteSource = AutoCompleteSource.ListItems;
                cboName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboName.DataSource = sList.ToArray();
                //cboName.DisplayMember = "";
                cboName.Text = "";
                btnClear.PerformClick();
            }
            cboName.Focus();
        }
        private void btnInq_Click(object sender, EventArgs e)
        {
            frmTelephone_Inq frmTelephone_Inq = new frmTelephone_Inq();
            frmTelephone_Inq.strUserName = cboUser.Text;
            frmTelephone_Inq.ShowDialog();
            if(strName!="")
            {
                cboName.Text=strName;
                getData();  //取得與姓名相關資料
                strName = "";
            }
        }
        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            getData();  //取得與姓名相關資料
        }
        private void btnTypeRename_Click(object sender, EventArgs e)    //分類更名
        {
            //分類更名
            try
            {
                frmTelephone_RenameType frmTelephone_RenameType = new frmTelephone_RenameType();
                frmTelephone_RenameType.strUser = cboUser.Text;
                frmTelephone_RenameType.strItem = cboType.Text;
                frmTelephone_RenameType.ShowDialog();
                cboType.Text = frmTelephone_RenameType.strItem;
                addItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnTypeRename_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                txtCellphone_TW.Focus();
            }
        }

        private void txtCellphone_TW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCellphone_CN.Focus();
            }
        }
        private void txtCellphone_CN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCompany_TW.Focus();
            }
        }
        private void txtCompany_TW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void getData()  //取得與姓名相關資料
        {
            //取得與姓名相關資料
            try
            {
                if (cboName.Text == "" || cboUser.Text == "")
                {
                    return;
                }
                string strSQL = $@"select *
                                    from   tel
                                    where  tel_username = '{cboUser.Text.Trim()}'
                                           and tel_name = '{cboName.Text.Trim()}' ";
                DataTable dt = clsDB.sql_select_dt(strSQL);
                if (dt.Rows.Count > 0)
                {
                    cboType.Text = dt.Rows[0]["tel_type"].ToString();         //分類
                                                                              //cboName.Text = "";              //姓名
                    txtCellphone_TW.Text = dt.Rows[0]["tel_twphone"].ToString();      //台灣手機
                    txtCompany_TW.Text = dt.Rows[0]["tel_twfax"].ToString();       //台灣公司電話
                    txtHome_TW.Text = dt.Rows[0]["tel_twmobile"].ToString();           //台灣住家電話
                    txtAddress_TW.Text = dt.Rows[0]["tel_twaddress"].ToString();        //台灣地址
                    txtCellphone_CN.Text = dt.Rows[0]["tel_dlphone"].ToString();      //大陸手機
                    txtCompany_CN.Text = dt.Rows[0]["tel_dlfax"].ToString();        //大陸公司電話
                    txtHome_CN.Text = dt.Rows[0]["tel_dlmobile"].ToString();          //大陸住家電話
                    txtAddress_CN.Text = dt.Rows[0]["tel_dladdress"].ToString();        //台大陸地址
                    txtNote.Text = dt.Rows[0]["tel_bz"].ToString();              //備註
                    txtEmail_TW.Text = dt.Rows[0]["tel_twemail"].ToString();          //台灣e-mail
                    txtEmail_CN.Text = dt.Rows[0]["tel_dlemail"].ToString();          //大陸e-mail
                }
                else
                {
                    if (MessageBox.Show(this, "沒有找到這個姓名的電話簿,要創建嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        cboName.Text = "";              //姓名
                    }
                    cboType.Text = "(ALL)";         //分類

                    txtCellphone_TW.Text = "";      //台灣手機
                    txtCompany_TW.Text = "";        //台灣公司電話
                    txtHome_TW.Text = "";           //台灣住家電話
                    txtAddress_TW.Text = "";        //台灣地址
                    txtCellphone_CN.Text = "";      //大陸手機
                    txtCompany_CN.Text = "";        //大陸公司電話
                    txtHome_CN.Text = "";           //大陸住家電話
                    txtAddress_CN.Text = "";        //台大陸地址
                    txtNote.Text = "";              //備註
                    txtEmail_TW.Text = "";          //台灣e-mail
                    txtEmail_CN.Text = "";          //大陸e-mail
                }
                txtCellphone_TW.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-cboName_SelectedIndexChanged" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
