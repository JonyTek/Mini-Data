using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.Model;
using MiniData.Core.QueryBuilders;

namespace MiniData.Core.Specs.QueryBuilder
{
    [TestClass]
    public class WhereBuilderSpecs
    {
        [TestMethod]
        public void ShouldCreateLikeWhereQuery()
        {
            var builder =
                new WhereBuilder<Model>()
                    .Where(model => model.Name, new Like<string>("%JONY"))
                    .ToString();

            builder.Should().Be("WHERE [Name] LIKE '%JONY'");
        }

        [TestMethod]
        public void ShouldCreateEqualsWhereQuery()
        {
            var builder =
                new WhereBuilder<Model>()
                    .Where("Id", new Equals<int>(1))
                    .ToString();

            builder.Should().Be("WHERE [Id] = 1");
        }

        [TestMethod]
        public void ShouldCreateNotEqualsWhereQuery()
        {
            var builder =
                new WhereBuilder<Model>()
                    .Where("Id", new NotEquals<int>(1))
                    .ToString();

            builder.Should().Be("WHERE [Id] != 1");
        }

        [TestMethod]
        public void ShouldCreateGreaterThenWhereQuery()
        {
            var builder =
                new WhereBuilder<Model>()
                    .Where("Id", new GreaterThen<int>(1))
                    .ToString();

            builder.Should().Be("WHERE [Id] > 1");
        }

        [TestMethod]
        public void ShouldCreateGreatenEqualThenWhereQuery()
        {
            var builder =
                new WhereBuilder<Model>()
                    .Where("Id", new GreaterEqualThen<int>(1))
                    .ToString();

            builder.Should().Be("WHERE [Id] >= 1");
        }

        [TestMethod]
        public void ShouldCreateLessThenWhereQuery()
        {
            var builder =
                new WhereBuilder<Model>()
                    .Where("Id", new LessThen<int>(1))
                    .ToString();

            builder.Should().Be("WHERE [Id] < 1");
        }

        [TestMethod]
        public void ShouldCreateLessEqualThenWhereQuery()
        {
            var builder =
                new WhereBuilder<Model>()
                    .Where("Id", new LessEqualThen<int>(1))
                    .ToString();

            builder.Should().Be("WHERE [Id] <= 1");
        }

        [TestMethod]
        public void ShouldCreateIsNullWhereQuery()
        {
            var builder =
                new WhereBuilder<Model>()
                    .Where("Id", new IsNull<int>())
                    .ToString();

            builder.Should().Be("WHERE [Id] IS NULL");
        }

        [TestMethod]
        public void ShouldCreateIsNotNullWhereQuery()
        {
            var builder =
                new WhereBuilder<Model>()
                    .Where("Id", new IsNotNull<int>())
                    .ToString();

            builder.Should().Be("WHERE [Id] IS NOT NULL");
        }

        [TestMethod]
        public void ShouldCreateAndWhereQuery()
        {
            var builder =
                new WhereBuilder<Model>()
                    .Where("Id", new IsNotNull<int>())
                    .AndWhere("Id", new IsNull<int>())
                    .ToString();

            builder.Should().Be("WHERE ([Id] IS NOT NULL AND [Id] IS NULL)");
        }

        [TestMethod]
        public void ShouldCreateOrWhereQuery()
        {
            var builder = new WhereBuilder<Model>()
                .Where("Id", new IsNotNull<int>())
                .OrWhere("Id", new IsNull<int>())
                .ToString();

            builder.Should().Be("WHERE ([Id] IS NOT NULL OR [Id] IS NULL)");
        }
    }
}