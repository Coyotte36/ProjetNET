using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVehicle()
        {
            return Ok();
        }
    }
}
