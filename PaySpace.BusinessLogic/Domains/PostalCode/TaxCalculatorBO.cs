using PaySpace.BusinessLogic.Domains.PostalCode.Interfaces;
using PaySpace.BusinessLogic.Domains.PostalCode.Interfaces.Models;
using PaySpace.DataLayer.Interfaces.Core;

namespace PaySpace.BusinessLogic.Domains.PostalCode
{
    public class TaxCalculatorBO : ITaxCalculatorBO
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostalCodeMapper _taxCalculationMapper;

        public TaxCalculatorBO(IUnitOfWork unitOfWork, IPostalCodeMapper taxCalculationMapper)
        {
            _unitOfWork = unitOfWork;
            _taxCalculationMapper = taxCalculationMapper;
        }

        public ITaxCalculator GetTaxCalculation(int id)
        {
            var entity = _unitOfWork.TaxCalculatorRepository.GetTaxCalculator(id);
            return _taxCalculationMapper.Map<DataLayer.Interfaces.Entities.ITaxCalculator, ITaxCalculator>(entity);
        }
    }
}
