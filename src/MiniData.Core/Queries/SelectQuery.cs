using System;
using System.Linq.Expressions;
using System.Text;
using MiniData.Core.Model;
using MiniData.Core.QueryBuilders;

namespace MiniData.Core.Queries
{
    public class SelectQuery<T> : IQuery<T>
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

        public override string ToString()
        {
            var selectList = _selectBuilder.ToString();

            if (string.IsNullOrEmpty(selectList)) return string.Empty;

            _queryBuilder.Append(selectList).AppendFormat(" FROM [{0}]", typeof (T).Name);

            var where = _whereBuilder.ToString();

            if (!string.IsNullOrEmpty(where)) _queryBuilder.AppendFormat(" {0}", where);

            return _queryBuilder.ToString();
        }
    }
}
