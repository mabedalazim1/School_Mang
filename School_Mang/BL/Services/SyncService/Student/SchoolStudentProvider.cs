using School_Mang.DAL;
using System.Data;

namespace School_Mang.BL.Services.SyncService.Student
{
    public class SchoolStudentProvider
    {
        private readonly DataAcceseLayer _dal;

        public SchoolStudentProvider()
        {
            _dal = new DataAcceseLayer();
        }

        public DataTable GetCurrentStudents(int yearId)
        {
            return _dal.ExecQuery(
                "SP_Get_Students_For_Sync",
                SqlParam.Int("@YearId", yearId));
        }
    }
}
