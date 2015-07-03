using System;
using MiniData.Core.Exceptions;
using MiniData.Core.Extensions;

namespace MiniData.Core.Helpers
{
    internal static class SqlTypeMap
    {
        internal static string GetType(Type type)
        {
            if (string.Equals(0.GetFullName(), type.FullName))
                return "[int]";
            if (string.Equals("".GetFullName(), type.FullName))
                return "[varchar](max)";

            throw new InvalidTypeException(type);
        }
    }
}