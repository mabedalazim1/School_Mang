using School_Mang.BL.Common.Helper;
using System.Collections.Generic;
using System.Data;
using School_Mang.BL.Services.SyncService.Models;

namespace School_Mang.BL.Services.SyncService.Student
{
    public class StudentMapper
    {
        public List<StudentSyncTemp> MapSchoolStudents(DataTable table)
        {
            var result = new List<StudentSyncTemp>();

            foreach (DataRow row in table.Rows)
            {
                result.Add(new StudentSyncTemp
                {
                    SeatNo = SafeConverter.GetInt(row["SeatNo"]),
                    StdCode = SafeConverter.GetString(row["StdCode"]),
                    OsraId = SafeConverter.GetInt(row["OsraId"]),
                    FirstName = SafeConverter.GetString(row["FirstName"]),
                    FullName = SafeConverter.GetString(row["FullName"]),
                    Grade_Id = SafeConverter.GetInt(row["Grade_Id"]),
                    Class_Id = SafeConverter.GetInt(row["Class_Id"]),
                    Gender_Id = SafeConverter.GetInt(row["Gender_Id"]),
                    Religion_Id = SafeConverter.GetInt(row["Religion_Id"])
                });
            }

            return result;
        }

        public Dictionary<string, int> MapSiteStudents(DataTable table)
        {
            var result = new Dictionary<string, int>();

            foreach (DataRow row in table.Rows)
            {
                string stdCode = SafeConverter.GetString(row["StdCode"]);
                int seatNo = SafeConverter.GetInt(row["student_Id"]);

                result[stdCode] = seatNo;
            }

            return result;
        }
    }
}
