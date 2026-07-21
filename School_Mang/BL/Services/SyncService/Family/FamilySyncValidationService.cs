using School_Mang.BL.Enums;
using School_Mang.BL.Services.SyncService;
using School_Mang.BL.Services.SyncService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.SyncService.Family
{
    public class FamilySyncValidationService
    {
        private readonly FamilySyncTempService _tempService;
        private readonly SiteUserProvider _siteUserProvider;
        private readonly FamilyDataGenerator _generator;

        public FamilySyncValidationService()
        {
            _tempService = new FamilySyncTempService();
            _siteUserProvider = new SiteUserProvider();
            _generator = new FamilyDataGenerator();
        }


        public FamilyValidationResult ValidateUserNames()
        {
            var result = new FamilyValidationResult();

            // الأسر التي سيتم إضافتها للموقع فقط
            List<FamilySyncTemp> families =
                _tempService.GetFamiliesForSync((int)FamilySyncAction.Add);

            result.CheckedCount = families.Count;

            // كل أسماء المستخدمين الموجودة بالموقع
            HashSet<string> existingUserNames =
                _siteUserProvider.GetAllUserNames();


            foreach (FamilySyncTemp family in families)
            {
                // الاسم غير موجود بالموقع
                // نضيفه للقائمة حتى نمنع تكراره داخل نفس العملية
                if (!existingUserNames.Contains(family.SiteUserName))
                {
                    existingUserNames.Add(family.SiteUserName);
                    continue;
                }

                // الاسم موجود
                // نولد اسم بديل
                int attempt = 1;
                string newUserName;


                do
                {
                    newUserName =
                        _generator.GenerateUniqueUserName(
                            family.FatherNat,
                            family.OsraId,
                            attempt);

                    attempt++;

                } while (existingUserNames.Contains(newUserName));

                // تحديث البيانات الجديدة
                family.SiteUserName = newUserName;

                family.SitePassword =
                    _generator.GeneratePassword(newUserName);

                // تحديث الجدول المؤقت
                _tempService.UpdateUser(family);

                // إضافة الاسم الجديد للقائمة
                existingUserNames.Add(newUserName);


                // تم تعديل اسم المستخدم
                result.UpdatedUserNames++;
            }


            return result;

        }

    }
}
