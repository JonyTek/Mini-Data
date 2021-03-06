﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DataMap.Extensions;
using MiniData.Core.Helpers;
using MiniData.Core.Model;

//http://www.codeproject.com/Articles/837599/Using-Csharp-to-connect-to-and-query-from-a-SQL-da

namespace MiniData.Core.DataAccess
{
    public class Executor
    {
        internal async Task<IEnumerable<T>> ExecuteAndReturnAsync<T>(IQuery<T> query)
            where T : class, new()
        {
            var table = new DataTable();
            using (var connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                using (var command = new SqlCommand(query.ToString(), connection))
                {
                    await command.Connection.OpenAsync();

                    table.Load(await command.ExecuteReaderAsync());

                    command.Connection.Close();
                }
            }

            return table.ToEnumerableOf<T>();
        }

        internal async Task<int> ExecuteNonQueryAsync(IQuery query)
        {
            using (var connection = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                int result;
                using (var command = new SqlCommand(query.ToString(), connection))
                {
                    await command.Connection.OpenAsync();

                    result = await command.ExecuteNonQueryAsync();
                    
                    command.Connection.Close();
                }

                return result;
            }
        }
    }
}