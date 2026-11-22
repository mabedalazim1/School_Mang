using School_Mang.BL;
using School_Mang.BL.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace School_Mang.PL.NATIGA
{
    public partial class FRM_CHOSE_FINAL_RASD : Form, INavigationAware
    {
        private NavigationContext _context = new NavigationContext();

        public void SetNavigation(NavigationContext context)
        {
            _context = context ?? new NavigationContext();

            if (_context.Natiga == null)
            {
                lbl_title.Text = "بيانات التنقل غير مكتملة";
                return;
            }

            if (_context.Natiga.AmalSana)
            {
                lbl_title.Text = "كشوف أعمال السنة";
                pic_rasd.Image = Properties.Resources.test_48;
            }
            else if (_context.Natiga.FinalTest)
            {
                lbl_title.Text = "كشوف درجات الإختبار";
                pic_rasd.Image = Properties.Resources.note_48;
            }
            else if (_context.Natiga.FinalKoshof)
            {
                lbl_title.Text = "كشوف النتائج النهائية";
                pic_rasd.Image = Properties.Resources.final_naega_3_48;
            }
            else if (_context.Natiga.AhsaaEdara)
            {
                lbl_title.Text = "إحصاء الإدارة";
                pic_rasd.Image = Properties.Resources.final_naega_3_48;
            }
            else
            {
                lbl_title.Text = "كشوف مراجعة النتائج";
                pic_rasd.Image = Properties.Resources.test_48_1;
            }

        }


        private readonly BL.NATEG.CLS_NATEG nateg = new BL.NATEG.CLS_NATEG();
        private readonly RPT.REPORT_CONNECTION RPT = new RPT.REPORT_CONNECTION();

        private readonly LookupService _stdData = new LookupService();
        // Form Closed
        private static FRM_CHOSE_FINAL_RASD frm_Chose_Final_Rasd;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Chose_Final_Rasd = null;
        }
        public static FRM_CHOSE_FINAL_RASD Get_Frm_Chose_Final_Rasd
        {
            get
            {
                if (frm_Chose_Final_Rasd == null)
                {
                    frm_Chose_Final_Rasd = new FRM_CHOSE_FINAL_RASD();
                    frm_Chose_Final_Rasd.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Chose_Final_Rasd;
            }
        }
        public FRM_CHOSE_FINAL_RASD()
        {
            InitializeComponent();

            if (frm_Chose_Final_Rasd == null)
            {
                frm_Chose_Final_Rasd = this;
            }

            // Fill Combo
            Waiting.Start();
            try
            {
                cmb_grade.DataSource = _stdData.Get_grades();
                cmb_grade.DisplayMember = "GradeDesc";
                cmb_grade.ValueMember = "Grade_Id";

                Add_To_Comb_Test();
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

        private void btn_close_b_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }


        private void Add_To_Comb_Test()
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "نصف العام");
            comboSource.Add(2, "أخر العام");

            cmb_test.DataSource = new BindingSource(comboSource, null);
            cmb_test.DisplayMember = "Value";
            cmb_test.ValueMember = "Key";
        }

        private Boolean Verify_Count()
        {
            int grade = Convert.ToInt32(cmb_grade.SelectedValue);
            DataTable dt = new DataTable();
            dt = nateg.Get_Final_Degree(grade);

            if (dt == null)
            {
                MSG.ErrorMesg("تعذر الحصول على النتائج من قاعدة البيانات.");
                return false;
            }

            if (dt.Rows.Count == 0)
            {
                MSG.ErrorMesg("لا توجد نتائج مسجلة للصف المحدد");
                if (grade < 10 && _context.Natiga.FinalTest)
                {
                    if (grade < 3)
                    {
                        MSG.MyExclamationMsg("الصفين الأول والثاني ليس لهم درجات اختبار ..!");
                    }
                    else
                    {
                        MSG.MyExclamationMsg("تأكد من رفع ملفات أعمال السنة للصف المحدد. !");
                    }

                }

                return false;
            }
            else
            {
                return true;
            }
        }
        private void OpenAmalReport(byte test_kind)
        {
            Waiting.Start();
            try
            {
                int grade = Convert.ToInt32(cmb_grade.SelectedValue);

                string month = "";
                if (test_kind == 1)
                {
                    month = "نصف العام";
                }
                else
                {
                    month = "أخر العام";
                }

                RPT.Open_Koshof_Amal(grade, month);

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

        private void OpenRasdTestReport(byte test_kind)
        {
            Waiting.Start();
            try
            {
                int grade = Convert.ToInt32(cmb_grade.SelectedValue);
                int year = Properties.Settings.Default.year_cod;


                if (test_kind == 1)
                {
                    RPT.OpenResdTest_A(year, grade);
                }
                else
                {
                    RPT.OpenResdTest_B(year, grade);
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

        private void OpenFinalNatage(byte test_kind)
        {
            Waiting.Start();
            try
            {
                int grade = Convert.ToInt32(cmb_grade.SelectedValue);
                int year = Properties.Settings.Default.year_cod;


                if (test_kind == 1)
                {
                    RPT.OpenNatega_A(year, grade);
                }
                else
                {
                    RPT.OpenNatega_B(year, grade);
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

        private void OpenFinalKoshof(byte test_kind)
        {
            Waiting.Start();
            try
            {
                int grade = Convert.ToInt32(cmb_grade.SelectedValue);
                int year = Properties.Settings.Default.year_cod;


                if (test_kind == 1)
                {
                    switch (year)
                    {
                        case var expration when year < 4:
                            MSG.ErrorMesg("هذا الإجراء متاح فى نهاية العام فقط ..!");
                            MSG.MyExclamationMsg("يرجي التأكد من نوع الاختبار ..!");
                            cmb_grade.Focus();
                            return;
                        case var expration when year > 3:
                            switch (grade)
                            {
                                case 10:
                                case 11:
                                    MSG.ErrorMesg("هذا الإجراء متاح فى نهاية العام فقط ..!");
                                    MSG.MyExclamationMsg("يرجي التأكد من نوع الاختبار ..!");
                                    cmb_grade.Focus();
                                    return;
                                case 1:
                                case 2:
                                    MSG.ErrorMesg("لم يتم أتاحة هذا الصف!");
                                    MSG.MyExclamationMsg("يرجي التأكد من نوع الاختبار ..!");
                                    cmb_grade.Focus();
                                    return;
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                case 7:
                                case 8:
                                case 9:
                                    RPT.OpenFinal_Koshof(year, grade, 1);
                                    return;

                            }

                            return;
                    }

                }
                else
                {
                    switch (year)
                    {
                        case 1:
                            break;
                    }

                    RPT.OpenFinal_Koshof(year, grade, 2);
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

        private void OpenFinalAhsaaEdara(byte test_kind)
        {
            Waiting.Start();
            try
            {
                int grade = Convert.ToInt32(cmb_grade.SelectedValue);
                int year = Properties.Settings.Default.year_cod;

                if (test_kind == 1)
                {

                    MSG.ErrorMesg("هذا الإجراء متاح فى نهاية العام فقط ..!");
                    MSG.MyExclamationMsg("يرجي التأكد من نوع الاختبار لم يتم إضافته لنصف العام ..!");
                    cmb_grade.Focus();
                    return;

                }
                else
                {
                    switch (grade)
                    {
                        case 11:
                        case 10:
                        case 9:
                            MSG.ErrorMesg("هذا الاجراء غير متاح للصف المحدد ..!");
                            return;
                    }

                    RPT.OpenAhsaaEdara(year, grade);
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

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (_context?.Natiga == null)
            {
                MSG.ErrorMesg("بيانات التنقل غير مكتملة، يرجى فتح الشاشة مرة أخرى.");
                return;
            }

            try
            {
                byte test_kind = Convert.ToByte(cmb_test.SelectedValue);

                if (_context.Natiga.AmalSana)
                {
                    OpenAmalReport(test_kind);
                }
                else if (_context.Natiga.FinalTest)
                {
                    if (!Verify_Count()) return;
                    OpenRasdTestReport(test_kind);
                }
                else if (_context.Natiga.FinalNataga)
                {
                    if (!Verify_Count()) return;
                    OpenFinalNatage(test_kind);
                }
                else if (_context.Natiga.FinalKoshof)
                {
                    if (!Verify_Count()) return;
                    OpenFinalKoshof(test_kind);
                }
                else if (_context.Natiga.AhsaaEdara)
                {
                    if (!Verify_Count()) return;
                    OpenFinalAhsaaEdara(test_kind);
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }
    }
}
