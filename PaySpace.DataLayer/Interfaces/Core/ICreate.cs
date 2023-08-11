namespace PaySpace.DataLayer.Interfaces.Core
{
    public interface ICreate<out T>
    {
        T Create();
    }
}
