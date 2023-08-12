using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.STD
{
    public partial class FRM_TAHWELAT : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.MSG msg = new BL.MSG();
        BL.Waiting Waiting = new BL.Waiting();
        MAIN.CLS_FUNCATIONS Func = new MAIN.CLS_FUNCATIONS();

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

            Waiting.Wait();
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
           
            dt_std_data.DataSource =  std.GET_Trans_Data(0,3);
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
            Waiting.End_WAit();
        }

        #region My Voids

        // Verify Stdunet Status 
        private Boolean Verify_Std()
        {
            if (dt_std_data.SelectedRows.Count == 0)
            {
                msg.ErrorMesg("يرجى اختيار طالب ..!");
                return true;
            }
            else
            {
                return false;
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
            dt_std_data.DataSource = std.GET_Trans_Data(
                Convert.ToInt32(cmb_grade.SelectedValue),
                Convert.ToInt32(cmb_status.SelectedIndex)+3);
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
                    Convert.ToInt32(cmb_status.SelectedIndex +3),
                    txt_std_data.Text);

                dt_std_data.DataSource = dt;

                lbl_count.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                Waiting.End_WAit();
            }
        }

        private void btn_new_std_Click(object sender, EventArgs e)
        {
            if (Verify_Std()) return;

            BL.Globals.Update_Taheewl = true;
            byte resom = Convert.ToByte(dt_std_data.CurrentRow.Cells["Resom"].Value);
            byte kotob = Convert.ToByte(dt_std_data.CurrentRow.Cells["Kotob"].Value);

           
            FRM_TAHEEL_STD.Get_Tahweel_Std.txt_trans_code.Text = dt_std_data.CurrentRow.Cells["Transfer_code"].Value.ToString();
            FRM_TAHEEL_STD.Get_Tahweel_Std.txt_std_name.Text = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
            FRM_TAHEEL_STD.Get_Tahweel_Std.txt_guardian_name.Text = dt_std_data.CurrentRow.Cells["Guardian_name"].Value.ToString();
            FRM_TAHEEL_STD.Get_Tahweel_Std.txt_adrs.Text = dt_std_data.CurrentRow.Cells["adrs"].Value.ToString();
            FRM_TAHEEL_STD.Get_Tahweel_Std.txt_transfer_reason.Text = dt_std_data.CurrentRow.Cells["Transfer_reason"].Value.ToString();
            FRM_TAHEEL_STD.Get_Tahweel_Std.txt_to_school.Text = dt_std_data.CurrentRow.Cells["Transfer_School"].Value.ToString();
            
            if(resom == 0)
            {
                FRM_TAHEEL_STD.Get_Tahweel_Std.chk_resom_no.Checked = true;
                FRM_TAHEEL_STD.Get_Tahweel_Std.chk_resom_yes.Checked = false;
            }
            else
            {
                FRM_TAHEEL_STD.Get_Tahweel_Std.chk_resom_no.Checked = false;
                FRM_TAHEEL_STD.Get_Tahweel_Std.chk_resom_yes.Checked = true;
            }

            if (kotob == 0)
            {
                FRM_TAHEEL_STD.Get_Tahweel_Std.chk_kotob_no.Checked = true;
                FRM_TAHEEL_STD.Get_Tahweel_Std.chk_kotob_yes.Checked = false;
            }
            else
            {
                FRM_TAHEEL_STD.Get_Tahweel_Std.chk_kotob_no.Checked = false;
                FRM_TAHEEL_STD.Get_Tahweel_Std.chk_kotob_yes.Checked = true;
            }

            FRM_TAHEEL_STD.Get_Tahweel_Std.transfer_status = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value);
            if(Convert.ToInt32(dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value) == 3)
            {
                FRM_TAHEEL_STD.Get_Tahweel_Std.lbl_mohwel.Text = "محول إلى";
            }
            else
            {
                FRM_TAHEEL_STD.Get_Tahweel_Std.lbl_mohwel.Text = "محول من";
            }

            FRM_TAHEEL_STD.Get_Tahweel_Std.grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);

            FRM_TAHEEL_STD.Get_Tahweel_Std.ShowDialog();
        }

        private void btn_del_std_Click(object sender, EventArgs e)
        {
            if (Verify_Std()) return;

            string std_name = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
            string std_code = dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();
            int class_id = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Class_Id"].Value);
            int grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);
            int year = Properties.Settings.Default.year_cod;

            if(grade > 6)
            {
                class_id += 2;
            }
            else
            {
                class_id += 3;
            }

            int new_year = Convert.ToInt32(std.Get_Count_New_Year(year + 1).Rows[0][0]);
            int std_found=Convert.ToInt32(std.Get_Count_Trans_Std(new_year, std_code).Rows[0][0]);
            int to_School;
            try
            {
                if(msg.DialogeErrMsg("هل تريد حذف طلب التحويل للطالب  / " + std_name +" .. !") == DialogResult.Yes)
                {
                    msg.MyMesg(dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value.ToString());
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
                    msg.MyMesg(to_School.ToString());
                    std.Delete_Transfers_Data(
                        Convert.ToInt32(dt_std_data.CurrentRow.Cells["Transfer_code"].Value),
                        dt_std_data.CurrentRow.Cells["std_code"].Value.ToString(),
                        Convert.ToInt32(dt_std_data.CurrentRow.Cells["Year_Id"].Value),
                        grade,
                        class_id,
                        new_year,// = 0 If Std Trans To School 
                        std_found, // = 0 If Std Not Found On Table
                        to_School // = 1 If Std Trans To School
                        );
                    // Update DataGrid

                    cmb_grade_SelectedIndexChanged(sender, e);

                    msg.MyMesg("تم حذف طلب التحويل للطالب  /  " + std_name + "...! ");
                }
                else
                {
                    msg.ErrorMesg("تم الغاء عملية الحذف ..!");
                    return;
                }
            }catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void btn_talab_elthak_Click(object sender, EventArgs e)
        {
            if (Verify_Std()) return;
        }
    }
}
