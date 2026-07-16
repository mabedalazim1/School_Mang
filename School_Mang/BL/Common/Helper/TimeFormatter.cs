using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Common.Helper
{
    public static class TimeFormatter
    {
        public static string FormatElapsed(TimeSpan elapsed)
        {
            if (elapsed.TotalMinutes < 1)
                return "أقل من دقيقة";

            if (elapsed.TotalHours < 1)
                return $"{(int)elapsed.TotalMinutes} دقيقة";

            if (elapsed.TotalDays < 1)
            {
                int hours = (int)elapsed.TotalHours;
                int minutes = elapsed.Minutes;

                return minutes == 0
                    ? $"{hours} ساعة"
                    : $"{hours} ساعة و {minutes} دقيقة";
            }

            int days = (int)elapsed.TotalDays;
            int remainingHours = elapsed.Hours;

            return remainingHours == 0
                ? $"{days} يوم"
                : $"{days} يوم و {remainingHours} ساعة";
        }
    }
}
