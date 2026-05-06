using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Common
{
    public static class SchoolFormatter
    {
        public static string ToArabic(long num)
        {
            const string arabicDigits = "۰۱۲۳٤٥٦۷۸۹";

            var str = num.ToString();

            return new string(str.Select(c =>
                char.IsDigit(c) ? arabicDigits[c - '0'] : c
            ).ToArray());

        }
        public static string Year_Desc(
                                        int myYear,
                                        bool currentYearData = false,
                                        bool detailsStd = false,
                                        bool elthakNextYear = false)
        {
            string desc = " العام الدراسى ";

            // override الأول
            if (currentYearData == false)
            {
                desc += ToArabic(myYear) + " - " +
                        ToArabic(myYear + 1);
                return desc;
            }

            // السلوك القديم
            if (detailsStd || elthakNextYear)
            {
                desc += ToArabic(myYear - 1) + " - " +
                        ToArabic(myYear);
            }
            else
            {
                desc += ToArabic(myYear - 1) + " - " +
                        ToArabic(myYear);
            }

            return desc;
        }
    }
}