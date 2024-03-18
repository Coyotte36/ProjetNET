using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.ApiModels;
using System.Reflection.Metadata;
using Server.Domain;
using Infrastructure.Data.SQLite;
using Shared;

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
            if (maintenance.Count == 0) return Ok(new List<Maintenance>());
            return Ok(maintenance);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var maintenance = MaintenanceRepository.Find(id);
            if (maintenance == null) return NotFound();
            return Ok(maintenance);
        }

        [HttpGet("ByVehicleId/{vehicleId}")]
        public IActionResult GetMaintenancesByVehicleId(int vehicleId)
        {
            var maintenances = MaintenanceRepository.Where(m => m.VehicleId == vehicleId).ToList();
            if (maintenances.Count == 0) maintenances = [];
            return Ok(maintenances);
        }
        
        [HttpPost("AddMaintenance")]
        public IActionResult CreateMaintenance(int vehicleId, int mileageMaintenance, string worksPerformed)
        {
            // Recherche du véhicule par son identifiant
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
            if (vehicle == null)
            {
                return NotFound("Vehicle not found.");
            }

            // Création de la nouvelle maintenance
            var maintenance = new Maintenance()
            {
                VehicleId = vehicleId,
                MileageMaintenance = mileageMaintenance,
                WorksPerformed = worksPerformed
            };

            // Ajout de la maintenance à la base de données
            _context.Maintenances.Add(maintenance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
