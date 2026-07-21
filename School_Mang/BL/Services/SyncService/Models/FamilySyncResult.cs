namespace School_Mang.BL.Services.SyncService.Models
{
    public class FamilySyncResult
    {
        // نتائج تجهيز البيانات
        public int NoChange { get; set; }

        public int Added { get; set; }

        public int Reactivated { get; set; }

        public int Disabled { get; set; }

        // نتائج التحقق من أسماء المستخدمين
        public int CheckedUserNames { get; set; }

        public int UpdatedUserNames { get; set; }

        // نتائج التنفيذ على الموقع
        public int AddedToSite { get; set; }

        public int ReactivatedOnSite { get; set; }

        public int DisabledOnSite { get; set; }

        // إجمالى الأسر التى تمت معالجتها أثناء التجهيز
        public int Total =>
            Added + Reactivated + Disabled + NoChange;

        public int SiteTotal =>
           AddedToSite + ReactivatedOnSite + DisabledOnSite;
    }
}
