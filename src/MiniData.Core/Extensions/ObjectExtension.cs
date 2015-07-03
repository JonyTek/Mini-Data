using System.Collections.Generic;
using System.Reflection;

namespace MiniData.Core.Extensions
{
    public static class ObjectExtension
    {
        internal static IEnumerable<PropertyInfo> GetProperties(this object obj)
        {
            return obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
        }
    }
}