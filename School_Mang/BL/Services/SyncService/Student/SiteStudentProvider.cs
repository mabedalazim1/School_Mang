using School_Mang.DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace School_Mang.BL.Services.SyncService.Student
{
    public class SiteStudentProvider
    {
        private readonly SiteAccessLayer _dal;

        public SiteStudentProvider()
        {
            _dal = new SiteAccessLayer();
        }

        public DataTable GetSiteStudents()
        {
            return _dal.ExecQuery(
                "SP_Get_Site_Students");
        }

        public int GetMaxTemporarySeatNo()
        {
            SiteAccessLayer dal = new SiteAccessLayer();

            string sql = @"
                        SELECT ISNULL(MAX(student_Id), 0)
                        FROM students
                        WHERE student_Id >= 100001";

            return dal.ExecuteScalarQuery<int>(sql);
        }

    }
}
