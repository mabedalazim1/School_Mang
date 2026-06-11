using DevExpress.Utils.MVVM.Services;
using School_Mang.BL;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using School_Mang.BL.Services.STD;
using System;
using System.Windows.Forms;
using School_Mang.BL.Services.Reports;

namespace School_Mang.PL.STD
{
    public partial class FRM_KAEMA_GRADE : Form, INavigationAware
    {

        private NavigationContext _context;
        private readonly LookupService _lookupService = new LookupService();
        private readonly GetDataService _getData = new GetDataService();
        private readonly StudentReportService _reportService = new StudentReportService();
        public void SetNavigation(NavigationContext context)
        {
            _context = context ?? new NavigationContext();
            ApplyContext();
        }


        // Form Closed
        private static FRM_KAEMA_GRADE frm_Kaema_Grade;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Kaema_Grade = null;
        }
        public static FRM_KAEMA_GRADE Get_Frm_Kaema_Grade
        {
            get
            {
                if (frm_Kaema_Grade == null)
                {
                    frm_Kaema_Grade = new FRM_KAEMA_GRADE();
                    frm_Kaema_Grade.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Kaema_Grade;
            }
        }
        public FRM_KAEMA_GRADE()
        {
            InitializeComponent();

            if (frm_Kaema_Grade == null)
            {
                frm_Kaema_Grade = this;
            }

            ApplyContext();
            
        }
        int move;
        int move_x;
        int move_y;

        private void pn_top_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            move_x = e.X;
            move_y = e.Y;
        }
        private void ApplyContext()
        {
            if (_context == null) return;

            if (_context.CurrentReport == ReportDataType.Open41New
               || _context.CurrentReport == ReportDataType.OpenTadargSen)
            {
                cmb_grade.DataSource = _lookupService.Get_grades("yes");
            }

            else
            {
                cmb_grade.DataSource = _lookupService.Get_grades();
            }


            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            cmb_sana.DataSource = _lookupService.Get_years();
            cmb_sana.DisplayMember = "YearDesc";
            cmb_sana.ValueMember = "Year_Id";
        }

        private void pn_top_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void pn_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move_x, MousePosition.Y - move_y);
            }
        }
        private void Print_Kaema(int grade = 0)
        {
            try
            {
                var yearId = Convert.ToInt32(cmb_sana.SelectedValue);
                grade = Convert.ToInt32(cmb_grade.SelectedValue);

                var result = _reportService.PrintKaema(yearId, grade);

                if (!result.Success)
                {
                    MSG.ErrorMesg(result.Message);
                }

            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }


        private void FRM_KAEMA_GRADE_Load(object sender, EventArgs e)
        {

            cmb_grade.SelectedIndex = 0;
            if (cmb_sana.Items.Count > 1)
            {
                cmb_sana.SelectedIndex = 0;
            }
        }

        private void btn_print_kaema_Click(object sender, EventArgs e)
        {
            Waiting.Start();
            int grade = Convert.ToInt32(cmb_grade.SelectedValue);
            int year_id = Convert.ToInt32(cmb_sana.SelectedValue);
            bool sort = chk_sort.Checked;
            StudentReportService.Result result = StudentReportService.Result.Ok();

            try
            {
                switch (_context.CurrentReport)
                {
                    case ReportDataType.OpenKaema:

                        Print_Kaema(grade);
                        break;

                    case ReportDataType.OpenTadargSen:

                        result = _reportService.PrintTadargSen(year_id, grade, sort);
                        break;

                    case ReportDataType.OpenSegel:

                        result = _reportService.PrintSegel(year_id, grade);
                        break;

                    case ReportDataType.Open41New:

                        result = _reportService.Print41New(year_id, grade);
                        break;

                    case ReportDataType.OpenTransferFrom:

                        result = _reportService.PrintTransfer(year_id - 1  , grade,3,7);
                        break;

                    case ReportDataType.OpenTransferTo:

                        result = _reportService.PrintTransfer(year_id ,grade, 4);
                        break;
                }
                if (!result.Success)
                {
                    MSG.ErrorMesg(result.Message);
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally {
                Waiting.Stop();
            }
        }

        private void btn_print_kaema_all_Click(object sender, EventArgs e)
        {
            Waiting.Start();
            int year_id = Convert.ToInt32(cmb_sana.SelectedValue);
            bool sort = chk_sort.Checked;
            StudentReportService.Result result = StudentReportService.Result.Ok();

            try
            {
                switch (_context.CurrentReport)
                {
                    case ReportDataType.OpenKaema:

                        Print_Kaema();
                        break;

                    case ReportDataType.OpenTadargSen:

                        if (MSG.DialogeErrMsg("سوف يتم عرض بيانات جميع الطلاب .. هل تريد المتابعة ؟ ") != DialogResult.Yes) return;

                        result = _reportService.PrintTadargSen(year_id, 0, sort);
                        break;

                    case ReportDataType.OpenSegel:
                        if (MSG.DialogeErrMsg("سوف يتم عرض بيانات جميع الطلاب .. هل تريد المتابعة ؟ ") != DialogResult.Yes) return;

                        result = _reportService.PrintSegel(year_id);
                        break;

                    case ReportDataType.Open41New:

                        if (MSG.DialogeErrMsg("سوف يتم عرض بيانات جميع الطلاب .. هل تريد المتابعة ؟ ") != DialogResult.Yes) return;
                       
                        result = _reportService.Print41New(year_id);
                        break;

                    case ReportDataType.OpenTransferFrom:

                        if (MSG.DialogeErrMsg("سوف يتم عرض بيانات جميع الطلاب .. هل تريد المتابعة ؟ ") != DialogResult.Yes) return;
                        result = _reportService.PrintTransfer(year_id -1, 0, 3,7);
                        break;

                    case ReportDataType.OpenTransferTo:

                        if (MSG.DialogeErrMsg("سوف يتم عرض بيانات جميع الطلاب .. هل تريد المتابعة ؟ ") != DialogResult.Yes) return;
                        result = _reportService.PrintTransfer(year_id ,0, 4);
                        break;
                }

                if (!result.Success)
                {
                    MSG.ErrorMesg(result.Message);
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
            }
            
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void FRM_KAEMA_GRADE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_close_b_Click(sender, e);
            }
        }
    }
}
