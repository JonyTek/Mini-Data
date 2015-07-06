using System;
using System.Reflection;

namespace MiniData.Core.Util
{
    internal static class SqlTypeFormatter
    {
        internal static string Format<T>(T value)
        {
            switch (typeof(T).FullName)
            {
                case "System.String":
                case "System.Guid":
                    return string.Format("'{0}'", value);
                case "System.DateTime":
                    {
                        var date = DateTime.Parse(value.ToString());

                        return string.Format("'{0}'", date.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                default:
                    return value.ToString();
            }
        }

        internal static string Format<T>(PropertyInfo property, T obj)
        {
            switch (property.PropertyType.FullName)
            {
                case "System.String":
                case "System.Guid":
                    return string.Format("'{0}'", property.GetValue(obj));
                case "System.DateTime":
                    {
                        var date = DateTime.Parse(obj.ToString());

                        return string.Format("'{0}'", date.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                default:
                    return obj.ToString();
            }
        }
    }
}