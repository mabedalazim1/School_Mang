using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.STD.HOME
{
    public partial class FRM_STD_REPORTS : Form
    {
        CLS_STD_FUNCATIONS Func = new CLS_STD_FUNCATIONS();

        // Form Closed
        private static FRM_STD_REPORTS frm_Std_Reports;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Std_Reports = null;
        }
        public static FRM_STD_REPORTS Get_Frm_Std_Reports
        {
            get
            {
                if (frm_Std_Reports == null)
                {
                    frm_Std_Reports = new FRM_STD_REPORTS();
                    frm_Std_Reports.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Std_Reports;
            }
        }
        public FRM_STD_REPORTS()
        {
            InitializeComponent();

            if (frm_Std_Reports == null)
            {
                frm_Std_Reports = this;
            }
        }

        private void lbl_back_Click(object sender, EventArgs e)
        {
            Func.changePages(MAIN.FRM_TALABA.Get_Frm_Talaba.pn_home);
        }

        private void pic_back_Click(object sender, EventArgs e)
        {
             lbl_back_Click(sender, e);
        }
    }
}
