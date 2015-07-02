namespace MiniData.Core.Model
{
    public class IsNull<T> : AbstractWhere<T>
    {
        internal override WhereType Type
        {
            get { return WhereType.IsNull; }
        }
    }
}