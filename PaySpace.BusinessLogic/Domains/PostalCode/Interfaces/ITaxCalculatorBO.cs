using PaySpace.BusinessLogic.Domains.PostalCode.Interfaces.Models;

namespace PaySpace.BusinessLogic.Domains.PostalCode.Interfaces
{
    public interface ITaxCalculatorBO
    {
        ITaxCalculator GetTaxCalculation(int id);
    }
}
