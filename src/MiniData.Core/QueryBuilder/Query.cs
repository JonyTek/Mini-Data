using System.Collections.Generic;
using System.Text;

namespace MiniData.Core.QueryBuilder
{
    public partial class Query<T>
    {
        private readonly StringBuilder _queryBuilder;

        internal HashSet<string> SelectColumns;

        public Query()
        {
            _queryBuilder = new StringBuilder();

            SelectColumns = new HashSet<string>();
        }

        public override string ToString()
        {
            _queryBuilder
                .Append("SELECT ")
                .Append(CompileSelectList())
                .AppendFormat(" FROM [{0}]", typeof (T).Name);

            var where = CompileWhere();
            if (!string.IsNullOrEmpty(where))
            {
                _queryBuilder.AppendFormat(" WHERE {0}", where);
            }

            return _queryBuilder.ToString();
        }
    }
}
