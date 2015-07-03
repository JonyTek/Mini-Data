using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MiniData.Core.Extensions;

namespace MiniData.Core.QueryBuilders
{
    public class SelectBuilder<T>
    {
        internal HashSet<string> SelectColumns = new HashSet<string>();

        internal SelectBuilder<T> Select(params string[] columns)
        {
            foreach (var column in columns.Where(column => !SelectColumns.Contains(column)))
            {
                SelectColumns.Add(column.Trim());
            }

            return this;
        }

        internal SelectBuilder<T> Select(string columns)
        {
            Select(columns.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            return this;
        }

        internal SelectBuilder<T> Select<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            var column = expression.FieldName();

            if (!SelectColumns.Contains(column))
            {
                SelectColumns.Add(column);
            }

            return this;
        }

        public override string ToString()
        {
            var columns = new StringBuilder("SELECT ");

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