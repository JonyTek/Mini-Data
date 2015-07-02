namespace MiniData.Core.Model
{
    public class GreaterEqualThen<T> : AbstractWhere<T>
    {
        public GreaterEqualThen(T value)
            : base(value)
        {
        }

        internal override WhereType Type
        {
            get { return WhereType.GreaterEqualThen; }
        }
    }
}