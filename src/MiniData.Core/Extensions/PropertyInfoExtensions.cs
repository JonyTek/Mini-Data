using System.Reflection;
using MiniData.Core.Attributes;
using MiniData.Core.Helpers;

namespace MiniData.Core.Extensions
{
    public static class PropertyInfoExtensions
    {
        internal static bool IsNullableType(this PropertyInfo property)
        {
            return property.GetCustomAttribute<NullAttribute>() != null;
        }

        internal static bool IsAutoIncrement(this PropertyInfo property)
        {
            return property.GetCustomAttribute<AutoIncrementAttribute>() != null ||
                   property.GetCustomAttribute<PrimaryKeyAttribute>() != null;
        }

        internal static string ToSqlType(this PropertyInfo property)
        {
            return SqlTypeMap.GetType(property.PropertyType);
        }
    }
}