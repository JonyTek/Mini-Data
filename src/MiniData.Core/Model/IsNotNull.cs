namespace MiniData.Core.Model
{
    public class IsNotNull<T> : AbstractWhere<T>
    {
        internal override WhereType Type
        {
            get { return WhereType.IsNotNull; }
        }
    }
}