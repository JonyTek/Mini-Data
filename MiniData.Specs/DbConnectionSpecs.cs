using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Core.Model;
using MiniData.Specs.Model;

namespace MiniData.Specs
{
    [TestClass]
    public class DbConnectionSpecs
    {
        [TestInitialize]
        public void OnBeforeEachTest()
        {
            DbConnection.ConnectionString = "ConnectionString";
        }

        [TestMethod]
        public async Task ShouldInterfaceWithSelect()
        {
            using (var db = new DbConnection())
            {
                var query = db.Select<Person>("*").Where(p => p.Id, new Equals<int>(1));

                var people = await query.SelectAsync();
                var person = await query.SelectSingleAsync();

                people.Count().Should().Be(1);
                person.Should().NotBe(null);
            }
        }

        [TestMethod]
        public async Task ShouldCreateATable()
        {
            using (var db = new DbConnection())
            {
                await db.CreateTableAsync<Table>();
            }
        }
    }
}
