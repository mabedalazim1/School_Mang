using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_CHOSE_FINAL_RASD : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.MSG msg = new BL.MSG();
        BL.Waiting waiting = new BL.Waiting();
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
            waiting.Wait();
            cmb_grade.DataSource = std.Get_grades();
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            Add_To_Comb_Test();
            waiting.End_WAit();
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
                msg.ErrorMesg("لا توجد نتائج مسجلة للصف المحدد");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void OpenAmalReport(byte test_kind)
        {
            waiting.Wait();
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

                waiting.End_WAit();
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                waiting.End_WAit();
            }

        }

        private void OpenRasdTestReport(byte test_kind)
        {
            waiting.Wait();
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

               

                waiting.End_WAit();
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                waiting.End_WAit();
            }

        }

        private void OpenFinalNatage(byte test_kind)
        {
            waiting.Wait();
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



                waiting.End_WAit();
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                waiting.End_WAit();
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
            
        }
    }
}
