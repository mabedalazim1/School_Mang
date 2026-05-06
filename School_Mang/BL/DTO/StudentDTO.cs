using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.DTO
{
    public class StudentDTO
    {
        // بيانات الطالب الأساسية
        public string StdCode { get; set; }
        public string StdName { get; set; }
        public string Nat { get; set; }
        public string StudentFullName { get; set; }

        // الأكواد
        public int GradeId { get; set; }
        public int YearId { get; set; }
        public int GenderId { get; set; }
        public int ReligionId { get; set; }
        public int NationalityId { get; set; }
        public int OsraId { get; set; }
        public int StudentStatus {  get; set; }
        public int Sana {  get; set; }
        public int ClassId { get; set; }

        // بيانات الأسرة
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Address { get; set; }
        public string Wazifa { get; set; }
        public string FatherTel { get; set; }
        public string MotherTel { get; set; }
    }
}
