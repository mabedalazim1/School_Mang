using School_Mang.BL;
using School_Mang.BL.Common;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.DTO;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using School_Mang.BL.Services.SyncService;
using School_Mang.BL.Services.SyncService.Degree;
using School_Mang.BL.Services.SyncService.Family;
using School_Mang.BL.Services.SyncService.Models;
using School_Mang.BL.Services.SyncService.Student;
using School_Mang.DAL;
using School_Mang.PL.SITE;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace School_Mang.PL.MAIN
{
    public partial class FRM_MANGE_SITE : Form
    {
        // Async Data
        private readonly SyncProcessService _syncProcessService = new SyncProcessService();
        private readonly FamilySyncValidationService _validationService = new FamilySyncValidationService();
        private readonly  FamilySiteSyncService service =new FamilySiteSyncService();
        private readonly  LookupService _lookup = new LookupService();
    

        // Form Closed
        private static FRM_MANGE_SITE frm_Mange_Site;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Mange_Site = null;
        }
        public static FRM_MANGE_SITE Get_Frm_Mange_Site
        {
            get
            {
                if (frm_Mange_Site == null)
                {
                    frm_Mange_Site = new FRM_MANGE_SITE();
                    frm_Mange_Site.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Mange_Site;
            }
        }


        public FRM_MANGE_SITE()
        {
            InitializeComponent();

            if (frm_Mange_Site == null)
            {
                frm_Mange_Site = this;
            }
        }

        BL.NATEG.cls_NATAG_FUNCTIONS natag_func = new BL.NATEG.cls_NATAG_FUNCTIONS();


        int year = Properties.Settings.Default.year_cod;

        
        #region أدوات الصيانة والاختبار

        private async void RestorData()
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            Waiting.Start();
            try
            {
                var localDal = new DataAcceseLayer();
                var siteDal = new SiteAccessLayer();

                // قراءة الدرجات من القاعدة المحلية
               
                DataTable degrees = localDal.Query("SELECT * FROM degrees_copy");
                DataTable marks = localDal.Query("SELECT * FROM marks_copy");
                DataTable students = localDal.Query("SELECT * FROM students_copy");

                if (marks.Rows.Count == 0)
                {
                    MessageBox.Show("جدول التقييمات المحلي فارغ.");
                    return;
                }
                if (degrees.Rows.Count == 0)
                {
                    MessageBox.Show("جدول الدرجات المحلي فارغ.");
                    return;
                }
                // حذف الدرجات من الموقع
                siteDal.Query("DELETE FROM marks");
                siteDal.Query("DELETE FROM degrees");
                siteDal.Query("DELETE FROM students");



                // رفع الدرجات للموقع
                siteDal.BulkInsert(students, "students");
                siteDal.BulkInsert(degrees, "degrees");
                siteDal.BulkInsert(marks, "marks");

                MessageBox.Show(
                    $"تم نقل {students.Rows.Count} سجل طلاب.\n" +
                    $"تم نقل {degrees.Rows.Count} سجل درجات.\n" +
                    $"تم نقل {marks.Rows.Count} سجل تقييم.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

            }
            catch (Exception ex)
            {
                {
                    MSG.ErrorMesg(ex.Message);
                }
            }
        }

        private bool CheckBeforeStudentYearOperation(string operationName)
        {
            int currentYear = Properties.Settings.Default.year_cod;

            StudentService studentService = new StudentService();

            // لا يوجد عامان مستخدمان
            if (studentService.HasStudentsInYear(currentYear + 1))
            {
                MessageBox.Show(
                    $"لا يمكن تنفيذ عملية ({operationName}) أثناء تجهيز العام الدراسي الجديد.\nقم أولاً بتغيير العام الدراسي في البرنامج.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }


            // يجب أن تكون أرقام الجلوس موجودة
            if (studentService.HasStudentsWithoutGolos(currentYear))
            {
                MessageBox.Show(
                    $"لا يمكن تنفيذ عملية ({operationName}) قبل تسجيل أرقام الجلوس لجميع الطلاب.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }
        #endregion
        private void changePages(Panel pn, string lbl)
        {
            FRM_MAIN.Get_Frm_Main.pn_home.Visible = false;
            FRM_MAIN.Get_Frm_Main.pn_main.Controls.Clear();
            FRM_MAIN.Get_Frm_Main.pn_main.Visible = false;
            FRM_MAIN.Get_Frm_Main.lbl_main.Text = lbl;
            FRM_MAIN.Get_Frm_Main.lbl_main.Visible = false;
            FRM_MAIN.Get_Frm_Main.pn_main.BringToFront();
            FRM_MAIN.Get_Frm_Main.pn_main.Controls.Add(pn);
            FRM_MAIN.Get_Frm_Main.trans_a.ShowSync(FRM_MAIN.Get_Frm_Main.pn_main);
            FRM_MAIN.Get_Frm_Main.lbl_main.Visible = true;
        }


        private FRM_PROGRESS CreateProgress()
        {
            var progress = new FRM_PROGRESS();
            progress.StartPosition = FormStartPosition.CenterScreen;
            progress.Show();

            return progress;
        }

        private void lbl_back_Click(object sender, EventArgs e)
        {
            natag_func.changePages(FRM_SETTINGS.Get_Frm_Settings.pn_home, "الإعدادات");
        }

        private void lbl_users_Click(object sender, EventArgs e)
        {
            try
            {
                FRM_COUNT_USERS.Get_Frm_Count_Users.ShowDialog();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void pic_users_Click(object sender, EventArgs e)
        {
            lbl_users_Click(sender, e);
        }

        private async void lbl_final_test_Click(object sender, EventArgs e)
        {
            int currentYear = Properties.Settings.Default.year_cod;

            if (!await InternetFlow.EnsureAsync())
                return;

            if (!CheckBeforeStudentYearOperation("أرشفة الدرجات"))
                return;

            string currentYearDesc = SchoolFormatter.ReverseYearDesc(
                _lookup.GetYearDesc(currentYear));

            string msg1 = $@"                  تحذير هام

                        سيتم الآن أرشفة درجات العام الدراسى  ({currentYearDesc})
                        بعد نجاح عملية الأرشفة سيتم الاحتفاظ بهذه الدرجات
                        داخل الأرشيف، 
                        وستكون جاهزة لبدء رفع درجات العام الدراسى الجديد.

                        هل أنت متأكد من تنفيذ عملية الأرشفة؟";

            string msg2 = $@"                تأكيد نهائى

                        سيتم الآن أرشفة درجات العام الدراسى ({currentYearDesc})
                        بعد نجاح عملية الأرشفة سيتم الاحتفاظ بهذه الدرجات
                        داخل الأرشيف،
                        وستكون جاهزة لبدء رفع درجات العام الدراسى الجديد.

                        هل أنت متأكد من تنفيذ عملية الأرشفة؟";


            if (MSG.DialogeMsgRtl(msg1) != DialogResult.Yes)
            {
                MSG.ErrorMesg("تم إلغاء الأرشفة");
                return;
            }

            if (MSG.DialogeErrMsgRtl(msg2) != DialogResult.Yes)
            {
                MSG.ErrorMesg("تم إلغاء الأرشفة");
                return;
            }

            using (var frm = new FRM_ADMIN_PASSWORD(" أرشفة الدرجات"))
            {
                if (frm.ShowDialog() != DialogResult.OK)
                    return;
            }

            Waiting.Start();
            try
            {
                var degreeService = new DegreeArchiveService();

                degreeService.Archive(currentYear - 1);

                MessageBox.Show(
                     "تمت أرشفة الدرجات بنجاح.",
                     "نجاح",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information
                );
                
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                Waiting.Stop();
            }
            finally
            {
              
                Waiting.Stop();
            }
        }

        private void pic_final_test_Click(object sender, EventArgs e)
        {
            lbl_final_test_Click(sender, e);
        }

        private  void lbl_unmach_database_Click(object sender, EventArgs e)
        {

        }

        private void pic_unmach_database_Click(object sender, EventArgs e)
        {
            lbl_unmach_database_Click(sender, e);
        }

        public async void lbl_unmach_site_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            try
            {
                
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void pic_unmach_site_Click(object sender, EventArgs e)
        {
            lbl_unmach_site_Click(sender, e);
        }

        private void lbl_add_user_Click(object sender, EventArgs e)
        {
            MSG.ErrorMesg("هذا الإجراء غير متاح حالياً .. !");
            return;

        }

        private void pic_add_user_Click(object sender, EventArgs e)
        {
            lbl_add_user_Click(sender, e);
        }

        private void lbl_link_data_Click(object sender, EventArgs e)
        {
            MSG.ErrorMesg("لسه ما خلصش ..!");
        }

        private void pic_link_data_Click(object sender, EventArgs e)
        {

        }

        private async void lbl_update_data_Click(object sender, EventArgs e)
        {
            int currentYear = Properties.Settings.Default.year_cod;
            int archiveYear = currentYear - 1;

            var restoreService = new StudentRestoreService();

            // 1- الإنترنت
            if (!await InternetFlow.EnsureAsync())
                return;

            
            // 2- وجود الأرشيف
            if (!restoreService.HasArchive(archiveYear))
            {
                MessageBox.Show(
                    "لا يوجد أرشيف للعام الدراسي السابق.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string archiveYearDesc = SchoolFormatter.ReverseYearDesc(
                _lookup.GetYearDesc(archiveYear));

            string msg1 = $@"                  تحذير هام

                سيتم الآن التراجع عن أرشفة العام الدراسى ({archiveYearDesc})

                سيتم حذف بيانات الطلاب والدرجات الحالية من الموقع،
                ثم استرجاع بيانات العام الدراسى من الأرشيف.

                هل أنت متأكد من المتابعة؟";

            string msg2 = $@"                تأكيد نهائى

                سيتم الآن إلغاء عملية الأرشفة نهائياً
                واسترجاع بيانات العام الدراسى ({archiveYearDesc}).

                بعد تنفيذ العملية سيتم حذف الأرشيف الخاص بهذا العام.

                هل أنت متأكد من تنفيذ العملية؟";


            if (MSG.DialogeMsgRtl(msg1) != DialogResult.Yes)
            {
                MSG.ErrorMesg("تم إلغاء عملية الاسترجاع");
                return;
            }

            if (MSG.DialogeErrMsgRtl(msg2) != DialogResult.Yes)
            {
                MSG.ErrorMesg("تم إلغاء عملية الاسترجاع");
                return;
            }

            using (var frm = new FRM_ADMIN_PASSWORD("التراجع عن أرشفة الدرجات"))
            {
                if (frm.ShowDialog() != DialogResult.OK)
                    return;
            }

            Waiting.Start();

            try
            {
                // 4- تنفيذ الاسترجاع
                restoreService.Restore(archiveYear);

               
                MessageBox.Show(
                    "تم التراجع عن الأرشفة واسترجاع بيانات العام الدراسي بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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

        private void pic_update_data_Click(object sender, EventArgs e)
        {
            lbl_update_data_Click(sender, e);
        }

        private void pic_study_Click(object sender, EventArgs e)
        {
            lbl_study_Click(sender, e);
        }

        private async void lbl_study_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            // Get Std Data Form
            changePages(FRM_MANGE_LESSONS.Get_Mange_Lessons.pn_mange_lesson, "إدارة المقررات");

        }

        private async void lbl_add_data_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            
        }

        private void pic_add_data_Click(object sender, EventArgs e)
        {
            lbl_add_data_Click(sender, e);
        }

        private async void lbl_add_studentd_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            using (var frm = new SITE.FRM_EDIT_DATA("إضافة الطلاب", 11))
            {
                frm.ShowDialog();
            }
           
        }

        private void pic_add_studentd_Click(object sender, EventArgs e)
        {
            lbl_add_studentd_Click(sender, e);
        }

        private async void lbl_async_site_Click(object sender, EventArgs e)
        {
            int currentYear = Properties.Settings.Default.year_cod;
            if (!await InternetFlow.EnsureAsync())
                return;

            if (!CheckBeforeStudentYearOperation("اعتماد بيانات الطلاب"))
                return;


            string currentYearDesc = SchoolFormatter.ReverseYearDesc(
                _lookup.GetYearDesc(currentYear));

            string msg1 = $@"                  تحذير هام
                        سيتم الآن تحديث بيانات الطلاب للعام 
                       ({currentYearDesc}) ....."
                       ;

            string msg2 = $@"                تأكيد نهائى

                        سيتم الآن تحديث بيانات الطلاب للعام الجديد.
                        ({currentYearDesc}) .....

                        هل أنت متأكد من تنفيذ عملية التحديث؟";


            if (MSG.DialogeMsgRtl(msg1) != DialogResult.Yes)
            {
                MSG.ErrorMesg("تم إلغاء التحديث");
                return;
            }

            if (MSG.DialogeErrMsgRtl(msg2) != DialogResult.Yes)
            {
                MSG.ErrorMesg("تم إلغاء التحديث");
                return;
            }

            using (var frm = new FRM_ADMIN_PASSWORD("تحديث بيانات الطلاب"))
            {
                if (frm.ShowDialog() != DialogResult.OK)
                    return;
            }

            Waiting.Start();

            var progress = CreateProgress();

            try
            {

                var service = new StudentSyncService();
                var executeService = new StudentSyncExecuteService();


                
                progress.Start(100, "اعتماد بيانات الطلاب");


                service.ProgressChanged += (current, total, message) =>
                {
                    progress.UpdateProgress(
                        current,
                        total,
                        message);
                };


                executeService.ProgressChanged += (current, total, message) =>
                {
                    progress.UpdateProgress(
                        current,
                        total,
                        message);
                };


                // اعتماد العام الحالى
               service.PrepareSync(currentYear, true);

                var executeResult = executeService.Execute(currentYear -1, true);

                // تحديث العام فى الموقع
                var siteProvider = new SiteDataProvider();
                siteProvider.SetSiteCurrentYear(year);

                progress.Finish();
                progress.Close();


                using (var frm = new FRM_SYNC_RESULT(
                    executeResult,
                    currentYear,
                    SyncResultView.SiteSync,
                    "نتيجة اعتماد بيانات الطلاب"))
                {
                    frm.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                {
                    MSG.ErrorMesg(ex.Message);
                }
            }
            finally
            {
                if (progress != null)
                {
                    progress.Finish();
                    progress.Close();
                }
                Waiting.Stop();
            }
        }

        private void pic_async_site_Click(object sender, EventArgs e)
        {
            lbl_async_site_Click(sender, e);
        }

        private async void lbl_sync_family_Click(object sender, EventArgs e)
        {
            using (var frm = new FRM_ADMIN_PASSWORD(" أرشفة الأسر"))
            {
                if (frm.ShowDialog() != DialogResult.OK)
                    return;
            }

            if (!await InternetFlow.EnsureAsync())
                return;

            try
            {
                var frm = new FRM_SYNC_YEAR("تجهيز الأسر للمزامنة", SyncType.Family);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    StartFamilySiteSync();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pic_sync_family_Click(object sender, EventArgs e)
        {
            lbl_sync_family_Click(sender, e);
        }

        private async void StartFamilySiteSync()

        {
            if (!await InternetFlow.EnsureAsync())
                return;

            using (var frm = new FRM_ADMIN_PASSWORD(" مزامنة الأسر"))
            {
                if (frm.ShowDialog() != DialogResult.OK)
                    return;
            }

            Waiting.Start();

            try
            {

                SyncProcessInfo info =
                    _syncProcessService.GetStatus("Family");

                if (!info.IsPrepared || !info.PreparedDate.HasValue)
                {
                    MSG.ErrorMesg("يجب تجهيز بيانات الأسر أولاً قبل بدء المزامنة.");
                    return;
                }


                TimeSpan elapsed =
                    DateTime.Now - info.PreparedDate.Value;


                if (elapsed > TimeSpan.FromMinutes(4))
                {
                    string elapsedText =
                        TimeFormatter.FormatElapsed(elapsed);

                    if (MSG.DialogeErrMsg(
                        $"تم تجهيز بيانات الأسر منذ {elapsedText}\n\n" +
                        "قد تكون بيانات المدرسة قد تغيرت منذ ذلك الوقت.\n\n" +
                        "هل تريد المتابعة باستخدام البيانات الحالية؟")
                        == DialogResult.No)
                    {
                        MSG.ErrorMesg("تم إلغاء المزامنة");
                        return;
                    }
                }


                // التحقق النهائي من أسماء المستخدمين
                FamilyValidationResult result =
                    _validationService.ValidateUserNames();


                if (result.CheckedCount == 0)
                {
                    if (MSG.DialogeErrMsg(
                        "لا توجد أسر جديدة تحتاج إلى التحقق من أسماء المستخدمين.\n\n" +
                        "هل تريد المتابعة في عملية المزامنة؟")
                        == DialogResult.No)
                    {
                        MSG.ErrorMesg("تم إلغاء المزامنة");
                        return;
                    }
                }
                else
                {
                    MSG.MyMesg(
                        $"تم التحقق من بيانات الأسر بنجاح.\n\n" +
                        $"عدد الأسر التي تم فحصها: {result.CheckedCount}\n" +
                        $"عدد أسماء المستخدمين التي تم تعديلها: {result.UpdatedUserNames}");
                }

                // هنا تبدأ مزامنة الموقع الفعلية
                if (MSG.DialogeErrMsg(
                         "تم التحقق من بيانات الأسر.\n\n" +
                         "هل تريد المتابعة في عملية المزامنة؟")
                         == DialogResult.No)
                {
                    MSG.ErrorMesg("تم إلغاء المزامنة");
                    return;
                }
                var progress = new FRM_PROGRESS();

                progress.StartPosition = FormStartPosition.CenterScreen;
                progress.Show();

                service.ProgressChanged += (current, total, message) =>
                {
                    progress.UpdateProgress(current, total, message);
                };

                FamilySyncResult resultSite =
                    service.SyncFamilies();


                progress.Finish();
                progress.Close();

                MSG.MyMesg("تمت مزامنة الأسر بنجاح.");
                int year = Properties.Settings.Default.year_cod;
                var frm = new FRM_SYNC_RESULT(resultSite,
                                              year,
                                              SyncResultView.SiteSync,
                                              "تحديث بيانات المستخدمين");

                frm.ShowDialog();

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
        private void lbl_add_family_Click(object sender, EventArgs e)
        {

            StartFamilySiteSync();
        }

        private void pic_add_family_Click(object sender, EventArgs e)
        {
            StartFamilySiteSync();
        }

        private async void lbl_sync_students_Click(object sender, EventArgs e)
        { 
            // تستخدم من السيرفر المحلى فى حالة استعادة بيانات 2025-2026 
            // للتجربة فقط وبعدها يتم الغاء الاجراء
            // *******************************

            //RestorData();
            //return;

            // *******************************


            if (!await InternetFlow.EnsureAsync())
                return;

            using (var frm = new FRM_ADMIN_PASSWORD(" مزامنة الطلاب"))
            {
                if (frm.ShowDialog() != DialogResult.OK)
                    return;
            }

            using (var frm = new FRM_SYNC_YEAR("مزامنة الطلاب", SyncType.Student))
            {
                frm.ShowDialog();
            }
        }

        private void pic_sync_students_Click(object sender, EventArgs e)
        {
            lbl_sync_students_Click(sender, e);
        }
    }
}
