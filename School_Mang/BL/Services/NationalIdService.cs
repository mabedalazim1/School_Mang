using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services
{
    public class NationalIdService
    {
        public (int day, int month, int year)? ExtractBirthDate(string nat)
        {
            if (string.IsNullOrWhiteSpace(nat) || nat.Length != 14)
                return null;

            int dd = Convert.ToInt32(nat.Substring(5, 2));
            int mm = Convert.ToInt32(nat.Substring(3, 2));
            int yy = Convert.ToInt32(nat.Substring(1, 2));
            int century = Convert.ToInt32(nat.Substring(0, 1));

            if (century == 3) yy += 2000;
            else if (century == 2) yy += 1900;
            else return null;

            if (mm > 12 || dd > 31)
                return null;

            return (dd, mm, yy);
        }
    }
}