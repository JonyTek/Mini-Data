using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniData.Model;
using MiniData.Specs.Model;

namespace MiniData.Specs
{
    [TestClass]
    public class DbConnectionSpecs
    {
        [TestInitialize]
        public void OnBeforeEachTest()
        {
            DbConnection.Init("ConnectionString");

            using (var db = new DbConnection())
            {
                db.DropCreateTableAsync<Person>().Wait();
            }
        }

        [TestMethod]
        public async Task ShouldDropCreateATable()
        {
            using (var db = new DbConnection())
            {
                await db.DropTableAsync<Table>();

                await db.CreateTableAsync<Table>();

                await db.DropCreateTableAsync<Table>();
            }
        }

        [TestMethod]
        public async Task ShouldInsertAnObject()
        {
            using (var db = new DbConnection())
            {
                Enumerable.Range(0, 100).ToList().ForEach(_ => db.InsertAsync(new Person {Name = "Rick Bobby"}).Wait());

                var people = await db.Select<Person>().SelectAsync();

                people.Count().Should().Be(100);
            }
        }

        [TestMethod]
        public async Task ShouldSelectEquals()
        {
            using (var db = new DbConnection())
            {
                await db.InsertAsync(new Person {Name = "Rick Bobby"});

                var query = db.Select<Person>().Where(p => p.Id, Sql.Equals(1));

                var people = await query.SelectAsync();
                var person = await query.SelectSingleAsync();

                people.Count().Should().Be(1);
                person.Should().NotBe(null);
            }
        }

        [TestMethod]
        public async Task ShouldSelectLike()
        {
            using (var db = new DbConnection<Person>())
            {
                await db.InsertCollectionAsync(new List<Person>
                {
                    new Person {Name = "Jonathan Swieboda"},
                    new Person {Name = "James Nathan Smith"}
                });

                var query = db.Select(p => p.Name).Where(p => p.Name, Sql.Like("%"));

                var people = await query.SelectAsync();

                people.Count().Should().Be(2);
            }
        }
    }
}
