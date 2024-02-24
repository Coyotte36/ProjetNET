using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shared.ApiModels.VehicleModel;

namespace Shared.ApiModels
{
    public class MaintenanceModel
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public VehicleModel Vehicle { get; set; }
        public int MileageMaintenance { get; set; }
        public string WorksPerformed { get; set; }
    }
}
