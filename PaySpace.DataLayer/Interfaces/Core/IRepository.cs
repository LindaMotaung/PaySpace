using System.Linq;
namespace PaySpace.DataLayer.Interfaces.Core
{
    public interface IRepository<TInterface> : IAddUpdateAndRemove<TInterface>
    {
        IQueryable<TInterface> GetAll();
    }
}
