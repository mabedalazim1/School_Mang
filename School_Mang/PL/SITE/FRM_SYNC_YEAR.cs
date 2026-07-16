using School_Mang.BL;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using School_Mang.BL.Services.FamilySyncService;
using School_Mang.BL.Services.FamilySyncService.Models;
using School_Mang.BL.Services.SyncService;
using System;
using System.Windows.Forms;



namespace School_Mang.PL.SITE
{
    public partial class FRM_SYNC_YEAR : Form
    {
        private readonly StudentService _student = new StudentService();
        private readonly LookupService _lookup = new LookupService();
        private readonly int currentYear = Properties.Settings.Default.year_cod;

        private string _currentYearDesc;
        private string _nextYearDesc;
        private string _titel;

        public FRM_SYNC_YEAR(string title ="المزامنة")
        {
            InitializeComponent();
            _titel = title;
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

        private void pn_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move_x, MousePosition.Y - move_y);
            }
        }

        private void pn_top_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private string ReverseYearDesc(string yearDesc)
        {
            string[] parts = yearDesc.Split('-');

            return parts.Length == 2
                ? $"{parts[1]}-{parts[0]}"
                : yearDesc;
        }

        private void FRM_EDIT_DATA_Load(object sender, EventArgs e)
        {
            lbl_title.Text = _titel;

            Waiting.Start();
            try
            {
                string currentYearDesc = ReverseYearDesc(_lookup.GetYearDesc(currentYear));
                string nextYearDesc = ReverseYearDesc(_lookup.GetYearDesc(currentYear + 1));

                _currentYearDesc = currentYearDesc;
                _nextYearDesc = nextYearDesc;

                lbl_year.Text = Properties.Settings.Default.Year_Desc;
                bool hasNextYearData = _student.HasStudentsInYear(currentYear + 1);

                if (hasNextYearData)
                {
                    lbl_msg.Text = "تم العثور على بيانات للعام الدراسي القادم";
                    lbl_data.Text = "اختر العام الذى تريد مزامنته مع الموقع";

                    radioCurrent.Visible = true;
                    radioNext.Visible = true;
                    radioCurrent.Text = "عام" + currentYearDesc;
                    radioNext.Text = "عام" + nextYearDesc;
                }
                else
                {
                    lbl_msg.Text = "لا توجد بيانات للعام الدراسي القادم";
                    lbl_data.Text = "اضغط موافق لبدء مزامنة بيانات العام الحالي";

                    radioCurrent.Visible = false;
                    radioNext.Visible = false;
                }
                radioCurrent.Checked = true;
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

        private void btn_ok_Click(object sender, EventArgs e)
        {

            var service = new FamilySyncService();

            int year = radioCurrent.Checked
                         ? currentYear
                         : currentYear + 1;

           string data = radioCurrent.Checked
                        ? _currentYearDesc
                        : _nextYearDesc;


            if (MSG.DialogeMsg("سوف تتم عملية المزامنة لعام " + data) != DialogResult.Yes)
            {
                MSG.ErrorMesg("تم إلغاء عملية المزامنة");
                return;
            }
            if (MSG.DialogeErrMsg("هل تريد متابعة المزامنة " + data) != DialogResult.Yes)
            {
                MSG.ErrorMesg("تم إلغاء عملية المزامنة");
                return;
            }

            Waiting.Start();
            try
            {
                FamilySyncResult result = service.SyncFamilies(year);

                Waiting.Stop();

                MSG.MyMesg("تمت المزامنة بنجاح.");
                this.Close();
                this.Dispose();

                var frm = new FRM_SYNC_RESULT(result,
                                                year,
                                                 SyncResultView.Prepare,
                                                "بيانات الأسر الجديدة");

                frm.ShowDialog();

                if (frm.Action == SyncNextAction.Continue)
                {
                    DialogResult = DialogResult.OK;
                }

                Close();
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
    }
}
