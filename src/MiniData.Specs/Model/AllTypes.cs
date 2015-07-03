using MiniData.Core.Attributes;

namespace MiniData.Core.Specs.Model
{
    public class AllTypes
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Null]
        public string Name { get; set; }
    }
}