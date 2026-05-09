using School_Mang.BL;
using School_Mang.BL.DTO;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
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
    public partial class FRM_GET_STD : Form , INavigationAware, INavigationAwareLoaded
    {

        private NavigationContext _context;

        public void SetNavigation(NavigationContext context)
        {
            _context = context;
        }

        public void OnNavigatedTo()
        {
            if (_context?.OsraMode.HasFlag(GetOsraMode.OpenFromAddstudent) == true)
                LoadStudentData();
            if (_context?.OsraMode.HasFlag(GetOsraMode.EditStudent) == true)
                LoadStudentData();
        }

        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        DAL.TestConcation testConcation = new DAL.TestConcation();

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
            cmb_sana.SelectedIndex = 0;

            Waiting.Start();
            if (testConcation.IsServerConnected())
            {
                this.dt_std_data.DataSource = std.Get_All_Std_Data(0);
                dt_std_data.Columns["std_code"].Visible = false;
                dt_std_data.Columns["id"].Visible = false;
                dt_std_data.Columns["std_name"].Visible = false;
                dt_std_data.Columns["Gender_Id"].Visible = false;
                dt_std_data.Columns["Grade_Id"].Visible = false;
                dt_std_data.Columns["Std_Status_Id"].Visible = false;
                dt_std_data.Columns["Nationality_Id"].Visible = false;
                dt_std_data.Columns["Year_Id"].Visible = false;
                dt_std_data.Columns["Updated_At"].Visible = false;
                dt_std_data.Columns["Religion_Id"].Visible = false;
                dt_std_data.Columns["اسم الأب"].Visible = false;
                dt_std_data.Columns["الوظيفة"].Visible = false;
                dt_std_data.Columns["اسم الأم"].Visible = false;
                dt_std_data.Columns["الرقم القومى"].Visible = false;
                lbl_count.Text = dt_std_data.Rows.Count.ToString();

            }

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

            Waiting.Stop();
        }


        // Verify Stdunet Status 
        private Boolean Verify_Std_Status()
        {
            if (dt_std_data.SelectedRows.Count == 0)
            {
                MSG.ErrorMesg(" يرجى إختيار طالب أولاً ..!");
                return true;
            }
            else
            {
                return false;
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

        public void txt_std_data_OnValueChanged(object sender, EventArgs e)
        {
            Waiting.Start();
            if (!testConcation.IsServerConnected())
            {
                MSG.ErrorMesg("تأكد من الاتصال بالسيرفر.. !");
                return;
            }
            DataTable Dt;
            Dt = std.Search_Std_Data(txt_std_data.Text, cmb_sana.SelectedIndex);

            dt_std_data.DataSource = Dt;
            lbl_count.Text = Dt.Rows.Count.ToString();
            try
            {

            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
            }
            Waiting.Stop();
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
                    c.OsraMode = GetOsraMode.AddFromGetStd;
                    //c.AddFromGetStd = true;
                }).Show(FRM_ADD_STD.getAdd_Std_Frm);

            //FRM_ADD_STD.getAdd_Std_Frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        public void cmb_sana_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudentData();
        }
        public void LoadStudentData()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = std.Search_Std_Data(txt_std_data.Text, cmb_sana.SelectedIndex);
                if (Dt != null)
                {
                    dt_std_data.DataSource = Dt;
                    lbl_count.Text = Dt.Rows.Count.ToString();
                }

            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }
        private void btn_edit_std_Click(object sender, EventArgs e)
        {
            if (Verify_Std_Status()) return;


            var frm = FRM_ADD_STD.getAdd_Std_Frm;
            try
            {
                var row = dt_std_data.CurrentRow;
        
                this.Visible = false;

                AppNavigation.Instance.
                    WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                    .SetContext(c =>
                    {
                        c.StudentMode = GetStudentMode.UpdateStdData;

                        c.StudentData = new StudentDTO
                        {
                            StdCode = row.Cells["std_code"].Value?.ToString(),
                            Nat = row.Cells["الرقم القومى"].Value?.ToString(),
                            StdName = row.Cells["std_name"].Value?.ToString(),

                            GradeId = Convert.ToInt32(row.Cells["Grade_Id"].Value),
                            YearId = Convert.ToInt32(row.Cells["Year_Id"].Value),
                            GenderId = Convert.ToInt32(row.Cells["Gender_Id"].Value),
                            ReligionId = Convert.ToInt32(row.Cells["Religion_Id"].Value),
                            NationalityId = Convert.ToInt32(row.Cells["Nationality_Id"].Value),
                            OsraId = Convert.ToInt32(row.Cells["id"].Value),

                            FatherName = row.Cells["اسم الأب"].Value?.ToString(),
                            MotherName = row.Cells["اسم الأم"].Value?.ToString(),
                            Address = row.Cells["العنوان"].Value?.ToString(),
                            Wazifa = row.Cells["الوظيفة"].Value?.ToString(),
                            FatherTel = row.Cells["هاتف الأب"].Value?.ToString(),
                            MotherTel = row.Cells["هاتف الأم"].Value?.ToString()
                        };
                    }).Show(FRM_ADD_STD.getAdd_Std_Frm); // تم التحقق

               // FRM_ADD_STD.getAdd_Std_Frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);


            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }

        }

        private void FRM_GET_STD_Load(object sender, EventArgs e)
        {
            try
            {
                dt_std_data.Columns["اسم الطالب"].Width = 230;
                //dt_std_data.Columns["الرقم القومى"].Width = 200;
                dt_std_data.Columns["العنوان"].Width = 270;
                dt_std_data_Click(sender, e);

                if (_context?.StudentCase.HasFlag(GetStudentCase.ElthakStd) == true)
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
            if (_context?.StudentCase.HasFlag(GetStudentCase.ElthakStd) == true)
            {
                btn_talab_elthak_Click(sender, e);
                return;
            }

            btn_edit_std_Click(sender, e);
        }

        private void btn_del_std_Click(object sender, EventArgs e)
        {
            if (Verify_Std_Status()) return;


            string name = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();

            int osrs_id = Convert.ToInt32(dt_std_data.CurrentRow.Cells["id"].Value.ToString());
            if (osrs_id.ToString() != "")
            {
                DataTable Dt;
                Dt = std.Verify_Osra_Data(osrs_id);

                if (MSG.DialogeErrMsg("هل تريد حذف البيانات الخاصة بالطالب /  " + name) == DialogResult.Yes)
                {
                    std.Delele_Std_Data(dt_std_data.CurrentRow.Cells["std_code"].Value.ToString());
                    this.dt_std_data.DataSource = std.Get_All_Std_Data(Convert.ToInt32(cmb_sana.SelectedValue));

                    if (Convert.ToInt32(Dt.Rows[0]["Id"].ToString()) == 1)
                    {
                        std.Delele_Osra_Data(osrs_id);
                    }

                    MSG.ErrorMesg("تم حذف البيانات الخاصة بالطالب /   " + name);

                }
                else
                {
                    MSG.ErrorMesg("تم إلغاء عملية الحذف الخاصة بالطالب /   " + name);
                    return;
                }

            }
        }

        private void btn_talab_elthak_Click(object sender, EventArgs e)
        {
            if (Verify_Std_Status()) return;
            var row = dt_std_data.CurrentRow;

            var frmElthak = FRM_STD_ELTEHK.Get_Std_Eltehk;
            int grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);
            frmElthak.txt_std_code.Text = dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();
            frmElthak.txt_std_name.Text = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
            frmElthak.cmb_grade.SelectedValue = dt_std_data.CurrentRow.Cells["Grade_Id"].Value;
            frmElthak.cmb_hala.SelectedValue = dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value;
            frmElthak.cmb_grade.SelectedValue = grade;
            frmElthak.txt_std_nat.Text = dt_std_data.CurrentRow.Cells["الرقم القومى"].Value.ToString(); ;
            frmElthak.txt_sana.Text = dt_std_data.CurrentRow.Cells["Year_Id"].Value.ToString(); ;


            if ((10 > grade && grade > 1))
            {
                var frm = FRM_TAHEEL_STD.Get_Tahweel_Std;

                frm.chk_resom_no.Checked = true;
                frm.chk_kotob_no.Checked = true;
                frm.lbl_mohwel.Text = "محول من";

                
                AppNavigation.Instance
                    .SetContext(c =>
                {
                    c.StudentCase = GetStudentCase.TaheewlToSchool;
                    c.StudentData = new StudentDTO {
                        StdCode = row.Cells["std_code"].Value?.ToString(),
                        StudentFullName = row.Cells["اسم الطالب"].Value?.ToString(),
                        FatherName = row.Cells["اسم الأب"].Value?.ToString(),
                        Address = row.Cells["العنوان"].Value?.ToString(),
                        GradeId = Convert.ToInt32(row.Cells["Grade_Id"].Value),
                        TransferStatus = 4,
                        TransferReason = "رغبة ولى الأمر"
                    };
                })
                    .Show(FRM_TAHEEL_STD.Get_Tahweel_Std); // تم التحقق

               // FRM_TAHEEL_STD.Get_Tahweel_Std.ShowDialog();
            }
            else
            {
                AppNavigation.Instance
                    .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                    .SetContext(c =>
                {
                    c.StudentCase = GetStudentCase.TaheewlToSchool;
                })
                    .Show(FRM_STD_ELTEHK.Get_Std_Eltehk);

                //FRM_STD_ELTEHK.Get_Std_Eltehk.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
            }

        }

        private void dt_std_data_Click(object sender, EventArgs e)
        {
            int grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);
            if ((10 > grade && grade > 1))
            {
                btn_talab_elthak.ButtonText = "طلب تحويل";
            }
            else
            {
                btn_talab_elthak.ButtonText = "طلب إلتحاق";
            }
        }
    }
}
