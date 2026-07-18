using School_Mang.BL.Services.SyncService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.SyncService
{
    public class StudentSyncExecuteService
    {
        private readonly StudentArchiveService _archive;
        private readonly StudentSyncTempService _temp;

        public StudentSyncExecuteService()
        {
            _archive = new StudentArchiveService();
            _temp = new StudentSyncTempService();
        }


        public void Execute(int yearId)
        {
            // 1- Archive
            _archive.Archive(yearId);


            // 2- Get Temp Data


            // 3- Update


            // 4- Add


            // 5- Delete
        }
    }
}
