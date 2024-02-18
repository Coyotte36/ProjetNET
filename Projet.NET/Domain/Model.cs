using Shared.ApiModels;

namespace Server.Domain
{
    public class Model
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int MaintenanceFrequency { get; set; }
        public string Description { get; set; }
    }
}
