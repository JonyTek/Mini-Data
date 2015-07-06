using MiniData.Core.Model;

namespace MiniData.Model
{
    public static class Sql
    {
        public static AbstractWhere<T> Like<T>(T value)
        {
            return new Like<T>(value);
        }

        public static AbstractWhere<T> Equals<T>(T value)
        {
            return new Equals<T>(value);
        }

        public static AbstractWhere<T> NotEquals<T>(T value)
        {
            return new NotEquals<T>(value);
        }

        public static AbstractWhere<T> GreaterThen<T>(T value)
        {
            return new GreaterThen<T>(value);
        }

        public static AbstractWhere<T> GreaterEqualThen<T>(T value)
        {
            return new GreaterEqualThen<T>(value);
        }

        public static AbstractWhere<T> LessThen<T>(T value)
        {
            return new LessThen<T>(value);
        }

        public static AbstractWhere<T> LessEqualThen<T>(T value)
        {
            return new LessEqualThen<T>(value);
        }

        public static AbstractWhere<T> IsNull<T>()
        {
            return new IsNull<T>();
        }

        public static AbstractWhere<T> IsNotNull<T>()
        {
            return new IsNotNull<T>();
        }
    }
}
