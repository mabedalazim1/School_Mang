using School_Mang.BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Common.Extensions
{
    public static class StudentCaseExtensions
    {
        public static bool IsElthak(this GetStudentCase c)
        => c.HasFlag(GetStudentCase.ElthakStd)
        || c.HasFlag(GetStudentCase.ElthakStdNextYear);

        public static bool IsDetails(this GetStudentCase c)
            => c.HasFlag(GetStudentCase.StudentDetails);

        public static bool IsNextYearElthak(this GetStudentCase c)
            => c.HasFlag(GetStudentCase.ElthakStdNextYear);
        public static bool IsDegreeStatement(this GetStudentCase c)
            => c.HasFlag(GetStudentCase.DegreeStatement);
    }
}
