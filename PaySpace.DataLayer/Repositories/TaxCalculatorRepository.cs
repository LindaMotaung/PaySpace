using System.Linq;
using PaySpace.DataLayer.Core;
using PaySpace.DataLayer.Data;
using PaySpace.DataLayer.Entities;
using PaySpace.DataLayer.Interfaces.Entities;
using PaySpace.DataLayer.Interfaces.Repositories;

namespace PaySpace.DataLayer.Repositories
{
    public class TaxCalculatorRepository : Repository<TaxCalculator, ITaxCalculator>, ITaxCalculatorRepository
    {
        public TaxCalculatorRepository(PaySpaceContext psContext) : base(psContext)
        {
        }

        public ITaxCalculator GetTaxCalculator(int id)
        {
            return context.TaxCalculator.FirstOrDefault(u => u.Id == id);
        }
    }
}
