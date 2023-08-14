using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using PaySpace.Api.Common;
using PaySpace.Api.Logic.Strategies;
using PaySpace.BusinessLogic.TransferObjects;

namespace PaySpace.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/codes")]
    public class TaxController : BaseApiController
    {
        private static TaxFacade _taxStrategy => TaxFacade.Instance;

        /// <summary>
        /// Submits a tax calculation based on the TO (Transfer Object)
        /// </summary>
        [HttpPost]
        [Route("")]
        public CreatedNegotiatedContentResult<long> CalculateTax(TaxTO tax)
        {
            var id = _taxStrategy.CalculateTax(tax);
            return Created(id);
        }
    }
}
