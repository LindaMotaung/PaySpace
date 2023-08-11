using System.Web.Http;
using System.Web.Http.Results;

namespace PaySpace.Api.Common
{
    public abstract class BaseApiController : ApiController
    {
        protected internal CreatedNegotiatedContentResult<long> Created(long id)
        {
            var location = $"{Request.RequestUri}/{id}";
            return Created(location, id);
        }
    }
}
