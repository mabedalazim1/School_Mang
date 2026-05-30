using System;

namespace School_Mang.BL.Extensions
{
    public static class EnumExtensions
    {
        public static bool Has<T>(this T value, T flag) where T : Enum
        {
            var v = Convert.ToInt64(value);
            var f = Convert.ToInt64(flag);
            return (v & f) != 0;
        }
    }
}