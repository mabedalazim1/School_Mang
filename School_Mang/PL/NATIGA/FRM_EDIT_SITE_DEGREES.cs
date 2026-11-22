using School_Mang.BL;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.Services;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_EDIT_SITE_DEGREES : Form, INavigationAware
    {
        private NavigationContext _context = new NavigationContext();

        public void SetNavigation(NavigationContext context)
        {
            _context = context ?? new NavigationContext();
        }


        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();


        // Form Closed
        private static FRM_EDIT_SITE_DEGREES frm_Edit_Site_Degree;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Edit_Site_Degree = null;
        }
        public static FRM_EDIT_SITE_DEGREES Get_Edit_Site_Degree
        {
            get
            {
                if (frm_Edit_Site_Degree == null)
                {
                    frm_Edit_Site_Degree = new FRM_EDIT_SITE_DEGREES();
                    frm_Edit_Site_Degree.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Edit_Site_Degree;
            }
        }
        public FRM_EDIT_SITE_DEGREES()
        {
            InitializeComponent();

            if (frm_Edit_Site_Degree == null)
            {
                frm_Edit_Site_Degree = this;
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
        string badania_old;
        string general_old;

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

        private async void FRM_EDIT_SITE_DEGREES_Load(object sender, EventArgs e)
        {
            if (_context?.Natiga == null)
            {
                MSG.ErrorMesg("بيانات التنقل غير مكتملة، يرجى فتح الشاشة مرة أخرى.");
                Close();
                return;
            }

            //Test Intrent Connection
            if (!await InternetFlow.EnsureAsync())
                return;

            txt_ar.TextAlign = HorizontalAlignment.Center;
            txt_badnia.TextAlign = HorizontalAlignment.Center;
            txt_din.TextAlign = HorizontalAlignment.Center;
            txt_english.TextAlign = HorizontalAlignment.Center;
            txt_maharat.TextAlign = HorizontalAlignment.Center;
            txt_math.TextAlign = HorizontalAlignment.Center;
            txt_sinces.TextAlign = HorizontalAlignment.Center;
            txt_social.TextAlign = HorizontalAlignment.Center;
            txt_tecnolgey.TextAlign = HorizontalAlignment.Center;
            txt_total.TextAlign = HorizontalAlignment.Center;

            // Store Old Degrees
            ar_old = txt_ar.Text;
            din_old = txt_din.Text;
            math_old = txt_math.Text;
            sinces_old = txt_sinces.Text;
            social_old = txt_social.Text;
            english_old = txt_english.Text;
            maharat_old = txt_maharat.Text;
            tocnolegy_old = txt_tecnolgey.Text;
            badania_old = txt_badnia.Text;

            txt_total.ReadOnly = true;

            int grade_id = _context.Natiga.TestGradeId;
            switch (grade_id)
            {
                case 10:
                case 11:
                case 1:
                case 2:
                case 3:
                    lbl_sinces.Text = "علوم";
                    txt_sinces.Enabled = false;
                    lbl_mahrat.Text = "مهارات";
                    lbl_tecnolgy.Text = "تكنولوجيا";
                    txt_social.Enabled = false;
                    txt_maharat.Enabled = false;
                    txt_tecnolgey.Enabled = false;
                    txt_badnia.Enabled = true;
                    CheckDegree(txt_badnia, badania_old);
                    break;
                case 4:
                case 5:
                case 6:
                    lbl_sinces.Text = "علوم";
                    lbl_mahrat.Text = "مهارات";
                    lbl_tecnolgy.Text = "تكنولوجيا";
                    txt_social.Enabled = true;
                    txt_maharat.Enabled = true;
                    txt_tecnolgey.Enabled = true;
                    txt_badnia.Enabled = false;
                    CheckDegree(txt_sinces, sinces_old);
                    CheckDegree(txt_social, social_old);
                    CheckDegree(txt_maharat, maharat_old);
                    CheckDegree(txt_tecnolgey, tocnolegy_old);
                    break;
                case 7:
                case 8:
                case 9:
                    lbl_sinces.Text = "علوم";
                    lbl_mahrat.Text = "فنية";
                    lbl_tecnolgy.Text = "حاسب";
                    txt_social.Enabled = true;
                    txt_maharat.Enabled = true;
                    txt_tecnolgey.Enabled = true;
                    txt_badnia.Enabled = false;
                    CheckDegree(txt_sinces, sinces_old);
                    CheckDegree(txt_social, social_old);
                    CheckDegree(txt_maharat, maharat_old);
                    CheckDegree(txt_tecnolgey, tocnolegy_old);
                    break;

            }

            //CheckDegree
            CheckDegree(txt_ar, ar_old);
            CheckDegree(txt_din, din_old);
            CheckDegree(txt_math, math_old);
            CheckDegree(txt_english, english_old);
            CheckGeneralDegree();
        }


        private void DecimalDegree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            TextBox textBox = sender as TextBox;

            if (textBox == null)
                return;

            string currentText = textBox.Text.Remove(
                textBox.SelectionStart,
                textBox.SelectionLength
            );

            string newText = currentText.Insert(
                textBox.SelectionStart,
                e.KeyChar.ToString()
            );

            // السماح بالأرقام والنقطة والفاصلة فقط
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }

            // منع وجود أكثر من فاصل عشري
            int separators = newText.Count(c => c == '.' || c == ',');

            if (separators > 1)
            {
                e.Handled = true;
                return;
            }

            // السماح بمنزلتين عشريتين فقط
            int separatorIndex = newText.IndexOfAny(new char[] { '.', ',' });

            if (separatorIndex >= 0 &&
                newText.Length - separatorIndex - 1 > 2)
            {
                e.Handled = true;
            }
        }

        private decimal ReadDegree(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
                return 0;

            decimal value;

            if (!TryReadDegree(textBox.Text, out value))
                throw new InvalidOperationException(
                    "توجد درجة غير صحيحة في مادة: " + textBox.Name);

            return value;
        }

        private void CalculateGeneralDegree()
        {
            decimal total = 0;
            int grade = _context.Natiga.TestGradeId;

            switch (grade)
            {
                // الصفوف الأول والثاني والثالث
                case 1:
                case 2:
                case 3:

                    total =
                        ReadDegree(txt_ar) +
                        ReadDegree(txt_math) +
                        ReadDegree(txt_english);

                    break;

                // الصفوف من الرابع إلى التاسع
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:

                    total =
                        ReadDegree(txt_ar) +
                        ReadDegree(txt_math) +
                        ReadDegree(txt_english) +
                        ReadDegree(txt_sinces) +
                        ReadDegree(txt_social);

                    break;

                // الصفان العاشر والحادي عشر
                case 10:
                case 11:

                    total =
                        ReadDegree(txt_ar) +
                        ReadDegree(txt_din) +
                        ReadDegree(txt_math) +
                        ReadDegree(txt_english) +
                        ReadDegree(txt_badnia);

                    total = Math.Round(total / 5, 0);


                    break;
            }

            txt_total.Text = total.ToString("0.##");
            ApplyTotalColor(txt_total, total);
        }



        private bool TryReadDegree(string value, out decimal degree)
        {
            value = value.Trim().Replace(',', '.');

            return decimal.TryParse(
                value,
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                out degree
            );
        }

        private void ApplyDegreeColor(TextBox textBox, decimal degree)
        {

            int grade = _context.Natiga.TestGradeId;

            if (grade == 10 || grade == 11)
            {
                if (degree == 1)
                    textBox.BackColor = Color.Red;
                else if (degree == 2)
                    textBox.BackColor = Color.Orange;
                else if (degree == 3)
                    textBox.BackColor = Color.Green;
                else
                    textBox.BackColor = Color.Blue;

                return;
            }

            if (degree < 7.5m)
                textBox.BackColor = Color.Red;
            else if (degree < 9.75m)
                textBox.BackColor = Color.Salmon;
            else if (degree < 11.25m)
                textBox.BackColor = Color.DarkOrange;
            else if (degree < 12.75m)
                textBox.BackColor = Color.Green;
            else
                textBox.BackColor = Color.Blue;
        }

        private void ApplyTotalColor(TextBox textBox, decimal total)
        {
            int grade = _context.Natiga.TestGradeId;

            if (grade == 10 || grade == 11)
            {
                if (total == 1)
                    textBox.BackColor = Color.Red;
                else if (total == 2)
                    textBox.BackColor = Color.Orange;
                else if (total == 3)
                    textBox.BackColor = Color.Green;
                else
                    textBox.BackColor = Color.Blue;

                return;
            }

            decimal multiplier = grade <= 3 ? 3 : 5;

            if (total < 7.5m * multiplier)
                textBox.BackColor = Color.Red;
            else if (total < 9.75m * multiplier)
                textBox.BackColor = Color.Salmon;
            else if (total < 11.25m * multiplier)
                textBox.BackColor = Color.DarkOrange;
            else if (total < 12.75m * multiplier)
                textBox.BackColor = Color.Green;
            else
                textBox.BackColor = Color.Blue;
        }
        private void CheckDegree(TextBox textBox, string oldValue)
        {
            decimal degree;

            if (!TryReadDegree(textBox.Text, out degree))
            {
                return;
            }

            decimal fraction = degree - Math.Truncate(degree);

            if (degree < 0 || degree > 15 ||
                (fraction != 0 && fraction != 0.25m &&
                 fraction != 0.50m && fraction != 0.75m))
            {
                MSG.ErrorMesg("الدرجة يجب أن تكون من 0 إلى 15 وبفواصل ربع درجة ..!");
                textBox.Text = oldValue;
                textBox.Focus();
                return;
            }

            CalculateGeneralDegree();
            ApplyDegreeColor(textBox, degree);
        }


        private void CheckGeneralDegree()
        {

            decimal total;

            if (!decimal.TryParse(txt_total.Text, out total))
                return;

            if (total < 0)
            {
                MSG.ErrorMesg("المجموع غير صحيح ..!");
                txt_total.Text = "0";
                return;
            }

            ApplyTotalColor(txt_total, total);
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click_1(sender, e);
        }

        private void btn_close_b_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_ar_KeyPress(object sender, KeyPressEventArgs e)
        {

            DecimalDegree_KeyPress(sender, e);

        }

        private void txt_din_KeyPress(object sender, KeyPressEventArgs e)
        {

            DecimalDegree_KeyPress(sender, e);
        }

        private void txt_math_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalDegree_KeyPress(sender, e);
        }

        private void txt_sinces_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalDegree_KeyPress(sender, e);
        }

        private void txt_social_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalDegree_KeyPress(sender, e);
        }

        private void txt_english_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalDegree_KeyPress(sender, e);
        }

        private void txt_maharat_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalDegree_KeyPress(sender, e);
        }

        private void txt_tecnolgey_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalDegree_KeyPress(sender, e);
        }

        private void txt_badnia_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalDegree_KeyPress(sender, e);
        }

        private void txt_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            DecimalDegree_KeyPress(sender, e);
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;


            try
            {
                int student_Id;

                if (!int.TryParse(txt_cod.Text, out student_Id))
                {
                    MSG.ErrorMesg("كود الطالب غير صحيح ..!");
                    return;
                }

                decimal ar = ReadDegree(txt_ar);
                decimal din = ReadDegree(txt_din);
                decimal math = ReadDegree(txt_math);
                decimal scince = ReadDegree(txt_sinces);
                decimal social = ReadDegree(txt_social);
                decimal english = ReadDegree(txt_english);
                decimal maharat = ReadDegree(txt_maharat);
                decimal tocnolegy = ReadDegree(txt_tecnolgey);
                decimal badania = ReadDegree(txt_badnia);
                decimal general = ReadDegree(txt_total);

                int test_kind_Id;

                if (!int.TryParse(txt_test_kind_id.Text, out test_kind_Id))
                {
                    MSG.ErrorMesg("نوع الاختبار غير صحيح ..!");
                    return;
                }

                NATEG.Update_Degree(
                    student_Id, ar, din, math, scince, social, english,
                    maharat, tocnolegy, badania, general, test_kind_Id);

                MSG.MyMesg("تم التعديل بنجاح ..!");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void txt_ar_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_ar, ar_old);
        }

        private void txt_din_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_din, din_old);
        }

        private void txt_math_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_math, math_old);
        }

        private void txt_sinces_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_sinces, sinces_old);
        }

        private void txt_social_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_social, social_old);
        }

        private void txt_english_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_english, english_old);
        }

        private void txt_maharat_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_maharat, maharat_old);
        }

        private void txt_tecnolgey_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_tecnolgey, tocnolegy_old);
        }

        private void txt_badnia_Leave(object sender, EventArgs e)
        {
            CheckDegree(txt_badnia, badania_old);
        }

        private void txt_total_TextChanged(object sender, EventArgs e)
        {
            // CheckDegree(txt_total, general_old);
        }
    }
}
