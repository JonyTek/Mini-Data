using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.Extensions;

namespace MiniData.Core.Specs.Extensions
{
    [TestClass]
    public class ObjectExtensionsSpecs
    {
        [TestMethod]
        public void ShouldGetProperties()
        {
            var props = new Model.Model().GetProperties();

            props.Count().Should().BeGreaterOrEqualTo(2);
        }

        [TestMethod]
        public void ShouldCheckIfNullableType()
        {
            var properties = new Model.Model().GetProperties().ToArray();

            properties[1].IsNullableType().Should().BeFalse();
            properties[2].IsNullableType().Should().BeTrue();
        }
    }
}