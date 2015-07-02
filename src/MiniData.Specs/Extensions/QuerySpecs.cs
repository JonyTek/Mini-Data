using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.QueryBuilder;

namespace MiniData.Specs.Extensions
{
    [TestClass]
    public class QuerySpecs
    {
        [TestMethod]
        public void ShouldCreateWhereTableNameToQuery()
        {
            var query = new Query<Model>().Select("Id").ToString();

            query.Should().Contain("SELECT [Id] FROM [Model]");
        }
    }
}