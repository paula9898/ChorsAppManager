using ChorsAppManager.Backend.Application.ChoresServices;
using Microsoft.AspNetCore.Mvc;

namespace ChorsAppManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChoresController : ControllerBase
    {
        private readonly IChoresService _choreService;

        public ChoresController(IChoresService choresService)

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