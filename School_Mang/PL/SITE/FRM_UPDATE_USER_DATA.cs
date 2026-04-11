using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.BL.Common.Helper;

namespace School_Mang.PL.SITE
{
    public partial class FRM_UPDATE_USER_DATA : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.MSG msg = new BL.MSG();
        BL.SITE.CLS_MANGE_SITE site = new BL.SITE.CLS_MANGE_SITE();
        BL.Waiting Waiting = new BL.Waiting();

        // Form Closed
        private static FRM_UPDATE_USER_DATA frm_Update_User_Data;

        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Update_User_Data = null;
        }
        public static FRM_UPDATE_USER_DATA Get_Update_User_Data
        {
            get
            {
                if (frm_Update_User_Data == null)
                {
                    frm_Update_User_Data = new FRM_UPDATE_USER_DATA();
                    frm_Update_User_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Update_User_Data;
            }
        }
        public FRM_UPDATE_USER_DATA()
        {
            InitializeComponent();

            if (frm_Update_User_Data == null)
            {
                frm_Update_User_Data = this;
            }

            cmb_grade.DataSource = std.Get_grades();
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            cmb_gender.DataSource = std.Get_genders();
            cmb_gender.DisplayMember = "GenderDesc";
            cmb_gender.ValueMember = "Gender_Id";

            cmb_relgien.DataSource = std.Get_religion();
            cmb_relgien.DisplayMember = "ReligionDesc";
            cmb_relgien.ValueMember = "Religion_Id";

            cmb_class.DataSource = std.Get_Class_Id(grade);
            cmb_class.DisplayMember = "Class_Desc";
            cmb_class.ValueMember = "Class_Id";

        }

        int move;
        int move_x;
        int move_y;
        int grade = 1;

        
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

        private void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_class.DataSource = std.Get_Class_Id(Convert.ToInt32(cmb_grade.SelectedValue));
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            Close();
            if (BL.Globals.From_Un_Matched)
            {
                BL.Globals.From_Un_Matched = false;
                FRM_UNMATCH_DATA.Get_Frm_UnMatch_Data.Show(MAIN.FRM_MAIN.Get_Frm_Main);
            }
            else
            {
                FRM_SITE_USER_DATA.Get_Frm_Site_User_Data.txt_std_data_OnValueChanged(sender, e);
                FRM_SITE_USER_DATA.Get_Frm_Site_User_Data.Show(MAIN.FRM_MAIN.Get_Frm_Main);
            }
           
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private async void btn_save_data_Click(object sender, EventArgs e)
        {
            bool isConncted = await InternetHelper.CheckInternetAsync();

            if (!isConncted)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                return;
            }

            if (txt_std_code.Text =="")
            {
                msg.ErrorMesg("يرجى ادخال رقم الجلوس ..!");
               
                txt_std_code.Focus();
                txt_std_code.SelectAll();
                return;
            }
            else
            {
                int code = Convert.ToInt32(txt_std_code.Text);
                DataTable Dt = site.Verify_UserSchoolId(code);
                if(Dt.Rows.Count > 0)
                {
                    msg.ErrorMesg("رقم الجلوس مسجل من قبل ..!");

                    txt_std_code.Focus();
                    txt_std_code.SelectAll();
                    return;
                }
            }

            try
            {
                int Golos = Convert.ToInt32(txt_std_code.Text);
                string first_name = txt_first_name.Text;
                string full_name = txt_std_name.Text;
                byte grade = Convert.ToByte(cmb_grade.SelectedValue);
                byte class_id = Convert.ToByte(cmb_class.SelectedValue);
                byte gender = Convert.ToByte(cmb_gender.SelectedValue);
                byte relgien = Convert.ToByte(cmb_relgien.SelectedValue);
                string stdCode = txt_stdCode.Text;
                Waiting.Wait();
                site.Update_User_Data(Golos, full_name, first_name, stdCode);
                site.Update_Student_Data(Golos, grade, class_id, gender, relgien, stdCode);
                Waiting.End_WAit();
                msg.MyMesg("تم تحديث بيانات المستخدم بنجاح ..!");
            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void txt_std_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void FRM_UPDATE_USER_DATA_Load(object sender, EventArgs e)
        {
            if (txt_std_code.Text != "")
            {
                int code = Convert.ToInt32(txt_std_code.Text);
                if (site.Verify_Std_Degrees(code).Rows.Count > 0 ||
                    site.Verify_Std_Marks(code).Rows.Count > 0)
                {
                    txt_std_code.Enabled = false;
                }
                else
                {
                    txt_std_code.Enabled = true;
                }
            }
        }
    }
}
