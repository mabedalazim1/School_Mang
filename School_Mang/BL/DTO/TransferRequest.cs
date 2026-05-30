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

    public class DeleteTransferRequest
    {
        public string StdCode { get; set; }
        public string StdName { get; set; }
        public int ClassId { get; set; }
        public int GradeId { get; set; }
        public int Year { get; set; }
        public int TransferCode { get; set; }
        public int CurrentYear { get; set; }
        public bool TransAfterYear { get; set; }
        public int StatusId { get; set; }
    }
    public class TransferEditData
    {
        public string TransferCode { get; set; }
        public string StdName { get; set; }
        public string StdCode { get; set; }
        public string GuardianName { get; set; }
        public string Address { get; set; }
        public string Reason { get; set; }
        public string ToSchool { get; set; }

        public byte Resom { get; set; }
        public byte Kotob { get; set; }

        public int StatusId { get; set; }
        public int GradeId { get; set; }
    }
    public class TransferReportData
    {
        public string StudentName { get; set; }

        public string TransferCode { get; set; }

        public string ToSchoolYearDesc { get; set; }

        public string FromSchoolYearDesc { get; set; }

        public string GradeDesc { get; set; }

        public byte TransferSavedStatus { get; set; }
    }
}
