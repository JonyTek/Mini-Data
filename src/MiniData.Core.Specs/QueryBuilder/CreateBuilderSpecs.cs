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
         
            builder.ToString().Should().Contain("CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ");
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
            Action action = builder.CreateTable<InvalidKey>;

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

        [TestMethod]
        public void ShouldCreateDateTimeColumn()
        {
            var properties = new AllTypes().GetProperties().ToArray();

            var builder = new CreateBuilder();
            var sql = builder.GetColumnDetails(properties[2]);

            sql.Should().Be("[DateTime] [datetime]  NOT NULL,");
        }

        [TestMethod]
        public void ShouldCreateGuidColumn()
        {
            var properties = new AllTypes().GetProperties().ToArray();

            var builder = new CreateBuilder();
            var sql = builder.GetColumnDetails(properties[3]);

            sql.Should().Be("[Guid] [uniqueidentifier]  NOT NULL,");
        }

        [TestMethod]
        public void ShouldCreateBoolColumn()
        {
            var properties = new AllTypes().GetProperties().ToArray();

            var builder = new CreateBuilder();
            var sql = builder.GetColumnDetails(properties[4]);

            sql.Should().Be("[Boolean] [bit]  NOT NULL,");
        }

        [TestMethod]
        public void ShouldCreateFloatColumn()
        {
            var properties = new AllTypes().GetProperties().ToArray();

            var builder = new CreateBuilder();
            var sql = builder.GetColumnDetails(properties[5]);

            sql.Should().Be("[Float] [float]  NOT NULL,");
        }

        [TestMethod]
        public void ShouldCreateDecimalColumn()
        {
            var properties = new AllTypes().GetProperties().ToArray();

            var builder = new CreateBuilder();
            var sql = builder.GetColumnDetails(properties[6]);

            sql.Should().Be("[Decimal] [decimal(18, 0)]  NOT NULL,");
        }

        [TestMethod]
        public void ShouldCreateCharColumn()
        {
            var properties = new AllTypes().GetProperties().ToArray();

            var builder = new CreateBuilder();
            var sql = builder.GetColumnDetails(properties[7]);

            sql.Should().Be("[Char] [char(10)]  NOT NULL,");
        }

        [TestMethod]
        public void ShouldCreateSmallIntColumn()
        {
            var properties = new AllTypes().GetProperties().ToArray();

            var builder = new CreateBuilder();
            var sql = builder.GetColumnDetails(properties[8]);

            sql.Should().Be("[Int16] [smallint]  NOT NULL,");
        }

        [TestMethod]
        public void ShouldCreateBigIntColumn()
        {
            var properties = new AllTypes().GetProperties().ToArray();

            var builder = new CreateBuilder();
            var sql = builder.GetColumnDetails(properties[9]);

            sql.Should().Be("[Int64] [bigint]  NOT NULL,");
        }

        [TestMethod]
        public void ShouldCreateCustomColumn()
        {
            var properties = new AllTypes().GetProperties().ToArray();

            var builder = new CreateBuilder();
            var sql = builder.GetColumnDetails(properties[10]);

            sql.Should().Be("[Custom] [varchar(50)] IDENTITY(1,1) NULL,");
        }
    }
}