using System;
using System.Data;

namespace FishHoghoghi.Extensions
{
    public static class DataRowExtension
    {
        private static object GetValue(this DataRow dataRow, string name)
        {
            try
            {
                return dataRow[name];
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public static string GetValueString(this DataRow dataRow, string name)
        {
            var value = dataRow.GetValue(name);

            if (value == null)
                return string.Empty;

            return value.ToString();
        }

        public static decimal GetValueNumber(this DataRow dataRow, string name)
        {
            var value = dataRow.GetValue(name);

            if (value == null)
                return 0;

            return Convert.ToInt64(value);
        }

        public static decimal GetDecimalValue(this DataRow dataRow, string name)
        {
            var value = dataRow.GetValue(name);

            if (value == null)
                return 0;

            return Convert.ToDecimal(value);
        }

        public static decimal GetDecimalValue(this DataRow dataRow, string name, out decimal result)
        {
            result = dataRow.GetDecimalValue(name);

            return result;
        }
    }
}