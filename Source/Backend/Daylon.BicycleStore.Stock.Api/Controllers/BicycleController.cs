using Daylon.BicycleStore.Communication.Request;
using Daylon.BicycleStore.Stock.Application.Interface;
using Daylon.BicycleStore.Stock.Exceptions;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync()
        {
            var bicycles = await _services.GetBicyclesAsync();

            if (bicycles == null || bicycles.Count == 0)
                return NotFound(ResourceMessagesException.BICYCLE_NOT_FOUND);

            return Ok(bicycles);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var bicycle = await _services.GetBicycleByIdAsync(id);

            if (bicycle == null)
                return NotFound(ResourceMessagesException.BICYCLE_NOT_FOUND);

            return Ok(bicycle);
        }

        // POST

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterBicycleAsync(
            [FromBody] RequestRegisterBicycleJson request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bicycle = await _services.RegisterBicycleAsync(request);

            return Created(string.Empty, bicycle);
        }

        // PUT

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBicycleAsync(
            [FromBody] RequestUpdateBicycleJson request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bicycle = await _services.UpdateBicycleAsync(request);

            if (bicycle == null)
                return NotFound(ResourceMessagesException.BICYCLE_NOT_FOUND);

            return Ok(bicycle);
        }

        // DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBicycleAsync(Guid id)
        {
            var bicycle = await _services.GetBicycleByIdAsync(id);

            if (bicycle == null)
                return NotFound(ResourceMessagesException.BICYCLE_NOT_FOUND);

            await _services.DeleteBicycleAsync(id);

            return NoContent();
        }
    }
}

