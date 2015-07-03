﻿using System;
using System.Configuration;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MiniData.Core.Helpers;
using MiniData.Core.Model;
using MiniData.Core.Queries;

namespace MiniData
{
    public class DbConnection : IDisposable, IDbConnection
    {
        public static void Init(string name)
        {
            ConnectionString = name;
        }

        internal static string ConnectionString
        {
            set { ConnectionHelper.ConnectionString = ConfigurationManager.ConnectionStrings[value].ConnectionString; }
        }

        public SelectQuery<T> Select<T>(params string[] columns)
            where T : class , new()
        {
            return new SelectQuery<T>().Select(columns);
        }

        public SelectQuery<T> Select<T>(string columns)
               where T : class , new()
        {
            return new SelectQuery<T>().Select(columns);
        }

        public SelectQuery<T> Select<T, TProperty>(Expression<Func<T, TProperty>> expression)
               where T : class , new()
        {
            return new SelectQuery<T>().Select(expression);
        }

        public async Task CreateTableAsync<TTable>() where TTable : class, IDbTable, new()
        {
            await new CreateQuery().CreateTableAsync<TTable>();
        }
        public async Task DropCreateTableAsync<TTable>() where TTable : class, IDbTable, new()
        {
            await DropTableAsync<TTable>();
            
            await CreateTableAsync<TTable>();
        }

        public async Task DropTableAsync<TTable>() where TTable : class, IDbTable, new()
        {
            await new DropQuery().DropAsync<TTable>();
        }

        public void Dispose() { }
    }
}