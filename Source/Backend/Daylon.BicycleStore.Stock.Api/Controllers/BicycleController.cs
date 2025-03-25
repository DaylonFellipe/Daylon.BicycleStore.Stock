using Daylon.BicycleStore.Stock.Domain.Entity;
using Daylon.BicycleStore.Stock.Domain.Repositories.Bicycle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Daylon.BicycleStore.Stock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicycleController : ControllerBase
    {
        private readonly IBicycleRepository _bicycleRepository;

        public BicycleController(IBicycleRepository bicycleRepository)
        {
            _bicycleRepository = bicycleRepository;
        }


        [HttpGet]
        public async Task<List<Bicycle>> Get()
        {
            var result = await _bicycleRepository.GetBicyclesAsync();

            return result;
        }
    }
}
