using School_Mang.BL.STD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services
{
    public class StudentDataMigrationService
    {
        private readonly CLS_STD std = new CLS_STD();

        public void PromoteYear()
        {

            int currentYear = Properties.Settings.Default.year_cod;
            int newYear = currentYear + 1;
            DataTable dt = std.Get_School_year_Data(currentYear, 0, 0);

            if (dt.Rows.Count == 0)
                throw new Exception("لا يوجد بيانات مسجلة لهذا العام");

            foreach (DataRow row in dt.Rows)
            {
                string std_code = row["std_code"].ToString();
                int grade = Convert.ToInt32(row["Grade_Id"]);
                int class_id = Convert.ToInt32(row["Class_Id"]);
                int status = Convert.ToInt32(row["Std_Status_Id"]);

                GetNextValues(
                    grade,
                    class_id,
                    out int newGrade,
                    out int newClassId
                );

                var exists = std.Verify_Std_School_Code(std_code, newYear);

                if (exists.Rows.Count > 0)
                {
                    HandleExistingStudent(std_code, newYear, newGrade, newClassId, status);
                }
                else
                {
                    AddNewStudent(std_code, newYear, newGrade, newClassId, status);
                }
            }
        }

        private void GetNextValues(int grade, int classId, out int newGrade, out int newClassId)
        {
            newGrade = 0;
            newClassId = 0;

            switch (grade)
            {
                case 10:
                    newGrade = 11;
                    newClassId = classId + 2;
                    break;

                case 11:
                    newGrade = 1;
                    newClassId = classId + 2;
                    break;

                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    newGrade = grade + 1;
                    newClassId = classId + 3;
                    break;

                case 6:
                    newGrade = 7;
                    newClassId = (classId == 20) ? 23 : 24;
                    break;

                case 7:
                case 8:
                    newGrade = grade + 1;
                    newClassId = classId + 2;
                    break;

                case 9:
                    newGrade = 0;
                    break;

                default:
                    newGrade = 0;
                    break;
            }
        }

        private void HandleExistingStudent(string std_code, int newYear, int newGrade, int newClassId, int status)
        {
            if (status == 3 || status == 6 || newGrade == 0)
            {
                std.Delete_School_Std_Data(std_code, newYear);
            }
            else
            {
                std.Update_New_School_Std(
                    std_code,
                    newGrade,
                    2,
                    newClassId,
                    newYear
                );
            }
        }

        private void AddNewStudent(string std_code, int newYear, int newGrade, int newClassId, int status)
        {
            if (newGrade == 0 || status == 3 || status == 6)
                return;

            std.Add_School_Std_Data(
                std_code,
                newYear,
                newGrade,
                2,
                newClassId
            );
        }
    }
}
