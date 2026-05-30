using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Models
{
    public class StudentSaveRequest
    {
        public string StudentName { get; set; }
        public string NationalId { get; set; }
        public int YearId { get; set; }
        public int GradeId { get; set; }
        public int GenderId { get; set; }
        public int NationalityId { get; set; }
        public int ReligionId { get; set; }
        public int StatusId { get; set; }
        public int OsraId { get; set; }
        public int ClassId { get; set; }
        public string StdCode { get; set; }
    }
}
