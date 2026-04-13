using System;
using System.Data;
using System.Data.SqlClient;

public static class SqlParam
{
    public static SqlParameter Int(string name, int? value)
        => new SqlParameter(name, SqlDbType.Int)
        {
            Value = value ?? (object)DBNull.Value
        };

    // =========================
    // BYTE -> TinyInt
    // =========================
    public static SqlParameter Byte(string name, byte? value)
        => new SqlParameter(name, SqlDbType.TinyInt)
        {
            Value = value ?? (object)DBNull.Value
        };

    // =========================
    // SHORT -> SmallInt (مهم جداً للدرجات أحياناً)
    // =========================
    public static SqlParameter Short(string name, short? value)
        => new SqlParameter(name, SqlDbType.SmallInt)
        {
            Value = value ?? (object)DBNull.Value
        };

    public static SqlParameter NVar(string name, string value, int size = 255)
        => new SqlParameter(name, SqlDbType.NVarChar, size)
        {
            Value = string.IsNullOrWhiteSpace(value)
                ? (object)DBNull.Value
                : value
        };

    public static SqlParameter Bit(string name, bool? value)
        => new SqlParameter(name, SqlDbType.Bit)
        {
            Value = value ?? (object)DBNull.Value
        };

    public static SqlParameter Date(string name, DateTime? value)
        => new SqlParameter(name, SqlDbType.DateTime)
        {
            Value = value ?? (object)DBNull.Value
        };

    public static SqlParameter Float(string name, decimal? value)
    => new SqlParameter(name, SqlDbType.Float)
    {
        Value = value ?? (object)DBNull.Value
    };
    public static SqlParameter Decimal(string name, decimal? value, byte precision = 18, byte scale = 2)
    => new SqlParameter(name, SqlDbType.Decimal)
    {
        Precision = precision,
        Scale = scale,
        Value = value ?? (object)DBNull.Value
    };

    public static SqlParameter Tiny(string name, bool? value)
    => new SqlParameter(name, SqlDbType.TinyInt)
    {
        Value = value.HasValue
            ? (value.Value ? 1 : 0)
            : (object)DBNull.Value
    };
    public static SqlParameter Decimal(string name, decimal? value)
        => new SqlParameter(name, SqlDbType.Decimal)
        {
            Value = value ?? (object)DBNull.Value
        };
}