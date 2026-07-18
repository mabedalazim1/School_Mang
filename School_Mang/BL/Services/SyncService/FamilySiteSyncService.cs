using School_Mang.BL.Enums;
using School_Mang.BL.Services.FamilySyncService;
using School_Mang.BL.Services.FamilySyncService.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace School_Mang.BL.Services.SyncService
{
    public class FamilySiteSyncService
    {
        private readonly FamilySyncTempService _tempService;
        private readonly SiteUserProvider _siteProvider;

        private int _current;
        private int _total;

        public FamilySiteSyncService()
        {
            _tempService = new FamilySyncTempService();
            _siteProvider = new SiteUserProvider();
        }

        public event Action<int, int, string> ProgressChanged;

        public FamilySyncResult SyncFamilies()
        {
            FamilySyncResult result = new FamilySyncResult();

            var addFamilies =
                _tempService.GetFamiliesForSync((int)FamilySyncAction.Add);

            var activateFamilies =
                _tempService.GetFamiliesForSync((int)FamilySyncAction.Activate);

            var disableFamilies =
                _tempService.GetFamiliesForSync((int)FamilySyncAction.Disable)
                .Where(x => x.SiteIsActive)
                .ToList();

            var noChangeFamilies =
                _tempService.GetFamiliesForSync((int)FamilySyncAction.NoChange);

            _total =
                addFamilies.Count +
                activateFamilies.Count +
                noChangeFamilies.Count +
                disableFamilies.Count;


            _current = 0;


            SyncNewFamilies(addFamilies, result);

            ActivateFamilies(activateFamilies, result);

            UpdateExistingFamilies(noChangeFamilies);

            DisableFamilies(disableFamilies, result);


            return result;
        }

        private void SyncNewFamilies(List<FamilySyncTemp> families,
                                     FamilySyncResult result)
        {
            foreach (var family in families)
            {
                _siteProvider.AddFamilyUser(family);

                result.AddedToSite++;

                _current++;

                ProgressChanged?.Invoke(
                    _current,
                    _total,
                    $"إضافة : {family.FatherName}");
            }
        }

        private void ActivateFamilies(List<FamilySyncTemp> families,
                                       FamilySyncResult result)
        {
            if (families.Count == 0)
                return;

            foreach (var family in families)
            {
                _siteProvider.ActivateFamily(family.OsraId);

                result.ReactivatedOnSite++;

                _current++;

                ProgressChanged?.Invoke(
                    _current,
                    _total,
                    $"تفعيل أسرة : {family.FatherName}");
            }
        }

        private void UpdateExistingFamilies(List<FamilySyncTemp> families)
        {
            if (families.Count == 0)
                return;

            DataTable table = new DataTable();

            table.Columns.Add("OsraId", typeof(string));
            table.Columns.Add("WhatsApp", typeof(string));


            foreach (var family in families)
            {
                table.Rows.Add(
                    family.OsraId.ToString(),
                    family.WhatsAppNumber);
            }

            _siteProvider.UpdateFamilyWhatsApp(table);

            _current += families.Count;

            ProgressChanged?.Invoke(
                _current,
                _total,
                "تم تحديث أرقام الواتساب");
        }

        private void DisableFamilies(List<FamilySyncTemp> families,
                             FamilySyncResult result)
        {
            if (families.Count == 0)
                return;

            foreach (var family in families)
            {
                // حماية أخيرة في حالة تغير البيانات
                if (!family.SiteIsActive)
                    continue;


                _siteProvider.DisableFamily(family.OsraId);

                result.DisabledOnSite++;

                _current++;

                ProgressChanged?.Invoke(
                    _current,
                    _total,
                    "جارى تعطيل الأسر غير الموجودة");
            }
        }
    }
}
