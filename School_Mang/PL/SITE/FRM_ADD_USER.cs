using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BCrypt.Net;
using School_Mang.BL.Common.Helper;
using School_Mang.BL;
using School_Mang.BL.Services;
using School_Mang.BL.Services.STD;

namespace School_Mang.PL.SITE
{
    public partial class FRM_ADD_USER : Form
    {

        BL.SITE.CLS_MANGE_SITE site = new BL.SITE.CLS_MANGE_SITE();
        
        BL.SITE.CLS_ADD_USER site_users = new BL.SITE.CLS_ADD_USER();
        private readonly VerifyService _verify = new VerifyService();
        private readonly LookupService _stdData = new LookupService();
        private readonly GetDataService _getData = new GetDataService();


        // Form Closed
        private static FRM_ADD_USER frm_Add_User;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Add_User = null;
        }
        public static FRM_ADD_USER Get_Add_User
        {
            get
            {
                if (frm_Add_User == null)
                {
                    frm_Add_User = new FRM_ADD_USER();
                    frm_Add_User.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Add_User;
            }
        }
        public FRM_ADD_USER()
        {
            InitializeComponent();

            if (frm_Add_User == null)
            {
                frm_Add_User = this;
            }


            // Fill Combos

            cmb_gender.DataSource = _stdData.Get_genders();
            cmb_gender.DisplayMember = "GenderDesc";
            cmb_gender.ValueMember = "Gender_Id";

            cmb_grade.DataSource = _stdData.Get_grades();
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";
            cmb_grade.SelectedValue = 1;

            cmb_class.DataSource = _stdData.Get_Grad_Data(1);
            cmb_class.DisplayMember = "Class_Desc";
            cmb_class.ValueMember = "Class_Id";

            cmb_relgien.DataSource = _stdData.Get_religion();
            cmb_relgien.DisplayMember = "ReligionDesc";
            cmb_relgien.ValueMember = "Religion_Id";

        }

        int move;
        int move_x;
        int move_y;


        bool is_student = false;
        int user_role = 0;
        DataTable Dt_std_code;
        string stdCode = "";
        private int Verify_Std_Code(string sdt_code)
        {
            Boolean code_status = false;
            int code = Convert.ToInt32(sdt_code);
            int year = Properties.Settings.Default.year_cod;
            // Verify Student Code 


            while (!code_status)
            {
                DataTable std_Dt = _verify.Verify_Std_Code(code.ToString());
                if (std_Dt.Rows.Count != 0)
                {
                    DataTable Dt = _getData.GET_Code_Std_Grade(Convert.ToInt32(cmb_grade.SelectedValue),year, "no");
                    code = Convert.ToInt32(Dt.Rows[0]["count_std"]) + 1;
                }
                else
                {
                    code_status = true;

                }
                code += 1;
            }
            return code;

        }

        private void Get_Std_Code()
        {
            int count_std;
            int sdt_code;
            // Student Code
            string year = Properties.Settings.Default.Year_Desc.Substring(2, 2);
            string grade = "";
            switch (cmb_grade.SelectedValue)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:

                    grade = cmb_grade.SelectedValue.ToString() + "000";

                    break;
                case 10:
                    grade = "0100";
                    break;

                case 11:
                    grade = "0200";
                    break;

                default:

                    break;
            }
            int year_code = Properties.Settings.Default.year_cod;
            DataTable Dt = _getData.GET_Code_Std_Grade(Convert.ToInt32(cmb_grade.SelectedValue), year_code, "yes");
            count_std = Convert.ToInt32(Dt.Rows[0]["count_std"]);
            sdt_code = Convert.ToInt32(year + grade) + count_std + 1;

            // Verify Student Code 

            DataTable std_Dt = _verify.Verify_Std_Code(Convert.ToString(sdt_code));
            if (std_Dt.Rows.Count != 0)
            {
                sdt_code = Verify_Std_Code(sdt_code.ToString());
            }
            stdCode = sdt_code.ToString();
        }
        private Boolean is_cheked_data()
        {
            if (chk_std.Checked || chk_user.Checked ||
                       chk_admin.Checked || chk_teacher.Checked)
            {
                return true;
            }
            else
            {
                chk_std.Focus();
                MSG.ErrorMesg("يرجى اختيار نوع المستخدم ..!");
                return false;
            }
        }
        private void is_valid(TextBox textBox)
        {
            if (textBox.Text != "")
            {
                textBox.BackColor = Color.White;
            }
        }

