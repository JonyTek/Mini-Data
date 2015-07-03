using System.Threading.Tasks;
using MiniData.Core.DataAccess;
using MiniData.Core.Model;
using MiniData.Core.QueryBuilders;

namespace MiniData.Core.Queries
{
    public class CreateQuery : IQuery
    {
        private readonly CreateBuilder _createBuilder = new CreateBuilder(); 

        internal async Task CreateTableAsync<T>()
            where T : class, IDbTable, new()
        {
            _createBuilder.CreateTable<T>();

            var executor = new Executor();

            await executor.ExecuteNonQueryAsync(this);
        }

        public override string ToString()
        {
            return _createBuilder.ToString();
        }
    }
}