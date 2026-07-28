using School_Mang.BL;
using School_Mang.BL.Common;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using School_Mang.BL.Services.SyncService;
using School_Mang.BL.Services.SyncService.Family;
using School_Mang.BL.Services.SyncService.Models;
using School_Mang.BL.Services.SyncService.Student;
using System;
using System.Windows.Forms;



namespace School_Mang.PL.SITE
{
    public partial class FRM_SYNC_YEAR : Form
    {
        private readonly StudentService _student = new StudentService();
        private readonly LookupService _lookup = new LookupService();
        private readonly int currentYear = Properties.Settings.Default.year_cod;
        private readonly SyncType _syncType;

        private string _currentYearDesc;
        private string _nextYearDesc;
        private string _titel;

        public FRM_SYNC_YEAR(string title ="المزامنة" ,SyncType syncType = SyncType.Family)
        {
            InitializeComponent();
            _titel = title;
            _syncType = syncType;
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

        

        private void FRM_EDIT_DATA_Load(object sender, EventArgs e)
        {
            lbl_title.Text = _titel;

            Waiting.Start();
            try
            {
                string currentYearDesc = SchoolFormatter.ReverseYearDesc(
                    _lookup.GetYearDesc(currentYear));
                string nextYearDesc = SchoolFormatter.ReverseYearDesc(
                    _lookup.GetYearDesc(currentYear + 1));

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
                    lbl_data.Text = "اضغط موافق لبدء تجهيز بيانات العام الحالي";

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

        private bool ConfirmPrepare(string yearDesc)
        {
            if (MSG.DialogeMsg($"سوف تتم عملية التجهيز لعام {yearDesc}") != DialogResult.Yes)
                return false;

            return MSG.DialogeErrMsg($"هل تريد متابعة التجهيز {yearDesc}") == DialogResult.Yes;
        }

        private FRM_PROGRESS CreateProgress()
        {
            var progress = new FRM_PROGRESS();
            progress.StartPosition = FormStartPosition.CenterScreen;
            progress.Show();

            return progress;
        }

        private void ShowPrepareResult(FamilySyncResult result, int year)
        {
            MSG.MyMesg("تمت عملية التجهيز بنجاح.");

            using (var frm = new FRM_SYNC_RESULT(
                result,
                year,
                SyncResultView.Prepare,
                "بيانات الأسر الجديدة"))
            {
                frm.ShowDialog();

                if (frm.Action == SyncNextAction.Continue)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void PrepareFamilies(int year)
        {
            var service = new FamilySyncService();

            FRM_PROGRESS progress = null;

            try
            {
                progress = CreateProgress();

                service.ProgressChanged += (current, total, message) =>
                {
                    progress.UpdateProgress(current, total, message);
                };

                FamilySyncResult result = service.SyncFamilies(year);

                progress.Finish();
                progress.Close();


                ShowPrepareResult(result, year);

                if (!IsDisposed)
                    Close();
            }
            catch (Exception ex)
            {
                progress?.Close();
                Show();
                MSG.ErrorMesg(ex.Message);
            }
        }
        private void PrepareStudents(int year)
        {
            int currentYear = Properties.Settings.Default.year_cod;

            StudentService studentService = new StudentService();

            int archiveYear = studentService.HasStudentsInYear(currentYear + 1)
                ? currentYear
                : currentYear - 1;

            var archiveService = new StudentArchiveSyncService();
            var service = new StudentSyncService();
            var executeService = new StudentSyncExecuteService();

            FRM_PROGRESS progress = null;

            try
            {
                progress = new FRM_PROGRESS();
                progress.StartPosition = FormStartPosition.CenterScreen;
                progress.Show();

                archiveService.ProgressChanged += (value, message) =>
                {
                    progress.UpdateProgress(value, 100, message);
                };

                service.ProgressChanged += (current, total, message) =>
                {
                    progress.UpdateProgress(current, total, message);
                };



                // إنشاء لقطة الأرشيف مرة واحدة فقط لكل سنة
                if (!archiveService.HasArchive(archiveYear))
                {
                    archiveService.Sync(archiveYear);
                }


                var result = service.PrepareSync(year);


                var executeResult = executeService.Execute();

                // تحديث العام فى الموقع
                var siteProvider = new SiteDataProvider();
                siteProvider.SetSiteCurrentYear(year);


                progress.Finish();
                progress.Close();


                using (var frm = new FRM_SYNC_RESULT(
                         executeResult,
                         year,
                         SyncResultView.SiteSync,
                         "نتيجة مزامنة الطلاب")
                    )
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                progress?.Close();
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            bool isCurrentYear = radioCurrent.Checked;

            int year = isCurrentYear ? currentYear : currentYear + 1;

            string data = isCurrentYear
                ? _currentYearDesc
                : _nextYearDesc;

            if (!ConfirmPrepare(data))
            {
                MSG.ErrorMesg("تم إلغاء عملية التجهيز");
                return;
            }

            Hide();

            if (_syncType == SyncType.Family)
            {
                PrepareFamilies(year);
            }
            else if (_syncType == SyncType.Student)
            {
                PrepareStudents(year);
            }
        }
    }
}
