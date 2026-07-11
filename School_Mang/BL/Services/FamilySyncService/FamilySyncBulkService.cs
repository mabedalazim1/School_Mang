using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.FamilySyncService
{
    public class FamilySyncBulkService
    {
        private readonly DataAcceseLayer _dal;

        public FamilySyncBulkService()
        {
            _dal = new DataAcceseLayer();
        }



        public void ClearTemp()
        {
            _dal.ExecNonQuery("SP_Clear_FamilySync_Temp");
        }


        public void InsertTempFamilies(DataTable table)
        {
            _dal.BulkInsert(
                table,
                "FamilySync_Temp");
        }

        public void UpdateUserNames(DataTable table)
        {
            _dal.ExecuteTableParameter(
                "SP_Update_FamilySync_UserNames",
                "@Users",
                table,
                "FamilyUserNameTable");
        }

        public void UpdateSiteFamilies(DataTable table)
        {
            _dal.ExecuteTableParameter(
                "SP_Update_FamilySync_Site_Data",
                "@SiteFamilies",
                table,
                "SiteFamilySyncTable");
        }
        
    }
}
