using Infrastructure.Data.SQLite;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Domain;
using Shared.ApiModels;
using Shared;

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

        [HttpPost("AddVehicle")]
        public IActionResult CreateVehicle(Model modelId, int year, int mileage, string matriculation)
        {

            var newVehicle = new Vehicle()
            {
                ModelId = modelId,
                Year = year,
                Mileage = mileage,
                Matriculation = matriculation,
                Energie = EnergyType.Diesel
            };

            VehicleRepository.Add(newVehicle);
            _context.SaveChanges();

            return Ok();
        }

    }
}
