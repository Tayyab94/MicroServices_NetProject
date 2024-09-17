using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomerController : ControllerBase
    {

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("HEllo");
        }
    }
}
