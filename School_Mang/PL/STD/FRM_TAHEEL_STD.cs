using School_Mang.BL;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.STD
{
    public partial class FRM_TAHEEL_STD : Form, INavigationAware
    {

        private NavigationContext _context;

        public void SetNavigation(NavigationContext context)
        {
            _context = context;
            ApplyContext();
        }

        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        
        RPT.REPORT_CONNECTION RPT = new RPT.REPORT_CONNECTION();
        public int transfer_status;
        public int grade = 0;
        private byte transfer_saved_status;

        public byte rosom = 0;
        public byte kotob = 0;

        private byte save_data = 0;

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
            ApplyContext();
        }
        #region My Voids


        private void LoadEditData()
        {
            // Import Data From FrmCurrentStd
            var d = _context?.StudentData;
            if (d == null) return;

            txt_std_code.Text = d.StdCode;
            txt_std_name.Text = d.StudentFullName;
            txt_guardian_name.Text = d.FatherName;
            txt_adrs.Text = d.Address;
            grade = d.GradeId;
        }
        private Boolean Cheack_Tarns_Data()
        {
            DataTable Dt;
            DataTable DtTransData;
            Dt = std.GET_Trans_By_Code(txt_std_code.Text);
            if (Dt.Rows.Count != 0)
            {
                txt_trans_code.Text = Dt.Rows[0]["Transfer_code"].ToString();
                txt_grade.Text = Dt.Rows[0]["Grade_Id"].ToString();
                txt_year.Text = Dt.Rows[0]["Year_Id"].ToString();
                txt_trans_after.Text = Convert.ToBoolean(Dt.Rows[0]["Year_Id"]).ToString();
                DtTransData = std.Get_Tahewl_Data(txt_trans_code.Text);
                transfer_saved_status = Convert.ToByte(DtTransData.Rows[0]["Transfer_status"]);
                return true;
            }
            else
            {
                return false;
            }
        }
        private Boolean Cheack_Data(TextBox txt)
        {
            if (txt.Text == "")
            {
                MSG.ErrorMesg("تأكد من استكمال البيانات ! ..");
                txt.BackColor = Color.MistyRose;
                txt.Focus();
                Waiting.Stop();
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

            Waiting.Start();
            // Trans Code
            string current_year;
            string year = Properties.Settings.Default.MyYear.ToString().Substring(2, 2);
            if (_context?.CurrentYearData == true)
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
                Waiting.Stop();
                return Trans_cod;
            }
            else
            {
                Waiting.Stop();
                return Convert.ToInt32(Dt.Rows[0]["Max_Trans_Code"]) + 1;
            }

        }
        private Boolean Verify_Std_School_Code(string std_code, int year)
        {
            DataTable Dt;
            Dt = std.Verify_Std_School_Code(std_code, year);
            if (Dt.Rows.Count == 0)
            {
                Waiting.Stop();
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        private void ApplyContext()
        {
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

            chk_after.Checked = true;
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
            this.Dispose();
        }

        private void chk_resom_yes_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_resom_yes.Checked)
            {
                chk_resom_no.Checked = false;
                rosom = 1;
            }
            else
            {
                chk_resom_no.Checked = true;
                rosom = 0;
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
                bool Trans_After_Year = false;
                Waiting.Start();

                // Check Entry Data
                if (!Cheack_Data(txt_to_school)) return;
                if (!Cheack_Data(txt_adrs)) return;
                if (!Cheack_Data(txt_guardian_name)) return;
                if (!Cheack_Data(txt_transfer_reason)) return;

                //  New Trans Data  New Student
                if (_context?.StudentCase.HasFlag(GetStudentCase.UpdateTaheewl) != true)
                {

                    int year = Properties.Settings.Default.year_cod;
                    if (_context?.StudentCase.HasFlag(GetStudentCase.TaheewlToSchool) != true)
                    {
                        // Cheak If Student Has Data On Next Year Or Not 
                        if (!Verify_Std_School_Code(txt_std_code.Text, year + 1))
                        {
                            if (chk_after.Checked)
                            {
                                MSG.ErrorMesg("لا يمكن تحويل الطالب .. غير مقيد بالعام الجديد .. يمكنك تغيير العام ثم تحويل الطالب ... !");
                                Waiting.Stop();
                                return;
                            }
                            else
                            {
                                if (MSG.DialogeErrMsg("سوف يتم تحويل من المدرسة عن العام السابق .. هل تريد المتابعة ؟ ") != DialogResult.Yes) return;
                            }
                        }
                    }
                
                    try
                    {

                        // If Transfer To School
                        if (_context?.StudentCase.HasFlag(GetStudentCase.TaheewlToSchool) == true)
                        {
                            FRM_STD_ELTEHK.Get_Std_Eltehk.btn_new_std_Click(sender, e);
                            year += 1;
                       
                        }
                        else
                        {
                            // If Trans on Current Year After School Begin
                            if (chk_before.Checked)
                            {
                                Trans_After_Year = true;
                                year -= 1;
                            }
                            else
                            {
                                switch (grade)
                                {
                                    case 10:
                                        grade = 11;
                                        break;
                                    case 11:
                                        grade = 1;
                                        break;
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:
                                    case 7:
                                    case 8:
                                        grade += 1;
                                        break;
                                }
                                Trans_After_Year = false;

                            }
                        }

                        // Add Transfers Data
                        Waiting.Start();
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
                            grade,
                            Trans_After_Year);

                        // Get Trans Code After Save data
                        Waiting.Start();
                        if (Cheack_Tarns_Data())
                        {
                            // Del From New Year
                            std.Delete_School_Std_Data(txt_std_code.Text, year+2);
                            MSG.MyMesg("تم حفظ طلب التحويل بنجاح .. !");

                        }

                        else
                        {
                            MSG.ErrorMesg("لم يتم الحفظ ..!");
                            Waiting.Stop();
                            return;
                        }

                        // Update Current Std Data
                        var frm = FRM_CURRENT_STD.Get_Current_Std;
                        frm.txt_std_data.Text = "";
                        frm.ChangeSelectedData();
                    }
                    catch (Exception ex)
                    {
                        MSG.ErrorMesg(ex.Message);
                        Waiting.Stop();
                    }
                }
                // If Update Current Trans Data
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

                        FRM_TAHWELAT.Get_Frm_Tahwelat.ChangSelectedData();
                        MSG.MyMesg("تم تعديل طلب التحويل بنجاح .. !");


                    }
                    catch (Exception ex)
                    {
                        MSG.ErrorMesg(ex.Message);
                        Waiting.Stop();
                    }
                }
            // Update Current Std Data

            FRM_TAHWELAT.Get_Frm_Tahwelat.cmb_grade_SelectedIndexChanged(sender, e);

            // Data is Saved
            save_data = 1;
            btn_new_std.Enabled = false;


            Waiting.Stop();

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
            LoadEditData();


            if (_context?.StudentCase.HasFlag(GetStudentCase.UpdateTaheewl) == true)
            {
                lbl_title.Text = "تعديل طلب التحويل";
                btn_new_std.ButtonText = "تعديل";
                chk_after.Checked = true;
                chk_before.Visible = false;
                chk_after.Visible = false;

                // Data is Saved
                save_data = 1;
            }
            else
            {
                lbl_title.Text = "طلب تحويل طالب";
                btn_new_std.ButtonText = "حفظ";

                // Data Not Save Yet
                save_data = 0;
            }

            if (_context?.StudentCase.HasFlag(GetStudentCase.TaheewlToSchool) == true)
            {
                chk_after.Checked = true;
                chk_before.Visible = false;
                chk_after.Visible = false;
            }
            this.BeginInvoke(new Action(() =>
            {
                txt_to_school.Focus();
            }));
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

            if (chk_after.Checked)
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
                if (MSG.DialogeErrMsg("سوف يتم تحويل الطالب أثناء الدراسة .. هل تريد المتابعة ؟ ") != DialogResult.Yes)
                {
                    chk_after.Checked = true;
                    chk_before.Checked = false;

                    return;
                }

                chk_after.Checked = false;
                chk_kotob_yes.Checked = true;
                chk_kotob_no.Checked = false;
                chk_resom_yes.Checked = true;
                chk_resom_no.Checked = false;
            }
            else
            {
                chk_after.Checked = true;
                chk_kotob_yes.Checked = false;
                chk_resom_yes.Checked = false;
                chk_kotob_no.Checked = true;
                chk_resom_no.Checked = true;
            }
        }

        private void btn_edit_std_Click(object sender, EventArgs e)
        {
            if (_context?.StudentCase.HasFlag(GetStudentCase.TaheewlToSchool) == true)
            {
                if (Cheack_Tarns_Data())
                {
                    save_data = 1;
                }
                else
                {
                    save_data = 0;
                    MSG.ErrorMesg("يرجى حفظ طلب التحويل أولا .. !");
                }
            }

            try
            {
                // Check Saved Data
                if (save_data != 0)
                {
                    Waiting.Start();
                    // Get Year Desc
                    int sana = (Convert.ToInt32(txt_year.Text)) + 2021;

                    // To School
                    string year_data_To_Schhol = std.Get_Year_Desc(sana).Rows[0]["YearDesc"].ToString();
                    string[] year_To_Schhol = year_data_To_Schhol.Split('-');
                    string year_desc_To_Schhol = year_To_Schhol[1] + "-" + year_To_Schhol[0];

                    // From School
                    string year_data = std.Get_Year_Desc(sana + 1).Rows[0]["YearDesc"].ToString();
                    string[] year = year_data.Split('-');
                    string year_desc = year[1] + "-" + year[0];
                    string grade_desc = "";
                    // Get new Grade
                    int saved_grade = Convert.ToInt32(txt_grade.Text);
                    // If Trans After School
                    if (Convert.ToBoolean(txt_trans_after.Text))
                    {
                        grade_desc = std.Get_Grade_Desc(saved_grade).Rows[0]["GradeDesc"].ToString();
                    }
                    else
                    {
                        grade_desc = std.Get_Grade_Desc(saved_grade + 1).Rows[0]["GradeDesc"].ToString();
                    }

                    string std_name = txt_std_name.Text;
                    string trans_code = txt_trans_code.Text;


                    Waiting.Stop();
                    // Open Report
                    if(transfer_saved_status == 3)
                    {
                        RPT.OpenTahwel_From_Report(trans_code, std_name, year_desc, grade_desc);
                    }
                    else
                    {
                        RPT.OpenTahwel_To_Report(trans_code, std_name, year_desc_To_Schhol);
                    }
                }
                else
                {
                    MSG.ErrorMesg("يرجى حفظ طلب التحويل أولا .. !");
                    return;
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                Waiting.Stop();
            }
            Waiting.Stop();
        }
    }
}
