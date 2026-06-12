using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Models
{
    public class TransferData
    {
        public string StudentName { get; set; }
        public string TransferCode { get; set; }

        public int GradeId { get; set; }

        public int YearId { get; set; }

        public byte TransferStatus { get; set; }
        public byte TransferSavedStatus {  get; set; }
    }
   
}
