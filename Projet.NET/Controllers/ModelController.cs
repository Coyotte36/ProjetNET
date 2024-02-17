using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Projet.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetModels()
        {
            return Ok();
        }
    }
}
