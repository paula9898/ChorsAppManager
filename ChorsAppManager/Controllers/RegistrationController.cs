using ChorsAppManager.Backend.Application.RegistrationUserService;
using ChorsAppManager.Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ChorsAppManager.Backend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegistrationController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto model)
        {
            
                var result = await _registerService.RegisterUser(model);

                if(result)
                {
                   
                }
            return Ok("Registration successful");
        }

    }
}
