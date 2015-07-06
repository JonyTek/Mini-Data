using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.Helpers;
using MiniData.Core.Util;

namespace MiniData.Core.Specs.Helpers
{
    [TestClass]
    public class WhereValueFormatterSpecs
    {
        [TestMethod]
        public void ShouldFormatString()
        {
            SqlTypeFormatter.Format("YO").Should().Be("'YO'");
        }

        [TestMethod]
        public void ShouldFormatGuid()
        {
            var guid = Guid.NewGuid();
            SqlTypeFormatter.Format(guid).Should().Be("'" + guid + "'");
        }

        [TestMethod]
        public void ShouldFormatDouble()
        {
            SqlTypeFormatter.Format(1.1d).Should().Be("1.1");
        }

        [TestMethod]
        public void ShouldFormatInt()
        {
            SqlTypeFormatter.Format(1).Should().Be("1");
        }

        [TestMethod]
        public void ShouldFormatDateTime()
        {
            SqlTypeFormatter.Format(new DateTime(2000, 1, 1, 0, 0, 0)).Should().Be("'2000-01-01 00:00:00'");
        }
    }
}
