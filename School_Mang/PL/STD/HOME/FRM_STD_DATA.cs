using School_Mang.BL;
using School_Mang.BL.Services;
using School_Mang.PL.MAIN;
using System;
using System.Data;
using School_Mang.BL.Enums;
using System.Windows.Forms;

namespace School_Mang.PL.STD.HOME
{
    public partial class FRM_STD_DATA : Form
    {
        private readonly StudentService studentService = new StudentService();

        private readonly StudentDataMigrationService dataMigration = new StudentDataMigrationService();

        BL.STD.CLS_STD std = new BL.STD.CLS_STD();

        CLS_STD_FUNCATIONS Func = new CLS_STD_FUNCATIONS();

        int permission_id = Properties.Settings.Default.permission_id;
        // Form Closed
        private static FRM_STD_DATA frm_Std_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Std_Data = null;
        }
        public static FRM_STD_DATA Get_Frm_Std_Data
        {
            get
            {
                if (frm_Std_Data == null)
                {
                    frm_Std_Data = new FRM_STD_DATA();
                    frm_Std_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Std_Data;
            }
        }

        public FRM_STD_DATA()
        {
            InitializeComponent();

            if (frm_Std_Data == null)
            {
                frm_Std_Data = this;
            }

            // Set User permission
            switch (permission_id)
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


        private void GetCurrentStudent()
        {
            Waiting.Start();
            // Globals.Current_Year_Data = true; // تحذف

            AppNavigation.Instance
                        .WithOwner(FRM_MAIN.Get_Frm_Main)
                        .SetContext(c =>
                        {
                            c.CurrentYearData = true;
                        })
                        .Show<FRM_CHOOSE_GRADE>();
            // تم التعديل علي نظام Navgation
        }
        private void lbl_current_stds_Click(object sender, EventArgs e)
        {
            GetCurrentStudent();
        }

        private void GoBack()
        {
            Func.changePages(MAIN.FRM_TALABA.Get_Frm_Talaba.pn_home);
        }
        private void lbl_back_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void ShowStudent()
        {
            DataTable Dt = std.Get_All_Std_Data(0);
            if (Dt.Rows.Count == 0)
            {
                MSG.ErrorMesg("لم يتم تسجيل طلاب جدد لهذا العام .. !");
                return;
            }
            AppNavigation.Instance.Show(FRM_GET_STD.Get_Student);

            // لا يوجد context في هذا الجزء
        }
        private void lbl_show_stds_Click(object sender, EventArgs e)
        {
            ShowStudent();
        }

        private void GetOsraData()
        {
            //FRM_GET_OSRAA.Get_Osra_data.ShowDialog();

            AppNavigation.Instance
                        .SetContext(c =>
                        {
                            c.OsraMode = GetOsraMode.OpenFormGetOsra;

                            //c.OpenFormGetOsra = true; // تأكد من استخدامها فى الفورم الى بتستدعيه
                        })
                        .Show(FRM_GET_OSRAA.Get_Osra_data);

            //OpenFormGetOsra  تم وغالبا الفورم لا يستخدم 
            // لأانه بيكرر هناك اسناد true
        }
        private void lbl_get_osra_data_Click(object sender, EventArgs e)
        {
            GetOsraData();
        }

        private void AddStudent()
        {
            // FRM_ADD_STD.getAdd_Std_Frm.ShowDialog(); //frm = new FRM_ADD_STD();
            //frm.ShowDialog();
            AppNavigation.Instance
                            .SetContext(c =>
                            {
                                c.OsraMode = GetOsraMode.Normal;
                                c.StudentMode = GetStudentMode.AddNewStudent;
                                //c.OpenFormGetOsra = false;
                            })
                            .Show(FRM_ADD_STD.getAdd_Std_Frm); // تم التحقق
        }
        private void lbl_add_std_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void pic_current_stds_Click(object sender, EventArgs e)
        {
            GetCurrentStudent();
        }

        private void pic_add_std_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void pic_get_osra_data_Click(object sender, EventArgs e)
        {
            GetOsraData();
        }

        private void pic_show_stds_Click(object sender, EventArgs e)
        {
            ShowStudent();
        }

        private void NextYearData()
        {
            //FRM_CHOOSE_GRADE frm = new FRM_CHOOSE_GRADE();
            //frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);

            AppNavigation.Instance
                       .WithOwner(FRM_MAIN.Get_Frm_Main)
                       .SetContext(c =>
                       {
                           c.CurrentYearData = false;
                           c.StudentCase = GetStudentCase.ElthakStdNextYear;
                       })
                       .Show<FRM_CHOOSE_GRADE>(); // تم التحقق
        }
        private void lbl_next_year_Click(object sender, EventArgs e)
        {
           NextYearData();
        }

        private void pic_next_year_Click(object sender, EventArgs e)
        {
            NextYearData();
        }

        private void pic_back_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        public void TahwletFromStudent()
        {
            AppNavigation.Instance
               .Show(FRM_TAHWELAT.Get_Frm_Tahwelat);

            //FRM_TAHWELAT.Get_Frm_Tahwelat.ShowDialog();
        }
        public void lbl_tahwelat_Click(object sender, EventArgs e)
        {
            TahwletFromStudent();
        }

        private void pic_tahwelat_Click(object sender, EventArgs e)
        {
            TahwletFromStudent();
        }

        void StudentDetails()
        {
            AppNavigation.Instance
               .SetContext(c =>
               {
                   c.StudentCase = GetStudentCase.StudentDetails;
               })
               .Show(FRM_CURRENT_STD.Get_Current_Std); // تم التحقق

            //FRM_CURRENT_STD.Get_Current_Std.ShowDialog();
        }
        private void lbl_std_details_Click(object sender, EventArgs e)
        {
            StudentDetails();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StudentDetails();
        }

        private void UpdateNewYearData()
        {

            if (MSG.DialogeMsg("هل تريد ترحيل بيانات العام الحالى ..!") != DialogResult.Yes)
            {
                MSG.ErrorMesg("تم إلغاء التحديث");
                return;
            }

            try
            {
                Waiting.Start();

                dataMigration.PromoteYear();

                MSG.MyMesg("تم تحديث بيانات العام الجديد بنجاح");
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
        private void lbl_update_std_data_Click(object sender, EventArgs e)
        {
            UpdateNewYearData();
        }

        private void pic_update_std_data_Click(object sender, EventArgs e)
        {
            UpdateNewYearData();
        }

        void ExeclData()
        {
            AppNavigation.Instance.Show(FRM_TOEXCEL.get_frm_To_Excel);

            // FRM_TOEXCEL.get_frm_To_Excel.ShowDialog();
        }
        private void lbl_to_excel_Click(object sender, EventArgs e)
        {
            ExeclData();
        }

        private void pic_to_excel_Click(object sender, EventArgs e)
        {
            ExeclData();
        }
    }
}
