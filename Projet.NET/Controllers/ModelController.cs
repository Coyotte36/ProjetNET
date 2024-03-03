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
            var models = ModelRepository.ToList();
            if (models.Count == 0) return NoContent();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = ModelRepository.Find(id);
            if (model == null) return NotFound();
            return Ok(model);
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

        [HttpDelete("{id}")]
        public void DeleteModel(int id)
        {
            _context.Set<Model>()
                .Remove(new Model { Id = id });

            _context.SaveChanges();

        }

    }
}
