using School_Mang.BL.Common.Helper;
using School_Mang.BL.DTO;
using School_Mang.BL.Services.FamilySyncService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


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
                    WhatsAppNumber = SafeConverter.GetString(row["WhatsApp_Number"]),
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
                    FullName = SafeConverter.GetString(row["fullName"]),
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

        public List<FamilySyncTemp> MapTempFamilies(DataTable table)
        {
            return table.AsEnumerable()
                .Select(r => new FamilySyncTemp
                {
                    OsraId = r.Field<int>("Osra_Id"),
                    FatherName = r.Field<string>("Father_Name"),
                    FirstName = r.Field<string>("First_Name"),
                    WhatsAppNumber = r.Field<string>("WhatsApp_Number"),
                    FatherNat = r.Field<string>("Father_Nat"),
                    SiteUserName = r.Field<string>("Site_UserName"),
                    SitePassword = r.Field<string>("Site_Password"),
                    SiteIsActive = r.Field<bool>("Site_IsActive"),
                    ActionId = r.Field<int>("Action_Id")
                })
                .ToList();
        }

    }
}
