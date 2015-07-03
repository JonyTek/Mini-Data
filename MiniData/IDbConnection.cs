using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MiniData.Core.Model;
using MiniData.Core.Queries;

namespace MiniData
{
    public interface IDbConnection
    {
        SelectQuery<T> Select<T>(params string[] columns) where T : class, new();

        SelectQuery<T> Select<T>(string columns) where T : class, new();

        SelectQuery<T> Select<T, TProperty>(Expression<Func<T, TProperty>> expression) where T : class, new();

        Task CreateTableAsync<TTable>() where TTable : class, IDbTable, new();
    }
}