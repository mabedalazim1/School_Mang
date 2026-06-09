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
        public static string GetString(object value)
        {
            return value == DBNull.Value || value == null
                ? string.Empty
                : value.ToString();
        }
        public static DateTime? GetDateTimeNullable(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;

            if (DateTime.TryParse(value.ToString(), out DateTime result))
                return result;

            return null;
        }
    }
}
