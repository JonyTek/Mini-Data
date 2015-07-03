using MiniData.Core.Attributes;
using MiniData.Core.Model;

namespace MiniData.Core.Specs.Model
{
    public class Model : DbTable
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        [Nullable]
        public int? Nullable { get; set; }
    }
}