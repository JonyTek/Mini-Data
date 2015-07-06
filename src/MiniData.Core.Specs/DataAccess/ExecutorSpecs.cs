using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.DataAccess;
using MiniData.Core.Helpers;
using MiniData.Core.Model;
using MiniData.Core.Queries;
using MiniData.Core.Specs.Model;

namespace MiniData.Core.Specs.DataAccess
{
    [TestClass]
    public class ExecutorSpecs
    {
        [TestInitialize]
        public void OnBeforeEachTest()
        {
            ConnectionHelper.ConnectionString =
                ConfigurationManager.ConnectionStrings["ConnectionString"]
                    .ConnectionString;
        }


        [TestMethod]
        public async Task ShouldGetData()
        {
            var people = await new SelectQuery<Person>().Select(p => p.Id).Where("Id", new Equals<int>(1)).SelectAsync();

            people.Count().Should().BeGreaterOrEqualTo(1);
        }
    }
}