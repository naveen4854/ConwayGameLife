using BusinessLayer;
using Models;
using System.Web.Http;

namespace Services.Controllers
{
    public class ConvayController : ApiController
    {
        [HttpPost]
        [Route("api/GetNextSimulation")]
        public Grid GetNextSimulation([FromBody]Grid gridObj)
        {
            ConwayManager convy = new ConwayManager();
            return convy.GetNextSimulation(gridObj);
        }
       
    }
}
