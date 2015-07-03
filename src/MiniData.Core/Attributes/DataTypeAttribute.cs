using System;

namespace MiniData.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataTypeAttribute : Attribute
    {
        internal string Type { get; set; }

        public DataTypeAttribute(string type)
        {
            Type = type;
        }
    }
}
