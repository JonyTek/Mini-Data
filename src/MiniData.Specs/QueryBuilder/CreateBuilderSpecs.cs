using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.Exceptions;
using MiniData.Core.Extensions;
using MiniData.Core.QueryBuilders;
using MiniData.Core.Specs.Model;

namespace MiniData.Core.Specs.QueryBuilder
{
    [TestClass]
    public class CreateBuilderSpecs
    {
        [TestMethod]
        public void ShouldReturnTrueForPrimaryKey()
        {
            var builder = new CreateBuilder();
            builder.CreateTable<Person>();
         
            builder.Query().Should().Contain("CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ");
        }

        [TestMethod]
        public void ShouldReturnFalseForNonPrimaryKey()
        {
            var builder = new CreateBuilder();
            builder.CreateTable<NoKey>();

            builder.ToString().Should().NotContain("CLUSTERED ");
        }

        [TestMethod]
        public void ShouldThrowIfPrimaryKeyNotInt()
        {
            var builder = new CreateBuilder();
            Action action = () => builder.CreateTable<InvalidKey>();

            action.ShouldThrow<InvalidKeyException>();
        }

        [TestMethod]
        public void ShouldCreateIntColumn()
        {
            var properties = new AllTypes().GetProperties().ToArray();

            var builder = new CreateBuilder();
            var sql = builder.GetColumnDetails(properties[0]);

            sql.Should().Be("[Id] [int] IDENTITY(1,1) NOT NULL,");
        }

        [TestMethod]
        public void ShouldCreateStringColumn()
        {
            var properties = new AllTypes().GetProperties().ToArray();

            var builder = new CreateBuilder();
            var sql = builder.GetColumnDetails(properties[1]);

            sql.Should().Be("[Name] [varchar](max)  NULL,");
        }
    }
}