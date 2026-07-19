using School_Mang.BL.Services.FamilySyncService.Models;
using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace School_Mang.BL.Services.SyncService
{
    public class SiteUserProvider
    {
        private readonly SiteAccessLayer _site;

        public SiteUserProvider()
        {
            _site = new SiteAccessLayer();
        }


        public DataTable GetAllFamilies()
        {
            return _site.ExecQuery("SP_Get_Site_Student_Families");
        }

        public HashSet<string> GetAllUserNames()
        {
            DataTable dt = _site.Query(
                "SELECT username FROM users");

            HashSet<string> result =
                new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

            foreach (DataRow row in dt.Rows)
            {
                string userName = row["username"].ToString();

                if (!string.IsNullOrWhiteSpace(userName))
                    result.Add(userName);
            }

            return result;
        }

        public void AddFamilyUser(FamilySyncTemp family)
        {
            _site.ExecNonQuery(
                "SP_Add_User_2025",
                SqlParam.NVar("@username", family.SiteUserName),
                SqlParam.NVar("@password", family.SitePassword),
                SqlParam.NVar("@firstName", family.FirstName),
                SqlParam.NVar("@fullName", family.FatherName),
                SqlParam.Int("@roleId", 5),
                SqlParam.NVar("@osraId", family.OsraId.ToString()),
                SqlParam.NVar("@note", family.WhatsAppNumber)
            );
        }

        public void ActivateFamily(int osraId)
        {
            _site.ExecNonQuery(
                "SP_Activate_Family_User",
                SqlParam.NVar("@Osra_Id", osraId.ToString()));
        }

        public void DisableFamily(int osraId)
        {
            _site.ExecNonQuery(
                "SP_Disable_Family_User",
                SqlParam.NVar("@Osra_Id", osraId.ToString()));
        }

        public void UpdateFamilyWhatsApp(DataTable table)
        {
            _site.ExecuteTableParameter(
                "SP_Update_Family_WhatsApp",
                "@Families",
                table,
                "FamilyWhatsAppType");
        }
    }
}
