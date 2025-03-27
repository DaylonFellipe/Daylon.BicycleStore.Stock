using Daylon.BicycleStore.Communication.Request;
using Daylon.BicycleStore.Stock.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Daylon.BicycleStore.Stock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicycleController : ControllerBase
    {
        private readonly IBicycleService _services;

        public BicycleController(IBicycleService bicycleRepository)
        {
            _services = bicycleRepository;
        }

        // GET

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync()
        {
            var bicycles = await _services.GetBicyclesAsync();

            if (bicycles.Count == 0) return NotFound("No bicycles found");

            return Ok(bicycles);
        }

        // POST

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterBicycle(
            [FromBody] RequestRegisterBicycleJson request)
        {
            var bicycle = await _services.RegisterBicycleAsync(request);

            return Created(string.Empty, bicycle);
        }
    }
}

