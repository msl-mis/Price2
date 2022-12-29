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
    public partial class frmBOMPrice_Msgbox : Form
    {
        public static string strWhoCall = "";
        public static string strMsg = "";
        public frmBOMPrice_Msgbox()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmBOMPrice.rstrMsg = "OK";
            this.Close();
        }

        private void btnNG_Click(object sender, EventArgs e)
        {
            frmBOMPrice.rstrMsg = "NO";
            this.Close();
        }
    }
}
