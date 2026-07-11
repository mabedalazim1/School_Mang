using School_Mang.BL.DTO;
using School_Mang.BL.Enums;
using School_Mang.BL.Services.FamilySyncService.Models;
using System.Collections.Generic;
using System.Linq;

namespace School_Mang.BL.Services.FamilySyncService
{
    public class FamilyComparer
    {
        public List<FamilySyncItem> Compare(
                                        List<SchoolFamily> schoolFamilies,
                                        List<SiteFamily> siteFamilies)
        {
            var result = new List<FamilySyncItem>();

            var siteDictionary = siteFamilies.ToDictionary(x => x.OsraId);

            // المرحلة الأولى
            foreach (var schoolFamily in schoolFamilies)
            {
                if (!siteDictionary.TryGetValue(schoolFamily.OsraId, out SiteFamily siteFamily))
                {
                    result.Add(new FamilySyncItem
                    {
                        SchoolFamily = schoolFamily,
                        Action = FamilySyncAction.Add
                    });

                    continue;
                }

                result.Add(new FamilySyncItem
                {
                    SchoolFamily = schoolFamily,
                    SiteFamily = siteFamily,
                    Action = siteFamily.IsActive
                        ? FamilySyncAction.NoChange
                        : FamilySyncAction.Activate
                });
            }

            // المرحلة الثانية
            var schoolDictionary = schoolFamilies.ToDictionary(x => x.OsraId);

            foreach (var siteFamily in siteFamilies)
            {
                if (!schoolDictionary.TryGetValue(siteFamily.OsraId, out SchoolFamily schoolFamily))
                {
                    result.Add(new FamilySyncItem
                    {
                        SiteFamily = siteFamily,
                        Action = FamilySyncAction.Disable
                    });
                }
            }

            return result;
        }

    }
}
