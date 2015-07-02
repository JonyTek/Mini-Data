using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.QueryBuilder;

namespace MiniData.Specs.QueryBuilder
{
    [TestClass]
    public class SelectBuilderSpecs
    {
        [TestMethod]
        public void ShouldInsertIndividualColumnNames()
        {
            var query = new Query<Model>();

            query.Select("Id Name");

            query.SelectColumns.Count.Should().Be(2);
            query.SelectColumns.First().Should().Be("Id");
            query.SelectColumns.Last().Should().Be("Name");
        }

        [TestMethod]
        public void ShouldInsertIndividualColumnNames1()
        {
            var query = new Query<Model>();

            query.Select("Id", "Name");

            query.SelectColumns.Count.Should().Be(2);
            query.SelectColumns.First().Should().Be("Id");
            query.SelectColumns.Last().Should().Be("Name");
        }

        [TestMethod]
        public void ShouldSetMultipleSelectListThroughExpression()
        {
            var query = new Query<Model>();

            query.Select(model => model.Id).Select(model => model.Name);

            query.SelectColumns.Count.Should().Be(2);
            query.SelectColumns.First().Should().Be("Id");
            query.SelectColumns.Last().Should().Be("Name");
        }

        [TestMethod]
        public void ShouldReturnCorrectSelectList()
        {
            var query = new Query<Model>();
            query
                .Select(model => model.Id)
                .Select(model => model.Name);

            query.ToString().Should().Contain("SELECT [Id], [Name]");
        }

        [TestMethod]
        public void ShouldReturnSelectAll()
        {
            var query = new Query<Model>();

            query.ToString().Should().Contain("SELECT *");
        }

        [TestMethod]
        public void ShouldReturnSelectAll1()
        {
            var query = new Query<Model>().Select(model => model.All);

            query.ToString().Should().Contain("SELECT *");
        }
    }
}
