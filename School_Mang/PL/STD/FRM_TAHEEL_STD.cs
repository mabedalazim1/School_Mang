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
    public partial class FRM_TAHEEL_STD : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.MSG msg = new BL.MSG();
        BL.Waiting Waiting = new BL.Waiting();

        public int transfer_status;
        public int grade = 0;

        public byte rosom = 0;
        public byte kotob = 0;

        private short trans_year = 0;
        private short trans_grade = 0;

        int permission_id = Properties.Settings.Default.permission_id;

        // Form Closed
        private static FRM_TAHEEL_STD frm_Tahweel_Std;

        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Tahweel_Std = null;
        }
        public static FRM_TAHEEL_STD Get_Tahweel_Std
        {
            get
            {
                if (frm_Tahweel_Std == null)
                {
                    frm_Tahweel_Std = new FRM_TAHEEL_STD();
                    frm_Tahweel_Std.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Tahweel_Std;
            }
        }

        public FRM_TAHEEL_STD()
        {
            InitializeComponent();

            if (frm_Tahweel_Std == null)
            {
                frm_Tahweel_Std = this;
            }
            chk_kotob_no.Checked = true;
            chk_resom_no.Checked = true;


            // Set User permission
            switch (permission_id)
            {
                case 3:
                    btn_new_std.Enabled = false;
                    break;
                case 1:
                case 2:
                    btn_new_std.Enabled = true;
                    break;
            }


            txt_std_name.Focus();
            chk_after.Checked = true;
        }
        #region My Voids

        private Boolean Cheack_Data(TextBox txt)
        {
            if (txt.Text == "")
            {
                msg.ErrorMesg("تأكد من استكمال البيانات ! ..");
                txt.BackColor = Color.MistyRose;
                txt.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        // Generate Trans Code 
        private int Trans_cod()
        {

            Waiting.Wait();
            // Trans Code
            string current_year;
            string year = Properties.Settings.Default.MyYear.ToString().Substring(2, 2);
            if (BL.Globals.Current_Year_Data)
            {
                current_year = year;
            }
            else
            {
                current_year = (Convert.ToInt32(year) + 1).ToString();
            }

            DataTable Dt = std.Get_Trans_Code(current_year);
            if (Dt.Rows[0]["Max_Trans_Code"].ToString() == "")
            {
                int Trans_cod = Convert.ToInt32(current_year + "001");
                Waiting.End_WAit();
                return Trans_cod;
            }
            else
            {
                Waiting.End_WAit();
                return Convert.ToInt32(Dt.Rows[0]["Max_Trans_Code"]) + 1;
            }

        }
        private Boolean Verify_Std_School_Code(string std_code, int year)
        {
            DataTable Dt;
            Dt = std.Verify_Std_School_Code(std_code, year);
            if (Dt.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            BL.Globals.Update_Taheewl = false;
            this.Close();
            this.Dispose();
        }

        private void chk_resom_yes_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_resom_yes.Checked)
            {
                chk_resom_no.Checked = false;
                rosom = 0;
            }
            else
            {
                chk_resom_no.Checked = true;
                rosom = 1;
            }
        }

        private void chk_kotob_yes_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_kotob_yes.Checked)
            {
                chk_kotob_no.Checked = false;
                kotob = 1;
            }
            else
            {
                chk_kotob_no.Checked = true;
                kotob = 0;
            }
        }

        private void chk_kotob_no_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_kotob_no.Checked)
            {
                chk_kotob_yes.Checked = false;
                kotob = 0;
            }
            else
            {
                chk_kotob_yes.Checked = true;
                kotob = 1;
            }
        }

        private void chk_resom_no_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_resom_no.Checked)
            {
                chk_resom_yes.Checked = false;
                rosom = 0;
            }
            else
            {
                chk_resom_yes.Checked = true;
                rosom = 1;
            }
        }

        private void btn_new_std_Click(object sender, EventArgs e)
        {
            if (!Cheack_Data(txt_to_school)) return;
            if (!Cheack_Data(txt_adrs)) return;
            if (!Cheack_Data(txt_guardian_name)) return;
            if (!Cheack_Data(txt_transfer_reason)) return;

            Waiting.Wait();
            if (!BL.Globals.Update_Taheewl)
            {
                int year = Properties.Settings.Default.year_cod;
                if (!Verify_Std_School_Code(txt_std_code.Text, year+1))
                {
                    if (chk_after.Checked)
                    {
                        msg.ErrorMesg("لا يمكن تحويل الطالب .. غير مقيد بالعام الجديد .. يمكنك تغيير العام ثم تحويل الطالب ... !");
                        Waiting.End_WAit();
                        return;
                    }
                    else
                    {
                        if (msg.DialogeErrMsg("سوف يتم تحويل من المدرسة عن العام السابق .. هل تريد المتابعة ؟ ") != DialogResult.Yes) return;

                        // Get Trans Year And Grade For Old Std
                      
                            year -= 1;
                            grade -= 1;
                    }
                   
                }
                try
                {
                    // If Transfer To School
                    if (BL.Globals.Taheewl_To_School)
                    {
                        FRM_STD_ELTEHK.Get_Std_Eltehk.btn_new_std_Click(sender, e);
                        year += 1;
                        BL.Globals.Taheewl_To_School = false;
                    }


                    // Add Transfers Data
                    std.Add_Transfers_Data(
                        Trans_cod().ToString(),
                        txt_std_code.Text,
                        txt_to_school.Text,
                        transfer_status,
                        year,
                        txt_guardian_name.Text,
                        txt_transfer_reason.Text,
                        rosom, kotob,
                        txt_adrs.Text,
                        grade);


                    msg.MyMesg("تم حفظ طلب التحويل بنجاح .. !");

                    // Update Current Std Data
                    FRM_GET_STD.Get_Student.txt_std_data.Text = "";
                    FRM_GET_STD.Get_Student.txt_std_data_OnValueChanged(sender, e);
                }
                catch (Exception ex)
                {
                    msg.ErrorMesg(ex.Message);
                    Waiting.End_WAit();
                }
            }
            else
            {
                try
                {// Update Transfers Data
                    if (chk_resom_no.Checked)
                    {
                        rosom = 0;
                    }
                    else
                    {
                        rosom = 1;
                    }

                    if (chk_kotob_no.Checked)
                    {
                        kotob = 0;
                    }
                    else
                    {
                        kotob = 1;
                    }


                    std.Update_Trans_Data(
                        Convert.ToInt32(txt_trans_code.Text),
                        txt_to_school.Text,
                        txt_guardian_name.Text,
                        txt_transfer_reason.Text,
                        rosom, kotob,
                        txt_adrs.Text);

                    // Update Current Std Data

                    FRM_TAHWELAT.Get_Frm_Tahwelat.cmb_grade_SelectedIndexChanged(sender, e);
                    msg.MyMesg("تم تعديل طلب التحويل بنجاح .. !");


                }
                catch (Exception ex)
                {
                    msg.ErrorMesg(ex.Message);
                    Waiting.End_WAit();
                }
            }
            // Update Current Std Data

            FRM_TAHWELAT.Get_Frm_Tahwelat.cmb_grade_SelectedIndexChanged(sender, e);
            btn_new_std.Enabled = false;

            Waiting.End_WAit();

        }

        private void txt_to_school_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_to_school.BackColor = Color.White;
        }

        private void txt_guardian_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_guardian_name.BackColor = Color.White;
        }

        private void txt_adrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_adrs.BackColor = Color.White;
        }

        private void txt_transfer_reason_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_transfer_reason.BackColor = Color.White;
        }

        private void FRM_TAHEEL_STD_Load(object sender, EventArgs e)
        {
            if (BL.Globals.Update_Taheewl)
            {
                lbl_title.Text = "تعديل طلب التحويل";
                btn_new_std.ButtonText = "تعديل";
                chk_after.Checked = true;
                chk_before.Visible = false;
                chk_after.Visible = false;
            }
            else
            {
                lbl_title.Text = "طلب تحويل طالب";
                btn_new_std.ButtonText = "حفظ";
            }

            if (BL.Globals.Taheewl_To_School)
            {
                chk_after.Checked = true;
                chk_before.Visible = false;
                chk_after.Visible = false;
            }
        }

        private void FRM_TAHEEL_STD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_close_b_Click(sender, e);
            }
        }

        private void chk_after_CheckedChanged(object sender, EventArgs e)
        {

            if(chk_after.Checked )
            {

                chk_before.Checked = false;
            }
            else
            {
                chk_before.Checked = true;
            }
        }

        private void chk_before_CheckedChanged(object sender, EventArgs e)
        {
           
            if (chk_before.Checked)
            {
                if (msg.DialogeErrMsg("سوف يتم تحويل الطالب أثناء الدراسة .. هل تريد المتابعة ؟ ") != DialogResult.Yes) 
                {
                    chk_after.Checked = true;
                    chk_before.Checked = false;
                    return;
                }
                
                chk_after.Checked = false;
                
            }
            else
            {
                chk_after.Checked = true;
            }
        }
    }
}
