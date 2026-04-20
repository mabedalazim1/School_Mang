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


namespace School_Mang.PL.NATIGA
{
    public partial class FRM_CHOSE_FINAL_RASD : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        
        BL.NATEG.CLS_NATEG nateg = new BL.NATEG.CLS_NATEG();
        BL.NATEG.ExcelUtlity Excel = new BL.NATEG.ExcelUtlity();
        RPT.REPORT_CONNECTION RPT = new RPT.REPORT_CONNECTION();


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
            cmb_grade.DataSource = std.Get_grades();
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            Add_To_Comb_Test();
            Waiting.Stop();
        }



        private void Add_To_Comb_Test()
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "نصف العام");
            comboSource.Add(2, "أخر العام");

            cmb_test.DataSource = new BindingSource(comboSource, null);
            cmb_test.DisplayMember = "Value";
            cmb_test.ValueMember = "Key";

            if (BL.Globals.Amal_Sana == true)
            {
                lbl_title.Text = "كشوف أعمال السنة";
                pic_rasd.Image = Properties.Resources.test_48;
            }
            else if(BL.Globals.Final_Test == true)
            {
                lbl_title.Text = "كشوف درجات الإختبار";
                pic_rasd.Image = Properties.Resources.note_48;
            }
            else if(BL.Globals.Final_Koshof == true)
            {
                lbl_title.Text = "كشوف النتائج النهائية";
                pic_rasd.Image = Properties.Resources.final_naega_3_48;
            }
            else
            {
                lbl_title.Text = "كشوف مراجعة النتائج";
                pic_rasd.Image = Properties.Resources.test_48_1;
            }
        }

        private Boolean Verify_Count()
        {
            int grade = Convert.ToInt32(cmb_grade.SelectedValue);
            DataTable dt = new DataTable();
            dt = nateg.Get_Final_Degree(grade);

            if (dt.Rows.Count == 0)
            { 
                MSG.ErrorMesg("لا توجد نتائج مسجلة للصف المحدد");
                if(grade < 10  && BL.Globals.Final_Test)
                {
                    if(grade < 3)
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
                if(test_kind == 1)
                {
                    month = "نصف العام";
                }
                else
                {
                    month = "أخر العام";
                }

                RPT.Open_Koshof_Amal(grade, month);

                Waiting.Stop();
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


                Waiting.Stop();
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



                Waiting.Stop();
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
                            Waiting.Stop();
                            return;
                        case var expration when year > 3:
                            switch (grade)
                            {
                                case 10:
                                case 11:
                                    MSG.ErrorMesg("هذا الإجراء متاح فى نهاية العام فقط ..!");
                                    MSG.MyExclamationMsg("يرجي التأكد من نوع الاختبار ..!");
                                    cmb_grade.Focus();
                                    Waiting.Stop();
                                    return;
                                case 1:
                                case 2:
                                    MSG.ErrorMesg("لم يتم أتاحة هذا الصف!");
                                    MSG.MyExclamationMsg("يرجي التأكد من نوع الاختبار ..!");
                                    cmb_grade.Focus();
                                    Waiting.Stop();
                                    return;
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                case 7:
                                case 8:
                                case 9:
                                    RPT.OpenFinal_Koshof(year, grade,1);
                                    Waiting.Stop();
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

                   RPT.OpenFinal_Koshof(year, grade,2);
                }



                Waiting.Stop();
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

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            BL.Globals.Amal_Sana = false;
            BL.Globals.Final_Test = false;
            BL.Globals.Final_Nataga = false;
            BL.Globals.Final_Koshof = false;
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
    
            byte test_kind = Convert.ToByte(cmb_test.SelectedValue);
            if (BL.Globals.Amal_Sana)
            {
                OpenAmalReport(test_kind);
            }
            else if(BL.Globals.Final_Test)
            {
                if (!Verify_Count()) return;
                OpenRasdTestReport(test_kind);
            }else if (BL.Globals.Final_Nataga)
            {
                if (!Verify_Count()) return;
                OpenFinalNatage(test_kind);

            }
            else if (BL.Globals.Final_Koshof)
            {
                if (!Verify_Count()) return;
                OpenFinalKoshof(test_kind);

            }

        }
    }
}
