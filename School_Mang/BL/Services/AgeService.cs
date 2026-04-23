using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services
{
    public class AgeService
    {
        public (int days, int months, int years) CalculateAge(DateTime birthDate, int schoolYear)
        {
            int sana_day = 1;
            int sana_month = 10;
            int sana_year = schoolYear;

            int day = birthDate.Day;
            int month = birthDate.Month;
            int year = birthDate.Year;

            if (year % 4 == 0 && month == 2)
            {
                if (day > 29) return (0, 0, 0);
            }
            else if (year % 4 != 0 && month == 2)
            {
                if (day > 28) return (0, 0, 0);
            }

            switch (month)
            {
                case 4:
                case 6:
                case 9:
                case 11:
                    if (day > 30) return (0, 0, 0);
                    break;
            }

            if (day > 1)
            {
                sana_day += 30;
                sana_month -= 1;
            }

            if (month > 9)
            {
                sana_month += 12;
                sana_year -= 1;
            }

            int new_day = sana_day - day;
            int new_month = sana_month - month;
            int new_year = sana_year - year;

            if (new_month == 12)
            {
                new_month = 0;
                new_year++;
            }

            return (new_day, new_month, new_year);
        }
    }
}