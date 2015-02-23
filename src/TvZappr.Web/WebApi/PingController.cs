using System.Web.Http;
using TvZappr.Interop;

namespace TvZappr.Web.WebApi
{
    public class PingController : ApiController
    {
        [HttpGet]
        [Route(ApiRoutes.Ping)]
        public IHttpActionResult Do()
        {
            return Ok("pong!");
        }
    }
}