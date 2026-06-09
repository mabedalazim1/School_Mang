using School_Mang.BL;
using School_Mang.BL.Common;
using School_Mang.BL.DTO;
using School_Mang.BL.Enums;
using School_Mang.BL.Extensions;
using School_Mang.BL.Models;
using School_Mang.BL.Services;
using School_Mang.BL.Services.STD;
using System;
using System.Drawing;
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
        private readonly TransferData _transferData = new TransferData();
        private readonly TransferService _transferService = new TransferService();
        private readonly StudentSaveService _saveService = new StudentSaveService();
        private readonly ClassService _classService = new ClassService();

        RPT.REPORT_CONNECTION RPT = new RPT.REPORT_CONNECTION();
        public int transfer_status;
        public int grade = 0;
        public int studentStatus = 0;
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
            if (_context?.TransferData != null)
            {
                LoadTransfer(_context.TransferData);
                return;
            }

            if (_context?.StudentData != null)
            {
                LoadStudent(_context.StudentData);
                return;
            }
        }
        private void LoadTransfer(TransferEditData d)
        {
            txt_trans_code.Text = d.TransferCode;
            txt_std_name.Text = d.StdName;
            txt_guardian_name.Text = d.GuardianName;
            txt_adrs.Text = d.Address;
            txt_transfer_reason.Text = d.Reason;
            txt_to_school.Text = d.ToSchool;
            transfer_status = d.StatusId;
            grade = d.GradeId;
            lbl_mohwel.Text = d.StatusId == 3 ? "محول إلى" : "محول من";
            SetFlags(d.Resom, d.Kotob);
        }
        private void SetFlags(byte resom, byte kotob)
        {
            chk_resom_yes.Checked = resom != 0;
            chk_resom_no.Checked = resom == 0;

            chk_kotob_yes.Checked = kotob != 0;
            chk_kotob_no.Checked = kotob == 0;
        }

        private void LoadStudent(StudentDTO d)
        {
            txt_std_code.Text = d.StdCode;
            txt_std_name.Text = d.StudentFullName;
            txt_guardian_name.Text = d.FatherName;
            txt_adrs.Text = d.Address;
            grade = d.GradeId;
            transfer_status = d.TransferStatus;
            studentStatus = d.StudentStatus;
            txt_transfer_reason.Text = d.TransferReason;
        }

        private bool Cheack_Tarns_Data()
        {
            var stdCode = txt_std_code.Text;
            var data = _transferService.GetTransferData(stdCode);

            if (data != null)
            {
                txt_trans_code.Text = data.TransferCode;
                txt_grade.Text = data.GradeId.ToString();
                txt_year.Text = data.YearId.ToString();
                transfer_saved_status = data.TransferSavedStatus;
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool Cheack_Data(TextBox txt)
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

        private void AddNewStudent(StudentDTO d)
        {
            int newYear = Properties.Settings.Default.year_cod + 1;
            int classId = _classService.GetClassByGrade(d.GradeId);
            try
            {
                var req = new StudentSaveRequest
                {
                    StdCode = d.StdCode,
                    YearId = newYear,
                    GradeId = d.GradeId,
                    StatusId = 4,
                    ClassId = classId
                };
                _saveService.AddToSchool(req);

            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
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
            Waiting.Start();

            // Check Entry Data
            if (!Cheack_Data(txt_to_school)) return;
            if (!Cheack_Data(txt_adrs)) return;
            if (!Cheack_Data(txt_guardian_name)) return;
            if (!Cheack_Data(txt_transfer_reason)) return;

            //  New Trans Data  New Student
            if (_context?.StudentCase.Has(GetStudentCase.UpdateTaheewl) != true)
            {

                int year = Properties.Settings.Default.year_cod;
                if (_context?.StudentCase.Has(GetStudentCase.TaheewlToSchool) != true)
                {
                    // Cheak If Student Has Data On Next Year Or Not 
                    if (!_transferService.IsStudentRegistered(txt_std_code.Text, year + 1))
                    {
                        if (chk_after.Checked)
                        {
                            MSG.ErrorMesg("لا يمكن تحويل الطالب .. غير مقيد بالعام الجديد .. يمكنك تغيير العام ثم تحويل الطالب ... !");
                            Waiting.Stop();
                            return;
                        }
                        else
                        {
                            if (MSG.DialogeErrMsg("سوف يتم تحويل من المدرسة عن العام السابق .. هل تريد المتابعة ؟ ") != DialogResult.Yes)
                            {
                                Waiting.Stop();
                                return;
                            }
                        }
                    }
                }

                // If Transfer To School
                if (_context?.StudentCase.Has(GetStudentCase.TaheewlToSchool) == true)
                {
                    // Save TaheewlToSchool Not Etehak
                    AddNewStudent(_context.StudentData);
                }
                try
                {
                    // If Trans on Current Year After School Begin
                    var request = new TransferRequest
                    {
                        StdCode = txt_std_code.Text,
                        ToSchool = txt_to_school.Text,
                        GuardianName = txt_guardian_name.Text,
                        Reason = txt_transfer_reason.Text,
                        Address = txt_adrs.Text,
                        Grade = grade,
                        Year = Properties.Settings.Default.year_cod,
                        TransferStatus = transfer_status,
                        Rosom = rosom,
                        Kotob = kotob,
                        IsBeforeChecked = chk_before.Checked,
                        IsAfterChecked = chk_after.Checked,
                        IsUpdate = _context?.StudentCase.Has(GetStudentCase.UpdateTaheewl) == true,
                        IsSchoolTransfer = _context?.StudentCase.Has(GetStudentCase.TaheewlToSchool) == true,
                        CurrentYearData = _context?.CurrentYearData == true,
                        IsValidStudent = true
                    };


                    _transferService.CreateTransfer(request);

                    // Update Current Std Data
                    var frm = FRM_CURRENT_STD.Get_Current_Std;
                    frm.txt_std_data.Text = "";
                    frm.Get_School_Year_Data();

                    var frmNewStd = FRM_GET_STD.Get_Student;
                    frmNewStd.SearchStudents();

                    MSG.MyMesg("تم حفظ طلب التحويل بنجاح .. !");
                }
                catch (Exception ex)
                {
                    MSG.ErrorMesg(ex.Message);
                }
                finally
                {
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

                    var request = new TransferRequest
                    {
                        TransCode = Convert.ToInt32(txt_trans_code.Text),
                        ToSchool = txt_to_school.Text,
                        GuardianName = txt_guardian_name.Text,
                        Reason = txt_transfer_reason.Text,
                        Rosom = rosom,
                        Kotob = kotob,
                        Address = txt_adrs.Text
                    };

                    _transferService.UpdateTransfer(request);

                    // Update Current Std Data
                    FRM_TAHWELAT.Get_Frm_Tahwelat.ChangSelectedData();
                    MSG.MyMesg("تم تعديل طلب التحويل بنجاح .. !");



                }
                catch (Exception ex)
                {
                    MSG.ErrorMesg(ex.Message);

                }
                finally
                {
                    Waiting.Stop();
                }
            }
            // Update Current Std Data

            FRM_TAHWELAT.Get_Frm_Tahwelat.ChangSelectedData();

            // Data is Saved
            save_data = 1;
            btn_new_std.Enabled = false;

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


            if (_context?.StudentCase.Has(GetStudentCase.UpdateTaheewl) == true)
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

            if (_context?.StudentCase.Has(GetStudentCase.TaheewlToSchool) == true)
            {
                chk_after.Checked = true;
                chk_before.Visible = false;
                chk_after.Visible = false;
            }
            this.BeginInvoke(new Action(() =>
            {
                txt_to_school.Focus();
            }));

            // الطالب المستجد
            if (studentStatus == 1)
            {
                chk_after.Enabled = false;
                chk_before.Enabled = true;
                chk_before.Checked = true;
                chk_after.Checked = false;
                chk_kotob_no.Checked = false;
                chk_resom_no.Checked = false;
                chk_kotob_yes.Checked = true;
                chk_resom_yes.Checked = true;
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

            // الطالب المستجد
            if (studentStatus == 1)
                return;

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
            // الطالب المستجد
            if (studentStatus == 1)
                return;

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
            try
            {
                Waiting.Start();

                TransferData transferData = null;

                // لو تحويل إلى مدرسة
                if (_context?.StudentCase.Has(GetStudentCase.TaheewlToSchool) == true)
                {
                    transferData =
                        _transferService.GetTransferData(txt_std_code.Text);

                    if (transferData == null)
                    {
                        MSG.ErrorMesg("يرجى حفظ طلب التحويل أولا .. !");
                        return;
                    }
                }

                var reportData =
                    _transferService.GetTransferReportData(
                        txt_std_code.Text,
                        chk_before.Checked);

                if (reportData == null)
                {
                    MSG.ErrorMesg("بيانات التحويل غير موجودة");
                    return;
                }

                if (reportData.TransferSavedStatus == 3 || reportData.TransferSavedStatus == 7)
                {
                    RPT.OpenTahwel_From_Report(
                        reportData.TransferCode,
                        txt_std_name.Text,
                        reportData.FromSchoolYearDesc,
                        reportData.GradeDesc);
                }
                else
                {
                    RPT.OpenTahwel_To_Report(
                        reportData.TransferCode,
                        txt_std_name.Text,
                        reportData.ToSchoolYearDesc);
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
            }
        }
    }
}