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

        public DataTable Get_Test_Month()
        {
            DataAcceseLayer DAL = new DataAcceseLayer();
            DataTable Dt;
            Dt = DAL.Selectdata("SP_GET_TEST_MONTHS", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Rasd_Data(int grade_id)
        {

            DataAcceseLayer DAL = new DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@year_id", SqlDbType.Int);
            param[0].Value = Properties.Settings.Default.year_cod;

            param[1] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[1].Value = grade_id;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Rasd_Data", param);
            DAL.Close();
            return Dt;
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

        public DataTable Get_Mark_Data(int test_kind_Id, int grade_Id)
        {

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@test_kind_Id", SqlDbType.Int);
            param[0].Value = test_kind_Id;


            param[1] = new SqlParameter("@grade_Id", SqlDbType.Int);
            param[1].Value = grade_Id;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Mark_Data", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Degree_Data(int test_kind_Id, int grade_Id)
        {

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@test_kind_Id", SqlDbType.Int);
            param[0].Value = test_kind_Id;


            param[1] = new SqlParameter("@grade_Id", SqlDbType.Int);
            param[1].Value = grade_Id;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Degree_Data", param);
            DAL.Close();
            return Dt;
        }
    }
}
