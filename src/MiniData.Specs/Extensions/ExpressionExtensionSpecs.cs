using System;
using System.Linq.Expressions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.Extensions;

namespace MiniData.Core.Specs.Extensions
{
    [TestClass]
    public class ExpressionExtensionSpecs
    {
        [TestMethod]
        public void ShouldGetAnExpressionName()
        {
            Expression<Func<Model.Model, int>> expression = model => model.Id;
            
            expression.FieldName().Should().Be("Id");
        }
    }
}