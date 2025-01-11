using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using School_Mang.DAL;

namespace School_Mang.BL.NATEG
{
    class CLS_NATEG
    {
        public DataTable Get_Golos_Sum(int Grade_Id, string status = "")
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.year_cod;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = Grade_Id;

            param[2] = new SqlParameter("@status", SqlDbType.VarChar,5);
            param[2].Value = status;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Golos_Sum", param);
            DAL.Close();
            return Dt;
        }

        public void Update_Golos_Data(int std_code, int Golos)
        {
            DataAcceseLayer DAL = new DataAcceseLayer();
           
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.year_cod;

            param[1] = new SqlParameter("@std_code", SqlDbType.Int);
            param[1].Value = std_code;

            param[2] = new SqlParameter("@Golos", SqlDbType.Int);
            param[2].Value = Golos;

            DAL.Open();
            DAL.ExeucuteCommand("SP_Update_Golos_Data", param);  
        }

        public DataTable Get_Golos_Data(int Grade_Id)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.year_cod;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = Grade_Id;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Golos_Data", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Golos_Edit_Data(int Grade_Id, string Get_All = "no")                   
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.year_cod;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = Grade_Id;

            param[2] = new SqlParameter("@Get_All", SqlDbType.NVarChar, 3);
            param[2].Value = Get_All;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Golos_Edit_Data", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Search_Golos_Data(int Grade_Id, string studeNtname)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.year_cod;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = Grade_Id;

            param[2] = new SqlParameter("@studeNtname", SqlDbType.NVarChar, 200);
            param[2].Value = studeNtname;

            DataTable Dt;
             
