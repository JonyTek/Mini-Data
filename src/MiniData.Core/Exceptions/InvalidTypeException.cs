using System;

namespace MiniData.Core.Exceptions
{
    public class InvalidTypeException : Exception
    {
        public InvalidTypeException(Type type)
            : base(string.Format("iNVALID TYPE: {0}", type.FullName)) { }
    }
}