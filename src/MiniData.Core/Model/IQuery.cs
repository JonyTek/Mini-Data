namespace MiniData.Core.Model
{
    internal interface IQuery
    {
        string ToString();
    }

    internal interface IQuery<T> : IQuery
    {
    }
}