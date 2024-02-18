using Infrastructure.Data.SQLite;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Domain;
using Shared.ApiModels;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        private DbSet<Vehicle> VehicleRepository => _context.Set<Vehicle>();


        [HttpGet]
        public IActionResult Get()
        {
            var maintenance = VehicleRepository.ToList();
            if (maintenance.Count == 0) return NoContent();
            return Ok(maintenance);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var parameter = VehicleRepository.Find(id);
            if (parameter == null) return NotFound();
            return Ok(parameter);
        }
    }
}
