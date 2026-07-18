using School_Mang.BL;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.DTO;
using School_Mang.BL.Enums;
using School_Mang.BL.Services.FamilySyncService;
using School_Mang.BL.Services.FamilySyncService.Models;
using School_Mang.BL.Services.SyncService;
using School_Mang.BL.Services.SyncService.Models;
using School_Mang.DAL;
using School_Mang.PL.SITE;
using System;
using System.Data;
using System.Windows.Forms;

namespace School_Mang.PL.MAIN
{
    public partial class FRM_MANGE_SITE : Form
    {
        // Async Data
        private readonly SyncProcessService _syncProcessService = new SyncProcessService();
        private readonly FamilySyncValidationService _validationService = new FamilySyncValidationService();
        private readonly  FamilySiteSyncService service =new FamilySiteSyncService();
    

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
            if (!await InternetFlow.EnsureAsync())
                return;

            try
            {

                
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
            Waiting.Stop();
        }

        private void pic_final_test_Click(object sender, EventArgs e)
        {
            lbl_final_test_Click(sender, e);
        }

        private async void lbl_unmach_database_Click(object sender, EventArgs e)
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

        private void lbl_update_data_Click(object sender, EventArgs e)
        {
            MSG.ErrorMesg("هذا الإجراء غير متاح حالياً .. !");
            return;


           
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

        private void lbl_add_data_Click(object sender, EventArgs e)
        {
            using (var frm = new SITE.FRM_EDIT_DATA("تحديث المستخدمين", 10))
            {
                frm.ShowDialog();
            }
        }

        private void pic_add_data_Click(object sender, EventArgs e)
        {
            lbl_add_data_Click(sender, e);
        }

        private void lbl_add_studentd_Click(object sender, EventArgs e)
        {
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
            if (!await InternetFlow.EnsureAsync())
                return;

            
        }

        private void pic_async_site_Click(object sender, EventArgs e)
        {
            lbl_async_site_Click(sender, e);
        }

        private void lbl_sync_family_Click(object sender, EventArgs e)
        {
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

        private void StartFamilySiteSync()
        {
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

        private void lbl_sync_students_Click(object sender, EventArgs e)
        {
            using (var frm = new FRM_SYNC_YEAR("مزامنة الطلاب", SyncType.Student))
            {
                frm.ShowDialog();
            }
        }
    }
}
