using School_Mang.BL;
using School_Mang.BL.Services;
using System;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_EDIT_GOLOS : Form, INavigationAware
    {
        private NavigationContext _context = new NavigationContext();

        public void SetNavigation(NavigationContext context)
        {
            _context = context ?? new NavigationContext();
        }

       private readonly BL.NATEG.CLS_NATEG NATEG  = new BL.NATEG.CLS_NATEG();

        // Form Closed
        private static FRM_EDIT_GOLOS frm_Edit_Golos;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Edit_Golos = null;
        }
        public static FRM_EDIT_GOLOS Get_frm_Edit_Golos
        {
            get
            {
                if (frm_Edit_Golos == null)
                {
                    frm_Edit_Golos = new FRM_EDIT_GOLOS();
                    frm_Edit_Golos.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Edit_Golos;
            }
        }
        public FRM_EDIT_GOLOS()
        {
            InitializeComponent();

            if (frm_Edit_Golos == null)
            {
                frm_Edit_Golos = this;
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

        private void pn_top_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void pn_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move_x, MousePosition.Y - move_y);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Globals.From_Un_Matched)
            {
                SITE.FRM_UNMATCH_DATA.Get_Frm_UnMatch_Data.Close();
                MAIN.FRM_MANGE_SITE.Get_Frm_Mange_Site.lbl_unmach_site_Click(sender, e);
            }
            else
            {
                FRM_FINAL_DATA.Get_Frm_Final_Data.Show(MAIN.FRM_MAIN.Get_Frm_Main);
            }
        }

        private void FRM_EDIT_GOLOS_Load(object sender, EventArgs e)
        {
            txt_golos.TextAlign = HorizontalAlignment.Center;
            txt_grade.TextAlign = HorizontalAlignment.Center;
            txt_year.TextAlign = HorizontalAlignment.Center;
            txt_class.TextAlign = HorizontalAlignment.Center;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (_context?.Natiga == null)
            {
                MSG.ErrorMesg("بيانات التنقل غير مكتملة، يرجى فتح الشاشة مرة أخرى.");
                return;
            }

            try
            {
                if (txt_golos.Text == _context.Natiga.StudentGolos.ToString())
                {
                   MSG.MyExclamationMsg("يرجي تغيير رقم الجلوس لتتمكن من التعديل ..!");
                   MSG.ErrorMesg("لم يتم تعديل رقم الجلوس ..!");
                }
                else
                {
                    int code;
                    int golos;

                    if (!int.TryParse(txt_code.Text, out code) ||
                        !int.TryParse(txt_golos.Text, out golos))
                    {
                        MSG.ErrorMesg("كود الطالب ورقم الجلوس يجب أن يكونا أرقامًا صحيحة.");
                        return;
                    }

                    NATEG.Update_Golos_Data(code, golos);
                    MSG.MyMesg("تم تعديل رقم الجلوس بنجاح ..!");

                    FRM_FINAL_DATA.Get_Frm_Final_Data.TxtChanged();
                    btn_close_b_Click(sender, e);
                    return;
                }
               

            }catch(Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void txt_golos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
