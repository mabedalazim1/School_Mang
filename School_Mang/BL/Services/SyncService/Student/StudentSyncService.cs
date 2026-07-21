using School_Mang.BL.Common.Helper;
using School_Mang.BL.Enums;
using School_Mang.BL.Services.SyncService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace School_Mang.BL.Services.SyncService.Student
{
    public class StudentSyncService
    {
        public event Action<int, int, string> ProgressChanged;

        private readonly SyncProcessService _syncProcess;
        private readonly StudentMapper _mapper;
        private readonly SchoolStudentProvider _schoolProvider;
        private readonly SiteStudentProvider _siteProvider;
        private readonly StudentSyncTempService _tempService;

        public StudentSyncService()
        {
            _schoolProvider = new SchoolStudentProvider();
            _siteProvider = new SiteStudentProvider();
            _mapper = new StudentMapper();
            _syncProcess = new SyncProcessService();
            _tempService = new StudentSyncTempService();
        }

        private void ReportProgress(int current, int total, string message)
        {
            ProgressChanged?.Invoke(current, total, message);
        }

        public StudentSyncResult PrepareSync(int yearId)
        {
            ReportProgress(20, 100, "بدء تجهيز الطلاب");


            DataTable schoolTable = _schoolProvider.GetCurrentStudents(yearId);

            var schoolStudents = _mapper.MapSchoolStudents(schoolTable);

            ReportProgress(30, 100, "جاري قراءة بيانات الطلاب من المدرسة");


            // قائمة أكواد طلاب المدرسة للمقارنة مع الموقع
            var schoolCodes = schoolStudents
                .Select(x => x.StdCode)
                .ToHashSet();


            DataTable siteTable = _siteProvider.GetSiteStudents();

            var siteStudents = _mapper.MapSiteStudents(siteTable);

            ReportProgress(45, 100, "جاري قراءة بيانات الطلاب من الموقع");

            var resolver = new StudentActionResolver(siteStudents);

            var result = new StudentSyncResult();


            ReportProgress(65, 100, "جاري مقارنة بيانات الطلاب");


            // تحديد الإضافة والتحديث
            foreach (var student in schoolStudents)
            {
                student.Action_Id = resolver.Resolve(student.StdCode);

                if (student.Action_Id == StudentSyncAction.Update)
                {
                    // الاحتفاظ برقم الجلوس الموجود بالموقع
                    student.SeatNo = resolver.GetSeatNo(student.StdCode);

                    result.Updated++;
                }
                else
                {
                    // الطالب الجديد سيأخذ رقمًا مؤقتًا لاحقًا
                    result.Added++;
                }
            }


            ReportProgress(80, 100, "جاري تحديد الطلاب المحذوفين");


            // تحديد الطلاب الموجودين في الموقع وغير الموجودين في المدرسة
            foreach (DataRow row in siteTable.Rows)
            {
                string stdCode = SafeConverter.GetString(row["StdCode"]);

                if (!schoolCodes.Contains(stdCode))
                {
                    schoolStudents.Add(new StudentSyncTemp
                    {
                        StdCode = stdCode,
                        Action_Id = StudentSyncAction.Delete
                    });

                    result.Deleted++;
                }
            }


            ReportProgress(95, 100, "جاري حفظ بيانات التجهيز");

            FixEmptySeatNumbers(schoolStudents);

            _tempService.Clear();

            _tempService.Save(schoolStudents);


            _syncProcess.SetPrepared("Student");


            ReportProgress(100, 100, "تم تجهيز بيانات الطلاب");


            return result;
        }

        private void FixEmptySeatNumbers(List<StudentSyncTemp> students)
        {
            int nextSeatNo = 100001;

            foreach (var student in students)
            {
                if (student.SeatNo <= 0)
                {
                    student.SeatNo = nextSeatNo;
                    nextSeatNo++;
                }
            }
        }
    }
}
