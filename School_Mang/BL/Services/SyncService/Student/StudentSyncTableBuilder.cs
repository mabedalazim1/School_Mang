using System.Data;

namespace School_Mang.BL.Services.SyncService.Student
{
    public class StudentSyncTableBuilder
    {
        public DataTable Build(DataTable source)
        {
            DataTable table = new DataTable();

            table.Columns.Add("student_Id", typeof(int));
            table.Columns.Add("class_Id", typeof(int));
            table.Columns.Add("gender_Id", typeof(int));
            table.Columns.Add("religion_Id", typeof(int));
            table.Columns.Add("grade_Id", typeof(int));
            table.Columns.Add("stdCode", typeof(string));
            table.Columns.Add("osraId", typeof(int));
            table.Columns.Add("std_firstName", typeof(string));
            table.Columns.Add("std_fullName", typeof(string));


            foreach (DataRow row in source.Rows)
            {
                table.Rows.Add(
                    row["SeatNo"],
                    row["Class_Id"],
                    row["Gender_Id"],
                    row["Religion_Id"],
                    row["Grade_Id"],
                    row["StdCode"],
                    row["OsraId"],
                    row["FirstName"],
                    row["FullName"]
                );
            }


            return table;
        }
    }
}
