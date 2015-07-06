using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MiniData.Core.Model;
using MiniData.Core.Queries;

namespace MiniData
{
    public interface IDbConnection<T> where T : class, new()
    {
        SelectQuery<T> Select<TProperty>(Expression<Func<T, TProperty>> expression);
    }

    public interface IDbConnection
    {
        SelectQuery<T> Select<T>(params string[] columns) where T : class, new();

        SelectQuery<T> Select<T>(string columns) where T : class, new();

        Task CreateTableAsync<TTable>() where TTable : class, IDbTable, new();

        Task DropCreateTableAsync<TTable>() where TTable : class, IDbTable, new();

        Task DropTableAsync<TTable>() where TTable : class, IDbTable, new();

        Task InsertAsync<T>(T toInsert) where T : class, IDbTable, new();

        Task InsertCollectionAsync<T>(IEnumerable<T> toInsert) where T : class, IDbTable, new();
    }
}