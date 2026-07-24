using School_Mang.DAL;
using System.Data.SqlClient;

namespace School_Mang.BL.Services.SyncService.Degree
{
    public class DegreeArchiveService
    {
        private readonly SiteAccessLayer _dal = new SiteAccessLayer();

        public void Archive(int yearId)
        {
            _dal.ExecNonQuery(
                 "SP_Archive_Degrees",
                 _dal.Param("@Year_Id", yearId)
            );
        }
    }
}
