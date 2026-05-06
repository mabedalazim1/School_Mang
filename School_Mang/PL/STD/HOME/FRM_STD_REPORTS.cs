using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.BL;
using School_Mang.BL.Services;
using School_Mang.BL.Enums;

namespace School_Mang.PL.STD.HOME
{
    public partial class FRM_STD_REPORTS : Form
    {
        CLS_STD_FUNCATIONS Func = new CLS_STD_FUNCATIONS();
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        

        int year = Properties.Settings.Default.year_cod;

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
            FRM_KAEMA_GRADE.Get_Frm_Kaema_Grade.chk_sort.Visible = false;

            if (frm_Std_Reports == null)
            {
                frm_Std_Reports = this;
            }
        }

        private void Open_Report(string title, ReportDataType type )
        {
            var frm = FRM_KAEMA_GRADE.Get_Frm_Kaema_Grade;
            frm.label11.Text = title;
            frm.Text = title;

            AppNavigation.Instance
                .SetContext(c =>
                {
                   c.CurrentReport = type;
                })
                .Show(frm);
        }

        private void Open_Count_Std(int year)
        {
            Waiting.Start();
            try
            {

                RPT.REPORT_CONNECTION RPT = new RPT.REPORT_CONNECTION();
                RPT.OpenCount_Std(year);
            }
            catch (Exception ex)
            {
                MSG.MyMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
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

        private void lbl_kwaam_fasl_Click(object sender, EventArgs e)
        {
            Open_Report("قوائم الفصول", ReportDataType.OpenKaema);
               
        }

        private void lbl_kwaam_sen_Click(object sender, EventArgs e)
        {
            FRM_KAEMA_GRADE.Get_Frm_Kaema_Grade.chk_sort.Visible = true;
          
            Open_Report("تدرج السن", ReportDataType.OpenTadargSen);
                
        }

        private void lbl_segel_Click(object sender, EventArgs e)
        {
            Open_Report("سجل الطلاب", ReportDataType.OpenSegel);
                
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
            Open_Report("41 مستجدين", ReportDataType.Open41New);
               
        }

        private void pic_41_new_Click(object sender, EventArgs e)
        {
            lbl_41_new_Click(sender, e);
        }

        private void lbl_transfer_from_Click(object sender, EventArgs e)
        {

            Open_Report("محولون من المدرسة", ReportDataType.OpenTransferFrom);
                
        }

        private void lbl_transfer_to_Click(object sender, EventArgs e)
        {
            Open_Report("محولون إلى المدرسة", ReportDataType.OpenTransferFrom);
        }

        private void pic_transfer_from_Click(object sender, EventArgs e)
        {
            lbl_transfer_from_Click(sender, e);
        }

        private void pic_transfer_to_Click(object sender, EventArgs e)
        {
            lbl_transfer_to_Click(sender, e);
        }

        private void lbl_count_Click(object sender, EventArgs e)
        {
            
            Open_Count_Std(year);
        }

        private void pic_count_Click(object sender, EventArgs e)
        {
            lbl_count_Click(sender, e);
        }

        private void lbl_count_new_Click(object sender, EventArgs e)
        {
            Open_Count_Std(year + 1);
        }

        private void pic_count_new_Click(object sender, EventArgs e)
        {
            lbl_count_new_Click(sender, e);
        }

        private void lbl_bian_dragat_Click(object sender, EventArgs e)
        {
            Waiting.Start();

            AppNavigation.Instance
                .SetContext(c =>
                {
                    c.CurrentYearData = true;
                    c.StudentCase = GetStudentCase.DegreeStatement;
                }).Show<FRM_CHOOSE_GRADE>();

            //FRM_CHOOSE_GRADE frm = new FRM_CHOOSE_GRADE();
            //frm.ShowDialog();
        }

        private void pic_bian_dragat_Click(object sender, EventArgs e)
        {
            lbl_bian_dragat_Click(sender, e);
        }
    }
}
