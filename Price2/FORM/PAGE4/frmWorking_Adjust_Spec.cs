using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Price2
{
    public partial class frmWorking_Adjust_Spec : Form
    {
        public static string rstrItem = "";   //傳來的項目
        public static string rstrLine = "";   //傳來的線路
        string strType = "";
        public frmWorking_Adjust_Spec()
        {
            InitializeComponent();
        }

        private void frmWorking_Adjust_Spec_Load(object sender, EventArgs e)
        {
            //要加入初始化的東西
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                if (rstrItem == "加工/分")
                {
                    panel_def.Visible = false;
                    panel.Visible = true;
                    if (rstrLine.Substring(0, 1) == "F")
                    {
                        strType = "電源線";
                    }
                    else if (rstrLine.Substring(0, 1) == "8")
                    {
                        if (rstrLine.Substring(0, 2) == "8L" || rstrLine.Substring(0, 2) == "8M")
                        {
                            strType = "光纖線";
                        }
                        else
                        {
                            strType = "網路線";
                        }
                    }
                    else
                    {
                        strType = "電腦線";
                    }
                    groupBox.Text = strType+ rstrItem+"表";
                    dgvData.Columns["def_id"].HeaderText = "產品規格";
                    dgvData.Columns["def_qty"].HeaderText = rstrItem;
                }
                else
                {
                    panel_def.Visible = true;
                    panel.Visible = false;
                    strType = "不良率";
                    groupBox.Text = strType  + "表";
                    dgvData.Columns["def_id"].HeaderText = "產品規格";
                    dgvData.Columns["def_qty"].HeaderText = rstrItem;
                }
                strSQL = $@"select def_id,def_qty from defect where def_type like '%{strType}%'";
                dt = clsDB.sql_select_dt(strSQL);
                if(dt.Rows.Count>0)
                {
                    dgvData.Rows.Clear();
                    for(int i =0; i<dt.Rows.Count; i++)
                    {
                        dgvData.Rows.Add();
                        dgvData.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                        dgvData.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-frmWorking_Adjust_Spec_Load" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cboItem_TextChanged(object sender, EventArgs e)
        {
            string strSQL = "";
            DataTable dt = new DataTable();
            groupBox.Text = cboItem.Text + rstrItem + "表";
            strSQL = $@"select def_id,def_qty from defect where def_type like '%{cboItem.Text}%'";
            dt = clsDB.sql_select_dt(strSQL);
            if (dt.Rows.Count > 0)
            {
                //dgvData.DataSource = dt;
                dgvData.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvData.Rows.Add();
                    dgvData.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dgvData.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存
            try
            {
                string strSQL = "";
                DataTable dt = new DataTable();
                if (MessageBox.Show("你確定要儲存嗎?", "Check", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;//滑鼠漏斗指標
                
                if (rstrItem == "加工/分")
                {
                    strSQL = $@"delete from defect where def_type = '{cboItem.Text}{rstrItem}' ";
                    for(int i=0; i <dgvData.Rows.Count-1; i++)
                    {
                        strSQL = $@"insert defect(def_id, def_qty, def_type) values('{dgvData.Rows[i].Cells[0].Value.ToString()}', '{dgvData.Rows[i].Cells[1].Value.ToString()}', '{cboItem.Text}{rstrItem}')";
                    }
                }
                else
                {
                    strSQL = $@"delete from defect where def_type = '{rstrItem}' ";
                    for (int i = 0; i < dgvData.Rows.Count - 1; i++)
                    {
                        strSQL = $@"insert defect(def_id, def_qty, def_type) values('{dgvData.Rows[i].Cells[0].Value.ToString()}', '{dgvData.Rows[i].Cells[1].Value.ToString()}', '{rstrItem}')";
                    }
                }
                MessageBox.Show("儲存完成!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;//滑鼠還原預設
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;//滑鼠還原預設
                MessageBox.Show(this.Name + "-btnSave_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //導出
            try
            {
                Boolean chkFlag = false;
                string tmp="";
                string[] tmp1;
                string[] tmp2;
                string tsql1="";
                string tsql33="";
                string tx1 ="";
                string tx2 ="";
                string tx1F = "";
                string tx1M = "";
                string tx1I = "";
                string tx2F = "";
                string tx2M = "";
                string tx2I = "";
                if (rstrItem == "加工/分")
                {
                    if (dgvData.CurrentRow.Index < 0)
                    {
                        MessageBox.Show("請選擇條件!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        if (dgvData.Rows[dgvData.CurrentRow.Index].Cells[0].Value.ToString() == ""
                        || dgvData.Rows[dgvData.CurrentRow.Index].Cells[1].Value.ToString() == "")
                        {
                            MessageBox.Show("請選擇條件!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    tmp = dgvData.Rows[dgvData.CurrentRow.Index].Cells[0].Value.ToString();
                    if (tmp.IndexOf("＞") >= 0)//x大於某個線長時
                    {
                        tmp1 = tmp.Split('＞');
                        if(tmp1.Length<3)//x大於某個線長時,x>a
                        {
                            tx1 = tmp1[1].Substring(0, tmp1[1].Length-1);
                            tx1F =(Convert.ToSingle( tx1) / 3.28084).ToString("0.###");
                            tx1M = (Convert.ToSingle(tx1) / 1).ToString("0.###");
                            tx1I = (Convert.ToSingle(tx1) / 39.37008).ToString("0.###");
                            if (tmp1[1].Substring(tmp1[1].Length - 1, 1) == "M")
                            {
                                tx1F = (Convert.ToSingle(tx1) / 3.28084).ToString("0.###");
                                tx1M = (Convert.ToSingle(tx1) / 1).ToString("0.###");
                                tx1I = (Convert.ToSingle(tx1) / 39.37008).ToString("0.###");
                                tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) > {tx1F} )) 
                                            or ((right(pri_length, 1) = 'M')  and (cast(left(pri_length, len(pri_length)-1) as float) > {tx1M} )) 
                                            or ((right(pri_length, 1) = 'I')  and (cast(left(pri_length, len(pri_length)-1) as float) > {tx1I} ))) ";
                                tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx1F} )) 
                                             or ((right(aa.pri_length, 1)= 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx1M} )) 
                                             or ((right(aa.pri_length, 1)= 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx1I} ))) ";
                            }
                            else
                            {
                                tx1F = (Convert.ToSingle(tx1) * 1).ToString("0.###");
                                tx1M = (Convert.ToSingle(tx1) * 0.3048).ToString("0.###");
                                tx1I = (Convert.ToSingle(tx1) * 12).ToString("0.###");
                                tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) > {tx1F} )) 
                                            or ((right(pri_length, 1) = 'M')  and (cast(left(pri_length, len(pri_length)-1) as float) > {tx1M} )) 
                                            or ((right(pri_length, 1) = 'I')  and (cast(left(pri_length, len(pri_length)-1) as float) > {tx1I} ))) ";
                                tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx1F} )) 
                                             or ((right(aa.pri_length, 1)= 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx1M} )) 
                                             or ((right(aa.pri_length, 1)= 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx1I} ))) ";
                            }
                            chkFlag = true;
                        }
                        else//x大於某個線長時,a>x>b
                        {
                            tmp1 = tmp.Split('＞');
                            tx2 = tmp1[2].Substring(0, tmp1[2].Length - 1);
                            tx1 = tmp1[0].Substring(0, tmp1[0].Length - 1);
                            if (tmp1[2].Substring(tmp1[1].Length - 1, 1) == "M")
                            {
                                tx1F = (Convert.ToSingle(tx1) / 3.28084).ToString("0.###");
                                tx1M = (Convert.ToSingle(tx1) / 1).ToString("0.###");
                                tx1I = (Convert.ToSingle(tx1) / 39.37008).ToString("0.###");
                                tx2F = (Convert.ToSingle(tx2) / 3.28084).ToString("0.###");
                                tx2M = (Convert.ToSingle(tx2) / 1).ToString("0.###");
                                tx2I = (Convert.ToSingle(tx2) / 39.37008).ToString("0.###");
                                tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) > {tx2F}) and (cast(left(pri_length, len(pri_length)-1) as float) < {tx1F})) 
                                            or ((right(pri_length, 1) = 'M') and (cast(left(pri_length, len(pri_length)-1) as float) > {tx2M}) and (cast(left(pri_length, len(pri_length)-1) as float) < {tx1M})) 
                                            or ((right(pri_length, 1) = 'I') and (cast(left(pri_length, len(pri_length)-1) as float) > {tx2I}) and (cast(left(pri_length, len(pri_length)-1) as float) < {tx1I}))) ";
                                tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx2F}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx1F})) 
                                             or ((right(aa.pri_length, 1)= 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx2M}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx1M})) 
                                             or ((right(aa.pri_length, 1)= 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx2I}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx1I}))) ";
                            }
                            else
                            {
                                tx1F = (Convert.ToSingle(tx1) * 1).ToString("0.###");
                                tx1M = (Convert.ToSingle(tx1) * 0.3048).ToString("0.###");
                                tx1I = (Convert.ToSingle(tx1) * 12).ToString("0.###");
                                tx2F = (Convert.ToSingle(tx2) * 1).ToString("0.###");
                                tx2M = (Convert.ToSingle(tx2) * 0.3048).ToString("0.###");
                                tx2I = (Convert.ToSingle(tx2) * 12).ToString("0.###");
                                tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) > {tx2F}) and (cast(left(pri_length, len(pri_length)-1) as float) < {tx1F})) 
                                            or ((right(pri_length, 1) = 'M') and (cast(left(pri_length, len(pri_length)-1) as float) > {tx2M}) and (cast(left(pri_length, len(pri_length)-1) as float) < {tx1M})) 
                                            or ((right(pri_length, 1) = 'I') and (cast(left(pri_length, len(pri_length)-1) as float) > {tx2I}) and (cast(left(pri_length, len(pri_length)-1) as float) < {tx1I}))) ";
                                tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx2F}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx1F})) 
                                             or ((right(aa.pri_length, 1)= 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx2M}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx1M})) 
                                             or ((right(aa.pri_length, 1)= 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx2I}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx1I}))) ";
                            }
                            chkFlag = true;
                        }
                    }
                    else if(tmp.IndexOf("≦") >= 0)
                    {
                        if (tmp.IndexOf("＜") >= 0 && tmp.IndexOf("＜") < tmp.IndexOf("≦"))//X介於二個線長之間時,a<x≦b
                        {
                            tmp1 = tmp.Split('≦');
                            tx2 = tmp1[1].Substring(0, tmp1[1].Length - 1);
                            tmp2 = tmp1[0].Split('＜');
                            tx1 = tmp2[0].Substring(0, tmp2[0].Length - 1);
                            if (tmp1[1].Substring(tmp1[1].Length - 1, 1) == "M")
                            {
                                tx1F = (Convert.ToSingle(tx1) / 3.28084).ToString("0.###");
                                tx1M = (Convert.ToSingle(tx1) / 1).ToString("0.###");
                                tx1I = (Convert.ToSingle(tx1) / 39.37008).ToString("0.###");
                                tx2F = (Convert.ToSingle(tx2) / 3.28084).ToString("0.###");
                                tx2M = (Convert.ToSingle(tx2) / 1).ToString("0.###");
                                tx2I = (Convert.ToSingle(tx2) / 39.37008).ToString("0.###");
                                tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2F}) and (cast(left(pri_length, len(pri_length)-1) as float) > {tx1F}))
                                            or ((right(pri_length, 1) = 'M') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2M}) and (cast(left(pri_length, len(pri_length)-1) as float) > {tx1M})) 
                                            or ((right(pri_length, 1) = 'I') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2I}) and (cast(left(pri_length, len(pri_length)-1) as float) > {tx1I}))) ";
                                tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2F}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx1F})) 
                                             or ((right(aa.pri_length, 1) = 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2M}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx1M})) 
                                             or ((right(aa.pri_length, 1) = 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2I}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx1I}))) ";
                            }
                            else
                            {
                                tx1F = (Convert.ToSingle(tx1) * 1).ToString("0.###");
                                tx1M = (Convert.ToSingle(tx1) * 0.3048).ToString("0.###");
                                tx1I = (Convert.ToSingle(tx1) * 12).ToString("0.###");
                                tx2F = (Convert.ToSingle(tx2) * 1).ToString("0.###");
                                tx2M = (Convert.ToSingle(tx2) * 0.3048).ToString("0.###");
                                tx2I = (Convert.ToSingle(tx2) * 12).ToString("0.###");
                                tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2F}) and (cast(left(pri_length, len(pri_length)-1) as float) > {tx1F}))
                                            or ((right(pri_length, 1) = 'M') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2M}) and (cast(left(pri_length, len(pri_length)-1) as float) > {tx1M})) 
                                            or ((right(pri_length, 1) = 'I') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2I}) and (cast(left(pri_length, len(pri_length)-1) as float) > {tx1I}))) ";
                                tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2F}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx1F})) 
                                             or ((right(aa.pri_length, 1) = 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2M}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx1M})) 
                                             or ((right(aa.pri_length, 1) = 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2I}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) > {tx1I}))) ";
                            }
                            chkFlag = true;
                        }
                        else if (tmp.IndexOf("＜") >= 0 && tmp.IndexOf("≦") < tmp.IndexOf("＜"))//X介於二個線長之間時,a≦x<b
                        {
                            tmp1 = tmp.Split('＜');
                            tx2 = tmp1[1].Substring(0, tmp1[1].Length - 1);
                            tmp2 = tmp1[0].Split('≦');
                            tx1 = tmp2[0].Substring(0, tmp2[0].Length - 1);
                            if (tmp1[1].Substring(tmp1[1].Length - 1, 1) == "M")
                            {
                                tx1F = (Convert.ToSingle(tx1) / 3.28084).ToString("0.###");
                                tx1M = (Convert.ToSingle(tx1) / 1).ToString("0.###");
                                tx1I = (Convert.ToSingle(tx1) / 39.37008).ToString("0.###");
                                tx2F = (Convert.ToSingle(tx2) / 3.28084).ToString("0.###");
                                tx2M = (Convert.ToSingle(tx2) / 1).ToString("0.###");
                                tx2I = (Convert.ToSingle(tx2) / 39.37008).ToString("0.###");
                                tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2F}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1F}))
                                            or ((right(pri_length, 1) = 'M') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2M}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1M})) 
                                            or ((right(pri_length, 1) = 'I') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2I}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1I}))) ";
                                tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2F}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1F})) 
                                             or ((right(aa.pri_length, 1) = 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2M}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1M})) 
                                             or ((right(aa.pri_length, 1) = 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) = {tx2I}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1I}))) ";
                            }
                            else
                            {
                                tx1F = (Convert.ToSingle(tx1) * 1).ToString("0.###");
                                tx1M = (Convert.ToSingle(tx1) * 0.3048).ToString("0.###");
                                tx1I = (Convert.ToSingle(tx1) * 12).ToString("0.###");
                                tx2F = (Convert.ToSingle(tx2) * 1).ToString("0.###");
                                tx2M = (Convert.ToSingle(tx2) * 0.3048).ToString("0.###");
                                tx2I = (Convert.ToSingle(tx2) * 12).ToString("0.###");
                                tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2F}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1F}))
                                            or ((right(pri_length, 1) = 'M') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2M}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1M})) 
                                            or ((right(pri_length, 1) = 'I') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2I}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1I}))) ";
                                tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2F}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1F})) 
                                             or ((right(aa.pri_length, 1) = 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2M}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1M})) 
                                             or ((right(aa.pri_length, 1) = 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2I}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1I}))) ";
                            }
                            chkFlag = true;
                        }
                        else//X小於等於某個線長時
                        {
                            tmp1 = tmp.Split('≦');
                            if (tmp1.Length > 2)//X小於等於某個線長時,a≦x≦b
                            {
                                tx2 = tmp1[2].Substring(0, tmp1[2].Length - 1);

                                tx1 = tmp1[0].Substring(0, tmp1[0].Length - 1);
                                if (tmp1[2].Substring(tmp1[2].Length - 1, 1) == "M")
                                {
                                    tx1F = (Convert.ToSingle(tx1) / 3.28084).ToString("0.###");
                                    tx1M = (Convert.ToSingle(tx1) / 1).ToString("0.###");
                                    tx1I = (Convert.ToSingle(tx1) / 39.37008).ToString("0.###");
                                    tx2F = (Convert.ToSingle(tx2) / 3.28084).ToString("0.###");
                                    tx2M = (Convert.ToSingle(tx2) / 1).ToString("0.###");
                                    tx2I = (Convert.ToSingle(tx2) / 39.37008).ToString("0.###");
                                    tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2F}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1F}))
                                            or ((right(pri_length, 1) = 'M') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2M}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1M})) 
                                            or ((right(pri_length, 1) = 'I') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2I}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1I}))) ";
                                    tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2F}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1F})) 
                                             or ((right(aa.pri_length, 1) = 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2M}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1M})) 
                                             or ((right(aa.pri_length, 1) = 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2I}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1I}))) ";
                                }
                                else
                                {
                                    tx1F = (Convert.ToSingle(tx1) * 1).ToString("0.###");
                                    tx1M = (Convert.ToSingle(tx1) * 0.3048).ToString("0.###");
                                    tx1I = (Convert.ToSingle(tx1) * 12).ToString("0.###");
                                    tx2F = (Convert.ToSingle(tx2) * 1).ToString("0.###");
                                    tx2M = (Convert.ToSingle(tx2) * 0.3048).ToString("0.###");
                                    tx2I = (Convert.ToSingle(tx2) * 12).ToString("0.###");
                                    tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2F}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1F}))
                                            or ((right(pri_length, 1) = 'M') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2M}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1M})) 
                                            or ((right(pri_length, 1) = 'I') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2I}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1I}))) ";
                                    tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2F}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1F})) 
                                             or ((right(aa.pri_length, 1) = 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2M}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1M})) 
                                             or ((right(aa.pri_length, 1) = 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2I}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1I}))) ";
                                }
                                chkFlag = true;
                            }
                            else//X小於等於某個線長時,x≦a
                            {
                                tx2 = tmp1[1].Substring(0, tmp1[1].Length - 1);
                                if (Convert.ToSingle(tx2) > 0)
                                {
                                    if (tmp1[1].Substring(tmp1[1].Length - 1, 1) == "M")
                                    {
                                        tx2F = (Convert.ToSingle(tx2) / 3.28084).ToString("0.###");
                                        tx2M = (Convert.ToSingle(tx2) / 1).ToString("0.###");
                                        tx2I = (Convert.ToSingle(tx2) / 39.37008).ToString("0.###");
                                        tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2F} )) 
                                            or ((right(pri_length, 1) = 'M')  and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2M} )) 
                                            or ((right(pri_length, 1) = 'I')  and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2I} ))) ";
                                        tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2F} )) 
                                             or ((right(aa.pri_length, 1)= 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2M} )) 
                                             or ((right(aa.pri_length, 1)= 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2I} ))) ";
                                    }
                                    else
                                    {
                                        tx2F = (Convert.ToSingle(tx2) * 1).ToString("0.###");
                                        tx2M = (Convert.ToSingle(tx2) * 0.3048).ToString("0.###");
                                        tx2I = (Convert.ToSingle(tx2) * 12).ToString("0.###");
                                        tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2F} )) 
                                            or ((right(pri_length, 1) = 'M')  and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2M} )) 
                                            or ((right(pri_length, 1) = 'I')  and (cast(left(pri_length, len(pri_length)-1) as float) <= {tx2I} ))) ";
                                        tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2F} )) 
                                             or ((right(aa.pri_length, 1)= 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2M} )) 
                                             or ((right(aa.pri_length, 1)= 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) <= {tx2I} ))) ";
                                    }
                                    chkFlag = true;
                                }
                            }
                        }
                    }
                    else if (tmp.IndexOf("<") >= 0)
                    {
                        tmp1 = tmp.Split('<');

                        if (tmp1.Length > 2)//X介於二個線長之間時,a<x<b
                        {
                            tx2 = tmp1[2].Substring(0, tmp1[2].Length - 1);

                            tx1 = tmp1[0].Substring(0, tmp1[0].Length - 1);
                            if (tmp1[2].Substring(tmp1[2].Length - 1, 1) == "M")
                            {
                                tx1F = (Convert.ToSingle(tx1) / 3.28084).ToString("0.###");
                                tx1M = (Convert.ToSingle(tx1) / 1).ToString("0.###");
                                tx1I = (Convert.ToSingle(tx1) / 39.37008).ToString("0.###");
                                tx2F = (Convert.ToSingle(tx2) / 3.28084).ToString("0.###");
                                tx2M = (Convert.ToSingle(tx2) / 1).ToString("0.###");
                                tx2I = (Convert.ToSingle(tx2) / 39.37008).ToString("0.###");
                                tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2F}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1F}))
                                            or ((right(pri_length, 1) = 'M') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2M}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1M})) 
                                            or ((right(pri_length, 1) = 'I') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2I}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1I}))) ";
                                tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2F}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1F})) 
                                             or ((right(aa.pri_length, 1) = 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2M}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1M})) 
                                             or ((right(aa.pri_length, 1) = 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2I}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1I}))) ";
                            }
                            else
                            {
                                tx1F = (Convert.ToSingle(tx1) * 1).ToString("0.###");
                                tx1M = (Convert.ToSingle(tx1) * 0.3048).ToString("0.###");
                                tx1I = (Convert.ToSingle(tx1) * 12).ToString("0.###");
                                tx2F = (Convert.ToSingle(tx2) * 1).ToString("0.###");
                                tx2M = (Convert.ToSingle(tx2) * 0.3048).ToString("0.###");
                                tx2I = (Convert.ToSingle(tx2) * 12).ToString("0.###");
                                tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2F}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1F}))
                                            or ((right(pri_length, 1) = 'M') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2M}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1M})) 
                                            or ((right(pri_length, 1) = 'I') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2I}) and (cast(left(pri_length, len(pri_length)-1) as float) >= {tx1I}))) ";
                                tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2F}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1F})) 
                                             or ((right(aa.pri_length, 1) = 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2M}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1M})) 
                                             or ((right(aa.pri_length, 1) = 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2I}) and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) >= {tx1I}))) ";
                            }
                            chkFlag = true;
                        }
                        else//X小於等於某個線長時,x<a
                        {
                            tx2 = tmp1[1].Substring(0, tmp1[1].Length - 1);
                            if (Convert.ToSingle(tx2) > 0)
                            {
                                if (tmp1[1].Substring(tmp1[1].Length - 1, 1) == "M")
                                {
                                    tx2F = (Convert.ToSingle(tx2) / 3.28084).ToString("0.###");
                                    tx2M = (Convert.ToSingle(tx2) / 1).ToString("0.###");
                                    tx2I = (Convert.ToSingle(tx2) / 39.37008).ToString("0.###");
                                    tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2F} )) 
                                            or ((right(pri_length, 1) = 'M')  and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2M} )) 
                                            or ((right(pri_length, 1) = 'I')  and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2I} ))) ";
                                    tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2F} )) 
                                             or ((right(aa.pri_length, 1)= 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2M} )) 
                                             or ((right(aa.pri_length, 1)= 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2I} ))) ";
                                }
                                else
                                {
                                    tx2F = (Convert.ToSingle(tx2) * 1).ToString("0.###");
                                    tx2M = (Convert.ToSingle(tx2) * 0.3048).ToString("0.###");
                                    tx2I = (Convert.ToSingle(tx2) * 12).ToString("0.###");
                                    tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2F} )) 
                                            or ((right(pri_length, 1) = 'M')  and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2M} )) 
                                            or ((right(pri_length, 1) = 'I')  and (cast(left(pri_length, len(pri_length)-1) as float) < {tx2I} ))) ";
                                    tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2F} )) 
                                             or ((right(aa.pri_length, 1)= 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2M} )) 
                                             or ((right(aa.pri_length, 1)= 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) < {tx2I} ))) ";
                                }
                                chkFlag = true;
                            }
                        }
                    }
                    else if (tmp.IndexOf("＝") >= 0 && chkFlag == false)//x等於某個線長時,x=a
                    {
                        tmp1 = tmp.Split("＝");
                        tx1 = tmp1[1].Substring(0, tmp1[1].Length - 1);
                        if (tmp1[1].Substring(tmp1[1].Length - 1, 1) == "M" || cboItem.Text=="光纖線")
                        {
                            tx1F = (Convert.ToSingle(tx1) / 3.28084).ToString("0.###");
                            tx1M = (Convert.ToSingle(tx1) / 1).ToString("0.###");
                            tx1I = (Convert.ToSingle(tx1) / 39.37008).ToString("0.###");
                            tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) = {tx2F} )) 
                                            or ((right(pri_length, 1) = 'M')  and (cast(left(pri_length, len(pri_length)-1) as float) = {tx2M} )) 
                                            or ((right(pri_length, 1) = 'I')  and (cast(left(pri_length, len(pri_length)-1) as float) = {tx2I} ))) ";
                            tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) = {tx2F} )) 
                                             or ((right(aa.pri_length, 1)= 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) = {tx2M} )) 
                                             or ((right(aa.pri_length, 1)= 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) = {tx2I} ))) ";
                        }
                        else
                        {
                            tx1F = (Convert.ToSingle(tx1) * 1).ToString("0.###");
                            tx1M = (Convert.ToSingle(tx1) * 0.3048).ToString("0.###");
                            tx1I = (Convert.ToSingle(tx1) * 12).ToString("0.###");
                            tsql1 = $@"and (((right(pri_length, 1) = 'F') and (cast(left(pri_length, len(pri_length)-1) as float) = {tx2F} )) 
                                            or ((right(pri_length, 1) = 'M')  and (cast(left(pri_length, len(pri_length)-1) as float) = {tx2M} )) 
                                            or ((right(pri_length, 1) = 'I')  and (cast(left(pri_length, len(pri_length)-1) as float) = {tx2I} ))) ";
                            tsql33 = $@"and (((right(aa.pri_length, 1) = 'F') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) = {tx2F} )) 
                                             or ((right(aa.pri_length, 1)= 'M') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) = {tx2M} )) 
                                             or ((right(aa.pri_length, 1)= 'I') and (cast(left(aa.pri_length, len(aa.pri_length)-1) as float) = {tx2I} ))) ";
                        }
                        chkFlag = true;
                    }
                    if(chkFlag==false)
                    {
                        MessageBox.Show("此規則有問題,請檢查!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    frmWorking_Adjust.tsql1 = tsql1;
                    frmWorking_Adjust.tsql33 = tsql33;
                    frmWorking_Adjust.rstrItem = cboItem.Text;
                    frmWorking_Adjust.rstrID = dgvData.Rows[dgvData.CurrentRow.Index].Cells[0].Value.ToString();
                    frmWorking_Adjust.rstrQty = dgvData.Rows[dgvData.CurrentRow.Index].Cells[1].Value.ToString();
                }
                else
                {
                    frmWorking_Adjust.tsql1 = "";
                    frmWorking_Adjust.rstrID = dgvData.Rows[dgvData.CurrentRow.Index].Cells[0].Value.ToString();
                    frmWorking_Adjust.rstrQty = dgvData.Rows[dgvData.CurrentRow.Index].Cells[1].Value.ToString();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.Name + "-btnExport_Click" + "\n" + ex.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                btnExport.PerformClick();
            }
        }
    }
}
