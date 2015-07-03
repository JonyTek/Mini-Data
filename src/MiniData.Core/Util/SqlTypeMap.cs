using System;
using MiniData.Core.Exceptions;

namespace MiniData.Core.Util
{
    internal static class SqlTypeMap
    {
        internal static string GetType(Type type)
        {
            if (string.Equals(typeof(int).FullName, type.FullName))
                return "[int]";
            if (string.Equals(typeof(Int16).FullName, type.FullName))
                return "[smallint]";
            if (string.Equals(typeof(Int64).FullName, type.FullName))
                return "[bigint]";
            if (string.Equals(typeof(string).FullName, type.FullName))
                return "[varchar](max)";
            if (string.Equals(typeof(DateTime).FullName, type.FullName))
                return "[datetime]";
            if (string.Equals(typeof(Guid).FullName, type.FullName))
                return "[uniqueidentifier]";
            if (string.Equals(typeof(bool).FullName, type.FullName))
                return "[bit]";
            if (string.Equals(typeof(float).FullName, type.FullName))
                return "[float]";
            if (string.Equals(typeof(decimal).FullName, type.FullName))
                return "[decimal(18, 0)]";
            if (string.Equals(typeof(char).FullName, type.FullName))
                return "[char(10)]";

            throw new InvalidTypeException(type);
        }
    }
}