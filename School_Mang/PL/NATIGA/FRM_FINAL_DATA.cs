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
            DataTable grade_dt = std.Get_grades();
            cmb_grade.DataSource = grade_dt;
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            LoadStdData();
        }
        
        private void LoadStdData()
        {
            try
            {
                int grade_id = BL.Globals.test_grade_id;
                DataTable Dt;

                Dt = NATEG.Get_Final_Total_Degree(grade_id);
                dt_std_data.DataSource = null;
                Waiting.Wait();
                dt_std_data.DataSource = Dt;
                dt_std_data.Columns["Absent_Any"].Visible = false;
                Check_Absent();
                lbl_count.Text = Dt.Rows.Count.ToString();

                Waiting.End_WAit();
            }
            catch(Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                Waiting.End_WAit();
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
            catch(Exception e)
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
            Close();
            FRM_FINAL_COUNT_DATA.Get_Frm_Final_Count_Data.Visible = true;
        }

        private void FRM_FINAL_DATA_Load(object sender, EventArgs e)
        {
            try
            {
                
                dt_std_data.Columns["اسم الطالب"].Width = 200;
                cmb_grade.SelectedValue = Convert.ToInt32(BL.Globals.test_grade_id);
                Check_Absent();
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

        private void txt_std_data_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                int grade = BL.Globals.test_grade_id;
                string std_name = txt_std_data.Text;
                Waiting.Wait();
                DataTable Dt;
                Dt = NATEG.Get_Final_Total_Degree(grade, std_name);

                dt_std_data.DataSource = Dt;
                lbl_count.Text = Dt.Rows.Count.ToString();

                Waiting.End_WAit();
            }
            catch(Exception ex)
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
            int grade;
            try
            {
                Waiting.Wait();
                
                grade = Convert.ToInt32(cmb_grade.SelectedValue);
                DataTable Dt;
                Dt = NATEG.Get_Final_Total_Degree(grade);
                if(Dt.Rows.Count == 0)
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

                Waiting.End_WAit();
            }catch(Exception ex)
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
            Edit_Degree("أعمال نصف العام", 1);
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
