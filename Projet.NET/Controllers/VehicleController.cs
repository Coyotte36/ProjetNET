﻿using Infrastructure.Data.SQLite;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Domain;
using Shared.ApiModels;
using Shared;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
            var vehicles = VehicleRepository.ToList();
            if (vehicles.Count == 0) return Ok(new List<Vehicle>());
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var vehicle = VehicleRepository
                .FirstOrDefault(x => x.Id == id);
            if (vehicle == null) return NotFound();
            return Ok(vehicle);
        }



        [HttpPost("AddVehicle")]
        public IActionResult CreateVehicle(string matriculation, string modelName, int year, int mileage,
            EnergyType energie)
        {

            if (matriculation.Length < 7 || matriculation.Length > 9)
            {
                return BadRequest("L'immatriculation doit avoir entre 7 et 9 caractères.");
            }

            if (mileage <= 0)
            {
                return BadRequest("Le kilométrage doit être un nombre positif");
            }

            // Recherche du modèle par son nom dans la base de données
            var model = _context.Models.FirstOrDefault(m => m.Name == modelName);
            if (model == null)
            {
                return BadRequest("Invalid model name.");
            }

            // Création du nouveau véhicule avec le modèle trouvé
            var newVehicle = new Vehicle()
            {
                Matriculation = matriculation,
                ModelId = model.Id,
                Year = year,
                Mileage = mileage,
                Energie = energie
            };

            // Ajout du nouveau véhicule à la base de données
            _context.Vehicles.Add(newVehicle);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public void DeleteVehicle(int id)
        {
            _context.Set<Vehicle>()
                .Remove(new Vehicle { Id = id });

            _context.SaveChanges();

        }

        [HttpPut("Edit/{id}")]
        public IActionResult UpdateVehicle(int id, int modelId, int year, int mileage, string matriculation,
            EnergyType energie)
        {
            var existingVehicle = VehicleRepository.FirstOrDefault(x => x.Id == id);

            existingVehicle.ModelId = modelId;
            existingVehicle.Year = year;
            existingVehicle.Mileage = mileage;
            existingVehicle.Matriculation = matriculation;
            existingVehicle.Energie = energie;

            _context.SaveChanges();
            return Ok();

        }
    }
}

