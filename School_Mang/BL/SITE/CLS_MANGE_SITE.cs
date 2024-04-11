using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.SITE
{
    class CLS_MANGE_SITE
    {
        MSG msg = new MSG();

        public DataTable Get_Count_Users_Data()
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Count_Users_Data ", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Users_Data(string fullName, int code = 0)
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@grade_Id", SqlDbType.TinyInt);
            param[0].Value = Convert.ToByte(Globals.test_grade_id);

            param[1] = new SqlParameter("@serach", SqlDbType.NVarChar,3);
            param[1].Value = "yes";

            param[2] = new SqlParameter("@fullName", SqlDbType.NVarChar, 100);
            param[2].Value = fullName;

            param[3] = new SqlParameter("@code", SqlDbType.Int);
            param[3].Value = code;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Users_Data ", param);
            DAL.Close();
            return Dt;
        }


        public DataTable Get_Users_Data(int code)
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@grade_Id", SqlDbType.TinyInt);
            param[0].Value = Convert.ToByte(Globals.test_grade_id);

            param[1] = new SqlParameter("@serach", SqlDbType.NVarChar, 3);
            param[1].Value = "yes";

            param[2] = new SqlParameter("@fullName", SqlDbType.NVarChar, 100);
            param[2].Value = "";

            param[3] = new SqlParameter("@code", SqlDbType.Int);
            param[3].Value = code;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Users_Data ", param);
            DAL.Close();
            return Dt;
        }
        public DataTable Get_Users_Data(byte grade_Id)
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@grade_Id", SqlDbType.TinyInt);
            param[0].Value = grade_Id;

            param[1] = new SqlParameter("@serach", SqlDbType.NVarChar, 3);
            param[1].Value = "no";

            param[2] = new SqlParameter("@fullName", SqlDbType.NVarChar, 100);
            param[2].Value = "";

            param[3] = new SqlParameter("@code", SqlDbType.Int);
            param[3].Value = 0;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Users_Data ", param);
            DAL.Close();
            return Dt;
        }

        public void Update_User_Data(int Golos, string fullName, string firstName, string stdCode)
        {

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@userSchoolId", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@fullName", SqlDbType.NVarChar, 255);
            param[1].Value = fullName;

            param[2] = new SqlParameter("@firstName", SqlDbType.NVarChar,255);
            param[2].Value = firstName;

            param[3] = new SqlParameter("@stdCode", SqlDbType.NVarChar, 50);
            param[3].Value = stdCode;

            DAL.ExeucuteCommand("SP_Update_User_Data", param);
        }

        public void Update_Student_Data(int Golos,
                                        byte grade_Id,
                                        byte class_Id,
                                        byte gender_Id,
                                        byte religion_Id,
                                        string stdCode)
        {

            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@grade_Id", SqlDbType.TinyInt);
            param[1].Value = grade_Id;

            param[2] = new SqlParameter("@class_Id", SqlDbType.TinyInt);
            param[2].Value = class_Id;

            param[3] = new SqlParameter("@gender_Id", SqlDbType.TinyInt);
            param[3].Value = gender_Id;

            param[4] = new SqlParameter("@religion_Id", SqlDbType.TinyInt);
            param[4].Value = religion_Id;

            param[5] = new SqlParameter("@stdCode", SqlDbType.NVarChar,50);
            param[5].Value = stdCode;

            DAL.ExeucuteCommand("SP_Update_Student_Data", param);
        }

        public DataTable Get_User_Code(int Golos = 0)
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            Dt = DAL.Selectdata("SP_Get_User_Code ", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Verify_UserSchoolId(int userSchoolId)
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@userSchoolId", SqlDbType.Int);
            param[0].Value = userSchoolId; 

            Dt = DAL.Selectdata("SP_Verify_UserSchoolId", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Verify_Username(string username)
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@username", SqlDbType.NVarChar,255);
            param[0].Value = username;

            Dt = DAL.Selectdata("SP_Verify_Username", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Verify_Std_Degrees(int student_Id)
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@student_Id", SqlDbType.NVarChar, 255);
            param[0].Value = student_Id;

            Dt = DAL.Selectdata("SP_Verify_Std_Degrees", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Verify_Std_Marks(int student_Id)
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
            param[0].Value = student_Id;

            Dt = DAL.Selectdata("SP_Verify_Std_Marks", param);
            DAL.Close();
            return Dt;
        }
        public void Add_User_Data(string username,
                                  string password,
                                  int roleId)
        {
            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@username", SqlDbType.NVarChar,255);
            param[0].Value = username;

            param[1] = new SqlParameter("@password", SqlDbType.NVarChar, 255);
            param[1].Value = password;

            param[2] = new SqlParameter("@firstName", SqlDbType.NVarChar, 255);
            string user_first_name = char.ToUpper(username.First()) + username.Substring(1).ToLower();
            param[2].Value = user_first_name;

            param[3] = new SqlParameter("@fullName", SqlDbType.NVarChar, 255);
            param[3].Value = "";

            param[4] = new SqlParameter("@userSchoolId", SqlDbType.Int);
            param[4].Value = 0;

            param[5] = new SqlParameter("@roleId", SqlDbType.Int);
            param[5].Value = roleId;

            param[6] = new SqlParameter("@class_Id", SqlDbType.Int);
            param[6].Value = 0;

            param[7] = new SqlParameter("@gender_Id", SqlDbType.Int);
            param[7].Value = 0;

            param[8] = new SqlParameter("@religion_Id", SqlDbType.Int);
            param[8].Value = 0;

            param[9] = new SqlParameter("@grade_Id", SqlDbType.Int);
            param[9].Value = 0;

            DAL.Open();
            DAL.ExeucuteCommand("SP_Add_User_Data", param);
            DAL.Close();
        }

        public void Add_User_Data(string username,
                                 string password,
                                 string firstName,
                                 string fullName,
                                 int userSchoolId,
                                 int roleId,
                                 int class_Id,
                                 int gender_Id,
                                 int religion_Id,
                                 int grade_Id,
                                 string stdCode)
        {
            SiteAccessLayer DAL = new SiteAccessLayer();

            SqlParameter[] param = new SqlParameter[11];

            param[0] = new SqlParameter("@username", SqlDbType.NVarChar, 255);
            param[0].Value = username;

            param[1] = new SqlParameter("@password", SqlDbType.NVarChar, 255);
            param[1].Value = password;

            param[2] = new SqlParameter("@firstName", SqlDbType.NVarChar, 255);
            param[2].Value = firstName;

            param[3] = new SqlParameter("@fullName", SqlDbType.NVarChar, 255);
            param[3].Value = fullName;

            param[4] = new SqlParameter("@userSchoolId", SqlDbType.Int);
            param[4].Value = userSchoolId;

            param[5] = new SqlParameter("@roleId", SqlDbType.Int);
            param[5].Value = roleId;

            param[6] = new SqlParameter("@class_Id", SqlDbType.Int);
            param[6].Value = class_Id;

            param[7] = new SqlParameter("@gender_Id", SqlDbType.Int);
            param[7].Value = gender_Id;

            param[8] = new SqlParameter("@religion_Id", SqlDbType.Int);
            param[8].Value = religion_Id;

            param[9] = new SqlParameter("@grade_Id", SqlDbType.Int);
            param[9].Value = grade_Id;

            param[10] = new SqlParameter("@stdCode", SqlDbType.NVarChar,50);
            param[10].Value = stdCode;
            DAL.Open();
            DAL.ExeucuteCommand("SP_Add_User_Data", param);
            DAL.Close();
        }

        public void Update_User_stdCode(string stdCode, int Golos )
                               
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@stdCode", SqlDbType.NVarChar, 50);
            param[0].Value = stdCode;

            param[1] = new SqlParameter("@userSchoolId", SqlDbType.Int);
            param[1].Value = Golos;


            DAL.Open();
            DAL.ExeucuteCommand("SP_Update_User_stdCode", param);
            DAL.Close();
        }

        public DataTable Get_User_Table_Data()
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            DataTable Dt;

            string query = @"select * from users;";
            Dt = DAL.ReadData_Query(query, null);
            DAL.Close();
            return Dt;

        }
    }
}
