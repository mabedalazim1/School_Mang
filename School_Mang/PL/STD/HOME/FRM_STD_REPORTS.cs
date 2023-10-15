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
        BL.MSG msg = new BL.MSG();
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();

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

        private void Open_Report(string title)
        {
            FRM_KAEMA_GRADE.Get_Frm_Kaema_Grade.label11.Text = title;
            FRM_KAEMA_GRADE.Get_Frm_Kaema_Grade.Text = title;
            FRM_KAEMA_GRADE.Get_Frm_Kaema_Grade.ShowDialog();
        }
        private void lbl_back_Click(object sender, EventArgs e)
        {
            Func.changePages(MAIN.FRM_TALABA.Get_Frm_Talaba.pn_home);
        }

        private void pic_back_Click(object sender, EventArgs e)
        {
             lbl_back_Click(sender, e);
        }

        private void lbl_kwaam_fasl_Click(object sender, EventArgs e)
        {
            BL.Globals.Open_Kaema = true;
            BL.Globals.Open_Segel = false;
            BL.Globals.Open_Tadarg_Sen = false;
            BL.Globals.Open_41_New = false;
            BL.Globals.Open_Transfer_From = false;
            BL.Globals.Open_Transfer_To = false;

            Open_Report("قوائم الفصول");

        }

        private void lbl_kwaam_sen_Click(object sender, EventArgs e)
        {
            BL.Globals.Open_Kaema = false;
            BL.Globals.Open_Segel = false;
            BL.Globals.Open_Tadarg_Sen = true;
            BL.Globals.Open_41_New = false;
            BL.Globals.Open_Transfer_From = false;
            BL.Globals.Open_Transfer_To = false;

            Open_Report("تدرج السن");
        }

        private void lbl_segel_Click(object sender, EventArgs e)
        {
            BL.Globals.Open_Kaema = false;
            BL.Globals.Open_Segel = true;
            BL.Globals.Open_Tadarg_Sen = false;
            BL.Globals.Open_41_New = false;
            BL.Globals.Open_Transfer_From = false;
            BL.Globals.Open_Transfer_To = false;

            Open_Report("سجل الطلاب");
        }

        private void pic__kwaam_sen_Click(object sender, EventArgs e)
        {
            lbl_kwaam_sen_Click(sender, e);
        }

        private void pic_kwaam_fasl_Click(object sender, EventArgs e)
        {
            lbl_kwaam_fasl_Click(sender, e);
        }

        private void pic_segel_Click(object sender, EventArgs e)
        {
            lbl_segel_Click(sender, e);
        }

        private void lbl_41_new_Click(object sender, EventArgs e)
        {
            BL.Globals.Open_Kaema = false;
            BL.Globals.Open_Segel = false;
            BL.Globals.Open_Tadarg_Sen = false;
            BL.Globals.Open_41_New = true;
            BL.Globals.Open_Transfer_From = false;
            BL.Globals.Open_Transfer_To = false;

            Open_Report("41 مستجدين");
        }

        private void pic_41_new_Click(object sender, EventArgs e)
        {
            lbl_41_new_Click(sender, e);
        }

        private void lbl_transfer_from_Click(object sender, EventArgs e)
        {
            BL.Globals.Open_Kaema = false;
            BL.Globals.Open_Segel = false;
            BL.Globals.Open_Tadarg_Sen = false;
            BL.Globals.Open_41_New = false;
            BL.Globals.Open_Transfer_From = true;
            BL.Globals.Open_Transfer_To = false;

            Open_Report("محولون من المدرسة");
        }

        private void lbl_transfer_to_Click(object sender, EventArgs e)
        {
            BL.Globals.Open_Kaema = false;
            BL.Globals.Open_Segel = false;
            BL.Globals.Open_Tadarg_Sen = false;
            BL.Globals.Open_41_New = false;
            BL.Globals.Open_Transfer_From = false;
            BL.Globals.Open_Transfer_To = true;

            Open_Report("محولون إلى المدرسة");
        }

        private void pic_transfer_from_Click(object sender, EventArgs e)
        {
            lbl_transfer_from_Click(sender, e);
        }

        private void pic_transfer_to_Click(object sender, EventArgs e)
        {
            lbl_transfer_to_Click(sender, e);
        }
    }
}
