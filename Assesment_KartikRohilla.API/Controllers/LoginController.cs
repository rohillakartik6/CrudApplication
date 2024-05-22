using Assesment_KartikRohilla.Application.Services.Interface;
using Assesment_KartikRohilla.Model;
using Assesment_KartikRohilla.SharedLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_KartikRohilla.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService service;
        public LoginController(ILoginService service)
        {
            this.service = service;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login model)
        {
            ApiResponse response = new();
            var data = await service.Login(model);
            return Ok(data);
        }
    }
}
