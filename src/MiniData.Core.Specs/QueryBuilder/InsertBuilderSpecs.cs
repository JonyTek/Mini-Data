using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.QueryBuilders;
using MiniData.Core.Specs.Model;

namespace MiniData.Core.Specs.QueryBuilder
{
    [TestClass]
    public class InsertBuilderSpecs
    {
        [TestMethod]
        public void ShouldCreateAInsertQuery()
        {
            var builder = new InsertBuilder();
            builder.Insert(new Person {Name = "Jony Tek"});

            var query = builder.ToString().Replace(Environment.NewLine, "");
         
            query.Should().Be("INSERT INTO [dbo].[Person]([Name])VALUES('Jony Tek')");
        }
    }
}
