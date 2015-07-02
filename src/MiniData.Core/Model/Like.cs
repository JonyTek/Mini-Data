namespace MiniData.Core.Model
{
    public class Like<T> : AbstractWhere<T>
    {
        public Like(T value)
            : base(value)
        {
        }

        internal override WhereType Type
        {
            get { return WhereType.Like; }
        }
    }
}