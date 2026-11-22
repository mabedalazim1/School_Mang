using School_Mang.DAL;
using System.Data;


namespace School_Mang.BL.NATEG
{
    public class CLS_NATEG
    {
        private DataAcceseLayer DAL = new DataAcceseLayer();
        private SiteAccessLayer SiteAccess = new SiteAccessLayer();

        

        public void Update_Golos_Data(int std_code, int Golos)
        {
            DAL.ExecNonQuery("SP_Update_Golos_Data",
                SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Int("@std_code", std_code),
                SqlParam.Int("@Golos", Golos)
            );
        }

        
        public DataTable Get_Golos_Edit_Data(int Grade_Id, string Get_All = "no")
        {
            return DAL.ExecQuery("SP_Get_Golos_Edit_Data",
                SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.NVar("@Get_All", Get_All, 3)
            );
        }

        public DataTable Search_Golos_Data(int Grade_Id, string studeNtname)
        {
            return DAL.ExecQuery("SP_Search_Golos_Data",
                SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.NVar("@studeNtname", studeNtname, 200)
            );
        }

        public DataTable Get_Test_Month()
        {
            return DAL.ExecQuery("SP_GET_TEST_MONTHS");
        }

        public DataTable Get_Rasd_Data(int grade_id, int status = 0)
        {
            return DAL.ExecQuery("SP_Get_Rasd_Data",
                SqlParam.Int("@year_id", Properties.Settings.Default.year_cod),
                SqlParam.Int("@Grade_Id", grade_id),
                SqlParam.Int("@status", status)
            );
        }

        public void DeleteDegreeFromSite(int grade_Id, int test_kind_Id, int student_Id)
        {
            SiteAccess.ExecNonQuery("SP_Delete_From_Degree",
                SqlParam.Int("@grade_Id", grade_Id),
                SqlParam.Int("@test_kind_Id", test_kind_Id),
                SqlParam.Int("@student_Id", student_Id)
            );
        }

        public void DeleteMarkFromSite(int grade_Id, int test_kind_Id, int student_Id)
        {
            SiteAccess.ExecNonQuery("SP_Delete_From_Mark",
                SqlParam.Int("@grade_Id", grade_Id),
                SqlParam.Int("@test_kind_Id", test_kind_Id),
                SqlParam.Int("@student_Id", student_Id)
            );
        }

        public DataTable GET_GRADE()
        {
            return SiteAccess.ExecQuery("SP_GET_GRADE");
        }

        public DataTable GET_TEST_KIND()
        {
            return SiteAccess.ExecQuery("SP_GET_TEST_KIND");
        }

        public DataTable Get_Count_Degree(int test_kind_Id)
        {
            return SiteAccess.ExecQuery("SP_Get_Count_Degree",
                SqlParam.Int("@test_kind_Id", test_kind_Id)
            );
        }

        public DataTable Toggle_Hide_Data(int student_Id, byte test_kind_Id, string show_data)
        {
            bool data = show_data == "False" ? true : false;

            return SiteAccess.ExecQuery("SP_Toggle_Hide_Data",
                SqlParam.Int("@student_Id", student_Id),
                SqlParam.Byte("@test_kind_Id", test_kind_Id),
                SqlParam.Bit("@show_data", data)
            );
        }
        public DataTable Get_Count_Mark(int test_kind_Id)
        {
            return SiteAccess.ExecQuery("SP_Get_Count_Mark",
                SqlParam.Int("@test_kind_Id", test_kind_Id)
            );
        }
        public DataTable Get_Mark_Data(int test_kind_Id, int grade_Id, string serach = "no", string std_name = "")
        {
            return SiteAccess.ExecQuery("SP_Get_Mark_Data",
                SqlParam.Int("@test_kind_Id", test_kind_Id),
                SqlParam.Int("@grade_Id", grade_Id),
                SqlParam.NVar("@serach", serach, 3),
                SqlParam.NVar("@std_name", std_name, 100)
            );
        }
        public DataTable Get_Degree_Data(int test_kind_Id, int grade_Id, string serach = "no", string std_name = "")
        {
            return SiteAccess.ExecQuery("SP_Get_Degree_Data",
                SqlParam.Int("@test_kind_Id", test_kind_Id),
                SqlParam.Int("@grade_Id", grade_Id),
                SqlParam.NVar("@serach", serach, 3),
                SqlParam.NVar("@std_name", std_name, 100)
            );
        }

