using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.SyncService.Models
{
    public class StudentSyncResult
    {
        // نتائج التجهيز
        public int Added { get; set; }

        public int Updated { get; set; }

        public int Deleted { get; set; }

        public int NoChange { get; set; }

        public int Total =>
            Added + Updated + Deleted + NoChange;


        // نتائج التنفيذ على الموقع
        public int AddedToSite { get; set; }

        public int UpdatedOnSite { get; set; }

        public int DeletedOnSite { get; set; }

        public int SchoolCount { get; set; }

        public int SiteCount { get; set; }

        public int SiteTotal =>
            AddedToSite + UpdatedOnSite + DeletedOnSite;
    }
}
