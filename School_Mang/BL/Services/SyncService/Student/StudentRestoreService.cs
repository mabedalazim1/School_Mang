using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.SyncService.Student
{
    public class StudentRestoreService
    {
        private readonly SiteAccessLayer _dal;

        public StudentRestoreService()
        {
            _dal = new SiteAccessLayer();
        }

        public bool HasArchive(int yearId)
        {
            DataTable dt = _dal.ExecQuery(
                "SP_Has_Students_Archive",
                _dal.Param("@Year_Id", yearId)
            );

            return dt.Rows.Count > 0 &&
                   (bool)dt.Rows[0]["HasArchive"];
        }

        public void Restore(int yearId)
        {
            _dal.ExecNonQuery(
                "SP_Restore_Year_From_Archive",
                _dal.Param("@Year_Id", yearId)
            );
        }
    }
}
