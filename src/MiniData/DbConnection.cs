using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MiniData.Core.Helpers;
using MiniData.Core.Model;
using MiniData.Core.Queries;

namespace MiniData
{
    public class DbConnection<T> : DbConnection, IDbConnection<T>
           where T : class, IDbTable, new()
    {
        public SelectQuery<T> Select<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            return new SelectQuery<T>().Select(expression);
        }
    }

    public class DbConnection : IDisposable, IDbConnection
    {
        public static void Init(string connectionStringName)
        {
            ConnectionString = connectionStringName;
        }

        internal static string ConnectionString
        {
            set { ConnectionHelper.ConnectionString = ConfigurationManager.ConnectionStrings[value].ConnectionString; }
        }

        public SelectQuery<T> Select<T>(params string[] columns)
            where T : class, new()
        {
            return new SelectQuery<T>().Select(columns);
        }

        public SelectQuery<T> Select<T>(string columns)
            where T : class, new()
        {
            return new SelectQuery<T>().Select(columns);
        }

        public async Task CreateTableAsync<T>()
           where T : class, IDbTable, new()
        {
            await new CreateQuery().CreateTableAsync<T>();
        }

        public async Task DropCreateTableAsync<T>()
            where T : class, IDbTable, new()
        {
            await DropTableAsync<T>();

            await CreateTableAsync<T>();
        }

        public async Task DropTableAsync<T>()
            where T : class, IDbTable, new()
        {
            await new DropQuery().DropAsync<T>();
        }

        public async Task InsertAsync<T>(T toInsert)
            where T : class, IDbTable, new()
        {
            await new InsertQuery<T>().InsertAsync(toInsert);
        }

        public async Task InsertCollectionAsync<T>(IEnumerable<T> toInsert)
           where T : class, IDbTable, new()
        {
            foreach (var item in toInsert)
            {
                await InsertAsync(item);
            }
        }

        public void Dispose()
        {
            //NO OP
        }
    }
}