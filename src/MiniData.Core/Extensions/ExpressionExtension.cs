using System;
using System.Linq.Expressions;

namespace MiniData.Core.Extensions
{
    internal static class ExpressionExtension
    {
        internal static string FieldName<TSchema, TProperty>(this Expression<Func<TSchema, TProperty>> expression)
        {
            return ((MemberExpression) expression.Body).Member.Name;
        }
    }
}