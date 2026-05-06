using School_Mang.BL;
using School_Mang.BL.Common;
using School_Mang.BL.Common.Extensions;
using School_Mang.BL.DTO;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using School_Mang.BL.Services.Reports;
using School_Mang.BL.Services.STD;
using School_Mang.PL.STD.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace School_Mang.PL.STD
{
    public partial class FRM_CURRENT_STD : Form, INavigationAware
    {
        private CurrentStdFormService _service;
        private NavigationContext _context;
        private readonly StudentService studentService = new StudentService();
        private readonly StudentReportService _reportService = new StudentReportService();
        private readonly ElthakReportService _elthakService = new ElthakReportService();
        public void SetNavigation(NavigationContext context)
        {
            _context = context;

            EnsureService();

            _service.ApplyContext();
        }

        private void EnsureService()
        {
            if (_service != null) return;

            _service = new CurrentStdFormService(
                this,
                _context,
                Properties.Settings.Default.permission_id
            );
        }
        

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

        // أخفاء الأعمدة 
        private void HideColumns(params string[] columns)
        {
            foreach (var col in columns)
            {
                if (dt_std_data.Columns.Contains(col))
                    dt_std_data.Columns[col].Visible = false;
            }
        }
        // إظهار الأعمدة
        private void ShowColumns(params string[] columns)
        {
            foreach (var col in columns)
            {
                if (dt_std_data.Columns.Contains(col))
                    dt_std_data.Columns[col].Visible = true;
            }
        }
        // Get School Year Data
        public void Get_School_Year_Data()
        {  
            try
            {
                int my_grade = Convert.ToInt32(cmb_grade.SelectedValue);
                int year = SchoolDateHelper.GetCurrentYear(year_cod, _context);
                Waiting.Start();
                var dt = studentService.GetStudentsByYear(year, my_grade, 0);


                dt_std_data.DataSource = dt;

                HideColumns(
                     "std_code", "Grade_Id", "Religion_Id", "Gender_Id",
                     "Std_Status_Id", "Osraa_Id", "Year_Id", "Class_No", "Class_Id",
                     "father_name", "std_name", "std_nat", "year", "old_grade",
                     "year_desc", "Updated_At", "Updated_by"
                 );

                if (_context.StudentCase.IsDetails())
                {
                    // Open From Details 
                    HideColumns("الفصل", "الديانة", "النوع", "الحالة");

                    ShowColumns("العنوان", "هاتف الأب", "هاتف الأم");
                    btn_del_std.Visible = false;
                    btn_talab_elthak.Visible = false;
                }
                else
                {
                    // Open From School Data
                    HideColumns("العنوان", "هاتف الأب", "هاتف الأم");

                    ShowColumns("الفصل", "الديانة", "النوع", "الحالة");

                    btn_del_std.Visible = true;
                    btn_talab_elthak.Visible = true;
                }
                lbl_count.Text = dt.Rows.Count.ToString();

                _context?.PostAction?.Invoke();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }finally
            { 
                Waiting.Stop();
            }
            
        }
        // Get Class Data
        public void Get_Class_Data(int gradeId, int classId = 0)
        {
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
            }
        }
        // Get Classes
        private void LoadGradeClasses(int gradeId)
        {
            var dt = studentService.GetGradeData(gradeId);

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
            var dt = studentService.GetStudentsByYear(year, gradeId, classId);

            dt_std_data.DataSource = dt;
            lbl_count.Text = dt.Rows.Count.ToString();
        }

        // Verify Stdunet Status 

        
        
        private void LoadClases()
        {
            if (cmb_grade.SelectedIndex < 0 || cmb_class.SelectedIndex < 0)
                return;

            Waiting.Start();
            try
            {
                DataTable std_dt;
                int year = SchoolDateHelper.GetCurrentYear(year_cod, _context);
                std_dt = studentService.GetStudentsByYear(
                     year,
                    Convert.ToInt32(cmb_grade.SelectedValue),
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

        public void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeSelectedData();
        }

        public void ChangeSelectedData()
        {

            Get_Class_Data(Convert.ToInt32(cmb_grade.SelectedValue));
            txt_std_data.Text = "";
        }
        private void pic_help_MouseLeave(object sender, EventArgs e)
        {
            lbl_help.Visible = false;
        }

        private void txt_std_data_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void cmb_class_SelectedIndexChanged(object sender, EventArgs e)
        {
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
           
            try
            {
                dt_std_data.Columns["اسم الطالب"].Width = 200;
                cmb_grade.SelectedValue = grade;
                int myYear = Properties.Settings.Default.MyYear;
                lbl_current_year.Text = "بيانات " + SchoolFormatter.Year_Desc(
                       myYear,       
                       _context?.CurrentYearData ?? false,
                       _context?.StudentCase.HasFlag(GetStudentCase.StudentDetails) ?? false,
                       _context?.StudentCase.HasFlag(GetStudentCase.ElthakStdNextYear) ?? false);
                lbl_count.Text = dt_std_data.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }

        }

        private void btn_new_std_Click(object sender, EventArgs e)
        {
            _service.HandleNewStdClick(dt_std_data.CurrentRow);
        }

        private void txt_std_data_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int year = SchoolDateHelper.GetCurrentYear(year_cod, _context);

               // DataTable dt;
               var dt = studentService.SearchSchoolyearData(
                    year,
                    Convert.ToInt32(cmb_grade.SelectedValue),
                    Convert.ToInt32(cmb_class.SelectedValue),
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

        private void btn_del_std_Click(object sender, EventArgs e)
        {
            _service.HandleDeleteStudent(
                     dt_std_data.CurrentRow,
                     cmb_class.SelectedIndex,
                     Convert.ToInt32(cmb_grade.SelectedValue)
            );
        }

        private void btn_tahwel_Click(object sender, EventArgs e)
        {
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

                    var frm = FRM_TAHEEL_STD.Get_Tahweel_Std;
                    frm.txt_transfer_reason.Text = "رغبة ولى الأمر";
                    frm.chk_resom_no.Checked = true;
                    frm.chk_kotob_no.Checked = true;
                    frm.transfer_status = 3;
                    frm.lbl_mohwel.Text = "محول إلى";

                    var row = dt_std_data.CurrentRow;
                    AppNavigation.Instance.

                        SetContext(c =>
                        {
                            c.StudentData = new StudentDTO
                            {
                                StdCode = row.Cells["std_code"].Value?.ToString(),
                                StudentFullName = row.Cells["اسم الطالب"].Value?.ToString(),
                                FatherName = row.Cells["father_name"].Value?.ToString(),
                                Address = row.Cells["العنوان"].Value?.ToString(),
                                GradeId = Convert.ToInt32(row.Cells["Grade_Id"].Value)
                            };
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

            if (dt_std_data.SelectedRows.Count > 0)
            {
                // if (Verify_Std_Status()) return;
                try
                {
                    string std_code = dt_std_data.CurrentRow.Cells[0].Value.ToString();
                    string std_name = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
                    string std_nat = dt_std_data.CurrentRow.Cells["std_nat"].Value.ToString();
                    int sana = (Convert.ToInt32(dt_std_data.CurrentRow.Cells["year"].Value)) +2020; 
                    int grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);
                    string grade_desc = dt_std_data.CurrentRow.Cells["old_grade"].Value.ToString();

                    // Get New Std (KG2 And Prim Six) Data For New Year
                    bool nextYearElthak = _context.StudentCase.IsNextYearElthak();


                    _elthakService.OpenElthakReport(grade,grade_desc,std_code, 
                                                    std_name, std_nat, sana,nextYearElthak);
                                                   
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

        }
    }
}
