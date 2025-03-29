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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var bicycle = await _services.GetBicycleByIdAsync(id);

            return Ok(bicycle);
        }

        // POST

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterBicycleAsync(
            [FromBody] RequestRegisterBicycleJson request)
        {
            var bicycle = await _services.RegisterBicycleAsync(request);

            return Created(string.Empty, bicycle);
        }

        // PUT

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateBicycleAsync(
            [FromBody] RequestUpdateBicycleJson request)
        {
            var bicycle = await _services.UpdateBicycleAsync(request);

            return Ok(bicycle);
        }

        // DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBicycleAsync(Guid id)
        {
            await _services.DeleteBicycleAsync(id);

            return NoContent();
        }
    }
}

