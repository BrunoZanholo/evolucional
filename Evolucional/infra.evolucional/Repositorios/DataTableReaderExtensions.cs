using System;
using System.Data;

namespace infra.evolucional.Repositorios
{
    internal static class DataTableReaderExtensions
    {
        internal static bool IsNull(this DataTableReader reader, string key)
        {
            return (reader[key] == DBNull.Value);
        }

        internal static Guid Guid(this DataTableReader reader, string key)
        {
            return ((IsNull(reader, key)) ? System.Guid.Empty : System.Guid.Parse(reader[key].ToString()));
        }

        internal static int Int(this DataTableReader reader, string key)
        {
            return ((IsNull(reader, key)) ? 0 : Convert.ToInt32(reader[key]));
        }

        internal static int? IntNullable(this DataTableReader reader, string key, int? ifNull = null)
        {
            return ((IsNull(reader, key)) ? ifNull : Convert.ToInt32(reader[key]));
        }

        internal static bool Bool(this DataTableReader reader, string key, bool ifNull = false)
        {
            return ((IsNull(reader, key)) ? ifNull : Convert.ToBoolean(reader[key]));
        }

        internal static bool? BoolNullable(this DataTableReader reader, string key, bool? ifNull = null)
        {
            return ((IsNull(reader, key)) ? ifNull : Convert.ToBoolean(reader[key]));
        }

        internal static string String(this DataTableReader reader, string key)
        {
            return ((IsNull(reader, key)) ? string.Empty : reader[key].ToString().Trim());
        }

        internal static string StringNullable(this DataTableReader reader, string key, string ifNull = null)
        {
            return ((IsNull(reader, key)) ? ifNull : reader[key].ToString().Trim());
        }

        internal static decimal Decimal(this DataTableReader reader, string key)
        {
            return ((IsNull(reader, key)) ? 0M : Convert.ToDecimal(reader[key]));
        }

        internal static decimal? DecimalNullable(this DataTableReader reader, string key, decimal? ifNull = null)
        {
            return ((IsNull(reader, key)) ? ifNull : Convert.ToDecimal(reader[key]));
        }

        internal static DateTime Datetime(this DataTableReader reader, string key)
        {
            return (DateTime.SpecifyKind(((IsNull(reader, key)) ? DateTime.MinValue : Convert.ToDateTime(reader[key])), DateTimeKind.Local));
        }

        internal static DateTime? DatetimeNullable(this DataTableReader reader, string key, DateTime? ifNull = null)
        {
            return ((IsNull(reader, key)) ? (ifNull != null ? DateTime.SpecifyKind(ifNull.Value, DateTimeKind.Local) : ifNull) : DateTime.SpecifyKind(Convert.ToDateTime(reader[key]), DateTimeKind.Local));
        }
    }
}