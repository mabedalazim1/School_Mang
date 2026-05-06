using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services
{
    public static class AgeService
    {
        public class AgeResult
        {
            public int Days { get; set; }
            public int Months { get; set; }
            public int Years { get; set; }
        }

        public class NatAgeResult
        {
            public int Days { get; set; }
            public int Months { get; set; }
            public int Years { get; set; }

            public int BirthDay { get; set; }
            public int BirthMonth { get; set; }
            public int BirthYear { get; set; }
            public string BirthDate =>
                $"{BirthYear:0000}-{BirthMonth:00}-{BirthDay:00}";
        }
        public static AgeResult CalculateAge(int day, int month, int year, int sana)
        {
            int new_day;
            int new_month;
            int new_year;
            int sana_day = 1;
            int sana_month = 10;
            int sana_year = sana;

            try

            {
                if (year % 4 == 0 && month == 2)
                {
                    if (day > 29)
                    {
                        throw new Exception("تأكد من اليوم");
                    }
                }
                else if (year % 4 != 0 && month == 2)
                {
                    if (day > 28)
                    {
                        throw new Exception("تأكد من اليوم");
                    }
                }

                switch (month)
                {
                    case 4:
                    case 6:
                    case 9:
                    case 11:

                        if (day > 30)
                        {
                            throw new Exception("تأكد من اليوم");
                        }
                        break;
                }

                if (day > 1)
                {
                    sana_day += 30;
                    sana_month --;

                }

                // تحويل السنة الدراسية *** تبدأ من أكتوبر

                if (month > 9)
                {
                    sana_month += 12;
                    sana_year --;
                }

                new_day = sana_day - day;
                new_month = sana_month - month;
                new_year = sana_year - year;

                if (new_year < 0)
                {
                    throw new Exception("العمر غير مناسب للسنة الدراسية الحالية");
                }

                if (new_month == 12)
                {
                    new_month = 0;
                    new_year = new_year + 1;
                }

                int totalMonths = (new_year * 12) + new_month;
                int minAllowedMonths = (3 * 12) + 6;

                // أقل من السن
                if (totalMonths < minAllowedMonths)
                {
                    throw new Exception("العمر أقل من 3 سنوات ونصف وغير مقبول");
                }
                return new AgeResult
                {
                    Days = new_day,
                    Months = new_month,
                    Years = new_year
                };


            }
            catch (Exception)
            {
                throw;
            }
        }

        public static NatAgeResult NatAgeHesabSen(string nat, int sana)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nat) || nat.Length != 14)
                    throw new Exception("الرقم القومى غير صحيح");

                string txt = nat;

                // =========================
                // قراءة الرقم القومي (الصحيح)
                // =========================
                int century = int.Parse(txt.Substring(0, 1));   // 2 أو 3
                int yy = int.Parse(txt.Substring(1, 2));        // سنة الميلاد
                int mm = int.Parse(txt.Substring(3, 2));        // الشهر
                int dd = int.Parse(txt.Substring(5, 2));        // اليوم

                // =========================
                // validation يوم / شهر
                // =========================
                if (dd < 1 || dd > 31)
                    throw new Exception("الرقم القومى خطأ .. تأكد من اليوم");

                if (mm < 1 || mm > 12)
                    throw new Exception("الرقم القومى خطأ .. تأكد من الشهر");

                // =========================
                // تحويل السنة الكاملة
                // =========================
                int fullYear = (century == 2) ? 1900 + yy : 2000 + yy;

                // =========================
                // validation السنة
                // =========================

                if (fullYear > sana || century > 3)
                    throw new Exception("الرقم القومى خطأ .. تأكد من السنة");

                if (century < 2 || century > 3)
                    throw new Exception("الرقم القومى غير صحيح");

                // =========================
                // حساب العمر
                // =========================
                var hes = CalculateAge(dd, mm, fullYear, sana);
                return new NatAgeResult
                {
                    BirthDay = dd,
                    BirthMonth = mm,
                    BirthYear = fullYear,

                    Days = hes.Days,
                    Months = hes.Months,
                    Years = hes.Years
                }; 
            }
            catch
            {
                throw;
            }
        }
    }
}