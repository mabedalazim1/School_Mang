using DevExpress.Utils.MVVM.Services;
using School_Mang.BL;
using School_Mang.BL.Common;
using School_Mang.BL.Extensions;
using School_Mang.BL.DTO;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using School_Mang.BL.Services.Reports;
using School_Mang.BL.Services.STD;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace School_Mang.PL.STD.Services
{
    public class CurrentStdFormService
    {
        private readonly FRM_CURRENT_STD _form;
        private readonly NavigationContext _context;
        private readonly int _permissionId;
        private readonly StudentReportService _reportService = new StudentReportService();
        private readonly int _yearCod;
        private readonly StudentService _studentService; 
        private readonly LookupService _stdData = new LookupService();

        public CurrentStdFormService(
            FRM_CURRENT_STD form,
            NavigationContext context,
            int permissionId)
        {
            _form = form;
            _context = context;
            _permissionId = permissionId;
        }

        private bool _isApplyingContext;
        public void ApplyContext()
        {
            if (_isApplyingContext) return;

            try
            {
                _isApplyingContext = true;

                LoadGrades();
                ApplyStudentCaseRules();
                ApplyYearRules();
                ApplyPermissions();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                _isApplyingContext = false;
            }
        }

        private void LoadGrades()
        {
            DataTable grade_dt = _stdData.Get_grades();

            DataRow dr = grade_dt.NewRow();
            dr["GradeDesc"] = "الكل";
            dr["Grade_Id"] = 0;

            grade_dt.Rows.InsertAt(dr, 0);

            _form.cmb_grade.DataSource = grade_dt;
            _form.cmb_grade.DisplayMember = "GradeDesc";
            _form.cmb_grade.ValueMember = "Grade_Id";
        }

        private void ApplyStudentCaseRules()
        {
            if (_context == null) return;

            if (_context.StudentCase.IsElthak())
            {
                _form.btn_talab_elthak.Location = new Point(409, 15);
                _form.btn_del_std.Visible = false;
                _form.btn_tahwel.Visible = false;
            }
            else
            {
                _form.btn_del_std.Visible = true;
                _form.btn_tahwel.Visible = true;
            }
        }

        private void ApplyYearRules()
        {
            if (_context == null) return;

            if (_context.CurrentYearData)
            {
                _form.btn_tahwel.Visible = true;
                _form.btn_del_std.Location = new Point(208, 15);
            }
            else
            {
                _form.btn_tahwel.Visible = false;
                _form.btn_del_std.Location = new Point(278, 15);
            }
        }

        private void ApplyPermissions()
        {
            switch (_permissionId)
            {
                case 3:
                    _form.btn_new_std.Enabled = false;
                    _form.btn_tahwel.Enabled = false;
                    _form.btn_del_std.Enabled = false;
                    break;

                case 2:
                    _form.btn_new_std.Enabled = true;
                    _form.btn_tahwel.Enabled = true;
                    _form.btn_del_std.Enabled = false;
                    break;

                case 1:
                    _form.btn_new_std.Enabled = true;
                    _form.btn_tahwel.Enabled = true;
                    _form.btn_del_std.Enabled = true;
                    break;
            }
        }
        public void HandleNewStdClick(DataGridViewRow row)
        {
            if (row == null)
            {
                MSG.ErrorMesg("يرجى اختيار طالب ..!");
                return;
            }

            if (_context.StudentCase.IsDegreeStatement() == true)
            {
                ShowDegreeStatement(row);
                return;
            }

            OpenUpdateForm(row);
        }
        public void ShowDegreeStatement(DataGridViewRow row)
        {
            if (row == null)
            {
                MSG.ErrorMesg("يرجى اختيار طالب أولاً!");
                return;
            }

            try
            {
                int year = Properties.Settings.Default.year_cod;

                var gradeValue = row.Cells["Grade_Id"]?.Value;
                var stdCodeValue = row.Cells["std_code"]?.Value;

                if (gradeValue == null || stdCodeValue == null)
                {
                    MSG.ErrorMesg("بيانات الطالب غير مكتملة!");
                    return;
                }

                _reportService.OpenDegreeStatement(
                    year,
                    Convert.ToInt32(gradeValue),
                    stdCodeValue.ToString()
                );
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }
        private void OpenUpdateForm(DataGridViewRow row)
        {
            var frm = FRM_UPDATE_SCHOOL_STD.Get_Update_School_Std;

            int grade = Convert.ToInt32(row.Cells["Grade_Id"].Value);
            frm.grade = grade;

            if (row.Cells["Updated_by"].Value.ToString() != "")
            {
                DateTime my_date = Convert.ToDateTime(row.Cells["Updated_At"].Value.ToString());
                frm.lbl_edit_date.Visible = true;
                frm.lbl_by.Visible = true;
                frm.lbl_edit_by.Visible = true;
                frm.lbl_date.Visible = true;
                frm.lbl_edit_date.Text = my_date.ToString("dd/MM/yyyy");
                frm.lbl_edit_by.Text = row.Cells["Updated_by"].Value.ToString();
            }
            else
            {
                frm.lbl_edit_date.Visible = false;
                frm.lbl_edit_by.Visible = false;
                frm.lbl_by.Visible = false;
                frm.lbl_date.Visible = false;
            }

           frm.row_index = row.Index;


            // BL.Globals.Update_Std_Data = true;
        
            AppNavigation.Instance
                .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                .SetContext(c =>
                {
                    c.CurrentYearData = _context.CurrentYearData;
                    c.StudentState.UpdateStdData = true;
                    c.StudentData = new StudentDTO
                    {
                        OsraId = Convert.ToInt32(row.Cells["Osraa_Id"].Value),
                        StdCode = row.Cells["std_code"].Value?.ToString(),
                        StudentFullName = row.Cells["اسم الطالب"].Value?.ToString(),
                        StdName = row.Cells["std_name"].Value?.ToString(),
                        Nat = row.Cells["std_nat"].Value?.ToString(),
                        StudentStatus = Convert.ToInt32(row.Cells["Std_Status_Id"].Value),
                        GradeId = Convert.ToInt32(row.Cells["Grade_Id"].Value),
                        Sana = Convert.ToInt32(row.Cells["Year_Id"].Value),
                        GenderId = Convert.ToInt32(row.Cells["Gender_Id"].Value),
                        ClassId = Convert.ToInt32(row.Cells["Class_Id"].Value),
                        ReligionId = Convert.ToInt32(row.Cells["Religion_Id"].Value)
                    };
                }).Show(frm);
        }

        public void HandleDeleteStudent(DataGridViewRow row, int selectedClass, int gradeId)
        {
            if (row == null)
            {
                MSG.ErrorMesg("يرجى اختيار طالب .. !");
                return;
            }

            var result = StdValidationService.VerifyStdStatus(
                row.Cells["Std_Status_Id"]?.Value
            );

            if (!result.IsValid)
            {
                MSG.ErrorMesg(result.Message);
                return;
            }

            string std_name = row.Cells["اسم الطالب"].Value.ToString();
            string std_code = row.Cells["std_code"].Value.ToString();
            int row_index = row.Index;

            if (MSG.DialogeErrMsg("هل تريد حذف الطالب  " + std_name + "  ..؟") != DialogResult.Yes)
            {
                MSG.ErrorMesg("تم الغاء عملية الحذف ..!");
                return;
            }

            int year = SchoolDateHelper.GetCurrentYear(_yearCod, _context);

            _studentService.Delete_School_Std_Data(std_code, year);

            // 🔥 هنا الفرق
            _form.Get_Class_Data(gradeId);
            _form.txt_std_data.Text = "";

            if (row_index != 0)
            {
                row_index--;
                _form.dt_std_data.FirstDisplayedScrollingRowIndex = row_index;
                _form.dt_std_data.Rows[row_index].Selected = true;
                _form.dt_std_data.CurrentCell = _form.dt_std_data.Rows[row_index].Cells["اسم الطالب"];
            }

            _form.cmb_class.SelectedIndex = selectedClass;

            MSG.MyMesg("تم حذف الطالب  " + std_name + "...! ");
        }
    }
}

