using DevExpress.Utils.Animation;
using School_Mang.BL.Common;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.DTO;
using School_Mang.DAL;
using System;
using System.Data;


namespace School_Mang.BL.Services.STD
{
    public class OsraDataService
    {
        private readonly TestConcation _testConcation;
        private readonly DataAcceseLayer _dal;
        private readonly VerifyService _verify;


        public OsraDataService()
        {
            _testConcation = new TestConcation();
            _dal = new DataAcceseLayer();
            _verify = new VerifyService();
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

        private int GenerateOsraCode(int year)
        {
            // Student Code
            string next_year = SafeConverter.GetString(year);
            DataTable dt = _verify.Verify_Osra_Code(next_year);
            if (dt == null || dt.Rows.Count == 0 || dt.Rows[0]["Max_Osra_Id"] == DBNull.Value)
            {
                int Osra_cod = SafeConverter.GetInt(next_year + "001");
                return Osra_cod;
            }

            return Convert.ToInt32(dt.Rows[0]["Max_Osra_Id"]) + 1;
        }

        public ServiceResult<int> SaveOsraData(StudentDTO dto,int nextYear)
        {
            try
            {
                int osraId = GenerateOsraCode(nextYear);

                AddOsraData(dto, osraId);

                return ServiceResult<int>.Ok(osraId);
            }
            catch (Exception ex)
            {
                return ServiceResult<int>.Fail(ex.Message);
            }
        }

        public ServiceResult<int> UpdateOsraService(StudentDTO dto, int OsraId)
        {
            try
            {
                UpdateOsra(dto, OsraId);

                return ServiceResult<int>.Ok(dto.OsraId);
            }
            catch (Exception ex)
            {
                return ServiceResult<int>.Fail(ex.Message);
            }
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

        private void AddOsraData(StudentDTO dto, int Osraa_Id)
        {
            _dal.ExecNonQuery("SP_Add_Osra_Data",
                SqlParam.NVar("@father_nat", dto.FatherNat, 14),
                SqlParam.NVar("@address", dto.Address, 100),
                SqlParam.NVar("@father_name", dto.FatherName, 40),
                SqlParam.NVar("@father_last_name", dto.FatherLastName, 12),
                SqlParam.NVar("@father_moahel", dto.FatherMoahel, 50),
                SqlParam.NVar("@father_wazifa", dto.FatherWazifa, 50),
                SqlParam.NVar("@tel", dto.Tel, 7),
                SqlParam.NVar("@father_mobil_1", dto.FatherMobil_1, 11),
                SqlParam.NVar("@father_mobil_2", dto.FatherMobil_2, 11),
                SqlParam.Int("@father_hala", dto.FatherHala),
                SqlParam.NVar("@mother_nat", dto.MotherNat, 14),
                SqlParam.NVar("@mother_name", dto.MotherName, 50),
                SqlParam.NVar("@mother_moahel", dto.MotherMoahel, 50),
                SqlParam.NVar("@mother_wazifa", dto.MotherWazifa, 50),
                SqlParam.NVar("@mother_mobil_1", dto.MotherMbil_1, 11),
                SqlParam.NVar("@mother_mobil_2", dto.MotherMbil_2, 11),
                SqlParam.Int("@mother_hala", dto.MotherHala),
                SqlParam.NVar("@comments", dto.Comments, 250),
                SqlParam.Int("@Osraa_Id", Osraa_Id),
                SqlParam.NVar("@Created_by", dto.UserName, 15),
                SqlParam.NVar("@Updated_by", dto.UserName, 15)
            );
        }
        public void UpdateOsra(StudentDTO dto, int OsraId)
        {
            _dal.ExecNonQuery("SP_Update_Osra_Data",
                SqlParam.NVar("@father_nat",dto.FatherNat, 14),
                SqlParam.NVar("@address", dto.Address, 100),
                SqlParam.NVar("@father_name", dto.FatherName, 40),
                SqlParam.NVar("@father_last_name", dto.FatherLastName, 12),
                SqlParam.NVar("@father_moahel", dto.FatherMoahel, 50),
                SqlParam.NVar("@father_wazifa", dto.FatherWazifa, 50),
                SqlParam.NVar("@tel", dto.Tel, 7),
                SqlParam.NVar("@father_mobil_1", dto.FatherMobil_1, 11),
                SqlParam.NVar("@father_mobil_2", dto.FatherMobil_2, 11),
                SqlParam.Int("@father_hala", dto.FatherHala),
                SqlParam.NVar("@mother_nat", dto.MotherNat, 14),
                SqlParam.NVar("@mother_name", dto.MotherName, 50),
                SqlParam.NVar("@mother_moahel", dto.MotherMoahel, 50),
                SqlParam.NVar("@mother_wazifa", dto.MotherWazifa, 50),
                SqlParam.NVar("@mother_mobil_1", dto.MotherMbil_1, 11),
                SqlParam.NVar("@mother_mobil_2", dto.MotherMbil_2, 11),
                SqlParam.Int("@mother_hala", dto.MotherHala),
                SqlParam.NVar("@comments", dto.Comments, 250),
                SqlParam.Int("@Osraa_Id", OsraId),
                SqlParam.NVar("@Updated_by", dto.UserName, 15)
            );
        }


    }
}
