using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MiniData.Core.Extensions;
using MiniData.Core.Model;
using MiniData.Core.Util;

namespace MiniData.Core.QueryBuilders
{
    internal class InsertBuilder
    {
        private StringBuilder _insertBuilder;

        internal void Insert<T>(T toInsert)
            where T : class, IDbTable, new()
        {
            _insertBuilder = new StringBuilder();

            var values = new Collection<string>();

            _insertBuilder.AppendFormat("INSERT INTO [dbo].[{0}]", typeof (T).Name)
                .AppendFormat("{0}(", Environment.NewLine);

            foreach (var property in toInsert.GetProperties().Where(property => !property.IsPrimarykey()))
            {
                _insertBuilder.AppendFormat("[{0}],", property.Name);

                values.Add(SqlTypeFormatter.Format(property, toInsert));
            }

            _insertBuilder.Remove(_insertBuilder.Length - 1, 1);

            _insertBuilder
                .AppendFormat("){0}", Environment.NewLine)
                .AppendFormat("VALUES{0}", Environment.NewLine)
                .AppendFormat("({0})", string.Join(",", values).TrimEnd(','));
        }

        public override string ToString()
        {
            return _insertBuilder.ToString();
        }
    }
}
