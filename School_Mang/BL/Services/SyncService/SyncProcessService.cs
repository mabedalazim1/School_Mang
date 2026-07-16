using School_Mang.BL.DTO;
using School_Mang.DAL;
using System;
using System.Data;

namespace School_Mang.BL.Services.SyncService
{
    public class SyncProcessService
    {
        private readonly DataAcceseLayer _dal = new DataAcceseLayer();

        public void SetPrepared(string syncName)
        {
            _dal.ExecNonQuery(
                "SP_Set_Sync_Prepared",
                SqlParam.NVar("@Sync_Name", syncName));
        }

        public void ClearPrepared(string syncName)
        {
            _dal.ExecNonQuery(
                "SP_Clear_Sync_Process",
                SqlParam.NVar("@Sync_Name", syncName));
        }

        public SyncProcessInfo GetStatus(string syncName)
        {
            DataTable dt = _dal.ExecQuery(
                "SP_Get_Sync_Process",
                SqlParam.NVar("@Sync_Name", syncName));

            if (dt.Rows.Count == 0)
            {
                return new SyncProcessInfo
                {
                    IsPrepared = false,
                    PreparedDate = null
                };
            }

            DataRow row = dt.Rows[0];

            return new SyncProcessInfo
            {
                IsPrepared = Convert.ToBoolean(row["Is_Prepared"]),
                PreparedDate = row["Prepared_Date"] == DBNull.Value
                    ? (DateTime?)null
                    : Convert.ToDateTime(row["Prepared_Date"])
            };
        }

    }
}