        public void Update_Degree(
                    int student_Id, decimal arabic_degre, decimal dain_degre,
                    decimal math_degre, decimal scince_degre, decimal social_degre,
                    decimal english_degre, decimal maharat_degre, decimal tocnolegy_degre,
                    decimal badania_degre, decimal general_degre, int test_kind_Id)
        {
            SiteAccess.ExecNonQuery("SP_Update_Degree",
                SqlParam.Int("@student_Id", student_Id),
                SqlParam.Decimal("@arabic_degre", arabic_degre),
                SqlParam.Decimal("@dain_degre", dain_degre),
                SqlParam.Decimal("@math_degre", math_degre),
                SqlParam.Decimal("@scince_degre", scince_degre),
                SqlParam.Decimal("@social_degre", social_degre),
                SqlParam.Decimal("@english_degre", english_degre),
                SqlParam.Decimal("@maharat_degre", maharat_degre),
                SqlParam.Decimal("@tocnolegy_degre", tocnolegy_degre),
                SqlParam.Decimal("@badania_degre", badania_degre),
                SqlParam.Decimal("@general_degre", general_degre),
                SqlParam.Int("@test_kind_Id", test_kind_Id)
            );
        }

       public void Update_Mark(
                           int student_Id, decimal arabic_degre, decimal dain_degre,
                           decimal math_degre, decimal scince_degre, decimal social_degre,
                           decimal english_degre, decimal maharat_degre, decimal tocnolegy_degre,
                           decimal french_degre, decimal general_degre, int sort_code, int test_kind_Id)
{
    SiteAccess.ExecNonQuery("SP_Update_Mark",
        SqlParam.Int("@student_Id", student_Id),
        SqlParam.Decimal("@arabic_degre", arabic_degre),
        SqlParam.Decimal("@dain_degre", dain_degre),
        SqlParam.Decimal("@math_degre", math_degre),
        SqlParam.Decimal("@scince_degre", scince_degre),
        SqlParam.Decimal("@social_degre", social_degre),
        SqlParam.Decimal("@english_degre", english_degre),
        SqlParam.Decimal("@maharat_degre", maharat_degre),
        SqlParam.Decimal("@tocnolegy_degre", tocnolegy_degre),
        SqlParam.Decimal("@french_degre", french_degre),
        SqlParam.Decimal("@general_degre", general_degre),
        SqlParam.Int("@sort_code", sort_code),
        SqlParam.Int("@test_kind_Id", test_kind_Id)
    );
}

