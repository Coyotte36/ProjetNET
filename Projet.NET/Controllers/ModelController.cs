using Infrastructure.Data.SQLite;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Domain;
using Shared;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        private DbSet<Model> ModelRepository => _context.Set<Model>();


        [HttpGet]
        public IActionResult Get()
        {
            var maintenance = ModelRepository.ToList();
            if (maintenance.Count == 0) return NoContent();
            return Ok(maintenance);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var parameter = ModelRepository.Find(id);
            if (parameter == null) return NotFound();
            return Ok(parameter);
        }

        [HttpPost("AddModel")]
        public IActionResult CreateModel(string name, BrandName brand, int maintenanceFrequency, string description)
        {

            var newModel = new Model()
            {
                Name = name,
                Brand = brand,
                MaintenanceFrequency = maintenanceFrequency,
                Description = description
            };

            ModelRepository.Add(newModel);
            _context.SaveChanges();

            return Ok();
        }
    }
}
