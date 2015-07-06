using System.Threading.Tasks;
using MiniData.Core.DataAccess;
using MiniData.Core.Model;
using MiniData.Core.QueryBuilders;

namespace MiniData.Core.Queries
{
    internal class DropQuery : IQuery
    {
        private readonly DropBuilder _dropBuilder = new DropBuilder();

        internal async Task DropAsync<T>()
            where T : class, IDbTable, new()
        {
            _dropBuilder.DropTable<T>();

            var executor = new Executor();

            await executor.ExecuteNonQueryAsync(this);
        }

        public override string ToString()
        {
            return _dropBuilder.ToString();
        }
    }
}