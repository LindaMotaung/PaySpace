using PaySpace.DataLayer.Interfaces.Core;
using PaySpace.DataLayer.Interfaces.Entities;

namespace PaySpace.DataLayer.Interfaces.Repositories
{
    public interface IPostalCodeRepository : IRepositoryWithCreate<IPostalCode>
    {
        IPostalCode GetPostalCode(int id);
    }
}
