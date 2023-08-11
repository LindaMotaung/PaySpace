using PaySpace.BusinessLogic.Domains.PostalCode.Interfaces.Models;

namespace PaySpace.BusinessLogic.Domains.PostalCode.Interfaces
{
    public interface IPostalCodeBO
    {
        IPostalCode GetPostalCode(int id);
    }
}
