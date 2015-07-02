using System;
using System.Linq.Expressions;
using System.Text;
using MiniData.Core.Extensions;
using MiniData.Core.Helpers;
using MiniData.Core.Model;

namespace MiniData.Core.QueryBuilder
{
    public partial class Query<T>
    {
        private readonly StringBuilder _whereBuilder = new StringBuilder();

        public Query<T> Where(string whereQuery)
        {
            _whereBuilder.Append(whereQuery);

            return this;
        }

        public Query<T> Where<TProperty>(Expression<Func<T, TProperty>> expression, AbstractWhere<TProperty> where)
        {
            return Where(expression.FieldName(), where);
        }

        public Query<T> Where<TProperty>(string column, AbstractWhere<TProperty> where)
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

        public Query<T> AndWhere<TProperty>(Expression<Func<T, TProperty>> expression, AbstractWhere<TProperty> where)
        {
            return AndWhere(expression.FieldName(), where);
        }

        public Query<T> AndWhere<TProperty>(string column, AbstractWhere<TProperty> where)
        {
            return ConcatQueries(column, where, "AND");
        }

        public Query<T> OrWhere<TProperty>(Expression<Func<T, TProperty>> expression, AbstractWhere<TProperty> where)
        {
            return OrWhere(expression.FieldName(), where);
        }

        public Query<T> OrWhere<TProperty>(string column, AbstractWhere<TProperty> where)
        {
            return ConcatQueries(column, where, "OR");
        }

        private Query<T> ConcatQueries<TProperty>(string column, AbstractWhere<TProperty> where, string andOrWhere)
        {
            var currentWhere = CompileWhere();

            ClearWhereBuilder();

            Where(column, where);

            var newWhere = CompileWhere();

            ClearWhereBuilder();

            _whereBuilder.AppendFormat("({0} {1} {2})", currentWhere, andOrWhere, newWhere);

            return this;
        }

        private void ClearWhereBuilder()
        {
            _whereBuilder.Clear();
        }

        private string CompileWhere()
        {
            return _whereBuilder.ToString().Trim();
        }
    }
}