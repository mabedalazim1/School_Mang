using School_Mang.BL.Enums;
using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.FamilySyncService
{
    public class FamilySyncTempService
    {
        private readonly DataAcceseLayer _dal;

        public FamilySyncTempService()
        {
            _dal = new DataAcceseLayer();
        }


        public int Clear()
        {
            return _dal.ExecuteQuery(
                "DELETE FROM FamilySync_Temp");
        }


        public DataTable GetFamiliesNeedUserName()
        {
            return _dal.ExecQuery(
                "SP_Get_Families_Need_UserName");
        }

        public DataTable GetFamiliesWithoutUserName()
        {
            return _dal.Query(@"
        SELECT *
        FROM FamilySync_Temp
        WHERE Site_UserName IS NULL
          AND Action_Id = @ActionId",
                SqlParam.Int("@ActionId", (int)FamilySyncAction.Add));
        }
        public void UpdateUserName(int osraId, string userName)
        {
            _dal.ExecNonQuery(
                "SP_Update_FamilySync_UserName",
                SqlParam.Int("@Osra_Id", osraId),
                SqlParam.NVar("@Site_UserName", userName));
        }

        public DataTable GetTempFamilyIds()
        {
            return _dal.Query(
                "SELECT Osra_Id FROM FamilySync_Temp");
        }

    }
}
