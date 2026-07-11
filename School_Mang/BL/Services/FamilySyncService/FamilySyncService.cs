using School_Mang.BL.Services.FamilySyncService.Models;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web.Services.Description;

namespace School_Mang.BL.Services.FamilySyncService
{
    public class FamilySyncService
    {
        private readonly SchoolFamilyProvider _schoolProvider;
        private readonly FamilyMapper _mapper;
        private readonly FamilySyncTempBuilder _tempBuilder;
        private readonly TempTableBuilder _tableBuilder;
        private readonly FamilySyncBulkService _bulkService;
        private readonly FamilySyncTempService _tempService;
        private readonly SiteUserProvider _siteUserProvider;

        public FamilySyncService()
        {
            _schoolProvider = new SchoolFamilyProvider();
            _mapper = new FamilyMapper();
            _tempBuilder = new FamilySyncTempBuilder();
            _tableBuilder = new TempTableBuilder();
            _bulkService = new FamilySyncBulkService();
            _tempService = new FamilySyncTempService();
            _siteUserProvider = new SiteUserProvider();

        }


        public FamilySyncResult SyncFamilies(int year)
        {
            var result = new FamilySyncResult();

            PrepareTempTable(year, result);

            UpdateSiteData(result);

            AppendSiteOnlyFamilies(result);

            return result;
        }

        private void PrepareTempTable(int yearId, FamilySyncResult result)
        {
            // تنظيف الجدول المؤقت
            _bulkService.ClearTemp();

            // قراءة أسر العام الدراسي
            DataTable schoolTable =
                _schoolProvider.GetCurrentFamilies(yearId);

            
            // Mapping أسر المدرسة
            var schoolFamilies =
                _mapper.MapSchoolFamilies(schoolTable);



            // قراءة أسر الموقع
            DataTable siteTable =
                _siteUserProvider.GetAllFamilies();


            // Mapping أسر الموقع
            var siteFamilies =
                _mapper.MapSiteFamilies(siteTable);

            // أسماء المستخدمين الموجودة بالموقع
            HashSet<string> existingUserNames =
                _siteUserProvider.GetAllUserNames();


            // تجهيز بيانات الـ Temp
            // (سنعدل Build في الخطوة القادمة)
            var tempFamilies =
                _tempBuilder.Build(
                    schoolFamilies,
                    siteFamilies,
                    existingUserNames, 
                    result);

            // تحويل إلى DataTable
            DataTable tempTable =
                _tableBuilder.BuildTempFamilies(tempFamilies);



            // Bulk Insert
            _bulkService.InsertTempFamilies(tempTable);

        }


        
        private void UpdateSiteData(FamilySyncResult result)
        {
            DataTable siteTable =
                _siteUserProvider.GetAllFamilies();

            var siteFamilies =
                _mapper.MapSiteFamilies(siteTable);

            DataTable table =
                _tableBuilder.BuildSiteFamilies(siteFamilies,result);

            _bulkService.UpdateSiteFamilies(table);
        }
       
        private void AppendSiteOnlyFamilies(FamilySyncResult result)
        {
            // أسر الموقع
            DataTable siteTable =
                _siteUserProvider.GetAllFamilies();

            var siteFamilies =
                _mapper.MapSiteFamilies(siteTable);

            // أرقام الأسر الموجودة فى الجدول المؤقت
            DataTable tempIdsTable =
                _tempService.GetTempFamilyIds();

            var tempIds =
                _mapper.MapTempFamilyIds(tempIdsTable);

            // بناء الأسر الموجودة بالموقع فقط
            var siteOnlyFamilies =
                _tempBuilder.BuildSiteOnlyFamilies(
                    siteFamilies,
                    tempIds,
                    result);

            if (siteOnlyFamilies.Count == 0)
                return;

            // تحويلها إلى DataTable
            DataTable table =
                _tableBuilder.BuildTempFamilies(siteOnlyFamilies);

            // Bulk Insert
            _bulkService.InsertTempFamilies(table);
        }
    }
}
