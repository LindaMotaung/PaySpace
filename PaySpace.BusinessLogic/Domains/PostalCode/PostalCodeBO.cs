using PaySpace.BusinessLogic.Domains.PostalCode.Interfaces;
using PaySpace.DataLayer.Interfaces.Core;
using IPostalCode = PaySpace.BusinessLogic.Domains.PostalCode.Interfaces.Models.IPostalCode;

namespace PaySpace.BusinessLogic.Domains.PostalCode
{
    public class PostalCodeBO : IPostalCodeBO
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostalCodeMapper _postalCodeMapper;

        public PostalCodeBO(IUnitOfWork unitOfWork, IPostalCodeMapper postalCodeMapper)
        {
            _unitOfWork = unitOfWork;
            _postalCodeMapper = postalCodeMapper;
        }

        public IPostalCode GetPostalCode(int id)
        {
            var entity = _unitOfWork.PostalCodeRepository.GetPostalCode(id);
            return _postalCodeMapper.Map<DataLayer.Interfaces.Entities.IPostalCode, IPostalCode>(entity);
        }
    }
}
