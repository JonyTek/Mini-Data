namespace MiniData.Core.Model
{
    public class LessThen<T> : AbstractWhere<T>
    {
        public LessThen(T value)
            : base(value)
        {
        }

        internal override WhereType Type
        {
            get { return WhereType.LessThen; }
        }
    }
}