using School_Mang.BL.Common.Helper;
using School_Mang.BL.DTO;
using School_Mang.BL.Services.FamilySyncService.Models;
using System;
using System.Collections.Generic;
using System.Data;


namespace School_Mang.BL.Services.FamilySyncService
{
    public class FamilyMapper
    {
        public List<SchoolFamily> MapSchoolFamilies(DataTable table)
        {
            var result = new List<SchoolFamily>();

            foreach (DataRow row in table.Rows)
            {
                result.Add(new SchoolFamily
                {
                    OsraId = SafeConverter.GetInt(row["Osraa_Id"]),
                    FatherName = SafeConverter.GetString(row["father_name"]),
                    WhatsAppNumber = SafeConverter.GetString(row["mother_mobil_2"]),
                    FatherNat = SafeConverter.GetString(row["Father_Nat"])
                });
            }

            return result;
        }

        public List<SiteFamily> MapSiteFamilies(DataTable table)
        {
            var result = new List<SiteFamily>();

            foreach (DataRow row in table.Rows)
            {
                result.Add(new SiteFamily
                {
                    OsraId = SafeConverter.GetInt(row["osraId"]),
                    UserName = SafeConverter.GetString(row["username"]),
                    IsActive = SafeConverter.GetBool(row["IsActive"]),
                });
            }

            return result;
        }

        public List<FamilySyncTemp> MapTempFamilies(DataTable table)
        {
            var result = new List<FamilySyncTemp>();

            foreach (DataRow row in table.Rows)
            {
                result.Add(new FamilySyncTemp
                {
                    OsraId = Convert.ToInt32(row["Osra_Id"]),

                    FatherName = row["Father_Name"].ToString(),
                    FirstName = row["First_Name"] == DBNull.Value
                        ? null
                        : row["First_Name"].ToString(),

                    FatherNat = row["Father_Nat"].ToString(),
                    WhatsAppNumber = row["WhatsApp_Number"].ToString(),

                    SiteUserName = row["Site_UserName"] == DBNull.Value
                        ? null
                        : row["Site_UserName"].ToString(),

                    SitePassword = row["Site_Password"] == DBNull.Value
                        ? null
                        : row["Site_Password"].ToString(),

                    SiteIsActive = row["Site_IsActive"] != DBNull.Value &&
                                   Convert.ToBoolean(row["Site_IsActive"]),

                    ActionId = Convert.ToInt32(row["Action_Id"])
                });
            }

            return result;
        }
        public HashSet<int> MapTempFamilyIds(DataTable table)
        {
            HashSet<int> ids = new HashSet<int>();

            foreach (DataRow row in table.Rows)
            {
                ids.Add(Convert.ToInt32(row["Osra_Id"]));
            }

            return ids;
        }

    }
}
