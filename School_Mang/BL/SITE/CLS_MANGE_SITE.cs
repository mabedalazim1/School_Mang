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

        public DataTable Get_Users_Data(byte grade_Id)
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@grade_Id", SqlDbType.TinyInt);
            param[0].Value = grade_Id;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Users_Data ", param);
            DAL.Close();
            return Dt;
        }
    }
}
