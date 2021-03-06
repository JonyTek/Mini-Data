﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.Model;
using MiniData.Core.Queries;

namespace MiniData.Core.Specs.Queries
{
    [TestClass]
    public class QuerySpecs
    {
        [TestMethod]
        public void ShouldCreateWhereTableNameToQuery()
        {
            var query = new SelectQuery<Model.Model>().Select("Id").ToString();

            query.Should().Contain("SELECT [Id] FROM [Model]");
        }


        [TestMethod]
        public void ShouldCreateLikeWhereQuery()
        {
            var query =
                new SelectQuery<Model.Model>().Select(model => model.Name)
                    .Where(model => model.Name, new Like<string>("%JONY"))
                    .ToString();

            query.Should().Be("SELECT [Name] FROM [Model] WHERE [Name] LIKE '%JONY'");
        }

        [TestMethod]
        public void ShouldCreateEqualsWhereQuery()
        {
            var query = new SelectQuery<Model.Model>().Select("Id").Where("Id", new Equals<int>(1)).ToString();

            query.Should().Be("SELECT [Id] FROM [Model] WHERE [Id] = 1");
        }

        [TestMethod]
        public void ShouldCreateNotEqualsWhereQuery()
        {
            var query = new SelectQuery<Model.Model>().Select("Id").Where("Id", new NotEquals<int>(1)).ToString();

            query.Should().Be("SELECT [Id] FROM [Model] WHERE [Id] != 1");
        }

        [TestMethod]
        public void ShouldCreateGreaterThenWhereQuery()
        {
            var query = new SelectQuery<Model.Model>().Select("Id").Where("Id", new GreaterThen<int>(1)).ToString();

            query.Should().Be("SELECT [Id] FROM [Model] WHERE [Id] > 1");
        }

        [TestMethod]
        public void ShouldCreateGreatenEqualThenWhereQuery()
        {
            var query = new SelectQuery<Model.Model>().Select("Id").Where("Id", new GreaterEqualThen<int>(1)).ToString();

            query.Should().Be("SELECT [Id] FROM [Model] WHERE [Id] >= 1");
        }

        [TestMethod]
        public void ShouldCreateLessThenWhereQuery()
        {
            var query = new SelectQuery<Model.Model>().Select("Id").Where("Id", new LessThen<int>(1)).ToString();

            query.Should().Be("SELECT [Id] FROM [Model] WHERE [Id] < 1");
        }

        [TestMethod]
        public void ShouldCreateLessEqualThenWhereQuery()
        {
            var query = new SelectQuery<Model.Model>().Select("Id").Where("Id", new LessEqualThen<int>(1)).ToString();

            query.Should().Be("SELECT [Id] FROM [Model] WHERE [Id] <= 1");
        }

        [TestMethod]
        public void ShouldCreateIsNullWhereQuery()
        {
            var query = new SelectQuery<Model.Model>().Select("Id").Where("Id", new IsNull<int>()).ToString();

            query.Should().Be("SELECT [Id] FROM [Model] WHERE [Id] IS NULL");
        }

        [TestMethod]
        public void ShouldCreateIsNotNullWhereQuery()
        {
            var query = new SelectQuery<Model.Model>().Select("Id").Where("Id", new IsNotNull<int>()).ToString();

            query.Should().Be("SELECT [Id] FROM [Model] WHERE [Id] IS NOT NULL");
        }

        [TestMethod]
        public void ShouldCreateAndWhereQuery()
        {
            var query =
                new SelectQuery<Model.Model>().Select("Id")
                    .Where("Id", new IsNotNull<int>())
                    .AndWhere("Id", new IsNull<int>())
                    .ToString();

            query.Should().Be("SELECT [Id] FROM [Model] WHERE ([Id] IS NOT NULL AND [Id] IS NULL)");
        }

        [TestMethod]
        public void ShouldCreateOrWhereQuery()
        {
            var query = new SelectQuery<Model.Model>()
                .Select("Id")
                .Where("Id", new IsNotNull<int>())
                .OrWhere("Id", new IsNull<int>())
                .ToString();

            query.Should().Be("SELECT [Id] FROM [Model] WHERE ([Id] IS NOT NULL OR [Id] IS NULL)");
        }
    }
}