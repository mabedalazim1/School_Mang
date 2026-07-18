using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.SyncService
{
    public class StudentSyncResult
    {
        public int Added { get; set; }
        public int Updated { get; set; }
        public int Deleted { get; set; }
        public int Checked { get; set; }

        public int SchoolCount { get; set; }
        public int SiteCount { get; set; }
    }
}
