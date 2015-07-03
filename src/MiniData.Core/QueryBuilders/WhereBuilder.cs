using System;
using System.Linq.Expressions;
using System.Text;
using MiniData.Core.Extensions;
using MiniData.Core.Helpers;
using MiniData.Core.Model;
using MiniData.Core.Queries;
using MiniData.Core.Util;

namespace MiniData.Core.QueryBuilders
{
    internal class WhereBuilder<T>
    {
        private readonly StringBuilder _whereBuilder = new StringBuilder();

        internal WhereBuilder<T> Where(string whereQuery)
        {
            _whereBuilder.Append(whereQuery);

            return this;
        }

        internal WhereBuilder<T> Where<TProperty>(Expression<Func<T, TProperty>> expression, AbstractWhere<TProperty> where)
        {
            return Where(expression.FieldName(), where);
        }

        internal WhereBuilder<T> Where<TProperty>(string column, AbstractWhere<TProperty> where)
        {
            var type = "=";
            var isNullWhere = false;

            switch (where.Type)
            {
                case WhereType.Like:
                    type = "LIKE";
                    break;
                case WhereType.Equals:
                    type = "=";
                    break;
                case WhereType.NotEquals:
                    type = "!=";
                    break;
                case WhereType.GreatedThen:
                    type = ">";
                    break;
                case WhereType.GreaterEqualThen:
                    type = ">=";
                    break;
                case WhereType.LessThen:
                    type = "<";
                    break;
                case WhereType.LessEqualThen:
                    type = "<=";
                    break;
                case WhereType.IsNull:
                    type = "IS NULL";
                    isNullWhere = true;
                    break;
                case WhereType.IsNotNull:
                    type = "IS NOT NULL";
                    isNullWhere = true;
                    break;
            }

            _whereBuilder.AppendFormat("[{0}] {1} {2}", column, type,
                isNullWhere
                    ? string.Empty
                    : WhereValueFormatter.Format(where.Value));

            return this;
        }

        internal WhereBuilder<T> AndWhere<TProperty>(Expression<Func<T, TProperty>> expression, AbstractWhere<TProperty> where)
        {
            return AndWhere(expression.FieldName(), where);
        }

        internal WhereBuilder<T> AndWhere<TProperty>(string column, AbstractWhere<TProperty> where)
        {
            return ConcatQueries(column, where, "AND");
        }

        internal WhereBuilder<T> OrWhere<TProperty>(Expression<Func<T, TProperty>> expression, AbstractWhere<TProperty> where)
        {
            return OrWhere(expression.FieldName(), where);
        }

        internal WhereBuilder<T> OrWhere<TProperty>(string column, AbstractWhere<TProperty> where)
        {
            return ConcatQueries(column, where, "OR");
        }

        private WhereBuilder<T> ConcatQueries<TProperty>(string column, AbstractWhere<TProperty> where, string andOrWhere)
        {
            var currentWhere = GetToString();

            ClearWhereBuilder();

            Where(column, where);

            var newWhere = GetToString();

            ClearWhereBuilder();

            _whereBuilder.AppendFormat("({0} {1} {2})", currentWhere, andOrWhere, newWhere);

            return this;
        }

        private void ClearWhereBuilder()
        {
            _whereBuilder.Clear();
        }

        private string GetToString()
        {
            return _whereBuilder.ToString().Trim();
        }

        public override string ToString()
        {
            _whereBuilder.Insert(0, "WHERE ");

            return _whereBuilder.ToString().Trim();
        }
    }
}