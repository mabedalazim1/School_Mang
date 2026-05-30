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
        private readonly TestConcation testConcation = new TestConcation();
        private readonly CLS_STD std = new CLS_STD();

        private ServiceResult CheckConnection()
        {
            if (!testConcation.IsServerConnected())
                return ServiceResult.Fail(ServiceMessages.ServerConnectionFailed);

            return ServiceResult.Ok();
        }

        public ServiceResult<DataTable> GetStudentsData(int year = 0)
        {
            var connection = CheckConnection();

            if (!connection.Success)
                return ServiceResult<DataTable>.Fail(connection.Message);

            var dt = std.Get_All_Std_Data(year);

            return ServiceResult<DataTable>.Ok(dt);
        }


        public ServiceResult<DataTable> SearchStdData(string txt,int year)
        {
            var connection = CheckConnection();

            if (!connection.Success)
                return ServiceResult<DataTable>.Fail(connection.Message);

            var dt = std.Search_Std_Data(txt,year);

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
                std.Delele_Std_Data(stdCode);

                // 2- التحقق من الأسرة
                DataTable dt = std.Verify_Osra_Data(osraId);

                bool hasOtherStudents =
                    dt != null &&
                    dt.Rows.Count > 0 &&
                    SafeConverter.GetInt(dt.Rows[0]["Id"]) > 0;

                // 3- حذف الأسرة لو الطالب الوحيد
                if (!hasOtherStudents)
                {
                    std.Delele_Osra_Data(osraId);
                }

                return ServiceResult.Ok("تم حذف الطالب بنجاح");
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.Message);
            }
        }
    }
}
   
