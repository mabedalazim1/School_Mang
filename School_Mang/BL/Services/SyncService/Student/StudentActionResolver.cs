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
        private readonly HashSet<string> _siteStudents;

        public StudentActionResolver(HashSet<string> siteStudents)
        {
            _siteStudents = siteStudents;
        }

        public StudentSyncAction Resolve(string stdCode)
        {
            if (_siteStudents.Contains(stdCode))
                return StudentSyncAction.Update;

            return StudentSyncAction.Add;
        }
    }
}
