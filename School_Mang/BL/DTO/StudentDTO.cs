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
        public DateTime? BirthDate { get; set; }

        // الأكواد
        public int GradeId { get; set; }
        public int YearId { get; set; }
        public int GenderId { get; set; }
        public int ReligionId { get; set; }
        public int NationalityId { get; set; }
        public int OsraId { get; set; }
        public int Sana {  get; set; }
        public int ClassId { get; set; }
        public int StudentStatus { get; set; }
        public int TransferStatus { get; set; }
        public string TransferReason { get; set; }

        // بيانات الأسرة
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Address { get; set; }
        public string Wazifa { get; set; }
        public string FatherTel { get; set; }
        public string MotherTel { get; set; }
        public string FatherLastName { get; set; }
        public string FatherNat { get; set; }
        public int FatherHala { get; set; }
        public string FatherMoahel { get; set; }
        public string FatherWazifa { get; set; }
        public string Tel { get; set; }
        public string FatherMobil_1 { get; set; }
        public string FatherMobil_2 { get; set; }
        public string MotherNat { get; set; }
        public string MotherMoahel { get; set; }
        public string MotherWazifa { get; set; }
        public int MotherHala { get; set; }
        public string MotherMbil_1 { get; set; }
        public string MotherMbil_2 { get; set; }
        public byte WhatsAppSource { get; set; }
        public string Comments { get; set; }
        // User
        public string UserName { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
