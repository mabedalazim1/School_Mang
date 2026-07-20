using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.SyncService.Student
{
    public class StudentArchiveProvider
    {
        private readonly SiteAccessLayer _dal = new SiteAccessLayer();

        public DataTable GetStudents(int yearId)
        {
            return _dal.ExecQuery(
                "SP_Get_Archive_Students",
                new SqlParameter("@Year_Id", yearId)
            );
        }
    }
}
