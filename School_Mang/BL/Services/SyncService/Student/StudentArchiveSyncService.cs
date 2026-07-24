using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.SyncService.Student
{
    public class StudentArchiveSyncService
    {
        private readonly SchoolStudentProvider _schoolProvider = new SchoolStudentProvider();
        private readonly StudentArchiveProvider _archiveProvider = new StudentArchiveProvider();
        private readonly SiteAccessLayer _siteDal = new SiteAccessLayer();


        public event Action<int, string> ProgressChanged;

        private void ReportProgress(int value, string message)
        {
            ProgressChanged?.Invoke(value, message);
        }

        public void Sync(int yearId)
        {
            // 1- قراءة الطلاب الحاليين
            ReportProgress(2, "جاري قراءة بيانات الطلاب...");
            DataTable students = _schoolProvider.GetArchiveStudents(yearId);

            // التحقق من صحة البيانات
            ReportProgress(5, "جاري التحقق من البيانات...");
            if (!ValidateStudents(students))
                return;

            // 2- قراءة طلاب الأرشيف
            ReportProgress(8, "جاري قراءة بيانات الأرشيف...");
            DataTable archive = _archiveProvider.GetStudents(yearId);

            // 3- استخراج الطلاب غير الموجودين بالأرشيف
            ReportProgress(12, "جاري مقارنة البيانات...");
            DataTable newStudents = GetNewStudents(students, archive);

            if (newStudents.Rows.Count == 0) 
            {
                ReportProgress(20, "لا توجد بيانات جديدة للأرشفة.");
                return;
            }


            // 4- تحويل البيانات إلى شكل جدول الأرشيف
            ReportProgress(16, "جاري تجهيز البيانات...");
            newStudents = ConvertToArchiveTable(newStudents, yearId);

            // 5- حفظهم فى الأرشيف
            ReportProgress(18, "جاري حفظ البيانات...");
            _siteDal.BulkInsert(newStudents, "students_archive");
            ReportProgress(20, "تمت أرشفة الطلاب بنجاح.");
        }

        /// <summary>
        /// التحقق من أن جميع الطلاب لهم رقم جلوس.
        /// </summary>
        private bool ValidateStudents(DataTable students)
        {
            var invalidStudents = students.AsEnumerable()
                .Where(r => r.IsNull("student_Id"))
                .ToList();

            if (!invalidStudents.Any())
                return true;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("لا يمكن متابعة أرشفة الطلاب.");
            sb.AppendLine();
            sb.AppendLine($"عدد الطلاب الذين ليس لهم رقم جلوس: {invalidStudents.Count}");
            sb.AppendLine();
            sb.AppendLine("الطلاب:");
            sb.AppendLine();

            foreach (var row in invalidStudents)
            {
                sb.AppendLine($"• {row["std_fullName"]} (الكود: {row["stdCode"]})");
            }

            MSG.MyMesg(sb.ToString());

            return false;
        }

        private DataTable GetNewStudents(DataTable students, DataTable archive)
        {
            HashSet<string> archiveCodes = archive.AsEnumerable()
                .Select(r => r.Field<string>("stdCode"))
                .Where(code => !string.IsNullOrWhiteSpace(code))
                .ToHashSet();

            DataTable newStudents = students.Clone();

            foreach (DataRow row in students.Rows)
            {
                string stdCode = row["stdCode"].ToString();

                if (!archiveCodes.Contains(stdCode))
                {
                    newStudents.ImportRow(row);
                }
            }

            return newStudents;
        }

        private DataTable ConvertToArchiveTable(DataTable students, int yearId)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Year_Id", typeof(int));
            table.Columns.Add("student_Id", typeof(int));
            table.Columns.Add("class_Id", typeof(int));
            table.Columns.Add("gender_Id", typeof(int));
            table.Columns.Add("religion_Id", typeof(int));
            table.Columns.Add("grade_Id", typeof(int));
            table.Columns.Add("stdCode", typeof(string));
            table.Columns.Add("osraId", typeof(string));
            table.Columns.Add("std_firstName", typeof(string));
            table.Columns.Add("std_fullName", typeof(string));

            foreach (DataRow row in students.Rows)
            {
                DataRow newRow = table.NewRow();

                newRow["Year_Id"] = yearId;
                newRow["student_Id"] = row["student_Id"];
                newRow["class_Id"] = row["class_Id"];
                newRow["gender_Id"] = row["gender_Id"];
                newRow["religion_Id"] = row["religion_Id"];
                newRow["grade_Id"] = row["grade_Id"];
                newRow["stdCode"] = row["stdCode"];
                newRow["osraId"] = row["osraId"];
                newRow["std_firstName"] = row["std_firstName"];
                newRow["std_fullName"] = row["std_fullName"];

                table.Rows.Add(newRow);
            }

            return table;
        }

        public bool HasArchive(int yearId)
        {
            int count = _siteDal.ExecuteScalarQuery<int>(
                @"SELECT COUNT(*)
                FROM students_archive
                WHERE Year_Id = @Year_Id",
                _siteDal.Param("@Year_Id", yearId)
            );

            return count > 0;
        }
    }
}
