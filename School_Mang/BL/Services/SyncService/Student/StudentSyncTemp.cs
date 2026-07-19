using School_Mang.BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.SyncService.Student
{
    public class StudentSyncTemp
    {
        public int SeatNo { get; set; }

        public string StdCode { get; set; }

        public int OsraId { get; set; }

        public string FirstName { get; set; }

        public string FullName { get; set; }

        public int Grade_Id { get; set; }

        public int Class_Id { get; set; }

        public int Gender_Id { get; set; }

        public int Religion_Id { get; set; }

        public StudentSyncAction Action_Id { get; set; }
    }
}
