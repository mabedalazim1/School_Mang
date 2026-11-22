using School_Mang.BL;
using School_Mang.DAL;
using System;
using System.Data;

namespace School_Mang.BL.Services.Nateg
{
    public class GolosService
    {
        private readonly DataAcceseLayer DAL =
           new DataAcceseLayer();
        public DataTable GetGolosSum(int gradeId, string status = "")
        {
            return DAL.ExecQuery(
                "SP_Get_Golos_Sum",
                SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Int("@Grade_Id", gradeId),
                SqlParam.NVar("@status", status, 5)
            );
        }

        public DataTable GetGolosData(int gradeId)
        {
            return DAL.ExecQuery(
                "SP_Get_Golos_Data",
                SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Int("@Grade_Id", gradeId)
            );
        }

        public void UpdateGolosData(int stdCode, int golos)
        {
            DAL.ExecNonQuery(
                "SP_Update_Golos_Data",
                SqlParam.Int("@year_Id", Properties.Settings.Default.year_cod),
                SqlParam.Int("@std_code", stdCode),
                SqlParam.Int("@Golos", golos)
            );
        }

        public void UpdateGolosNumbers(int gradeId, int startingGolos)
        {
            DataTable students = GetGolosData(gradeId);

            foreach (DataRow row in students.Rows)
            {
                int stdCode = Convert.ToInt32(row["std_code"]);

                UpdateGolosData(stdCode, startingGolos);

                startingGolos++;
            }
        }
    }
}