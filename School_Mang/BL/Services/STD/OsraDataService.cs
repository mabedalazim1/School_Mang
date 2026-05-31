using School_Mang.BL.Common;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.STD;
using School_Mang.DAL;
using System;
using System.Data;


namespace School_Mang.BL.Services.STD
{
    public class OsraDataService
    {
        private readonly TestConcation _testConcation;
        private readonly DataAcceseLayer _dal;


        public OsraDataService() 
        {
            _testConcation = new TestConcation();
            _dal = new DataAcceseLayer();
        }
        private ServiceResult CheckConnection()
        {
            if (!_testConcation.IsServerConnected())
                return ServiceResult.Fail(ServiceMessages.ServerConnectionFailed);

            return ServiceResult.Ok();
        }

        public ServiceResult<DataTable> GetOsraData()
        {
            var connection = CheckConnection();

            if (!connection.Success)
                return ServiceResult<DataTable>.Fail(connection.Message);

            var dt = Get_All_Osra_Data();

            return ServiceResult<DataTable>.Ok(dt);
        }

        public ServiceResult<DataTable> SearchOsra(string text)
        {
            var connection = CheckConnection();

            if (!connection.Success)
                return ServiceResult<DataTable>.Fail(connection.Message);

            var dt = Search_Osra_Data(text);

            return ServiceResult<DataTable>.Ok(dt);
        }

        public ServiceResult<DataTable> GetOsraDataById(int osraId)
        {
            var connection = CheckConnection();

            if (!connection.Success)
                return ServiceResult<DataTable>.Fail(connection.Message);

            var dt = Get_osra_Data_ById(osraId);

            return ServiceResult<DataTable>.Ok(dt);
        }
        public (string updatedBy, DateTime? updatedAt) GetUpdateInfo(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return (null, null);

            var row = dt.Rows[0];

            var updatedBy = row["Updated_by"] == DBNull.Value
                ? null
                : row["Updated_by"].ToString();

            if (string.IsNullOrWhiteSpace(updatedBy))
                return (null, null);

            DateTime? updatedAt = row["Updated_At"] == DBNull.Value
                ? (DateTime?)null
                : Convert.ToDateTime(row["Updated_At"]);

            return (updatedBy, updatedAt);
        }
        public ServiceResult DeleteOsra(int osraId)
        {
            var connection = CheckConnection();
            if (!connection.Success)
                return connection;

            var dt = Verify_Osra_Data(osraId);

            if (dt == null || dt.Rows.Count == 0)
                return ServiceResult.Fail("خطأ في التحقق من البيانات");

            if (SafeConverter.GetInt(dt.Rows[0]["Id"]) != 0)
                return ServiceResult.Fail("لا يمكن حذف هذه البيانات لأنها مرتبطة ببيانات أخرى");

            Delele_Osra_Data(osraId);

            return ServiceResult.Ok("تم حذف البيانات بنجاح");
        }
        public DataTable Verify_Osra_Data(int Osraa_Id)
          => _dal.ExecQuery("SP_Verify_Osra_Data",
              SqlParam.Int("@Osraa_Id", Osraa_Id));

        public DataTable Get_osra_Data_ById(int Osraa_Id)
           => _dal.ExecQuery("SP_Get_osra_Data_ById",
               SqlParam.Int("@Osraa_Id", Osraa_Id));

        private DataTable Get_All_Osra_Data()
            => _dal.ExecQuery("SP_Get_All_Osra_Data", null);
        private DataTable Search_Osra_Data(string osra_data)
            => _dal.ExecQuery("SP_Search_Osra_Data",
                SqlParam.NVar("@osra_data", osra_data, 100));

        private void Delele_Osra_Data(int Osra_Id)
           => _dal.ExecNonQuery("SP_Delele_Osra_Data",
               SqlParam.Int("@Osra_Id", Osra_Id));

    }
}
