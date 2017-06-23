namespace WebApi.Controllers
{
    using System.Web.Http;

    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiController
    {

        public IHttpActionResult Get()
        {
            return Ok("test token");
        }
    }
}
