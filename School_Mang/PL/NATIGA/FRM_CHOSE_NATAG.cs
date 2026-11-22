using School_Mang.BL;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.NATEG;
using School_Mang.BL.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_CHOSE_NATAG : Form
    {
        private readonly CLS_NATEG NATEG = new CLS_NATEG();
        

        // Form Closed
        private static FRM_CHOSE_NATAG frm_Chose_Natag;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Chose_Natag = null;
        }
        public static FRM_CHOSE_NATAG Get_Frm_Chose_Natag
        {
            get
            {
                if (frm_Chose_Natag == null)
                {
                    frm_Chose_Natag = new FRM_CHOSE_NATAG();
                    frm_Chose_Natag.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Chose_Natag;
            }
        }
        public FRM_CHOSE_NATAG()
        {
            InitializeComponent();

            if (frm_Chose_Natag == null)
            {
                frm_Chose_Natag = this;
            }

            Add_To_Comb_Test();
            Load_Data();
        }



        private void Load_Data()
        {
            try
            {
                Waiting.Start();

                cmb_month.DataSource = NATEG.GET_TEST_KIND();
                cmb_month.DisplayMember = "testkind_desc";
                cmb_month.ValueMember = "id";
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

        private void Add_To_Comb_Test()
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "التقييمات");
            comboSource.Add(2, "الإختبارات");

            cmb_test.DataSource = new BindingSource(comboSource, null);
            cmb_test.DisplayMember = "Value";
            cmb_test.ValueMember = "Key";
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            btn_close_Click(sender, e);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btn_show_data_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            if (cmb_test.SelectedValue == null || cmb_month.SelectedValue == null)
            {
                MSG.ErrorMesg("يرجى تحديد نوع البيانات والشهر أولاً.");
                return;
            }

            int testKind;
            int testMonth;

            if (!int.TryParse(cmb_test.SelectedValue.ToString(), out testKind) ||
                !int.TryParse(cmb_month.SelectedValue.ToString(), out testMonth))
            {
                MSG.ErrorMesg("القيم المحددة غير صحيحة، يرجى إعادة الاختيار.");
                return;
            }

            string testMonthName = cmb_month.Text;
            DataTable Dt ;

            try
            {
                switch (testKind)
                {
                    case 1:
                        Dt = NATEG.Get_Count_Degree(testMonth);
                        if (Dt == null)
                        {
                            MSG.ErrorMesg("تعذر الحصول على بيانات التقييمات.");
                            return;
                        }
                        if (Dt.Rows.Count == 0)
                        {
                            MSG.ErrorMesg("لا توجد بيانات مسجلة ..!");
                            return;
                        }
                        break;
                    case 2:
                        Dt = NATEG.Get_Count_Mark(testMonth);
                        if (Dt == null)
                        {
                            MSG.ErrorMesg("تعذر الحصول على بيانات الاختبارات.");
                            return;
                        }

                        if (Dt.Rows.Count == 0)
                        {
                            MSG.ErrorMesg("لا توجد بيانات مسجلة ..!");
                            return;
                        }
                        break;

                    default:
                        MSG.ErrorMesg("نوع البيانات المحدد غير صحيح.");
                        return;
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }

           

            //FRM_NATAG_DATA frm = new FRM_NATAG_DATA();
            //frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);

            var frm = new FRM_NATAG_DATA();

            AppNavigation.Instance
                .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                .SetContext(c =>
                {
                    c.Natiga.TestKind = testKind;
                    c.Natiga.TestMonth = testMonth;
                    c.Natiga.TestMonthName = testMonthName;
                })
                .Show(frm);

        }
    }
}
