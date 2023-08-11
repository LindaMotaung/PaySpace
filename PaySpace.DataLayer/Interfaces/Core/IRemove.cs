namespace PaySpace.DataLayer.Interfaces.Core
{
    public interface IRemove<in T>
    {
        void Remove(T item);
    }
}
