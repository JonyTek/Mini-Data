using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.QueryBuilders;

namespace MiniData.Core.Specs.QueryBuilder
{
    [TestClass]
    public class SelectBuilderSpecs
    {
        [TestMethod]
        public void ShouldInsertIndividualColumnNames()
        {
            var builder = new SelectBuilder<Model>();

            builder.Select("Id Name");

            builder.SelectColumns.Count.Should().Be(2);
            builder.SelectColumns.First().Should().Be("Id");
            builder.SelectColumns.Last().Should().Be("Name");
        }

        [TestMethod]
        public void ShouldInsertIndividualColumnNames1()
        {
            var builder = new SelectBuilder<Model>();

            builder.Select("Id", "Name");

            builder.SelectColumns.Count.Should().Be(2);
            builder.SelectColumns.First().Should().Be("Id");
            builder.SelectColumns.Last().Should().Be("Name");
        }

        [TestMethod]
        public void ShouldSetMultipleSelectListThroughExpression()
        {
            var builder = new SelectBuilder<Model>();

            builder.Select(model => model.Id).Select(model => model.Name);

            builder.SelectColumns.Count.Should().Be(2);
            builder.SelectColumns.First().Should().Be("Id");
            builder.SelectColumns.Last().Should().Be("Name");
        }

        [TestMethod]
        public void ShouldReturnCorrectSelectList()
        {
            var builder = new SelectBuilder<Model>();
            builder
                .Select(model => model.Id)
                .Select(model => model.Name);

            builder.ToString().Should().Contain("SELECT [Id], [Name]");
        }

        [TestMethod]
        public void ShouldReturnSelectAll()
        {
            var builder = new SelectBuilder<Model>();

            builder.ToString().Should().Contain("SELECT *");
        }

        [TestMethod]
        public void ShouldReturnSelectAll1()
        {
            var builder = new SelectBuilder<Model>().Select(model => model.All);

            builder.ToString().Should().Contain("SELECT *");
        }
    }
}
