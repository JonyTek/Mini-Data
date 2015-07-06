using System.Threading.Tasks;
using MiniData.Core.DataAccess;
using MiniData.Core.Model;
using MiniData.Core.QueryBuilders;

namespace MiniData.Core.Queries
{
    internal class InsertQuery<T> : IQuery<T>
    {
        private readonly InsertBuilder _insertBuilder = new InsertBuilder();

        internal async Task InsertAsync<T>(T toInsert)
            where T : class, IDbTable, new()

        {
            _insertBuilder.Insert(toInsert);

            var executor = new Executor();

            await executor.ExecuteNonQueryAsync(this);
        }

        public override string ToString()
        {
            return _insertBuilder.ToString();
        }
    }
}