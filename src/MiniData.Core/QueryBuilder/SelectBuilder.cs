using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MiniData.Core.Extensions;

namespace MiniData.Core.QueryBuilder
{
    public partial class Query<T>
    {
        public Query<T> Select(params string[] columns)
        {
            foreach (var column in columns.Where(column => !SelectColumns.Contains(column)))
            {
                SelectColumns.Add(column.Trim());
            }

            return this;
        }

        public Query<T> Select(string columns)
        {
            Select(columns.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            return this;
        }

        public Query<T> Select<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            var column = expression.FieldName();

            if (!SelectColumns.Contains(column))
            {
                SelectColumns.Add(column);
            }

            return this;
        }

        private string CompileSelectList()
        {
            var columns = new StringBuilder();

            if (SelectColumns.Contains("All") || SelectColumns.Contains("*") || !SelectColumns.Any())
            {
                columns.Append("*");

                return columns.ToString().TrimEnd();
            }

            foreach (var column in SelectColumns)
            {
                columns.AppendFormat("[{0}], ", column);
            }

            return columns.ToString().TrimEnd(',', ' ');
        }
    }
}