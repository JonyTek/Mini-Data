using System.Reflection;
using MiniData.Core.Attributes;
using MiniData.Core.Helpers;
using MiniData.Core.Util;

namespace MiniData.Core.Extensions
{
    public static class PropertyInfoExtensions
    {
        internal static bool IsNullableType(this PropertyInfo property)
        {
            return property.GetCustomAttribute<NullableAttribute>() != null;
        }

        internal static bool IsAutoIncrement(this PropertyInfo property)
        {
            return property.GetCustomAttribute<AutoIncrementAttribute>() != null ||
                   property.GetCustomAttribute<PrimaryKeyAttribute>() != null;
        }

        internal static bool IsPrimarykey(this PropertyInfo property)
        {
            return property.GetCustomAttribute<PrimaryKeyAttribute>() != null;
        }

        internal static string ToSqlType(this PropertyInfo property)
        {
            var prop = property.GetCustomAttribute<DataTypeAttribute>();

            return prop != null ? string.Format("[{0}]", prop.Type) : SqlTypeMap.GetType(property.PropertyType);
        }
    }
}