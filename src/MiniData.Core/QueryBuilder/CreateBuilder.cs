using System;
using System.Text;
using MiniData.Core.Model;
using MiniData.Core.Properties;

namespace MiniData.Core.QueryBuilder
{
    public class CreateBuilder
    {
        private readonly StringBuilder _queryBuilder;

        internal CreateBuilder()
        {
            _queryBuilder = new StringBuilder(Resources.CreateTableStart);
        }

        public void CreateTable<T>()
            where T : IDbTable
        {
            _queryBuilder.AppendFormat("CREATE TABLE [dbo].[{0}](", typeof (T).Name);


            //INSERT LOGIC
            
            _queryBuilder.Append(")");
        }

        public override string ToString()
        {
            return _queryBuilder.Append(Resources.CreateTableEnd).ToString();
        }
    }
}
