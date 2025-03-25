using Daylon.BicycleStore.Stock.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Daylon.BicycleStore.Stock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicycleController : ControllerBase
    {
        [HttpGet]
        public IActionResult<List<Bicycle>> Get()
        {
            var result = 



            return Ok();
        }
    }
}
