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
    public partial class FRM_FINAL_DATA : Form
    {
        BL.MSG msg = new BL.MSG();
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        BL.Waiting Waiting = new BL.Waiting();
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();


        // Form Closed
        private static FRM_FINAL_DATA frm_Final_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Final_Data = null;
        }
        public static FRM_FINAL_DATA Get_Frm_Final_Data
        {
            get
            {
                if (frm_Final_Data == null)
                {
                    frm_Final_Data = new FRM_FINAL_DATA();
                    frm_Final_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Final_Data;
            }
        }
        public FRM_FINAL_DATA()
        {
            InitializeComponent();

            if (frm_Final_Data == null)
            {
                frm_Final_Data = this;
            }
            if (BL.Globals.Edit_Golos)
            {
                // Add Grade Data
                DataTable grade_dt = std.Get_grades();
                cmb_grade.DataSource = grade_dt;
                cmb_grade.DisplayMember = "GradeDesc";
                cmb_grade.ValueMember = "Grade_Id";

                DataRow dr = grade_dt.NewRow();
                dr["GradeDesc"] = "الكل";
                dr["Grade_Id"] = 0;
                grade_dt.Rows.InsertAt(dr, 0);

            }
            else
            {
                DataTable grade_dt = std.Get_grades();
                cmb_grade.DataSource = grade_dt;
                cmb_grade.DisplayMember = "GradeDesc";
                cmb_grade.ValueMember = "Grade_Id";
            }


            LoadStdData();
        }

        private void LoadStdData()
        {
            try
            {
                if (BL.Globals.Edit_Golos)
                {
                    label11.Text = "تعديل أرقام الجلوس للطلاب ";
                    btn_amal_nesf.ButtonText = "تعديل رقم الجلوس";
                    btn_amal_akher.Visible = false;
                    btn_test_akher.Visible = false;
                    btn_absent_std.Visible = false;
                    btn_test_nesf.Visible = false;

                    btn_amal_nesf.Location = new Point(867, 8);
                    btn_close_b.Location = new Point(163, 8);

                    int grade_id = 0;
                    DataTable Dt;
                    Dt = NATEG.Get_Golos_Edit_Data(grade_id, "yes");
                    dt_std_data.DataSource = null;
                    Waiting.Wait();
                    dt_std_data.DataSource = Dt;
                    dt_std_data.Columns["std_code"].Visible = false;

                    lbl_count.Text = Dt.Rows.Count.ToString();
                }
                else
                {
                    label11.Text = "درجات الاختبارات النهائية";
                    btn_amal_nesf.ButtonText = "أعمال نصف العام";
                    btn_amal_akher.Visible = true;
                    btn_test_akher.Visible = true;
                    btn_absent_std.Visible = true;
                    btn_test_nesf.Visible = true;

                    btn_amal_nesf.Location = new Point(1018, 8);
                    btn_close_b.Location = new Point(7, 8);

                    int grade_id = BL.Globals.test_grade_id;
                    DataTable Dt;

                    Dt = NATEG.Get_Final_Total_Degree(grade_id);
                    dt_std_data.DataSource = null;
                    Waiting.Wait();
                    dt_std_data.DataSource = Dt;
                    dt_std_data.Columns["Absent_Any"].Visible = false;
                    Check_Absent();
                    lbl_count.Text = Dt.Rows.Count.ToString();

                    ChangLayOut();
                    
                }


                Waiting.End_WAit();
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

        private void ChangLayOut()
        {
            int grade_id = BL.Globals.test_grade_id;
            if (grade_id < 4 || grade_id > 9)
            {
                btn_amal_nesf.Visible = false;
                btn_amal_akher.Visible = false;
                btn_test_akher.Visible = true;
                btn_absent_std.Visible = false;
                btn_test_nesf.Visible = false;
                btn_test_akher.ButtonText = "تقييم أخر العام";
            }
            else
            {
                btn_amal_nesf.Visible = true;
                btn_amal_akher.Visible = true;
                btn_test_akher.Visible = true;
                btn_absent_std.Visible = true;
                btn_test_nesf.Visible = true;
                btn_test_akher.ButtonText = "اختبار أخر العام";
            }
        }
        private void Check_Absent()
        {
            foreach (DataGridViewRow row in dt_std_data.Rows)
            {
                // Get Absent Student
                if (row.Cells["Absent_Any"].Value.ToString() != "0")
                {
                    row.DefaultCellStyle.BackColor = Color.Crimson;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionBackColor = Color.OrangeRed;
                }

            }
        }

        private void Edit_Degree(string Final_Test_Name, byte Final_Test_Kind)
        {
            try
            {
                this.Visible = false;
                BL.Globals.Final_Test_Name = Final_Test_Name;
                BL.Globals.Final_Test_Kind = Final_Test_Kind;
                BL.Globals.Std_Golos = Convert.ToInt32(dt_std_data.CurrentRow.Cells[0].Value);
                FRM_FINAL_DEGREE_DATA.Get_Final_Degree_Data.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
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
            BL.Globals.Edit_Golos = false;

            Close();
            if (!BL.Globals.Edit_Golos)
            {
                FRM_FINAL_COUNT_DATA.Get_Frm_Final_Count_Data.Visible = true;
            }
        }

        private void FRM_FINAL_DATA_Load(object sender, EventArgs e)
        {
            try
            {
                if (BL.Globals.Edit_Golos)
                {
                    dt_std_data.Columns["studeNtname"].Width = 350;
                    dt_std_data.Columns["studeNtname"].HeaderText = "اسم الطالب";
                    dt_std_data.Columns["Golos"].HeaderText = "رقم الجلوس";
                    dt_std_data.Columns["Golos"].Width = 150;
                    dt_std_data.Columns["GradeDesc"].HeaderText = "الصف";
                    dt_std_data.Columns["Class_Desc"].HeaderText = "الفصل";
                    dt_std_data.Columns["YearDesc"].HeaderText = "العام الدراسي";
                    cmb_grade.SelectedValue = 0;

                }
                else
                {
                    dt_std_data.Columns["اسم الطالب"].Width = 200;
                    cmb_grade.SelectedValue = Convert.ToInt32(BL.Globals.test_grade_id);
                    Check_Absent();
                }
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void pic_help_MouseHover(object sender, EventArgs e)
        {
            lbl_help.Text = " البحث بالاسم";
            lbl_help.Visible = true;
        }

        private void pic_help_MouseLeave(object sender, EventArgs e)
        {
            lbl_help.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            txt_std_data.Focus();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        private void txt_std_data_Enter(object sender, EventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void txt_std_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void txt_std_data_Leave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        public void txt_std_data_OnValueChanged(object sender, EventArgs e)
        { 
            DataTable Dt;
            try
            {
                if (!BL.Globals.Edit_Golos)
                {
                    int grade = BL.Globals.test_grade_id;
                    string std_name = txt_std_data.Text;
                    Waiting.Wait();
                  
                    Dt = NATEG.Get_Final_Total_Degree(grade, std_name);
                }
                else
                {
                    int grade = Convert.ToInt32(cmb_grade.SelectedValue);
                    Dt = NATEG.Search_Golos_Data(grade,txt_std_data.Text);
                }
                

                dt_std_data.DataSource = Dt;
                lbl_count.Text = Dt.Rows.Count.ToString();
                Waiting.End_WAit();
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

        public void cmb_grade_DropDownClosed(object sender, EventArgs e)
        {
            int grade = Convert.ToInt32(cmb_grade.SelectedValue);
            try
            {
                Waiting.Wait();
                DataTable Dt;
                if (!BL.Globals.Edit_Golos)
                {
                    Dt = NATEG.Get_Final_Total_Degree(grade);
                    if (Dt.Rows.Count == 0)
                    {
                        msg.ErrorMesg("لا توجد بيانات مسجلة للصف المحدد ..!");
                        cmb_grade.SelectedValue = BL.Globals.test_grade_id;
                        return;
                    }
                    else
                    {
                        BL.Globals.test_grade_id = Convert.ToInt32(cmb_grade.SelectedValue);
                        dt_std_data.DataSource = Dt;
                        lbl_count.Text = Dt.Rows.Count.ToString();
                        Check_Absent();
                    }
                }
                else
                {
                    if(cmb_grade.SelectedIndex == 0)
                    {
                        Dt = NATEG.Get_Golos_Edit_Data(grade,"yes");
                        dt_std_data.DataSource = Dt;
                    }
                    else
                    {
                        Dt = NATEG.Get_Golos_Edit_Data(grade);
                        dt_std_data.DataSource = Dt;
                    }
                    lbl_count.Text = Dt.Rows.Count.ToString();
                }
                ChangLayOut();
                Waiting.End_WAit();
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

        private void btn_amal_nesf_Click(object sender, EventArgs e)
        {
            if (BL.Globals.Edit_Golos)
            {
                string code = dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();
                string std_name  = dt_std_data.CurrentRow.Cells["studeNtname"].Value.ToString();
                string golos = dt_std_data.CurrentRow.Cells["Golos"].Value.ToString();
                string grade_desc = dt_std_data.CurrentRow.Cells["GradeDesc"].Value.ToString();
                string class_desc = dt_std_data.CurrentRow.Cells["Class_Desc"].Value.ToString();
                string year_desc = dt_std_data.CurrentRow.Cells["YearDesc"].Value.ToString();
                
                if (golos == "") golos = "0";

                this.Hide();

                FRM_EDIT_GOLOS.Get_frm_Edit_Golos.golos = Convert.ToInt32(golos);
                FRM_EDIT_GOLOS.Get_frm_Edit_Golos.txt_code.Text = code;
                FRM_EDIT_GOLOS.Get_frm_Edit_Golos.txt_std_name.Text = std_name;
                FRM_EDIT_GOLOS.Get_frm_Edit_Golos.txt_golos.Text = golos;
                FRM_EDIT_GOLOS.Get_frm_Edit_Golos.txt_grade.Text = grade_desc;
                FRM_EDIT_GOLOS.Get_frm_Edit_Golos.txt_class.Text = class_desc;
                FRM_EDIT_GOLOS.Get_frm_Edit_Golos.txt_year.Text = year_desc;

                FRM_EDIT_GOLOS.Get_frm_Edit_Golos.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
                

            }
            else
            {
                Edit_Degree("أعمال نصف العام", 1);
            }
            
        }

        private void btn_test_nesf_Click(object sender, EventArgs e)
        {
            Edit_Degree("اختبار نصف العام", 2);
        }

        private void btn_amal_akher_Click(object sender, EventArgs e)
        {
            Edit_Degree("أعمال أخر العام", 3);
        }

        private void btn_test_akher_Click(object sender, EventArgs e)
        {
            Edit_Degree("اختبار أخر العام", 4);
        }

        private void btn_absent_std_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                BL.Globals.Std_Golos = Convert.ToInt32(dt_std_data.CurrentRow.Cells[0].Value);
                FRM_EDIT_ABSENT_STD.Get_Frm_Edit_absent_std.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }
    }
}
