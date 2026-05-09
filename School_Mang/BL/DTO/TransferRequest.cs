using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.DTO
{
    public class TransferRequest
    {
        public string StdCode { get; set; }
        public string ToSchool { get; set; }
        public string GuardianName { get; set; }
        public string Reason { get; set; }
        public string Address { get; set; }

        public int Grade { get; set; }
        public int Year { get; set; }

        public int TransferStatus { get; set; }

        public byte Rosom { get; set; }
        public byte Kotob { get; set; }

        public int TransCode { get; set; }

        public bool IsBeforeChecked { get; set; }
        public bool IsAfterChecked { get; set; }

        public bool IsUpdate { get; set; }
        public bool IsSchoolTransfer { get; set; }

        public bool CurrentYearData { get; set; }
        public bool IsValidStudent { get; set; }
    }
}
