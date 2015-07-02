namespace MiniData.Core.Model
{
    public class GreaterThen<T> : AbstractWhere<T>
    {
        public GreaterThen(T value)
            : base(value)
        {
        }

        internal override WhereType Type
        {
            get { return WhereType.GreatedThen; }
        }
    }
}