using School_Mang.BL.DTO;
using School_Mang.BL.Enums;
using School_Mang.BL.Services.FamilySyncService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.FamilySyncService
{
    public class FamilySyncTempBuilder
    {

        private readonly FamilyDataGenerator _generator;

        public FamilySyncTempBuilder()
        {
            _generator = new FamilyDataGenerator();
        }

        public List<FamilySyncTemp> Build(
                                        List<SchoolFamily> families,
                                        List<SiteFamily> siteFamilies,
                                        HashSet<string> existingUserNames,
                                        FamilySyncResult result)
        {
            var tempFamilies = new List<FamilySyncTemp>();

            foreach (var family in families)
            {
                var oldFamily =
                                siteFamilies.FirstOrDefault(
                                x => x.OsraId == family.OsraId);

                if (oldFamily != null)
                {
                    // أسرة قديمة موجودة بالموقع
                    tempFamilies.Add(new FamilySyncTemp
                    {
                        OsraId = family.OsraId,

                        FatherName = family.FatherName,

                        FirstName =
                            _generator.GenerateFirstName(
                                family.FatherName),

                        FatherNat = family.FatherNat,

                        WhatsAppNumber = family.WhatsAppNumber,


                        // بيانات الموقع كما هي
                        SiteUserName = oldFamily.UserName,

                        SitePassword = null,

                        SiteIsActive = oldFamily.IsActive,


                        ActionId = (int)FamilySyncAction.NoChange
                        
                    });
                    result.NoChange++;
                    
                }
                else
                {
                    // أسرة جديدة
                    string userName =
                        GenerateUniqueUserName(
                            family.FatherNat,
                            family.OsraId,
                            existingUserNames);


                    tempFamilies.Add(new FamilySyncTemp
                    {
                        OsraId = family.OsraId,

                        FatherName = family.FatherName,

                        FirstName =
                            _generator.GenerateFirstName(
                                family.FatherName),

                        FatherNat = family.FatherNat,

                        WhatsAppNumber = family.WhatsAppNumber,


                        SiteUserName = userName,

                        SitePassword =
                            _generator.GeneratePassword(userName),


                        SiteIsActive = false,


                        ActionId = (int)FamilySyncAction.Add
                    });
                    result.Added++;
                }
            }

            return tempFamilies;
        }

        private string GenerateUniqueUserName(
                                    string fatherNat,
                                    int osraId,
                                    HashSet<string> existingUserNames)
        {
            int attempt = 0;

            while (true)
            {
                string userName =
                    _generator.GenerateUniqueUserName(
                        fatherNat,
                        osraId,
                        attempt);

                if (!existingUserNames.Contains(userName))
                {
                    existingUserNames.Add(userName);
                    return userName;
                }

                attempt++;
            }
        }
        public List<FamilySyncTemp> BuildSiteOnlyFamilies(
            List<SiteFamily> siteFamilies,
            HashSet<int> tempFamilyIds,
            FamilySyncResult result)
        {
            var tempFamilies = new List<FamilySyncTemp>();

            foreach (var family in siteFamilies)
            {
                // موجود بالفعل فى الجدول المؤقت
                if (tempFamilyIds.Contains(family.OsraId))
                    continue;

                // الأسرة معطلة بالفعل بالموقع
                // لا تحتاج أى إجراء
                if (!family.IsActive)
                    continue;


                tempFamilies.Add(new FamilySyncTemp
                {
                    OsraId = family.OsraId,

                    // البيانات القادمة من الموقع فقط
                    SiteUserName = family.UserName,
                    SiteIsActive = family.IsActive,

                    // البيانات المحلية غير موجودة
                    FirstName = null,
                    FatherName = null,
                    FatherNat = null,
                    WhatsAppNumber = null,
                    SitePassword = null,

                    // مبدئياً مرشح للتعطيل
                    ActionId = (int)FamilySyncAction.Disable
                });
                result.Disabled++;
            }

            return tempFamilies;
        }
    }
}
