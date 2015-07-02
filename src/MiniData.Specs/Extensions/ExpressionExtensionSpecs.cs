using System;
using System.Linq.Expressions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.Extensions;

namespace MiniData.Specs.Extensions
{
    [TestClass]
    public class ExpressionExtensionSpecs
    {
        [TestMethod]
        public void ShouldGetAnExpressionName()
        {
            Expression<Func<Model, int>> expression = model => model.Id;

            expression.FieldName().Should().Be("Id");
        }
    }
}