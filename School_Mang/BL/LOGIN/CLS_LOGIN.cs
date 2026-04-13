using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using School_Mang.BL.Common.Helper;

namespace School_Mang.BL.LOGIN
{
    class CLS_LOGIN
    {
        private MSG msg = new MSG();
        private DAL.DataAcceseLayer DAL  = new DAL.DataAcceseLayer();

        public DataTable Login(string ID, string PWD)
        {
            try
            {
               return DAL.ExecQuery("SP_LOGIN",
                    SqlParam.NVar("@user_name", ID,20),
                    SqlParam.NVar("@user_password", PWD, 20)
               );

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
                return DAL.ExecQuery("SP_Change_PassWord",
                     SqlParam.NVar("@user_name", user_name, 20),
                     SqlParam.NVar("@user_password", password, 20)
                );
                
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
                return null;
            }
        }

    }
}
