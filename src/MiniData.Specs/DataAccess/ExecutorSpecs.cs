using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.DataAccess;
using MiniData.Core.Helpers;
using MiniData.Core.Model;
using MiniData.Core.QueryBuilder;

namespace MiniData.Core.Specs.DataAccess
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }


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
            var query = new Query<Person>().Select("*").Where("Id", new Equals<int>(1));

            var executor = new Executor();
            var nodes = await executor.ExecuteAndReturnAsync(query);

            nodes.Count().Should().BeGreaterOrEqualTo(1);
        }
    }
}