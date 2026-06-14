using School_Mang.BL;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using School_Mang.PL.STD;
using School_Mang.PL.STD.HOME;
using System;
using System.Windows.Forms;

namespace School_Mang.PL.MAIN
{
    public partial class FRM_TALABA : Form
    {

        private readonly UserService userService = new UserService();
        private readonly StudentService studentService = new StudentService();

        // Form Closed
        private static FRM_TALABA frm_Talaba;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Talaba = null;
        }
        public static FRM_TALABA Get_Frm_Talaba
        {
            get
            {
                if (frm_Talaba == null || frm_Talaba.IsDisposed)
                {
                    frm_Talaba = new FRM_TALABA();
                    frm_Talaba.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Talaba;
            }
        }

        public FRM_TALABA()
        {
            InitializeComponent();

            if (frm_Talaba == null)
            {
                frm_Talaba = this;
            }

            // Set User permission

            var settings = Properties.Settings.Default;
            switch (settings.permission_id)
            {
                case 3:
                    card_new.Visible = false;
                    break;
                case 1:
                case 2:
                    card_new.Visible = true;
                    break;
            }
        }

        // Change Pages
        private void ChangePages(Panel pn, string lbl)
        {
            var frmMain = FRM_MAIN.Get_Frm_Main;
            frmMain.pn_home.Visible = false;
            frmMain.pn_main.Controls.Clear();
            frmMain.pn_main.Visible = false;
            frmMain.lbl_main.Text = lbl;
            frmMain.lbl_main.Visible = false;
            frmMain.pn_main.BringToFront();
            frmMain.pn_main.Controls.Add(pn);
            frmMain.trans_a.ShowSync(frmMain.pn_main);
            frmMain.lbl_main.Visible = true;
        }

        // Hide New Year
        private void CheckNewYear()
        {
            // Get Year
            var stdData = FRM_STD_DATA.Get_Frm_Std_Data;
            var stdReports = FRM_STD_REPORTS.Get_Frm_Std_Reports;

            var settings = Properties.Settings.Default;
            stdData.lbl_year.Text = settings.Year_Desc;
            stdReports.lbl_cruunt_year.Text = settings.Year_Desc;
            int new_year = settings.MyYear + 1;
            var newYearText = studentService.GetYearName(new_year);

            stdData.lbl_new_year.Text = newYearText;
            stdReports.lbl_new_year.Text = newYearText;

            // Hide New Year Card If There Is no Student On New Year
            int year_code = settings.year_cod + 1;

            bool hasStudents = studentService.HasStudentsInYear(year_code);

            stdData.card_new_year.Visible = hasStudents;
            stdReports.card_new_year.Visible = hasStudents;
        }


        private void GetAge()
        {
            //FRM_HESAB_SEN frm_sen = new STD.FRM_HESAB_SEN();

            AppNavigation.Instance.Show<FRM_HESAB_SEN>();

            //frm_sen.ShowDialog();
        }
        private void lbl_age_Click(object sender, EventArgs e)
        {
            GetAge();
        }
        private void pic_age_Click(object sender, EventArgs e)
        {
            GetAge();
        }

        private void AddStudent()
        {
            AppNavigation.Instance
                            .Show(FRM_ADD_STD.getAdd_Std_Frm); // تم التحقق

            //STD.FRM_ADD_STD.getAdd_Std_Frm.ShowDialog();
        }
        private void pic_add_std_Click(object sender, EventArgs e)
        {
            AddStudent();
        }
        private void lbl_add_std_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void ElthakStudent()
        {
            AppNavigation.Instance.SetContext(c =>
            {
                c.StudentCase = GetStudentCase.ElthakStd;
            })
                .Show(FRM_GET_STD.Get_Student); // تم التحقق

            //STD.FRM_GET_STD.Get_Student.ShowDialog();
        }
        private void pic_elthak_Click(object sender, EventArgs e)
        {
            ElthakStudent();
        }

        private void lbl_elthak_Click(object sender, EventArgs e)
        {
            ElthakStudent();
        }

        

        private void CurrentStudent()
        {
            try
            {
                // Get Data From dataBase
                CheckNewYear();
                // Test Permissions
                var settings = Properties.Settings.Default;
                int user = settings.user_code;
                bool isAdmin = userService.IsAdmin(user);

                FRM_STD_DATA.Get_Frm_Std_Data.card_update_data.Visible = isAdmin;

                // Get Std Data Form
                ChangePages(FRM_STD_DATA.Get_Frm_Std_Data.pn_std_home, "بيانات الطلاب");
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void lbl_current_stds_Click(object sender, EventArgs e)
        {
            CurrentStudent();
        }
        private void pic_current_stds_Click(object sender, EventArgs e)
        {
            CurrentStudent();
        }
        private void Tahwelat()
        {
            FRM_STD_DATA.Get_Frm_Std_Data.TahwletFromStudent();
        }
        private void lbl_tahwelat_Click(object sender, EventArgs e)
        {
            Tahwelat();
        }

        private void pic_tahwelat_Click(object sender, EventArgs e)
        {
            Tahwelat();
        }
        private void Ehsaa()
        {
            // Hide New Year Data
            CheckNewYear();
            // Get Std Data Form
            ChangePages(FRM_STD_REPORTS.Get_Frm_Std_Reports.pn_std_home, "تقارير - احصائيات");
        }
        private void lbl_ehsaa_Click(object sender, EventArgs e)
        {
            Ehsaa();
        }

        private void pic_ehsaa_Click(object sender, EventArgs e)
        {
            Ehsaa();
        }
        private void EltehakOld()
        {
            AppNavigation.Instance.SetContext(c =>
            {
                c.StudentCase = GetStudentCase.ElthakStdNextYear;
                c.CurrentYearData = true;
            })
                .Show(FRM_CURRENT_STD.Get_Current_Std); // تم التحقق

            //STD.FRM_CURRENT_STD.Get_Current_Std.ShowDialog();
        }
        private void lbl_eltehak_old_Click(object sender, EventArgs e)
        {
            EltehakOld();    
        }

        private void pic_eltehak_old_Click(object sender, EventArgs e)
        {
            EltehakOld();
        }

        private void BianDragat()
        {
            Waiting.Start();

            AppNavigation.Instance.SetContext(
                c =>
                {
                    c.CurrentYearData = true;
                    c.StudentCase = GetStudentCase.DegreeStatement;
                })
                .Show<FRM_CHOOSE_GRADE>(); // تم التحقق

            //STD. FRM_CHOOSE_GRADE frm = new STD.FRM_CHOOSE_GRADE();
            //frm.ShowDialog();
        }
        private void lbl_bian_dragat_Click(object sender, EventArgs e)
        {
            BianDragat();
        }

        private void pic_bian_dragat_Click(object sender, EventArgs e)
        {
            BianDragat();
        }

        private void NextYear()
        {
            AppNavigation.Instance.SetContext(c =>
            {
                c.StudentCase = GetStudentCase.ElthakStd;
                c.CurrentYearData = false;
                
            })
                .Show(FRM_CURRENT_STD.Get_Current_Std); // تم التحقق


            //FRM_CURRENT_STD.Get_Current_Std.ShowDialog();
        }
        private void pic_elthak_next_year_Click(object sender, EventArgs e)
        {
            NextYear();
        }

        private void lbl_elthak_next_year_Click(object sender, EventArgs e)
        {
            NextYear();
        }

    }
}
