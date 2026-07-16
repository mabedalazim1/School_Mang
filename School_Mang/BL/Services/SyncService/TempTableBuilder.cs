using School_Mang.BL.Enums;
using School_Mang.BL.Services.FamilySyncService.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace School_Mang.BL.Services.FamilySyncService
{
    public class TempTableBuilder
    {
        public DataTable BuildTempFamilies(List<FamilySyncTemp> families)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Osra_Id", typeof(int));
            table.Columns.Add("Father_Name", typeof(string));
            table.Columns.Add("First_Name", typeof(string));
            table.Columns.Add("Father_Nat", typeof(string));
            table.Columns.Add("WhatsApp_Number", typeof(string));
            table.Columns.Add("Site_UserName", typeof(string));
            table.Columns.Add("Site_Password", typeof(string));
            table.Columns.Add("Site_IsActive", typeof(bool));
            table.Columns.Add("Action_Id", typeof(int));

            foreach (var family in families)
            {
                table.Rows.Add(
                    family.OsraId,
                    family.FatherName,
                    family.FirstName ?? (object)DBNull.Value,
                    family.FatherNat,
                    family.WhatsAppNumber,
                    family.SiteUserName ?? (object)DBNull.Value,
                    family.SitePassword ?? (object)DBNull.Value,
                    family.SiteIsActive,
                    family.ActionId
                );
            }

            return table;
        }

        public DataTable BuildSiteFamilies(List<SiteFamily> families,
                                           FamilySyncResult result)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Osra_Id", typeof(int));
            table.Columns.Add("Site_UserName", typeof(string));
            table.Columns.Add("Site_IsActive", typeof(bool));
            table.Columns.Add("Action_Id", typeof(int));

            foreach (var family in families)
            {
                int action = family.IsActive
                                     ? (int)FamilySyncAction.NoChange
                                     : (int)FamilySyncAction.Activate;
                if (action == (int)FamilySyncAction.Activate)
                    result.Reactivated++;

                table.Rows.Add(
                    family.OsraId,
                    family.UserName,
                    family.IsActive,
                    action);
            }

            return table;
        }
       
    }
}
