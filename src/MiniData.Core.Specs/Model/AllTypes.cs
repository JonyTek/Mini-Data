using System;
using MiniData.Core.Attributes;

namespace MiniData.Core.Specs.Model
{
    public class AllTypes
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Nullable]
        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public Guid Guid { get; set; }

        public bool Boolean { get; set; }

        public float Float { get; set; }

        public decimal Decimal { get; set; }

        public char Char { get; set; }

        public Int16 Int16 { get; set; }

        public Int64 Int64 { get; set; }

        [Nullable]
        [AutoIncrement]
        [DataType("varchar(50)")]
        public string Custom { get; set; }
    }
}