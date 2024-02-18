using Shared.ApiModels;
using Shared;

namespace Server.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public ModelModel Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Matriculation { get; set; }
        public EnergyType Energie { get; set; }
    }
}
