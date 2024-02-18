using Shared.ApiModels;
using Shared;
using System.Text.Json.Serialization;

namespace Server.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Matriculation { get; set; }
        public EnergyType Energie { get; set; }
        [JsonIgnore] public IList<MaintenanceModel> Maintenance { get; set; } = new List<MaintenanceModel>();
    }
}
