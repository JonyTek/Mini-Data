using System;

namespace MiniData.Core.Exceptions
{
    public class InvalidTypeException : Exception
    {
        public InvalidTypeException(Type type)
            : base(string.Format("iInvalid type: {0}", type.FullName)) { }
    }
}