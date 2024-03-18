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
            if (models.Count == 0) return Ok(new List<Model>());
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
            
            if (name.Length < 1)
            {
                return BadRequest("Le nom du modèle doit avoir au moins 1 caractère");
            }

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

        [HttpPut("Edit/{id}")]
        public IActionResult UpdateModel(int id, string name, BrandName brand, int maintenanceFrequency, string description)
        {
            var existingModel = ModelRepository.FirstOrDefault(x => x.Id == id);

            existingModel.Name = name;
            existingModel.Brand = brand;
            existingModel.MaintenanceFrequency = maintenanceFrequency;
            existingModel.Description = description;

            _context.SaveChanges();
            return Ok();

        }

    }
}
