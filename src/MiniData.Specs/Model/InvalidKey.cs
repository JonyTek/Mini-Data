using MiniData.Core.Attributes;
using MiniData.Core.Model;

namespace MiniData.Core.Specs.Model
{
    public class InvalidKey : IDbTable
    {
        [PrimaryKey]
        public string Key { get; set; }
    }
}