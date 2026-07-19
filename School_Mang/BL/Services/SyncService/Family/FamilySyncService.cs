using School_Mang.BL.Services.FamilySyncService.Models;
using School_Mang.BL.Services.SyncService;
using System;
using System.Collections.Generic;
using System.Data;
using School_Mang.BL.Services;

namespace School_Mang.BL.Services.SyncService.Family
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
        private readonly SyncProcessService _syncProcessService;

        public event Action<int, int, string> ProgressChanged;

        private int _current;
        private int _total;

        public FamilySyncService()
        {
            _schoolProvider = new SchoolFamilyProvider();
            _mapper = new FamilyMapper();
            _tempBuilder = new FamilySyncTempBuilder();
            _tableBuilder = new TempTableBuilder();
            _bulkService = new FamilySyncBulkService();
            _tempService = new FamilySyncTempService();
            _siteUserProvider = new SiteUserProvider();
            _syncProcessService = new SyncProcessService();

        }

        private void Report(string message)
        {
            _current++;
            ProgressChanged?.Invoke(_current, _total, message);
        }

        public FamilySyncResult SyncFamilies(int year)
        {
            _total = 10;
            _current = 0;

            var result = new FamilySyncResult();

            PrepareTempTable(year, result);

            UpdateSiteData(result);

            AppendSiteOnlyFamilies(result);

            _syncProcessService.SetPrepared("Family");

            return result;
        }

        private void PrepareTempTable(int yearId, FamilySyncResult result)
        {
            // تنظيف الجدول المؤقت
            Report("تنظيف الجدول المؤقت");
            _bulkService.ClearTemp();

            // قراءة أسر العام الدراسي
            Report("قراءة بيانات المدرسة");
            DataTable schoolTable =
                _schoolProvider.GetCurrentFamilies(yearId);


            // Mapping أسر المدرسة
            Report("تجهيز بيانات المدرسة");
            var schoolFamilies =
                _mapper.MapSchoolFamilies(schoolTable);



            // قراءة أسر الموقع
            Report("قراءة بيانات الموقع");
            DataTable siteTable =
                _siteUserProvider.GetAllFamilies();


            // Mapping أسر الموقع
            Report("تجهيز بيانات الموقع");
            var siteFamilies =
                _mapper.MapSiteFamilies(siteTable);

            // أسماء المستخدمين الموجودة بالموقع
            Report("تحميل أسماء المستخدمين");
            HashSet<string> existingUserNames =
                _siteUserProvider.GetAllUserNames();


            // تجهيز بيانات الـ Temp
            // (سنعدل Build في الخطوة القادمة)
            Report("بناء جدول البيانات");
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
            Report("حفظ البيانات المؤقتة");
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
