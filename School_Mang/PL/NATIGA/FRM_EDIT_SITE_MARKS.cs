using School_Mang.BL;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.Services;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace School_Mang.PL.NATIGA
{
    public partial class FRM_EDIT_SITE_MARKS : Form, INavigationAware
    {
        private NavigationContext _context = new NavigationContext();

        public void SetNavigation(NavigationContext context)
        {
            _context = context ?? new NavigationContext();
        }


        private readonly BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        


        // Form Closed
        private static FRM_EDIT_SITE_MARKS frm_Edit_Site_Mark;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Edit_Site_Mark = null;
        }
        public static FRM_EDIT_SITE_MARKS Get_Edit_Site_Mark
        {
            get
            {
                if (frm_Edit_Site_Mark == null)
                {
                    frm_Edit_Site_Mark = new FRM_EDIT_SITE_MARKS();
                    frm_Edit_Site_Mark.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Edit_Site_Mark;
            }
        }

        public FRM_EDIT_SITE_MARKS()
        {
            InitializeComponent();

            if (frm_Edit_Site_Mark == null)
            {
                frm_Edit_Site_Mark = this;
            }
        }


        

        int move;
        int move_x;
        int move_y;

        // Store Old Data
        string ar_old;
        string din_old;
        string math_old;
        string sinces_old;
        string social_old;
        string english_old;
        string maharat_old;
        string tocnolegy_old;
        string frinsh_old;
        string sort_old;


        private void ChangeSortColor()
        {
            int sort;

            if (!int.TryParse(txt_sort.Text, out sort) || sort == 0)
            {
                txt_sort.BackColor = Color.Orange;
                txt_sort.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                txt_sort.BackColor = Color.Green;
                txt_sort.ForeColor = Color.WhiteSmoke;
            }
        }

        private double ReadMark(TextBox textBox)
        {
            double value;

            if (string.IsNullOrWhiteSpace(textBox.Text))
                return 0;

            if (!double.TryParse(textBox.Text, out value))
                throw new InvalidOperationException(
                    "توجد درجة غير صحيحة في " + textBox.Name);

            return value;
        }

        private void CheckDegree(TextBox textBox, string txt, byte test = 1)
        {
            try
            {
                int grade = _context.Natiga.TestGradeId;
                byte test_kind_id = Convert.ToByte(txt_test_kind_id.Text);

                if (test == 1)
                {
                    if (grade == 10 ||
                        grade == 11 ||
                       (grade == 9 && (test_kind_id == 3 || test_kind_id == 6)))
                    {
                        txt_french.Enabled = false;
                    }
                    else
                    {
                        txt_french.Enabled = true;

                    }

                    if (!(grade == 9 && (test_kind_id == 3 || test_kind_id == 6)))
                    {
                        double currentMark = ReadMark(textBox);
                        if (currentMark > 20 || currentMark < 0)
                        {
                            MSG.ErrorMesg("تأكد من الدرجة ..!");
                            textBox.Text = txt;
                            textBox.Focus();
                        }
                    }
                    
                    double total;
                    switch (grade)
                    {
                        case 10:
                        case 11:

                            total =
                              ReadMark(txt_ar) +
                              ReadMark(txt_math) +
                              ReadMark(txt_english);

                            txt_total.Text = total.ToString();
                            break;

                        case 1:
                        case 2:
                        case 3:
                            total =
                               ReadMark(txt_ar) +
                               ReadMark(txt_math) +
                               ReadMark(txt_english) +
                               ReadMark(txt_french);
                            txt_total.Text = total.ToString();
                            break;

                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            total =
                               ReadMark(txt_ar) +
                               ReadMark(txt_sinces) +
                               ReadMark(txt_social) +
                               ReadMark(txt_math) +
                               ReadMark(txt_english) +
                               ReadMark(txt_french);

                            txt_total.Text = total.ToString();
                            break;
                    }
                }
                else
                {
                    textBox.BackColor = Color.WhiteSmoke;
                    textBox.ForeColor = Color.Black;
                }
                // Change Mark Color

                double mark = ReadMark(textBox);

                if ((grade == 9 && test_kind_id == 3) || (grade == 9 && test_kind_id == 6))
                {
                    textBox.BackColor = Color.White;
                }
                else
                {
                    switch (mark)
                    {

                        case double n when n < 10:
                            textBox.BackColor = Color.Red;
                            textBox.ForeColor = Color.WhiteSmoke;
                            break;
                        case double n when n < 15:
                            textBox.BackColor = Color.Orange;
                            textBox.ForeColor = Color.WhiteSmoke;
                            break;
                        case double n when n <= 20:
                            textBox.BackColor = Color.Green;
                            textBox.ForeColor = Color.WhiteSmoke;
                            break;

                        default:
                            textBox.BackColor = Color.WhiteSmoke;
                            textBox.ForeColor = Color.Black;
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            
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


        private void btn_close_b_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void FRM_EDIT_SITE_MARKS_Load(object sender, EventArgs e)
        {
            if (_context?.Natiga == null)
            {
                MSG.ErrorMesg("بيانات التنقل غير مكتملة، يرجى فتح الشاشة مرة أخرى.");
                Close();
                return;
            }


            txt_ar.TextAlign = HorizontalAlignment.Center;
            txt_french.TextAlign = HorizontalAlignment.Center;
            txt_din.TextAlign = HorizontalAlignment.Center;
            txt_english.TextAlign = HorizontalAlignment.Center;
            txt_maharat.TextAlign = HorizontalAlignment.Center;
            txt_math.TextAlign = HorizontalAlignment.Center;
            txt_sinces.TextAlign = HorizontalAlignment.Center;
            txt_social.TextAlign = HorizontalAlignment.Center;
            txt_tecnolgey.TextAlign = HorizontalAlignment.Center;
            txt_total.TextAlign = HorizontalAlignment.Center;
            txt_sort.TextAlign = HorizontalAlignment.Center;

            // Store Old Marks
            ar_old = txt_ar.Text;
            din_old = txt_din.Text;
            math_old = txt_math.Text;
            sinces_old = txt_sinces.Text;
            social_old = txt_social.Text;
            english_old = txt_english.Text;
            maharat_old = txt_maharat.Text;
            tocnolegy_old = txt_tecnolgey.Text;
            frinsh_old = txt_french.Text;
            sort_old = txt_sort.Text;

            // Chang Lables

            int grade_id = _context.Natiga.TestGradeId;
            switch (grade_id)
            {
                case 10:
                case 11:
                    lbl_mahrat.Text = "مهارات";
                    lbl_tecnolgy.Text = "تكنولوجيا";
                    txt_social.Enabled = false;
                    txt_maharat.Enabled = false;
                    txt_tecnolgey.Enabled = false;
                    txt_french.Enabled = false;
                    txt_sinces.Enabled = false;
                    break;

                case 1:
                case 2:
                case 3:
                    txt_sinces.Enabled = false;
                    txt_social.Enabled = false;
                    txt_maharat.Enabled = false;
                    txt_tecnolgey.Enabled = false;
                    txt_french.Enabled = true;
                    CheckDegree(txt_french, frinsh_old, 0);
                    break;
                case 4:
                case 5:
                case 6:
                    txt_social.Enabled = true;
                    txt_maharat.Enabled = false;
                    txt_tecnolgey.Enabled = false;
                    txt_french.Enabled = true;
                    CheckDegree(txt_social, social_old, 0);
                    CheckDegree(txt_french, frinsh_old, 0);

                    break;
                case 7:
                case 8:
                case 9:
                    txt_social.Enabled = true;
                    txt_maharat.Enabled = true;
                    txt_tecnolgey.Enabled = true;
                    txt_french.Enabled = true;
                    CheckDegree(txt_social, social_old, 0);
                    CheckDegree(txt_french, frinsh_old, 0);
                    CheckDegree(txt_maharat, maharat_old, 0);
                    CheckDegree(txt_tecnolgey, tocnolegy_old, 0);
                    break;

            }
           
            //CheckDegree
            CheckDegree(txt_ar, ar_old, 0);
            CheckDegree(txt_din, din_old, 0);
            CheckDegree(txt_math, math_old, 0);
            CheckDegree(txt_english, english_old, 0);

            if (grade_id != 10 && grade_id != 11 &&
                grade_id != 1 && grade_id != 2 && grade_id != 3)
            {
                CheckDegree(txt_sinces, sinces_old, 0);
            }

            // Handel Sort
            ChangeSortColor();

            // فحص الإنترنت
            if (!await InternetFlow.EnsureAsync())
            {
                MSG.ErrorMesg("تعذر الاتصال بالإنترنت، سيتم إغلاق الشاشة.");
                Close();
                return;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void txt_ar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_sinces_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_french_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_maharat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_tecnolgey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_sinces_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_sinces, sinces_old, 1);
        }

        private void txt_social_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_social, social_old, 1);
        }

        private void txt_english_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_english, english_old, 1);
        }

        private void txt_french_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_french, frinsh_old, 1);
        }

        private void txt_din_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_din, din_old, 1);
        }

        private void txt_maharat_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_maharat, maharat_old, 1);
        }

        private void txt_tecnolgey_TextChanged(object sender, EventArgs e)
        {
            CheckDegree(txt_tecnolgey, tocnolegy_old, 1);
        }

        private void txt_sort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            TextBox txt = (TextBox)sender;

            string newText = txt.Text.Remove(
                txt.SelectionStart, txt.SelectionLength)
                .Insert(txt.SelectionStart, e.KeyChar.ToString());

            int value;

            if (int.TryParse(newText, out value) && value > 10)
                e.Handled = true;
        }


        private void txt_sort_TextChanged(object sender, EventArgs e)
        {
            int value;

            if (int.TryParse(txt_sort.Text, out value) && value > 10)
            {
                MSG.ErrorMesg("الترتيب يجب ألا يزيد عن 10 ..!");
                txt_sort.Text = sort_old;
                txt_sort.Focus();
                return;
            }
            ChangeSortColor();
        }

        private void txt_ar_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_ar, ar_old, 1);

        }

        private void txt_math_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_math, math_old, 1);
        }

        private void txt_sinces_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_sinces, sinces_old, 1);
        }

        private void txt_social_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_social, social_old, 1);

        }

        private void txt_english_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_english, english_old, 1);

        }

        private void txt_french_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_french, frinsh_old, 1);

        }

        private void txt_din_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_din, din_old, 1);

        }

        private void txt_maharat_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_maharat, maharat_old, 1);

        }

        private void txt_tecnolgey_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_tecnolgey, tocnolegy_old, 1);

        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            //Test Intrent Connection
            if (!await InternetFlow.EnsureAsync())
            {
                MSG.ErrorMesg("تأكد من الإتصال بالإنترنت .. لم يتم الحفظ!");
                return;
            }
                

            try
            {
                int student_Id;

                if (!int.TryParse(txt_cod.Text, out student_Id))
                {
                    MSG.ErrorMesg("كود الطالب غير صحيح ..!");
                    return;
                }

                decimal ar = (decimal)ReadMark(txt_ar);
                decimal din = (decimal)ReadMark(txt_din);
                decimal math = (decimal)ReadMark(txt_math);
                decimal scince = (decimal)ReadMark(txt_sinces);
                decimal social = (decimal)ReadMark(txt_social);
                decimal english = (decimal)ReadMark(txt_english);
                decimal maharat = (decimal)ReadMark(txt_maharat);
                decimal tocnolegy = (decimal)ReadMark(txt_tecnolgey);
                decimal french = (decimal)ReadMark(txt_french);
                decimal general = (decimal)ReadMark(txt_total);

                int test_kind_Id;
                int sort_code;

                if (!int.TryParse(txt_test_kind_id.Text, out test_kind_Id) ||
                    !int.TryParse(txt_sort.Text, out sort_code))
                {
                    MSG.ErrorMesg("نوع الاختبار أو الترتيب غير صحيح ..!");
                    return;
                }

                if (sort_code < 0 || sort_code > 10)
                {
                    MSG.ErrorMesg("الترتيب يجب أن يكون من 0 إلى 10 ..!");
                    txt_sort.Focus();
                    return;
                }

                NATEG.Update_Mark(
                    student_Id, ar, din, math, scince, social, english,
                    maharat, tocnolegy, french, general, sort_code, test_kind_Id);

               
                MSG.MyMesg("تم التعديل بنجاح ..!");
                DialogResult = DialogResult.OK;
                this.Close();

            }
            catch(Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }
    }
}
