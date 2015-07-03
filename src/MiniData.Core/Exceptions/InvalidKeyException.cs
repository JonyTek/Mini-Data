using System;

namespace MiniData.Core.Exceptions
{
    public class InvalidKeyException : Exception
    {
         public InvalidKeyException()
            : base("Key must be of type System.Int32") { }
    }
}