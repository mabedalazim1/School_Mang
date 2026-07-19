using School_Mang.DAL;
using System.Data;

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
    }
}
