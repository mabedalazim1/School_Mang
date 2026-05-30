using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Common.Helper
{
    public static class SafeConverter
    {
        public static int GetInt(object value, int defaultValue = 0)
        {
            if (value == null || value == DBNull.Value || value.ToString() == "")
                return defaultValue;

            return int.TryParse(value.ToString(), out int result)
                ? result
                : defaultValue;
        }
    }
}
