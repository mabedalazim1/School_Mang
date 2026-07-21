using School_Mang.BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.SyncService.Student
{
    public class StudentActionResolver
    {
        private readonly Dictionary<string, int> _siteStudents;

        public StudentActionResolver(Dictionary<string, int> siteStudents)
        {
            _siteStudents = siteStudents;
        }

        public StudentSyncAction Resolve(string stdCode)
        {
            if (_siteStudents.ContainsKey(stdCode))
                return StudentSyncAction.Update;

            return StudentSyncAction.Add;
        }

        public int GetSeatNo(string stdCode)
        {
            if (_siteStudents.TryGetValue(stdCode, out int seatNo))
                return seatNo;

            return 0;
        }
    }
}
