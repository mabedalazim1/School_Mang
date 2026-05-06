using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.BL;
using School_Mang.BL.Services;
using School_Mang.BL.Enums;

namespace School_Mang.PL.STD
{
    public partial class FRM_TAHWELAT : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        
        MAIN.CLS_FUNCATIONS Func = new MAIN.CLS_FUNCATIONS();

        private byte test_year = 0;

        int permission_id = Properties.Settings.Default.permission_id;

        // Form Closed
        private static FRM_TAHWELAT frm_Tahwelat;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Tahwelat = null;
        }
        public static FRM_TAHWELAT Get_Frm_Tahwelat
        {
            get
            {
                if (frm_Tahwelat == null)
                {
                    frm_Tahwelat = new FRM_TAHWELAT();
                    frm_Tahwelat.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Tahwelat;
            }
        }
        public FRM_TAHWELAT()
        {
            InitializeComponent();

            if (frm_Tahwelat == null)
            {
                frm_Tahwelat = this;
            }

            // Set year val
            BL.Globals.My_Year = Convert.ToByte(Properties.Settings.Default.year_cod);
            lbl_year_b.Text = Properties.Settings.Default.MyYear.ToString();
            Waiting.Start();
            // Add Grade Data
            DataTable grade_dt = std.Get_grades();
            cmb_grade.DataSource = grade_dt;
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            DataRow dr = grade_dt.NewRow();
            dr["GradeDesc"] = "الكل";
            dr["Grade_Id"] = 0;
            grade_dt.Rows.InsertAt(dr, 0);

            // Get Trans  Data
            dt_std_data.DataSource = std.GET_Trans_Data(0, 3);
            dt_std_data.Columns["std_code"].Visible = false;
            dt_std_data.Columns["Year_Id"].Visible = false;
            dt_std_data.Columns["Grade_Id"].Visible = false;
            dt_std_data.Columns["Std_Status_Id"].Visible = false;
            dt_std_data.Columns["adrs"].Visible = false;
            dt_std_data.Columns["Kotob"].Visible = false;
            dt_std_data.Columns["Resom"].Visible = false;
            dt_std_data.Columns["Transfer_School"].Visible = false;
            dt_std_data.Columns["Transfer_reason"].Visible = false;
            dt_std_data.Columns["Guardian_name"].Visible = false;
            dt_std_data.Columns["Transfer_code"].Visible = false;
            dt_std_data.Columns["Class_Id"].Visible = false;
            dt_std_data.Columns["Trans_After_Year"].Visible = false;

            // Set User permission
            switch (permission_id)
            {
                case 3:
                    btn_del_std.Enabled = false;
                    break;
                case 2:
                    btn_del_std.Enabled = false;
                    break;
                case 1:
                    btn_del_std.Enabled = true;
                    break;
            }

            Waiting.Stop();
        }

        #region My Voids

        // Verify Stdunet Status 
        private Boolean Verify_Std()
        {
            if (dt_std_data.SelectedRows.Count == 0)
            {
                MSG.ErrorMesg("يرجى اختيار طالب ..!");
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Test_Data()
        {
            DataTable Dt_Trans_Current_Year = std.GET_Trans_Data(0, 3);
            DataTable Dt_Trans_Next_Year = std.GET_Trans_Data(0, 4);

            if (Dt_Trans_Current_Year.Rows.Count == 0 && Dt_Trans_Next_Year.Rows.Count == 00)
            {
                MSG.ErrorMesg("لا يوجد طلبات تحويل مسجلة هذا العام .. !");
                return;
            }
        }
        #endregion


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

        private void FRM_TAHWELAT_Load(object sender, EventArgs e)
        {
            cmb_grade.SelectedIndex = 0;

            cmb_status.SelectedIndex = 0;

            lbl_count.Text = dt_std_data.Rows.Count.ToString();

            Test_Data();

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangSelectedData();
        }

        public void ChangSelectedData()
        {
            dt_std_data.DataSource = std.GET_Trans_Data(
            Convert.ToInt32(cmb_grade.SelectedValue),
            Convert.ToInt32(cmb_status.SelectedIndex) + 3);

            lbl_count.Text = dt_std_data.Rows.Count.ToString();
            txt_std_data.Text = "";
        }
        private void cmb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_grade_SelectedIndexChanged(sender, e);
        }

        private void pic_help_MouseLeave(object sender, EventArgs e)
        {
            lbl_help.Visible = false;
        }

        private void pic_help_MouseHover(object sender, EventArgs e)
        {
            lbl_help.Text = " البحث بالاسم  ";
            lbl_help.Visible = true;
        }

        private void txt_std_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void txt_std_data_MouseLeave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
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

        private void txt_std_data_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                DataTable dt;
                dt = std.Search_Trans_Data(

                    Convert.ToInt32(cmb_grade.SelectedValue),
                    Convert.ToInt32(cmb_status.SelectedIndex + 3),
                    txt_std_data.Text);

                dt_std_data.DataSource = dt;

                lbl_count.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                Waiting.Stop();
            }
        }

        private void btn_new_std_Click(object sender, EventArgs e)
        {
            if (Verify_Std()) return;

            //BL.Globals.Update_Taheewl = true;

            byte resom = Convert.ToByte(dt_std_data.CurrentRow.Cells["Resom"].Value);
            byte kotob = Convert.ToByte(dt_std_data.CurrentRow.Cells["Kotob"].Value);

            var frm = FRM_TAHEEL_STD.Get_Tahweel_Std;

            frm.txt_trans_code.Text = dt_std_data.CurrentRow.Cells["Transfer_code"].Value.ToString();
            frm.txt_std_name.Text = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
            frm.txt_guardian_name.Text = dt_std_data.CurrentRow.Cells["Guardian_name"].Value.ToString();
            frm.txt_adrs.Text = dt_std_data.CurrentRow.Cells["adrs"].Value.ToString();
            frm.txt_transfer_reason.Text = dt_std_data.CurrentRow.Cells["Transfer_reason"].Value.ToString();
            frm.txt_to_school.Text = dt_std_data.CurrentRow.Cells["Transfer_School"].Value.ToString();
            frm.txt_std_code.Text = dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();

            if (resom == 0)
            {
                frm.chk_resom_no.Checked = true;
                frm.chk_resom_yes.Checked = false;
            }
            else
            {
                frm.chk_resom_no.Checked = false;
                frm.chk_resom_yes.Checked = true;
            }

            if (kotob == 0)
            {
                frm.chk_kotob_no.Checked = true;
                frm.chk_kotob_yes.Checked = false;
            }
            else
            {
                frm.chk_kotob_no.Checked = false;
                frm.chk_kotob_yes.Checked = true;
            }

            frm.transfer_status = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value);
            if (Convert.ToInt32(dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value) == 3)
            {
                frm.lbl_mohwel.Text = "محول إلى";
            }
            else
            {
                frm.lbl_mohwel.Text = "محول من";
            }

            frm.grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);

            AppNavigation.Instance
                .SetContext(c =>
                {
                    c.StudentCase = GetStudentCase.UpdateTaheewl;
                }).Show(frm);

           // FRM_TAHEEL_STD.Get_Tahweel_Std.ShowDialog();
        }

        private void btn_del_std_Click(object sender, EventArgs e)
        {
            if (Verify_Std()) return;
            try
            {
                string std_name = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
                string std_code = dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();
                int class_id = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Class_Id"].Value);
                int grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);
                int year = Properties.Settings.Default.year_cod;

                if (grade > 6)
                {
                    class_id += 2;
                }
                else
                {
                    class_id += 3;
                }

                bool Trans_After_Year = Convert.ToBoolean(dt_std_data.CurrentRow.Cells["Trans_After_Year"].Value);
                int Transfer_code = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Transfer_code"].Value);
                int current_year = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Year_Id"].Value);
                int new_year = Convert.ToInt32(std.Get_Count_New_Year(year + 1).Rows[0][0]);
                int std_found = Convert.ToInt32(std.Get_Count_Trans_Std(new_year, std_code).Rows[0][0]);
                int to_School;
                try
                {
                    if (MSG.DialogeErrMsg("هل تريد حذف طلب التحويل للطالب  / " + std_name + " .. !") == DialogResult.Yes)
                    {

                        // Delete Trans Data

                        if (dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value.ToString() == "4")
                        {
                            // If Std Trans To School
                            to_School = 1;
                            new_year = 0;
                        }
                        else
                        {
                            to_School = 0;
                        }
                      
                        // Delete Trans Data
                       std.Delete_Transfers_Data(
                            Transfer_code,
                            std_code,
                            current_year,
                            grade,
                            class_id,
                            new_year,// = 0 If Std Trans To School 
                            std_found, // = 0 If Std Not Found On Table
                            to_School, // = 1 If Std Trans To School,
                            Trans_After_Year // 1 if Trans After Year Begin
                            );
                        // Update DataGrid

                        cmb_grade_SelectedIndexChanged(sender, e);

                        MSG.MyMesg("تم حذف طلب التحويل للطالب  /  " + std_name + "...! ");
                    }
                    else
                    {
                        MSG.ErrorMesg("تم الغاء عملية الحذف ..!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MSG.ErrorMesg(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }


        private void btn_talab_tahewl_Click(object sender, EventArgs e)
        {
            if (Verify_Std()) return;

            // Get Trans Data
            int grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);
            int Std_Status_Id = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value);
            string trans_code = dt_std_data.CurrentRow.Cells["Transfer_code"].Value.ToString();
            string std_name = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
            int sana = (Convert.ToInt32(dt_std_data.CurrentRow.Cells["Year_Id"].Value)) + 2021;
            string year_data;
            string grade_desc = "";
            bool Trans_After_Year = Convert.ToBoolean(dt_std_data.CurrentRow.Cells["Trans_After_Year"].Value);

            // Get New Year & Grade For Tahewl To School
            if (Std_Status_Id == 3)
            {
                // If Trans After School
                if (Trans_After_Year)
                {
                    grade_desc = std.Get_Grade_Desc(grade).Rows[0]["GradeDesc"].ToString();
                }
                else
                {
                    //grade_desc = std.Get_Grade_Desc(grade + 1).Rows[0]["GradeDesc"].ToString();
                    grade_desc = std.Get_Grade_Desc(grade).Rows[0]["GradeDesc"].ToString();
                }
                year_data = std.Get_Year_Desc(sana + 1).Rows[0]["YearDesc"].ToString();
            }
            else
            {
                year_data = std.Get_Year_Desc(sana).Rows[0]["YearDesc"].ToString();

            }

            string[] year = year_data.Split('-');
            string year_desc = year[1] + "-" + year[0];

            // Open Report
            RPT.REPORT_CONNECTION RPT = new RPT.REPORT_CONNECTION();
            try
            {
                if (Std_Status_Id == 3)
                {

                    RPT.OpenTahwel_From_Report(trans_code, std_name, year_desc, grade_desc);
                }
                else
                {
                    RPT.OpenTahwel_To_Report(trans_code, std_name, year_desc);
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void btn_current_year_Click(object sender, EventArgs e)
        {
            if (test_year == 0)
            {
                //Set year val
                BL.Globals.My_Year = Convert.ToByte(Properties.Settings.Default.year_cod + 1);
                test_year = 1;
                btn_current_year.ButtonText = "العام الحالى";
                lbl_year_b.Text = (Properties.Settings.Default.MyYear + 1).ToString();
            }
            else
            {
                //Set year val
                BL.Globals.My_Year = Convert.ToByte(Properties.Settings.Default.year_cod);
                test_year = 0;
                btn_current_year.ButtonText = "العام القادم";
                lbl_year_b.Text = Properties.Settings.Default.MyYear.ToString();
            }

            cmb_grade_SelectedIndexChanged(sender, e);
            Test_Data();

        }

    }
}
