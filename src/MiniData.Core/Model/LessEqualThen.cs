namespace MiniData.Core.Model
{
    public class LessEqualThen<T> : AbstractWhere<T>
    {
        public LessEqualThen(T value)
            : base(value)
        {
        }

        internal override WhereType Type
        {
            get { return WhereType.LessEqualThen; }
        }
    }
}