        public void Update_Sery_Data(int Golos, int Sery)
        {

            DAL.ExecNonQuery("SP_Add_Sery",
                SqlParam.Int("@Golos", Golos),
                SqlParam.Int("@Year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Int("@Sery", Sery)
            );
        }

        public void Add_Amal_Final_1_2_3(int Golos,
                                        decimal arabic, decimal dain,
                                        decimal math, decimal english,
                                        decimal motadd, decimal badnia)
        {
            DAL.ExecNonQuery("SP_Add_Amal_Final_1_2_3",
                SqlParam.Int("@Golos", Golos),
                SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Float("@arabic", arabic),
                SqlParam.Float("@dain", dain),
                SqlParam.Float("@math", math),
                SqlParam.Float("@english", english),
                SqlParam.Float("@motadd", motadd),
                SqlParam.Float("@badnia", badnia)
            );
        }
  public void Add_Amal_A_1_2(int Golos,
                             decimal arabic_A_1, decimal dain_A_1,
                             decimal math_A_1, decimal scince_A_1,
                             decimal english_A_1, decimal maharat_A_1,
                             decimal mabday, decimal nehay)
        {
            DAL.ExecNonQuery("SP_Add_Amal_A_4_5_6",
                SqlParam.Int("@Golos", Golos),
                SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Float("@arabic_A_1", arabic_A_1),
                SqlParam.Float("@dain_A_1", dain_A_1),
                SqlParam.Float("@math_A_1", math_A_1),
                SqlParam.Float("@scince_A_1", scince_A_1),
                SqlParam.Float("@social_A_1", mabday),
                SqlParam.Float("@english_A_1", english_A_1),
                SqlParam.Float("@maharat_A_1", maharat_A_1),
                SqlParam.Float("@tocnolegy_A_1", nehay)
            );
        }

        public void Add_Amal_A_3(int Golos,
                                 decimal arabic_A_1, decimal dain_A_1,
                                 decimal math_A_1, decimal scince_A_1,
                                 decimal english_A_1, decimal maharat_A_1)
        {

            DAL.ExecNonQuery("SP_Add_Amal_A_4_5_6",
                SqlParam.Int("@Golos", Golos),
                SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Float("@arabic_A_1", arabic_A_1),
                SqlParam.Float("@dain_A_1", dain_A_1),
                SqlParam.Float("@math_A_1", math_A_1),
                SqlParam.Float("@scince_A_1", scince_A_1),
                SqlParam.Float("@social_A_1", 0),
                SqlParam.Float("@english_A_1", english_A_1),
                SqlParam.Float("@maharat_A_1", maharat_A_1),
                SqlParam.Float("@tocnolegy_A_1", 0)
            );
        }
        public void Add_Amal_A_4_5_6(int Golos,
                                    decimal arabic_A_1, decimal dain_A_1,
                                    decimal math_A_1, decimal scince_A_1,
                                    decimal social_A_1, decimal english_A_1,
                                    decimal maharat_A_1 , decimal tocnolegy_A_1)
        {

            DAL.ExecNonQuery("SP_Add_Amal_A_4_5_6",
                 SqlParam.Int("@Golos", Golos),
                 SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
                 SqlParam.Float("@arabic_A_1", arabic_A_1),
                 SqlParam.Float("@dain_A_1", dain_A_1),
                 SqlParam.Float("@math_A_1", math_A_1),
                 SqlParam.Float("@scince_A_1", scince_A_1),
                 SqlParam.Float("@social_A_1", social_A_1),
                 SqlParam.Float("@english_A_1", english_A_1),
                 SqlParam.Float("@maharat_A_1", maharat_A_1),
                 SqlParam.Float("@tocnolegy_A_1", tocnolegy_A_1)
             );
        }

        public void Add_Test_A(int Golos,
                                  decimal arabic_A_2, decimal dain_A_2,
                                  decimal math_A_2, decimal scince_A_2,
                                  decimal social_A_2, decimal english_A_2,
                                  decimal maharat_A_2, decimal tocnolegy_A_2)
        {

            DAL.ExecNonQuery("SP_Add_Test_A",
         SqlParam.Int("@Golos", Golos),
         SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
         SqlParam.Float("@arabic_A_2", arabic_A_2),
         SqlParam.Float("@dain_A_2", dain_A_2),
         SqlParam.Float("@math_A_2", math_A_2),
         SqlParam.Float("@scince_A_2", scince_A_2),
         SqlParam.Float("@social_A_2", social_A_2),
         SqlParam.Float("@english_A_2", english_A_2),
         SqlParam.Float("@maharat_A_2", maharat_A_2),
         SqlParam.Float("@tocnolegy_A_2", tocnolegy_A_2)
     );
        }

        public void Add_Test_B(int Golos,
                                decimal arabic_B_2, decimal dain_B_2,
                                decimal math_B_2, decimal scince_B_2,
                                decimal social_B_2, decimal english_B_2,
                                decimal maharat_B_2, decimal tocnolegy_B_2)
        {

            DAL.ExecNonQuery("SP_Add_Test_B",
                           SqlParam.Int("@Golos", Golos),
                           SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
                           SqlParam.Float("@arabic_B_2", arabic_B_2),
                           SqlParam.Float("@dain_B_2", dain_B_2),
                           SqlParam.Float("@math_B_2", math_B_2),
                           SqlParam.Float("@scince_B_2", scince_B_2),
                           SqlParam.Float("@social_B_2", social_B_2),
                           SqlParam.Float("@english_B_2", english_B_2),
                           SqlParam.Float("@maharat_B_2", maharat_B_2),
                           SqlParam.Float("@tocnolegy_B_2", tocnolegy_B_2)
            );
        }

        public void Add_Amal_B_1_2(int Golos,
                                   decimal arabic_B_1, decimal dain_B_1,
                                   decimal math_B_1, decimal scince_B_1,
                                  decimal english_B_1, decimal maharat_B_1,
                                    decimal mabday, decimal nehay)
        {

            DAL.ExecNonQuery("SP_Add_Amal_B_4_5_6",
                           SqlParam.Int("@Golos", Golos),
                           SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
                           SqlParam.Float("@arabic_B_1", arabic_B_1),
                           SqlParam.Float("@dain_B_1", dain_B_1),
                           SqlParam.Float("@math_B_1", math_B_1),
                           SqlParam.Float("@scince_B_1", scince_B_1),
                           SqlParam.Float("@social_B_1", mabday),
                           SqlParam.Float("@english_B_1", english_B_1),
                           SqlParam.Float("@maharat_B_1", maharat_B_1),
                           SqlParam.Float("@tocnolegy_B_1", nehay)
            );
        }

        public void Add_Amal_B_3(int Golos,
                                   decimal arabic_B_1, decimal dain_B_1,
                                   decimal math_B_1, decimal scince_B_1,
                                  decimal english_B_1,decimal maharat_B_1)
        {

            DAL.ExecNonQuery("SP_Add_Amal_B_4_5_6",
        SqlParam.Int("@Golos", Golos),
        SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
        SqlParam.Float("@arabic_B_1", arabic_B_1),
        SqlParam.Float("@dain_B_1", dain_B_1),
        SqlParam.Float("@math_B_1", math_B_1),
        SqlParam.Float("@scince_B_1", scince_B_1),
        SqlParam.Float("@social_B_1", 0),
        SqlParam.Float("@english_B_1", english_B_1),
        SqlParam.Float("@maharat_B_1", maharat_B_1),
        SqlParam.Float("@tocnolegy_B_1", 0)
    );
        }


        public void Add_Amal_B_4_5_6(int Golos,
                                    decimal arabic_B_1, decimal dain_B_1,
                                    decimal math_B_1, decimal scince_B_1,
                                    decimal social_B_1, decimal english_B_1,
                                    decimal maharat_B_1, decimal tocnolegy_B_1)
        {

            DAL.ExecNonQuery("SP_Add_Amal_B_4_5_6",
         SqlParam.Int("@Golos", Golos),
         SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
         SqlParam.Float("@arabic_B_1", arabic_B_1),
         SqlParam.Float("@dain_B_1", dain_B_1),
         SqlParam.Float("@math_B_1", math_B_1),
         SqlParam.Float("@scince_B_1", scince_B_1),
         SqlParam.Float("@social_B_1", social_B_1),
         SqlParam.Float("@english_B_1", english_B_1),
         SqlParam.Float("@maharat_B_1", maharat_B_1),
         SqlParam.Float("@tocnolegy_B_1", tocnolegy_B_1)
     );
        }


        public void Add_Amal_A_7_8_9(int Golos,
                                   decimal arabic_A_1, decimal dain_A_1,
                                   decimal math_A_1, decimal scince_A_1,
                                   decimal scince_A_practical,
                                   decimal social_A_1, decimal english_A_1,
                                   decimal maharat_A_1, decimal tocnolegy_A_1,
                                   decimal tocnolegy_A_practical,
                                   decimal nashat_1_A, decimal nashat_2_A)
        {

            DAL.ExecNonQuery("SP_Add_Amal_A_7_8_9",
         SqlParam.Int("@Golos", Golos),
         SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
         SqlParam.Float("@arabic_A_1", arabic_A_1),
         SqlParam.Float("@dain_A_1", dain_A_1),
         SqlParam.Float("@math_A_1", math_A_1),
         SqlParam.Float("@scince_A_1", scince_A_1),
         SqlParam.Float("@scince_A_practical", scince_A_practical),
         SqlParam.Float("@social_A_1", social_A_1),
         SqlParam.Float("@english_A_1", english_A_1),
         SqlParam.Float("@maharat_A_1", maharat_A_1),
         SqlParam.Float("@tocnolegy_A_1", tocnolegy_A_1),
         SqlParam.Float("@tocnolegy_A_practical", tocnolegy_A_practical),
         SqlParam.Float("@nashat_1_A", nashat_1_A),
         SqlParam.Float("@nashat_2_A", nashat_2_A)
     );

        }

        public void Add_Amal_B_7_8_9(int Golos,
                                  decimal arabic_B_1, decimal dain_B_1,
                                  decimal math_B_1, decimal scince_B_1,
                                  decimal scince_B_practical,
                                  decimal social_B_1, decimal english_B_1,
                                  decimal maharat_B_1, decimal tocnolegy_B_1,
                                  decimal tocnolegy_B_practical,
                                  decimal nashat_1_B, decimal nashat_2_B)
        {

            DAL.ExecNonQuery("SP_Add_Amal_B_7_8_9",
         SqlParam.Int("@Golos", Golos),
         SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
         SqlParam.Float("@arabic_B_1", arabic_B_1),
         SqlParam.Float("@dain_B_1", dain_B_1),
         SqlParam.Float("@math_B_1", math_B_1),
         SqlParam.Float("@scince_B_1", scince_B_1),
         SqlParam.Float("@scince_B_practical", scince_B_practical),
         SqlParam.Float("@social_B_1", social_B_1),
         SqlParam.Float("@english_B_1", english_B_1),
         SqlParam.Float("@maharat_B_1", maharat_B_1),
         SqlParam.Float("@tocnolegy_B_1", tocnolegy_B_1),
         SqlParam.Float("@tocnolegy_B_practical", tocnolegy_B_practical),
         SqlParam.Float("@nashat_1_B", nashat_1_B),
         SqlParam.Float("@nashat_2_B", nashat_2_B)
     );
        }

        public DataTable Get_Final_Degree(int Grade_Id)
        {

            return DAL.ExecQuery("SP_Get_Final_Degree",
                             SqlParam.Int("@Year_Id", Properties.Settings.Default.year_cod),
                             SqlParam.Int("@Grade_Id", Grade_Id)
            );
        }

        public DataTable Get_Count_Final_Degree()
        {
            return DAL.ExecQuery("SP_Get_Count_Final_Degree",
                SqlParam.Int("@Year_Id", Properties.Settings.Default.year_cod)
            );
        }

        public DataTable Get_Final_Total_Degree(int Grade_Id, string name = "")
        {
            return DAL.ExecQuery("SP_Get_Final_Total_Degree",
                SqlParam.Int("@Year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.NVar("@Name", name, 100)
            );
        }

        // الدالة الجديدة: تستقبل المرحلة صراحةً
        public DataTable Get_Final_All_Data(int Golos, int GradeId)
        {
            return DAL.ExecQuery("SP_Get_Final_All_Data",
                SqlParam.Int("@Year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Int("@Grade_Id", GradeId),
                SqlParam.Int("@Golos", Golos)
            );
        }
        public void Update_Final_Degree_Data(
                                            decimal arabic,
                                            decimal math,
                                            decimal scince,
                                            decimal scince_practical,
                                            decimal social,
                                            decimal english,
                                            decimal dain,
                                            decimal maharat,
                                            decimal tocnolegy,
                                            decimal tocnolegy_practical,
                                            int studentGolos,
                                            byte testKind)
        {

            DAL.ExecNonQuery("SP_Update_Final_Degree_Data",
        SqlParam.Int("@Golos", studentGolos),
        SqlParam.Int("@Year_Id", Properties.Settings.Default.year_cod),
        SqlParam.Int("@Test_Kind", testKind),

        SqlParam.Float("@arabic", arabic),
        SqlParam.Float("@math", math),
        SqlParam.Float("@scince", scince),
        SqlParam.Float("@scince_practical", scince_practical),
        SqlParam.Float("@social", social),
        SqlParam.Float("@english", english),
        SqlParam.Float("@dain", dain),
        SqlParam.Float("@maharat", maharat),
        SqlParam.Float("@tocnolegy", tocnolegy),
        SqlParam.Float("@tocnolegy_practical", tocnolegy_practical)
    );
        }


        public void Update_Final_Absent(
                                           int stdGolos,
                                           bool absent_ar_A,
                                           bool absent_ar_B,
                                           bool absent_math_A,
                                           bool absent_math_B,
                                           bool absent_scince_A,
                                           bool absent_scince_B,
                                           bool absent_social_A,
                                           bool absent_social_B,
                                           bool absent_english_A,
                                           bool absent_english_B,
                                           bool absent_din_A,
                                           bool absent_din_B,
                                           bool absent_maharat_A,
                                           bool absent_maharat_B,
                                           bool absent_tocnolegy_A,
                                           bool absent_tocnolegy_B,
                                           bool absent_term_A,
                                           bool absent_term_B)
        {

            DAL.ExecNonQuery("SP_Update_Final_Absent",
       SqlParam.Int("@Golos", stdGolos),
       SqlParam.Int("@Year_Id", Properties.Settings.Default.year_cod),

       SqlParam.Bit("@absent_ar_A", absent_ar_A),
       SqlParam.Bit("@absent_ar_B", absent_ar_B),
       SqlParam.Bit("@absent_math_A", absent_math_A),
       SqlParam.Bit("@absent_math_B", absent_math_B),
       SqlParam.Bit("@absent_scince_A", absent_scince_A),
       SqlParam.Bit("@absent_scince_B", absent_scince_B),
       SqlParam.Bit("@absent_social_A", absent_social_A),
       SqlParam.Bit("@absent_social_B", absent_social_B),
       SqlParam.Bit("@absent_english_A", absent_english_A),
       SqlParam.Bit("@absent_english_B", absent_english_B),
       SqlParam.Bit("@absent_din_A", absent_din_A),
       SqlParam.Bit("@absent_din_B", absent_din_B),
       SqlParam.Bit("@absent_maharat_A", absent_maharat_A),
       SqlParam.Bit("@absent_maharat_B", absent_maharat_B),
       SqlParam.Bit("@absent_tocnolegy_A", absent_tocnolegy_A),
       SqlParam.Bit("@absent_tocnolegy_B", absent_tocnolegy_B),
       SqlParam.Bit("@absent_term_A", absent_term_A),
       SqlParam.Bit("@absent_term_B", absent_term_B)
   );
        }
    }
}
