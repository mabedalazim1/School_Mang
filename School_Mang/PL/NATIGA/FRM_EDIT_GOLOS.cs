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
    public partial class FRM_EDIT_GOLOS : Form
    {
        BL.NATEG.CLS_NATEG NATEG  = new BL.NATEG.CLS_NATEG();
        BL.MSG msg = new BL.MSG();

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

        public int golos;
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
            if (BL.Globals.From_Un_Matched)
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
          
            try
            {
                if (txt_golos.Text == golos.ToString())
                {
                   msg.MyExclamationMsg("يرجي تغيير رقم الجلوس لتتمكن من التعديل ..!");
                    msg.ErrorMesg("لم يتم تعديل رقم الجلوس ..!");
                }
                else
                {
                    int code  = Convert.ToInt32(txt_code.Text);
                    int golos = Convert.ToInt32(txt_golos.Text);
                    
                    NATEG.Update_Golos_Data(code, golos);
                    FRM_FINAL_DATA.Get_Frm_Final_Data.txt_std_data_OnValueChanged(sender, e);
                    msg.MyMesg("تم تعديل رقم الجلوس بنجاح ..!");
                }
               

            }catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
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
