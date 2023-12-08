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
    public partial class FRM_EDIT_SITE_DEGREES : Form
    {

        BL.MSG msg = new BL.MSG();
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        BL.Waiting Waiting = new BL.Waiting();

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

        private void FRM_EDIT_SITE_DEGREES_Load(object sender, EventArgs e)
        {
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
            general_old = txt_total.Text;

            int grade_id = BL.Globals.test_grade_id;
            switch (grade_id)
            {
                case 10:
                case 11:
                case 1:
                case 2:
                case 3:
                    lbl_sinces.Text = "متعدد";
                    lbl_mahrat.Text = "مهارات";
                    lbl_tecnolgy.Text = "تكنولوجيا";
                    txt_social.Enabled = false;
                    txt_maharat.Enabled = false;
                    txt_tecnolgey.Enabled = false;
                    txt_badnia.Enabled = true;
                    CheckDegree(txt_badnia, badania_old, 0);
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
                    CheckDegree(txt_social, social_old, 0);
                    CheckDegree(txt_maharat, maharat_old, 0);
                    CheckDegree(txt_tecnolgey, maharat_old, 0);
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
                    CheckDegree(txt_social, social_old, 0);
                    CheckDegree(txt_maharat, maharat_old, 0);
                    CheckDegree(txt_tecnolgey, maharat_old, 0);
                    break;

            }
            
            //CheckDegree
            CheckDegree(txt_ar, ar_old,0);
            CheckDegree(txt_din, din_old,0);
            CheckDegree(txt_math, math_old,0);
            CheckDegree(txt_sinces, sinces_old,0);
            CheckDegree(txt_english, english_old,0);
            CheckDegree(txt_total, general_old,0);
        }

        private void CheckDegree(TextBox textBox, string txt, byte test=1)
        {
            if (test == 1)
            {
                if (Convert.ToInt32(textBox.Text) > 4 || (Convert.ToInt32(textBox.Text) < 1
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
                    case 1:
                    case 2:
                    case 3:
                        total =
                           Convert.ToDouble(txt_ar.Text) +
                           Convert.ToDouble(txt_din.Text) +
                           Convert.ToDouble(txt_sinces.Text) +
                           Convert.ToDouble(txt_math.Text) +
                           Convert.ToDouble(txt_english.Text) +
                           Convert.ToDouble(txt_badnia.Text) ;
                        total = Math.Round(total / 6, 0);
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
                           Convert.ToDouble(txt_din.Text) +
                           Convert.ToDouble(txt_sinces.Text) +
                           Convert.ToDouble(txt_social.Text) +
                           Convert.ToDouble(txt_math.Text) +
                           Convert.ToDouble(txt_english.Text) +
                           Convert.ToDouble(txt_maharat.Text)+
                           Convert.ToDouble(txt_tecnolgey.Text);
                        total = Math.Round(total / 8, 0);
                        txt_total.Text = total.ToString();
                        break;
                }

            }
            
                switch (Convert.ToInt32(textBox.Text))
                {
                    case 1:
                        textBox.BackColor = Color.Red;
                        break;
                    case 2:
                        textBox.BackColor = Color.Orange;
                        break;
                    case 3:
                        textBox.BackColor = Color.Green;
                        break;
                    case 4:
                        textBox.BackColor = Color.Blue;
                        break;
                }
                
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
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txt_din_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_math_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_sinces_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_social_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_english_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_maharat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_tecnolgey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_badnia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
               int student_Id = Convert.ToInt32(txt_cod.Text);
               int ar = Convert.ToInt32(txt_ar.Text);
               int din = Convert.ToInt32(txt_din.Text);
               int math = Convert.ToInt32(txt_math.Text);
               int scince = Convert.ToInt32(txt_sinces.Text);
               int social = Convert.ToInt32(txt_social.Text);
               int english = Convert.ToInt32(txt_english.Text);
               int maharat = Convert.ToInt32(txt_maharat.Text);
               int tocnolegy = Convert.ToInt32(txt_tecnolgey.Text);
               int badania = Convert.ToInt32(txt_badnia.Text);
               int general = Convert.ToInt32(txt_total.Text);
               int test_kind_Id = Convert.ToInt32(txt_test_kind_id.Text);
                NATEG.Update_Degree(
                    student_Id, ar, din, math, scince, social, english,
                    maharat, tocnolegy, badania, general, test_kind_Id);
               
            FRM_SITE_STD_DATA.Get_Frm_Site_Std_Data.cmb_grade_DropDownClosed(sender, e);
                msg.MyMesg("تم التعديل بنجاح ..!");
                this.Close();


            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
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
            CheckDegree(txt_total, general_old);
        }
    }
}
