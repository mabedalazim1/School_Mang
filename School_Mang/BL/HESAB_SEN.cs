using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.BL;

namespace School_Mang.BL
{
    class HESAB_SEN
    {
        public string[] HesabSen(int day, int month, int year,int sana)
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
                        MSG.ErrorMesg(" تأكد من اليوم");
                        return null;
                    }
                }
                else if (year % 4 != 0 && month == 2)
                {
                    if (day > 28)
                    {
                        MSG.ErrorMesg("تأكد من اليوم ");
                        return null;
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
                            MSG.ErrorMesg("تأكد من اليوم");
                            return null ;
                        }
                        break;

                }

                if (day > 1)
                {
                    sana_day = sana_day + 30;
                    sana_month = sana_month - 1;

                }
                if (month > 9)
                {
                    sana_month = sana_month + 12;
                    sana_year = sana_year - 1;
                }
                new_day = sana_day - day;
                new_month = sana_month - month;
                new_year = sana_year - year;
                if (new_month == 12)
                {
                    new_month = 0;
                    new_year = new_year + 1;
                }

                string dd = Convert.ToString(new_day);
                string mm = Convert.ToString(new_month);
                string yy = Convert.ToString(new_year);
                string[] dat = { dd, mm, yy };

                return dat;
            

            }catch(Exception e)
            {
                MSG.ErrorMesg(e.Message);
                return null;
            }
        }
           

        public string[] Nat_HesabSen(string nat, int sana)
        {
            string newday ="00";
            string newmounth ="00";
            string newsanaa="00";
            string day = "00";
            string mounth = "00";
            string year = "00";

            try
            {

                if (nat != null)
                {
                   
                    if (nat.Length == 14)
                    {
                        string txt = nat.ToString();
                        int dd = Convert.ToInt32(txt.Substring(5, 2));
                        if (dd > 31)
                        {
                            MSG.ErrorMesg(" الرقم القومى خطأ .. تأكد من اليوم");
                            return null;

                        };
                        int mm = Convert.ToInt32(txt.Substring(3, 2));
                        if (mm > 12)
                        {
                            MSG.ErrorMesg("الرقم القومى خطأ .. تأكد من الشهر");
                            return null;

                        };
                        int yy = Convert.ToInt32(txt.Substring(1, 2));
                        int last = Convert.ToInt32(txt.Substring(0, 1));
                        if(yy+2000 > sana && last == 3  || yy + 1900 > sana && last == 2 || last >3)
                        {
                            MSG.ErrorMesg("الرقم القومى خطأ .. تأكد من السنة");
                            return null;
                        }
                        if (last > 2)
                        {
                            yy = yy + 2000;
                        }
                        else if(last == 2)
                        {
                            yy = yy + 1900;
                        }
                        day = Convert.ToString(dd);
                        mounth = Convert.ToString(mm);
                        year = Convert.ToString(yy);
                        newday = HesabSen(dd, mm, yy, sana)[0].ToString();
                        newmounth = HesabSen(dd, mm, yy, sana)[1];
                        newsanaa = HesabSen(dd, mm, yy, sana)[2];

                    }
                    else
                    {
                        MSG.ErrorMesg();
                        return null;

                    }
                }

                string[] dat = { newday, newmounth, newsanaa, day,mounth,year };
                return dat;
            }catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
                return null;
            }
        }
        public int Chack_Type(TextBox txt)
        {
            if(txt.Text.Length != 14)
            {
                MSG.ErrorMesg();
                return -1;
            }
            // Chack Type
            int type = Convert.ToInt32(txt.Text.Substring(12, 1));

            if(type%2== 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
