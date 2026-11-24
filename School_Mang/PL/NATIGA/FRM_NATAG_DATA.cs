using School_Mang.BL;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.Services;
using System;
using System.Data;
using System.Windows.Forms;


namespace School_Mang.PL.NATIGA
{
    public partial class FRM_NATAG_DATA : Form, INavigationAware, INavigationAwareLoaded
    {
        private NavigationContext _context = new NavigationContext();

        public void SetNavigation(NavigationContext context)
        {
            _context = context ?? new NavigationContext();
        }

        public void OnNavigatedTo()
        {
            Load_Data();
        }

        private readonly BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();



        // Form Closed
        private static FRM_NATAG_DATA Frm_Natag_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            Frm_Natag_Data = null;
        }
        public static FRM_NATAG_DATA Get_Frm_Natag_Data
        {
            get
            {
                if (Frm_Natag_Data == null)
                {
                    Frm_Natag_Data = new FRM_NATAG_DATA();
                    Frm_Natag_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return Frm_Natag_Data;
            }
        }
        public FRM_NATAG_DATA()
        {
            InitializeComponent();

            if (Frm_Natag_Data == null)
            {
                Frm_Natag_Data = this;
            }
        }




        private async void Load_Data()
        {
            bool isConncted = await InternetFlow.EnsureAsync(retries: 2, delayMs: 500);

            if (!isConncted)
            {
                this.Close();
                return;
            }
            else
            {
                Waiting.Start();
                DataTable Dt = null;
                try
                {
                    switch (_context.Natiga.TestKind)
                    {
                        case 1:
                            Dt = NATEG.Get_Count_Degree(_context.Natiga.TestMonth);

                            dt_std_data.DataSource = Dt;
                            lbl_title.Text = "بيانات الموقع - التقييمات";

                            break;
                        case 2:
                            Dt = NATEG.Get_Count_Mark(_context.Natiga.TestMonth);

                            dt_std_data.DataSource = Dt;
                            lbl_title.Text = "بيانات الموقع - الإختبارات";
                            break;

                        default:
                            MSG.ErrorMesg("نوع الاختبار غير صحيح ..!");
                            this.Close();
                            return;
                    }
                    if (Dt != null && Dt.Rows.Count > 0)
                    {
                        dt_std_data.Columns["id"].Visible = false;
                        dt_std_data.Columns["test_kind_Id"].Visible = false;
                        dt_std_data.Columns["grade_Id"].Visible = false;
                        dt_std_data.CurrentCell = dt_std_data.Rows[0].Cells[1];
                    }
                    else
                    {
                        MSG.ErrorMesg("لا توجد بيانات للعرض ..!");
                        this.Close();
                    }
                }
                catch (Exception e)
                {
                    MSG.ErrorMesg(e.Message);
                }
                finally
                {
                    Waiting.Stop();
                }
            }
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
            btn_close_Click(sender, e);

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btn_show_data_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            if (dt_std_data.CurrentRow == null)
                return;

            int gradeId = Convert.ToInt32(dt_std_data.CurrentRow.Cells["grade_Id"].Value);
            int testMonth = Convert.ToInt32(dt_std_data.CurrentRow.Cells["test_kind_Id"].Value);

            var frm = FRM_SITE_STD_DATA.Get_Frm_Site_Std_Data;

            AppNavigation.Instance
                .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                .SetContext(c =>
                {
                    c.Natiga.TestKind = _context.Natiga.TestKind;
                    c.Natiga.TestMonth = testMonth;
                    c.Natiga.TestMonthName = _context.Natiga.TestMonthName;
                    c.Natiga.TestGradeId = gradeId;
                })
                .Show(frm);
        }

        private void dt_std_data_DoubleClick(object sender, EventArgs e)
        {
            btn_show_data_Click(sender, e);
        }
    }
}
