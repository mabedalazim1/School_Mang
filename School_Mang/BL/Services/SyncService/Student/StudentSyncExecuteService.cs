using School_Mang.BL.Services.SyncService.Models;
using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.SyncService.Student
{
    public class StudentSyncExecuteService
    {

        private readonly StudentSyncTempService _temp;
        private readonly SiteAccessLayer _siteDal;

        public StudentSyncExecuteService()
        {
            _temp = new StudentSyncTempService();
            _siteDal = new SiteAccessLayer();
        }


        public StudentSyncResult Execute()
        {
            // قراءة بيانات التجهيز من قاعدة المدرسة
            DataTable table = _temp.GetAll();


            if (table.Rows.Count == 0)
                return new StudentSyncResult();


            // تنظيف جدول المزامنة في الموقع
            _siteDal.ExecuteNonQuery(
                "TRUNCATE TABLE StudentSync_Temp"
            );


            // إرسال البيانات للموقع
            _siteDal.BulkInsert(
                table,
                "StudentSync_Temp"
            );


            // تنفيذ المزامنة
            DataTable result = _siteDal.ExecQuery(
                "SP_Execute_Student_Sync"
            );


            if (result.Rows.Count == 0)
                return new StudentSyncResult();


            return new StudentSyncResult
            {
                Added = Convert.ToInt32(result.Rows[0]["Added"]),
                Updated = Convert.ToInt32(result.Rows[0]["Updated"]),
                Deleted = Convert.ToInt32(result.Rows[0]["Deleted"])
            };
        }
    }
}
