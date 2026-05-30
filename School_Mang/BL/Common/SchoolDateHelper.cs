using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using School_Mang.BL.Extensions;


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
            if (context?.StudentCase.Has(GetStudentCase.StudentDetails) == true ||
                context?.StudentCase.Has(GetStudentCase.ElthakStdNextYear) == true)
            {
                return yearCod;
            }

            return yearCod;
        }
    }
}
