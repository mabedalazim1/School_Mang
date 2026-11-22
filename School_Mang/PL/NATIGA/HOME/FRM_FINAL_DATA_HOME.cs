using School_Mang.BL;
using School_Mang.BL.Services;
using School_Mang.BL.Services.Nateg;
using School_Mang.PL.MAIN;
using System;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA.HOME
{
    public partial class FRM_FINAL_DATA_HOME : Form
    {
        private readonly FinalDataUploadService _uploadService =
                                                 new FinalDataUploadService();

        BL.NATEG.cls_NATAG_FUNCTIONS natag_func = new BL.NATEG.cls_NATAG_FUNCTIONS();
        
        // BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        // BL.NATEG.ExcelUtlity Excel = new BL.NATEG.ExcelUtlity();

        // Form Closed
        private static FRM_FINAL_DATA_HOME frm_Final_Data_home;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Final_Data_home = null;
        }
        public static FRM_FINAL_DATA_HOME Get_Frm_Final_Data_Home
        {
            get
            {
                if (frm_Final_Data_home == null)
                {
                    frm_Final_Data_home = new FRM_FINAL_DATA_HOME();
                    frm_Final_Data_home.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Final_Data_home;
            }
        }


        public FRM_FINAL_DATA_HOME()
        {
            InitializeComponent();

            if (frm_Final_Data_home == null)
            {
                frm_Final_Data_home = this;
            }

        }

        private void Check_Data()
        {
            string fileName = natag_func.OpenDialoge(openFileDialog1);

            if (fileName == null)
            {
                MSG.ErrorMesg("تم إلغاء الإجراء..!");
                BL.Globals.Dir_Path = "D://Rasd";
                return;
            }

            try
            {
                Waiting.Start();

                // قراءة بيانات الملف والتحقق منها
                FinalDataUploadInfo info = _uploadService.GetUploadInfo(fileName);

                if (info == null || !info.IsValid)
                {
                    MSG.ErrorMesg(info?.ErrorMessage ?? "تعذر قراءة بيانات الملف.");
                    BL.Globals.Dir_Path = "D://Rasd";
                    return;
                }

                // تجهيز رسالة تأكيد التحميل
                string fileInfo = " سوف يتم تحميل  " +
                                  info.FileKind + " " +
                                  info.FileDescription + " - الصف " +
                                  info.GradeDescription + " - " +
                                  info.TermDescription;

                if (MSG.DialogeMsg(fileInfo + "\n" +
                                   "هل تريد المتابعة .. ؟") != DialogResult.Yes)
                {
                    MSG.ErrorMesg("تم إلغاء الإجراء ..!");
                    BL.Globals.Dir_Path = "D://Rasd";
                    return;
                }

                // تنفيذ رفع الدرجات
                _uploadService.UploadGrades(fileName, info);

                MSG.MyMesg("تم تحديث الدرجات بنجاح .. !");
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                MSG.ErrorMesg("لم يتم رفع الملف.");
            }
            finally
            {
                Waiting.Stop();
            }
        }

        private void lbl_back_Click(object sender, EventArgs e)
        {
            natag_func.changePages(FRM_NATEG.Get_Frm_Nateg.pn_home, "التقييمات");
        }

        private void lbl_get_dgree_a_Click(object sender, EventArgs e)
        {
            try
            {
                // BL.Globals.Amal_Sana = true;
                // BL.Globals.Final_Test = false;
                // BL.Globals.Final_Koshof = false;
                // FRM_CHOSE_FINAL_DATA frm = new FRM_CHOSE_FINAL_DATA();
                // frm.ShowDialog();

                var frm = new FRM_CHOSE_FINAL_DATA();

                AppNavigation.Instance
                    .WithOwner(FRM_MAIN.Get_Frm_Main)
                    .SetContext(c =>c.Natiga.AmalSana = true)
                    .Show(frm);
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void pic_get_dgree_a_Click(object sender, EventArgs e)
        {
            lbl_get_dgree_a_Click(sender, e);
        }

        private void lbl_get_dgree_b_Click(object sender, EventArgs e)
        {
            try
            {
                // BL.Globals.Final_Test = true;
                // BL.Globals.Amal_Sana = false;
                // BL.Globals.Final_Koshof = false;
                // FRM_CHOSE_FINAL_DATA frm = new FRM_CHOSE_FINAL_DATA();
                // frm.ShowDialog();

                var frm = new FRM_CHOSE_FINAL_DATA();

                AppNavigation.Instance
                    .WithOwner(FRM_MAIN.Get_Frm_Main)
                    .SetContext(c => c.Natiga.FinalTest = true)
                    .Show(frm);
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void pic_get_dgree_b_Click(object sender, EventArgs e)
        {
            lbl_get_dgree_b_Click(sender, e);
        }

        private void lbl_upload_file_Click(object sender, EventArgs e)
        {
            Check_Data();
        }

        private void pic_upload_file_Click(object sender, EventArgs e)
        {
            lbl_upload_file_Click(sender, e);
        }

        private void lbl_final_Click(object sender, EventArgs e)
        {
            //BL.Globals.Amal_Sana = true;
            //FRM_CHOSE_FINAL_RASD.Get_Frm_Chose_Final_Rasd.ShowDialog();
            var frm = FRM_CHOSE_FINAL_RASD.Get_Frm_Chose_Final_Rasd;

            AppNavigation.Instance
                .SetContext(c=>c.Natiga.AmalSana=true)
                .Show(frm);


        }

        private void pic_final_Click(object sender, EventArgs e)
        {
            lbl_final_Click(sender, e);
        }


        private void lbl_final_test_Click(object sender, EventArgs e)
        {
            //BL.Globals.Final_Test = true;
            //FRM_CHOSE_FINAL_RASD.Get_Frm_Chose_Final_Rasd.ShowDialog();

            var frm = FRM_CHOSE_FINAL_RASD.Get_Frm_Chose_Final_Rasd;

            AppNavigation.Instance
                .SetContext(c => c.Natiga.FinalTest = true)
                .Show(frm);
        }

        private void pic_final_test_Click(object sender, EventArgs e)
        {
            lbl_final_test_Click(sender, e);
        }

        private void lbl_data_Click(object sender, EventArgs e)
        {
            var frm = FRM_FINAL_COUNT_DATA.Get_Frm_Final_Count_Data;
            frm.Visible = true;
            frm.BringToFront();
        }

        private void pic_data_Click(object sender, EventArgs e)
        {
            lbl_data_Click(sender, e);
        }

        private void pic_back_Click(object sender, EventArgs e)
        {
            lbl_back_Click(sender, e);
        }

        private void pic_natega_a_Click(object sender, EventArgs e)
        {
            lbl_natega_a_Click(sender,e);
        }

        private void lbl_natega_a_Click(object sender, EventArgs e)
        {
            // BL.Globals.Amal_Sana = false;
            //BL.Globals.Final_Test = false;
            //BL.Globals.Final_Nataga = true;
            //BL.Globals.Final_Koshof = false;
            //BL.Globals.AhsaaEdara = false;
            //FRM_CHOSE_FINAL_RASD.Get_Frm_Chose_Final_Rasd.ShowDialog();

            var frm = FRM_CHOSE_FINAL_RASD.Get_Frm_Chose_Final_Rasd;

            AppNavigation.Instance
                .SetContext(c => c.Natiga.FinalNataga= true)
                .Show(frm);
        }

        private void lbl_final_koshof_Click(object sender, EventArgs e)
        {
            //BL.Globals.Amal_Sana = false;
            //BL.Globals.Final_Test = false;
           // BL.Globals.Final_Nataga = false;
            //BL.Globals.Final_Koshof = true;
            //BL.Globals.AhsaaEdara = false;
            //FRM_CHOSE_FINAL_RASD.Get_Frm_Chose_Final_Rasd.ShowDialog();

            var frm = FRM_CHOSE_FINAL_RASD.Get_Frm_Chose_Final_Rasd;

            AppNavigation.Instance
                .SetContext(c => c.Natiga.FinalKoshof = true)
                .Show(frm);
        }

        private void pic_final_koshof_Click(object sender, EventArgs e)
        {
            lbl_final_koshof_Click(sender, e);
        }

        private void pic_sofof_ola_Click(object sender, EventArgs e)
        {
            lbl_sofof_ola_Click(sender, e);
        }

        private void lbl_sofof_ola_Click(object sender, EventArgs e)
        {
            MSG.ErrorMesg("هذا الإجراء عير متاح حالياً .. !");
            return;

            /*
               الكود القديم لرفع درجات الصفوف الأولى
               محفوظ هنا للرجوع إليه عند الحاجة.
           */

            /*
            string file_name = natag_func.OpenDialoge(openFileDialog1);
            if (file_name == null)
            {
                MSG.ErrorMesg("تم إلغاء الإجراء..!");
                BL.Globals.Dir_Path = "D://Rasd";
                return;
            }
            try
            {
                int Golos;
                decimal arabic;
                decimal dain;
                decimal math;
                decimal english;
                decimal motadd;
                decimal badnia;

                Waiting.Start();
                DataTable dt_information = Excel.GetInformationData_SofofOla(file_name);
                DataRow row = dt_information.Rows[0];

                // Test If File Have Valid Value
                string file_kind = row[0].ToString();
                if (file_kind == "" || file_kind == null || file_kind !="6")
                {
                    MSG.ErrorMesg("الملف غير صالح .. يرجى التأكد من الملف المطلوب ..!");
                    BL.Globals.Dir_Path = "D://Rasd";
                    return;
                }
                else
                {
                    string grade = "";
                    switch (row[1].ToString())
                    {
                        case "10":
                            grade = " KG 1";
                            break;

                        case "11":
                            grade = " KG 2";
                            break;
                        case "1":
                            grade = " الصف الأول ب ";
                            break;
                        case "2":
                            grade = " الصف الثاني ب ";
                            break;
                        case "3":
                            grade = " الصف الثالث ب ";
                            break;
                    }
                    string file_info = " سوف يتم تحميل درجات أعمال السنة " +
                                   "\n" + grade;

                    if (MSG.DialogeMsg(file_info + "\n" + "هل تريد المتابعة .. ؟") == DialogResult.Yes)
                    {
                        
                        DataTable dt_degree = new DataTable();
                        dt_degree = Excel.Read_Amal_1_2_3(file_name);
                        foreach (DataRow amal in dt_degree.Rows)
                        {
                            Golos = Convert.ToInt32(amal[0]);
                            arabic = Convert.ToDecimal(amal[1]);
                            dain = Convert.ToDecimal(amal[2]);
                            math = Convert.ToDecimal(amal[3]);
                            english = Convert.ToDecimal(amal[4]);
                            motadd = Convert.ToDecimal(amal[5]);
                            badnia = Convert.ToDecimal(amal[6]);

                            NATEG.Add_Amal_Final_1_2_3(Golos,
                                                    arabic,
                                                    dain,
                                                    math,
                                                    english,
                                                    motadd,
                                                    badnia);
                        }
                        Waiting.Stop();
                        MSG.MyMesg("تم تحديث الدرجات بنجاح .. !");


                    }
                    else
                    {
                        MSG.ErrorMesg("تم إلغاء الإجراء ..!");
                        BL.Globals.Dir_Path = "D://Rasd";
                        return;
                    }
                }

                Waiting.Stop();

            }
            catch(Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }

            */
        }

        private void lbl_ahsaa_Click(object sender, EventArgs e)
        {
           // BL.Globals.Amal_Sana = false;
            //BL.Globals.Final_Test = false;
            //BL.Globals.Final_Nataga = false;
           // BL.Globals.Final_Koshof = false;
            //BL.Globals.AhsaaEdara = true;
           // FRM_CHOSE_FINAL_RASD.Get_Frm_Chose_Final_Rasd.ShowDialog();

            var frm = FRM_CHOSE_FINAL_RASD.Get_Frm_Chose_Final_Rasd;

            AppNavigation.Instance
                .SetContext(c => c.Natiga.AhsaaEdara = true)
                .Show(frm);


        }

        private void picl_ahsaa_Click(object sender, EventArgs e)
        {
            lbl_ahsaa_Click(sender, e);
        }
    }
}
