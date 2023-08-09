using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace School_Mang.BL.LOGIN
{
    class CLS_LOGIN
    {
        BL.MSG msg = new BL.MSG();
        public DataTable Login(string ID, string PWD)
        {
            try
            {
                DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar, 20);
                param[0].Value = ID;
                param[1] = new SqlParameter("@user_password", SqlDbType.NVarChar, 20);
                param[1].Value = PWD;
                DataTable Dt;

                Dt = DAL.Selectdata("SP_LOGIN", param);
                DAL.Close();
                return Dt;

            }catch(Exception e)
            {
                msg.ErrorMesg(e.Message);
                return null;
            }
        }

        public DataTable Change_PassWord(string user_name, string password)
        {
            try
            {
                DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar, 20);
                param[0].Value = user_name;
                param[1] = new SqlParameter("@password ", SqlDbType.NVarChar, 20);
                param[1].Value = password;
                DataTable Dt;

                Dt = DAL.Selectdata("SP_Change_PassWord", param);
                DAL.Close();
                return Dt;

            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
                return null;
            }
        }

    }
}
