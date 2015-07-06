using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.QueryBuilders;
using MiniData.Core.Specs.Model;

namespace MiniData.Core.Specs.QueryBuilder
{
    [TestClass]
    public class DropBuilderSpecs
    {
        [TestMethod]
        public void ShouldCreateDropQuery()
        {
            var query = new DropBuilder();
           
            query.DropTable<Person>();

            query.ToString().Should().Be("IF OBJECT_ID('dbo.Person', 'U') IS NOT NULL DROP TABLE [dbo].[Person]");
        }
    }
}
