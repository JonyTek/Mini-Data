using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MiniData.Core.DataAccess;
using MiniData.Core.Model;
using MiniData.Core.QueryBuilders;

namespace MiniData.Core.Queries
{
    public class SelectQuery<T> : IQuery<T> where T : class, new()
    {
        private readonly StringBuilder _queryBuilder = new StringBuilder();

        private readonly SelectBuilder<T> _selectBuilder = new SelectBuilder<T>();

        private readonly WhereBuilder<T> _whereBuilder = new WhereBuilder<T>();

        internal SelectQuery<T> Select(params string[] columns)
        {
            _selectBuilder.Select(columns);

            return this;
        }

        internal SelectQuery<T> Select(string columns)
        {
            _selectBuilder.Select(columns);

            return this;
        }

        internal SelectQuery<T> Select<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            _selectBuilder.Select(expression);

            return this;
        }

        public SelectQuery<T> Where<TProperty>(Expression<Func<T, TProperty>> expression,
            AbstractWhere<TProperty> where)
        {
             _whereBuilder.Where(expression, where);

            return this;
        }

        public SelectQuery<T> Where<TProperty>(string column, AbstractWhere<TProperty> where)
        {
             _whereBuilder.Where(column, where);
             
            return this;
        }

        public SelectQuery<T> AndWhere<TProperty>(Expression<Func<T, TProperty>> expression,
            AbstractWhere<TProperty> where)
        {
            _whereBuilder.AndWhere(expression, where);

            return this;
        }

        public SelectQuery<T> AndWhere<TProperty>(string column, AbstractWhere<TProperty> where)
        {
            _whereBuilder.AndWhere(column, where);

            return this;
        }

        public SelectQuery<T> OrWhere<TProperty>(Expression<Func<T, TProperty>> expression,
            AbstractWhere<TProperty> where)
        {
            _whereBuilder.OrWhere(expression, where);

            return this;
        }

        public SelectQuery<T> OrWhere<TProperty>(string column, AbstractWhere<TProperty> where)
        {
            _whereBuilder.OrWhere(column, where);

            return this;
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            var executor = new Executor();

            return await executor.ExecuteAndReturnAsync(this);
        }

        public async Task<T> SelectSingleAsync()
        {
            var result = await SelectAsync();

            return result.FirstOrDefault();
        }
        
        public override string ToString()
        {
            var selectList = _selectBuilder.ToString();

            var query = _queryBuilder.ToString();

            if (!string.IsNullOrEmpty(query)) return query;
         
            _queryBuilder
                .Append(selectList)
                .AppendFormat(" FROM [{0}]", typeof (T).Name)
                .AppendFormat(" {0}", _whereBuilder);

            return _queryBuilder.ToString();
        }
    }
}
