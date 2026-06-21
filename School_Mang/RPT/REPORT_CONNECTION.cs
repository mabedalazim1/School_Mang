using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Mang.BL;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;
using School_Mang.BL.Services;

namespace School_Mang.RPT
{
    class REPORT_CONNECTION
    {

        string[] sen = { };

        private void OpenReport(ReportDocument rpt, string frm_caption, string frm_text)
        {
            Waiting.Start();

            string server = Properties.Settings.Default.Server_Name;
            string dataBase = Properties.Settings.Default.DataBasee_name;
            string user = Properties.Settings.Default.DataBasee_User;
            string pass = Properties.Settings.Default.DataBasee_Pass;

            try
            {
                using (var frm = new FRM_REPORTS())
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    rpt.DataSourceConnections[0].SetConnection(server, dataBase, user, pass);

                    frm.lbl_caption.Text = frm_caption;
                    frm.Text = frm_text;
                    frm.crystalReportViewer1.ReportSource = rpt;
                    Waiting.Stop();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                try
                {
                    rpt.Close();
                    rpt.Dispose();
                }
                catch { }

                Waiting.Stop();
            }
        }
        public void OpenElthakReport(string std_code, 
                                     string std_name, 
                                     string nat , 
                                     int sana, 
                                     string new_year = "", 
                                     string new_grade= "")
        {
            try
            {
                ReportDocument myReport = new ReportDocument();
                myReport.Load(Application.StartupPath + @"/MyReports/rpt_Eltehak.rpt");
                //rpt_Eltehak myReport = new rpt_Eltehak();

               var sen = AgeService.NatAgeHesabSen(nat, sana);
               string octber_date = sen.Days + " يوم - " + sen.Months + " شهر - " + sen.Years + " سنة";


                myReport.SetParameterValue("@std_code", std_code);
                myReport.SetParameterValue("octber_date", octber_date);
                myReport.SetParameterValue("new_year", new_year);
                myReport.SetParameterValue("new_grade", new_grade);

                OpenReport(myReport, "طلب إلتحاق  " + std_name, "طلب إلتحاق");
            }
            catch(Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }
            
        }

