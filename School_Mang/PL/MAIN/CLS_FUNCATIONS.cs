using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.PL.MAIN
{
    class CLS_FUNCATIONS
    {
        BL.MSG msg = new BL.MSG();
        public string ToArabic(long num)
        {
            const string _arabicDigits = "۰۱۲۳٤٥٦۷۸۹";
            try
            {
               
                return new string(num.ToString().Select(c => _arabicDigits[c - '0']).ToArray());
            }
            catch(Exception e)
            {
                msg.ErrorMesg(e.Message);
                return num.ToString();
            }
        
        }

        // Get Year Desc
        public string Year_Desc()
        {
            string desc = " العام الدراسى ";
            if (BL.Globals.Current_Year_Data || BL.Globals.Details_Std)
            {
                desc += ToArabic(
                    Properties.Settings.Default.MyYear - 1) + " - " +
                    ToArabic(Properties.Settings.Default.MyYear);
                return desc;
            }
            else
            {
                desc += ToArabic(
                     Properties.Settings.Default.MyYear) + " - " +
                     ToArabic(Properties.Settings.Default.MyYear + 1);
                return desc;
            }

        }
    }
}
