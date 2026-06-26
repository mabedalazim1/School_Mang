using School_Mang.BL;
using School_Mang.BL.Common;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.DTO;
using School_Mang.BL.Enums;
using School_Mang.BL.Extensions;
using School_Mang.BL.Services;
using School_Mang.BL.Services.Reports;
using School_Mang.BL.Services.STD;
using School_Mang.PL.STD.Mappers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace School_Mang.PL.STD
{
    public partial class FRM_CURRENT_STD : Form, INavigationAware
    {

        private NavigationContext _context;
        private readonly ElthakReportService _elthakService = new ElthakReportService();
        private readonly LookupService _stdData = new LookupService();
        private readonly StudentReportService _reportService = new StudentReportService();
        private readonly StudentService _studentService = new StudentService();

        private readonly int _yearCod = Properties.Settings.Default.year_cod;

        public void SetNavigation(NavigationContext context)
        {
            _context = context;

            ApplyContext();

            LoadInitialData();
        }

        private bool _showUpdatedAt = false;

        private int _loadingDepth = 0;

        private bool IsLoading => _loadingDepth > 0;

        private void BeginLoad() => _loadingDepth++;
        private void EndLoad() => _loadingDepth--;

        private bool _isDoubleClickBusy;

        int year_cod = Properties.Settings.Default.year_cod;
        int permission_id = Properties.Settings.Default.permission_id;

        public short grade = 0;

        // Form Closed
        private static FRM_CURRENT_STD frm_Current_Std;

        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Current_Std = null;
            
        }
        public static FRM_CURRENT_STD Get_Current_Std
        {
            get
            {
                if (frm_Current_Std == null)
                {
                    frm_Current_Std = new FRM_CURRENT_STD();
                    frm_Current_Std.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Current_Std;
            }
        }

        public FRM_CURRENT_STD()
        {
            InitializeComponent();

            if (frm_Current_Std == null)
            {
                frm_Current_Std = this;
            }

        }

        private bool _isApplyingContext;
        private bool _gridInitialized = false;

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

            cmb_grade.DataSource = grade_dt;
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";
        }

        private void ApplyStudentCaseRules()
        {
            if (_context == null) return;

            if (_context.StudentCase.IsElthak())
            {
                btn_talab_elthak.Location = new Point(409, 15);
                btn_del_std.Visible = false;
                btn_tahwel.Visible = false;
            }
            else
            {

                btn_del_std.Visible = true;
                btn_tahwel.Visible = true;
            }
        }

        private void ApplyYearRules()
        {
            if (_context == null) return;

            if (_context.CurrentYearData)
            {
                btn_tahwel.Visible = true;
                btn_del_std.Location = new Point(208, 15);
            }
            else
            {
                btn_tahwel.Visible = false;
                btn_del_std.Location = new Point(278, 15);
            }
        }

        private void ApplyPermissions()
        {
            switch (permission_id)
            {
                case 3:
                    btn_new_std.Enabled = false;
                    btn_tahwel.Enabled = false;
                    btn_del_std.Enabled = false;
                    break;

                case 2:
                    btn_new_std.Enabled = true;
                    btn_tahwel.Enabled = true;
                    btn_del_std.Enabled = false;
                    break;

                case 1:
                    btn_new_std.Enabled = true;
                    btn_tahwel.Enabled = true;
                    btn_del_std.Enabled = true;
                    break;
            }
        }

        public void SelectRow(int index)
        {
            if (index < 0) return;

            if (dt_std_data.DataSource == null || dt_std_data.Rows.Count == 0)
                return;

            if (index >= dt_std_data.Rows.Count)
                index = dt_std_data.Rows.Count - 1;

            dt_std_data.ClearSelection();
            dt_std_data.Rows[index].Selected = true;
            dt_std_data.FirstDisplayedScrollingRowIndex = index;
        }

        int move;
        int move_x;
        int move_y;

        #region My Voids

        private void HideUpdatedAtColumn()
        {
            if (dt_std_data.Columns.Contains("Updated_At"))
            {
                dt_std_data.Columns["Updated_At"].Visible = false;
            }

            _showUpdatedAt = false;
        }

        // Get School Year Data
        private void LoadInitialData()
        {
           // Get_Class_Data(1);
            Get_School_Year_Data();
        }

        public void Get_School_Year_Data(bool sortByUpdatedAt = false)
        {
            if (_context == null)
                return;

            try
            {
                Waiting.Start();

                int my_grade = SafeConverter.GetInt(cmb_grade.SelectedValue);
                int year = SchoolDateHelper.GetCurrentYear(year_cod, _context);

                var dt = _studentService.GetStudentsByYear(year, my_grade, 0, sortByUpdatedAt);

                dt_std_data.SuspendLayout();

                dt_std_data.DataSource = dt;

                dt_std_data.ResumeLayout();
                if (!_gridInitialized)
                {
                    ApplyBaseGridLayout();
                    ApplyContextGridLayout();
                    _gridInitialized = true;
                }

                ShowUpdate();

                lbl_count.Text = dt.Rows.Count.ToString();

                if (!_context.CurrentYearData)
                {
                    btn_del_std.Visible = false;
                }

                _context?.PostAction?.Invoke();
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

        private void ApplyBaseGridLayout()
        {
            GridHelper.SetColumnsVisibility(dt_std_data,
                ColumnVisibility.Hide,
                "std_code", "Grade_Id", "Religion_Id", "Gender_Id",
                "Std_Status_Id", "Osraa_Id", "Year_Id", "Class_No", "Class_Id",
                "father_name", "std_name", "std_nat", "year", "old_grade",
                "year_desc", "Updated_by", "Updated_At"
            );
           
        }
        private void ApplyContextGridLayout()
        {
            if (_context.StudentCase.IsDetails())
            {
                GridHelper.SetColumnsVisibility(dt_std_data,
                    ColumnVisibility.Hide,
                    "الفصل", "الديانة", "النوع", "الحالة");

                GridHelper.SetColumnsVisibility(dt_std_data,
                    ColumnVisibility.Show,
                    "العنوان", "هاتف الأب", "هاتف الأم");

                btn_del_std.Visible = false;
                btn_talab_elthak.Visible = false;
            }
            else
            {
                GridHelper.SetColumnsVisibility(dt_std_data,
                    ColumnVisibility.Hide,
                    "العنوان", "هاتف الأب", "هاتف الأم");

                GridHelper.SetColumnsVisibility(dt_std_data,
                    ColumnVisibility.Show,
                    "الفصل", "الديانة", "النوع", "الحالة");

                btn_del_std.Visible = true;
                btn_talab_elthak.Visible = true;
            }
        }

        private void ShowUpdate()
        {
            dt_std_data.Columns["Updated_At"].Visible = _showUpdatedAt;

            if (_showUpdatedAt)
            {
                dt_std_data.Columns["Updated_At"].HeaderText = "آخر تعديل";
                dt_std_data.Columns["Updated_At"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }
        // Get Class Data
        public void Get_Class_Data(int gradeId, int classId = 0)
        {
            BeginLoad();

            Waiting.Start();

            try
            {
                LoadGradeClasses(gradeId);
                cmb_class.SelectedValue = classId;

                LoadStudents(gradeId, classId);
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
                EndLoad();
            }
        }
        // Get Classes
        private void LoadGradeClasses(int gradeId)
        {
            var dt = _studentService.GetGradeData(gradeId);

            DataRow dr = dt.NewRow();
            dr["Class_Desc"] = "الكل";
            dr["Class_Id"] = 0;
            dt.Rows.InsertAt(dr, 0);

            cmb_class.DataSource = dt;
            cmb_class.DisplayMember = "Class_Desc";
            cmb_class.ValueMember = "Class_Id";
        }

        // Get Students
        private void LoadStudents(int gradeId, int classId)
        {

            int year = SchoolDateHelper.GetCurrentYear(year_cod, _context);
            var dt = _studentService.GetStudentsByYear(year, gradeId, classId);

            dt_std_data.DataSource = dt;
            lbl_count.Text = dt.Rows.Count.ToString();

        }

        private StudentDTO MapStudentFromRow(DataGridViewRow row)
        {
            return new StudentDTO
            {
                OsraId = SafeConverter.GetInt(row.Cells["Osraa_Id"].Value),
                StdCode = SafeConverter.GetString(row.Cells["std_code"].Value),
                StudentFullName = SafeConverter.GetString(row.Cells["اسم الطالب"].Value),
                StdName = SafeConverter.GetString(row.Cells["std_name"].Value),
                Nat = SafeConverter.GetString(row.Cells["std_nat"].Value),
                StudentStatus = SafeConverter.GetInt(row.Cells["Std_Status_Id"].Value),
                GradeId = SafeConverter.GetInt(row.Cells["Grade_Id"].Value),
                Sana = SafeConverter.GetInt(row.Cells["Year_Id"].Value),
                GenderId = SafeConverter.GetInt(row.Cells["Gender_Id"].Value),
                ClassId = SafeConverter.GetInt(row.Cells["Class_Id"].Value),
                ReligionId = SafeConverter.GetInt(row.Cells["Religion_Id"].Value)
            };
        }

        private void HandleNewStdClick(DataGridViewRow row)
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

        private void ShowDegreeStatement(DataGridViewRow row)
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

            int grade = SafeConverter.GetInt(row.Cells["Grade_Id"].Value);
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
                    c.StudentData = MapStudentFromRow(row);
                }).Show(frm);
        }

        private void HandleDeleteStudent(DataGridViewRow row, int selectedClass, int gradeId)
        {
            if (row == null)
            {
                MSG.ErrorMesg("يرجى اختيار طالب .. !");
                return;
            }
            string std_name = row.Cells["اسم الطالب"].Value.ToString();
            string std_code = row.Cells["std_code"].Value.ToString();
            int row_index = row.Index;
            var year = SchoolDateHelper.GetCurrentYear(_yearCod, _context);

            var result = _studentService.CanDeleteStudent(std_code,
                                          year,
                                          row.Cells["Std_Status_Id"].Value);

            if (!result.IsValid)
            {
                MSG.ErrorMesg(result.Message);
                return;
            }

            if (MSG.DialogeErrMsg("هل تريد حذف الطالب  " + std_name + "  ..؟") != DialogResult.Yes)
            {
                MSG.ErrorMesg("تم الغاء عملية الحذف ..!");
                return;
            }

            _studentService.DeleteStudent(std_code, year);

            RefreshAfterDelete(gradeId, selectedClass, row_index, std_name);
        }

        private void RefreshAfterDelete(int gradeId, int selectedClass, int row_index, string std_name)
        {
            Get_Class_Data(gradeId);

            txt_std_data.Text = "";

            if (row_index != 0)
            {
                row_index--;
                dt_std_data.FirstDisplayedScrollingRowIndex = row_index;
                dt_std_data.Rows[row_index].Selected = true;
                dt_std_data.CurrentCell = dt_std_data.Rows[row_index].Cells["اسم الطالب"];
            }

            cmb_class.SelectedIndex = selectedClass;

            MSG.MyMesg("تم حذف الطالب  " + std_name + "...! ");
        }
        // Verify Stdunet Status 

        private void LoadClases()
        {
            if (cmb_grade.SelectedIndex < 0 || cmb_class.SelectedIndex < 0)
                return;

            BeginLoad();

            HideUpdatedAtColumn();

            Waiting.Start();
            try
            {
                DataTable std_dt;
                int year = SchoolDateHelper.GetCurrentYear(year_cod, _context);
                std_dt = _studentService.GetStudentsByYear(
                     year,
                    SafeConverter.GetInt(cmb_grade.SelectedValue),
                    cmb_class.SelectedIndex);

                lbl_count.Text = std_dt.Rows.Count.ToString();
                dt_std_data.DataSource = std_dt;
                txt_std_data.Text = "";
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
                EndLoad();
            }
        }

        #endregion


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

        private void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeSelectedData();
        }

        public void ChangeSelectedData()
        {
            if (IsLoading) return;

            HideUpdatedAtColumn();

            Get_Class_Data(SafeConverter.GetInt(cmb_grade.SelectedValue));
            txt_std_data.Text = "";
        }
        private void pic_help_MouseLeave(object sender, EventArgs e)
        {
            lbl_help.Visible = false;
        }

        private void txt_std_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            HideUpdatedAtColumn();
            pic_help_MouseHover(sender, e);
        }

        private void pic_help_MouseHover(object sender, EventArgs e)
        {
            lbl_help.Text = " البحث بالاسم  ";
            lbl_help.Visible = true;

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

        private void CloseForm()
        {
            this.Close();
            this.Dispose();

        }
        private void btn_close_b_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void cmb_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsLoading) return;

            LoadClases();

        }

        private void FRM_CURRENT_STD_Load(object sender, EventArgs e)
        {
            if (_context.StudentCase.IsDegreeStatement())
            {
                btn_talab_elthak.Visible = false;
                btn_del_std.Visible = false;
                btn_new_std.ButtonText = "بيان درجات";
            }
            else
            {
                btn_talab_elthak.Visible = true;
                if (_context.StudentCase.IsElthak() == true
                    || _context.StudentCase.IsNextYearElthak() == true)
                {
                    btn_del_std.Visible = false;
                }
                else
                {
                    btn_del_std.Visible = true;
                }

                btn_new_std.ButtonText = "تعديل البيانات";
            }
            toolTip1.SetToolTip(pic_sort, "ترتيب");
            toolTip1.SetToolTip(pic_help, "بحث");
            pic_sort.Image = Properties.Resources.transfer_to_100;
            try
            {
                dt_std_data.Columns["اسم الطالب"].Width = 200;
                cmb_grade.SelectedValue = grade;
                int myYear = Properties.Settings.Default.MyYear;
                lbl_current_year.Text = "بيانات " + SchoolFormatter.Year_Desc(
                       myYear,
                       _context?.CurrentYearData ?? false,
                       _context?.StudentCase.Has(GetStudentCase.StudentDetails) ?? false,
                       _context?.StudentCase.Has(GetStudentCase.ElthakStdNextYear) ?? false);
                lbl_count.Text = dt_std_data.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }

        }

        private void btn_new_std_Click(object sender, EventArgs e)
        {
            HandleNewStdClick(dt_std_data.CurrentRow);
        }

        private void txt_std_data_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int year = SchoolDateHelper.GetCurrentYear(year_cod, _context);

                // DataTable dt;
                var dt = _studentService.SearchSchoolyearData(
                     year,
                     SafeConverter.GetInt(cmb_grade.SelectedValue),
                     SafeConverter.GetInt(cmb_class.SelectedValue),
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

        private void dt_std_data_DoubleClick(object sender, EventArgs e)
        {
            if (_isDoubleClickBusy) return;
            Waiting.Stop();

            try
            {
                _isDoubleClickBusy = true;
                dt_std_data.Enabled = false;

                if (_context.StudentCase.IsElthak() == true
                || _context.StudentCase.IsNextYearElthak() == true)
                {
                    btn_talab_elthak_Click(sender, e);
                }
                else
                {
                    if (permission_id == 3)
                    {
                        return;
                    }
                    btn_new_std_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                dt_std_data.Enabled = true;
                _isDoubleClickBusy = false;
                Waiting.Stop();
            }
        }

        private void btn_del_std_Click(object sender, EventArgs e)
        {
            HandleDeleteStudent(
                    dt_std_data.CurrentRow,
                    cmb_class.SelectedIndex,
                    SafeConverter.GetInt(cmb_grade.SelectedValue)
           );
        }

        private void btn_tahwel_Click(object sender, EventArgs e)
        {
            var StudentStatus = dt_std_data.CurrentRow?.Cells["Std_Status_Id"]?.Value;
            if (dt_std_data.SelectedRows.Count > 0)
            {
                var result = StdValidationService.VerifyStdStatus(
                     dt_std_data.CurrentRow?.Cells["Std_Status_Id"]?.Value
                );

                if (!result.IsValid)
                {
                    MSG.ErrorMesg(result.Message);
                    return;
                }
                try
                {
                    var frm = FRM_TAHWEL_STD.Get_Tahweel_Std;

                    frm.chk_resom_no.Checked = true;
                    frm.chk_kotob_no.Checked = true;
                    frm.lbl_mohwel.Text = "محول إلى";

                    var row = dt_std_data.CurrentRow;
                    AppNavigation.Instance.

                        SetContext(c =>
                        {
                            c.StudentData = FRM_CURRENT_STD_Mappes.MapToTahweelStd(row);
                        })
                        .Show(frm);

                }
                catch (Exception ex)
                {
                    MSG.ErrorMesg(ex.Message);
                }

            }
            else
            {
                MSG.ErrorMesg("يرجى اختيار طالب .. !");
            }


            Waiting.Stop();
        }

        private void btn_talab_elthak_Click(object sender, EventArgs e)
        {

            if (dt_std_data.SelectedRows.Count <= 0)
            {
                MSG.ErrorMesg("يرجى اختيار طالب .. !");
                return;
            }

            try
            {
                DataGridViewRow row = dt_std_data.SelectedRows[0];
                string std_code = row.Cells[0].Value?.ToString();
                if (string.IsNullOrWhiteSpace(std_code))
                {
                    MSG.ErrorMesg("يرجى اختيار طالب .. !");
                    return;
                }

                string std_name = row.Cells["اسم الطالب"].Value?.ToString();
                string std_nat = row.Cells["std_nat"].Value.ToString();
                int stdYear = SafeConverter.GetInt(row.Cells["Year"].Value) + 2020;
                int grade = SafeConverter.GetInt(row.Cells["Grade_Id"].Value);
                string grade_desc = row.Cells["old_grade"].Value.ToString();
                int newYear = SafeConverter.GetInt(row.Cells["Year_Id"].Value) + 2021;


                // Get New Std (KG2 And Prim Six) Data For New Year
                bool nextYearElthak = _context.StudentCase.IsNextYearElthak();


                _elthakService.OpenElthakReport(grade, grade_desc, std_code,
                                                std_name, std_nat, stdYear, newYear, nextYearElthak);

            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);

            }
        }

        private void pic_sort_Click(object sender, EventArgs e)
        {
            _showUpdatedAt = !_showUpdatedAt;

            Get_School_Year_Data(_showUpdatedAt);
            pic_sort.Image = _showUpdatedAt ? Properties.Resources.transfer_from_100 : Properties.Resources.transfer_to_100;
        }

        private void lbl_sort_Click(object sender, EventArgs e)
        {
            pic_sort_Click(sender, e);
        }

    }
}
