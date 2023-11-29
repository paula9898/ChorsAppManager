using ChorsAppManager.Backend.Application.ChoresServices;
using Microsoft.AspNetCore.Mvc;

namespace ChorsAppManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChoresController : ControllerBase
    {
        private readonly IChoresService _choreService;

<<<<<<< Updated upstream:ChorsAppManager/Controllers/WeatherForecastController.cs
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
=======
        public ChoresController(IChoresService choresService)
>>>>>>> Stashed changes:ChorsAppManager/Controllers/ChoresController.cs
        {
            _choreService = choresService;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetChoreById(int id)
        {
            var chore = await _choreService.GetChoreById(id);

            return Ok(chore);
        }
    }
}