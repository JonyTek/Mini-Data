using System;

namespace MiniData.Core.Helpers
{
    internal static class WhereValueFormatter
    {
        internal static string Format<T>(T value)
        {
            switch (typeof (T).FullName)
            {
                case "System.String":
                case "System.Guid":
                {
                    return string.Format("'{0}'", value);
                }
                case "System.DateTime":
                {
                    var date = DateTime.Parse(value.ToString());
                    
                    return string.Format("'{0}'", date.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                default:
                {
                    return value.ToString();
                }
            }
        }
    }
}