namespace PaySpace.DataLayer.Interfaces.Core
{
    public interface IUpdate<T>
    {
        T Update(T item);
    }
}
