using School_Mang.BL.STD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.STD
{
    public static class SchoolYearService
    {
        public static int GetCalculationYear(int yearId)
        {
            GetDataService _getData = new GetDataService();
            var dt = _getData.Get_Year_By_Id(yearId);

            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("السنة الدراسية غير موجودة");

            return Convert.ToInt32(dt.Rows[0]["Year"]) - 1;
        }
    }
}