            Dt = DAL.Selectdata("SP_Search_Golos_Data", param);
            DAL.Close();
            return Dt;
        }


        public DataTable Get_Test_Month()
        {
            DataAcceseLayer DAL = new DataAcceseLayer();
            DataTable Dt;
            Dt = DAL.Selectdata("SP_GET_TEST_MONTHS", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Rasd_Data(int grade_id,int status = 0)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@year_id", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.year_cod;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = grade_id;

            param[2] = new SqlParameter("@status", SqlDbType.Int);
            param[2].Value = status;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Rasd_Data", param);
            DAL.Close();
            return Dt;
        }

        public void DeleteAssessmentFromSite(int year_Id,int term_Id, int grade_Id, string sp_name)
        {

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[0].Value = year_Id;

            param[1] = new SqlParameter("@term_Id", SqlDbType.Int);
            param[1].Value = term_Id;

            param[2] = new SqlParameter("@grade_Id", SqlDbType.Int);
            param[2].Value = grade_Id;

            DAL.ExeucuteCommand("SP_Delete_From_" + sp_name, param);
        }


        public void DeleteDegreeFromSite(int grade_Id, int test_kind_Id, int student_Id)
        {

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@grade_Id", SqlDbType.Int);
            param[0].Value = grade_Id;

            param[1] = new SqlParameter("@test_kind_Id", SqlDbType.Int);
            param[1].Value = test_kind_Id;

            param[2] = new SqlParameter("@student_Id", SqlDbType.Int);
            param[2].Value = student_Id;

            DAL.ExeucuteCommand("SP_Delete_From_Degree", param);
        }

        public void DeleteMarkFromSite(int grade_Id, int test_kind_Id, int student_Id)
        {

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@grade_Id", SqlDbType.Int);
            param[0].Value = grade_Id;

            param[1] = new SqlParameter("@test_kind_Id", SqlDbType.Int);
            param[1].Value = test_kind_Id;

            param[2] = new SqlParameter("@student_Id", SqlDbType.Int);
            param[2].Value = student_Id;

            DAL.ExeucuteCommand("SP_Delete_From_Mark", param);
        }

        public DataTable GET_GRADE()
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            DataTable Dt;
            Dt = DAL.Selectdata("SP_GET_GRADE", null);
            DAL.Close();
            return Dt;
        }

        public DataTable GET_TEST_KIND()
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            DataTable Dt;
            Dt = DAL.Selectdata("SP_GET_TEST_KIND", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Count_Degree(int test_kind_Id)
        {

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@test_kind_Id", SqlDbType.Int);
            param[0].Value = test_kind_Id;

            
            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Count_Degree", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Toggle_Hide_Data(int student_Id,byte test_kind_Id , string show_data)
        {
            bool data ;

            if(show_data != "False")
            {
                data = false;
            }
            else
            {
                data = true;
            }
            

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
            param[0].Value = student_Id;

            param[1] = new SqlParameter("@test_kind_Id", SqlDbType.TinyInt);
            param[1].Value = test_kind_Id;

            param[2] = new SqlParameter("@show_data", SqlDbType.Bit);
            param[2].Value = data;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Toggle_Hide_Data", param);
            DAL.Close();
            return Dt;
        }
        public DataTable Get_Count_Mark(int test_kind_Id)
        {

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@test_kind_Id", SqlDbType.Int);
            param[0].Value = test_kind_Id;


            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Count_Mark", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Mark_Data(int test_kind_Id, int grade_Id,string serach = "no", string std_name = "")
        {

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@test_kind_Id", SqlDbType.Int);
            param[0].Value = test_kind_Id;


            param[1] = new SqlParameter("@grade_Id", SqlDbType.Int);
            param[1].Value = grade_Id;

            param[2] = new SqlParameter("@serach", SqlDbType.NVarChar, 3);
            param[2].Value = serach;

            param[3] = new SqlParameter("@std_name", SqlDbType.NVarChar, 100);
            param[3].Value = std_name;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Mark_Data", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Degree_Data(int test_kind_Id, int grade_Id, string serach ="no",string std_name="")
        {

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@test_kind_Id", SqlDbType.Int);
            param[0].Value = test_kind_Id;


            param[1] = new SqlParameter("@grade_Id", SqlDbType.Int);
            param[1].Value = grade_Id;

            param[2] = new SqlParameter("@serach", SqlDbType.NVarChar, 3);
            param[2].Value = serach;

            param[3] = new SqlParameter("@std_name", SqlDbType.NVarChar, 100);
            param[3].Value = std_name;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Degree_Data", param);
            DAL.Close();
            return Dt;
        }

        public void Update_Degree(
            int student_Id,int arabic_degre, int dain_degre,
            int math_degre, int scince_degre, int social_degre,
            int english_degre, int maharat_degre, int tocnolegy_degre,
            int badania_degre, int general_degre, int test_kind_Id)
        {

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[12];

            param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
            param[0].Value = student_Id;

            param[1] = new SqlParameter("@arabic_degre", SqlDbType.Int);
            param[1].Value = arabic_degre;

            param[2] = new SqlParameter("@dain_degre", SqlDbType.Int);
            param[2].Value = dain_degre;

            param[3] = new SqlParameter("@math_degre", SqlDbType.Int);
            param[3].Value = math_degre;

            param[4] = new SqlParameter("@scince_degre", SqlDbType.Int);
            param[4].Value = scince_degre;

            param[5] = new SqlParameter("@social_degre", SqlDbType.Int);
            param[5].Value = social_degre;

            param[6] = new SqlParameter("@english_degre", SqlDbType.Int);
            param[6].Value = english_degre;

            param[7] = new SqlParameter("@maharat_degre", SqlDbType.Int);
            param[7].Value = maharat_degre;

            param[8] = new SqlParameter("@tocnolegy_degre", SqlDbType.Int);
            param[8].Value = tocnolegy_degre;

            param[9] = new SqlParameter("@badania_degre", SqlDbType.Int);
            param[9].Value = badania_degre;

            param[10] = new SqlParameter("@general_degre", SqlDbType.Int);
            param[10].Value = general_degre;

            param[11] = new SqlParameter("@test_kind_Id", SqlDbType.Int);
            param[11].Value = test_kind_Id;

            DAL.ExeucuteCommand("SP_Update_Degree", param);
        }

        public void Update_Mark(
           int student_Id, decimal arabic_degre, decimal dain_degre,
           decimal math_degre, decimal scince_degre, decimal social_degre,
           decimal english_degre, decimal maharat_degre, decimal tocnolegy_degre,
           decimal french_degre, decimal general_degre,int sort_code, int test_kind_Id)
        {

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[13];

            param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
            param[0].Value = student_Id;

            param[1] = new SqlParameter("@arabic_degre", SqlDbType.Float);
            param[1].Value = arabic_degre;

            param[2] = new SqlParameter("@dain_degre", SqlDbType.Float);
            param[2].Value = dain_degre;

            param[3] = new SqlParameter("@math_degre", SqlDbType.Float);
            param[3].Value = math_degre;

            param[4] = new SqlParameter("@scince_degre", SqlDbType.Float);
            param[4].Value = scince_degre;

            param[5] = new SqlParameter("@social_degre", SqlDbType.Float);
            param[5].Value = social_degre;

            param[6] = new SqlParameter("@english_degre", SqlDbType.Float);
            param[6].Value = english_degre;

            param[7] = new SqlParameter("@maharat_degre", SqlDbType.Float);
            param[7].Value = maharat_degre;

            param[8] = new SqlParameter("@tocnolegy_degre", SqlDbType.Float);
            param[8].Value = tocnolegy_degre;

            param[9] = new SqlParameter("@french_degre", SqlDbType.Float);
            param[9].Value = french_degre;

            param[10] = new SqlParameter("@general_degre", SqlDbType.Float);
            param[10].Value = general_degre;

            param[11] = new SqlParameter("@sort_code", SqlDbType.Int);
            param[11].Value = sort_code;

            param[12] = new SqlParameter("@test_kind_Id", SqlDbType.Int);
            param[12].Value = test_kind_Id;

            DAL.ExeucuteCommand("SP_Update_Mark", param);
        }

        public void Update_Sery_Data(int Golos, int Sery)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[1].Value = Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@Sery", SqlDbType.Int);
            param[2].Value = Sery;

            DAL.ExeucuteCommand("SP_Add_Sery", param);
        }

        public void Add_Amal_Final_1_2_3(int Golos,
                                   decimal arabic, decimal dain,
                                   decimal math, decimal english,
                                   decimal motadd, decimal badnia)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[1].Value = Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@arabic", SqlDbType.Float);
            param[2].Value = arabic;

            param[3] = new SqlParameter("@dain", SqlDbType.Float);
            param[3].Value = dain;

            param[4] = new SqlParameter("@math", SqlDbType.Float);
            param[4].Value = math;

            param[5] = new SqlParameter("@english", SqlDbType.Float);
            param[5].Value = english;

            param[6] = new SqlParameter("@motadd", SqlDbType.Float);
            param[6].Value = motadd;

            param[7] = new SqlParameter("@badnia", SqlDbType.Float);
            param[7].Value = badnia;

            DAL.ExeucuteCommand("SP_Add_Amal_Final_1_2_3", param);
        }

        public void Add_Amal_A_1_2(int Golos,
                                   decimal arabic_A_1, decimal dain_A_1,
                                   decimal math_A_1, decimal scince_A_1,
                                   decimal english_A_1, decimal maharat_A_1,
                                   decimal mabday, decimal nehay)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[1].Value = Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@arabic_A_1", SqlDbType.Float);
            param[2].Value = arabic_A_1;

            param[3] = new SqlParameter("@dain_A_1", SqlDbType.Float);
            param[3].Value = dain_A_1;

            param[4] = new SqlParameter("@math_A_1", SqlDbType.Float);
            param[4].Value = math_A_1;

            param[5] = new SqlParameter("@scince_A_1", SqlDbType.Float);
            param[5].Value = scince_A_1;

            param[6] = new SqlParameter("@social_A_1", SqlDbType.Float);
            param[6].Value = mabday;

            param[7] = new SqlParameter("@english_A_1", SqlDbType.Float);
            param[7].Value = english_A_1;

            param[8] = new SqlParameter("@maharat_A_1", SqlDbType.Float);
            param[8].Value = maharat_A_1;

            param[9] = new SqlParameter("@tocnolegy_A_1", SqlDbType.Float);
            param[9].Value = nehay;

            DAL.ExeucuteCommand("SP_Add_Amal_A_4_5_6", param);
        }

        public void Add_Amal_A_3(int Golos,
                                decimal arabic_A_1, decimal dain_A_1,
                                decimal math_A_1, decimal scince_A_1,
                                decimal english_A_1, decimal maharat_A_1)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[1].Value = Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@arabic_A_1", SqlDbType.Float);
            param[2].Value = arabic_A_1;

            param[3] = new SqlParameter("@dain_A_1", SqlDbType.Float);
            param[3].Value = dain_A_1;

            param[4] = new SqlParameter("@math_A_1", SqlDbType.Float);
            param[4].Value = math_A_1;

            param[5] = new SqlParameter("@scince_A_1", SqlDbType.Float);
            param[5].Value = scince_A_1;

            param[6] = new SqlParameter("@social_A_1", SqlDbType.Float);
            param[6].Value = 0;

            param[7] = new SqlParameter("@english_A_1", SqlDbType.Float);
            param[7].Value = english_A_1;

            param[8] = new SqlParameter("@maharat_A_1", SqlDbType.Float);
            param[8].Value = maharat_A_1;

            param[9] = new SqlParameter("@tocnolegy_A_1", SqlDbType.Float);
            param[9].Value = 0;

            DAL.ExeucuteCommand("SP_Add_Amal_A_4_5_6", param);
        }
        public void Add_Amal_A_4_5_6(int Golos,
                                    decimal arabic_A_1, decimal dain_A_1,
                                    decimal math_A_1, decimal scince_A_1,
                                    decimal social_A_1, decimal english_A_1,
                                    decimal maharat_A_1 , decimal tocnolegy_A_1)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[1].Value = Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@arabic_A_1", SqlDbType.Float);
            param[2].Value = arabic_A_1;

            param[3] = new SqlParameter("@dain_A_1", SqlDbType.Float);
            param[3].Value = dain_A_1;

            param[4] = new SqlParameter("@math_A_1", SqlDbType.Float);
            param[4].Value = math_A_1;

            param[5] = new SqlParameter("@scince_A_1", SqlDbType.Float);
            param[5].Value = scince_A_1;

            param[6] = new SqlParameter("@social_A_1", SqlDbType.Float);
            param[6].Value = social_A_1;

            param[7] = new SqlParameter("@english_A_1", SqlDbType.Float);
            param[7].Value = english_A_1;

            param[8] = new SqlParameter("@maharat_A_1", SqlDbType.Float);
            param[8].Value = maharat_A_1;

            param[9] = new SqlParameter("@tocnolegy_A_1", SqlDbType.Float);
            param[9].Value = tocnolegy_A_1;

            DAL.ExeucuteCommand("SP_Add_Amal_A_4_5_6", param);
        }

        public void Add_Test_A(int Golos,
                                  decimal arabic_A_2, decimal dain_A_2,
                                  decimal math_A_2, decimal scince_A_2,
                                  decimal social_A_2, decimal english_A_2,
                                  decimal maharat_A_2, decimal tocnolegy_A_2)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[1].Value = Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@arabic_A_2", SqlDbType.Float);
            param[2].Value = arabic_A_2;

            param[3] = new SqlParameter("@dain_A_2", SqlDbType.Float);
            param[3].Value = dain_A_2;

            param[4] = new SqlParameter("@math_A_2", SqlDbType.Float);
            param[4].Value = math_A_2;

            param[5] = new SqlParameter("@scince_A_2", SqlDbType.Float);
            param[5].Value = scince_A_2;

            param[6] = new SqlParameter("@social_A_2", SqlDbType.Float);
            param[6].Value = social_A_2;

            param[7] = new SqlParameter("@english_A_2", SqlDbType.Float);
            param[7].Value = english_A_2;

            param[8] = new SqlParameter("@maharat_A_2", SqlDbType.Float);
            param[8].Value = maharat_A_2;

            param[9] = new SqlParameter("@tocnolegy_A_2", SqlDbType.Float);
            param[9].Value = tocnolegy_A_2;

            DAL.ExeucuteCommand("SP_Add_Test_A", param);
        }

        public void Add_Test_B(int Golos,
                                decimal arabic_B_2, decimal dain_B_2,
                                decimal math_B_2, decimal scince_B_2,
                                decimal social_B_2, decimal english_B_2,
                                decimal maharat_B_2, decimal tocnolegy_B_2)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[1].Value = Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@arabic_B_2", SqlDbType.Float);
            param[2].Value = arabic_B_2;

            param[3] = new SqlParameter("@dain_B_2", SqlDbType.Float);
            param[3].Value = dain_B_2;

            param[4] = new SqlParameter("@math_B_2", SqlDbType.Float);
            param[4].Value = math_B_2;

            param[5] = new SqlParameter("@scince_B_2", SqlDbType.Float);
            param[5].Value = scince_B_2;

            param[6] = new SqlParameter("@social_B_2", SqlDbType.Float);
            param[6].Value = social_B_2;

            param[7] = new SqlParameter("@english_B_2", SqlDbType.Float);
            param[7].Value = english_B_2;

            param[8] = new SqlParameter("@maharat_B_2", SqlDbType.Float);
            param[8].Value = maharat_B_2;

            param[9] = new SqlParameter("@tocnolegy_B_2", SqlDbType.Float);
            param[9].Value = tocnolegy_B_2;

            DAL.ExeucuteCommand("SP_Add_Test_B", param);
        }

        public void Add_Amal_B_1_2(int Golos,
                                   decimal arabic_B_1, decimal dain_B_1,
                                   decimal math_B_1, decimal scince_B_1,
                                  decimal english_B_1, decimal maharat_B_1,
                                    decimal mabday, decimal nehay)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[1].Value = Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@arabic_B_1", SqlDbType.Float);
            param[2].Value = arabic_B_1;

            param[3] = new SqlParameter("@dain_B_1", SqlDbType.Float);
            param[3].Value = dain_B_1;

            param[4] = new SqlParameter("@math_B_1", SqlDbType.Float);
            param[4].Value = math_B_1;

            param[5] = new SqlParameter("@scince_B_1", SqlDbType.Float);
            param[5].Value = scince_B_1;

            param[6] = new SqlParameter("@social_B_1", SqlDbType.Float);
            param[6].Value = mabday;

            param[7] = new SqlParameter("@english_B_1", SqlDbType.Float);
            param[7].Value = english_B_1;

            param[8] = new SqlParameter("@maharat_B_1", SqlDbType.Float);
            param[8].Value = maharat_B_1;

            param[9] = new SqlParameter("@tocnolegy_B_1", SqlDbType.Float);
            param[9].Value = nehay;

            DAL.ExeucuteCommand("SP_Add_Amal_B_4_5_6", param);
        }

        public void Add_Amal_B_3(int Golos,
                                   decimal arabic_B_1, decimal dain_B_1,
                                   decimal math_B_1, decimal scince_B_1,
                                  decimal english_B_1,decimal maharat_B_1)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[1].Value = Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@arabic_B_1", SqlDbType.Float);
            param[2].Value = arabic_B_1;

            param[3] = new SqlParameter("@dain_B_1", SqlDbType.Float);
            param[3].Value = dain_B_1;

            param[4] = new SqlParameter("@math_B_1", SqlDbType.Float);
            param[4].Value = math_B_1;

            param[5] = new SqlParameter("@scince_B_1", SqlDbType.Float);
            param[5].Value = scince_B_1;

            param[6] = new SqlParameter("@social_B_1", SqlDbType.Float);
            param[6].Value = 0;

            param[7] = new SqlParameter("@english_B_1", SqlDbType.Float);
            param[7].Value = english_B_1;

            param[8] = new SqlParameter("@maharat_B_1", SqlDbType.Float);
            param[8].Value = maharat_B_1;

            param[9] = new SqlParameter("@tocnolegy_B_1", SqlDbType.Float);
            param[9].Value = 0;

            DAL.ExeucuteCommand("SP_Add_Amal_B_4_5_6", param);
        }


        public void Add_Amal_B_4_5_6(int Golos,
                                    decimal arabic_B_1, decimal dain_B_1,
                                    decimal math_B_1, decimal scince_B_1,
                                    decimal social_B_1, decimal english_B_1,
                                    decimal maharat_B_1, decimal tocnolegy_B_1)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[1].Value = Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@arabic_B_1", SqlDbType.Float);
            param[2].Value = arabic_B_1;

            param[3] = new SqlParameter("@dain_B_1", SqlDbType.Float);
            param[3].Value = dain_B_1;

            param[4] = new SqlParameter("@math_B_1", SqlDbType.Float);
            param[4].Value = math_B_1;

            param[5] = new SqlParameter("@scince_B_1", SqlDbType.Float);
            param[5].Value = scince_B_1;

            param[6] = new SqlParameter("@social_B_1", SqlDbType.Float);
            param[6].Value = social_B_1;

            param[7] = new SqlParameter("@english_B_1", SqlDbType.Float);
            param[7].Value = english_B_1;

            param[8] = new SqlParameter("@maharat_B_1", SqlDbType.Float);
            param[8].Value = maharat_B_1;

            param[9] = new SqlParameter("@tocnolegy_B_1", SqlDbType.Float);
            param[9].Value = tocnolegy_B_1;

            DAL.ExeucuteCommand("SP_Add_Amal_B_4_5_6", param);
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

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[14];

            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[1].Value = Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@arabic_A_1", SqlDbType.Float);
            param[2].Value = arabic_A_1;

            param[3] = new SqlParameter("@dain_A_1", SqlDbType.Float);
            param[3].Value = dain_A_1;

            param[4] = new SqlParameter("@math_A_1", SqlDbType.Float);
            param[4].Value = math_A_1;

            param[5] = new SqlParameter("@scince_A_1", SqlDbType.Float);
            param[5].Value = scince_A_1;

            param[6] = new SqlParameter("@scince_A_practical", SqlDbType.Float);
            param[6].Value = scince_A_practical;

            param[7] = new SqlParameter("@social_A_1", SqlDbType.Float);
            param[7].Value = social_A_1;

            param[8] = new SqlParameter("@english_A_1", SqlDbType.Float);
            param[8].Value = english_A_1;

            param[9] = new SqlParameter("@maharat_A_1", SqlDbType.Float);
            param[9].Value = maharat_A_1;

            param[10] = new SqlParameter("@tocnolegy_A_1", SqlDbType.Float);
            param[10].Value = tocnolegy_A_1;

            param[11] = new SqlParameter("@tocnolegy_A_practical", SqlDbType.Float);
            param[11].Value = tocnolegy_A_practical;

            param[12] = new SqlParameter("@nashat_1_A", SqlDbType.Float);
            param[12].Value = nashat_1_A;

            param[13] = new SqlParameter("@nashat_2_A", SqlDbType.Float);
            param[13].Value = nashat_2_A;

            DAL.ExeucuteCommand("SP_Add_Amal_A_7_8_9", param);
            
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

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[14];

            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@year_Id", SqlDbType.Int);
            param[1].Value = Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@arabic_B_1", SqlDbType.Float);
            param[2].Value = arabic_B_1;

            param[3] = new SqlParameter("@dain_B_1", SqlDbType.Float);
            param[3].Value = dain_B_1;

            param[4] = new SqlParameter("@math_B_1", SqlDbType.Float);
            param[4].Value = math_B_1;

            param[5] = new SqlParameter("@scince_B_1", SqlDbType.Float);
            param[5].Value = scince_B_1;

            param[6] = new SqlParameter("@scince_B_practical", SqlDbType.Float);
            param[6].Value = scince_B_practical;

            param[7] = new SqlParameter("@social_B_1", SqlDbType.Float);
            param[7].Value = social_B_1;

            param[8] = new SqlParameter("@english_B_1", SqlDbType.Float);
            param[8].Value = english_B_1;

            param[9] = new SqlParameter("@maharat_B_1", SqlDbType.Float);
            param[9].Value = maharat_B_1;

            param[10] = new SqlParameter("@tocnolegy_B_1", SqlDbType.Float);
            param[10].Value = tocnolegy_B_1;

            param[11] = new SqlParameter("@tocnolegy_B_practical", SqlDbType.Float);
            param[11].Value = tocnolegy_B_practical;

            param[12] = new SqlParameter("@nashat_1_B", SqlDbType.Float);
            param[12].Value = nashat_1_B;

            param[13] = new SqlParameter("@nashat_2_B", SqlDbType.Float);
            param[13].Value = nashat_2_B;

            DAL.ExeucuteCommand("SP_Add_Amal_B_7_8_9", param);
        }

        public DataTable Get_Final_Degree(int Grade_Id)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.year_cod;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = Grade_Id;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Final_Degree ", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Count_Final_Degree()
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.year_cod;


            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Count_Final_Degree", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Final_Total_Degree(int Grade_Id,string name = "")
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.year_cod;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = Grade_Id;

            param[2] = new SqlParameter("@Name", SqlDbType.NVarChar,100);
            param[2].Value = name;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Final_Total_Degree ", param);
            DAL.Close();
            return Dt;
        }
        public DataTable Get_Final_All_Data(int Golos)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.year_cod;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = Globals.test_grade_id;

            param[2] = new SqlParameter("@Golos", SqlDbType.Int);
            param[2].Value = Golos;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Final_All_Data ", param);
            DAL.Close();
            return Dt;
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
                                            decimal tocnolegy_practical)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Globals.Std_Golos;

            param[1] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[1].Value =Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@Test_Kind", SqlDbType.Int);
            param[2].Value = Globals.Final_Test_Kind;

            param[3] = new SqlParameter("@arabic", SqlDbType.Float);
            param[3].Value = arabic;

            param[4] = new SqlParameter("@math", SqlDbType.Float);
            param[4].Value = math;

            param[5] = new SqlParameter("@scince", SqlDbType.Float);
            param[5].Value = scince;

            param[6] = new SqlParameter("@scince_practical", SqlDbType.Float);
            param[6].Value = scince_practical;

            param[7] = new SqlParameter("@social", SqlDbType.Float);
            param[7].Value = social;

            param[8] = new SqlParameter("@english", SqlDbType.Float);
            param[8].Value = english;

            param[9] = new SqlParameter("@dain", SqlDbType.Float);
            param[9].Value = dain;

            param[10] = new SqlParameter("@maharat", SqlDbType.Float);
            param[10].Value = maharat;

            param[11] = new SqlParameter("@tocnolegy", SqlDbType.Float);
            param[11].Value = tocnolegy;

            param[12] = new SqlParameter("@tocnolegy_practical", SqlDbType.Float);
            param[12].Value = tocnolegy_practical;

            DAL.ExeucuteCommand("SP_Update_Final_Degree_Data", param);
        }

        public void Update_Final_Absent(
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

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Globals.Std_Golos;

            param[1] = new SqlParameter("@Year_Id", SqlDbType.Int);
            param[1].Value = Properties.Settings.Default.year_cod;

            param[2] = new SqlParameter("@absent_ar_A", SqlDbType.Bit);
            param[2].Value = absent_ar_A;

            param[3] = new SqlParameter("@absent_ar_B", SqlDbType.Bit);
            param[3].Value = absent_ar_B;

            param[4] = new SqlParameter("@absent_math_A", SqlDbType.Bit);
            param[4].Value = absent_math_A;

            param[5] = new SqlParameter("@absent_math_B", SqlDbType.Bit);
            param[5].Value = absent_math_B;

            param[6] = new SqlParameter("@absent_scince_A", SqlDbType.Bit);
            param[6].Value = absent_scince_A;

            param[7] = new SqlParameter("@absent_scince_B", SqlDbType.Bit);
            param[7].Value = absent_scince_B;

            param[8] = new SqlParameter("@absent_social_A", SqlDbType.Bit);
            param[8].Value = absent_social_A;

            param[9] = new SqlParameter("@absent_social_B", SqlDbType.Bit);
            param[9].Value = absent_social_B;

            param[10] = new SqlParameter("@absent_english_A", SqlDbType.Bit);
            param[10].Value = absent_english_A;

            param[11] = new SqlParameter("@absent_english_B", SqlDbType.Bit);
            param[11].Value = absent_english_B;

            param[12] = new SqlParameter("@absent_din_A", SqlDbType.Bit);
            param[12].Value = absent_din_A;

            param[13] = new SqlParameter("@absent_din_B", SqlDbType.Bit);
            param[13].Value = absent_din_B;

            param[14] = new SqlParameter("@absent_maharat_A", SqlDbType.Bit);
            param[14].Value = absent_maharat_A;

            param[15] = new SqlParameter("@absent_maharat_B", SqlDbType.Bit);
            param[15].Value = absent_maharat_B;

            param[16] = new SqlParameter("@absent_tocnolegy_A", SqlDbType.Bit);
            param[16].Value = absent_tocnolegy_A;

            param[17] = new SqlParameter("@absent_tocnolegy_B", SqlDbType.Bit);
            param[17].Value = absent_tocnolegy_B;

            param[18] = new SqlParameter("@absent_term_A", SqlDbType.Bit);
            param[18].Value = absent_term_A;

            param[19] = new SqlParameter("@absent_term_B", SqlDbType.Bit);
            param[19].Value = absent_term_B;

            DAL.ExeucuteCommand("SP_Update_Final_Absent", param);
        }
    }
}
