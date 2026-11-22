using School_Mang.BL;
using School_Mang.DAL;
using System.Data;

namespace School_Mang.BL.Services.Nateg
{
    public class RasdService
    {
        private readonly DataAcceseLayer DAL =
            new DataAcceseLayer();

        public DataTable GetRasdData(int gradeId, int status = 0)
        {
            return DAL.ExecQuery(
                "SP_Get_Rasd_Data",
                SqlParam.Int("@year_id", Properties.Settings.Default.year_cod),
                SqlParam.Int("@Grade_Id", gradeId),
                SqlParam.Int("@status", status)
            );
        }
    }
}