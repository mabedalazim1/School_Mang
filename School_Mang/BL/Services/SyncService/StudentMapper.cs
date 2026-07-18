using School_Mang.BL.Common.Helper;
using System.Collections.Generic;
using System.Data;

namespace School_Mang.BL.Services.SyncService
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

        public HashSet<string> MapSiteStudents(DataTable table)
        {
            var result = new HashSet<string>();

            foreach (DataRow row in table.Rows)
            {
                result.Add(SafeConverter.GetString(row["StdCode"]));
            }

            return result;
        }
    }
}
