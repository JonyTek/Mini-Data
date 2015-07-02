namespace MiniData.Core.Model
{
    public class Equals<T> : AbstractWhere<T>
    {
        public Equals(T value)
            : base(value)
        {
        }

        internal override WhereType Type
        {
            get { return WhereType.Equals; }
        }
    }
}