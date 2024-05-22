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
    public partial class FRM_FINAL_DEGREE_DATA : Form
    {
        BL.MSG msg = new BL.MSG();
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        BL.Waiting Waiting = new BL.Waiting();


        // Form Closed
        private static FRM_FINAL_DEGREE_DATA frm_Final_Degree_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Final_Degree_Data = null;
        }
        public static FRM_FINAL_DEGREE_DATA Get_Final_Degree_Data
        {
            get
            {
                if (frm_Final_Degree_Data == null)
                {
                    frm_Final_Degree_Data = new FRM_FINAL_DEGREE_DATA();
                    frm_Final_Degree_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Final_Degree_Data;
            }
        }
        public FRM_FINAL_DEGREE_DATA()
        {
            InitializeComponent();

            if (frm_Final_Degree_Data == null)
            {
                frm_Final_Degree_Data = this;
            }
        }

        // Store Old Data
        string ar_old;
        string din_old;
        string math_old;
        string sinces_old;
        string sinces_practical_old;
        string social_old;
        string english_old;
        string maharat_old;
        string tocnolegy_old;
        string tocnolegy_practical_old;


        int move;
        int move_x;
        int move_y;

        private void Cheack_Gyab(TextBox textBox, byte absent)
        {
            if (absent == 1)
            {
                textBox.Text = "غ";
                textBox.Enabled = false;
            }
            else
            {
                textBox.Enabled = true;
            }
        }
        private void Get_Data(byte test_kind)
        {

            // Change Lables For Grades
            byte test_grade_id = Convert.ToByte(BL.Globals.test_grade_id);
            switch (test_grade_id)
            {
                case 10:
                case 11:
                case 1:
                case 2:
                case 3:
                    lbl_mahrat.Location = new Point(189, 31);
                    lbl_mahrat.Text = "بدنية";
                    txt_test_kind.Text = "تقييم أخر العام";
                    break;

                case 4:
                case 5:
                case 6:
                    lbl_mahrat.Location = new Point(189, 31);
                    lbl_mahrat.Text = "مهارات";
                    lbl_tocnolegy.Location = new Point(96, 31);
                    lbl_tocnolegy.Text = "تكنولوجي";
                    txt_test_kind.Text = BL.Globals.Final_Test_Name;
                    break;

                case 7:
                case 8:
                case 9:
                    lbl_mahrat.Location = new Point(197, 31);
                    lbl_mahrat.Text = "فنية";
                    lbl_tocnolegy.Location = new Point(106, 31);
                    lbl_tocnolegy.Text = "حاسب";
                    txt_test_kind.Text = BL.Globals.Final_Test_Name;
                    break;
            }
            
            int Std_Golos = BL.Globals.Std_Golos;
            DataTable Dt = NATEG.Get_Final_All_Data(Std_Golos);
            if (Dt.Rows.Count == 0)
            {
                msg.ErrorMesg("لا توجد بيانات مسجلة لهذا الطالب ..!");
                return;
            }
            txt_grade.Text = Dt.Rows[0]["GradeDesc"].ToString();
            txt_name.Text = Dt.Rows[0]["stdunet_name"].ToString();

            // Get Absent Student
            byte absent_ar_A = Convert.ToByte(Dt.Rows[0]["absent_ar_A"]);
            byte absent_ar_B = Convert.ToByte(Dt.Rows[0]["absent_ar_B"]);
            byte absent_math_A = Convert.ToByte(Dt.Rows[0]["absent_math_A"]);
            byte absent_math_B = Convert.ToByte(Dt.Rows[0]["absent_math_B"]);
            byte absent_scince_A = Convert.ToByte(Dt.Rows[0]["absent_scince_A"]);
            byte absent_scince_B = Convert.ToByte(Dt.Rows[0]["absent_scince_B"]);
            byte absent_social_A = Convert.ToByte(Dt.Rows[0]["absent_social_A"]);
            byte absent_social_B = Convert.ToByte(Dt.Rows[0]["absent_social_B"]);
            byte absent_english_A = Convert.ToByte(Dt.Rows[0]["absent_english_A"]);
            byte absent_english_B = Convert.ToByte(Dt.Rows[0]["absent_english_B"]);
            byte absent_din_A = Convert.ToByte(Dt.Rows[0]["absent_din_A"]);
            byte absent_din_B = Convert.ToByte(Dt.Rows[0]["absent_din_B"]);
            byte absent_maharat_A = Convert.ToByte(Dt.Rows[0]["absent_maharat_A"]);
            byte absent_maharat_B = Convert.ToByte(Dt.Rows[0]["absent_maharat_B"]);
            byte absent_tocnolegy_A = Convert.ToByte(Dt.Rows[0]["absent_tocnolegy_A"]);
            byte absent_tocnolegy_B = Convert.ToByte(Dt.Rows[0]["absent_tocnolegy_B"]);


            try
            {
                Waiting.Wait();
                lbl_sinces.Text = "علوم";
                switch (test_kind)
                {
                    case 1:
                        txt_ar.Text = Dt.Rows[0]["arabic_A_1"].ToString();
                        txt_din.Text = Dt.Rows[0]["dain_A_1"].ToString();
                        txt_math.Text = Dt.Rows[0]["math_A_1"].ToString();
                        txt_scince.Text = Dt.Rows[0]["scince_A_1"].ToString();
                        txt_scince_practical.Text = Dt.Rows[0]["scince_A_practical"].ToString();
                        txt_social.Text = Dt.Rows[0]["social_A_1"].ToString();
                        txt_english.Text = Dt.Rows[0]["english_A_1"].ToString();
                        txt_maharat.Text = Dt.Rows[0]["maharat_A_1"].ToString();
                        txt_tocnolegy.Text = Dt.Rows[0]["tocnolegy_A_1"].ToString();
                        txt_tocnolegy_practical.Text = Dt.Rows[0]["tocnolegy_A_practical"].ToString();
                        if (BL.Globals.test_grade_id == 7 || BL.Globals.test_grade_id == 8 || BL.Globals.test_grade_id == 9)
                        {
                            txt_scince_practical.Enabled = true;
                            txt_tocnolegy_practical.Enabled = true;
                        }
                        else
                        {
                            txt_scince_practical.Enabled = false;
                            txt_tocnolegy_practical.Enabled = false;
                        }


                        break;
                    case 2:
                        txt_ar.Text = Dt.Rows[0]["arabic_A_2"].ToString();
                        txt_din.Text = Dt.Rows[0]["dain_A_2"].ToString();
                        txt_math.Text = Dt.Rows[0]["math_A_2"].ToString();
                        txt_scince.Text = Dt.Rows[0]["scince_A_Test"].ToString();
                        txt_scince_practical.Text = "0";
                        txt_scince_practical.Enabled = false;
                        txt_social.Text = Dt.Rows[0]["social_A_2"].ToString();
                        txt_english.Text = Dt.Rows[0]["english_A_2"].ToString();
                        txt_maharat.Text = Dt.Rows[0]["maharat_A_2"].ToString();
                        txt_tocnolegy.Text = Dt.Rows[0]["tocnolegy_A_Test"].ToString();
                        txt_tocnolegy_practical.Text = "0";
                        txt_tocnolegy_practical.Enabled = false;

                        // Get Absent Student
                        Cheack_Gyab(txt_ar, absent_ar_A);
                        Cheack_Gyab(txt_din, absent_din_A);
                        Cheack_Gyab(txt_math, absent_math_A);
                        Cheack_Gyab(txt_scince, absent_scince_A);
                        Cheack_Gyab(txt_social, absent_social_A);
                        Cheack_Gyab(txt_english, absent_english_A);
                        Cheack_Gyab(txt_maharat, absent_maharat_A);
                        Cheack_Gyab(txt_tocnolegy, absent_tocnolegy_A);
                        break;
                    case 3:
                        txt_ar.Text = Dt.Rows[0]["arabic_B_1"].ToString();
                        txt_din.Text = Dt.Rows[0]["dain_B_1"].ToString();
                        txt_math.Text = Dt.Rows[0]["math_B_1"].ToString();
                        txt_scince.Text = Dt.Rows[0]["scince_B_1"].ToString();
                        txt_scince_practical.Text = Dt.Rows[0]["scince_B_practical"].ToString();
                        txt_social.Text = Dt.Rows[0]["social_B_1"].ToString();
                        txt_english.Text = Dt.Rows[0]["english_B_1"].ToString();
                        txt_maharat.Text = Dt.Rows[0]["maharat_B_1"].ToString();
                        txt_tocnolegy.Text = Dt.Rows[0]["tocnolegy_B_1"].ToString();
                        txt_tocnolegy_practical.Text = Dt.Rows[0]["tocnolegy_B_practical"].ToString();
                        if (BL.Globals.test_grade_id == 7 || BL.Globals.test_grade_id == 8 || BL.Globals.test_grade_id == 9)
                        {
                            txt_scince_practical.Enabled = true;
                            txt_tocnolegy_practical.Enabled = true;
                        }
                        else
                        {
                            txt_scince_practical.Enabled = false;
                            txt_tocnolegy_practical.Enabled = false;
                        }
                        break;
                    case 4:

                        txt_tocnolegy_practical.Enabled = false;
                        txt_scince_practical.Enabled = false;
                        

                        if (BL.Globals.test_grade_id < 4 || BL.Globals.test_grade_id > 9)
                        {
                            
                            txt_social.Text = "0";
                            txt_scince_practical.Text = "0";
                            txt_tocnolegy.Text = "0";
                            txt_tocnolegy_practical.Text = "0";
                            txt_ar.Text = Dt.Rows[0]["arabic_B_1"].ToString();
                            txt_din.Text = Dt.Rows[0]["dain_B_1"].ToString();
                            txt_math.Text = Dt.Rows[0]["math_B_1"].ToString();
                            txt_scince.Text = Dt.Rows[0]["scince_B_1"].ToString();
                            lbl_sinces.Text = "متعدد";
                            txt_english.Text = Dt.Rows[0]["english_B_1"].ToString();
                            txt_maharat.Text = Dt.Rows[0]["maharat_B_1"].ToString();
                        }
                        else
                        {
                            txt_ar.Text = Dt.Rows[0]["arabic_B_2"].ToString();
                            txt_din.Text = Dt.Rows[0]["dain_B_2"].ToString();
                            txt_math.Text = Dt.Rows[0]["math_B_2"].ToString();
                            txt_scince.Text = Dt.Rows[0]["scince_B_Test"].ToString();
                            txt_scince_practical.Text = "0";
                            txt_social.Text = Dt.Rows[0]["social_B_2"].ToString();
                            txt_english.Text = Dt.Rows[0]["english_B_2"].ToString();
                            txt_maharat.Text = Dt.Rows[0]["maharat_B_2"].ToString();
                            txt_tocnolegy.Text = Dt.Rows[0]["tocnolegy_B_Test"].ToString();
                            txt_tocnolegy_practical.Text = "0";

                        }

                       
                        // Get Absent Student
                        Cheack_Gyab(txt_ar, absent_ar_B);
                        Cheack_Gyab(txt_din, absent_din_B);
                        Cheack_Gyab(txt_math, absent_math_B);
                        Cheack_Gyab(txt_scince, absent_scince_B);
                        Cheack_Gyab(txt_social, absent_social_B);
                        Cheack_Gyab(txt_english, absent_english_B);
                        Cheack_Gyab(txt_maharat, absent_maharat_B);
                        Cheack_Gyab(txt_tocnolegy, absent_tocnolegy_B);
                        break;

                }
                if (BL.Globals.test_grade_id < 4 || BL.Globals.test_grade_id > 9)
                {
                    txt_social.Enabled = false;
                    txt_tocnolegy.Enabled = false;
                }
                else
                {
                    txt_social.Enabled = true;
                    txt_tocnolegy.Enabled = true;
                }
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                Waiting.End_WAit();
            }
        }

        private void CheckDegree(TextBox textBox, string txt_old)
        {
            if (textBox.Text == "غ") return;

            byte test_kind = BL.Globals.Final_Test_Kind;
            double max_degree = 0;

            byte grade = Convert.ToByte(BL.Globals.test_grade_id);
            try
            {
                switch (grade)
                {
                    case 10:
                    case 11:
                    case 1:
                    case 2:
                    case 3:
                        max_degree = 4;
                        break;

                    case 4:
                    case 5:
                    case 6:
                        switch (test_kind)
                        {
                            case 1:
                            case 3:
                                max_degree = 70;
                                break;
                            case 2:
                            case 4:
                                max_degree = 30;
                                break;
                        }

                        break;

                    case 7:
                    case 8:
                    case 9:
                        switch (test_kind)
                        {
                            case 1:
                            case 3:
                                max_degree = 20;
                                if (textBox.Name == "txt_scince_practical" || textBox.Name == "txt_tocnolegy_practical")
                                {
                                    max_degree = 16;
                                }

                                break;
                            case 2:
                            case 4:
                                max_degree = 80;
                                if (textBox.Name == "txt_scince" || textBox.Name == "txt_tocnolegy")
                                {
                                    max_degree = 64;
                                }
                                break;
                        }

                        break;

                }

                if (Convert.ToDouble(textBox.Text) > max_degree || (Convert.ToDouble(textBox.Text) < 0
                       ))
                {
                    msg.ErrorMesg("تأكد من الدرجة ..!");
                    textBox.Text = txt_old;
                    textBox.Focus();
                }
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
        }

        private decimal Get_Degree(TextBox textBox)
        {
            decimal degree = 0;
            try
            {
                Waiting.Wait();
                if (textBox.Text == "غ")
                {
                    degree = 0;
                }
                else
                {
                    degree = Convert.ToDecimal(textBox.Text);
                }
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                Waiting.End_WAit();
            }

            return degree;
        }
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            BL.Globals.Std_Golos = 0;
            Close();
            FRM_FINAL_DATA.Get_Frm_Final_Data.cmb_grade_DropDownClosed(sender, e);
            FRM_FINAL_DATA.Get_Frm_Final_Data.Visible = true;
        }

        private void FRM_FINAL_DEGREE_DATA_Load(object sender, EventArgs e)
        {
            txt_ar.TextAlign = HorizontalAlignment.Center;
            txt_din.TextAlign = HorizontalAlignment.Center;
            txt_math.TextAlign = HorizontalAlignment.Center;
            txt_scince.TextAlign = HorizontalAlignment.Center;
            txt_scince_practical.TextAlign = HorizontalAlignment.Center;
            txt_social.TextAlign = HorizontalAlignment.Center;
            txt_english.TextAlign = HorizontalAlignment.Center;
            txt_maharat.TextAlign = HorizontalAlignment.Center;
            txt_tocnolegy.TextAlign = HorizontalAlignment.Center;
            txt_tocnolegy_practical.TextAlign = HorizontalAlignment.Center;
            txt_test_kind.TextAlign = HorizontalAlignment.Center;
            txt_grade.TextAlign = HorizontalAlignment.Center;

            // Store Old Degrees
            ar_old = txt_ar.Text;
            din_old = txt_din.Text;
            math_old = txt_math.Text;
            sinces_old = txt_scince.Text;
            sinces_practical_old = txt_scince_practical.Text;
            social_old = txt_social.Text;
            english_old = txt_english.Text;
            maharat_old = txt_maharat.Text;
            tocnolegy_old = txt_tocnolegy.Text;
            tocnolegy_practical_old = txt_tocnolegy_practical.Text;

            try
            {
                byte test_kind = BL.Globals.Final_Test_Kind;
                Get_Data(test_kind);
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void txt_ar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_din_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_math_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_scince_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_scince_practical_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_social_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_english_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_maharat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_tocnolegy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_tocnolegy_practical_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_ar_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_ar, ar_old);
        }

        private void txt_din_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_din, din_old);
        }

        private void txt_math_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_math, math_old);
        }

        private void txt_scince_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_scince, sinces_old);
        }

        private void txt_scince_practical_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_scince_practical, sinces_practical_old);
        }

        private void txt_social_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_social, social_old);
        }

        private void txt_english_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_english, english_old);
        }

        private void txt_maharat_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_maharat, maharat_old);
        }

        private void txt_tocnolegy_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_tocnolegy, tocnolegy_old);
        }

        private void txt_tocnolegy_practical_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_tocnolegy_practical, tocnolegy_practical_old);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (BL.Globals.test_grade_id < 4 || BL.Globals.test_grade_id > 9)
            {
                BL.Globals.Final_Test_Kind = 3;
            }

            decimal ar = Get_Degree(txt_ar);
            decimal math = Get_Degree(txt_math);
            decimal scince = Get_Degree(txt_scince);
            decimal scince_practical = Get_Degree(txt_scince_practical);
            decimal social = Get_Degree(txt_social);
            decimal english = Get_Degree(txt_english);
            decimal din = Get_Degree(txt_din);
            decimal maharat = Get_Degree(txt_maharat);
            decimal tocnolegy = Get_Degree(txt_tocnolegy);
            decimal tocnolegy_practical = Get_Degree(txt_tocnolegy_practical);
            
            try
            {
                Waiting.Wait();
                NATEG.Update_Final_Degree_Data(
                    ar, math, scince, scince_practical, social, english
                    , din, maharat, tocnolegy, tocnolegy_practical);
                msg.MyMesg("تم تعديل الدرجات بنجاح ..!");

            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.End_WAit();
            }
        }
    }
}
