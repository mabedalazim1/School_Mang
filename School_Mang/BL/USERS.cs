using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace School_Mang.BL

{
    class USERS
    {
      

        public DataTable Get_Users()
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;
            Dt = DAL.Selectdata("SP_Get_Users_Data", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_User_img(int Id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = Id;

            Dt = DAL.Selectdata("SP_Get_User_Img", param);
            DAL.Close();
            return Dt;
        }

        public void Update_User_Img(int Id, byte[] IMEGE)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = Id;

            param[1] = new SqlParameter("@user_img", SqlDbType.VarBinary, int.MaxValue);
            param[1].Value = IMEGE;

            DAL.Open();
            DAL.ExeucuteCommand("SP_Add_Users_Img", param);
            DAL.Close();
        }

        public DataTable Search_User_Data(string osra_data)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@user_data", SqlDbType.NVarChar, 50);
            param[0].Value = osra_data;

            Dt = DAL.Selectdata("SP_Search_User_Data", param);
            DAL.Close();
            return Dt;
        }

        public void Add_Users_Data(string user_name , string user_password,
                                   int role_id, int permission_id,
                                   int role_id_2, int role_id_3,
                                   int role_id_4, int role_id_5)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar,20);
            param[0].Value = user_name;

            param[1] = new SqlParameter("@user_password", SqlDbType.NVarChar, 20);
            param[1].Value = user_password;

            param[2] = new SqlParameter("@role_id", SqlDbType.Int);
            param[2].Value = role_id;

            param[3] = new SqlParameter("@permission_id", SqlDbType.Int);
            param[3].Value = permission_id;

            param[4] = new SqlParameter("@role_id_2", SqlDbType.Int);
            param[4].Value = role_id_2;

            param[5] = new SqlParameter("@role_id_3", SqlDbType.Int);
            param[5].Value = role_id_3;

            param[6] = new SqlParameter("@role_id_4", SqlDbType.Int);
            param[6].Value = role_id_4;

            param[7] = new SqlParameter("@role_id_5", SqlDbType.Int);
            param[7].Value = role_id_5;

            DAL.Open();
            DAL.ExeucuteCommand("SP_Add_Users", param);
            DAL.Close();
        }

        public void Delete_User_Permissions(int Role_Permissions_id, int User_Role_id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@Role_Permissions_id", SqlDbType.Int);
            param[0].Value = Role_Permissions_id;

            param[1] = new SqlParameter("@User_Role_id", SqlDbType.Int);
            param[1].Value = User_Role_id;

            DAL.Open();
            DAL.ExeucuteCommand("SP_Delete_User_Permissions", param);
            DAL.Close();
        }


        public void Delete_User(int user_id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = user_id;

            
            DAL.Open();
            DAL.ExeucuteCommand("SP_Delete_User", param);
            DAL.Close();
        }
        public DataTable Get_User_Permission(int user_id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            DataTable Dt;
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = user_id;

            Dt = DAL.Selectdata("SP_Get_User_Permission", param);
            DAL.Close();
            return Dt;
        }
        public void Update_User_Permission(int role,
                                          int id_role,
                                          int permission,
                                          int id_permission)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@role", SqlDbType.Int);
            param[0].Value = role;

            param[1] = new SqlParameter("@id_role", SqlDbType.Int);
            param[1].Value = id_role;

            param[2] = new SqlParameter("@permission", SqlDbType.Int);
            param[2].Value = permission;

            param[3] = new SqlParameter("@id_permission", SqlDbType.Int);
            param[3].Value = id_permission;


            DAL.ExeucuteCommand("SP_Update_User_Permission", param);
        }

        public void Add_User_Permission( int user_id,
                                         int role_id,
                                         int permission_id)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@user_id", SqlDbType.Int);
            param[0].Value = user_id;

            param[1] = new SqlParameter("@role_id", SqlDbType.Int);
            param[1].Value = role_id;

            param[2] = new SqlParameter("@permission_id", SqlDbType.Int);
            param[2].Value = permission_id;

            DAL.ExeucuteCommand("SP_Add_User_Permission", param);
        }

        // Read Year data From databasse

        public DataTable Get_Year_data()
        {
            string Query = "Select * from App_Data;";
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            DataTable Dt;

            Dt = DAL.ReadData_Query(Query, null);
            DAL.Close();
            return Dt;

        }

        // Update Year Data
        public void Update_Year_Data(int year_id ,int MyYear, string Year_Desc)
        {
            string Query = "UPDATE App_Data SET Year_cod =" + year_id 
               + ",MyYear =" + MyYear
                + ",Year_Desc ='" + Year_Desc + "';";
            
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            DAL.Update_Data_Query(Query, null);
        }

    }

}
