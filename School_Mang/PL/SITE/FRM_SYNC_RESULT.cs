using School_Mang.BL;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using School_Mang.BL.Services.SyncService.Models;
using System;
using System.Windows.Forms;



namespace School_Mang.PL.SITE
{
    public partial class FRM_SYNC_RESULT : Form
    {
        private readonly FamilySyncResult _result;
        private readonly StudentSyncResult _studentResult;
        private readonly LookupService _lookUp;
        private readonly int _currentYear;
        private readonly string _title;
        private readonly SyncResultView _view;
        private readonly bool _isStudent;

        public SyncNextAction Action { get; private set; }


        public FRM_SYNC_RESULT(
            FamilySyncResult result,
            int currentYear,
            SyncResultView view,
            string title = "نتيجة المزامنة")
        {
            InitializeComponent();

            _result = result;
            _currentYear = currentYear;
            _lookUp = new LookupService();
            _title = title;
            _view = view;
        }

        public FRM_SYNC_RESULT(StudentSyncResult result,
                                int currentYear,
                                SyncResultView view,
                                string title = "نتيجة مزامنة الطلاب")
        {
            InitializeComponent();

            _studentResult = result;
            _currentYear = currentYear;
            _lookUp = new LookupService();
            _title = title;
            _view = view;
            _isStudent = true;
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
            Action = SyncNextAction.Close;
            Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }


        private void btnContinue_Click(object sender, EventArgs e)
        {
            Action = SyncNextAction.Continue;
            Close();
        }
        private void LoadFamilyResult()
        {
            if (_view == SyncResultView.Prepare)
            {
                grpPrepare.Visible = true;
                grpSite.Visible = false;

                lbl_result.Text = "تم تجهيز البيانات";
                btnContinue.Enabled = true;
            }
            else
            {
                grpPrepare.Visible = false;
                grpSite.Visible = true;

                lbl_result.Text = "تمت المزامنة بنجاح";
                btnContinue.Enabled = false;
            }

            lbl_no.Text = SafeConverter.GetString(_result.NoChange);
            lbl_add.Text = SafeConverter.GetString(_result.Added);
            lbl_update.Text = SafeConverter.GetString(_result.Reactivated);
            lbl_disabled.Text = SafeConverter.GetString(_result.Disabled);
            lbl_count.Text = SafeConverter.GetString(_result.Total);

            lbl_site_add.Text = SafeConverter.GetString(_result.AddedToSite);
            lbl_site_active.Text = SafeConverter.GetString(_result.ReactivatedOnSite);
            lbl_site_disabled.Text = SafeConverter.GetString(_result.DisabledOnSite);
            lbl_site_total.Text = SafeConverter.GetString(_result.SiteTotal);
        }

        private void LoadStudentResult()
        {
            grpPrepare.Visible = false;
            grpSite.Visible = true;

            lbl_result.Text = "تمت مزامنة الطلاب بنجاح";
            btnContinue.Enabled = false;

            // تغيير عناوين النتائج
            lbl1_title.Text = "طلاب جدد";
            lbl2_title.Text = "تم تحديث البيانات";
            lbl3_title.Text = "تم حذف الطلاب";
            lbl_total.Text = "إجمالى الطلاب";

            lbl_site_add.Text = SafeConverter.GetString(_studentResult.Added);
            lbl_site_active.Text = SafeConverter.GetString(_studentResult.Updated);
            lbl_site_disabled.Text = SafeConverter.GetString(_studentResult.Deleted);
            lbl_site_total.Text = SafeConverter.GetString(_studentResult.Total);
        }

        private void FRM_SYNC_RESULT_Load(object sender, EventArgs e)
        {
            Waiting.Start();

            try
            {
                lbl_year.Text = _lookUp.GetYearDesc(_currentYear);

                if (_isStudent)
                    LoadStudentResult();
                else
                    LoadFamilyResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Waiting.Stop();
            }
        }
    }
}