        private Boolean is_empty(TextBox textBox)
        {
            string text = textBox.Text.Replace(" ", string.Empty);

            if (textBox.Text == "" || text == string.Empty || textBox.Text == null)
            {
                MSG.ErrorMesg("يرجي استكمال البيانات ..!");
                textBox.BackColor = Color.MistyRose;
                ActiveControl = textBox;
                textBox.Focus();
                textBox.SelectAll();
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean is_cmb_empty(ComboBox comboBox)
        {
            if (comboBox.SelectedItem == null)
            {
                MSG.ErrorMesg("يرجي استكمال البيانات ..!");
                comboBox.Focus();
                comboBox.DroppedDown = true;
                return true;
            }
            return false;
        }

        private Boolean Check_Data()
        {
            if (is_empty(txt_user_name)) return false;

            if (!Regex.IsMatch(txt_user_name.Text, "^[a-zA-Z0-9]*$"))
            {
                txt_user_name.BackColor = Color.MistyRose;
                ActiveControl = txt_user_name;
                txt_user_name.Focus();
                txt_user_name.SelectAll();
                MSG.ErrorMesg("اسم المستخدم يجب أن يكون باللغة الإنجليزية وبدون مسافات..!");
                return false;
            }

            if (is_empty(txt_pass)) return false;

            if (txt_pass.Text.Length < 4)
            {
                txt_pass.BackColor = Color.MistyRose;
                ActiveControl = txt_pass;
                txt_pass.Focus();
                txt_pass.SelectAll();
                MSG.ErrorMesg("كلمة المرور يجب ألا تقل عن أربعة أحرف ..!");
                return false;
            }

            if (is_student)
            {
                if (is_empty(txt_first_name)) return false;
                if (is_empty(txt_std_code)) return false;
                if (is_empty(txt_full_name)) return false;
                if (is_cmb_empty(cmb_grade)) return false;
                if (is_cmb_empty(cmb_class)) return false;
                if (is_cmb_empty(cmb_relgien)) return false;
                if (is_cmb_empty(cmb_gender)) return false;
                if (user_role == 0) return false;
            }
            if (!is_cheked_data()) return false;
          
            return true;
        }

        private Boolean Verify_User(string user, bool show_msg = true)
        {
            Dt_std_code = site.Verify_Username(user);
            if (Dt_std_code.Rows.Count > 0)
            {
                if (show_msg)
                {

                    txt_user_name.BackColor = Color.MistyRose;
                    ActiveControl = txt_user_name;
                    txt_user_name.Focus();
                    txt_user_name.SelectAll();
                    MSG.ErrorMesg("يوجد مستخدم بنفس الاسم .. يرجي تغيير اسم المستخدم ..!");
                   
                    if (is_student)
                    {
                        Verify_User(Convert.ToInt32(txt_std_code.Text),true);
                    }
                }
                Waiting.Stop();
                return true;
            }
            return false;
        }

        private Boolean Verify_User(int code, bool show_msg = true)
        {
            Dt_std_code = site.Verify_UserSchoolId(code);
            if (Dt_std_code.Rows.Count > 0)
            {
                if (show_msg)
                {
                    txt_std_code.BackColor = Color.MistyRose;
                    ActiveControl = txt_std_code;
                    txt_std_code.Focus();
                    txt_std_code.SelectAll();
                    MSG.ErrorMesg("كود الطالب مستخدم من قبل .. برجي التأكد من الكود ..!");
                    MSG.MyExclamationMsg("الكود مستخدم من قبل للطالب : "
                                            + "\n"
                                            + Dt_std_code.Rows[0]["fullName"].ToString()
                                            + "\n"
                                            + "الصف : "
                                            + Dt_std_code.Rows[0]["grade_desc"].ToString());
                }
                Waiting.Stop();
                return true;
            }
            return false;
        }


        
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
            Close();
        }

        private async void btn_save_data_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            try
            {
                if (Check_Data())
                {

                    Waiting.Start();

                    string user = txt_user_name.Text;
                    string password = txt_pass.Text;
                    var passwordHash = BCrypt.Net.BCrypt.HashPassword(password, 10);
                    string first_name = txt_first_name.Text;
                    string full_name = txt_full_name.Text;
                    int class_id = Convert.ToInt32(cmb_class.SelectedValue);
                    int gender_Id = Convert.ToInt32(cmb_gender.SelectedValue);
                    int religion_Id = Convert.ToInt32(cmb_relgien.SelectedValue);
                    int grade_Id = Convert.ToInt32(cmb_grade.SelectedValue);

                    // Verify If Username Is Found
                    if (Verify_User(user)) return;

                    if (is_student)
                    {
                        int code = Convert.ToInt32(txt_std_code.Text);

                        // Verify If Code Is Found On site DataBase
                        if (Verify_User(code))
                        {
                            return;
                        }
                        else
                        {
                            Get_Std_Code();
                            // Add  stduent   للطلاب فقط 
                            site.Add_User_Data(user, passwordHash,
                                                first_name, full_name,
                                                code, user_role,
                                                class_id, gender_Id,
                                                religion_Id, grade_Id,
                                                stdCode);
                        }

                        // Verify user Is Saved
                        if (Verify_User(code,false))
                        {
                            MSG.MyMesg("تم حفظ بيانات المستخدم بنجاح ..!");
                        }
                        else
                        {
                            MSG.ErrorMesg("لم يتم الحفظ .. يرجي مراجعة البيانات ..!");
                        }
                    }
                    else
                    {
                        // Add Onther Users  لغير الطلاب
                        site.Add_User_Data(user, passwordHash, user_role);

                        //Verify If Username Is Found
                        if (Verify_User(user,false))
                        {
                            MSG.MyMesg("تم حفظ بيانات المستخدم بنجاح ..!");
                        }
                        else
                        {
                            MSG.ErrorMesg("لم يتم الحفظ .. يرجي مراجعة البيانات ..!");
                        }
                    }
                }
                else
                {
                    return;
                }
                Waiting.Stop();
            }
            catch (Exception ex)
            {
                Waiting.Stop();
                MSG.ErrorMesg(ex.Message);
            }
            Waiting.Stop();
        }

