using Sunny.UI.Win32;
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
    public partial class frmTaxRate : Form
    {
        string[] strRP = new string[20];
        public frmTaxRate()
        {
            InitializeComponent();
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

        private void frmTaxRate_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmTaxRate_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getData()
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            strSQL = $@"select Isnull(pub_tax, 0)    'pub_tax',
                               Isnull(pub_vntax, 0)  'pub_vntax',
                               Isnull(pub_tax1, 0)   'pub_tax1',
                               Isnull(pub_vntax1, 0) 'pub_vntax1'
                        from   pub ";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                txtCN_Tax.Text = dt.Rows[0]["pub_tax"].ToString();
                strRP[1] = dt.Rows[0]["pub_tax"].ToString();
                txtVN_Tax.Text = dt.Rows[0]["pub_vntax"].ToString();
                strRP[2] = dt.Rows[0]["pub_vntax"].ToString();
                txtCN_Untaxed.Text = dt.Rows[0]["pub_tax1"].ToString();
                strRP[3] = dt.Rows[0]["pub_tax1"].ToString();
                txtVN_Untaxed.Text = dt.Rows[0]["pub_vntax1"].ToString();
                strRP[4] = dt.Rows[0]["pub_vntax1"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                string taxchk = "XXXX";
                string oldtax = "";
                string newtax = "";
                string strSQL = "";
                DataTable dt = new DataTable();

                if (txtCN_Tax.Text=="" || txtVN_Tax.Text == "")
                {
                    MessageBox.Show("稅率不可空白!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                if (MessageBox.Show("確定要變更嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                //檢查中國國稅稅價是否有改變
                if (txtCN_Tax.Text != strRP[1])
                {
                    taxchk = "VXXX";
                    oldtax = strRP[1];
                    newtax = txtCN_Tax.Text;
                    strSQL = $@"update pub set pub_tax = '{newtax}";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update asp
                                set    asp_pricecal = Replace(asp_pricecal, '{oldtax}', '{newtax}')
                                from   asp
                                where  asp_currency = '人民幣'
                                       and asp_pricecal like '%/{oldtax}%' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update aspnum
                                set    aspnum_pricecal = Replace(aspnum_pricecal, '{oldtax}', '{newtax}')
                                from   aspnum
                                where  aspnum_currency = '人民幣'
                                       and aspnum_pricecal like '%/{oldtax}%' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update ptx
                                set    ptx_tbdjcal = Replace(ptx_tbdjcal, '{oldtax}', '{newtax}')
                                from   ptx
                                where  ptx_yfcurrency = '人民幣'
                                       and ptx_tbdjcal like '%/{oldtax}%' ";
                    clsDB.Execute(strSQL);

                    //先更新特選
                    strSQL = $@"select ptx_customerid,
                                       ptx_name,
                                       ptx_tbdjcal
                                from   ptx
                                where  ptx_yfcurrency = '人民幣'
                                       and ptx_tbdjcal like '%/{newtax}%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count>0)
                    {
                        for(int i =0;i<dt.Rows.Count;i++)
                        {
                            strSQL = $@"update ptx
                                        set    ptx_tbdj=ROUND({dt.Rows[i]["ptx_tbdjcal"].ToString()},6)
                                        from ptx
                                        where ptx_customerid = '{dt.Rows[i]["ptx_customerid"].ToString()}'
                                        and ptx_name = '{dt.Rows[i]["ptx_name"].ToString()}' ";
                            clsDB.Execute(strSQL);
                        }
                    }

                    //再更新內層aspnum
                    strSQL = $@"select aspnum_id,
                                       aspnum_num,
                                       aspnum_pricecal
                                from   aspnum
                                where  aspnum_currency = '人民幣'
                                       and aspnum_pricecal like '%/{newtax}%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strSQL = $@"update aspnum
                                        set    aspnum_price = Round({dt.Rows[i]["aspnum_pricecal"].ToString()}, 6)
                                        from   aspnum
                                        where  aspnum_id = '{dt.Rows[i]["aspnum_id"].ToString()}'
                                               and aspnum_num = '{dt.Rows[i]["aspnum_num"].ToString()}' ";
                            clsDB.Execute(strSQL);
                        }
                    }

                    //再更新asp
                    strSQL = $@"select asp_id,
                                       asp_pricecal
                                from   asp
                                where  asp_currency = '人民幣'
                                and    asp_pricecal like '%/{newtax}%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strSQL = $@"update asp
                                        set    asp_purprice = Round({dt.Rows[i]["asp_pricecal"].ToString()}, 6)
                                        from   asp
                                        where  asp_id = '{dt.Rows[i]["asp_id"].ToString()}'  ";
                            clsDB.Execute(strSQL);
                        }
                    }
                }

                //檢查中國國稅未稅價是否有改變
                if (txtCN_Untaxed.Text != strRP[3])
                {
                    taxchk = taxchk.Substring(0, 1) + "V" + taxchk.Substring(taxchk.Length - 2, 2);
                    oldtax = strRP[3];
                    newtax = txtCN_Untaxed.Text;
                    strSQL = $@"update pub set pub_tax = '{newtax}";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update asp
                                set    asp_pricecal = Replace(asp_pricecal, '{oldtax}', '{newtax}')
                                from   asp
                                where  asp_currency = '人民幣'
                                       and asp_pricecal like '%/{oldtax}%' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update aspnum
                                set    aspnum_pricecal = Replace(aspnum_pricecal, '{oldtax}', '{newtax}')
                                from   aspnum
                                where  aspnum_currency = '人民幣'
                                       and aspnum_pricecal like '%/{oldtax}%' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update ptx
                                set    ptx_tbdjcal = Replace(ptx_tbdjcal, '{oldtax}', '{newtax}')
                                from   ptx
                                where  ptx_yfcurrency = '人民幣'
                                       and ptx_tbdjcal like '%/{oldtax}%' ";
                    clsDB.Execute(strSQL);

                    //先更新特選
                    strSQL = $@"select ptx_customerid,
                                       ptx_name,
                                       ptx_tbdjcal
                                from   ptx
                                where  ptx_yfcurrency = '人民幣'
                                       and ptx_tbdjcal like '%/{newtax}%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strSQL = $@"update ptx
                                        set    ptx_tbdj=ROUND({dt.Rows[i]["ptx_tbdjcal"].ToString()},6)
                                        from ptx
                                        where ptx_customerid = '{dt.Rows[i]["ptx_customerid"].ToString()}'
                                        and ptx_name = '{dt.Rows[i]["ptx_name"].ToString()}' ";
                            clsDB.Execute(strSQL);
                        }
                    }

                    //再更新內層aspnum
                    strSQL = $@"select aspnum_id,
                                       aspnum_num,
                                       aspnum_pricecal
                                from   aspnum
                                where  aspnum_currency = '人民幣'
                                       and aspnum_pricecal like '%/{newtax}%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strSQL = $@"update aspnum
                                        set    aspnum_price = Round({dt.Rows[i]["aspnum_pricecal"].ToString()}, 6)
                                        from   aspnum
                                        where  aspnum_id = '{dt.Rows[i]["aspnum_id"].ToString()}'
                                               and aspnum_num = '{dt.Rows[i]["aspnum_num"].ToString()}' ";
                            clsDB.Execute(strSQL);
                        }
                    }

                    //再更新asp
                    strSQL = $@"select asp_id,
                                       asp_pricecal
                                from   asp
                                where  asp_currency = '人民幣'
                                and    asp_pricecal like '%/{newtax}%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strSQL = $@"update asp
                                        set    asp_purprice = Round({dt.Rows[i]["asp_pricecal"].ToString()}, 6)
                                        from   asp
                                        where  asp_id = '{dt.Rows[i]["asp_id"].ToString()}'  ";
                            clsDB.Execute(strSQL);
                        }
                    }
                }

                //檢查越南國稅稅價是否有改變
                if (txtVN_Tax.Text != strRP[2])
                {
                    taxchk = taxchk.Substring(0, 2) + "V" + taxchk.Substring(taxchk.Length - 1, 1);
                    oldtax = strRP[2];
                    newtax = txtVN_Tax.Text;
                    strSQL = $@"update pub set pub_tax = '{newtax}";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update asp
                                set    asp_pricecal = Replace(asp_pricecal, '{oldtax}', '{newtax}')
                                from   asp
                                where  asp_currency = '越南盾'
                                       and asp_pricecal like '%/{oldtax}%' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update aspnum
                                set    aspnum_pricecal = Replace(aspnum_pricecal, '{oldtax}', '{newtax}')
                                from   aspnum
                                where  aspnum_currency = '越南盾'
                                       and aspnum_pricecal like '%/{oldtax}%' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update ptx
                                set    ptx_tbdjcal = Replace(ptx_tbdjcal, '{oldtax}', '{newtax}')
                                from   ptx
                                where  ptx_yfcurrency = '越南盾'
                                       and ptx_tbdjcal like '%/{oldtax}%' ";
                    clsDB.Execute(strSQL);

                    //先更新特選
                    strSQL = $@"select ptx_customerid,
                                       ptx_name,
                                       ptx_tbdjcal
                                from   ptx
                                where  ptx_yfcurrency = '越南盾'
                                       and ptx_tbdjcal like '%/{newtax}%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strSQL = $@"update ptx
                                        set    ptx_tbdj=ROUND({dt.Rows[i]["ptx_tbdjcal"].ToString()},6)
                                        from ptx
                                        where ptx_customerid = '{dt.Rows[i]["ptx_customerid"].ToString()}'
                                        and ptx_name = '{dt.Rows[i]["ptx_name"].ToString()}' ";
                            clsDB.Execute(strSQL);
                        }
                    }

                    //再更新內層aspnum
                    strSQL = $@"select aspnum_id,
                                       aspnum_num,
                                       aspnum_pricecal
                                from   aspnum
                                where  aspnum_currency = '越南盾'
                                       and aspnum_pricecal like '%/{newtax}%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strSQL = $@"update aspnum
                                        set    aspnum_price = Round({dt.Rows[i]["aspnum_pricecal"].ToString()}, 6)
                                        from   aspnum
                                        where  aspnum_id = '{dt.Rows[i]["aspnum_id"].ToString()}'
                                               and aspnum_num = '{dt.Rows[i]["aspnum_num"].ToString()}' ";
                            clsDB.Execute(strSQL);
                        }
                    }

                    //再更新asp
                    strSQL = $@"select asp_id,
                                       asp_pricecal
                                from   asp
                                where  asp_currency = '越南盾'
                                and    asp_pricecal like '%/{newtax}%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strSQL = $@"update asp
                                        set    asp_purprice = Round({dt.Rows[i]["asp_pricecal"].ToString()}, 6)
                                        from   asp
                                        where  asp_id = '{dt.Rows[i]["asp_id"].ToString()}'  ";
                            clsDB.Execute(strSQL);
                        }
                    }
                }

                //檢查中國國稅稅價是否有改變
                if (txtVN_Untaxed.Text != strRP[4])
                {
                    taxchk = taxchk.Substring(0, 3) + "V";
                    oldtax = strRP[4];
                    newtax = txtVN_Untaxed.Text;
                    strSQL = $@"update pub set pub_tax = '{newtax}";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update asp
                                set    asp_pricecal = Replace(asp_pricecal, '{oldtax}', '{newtax}')
                                from   asp
                                where  asp_currency = '越南盾'
                                       and asp_pricecal like '%/{oldtax}%' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update aspnum
                                set    aspnum_pricecal = Replace(aspnum_pricecal, '{oldtax}', '{newtax}')
                                from   aspnum
                                where  aspnum_currency = '越南盾'
                                       and aspnum_pricecal like '%/{oldtax}%' ";
                    clsDB.Execute(strSQL);

                    strSQL = $@"update ptx
                                set    ptx_tbdjcal = Replace(ptx_tbdjcal, '{oldtax}', '{newtax}')
                                from   ptx
                                where  ptx_yfcurrency = '越南盾'
                                       and ptx_tbdjcal like '%/{oldtax}%' ";
                    clsDB.Execute(strSQL);

                    //先更新特選
                    strSQL = $@"select ptx_customerid,
                                       ptx_name,
                                       ptx_tbdjcal
                                from   ptx
                                where  ptx_yfcurrency = '越南盾'
                                       and ptx_tbdjcal like '%/{newtax}%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strSQL = $@"update ptx
                                        set    ptx_tbdj=ROUND({dt.Rows[i]["ptx_tbdjcal"].ToString()},6)
                                        from ptx
                                        where ptx_customerid = '{dt.Rows[i]["ptx_customerid"].ToString()}'
                                        and ptx_name = '{dt.Rows[i]["ptx_name"].ToString()}' ";
                            clsDB.Execute(strSQL);
                        }
                    }

                    //再更新內層aspnum
                    strSQL = $@"select aspnum_id,
                                       aspnum_num,
                                       aspnum_pricecal
                                from   aspnum
                                where  aspnum_currency = '越南盾'
                                       and aspnum_pricecal like '%/{newtax}%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strSQL = $@"update aspnum
                                        set    aspnum_price = Round({dt.Rows[i]["aspnum_pricecal"].ToString()}, 6)
                                        from   aspnum
                                        where  aspnum_id = '{dt.Rows[i]["aspnum_id"].ToString()}'
                                               and aspnum_num = '{dt.Rows[i]["aspnum_num"].ToString()}' ";
                            clsDB.Execute(strSQL);
                        }
                    }

                    //再更新asp
                    strSQL = $@"select asp_id,
                                       asp_pricecal
                                from   asp
                                where  asp_currency = '越南盾'
                                and    asp_pricecal like '%/{newtax}%' ";
                    dt = clsDB.sql_select_dt(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strSQL = $@"update asp
                                        set    asp_purprice = Round({dt.Rows[i]["asp_pricecal"].ToString()}, 6)
                                        from   asp
                                        where  asp_id = '{dt.Rows[i]["asp_id"].ToString()}'  ";
                            clsDB.Execute(strSQL);
                        }
                    }

                }

                string msgstr = "";
                if (taxchk.Substring(0, 1) == "V")
                {
                    msgstr = "中國國稅稅價變動";
                }
                if (taxchk.Substring(0, 1) == "V")
                {
                    msgstr = msgstr + "\n" + "中國國稅未稅價變動";
                }
                if (taxchk.Substring(0, 1) == "V")
                {
                    msgstr = msgstr + "\n" + "越南國稅稅價變動";
                }
                if (taxchk.Substring(0, 1) == "V")
                {
                    msgstr = msgstr + "\n" + "越南國稅未稅價變動";
                }

                if (taxchk != "XXXX")
                {
                    strSQL = $@"exec  serverupdate ";
                    clsDB.Execute(strSQL);
                    strSQL = $@"exec  updatepriclcost ";
                    clsDB.Execute(strSQL);
                    MessageBox.Show("變動完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
