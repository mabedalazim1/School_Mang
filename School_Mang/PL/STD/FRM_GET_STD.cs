using School_Mang.BL;
using School_Mang.BL.Common;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.Enums;
using School_Mang.BL.Extensions;
using School_Mang.BL.Services;
using School_Mang.BL.Services.STD;
using School_Mang.PL.STD.Mappers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace School_Mang.PL.STD
{
    public partial class FRM_GET_STD : Form , INavigationAware, INavigationAwareLoaded
    {

        private NavigationContext _context;
        private readonly StudentDataService studentData = new StudentDataService();
        public void SetNavigation(NavigationContext context)
        {
            _context = context;
        }

        public void OnNavigatedTo()
        {
            bool shouldRefresh =
         _context?.StudentState.OpenFromAddstudent == true ||
         _context?.StudentState.EditStudent == true;

            if (shouldRefresh)
                SearchStudents();
        }

        int permission_id = Properties.Settings.Default.permission_id;
        // Form Closed
        private static FRM_GET_STD frm_Get_Student;

        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Get_Student = null;
        }
        
        public static FRM_GET_STD Get_Student
        {
            get
            {
                if (frm_Get_Student == null)
                {
                    frm_Get_Student = new FRM_GET_STD();
                    frm_Get_Student.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }

                return frm_Get_Student;
            }
        }

        public FRM_GET_STD()
        {
            InitializeComponent();

            if (frm_Get_Student == null)
            {
                frm_Get_Student = this;
            }

            LoadStudentsData();
            SetPermission();
        }

        private void LoadStudentsData()
        {
            cmb_sana.SelectedIndex = 0;
            Waiting.Start();
            try
            {
                var result = studentData.GetStudentsData();

                if (!result.Success)
                {
                    MSG.ErrorMesg(result.Message);
                    return;
                }
                dt_std_data.DataSource = result.Data;
                lbl_count.Text = dt_std_data.Rows.Count.ToString();

                GridHelper.SetColumnsVisibility(dt_std_data,
                    ColumnVisibility.Hide,
                        "std_code",
                        "id",
                        "std_name",
                        "Gender_Id",
                        "Grade_Id",
                        "Std_Status_Id",
                       "Nationality_Id",
                        "Year_Id",
                       "Updated_At",
                        "Religion_Id",
                        "اسم الأب",
                        "الوظيفة",
                        "اسم الأم",
                       "الرقم القومى"
                );

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
        private void SetPermission()
        {

            // Set User permission
            switch (permission_id)
            {
                case 3:
                    btn_new_std.Enabled = false;
                    btn_del_std.Enabled = false;
                    btn_edit_std.ButtonText = "عرض البيانات ";
                    break;
                case 2:
                    btn_new_std.Enabled = true;
                    btn_del_std.Enabled = false;
                    btn_edit_std.ButtonText = "تعديل البيانات ";
                    break;

                case 1:
                    btn_new_std.Enabled = true;
                    btn_del_std.Enabled = true;
                    btn_edit_std.ButtonText = "تعديل البيانات ";
                    break;
            }
        }
        // Verify Stdunet Status 
        public void SearchStudents()
        {
            string txt = txt_std_data.Text;
            int year = SafeConverter.GetInt(cmb_sana.SelectedIndex);
            Waiting.Start();

            try
            {
                var result = studentData.SearchStdData(txt, year);
                if (!result.Success)
                {
                    MSG.ErrorMesg(result.Message);
                    return;
                }

                dt_std_data.DataSource = result.Data;
                lbl_count.Text = result.Data.Rows.Count.ToString();
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
        private DataRow GetSelectedStudentRow(bool showMessage = true)
        {
            if (dt_std_data.CurrentRow == null)
            {
                if (showMessage)
                    MSG.ErrorMesg("يرجى اختيار طالب أولاً");
                return null;
            }

            return ((DataRowView)dt_std_data.CurrentRow.DataBoundItem)?.Row;
        }

        private void UpdateButtonsState()
        {
            var row = GetSelectedStudentRow(false);
            if (row == null) return;

            int grade = SafeConverter.GetInt(row["Grade_Id"]);

            btn_talab_elthak.ButtonText =
                (grade > 1 && grade < 10) ? "طلب تحويل" : "طلب إلتحاق";
        }
        public void RefreshStudents()
        {
            txt_std_data.Text = "";
            SearchStudents();
            txt_std_data.Focus();
        }

        private void GetEltehakSdtudent()
        {
            try
            {
                var row = GetSelectedStudentRow();
                if (row == null)
                    return;

                int grade = SafeConverter.GetInt(row["Grade_Id"]);

                var frmElthak = FRM_STD_ELTEHK.Get_Std_Eltehk;

                if (grade > 1 && grade < 10)
                {

                    var frm = FRM_TAHEEL_STD.Get_Tahweel_Std;

                    frm.chk_resom_no.Checked = true;
                    frm.chk_kotob_no.Checked = true;
                    frm.lbl_mohwel.Text = "محول من";


                    AppNavigation.Instance
                        .SetContext(c =>
                        {
                            c.StudentCase = GetStudentCase.TaheewlToSchool;
                            c.StudentData = FRM_GET_STD_Mapper.MapToTransfer(row);
                        })
                        .Show(frm); // تم التحقق

                    // FRM_TAHEEL_STD.Get_Tahweel_Std.ShowDialog();
                }
                else
                {
                    var dto = FRM_GET_STD_Mapper.MapToAddStd(row);

                    AppNavigation.Instance
                        .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                        .SetContext(c =>
                        {
                            c.StudentCase = GetStudentCase.TaheewlToSchool;
                            c.StudentData = dto;
                        })
                        .Show(frmElthak);

                    //FRM_STD_ELTEHK.Get_Std_Eltehk.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
                }
            }
            catch (Exception ex)
            { 
                MSG.ErrorMesg(ex.Message); 
            }
        }

        private void EditStudent()
        {
            try
            {
                var row = GetSelectedStudentRow();
                if (row == null)
                    return;

                this.Visible = false;
                var frm = FRM_ADD_STD.getAdd_Std_Frm;

                AppNavigation.Instance.
                    WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                    .SetContext(c =>
                    {
                        c.StudentState.UpdateStdData = true;
                        c.StudentData = FRM_GET_STD_Mapper.MapToStudent(row);

                    }).Show(FRM_ADD_STD.getAdd_Std_Frm); // تم التحقق

                // FRM_ADD_STD.getAdd_Std_Frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void DeleteStudent()
        {
            try
            {
                var row = GetSelectedStudentRow();
                if (row == null)
                    return;

                string name = row["اسم الطالب"].ToString();
                string stdCode = row["std_code"].ToString();
                int osraId = SafeConverter.GetInt(row["id"]);
                int year = SafeConverter.GetInt(cmb_sana.SelectedValue);

                if (MSG.DialogeErrMsg($"هل تريد حذف الطالب / {name}") != DialogResult.Yes)
                {
                    MSG.ErrorMesg($"تم إلغاء عملية الحذف الخاصة بالطالب / {name}");
                    return;
                }

                var result = studentData.DeleteStudentWithOsraRule(stdCode, osraId);

                if (!result.Success)
                {
                    MSG.ErrorMesg(result.Message);
                    return;
                }

                var students = studentData.GetStudentsData(year);
                if (!students.Success)
                {
                    MSG.ErrorMesg(result.Message);
                    return;
                }
                dt_std_data.DataSource = students.Data;
                lbl_count.Text = students.Data.Rows.Count.ToString();

                MSG.ErrorMesg($"تم حذف الطالب / {name}");
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
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

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void txt_std_data_OnValueChanged(object sender, EventArgs e)
        {
            SearchStudents();
        }

        private void pic_help_MouseHover(object sender, EventArgs e)
        {
            lbl_help.Text = " البحث بالاسم أو الهاتف أو الأرقام القومية ";
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

        private void btn_new_std_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            AppNavigation.Instance.
                WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                .SetContext(c =>
                {
                    c.StudentState.AddFromGetStd = true;
                    //c.AddFromGetStd = true;
                }).Show(FRM_ADD_STD.getAdd_Std_Frm);

            //FRM_ADD_STD.getAdd_Std_Frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void cmb_sana_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchStudents();
        }
       
        private void btn_edit_std_Click(object sender, EventArgs e)
        {
            EditStudent();
        }

        private void FRM_GET_STD_Load(object sender, EventArgs e)
        {
            try
            {
                dt_std_data.Columns["اسم الطالب"].Width = 230;
                //dt_std_data.Columns["الرقم القومى"].Width = 200;
                dt_std_data.Columns["العنوان"].Width = 270;
                UpdateButtonsState();

                if (_context?.StudentCase.Has(GetStudentCase.ElthakStd) == true)
                {
                    btn_new_std.Visible = false;
                    btn_del_std.Visible = false;

                    btn_edit_std.Location = new Point(839, 15);
                    btn_talab_elthak.Location = new Point(432, 15);
                }
                else
                {
                    btn_new_std.Visible = true;
                    btn_del_std.Visible = true;

                    btn_new_std.Location = new Point(839, 15);
                    btn_edit_std.Location = new Point(631, 15);
                    btn_talab_elthak.Location = new Point(423, 15);
                }

            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }

        }

        private void dt_std_data_DoubleClick(object sender, EventArgs e)
        {
            if (_context?.StudentCase.Has(GetStudentCase.ElthakStd) == true)
            {
                GetEltehakSdtudent();
                return;
            }

            EditStudent();
        }

        private void btn_del_std_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }

        private void btn_talab_elthak_Click(object sender, EventArgs e)
        {
            GetEltehakSdtudent();
        }

        private void dt_std_data_Click(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }
    }
}
