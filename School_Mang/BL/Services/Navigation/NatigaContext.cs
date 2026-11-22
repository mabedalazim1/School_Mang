using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.Navigation
{
    public class NatigaContext
    {
        public bool KoshofRasd { get; set; }
        public bool EditGolos { get; set; }
        public int TestGradeId { get; set; }
        public int StudentGolos { get; set; }
        public byte FinalTestKind { get; set; }
        public string FinalTestName { get; set; }
        public bool AmalSana { get; set; }
        public bool FinalTest { get; set; }
        public bool FinalKoshof { get; set; }
        public bool FinalNataga { get; set; }
        public bool AhsaaEdara { get; set; }
        public bool DelAssessmentData { get; set; }

        public int TestKind { get; set; }
        public int TestMonth { get; set; }
        public string TestMonthName { get; set; }
    }
}
