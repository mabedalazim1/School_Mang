using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Common
{
    public static class SchoolDateHelper
    {
        public static int GetCurrentYear(int yearCod, NavigationContext context)
        {
            // override الأول
            if (context?.CurrentYearData == false)
                return yearCod + 1;

            // السلوك القديم
            if (context?.StudentCase.HasFlag(GetStudentCase.StudentDetails) == true ||
                context?.StudentCase.HasFlag(GetStudentCase.ElthakStdNextYear) == true)
            {
                return yearCod;
            }

            return yearCod;
        }
    }
}
