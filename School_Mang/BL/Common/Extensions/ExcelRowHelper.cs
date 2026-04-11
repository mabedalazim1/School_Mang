using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace School_Mang.BL.Common.Extensions
{
    public static class ExcelRowHelper
    {
        public static string expText = "خطأ في البيانات";
        public static int excelRow = 4;
        public static Action<string> showError = null;
        public static List<string> Errors = new List<string>();
        public static bool ThrowOnError = true;

        private static void HandleError(string col, object value)
        {
            var valStr = value == DBNull.Value ? "NULL" : value?.ToString();
            var msgStr = $"❌ العمود [{col}] - الصف [{excelRow}] - القيمة [{valStr}]";
            Errors.Add(msgStr);
            showError?.Invoke(msgStr);
        }

        // =========================
        // SAFE PARSE HELPERS
        // =========================
        private static double? SafeDouble(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;

            if (double.TryParse(
                Convert.ToString(value, CultureInfo.InvariantCulture),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out double result))
            {
                return result;
            }

            return null;
        }

        // =========================
        // INT (FIXED EXCEL ISSUE)
        // =========================
        public static int GetInt(this DataRow row, string col)
        {
            object value = row[col];

            if (value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()))
            {
                HandleError(col, value);

                if (ThrowOnError)
                    throw new Exception(expText);

                return 0;
            }

            var num = SafeDouble(value);

            if (!num.HasValue)
            {
                HandleError(col, value);

                if (ThrowOnError)
                    throw new Exception(expText);

                return 0;
            }

            return Convert.ToInt32(num.Value);
        }

        // =========================
        // BYTE
        // =========================
        public static byte GetByte(this DataRow row, string col)
        {
            object value = row[col];

            if (value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()))
            {
                HandleError(col, value);

                if (ThrowOnError)
                    throw new Exception(expText);

                return 0;
            }

            var num = SafeDouble(value);

            if (!num.HasValue)
            {
                HandleError(col, value);

                if (ThrowOnError)
                    throw new Exception(expText);

                return 0;
            }

            return Convert.ToByte(num.Value);
        }

        // =========================
        // SHORT
        // =========================
        public static short GetShort(this DataRow row, string col)
        {
            object value = row[col];

            if (value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()))
            {
                HandleError(col, value);

                if (ThrowOnError)
                    throw new Exception(expText);

                return 0;
            }

            var num = SafeDouble(value);

            if (!num.HasValue)
            {
                HandleError(col, value);

                if (ThrowOnError)
                    throw new Exception(expText);

                return 0;
            }

            return Convert.ToInt16(num.Value);
        }

        // =========================
        // STRING (FIXED)
        // =========================

        public static string GetString(this DataRow row, string col, bool allowNull = false)
        {
            object value = row[col];

            if (value == null || value == DBNull.Value)
            {
                if (!allowNull)
                    HandleError(col, value);

                if (ThrowOnError && !allowNull)
                    throw new Exception(expText);

                return null;
            }

            string str = value.ToString().Trim();

            if (string.IsNullOrWhiteSpace(str))
            {
                if (!allowNull)
                    HandleError(col, value);

                if (ThrowOnError && !allowNull)
                    throw new Exception(expText);

                return null;
            }

            return str;
        }
        public static string GetString(this DataRow row, string col)
        {
            return GetString(row, col, false);
        }

        // =========================
        // DATE
        // =========================
        public static DateTime GetDate(this DataRow row, string col)
        {
            object value = row[col];

            if (value == null || value == DBNull.Value)
            {
                HandleError(col, value);
                throw new Exception(expText);
            }

            if (DateTime.TryParse(value.ToString(), out DateTime dt))
                return dt;

            HandleError(col, value);
            throw new Exception(expText);
        }

        // =========================
        // RESET
        // =========================
        public static void Reset()
        {
            Errors.Clear();
            excelRow = 4;
            ThrowOnError = true;
        }
    }
}