namespace PaySpace.DataLayer.Interfaces.Core
{
    public interface IAddUpdateAndRemove<TInterface> : IAdd<TInterface>, IUpdate<TInterface>, IRemove<TInterface>
    {

    }
}
