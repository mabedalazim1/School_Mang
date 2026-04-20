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
using School_Mang.BL;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_SITE_STD_DATA : Form
    {
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();



        // Form Closed
        private static FRM_SITE_STD_DATA frm_Site_Std_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Site_Std_Data = null;
        }
        public static FRM_SITE_STD_DATA Get_Frm_Site_Std_Data
        {
            get
            {
                if (frm_Site_Std_Data == null)
                {
                    frm_Site_Std_Data = new FRM_SITE_STD_DATA();
                    frm_Site_Std_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Site_Std_Data;
            }
        }
        public FRM_SITE_STD_DATA()
        {
            InitializeComponent();

            if (frm_Site_Std_Data == null)
            {
                frm_Site_Std_Data = this;
            }


            DataTable grade_dt = std.Get_grades();
            cmb_grade.DataSource = grade_dt;
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";
            lbl_month.Text = BL.Globals.test_month_name;

            LoadStdData();
        }


        int move;
        int move_x;
        int move_y;

        
        private async void LoadStdData()
        {

            if (!await InternetFlow.EnsureAsync())
                return;

            try
            {
                int test_kind = BL.Globals.test_kind;
                int grade_id = BL.Globals.test_grade_id;
                int test_month = BL.Globals.test_month;


                if (BL.Globals.Test_Internet_Con)
                {

                    DataTable Dt;

                    dt_std_data.DataSource = null;

                    Waiting.Start();

                    if (test_kind == 1)
                    {
                        Dt = NATEG.Get_Degree_Data(test_month, grade_id);
                        dt_std_data.DataSource = Dt;

                        switch (grade_id)
                        {
                            case 10:
                            case 11:
                            case 1:
                            case 2:
                            case 3:
                                dt_std_data.Columns["دراسات"].Visible = false;
                                dt_std_data.Columns["مهارات"].Visible = false;
                                dt_std_data.Columns["تكنولوجيا"].Visible = false;
                                dt_std_data.Columns["تكنولوجيا"].Visible = false;
                                dt_std_data.Columns["علوم"].HeaderText = "متعدد";
                                break;

                            case 4:
                            case 5:
                            case 6:
                                dt_std_data.Columns["بدنية"].Visible = false;

                                break;

                            case 7:
                            case 8:
                            case 9:
                                dt_std_data.Columns["بدنية"].Visible = false;
                                dt_std_data.Columns["مهارات"].HeaderText = "فنية";
                                dt_std_data.Columns["تكنولوجيا"].HeaderText = "حاسب";
                                break;

                        }
                    }
                    else
                    {
                        Dt = NATEG.Get_Mark_Data(test_month, grade_id);
                        dt_std_data.DataSource = Dt;
                        switch (grade_id)
                        {
                            case 10:
                            case 11:
                                dt_std_data.Columns["دراسات"].Visible = false;
                                dt_std_data.Columns["فرنسى"].Visible = false;
                                dt_std_data.Columns["مهارات"].Visible = false;
                                dt_std_data.Columns["تكنولوجيا"].Visible = false;
                                dt_std_data.Columns["علوم"].HeaderText = "متعدد";
                                break;
                            case 1:
                            case 2:
                            case 3:
                                dt_std_data.Columns["دراسات"].Visible = false;
                                dt_std_data.Columns["مهارات"].Visible = false;
                                dt_std_data.Columns["تكنولوجيا"].Visible = false;
                                dt_std_data.Columns["علوم"].HeaderText = "متعدد";
                                break;

                            case 4:
                            case 5:
                            case 6:
                                dt_std_data.Columns["مهارات"].Visible = false;
                                dt_std_data.Columns["تكنولوجيا"].Visible = false;

                                break;

                            case 7:
                            case 8:
                            case 9:

                                dt_std_data.Columns["مهارات"].HeaderText = "فنية";
                                dt_std_data.Columns["تكنولوجيا"].HeaderText = "حاسب";
                                break;

                        }
                        Waiting.Stop();
                    }

                    dt_std_data.Columns["test_kind_Id"].Visible = false;
                    dt_std_data.Columns["grade_Id"].Visible = false;
                    dt_std_data.Columns["الصف"].Visible = false;
                    dt_std_data.Columns["نوع الإختبار"].Visible = false;
                    dt_std_data.Columns["userSchoolId"].Visible = false;
                    dt_std_data.Columns["show_data"].Visible = false;
                    
                    lbl_count.Text = dt_std_data.Rows.Count.ToString();
                    dt_std_data.Columns["اسم الطالب"].Width = 200;
                    Check_Hide_Natega();
                    Waiting.Stop();
                }
                else
                {
                    MSG.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                    Waiting.Stop();
                    this.Close();
                }
                Waiting.Stop();
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }
            finally
            {
                Waiting.Stop();
            }

        }

        private void Check_Hide_Natega()
        {
            try
            {
                foreach (DataGridViewRow row in dt_std_data.Rows)
                {
                    // Get Absent Student
                    if (row.Cells["show_data"].Value.ToString() == "False")
                    {
                        row.DefaultCellStyle.BackColor = Color.Crimson;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.SelectionBackColor = Color.OrangeRed;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = default;
                        row.DefaultCellStyle.ForeColor = default;
                        row.DefaultCellStyle.SelectionBackColor = default;

                    }

                }
            }
            catch(Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }
            
        }

        private async void Serach_Data()
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            try
            {
                int test_kind = BL.Globals.test_kind;
                int grade_id = BL.Globals.test_grade_id;
                int test_month = BL.Globals.test_month;

                DataTable Dt = new DataTable();
                switch (test_kind)
                {
                    case 1:
                        Dt = NATEG.Get_Degree_Data(test_month, grade_id, "yes", txt_std_data.Text);
                        break;
                    case 2:
                        Dt = NATEG.Get_Mark_Data(test_month, grade_id, "yes", txt_std_data.Text);
                        break;
                }


                dt_std_data.DataSource = Dt;
                lbl_count.Text = dt_std_data.Rows.Count.ToString();
                dt_std_data.Columns["اسم الطالب"].Width = 200;
                Check_Hide_Natega();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                Waiting.Stop();
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private async void FRM_SITE_STD_DATA_Load(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            dt_std_data.Columns["اسم الطالب"].Width = 200;
            cmb_grade.SelectedValue = BL.Globals.test_grade_id;
        }

        public async void cmb_grade_DropDownClosed(object sender, EventArgs e)
        {

            if (!await InternetFlow.EnsureAsync())
                return;


            try
            {
                BL.Globals.test_grade_id = Convert.ToInt32(cmb_grade.SelectedValue);
                txt_std_data.Text = "";

                LoadStdData();
                dt_std_data.Columns["اسم الطالب"].Width = 200;

                if (dt_std_data.Rows.Count == 0)
                {
                    MSG.ErrorMesg("لا توجد بيانات مسجلة لهذا الصف ..!");
                    return;
                }
                Waiting.Stop();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void txt_std_data_KeyUp(object sender, KeyEventArgs e)
        {
            Serach_Data();
        }

        private async void btn_edit_std_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            try
            {
                // Mark Or Degree --test_kind_id--
                int test_kind_id = BL.Globals.test_kind;

                string badnia = "0";
                string franch = "0";
                string sort_id = "0";

                string code = dt_std_data.CurrentRow.Cells["userSchoolId"].Value.ToString();
                string ar = dt_std_data.CurrentRow.Cells["عربى"].Value.ToString();
                string din = dt_std_data.CurrentRow.Cells["دين"].Value.ToString();
                string english = dt_std_data.CurrentRow.Cells["انجليزى"].Value.ToString();
                string sinces = dt_std_data.CurrentRow.Cells["علوم"].Value.ToString();
                string math = dt_std_data.CurrentRow.Cells["رياضيات"].Value.ToString();
                string social = dt_std_data.CurrentRow.Cells["دراسات"].Value.ToString();
                string maharat = dt_std_data.CurrentRow.Cells["مهارات"].Value.ToString();
                string tecnolgy = dt_std_data.CurrentRow.Cells["تكنولوجيا"].Value.ToString();
                string total = dt_std_data.CurrentRow.Cells["مجموع"].Value.ToString();

                // Get Test_Month From site --test_kind_Id_site--
                string test_kind_Id_site = dt_std_data.CurrentRow.Cells["test_kind_Id"].Value.ToString();
                
                string grade_Id = dt_std_data.CurrentRow.Cells["grade_Id"].Value.ToString();
                string name = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
                string grade = dt_std_data.CurrentRow.Cells["الصف"].Value.ToString();
                string test_kind = dt_std_data.CurrentRow.Cells["نوع الإختبار"].Value.ToString();

                switch (test_kind_id)
                {
                   
                    case 1:
                        badnia = dt_std_data.CurrentRow.Cells["بدنية"].Value.ToString();
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_cod.Text = code;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_ar.Text = ar;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_din.Text = din;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_english.Text = english;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_sinces.Text = sinces;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_math.Text = math;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_social.Text = social;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_badnia.Text = badnia;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_maharat.Text = maharat;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_tecnolgey.Text = tecnolgy;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_total.Text = total;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_test_kind_id.Text = test_kind_Id_site;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_grade_id.Text = grade_Id;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_name.Text = name;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_grade.Text = grade;
                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.txt_test_kind.Text = test_kind;

                        FRM_EDIT_SITE_DEGREES.Get_Edit_Site_Degree.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
                        break;
                    case 2:
                        franch = dt_std_data.CurrentRow.Cells["فرنسى"].Value.ToString();
                        sort_id = dt_std_data.CurrentRow.Cells["الترتيب"].Value.ToString();
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_cod.Text = code;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_ar.Text = ar;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_din.Text = din;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_english.Text = english;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_sinces.Text = sinces;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_math.Text = math;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_social.Text = social;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_french.Text = franch;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_maharat.Text = maharat;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_tecnolgey.Text = tecnolgy;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_total.Text = total;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_sort.Text = sort_id;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_test_kind_id.Text = test_kind_Id_site;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_grade_id.Text = grade_Id;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_name.Text = name;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_grade.Text = grade;
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.txt_test_kind.Text = test_kind;
                        
                        FRM_EDIT_SITE_MARKS.Get_Edit_Site_Mark.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
                        break;
                }

                


            }
            catch (Exception ex)
            {
                MSG.ErrorMesg();
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void dt_std_data_DoubleClick(object sender, EventArgs e)
        {
            btn_edit_std_Click(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_count_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dt_std_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_del_std_Click(object sender, EventArgs e)
        {
            MSG.ErrorMesg("هذا الإجراء غير متاح ..!");
        }

       
        private void pn_top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pic_help_Click(object sender, EventArgs e)
        {

        }

        private void btn_hide_data_Click(object sender, EventArgs e)
        {
            try
            {
                Waiting.Start();

                string std_name = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
                if (MSG.DialogeMsg("هل تريد تعديل حالة نتيجة ... ؟ " + "\n" + std_name) == DialogResult.No)
                {
                    MSG.MyExclamationMsg("تم إلغاء الإجراء..!");
                    Waiting.Stop();
                    return;
                }

                int student_id = Convert.ToInt32( dt_std_data.CurrentRow.Cells["userSchoolId"].Value);
                byte test_kind_id = Convert.ToByte(BL.Globals.test_month);
                string show_data = dt_std_data.CurrentRow.Cells["show_data"].Value.ToString();

                

                NATEG.Toggle_Hide_Data(student_id,test_kind_id,show_data);
                cmb_grade_SelectedIndexChanged(sender, e);
                Serach_Data();

                if(show_data == "False")
                {
                    MSG.MyMesg("تم إتاحة النتيجة للطالب ..!" + "\n" + std_name);
                    Waiting.Stop();
                }
                else
                {
                    MSG.MyExclamationMsg("تم حجب نتيجة الطالب ..!" + "\n" + std_name);
                    Waiting.Stop();
                }
               
                Waiting.Stop();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void dt_std_data_Click(object sender, EventArgs e)
        {
            if(dt_std_data.CurrentRow.Cells["show_data"].Value.ToString() != "False")
            {
                btn_hide_data.ButtonText = "حجب النتيجة";
            }
            else
            {
                btn_hide_data.ButtonText = "إلغاء الحجب";
            }
        }
    }
}
