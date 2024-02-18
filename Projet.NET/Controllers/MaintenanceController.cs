using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.ApiModels;
using System.Reflection.Metadata;
using Server.Domain;
using Infrastructure.Data.SQLite;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        private DbSet<Maintenance> MaintenanceRepository => _context.Set<Maintenance>();


        [HttpGet]
        public IActionResult Get()
        {
            var maintenance = MaintenanceRepository.ToList();
            if (maintenance.Count == 0) return NoContent();
            return Ok(maintenance);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var parameter = MaintenanceRepository.Find(id);
            if (parameter == null) return NotFound();
            return Ok(parameter);
        }
    }
}
