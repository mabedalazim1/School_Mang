using School_Mang.BL.Enums;
using School_Mang.BL.Services.FamilySyncService.Models;
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
        private readonly FamilyMapper _mapper;
        public FamilySyncTempService()
        {
            _dal = new DataAcceseLayer();
            _mapper = new FamilyMapper();
        }

        public List<FamilySyncTemp> GetFamiliesForSync(int actionId)
        {
            DataTable dt = _dal.ExecQuery(
                "SP_Get_Families_For_Sync",
                SqlParam.Int("@Action_Id", actionId));

            return _mapper.MapTempFamilies(dt);
        }

        public void UpdateUser(FamilySyncTemp family)
        {
            _dal.ExecNonQuery(
                "SP_Update_FamilySync_UserName",
                SqlParam.Int("@Osra_Id", family.OsraId),
                SqlParam.NVar("@Site_UserName", family.SiteUserName),
                SqlParam.NVar("@Site_Password", family.SitePassword));
        }

        public DataTable GetTempFamilyIds()
        {
            return _dal.Query(
                "SELECT Osra_Id FROM FamilySync_Temp");
        }

    }
}
