using Shared.ApiModels;

namespace Server.Domain
{
    public class Maintenance
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int MileageMaintenance { get; set; }
        public string WorksPerformed { get; set; }
    }
}
