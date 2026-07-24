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

        public event Action<int, int, string> ProgressChanged;

        private void ReportProgress(int current, int total, string message)
        {
            ProgressChanged?.Invoke(current, total, message);
        }

        public StudentSyncResult Execute(int archivedYearId = 0, bool finalSync = false)
        {
            // قراءة بيانات التجهيز من قاعدة المدرسة
            ReportProgress(10, 100, "جاري قراءة بيانات تجهيز الطلاب");
            DataTable table = _temp.GetAll();


            if (table.Rows.Count == 0)
                return new StudentSyncResult();


            // تنظيف جدول المزامنة في الموقع
            ReportProgress(30, 100, "جاري تنظيف جدول المزامنة بالموقع");
            _siteDal.Query(
                "TRUNCATE TABLE StudentSync_Temp"
            );


            // إرسال البيانات للموقع
            ReportProgress(50, 100, "جاري رفع بيانات الطلاب للموقع");
            _siteDal.BulkInsert(
                table,
                "StudentSync_Temp"
            );


            // تنفيذ المزامنة
            ReportProgress(75, 100, "جاري تنفيذ تحديث الطلاب");
            DataTable result = _siteDal.ExecQuery(
                "SP_Execute_Student_Sync",
                _siteDal.Param("@YearId", archivedYearId),
                _siteDal.Param("@FinalSync", finalSync)
            );

            ReportProgress(100, 100, "تم تنفيذ مزامنة الطلاب");
            if (result.Rows.Count == 0)
                return new StudentSyncResult();


            return new StudentSyncResult
            {
                Added = Convert.ToInt32(result.Rows[0]["Added"]),
                Updated = Convert.ToInt32(result.Rows[0]["Updated"]),
                Deleted = Convert.ToInt32(result.Rows[0]["Deleted"]),
            };
        }
    }
}
