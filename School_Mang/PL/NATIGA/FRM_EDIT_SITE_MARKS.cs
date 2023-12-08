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
    public partial class FRM_EDIT_SITE_MARKS : Form
    {

        BL.MSG msg = new BL.MSG();
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        BL.Waiting Waiting = new BL.Waiting();


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
        string general_old;
        string sort_old;

        private void CheckDegree(TextBox textBox, string txt, byte test = 1)
        {
            try
            {
                if (test == 1 && textBox.Text != "")
                {
                    if (Convert.ToDouble(textBox.Text) > 20 || (Convert.ToDouble(textBox.Text) < 0
                        ))
                    {
                        msg.ErrorMesg("تأكد من الدرجة ..!");
                        textBox.Text = txt;
                        textBox.Focus();
                    }
                    int grade = BL.Globals.test_grade_id;
                    double total;
                    switch (grade)
                    {
                        case 10:
                        case 11:

                            total =
                              Convert.ToDouble(txt_ar.Text) +
                              Convert.ToDouble(txt_sinces.Text) +
                              Convert.ToDouble(txt_math.Text) +
                              Convert.ToDouble(txt_english.Text);

                            txt_total.Text = total.ToString();
                            break;

                        case 1:
                        case 2:
                        case 3:
                            total =
                               Convert.ToDouble(txt_ar.Text) +
                               Convert.ToDouble(txt_sinces.Text) +
                               Convert.ToDouble(txt_math.Text) +
                               Convert.ToDouble(txt_english.Text) +
                               Convert.ToDouble(txt_french.Text);
                            txt_total.Text = total.ToString();
                            break;

                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            total =
                               Convert.ToDouble(txt_ar.Text) +
                               Convert.ToDouble(txt_sinces.Text) +
                               Convert.ToDouble(txt_social.Text) +
                               Convert.ToDouble(txt_math.Text) +
                               Convert.ToDouble(txt_english.Text) +
                               Convert.ToDouble(txt_french.Text);

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

                double mark = Convert.ToDouble(textBox.Text);

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
                    case double n when n < 21:
                        textBox.BackColor = Color.Green;
                        textBox.ForeColor = Color.WhiteSmoke;
                        break;

                    default:
                        textBox.BackColor = Color.WhiteSmoke;
                        textBox.ForeColor = Color.Black;
                        break;
                }
            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
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

        private void FRM_EDIT_SITE_MARKS_Load(object sender, EventArgs e)
        {
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
            general_old = txt_total.Text;
            sort_old = txt_sort.Text;

            // Chang Lables

            int grade_id = BL.Globals.test_grade_id;
            switch (grade_id)
            {
                case 10:
                case 11:
                    lbl_sinces.Text = "متعدد";
                    lbl_mahrat.Text = "مهارات";
                    lbl_tecnolgy.Text = "تكنولوجيا";
                    txt_social.Enabled = false;
                    txt_maharat.Enabled = false;
                    txt_tecnolgey.Enabled = false;
                    txt_french.Enabled = false;
                    break;

                case 1:
                case 2:
                case 3:
                    lbl_sinces.Text = "متعدد";
                    txt_social.Enabled = false;
                    txt_maharat.Enabled = false;
                    txt_tecnolgey.Enabled = false;
                    txt_french.Enabled = true;
                    CheckDegree(txt_french, frinsh_old, 0);
                    break;
                case 4:
                case 5:
                case 6:
                    lbl_sinces.Text = "علوم";
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
                    lbl_sinces.Text = "علوم";
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
            CheckDegree(txt_sinces, sinces_old, 0);
            CheckDegree(txt_english, english_old, 0);

            // Handel Sort
            if(Convert.ToInt32(txt_sort.Text) != 0)
            {
                txt_sort.BackColor = Color.Green;
                txt_sort.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                txt_sort.BackColor = Color.Orange;
                txt_sort.ForeColor = Color.WhiteSmoke;
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_sort_TextChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txt_sort.Text) > 10)
            {
                msg.ErrorMesg("تأكد من الدرجة ..!");
                txt_sort.Text = sort_old;
                txt_sort.Focus();
                return;
            }
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                int student_Id = Convert.ToInt32(txt_cod.Text);
                decimal ar = Convert.ToDecimal(txt_ar.Text);
                decimal din = Convert.ToDecimal(txt_din.Text);
                decimal math = Convert.ToDecimal(txt_math.Text);
                decimal scince = Convert.ToDecimal(txt_sinces.Text);
                decimal social = Convert.ToDecimal(txt_social.Text);
                decimal english = Convert.ToDecimal(txt_english.Text);
                decimal maharat = Convert.ToDecimal(txt_maharat.Text);
                decimal tocnolegy = Convert.ToDecimal(txt_tecnolgey.Text);
                decimal french = Convert.ToDecimal(txt_french.Text);
                decimal general = Convert.ToDecimal(txt_total.Text);
                int test_kind_Id = Convert.ToInt32(txt_test_kind_id.Text);
                NATEG.Update_Mark(
                    student_Id, ar, din, math, scince, social, english,
                    maharat, tocnolegy, french, general, test_kind_Id);

                FRM_SITE_STD_DATA.Get_Frm_Site_Std_Data.cmb_grade_DropDownClosed(sender, e);
                msg.MyMesg("تم التعديل بنجاح ..!");
                this.Close();

            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }
    }
}
