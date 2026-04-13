using System;
using System.Data;
using System.Data.SqlClient;

namespace School_Mang.BL
{
    class USERS
    {
        private readonly DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

        // ======================
        // GET USERS
        // ======================
        public DataTable Get_Users()
        {
            return DAL.ExecQuery("SP_Get_Users_Data");
        }

        // ======================
        // GET USER IMAGE
        // ======================
        public DataTable Get_User_img(int Id)
        {
            return DAL.ExecQuery("SP_Get_User_Img",
                SqlParam.Int("@user_id", Id));
        }

        // ======================
        // UPDATE IMAGE
        // ======================
        public void Update_User_Img(int Id, byte[] image)
        {
            DAL.ExecNonQuery("SP_Add_Users_Img",
                SqlParam.Int("@user_id", Id),
                new SqlParameter("@user_img", SqlDbType.VarBinary, int.MaxValue)
                {
                    Value = image ?? (object)DBNull.Value
                }
            );
        }

        // ======================
        // SEARCH USERS
        // ======================
        public DataTable Search_User_Data(string osra_data)
        {
            return DAL.ExecQuery("SP_Search_User_Data",
                SqlParam.NVar("@user_data", osra_data, 50));
        }

        // ======================
        // ADD USER
        // ======================
        public void Add_Users_Data(
            string user_name,
            string user_password,
            int role_id,
            int permission_id,
            int role_id_2,
            int role_id_3,
            int role_id_4,
            int role_id_5)
        {
            DAL.ExecNonQuery("SP_Add_Users",
                SqlParam.NVar("@user_name", user_name, 20),
                SqlParam.NVar("@user_password", user_password, 20),
                SqlParam.Int("@role_id", role_id),
                SqlParam.Int("@permission_id", permission_id),
                SqlParam.Int("@role_id_2", role_id_2),
                SqlParam.Int("@role_id_3", role_id_3),
                SqlParam.Int("@role_id_4", role_id_4),
                SqlParam.Int("@role_id_5", role_id_5)
            );
        }

        // ======================
        // DELETE USER PERMISSION
        // ======================
        public void Delete_User_Permissions(int Role_Permissions_id, int User_Role_id)
        {
            DAL.ExecNonQuery("SP_Delete_User_Permissions",
                SqlParam.Int("@Role_Permissions_id", Role_Permissions_id),
                SqlParam.Int("@User_Role_id", User_Role_id)
            );
        }

        // ======================
        // DELETE USER
        // ======================
        public void Delete_User(int user_id)
        {
            DAL.ExecNonQuery("SP_Delete_User",
                SqlParam.Int("@user_id", user_id)
            );
        }

        // ======================
        // GET USER PERMISSION
        // ======================
        public DataTable Get_User_Permission(int user_id)
        {
            return DAL.ExecQuery("SP_Get_User_Permission",
                SqlParam.Int("@user_id", user_id));
        }

        // ======================
        // UPDATE USER PERMISSION
        // ======================
        public void Update_User_Permission(
            int role,
            int id_role,
            int permission,
            int id_permission)
        {
            DAL.ExecNonQuery("SP_Update_User_Permission",
                SqlParam.Int("@role", role),
                SqlParam.Int("@id_role", id_role),
                SqlParam.Int("@permission", permission),
                SqlParam.Int("@id_permission", id_permission)
            );
        }

        // ======================
        // ADD USER PERMISSION
        // ======================
        public void Add_User_Permission(
            int user_id,
            int role_id,
            int permission_id)
        {
            DAL.ExecNonQuery("SP_Add_User_Permission",
                SqlParam.Int("@user_id", user_id),
                SqlParam.Int("@role_id", role_id),
                SqlParam.Int("@permission_id", permission_id)
            );
        }

        // ======================
        // YEAR DATA (TABLE)
        // ======================
        public DataTable Get_Year_data()
        {
            return DAL.Query("SELECT * FROM App_Data");
        }

        // ======================
        // UPDATE YEAR DATA
        // ======================
        public void Update_Year_Data(int year_id, int MyYear, string Year_Desc)
        {
            DAL.ExecuteQuery(
                "UPDATE App_Data SET Year_cod = @year_id, MyYear = @MyYear, Year_Desc = @desc",
                SqlParam.Int("@year_id", year_id),
                SqlParam.Int("@MyYear", MyYear),
                SqlParam.NVar("@desc", Year_Desc, 100)
            );
        }
    }
}