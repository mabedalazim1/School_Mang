using School_Mang.BL.Common;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.STD;
using School_Mang.DAL;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.STD
{
    public class StudentDataService
    {
        private readonly TestConcation _testConcation;
        private readonly DataAcceseLayer _dal;
        private readonly OsraDataService _osra;

        public StudentDataService()
        {
            _testConcation = new TestConcation();
            _dal = new DataAcceseLayer();
            _osra = new OsraDataService();
        }
        private ServiceResult CheckConnection()
        {
            if (!_testConcation.IsServerConnected())
                return ServiceResult.Fail(ServiceMessages.ServerConnectionFailed);

            return ServiceResult.Ok();
        }

        public ServiceResult<DataTable> GetStudentsData(int year = 0)
        {
            var connection = CheckConnection();

            if (!connection.Success)
                return ServiceResult<DataTable>.Fail(connection.Message);

            var dt = Get_All_Std_Data(year);

            return ServiceResult<DataTable>.Ok(dt);
        }


        public ServiceResult<DataTable> SearchStdData(string txt,int year)
        {
            var connection = CheckConnection();

            if (!connection.Success)
                return ServiceResult<DataTable>.Fail(connection.Message);

            var dt = Search_Std_Data(txt,year);

            return ServiceResult<DataTable>.Ok(dt);
        }
        public ServiceResult DeleteStudentWithOsraRule(string stdCode, int osraId)
        {
            var connection = CheckConnection();
            if (!connection.Success)
                return ServiceResult.Fail(ServiceMessages.ServerConnectionFailed);

            try
            {
                // 1- حذف الطالب
                Delele_Std_Data(stdCode);

                // 2- التحقق من الأسرة
                DataTable dt = _osra.Verify_Osra_Data(osraId);

                bool hasOtherStudents =
                    dt != null &&
                    dt.Rows.Count > 0 &&
                    SafeConverter.GetInt(dt.Rows[0]["Id"]) > 0;

                // 3- حذف الأسرة لو الطالب الوحيد
                if (!hasOtherStudents)
                {
                    Delele_Osra_Data(osraId);
                }

                return ServiceResult.Ok("تم حذف الطالب بنجاح");
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.Message);
            }
        }

        public DataTable Get_School_year_Data(int Year_Id, int Grade_Id, int Class_Id)
           => _dal.ExecQuery("SP_Get_School_year_Data",
               SqlParam.Int("@Year_Id", Year_Id),
               SqlParam.Int("@Grade_Id", Grade_Id),
               SqlParam.Int("@Class_Id", Class_Id));

        public DataTable Get_All_Std_Data(int Year_Id)
           => _dal.ExecQuery("SP_Get_All_Std_Data",
               SqlParam.Int("@Year_Id", Year_Id));

        private DataTable Search_Std_Data(string std_data, int Year_Id)
            => _dal.ExecQuery("SP_Search_Std_Data",
                SqlParam.NVar("@std_data", std_data, 100),
                SqlParam.Int("@Year_Id", Year_Id));
        private void Delele_Std_Data(string std_code)
            => _dal.ExecNonQuery("SP_Delele_Std_Data",
                SqlParam.NVar("@std_code", std_code, 20));

        private void Delele_Osra_Data(int Osra_Id)
           => _dal.ExecNonQuery("SP_Delele_Osra_Data",
               SqlParam.Int("@Osra_Id", Osra_Id));

    }
}
   
