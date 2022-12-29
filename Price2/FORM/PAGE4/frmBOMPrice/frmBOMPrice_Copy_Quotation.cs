using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Price2
{
    public partial class frmBOMPrice_Copy_Quotation : Form
    {
        public static string rstrID = "";  //由frmBOMPrice傳的ID
        public frmBOMPrice_Copy_Quotation()
        {
            InitializeComponent();
        }

        private void frmBOMPrice_Copy_Quotation_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                lblOldID.Text = rstrID;
                txtID.Text = rstrID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmBOMPrice_Special_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)    //取消
        {
            //取消
            try
            {
                frmBOMPrice.rstrButton = "Cancle";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnCancel_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)    //確認
        {
            //確認
            try
            {
                if(txtID.Text=="")
                {
                    return;
                }
                if (txtID.Text != lblOldID.Text)
                {
                    string strSQL = "";
                    DataTable dt = new DataTable();
                    strSQL = $@"select pri_customerid
                                from   pri
                                where  pri_customerid = '{txtID.Text.Trim()}'
                                       and pri_newcostchk like 'N%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if(dt.Rows.Count == 0)
                    {
                        strSQL = $@"delete from ptx
                                    where  ptx_customerid = '{txtID.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"delete from pmd
                                    where  pmd_customerid = '{txtID.Text.Trim()}' ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"insert into ptx
                                                (ptx_name,
                                                    ptx_tbdj,
                                                    ptx_qty,
                                                    ptx_aircost,
                                                    ptx_kd,
                                                    ptx_perqty,
                                                    ptx_perweight,
                                                    ptx_perky,
                                                    ptx_yfcurrency,
                                                    ptx_vendorid,
                                                    ptx_adddate,
                                                    ptx_customerid,
                                                    ptx_tbdjcal,
                                                    ptx_venshortname,
                                                    ptx_type,
                                                    ptx_assy)
                                    select ptx_name,
                                            ptx_tbdj,
                                            ptx_qty,
                                            ptx_aircost,
                                            ptx_kd,
                                            ptx_perqty,
                                            ptx_perweight,
                                            ptx_perky,
                                            ptx_yfcurrency,
                                            ptx_vendorid,
                                            ptx_adddate,
                                            '{txtID.Text.Trim()}',
                                            ptx_tbdjcal,
                                            ptx_venshortname,
                                            ptx_type,
                                            ptx_assy
                                    from   ptx
                                    where  ptx_customerid = '{lblOldID.Text}'
                                            and ptx_name in (select pri_part
                                                            from   pri
                                                            where  pri_customerid = '{lblOldID.Text}') ";
                        clsDB.Execute(strSQL);
                        strSQL = $@"insert into pmd
                                    select '{lblOldID.Text}',
                                           pmd_price,
                                           pmd_currency,
                                           pmd_qty,
                                           pmd_returnqty,
                                           pmd_adddate
                                    from   pmd
                                    where  pmd_customerid = '{lblOldID.Text}' ";
                        clsDB.Execute(strSQL);
                        if(chkCZF.Checked)
                        {
                            strSQL = $@"delete from odi
                                        where  odi_customerid = '{txtID.Text.Trim()}' ";
                            clsDB.Execute(strSQL);
                            strSQL = $@"insert into odi
                                        select '{txtID.Text.Trim()}',
                                               odi_price,
                                               odi_czf,
                                               odi_czf1,
                                               odi_line,
                                               odi_currency,
                                               odi_customer,
                                               odi_czftotal,
                                               odi_clcost,
                                               odi_convprice,
                                               0,
                                               0,
                                               0,
                                               0,
                                               odi_pricost,
                                               odi_mo,
                                               odi_czfpi,
                                               odi_adddate,
                                               0,
                                               odi_type,
                                               odi_wg,
                                               odi_vendorid,
                                               odi_oldll,
                                               odi_username,
                                               odi_gp,
                                               odi_gc,
                                               odi_active,
                                               odi_cjuser,
                                               odi_cjadddate1,
                                               odi_cjadddate,
                                               odi_convcost,
                                               odi_wgtype,
                                               odi_confirmflag,
                                               odi_pripart01,
                                               odi_pripart02,
                                               odi_pripart03,
                                               odi_pripart04,
                                               odi_priqty01,
                                               odi_priqty02,
                                               odi_priqty03,
                                               odi_priqty04,
                                               odi_pripart05,
                                               odi_priqty05,
                                               odi_oldpart01,
                                               odi_oldpart02,
                                               odi_oldpart03,
                                               odi_oldpart05,
                                               odi_oldpart06,
                                               odi_pripart06,
                                               odi_priqty06,
                                               odi_adddate1,
                                               odi_username1
                                        from   odi
                                        where  odi_customerid = '{lblOldID.Text}' ";
                            clsDB.Execute(strSQL);
                        }
                    }
                    else
                    {
                        //確認權限
                        if (clsGlobal.checkRightFlag("報價單複製覆蓋權限") == false )
                        {
                            MessageBox.Show("此客號已存在,您沒有權限覆蓋,請重新輸入!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            if (MessageBox.Show("此客號已存在,您要覆蓋嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                            strSQL = $@"delete from ptx
                                    where  ptx_customerid = '{txtID.Text.Trim()}' ";
                            clsDB.Execute(strSQL);
                            strSQL = $@"delete from pmd
                                    where  pmd_customerid = '{txtID.Text.Trim()}' ";
                            clsDB.Execute(strSQL);
                            strSQL = $@"insert into ptx
                                                (ptx_name,
                                                    ptx_tbdj,
                                                    ptx_qty,
                                                    ptx_aircost,
                                                    ptx_kd,
                                                    ptx_perqty,
                                                    ptx_perweight,
                                                    ptx_perky,
                                                    ptx_yfcurrency,
                                                    ptx_vendorid,
                                                    ptx_adddate,
                                                    ptx_customerid,
                                                    ptx_tbdjcal,
                                                    ptx_venshortname,
                                                    ptx_type,
                                                    ptx_assy)
                                    select ptx_name,
                                            ptx_tbdj,
                                            ptx_qty,
                                            ptx_aircost,
                                            ptx_kd,
                                            ptx_perqty,
                                            ptx_perweight,
                                            ptx_perky,
                                            ptx_yfcurrency,
                                            ptx_vendorid,
                                            ptx_adddate,
                                            '{txtID.Text.Trim()}',
                                            ptx_tbdjcal,
                                            ptx_venshortname,
                                            ptx_type,
                                            ptx_assy
                                    from   ptx
                                    where  ptx_customerid = '{lblOldID.Text}'
                                            and ptx_name in (select pri_part
                                                            from   pri
                                                            where  pri_customerid = '{lblOldID.Text}') ";
                            clsDB.Execute(strSQL);
                            strSQL = $@"insert into pmd
                                    select '{lblOldID.Text}',
                                           pmd_price,
                                           pmd_currency,
                                           pmd_qty,
                                           pmd_returnqty,
                                           pmd_adddate
                                    from   pmd
                                    where  pmd_customerid = '{lblOldID.Text}' ";
                            clsDB.Execute(strSQL);
                            if (chkCZF.Checked)
                            {
                                strSQL = $@"delete from odi
                                        where  odi_customerid = '{txtID.Text.Trim()}' ";
                                clsDB.Execute(strSQL);
                                strSQL = $@"insert into odi
                                        select '{txtID.Text.Trim()}',
                                               odi_price,
                                               odi_czf,
                                               odi_czf1,
                                               odi_line,
                                               odi_currency,
                                               odi_customer,
                                               odi_czftotal,
                                               odi_clcost,
                                               odi_convprice,
                                               0,
                                               0,
                                               0,
                                               0,
                                               odi_pricost,
                                               odi_mo,
                                               odi_czfpi,
                                               odi_adddate,
                                               0,
                                               odi_type,
                                               odi_wg,
                                               odi_vendorid,
                                               odi_oldll,
                                               odi_username,
                                               odi_gp,
                                               odi_gc,
                                               odi_active,
                                               odi_cjuser,
                                               odi_cjadddate1,
                                               odi_cjadddate,
                                               odi_convcost,
                                               odi_wgtype,
                                               odi_confirmflag,
                                               odi_pripart01,
                                               odi_pripart02,
                                               odi_pripart03,
                                               odi_pripart04,
                                               odi_priqty01,
                                               odi_priqty02,
                                               odi_priqty03,
                                               odi_priqty04,
                                               odi_pripart05,
                                               odi_priqty05,
                                               odi_oldpart01,
                                               odi_oldpart02,
                                               odi_oldpart03,
                                               odi_oldpart05,
                                               odi_oldpart06,
                                               odi_pripart06,
                                               odi_priqty06,
                                               odi_adddate1,
                                               odi_username1
                                        from   odi
                                        where  odi_customerid = '{lblOldID.Text}' ";
                                clsDB.Execute(strSQL);
                            }
                            else
                            {
                                strSQL = $@"update odi
                                            set    odi_username = '{clsGlobal.strG_User}',
                                                   odi_adddate = '{DateTime.Now.ToString("yyyy/MM/dd")}',
                                                   odi_pripart01 = '',
                                                   odi_pripart02 = '',
                                                   odi_pripart04 = '',
                                                   odi_priqty01 = 0,
                                                   odi_priqty02 = 0,
                                                   odi_priqty04 = 0,
                                                   odi_pripart05 = '',
                                                   odi_priqty05 = 0,
                                                   odi_oldpart01 = '',
                                                   odi_oldpart02 = '',
                                                   odi_oldpart03 = '',
                                                   odi_oldpart05 = ''
                                            from   odi
                                            where  odi_customerid = '{txtID.Text.Trim()}' ";
                                clsDB.Execute(strSQL);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("客號不可相同,請重新輸入.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Focus();
                    return;
                }
                frmBOMPrice.rstrID = txtID.Text;
                frmBOMPrice.rstrButton = "OK";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnOK_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
