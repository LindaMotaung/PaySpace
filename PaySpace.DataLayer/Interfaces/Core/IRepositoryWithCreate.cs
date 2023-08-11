namespace PaySpace.DataLayer.Interfaces.Core
{
    public interface IRepositoryWithCreate<TInterface> : IRepository<TInterface>, ICreate<TInterface>
        where TInterface : class
    {
    }
}
