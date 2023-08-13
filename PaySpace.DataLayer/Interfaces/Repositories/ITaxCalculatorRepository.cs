using PaySpace.DataLayer.Interfaces.Core;
using PaySpace.DataLayer.Interfaces.Entities;

namespace PaySpace.DataLayer.Interfaces.Repositories
{
    public interface ITaxCalculatorRepository : IRepositoryWithCreate<ITaxCalculator>
    {
        ITaxCalculator GetTaxCalculator(int id);
    }
}
