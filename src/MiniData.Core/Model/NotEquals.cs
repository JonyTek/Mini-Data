namespace MiniData.Core.Model
{
    public class NotEquals<T> : AbstractWhere<T>
    {
        public NotEquals(T value)
            : base(value)
        {
        }

        internal override WhereType Type
        {
            get { return WhereType.NotEquals; }
        }
    }
}