        public void OpenTahwel_From_Report(string trans_code,
                                           string std_name,
                                           string year_desc, 
                                           string grade_desc)
        {
            try
            {
                ReportDocument myReport = new ReportDocument();
                myReport.Load(Application.StartupPath + @"/MyReports/rpt_Tahewl_From.rpt");
                //rpt_Tahewl_From myReport = new rpt_Tahewl_From();
             
                myReport.SetParameterValue("@Transfer_code", trans_code);
                myReport.SetParameterValue("new_year_desc", year_desc);
                myReport.SetParameterValue("new_grade", grade_desc);
               
                OpenReport(myReport, "طلب تحويل  " + std_name, "طلب تحويل من المدرسة");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

        public void OpenTahwel_To_Report(string trans_code, 
                                         string std_name, 
                                         string year_desc)
        {
            try
            {
                ReportDocument myReport = new ReportDocument();
                myReport.Load(Application.StartupPath + @"/MyReports/rpt_Tahewl_To.rpt");
                //rpt_Tahewl_To myReport = new rpt_Tahewl_To();

                myReport.SetParameterValue("@Transfer_code", trans_code);
                myReport.SetParameterValue("new_year_desc", year_desc);

                OpenReport(myReport, "طلب تحويل  " + std_name, "طلب تحويل إلى المدرسة");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

        public void Open_Kaema_Report(int year,int grade, string grade_desc)                         
        {

            try
            {
                ReportDocument myReport = new ReportDocument();
                myReport.Load(Application.StartupPath + @"/MyReports/rpt_Kaema.rpt");
                //rpt_Kaema myReport = new rpt_Kaema();
               
                myReport.SetParameterValue("@year_id", year);
                myReport.SetParameterValue("@grade_id", grade);

                OpenReport(myReport, "قوائم فصول  " + grade_desc, "قوائم الفصول");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

        public void OpenTadargSen(int year_id,
                                  int grade_id =0,
                                   bool isDesc = false)
        {
            try
            {
                ReportDocument myReport = new ReportDocument();
                myReport.Load(Application.StartupPath + @"/MyReports/rpt_Tadarg_Sen.rpt");
                //rpt_Tadarg_Sen myReport = new rpt_Tadarg_Sen();

                int October_Sana =  year_id + 20;
              
                myReport.SetParameterValue("@year_id", year_id);
                myReport.SetParameterValue("@grade_id", grade_id);
                myReport.SetParameterValue("@October_Sana", October_Sana);
                myReport.SetParameterValue("@isDesc", isDesc);

                
                OpenReport(myReport, "تدرج السن" , "تدرج السن");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

        public void OpenSegel(int year_id,
                              int grade_id = 0)
        {
            try
            {
                ReportDocument myReport = new ReportDocument();
                myReport.Load(Application.StartupPath + @"/MyReports/rpt_Segel_Data.rpt");

                int October_Sana = year_id + 20;
               
                myReport.SetParameterValue("@year_id", year_id);
                myReport.SetParameterValue("@grade_id", grade_id);
                myReport.SetParameterValue("@October_Sana", October_Sana);

                myReport.SetParameterValue("@year_id", year_id, "rpt_Segel_Transform_From.rpt");
                myReport.SetParameterValue("@grade_id", grade_id, "rpt_Segel_Transform_From.rpt");
                myReport.SetParameterValue("@October_Sana", October_Sana, "rpt_Segel_Transform_From.rpt");


                OpenReport(myReport, "سجل الطلاب", "سجل الطلاب");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

        public void OpenMostgdin_41(int year_id,
                                 int grade_id = 0)
        {
            try
            {
                ReportDocument myReport = new ReportDocument();
                myReport.Load(Application.StartupPath + @"/MyReports/rpt_Mostgdin_41.rpt");
                //rpt_Tadarg_Sen myReport = new rpt_Tadarg_Sen();

                int October_Sana = year_id + 20;

                myReport.SetParameterValue("@year_id", year_id);
                myReport.SetParameterValue("@grade_id", grade_id);
                myReport.SetParameterValue("@October_Sana", October_Sana);


                OpenReport(myReport, "كشف 41 مستجدين", "كشف 41 مستجدين");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }


        } 
        
        public void OpenTahewl_Data(int year_id,
                                 int grade_id = 0,
                                 params int[] statuses)
        {
            try
            {
                ReportDocument myReport = new ReportDocument();
                myReport.Load(Application.StartupPath + @"/MyReports/rpt_Tahewl_Data.rpt");
                

                myReport.SetParameterValue("@year_id", year_id);
                myReport.SetParameterValue("@grade_id", grade_id);
                myReport.SetParameterValue("@Status_Ids", string.Join(",", statuses));
   
                OpenReport(myReport, "بيان الطلاب المحولين", "بيان الطلاب المحولين");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

        public void OpenCount_Std(int year_id)
        {
            try
            {
                ReportDocument myReport = new ReportDocument();
                myReport.Load(Application.StartupPath + @"/MyReports/rpt_Count_Std.rpt");


                myReport.SetParameterValue("@year_id", year_id);
                myReport.SetParameterValue("@grade_id", 0);

                OpenReport(myReport, "بيان احصاء الطلاب", "بيان احصاء الطلاب");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

        public void OpenKoshof_Rasd(int grade_id, string month, byte rasd_kind = 1 )
        {
            try
            {
                string report_name = "rpt_Rasd_Degree_A.rpt";

                int year = Properties.Settings.Default.year_cod;
                ReportDocument myReport = new ReportDocument();
                if (rasd_kind == 1)
                {
                    switch (grade_id)
                    {
                        case 10:
                        case 11:
                        case 1:
                        case 2:
                        case 3:

                            report_name = "rpt_Rasd_Degree_A.rpt";
                            break;
                        case 4:
                        case 5:
                        case 6:

                            report_name = "rpt_Rasd_Degree_B.rpt";
                            break;

                        case 7:
                        case 8:
                        case 9:

                            report_name = "rpt_Rasd_Degree_C.rpt";
                            break;

                    }
                }
                else
                {
                    switch (grade_id)
                    {
                        case 10:
                        case 11:
                            report_name = "rpt_Rasd_Mark_A.rpt";
                            break;
                        case 1:
                        case 2:
                        case 3:
                            report_name = "rpt_Rasd_Mark_B.rpt";
                            break;

                        case 4:
                        case 5:
                        case 6:
                            report_name = "rpt_Rasd_Mark_C.rpt";
                            break;

                        case 7:
                        case 8:
                        case 9:
                            report_name = "rpt_Rasd_Mark_D.rpt";
                            break;

                    }
                }
                myReport.Load(Application.StartupPath + @"/MyReports/" + report_name);


                myReport.SetParameterValue("@year_id", year);
                myReport.SetParameterValue("@grade_id", grade_id);
                myReport.SetParameterValue("@month", month);
                if(rasd_kind == 1)
                {
                    myReport.SetParameterValue("@test_kind", "تقييمات");
                }
                else
                {
                    myReport.SetParameterValue("@test_kind", "اختبار");
                }
               
                

                OpenReport(myReport, "كشوف الرصد", "كشوف الرصد");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }


        public void Open_Koshof_Amal(int grade_id, string month)
        {
            try
            {
                string report_name = "rpt_Rasd_Degree_A.rpt";
                byte myYear = Globals.My_Year;
                int year = Properties.Settings.Default.year_cod;
                ReportDocument myReport = new ReportDocument();

                switch (grade_id)
                {
                    case 10:
                    case 11:
                        MSG.ErrorMesg("لا توجد كشوف للصف المحدد");
                        Waiting.Stop();
                        return;
                    case 1:
                    case 2:
                    case 3:
                        switch (myYear)
                        {
                            case 1:
                            case 2:
                            case 3:
                                MSG.ErrorMesg("لا توجد كشوف للصف المحدد");
                                Waiting.Stop();
                                return;
                           case var expreation when year >3:
                                switch (grade_id)
                                {
                                    case 1:
                                    case 2:
                                        report_name = "rpt_Amal_Degree_A_1_2.rpt";
                                        break;
                                    case 3:
                                        report_name = "rpt_Amal_Degree_A.rpt";
                                        break;
                                }
                               
                                break;
                        }

                        break;
                    case 4:
                    case 5:
                    case 6:

                        report_name = "rpt_Amal_Degree_B.rpt";
                        break;

                    case 7:
                    case 8:
                    case 9:

                        report_name = "rpt_Amal_Degree_C.rpt";
                        break;

                }

                myReport.Load(Application.StartupPath + @"/MyReports/" + report_name);


                myReport.SetParameterValue("@year_id", year);
                myReport.SetParameterValue("@grade_id", grade_id);
                myReport.SetParameterValue("@month", month);

                myReport.SetParameterValue("@test_kind", "أعمال السنة");



                OpenReport(myReport, "كشوف الرصد", "أعمال السنة");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

        public void OpenResdTest_A(int year_id,
                                 int grade_id = 0)
        {
            try
            {
                ReportDocument myReport = new ReportDocument();

                switch (grade_id)
                {
                    case 10:
                    case 11:
                        MSG.ErrorMesg("لا توجد كشوف للصف المحدد");
                        Waiting.Stop();
                        return;
                    case 1:
                    case 2:
                    case 3:
                        switch (year_id)
                        {
                            case 1:
                            case 2:
                            case 3:

                                MSG.ErrorMesg("لا توجد كشوف للصف المحدد");
                                Waiting.Stop();
                                return;
                            case var exptration when year_id > 3:

                                switch (grade_id)
                                {
                                    case 1:
                                    case 2:
                                        MSG.ErrorMesg("لا توجد كشوف للصف المحدد");
                                        MSG.MyExclamationMsg("الصفين الأول والثاني ليس لهم درجات اختبار ..!");
                                        Waiting.Stop();
                                        return;
                                    case 3:
                                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Rasd_Test_A.rpt");

                                        myReport.SetParameterValue("@Year_Id", year_id);
                                        myReport.SetParameterValue("@Grade_Id", grade_id);
                                        break;
                                }
                                break;
                        }
                        break;
                    case 4:
                    case 5:
                    case 6:

                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Rasd_Test_B.rpt");

                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Rasd_Test_B_Part_1.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Rasd_Test_B_Part_1.rpt");

                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Rasd_Test_B_Part_2.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Rasd_Test_B_Part_2.rpt");
                        break;

                    case 7:
                    case 8:
                    case 9:

                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Rasd_Test_C.rpt");


                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Rasd_Test_C_Part_1.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Rasd_Test_C_Part_1.rpt");

                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Rasd_Test_C_Part_2.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Rasd_Test_C_Part_2.rpt");

                        break;
                }
             
                OpenReport(myReport, "كشف الرصد", "كشف الرصد ");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

        public void OpenResdTest_B(int year_id,
                                 int grade_id = 0)

        {

            try
            {
                ReportDocument myReport = new ReportDocument();

                switch (grade_id)
                {
                    case 10:
                    case 11:
                        MSG.ErrorMesg("لا توجد كشوف للصف المحدد");
                        Waiting.Stop();
                        return;

                    case 1:
                    case 2:
                    case 3:
                        switch (year_id)
                        {
                            case 1:
                            case 2:
                            case 3:

                                MSG.ErrorMesg("لا توجد كشوف للصف المحدد");
                                Waiting.Stop();
                                return;
                            case var exptration when year_id > 3:

                                switch (grade_id)
                                {
                                    case 1:
                                    case 2:
                                        MSG.ErrorMesg("لا توجد كشوف للصف المحدد");
                                        MSG.MyExclamationMsg("الصفين الأول والثاني ليس لهم درجات اختبار ..!");
                                        Waiting.Stop();
                                        return;
                                    case 3:
                                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Rasd_Test_A_Term_2.rpt");

                                        myReport.SetParameterValue("@Year_Id", 0);
                                        myReport.SetParameterValue("@Grade_Id", 0);
                                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Rasd_Test_A_Term_2_Part_1.rpt");
                                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Rasd_Test_A_Term_2_Part_1.rpt");

                                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Rasd_Test_A_Term_2_Part_2.rpt");
                                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Rasd_Test_A_Term_2_Part_2.rpt");
                                        break;
                                }
                                break;
                        }
                        break;

                       
                    case 4:
                    case 5:
                    case 6:
                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Rasd_Test_B_Term_2.rpt");

                        myReport.SetParameterValue("@Year_Id", 0);
                        myReport.SetParameterValue("@Grade_Id", 0);
                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Rasd_Test_B_Term_2_Part_1.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Rasd_Test_B_Term_2_Part_1.rpt");

                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Rasd_Test_B_Term_2_Part_2.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Rasd_Test_B_Term_2_Part_2.rpt");
                        break;

                    case 7:
                    case 8:
                    case 9:
                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Rasd_Test_C_Term_2.rpt");

                        myReport.SetParameterValue("@Year_Id", 0);
                        myReport.SetParameterValue("@Grade_Id", 0);
                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Rasd_Test_C_Term_2_Part_1.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Rasd_Test_C_Term_2_Part_1.rpt");

                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Rasd_Test_C_Term_2_Part_2.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Rasd_Test_C_Term_2_Part_2.rpt");

                        break;
                }

                OpenReport(myReport, "كشف الرصد", "كشف الرصد ");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

        public void OpenNatega_A(int year_id,
                              int grade_id = 0)
        {
            try
            {
                ReportDocument myReport = new ReportDocument();

                switch (grade_id)
                {
                    case 10:
                    case 11:
                        MSG.ErrorMesg("لا توجد كشوف للصف المحدد");
                        Waiting.Stop();
                        return;
                    case 1:
                    case 2:
                    case 3:
                        switch (year_id)
                        {
                            case 1:
                            case 2:
                            case 3:

                                MSG.ErrorMesg("لا توجد كشوف للصف المحدد");
                                Waiting.Stop();
                                return;
                            case var expration when year_id > 3:
                                switch (grade_id)
                                {
                                    case 1:
                                    case 2:
                                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Review_Rasd_Test_A_1_2.rpt");

                                        myReport.SetParameterValue("@Year_Id", year_id);
                                        myReport.SetParameterValue("@Grade_Id", grade_id);

                                        break;

                                    case 3:
                                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Review_Rasd_Test_A.rpt");

                                        myReport.SetParameterValue("@Year_Id", year_id);
                                        myReport.SetParameterValue("@Grade_Id", grade_id);

                                        break;
                                }
                                break;
                        }
                        break;
                    case 4:
                    case 5:
                    case 6:

                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Review_Rasd_Test_B.rpt");

                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Review_Rasd_Test_B_Part_1.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Review_Rasd_Test_B_Part_1.rpt");

                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Review_Rasd_Test_B_Part_2.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Review_Rasd_Test_B_Part_2.rpt");
                        break;

                    case 7:
                    case 8:
                    case 9:

                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Review_Rasd_Test_C.rpt");


                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Review_Rasd_Test_C_Part_1.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Review_Rasd_Test_C_Part_1.rpt");

                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Review_Rasd_Test_C_Part_2.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Review_Rasd_Test_C_Part_2.rpt");

                        break;
                }

                OpenReport(myReport, "نتيجة الفصل الدراسي الأول", "نتيجة الفصل الدراسي الأول ");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

        public void OpenNatega_B(int year_id,
                                 int grade_id = 0)
        {
            try
            {
                ReportDocument myReport = new ReportDocument();

                switch (grade_id)
                {
                    case 10:
                    case 11:
                        MSG.ErrorMesg("لا توجد كشوف للصف المحدد");
                        Waiting.Stop();
                        return;
                    case 1:
                    case 2:
                    case 3:
                        switch (year_id)
                        {
                            case 1:
                            case 2:
                            case 3:

                                MSG.ErrorMesg("لا توجد كشوف للصف المحدد");
                                Waiting.Stop();
                                return;
                            case var expration when year_id > 3:
                                switch (grade_id)
                                {
                                    case 1:
                                    case 2:
                                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Review_Rasd_Test_B_1_2.rpt");

                                        myReport.SetParameterValue("@Year_Id", year_id);
                                        myReport.SetParameterValue("@Grade_Id", grade_id);

                                        break;

                                    case 3:
                                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Natega_A.rpt");

                                        myReport.SetParameterValue("@Year_Id", 0);
                                        myReport.SetParameterValue("@Grade_Id", 0);

                                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Natega_A_Part_1.rpt");
                                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Natega_A_Part_1.rpt");

                                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Natega_A_part_2.rpt");
                                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Natega_A_part_2.rpt");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 4:
                    case 5:
                    case 6:
                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Natega_B.rpt");

                        myReport.SetParameterValue("@Year_Id", 0);
                        myReport.SetParameterValue("@Grade_Id", 0);
                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Natega_B_Part_1.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Natega_B_Part_1.rpt");

                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Natega_B_part_2.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Natega_B_part_2.rpt");
                        break;

                    case 7:
                    case 8:
                    case 9:
                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Natega_C.rpt");

                        myReport.SetParameterValue("@Year_Id", 0);
                        myReport.SetParameterValue("@Grade_Id", 0);
                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Natega_C_Part_1.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Natega_C_Part_1.rpt");

                        myReport.SetParameterValue("@Year_Id", year_id, "rpt_Natega_C_Part_2.rpt");
                        myReport.SetParameterValue("@Grade_Id", grade_id, "rpt_Natega_C_Part_2.rpt");

                        break;
                }

                OpenReport(myReport, "نتيجة الفصل الدراسي الثاني", "نتيجة الفصل الدراسي الثاني ");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

        public void OpenFinal_Koshof(int year_id,
                                int grade_id, byte term =2)
        {
            int October_Sana = year_id + 20;
            int year = Properties.Settings.Default.year_cod;
            try
            {
                ReportDocument myReport = new ReportDocument();
                if(term == 1)
                {

                    switch (grade_id)
                    {
                        case 10:
                        case 11:
                        case 1:
                        case 2:
                            MSG.ErrorMesg("لم يتم إتاحة هذا الإجراء .. !");
                            return;
                        case 3:
                            myReport.Load(Application.StartupPath + @"/MyReports/rpt_Koshof_Natega_Term_A_Grade_3_2025.rpt");
                            break;
                        case 4:
                        case 5:
                        case 6:
                            myReport.Load(Application.StartupPath + @"/MyReports/rpt_Koshof_Natega_B_Term_A_2025.rpt");
                            break;

                        case 7:
                        case 8:
                        case 9:
                            MSG.MyExclamationMsg("هذا الاجراء غير متاح في نصف العام للصف المحدد .. !");
                            return;
                    }
                }
                else
                {
                    switch (year)
                    {
                        case 1:
                        case 2:
                        case 3:
                            switch (grade_id)
                            {
                                case 10:
                                case 11:
                                case 1:
                                case 2:
                                case 3:
                                    myReport.Load(Application.StartupPath + @"/MyReports/rpt_Koshof_Natega_A.rpt");
                                    break;

                                case 4:
                                case 5:
                                case 6:
                                    myReport.Load(Application.StartupPath + @"/MyReports/rpt_Koshof_Natega_B.rpt");
                                    break;

                                case 7:
                                case 8:
                                case 9:
                                    myReport.Load(Application.StartupPath + @"/MyReports/rpt_Koshof_Natega_C.rpt");
                                    break;
                            }

                            break;

                        case var expration when year > 3:
                            switch (grade_id)
                            {
                                case 10:
                                case 11:
                                case 1:
                                case 2:
                                    myReport.Load(Application.StartupPath + @"/MyReports/rpt_Koshof_Natega_A.rpt");
                                    break;

                                case 3:
                                    myReport.Load(Application.StartupPath + @"/MyReports/rpt_Koshof_Natega_Term_B_Grade_3_2025.rpt");
                                    break;
                                case 4:
                                case 5:
                                case 6:
                                    myReport.Load(Application.StartupPath + @"/MyReports/rpt_Koshof_Natega_B_Term_B_2025.rpt");
                                    break;

                                case 7:
                                case 8:
                                case 9:
                                    myReport.Load(Application.StartupPath + @"/MyReports/rpt_Koshof_Natega_C_2025.rpt");
                                    break;
                            }
                            break;
                    }
                }
               

                myReport.SetParameterValue("@year_id", year_id);
                myReport.SetParameterValue("@grade_id", grade_id);
                myReport.SetParameterValue("@October_Sana", October_Sana);

                switch (term)
                {
                    case 1:
                        OpenReport(myReport, "كشوف نتيجةنصف العام", "كشوف نتيجةنصف العام ");
                        break;
                    case 2:
                        OpenReport(myReport, "كشوف نتيجةأخرالعام", "كشوف نتيجةأخرالعام ");
                        break;
                }
               
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

        public void OpenAhsaaEdara(int year_id,int grade_id)                   
        {
            ReportDocument myReport = new ReportDocument();
            switch (grade_id)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    myReport.Load(Application.StartupPath + @"/MyReports/rpt_Analysis_prim.rpt");
                    break;
                case 7:
                case 8:
                    myReport.Load(Application.StartupPath + @"/MyReports/rpt_Analysis_prep.rpt");
                    break;

            }
            myReport.SetParameterValue("@Year_Id", year_id);
            myReport.SetParameterValue("@Grade_Id", grade_id);
            OpenReport(myReport, "إحصاء النتيجة", "إحصاء النتيجة");
        }
        public void OpenDegree_Statement(int year_id,
                               int grade_id,
                               string std_code)
        {
            try
            {
                ReportDocument myReport = new ReportDocument();

                switch (grade_id)
                {
                    case 10:
                    case 11:
                    case 1:
                    case 2:
                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Degree_Statement_A.rpt");
                        break;
                    case 3:

                        switch (year_id)
                        {
                            case 1:
                            case 2:
                                case 3:

                                myReport.Load(Application.StartupPath + @"/MyReports/rpt_Degree_Statement_A.rpt");

                                break;
                            case var expreation when year_id > 3:
                                myReport.Load(Application.StartupPath + @"/MyReports/rpt_Degree_Statement_A_Grade_3_2025.rpt");

                                break;
                        }

                        break;

                    case 4:
                    case 5:
                    case 6:
                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Degree_Statement_B.rpt");

                        break;

                    case 7:
                    case 8:
                    case 9:
                        myReport.Load(Application.StartupPath + @"/MyReports/rpt_Degree_Statement_C.rpt");

                        break;
                }

                myReport.SetParameterValue("@year_id", year_id);
                myReport.SetParameterValue("@std_code", std_code);

                OpenReport(myReport, "بيان درجات طالب", "بيان درجات طالب ");
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }

        }

    }
}
