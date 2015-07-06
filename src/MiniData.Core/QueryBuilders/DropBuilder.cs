using System;
using System.Text;
using MiniData.Core.Model;

namespace MiniData.Core.QueryBuilders
{
    internal class DropBuilder
    {
        private readonly StringBuilder _dropBuilder = new StringBuilder();

        public void DropTable<T>()
            where T : class, IDbTable, new()
        {
            _dropBuilder.AppendFormat("IF OBJECT_ID('dbo.{0}', 'U') IS NOT NULL DROP TABLE [dbo].[{0}]", typeof(T).Name);
        }

        public override string ToString()
        {
            return _dropBuilder.ToString();
        }
    }
}