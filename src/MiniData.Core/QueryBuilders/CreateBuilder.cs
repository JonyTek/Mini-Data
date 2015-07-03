using System;
using System.Reflection;
using System.Text;
using MiniData.Core.Attributes;
using MiniData.Core.Exceptions;
using MiniData.Core.Extensions;
using MiniData.Core.Model;
using MiniData.Core.Properties;

namespace MiniData.Core.QueryBuilders
{
    public class CreateBuilder
    {
        private string _tableName;
        
        private PropertyInfo _primaryKey;

        private readonly StringBuilder _queryBuilder;

        internal CreateBuilder()
        {
            _queryBuilder = new StringBuilder(Resources.CreateTableStart);
        }

        internal void CreateTable<T>()
            where T : class, IDbTable, new()
        {
            _tableName = typeof (T).Name;

            _queryBuilder.AppendFormat("CREATE TABLE [dbo].[{0}](", _tableName);

            foreach (var property in Activator.CreateInstance<T>().GetProperties())
            {
                CheckPrimaryKey(property);

                _queryBuilder.Append(GetColumnDetails(property));
            }

            if (_primaryKey != null)
            {
                _queryBuilder.AppendFormat(Resources.PrimaryKeyTemplate, _tableName, _primaryKey.Name);
            }

            _queryBuilder.Append(")");

            if (_primaryKey != null)
            {
                _queryBuilder.Append("ON [PRIMARY]");
            }
        }

        internal string GetColumnDetails(PropertyInfo property)
        {
            var nullable = property.IsNullableType() ? "" : "NOT ";
            var increment = property.IsAutoIncrement() ? "IDENTITY(1,1)" : "";

            return string.Format("[{0}] {1} {2} {3}NULL,", property.Name, property.ToSqlType(), increment, nullable);
        }

        internal void CheckPrimaryKey(PropertyInfo property)
        {
            if (_primaryKey != null) return;

            var attribute = property.GetCustomAttribute<PrimaryKeyAttribute>();
            
            if (attribute == null) return;

            if (!string.Equals(property.PropertyType.FullName, "System.Int32")) throw new InvalidKeyException();

            _primaryKey = property;
        }

        public string Query()
        {
            return _queryBuilder.Append(Resources.CreateTableEnd).ToString();
        }
    }
}