        private void txt_user_name_KeyPress(object sender, KeyPressEventArgs e)
        {
                is_valid(txt_user_name);
        }

        private void txt_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            is_valid(txt_pass);
        }

        private void txt_first_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            is_valid(txt_first_name);
        }

        private void txt_std_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else
            {
                is_valid(txt_std_code);
            }

        }

        private void txt_full_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            is_valid(txt_full_name);
        }

        private void chk_std_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_std.Checked)
            {
                chk_admin.Checked = false;
                chk_user.Checked = false;
                chk_teacher.Checked = false;
                is_student = true;
                txt_first_name.Enabled = true;
                txt_full_name.Enabled = true;
                txt_std_code.Enabled = true;
                cmb_class.Enabled = true;
                cmb_gender.Enabled = true;
                cmb_grade.Enabled = true;
                cmb_relgien.Enabled = true;
                chk_add_data.Enabled = true;
                chk_import_data.Enabled = true;
                chk_add_data.Checked = true;
                user_role = 3;

            }
            else
            {
                is_student = false;
                txt_first_name.Enabled = false;
                txt_full_name.Enabled = false;
                txt_std_code.Enabled = false;
                cmb_class.Enabled = false;
                cmb_gender.Enabled = false;
                cmb_grade.Enabled = false;
                cmb_relgien.Enabled = false;
                chk_add_data.Enabled = false;
                chk_import_data.Enabled = false;
            }
        }

        private void chk_user_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_user.Checked)
            {
                chk_admin.Checked = false;
                chk_std.Checked = false;
                chk_teacher.Checked = false;
                user_role = 5;
            }
        }

        private void chk_teacher_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_teacher.Checked)
            {
                chk_admin.Checked = false;
                chk_std.Checked = false;
                chk_user.Checked = false;
                user_role = 2;
            }
        }

        private void chk_admin_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_admin.Checked)
            {
                chk_teacher.Checked = false;
                chk_std.Checked = false;
                chk_user.Checked = false;
                user_role = 1;
            }
        }

        private void chk_add_data_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_add_data.Checked)
            {
                chk_import_data.Checked = false;
                txt_first_name.Enabled = true;
                txt_full_name.Enabled = true;
                txt_std_code.Enabled = true;
                cmb_class.Enabled = true;
                cmb_gender.Enabled = true;
                cmb_grade.Enabled = true;
                cmb_relgien.Enabled = true;

            }

        }

        private void chk_import_data_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_import_data.Checked)
            {
                chk_add_data.Checked = false;
                txt_first_name.Enabled = false;
                txt_full_name.Enabled = false;
                txt_std_code.Enabled = false;
                cmb_class.Enabled = false;
                cmb_gender.Enabled = false;
                cmb_grade.Enabled = false;
                cmb_relgien.Enabled = false;

                // Get User Data
                if(txt_std_code.Text != "")
                {
                    try
                    {
                        BL.Globals.Get_User_Data = true;
                        FRM_SITE_USER_DATA.Get_Frm_Site_User_Data.ShowDialog();
                    }catch(Exception ex)
                    {
                        MSG.ErrorMesg(ex.Message);
                    }
                }
                else
                {
                    chk_std.Checked = true;
                    chk_import_data.Checked = false;
                    chk_add_data.Checked = true;
                    txt_std_code.Focus();
                    MSG.ErrorMesg("يرجي التأكد من ادخال رقم الجلوس للطالب ..!");
                }
            }

        }

        private void ERM_ADD_USER_Load(object sender, EventArgs e)
        {
            txt_user_name.Focus();
            chk_std.Checked = false;
        }

        private void cmb_grade_DropDownClosed(object sender, EventArgs e)
        {
            cmb_class.DataSource = _stdData.Get_Grad_Data(Convert.ToInt32(cmb_grade.SelectedValue));

        }
    }
}
